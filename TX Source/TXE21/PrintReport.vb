Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALCQ As TXREALCQ.MyData
Dim myTPaymnt As TPAYMNT.MyData
Dim myTXCOEB As TXCOEB.MyData

Dim ds As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim DsTXREALC As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drTot As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkSelBank As String

Dim WrkList As Integer
Dim WrkCode(6) As Integer
Dim WrkAss(6) As Integer
Dim WrkCCAss(6) As Integer
Dim WrkExcd(6) As String
Dim WrkCCExcd(6) As String
Dim WrkExam(6) As Integer
Dim WrkCCExam(6) As Integer
Dim WrkGross As Integer
Dim WrkExempt As Integer
Dim WrkNet As Integer
Dim WrkTaxAmount As Double
Dim WrkTaxTotal As Double
Dim WrkCC As Boolean
Dim WrkFrozenCode As String
Dim WrkSTBenefit As Double
Dim WrkTownBenefit As Double
	Public Sub PrtReport()
	Dim Good As Boolean
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
	myTPaymnt = New TPAYMNT.mydata(MyDBConnect)
	myTXCOEB = New TXCOEB.mydata(MyDBConnect)

	With MyFrmTXE21B
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
		WrkSelBank = .TxtBankCd.Text
	End With

	If ds.Tables.Count = 0 Then
		BuildDS(ds)
	Else
		ds.Clear()
	End If

 If WrkExCode(0) = Nothing Then
	 BufferExem()
 End If
 Good = GetDetail()
 If Not Good Then Exit Sub

Done:
	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.wrkds = ds
		.Show()
	End With

	End Sub
Private Function GetDetail() As Boolean
Dim Good As Boolean
Dim WrkType As String
Dim WrkDist As Integer
Dim WrkPhase As String
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String
Dim WrkGross10ML As Integer
Dim WrkBankCode As String
Dim WrkBankDesc As String
Dim SaveBank As String

Counter = 0
WrkType = "R"
WrkDist = 0
WrkPhase = ""
SaveBank = ""
WrkBankDesc = ""

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

If WrkSelBank <> String.Empty Then
  WrkQry = "BKCD=" & MyUtils.Quo(WrkSelBank)
Else
	WrkQry = "BKCD <> '  '"
End If
WrkSort = "BKCD, NAME, LIST#"

Good = GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
If Not Good Then Return False

