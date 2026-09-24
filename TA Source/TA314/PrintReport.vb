Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXPPRP As TXPPRP.myData

Dim ds As DataSet = New DataSet
Dim DsTXPPRP As DataSet = New DataSet
Dim dr As Data.DataRow
'Screen fields
Dim WrkPost As Boolean
'File
Dim WrkAss(9) As Integer
Dim WrkCode(9) As Integer
Dim WrkUnit(9) As Integer

Const MyPenCode As Integer = 250
Const MyPenPct As Integer = 25

  Public Sub PrtReport()

	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
	myTXPPRP = New TXPPRP.mydata(MyDBConnect)

  WrkPost = False
  With MyFrmTA314B
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
  MyCrViewer.WrkPenPct = MyPenPct
  MyCrViewer.WrkPost = WrkPost
  MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("PenAmount", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim AddrLine() As String
Dim WrkAmount As Integer
Dim I As Integer
Dim J As Integer
Dim WrkAnd As String
Dim Good As Boolean

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = "NAME"
WrkQry = ""

DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
If DsTXPPRP.Tables(0).Rows.Count = 0 Then
  myTXPPRPQ.CloseFile()
  Exit Sub
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
  If MyReportCancel Then Exit Sub
  With DsTXPPRP.Tables(0).Rows(I)
    WrkAss(0) = .Item("ass1")
    WrkAss(1) = .Item("ass2")
    WrkAss(2) = .Item("ass3")
    WrkAss(3) = .Item("ass4")
    WrkAss(4) = .Item("ass5")
    WrkAss(5) = .Item("ass6")
    WrkAss(6) = .Item("ass7")
    WrkAss(7) = .Item("ass8")
    WrkAss(8) = .Item("ass9")
    WrkAss(9) = .Item("ass10")
    WrkCode(0) = .Item("code1")
    WrkCode(1) = .Item("code2")
    WrkCode(2) = .Item("code3")
    WrkCode(3) = .Item("code4")
    WrkCode(4) = .Item("code5")
    WrkCode(5) = .Item("code6")
    WrkCode(6) = .Item("code7")
    WrkCode(7) = .Item("code8")
    WrkCode(8) = .Item("code9")
    WrkCode(9) = .Item("codea")
    WrkUnit(0) = .Item("unit1")
    WrkUnit(1) = .Item("unit2")
    WrkUnit(2) = .Item("unit3")
    WrkUnit(3) = .Item("unit4")
    WrkUnit(4) = .Item("unit5")
    WrkUnit(5) = .Item("unit6")
    WrkUnit(6) = .Item("unit7")
    WrkUnit(7) = .Item("unit8")
    WrkUnit(8) = .Item("unit9")
    WrkUnit(9) = .Item("unita")

    Good = False
    'Find an available bucket to use
    For J = 0 To 9
      If WrkCode(J) = MyPenCode Then
        WrkAmount = WrkAss(J)
        Good = True
        Exit For
      End If
    Next

    If Good Then
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
        .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
      dr.Item("penamount") = WrkAmount
      ds.Tables(0).Rows.Add(dr)
    End If
  End With

  If WrkPost Then
    UpdateTXPPRP(DsTXPPRP.Tables(0).Rows(I).Item("list#"), WrkAmount, J)
  End If

NextRec:
With myFrmProgress
  If DsTXPPRP.Tables(0).Rows.Count > 1 Then
    WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
    If SavePct <> WrkPct Then
      .ProgBar1.Value = WrkPct
      .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
  End If
End With
Next

myFrmProgress.Close()
myTXPPRPQ.CloseFile()
myTXPPRP.CloseFile()

End Sub
Private Sub UpdateTXPPRP(ByVal List As Integer, ByVal WrkAmount As Integer, ByVal J As Integer)

	myTXPPRP.GetOneRecordP(List)
	If Not myTXPPRP.RecordNotFound Then
		With myTXPPRP
		 ._GROSS = ._GROSS - WrkAmount
		 ._NET = ._NET - WrkAmount
		Select Case J
		Case 0
			._ASS1 = 0
			._CODE1 = 0
			._UNIT1 = 0
		Case 1
			._ASS2 = 0
			._CODE2 = 0
			._UNIT2 = 0
		Case 2
			._ASS3 = 0
			._CODE3 = 0
			._UNIT3 = 0
		Case 3
			._ASS4 = 0
			._CODE4 = 0
			._UNIT4 = 0
		Case 4
			._ASS5 = 0
			._CODE5 = 0
			._UNIT5 = 0
		Case 5
			._ASS6 = 0
			._CODE6 = 0
			._UNIT6 = 0
		Case 6
			._ASS7 = 0
			._CODE7 = 0
			._UNIT7 = 0
		Case 7
			._ASS8 = 0
			._CODE8 = 0
			._UNIT8 = 0
		Case 8
			._ASS9 = 0
			._CODE9 = 0
			._UNIT9 = 0
		Case 9
			._ASS10 = 0
			._CODEA = 0
			._UNITA = 0
		End Select
		End With
		myTXPPRP.UpdateOneRecordP()
	End If
End Sub
End Module






