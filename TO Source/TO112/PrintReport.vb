Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim DsTXPPRP As DataSet = New DataSet
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPPCode As Integer

Dim WrkGross(9) As Integer
Dim WrkCode(9) As Integer
Dim WrkUnit(9) As Integer

  Public Sub PrtReport()

	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)

  With MyFrmTO112B
    WrkYear = .TxtGLYear.Text
    WrkPPCode = MyUtils.CnvSng(.TxtCode.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
  End With

  If ds.Tables.Count = 0 Then
    BuildDS(ds)
  Else
    ds.Clear()
  End If

  GetDetail()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .WrkCode = WrkPPCode
    .WrkMillRt = MrateMillrt * 1000
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
Dim WrkTUnits As Integer
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

GetMillRate(WrkYear, "P", WrkDist)

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
    WrkTGross = 0
    WrkTUnits = 0
    For J = 0 To 9
      If WrkCode(J) <> WrkPPCode Then Continue For
      Good = True
      WrkTGross = WrkTGross + WrkGross(J)
      WrkTUnits = WrkTUnits + WrkUnit(J)
    Next J

    If Not Good Then GoTo NextRec

    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("name") = .Item("name")
    dr.Item("proploc") = .Item("loc#") & " " & .Item("loc")
    dr.Item("units") = WrkTUnits
    dr.Item("gross") = WrkTGross
    dr.Item("tax") = MyUtils.Round(WrkTGross * MrateMillrt, 2)
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

End Sub
End Module