GetMillRate(WrkGLYear, WrkType, WrkDist)
myTXREALCQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXREALCQ.ReadQry()
	If Not myTXREALCQ.IsEOF Then
	With myTXREALCQ
		Counter = Counter + 1
		'Omit Exempt properties
		If Trim(._CAT) = "3" Then GoTo NextRec

		WrkCC = False
		If ._CCNO > 0 Then
			WrkCC = True
		End If
		WrkList = ._LISTNO
		WrkBankCode = Trim(._BKCD)
		If WrkBankCode <> SaveBank Then
			WrkBankDesc = GetTXBanksDesc(WrkBankCode)
			SaveBank = WrkBankCode
		End If
		WrkCode(0) = ._CODE1
		WrkCode(1) = ._CODE2
		WrkCode(2) = ._CODE3
		WrkCode(3) = ._CODE4
		WrkCode(4) = ._CODE5
		WrkCode(5) = ._CODE6
		WrkCode(6) = ._CODE7
		WrkAss(0) = ._ASS1
		WrkAss(1) = ._ASS2
		WrkAss(2) = ._ASS3
		WrkAss(3) = ._ASS4
		WrkAss(4) = ._ASS5
		WrkAss(5) = ._ASS6
		WrkAss(6) = ._ASS7
		WrkExcd(0) = ._EXCD1
		WrkExcd(1) = ._EXCD2
		WrkExcd(2) = ._EXCD3
		WrkExcd(3) = ._EXCD4
		WrkExcd(4) = ._EXCD5
		WrkExcd(5) = ._EXCD6
		WrkExcd(6) = ._EXCD7
		WrkExam(0) = ._EXAM1
		WrkExam(1) = ._EXAM2
		WrkExam(2) = ._EXAM3
		WrkExam(3) = ._EXAM4
		WrkExam(4) = ._EXAM5
		WrkExam(5) = ._EXAM6
		WrkExam(6) = ._EXAM7
		WrkCCAss(0) = ._CASS1
		WrkCCAss(1) = ._CASS2
		WrkCCAss(2) = ._CASS3
		WrkCCAss(3) = ._CASS4
		WrkCCAss(4) = ._CASS5
		WrkCCAss(5) = ._CASS6
		WrkCCAss(6) = ._CASS7
		WrkCCExcd(0) = ._CCCD1
		WrkCCExcd(1) = ._CCCD2
		WrkCCExcd(2) = ._CCCD3
		WrkCCExcd(3) = ._CCCD4
		WrkCCExcd(4) = ._CCCD5
		WrkCCExcd(5) = ._CCCD6
		WrkCCExcd(6) = ._CCCD7
		WrkCCExam(0) = ._CEXA1
		WrkCCExam(1) = ._CEXA2
		WrkCCExam(2) = ._CEXA3
		WrkCCExam(3) = ._CEXA4
		WrkCCExam(4) = ._CEXA5
		WrkCCExam(5) = ._CEXA6
		WrkCCExam(6) = ._CEXA7
		WrkExempt = 0
		WrkGross10ML = 0
		If WrkCC Then
			WrkGross = ._CCGRS
			WrkExempt = ._CCEX
		Else
			WrkGross = ._GROSS + ._BTR
			For J = 0 To 6
				If WrkCode(J) = 71 Then
					If Not WrkCC Then
						WrkGross10ML = WrkGross10ML + WrkAss(J)
					Else
						WrkGross10ML = WrkGross10ML + WrkCCAss(J)
					End If
				End If
				If WrkExcd(J) <> "" And WrkExam(J) = 0 Then
					K = LookupExem(WrkExcd(J))
					WrkExempt = WrkExempt + WrkExFixedAmt(K)
				Else
					WrkExempt = WrkExempt + WrkExam(J)
				End If
			Next
		End If
		WrkNet = WrkGross - WrkExempt
		If WrkNet < 0 Then WrkNet = 0
		WrkTaxAmount = (WrkNet - WrkGross10ML) * MrateMillrt
		WrkTaxAmount = WrkTaxAmount + (WrkGross10ML * 0.01)
		WrkSTBenefit = 0
		WrkTownBenefit = ._TWNBN
		WrkFrozenCode = Trim(._FCCOD)
		Select Case WrkFrozenCode
		Case "F" 'Frozen
      WrkTaxTotal = MyUtils.Round(._FTAX, 2) - WrkTownBenefit
      WrkSTBenefit = MyUtils.Round(WrkTaxAmount - WrkTaxTotal - WrkTownBenefit, 2)
		Case "C" 'Heart/Circuit Breaker
			WrkSTBenefit = ._FTAX
			WrkTaxTotal = WrkTaxAmount - WrkSTBenefit - WrkTownBenefit
		Case Else	'Normal
			WrkTaxTotal = WrkTaxAmount - WrkTownBenefit
		End Select
		With myTPaymnt
			.In_ListNo = WrkList
			.In_Type = WrkType
			.In_Year = WrkGLYear
			.In_Dst = WrkDist
			.In_Phs = WrkPhase
			.In_TaxT = WrkTaxTotal
			.CalcPaySplit()
			WrkTaxTotal = .Out_TaxT
		End With

		'Create Report
		dr = ds.Tables(0).NewRow
		dr.Item("bank") = WrkBankCode & " " & WrkBankDesc
		dr.Item("listno") = WrkList
		dr.Item("name") = Trim(._NAME)
		dr.Item("propdesc") = Trim(._LOCNO) & " " & Trim(._LOC)
		dr.Item("taxtot") = WrkTaxTotal
		If Trim(._BTC) = "BT" Then
			dr.Item("backtax") = True
		Else
			dr.Item("backtax") = False
		End If
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
myTXREALCQ.CloseFile()
Return True

End Function
End Module






