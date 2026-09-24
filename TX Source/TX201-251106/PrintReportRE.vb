Imports System.Text
Module PrintReportRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTPaymnt As TPAYMNT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsElderly As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTotEx As DataSet = New DataSet
  Dim dsBCCTotEx As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim DsTXREALC As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drElderly As Data.DataRow
  Dim drTot As Data.DataRow
  Dim drTotEx As Data.DataRow
  Dim drErr As Data.DataRow

  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As String
  Dim WrkSortBy As String
  Dim WrkBillType As String
  Dim WrkExCode(200) As String
  Dim WrkExDesc(200) As String
  Dim WrkExFixedAmt(200) As Integer
  Dim WrkExPerc(200) As Decimal
  Dim WrkList As Integer
  Dim WrkType As String
  Dim WrkCode(6) As Integer
  Dim WrkAss(6) As Integer
  Dim WrkCCAss(6) As Integer
  Dim WrkExcd(6) As String
  Dim WrkCCExcd(6) As String
  Dim WrkExam(6) As Integer
  Dim WrkCCExam(6) As Integer
  Dim WrkGross As Integer
  Dim WrkExempt As Integer
  Dim WrkNet As Integer
  Dim WrkBTR As Integer
  Dim WrkTaxAmount As Decimal
  Dim WrkTax As Decimal
  Dim WrkTax1st As Decimal
  Dim WrkTax2nd As Decimal
  Dim WrkTax3rd As Decimal
  Dim WrkTax4th As Decimal
  Dim WrkCC As Boolean
  Dim WrkCCGross As Integer
  Dim WrkCCExempt As Integer
  Dim WrkCCNet As Integer
  Dim WrkCCTax As Decimal
  Dim WrkCCTax1st As Decimal
  Dim WrkCCTax2nd As Decimal
  Dim WrkSTBenefit As Decimal
  Dim WrkFrzLoss As Decimal
  Dim Wrk10MLLoss As Decimal
  Dim WrkTownBenefit As Decimal
  Dim WrkNewOwner As Boolean
  Dim WrkRounding As Decimal
  'Total Page
  Dim WrkTAccts As Integer
  Dim WrkTBills As Integer
  Dim WrkTGross As Long
  Dim WrkTExempt As Long
  Dim WrkTNet As Long
  Dim WrkTBTR As Long
  Dim WrkTNetNonElderly As Long
  Dim WrkTNetHeart As Integer
  Dim WrkTNetFrozen As Integer
  Dim WrkTTax As Decimal
  Dim WrkTTax1 As Decimal
  Dim WrkTTax2 As Decimal
  Dim WrkTVariance As Decimal
  Dim WrkTTaxNonElderly As Decimal
  Dim WrkTTaxFrozen As Decimal
  Dim WrkTTaxHeart As Decimal
  Dim WrkTTaxSTBenefit As Decimal
  Dim WrkTTaxTownBenefit As Decimal
  Dim WrkTTaxNormal As Decimal
  Dim WrkTTaxFrzLoss As Decimal
  Dim WrkTTax10MLLoss As Decimal
  Dim WrkTRounding As Decimal
  Dim WrkTTaxVariance As Decimal
  Dim WrkBCCGross As Long
  Dim WrkBCCExempt As Long
  Dim WrkBCCNet As Long
  Dim WrkBCCTax As Decimal
  Dim WrkBCCTax1 As Decimal
  Dim WrkBCCTax2 As Decimal
  Dim WrkTCCGross As Long
  Dim WrkTCCExempt As Long
  Dim WrkTCCNet As Long
  Dim WrkTCCTax As Decimal
  Dim WrkTCCTax1 As Decimal
  Dim WrkTCCTax2 As Decimal
  Dim WrkTWaiveredAccts As Integer
  Dim WrkTWaiveredGross As Integer
  Dim WrkTWaivered As Decimal
  'Exemption Totals
  Dim WrkBCCTExCount(200) As Integer
  Dim WrkBCCTExam(200) As Integer
  Dim WrkTExCount(200) As Integer
  Dim WrkTExam(200) As Integer
  Public Sub PrtReportRE()
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)


    WrkType = "R"
    'Clear Totals
    ClearTotals()

    With MyFrmTX201B
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSTot(dsTot)
      BuildDSTotEx(dsTotEx)
      BuildDSTotEx(dsBCCTotEx)
      dsElderly = ds.Clone
      dsErr = ds.Clone
    Else
      ds.Clear()
      dsTot.Clear()
      dsTotEx.Clear()
      dsBCCTotEx.Clear()
      dsElderly.Clear()
      dsErr.Clear()
    End If

    BufferExem()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsElderly = dsElderly
      .WrkdsTot = dsTot
      .WrkdsTotEx = dsTotEx
      .WrkdsBCCTotEx = dsBCCTotEx
      .WrkdsErr = dsErr
      .WrkType = WrkType
      .WrkTypeDesc = WrkBillType
      .Show()
    End With

  End Sub
  Private Sub ClearTotals()
    WrkTGross = 0
    WrkTExempt = 0
    WrkTNet = 0
    WrkTBTR = 0
    WrkTNetNonElderly = 0
    WrkTNetFrozen = 0
    WrkTNetHeart = 0
    WrkTTax = 0
    WrkTTax1 = 0
    WrkTTax2 = 0
    WrkTTaxNonElderly = 0
    WrkTTaxFrozen = 0
    WrkTTaxHeart = 0
    WrkTTaxSTBenefit = 0
    WrkTTaxTownBenefit = 0
    WrkTTaxNormal = 0
    WrkTTaxFrzLoss = 0
    WrkTTax10MLLoss = 0
    WrkTRounding = 0
    WrkTAccts = 0
    WrkTBills = 0
    WrkTWaiveredAccts = 0
    WrkTWaiveredGross = 0
    WrkTWaivered = 0
    WrkBCCGross = 0
    WrkBCCExempt = 0
    WrkBCCNet = 0
    WrkBCCTax = 0
    WrkBCCTax1 = 0
    WrkBCCTax2 = 0
    WrkTCCGross = 0
    WrkTCCExempt = 0
    WrkTCCNet = 0
    WrkTCCTax = 0
    WrkTCCTax1 = 0
    WrkTCCTax2 = 0
    Array.Clear(WrkTExCount, 0, 201)
    Array.Clear(WrkTExam, 0, 201)
    Array.Clear(WrkBCCTExCount, 0, 201)
    Array.Clear(WrkBCCTExam, 0, 201)

  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim Pos As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkFamily As String
    Dim WrkGross10ML As Integer
    Dim WrkOldOwner As String
    Dim WrkBankCode As String
    Dim WrkFrozenCode As String
    Dim WrkSname As String
    Dim SaveExLetter As String
    Const CEtitl1 As String = "FROZEN TAX"
    Const CEtitl2 As String = "ELDERLY H.E.A.R.T."

    WrkPhase = ""
    WrkBillType = GetTXTypeDesc(WrkType)
    WrkFamily = GetTXTypeFamily(WrkType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    WrkSort = "LETT, NAME, SNAME, ADD1"
    DsTXREALC = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXREALC.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveExLetter = ""
    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, "R", WrkDist)

    For I = 0 To (DsTXREALC.Tables(0).Rows.Count - 1)
      With DsTXREALC.Tables(0).Rows(I)
        'Omit Exempt properties
        If .Item("cat") = "3" Then GoTo NextRec

        WrkCC = False
        If .Item("ccno") > 0 Then
          WrkCC = True
        End If
        WrkList = .Item("list#")
        WrkNewOwner = False
        Pos = InStr(.Item("sname"), "N/O", CompareMethod.Text)
        If Pos > 0 Then
          WrkNewOwner = True
        End If
        WrkBankCode = .Item("bkcd")
        WrkCode(0) = .Item("code1")
        WrkCode(1) = .Item("code2")
        WrkCode(2) = .Item("code3")
        WrkCode(3) = .Item("code4")
        WrkCode(4) = .Item("code5")
        WrkCode(5) = .Item("code6")
        WrkCode(6) = .Item("code7")
        WrkAss(0) = .Item("ass1")
        WrkAss(1) = .Item("ass2")
        WrkAss(2) = .Item("ass3")
        WrkAss(3) = .Item("ass4")
        WrkAss(4) = .Item("ass5")
        WrkAss(5) = .Item("ass6")
        WrkAss(6) = .Item("ass7")
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
        WrkCCAss(0) = .Item("cass1")
        WrkCCAss(1) = .Item("cass2")
        WrkCCAss(2) = .Item("cass3")
        WrkCCAss(3) = .Item("cass4")
        WrkCCAss(4) = .Item("cass5")
        WrkCCAss(5) = .Item("cass6")
        WrkCCAss(6) = .Item("cass7")
        WrkCCExcd(0) = .Item("cccd1")
        WrkCCExcd(1) = .Item("cccd2")
        WrkCCExcd(2) = .Item("cccd3")
        WrkCCExcd(3) = .Item("cccd4")
        WrkCCExcd(4) = .Item("cccd5")
        WrkCCExcd(5) = .Item("cccd6")
        WrkCCExcd(6) = .Item("cccd7")
        WrkCCExam(0) = .Item("cexa1")
        WrkCCExam(1) = .Item("cexa2")
        WrkCCExam(2) = .Item("cexa3")
        WrkCCExam(3) = .Item("cexa4")
        WrkCCExam(4) = .Item("cexa5")
        WrkCCExam(5) = .Item("cexa6")
        WrkCCExam(6) = .Item("cexa7")
        WrkExempt = 0
        WrkGross10ML = 0
        WrkGross = .Item("gross") + .Item("btr")
        WrkBTR = .Item("btr")
        For J = 0 To 6
          If WrkCode(J) = 71 Then
            If Not WrkCC Then
              WrkGross10ML = WrkGross10ML + WrkAss(J)
            Else
              WrkGross10ML = WrkGross10ML + WrkCCAss(J)
            End If
          End If
          If Trim(WrkExcd(J)) <> "" Then
            K = LookupExem(WrkExcd(J))
            If WrkExam(J) = 0 And K >= 0 Then
              WrkExempt = WrkExempt + WrkExFixedAmt(K)
            Else
              WrkExempt = WrkExempt + WrkExam(J)
            End If
          End If
        Next
        WrkNet = WrkGross - WrkExempt
        If WrkNet < 0 Then WrkNet = 0
        WrkCCGross = 0
        WrkCCExempt = 0
        WrkCCNet = 0
        WrkCCTax = 0
        WrkCCTax1st = 0
        WrkCCTax2nd = 0
        If WrkCC Then
          WrkCCGross = .Item("ccgrs")
          WrkCCExempt = .Item("ccex")
          WrkCCNet = WrkCCGross - WrkCCExempt
          If WrkCCNet < 0 Then WrkCCNet = 0
          WrkCCTax = WrkCCNet * MrateMillrt
        End If
        WrkTaxAmount = (WrkNet - WrkGross10ML) * MrateMillrt
        WrkTaxAmount = WrkTaxAmount + (WrkGross10ML * 0.01)
        Wrk10MLLoss = 0
        If WrkGross10ML > 0 Then
          Wrk10MLLoss = MyUtils.Round((WrkNet * MrateMillrt) - WrkTaxAmount, 2)
        End If
        WrkSTBenefit = 0
        WrkFrzLoss = 0
        WrkTownBenefit = .Item("twnbn")
        WrkFrozenCode = .Item("fccod")
        Select Case WrkFrozenCode
          Case "F" 'Frozen
            WrkTax = MyUtils.Round(.Item("ftax"), 2) - WrkTownBenefit
            If WrkCC Then
              WrkFrzLoss = MyUtils.Round(WrkCCTax - WrkTax - WrkTownBenefit, 2)
            Else
              WrkFrzLoss = MyUtils.Round(WrkTaxAmount - WrkTax - WrkTownBenefit, 2)
            End If
          Case "C" 'Heart/Circuit Breaker
            WrkSTBenefit = .Item("ftax")
            WrkTax = WrkTaxAmount - WrkSTBenefit - WrkTownBenefit - WrkFrzLoss
            WrkCCTax = WrkCCTax - WrkSTBenefit - WrkTownBenefit
          Case Else 'Normal
            WrkTax = WrkTaxAmount - WrkTownBenefit
            WrkCCTax = WrkCCTax - WrkTownBenefit
        End Select
        With myTPaymnt
          .In_ListNo = WrkList
          .In_Type = WrkType
          .In_Year = WrkGLYear
          .In_Dst = WrkDist
          .In_Phs = WrkPhase
          .In_TaxT = WrkTax
          .CalcPaySplit()
          WrkTax = .Out_TaxT
          WrkTax1st = .Out_Tax1
          WrkTax2nd = .Out_Tax2
          WrkRounding = .In_TaxT - .Out_TaxT
          If Not WrkCC And .Out_Waivered > 0 Then
            WrkTWaiveredAccts = WrkTWaiveredAccts + 1
            WrkTWaivered = WrkTWaivered + .Out_Waivered
            WrkTWaiveredGross = WrkTWaiveredGross + WrkGross
            WrkRounding = .In_TaxT - .Out_Waivered
          End If
        End With
        If WrkCC Then
          With myTPaymnt
            .In_ListNo = WrkList
            .In_Type = WrkType
            .In_Year = WrkGLYear
            .In_Dst = WrkDist
            .In_Phs = WrkPhase
            .In_TaxT = WrkCCTax
            .CalcPaySplit()
            WrkCCTax = .Out_TaxT
            WrkCCTax1st = .Out_Tax1
            WrkCCTax2nd = .Out_Tax2
            WrkRounding = .In_TaxT - .Out_TaxT
          End With
        End If

        'Add to totals
        WrkFrozenCode = .Item("fccod")
        Select Case WrkFrozenCode
          Case "F" 'Frozen
            WrkTNetFrozen = WrkTNetFrozen + WrkNet
            WrkTTaxFrozen = WrkTTaxFrozen + WrkTax
          Case "C" 'Heart/Circuit Breaker
            If Not WrkCC Then
              WrkTNetHeart = WrkTNetHeart + WrkNet
              WrkTTaxHeart = WrkTTaxHeart + WrkTax
            Else
              WrkTNetHeart = WrkTNetHeart + WrkCCNet
              WrkTTaxHeart = WrkTTaxHeart + WrkCCTax
            End If
          Case Else 'Normal
            If Not WrkCC Then
              WrkTNetNonElderly = WrkTNetNonElderly + WrkNet
              WrkTTaxNonElderly = WrkTTaxNonElderly + WrkTax
            Else
              WrkTNetNonElderly = WrkTNetNonElderly + WrkCCNet
              WrkTTaxNonElderly = WrkTTaxNonElderly + WrkCCTax
            End If
        End Select
        WrkTTaxSTBenefit = WrkTTaxSTBenefit + WrkSTBenefit
        WrkTTaxFrzLoss = WrkTTaxFrzLoss + WrkFrzLoss
        WrkTTax10MLLoss = WrkTTax10MLLoss + Wrk10MLLoss
        WrkTTaxTownBenefit = WrkTTaxTownBenefit + WrkTownBenefit
        WrkTRounding = WrkTRounding + WrkRounding
        WrkTBTR = WrkTBTR + WrkBTR

        'Create Rate Book
        dr = ds.Tables(0).NewRow
        dr.Item("letter") = .Item("lett")
        dr.Item("frcd") = .Item("fccod")
        dr.Item("TypeDesc") = WrkBillType
        dr.Item("listno") = WrkList
        dr.Item("year") = WrkGLYear
        WrkOldOwner = ""
        If WrkNewOwner Then
          WrkSname = Trim(Replace(.Item("sname"), "N/O", ""))
          AddrLine = MyUtils.SetAddrLine(WrkSname, "", .Item("add1"), .Item("add2"),
        .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
          WrkOldOwner = .Item("name")
        Else
          AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
        .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        End If
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("oldowner") = .Item("name")
        dr.Item("bank") = .Item("bkcd")
        dr.Item("fryr") = .Item("fcyr")
        dr.Item("btr") = WrkBTR
        If .Item("btc") = "BT" Then
          dr.Item("backtax") = "BACK TAX"
        Else
          dr.Item("backtax") = ""
        End If
        If WrkSTBenefit = 0 And WrkFrzLoss = 0 Then
          dr.Item("gross") = WrkGross
          dr.Item("exemption") = WrkExempt
          dr.Item("net") = WrkNet
          dr.Item("taxtot") = WrkTax
          dr.Item("tax1st") = WrkTax1st
          dr.Item("tax2nd") = WrkTax2nd
          dr.Item("stbenefit") = 0
          dr.Item("frzloss") = 0
        End If
        dr.Item("townbenefit") = WrkTownBenefit
        dr.Item("ccno") = .Item("ccno")
        If WrkCC Then
          dr.Item("ccdate") = MyUtils.GetDBDate(.Item("cdate"))
          dr.Item("ccgross") = WrkCCGross
          dr.Item("ccexemption") = WrkCCExempt
          dr.Item("ccnet") = WrkCCNet
          dr.Item("ccetax") = WrkCCTax
          dr.Item("cctx1") = WrkCCTax1st
          dr.Item("cctx2") = WrkCCTax2nd
        End If
        dr.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
        dr.Item("propdesc2") = .Item("vol") & .Item("pge") & ", " & .Item("map")
        dr.Item("frcddesc") = String.Empty
        'Add to Report Totals
        WrkBCCGross = WrkBCCGross + WrkGross
        WrkBCCExempt = WrkBCCExempt + WrkExempt
        WrkBCCNet = WrkBCCNet + WrkNet
        WrkBCCTax = WrkBCCTax + WrkTax
        WrkBCCTax1 = WrkBCCTax1 + WrkTax1st
        WrkBCCTax2 = WrkBCCTax2 + WrkTax2nd
        If WrkCC And WrkFrzLoss = 0 Then
          WrkTCCGross = WrkTCCGross + WrkCCGross - WrkGross
          WrkTCCExempt = WrkTCCExempt + WrkCCExempt - WrkExempt
          WrkTCCNet = WrkTCCNet + WrkCCNet - WrkNet
          WrkTCCTax = WrkTCCTax + WrkCCTax - WrkTax
          WrkTCCTax1 = WrkTCCTax1 + WrkCCTax1st - WrkTax1st
          WrkTCCTax2 = WrkTCCTax2 + WrkCCTax2nd - WrkTax2nd
        End If
        WrkTAccts = WrkTAccts + 1
        If (WrkTax > 0 And Not WrkCC) Or WrkCCTax > 0 Then
          WrkTBills = WrkTBills + 1
        End If
        'Before C/C Exemption Totals
        For J = 0 To 6
          If Trim(WrkExcd(J)) <> "" Then
            K = LookupExem(WrkExcd(J))
            WrkBCCTExCount(K) = WrkBCCTExCount(K) + 1
            If WrkExam(J) = 0 And K >= 0 Then
              WrkBCCTExam(K) = WrkBCCTExam(K) + WrkExFixedAmt(K)
            Else
              WrkBCCTExam(K) = WrkBCCTExam(K) + WrkExam(J)
            End If
          End If
          'After C/C Exemption Totals
          If WrkCC Then
            If Trim(WrkCCExcd(J)) <> "" Then
              K = LookupExem(WrkCCExcd(J))
              If K >= 0 Then
                WrkTExCount(K) = WrkTExCount(K) + 1
                WrkTExam(K) = WrkTExam(K) + WrkCCExam(J)
              End If
            End If
          Else
            If Trim(WrkExcd(J)) <> "" Then
              K = LookupExem(WrkExcd(J))
              WrkTExCount(K) = WrkTExCount(K) + 1
              If WrkExam(J) = 0 And K >= 0 Then
                WrkTExam(K) = WrkTExam(K) + WrkExFixedAmt(K)
              Else
                WrkTExam(K) = WrkTExam(K) + WrkExam(J)
              End If
            End If
          End If
        Next
        ds.Tables(0).Rows.Add(dr)

        If WrkSTBenefit > 0 Or WrkFrzLoss > 0 Then
          drElderly = dsElderly.Tables(0).NewRow
          drElderly.ItemArray = dr.ItemArray 'Copy data from Reg rate book
          drElderly.Item("gross") = WrkGross
          drElderly.Item("exemption") = WrkExempt
          drElderly.Item("net") = WrkNet
          drElderly.Item("taxtot") = WrkTax
          drElderly.Item("tax1st") = WrkTax1st
          drElderly.Item("tax2nd") = WrkTax2nd
          If .Item("fccod") = "F" Then
            drElderly.Item("frcddesc") = CEtitl1
          Else
            drElderly.Item("frcddesc") = CEtitl2
          End If
          drElderly.Item("stbenefit") = WrkSTBenefit
          drElderly.Item("frzloss") = WrkFrzLoss
          drElderly.Item("townbenefit") = WrkTownBenefit
          dsElderly.Tables(0).Rows.Add(drElderly)
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXREALC.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Totals
    WrkTGross = WrkBCCGross + WrkTCCGross
    WrkTExempt = WrkBCCExempt + WrkTCCExempt
    WrkTNet = WrkBCCNet + WrkTCCNet
    WrkTTax = WrkBCCTax + WrkTCCTax
    WrkTTax1 = WrkBCCTax1 + WrkTCCTax1
    WrkTTax2 = WrkBCCTax2 + WrkTCCTax2
    drTot = dsTot.Tables(0).NewRow
    drTot.Item("tgross") = WrkTGross
    drTot.Item("texempt") = WrkTExempt
    drTot.Item("tnet") = WrkTNet
    drTot.Item("tbtr") = WrkTBTR
    drTot.Item("tnetnonelderly") = WrkTNetNonElderly
    drTot.Item("tnetfrozen") = WrkTNetFrozen
    drTot.Item("tnetheart") = WrkTNetHeart
    drTot.Item("ttax") = WrkTTax
    drTot.Item("ttax1") = WrkTTax1
    drTot.Item("ttax2") = WrkTTax2
    drTot.Item("ttaxmill") = WrkTNet * MrateMillrt
    drTot.Item("tvariance") = drTot.Item("ttaxmill") - WrkTTax
    drTot.Item("ttaxnonelderly") = WrkTTaxNonElderly
    drTot.Item("ttaxfrozen") = WrkTTaxFrozen
    drTot.Item("ttaxheart") = WrkTTaxHeart
    drTot.Item("ttaxstbenefit") = WrkTTaxSTBenefit
    drTot.Item("ttaxtownbenefit") = WrkTTaxTownBenefit
    drTot.Item("ttaxfrzloss") = WrkTTaxFrzLoss
    drTot.Item("ttax10mlloss") = WrkTTax10MLLoss
    drTot.Item("twaiveredaccts") = WrkTWaiveredAccts
    drTot.Item("twaivered") = WrkTWaivered
    drTot.Item("trounding") = WrkTRounding
    drTot.Item("ttaxvariance") = WrkTTaxSTBenefit + WrkTTaxTownBenefit + WrkTTaxFrzLoss + WrkTTax10MLLoss _
  + WrkTWaivered + WrkTRounding
    drTot.Item("taccts") = WrkTAccts
    drTot.Item("tbills") = WrkTBills
    drTot.Item("bccgross") = WrkBCCGross
    drTot.Item("bccexempt") = WrkBCCExempt
    drTot.Item("bccnet") = WrkBCCNet
    drTot.Item("bcctax") = WrkBCCTax
    drTot.Item("bcctax1") = WrkBCCTax1
    drTot.Item("bcctax2") = WrkBCCTax2
    drTot.Item("ccgross") = WrkTCCGross
    drTot.Item("ccexempt") = WrkTCCExempt
    drTot.Item("ccnet") = WrkTCCNet
    drTot.Item("cctax") = WrkTCCTax
    drTot.Item("cctax1") = WrkTCCTax1
    drTot.Item("cctax2") = WrkTCCTax2
    dsTot.Tables(0).Rows.Add(drTot)

    'Before C/C Exemption Totals
    drTotEx = dsBCCTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = "BEFORE C/C GROSS"
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = WrkBCCGross
    dsBCCTotEx.Tables(0).Rows.Add(drTotEx)
    drTotEx = dsBCCTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = "BEFORE C/C NET"
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = WrkBCCNet
    dsBCCTotEx.Tables(0).Rows.Add(drTotEx)
    'Add a Blank line to report
    drTotEx = dsBCCTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = ""
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = 0
    dsBCCTotEx.Tables(0).Rows.Add(drTotEx)

    For I = 0 To 200
      If WrkTExCount(I) > 0 Then
        If SaveExLetter <> Left(WrkExCode(I), 1) Then
          SaveExLetter = Left(WrkExCode(I), 1)
          K = LookupExem(SaveExLetter)
          drTotEx = dsBCCTotEx.Tables(0).NewRow
          drTotEx.Item("tcode") = ""
          If K >= 0 Then
            drTotEx.Item("tdesc") = WrkExDesc(K)
          Else
            drTotEx.Item("tdesc") = "*** " & SaveExLetter & " " & " not found in exemption file ***"
          End If
          drTotEx.Item("tcount") = 0
          drTotEx.Item("texempt") = 0
          dsBCCTotEx.Tables(0).Rows.Add(drTotEx)
        End If
        drTotEx = dsBCCTotEx.Tables(0).NewRow
        drTotEx.Item("tcode") = WrkExCode(I)
        drTotEx.Item("tdesc") = WrkExDesc(I)
        drTotEx.Item("tcount") = WrkBCCTExCount(I)
        drTotEx.Item("texempt") = WrkBCCTExam(I)
        dsBCCTotEx.Tables(0).Rows.Add(drTotEx)
      End If
    Next

    'After C/C Exemption Totals
    drTotEx = dsTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = "AFTER C/C GROSS"
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = WrkTGross
    dsTotEx.Tables(0).Rows.Add(drTotEx)
    drTotEx = dsTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = "AFTER C/C NET"
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = WrkTNet
    dsTotEx.Tables(0).Rows.Add(drTotEx)
    'Add a Blank line to report
    drTotEx = dsTotEx.Tables(0).NewRow
    drTotEx.Item("tcode") = ""
    drTotEx.Item("tdesc") = ""
    drTotEx.Item("tcount") = 0
    drTotEx.Item("texempt") = 0
    dsTotEx.Tables(0).Rows.Add(drTotEx)

    For I = 0 To 200
      If WrkTExCount(I) > 0 Then
        If SaveExLetter <> Left(WrkExCode(I), 1) Then
          SaveExLetter = Left(WrkExCode(I), 1)
          K = LookupExem(SaveExLetter)
          drTotEx = dsTotEx.Tables(0).NewRow
          drTotEx.Item("tcode") = ""
          If K >= 0 Then
            drTotEx.Item("tdesc") = WrkExDesc(K)
          Else
            drTotEx.Item("tdesc") = "*** " & SaveExLetter & " " & " not found in exemption file ***"
          End If
          drTotEx.Item("tcount") = 0
          drTotEx.Item("texempt") = 0
          dsTotEx.Tables(0).Rows.Add(drTotEx)
        End If
        drTotEx = dsTotEx.Tables(0).NewRow
        drTotEx.Item("tcode") = WrkExCode(I)
        drTotEx.Item("tdesc") = WrkExDesc(I)
        drTotEx.Item("tcount") = WrkTExCount(I)
        drTotEx.Item("texempt") = WrkTExam(I)
        dsTotEx.Tables(0).Rows.Add(drTotEx)
      End If
    Next

    myFrmProgress.Close()
    myTXREALCQ.CloseFile()

  End Sub
  Private Sub BufferExem()
    Dim I As Integer

    Dim myTXEXEM As TXEXEM.MyData
    Dim dsTXEXEM As DataSet = New DataSet

    myTXEXEM = New TXEXEM.MyData(myDBConnect)

    dsTXEXEM = myTXEXEM.GetAllData
    For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        WrkExCode(I) = Trim(.Item("texem"))
        WrkExDesc(I) = .Item("tdesc")
        WrkExFixedAmt(I) = .Item("tfixam")
        If .Item("tfixam") = 0 And .Item("tperc") = 0 Then
          WrkExPerc(I) = 1
        Else
          WrkExPerc(I) = .Item("tperc")
        End If
      End With
    Next

  End Sub
  Private Function LookupExem(ByVal Exem As String) As Integer
    Dim I As Integer

    For I = 0 To WrkExCode.GetUpperBound(0)
      If Trim(WrkExCode(I)) = "" Then
        Return -1
      End If
      If Trim(Exem) = Trim(WrkExCode(I)) Then
        Return I
      End If
    Next

  End Function
End Module






