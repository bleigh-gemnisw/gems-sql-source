Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXREALC As TXREALC.myData

Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
'General
Dim WrkBank As String
Dim WrkPost As Boolean
Dim WrkGLYear As Integer
Dim WrkAnd As String
Dim WrkOr As String
	Public Sub PrtReport()

	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXREALC = New TXREALC.mydata(MyDBConnect)

	With MyFrmTXE45B
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkBank = Trim(.TxtBankCd.Text)
    WrkPost = .ChkPost.Checked
	End With

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

	GetDetail()

Done:
	MyCrViewer = New FrmCrViewer
	MyCrViewer.Wrkds = ds
	MyCrViewer.WrkPost = WrkPost
	MyCrViewer.Show()

	End Sub
	Private Sub BuildDS()
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("Listno", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Bkcd", Type.GetType("System.String"))
			.Columns.Add("Bksr", Type.GetType("System.String"))
		End With
		ds.Tables.Add(myTable)
	End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim Counter As Integer

If MyServer = "DB2" Then
	WrkAnd = " *and "
	WrkOr = " *or "
Else
	WrkAnd = " and "
	WrkOr = " or "
End If
If MyServer = "SQL" Then
	MyBlocking = False
Else
	MyBlocking = True
End If

WrkSort = "LIST#"
WrkQry = "icode<>'I'" & WrkAnd & "YEAR = " & (WrkGLYear) & WrkAnd & "TYPE='R'"
If WrkBank <> "" Then
  WrkQry = WrkQry & WrkAnd & "BKCD = " & MyUtils.Quo(WrkBank)
Else
  WrkQry = WrkQry & WrkAnd & "BKCD <> ' '"
  WrkQry = WrkQry & WrkOr & "icode<>'I'" & WrkAnd & "BKSR <> ' '" & WrkAnd & "YEAR = " & (WrkGLYear) & WrkAnd & "TYPE='R'"
End If
myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
	myTXINVQ.ReadQry()
	If Not myTXINVQ.IsEOF Then
		Counter = Counter + 1
		With myTXREALC
			.GetOneRecordP(myTXINVQ._LISTNo)
			If .RecordNotFound Then GoTo NextRec
			If WrkPost Then
				._BKCD = myTXINVQ._BKCD
				._BKSV = myTXINVQ._BKSR
				.UpdateOneRecordP()
			End If
		End With

		With myTXINVQ
			dr = ds.Tables(0).NewRow
			dr.Item("listno") = ._LISTNo
			dr.Item("name") = Trim(._NAME)
			dr.Item("bkcd") = Trim(._BKCD)
			dr.Item("bksr") = Trim(._BKSR)
		End With
		ds.Tables(0).Rows.Add(dr)

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
myTXINVQ.CloseFile()

End Sub
Private Sub UpdateTXREALC(ByVal WrkListNo As Integer)

	With myTXREALC
		.GetOneRecordP(WrkListNo)
		If .RecordNotFound Then Exit Sub
		If WrkPost Then
			._BKCD = myTXINVQ._BKCD
			._BKSV = myTXINVQ._BKSR
			.UpdateOneRecordP()
		End If
	End With

	With myTXINVQ
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._LISTNo
		dr.Item("name") = Trim(._NAME)
		dr.Item("bkcd") = Trim(._BKCD)
		dr.Item("bksr") = Trim(._BKSR)
	End With
	ds.Tables(0).Rows.Add(dr)
End Sub
End Module






