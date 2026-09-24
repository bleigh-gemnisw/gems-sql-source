Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXSUPPCQ As TXSUPPCQ.MyData
  Dim ds As DataSet = New DataSet
  Dim DsFile As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkType As String
  Public Sub PrtReport()
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXSUPPCQ = New TXSUPPCQ.MyData(myDBConnect)

    With MyFrmTX501B
      If .RbRE.Checked Then WrkType = "R"
      If .RbPP.Checked Then WrkType = "P"
      If .RbMV.Checked Then WrkType = "M"
      If .RbSU.Checked Then WrkType = "S"
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkType = WrkType
    MyCrViewer.Show()
  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Add1", Type.GetType("System.String"))
      .Columns.Add("Add2", Type.GetType("System.String"))
      .Columns.Add("City", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("Zip", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "BTC <> '  '"
    Select Case WrkType
      Case "R"
        DsFile = myTXREALCQ.GetQry("NAME", WrkQry, 0)
      Case "P"
        DsFile = myTXPPRPCQ.GetQry("NAME", WrkQry, 0)
      Case "M"
        DsFile = myTXMVDCQ.GetQry("NAME", WrkQry, 0)
      Case "S"
        DsFile = myTXSUPPCQ.GetQry("NAME", WrkQry, 0)
    End Select
    If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("name") = .Item("name")
        dr.Item("add1") = .Item("add1")
        dr.Item("add2") = .Item("add2")
        dr.Item("city") = .Item("city")
        dr.Item("state") = .Item("state")
        sb = New StringBuilder
        sb.Append(Format(.Item("zip5"), "00000"))
        If .Item("zip4") > 0 Then
          sb.Append("-")
          sb.Append(Format(.Item("zip4"), "0000"))
        End If
        dr.Item("zip") = sb.ToString
        sb = Nothing
        Select Case WrkType
          Case "R", "P"
            dr.Item("propdesc") = Trim(.Item("loc#")) & " " & .Item("loc")
          Case "M", "S"
            dr.Item("propdesc") = Trim(.Item("regno")) & " " & .Item("make") & " " & .Item("model")
        End Select
        ds.Tables(0).Rows.Add(dr)
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsFile.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    myTXREALCQ.CloseFile()
    myTXPPRPCQ.CloseFile()
    myTXMVDCQ.CloseFile()
    myTXSUPPCQ.CloseFile()

  End Sub
End Module






