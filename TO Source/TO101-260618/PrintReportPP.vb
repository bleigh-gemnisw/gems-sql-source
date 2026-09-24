Imports System.Text
Module PrintReportPP

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXPPRPQ As TXPPRPQ.myData
Dim myTXPPRPCQ As TXPPRPCQ.myData
Dim myTXBTR As TXBTR.myData
Dim myTXBTRC As TXBTRC.myData
Dim DsTXPPRP As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkType As String
Dim WrkYear As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkOPMFile As Boolean
Dim WrkFrozenFile As Boolean
Dim WrkBTR As Boolean
Dim WrkCC As Boolean

Dim WrkExcd(4) As String
Dim WrkExam(4) As Integer
'Buffered files
Dim WrkCode(200) As Integer
Dim WrkDesc(200) As String
'Report fields
Dim RptCode(9) As String
Dim RptDesc(9) As String
Dim RptGross(9) As Integer
Dim RptExCode(4) As String
Dim RptExam(4) As Integer
'MC Totals 
Dim WrkTMCCode(200) As String
Dim WrkTMCCount(200) As Integer
Dim WrkTMCGross(200) As Integer

  Public Sub PrtReportPP()

	myTXPPRPQ = New TXPPRPQ.mydata(MyDBConnect)
	myTXPPRPCQ = New TXPPRPCQ.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)
	myTXBTRC = New TXBTRC.mydata(MyDBConnect)

  With MyFrmTO101B
    WrkType = "P"
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
    WrkCC = False
    If .ChkCC.Checked Then
      WrkCC = True
    End If
  End With

  BufferCodes()
  ClearTotals()
  GetDetail()

  End Sub
Private Sub ClearTotals()
  ReDim WrkTMCCode(200)
  ReDim WrkTMCCount(200)
  ReDim WrkTMCGross(200)
End Sub
Private Sub GetDetail()
Dim WrkSort As String
Dim WrkQry As String
Dim WrkAssCode(9) As Integer
Dim WrkGross(9) As Integer
Dim WrkUnit(9) As Integer
Dim WrkEx As Integer
Dim I As Integer
Dim J As Integer
Dim K As Integer
Dim L As Integer
Dim WrkAnd As String

If myDBConnect.ServerName = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

WrkSort = ""
WrkQry = "CAT = '5'"
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If

myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = "Processing Personal property data..."
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If Not WrkFrozenFile Then
  DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
  With DsTXPPRP.Tables(0).Rows(I)
    WrkAssCode(0) = .Item("code1")
    WrkAssCode(1) = .Item("code2")
    WrkAssCode(2) = .Item("code3")
    WrkAssCode(3) = .Item("code4")
    WrkAssCode(4) = .Item("code5")
    WrkAssCode(5) = .Item("code6")
    WrkAssCode(6) = .Item("code7")
    WrkAssCode(7) = .Item("code8")
    WrkAssCode(8) = .Item("code9")
    WrkAssCode(9) = .Item("codea")
    If WrkCC And .Item("ccno") > 0 Then
      WrkGross(0) = .Item("cass1")
      WrkGross(1) = .Item("cass2")
      WrkGross(2) = .Item("cass3")
      WrkGross(3) = .Item("cass4")
      WrkGross(4) = .Item("cass5")
      WrkGross(5) = .Item("cass6")
      WrkGross(6) = .Item("cass7")
      WrkGross(7) = .Item("cass8")
      WrkGross(8) = .Item("cass9")
      WrkGross(9) = .Item("cassa")
    Else
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
      If WrkBTR And .Item("btr") <> 0 Then
        If Not WrkFrozenFile Then
          myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
          If Not myTXBTR.RecordNotFound Then
            With myTXBTR
              WrkGross(0) = WrkGross(0) + ._BASS1
              WrkGross(1) = WrkGross(1) + ._BASS2
              WrkGross(2) = WrkGross(2) + ._BASS3
              WrkGross(3) = WrkGross(3) + ._BASS4
              WrkGross(4) = WrkGross(4) + ._BASS5
              WrkGross(5) = WrkGross(5) + ._BASS6
              WrkGross(6) = WrkGross(6) + ._BASS7
              WrkGross(7) = WrkGross(7) + ._BASS8
              WrkGross(8) = WrkGross(8) + ._BASS9
              WrkGross(9) = WrkGross(9) + ._BASSA
            End With
          End If
        Else
          myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
          If Not myTXBTRC.RecordNotFound Then
            With myTXBTRC
              WrkGross(0) = WrkGross(0) + ._BASS1
              WrkGross(1) = WrkGross(1) + ._BASS2
              WrkGross(2) = WrkGross(2) + ._BASS3
              WrkGross(3) = WrkGross(3) + ._BASS4
              WrkGross(4) = WrkGross(4) + ._BASS5
              WrkGross(5) = WrkGross(5) + ._BASS6
              WrkGross(6) = WrkGross(6) + ._BASS7
              WrkGross(7) = WrkGross(7) + ._BASS8
              WrkGross(8) = WrkGross(8) + ._BASS9
              WrkGross(9) = WrkGross(9) + ._BASSA
            End With
          End If
        End If
      End If
    End If

    If WrkCC And .Item("ccno") > 0 Then
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
    Else
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
    End If
    'Combine Gross into OPM groups
    Array.Clear(RptCode, 0, 10)
    Array.Clear(RptDesc, 0, 10)
    Array.Clear(RptGross, 0, 10)
    For J = 0 To 9
      If WrkAssCode(J) > 0 Then
        WrkTotalPP = WrkTotalPP + WrkGross(J)
        K = LookupRptCode(Format(WrkAssCode(J), "000"))
        RptCode(K) = Format(WrkAssCode(J), "000")
        RptDesc(K) = LookupOPMDesc(WrkAssCode(J))
        RptGross(K) = RptGross(K) + WrkGross(J)
      End If
    Next J

    'Add OPM groups to totals
    For J = 0 To 9
      If Not IsNothing(RptCode(J)) Then
        K = LookupWrkTMCCode(RptCode(J))
        WrkTMCCode(K) = RptCode(J)
        WrkTMCCount(K) = WrkTMCCount(K) + 1
        WrkTMCGross(K) = WrkTMCGross(K) + RptGross(J)
      End If
    Next J

    'Combine Exemptions into Letter groups
    Array.Clear(RptExCode, 0, 5)
    Array.Clear(RptExam, 0, 5)
    For J = 0 To 4
      WrkEx = 0
      If WrkExcd(J) <> "" Then
        K = LookupExem(WrkExcd(J))
        If K = -1 Then Continue For
        If WrkExam(J) = 0 Then
          WrkEx = WrkExFixedAmt(K)
        Else
          WrkEx = WrkExam(J)
        End If
        L = LookupRptExCode(WrkExLetter(K))
        RptExCode(L) = WrkExLetter(K)
        RptExam(L) = RptExam(L) + WrkEx
        WrkTotExPP = WrkTotExPP + WrkEx
      End If
    Next

    'Add Exemption Letter groups
    For J = 0 To 4
      If Not IsNothing(RptExCode(J)) Then
        K = LookupWrkTExCode(RptExCode(J))
        WrkTExCode(K) = RptExCode(J)
        WrkTExPPCount(K) = WrkTExPPCount(K) + 1
        WrkTExPP(K) = WrkTExPP(K) + RptExam(J)
      End If
    Next J
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

For I = 0 To 200
  If IsNothing(WrkTMCCode(I)) Then Exit For
  dr = dsTotMC.Tables(0).NewRow
  dr.Item("tmcgroup") = "C"
  dr.Item("tmccode") = WrkTMCCode(I)
  dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), WrkType)
  dr.Item("tmccount") = WrkTMCCount(I)
  dr.Item("tmcgross") = WrkTMCGross(I)
  dsTotMC.Tables(0).Rows.Add(dr)
Next I

myFrmProgress.Close()
Application.DoEvents()
myTXPPRPQ.CloseFile()
myTXPPRPCQ.CloseFile()

End Sub
Private Sub BufferCodes()
     Dim I As Integer

		 Dim myTXCode As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

		 myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkType)
     For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkCode(I) = .Item("tccode")
        WrkDesc(I) = .Item("tcdesc")
      End With
    Next

End Sub
Private Function LookupOPMDesc(ByVal Code As Integer) As String
     Dim I As Integer
     Dim WrkResult As String

     For I = 0 To WrkCode.GetUpperBound(0)
       If WrkCode(I) = 0 Then
         Return ""
       End If
       If Code = WrkCode(I) Then
         WrkResult = WrkDesc(I)
         Return WrkResult
       End If
    Next

    Return ""
End Function
Private Function LookupRptCode(ByVal Code As Integer) As Integer
     Dim I As Integer

     For I = 0 To RptCode.GetUpperBound(0)
       If RptCode(I) = 0 Then
         Return I
       End If
       If Code = RptCode(I) Then
         Return I
       End If
    Next

End Function
Private Function LookupRptExCode(ByVal Code As String) As Integer
     Dim I As Integer

     For I = 0 To RptExCode.GetUpperBound(0)
      If Trim(RptExCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(RptExCode(I)) Then
        Return I
      End If
    Next

End Function
Private Function LookupWrkTMCCode(ByVal Code As Integer) As Integer
     Dim I As Integer

     For I = 0 To WrkTMCCode.GetUpperBound(0)
       If WrkTMCCode(I) = "" Then
         Return I
       End If
       If Code = WrkTMCCode(I) Then
         Return I
       End If
    Next

End Function
End Module






