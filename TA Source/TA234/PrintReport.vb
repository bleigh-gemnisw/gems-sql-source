Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINV As TXINVQ.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen
Dim WrkGLYear1 As Integer
Dim WrkGLYear2 As Integer
Dim WrkIncrease As Boolean
Dim WrkChanges As Boolean
Dim WrkType As String

	Public Sub PrtReport()

	myTXINV = New TXINVQ.mydata(MyDBConnect)

	With MyFrmTA234B
    WrkGLYear1 = MyUtils.CnvSng(.TxtGLYear1.Text)
    WrkGLYear2 = MyUtils.CnvSng(.TxtGLYear2.Text)
		If .RbRE.Checked Then
			WrkType = "R"
		Else
			WrkType = "P"
		End If
		WrkIncrease = .RbIncrease.Checked
		WrkChanges = .RbChanges.Checked
	End With

	If ds.Tables.Count = 0 Then
		BuildDS(ds)
	Else
		ds.Clear()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	MyCrViewer.wrkds = ds
	MyCrViewer.WrkType = WrkType
	MyCrViewer.Show()

	End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkAnd As String
Dim WrkOr As String
Dim Counter As Integer
Dim SaveListNo As Integer
Dim SaveGross As Integer
Dim SaveName As String
Dim SaveLocation As String

If myDBConnect.ServerAS400 Then
	WrkAnd = " *and "
	WrkOr = " *or "
Else
	WrkAnd = " and "
	WrkOr = " or "
End If

WrkSort = "LIST#, YEAR desc"
WrkQry = "icode<>'I'" & WrkAnd & "TYPE = " & MyUtils.Quo(WrkType) & WrkAnd & "YEAR = " & WrkGLYear1 & WrkOr & _
  "icode<>'I'" & WrkAnd & "TYPE = " & MyUtils.Quo(WrkType) & WrkAnd & "YEAR = " & WrkGLYear2
Counter = 0
SaveListNo = 0
SaveGross = 0
SaveName = String.Empty
SaveLocation = String.Empty

myTXINV.OpenQry(WrkSort, WrkQry)
myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXINV.ReadQry()
	If Not myTXINV.IsEOF Then
	With myTXINV
		Counter = Counter + 1
		If SaveListNo = ._LISTNo Then
			'Filter increase only
			If WrkIncrease Then
				If SaveGross <= ._GROSS Then
					 GoTo NextRec
				End If
			End If
			'Filter changes only
			If WrkChanges Then
				If SaveGross = ._GROSS Then
					 GoTo NextRec
				End If
			End If
			dr = ds.Tables(0).NewRow
			dr.Item("listno") = SaveListNo
			dr.Item("name") = SaveName
			dr.Item("propdesc") = SaveLocation
			dr.Item("gross") = SaveGross
			dr.Item("ogross") = ._GROSS
			dr.Item("diff") = SaveGross - ._GROSS
			ds.Tables(0).Rows.Add(dr)
		End If
NextRec:
		SaveListNo = ._LISTNo
		SaveName = Trim(._NAME)
		SaveLocation = Trim(._LOCNo) & " " & Trim(._LOC)
		SaveGross = ._GROSS
	End With

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
myTXINV.CloseFile()

End Sub
End Module






