Imports System.Text
Imports TA523.TA523
Module PrintReport

	Dim myFrmProgress As FrmProgress
	Dim WrkPct As Integer
	Dim SavePct As Integer
	Dim found As Boolean
	Dim myTXSUPPQ As TXSUPPQ.MyData
	Dim myTXSUPP As TXSupp.MyData
	Dim myTXMCTL As TXMCTL.MyData
	'MK 7/14/25 Begin
	Dim myTXMSRP As TXMSRP.MyData
	Dim myTXMSRPDEP As TXMSRPDEP.MyData
	'MK 7/14/25 End

	Dim ds As DataSet = New DataSet
	Dim ds2 As DataSet = New DataSet
	'MK 7/14/25 Begin
	Dim dsTot As DataSet = New DataSet
	'MK 7/14/25 End
	Dim DsTXSUPPQ As DataSet = New DataSet
	Dim dr As Data.DataRow
	Dim dr2 As Data.DataRow
	'MK 7/14/25 Begin
	Dim drTot As Data.DataRow
	'MK 7/14/25 End

	'Screen
	'MK 7/14/25 Begin
	'Dim WrkVehYear As Integer
	'Dim WrkPriceSome As Boolean
	Dim WrkSelClass As Integer
	Dim WrkRoundDown As Boolean
	Dim WrkInclDMV As Boolean
	Dim WrkInclPost As Boolean
	'MK 7/14/25 End
	Dim WrkPost As Boolean

	'Control File
	'MK 7/14/25 Begin
	'Dim WrkValuePct As Decimal
	'Dim WrkValueMin As Integer
	Dim WrkBookPct As Decimal
	Dim WrkMinValue As Integer
	'MK 7/14/25 End

	'Totals
	Dim WrkTCount As Integer
	Dim WrkTValue As Integer
	Public Sub PrtReport()

		myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
		myTXSUPP = New TXSupp.MyData(myDBConnect)
		myTXMCTL = New TXMCTL.MyData(myDBConnect)
		'MK 7/14/25 Begin
		myTXMSRP = New TXMSRP.MyData(myDBConnect)
		myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
		'MK 7/14/25 End

		If ds.Tables.Count = 0 Then
			BuildDS()
			'MK 7/14/25 Begin
			ds2 = ds.Clone
			'MK 7/14/25 End
		Else
			ds.Clear()
			ds2.Clear()
			'MK 7/14/25 Begin
			dsTot.Clear()
			'MK 7/14/25 End
			ClearTotals()
		End If
		GetTXMCTL()
		'added 10/18/2023
		'MK 7/14/25 Begin
		'If MyFrmTA523B.RbPct80.Checked Then
		'	WrkValuePct = 0.8
		'End If
		'MK 7/14/25 End
		GetDetail()

