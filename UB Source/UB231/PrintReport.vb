Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCUSTRT As UTCUSTRT.MyData
Dim myTXPROF As TXPROF.myData

Dim ds As DataSet = New DataSet
Dim DsUTCUST As DataSet = New DataSet
Dim dr As DataRow

'Screen fields
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhase As Integer
Dim WrkPhaseA As String
Dim WrkSortBy As String
Dim WrkLienDate As Date
Dim ProfTxDate As Date
'Common Work fields
Dim WrkListNo As Integer
Dim WrkTaxType As String
Dim WrkUBType As String
Dim WrkBillDesc As String
Dim WrkFamily As String
Dim WrkCode As String
Dim WrkTotal As Decimal
Dim WrkTaxTotal As Decimal
'Assessment Work Fields
Dim WrkOrigAssmnt As Decimal
Dim WrkBillAmt As Decimal
Dim WrkBond As Decimal
Dim WrkYearsLeft As Integer
Dim WrkYearNo As Integer
Dim WrkAssmntLeft As Decimal
Dim WrkAssmntAdjust As Decimal
Dim WrkDelqPrincipal As Decimal
  Public Sub PrtReport()
	myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
	myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
	myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
  myTXPROF = New TXPROF.mydata(MyDBConnect)

  With MyFrmUB231B
    WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
    WrkUBType = .TxtUBType.Text
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkLienDate = MyUtils.StripTime(.DtPckNotice.Value)
    If .RbSortList.Checked Then
      WrkSortBy = "List"
    End If
    If .RbSortName.Checked Then
      WrkSortBy = "Name"
    End If
    If .RbSortLocation.Checked Then
      WrkSortBy = "Location"
    End If
    WrkListNo = MyUtils.CnvSng(.TxtListNo.Text)
  End With

  If WrkPhase = 0 Then
    WrkPhaseA = ""
  Else
    WrkPhaseA = WrkPhase
  End If
  myTXPROF.GetOneRecordP(WrkUBType, WrkYear, WrkPhaseA, WrkDist)
  If Not myTXPROF.RecordNotFound Then
    With myTXPROF
      ProfTxDate = MyUtils.GetDBDateMDY(._PRDUE1)
    End With
  Else
    MsgBox("Type: " & WrkUBType & vbCrLf & "Year: " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
    Exit Sub
  End If
  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .WrkUBType = WrkUBType
    .WrkDueDate = ProfTxDate
    .Show()
  End With

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("OrigAssmnt", Type.GetType("System.Decimal"))
      .Columns.Add("Bill", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String

WrkBillDesc = GetUTTypeDesc(WrkUBType)
WrkTaxType = GetUTTYPETaxType(WrkUBType)
WrkFamily = GetUTTYPEFamily(WrkUBType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkQry = ""
If Not WrkDistAll Then
  WrkQry = "cudst=" & WrkDist
End If

If WrkListNo > 0 Then
  If WrkQry = "" Then
    WrkQry = "cuacct=" & WrkListNo
  Else
    WrkQry = WrkQry & WrkAnd & "cuacct=" & WrkListNo
  End If
End If
WrkSort = ""
Select Case WrkSortBy
Case "List"
  WrkSort = "CUACCT"
Case "Name"
  WrkSort = "CUNAM1"
Case "Location"
  WrkSort = "CULOC, CULOC#"
End Select

DsUTCUST = myUTCUSTQ.GetQry(WrkSort, WrkQry, 0)
If DsUTCUST.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
  With DsUTCUST.Tables(0).Rows(I)
    WrkListNo = .Item("cuacct")
    WrkCode = GetRateCode(WrkUBType)
    If WrkCode = "" Then GoTo NextRec

    CalcAssmnt(I)

    AddrLine = MyUtils.SetAddrLine(.Item("cunam1"), .Item("cunam2"), .Item("cuadd1"), .Item("cuadd2"), _
        .Item("cucity"), .Item("cust"), 0, 0, .Item("cuzip"))

    If WrkAssmntLeft = 0 Then GoTo NextRec

Report:
   'Billing Report
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = WrkListNo
    dr.Item("BillType") = WrkBillDesc
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("propdesc") = .Item("culoc#") & " " & .Item("culoc")
    dr.Item("origassmnt") = WrkOrigAssmnt
    dr.Item("bill") = WrkBillAmt
    dr.Item("bond") = WrkBond
    ds.Tables(0).Rows.Add(dr)
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsUTCUST.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
myUTCUSTQ.CloseFile()

End Sub
  Private Sub CalcAssmnt(ByVal I As Integer)
    Dim MyUBCalcBill As UBCalcBill.BillAssessment
    Dim MyUBCalcBill2 As UBCalcBill.Amort

    MyUBCalcBill = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.Amort(myDBConnect)

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkBillAmt = 0
    WrkBond = 0
    WrkTaxTotal = 0
    WrkYearsLeft = 0

		myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
		If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = DsUTCUST.Tables(0).Rows(I).Item("cuaunt")
      .In_PropVal = DsUTCUST.Tables(0).Rows(I).Item("cupval")
      .In_Footage = DsUTCUST.Tables(0).Rows(I).Item("cufoot")
      .In_Acreage = DsUTCUST.Tables(0).Rows(I).Item("cuacre")
			.In_LateralFee = myUTCUSTAS._CALAT
			.In_UniformFee = myUTCUSTAS._CAUNIF
			.In_AssmntAdjust = myUTCUSTAS._CAADJ
			.In_DeferredAmt = myUTCUSTAS._CADEF
			.In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.Round(.Out_OrigBill, 2)
      WrkAssmntLeft = MyUtils.Round(.Out_AmtLeft, 2)
    End With

    WrkYearNo = myUTCUSTAS._CAPNO
    With MyUBCalcBill2
      .In_OrigBill = MyUBCalcBill.Out_OrigBill
      .In_AmtLeft = MyUBCalcBill.Out_AmtLeft
      .In_Balance = 0 ' WrkDelqPrincipal
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = myUTCUSTAS._CAPNO
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.Round(.Out_Bill, 2)
      WrkBond = MyUtils.Round(.Out_Bond, 2)
      WrkYearsLeft = .Out_BillsLeft
      WrkTaxTotal = MyUtils.Round(.Out_Bill + .Out_Bond, 2)
    End With

  End Sub
Private Function GetRateCode(ByVal WrkUBType As String) As String
	GetRateCode = ""
	myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
	If myUTCUSTRT.RecordNotFound Then Exit Function

	With myUTCUSTRT
		GetRateCode = ._CRCODE
	End With
End Function
End Module






