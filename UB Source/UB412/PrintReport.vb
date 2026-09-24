Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myTXINVLK As TXINVLK.myData
Dim myTXPROF As TXPROF.myData
Dim myUTCNTL As UTCNTL.myData
Dim myCashInt As CASHINT.MyData

Dim ds As DataSet = New DataSet
Dim dr As DataRow

'Screen fields
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhase As Integer
Dim WrkSortBy As String
Dim WrkInterestDate As Date
Dim WrkAddress As Boolean
Dim WrkZeroBal As Boolean
Dim WrkLocNo As String
Dim WrkLoc As String
Dim WrkPrtReport As Boolean
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
'Deliquent work fields
Dim WrkDelqInterest As Decimal
Dim WrkDelqFee As Decimal
Dim WrkDelqLien As Decimal
Dim WrkDelqBond As Decimal
Dim WrkDelqPrincipal As Decimal
  Public Sub PrtReport()
	myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
  myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
  myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
  myTXINVLK = New TXINVLK.mydata(MyDBConnect)
  myTXPROF = New TXPROF.mydata(MyDBConnect)
	myUTCNTL = New UTCNTL.mydata(MyDBConnect)
  myCashInt = New CASHINT.mydata(MyDBConnect)

  With MyFrmUB412B
    WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
    WrkUBType = .TxtUBType.Text
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkInterestDate = MyUtils.StripTime(.DtPckInterest.Value)
    WrkAddress = .ChkAddress.Checked
    WrkZeroBal = .ChkZeroBal.Checked
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
    WrkLocNo = MyUtils.JustifyRight(.TxtLocNo.Text, 7)
    WrkLoc = .TxtLoc.Text
    WrkPrtReport = .RbReport.Checked
  End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

	BufferTXPROF(WrkUBType, WrkYear)
  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .WrkUBType = WrkUBType
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
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("Units", Type.GetType("System.Decimal"))
      .Columns.Add("Original", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Unbilled", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkPhaseA As String
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkCaveat As Decimal
Dim WrkNoAddlBond As Boolean
Dim WrkBondPayoff As Decimal
Dim Counter As Integer

WrkBillDesc = GetUTTypeDesc(WrkUBType)
WrkTaxType = GetUTTYPETaxType(WrkUBType)
WrkFamily = GetUTTYPEFamily(WrkUBType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

Counter = 0
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

If WrkLoc <> String.Empty Then
  If WrkQry = "" Then
    WrkQry = "culoc=" & MyUtils.Quo(WrkLoc)
  Else
    WrkQry = WrkQry & WrkAnd & "culoc=" & MyUtils.Quo(WrkLoc)
  End If
  If WrkLocNo <> String.Empty Then
    WrkQry = WrkQry & WrkAnd & "culoc#=" & MyUtils.Quo(WrkLocNo)
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

If WrkPhase = 0 Then
  WrkPhaseA = ""
Else
  WrkPhaseA = WrkPhase
End If

myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, WrkPhaseA, WrkDist)
'If not found, use generic profile
If myTXPROF.RecordNotFound Then
	myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, String.Empty, 0)