Done:
		MyCrViewer = New FrmCrViewer
		MyCrViewer.wrkds = ds
		MyCrViewer.wrkds2 = ds2
		'MK 7/14/25 Begin
		MyCrViewer.wrkdsTot = dsTot
		'MK 7/14/25 End
		MyCrViewer.Show()

	End Sub
	Private Sub GetTXMCTL()
		myTXMCTL = New TXMCTL.MyData(myDBConnect)
		myTXMCTL.GetOneRecordP(1)
		If Not myTXMCTL.RecordNotFound Then
			With myTXMCTL
				'MK 7/14/25 Begin
				'WrkValuePct = ._VALPER
				'WrkValueMin = ._VALMIN
				WrkBookPct = ._VALPER
				WrkMinValue = ._VALMIN
				'MK 7/14/25 End
			End With
		End If
	End Sub
	Private Sub BuildDS()
		Dim myTable As New DataTable
		'MK 7/14/25 Begin
		'Dim myTable2 As New DataTable
		Dim myTableTot As New DataTable
		'MK 7/14/25 End

		With (myTable)
			.TableName = "mytable"
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("oname", Type.GetType("System.String"))
			.Columns.Add("class", Type.GetType("System.Int32"))
			.Columns.Add("make", Type.GetType("System.String"))
			.Columns.Add("year", Type.GetType("System.Int32"))
			.Columns.Add("idno", Type.GetType("System.String"))
			.Columns.Add("model", Type.GetType("System.String"))
			'MK 7/14/25 Begin
			.Columns.Add("source", Type.GetType("System.String"))
			.Columns.Add("msrp", Type.GetType("System.Int32"))
			'MK 7/14/25 End
			.Columns.Add("value", Type.GetType("System.Int32"))
		End With
		ds.Tables.Add(myTable)

		'MK 7/14/25 Begin
		'With myTable2
		'	.TableName = "mytable2"
		'	.Columns.Add("TCount", Type.GetType("System.Int32"))
		'	.Columns.Add("TValue", Type.GetType("System.Int32"))
		'End With
		'ds2.Tables.Add(myTable2)
		With myTableTot
			.TableName = "mytableTot"
			.Columns.Add("TCount", Type.GetType("System.Int32"))
			.Columns.Add("TValue", Type.GetType("System.Int32"))
		End With
		dstot.Tables.Add(myTableTot)
		'MK 7/14/25 End
	End Sub
	Private Sub ClearTotals()
		WrkTCount = 0
		WrkTValue = 0
	End Sub
	Private Sub GetDetail()
		Dim WrkSort As String
		Dim WrkQry As String
		Dim Counter As Integer
		Dim J As Integer
		Dim WrkAnd As String
		Dim WrkOr As String
		'MK 7/14/25 Begin
		Dim WrkConfig As Integer
		Dim WrkSource As String
		Dim WrkMSRP As Integer
		Dim WrkComplete As String
		'Dim Good As Boolean
		'MK 7/14/25 End
		Dim WrkValue As Integer

		WrkSort = "MAKE, YEAR, MODEL, CLASS"
		With MyFrmTA523B
			'MK 7/14/25 Begin
			'WrkVehYear = MyUtils.CnvSng(.TxtVehYear.Text)
			'WrkPriceSome = .RbPriceSome.Checked
			WrkSelClass = MyUtils.CnvSng(.TxtClass.Text)
			WrkRoundDown = .RbDown.Checked
			WrkInclDMV = .ChkInclDMV.Checked
			WrkInclPost = .ChkInclPost.Checked
			'MK 7/14/25 End
			WrkPost = .ChkUpdate.Checked
		End With

		If myDBConnect.ServerAS400 Then
			WrkAnd = " *and "
			WrkOr = " *or "
		Else
			WrkAnd = " and "
			WrkOr = " or "
		End If

		Counter = 0
		'MK 7/14/25 Begin
		'WrkQry = "CAT = '1'" & WrkAnd & "VALUE=0" & WrkAnd & "MSRP>0" & WrkAnd & "YEAR>=" & WrkVehYear
		WrkQry = "CAT = '1'"
		If Not WrkInclDMV Then
			WrkQry = WrkQry & WrkAnd & "MSRP=0"
		End If
		If WrkSelClass > 0 Then
			WrkQry = WrkQry & WrkAnd & "class=" & WrkSelClass
		Else
			WrkQry = WrkQry & WrkAnd & "class<>25"
		End If
		'MK 7/14/25 End
		myTXSUPPQ.OpenQry(WrkSort, WrkQry)

		myFrmProgress = New FrmProgress
		myFrmProgress.Show()
		myFrmProgress.Refresh()
		Application.DoEvents()

