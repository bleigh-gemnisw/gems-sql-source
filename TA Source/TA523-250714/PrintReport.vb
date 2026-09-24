Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim found As Boolean
Dim myTXSUPPQ As TXSUPPQ.MyData
Dim myTXSUPP As TXSUPP.MyData
Dim myTXMCTL As TXMCTL.MyData

Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXSUPPQ As DataSet = New DataSet
Dim dr As Data.DataRow
Dim dr2 As Data.DataRow

'Screen
Dim WrkVehYear As Integer
Dim WrkPriceSome As Boolean
Dim WrkRoundDown As Boolean
Dim WrkPost As Boolean

'Control File
Dim WrkValuePct As Decimal
Dim WrkValueMin As Integer

'Totals
Dim WrkTCount As Integer
Dim WrkTValue As Integer
	Public Sub PrtReport()

	myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
	myTXSUPP = New TXSUPP.mydata(MyDBConnect)
	myTXMCTL = New TXMCTL.mydata(MyDBConnect)

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
		ds2.Clear()
		ClearTotals()
	End If
    GetTXMCTL()
    'added 10/18/2023
    If MyFrmTA523B.RbPct80.Checked Then
      WrkValuePct = 0.8
    End If

    GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	MyCrViewer.wrkds = ds
	MyCrViewer.wrkds2 = ds2
	MyCrViewer.Show()

	End Sub
Private Sub GetTXMCTL()
	myTXMCTL = New TXMCTL.mydata(MyDBConnect)
	myTXMCTL.GetOneRecordP(1)
	If Not myTXMCTL.RecordNotFound Then
		With myTXMCTL
			WrkValuePct = ._VALPER
			WrkValueMin = ._VALMIN
		End With
	End If
End Sub
Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With (myTable)
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("oname", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("value", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TValue", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

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
Dim WrkValue As Integer
Dim Good As Boolean

WrkSort = "MAKE, YEAR, MODEL, CLASS"
With MyFrmTA523B
  WrkVehYear = MyUtils.CnvSng(.TxtVehYear.Text)
  WrkPriceSome = .RbPriceSome.Checked
  WrkPost = .ChkUpdate.Checked
  WrkRoundDown = .RbDown.Checked
End With

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

counter = 0
WrkQry = "CAT = '1'" & WrkAnd & "VALUE=0" & WrkAnd & "MSRP>0" & WrkAnd & "YEAR>=" & WrkVehYear
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
    If WrkPriceSome Then
      Select Case ._CLASS
      Case 1, 2, 3, 4, 12
        Good = True
      Case Else
        Good = False
      End Select
    Else
      Good = True
    End If
    If Not Good Then GoTo ReadNext
    WrkValue = 0
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._LISTNo
		dr.Item("Oname") = Trim(._NAME)
		dr.Item("class") = ._CLASS
		dr.Item("year") = ._YEAR
		dr.Item("make") = Trim(._MAKE)
		dr.Item("model") = Trim(._MODEL)
		dr.Item("idno") = Trim(._VINNO)

		WrkValue = ._MSRP * WrkValuePct
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

		If WrkValueMin > 0 Then
			If WrkValueMin > WrkValue Then
				WrkValue = WrkValueMin
			End If
		End If
		If WrkValue > 0 Then
			dr.Item("value") = WrkValue
			WrkTCount = WrkTCount + 1
			WrkTValue = WrkTValue + WrkValue
			ds.Tables(0).Rows.Add(dr)
		End If
		If WrkPost Then
			UpdateTXSUPP(._LISTNo, WrkValue)
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

  dr2 = ds2.Tables(0).NewRow
  dr2.Item("tcount") = WrkTCount
  dr2.Item("tvalue") = WrkTValue
  ds2.Tables(0).Rows.Add(dr2)
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
End Module






