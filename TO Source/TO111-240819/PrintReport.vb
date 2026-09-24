Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXPPRPCQ As TXPPRPCQ.myData
Dim DsTXPPRP As DataSet = New DataSet

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean

Dim WrkExcd(4) As String
Dim WrkExam(4) As Integer
Dim cSelCode1 As String = "T"
Dim cSelCode2 As String = "U"
Dim cSelCode3 As String = "N"
Public Sub PrtReport()
	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
	myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)

	With MyFrmTO111B
		WrkType = "P"
		WrkYear = .TxtGLYear.Text
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
		If .TxtDist.Text = "" Then
			WrkDistAll = True
		End If
		WrkFrozenFile = False
		If .ChkFrozenFile.Checked Then
			WrkFrozenFile = True
		End If
	End With

	If ds.Tables.Count = 0 Then
		BuildDS()
	Else
		ds.Clear()
	End If

	BufferExem()
	GetDetail()

	MyCrViewer = New FrmCrViewer
	With MyCrViewer
		.Wrkds = ds
		.WrkMillRt = MrateMillrt * 1000
		.Show()
	End With
End Sub

Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkTypeDesc As String
Dim WrkCode As String
Dim WrkCodeExam As Integer
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "CAT = '5'"
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If

myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = "Processing Personal property data..."
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

WrkTypeDesc = GetTXTypeDesc("P")
GetMillRate(WrkYear, "P", WrkDist)

If Not WrkFrozenFile Then
	DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
Else
	DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
	With DsTXPPRP.Tables(0).Rows(I)
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
		If .Item("ccno") > 0 Then
			WrkExcd(0) = .Item("cccd1")
			WrkExcd(1) = .Item("cccd2")
			WrkExcd(2) = .Item("cccd3")
			WrkExcd(3) = .Item("cccd4")
			WrkExcd(4) = .Item("cccd5")
			WrkExam(0) = .Item("cexa1")
			WrkExam(1) = .Item("cexa2")
			WrkExam(2) = .Item("cexa3")
			WrkExam(3) = .Item("cexa4")
			WrkExam(4) = .Item("cexa5")
		End If

		WrkCode = ""
		FindExemptions(WrkCode, WrkCodeExam)
		If WrkCode = "" Then GoTo NextRec

		dr = ds.Tables(0).NewRow
		dr.Item("listno") = .Item("list#")
		dr.Item("typedesc") = WrkTypeDesc
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
		dr.Item("addr1") = AddrLine(0)
		dr.Item("addr2") = AddrLine(1)
		dr.Item("addr3") = AddrLine(2)
		dr.Item("addr4") = AddrLine(3)
		dr.Item("addr5") = AddrLine(4)
		dr.Item("excd") = WrkCode
		dr.Item("exam") = WrkCodeExam
    dr.Item("revloss") = MyUtils.Round(WrkCodeExam * MrateMillrt, 2)
		ds.Tables(0).Rows.Add(dr)
	End With

NextRec:
With myFrmProgress
	WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
	If SavePct <> WrkPct Then
		.ProgBar1.Value = WrkPct
		.Refresh()
		SavePct = WrkPct
		Application.DoEvents()
	End If
End With
Next

myFrmProgress.Close()
Application.DoEvents()
myTXPPRPQ.CloseFile()
myTXPPRPCQ.CloseFile()

End Sub
Private Sub FindExemptions(ByRef WrkCode As String, ByRef WrkCodeExam As Integer)
  Dim I As Integer

  WrkCode = ""
  WrkCodeExam = 0

  For I = 0 To WrkExcd.GetUpperBound(0)
		If Mid(WrkExcd(I), 1, 1) = cSelCode1 Or Mid(WrkExcd(I), 1, 1) = cSelCode2 Or Mid(WrkExcd(I), 1, 1) = cSelCode3 Then
			If WrkCode = String.Empty Then
				WrkCode = WrkExcd(I)
				WrkCodeExam = WrkExam(I)
			Else
				WrkCodeExam = WrkCodeExam + WrkExam(I)
			End If
		End If
  Next

End Sub
End Module






