Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim DsTXPPRP As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow
Dim ds2 As DataSet = New DataSet
Dim dr2 As Data.DataRow
Dim ds3 As DataSet = New DataSet
Dim dr3 As Data.DataRow

Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPPCodea As Integer
Dim WrkPPCodeb As Integer

Dim WrkGross(9) As Integer
Dim WrkCode(9) As Integer
Dim WrkExcd(4) As String
Dim WrkExam(4) As Integer

  Public Sub PrtReport()

	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)

  With MyFrmTO116B
    WrkYear = .TxtGLYear.Text
    WrkPPCodea = MyUtils.CnvSng(.TxtCodea.Text)
    WrkPPCodeb = MyUtils.CnvSng(.TxtCodeb.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
  End With

  If ds.Tables.Count = 0 Then
    BuildDS(ds)
    ds2 = ds.Clone
    ds3 = ds.Clone
  Else
    ds.Clear()
    ds2.Clear()
    ds3.Clear()
  End If

  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .wrkds2 = ds2
    .wrkds3 = ds3
    .WrkCodea = WrkPPCodea
    .WrkCodeb = WrkPPCodeb
    .Show()
  End With
  End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim J As Integer
Dim WrkAnd As String
Dim WrkOr As String
Dim WrkTGross As Integer
Dim WrkExCode As String
Dim WrkExCodeExam As Integer
Dim Good As Boolean

If myDBConnect.ServerAS400 Then
  WrkOr = " *or "
  WrkAnd = " *and "
Else
  WrkOr = " or "
  WrkAnd = " and "
 End If

WrkSort = "NAME"
WrkQry = "CAT='5'"
If Not WrkDistAll Then
  WrkQry = "dist=" & WrkDist
End If
DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)

If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
  With DsTXPPRP.Tables(0).Rows(I)
    WrkGross(0) = .Item("ass1")
    WrkGross(1) = .Item("ass2")
    WrkGross(2) = .Item("ass3")
    WrkGross(3) = .Item("ass4")
    WrkGross(4) = .Item("ass5")
    WrkGross(5) = .Item("ass6")
    WrkGross(6) = .Item("ass7")
    WrkGross(7) = .Item("ass8")
    WrkGross(8) = .Item("ass9")
    WrkGross(9) = .Item("ass10")
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

    '15A
    If WrkPPCodea = 0 Then GoTo Check15b
    Good = False
    WrkTGross = 0
    For J = 0 To 9
      If WrkCode(J) <> WrkPPCodea Then Continue For
      Good = True
      WrkTGross = WrkTGross + WrkGross(J)
    Next J

    If Good Then '15A
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = .Item("list#")
      dr.Item("name") = .Item("name")
      dr.Item("gross") = WrkTGross
      ds.Tables(0).Rows.Add(dr)
    End If

    '15B
Check15b:
    If WrkPPCodeb = 0 Then GoTo CheckRex
    Good = False
    WrkTGross = 0
    For J = 0 To 9
      If WrkCode(J) <> WrkPPCodeb Then Continue For
      Good = True
      WrkTGross = WrkTGross + WrkGross(J)
    Next J

    If Good Then '15B
      dr2 = ds2.Tables(0).NewRow
      dr2.Item("listno") = .Item("list#")
      dr2.Item("name") = .Item("name")
      dr2.Item("gross") = WrkTGross
      ds2.Tables(0).Rows.Add(dr2)
    End If

CheckRex:
    'R Exemptions
    WrkExCode = ""
    WrkExCodeExam = 0
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

    FindExemptions(WrkExCode, WrkExCodeExam)
    If WrkExCode <> "" Then
      dr3 = ds3.Tables(0).NewRow
      dr3.Item("listno") = .Item("list#")
      dr3.Item("name") = .Item("name")
      dr3.Item("gross") = WrkExCodeExam
      ds3.Tables(0).Rows.Add(dr3)
    End If
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

End Sub
Private Sub FindExemptions(ByRef WrkCode As String, ByRef WrkCodeExam As Integer)
  Dim I As Integer

  WrkCode = ""
  WrkCodeExam = 0

  For I = 0 To WrkExcd.GetUpperBound(0)
    If Mid(WrkExcd(I), 1, 1) = "R" Then
      WrkCode = WrkExcd(I)
			WrkCodeExam = WrkCodeExam + WrkExam(I)
		End If
  Next

End Sub
End Module






