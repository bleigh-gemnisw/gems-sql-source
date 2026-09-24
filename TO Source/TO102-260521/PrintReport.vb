Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREALCQ As TXREALCQ.MyData
Dim myTXBTR As TXBTR.MyData
Dim myTXBTRC As TXBTRC.MyData
Dim DsTXREAL As DataSet = New DataSet
Dim DsTXBTR As DataSet = New DataSet
Dim dsTotMC As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkOPMFile As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkBTR As Boolean
Dim WrkTotal As Long
Dim WrkPrintDist As Boolean

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
'Buffered files
Dim WrkCode(100) As Integer
Dim WrkOPM(100) As String
'Totals
Dim WrkTMCCode(100) As String
Dim WrkTMCClass(100) As String
Dim WrkTMCGross(100) As Long

	Public Sub PrtReport()
  myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)
	myTXBTRC = New TXBTRC.mydata(MyDBConnect)

	With MyFrmTO102B
		WrkType = "R"
		WrkYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkOPMFile = False
		If .ChkOPM.Checked Then
			WrkOPMFile = True
		End If
		WrkFrozenFile = False
		If .ChkFrozenFile.Checked Then
			WrkFrozenFile = True
		End If
		WrkBTR = False
		If .ChkBAA.Checked Then
			WrkBTR = True
		End If
	End With

	If dsTotMC.Tables.Count = 0 Then
		BuildDS()
	Else
		dsTotMC.Clear()
	End If

	BufferCodes()
	ClearTotals()
	GetDetail()
	GetOPMAssr()

	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.WrkdsTotMC = dsTotMC
		.WrkBTR = MyFrmTO102B.ChkBAA.Checked
		.WrkTotal = WrkTotal
		.Show()
	End With
	End Sub
Friend Sub BuildDS()
	Dim myTableTotMC As New DataTable

	With myTableTotMC
		.TableName = "mytabletmc"
		.Columns.Add("tmcgroup", Type.GetType("System.String"))
		.Columns.Add("tmcgroupdesc", Type.GetType("System.String"))
		.Columns.Add("tmccode", Type.GetType("System.String"))
		.Columns.Add("tmcclass", Type.GetType("System.String"))
		.Columns.Add("tmcdesc", Type.GetType("System.String"))
		.Columns.Add("tmcgross", Type.GetType("System.Int64"))
	End With
	dsTotMC.Tables.Add(myTableTotMC)
End Sub
Private Sub ClearTotals()
	WrkTotal = 0
	ReDim WrkTMCCode(100)
	ReDim WrkTMCGross(100)
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkAssCode(6) As Integer
Dim WrkGross(6) As Integer
Dim WrkOPMGroup As String
Dim WrkCode As String
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim WrkAnd As String

If myDBConnect.ServerName = "DB2" Then
	WrkAnd = " *and "
Else
	WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "CAT = '3'"
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If
If Not WrkFrozenFile Then
	DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
	DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub
myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = ""
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

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
				With myTXBTR
					WrkGross(0) = WrkGross(0) + ._BASS1
					WrkGross(1) = WrkGross(1) + ._BASS2
					WrkGross(2) = WrkGross(2) + ._BASS3
					WrkGross(3) = WrkGross(3) + ._BASS4
					WrkGross(4) = WrkGross(4) + ._BASS5
					WrkGross(5) = WrkGross(5) + ._BASS6
					WrkGross(6) = WrkGross(6) + ._BASS7
				End With
			Else
				myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
				With myTXBTRC
					WrkGross(0) = WrkGross(0) + ._BASS1
					WrkGross(1) = WrkGross(1) + ._BASS2
					WrkGross(2) = WrkGross(2) + ._BASS3
					WrkGross(3) = WrkGross(3) + ._BASS4
					WrkGross(4) = WrkGross(4) + ._BASS5
					WrkGross(5) = WrkGross(5) + ._BASS6
					WrkGross(6) = WrkGross(6) + ._BASS7
				End With
			End If
		End If

		'Add Gross to OPM groups
		For J = 0 To 6
			If WrkAssCode(J) > 0 Then
				WrkOPMGroup = LookupOPMCode(WrkAssCode(J))
				K = LookupWrkTMCCode(.Item("exmpt"), WrkOPMGroup)
				WrkTMCCode(K) = .Item("exmpt")
				WrkTMCClass(K) = WrkOPMGroup
				WrkTMCGross(K) = WrkTMCGross(K) + WrkGross(J)
				WrkTotal = WrkTotal + WrkGross(J)
			End If
		Next J
	End With

NextRec:
With myFrmProgress
	WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
	If SavePct <> WrkPct Then
		.ProgBar1.Value = WrkPct
		.Refresh()
		SavePct = WrkPct
		Application.DoEvents()
	End If
End With
Next

For I = 0 To 100
	If IsNothing(WrkTMCCode(I)) Then Exit For
	dr = dsTotMC.Tables(0).NewRow
	WrkCode = Mid(WrkTMCCode(I), 1, 1)
	dr.Item("tmcgroup") = WrkCode
	dr.Item("tmcgroupdesc") = GetTXXPROPDesc(WrkCode)
	dr.Item("tmccode") = WrkTMCCode(I)
	dr.Item("tmcclass") = WrkTMCClass(I)
	dr.Item("tmcdesc") = GetTXXPROPDesc(WrkTMCCode(I))
	dr.Item("tmcgross") = WrkTMCGross(I)
	dsTotMC.Tables(0).Rows.Add(dr)
Next I

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
Private Sub BufferCodes()
		 Dim I As Integer

		 Dim myTXCode As TXCODE.MyData
		 Dim dsTXCode As DataSet = New DataSet

		 Array.Clear(WrkCode, 0, 101)
		 Array.Clear(WrkOPM, 0, 101)

		 myTXCode = New TXCODE.mydata(MyDBConnect)

		 dsTXCode = myTXCode.GetAllType(WrkType)
		 For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
			With dsTXCode.Tables(0).Rows(I)
				WrkCode(I) = .Item("tccode")
				WrkOPM(I) = .Item("tcopmc")
			End With
		Next

End Sub
Private Function LookupOPMCode(ByVal Code As Integer) As String
     Dim I As Integer
     Dim WrkResult As String

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = 0 Then
         Return ""
       End If
       If Code = WrkCode(I) Then
         WrkResult = WrkOPM(I)
         Return WrkResult
       End If
    Next

    Return ""
End Function
Private Function LookupWrkTMCCode(ByVal Code As String, ByVal OPMGroup As String) As Integer
     Dim I As Integer

     For I = 0 To WrkTMCCode.GetUpperBound(0)
       If WrkTMCCode(I) = "" Then
         Return I
       End If
      If Code = WrkTMCCode(I) And Trim(OPMGroup) = Trim(WrkTMCClass(I)) Then
        Return I
      End If
    Next

End Function
End Module






