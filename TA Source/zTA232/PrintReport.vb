Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXBTR As TXBTR.myData
Dim myTXPHIN As TXPHIN.myData

Dim dsTXREALQ As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkPost As Boolean

  Public Sub PrtReport()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)
	myTXPHIN = New TXPHIN.mydata(MyDBConnect)

	With MyFrmTA232B
		If .ChkPost.Checked Then WrkPost = True
	End With

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.wrkds = ds
  MyCrViewer.WrkPost = WrkPost
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Gross", Type.GetType("System.Int32"))
			.Columns.Add("BAA", Type.GetType("System.Int32"))
			.Columns.Add("FullValue", Type.GetType("System.Int32"))
		End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAnd As String
Dim WrkFullValue As Long
Dim Counter As Long

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = ""
Counter = 0

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

myTXREALQ.OpenQry(WrkSort, WrkQry)

ReadNext:
	myTXREALQ.ReadQry()
	If Not myTXREALQ.IsEOF Then
		Counter = Counter + 1
	With myTXREALQ
		dr = ds.Tables(0).NewRow
		dr.Item("listno") = ._LISTNO
		dr.Item("name") = Trim(._NAME)
		dr.Item("gross") = ._GROSS
		dr.Item("baa") = ._BTR
		WrkFullValue = ._GROSS + ._BTR
		dr.Item("fullvalue") = WrkFullValue
		ds.Tables(0).Rows.Add(dr)
	End With

	If Not WrkPost Then GoTo NextRec

	myTXPHIN.GetOneRecordP(myTXREALQ._LISTNO)
	With myTXPHIN
		.GetOneRecordP(myTXREALQ._LISTNO)
		._FULGRS = WrkFullValue
		._FULA1 = myTXREALQ._ASS1
		._FULA2 = myTXREALQ._ASS2
		._FULA3 = myTXREALQ._ASS3
		._FULA4 = myTXREALQ._ASS4
		._FULA5 = myTXREALQ._ASS5
		._FULA6 = myTXREALQ._ASS6
		._FULA7 = myTXREALQ._ASS7
		If myTXREALQ._BTR <> 0 Then
			myTXBTR.GetOneRecordP(myTXREALQ._LISTNO, "R")
			._FULA1 = ._FULA1 + myTXBTR._BASS1
			._FULA2 = ._FULA2 + myTXBTR._BASS2
			._FULA3 = ._FULA3 + myTXBTR._BASS3
			._FULA4 = ._FULA4 + myTXBTR._BASS4
			._FULA5 = ._FULA5 + myTXBTR._BASS5
			._FULA6 = ._FULA6 + myTXBTR._BASS6
			._FULA7 = ._FULA7 + myTXBTR._BASS7
		End If
		._FULC1 = myTXREALQ._CODE1
		._FULC2 = myTXREALQ._CODE2
		._FULC3 = myTXREALQ._CODE3
		._FULC4 = myTXREALQ._CODE4
		._FULC5 = myTXREALQ._CODE5
		._FULC6 = myTXREALQ._CODE6
		._FULC7 = myTXREALQ._CODE7
		If myTXPHIN.RecordNotFound Then
			._PLISTNo = myTXREALQ._LISTNO
			.AddOneRecordP()
		Else
			.UpdateOneRecordP()
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

Done:
myFrmProgress.Close()
myTXREALQ.CloseFile()

End Sub
End Module






