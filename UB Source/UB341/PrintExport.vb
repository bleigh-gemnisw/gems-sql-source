Imports System.io
Imports System.Text
Module PrintExport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myUTCUSTQ As UTCUSTQ.myData
Dim myUTCUSTRT As UTCUSTRT.myData
Dim myUTXREF As UTXREF.myData
Dim myUBCalcReading As UBCalcReading.MyData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkDist As Integer
Dim WrkUbType As String
Dim WrkBillType As String
Dim WrkAnd As String
Dim WrkOr As String
Dim cQuote As String = Chr(34)
	Public Sub PrtExport()

	myUTCUSTQ = New UTCUSTQ.mydata(MyDBConnect)
	myUTCUSTRT = New UTCUSTRT.mydata(MyDBConnect)
	myUTXREF = New UTXREF.mydata(MyDBConnect)
	myUBCalcReading = New UBCalcReading.mydata(MyDBConnect)

	With MyFrmUB341B
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		WrkUbType = .TxtUBType.Text
		If .ChkBillType.Checked Then
			WrkBillType = WrkUbType
		Else
			WrkBillType = String.Empty
		End If
	End With

	If ds.Tables.Count = 0 Then
		BuildDs(ds)
	Else
		ds.Clear()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.wrkds = ds
		.WrkDist = WrkDist
		.WrkExport = True
		.WrkPost = False
		.Show()
	End With

	End Sub
Private Sub GetDetail()
Dim sb As StringBuilder
Dim sw As StreamWriter = New StreamWriter(MyFrmUB341B.LblFilePath.Text)
Dim WrkQry As String
Dim WrkSort As String
Dim WrkCurrYr As Integer
Dim WrkPrevYr As Integer
Dim WrkPrevYr2 As Integer
Dim WrkMeterID As String
Dim WrkDate As Date
Dim Counter As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
 End If

Counter = 0
WrkQry = ""
If WrkDist > 0 Then
	WrkQry = "CUDST=" & WrkDist
End If
WrkSort = "CUACCT"

myUTCUSTQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

'Write Header
	sb = New StringBuilder
	sb.Append("ListNo")
	sb.Append(",")
	sb.Append("Name")
	sb.Append(",")
	sb.Append("Loc No")
	sb.Append(",")
	sb.Append("Location")
	sb.Append(",")
	sb.Append("Dist")
	sb.Append(",")
	sb.Append("Rate Code")
	sb.Append(",")
	sb.Append("Meter ID")
	sb.Append(",")
	sb.Append("Curr Yr")
	sb.Append(",")
	sb.Append("Prev Yr")
	sb.Append(",")
	sb.Append("Prev Yr2")
	sb.Append(",")
	sb.Append("Units")
	sw.WriteLine(sb.ToString)

ReadNext:
	myUTCUSTQ.ReadQry()
	If Not myUTCUSTQ.IsEOF Then
	With myUTCUSTQ
		myUTCUSTRT.GetOneRecordP(._CUACCT, WrkUbType)
		If myUTCUSTRT.RecordNotFound Then GoTo NextRec
		WrkMeterID = GetMeterIDs(._CUACCT)
		WrkDate = MyFrmUB341B.DtPckRead.Value
		WrkCurrYr = CalcMeterUsage(WrkDate)
		WrkDate = DateAdd(DateInterval.Year, -1, MyFrmUB341B.DtPckRead.Value)
		WrkPrevYr = CalcMeterUsage(WrkDate)
		WrkDate = DateAdd(DateInterval.Year, -2, MyFrmUB341B.DtPckRead.Value)
		WrkPrevYr2 = CalcMeterUsage(WrkDate)
		Counter = Counter + 1
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._CUACCT
		dr.Item("name") = Trim(._CUNAM1)
		dr.Item("location") = Trim(._CULOCNO) & " " & Trim(._CULOC)
		dr.Item("dist") = ._CUDST
		dr.Item("ratecd") = Trim(myUTCUSTRT._CRCODE)
		dr.Item("units") = myUTCUSTQ._CUUNIT
		ds.Tables(0).Rows.Add(dr)

		sb = New StringBuilder
		sb.Append(._CUACCT)
		sb.Append(",")
		sb.Append(cQuote)
		sb.Append(Trim(._CUNAM1))
		sb.Append(cQuote)
		sb.Append(",")
		sb.Append(cQuote)
		sb.Append(Trim(._CULOCNO))
		sb.Append(cQuote)
		sb.Append(",")
		sb.Append(cQuote)
		sb.Append(Trim(._CULOC))
		sb.Append(cQuote)
		sb.Append(",")
		sb.Append(._CUDST)
		sb.Append(",")
		sb.Append(Trim(myUTCUSTRT._CRCODE))
		sb.Append(",")
		sb.Append(cQuote)
		sb.Append(WrkMeterID)
		sb.Append(cQuote)
		sb.Append(",")
		sb.Append(WrkCurrYr)
		sb.Append(",")
		sb.Append(WrkPrevYr)
		sb.Append(",")
		sb.Append(WrkPrevYr2)
		sb.Append(",")
		sb.Append(myUTCUSTQ._CUUNIT)
		sw.WriteLine(sb.ToString)
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

sw.Close()
myFrmProgress.Close()
myUTCUSTQ.CloseFile()

End Sub
	Private Function CalcMeterUsage(ByVal WrkDate As Date) As Integer
		Dim WrkUsage As Integer

		With myUBCalcReading
			.In_ListNo = myUTCUSTQ._CUACCT
			.In_RateType = WrkBillType
			.In_AnnualBill = True
			.In_BillDate = WrkDate
			.GetMeterReadings()
			WrkUsage = .Out_MeterReadCurr + .Out_MeterReadPrev + .Out_MeterRead2 + .Out_MeterRead3
		End With
		Return WrkUsage
	End Function
	Private Function GetMeterIDs(ByVal WrkListNo As Integer) As String
		Dim ds2 As DataSet = New DataSet
		Dim I As Integer
		Dim sb As StringBuilder

		sb = New StringBuilder
		ds2 = myUTXREF.GetAllAcct(WrkListNo, WrkBillType)
		For I = 0 To ds2.Tables(0).Rows.Count - 1
			sb.Append(ds2.Tables(0).Rows(I).Item("cxref"))
			sb.Append(" ")
		Next

		Return sb.ToString
	End Function
End Module






