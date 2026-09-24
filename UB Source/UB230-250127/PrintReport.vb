Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTAS As UTCUSTAS.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myUTMETER As UTMETER.myData
Dim myUTRATEUS As UTRATEUS.myData
Dim myUTBREAK As UTBREAK.myData
Dim myTXPROF As TXPROF.myData
Dim myTPaymnt As TPAYMNT.MyData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

'Screen fields
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkPhase As Integer
Dim WrkPhas As String
Dim WrkDistto As Integer
Dim WrkPhaseto As Integer
Dim WrkSortBy As String
Dim WrkReport As Boolean
Dim WrkBillDate As Date

'Common Work fields
Dim wrkadist As Integer
Dim wrkaphase As Integer
Dim WrkListNo As Integer
Dim WrkTaxType As String
Dim WrkUBType As String
Dim WrkBillDesc As String
Dim WrkFamily As String
Dim WrkCode As String
'Assessment Work Fields
Dim WrkOrigAssmnt As Decimal
Dim WrkBillAmt As Decimal
Dim WrkDebugMsg As String
'Metered Work Fields
Dim WrkTotalUse As Integer
Dim WrkActualUse As Integer
'Misc fields
Dim WrkAmt1 As Decimal
Dim WrkAmt2 As Decimal
Dim WrkAmt3 As Decimal
Dim WrkAmt4 As Decimal
Dim WrkAmt5 As Decimal
Dim WrkAmt6 As Decimal
Public Sub PrtReport()
myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
myUTCUSTAS = New UTCUSTAS.mydata(MyDBConnect)
myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
myTXPROF = New TXPROF.mydata(MyDBConnect)
myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

With MyFrmUB230B
  WrkYear = MyUtils.CnvSng(.TxtYear.Text)
  WrkDist = MyUtils.CnvSng(.TxtDist.Text)
  WrkDistto = MyUtils.CnvSng(.TxtDistTo.Text)
  WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
  WrkPhaseto = MyUtils.CnvSng(.TxtPhaseTo.Text)
  WrkUBType = .TxtUBType.Text
  WrkBillDate = .DtPckBill.Value
  If WrkDist = 0 And WrkDistto = 0 Then
    WrkDistto = 999
    If WrkPhase = 0 And WrkPhaseto = 0 Then
      WrkPhaseto = 9
    End If
  End If
  If .RbSortList.Checked Then
    WrkSortBy = "List"
  End If
  If .RbSortName.Checked Then
    WrkSortBy = "Name"
  End If
  If .RbSortLocation.Checked Then
    WrkSortBy = "Location"
  End If
End With

If ds.Tables.Count = 0 Then
  BuildDS()
Else
  ds.Clear()
End If

GetDetail()
If ds.Tables(0).Rows.Count = 0 Then Exit Sub

Done:
MyCrViewer = New FrmCrViewer
With MyCrViewer
  .Wrkds = ds
  .WrkUBType = WrkUBType
  Select Case WrkSortBy
  Case "List"
    .Wrksort = "By List"
  Case "Name"
    .Wrksort = "By Name"
  Case "Location"
    .Wrksort = "By Location"
  End Select
  .Wrkdistphase = "District / Phase " + WrkDist.ToString + " / " + WrkPhase.ToString _
    + " To: " + WrkDistto.ToString + " / " + WrkPhaseto.ToString
  .WrkFamily = WrkFamily
  .Show()
End With


