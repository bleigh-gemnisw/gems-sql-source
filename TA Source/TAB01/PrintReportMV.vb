Imports System.Text
Module PrintReportMV

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXMVDQ As TXMVDQ.MyData
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXCOEB As TXCOEB.MyData
  Dim myTXMVPCT As TXMVPCT.MyData
  Dim DsTXMVD As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkFrozenFile As Boolean
  Dim WrkCC As Boolean
  Dim WrkBTR As Boolean

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer
  Dim WrkExLet(4) As String
  Public Sub PrtReportMV()

    myTXMVDQ = New TXMVDQ.MyData(myDBConnect)
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXCOEB = New TXCOEB.MyData(myDBConnect)
    myTXMVPCT = New TXMVPCT.MyData(myDBConnect)

    With MyFrmTAB01B
      WrkType = "M"
      WrkGLYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkPrintDist = False
      If .ChkPrtDist.Checked Then
        WrkPrintDist = True
      End If
      WrkFrozenFile = False
      If .ChkFrozenFile.Checked Then
        WrkFrozenFile = True
      End If
      WrkCC = False
      If .ChkCC.Checked Then
        WrkCC = True
      End If
      WrkBTR = False
      If .ChkBAA.Checked Then
        WrkBTR = True
      End If
    End With

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim DsTXCOEB As DataSet = New DataSet
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkEx As Integer
    Dim WrkGross As Decimal
    Dim WrkNet As Decimal
    Dim WrkMVCred As Decimal
    Dim WrkTex As Integer
    Dim WrkTotBTR As Decimal
    Dim Pos As Integer
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim L As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkSort = ""
    WrkQry = ""
    If Not WrkDistAll Then
      If Not WrkPrintDist Then
        WrkQry = "dist=" & WrkDist
      Else
        WrkQry = "pdst=" & WrkDist
      End If
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
        If .Item("cat") = "1" Then
          WrkTotBTR = 0
          If WrkBTR Then
            WrkTotBTR = .Item("btr")
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
          WrkTex = WrkExam(0) + WrkExam(1) + WrkExam(2) + WrkExam(3) + WrkExam(4)
          WrkMVCred = 0
          If WrkCC And .Item("ccno") > 0 Then
            WrkGross = .Item("ccgrs")
            WrkMVCred = CalcMvCred(.Item("ccno"))
            WrkNet = .Item("ccgrs") - WrkTex - WrkMVCred
          Else
            WrkGross = .Item("value") + WrkTotBTR
            WrkNet = .Item("value") - WrkTex + WrkTotBTR
          End If
          WrkTotalMV = WrkTotalMV + 1
          WrkTotalMVGross = WrkTotalMVGross + WrkGross
          WrkTotalMVNet = WrkTotalMVNet + WrkNet

          'Combine Exemptions into Letter groups
          For J = 0 To 4
            WrkEx = 0
            If Trim(WrkExcd(J)) <> "" Then
              K = LookupExem(WrkExcd(J))
              If WrkExam(J) = 0 Then
                WrkEx = WrkExFixedAmt(K)
              Else
                WrkEx = WrkExam(J)
              End If
              K = LookupWrkTExCode(WrkExcd(J))
              WrkTExCode(K) = WrkExcd(J)
              WrkTExMV(K) = WrkTExMV(K) + WrkEx
            End If
          Next

          'Add to Exemption Letter groups
          For J = 0 To 4
            WrkEx = 0
            If Trim(WrkExcd(J)) <> "" Then
              K = LookupExem(WrkExcd(J))
              If WrkExam(J) = 0 And DsTXMVD.Tables(0).Rows(I).Item("ccno") = 0 Then
                WrkEx = WrkExFixedAmt(K)
              Else
                WrkEx = WrkExam(J)
              End If
              L = LookupWrkLtrEx(WrkExLetter(K))
              WrkLtrEx(L) = WrkExLetter(K)
              Pos = InStr(WrkLtrDesc(L), WrkExcd(J))
              If Pos = 0 Then
                WrkLtrDesc(L) = WrkLtrDesc(L) + WrkExcd(J) & " "
              End If
              WrkLtrExMV(L) = WrkLtrExMV(L) + WrkEx
            End If
          Next

        Else
          If .Item("cat") = "3" Then
            WrkMVExempt = WrkMVExempt + .Item("value")
          End If
        End If
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

    myFrmProgress.Close()
    Application.DoEvents()
    myTXMVDQ.CloseFile()
    myTXMVDCQ.CloseFile()

  End Sub
  Public Function CalcMvCred(ByVal CCNo As Integer) As Integer
    Dim WrkCCGross As Decimal
    Dim WrkCode As String
    Dim WrkAmount As Decimal

    myTXCOEB.GetOneRecordP(CCNo)
    If myTXCOEB.RecordNotFound Then Exit Function

    With myTXCOEB
      WrkCCGross = ._CGRS
      WrkCode = ._CT2MC1
    End With

    myTXMVPCT.GetOneRecordP("M", WrkCode)
    If myTXMVPCT.RecordNotFound Then Exit Function

    With myTXMVPCT
      WrkAmount = MyUtils.Round(WrkCCGross * ._PCT, 0)
    End With

    Return WrkAmount
  End Function
End Module






