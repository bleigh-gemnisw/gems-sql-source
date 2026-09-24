Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myBDMASTQ As BDMASTQ.myData
Dim myBDRATE As BDRATE.myData

Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkSelType As String
Dim WrkCash As Boolean
Dim WrkCheck As Boolean
Dim WrkCredit As Boolean
Dim WrkAnd As String
Dim WrkOr As String
Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dr As DataRow
'Report fields
Dim WrkType(100) As String
Dim WrkTCount(100) As Integer
Dim WrkTValue(100) As Long
Dim WrkTFee(100) As Decimal
Dim WrkTMischg(100) As Decimal
'Totals
Dim WrkTCheck As Decimal
Dim WrkTCash As Decimal
Dim WrkTCredit As Decimal
Dim WrkTState As Decimal
Public Sub PrtReport()

  myBDMASTQ = New BDMASTQ.mydata(MyDBConnect)
  myBDRATE = New BDRATE.mydata(MyDBConnect)
  With MyFrmBD200B
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkSelType = .TxtType.Text
    WrkCash = .ChkCash.Checked
    WrkCheck = .ChkCheck.Checked
    WrkCredit = .ChkCredit.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
    BuildDSTot()
  Else
    ds.Clear()
    dsTot.Clear()
    ClearTotals()
  End If
  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.wrkds2 = dsTot
  MyCrViewer.wrkTCash = WrkTCash
  MyCrViewer.wrkTCheck = WrkTCheck
  MyCrViewer.WrkTCredit = WrkTCredit
  MyCrViewer.WrkTState = WrkTState
  MyCrViewer.Show()

End Sub
Private Sub ClearTotals()
  ReDim WrkType(100)
  ReDim WrkTCount(100)
  ReDim WrkTValue(100)
  ReDim WrkTFee(100)
  ReDim WrkTMischg(100)