End Sub
	Private Sub BuildDS()
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("BillType", Type.GetType("System.String"))
			.Columns.Add("Year", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Amt1", Type.GetType("System.Decimal"))
			.Columns.Add("Amt2", Type.GetType("System.Decimal"))
			.Columns.Add("Amt3", Type.GetType("System.Decimal"))
			.Columns.Add("Amt4", Type.GetType("System.Decimal"))
			.Columns.Add("Amt5", Type.GetType("System.Decimal"))
      .Columns.Add("Amt6", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
		End With
		ds.Tables.Add(myTable)
	End Sub

Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer
Dim Counter As Integer
Dim WrkAnd As String

WrkFamily = GetUTTYPEFamily(WrkUBType)
WrkTaxType = GetUTTYPETaxType(WrkUBType)

myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, "", 0)
If myTXPROF.RecordNotFound Then
	MsgBox("Add year " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
	Exit Sub
End If

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
End If

WrkQry = ""
Counter = 0
If WrkDistto > WrkDist Then
	WrkQry = "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
Else
WrkQry = "cudst=" & WrkDist
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
		'filter phase..  cannot go phase to phase in all cases as I can run dist 1 phase 3 to dist 4 phase 2
		wrkaphase = ._CUPHAS
		wrkadist = ._CUDST

		If WrkDist = WrkDistto Then
			If wrkaphase < WrkPhase Or wrkaphase > WrkPhaseto Then GoTo nextrec
		End If
		If WrkDist < WrkDistto Then
			If wrkaphase < WrkPhase And wrkadist = WrkDist Then GoTo nextrec
			If wrkaphase > WrkPhaseto And wrkadist = WrkDistto Then GoTo nextrec
		End If
		' end phase filter.

		WrkListNo = ._CUACCT
		WrkCode = GetRateCode(WrkUBType)

		If Trim(WrkCode) = "" Then GoTo NextRec
		WrkAmt1 = 0
		WrkAmt2 = 0
		WrkAmt3 = 0
		WrkAmt4 = 0
		WrkAmt5 = 0
    WrkAmt6 = 0
    Select Case WrkFamily
    Case "A"
      CalcAssmnt(I)
    Case "M"
      CalcMetered(I)
    Case "U"
      CalcUsage(I)
    End Select
		 WrkPhas = ""
		'Filter - Omit Zero Bills 
		If WrkBillAmt = 0 Then
			GoTo NextRec
		End If

		 If MyFrmUB230B.RbPerAnnual.Checked Then
			With myTPaymnt
				.In_ListNo = WrkListNo
				.In_Type = WrkTaxType
				.In_Year = WrkYear
				.In_Dst = wrkadist
				.In_Phs = WrkPhas
				.In_TaxT = WrkBillAmt
				.CalcPaySplit()
				WrkBillAmt = .Out_TaxT
			End With
		End If

		'Report
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = WrkListNo
		dr.Item("year") = WrkYear
		dr.Item("BillType") = WrkBillDesc
		dr.Item("name") = Trim(._CUNAM1)
		dr.Item("amt1") = WrkAmt1
		dr.Item("amt2") = WrkAmt2
		dr.Item("amt3") = WrkAmt3
		dr.Item("amt4") = WrkAmt4
		dr.Item("amt5") = WrkAmt5
    dr.Item("amt6") = WrkAmt6
    dr.Item("billamt") = WrkBillAmt
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
		Dim MyUBCalcBillA As UBCalcBill.BillAssessment
		Dim MyUBCalcBillAmort As UBCalcBill.Amort
		Dim WrkAssmntLeft As Decimal

    MyUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBillAmort = New UBCalcBill.Amort(myDBConnect)

    WrkOrigAssmnt = 0
		WrkAssmntLeft = 0
		WrkBillAmt = 0

		myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
		If myUTCUSTAS.RecordNotFound Then Exit Sub

		With MyUBCalcBillA
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
      WrkOrigAssmnt = MyUtils.FmtCurrency(.Out_OrigBill)
      WrkAssmntLeft = MyUtils.FmtCurrency(.Out_AmtLeft)
      WrkAmt1 = .Out_UnitPart
      WrkAmt2 = .Out_PropValPart
      WrkAmt3 = .Out_FootagePart
      WrkAmt4 = .Out_AcreagePart
      WrkAmt5 = .Out_OtherPart
      WrkDebugMsg = .Out_Debug
    End With

    If WrkAssmntLeft = 0 Then Exit Sub

    With MyUBCalcBillAmort
      .In_OrigBill = MyUBCalcBillA.Out_OrigBill
      .In_AmtLeft = MyUBCalcBillA.Out_AmtLeft
      .In_Balance = 0  'dont need balance  was cubal which was replaced.
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = myUTCUSTAS._CAPNO
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
    End With
  End Sub
  Private Sub CalcMetered(ByVal I As Integer)
    Dim MyUBCalcReading As UBCalcReading.MyData
    Dim MyUBCalcBill As UBCalcBill.MeteredUse
    Dim MyUBCalcBill2 As UBCalcBill.BillMetered
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkReading2 As Integer
    Dim WrkReading3 As Integer

    MyUBCalcReading = New UBCalcReading.mydata(MyDBConnect)
    MyUBCalcBill = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.BillMetered(myDBConnect)

    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkUBType
      If MyFrmUB230B.RbPerAnnual.Checked Then
        .In_AnnualBill = True
      Else
        .In_AnnualBill = False
      End If
      .In_BillDate = WrkBillDate
      .GetMeterReadings()
      WrkReadingCurr = .Out_MeterReadCurr
      WrkReadingPrev = .Out_MeterReadPrev
      WrkReading2 = .Out_MeterRead2
      WrkReading3 = .Out_MeterRead3
    End With

    With MyUBCalcBill
      .In_RateType = WrkUBType
      .In_MeterSize = Trim(myUTCUSTQ._CUMSIZ)
      .In_MeterReadCurr = WrkReadingCurr
      .In_MeterReadPrev = WrkReadingPrev
      .In_MeterRead2 = WrkReading2
      .In_MeterRead3 = WrkReading3
      .In_Units = myUTCUSTQ._CUUNIT
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = myUTCUSTQ._CUEDU
      End If
      .CalcMeteredUse()
      WrkTotalUse = .Out_TotalUse
      WrkActualUse = .Out_ActualUse
    End With

    With MyUBCalcBill2
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_TotalUse = MyUBCalcBill.Out_TotalUse
      .In_MinBill = MyUBCalcBill.Out_MinBill
      .In_UseMinCharge = MyUBCalcBill.Out_UseMinCharge
      .In_UnitCharge = MyUBCalcBill.Out_UnitCharge
      .In_MarkupPct = MyUBCalcBill.Out_MarkupPct
      .In_EDUCharge = MyUBCalcBill.Out_EDUCharge
      .CalcMetered()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkAmt1 = .Out_UsagePart
      WrkAmt2 = .Out_MinBillPart
      WrkAmt3 = .Out_BasePart
      WrkAmt4 = .Out_UnitPart
      WrkAmt5 = .Out_MarkupPart
      WrkAmt6 = .Out_EDUPart
      WrkDebugMsg = .Out_Debug
    End With
  End Sub
  Private Sub CalcUsage(ByVal I As Integer)
    Dim MyUBCalcBillU As UBCalcBill.BillUsage

    MyUBCalcBillU = New UBCalcBill.BillUsage(myDBConnect)
    With MyUBCalcBillU
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      If WrkUBType = "U" Then
        .In_Fixtures = myUTCUSTQ._CUSFIX
        .In_SurChg = myUTCUSTQ._CUSCHR
      Else
        .In_Fixtures = myUTCUSTQ._CUWFIX
        .In_SurChg = 0
      End If
      .In_Units = myUTCUSTQ._CUUNIT
      .In_Extras = myUTCUSTQ._CUXTRA
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = myUTCUSTQ._CUEDU
      End If
      .CalcUsage()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkAmt1 = .Out_UnitPart
      WrkAmt2 = .Out_FixtPart
      WrkAmt3 = .Out_ExtraPart
      WrkAmt4 = .Out_BasePart
      WrkAmt5 = .Out_MarkupPart
      WrkAmt6 = .Out_EDUPart
      WrkDebugMsg = .Out_Debug
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






