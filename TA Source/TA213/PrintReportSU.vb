Imports System.Text
Module PrintReportSU

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXSUPPQ As TXSUPPQ.MyData
Dim myTXBTR As TXBTR.MyData
Dim dsTot As DataSet = New DataSet
Dim DsTXSUPP As DataSet = New DataSet
Dim DsTXBTR As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPrintDist As Boolean
Dim WrkBTR As Boolean
Dim WrkCat As String

Dim WrkExcd(4) As String
Dim WrkExam(4) As Integer
'Report fields
Dim WrkLetter(40) As String
Dim WrkLetterCount(40) As Integer
Dim WrkLetterGross(40) As Long
Dim WrkLetterExam(40) As Long
Dim WrkLetterProrate(40) As Long
Dim WrkLetterCreditGross(40) As Long
Dim WrkLetterCredit(40) As Long
Dim WrkLetterNet(40) As Long
'Buffered files
Dim WrkSupCode(25) As String
Dim WrkSupPct(25) As Decimal
	Public Sub PrtReportSU()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)

	With MyFrmTA213B
		WrkType = "S"
		WrkYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkPrintDist = False
		If .ChkPrtDist.Checked Then
			WrkPrintDist = True
		End If
		WrkBTR = False
		If .ChkBAA.Checked Then
			WrkBTR = True
		End If
		If .ChkNonExempt.Checked Then
			WrkCat = "1"
		Else
			WrkCat = "3"
		End If
	End With

	If dsTot.Tables.Count = 0 Then
		BuildDS(dsTot)
		BufferTXSupcd()
	Else
		dsTot.Clear()
		ClearTotals()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.WrkdsTot = dsTot
		.WrkType = WrkType
		.WrkBTR = WrkBTR
		.Show()
	End With

	End Sub
Private Sub ClearTotals()
	ReDim WrkLetter(40)
	ReDim WrkLetterCount(40)
	ReDim WrkLetterGross(40)
	ReDim WrkLetterProrate(40)
	ReDim WrkLetterCredit(40)
	ReDim WrkLetterCreditGross(40)
	ReDim WrkLetterExam(40)
	ReDim WrkLetterNet(40)
End Sub
Private Sub GetDetail()
Dim WrkTypeDesc As String
Dim WrkTypeFamily As String
Dim WrkQry As String
Dim WrkLet As String
Dim WrkExempt As Integer
Dim WrkTotBTR As Decimal
Dim WrkAssPct As Decimal
Dim WrkGross As Integer
Dim WrkProrate As Integer
Dim WrkCredit As Integer
Dim WrkCreditGross As Integer
Dim WrkNet As Integer
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
	WrkAnd = " *and "
Else
	WrkAnd = " and "
 End If

WrkQry = "CAT = " & MyUtils.Quo(WrkCat)
If Not WrkDistAll Then
	If Not WrkPrintDist Then
		WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
	Else
		WrkQry = WrkQry & WrkAnd & "pdst=" & WrkDist
	End If
End If

    DsTXSUPP = myTXSUPPQ.GetQry("NAME", WrkQry, 0)
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then
	myTXSUPPQ.CloseFile()
	Exit Sub
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

WrkTypeDesc = GetTXTypeDesc(WrkType)
WrkTypeFamily = GetTXTypeFamily(WrkType)

