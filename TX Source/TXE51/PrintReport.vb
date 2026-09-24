Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXINV As TXINV.MyData
Dim MyUTBLHS As UTBLHS.myData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkSelection As String
Dim WrkBatchNo As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount As Integer
Dim WrkTPrinPaid As Decimal
Dim WrkTBrkAmt1 As Decimal
Dim WrkTBrkAmt2 As Decimal
Dim WrkTBrkAmt3 As Decimal
Dim WrkTBrkAmt4 As Decimal
Dim WrkTBrkAmt5 As Decimal
Dim WrkTBrkAmt6 As Decimal
Dim WrkBrkAmt(5) As Decimal
Dim WrkBrkPct(5) As Decimal
Dim WrkBrkCode(5) As String
Public Sub PrtReport()

  myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  MyUTBLHS = New UTBLHS.mydata(MyDBConnect)

  With MyFrmTXE51B
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    If .RbAll.Checked Then
      WrkSelection = ""
    End If
    If .RbAdjustments.Checked Then
      WrkSelection = "Adjustments"
    End If
    If .RbPayments.Checked Then
      WrkSelection = "Payments"
    End If
    If .RbRefunds.Checked Then
      WrkSelection = "Refunds"
    End If
    If .RbLiens.Checked Then
      WrkSelection = "Liens"
    End If
    If .RbSuspense.Checked Then
      WrkSelection = "Suspense"
    End If
    If .RbVoids.Checked Then
      WrkSelection = "Voids"
    End If
    If .RbTransfers.Checked Then
      WrkSelection = "Transfers"
    End If
    WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS()
  Else
    ds1.Clear()
    ds2.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds1
  MyCrViewer.wrkds2 = ds2
  MyCrViewer.WrkSelection = WrkSelection
  MyCrViewer.WrkBrkDesc1 = WrkBrkCode(0)
  MyCrViewer.WrkBrkDesc2 = WrkBrkCode(1)
  MyCrViewer.WrkBrkDesc3 = WrkBrkCode(2)
  MyCrViewer.WrkBrkDesc4 = WrkBrkCode(3)
  MyCrViewer.WrkBrkDesc5 = WrkBrkCode(4)
  MyCrViewer.WrkBrkDesc6 = WrkBrkCode(5)
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Comment", Type.GetType("System.String"))
      .Columns.Add("Reference", Type.GetType("System.String"))
      .Columns.Add("PrinPaid", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt1", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt2", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt3", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt4", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt5", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt6", Type.GetType("System.Decimal"))
      .Columns.Add("PenPaid", Type.GetType("System.Decimal"))
      .Columns.Add("DatePaid", Type.GetType("System.DateTime"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TPrinPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TBrkAmt1", Type.GetType("System.Decimal"))
      .Columns.Add("TBrkAmt2", Type.GetType("System.Decimal"))
      .Columns.Add("TBrkAmt3", Type.GetType("System.Decimal"))
      .Columns.Add("TBrkAmt4", Type.GetType("System.Decimal"))
      .Columns.Add("TBrkAmt5", Type.GetType("System.Decimal"))
      .Columns.Add("TBrkAmt6", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTCount = 0
  WrkTPrinPaid = 0
  WrkTBrkAmt1 = 0
  WrkTBrkAmt2 = 0
  WrkTBrkAmt3 = 0
  WrkTBrkAmt4 = 0
  WrkTBrkAmt5 = 0
  WrkTBrkAmt6 = 0
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
    Dim SaveYear As Integer
    Dim SaveType As String
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Select Case WrkSelection
Case "Suspense"
  WrkQry = "RCODE ='S'" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
Case "Voids"
  WrkQry = "RCODE ='V'" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
Case "Transfers"
  WrkQry = "PRF ='TXA12'" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
Case Else
  WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd & _
    "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
End Select

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If

MyTypes = MyFrmTXE51B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    If WrkBatchNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkBatchNo
End If

WrkSort = "YEAR, TYPE, DIST, LIST#"
myTXHSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveType = ""
ReadNext:
  myTXHSTQ.ReadQry()
  If Not myTXHSTQ.IsEOF Then
  With myTXHSTQ
    Counter = Counter + 1
    dr = ds1.Tables(0).NewRow
    If SaveType <> "" And SaveType <> ._TYPE Then
      WriteTotals(SaveYear, SaveType)
      ClearTotals()
    End If
    If SaveYear > 0 And SaveYear <> ._YEAR Then
      WriteTotals(SaveYear, SaveType)
      ClearTotals()
    End If
    SaveYear = ._YEAR
    SaveType = ._TYPE

'Filter records based on selection
    Select Case WrkSelection
    Case "Adjustments"
      If ._ADJCD <> "A" Then GoTo NextRec
    Case "Liens"
      If ._LAMT = 0 Then GoTo NextRec
    Case "Payments"
      If ._PAMT <= 0 Then GoTo NextRec
    Case "Refunds"
      If ._ADJCD <> "R" Then GoTo NextRec
    Case Else
    End Select

    WrkTCount = WrkTCount + 1
    dr.Item("listno") = ._LISTNo
    dr.Item("year") = ._YEAR
    dr.Item("type") = ._TYPE
    dr.Item("comment") = Trim(._COMM)
    dr.Item("reference") = ._REF
    dr.Item("prinpaid") = ._PAMT
    MyUTBLHS.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
    If Not MyUTBLHS.RecordNotFound And ._PAMT <> 0 Then
      SplitAmt(._PAMT)
      dr.Item("brkamt1") = WrkBrkAmt(0)
      dr.Item("brkamt2") = WrkBrkAmt(1)
      dr.Item("brkamt3") = WrkBrkAmt(2)
      dr.Item("brkamt4") = WrkBrkAmt(3)
      dr.Item("brkamt5") = WrkBrkAmt(4)
      dr.Item("brkamt6") = WrkBrkAmt(5)
    Else
      dr.Item("brkamt1") = 0
      dr.Item("brkamt2") = 0
      dr.Item("brkamt3") = 0
      dr.Item("brkamt4") = 0
      dr.Item("brkamt5") = 0
      dr.Item("brkamt6") = 0
    End If
    dr.Item("reference") = Trim(._REF)
    dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
    dr.Item("batchno") = ._BATCHN
    myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        dr.Item("name") = Trim(._NAME)
      End With
    End If
    WrkTPrinPaid = WrkTPrinPaid + ._PAMT
    WrkTBrkAmt1 = WrkTBrkAmt1 + WrkBrkAmt(0)
    WrkTBrkAmt2 = WrkTBrkAmt2 + WrkBrkAmt(1)
    WrkTBrkAmt3 = WrkTBrkAmt3 + WrkBrkAmt(2)
    WrkTBrkAmt4 = WrkTBrkAmt4 + WrkBrkAmt(3)
    WrkTBrkAmt5 = WrkTBrkAmt5 + WrkBrkAmt(4)
    WrkTBrkAmt6 = WrkTBrkAmt6 + WrkBrkAmt(5)
  End With
  ds1.Tables(0).Rows.Add(dr)
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

WriteTotals(SaveYear, SaveType)
myFrmProgress.Close()

CloseFiles:
myTXHSTQ.CloseFile()
myTXINV.CloseFile()

End Sub
Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
  If WrkTCount = 0 Then Exit Sub

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("year") = SaveYear
  dr2.Item("type") = SaveType
  dr2.Item("tprinpaid") = WrkTPrinPaid
  dr2.Item("tbrkamt1") = WrkTBrkAmt1
  dr2.Item("tbrkamt2") = WrkTBrkAmt2
  dr2.Item("tbrkamt3") = WrkTBrkAmt3
  dr2.Item("tbrkamt4") = WrkTBrkAmt4
  dr2.Item("tbrkamt5") = WrkTBrkAmt5
  dr2.Item("tbrkamt6") = WrkTBrkAmt6
  ds2.Tables(0).Rows.Add(dr2)
End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Sub SplitAmt(ByVal WrkPaid As Decimal)
    Dim I As Integer
    Dim WrkTotBrk As Decimal
    Dim WrkDiff As Decimal

    WrkBrkPct(0) = MyUTBLHS._AMT1 / MyUTBLHS._BLAMT
    WrkBrkAmt(0) = MyUtils.Round(WrkPaid * WrkBrkPct(0), 2)
    WrkBrkCode(0) = Trim(MyUTBLHS._CODE1)
    WrkBrkPct(1) = MyUTBLHS._AMT2 / MyUTBLHS._BLAMT
    WrkBrkAmt(1) = MyUtils.Round(WrkPaid * WrkBrkPct(1), 2)
    WrkBrkCode(1) = Trim(MyUTBLHS._CODE2)
    WrkBrkPct(2) = MyUTBLHS._AMT3 / MyUTBLHS._BLAMT
    WrkBrkAmt(2) = MyUtils.Round(WrkPaid * WrkBrkPct(2), 2)
    WrkBrkCode(2) = Trim(MyUTBLHS._CODE3)
    WrkBrkPct(3) = MyUTBLHS._AMT4 / MyUTBLHS._BLAMT
    WrkBrkAmt(3) = MyUtils.Round(WrkPaid * WrkBrkPct(3), 2)
    WrkBrkCode(3) = Trim(MyUTBLHS._CODE4)
    WrkBrkPct(4) = MyUTBLHS._AMT5 / MyUTBLHS._BLAMT
    WrkBrkAmt(4) = MyUtils.Round(WrkPaid * WrkBrkPct(4), 2)
    WrkBrkCode(4) = Trim(MyUTBLHS._CODE5)
    WrkBrkPct(5) = MyUTBLHS._AMT6 / MyUTBLHS._BLAMT
    WrkBrkAmt(5) = MyUtils.Round(WrkPaid * WrkBrkPct(5), 2)
    WrkBrkCode(5) = Trim(MyUTBLHS._CODE6)
    WrkTotBrk = 0
    For I = 0 To 5
      WrkTotBrk = WrkTotBrk + WrkBrkAmt(I)
    Next

    WrkDiff = WrkPaid - WrkTotBrk
    If WrkDiff = 0 Then Exit Sub

    For I = 0 To 5
      If WrkBrkAmt(I) > 0 Then
        WrkBrkAmt(I) = WrkBrkAmt(I) + WrkDiff
        Exit For
      End If
    Next

  End Sub
End Module






