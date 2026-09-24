Imports System.Text
Module PrintReportPP

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim DsTXPPRP As DataSet = New DataSet
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

  Public Sub PrtReportPP()

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)

    With MyFrmTAB01B
      WrkType = "P"
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
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkEx As Integer
    Dim WrkTotBTR As Decimal
    Dim WrkGross As Integer
    Dim WrkNet As Integer
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
        If .Item("cat") = "5" Then
          WrkTotBTR = 0
          If WrkBTR Then
            WrkTotBTR = .Item("btr")
          End If
          If WrkCC And .Item("ccno") > 0 Then
            WrkGross = .Item("ccgrs")
            WrkNet = .Item("ccgrs") - .Item("ccex")
          Else
            WrkGross = .Item("gross") + WrkTotBTR
            WrkNet = .Item("net") + WrkTotBTR
          End If
          WrkTotalPP = WrkTotalPP + 1
          WrkTotalPPGross = WrkTotalPPGross + WrkGross
          WrkTotalPPNet = WrkTotalPPNet + WrkNet
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

          'Add to Exemption groups
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
              WrkTExPP(K) = WrkTExPP(K) + WrkEx
            End If
          Next

          'Add to Exemption Letter groups
          For J = 0 To 4
            WrkEx = 0
            If Trim(WrkExcd(J)) <> "" Then
              K = LookupExem(WrkExcd(J))
              If WrkExam(J) = 0 And DsTXPPRP.Tables(0).Rows(I).Item("ccno") = 0 Then
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
              WrkLtrExPP(L) = WrkLtrExPP(L) + WrkEx
            End If
          Next
        Else
            WrkPPExempt = WrkPPExempt + .Item("gross")
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
    myTXPPRPCQ.CloseFile()

  End Sub
End Module






