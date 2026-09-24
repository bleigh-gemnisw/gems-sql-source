Imports System.Text
Module PrintReportSU

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPCQ As TXSUPPCQ.MyData
  Dim myTXCOEB As TXCOEB.MyData
  Dim myTXMVPCT As TXMVPCT.MyData
  Dim myTPaymnt As TPAYMNT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTotEx As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim DsTXSUPP As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drTot As Data.DataRow
  Dim drTotEx As Data.DataRow
  Dim drErr As Data.DataRow
  Dim dsBCCTotEx As DataSet = New DataSet

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
  Dim WrkExcd(4) As String
  Dim WrkExam(9) As Integer
  Dim WrkCCExcd(4) As String
  Dim WrkCCExam(9) As Integer
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
  Dim WrkRounding As Decimal
  Dim WrkCC As Boolean
  Dim WrkCCGross As Integer
  Dim WrkCCExempt As Integer
  Dim WrkCCNet As Integer
  Dim WrkCCCredit As Integer
  Dim WrkCCTax As Decimal
  Dim WrkCCTax1st As Decimal
  Dim WrkCCTax2nd As Decimal
  'Total Page
  Dim WrkTAccts As Integer
  Dim WrkTBills As Integer
  Dim WrkTGross As Long
  Dim WrkTPartial As Long
  Dim WrkTCredit As Long
  Dim WrkTExempt As Long
  Dim WrkTNet As Long
  Dim WrkTFull As Long
  Dim WrkTProrate As Long
  Dim WrkTFullCredit As Long
  Dim WrkTProrateCredit As Long
  Dim WrkTBTR As Long
  Dim WrkTTax As Decimal
  Dim WrkTTax1 As Decimal
  Dim WrkTTax2 As Decimal
  Dim WrkTTaxNormal As Decimal
  Dim WrkTRounding As Decimal
  Dim WrkBCCGross As Long
  Dim WrkBCCExempt As Long
  Dim WrkBCCNet As Long
  Dim WrkBCCTax As Decimal
  Dim WrkBCCTax1 As Decimal
  Dim WrkBCCTax2 As Decimal
  Dim WrkTCCGross As Long
  Dim WrkTCCExempt As Long
  Dim WrkTCCNet As Long
  Dim WrkTCCCredit As Long
  Dim WrkTCCTax As Decimal
  Dim WrkTCCTax1 As Decimal
  Dim WrkTCCTax2 As Decimal
  Dim WrkTWaiveredAccts As Integer
  Dim WrkTWaiveredGross As Integer
  Dim WrkTWaivered As Decimal
  'Buffered files
  Dim WrkSupCode(25) As String
  Dim WrkSupPct(25) As Decimal
  'Exemption Totals
  Dim WrkBCCTExCount(200) As Integer
  Dim WrkBCCTExam(200) As Integer
  Dim WrkTExCount(200) As Integer
  Dim WrkTExam(200) As Integer
  Public Sub PrtReportSU()
    myTXSUPPCQ = New TXSUPPCQ.MyData(myDBConnect)
    myTXCOEB = New TXCOEB.MyData(myDBConnect)
    myTXMVPCT = New TXMVPCT.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)

    WrkType = "S"
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
      dsErr = ds.Clone
    Else
      ds.Clear()
      dsTot.Clear()
      dsTotEx.Clear()
      dsBCCTotEx.Clear()
      dsErr.Clear()
    End If

    BufferTXSupcd()
    BufferExem()
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
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
    WrkTPartial = 0
    WrkTCredit = 0
    WrkTExempt = 0
    WrkTNet = 0
    WrkTFull = 0
    WrkTProrate = 0
    WrkTFullCredit = 0
    WrkTProrateCredit = 0
    WrkTBTR = 0
    WrkTTax = 0
    WrkTTax1 = 0
    WrkTTax2 = 0
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
    WrkTCCCredit = 0
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
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkFamily As String
    Dim SaveExLetter As String
    Dim WrkMVCred As Integer
    Dim WrkProratePct As Decimal
    Dim WrkCreditPct As Decimal
    Dim WrkProrate As Integer
    Dim WrkCredit As Integer

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

    WrkSort = "NAME, SNAME, ADD1"

    DsTXSUPP = myTXSUPPCQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveExLetter = ""
    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, "S", WrkDist)

    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      With DsTXSUPP.Tables(0).Rows(I)
        'Omit Exempt properties
        'MK 11/6/25 Begin
        If .Item("cat") <> "1" Then GoTo NextRec
        'MK 11/6/25 End
        'If .Item("cat") = "3" Then GoTo NextRec
        WrkCC = False
        If .Item("ccno") > 0 Then
          WrkCC = True
        End If
        WrkList = .Item("list#")
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
        WrkCCExcd(0) = .Item("cccd1")
        WrkCCExcd(1) = .Item("cccd2")
        WrkCCExcd(2) = .Item("cccd3")
        WrkCCExcd(3) = .Item("cccd4")
        WrkCCExcd(4) = .Item("cccd5")
        WrkCCExam(0) = .Item("cexa1")
        WrkCCExam(1) = .Item("cexa2")
        WrkCCExam(2) = .Item("cexa3")
        WrkCCExam(3) = .Item("cexa4")
        WrkCCExam(4) = .Item("cexa5")
        WrkExempt = 0
        WrkGross = .Item("value") + .Item("btr")
        WrkBTR = .Item("btr")
        For J = 0 To 4
          If Trim(WrkExcd(J)) <> "" Then
            K = LookupExem(WrkExcd(J))
            If WrkExam(J) = 0 And K >= 0 Then
              WrkExempt = WrkExempt + WrkExFixedAmt(K)
            Else
              WrkExempt = WrkExempt + WrkExam(J)
            End If
          End If
        Next
        WrkProratePct = CalcPct(.Item("ass"))
        WrkProrate = CalcAssmt(.Item("value"), WrkProratePct)
        WrkCreditPct = CalcPct(.Item("oass"))
        WrkCredit = CalcAssmt(.Item("oval"), WrkCreditPct)
        If WrkCredit > WrkProrate Then
          WrkCredit = WrkProrate
        End If
        WrkNet = WrkProrate - WrkCredit - WrkExempt
        If WrkNet < 0 Then WrkNet = 0
        WrkCCGross = 0
        WrkCCExempt = 0
        WrkCCNet = 0
        WrkCCCredit = 0
        WrkCCTax = 0
        WrkCCTax1st = 0
        WrkCCTax2nd = 0
        WrkMVCred = 0
        If WrkCC Then
          WrkCCGross = .Item("ccgrs")
          WrkCCExempt = .Item("ccex")
          myTXCOEB.GetOneRecordP(.Item("ccno"))
          If Not myTXCOEB.RecordNotFound Then
            With myTXCOEB
              WrkCCNet = ._NTNET
              WrkGross = ._CGRS
            End With
          End If
          WrkCCTax = WrkCCNet * MrateMillrt
        End If
        WrkTaxAmount = WrkNet * MrateMillrt
        WrkTax = WrkTaxAmount
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
          If .Out_Waivered > 0 Then
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
        WrkTBTR = WrkTBTR + WrkBTR

        'Create Rate Book
        dr = ds.Tables(0).NewRow
        dr.Item("letter") = .Item("lett")
        dr.Item("TypeDesc") = WrkBillType
        dr.Item("listno") = WrkList
        dr.Item("year") = WrkGLYear
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("gross") = WrkGross
        dr.Item("exemption") = WrkExempt
        dr.Item("prorate") = WrkProrate
        dr.Item("credit") = WrkCredit
        dr.Item("net") = WrkNet
        dr.Item("btr") = WrkBTR
        If .Item("btc") = "BT" Then
          dr.Item("backtax") = "BACK TAX"
        Else
          dr.Item("backtax") = ""
        End If
        dr.Item("taxtot") = WrkTax
        dr.Item("tax1st") = WrkTax1st
        dr.Item("tax2nd") = WrkTax2nd
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
        dr.Item("propdesc") = .Item("year") & " " & .Item("make") & " " &
      .Item("model") & " " & .Item("vinno") & " " & .Item("regno")
        If WrkCredit > 0 Then
          dr.Item("propdesc2") = .Item("oyear") & " " & .Item("omake") & " " &
        .Item("omod") & " " & .Item("ovin") & " " & .Item("oreg#")
        End If
        'Add to Report Totals
        WrkBCCGross = WrkBCCGross + WrkGross
        WrkBCCExempt = WrkBCCExempt + WrkExempt
        WrkBCCNet = WrkBCCNet + WrkNet
        WrkBCCTax = WrkBCCTax + WrkTax
        WrkBCCTax1 = WrkBCCTax1 + WrkTax1st
        WrkBCCTax2 = WrkBCCTax2 + WrkTax2nd
        If WrkCC Then
          WrkTCCGross = WrkTCCGross + WrkCCGross - WrkGross
          WrkTCCExempt = WrkTCCExempt + WrkCCExempt - WrkExempt
          WrkTCCNet = WrkTCCNet + WrkCCNet - WrkNet
          WrkTCCCredit = WrkTCCCredit + WrkMVCred
          WrkTCCTax = WrkTCCTax + WrkCCTax - WrkTax
          WrkTCCTax1 = WrkTCCTax1 + WrkCCTax1st - WrkTax1st
          WrkTCCTax2 = WrkTCCTax2 + WrkCCTax2nd - WrkTax2nd
        End If
        WrkTAccts = WrkTAccts + 1
        WrkTRounding = WrkTRounding + WrkRounding
        If (WrkTax > 0 And Not WrkCC) Or WrkCCTax > 0 Then
          WrkTBills = WrkTBills + 1
        End If

        'Before C/C Exemption Totals
        For J = 0 To 4
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
        WrkTGross = WrkBCCGross + WrkTCCGross
        WrkTExempt = WrkBCCExempt + WrkTCCExempt
        WrkTNet = WrkBCCNet + WrkTCCNet
        WrkTTax = WrkBCCTax + WrkTCCTax
        WrkTTax1 = WrkBCCTax1 + WrkTCCTax1
        WrkTTax2 = WrkBCCTax2 + WrkTCCTax2
        WrkTPartial = WrkTPartial + WrkProrate
        WrkTCredit = WrkTCredit + WrkCredit
        If WrkProratePct = 1 Then
          WrkTFull = WrkTFull + WrkGross
        Else
          WrkTProrate = WrkTProrate + WrkGross
        End If
        If WrkCredit > 0 Then
          If WrkCreditPct = 1 Then
            WrkTFullCredit = WrkTFullCredit + WrkCredit
          Else
            WrkTProrateCredit = WrkTProrateCredit + WrkCredit
          End If
        End If
        WrkTRounding = WrkTRounding + WrkRounding
        ds.Tables(0).Rows.Add(dr)
      End With


NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Totals
    drTot = dsTot.Tables(0).NewRow
    drTot.Item("taccts") = WrkTAccts
    drTot.Item("tbills") = WrkTBills
    drTot.Item("tgross") = WrkTGross
    drTot.Item("texempt") = WrkTExempt
    drTot.Item("tprorate") = WrkTProrate
    drTot.Item("tcredit") = WrkTCredit
    drTot.Item("tnet") = WrkTNet
    drTot.Item("tfull") = WrkTFull
    drTot.Item("tpartial") = WrkTPartial
    drTot.Item("tfullcredit") = WrkTFullCredit
    drTot.Item("tproratecredit") = WrkTProrateCredit
    drTot.Item("tbtr") = WrkTBTR
    drTot.Item("ttax") = WrkTTax
    drTot.Item("ttax1") = WrkTTax1
    drTot.Item("ttax2") = WrkTTax2
    drTot.Item("bccgross") = WrkBCCGross
    drTot.Item("bccexempt") = WrkBCCExempt
    drTot.Item("bccnet") = WrkBCCNet
    drTot.Item("bcctax") = WrkBCCTax
    drTot.Item("bcctax1") = WrkBCCTax1
    drTot.Item("bcctax2") = WrkBCCTax2
    drTot.Item("ccgross") = WrkTCCGross
    drTot.Item("ccexempt") = WrkTCCExempt
    drTot.Item("ccnet") = WrkTCCNet
    drTot.Item("cccredit") = WrkTCCCredit
    drTot.Item("cctax") = WrkTCCTax
    drTot.Item("cctax1") = WrkTCCTax1
    drTot.Item("cctax2") = WrkTCCTax2
    drTot.Item("ttaxmill") = WrkTNet * MrateMillrt
    drTot.Item("tvariance") = drTot.Item("ttaxmill") - WrkTTax
    drTot.Item("ttaxheart") = 0
    drTot.Item("ttaxstbenefit") = 0
    drTot.Item("ttaxtownbenefit") = 0
    drTot.Item("ttaxfrzloss") = 0
    drTot.Item("ttax10mlloss") = 0
    drTot.Item("twaiveredaccts") = WrkTWaiveredAccts
    drTot.Item("twaivered") = WrkTWaivered
    drTot.Item("trounding") = WrkTRounding
    drTot.Item("ttaxvariance") = WrkTWaivered + WrkTRounding
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
    myTXSUPPCQ.CloseFile()

  End Sub
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    WrkPct = WrkSupPct(K)
    Return WrkPct
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Integer
    WrkProRate = MyUtils.Round(Value * Pct, 0)
    Return WrkProRate
  End Function
  Private Sub BufferTXSupcd()
    Dim I As Integer

    Dim myTXSUPCD As TXSUPCD.MyData
    Dim dsTXSupcd As DataSet = New DataSet

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)

    dsTXSupcd = myTXSUPCD.GetAllData
    For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupPct(I) = .Item("spct")
      End With
    Next

  End Sub
  Private Function LookupTxSupcd(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next

  End Function
  Private Sub BufferExem()
    Dim I As Integer

    Dim myTXEXEM As TXEXEM.MyData
    Dim dsTXEXEM As DataSet = New DataSet

    myTXEXEM = New TXEXEM.MyData(myDBConnect)

    dsTXEXEM = myTXEXEM.GetAllData
    For I = 0 To dsTXEXEM.Tables(0).Rows.Count - 1
      With dsTXEXEM.Tables(0).Rows(I)
        WrkExCode(I) = .Item("texem")
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







