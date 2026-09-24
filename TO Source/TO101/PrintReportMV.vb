Imports System.Text
Module PrintReportMV

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDQ As TXMVDQ.myData
Dim myTXMVDCQ As TXMVDCQ.myData
Dim myTXBTR As TXBTR.myData
Dim myTXBTRC As TXBTRC.myData
Dim DsTXMVD As DataSet = New DataSet
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
Dim WrkExLet(4) As String
'Report fields
Dim RptExCode(4) As String
Dim RptExam(4) As Integer
'MC Totals 
Dim WrkTMCCode(200) As String
Dim WrkTMCCount(200) As Integer
Dim WrkTMCGross(200) As Integer
  Public Sub PrtReportMV()

	myTXMVDQ = New TXMVDQ.mydata(MyDBConnect)
	myTXMVDCQ = New TXMVDCQ.mydata(MyDBConnect)
	myTXBTR = New TXBTR.mydata(MyDBConnect)
	myTXBTRC = New TXBTRC.mydata(MyDBConnect)

  With MyFrmTO101B
    WrkType = "M"
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
Dim WrkEx As Integer
Dim WrkGross As Decimal
Dim WrkClass As Integer
Dim WrkTotBTR As Decimal
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
WrkQry = "CAT = '1'"
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If

myFrmProgress = New FrmProgress
myFrmProgress.LblMsg.Text = "Processing Motor Vehicle data..."
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

If Not WrkFrozenFile Then
  DsTXMVD = myTXMVDQ.GetQry(WrkSort, WrkQry, 0)
Else
  DsTXMVD = myTXMVDCQ.GetQry(WrkSort, WrkQry, 0)
End If
If DsTXMVD.Tables(0).Rows.Count = 0 Then Exit Sub

For I = 0 To (DsTXMVD.Tables(0).Rows.Count - 1)
  With DsTXMVD.Tables(0).Rows(I)
    If .Item("class") <= 4 Then
      WrkClass = .Item("class")
    Else
      WrkClass = 8
    End If
    If WrkCC And .Item("ccno") > 0 Then
      WrkGross = .Item("ccgrs")
    Else
      WrkGross = .Item("value")
      WrkTotBTR = 0
      If WrkBTR And .Item("btr") <> 0 Then
        If Not WrkFrozenFile Then
          myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
          If Not myTXBTR.RecordNotFound Then
            With myTXBTR
              WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + _
                ._BASS6 + ._BASS7 + ._BASS8 + ._BASS9 + ._BASSA
              WrkGross = WrkGross + WrkTotBTR
            End With
          End If
        Else
          myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
          If Not myTXBTRC.RecordNotFound Then
            With myTXBTRC
              WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + _
                ._BASS6 + ._BASS7 + ._BASS8 + ._BASS9 + ._BASSA
              WrkGross = WrkGross + WrkTotBTR
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

    'Add OPM groups to totals
    WrkTotalMV = WrkTotalMV + WrkGross
    K = LookupWrkTMCCode(Format(WrkClass, "00"))
    WrkTMCCode(K) = Format(WrkClass, "00")
    WrkTMCCount(K) = WrkTMCCount(K) + 1
    WrkTMCGross(K) = WrkTMCGross(K) + WrkGross

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
          WrkTotExMV = WrkTotExMV + WrkEx
        End If
      Next

    'Add Exemption groups
    For J = 0 To 4
      If Not IsNothing(RptExCode(J)) Then
        K = LookupWrkTExCode(RptExCode(J))
        WrkTExCode(K) = RptExCode(J)
        WrkTExMVCount(K) = WrkTExMVCount(K) + 1
        WrkTExMV(K) = WrkTExMV(K) + RptExam(J)
      End If
    Next J

  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / DsTXMVD.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

'Totals
For I = 0 To 200
  If IsNothing(WrkTMCCode(I)) Then Exit For
  dr = dsTotMC.Tables(0).NewRow
  dr.Item("tmcgroup") = "B"
  dr.Item("tmccode") = WrkTMCCode(I)
  If WrkTMCCode(I) = 8 Then
    dr.Item("tmcdesc") = "All Other Registered MV"
  Else
    dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), WrkType)
  End If
  dr.Item("tmccount") = WrkTMCCount(I)
  dr.Item("tmcgross") = WrkTMCGross(I)
  dsTotMC.Tables(0).Rows.Add(dr)
Next I

myFrmProgress.Close()
Application.DoEvents()
myTXMVDQ.CloseFile()
myTXMVDCQ.CloseFile()

End Sub
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






