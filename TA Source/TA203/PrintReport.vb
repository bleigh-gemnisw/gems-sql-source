Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.myData
  Dim myTXREALCQ As TXREALCQ.myData
  Dim myTXREAAQ As TXREAAQ.myData
  Dim myTXPPRPQ As TXPPRPQ.myData
  Dim myTXPPRPCQ As TXPPRPCQ.myData
  Dim myTXPPRAQ As TXPPRAQ.myData
  Dim myTXMVDQ As TXMVDQ.myData
  Dim myTXMVDCQ As TXMVDCQ.myData
  Dim myTXMVAQ As TXMVAQ.myData
  Dim myTXSUPPQ As TXSUPPQ.myData
  Dim myTXSUPAQ As TXSUPAQ.myData
  Dim ds As DataSet = New DataSet
  Dim DsFile As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkGross As Boolean
  Dim WrkMVPublic As Boolean
  'Screen fields
  Dim WrkNo As Integer
  Dim WrkMin As Integer
  Dim WrkMax As Integer
  Dim WrkFile As String
  Dim WrkGLYear As Integer
  Public Sub PrtReport()
    Dim WrkType As String
    myTXREALQ = New TXREALQ.mydata(MyDBConnect)
    myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
    myTXREAAQ = New TXREAAQ.mydata(MyDBConnect)
    myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)
    myTXPPRAQ = New TXPPRAQ.mydata(MyDBConnect)
    myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
    myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)
    myTXMVAQ = New TXMVAQ.mydata(MyDBConnect)
    myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
    myTXSUPAQ = New TXSUPAQ.mydata(MyDBConnect)

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    With MyFrmTA203B
      WrkNo = MyUtils.CnvSng(.TxtNo.Text)
      WrkMin = MyUtils.CnvSng(.TxtMin.Text)
      WrkMax = MyUtils.CnvSng(.TxtMax.Text)
      WrkFile = .CboFile.SelectedItem.ToString
      WrkGLYear = 0
      If .TxtGLYear.Enabled Then
        WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      End If
      If .ChkMVPublic.Checked Then
          WrkMVPublic = True
        Else
          WrkMVPublic = False
      End If
      If .RbGross.Checked Then
        WrkGross = True
      Else
        WrkGross = False
      End If
      WrkType = ""
      'Run Report
      If .RbRE.Checked Then
        WrkType = "R"
        GetDetail("R")
      End If
      If .RbPP.Checked Then
        WrkType = "P"
        GetDetail("P")
      End If
      If .RbMV.Checked Then
        WrkType = "M"
        GetDetail("M")
      End If
      If .RbSU.Checked Then
        WrkType = "S"
        GetDetail("S")
      End If
      If .RbAll.Checked Then
        WrkType = "*"
        GetDetail("R")
        GetDetail("P")
        GetDetail("M")
        CombineFiles()
      End If
    End With

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkType = WrkType
    MyCrViewer.WrkFile = WrkFile
    MyCrViewer.WrkGLYear = WrkGLYear
    MyCrViewer.WrkGross = WrkGross
    MyCrViewer.Show()
  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("Assmnt", Type.GetType("System.Int64"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail(ByVal WrkType As String)
    Dim WrkQry As String
    Dim WrkFldSort As String
    Dim WrkTypeDesc As String
    Dim I As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    WrkTypeDesc = ""
    Select Case WrkType
      Case "R"
        WrkQry = "CAT='1'"
        If WrkGross Then
          WrkFldSort = "GROSS"
        Else
          WrkFldSort = "NET"
        End If
        WrkTypeDesc = "Real Estate"
        Select Case WrkFile
          Case "Regular"
            DsFile = myTXREALQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Frozen"
            DsFile = myTXREALCQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Archive"
            WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkGLYear)
            DsFile = myTXREAAQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
        End Select
      Case "P"
        WrkTypeDesc = "Personal Property"
        WrkQry = "CAT='5'"
        If WrkGross Then
          WrkFldSort = "GROSS"
        Else
          WrkFldSort = "NET"
        End If
        Select Case WrkFile
          Case "Regular"
            DsFile = myTXPPRPQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Frozen"
            DsFile = myTXPPRPCQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Archive"
            WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkGLYear)
            DsFile = myTXPPRAQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
        End Select
      Case "M"
        WrkQry = "CAT='1'"
        WrkTypeDesc = "Motor Vehicle"
        If WrkGross Then
          WrkFldSort = "VALUE"
        Else
          WrkFldSort = "VALUE"
        End If
        Select Case WrkFile
          Case "Regular"
            DsFile = myTXMVDQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Frozen"
            DsFile = myTXMVDCQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Archive"
            WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkGLYear)
            DsFile = myTXMVAQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
        End Select
      Case "S"
        WrkQry = "CAT='1'"
        WrkTypeDesc = "Supplemental MV"
        If WrkGross Then
          WrkFldSort = "VALUE"
        Else
          WrkFldSort = "VALUE"
        End If
        Select Case WrkFile
          Case "Regular"
            DsFile = myTXSUPPQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
          Case "Archive"
            WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkGLYear)
            DsFile = myTXSUPAQ.GetQry(WrkFldSort & " desc", WrkQry, WrkNo)
        End Select
    End Select
    If DsFile.Tables(0).Rows.Count = 0 Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = myFrmProgress.Text & "- Type " & WrkType
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsFile.Tables(0).Rows.Count - 1)
      With DsFile.Tables(0).Rows(I)
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = .Item("list#")
        dr.Item("name") = .Item("name")
        Select Case WrkType
          Case "R", "P"
            dr.Item("propdesc") = Trim(.Item("loc#")) & " " & .Item("loc")
            If WrkGross Then
              dr.Item("assmnt") = .Item("gross")
            Else
              dr.Item("assmnt") = .Item("net")
            End If
          Case "M", "S"
            If WrkMVPublic Then
              dr.Item("propdesc") = Trim(.Item("regno")) & " " & .Item("year") & " " & .Item("make") & " " & .Item("model")
            Else
              dr.Item("propdesc") = .Item("year") & " " & .Item("make") & " " & .Item("model")
            End If
            dr.Item("assmnt") = .Item("value")
        End Select
        If WrkMax > 0 Then
          If dr.Item("assmnt") > WrkMax Then
            Continue For
          End If
        End If
        If WrkMin > 0 Then
          If dr.Item("assmnt") < WrkMin Then
            Continue For
          End If
        End If
        If MyFrmTA203B.RbAll.Checked Then
          dr.Item("typedesc") = WrkTypeDesc
        Else
          dr.Item("typedesc") = ""
        End If
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
    myTXREALQ.CloseFile()
    myTXREALCQ.CloseFile()
    myTXREAAQ.CloseFile()
    myTXPPRPQ.CloseFile()
    myTXPPRPCQ.CloseFile()
    myTXPPRAQ.CloseFile()
    myTXMVDQ.CloseFile()
    myTXMVDCQ.CloseFile()
    myTXMVAQ.CloseFile()
    myTXSUPPQ.CloseFile()
    myTXSUPAQ.CloseFile()
  End Sub
  Private Sub CombineFiles()
    Dim TempTable As New DataTable
    Dim dv As DataView
    Dim I As Integer
    TempTable = ds.Tables(0)
    dv = TempTable.DefaultView
    dv.Sort = "Assmnt DESC"
    TempTable = dv.ToTable
    ds.Tables(0).Clear()
    If WrkNo = 0 Then
      WrkNo = TempTable.Rows.Count
    End If

    For I = 0 To WrkNo - 1
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = TempTable.Rows(I).Item("listno")
      dr.Item("name") = TempTable.Rows(I).Item("name")
      dr.Item("propdesc") = TempTable.Rows(I).Item("propdesc")
      dr.Item("assmnt") = TempTable.Rows(I).Item("assmnt")
      dr.Item("typedesc") = TempTable.Rows(I).Item("typedesc")
      ds.Tables(0).Rows.Add(dr)
    Next
  End Sub
End Module