ReadNext:
		myTXSUPPQ.ReadQry()
		If Not myTXSUPPQ.IsEOF Then
			With myTXSUPPQ
				Counter = Counter + 1
				'MK 7/14/25 Begin
				'If WrkPriceSome Then
				'	Select Case ._CLASS
				'		Case 1, 2, 3, 4, 12
				'			Good = True
				'		Case Else
				'			Good = False
				'	End Select
				'Else
				'	Good = True
				'End If
				'If Not Good Then GoTo ReadNext
				'WrkValue = 0
				'dr = ds.Tables(0).NewRow
				'dr.Item("listno") = ._LISTNo
				'dr.Item("Oname") = Trim(._NAME)
				'dr.Item("class") = ._CLASS
				'dr.Item("year") = ._YEAR
				'dr.Item("make") = Trim(._MAKE)
				'dr.Item("model") = Trim(._MODEL)
				'dr.Item("idno") = Trim(._VINNO)

				'WrkValue = ._MSRP * WrkValuePct
				'J = WrkValue Mod 10
				'If J <> 0 Then
				'	If WrkRoundDown Then
				'		WrkValue = WrkValue - J
				'	Else
				'		If J < 5 Then
				'			WrkValue = WrkValue - J
				'		Else
				'			WrkValue = WrkValue + (10 - J)
				'		End If
				'	End If
				'End If

				'If WrkValueMin > 0 Then
				'	If WrkValueMin > WrkValue Then
				'		WrkValue = WrkValueMin
				'	End If
				'End If
				'If WrkValue > 0 Then
				'	dr.Item("value") = WrkValue
				'	WrkTCount = WrkTCount + 1
				'	WrkTValue = WrkTValue + WrkValue
				'	ds.Tables(0).Rows.Add(dr)
				'End If
				'MK 7/14/25 End
				WrkSource = ""
				WrkValue = 0
				myTXMSRP.GetOneRecordP(._VINNO)
				With myTXMSRP
					If Not .RecordNotFound Then
						If Not WrkInclPost Then
							If ._OVMSRP > 0 Then
								GoTo NextRec
							End If
						Else
							If ._OVSOURCE <> "P" Then
								GoTo NextRec
							End If
						End If
					End If
				End With

				WrkConfig = GetPriceDigestConfig(Trim(._VINNO), ._YEAR)
				If WrkConfig = 0 Then
					GoTo NextRec
				End If
				If WrkInclDMV And ._MSRP > 0 Then
					WrkMSRP = ._MSRP
					WrkSource = "DMV"
				Else
					WrkMSRP = GetPriceDigestMSRP(WrkConfig)
					WrkSource = "PD"
				End If
				WrkComplete = GetPriceDigestComplete(WrkConfig)
				If WrkMSRP > 0 Then
					If WrkInclDMV And WrkSource = "DMV" Then
						WrkValue = ._VALUE
					Else
						WrkValue = CalcValue(WrkMSRP, ._YEAR)
						J = WrkValue Mod 10
						If J <> 0 Then
							If WrkRoundDown Then
								WrkValue = WrkValue - J
							Else
								If J < 5 Then
									WrkValue = WrkValue - J
								Else
									WrkValue = WrkValue + (10 - J)
								End If
							End If
						End If
					End If
					If WrkMinValue > 0 Then
						If WrkMinValue > WrkValue Then
							WrkValue = WrkMinValue
						End If
					End If
				End If

				If WrkValue > 0 Or WrkComplete = "N" Then
					If WrkComplete = "Y" Then
						dr = ds.Tables(0).NewRow
					Else
						dr = ds2.Tables(0).NewRow
					End If
					dr.Item("listno") = ._LISTNo
					dr.Item("Oname") = Trim(._NAME)
					dr.Item("class") = ._CLASS
					dr.Item("year") = ._YEAR
					dr.Item("make") = Trim(._MAKE)
					dr.Item("model") = Trim(._MODEL)
					dr.Item("idno") = Trim(._VINNO)
					dr.Item("source") = WrkSource
					dr.Item("msrp") = WrkMSRP
					dr.Item("value") = WrkValue
					WrkTCount = WrkTCount + 1
					WrkTValue = WrkTValue + WrkValue
					If WrkComplete = "Y" Then
						ds.Tables(0).Rows.Add(dr)
					Else
						ds2.Tables(0).Rows.Add(dr)
					End If

					If WrkPost Then
						UpdateTXSUPP(._LISTNo, WrkValue)
						'MK 7/14/25 Begin
						With myTXMSRP
							.GetOneRecordP(Trim(myTXSUPPQ._VINNO))
							If WrkSource = "PD" Then
								._OVMSRP = WrkMSRP
							End If
							._OVSOURCE = "P"
							._COMPLETE = WrkComplete
							If .RecordNotFound Then
								._VINNO = Trim(myTXSUPPQ._VINNO)
								._NONTAX = ""
								.AddOneRecordP()
							Else
								.UpdateOneRecordP()
							End If
						End With
						'MK 7/14/25 End
					End If
				End If
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
		myTXSUPPQ.CloseFile()
		myTXSUPP.CloseFile()

	End Sub
	Private Sub WriteTotals()
		If WrkTCount = 0 Then Exit Sub

		'MK 7/14/25 Begin
		'dr2 = ds2.Tables(0).NewRow
		'dr2.Item("tcount") = WrkTCount
		'dr2.Item("tvalue") = WrkTValue
		'ds2.Tables(0).Rows.Add(dr2)
		drTot = dsTot.Tables(0).NewRow
		drTot.Item("tcount") = WrkTCount
		drTot.Item("tvalue") = WrkTValue
		dsTot.Tables(0).Rows.Add(drTot)
		'MK 7/14/25 End
	End Sub
	Private Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Single
		CalcProRate = Gross * Pct
		Return CalcProRate
	End Function
	Private Sub UpdateTXSUPP(ByVal WrkListNo As Integer, ByVal WrkValue As Integer)
		Dim WrkTxSupCd As String()
		Dim WrkPct As Decimal
		Dim TotExempt As Integer

		myTXSUPP.GetOneRecordP(WrkListNo)
		If myTXSUPP.RecordNotFound Then Exit Sub
		With myTXSUPP
			._VALUE = WrkValue
			WrkTxSupCd = GetTXSupCd(Trim(._ASS))
			WrkPct = WrkTxSupCd(0)
			._PVAL = CalcProRate(WrkValue, WrkPct)

			If Trim(._OASS) <> "" Then
				WrkTxSupCd = GetTXSupCd(Trim(._OASS))
				WrkPct = WrkTxSupCd(0)
				._OPVAL = CalcProRate(._OVAL, WrkPct)
				If ._PVAL < ._OPVAL Then
					._OPVAL = ._PVAL
				End If
				TotExempt = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
				._PNET = ._PVAL - ._OPVAL - TotExempt
				If ._PNET < 0 Then
					._PNET = 0
				End If
			End If
			.UpdateOneRecordP()
		End With
	End Sub
	'MK 7/14/25 Begin
	Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkYear As Integer) As Integer
		Dim WrkDeYear As Integer
		Dim WrkValue As Integer
		Dim WrkDepr As Decimal
		'Calculate Assessment Value
		WrkValue = 0
		WrkDeYear = 2024 - WrkYear + 1
		If WrkDeYear < 1 Then
			WrkDeYear = 1
		End If
		WrkDepr = GetTXMSRPDEP(WrkDeYear)
		If WrkMSRP > 0 Then
			WrkValue = WrkMSRP * WrkDepr * WrkBookPct
		End If
		If WrkValue < WrkMinValue Then
			WrkValue = WrkMinValue
		End If
		Return WrkValue
	End Function
	Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
		Dim WrkDepr As Decimal
		If DeprYear < 0 Then DeprYear = 1
		WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
		Return WrkDepr
	End Function
	Private Function GetPriceDigestConfig(ByVal WrkVIN As String, ByVal WrkYear As Integer) As Integer
		Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
		Dim WrkConfig As Integer
		WrkConfig = 0
		myPriceDigestVIN = New PriceDigestAPI.ApiVIN
		With myPriceDigestVIN
			.GetApiVIN(WrkVIN)
			If .IsError Then
				Return 0
			End If
			If WrkYear - .modelYear > 1 Then 'If Vehicle year is more than 1 year different then it's an error
				Return 0
			End If
			WrkConfig = myPriceDigestVIN.configurationId
		End With
		Return WrkConfig
	End Function
	Private Function GetPriceDigestMSRP(ByVal WrkConfig As Integer) As Integer
		Dim myPriceDigestValue As PriceDigestAPI.ApiValue
		Dim WrkMSRP As Integer
		myPriceDigestValue = New PriceDigestAPI.ApiValue
		With myPriceDigestValue
			.GetApiValue(WrkConfig)
			WrkMSRP = .MSRP
		End With
		Return WrkMSRP
	End Function
	Private Function GetPriceDigestComplete(ByVal WrkConfig As Integer) As String
		Dim myPriceDigestSpecs As PriceDigestAPI.ApiSpecs
		Dim WrkComplete As String
		WrkComplete = ""
		myPriceDigestSpecs = New PriceDigestAPI.ApiSpecs
		With myPriceDigestSpecs
			.GetApiSpecs(WrkConfig)
			WrkComplete = .Complete
		End With
		Return WrkComplete
	End Function
	'MK 7/14/25 End
End Module