For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
	With DsTXSUPP.Tables(0).Rows(I)
		WrkExcd(0) = .Item("excd1")
		WrkExcd(1) = .Item("excd2")
		WrkExcd(2) = .Item("excd3")
		WrkExcd(3) = .Item("excd4")
		WrkExcd(4) = .Item("excd5")
		WrkExam(0) = .Item("exam1")
		WrkExam(1) = .Item("exam2")
		WrkExam(2) = .Item("exam3")
		WrkExam(3) = .Item("exam4")
		WrkExam(4) = .Item("exam5")

		'Combine into Letter groups
		WrkExempt = 0
			For J = 0 To 4
				If WrkExcd(J) <> "" Then
					K = LookupExem(WrkExcd(J))
					If WrkExam(J) = 0 Then
						WrkExempt = WrkExempt + WrkExFixedAmt(K)
					Else
						WrkExempt = WrkExempt + WrkExam(J)
					End If
				End If
			Next

		WrkGross = .Item("value")
		WrkAssPct = CalcPct(.Item("ass"))
		WrkProrate = CalcAssmt(.Item("value"), WrkAssPct)
		WrkAssPct = CalcPct(.Item("oass"))
		WrkCreditGross = .Item("oval")
		WrkCredit = CalcAssmt(.Item("oval"), WrkAssPct)
		If WrkCredit > WrkProrate Then
			WrkCredit = WrkProrate
		End If
		WrkNet = WrkProrate - WrkCredit - WrkExempt

		'Add Exemption groups
		WrkLet = .Item("lett")
		K = LookupWrkLetter(WrkLet)
		WrkLetter(K) = WrkLet
		WrkLetterCount(K) = WrkLetterCount(K) + 1
		WrkLetterGross(K) = WrkLetterGross(K) + WrkGross
		WrkLetterProrate(K) = WrkLetterProrate(K) + WrkProrate
		WrkLetterCreditGross(K) = WrkLetterCreditGross(K) + WrkCreditGross
		WrkLetterCredit(K) = WrkLetterCredit(K) + WrkCredit
		WrkLetterExam(K) = WrkLetterExam(K) + WrkExempt
		WrkLetterNet(K) = WrkLetterNet(K) + WrkNet

		If WrkBTR Then
			myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
			If Not myTXBTR.RecordNotFound Then
				With myTXBTR
					WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
					WrkLetterGross(K) = WrkLetterGross(K) + WrkTotBTR
					WrkLetterNet(K) = WrkLetterNet(K) + WrkTotBTR
				End With
			End If
		End If
	End With

NextRec:
With myFrmProgress
	WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
	If SavePct <> WrkPct Then
		.ProgBar1.Value = WrkPct
		.Refresh()
		SavePct = WrkPct
		Application.DoEvents()
	End If
End With
Next

'Totals
For I = 0 To 40
	If WrkLetter(I) = Nothing Then Exit For
	dr = dsTot.Tables(0).NewRow
	dr.Item("totletter") = WrkLetter(I)
	dr.Item("totcount") = WrkLetterCount(I)
	dr.Item("totgross") = WrkLetterGross(I)
	dr.Item("totprorate") = WrkLetterProrate(I)
	dr.Item("totcreditgross") = WrkLetterCreditGross(I)
	dr.Item("totcredit") = WrkLetterCredit(I)
	dr.Item("totexam") = WrkLetterExam(I)
	dr.Item("totnet") = WrkLetterNet(I)
	dsTot.Tables(0).Rows.Add(dr)
Next

myFrmProgress.Close()
myTXSUPPQ.CloseFile()

End Sub
	Public Function CalcPct(ByVal AssCd As String) As Decimal
		Dim K As Integer
		Dim WrkPct As Decimal

		K = LookupTxSupcd(AssCd)
		WrkPct = WrkSupPct(K)
		Return WrkPct
	End Function
	Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
		Dim WrkProRate As Decimal

    WrkProRate = MyUtils.Round(Value * Pct, 0)
		Return WrkProRate
	End Function
Private Sub BufferTXSupcd()
		 Dim I As Integer

		 Dim myTXSUPCD As TXSUPCD.MyData
		 Dim dsTXSupcd As DataSet = New DataSet

		 myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)

		 dsTXSupcd = myTXSUPCD.GetAllData
		 For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
			With dsTXSupcd.Tables(0).Rows(I)
				WrkSupCode(I) = .Item("scod")
				WrkSupPct(I) = .Item("spct")
			End With
		Next

End Sub
Private Function LookupTxSupcd(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next

End Function
  Private Function LookupWrkLetter(ByVal Letter As String) As Integer
    Dim I As Integer

    For I = 0 To WrkLetter.GetUpperBound(0)
      If Trim(WrkLetter(I)) = "" Then
        Return I
      End If
      If Trim(Letter) = Trim(WrkLetter(I)) Then
        Return I
      End If
    Next

  End Function
End Module