End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Trdate", Type.GetType("System.DateTime"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Permno", Type.GetType("System.String"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("Mischg", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("PayTyp", Type.GetType("System.String"))
      .Columns.Add("Check", Type.GetType("System.Decimal"))
      .Columns.Add("Cash", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDSTot()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TValue", Type.GetType("System.Int32"))
      .Columns.Add("TFee", Type.GetType("System.Decimal"))
      .Columns.Add("TMischg", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkTypeDesc As String
Dim WrkStateFee As Decimal
Dim Counter As Integer
Dim I As Integer
Dim K As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkTCheck = 0
WrkTCash = 0
WrkTCredit = 0
WrkTState = 0

WrkQry = "TRDATE >= " & WrkFrom & WrkAnd & "TRDATE <=" & WrkTo & WrkAnd & "PAYTYP<>' '"
If WrkSelType <> "" Then
  WrkQry = WrkQry & WrkAnd & "TYPE='" & WrkSelType & "'"
End If
WrkSort = "TRDATE, NAME"
myBDMASTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
  myBDMASTQ.ReadQry()
  If Not myBDMASTQ.IsEOF Then
  With myBDMASTQ
    Counter = Counter + 1
    'Filters
    If Not WrkCash And ._PAYTYP = "CA" Then
      GoTo NextRec
    End If
    If Not WrkCheck And ._PAYTYP = "CK" Then
      GoTo NextRec
    End If
    If Not WrkCredit And ._PAYTYP = "CR" Then
      GoTo NextRec
    End If
    dr = ds.Tables(0).NewRow
    dr.Item("trdate") = MyUtils.GetDBDate(._TRDATE)
    dr.Item("name") = Trim(._NAME)
    dr.Item("proploc") = Trim(._LOCNO) & " " & Trim(._LOC)
    dr.Item("type") = ._TYPE
    dr.Item("permno") = Trim(._PERMNO)
    dr.Item("value") = ._VALUE
    dr.Item("fee") = ._FEE
    dr.Item("mischg") = ._MISCHG
    dr.Item("total") = ._FEE + ._MISCHG
    Select Case Trim(._PAYTYP)
    Case "CA"
      dr.Item("paytyp") = "Cash"
      dr.Item("check") = 0
      dr.Item("cash") = dr.Item("total")
      dr.Item("credit") = 0
      WrkTCash = WrkTCash + ._FEE + ._MISCHG
    Case "CK"
      dr.Item("paytyp") = "Check"
      dr.Item("check") = dr.Item("total")
      dr.Item("cash") = 0
      dr.Item("credit") = 0
      WrkTCheck = WrkTCheck + ._FEE + ._MISCHG
    Case "CR"
      dr.Item("paytyp") = "Credit"
      dr.Item("check") = 0
      dr.Item("cash") = 0
      dr.Item("credit") = dr.Item("total")
      WrkTCredit = WrkTCredit + ._FEE + ._MISCHG
    End Select
    ds.Tables(0).Rows.Add(dr)
    WrkStateFee = CalcStateFee(._TYPE, ._VALUE)
    If WrkStateFee > 0 Then
      WrkTState = WrkTState + WrkStateFee
    End If
    WrkTypeDesc = Trim(._TYPE)
    K = LookupWrkType(WrkTypeDesc)
    WrkType(K) = WrkTypeDesc
    WrkTCount(K) = WrkTCount(K) + 1
    WrkTValue(K) = WrkTValue(K) + ._VALUE
    WrkTFee(K) = WrkTFee(K) + ._FEE
    WrkTMischg(K) = WrkTMischg(K) + ._MISCHG
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

'Totals
For I = 0 To 100
  If WrkType(I) = Nothing Then Exit For
  dr = dsTot.Tables(0).NewRow
  myBDRATE.GetFirstTier(WrkType(I))
  dr.Item("typedesc") = Trim(myBDRATE._DESC)
  dr.Item("tcount") = WrkTCount(I)
  dr.Item("tvalue") = WrkTValue(I)
  dr.Item("tfee") = WrkTFee(I)
  dr.Item("tmischg") = WrkTMischg(I)
  dr.Item("total") = WrkTFee(I) + WrkTMischg(I)
  dsTot.Tables(0).Rows.Add(dr)
Next

myFrmProgress.Close()
myBDMASTQ.CloseFile()

End Sub
  Function CalcStateFee(ByVal WrkType As String, ByVal WrkValue As Integer) As Decimal
    Dim WrkFeeCert As Decimal
    Dim WrkFeeState As Decimal

    WrkFeeCert = CalcCert(WrkType)
    If WrkFeeCert > 0 Then
      WrkFeeState = CalcRate("STATE", WrkValue)
    Else
      WrkFeeState = 0
    End If
  Return WrkFeeState
  End Function
  Function CalcRate(ByVal WrkType As String, ByVal WrkValue As Integer) As Decimal
    Dim dsrate As DataSet = New DataSet
    Dim WrkVal As Integer
    Dim WrkValueLeft As Integer
    Dim WrkRate(10) As Decimal
    Dim WrkTier(10) As Integer
    Dim WrkPer(10) As Integer
    Dim WrkCert(10) As Decimal
    Dim WrkMult As Integer
    Dim WrkFee As Decimal
    Dim I As Integer

    dsrate = myBDRATE.GetAllType(WrkType)
    For I = 0 To dsrate.Tables(0).Rows.Count - 1
      With dsrate.Tables(0).Rows(I)
        WrkRate(I) = .Item("rate")
        WrkTier(I) = .Item("tier")
        WrkPer(I) = .Item("per")
        WrkCert(I) = .Item("cert")
      End With
    Next

    WrkValueLeft = WrkValue
    For I = 0 To 10
      If WrkTier(I) = 0 Or WrkValueLeft = 0 Then Exit For
      If WrkValueLeft > WrkTier(I) Then
        WrkValueLeft = WrkValueLeft - WrkTier(I)
        WrkVal = WrkTier(I)
      Else
        WrkVal = WrkValueLeft
        WrkValueLeft = 0
      End If
      WrkMult = Math.Ceiling(WrkVal / WrkPer(I))
      WrkFee = WrkFee + (WrkMult * WrkRate(I))
    Next
  Return WrkFee
  End Function
  Function CalcCert(ByVal WrkType As String) As Decimal
    Dim dsrate As DataSet = New DataSet
    Dim WrkFee As Decimal

    WrkFee = 0
    dsrate = myBDRATE.GetAllType(WrkType)
    If dsrate.Tables(0).Rows.Count > 0 Then
      WrkFee = dsrate.Tables(0).Rows(0).Item("cert")
    End If
  Return WrkFee
  End Function
Private Function LookupWrkType(ByVal TypeDesc As String) As Integer
     Dim I As Integer

     For I = 0 To WrkType.GetUpperBound(0)
       If WrkType(I) = "" Then
         Return I
       End If
       If TypeDesc = WrkType(I) Then
         Return I
       End If
    Next

End Function
End Module






