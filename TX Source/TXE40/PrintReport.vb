Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXINV As TXINV.myData
Dim dsCash As DataSet = New DataSet
Dim dsCheck As DataSet = New DataSet
Dim dsCredit As DataSet = New DataSet
Dim dsSplit As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drTot As Data.DataRow

Dim WrkType As String
Dim WrkFromGLYear As Integer
Dim WrkToGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkSelection As String
Dim WrkSelBatchNo As Integer
Dim WrkSelListNo As Integer
Dim WrkSelCustID As Long
Dim WrkSelName As String
Dim WrkAnd As String
Dim WrkOr As String

Dim WrkTCount(2) As Integer
Dim WrkTTotPaid(2) As Decimal
'Dim WrkTPrinPaid(2) As Decimal
'Dim WrkTPenPaid(2) As Decimal
'Dim WrkTIntPaid(2) As Decimal
'Dim WrkTLienPaid(2) As Decimal
Public Sub PrtReport()

	myTXHSTQ = New TXHSTQ.mydata(MyDBConnect)
	myTXINV = New TXINV.mydata(MyDBConnect)

  With MyFrmTXE40B
    WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
    WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkSelBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
    WrkSelListNo = MyUtils.CnvSng(.TxtListNo.Text)
    WrkSelCustID = MyUtils.CnvSng(.TxtCustID.Text)
    WrkSelName = .TxtName.Text
  End With

  If dsCash.Tables.Count = 0 Then
    BuildDS()
  Else
    dsCash.Clear()
    dsCheck.Clear()
    dsCredit.Clear()
    dsSplit.Clear()
    dsTot.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkdsCash = dsCash
  MyCrViewer.wrkdsCheck = dsCheck
  MyCrViewer.wrkdsCredit = dsCredit
  MyCrViewer.wrkdsSplit = dsSplit
  MyCrViewer.wrkdsTot = dsTot
  MyCrViewer.WrkListNo = WrkSelListNo
  MyCrViewer.WrkCustID = WrkSelCustID
  MyCrViewer.WrkName = WrkSelName
  MyCrViewer.Show()

