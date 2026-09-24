Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREAL As TXREAL.MyData
Dim myTXPHIN As TXPHIN.myData
Dim myTXBTR As TXBTR.myData

Dim dsTXREALQ As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim WrkPIPct As Decimal
Dim WrkPost As Boolean

  Public Sub PrtReport()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREAL = New TXReal.mydata(MyDBConnect)
	myTXPHIN = New TXPHIN.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)

	With MyFrmTA233B
    WrkPIPct = MyUtils.CnvSng(.TxtPIPct.Text) / 100
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
			.Columns.Add("Current", Type.GetType("System.Int32"))
			.Columns.Add("Prior", Type.GetType("System.Int32"))
			.Columns.Add("PhaseIn", Type.GetType("System.Int32"))
		End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkAnd As String
Dim WrkCurrent As Long
Dim WrkDiff As Long
Dim WrkPrior As Long
Dim WrkPhaseIn As Long
Dim WrkAdj1 As Long
Dim WrkAdj2 As Long
Dim WrkAdj3 As Long
Dim WrkAdj4 As Long
Dim WrkAdj5 As Long
Dim WrkAdj6 As Long
Dim WrkAdj7 As Long
Dim WrkBTR As Boolean
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
	End With

	WrkCurrent = 0
	WrkPrior = 0
	WrkPhaseIn = 0
	myTXPHIN.GetOneRecordP(myTXREALQ._LISTNO)
	If Not myTXPHIN.RecordNotFound Then
		With myTXPHIN
			WrkCurrent = ._FULGRS
			WrkPrior = ._CAPGRS
			WrkDiff = WrkCurrent - WrkPrior
			If WrkDiff >= 0 Then
				WrkPhaseIn = WrkPrior + (WrkDiff * WrkPIPct)
			Else
				WrkPhaseIn = WrkCurrent
			End If
		End With
	End If
	dr.Item("current") = WrkCurrent
	dr.Item("prior") = WrkPrior
	dr.Item("phasein") = WrkPhaseIn
	ds.Tables(0).Rows.Add(dr)

	If Not WrkPost Then GoTo NextRec

	WrkAdj1 = 0
	WrkAdj2 = 0
	WrkAdj3 = 0
	WrkAdj4 = 0
	WrkAdj5 = 0
	WrkAdj6 = 0
	WrkAdj7 = 0

	With myTXPHIN
		.GetOneRecordP(myTXREALQ._LISTNO)
		If Not myTXPHIN.RecordNotFound Then
			With myTXPHIN
				._ADJGRS = WrkPhaseIn
				If ._FULGRS > 0 Then
          WrkAdj2 = MyUtils.Round((._FULA2 / ._FULGRS) * WrkPhaseIn, 0)
          WrkAdj3 = MyUtils.Round((._FULA3 / ._FULGRS) * WrkPhaseIn, 0)
          WrkAdj4 = MyUtils.Round((._FULA4 / ._FULGRS) * WrkPhaseIn, 0)
          WrkAdj5 = MyUtils.Round((._FULA5 / ._FULGRS) * WrkPhaseIn, 0)
          WrkAdj6 = MyUtils.Round((._FULA6 / ._FULGRS) * WrkPhaseIn, 0)
          WrkAdj7 = MyUtils.Round((._FULA7 / ._FULGRS) * WrkPhaseIn, 0)
				End If
					WrkAdj1 = WrkPhaseIn - WrkAdj2 - WrkAdj3 - WrkAdj4 - WrkAdj5 - WrkAdj6 - WrkAdj7
				._ADJA1 = WrkAdj1
				._ADJA2 = WrkAdj2
				._ADJA3 = WrkAdj3
				._ADJA4 = WrkAdj4
				._ADJA5 = WrkAdj5
				._ADJA6 = WrkAdj6
				._ADJA7 = WrkAdj7
				._ADJC1 = ._FULC1
				._ADJC2 = ._FULC2
				._ADJC3 = ._FULC3
				._ADJC4 = ._FULC4
				._ADJC5 = ._FULC5
				._ADJC6 = ._FULC6
				._ADJC7 = ._FULC7
				.UpdateOneRecordP()
			End With
		End If
	End With

	With myTXREAL
		.GetOneRecordP(myTXREALQ._LISTNO)
		._GROSS = WrkPhaseIn
		._ASS1 = WrkAdj1
		._ASS2 = WrkAdj2
		._ASS3 = WrkAdj3
		._ASS4 = WrkAdj4
		._ASS5 = WrkAdj5
		._ASS6 = WrkAdj6
		._ASS7 = WrkAdj7
		._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5 - ._EXAM6 - ._EXAM7
		WrkBTR = False
		If ._BTR <> 0 Then WrkBTR = True
		._BTR = 0
		.UpdateOneRecordP()
	End With

	If WrkBTR Then
		With myTXBTR
			.GetOneRecordP(myTXREALQ._LISTNO, "R")
			If Not .RecordNotFound Then
				.DeleteOneRecordP()
			End If
		End With
	End If

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
myTXREAL.CloseFile()

End Sub
End Module