End If
If myTXPROF.RecordNotFound Then
	MsgBox("Add year " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
	Exit Sub
End If

WrkCaveat = 0
WrkNoAddlBond = False
If WrkFamily = "A" Then
  myUTCNTL.GetOneRecordP(0)
	If Not myUTCNTL.RecordNotFound Then
		With myUTCNTL
			WrkCaveat = ._UBCAV
			If ._UASDV = "N" Then
				WrkNoAddlBond = True
			End If
		End With
	End If
End If

myUTCUSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myUTCUSTQ.ReadQry()
	If Not myUTCUSTQ.IsEOF Then
	With myUTCUSTQ
		Counter = Counter + 1
		WrkListNo = ._CUACCT
		WrkCode = GetRateCode(WrkUBType)
		If WrkCode = "" Then GoTo NextRec

		Select Case WrkFamily
		Case "A"
			CalcInterestListNo()
			CalcAssmnt(I)
			If Not WrkNoAddlBond Then
				WrkBondPayoff = CalcBond(._CUDST, ._CUPHAS)
			End If
		Case "U"
			CalcInterestListNo()
		End Select

		WrkTotal = WrkDelqPrincipal + WrkDelqInterest + WrkDelqFee + WrkDelqBond + WrkBondPayoff + _
			WrkDelqLien + WrkAssmntLeft
    If WrkAssmntLeft > 0 Or (WrkAssmntLeft = 0 And WrkDelqPrincipal > 0 And WrkDelqLien = 0) Then
      WrkTotal = WrkTotal + WrkCaveat
    End If
		AddrLine = Nothing
    If WrkAddress Or Not WrkPrtReport Then
      AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
    End If

		If WrkTotal = 0 And Not WrkZeroBal Then GoTo NextRec

Report:
	 'Billing Report
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = WrkListNo
		dr.Item("BillType") = WrkBillDesc
    If WrkAddress Or Not WrkPrtReport Then
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
    Else
      dr.Item("addr1") = Trim(._CUNAM1)
    End If
		dr.Item("location") = Trim(._CULOCNO) & " " & Trim(._CULOC)
		Select Case WrkFamily
		Case "A"
			dr.Item("units") = ._CUAUNT
		Case "U"
			dr.Item("units") = ._CUUNIT
		End Select
		dr.Item("original") = WrkOrigAssmnt
		dr.Item("balance") = WrkDelqPrincipal
		dr.Item("interest") = WrkDelqInterest
		dr.Item("bond") = WrkDelqBond + WrkBondPayoff
		If WrkAssmntLeft > 0 Then
			dr.Item("lien") = WrkDelqFee + WrkDelqLien + WrkCaveat
		Else
			dr.Item("lien") = WrkDelqFee + WrkDelqLien
		End If
		dr.Item("total") = WrkTotal
		dr.Item("unbilled") = WrkAssmntLeft
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
			.In_DwellUnits = myUTCUSTQ._CUAUNT
			.In_PropVal = myUTCUSTQ._CUPVAL
			.In_Footage = myUTCUSTQ._CUFOOT
			.In_Acreage = myUTCUSTQ._CUACRE
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.Round(.Out_OrigBill, 2)
      WrkAssmntLeft = MyUtils.Round(.Out_AmtLeft, 2)
    End With

    With MyUBCalcBill2
      .In_OrigBill = MyUBCalcBill.Out_OrigBill
      .In_AmtLeft = MyUBCalcBill.Out_AmtLeft
      .In_Balance = WrkDelqPrincipal
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
Private Sub CalcInterestListNo()
  Dim ds2 As DataSet = New DataSet
  Dim I As Integer

  WrkDelqInterest = 0
  WrkDelqFee = 0
  WrkDelqLien = 0
  WrkDelqBond = 0
  WrkDelqPrincipal = 0

  ds2 = myTXINVLK.GetViewbyList(WrkListNo, WrkTaxType, 999)
  If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

  For I = 0 To ds2.Tables(0).Rows.Count - 1
    With myCashInt
      If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
        .In_IntDate = WrkInterestDate
        .In_ListNo = WrkListNo
        .In_Type = WrkTaxType
        .In_Year = ds2.Tables(0).Rows(I).Item("year")
        .CalcInterest()
        WrkDelqInterest = WrkDelqInterest + .Out_Int
        WrkDelqFee = WrkDelqFee + .Out_Fee
        WrkDelqLien = WrkDelqLien + .Out_Lien
        WrkDelqBond = WrkDelqBond + .Out_Bond
        WrkDelqPrincipal = WrkDelqPrincipal + .Out_Prin
      Else
        WrkDelqPrincipal = WrkDelqPrincipal + ds2.Tables(0).Rows(I).Item("wbal")
      End If
    End With
  Next
End Sub
  Private Function CalcBond(ByVal Dist As Integer, ByVal Phase As Integer) As Decimal
    Dim WrkBondPayoff As Decimal
    Dim WrkMonths As Integer
    Dim WrkProMonths As Integer
    Dim WrkProfDate As Date
    Dim WrkFactor As Decimal
    Dim WrkDaysMo As Integer
    Dim WrkDays As Integer
    Dim WrkBondMonth As Decimal
    Dim WrkBondPartial As Decimal
    Dim K As Integer

    WrkBondPayoff = 0
    K = LookupProf(Dist, Phase)
    If K = -1 Then
      K = LookupProf(0, 0)
      If K = -1 Then
        Exit Function
      End If
    End If

    If WrkBond = 0 Then
      Return 0
    End If
    WrkProfDate = MyUtils.GetDBDateMDY(WrkProfDue1(K))
    WrkProMonths = 12
    If WrkProfDue2(K) > 0 Then
      WrkProMonths = 6
      WrkDays = DateTime.Compare(WrkInterestDate, MyUtils.GetDBDateMDY(WrkProfDue2(K)))
      If WrkDays > 0 Then
        WrkProfDate = MyUtils.GetDBDateMDY(WrkProfDue2(K))
      End If
    End If
    WrkMonths = DateDiff(DateInterval.Month, WrkProfDate, WrkInterestDate)
    If WrkMonths < 0 Then WrkMonths = 0
    WrkFactor = WrkMonths / WrkProMonths
    WrkBondPayoff = MyUtils.Round(WrkBond * WrkFactor, 2)
    If MyPayoffBondDay Then
      WrkBondMonth = MyUtils.Round(WrkBond * (1 / 12), 2)
      WrkDaysMo = CalcNoDays(WrkInterestDate.Month)
      WrkDays = WrkInterestDate.Day - 1
      If WrkDays = WrkDaysMo Then
        WrkDays = WrkDays - 1
      End If
      WrkBondPartial = MyUtils.Round(WrkBondMonth * (WrkDays / WrkDaysMo), 2)
      WrkBondPayoff = WrkBondPayoff + WrkBondPartial
    End If

    Return WrkBondPayoff

  End Function
  Private Function CalcNoDays(ByVal Month As Integer) As Integer
  Dim Days As Integer

  Select Case Month
  Case 1, 3, 5, 7, 8, 10, 12
    Days = 31
  Case 2
    Days = 28
  Case 4, 6, 9, 11
    Days = 30
  End Select

  Return Days
  End Function

End Module






