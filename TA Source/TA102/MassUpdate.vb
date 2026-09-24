Imports System.Text
Module MassUpdate
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREAL As TXREAL.MyData
Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkCode As String
Dim WrkAmount As Integer
	Public Sub UpdateExam()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREAL = New TXREAL.mydata(MyDBConnect)

	With MyFrmTA102C
		WrkCode = .TxtCode.Text
    WrkAmount = MyUtils.CnvSng(.TxtFixam.Text)
	End With

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

	GetDetail()

	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.Wrkds = ds
		.WrkRptId = "Update"
		.WrkCode = WrkCode
		.Show()
	End With
	End Sub
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("oldamount", Type.GetType("System.Int64"))
    .Columns.Add("newamount", Type.GetType("System.Int64"))
  End With
  ds.Tables.Add(myTable)
End Sub
Public Sub GetDetail()
	Dim WrkSort As String
  Dim WrkQry As String
	Dim Counter As Integer
  Dim J As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkOldAmount As Integer

  If myDBConnect.ServerAS400 Then
    WrkOr = " *or "
    WrkAnd = " *and "
  Else
    WrkOr = " or "
    WrkAnd = " and "
   End If

	Counter = 0
  WrkSort = ""
  WrkQry = "EXCD1=" & MyUtils.Quo(WrkCode) & WrkOr & "EXCD2=" & MyUtils.Quo(WrkCode) & WrkOr & _
    "EXCD3=" & MyUtils.Quo(WrkCode) & WrkOr & "EXCD4=" & MyUtils.Quo(WrkCode) & WrkOr & _
    "EXCD5=" & MyUtils.Quo(WrkCode)
	myTXREALQ.OpenQry(WrkSort, WrkQry)

  myFrmProgress = New FrmProgress
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

ReadNext:
	myTXREALQ.ReadQry()
	If Not myTXREALQ.IsEOF Then
		With myTXREALQ
			Counter = Counter + 1
			WrkExcd(0) = Trim(._EXCD1)
			WrkExcd(1) = Trim(._EXCD2)
			WrkExcd(2) = Trim(._EXCD3)
			WrkExcd(3) = Trim(._EXCD4)
			WrkExcd(4) = Trim(._EXCD5)
			WrkExcd(5) = Trim(._EXCD6)
			WrkExcd(6) = Trim(._EXCD7)
			WrkExam(0) = ._EXAM1
			WrkExam(1) = ._EXAM2
			WrkExam(2) = ._EXAM3
			WrkExam(3) = ._EXAM4
			WrkExam(4) = ._EXAM5
			WrkExam(5) = ._EXAM6
			WrkExam(6) = ._EXAM7
			For J = 0 To 6
				If WrkExcd(J) = WrkCode Then
					WrkOldAmount = WrkExam(J)
					WrkExam(J) = WrkAmount
				End If
			Next J
			UpdateTXREAL(._LISTNO, WrkAmount)
			dr = ds.Tables(0).NewRow
			dr.Item("listno") = ._LISTNO
			dr.Item("name") = Trim(._NAME)
			dr.Item("oldamount") = WrkOldAmount
			dr.Item("newamount") = WrkAmount
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

CloseFiles:
	myTXREALQ.CloseFile()

End Sub
Private Sub UpdateTXREAL(ByVal ListNo As Integer, ByVal Exam As Integer)
	Dim WrkTotExam As Integer
  Dim J As Integer

	myTXREAL.GetOneRecordP(ListNo)
	With myTXREAL
		._EXAM1 = WrkExam(0)
		._EXAM2 = WrkExam(1)
		._EXAM3 = WrkExam(2)
		._EXAM4 = WrkExam(3)
		._EXAM5 = WrkExam(4)
		._EXAM6 = WrkExam(5)
		._EXAM7 = WrkExam(6)
		For J = 0 To 6
			WrkTotExam = WrkTotExam + WrkExam(J)
		Next
		._NET = ._GROSS - WrkTotExam
		.UpdateOneRecordP()
	End With

End Sub
End Module






