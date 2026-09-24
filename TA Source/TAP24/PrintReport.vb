Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXDCPPQ As TXDCPPQ.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkYear As Integer
  Dim WrkFiling As String
  Dim WrkAppStatus As String
  Public Sub PrtReportSU()

    myTXDCPPQ = New TXDCPPQ.MyData(myDBConnect)

    With MyFrmTAP24B
      WrkYear = .TxtGLYear.Text
      If .RBFileAll.Checked Then WrkFiling = "All"
      If .RbFileExt.Checked Then WrkFiling = "E"
      If .RbFileLate.Checked Then WrkFiling = "L"
      If .RbFileNon.Checked Then WrkFiling = "N"
      If .RbFileOntime.Checked Then WrkFiling = " "
      If .RbStatAll.Checked Then WrkAppStatus = "All"
      If .RbStatActive.Checked Then WrkAppStatus = " "
      If .RbStatInact.Checked Then WrkAppStatus = "I"
      If .RbStatIncr.Checked Then WrkAppStatus = "C"
      If .RbStatPend.Checked Then WrkAppStatus = "P"
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkFiling = WrkFiling
      .WrkAppStatus = WrkAppStatus
      .Show()
    End With

  End Sub
  Friend Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("DBA", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Proploc", Type.GetType("System.String"))
      .Columns.Add("Filing", Type.GetType("System.String"))
      .Columns.Add("AppStatus", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim Counter As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "YEAR = " & WrkYear
    If Not MyFrmTAP24B.RBFileAll.Checked Then
      WrkQry = WrkQry & WrkAnd & "FILSTS = " & MyUtils.Quo(WrkFiling)
    End If
    If Not MyFrmTAP24B.RbStatAll.Checked Then
      WrkQry = WrkQry & WrkAnd & "STATUS = " & MyUtils.Quo(WrkAppStatus)
    End If

    myTXDCPPQ.OpenQry("LIST#", WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXDCPPQ.ReadQry()
    If Not myTXDCPPQ.IsEOF Then
      With myTXDCPPQ
        Counter = Counter + 1
        dr = ds.Tables(0).NewRow
        dr.Item("Listno") = ._LISTNO
        dr.Item("Name") = Trim(._OWNAME)
        dr.Item("DBA") = Trim(._DBA)
        dr.Item("Sname") = Trim(._OWNAME)
        dr.Item("PropLoc") = Trim(._LOCNO) & " " & Trim(._LOC)
        dr.Item("Filing") = GetFilingDesc(Trim(._FILSTS))
        dr.Item("AppStatus") = GetStatusDesc(Trim(._STATUS))
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    myFrmProgress.Close()
    myTXDCPPQ.CloseFile()

  End Sub
End Module






