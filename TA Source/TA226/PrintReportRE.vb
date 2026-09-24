Imports System.Text
Module PrintReportRE

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXREALQ As TXREALQ.MyData
Dim myTXREALCQ As TXREALCQ.myData
Dim DsTXREAL As DataSet = New DataSet

Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkPrintDist As Boolean
Dim WrkVetYear As Integer
Dim WrkExempt1 As String
Dim WrkExempt2 As String
Dim WrkExempt3 As String
Dim WrkExempt4 As String
Dim WrkExempt5 As String

Dim WrkExcd(6) As String
Dim WrkExam(6) As Integer
Dim RptExcd(6) As String
Dim RptExam(6) As Integer
Dim RptRevLoss(6) As Decimal
  Public Sub PrtReportRE()

	myTXREALQ = New TXREALQ.mydata(MyDBConnect)
	myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)

  With MyFrmTA226B
    WrkYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    WrkFrozenFile = False
    If .ChkFrozenFile.Checked Then
      WrkFrozenFile = True
    End If
    WrkVetYear = MyUtils.CnvSng(.TxtVetYear.Text)
    WrkExempt1 = .TxtExempt1.Text
    WrkExempt2 = .TxtExempt2.Text
    WrkExempt3 = .TxtExempt3.Text
    WrkExempt4 = .TxtExempt4.Text
    WrkExempt5 = .TxtExempt5.Text
  End With

  GetDetail()

  End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkSort As String
Dim WrkQry As String
Dim Good As Boolean
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim L As Integer
Dim WrkTExam As Integer
Dim WrkTRevLoss As Decimal

Dim WrkAnd As String

If myDBConnect.ServerAS400 Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "CAT = '1'" '& WrkAnd & "VTYR > 0"
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If
If WrkVetYear > 0 Then
  WrkQry = WrkQry & WrkAnd & "VTYR=" & WrkVetYear
End If

If Not WrkFrozenFile Then
  DsTXREAL = myTXREALQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXREAL = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

GetMillRate(WrkYear, WrkDist)

For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
  With DsTXREAL.Tables(0).Rows(I)
    WrkExcd(0) = .Item("excd1")
    WrkExcd(1) = .Item("excd2")
    WrkExcd(2) = .Item("excd3")
    WrkExcd(3) = .Item("excd4")
    WrkExcd(4) = .Item("excd5")
    WrkExcd(5) = .Item("excd6")
    WrkExcd(6) = .Item("excd7")
    WrkExam(0) = .Item("exam1")
    WrkExam(1) = .Item("exam2")
    WrkExam(2) = .Item("exam3")
    WrkExam(3) = .Item("exam4")
    WrkExam(4) = .Item("exam5")
    WrkExam(5) = .Item("exam6")
    WrkExam(6) = .Item("exam7")
    If .Item("ccno") > 0 Then
      WrkExcd(0) = .Item("cccd1")
      WrkExcd(1) = .Item("cccd2")
      WrkExcd(2) = .Item("cccd3")
      WrkExcd(3) = .Item("cccd4")
      WrkExcd(4) = .Item("cccd5")
      WrkExcd(5) = .Item("cccd6")
      WrkExcd(6) = .Item("cccd7")
      WrkExam(0) = .Item("cexa1")
      WrkExam(1) = .Item("cexa2")
      WrkExam(2) = .Item("cexa3")
      WrkExam(3) = .Item("cexa4")
      WrkExam(4) = .Item("cexa5")
      WrkExam(5) = .Item("cexa6")
      WrkExam(6) = .Item("cexa7")
    End If

    Array.Clear(RptExcd, 0, 7)
    Array.Clear(RptExam, 0, 7)
    Array.Clear(RptRevLoss, 0, 7)

    L = 0
    WrkTExam = 0
    WrkTRevLoss = 0
    For J = 0 To 6
      K = LookupExem(WrkExcd(J))
      If K < 0 Then Continue For
      Good = False
      If WrkExempt1 <> String.Empty Then
        If WrkExempt1 = WrkExcd(J) Then Good = True
      Else
        Good = True
      End If
      If WrkExempt2 <> String.Empty Then
        If WrkExempt2 = WrkExcd(J) Then Good = True
      End If
      If WrkExempt3 <> String.Empty Then
        If WrkExempt3 = WrkExcd(J) Then Good = True
      End If
      If WrkExempt4 <> String.Empty Then
        If WrkExempt4 = WrkExcd(J) Then Good = True
      End If
      If WrkExempt5 <> String.Empty Then
        If WrkExempt5 = WrkExcd(J) Then Good = True
      End If
      If Not Good Then Continue For
      RptExcd(L) = WrkExcd(J)
      RptExam(L) = WrkExam(J)
      RptRevLoss(L) = MyUtils.Round(WrkExam(J) * MrateMillrt, 2)
      WrkTExam = WrkTExam + RptExam(L)
      WrkTRevLoss = WrkTRevLoss + RptRevLoss(L)
      L = L + 1
    Next

    If WrkTExam = 0 Then GoTo NextRec
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"), _
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("excd1") = RptExcd(0)
    dr.Item("exam1") = RptExam(0)
    dr.Item("revloss1") = RptRevLoss(0)
    dr.Item("excd2") = RptExcd(1)
    dr.Item("exam2") = RptExam(1)
    dr.Item("revloss2") = RptRevLoss(1)
    dr.Item("excd3") = RptExcd(2)
    dr.Item("exam3") = RptExam(2)
    dr.Item("revloss3") = RptRevLoss(2)
    dr.Item("excd4") = RptExcd(3)
    dr.Item("exam4") = RptExam(3)
    dr.Item("revloss4") = RptRevLoss(3)
    dr.Item("excd5") = RptExcd(4)
    dr.Item("exam5") = RptExam(4)
    dr.Item("revloss5") = RptRevLoss(4)
    dr.Item("excd6") = RptExcd(5)
    dr.Item("exam6") = RptExam(5)
    dr.Item("revloss6") = RptRevLoss(5)
    dr.Item("excd7") = RptExcd(6)
    dr.Item("exam7") = RptExam(6)
    dr.Item("revloss7") = RptRevLoss(6)
    dr.Item("texam") = WrkTExam
    dr.Item("trevloss") = WrkTRevLoss
    ds.Tables(0).Rows.Add(dr)
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

myFrmProgress.Close()
Application.DoEvents()
myTXREALQ.CloseFile()
myTXREALCQ.CloseFile()

End Sub
End Module






