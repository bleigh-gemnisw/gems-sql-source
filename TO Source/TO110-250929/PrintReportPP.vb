Imports System.Text
Module PrintReportPP

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim DsTXPPRP As DataSet = New DataSet

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkFrozenFile As Boolean

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer
  Public Sub PrtReportPP()

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)

    With MyFrmTO110B
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

    GetDetail()

  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkTypeDesc As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkCodeB As Boolean
    Dim Good As Boolean

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

    WrkTypeDesc = GetTXTypeDesc(WrkType)
    GetMillRate(WrkYear, WrkDist)

    If Not WrkFrozenFile Then
      DsTXPPRP = myTXPPRPQ.GetQry(WrkSort, WrkQry, 0)
    Else
      DsTXPPRP = myTXPPRPCQ.GetQry(WrkSort, WrkQry, 0)
    End If
    If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
      With DsTXPPRP.Tables(0).Rows(I)
        Good = False
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

        For J = 0 To WrkExcd.GetUpperBound(0)
          If Mid(WrkExcd(J), 1, 1) = "B" And WrkExam(J) > 0 _
       Or Mid(WrkExcd(J), 1, 1) = "C" And WrkExam(J) > 0 Then
            K = LookupExem(WrkExcd(J))
            If WrkExLetter(K) <> "B" And WrkExLetter(K) <> "C" Then Continue For
            Good = True
            WrkCodeB = False
            If WrkExLetter(K) = "B" Then
              WrkCodeB = True
            End If
            If WrkCodeB Then
              dr = dsCatB.Tables(0).NewRow
            Else
              dr = dsCatC.Tables(0).NewRow
            End If
            dr.Item("listno") = .Item("list#")
            dr.Item("type") = WrkType
            dr.Item("typedesc") = WrkTypeDesc
            AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
          .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
            dr.Item("addr1") = AddrLine(0)
            dr.Item("addr2") = AddrLine(1)
            dr.Item("addr3") = AddrLine(2)
            dr.Item("addr4") = AddrLine(3)
            dr.Item("addr5") = AddrLine(4)
            dr.Item("excd") = WrkExcd(J)
            dr.Item("exam") = WrkExam(J)
            dr.Item("revloss") = MyUtils.Round(WrkExam(J) * CurMillrt, 2)
            If WrkCodeB Then
              dsCatB.Tables(0).Rows.Add(dr)
              MyCurAccts = MyCurAccts + 1
              MyCurAmt = MyCurAmt + WrkExam(J)
              MyCurRevLoss = MyCurRevLoss + dr.Item("revloss")
            Else
              dsCatC.Tables(0).Rows.Add(dr)
            End If
            'Missing
            If WrkCodeB And Not CheckTXM59A(.Item("list#"), WrkType, WrkYear) Then
              dr = dsErr.Tables(0).NewRow
              dr.Item("listno") = .Item("list#")
              dr.Item("type") = WrkType
              dr.Item("typedesc") = WrkTypeDesc
              dr.Item("addr1") = AddrLine(0)
              dr.Item("excd") = WrkExcd(J)
              dr.Item("exam") = WrkExam(J)
              dsErr.Tables(0).Rows.Add(dr)
            End If
          End If
        Next
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