End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    Dim myTable3 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("Reference", Type.GetType("System.String"))
      .Columns.Add("PrinPaid", Type.GetType("System.Decimal"))
      .Columns.Add("PenPaid", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("LienPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TotPaid", Type.GetType("System.Decimal"))
      .Columns.Add("DatePaid", Type.GetType("System.DateTime"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
    End With
    dsCash.Tables.Add(myTable)
    dsCheck = dsCash.Clone
    dsCredit = dsCash.Clone

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCorc", Type.GetType("System.String"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TPrinPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TPenPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TIntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TLienPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TTotPaid", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTable2)

    With myTable3
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("Cash", Type.GetType("System.Decimal"))
      .Columns.Add("Check", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("DatePaid", Type.GetType("System.DateTime"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      dsSplit.Tables.Add(myTable3)
    End With
  End Sub
Private Sub ClearTotals()
  Array.Clear(WrkTCount, 0, 3)
  Array.Clear(WrkTTotPaid, 0, 3)
  'Array.Clear(WrkTPrinPaid, 0, 3)
  'Array.Clear(WrkTPenPaid, 0, 3)
  'Array.Clear(WrkTIntPaid, 0, 3)
  'Array.Clear(WrkTLienPaid, 0, 3)
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
'Dim K As Integer
Dim WrkTypes As String
Dim WrkFamily As String
Dim WrkName As String
Dim WrkPropDesc As String

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

Counter = 0
WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd & _
  "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo

If WrkFromGLYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
End If

If WrkSelListNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "LIST#= " & WrkSelListNo
End If

If WrkSelBatchNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkSelBatchNo
End If

MyTypes = MyFrmTXE40B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "PDATE, LIST#"
myTXHSTQ.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myTXHSTQ.ReadQry()
  If Not myTXHSTQ.IsEOF Then
  With myTXHSTQ
    Counter = Counter + 1
    myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
    WrkName = ""
    WrkPropDesc = ""
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        'Filter records based on selection
        If WrkSelCustID > 0 Then
          If WrkSelCustID <> ._SSNo And WrkSelCustID <> ._SS2 Then
            GoTo NextRec
          End If
        End If

        If WrkSelName <> "" Then
          If WrkSelName <> Trim(._NAME) Then
            GoTo NextRec
          End If
        End If

        WrkName = Trim(._NAME)
        WrkFamily = GetTXTypeFamily(._TYPE)
        Select Case WrkFamily
        Case "M", "S"
          WrkPropDesc = Trim(._IMVREG)
        Case Else
          WrkPropDesc = Trim(._LOCNo) & " " & Trim(._LOC)
        End Select
      End With
    End If

    If ._CASH <> 0 Then
      dr = dsCash.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("type") = ._TYPE
      dr.Item("name") = WrkName
      dr.Item("propdesc") = WrkPropDesc
      'dr.Item("prinpaid") = ._PAMT
      'dr.Item("penpaid") = ._PCAMT
      'dr.Item("intpaid") = ._IAMT
      'dr.Item("lienpaid") = ._LAMT
      dr.Item("totpaid") = ._CASH
      dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
      dr.Item("batchno") = ._BATCHN
      'WrkTPrinPaid(K) = WrkTPrinPaid(K) + ._PAMT
      'WrkTPenPaid(K) = WrkTPenPaid(K) + ._PCAMT
      'WrkTIntPaid(K) = WrkTIntPaid(K) + ._IAMT
      'WrkTLienPaid(K) = WrkTLienPaid(K) + ._LAMT
      WrkTCount(0) = WrkTCount(0) + 1
      WrkTTotPaid(0) = WrkTTotPaid(0) + ._CASH
      dsCash.Tables(0).Rows.Add(dr)
      dr = Nothing
    End If

    If ._CHECK <> 0 Then
      dr = dsCheck.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("type") = ._TYPE
      dr.Item("name") = WrkName
      dr.Item("propdesc") = WrkPropDesc
      'dr.Item("prinpaid") = ._PAMT
      'dr.Item("penpaid") = ._PCAMT
      'dr.Item("intpaid") = ._IAMT
      'dr.Item("lienpaid") = ._LAMT
      dr.Item("totpaid") = ._CHECK
      dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
      dr.Item("batchno") = ._BATCHN
      'WrkTPrinPaid(K) = WrkTPrinPaid(K) + ._PAMT
      'WrkTPenPaid(K) = WrkTPenPaid(K) + ._PCAMT
      'WrkTIntPaid(K) = WrkTIntPaid(K) + ._IAMT
      'WrkTLienPaid(K) = WrkTLienPaid(K) + ._LAMT
      WrkTCount(1) = WrkTCount(1) + 1
      WrkTTotPaid(1) = WrkTTotPaid(1) + ._CHECK
      dsCheck.Tables(0).Rows.Add(dr)
      dr = Nothing
    End If

    If ._CREDIT <> 0 Then
      dr = dsCredit.Tables(0).NewRow
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("type") = ._TYPE
      dr.Item("name") = WrkName
      dr.Item("propdesc") = WrkPropDesc
      'dr.Item("prinpaid") = ._PAMT
      'dr.Item("penpaid") = ._PCAMT
      'dr.Item("intpaid") = ._IAMT
      'dr.Item("lienpaid") = ._LAMT
      dr.Item("totpaid") = ._CREDIT
      dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
      dr.Item("batchno") = ._BATCHN
      'WrkTPrinPaid(K) = WrkTPrinPaid(K) + ._PAMT
      'WrkTPenPaid(K) = WrkTPenPaid(K) + ._PCAMT
      'WrkTIntPaid(K) = WrkTIntPaid(K) + ._IAMT
      'WrkTLienPaid(K) = WrkTLienPaid(K) + ._LAMT
      WrkTCount(2) = WrkTCount(2) + 1
      WrkTTotPaid(2) = WrkTTotPaid(2) + ._CREDIT
      dsCredit.Tables(0).Rows.Add(dr)
      dr = Nothing
    End If

    'Split Detail
    dr = dsSplit.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    dr.Item("year") = ._YEAR
    dr.Item("type") = ._TYPE
    If Not myTXINV.RecordNotFound Then
      With myTXINV
        dr.Item("name") = Trim(._NAME)
        WrkFamily = GetTXTypeFamily(._TYPE)
        Select Case WrkFamily
        Case "M", "S"
          dr.Item("propdesc") = Trim(._IMVREG)
        Case Else
          dr.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
        End Select
      End With
    End If
    dr.Item("cash") = ._CASH
    dr.Item("check") = ._CHECK
    dr.Item("credit") = ._CREDIT
    dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
    dr.Item("batchno") = ._BATCHN
    dsSplit.Tables(0).Rows.Add(dr)
    dr = Nothing
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

WriteTotals()
myFrmProgress.Close()

CloseFiles:
myTXHSTQ.CloseFile()
myTXINV.CloseFile()

End Sub
Private Sub WriteTotals()
  Dim I As Integer

  For I = 0 To 2
    If WrkTCount(I) = 0 Then Continue For
    drTot = dsTot.Tables(0).NewRow
    Select Case I
    Case 0
      drTot.Item("tcorc") = "Cash"
    Case 1
      drTot.Item("tcorc") = "Check"
    Case 2
      drTot.Item("tcorc") = "Credit"
    End Select
    drTot.Item("tcount") = WrkTCount(I)
    'drTot.Item("tprinpaid") = WrkTPrinPaid(I)
    'drTot.Item("tpenpaid") = WrkTPenPaid(I)
    'drTot.Item("tintpaid") = WrkTIntPaid(I)
    'drTot.Item("tlienpaid") = WrkTLienPaid(I)
    drTot.Item("ttotpaid") = WrkTTotPaid(I) 'WrkTPrinPaid(I) + WrkTPenPaid(I) + WrkTIntPaid(I) + WrkTLienPaid(I)
    dsTot.Tables(0).Rows.Add(drTot)
  Next
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

End Module






