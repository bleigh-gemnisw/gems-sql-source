Imports System.Text
Module PrintReportRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREALCQ As TXREALCQ.MyData
Dim myTXBTR As TXBTR.MyData
Dim myTXBTRC As TXBTRC.MyData
Dim dsTot As DataSet = New DataSet
Dim DsTXREAL As DataSet = New DataSet
Dim DsTXBTR As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkBTR As Boolean
Dim WrkPrintDist As Boolean
Dim WrkCat As String

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
'Report fields
Dim WrkLetter(40) As String
Dim WrkLetterCount(40) As Integer
Dim WrkLetterGross(40) As Long
Dim WrkLetterExam(40) As Long
Dim WrkLetterNet(40) As Long
	Public Sub PrtReportRE()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)
	myTXBTRC = New TXBTRC.mydata(MyDBConnect)

	With MyFrmTA213B
		WrkType = "R"
		WrkYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkPrintDist = False
		If .ChkPrtDist.Checked Then
			WrkPrintDist = True
		End If
		WrkFrozenFile = False
		If .ChkFrozenFile.Checked Then
			WrkFrozenFile = True
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
  ReDim WrkLetterExam(40)
  ReDim WrkLetterNet(40)
End Sub
Private Sub GetDetail()
Dim WrkTypeDesc As String
Dim WrkTypeFamily As String
Dim WrkQry As String
Dim WrkAssCode(6) As Integer
Dim WrkGross(6) As Integer
Dim WrkExempt As Integer
Dim WrkLet As String
Dim WrkTotBTR As Decimal
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

If Not WrkFrozenFile Then
      DsTXREAL = myTXREALQ.GetQry("FCCOD, NAME", WrkQry, 0)
    Else
      DsTXREAL = myTXREALCQ.GetQry("FCCOD, NAME", WrkQry, 0)
    End If
If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()

WrkTypeDesc = GetTXTypeDesc(WrkType)
WrkTypeFamily = GetTXTypeFamily(WrkType)

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)

    WrkAssCode(0) = .Item("code1")
    WrkAssCode(1) = .Item("code2")
    WrkAssCode(2) = .Item("code3")
    WrkAssCode(3) = .Item("code4")
    WrkAssCode(4) = .Item("code5")
    WrkAssCode(5) = .Item("code6")
    WrkAssCode(6) = .Item("code7")
    WrkGross(0) = .Item("ass1")
    WrkGross(1) = .Item("ass2")
    WrkGross(2) = .Item("ass3")
    WrkGross(3) = .Item("ass4")
    WrkGross(4) = .Item("ass5")
    WrkGross(5) = .Item("ass6")
    WrkGross(6) = .Item("ass7")
		If WrkBTR Then
			If Not WrkFrozenFile Then
				myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
				If Not myTXBTR.RecordNotFound Then
					With myTXBTR
						WrkGross(0) = WrkGross(0) + ._BASS1
						WrkGross(1) = WrkGross(1) + ._BASS2
						WrkGross(2) = WrkGross(2) + ._BASS3
						WrkGross(3) = WrkGross(3) + ._BASS4
						WrkGross(4) = WrkGross(4) + ._BASS5
						WrkGross(5) = WrkGross(5) + ._BASS6
						WrkGross(6) = WrkGross(6) + ._BASS7
						WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
					End With
				End If
			Else
        myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
				If Not myTXBTRC.RecordNotFound Then
					With myTXBTRC
						WrkGross(0) = WrkGross(0) + ._BASS1
						WrkGross(1) = WrkGross(1) + ._BASS2
						WrkGross(2) = WrkGross(2) + ._BASS3
						WrkGross(3) = WrkGross(3) + ._BASS4
						WrkGross(4) = WrkGross(4) + ._BASS5
						WrkGross(5) = WrkGross(5) + ._BASS6
						WrkGross(6) = WrkGross(6) + ._BASS7
						WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
					End With
				End If
			End If
		End If

		WrkExcd(0) = .Item("excd1")
    WrkExcd(1) = .Item("excd2")
    WrkExcd(2) = .Item("excd3")
    WrkExcd(3) = .Item("excd4")
    WrkExcd(4) = .Item("excd5")
    WrkExcd(5) = .Item("excd6")
    WrkExcd(6) = .Item("excd7")
    WrkExam(0) = .Item("exam1")
    WrkExam(1) = .Item("exam2")
    WrkExam(2) = .Item("exam3")
    WrkExam(3) = .Item("exam4")
    WrkExam(4) = .Item("exam5")
    WrkExam(5) = .Item("exam6")
    WrkExam(6) = .Item("exam7")

    'Combine into Letter groups
    WrkExempt = 0
      For J = 0 To 6
        If WrkExcd(J) <> "" Then
          K = LookupExem(WrkExcd(J))
          If WrkExam(J) = 0 Then
            WrkExempt = WrkExempt + WrkExFixedAmt(K)
          Else
            WrkExempt = WrkExempt + WrkExam(J)
          End If
        End If
      Next

    'Add Exemption groups
    WrkLet = .Item("lett")
    K = LookupWrkLetter(WrkLet)
    WrkLetter(K) = WrkLet
    WrkLetterCount(K) = WrkLetterCount(K) + 1
    WrkLetterGross(K) = WrkLetterGross(K) + .Item("gross")
    WrkLetterExam(K) = WrkLetterExam(K) + WrkExempt
    WrkLetterNet(K) = WrkLetterNet(K) + .Item("gross") - WrkExempt

		If WrkBTR Then
			If Not WrkFrozenFile Then
				myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
				If Not myTXBTR.RecordNotFound Then
					With myTXBTR
						WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
						WrkLetterGross(K) = WrkLetterGross(K) + WrkTotBTR
						WrkLetterNet(K) = WrkLetterNet(K) + WrkTotBTR
					End With
				End If
			Else
        myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
				If Not myTXBTRC.RecordNotFound Then
					With myTXBTRC
						WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
						WrkLetterGross(K) = WrkLetterGross(K) + WrkTotBTR
						WrkLetterNet(K) = WrkLetterNet(K) + WrkTotBTR
					End With
				End If
			End If
		End If
	End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
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
  dr.Item("totexam") = WrkLetterExam(I)
  dr.Item("totnet") = WrkLetterNet(I)
  dsTot.Tables(0).Rows.Add(dr)
Next

myFrmProgress.Close()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
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






