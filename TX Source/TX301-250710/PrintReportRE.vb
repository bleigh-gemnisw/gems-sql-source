Imports System.Text
Imports System.IO
Module PrintReportRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTPaymnt As TPAYMNT.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXCOEB As TXCOEB.MyData
  Dim myTXDEFER As TXDEFER.MyData
  Dim myTXFREEZE As TXFREEZE.MyData

  Dim ds As DataSet = New DataSet
  Dim dsEscrow As DataSet = New DataSet
  Dim dsBill As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim DsTXREALC As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drBill As Data.DataRow
  Dim drTot As Data.DataRow

  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As String
  Dim WrkUpdate As Boolean
  Dim WrkUpdateDist As Boolean
  Dim WrkUpdatePDist As Boolean
  Dim WrkSortBy As String
  Dim WrkNonEscrow As Boolean
  Dim WrkNonEscrowBank As Boolean
  Dim WrkBank As String
  Dim WrkAllBanks As Boolean
  Dim WrkComment As String
  Dim WrkAlternative As Boolean
  Dim WrkBarcode As Boolean
  Dim WrkCSV As Boolean
  Dim WrkHeadings As Boolean

  Dim WrkTotDesc(6) As String
  Dim WrkTotCount(6) As Integer
  Dim WrkTotGross(6) As Long
  Dim WrkTotExemption(6) As Integer
  Dim WrkTotNet(6) As Long
  Dim WrkTotTax(6) As Decimal
  Dim WrkTot1st(6) As Decimal
  Dim WrkTot2nd(6) As Decimal
  Dim WrkList As Integer
  Dim WrkType As String
  Dim WrkCode(6) As Integer
  Dim WrkAss(6) As Integer
  Dim WrkCCAss(6) As Integer
  Dim WrkExcd(6) As String
  Dim WrkCCExcd(6) As String
  Dim WrkExam(6) As Integer
  Dim WrkCCExam(6) As Integer
  Dim WrkGross As Long
  Dim WrkExempt As Integer
  Dim WrkNet As Long
  Dim WrkTaxAmount As Decimal
  Dim WrkTaxTotal As Decimal
  Dim WrkTax1st As Decimal
  Dim WrkTax2nd As Decimal
  Dim WrkTax3rd As Decimal
  Dim WrkTax4th As Decimal
  Dim WrkDeferT As Decimal
  Dim WrkDefer1st As Decimal
  Dim WrkDefer2nd As Decimal
  Dim WrkDefer3rd As Decimal
  Dim WrkDefer4th As Decimal
  Dim WrkWaivered As Decimal
  Dim WrkCC As Boolean
  Dim WrkFrozenCode As String
  Dim WrkSTBenefit As Decimal
  Dim WrkTownBenefit As Decimal
  Dim WrkScanLine As String
  Dim WrkNewOwner As Boolean
  Dim WrkNewName As String
  Dim WrkBillCount As Integer
  Dim WrkIsEscrow As Boolean
  'Buffer Banks
  Dim WrkBanksCode(400) As String
  Dim WrkBanksPrnt(400) As Boolean

  Public Sub PrtReportRE()

    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXCOEB = New TXCOEB.MyData(myDBConnect)
    myTXDEFER = New TXDEFER.MyData(myDBConnect)
    myTXFREEZE = New TXFREEZE.MyData(myDBConnect)

    'Clear Totals
    Array.Clear(WrkTotCount, 0, 7)
    Array.Clear(WrkTotGross, 0, 7)
    Array.Clear(WrkTotExemption, 0, 7)
    Array.Clear(WrkTotNet, 0, 7)
    Array.Clear(WrkTotTax, 0, 7)
    Array.Clear(WrkTot1st, 0, 7)
    Array.Clear(WrkTot2nd, 0, 7)

    With MyFrmTX301B
      WrkType = "R"
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortZip.Checked Then
        WrkSortBy = "Zip"
      End If
      WrkUpdate = .ChkUpdate.Checked
      WrkUpdateDist = .ChkUpdateDist.Checked
      WrkNonEscrow = .RbSelNon.Checked
      WrkNonEscrowBank = .RbSelNonBanks.Checked
      WrkBank = .TxtBankCd.Text
      WrkAllBanks = .ChkAllBanks.Checked
      WrkComment = .TxtComment.Text
      WrkCSV = .RbCSV.Checked
      WrkHeadings = .ChkHeadings.Checked
      WrkAlternative = .ChkAlternative.Checked
      WrkBarcode = .ChkBarcode.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      dsEscrow = ds.Clone
      BuildDSBill(dsBill)
      BuildDSTot(dsTot)
    Else
      ds.Clear()
      dsEscrow.Clear()
      dsBill.Clear()
      dsTot.Clear()
    End If

    If WrkExCode(0) = Nothing Then
      BufferExem()
    End If

    If WrkNonEscrow Or WrkNonEscrowBank Then
      BufferBanksEscrow()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsEscrow = dsEscrow
      .wrkdsBill = dsBill
      .wrkdsTot = dsTot
      .WrkDueDate1 = ProfTxDt(0)
      .WrkDueDate2 = ProfTxDt(1)
      .WrkGraceDate1 = ProfGrDt(0)
      .WrkGraceDate2 = ProfGrDt(1)
      .WrkMillRt = MrateMillrt * 1000
      .WrkStateMillRt = MyUtils.CnvSng(MyFrmTX301B.TxtStateMillRate.Text)
      .WrkStateMoney = MyUtils.CnvSng(MyFrmTX301B.TxtStateMoney.Text)
      .WrkType = WrkType
      .WrkPost = WrkUpdate
      .WrkBillCount = WrkBillCount
      .Show()
    End With

    'Unlock file
    If WrkUpdate Then
      myTXINV.CloseFile()
    End If
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim AddrLine() As String
    Dim Pos As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkBillType As String
    Dim WrkFamily As String
    Dim WrkGross10ML As Integer
    Dim WrkOldOwner As String
    Dim WrkEscrowPrint As Boolean
    Dim WrkBankCode As String
    Dim WrkCreateBill As Boolean

    WrkPhase = ""
    WrkBillType = GetTXTypeDesc(WrkType) & " TAX BILL"
    WrkFamily = GetTXTypeFamily(WrkType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If Not WrkDistAll Then
      WrkQry = "dist=" & WrkDist
    End If
    If Trim(WrkBank) <> String.Empty Then
      If WrkQry = String.Empty Then
        WrkQry = "BKCD=" & MyUtils.Quo(WrkBank)
      Else
        WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBank)
      End If
    End If
    If WrkAllBanks Then
      If WrkQry = String.Empty Then
        WrkQry = "BKCD<>' ' " & WrkAnd & "BKSV=' '"
      Else
        WrkQry = WrkQry & WrkAnd & "BKCD<>' '" & WrkAnd & "BKSV=' '"
      End If
    End If

    Select Case WrkSortBy
      Case "Name"
        WrkSort = "BKCD, NAME, LIST#"
      Case "Zip"
        WrkSort = "BKCD, ZIP5, NAME"
      Case Else
        WrkSort = ""
    End Select

    GetTXFMBILL(WrkType)
    If Trim(myTXFMBILL._LINE1) = String.Empty Then
      GetTXFMBILL(" ")
    End If

    DsTXREALC = myTXREALCQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXREALC.Tables(0).Rows.Count = 0 Then Exit Sub

    If MyFrmTX301B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmTX301B.LblFilePath.Text)
    End If

    If MyFrmTX301B.LblFilePath.Text <> "" And WrkHeadings Then
      sw.WriteLine(HeadingsCSV)
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, WrkType, WrkDist)

    WrkBillCount = 0

    For I = 0 To (DsTXREALC.Tables(0).Rows.Count - 1)
      With DsTXREALC.Tables(0).Rows(I)
        WrkCC = False
        If .Item("ccno") > 0 Then
          WrkCC = True
        End If
        WrkList = .Item("list#")
        WrkNewOwner = False
        WrkNewName = String.Empty
        Pos = InStr(.Item("sname"), "N/O", CompareMethod.Text)
        If Pos > 0 Then
          WrkNewOwner = True
          WrkNewName = Trim(Replace(.Item("sname"), "N/O", ""))
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
        If WrkCC Then
          WrkGross = .Item("ccgrs")
          WrkExempt = .Item("ccex")
        Else
          WrkGross = .Item("gross") + .Item("btr")
          For J = 0 To 6
            If WrkCode(J) = 71 Then
              If Not WrkCC Then
                WrkGross10ML = WrkGross10ML + WrkAss(J)
              Else
                WrkGross10ML = WrkGross10ML + WrkCCAss(J)
              End If
            End If
            If Trim(WrkExcd(J)) <> "" And WrkExam(J) = 0 Then
              K = LookupExem(WrkExcd(J))
              WrkExempt = WrkExempt + WrkExFixedAmt(K)
            Else
              WrkExempt = WrkExempt + WrkExam(J)
            End If
          Next
        End If
        WrkNet = WrkGross - WrkExempt
        If WrkNet < 0 Then WrkNet = 0
        If .Item("cat") = "3" Then 'Tax Exempt
          WrkTaxAmount = 0
        Else
          WrkTaxAmount = (WrkNet - WrkGross10ML) * MrateMillrt
          WrkTaxAmount = WrkTaxAmount + (WrkGross10ML * 0.01)
        End If
        WrkSTBenefit = 0
        WrkTownBenefit = .Item("twnbn")
        WrkFrozenCode = .Item("fccod")
        Select Case WrkFrozenCode
          Case "F" 'Frozen
            WrkTaxTotal = MyUtils.Round(.Item("ftax"), 2) - WrkTownBenefit
            WrkSTBenefit = MyUtils.Round(WrkTaxAmount - WrkTaxTotal - WrkTownBenefit, 2)
          Case "C" 'Heart/Circuit Breaker
            WrkSTBenefit = .Item("ftax")
            WrkTaxTotal = WrkTaxAmount - WrkSTBenefit - WrkTownBenefit
          Case Else 'Normal
            WrkTaxTotal = WrkTaxAmount - WrkTownBenefit
        End Select
        WrkDeferT = 0
        WrkDefer1st = 0
        WrkDefer2nd = 0
        WrkDefer3rd = 0
        WrkDefer4th = 0
        If MyDefer Then
          myTXDEFER.GetOneRecordP(WrkList, "R", WrkGLYear)
          If myTXDEFER.RecordNotFound Then
            myTXDEFER.GetOneRecordP(WrkList, "R", WrkGLYear - 1)
          End If
          If Not myTXDEFER.RecordNotFound Then
            WrkDeferT = myTXDEFER._DEFERRED
            With myTPaymnt
              .In_ListNo = WrkList
              .In_Type = WrkType
              .In_Year = WrkGLYear
              .In_Dst = WrkDist
              .In_Phs = WrkPhase
              .In_TaxT = WrkDeferT
              .CalcPaySplit()
              WrkDeferT = .Out_TaxT
              WrkDefer1st = .Out_Tax1
              WrkDefer2nd = .Out_Tax2
              WrkDefer3rd = .Out_Tax3
              WrkDefer4th = .Out_Tax4
              WrkTaxTotal = WrkTaxTotal - .Out_TaxT
            End With
          End If
        End If
        If MyFreeze Then
          myTXFREEZE.GetOneRecordP(WrkList, "R", WrkGLYear)
          If myTXFREEZE.RecordNotFound Then
            myTXFREEZE.GetOneRecordP(WrkList, "R", WrkGLYear - 1)
          End If
          If Not myTXFREEZE.RecordNotFound Then
            WrkTaxTotal = myTXFREEZE._FRZTAX
          End If
        End If
        With myTPaymnt
          .In_ListNo = WrkList
          .In_Type = WrkType
          .In_Year = WrkGLYear
          .In_Dst = WrkDist
          .In_Phs = WrkPhase
          .In_TaxT = WrkTaxTotal
          .CalcPaySplit()
          WrkTaxTotal = .Out_TaxT
          WrkTax1st = .Out_Tax1
          WrkTax2nd = .Out_Tax2
          WrkTax3rd = .Out_Tax3
          WrkTax4th = .Out_Tax4
          WrkWaivered = .Out_Waivered
        End With

        'Determine which totals to add to
        K = 0 'Regular Tax
        If .Item("fccod") = "C" Then 'Heart
          K = 1
        End If
        If .Item("fccod") = "F" Then 'Frozen
          K = 2
        End If
        If WrkTownBenefit > 0 And K = 0 Then 'Town Benefit
          K = 3
        End If
        If WrkWaivered > 0 Then 'Waivered
          K = 4
        End If
        If WrkTaxTotal = 0 And K = 0 And .Item("cat") <> "3" Then 'Net Zero Tax
          K = 5
        End If
        If WrkTaxTotal = 0 And K = 0 And .Item("cat") = "3" Then 'Tax Exempt
          K = 6
        End If
        WrkTotCount(K) = WrkTotCount(K) + 1
        WrkTotGross(K) = WrkTotGross(K) + WrkGross
        WrkTotExemption(K) = WrkTotExemption(K) + WrkExempt
        WrkTotNet(K) = WrkTotNet(K) + WrkNet
        If WrkWaivered > 0 Then
          WrkTotTax(K) = WrkTotTax(K) + WrkWaivered
        Else
          WrkTotTax(K) = WrkTotTax(K) + WrkTaxTotal
        End If
        WrkTot1st(K) = WrkTot1st(K) + WrkTax1st
        WrkTot2nd(K) = WrkTot2nd(K) + WrkTax2nd

        'Create Report
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = WrkList
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("gross") = WrkGross
        dr.Item("exemption") = WrkExempt
        dr.Item("net") = WrkNet
        dr.Item("taxtot") = WrkTaxTotal
        Select Case K
          Case 0
            dr.Item("group") = ""
          Case 1
            dr.Item("group") = "Heart"
          Case 2
            dr.Item("group") = "Freeze"
          Case 3
            dr.Item("group") = "Town Benefit"
          Case 4
            dr.Item("group") = "Waivered"
          Case 5
            dr.Item("group") = "Net Zero Tax"
          Case 6
            dr.Item("group") = "Tax Exempt"
        End Select
        ds.Tables(0).Rows.Add(dr)

        'Filter - Omit Zero Bills 
        If WrkTaxTotal = 0 Then
          GoTo WriteInvoice
        End If

        If MyFrmTX301B.RbPrtBill.Checked Or MyFrmTX301B.LblFilePath.Text <> String.Empty Then
          Select Case myTXFMBILL._SCAN
            Case "S"
              WrkScanLine = BuildScanLineSewer(WrkList, WrkGLYear, WrkType, WrkTaxTotal, WrkTax1st, WrkTax2nd, 0, 0, .Item("btc"))
            Case "W"
              WrkScanLine = BuildScanLineWebster(WrkList, WrkGLYear, WrkType, WrkTaxTotal, WrkTax1st, WrkTax2nd, 0, 0, .Item("btc"))
            Case Else
              WrkScanLine = BuildScanLine(WrkList, WrkGLYear, WrkType, WrkTaxTotal, WrkTax1st, .Item("btc"))
          End Select
        End If

        WrkCreateBill = False
        WrkIsEscrow = False
        'Filter - Check Non Escrow 
        If WrkNonEscrow Then
          If Trim(WrkBankCode) <> String.Empty Or Trim(.Item("bksv")) <> String.Empty Then
            'Create Escrow List
            dr = dsEscrow.Tables(0).NewRow
            dr.Item("listno") = WrkList
            dr.Item("addr1") = AddrLine(0)
            dr.Item("gross") = WrkGross
            dr.Item("exemption") = WrkExempt
            dr.Item("net") = WrkNet
            dr.Item("taxtot") = WrkTaxTotal
            If Trim(WrkBankCode) <> String.Empty Then
              dr.Item("group") = "CD:" & WrkBankCode
            Else
              dr.Item("group") = "SV:" & .Item("bksv")
            End If
            dsEscrow.Tables(0).Rows.Add(dr)
            WrkIsEscrow = True
            GoTo WriteExport
          End If
        End If

        'Filter - Check Non Escrow Plus Banks
        If WrkNonEscrowBank Then
          WrkEscrowPrint = LookupBanksEscrow(.Item("bkcd"))
          If Not WrkEscrowPrint Or Trim(.Item("bksv")) <> String.Empty Then
            'Create Escrow List
            dr = dsEscrow.Tables(0).NewRow
            dr.Item("listno") = WrkList
            dr.Item("addr1") = AddrLine(0)
            dr.Item("gross") = WrkGross
            dr.Item("exemption") = WrkExempt
            dr.Item("net") = WrkNet
            dr.Item("taxtot") = WrkTaxTotal
            If Not WrkEscrowPrint Then
              dr.Item("group") = "CD:" & WrkBankCode
            Else
              dr.Item("group") = "SV:" & .Item("bksv")
            End If
            dsEscrow.Tables(0).Rows.Add(dr)
            WrkIsEscrow = True
            GoTo WriteExport
          End If
        End If

        WrkCreateBill = True

        'Filter - Print No Bills
        If MyFrmTX301B.RbPrtNoBill.Checked Then
          GoTo WriteInvoice
        End If

        'Create Billing File
        drBill = dsBill.Tables(0).NewRow
        drBill.Item("BillType") = WrkBillType
        drBill.Item("listno") = WrkList
        drBill.Item("year") = WrkGLYear
        WrkOldOwner = ""
        If WrkNewOwner Then
          AddrLine = MyUtils.SetAddrLine(WrkNewName, "", .Item("add1"), .Item("add2"),
        .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
          WrkOldOwner = .Item("name")
        Else
          AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
        .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        End If
        drBill.Item("addr1") = AddrLine(0)
        drBill.Item("addr2") = AddrLine(1)
        drBill.Item("addr3") = AddrLine(2)
        drBill.Item("addr4") = AddrLine(3)
        drBill.Item("addr5") = AddrLine(4)
        drBill.Item("bank") = .Item("bkcd")
        drBill.Item("gross") = WrkGross
        drBill.Item("exemption") = WrkExempt
        drBill.Item("net") = WrkNet
        drBill.Item("taxtot") = WrkTaxTotal
        drBill.Item("tax1st") = WrkTax1st
        drBill.Item("tax2nd") = WrkTax2nd
        drBill.Item("stbenefit") = WrkSTBenefit
        drBill.Item("townbenefit") = WrkTownBenefit
        drBill.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
        drBill.Item("propdesc2") = WrkOldOwner
        If .Item("btc") = "BT" Then
          drBill.Item("backtax") = True
        Else
          drBill.Item("backtax") = False
        End If
        drBill.Item("barcode") = BuildBarCode(WrkList, WrkType, WrkGLYear)
        drBill.Item("postnet") = BuildPostNet(.Item("zip5"), .Item("zip4"))
        drBill.Item("scanline") = WrkScanLine
        drBill.Item("ccno") = .Item("ccno")
        drBill.Item("ccdesc") = GetCCDesc(.Item("ccno"))
        drBill.Item("ccdate") = MyUtils.GetDBDate(.Item("cdate"))
      End With
      dsBill.Tables(0).Rows.Add(drBill)

WriteExport:
      If WrkCreateBill And Not WrkIsEscrow Then
        WrkBillCount = WrkBillCount + 1
      End If
      If MyFrmTX301B.LblFilePath.Text <> String.Empty And WrkCreateBill Then
        If WrkCSV Then
          sw.WriteLine(DownloadCSV(I))
        Else
          sw.WriteLine(DownloadREBill(I))
        End If
      End If

WriteInvoice:
      If WrkUpdate Then
        WriteREInvoice(I)
      End If

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

    'Bill Totals
    For K = 0 To 6
      drTot = dsTot.Tables(0).NewRow
      Select Case K
        Case 0
          drTot.Item("description") = "Regular Tax"
        Case 1
          drTot.Item("description") = "Heart"
        Case 2
          drTot.Item("description") = "Freeze"
        Case 3
          drTot.Item("description") = "Town Benefit"
        Case 4
          drTot.Item("description") = "Waivered"
        Case 5
          drTot.Item("description") = "Net Zero Tax"
        Case 6
          drTot.Item("description") = "Tax Exempt"
      End Select
      drTot.Item("count") = WrkTotCount(K)
      drTot.Item("gross") = WrkTotGross(K)
      drTot.Item("exemption") = WrkTotExemption(K)
      drTot.Item("net") = WrkTotNet(K)
      drTot.Item("taxtot") = WrkTotTax(K)
      drTot.Item("tax1st") = WrkTot1st(K)
      drTot.Item("tax2nd") = WrkTot2nd(K)
      dsTot.Tables(0).Rows.Add(drTot)
    Next

    If MyFrmTX301B.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myTXREALCQ.CloseFile()

  End Sub
  Private Function DownloadREBill(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const CCText As String = "ADJUSTED TAX:"
    Const CTwld As String = "TAX WOULD BE:"
    Const CEtitl1 As String = "FROZEN TAX IS: "
    Const CEtitl2 As String = "C/E BENEFIT IS:"
    Const COwtext As String = "OWNER OF RECORD 10/01/"
    Dim WrkSewerUse As Decimal
    Dim WrkSewerUse1st As Decimal
    Dim WrkSewerUse2nd As Decimal
    Dim WrkInteger As Integer

    With DsTXREALC.Tables(0).Rows(I)
      sb = New StringBuilder
      If .Item("btc") = "BT" Then
        sb.Append(MyUtils.JustifyRight(MyBTCode, 2))
      Else
        sb.Append(MyUtils.JustifyRight(String.Empty, 2))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkList, 7))
        sb.Append(CComma)
        sb.Append(MyUtils.JustifyRight(WrkGLYear, 5))
      Else
        sb.Append(Format(WrkList, "000000"))
        sb.Append(CComma)
        sb.Append(Format(WrkGLYear, "0000"))
      End If
      sb.Append(CComma)
      sb.Append(WrkType)
      sb.Append(CComma)
      If WrkNewOwner Then
        sb.Append(MyUtils.JustifyLeft(WrkNewName, 35))
        sb.Append(CComma)
        sb.Append(MyUtils.JustifyLeft(String.Empty, 35))
        sb.Append(CComma)
      Else
        sb.Append(MyUtils.JustifyLeft(.Item("name"), 35))
        sb.Append(CComma)
        sb.Append(MyUtils.JustifyLeft(.Item("sname"), 35))
        sb.Append(CComma)
      End If
      sb.Append(MyUtils.JustifyLeft(.Item("add1"), 35))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("add2"), 35))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("city"), 25))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("state"), 2))
      sb.Append(CComma)
      sb.Append(Format(.Item("zip5"), "00000"))
      sb.Append(CComma)
      sb.Append(Format(.Item("zip4"), "0000"))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
      Else
        WrkInteger = WrkTaxTotal * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTax1st, "fixed"), 13))
      Else
        WrkInteger = WrkTax1st * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTax2nd, "fixed"), 13))
      Else
        WrkInteger = WrkTax2nd * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkGross, 10))
      Else
        sb.Append(Format(WrkGross, "000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkExempt, 10))
      Else
        sb.Append(Format(WrkExempt, "000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkNet, 10))
      Else
        sb.Append(Format(WrkNet, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyRight(.Item("loc#"), 7))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("loc"), 25))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("bkcd"), 2))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("map"), 17))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("vol"), 5))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("pge"), 5))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("dist"), 4))
      Else
        sb.Append(Format(.Item("dist"), "000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(MrateMillrt * 1000, "###.000"), 8))
      Else
        sb.Append(Format(MrateMillrt * 1000000, "000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(myTOWN._TOWNBR, 4))
      Else
        sb.Append(Format(myTOWN._TOWNBR, "000"))
      End If
      sb.Append(CComma)
      If WrkSTBenefit > 0 Then
        sb.Append(MyUtils.JustifyLeft(CTwld, 13))
        sb.Append(CComma)
        If WrkAlternative Then
          sb.Append(MyUtils.JustifyRight(Format(MyUtils.Round(WrkTaxTotal + WrkSTBenefit + WrkTownBenefit, 2), "fixed"), 11))
        Else
          WrkInteger = MyUtils.Round(WrkTaxTotal + WrkSTBenefit + WrkTownBenefit, 2) * 100
          sb.Append(Format(WrkInteger, "000000000"))
        End If
      Else
        sb.Append(MyUtils.JustifyLeft("", 13))
        sb.Append(CComma)
        If WrkAlternative Then
          sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 11))
        Else
          sb.Append("000000000")
        End If
      End If
      sb.Append(CComma)
      If WrkSTBenefit > 0 Then
        If .Item("fccod") = "F" Then
          sb.Append(MyUtils.JustifyLeft(CEtitl1, 15))
        Else
          sb.Append(MyUtils.JustifyLeft(CEtitl2, 15))
        End If
      Else
        sb.Append(MyUtils.JustifyLeft("", 15))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkSTBenefit, "fixed"), 11))
      Else
        WrkInteger = WrkSTBenefit * 100
        sb.Append(Format(WrkInteger, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("fccod"), 1))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("fcyr"), 5))
      Else
        sb.Append(Format(.Item("fcyr"), "0000"))
      End If
      sb.Append(CComma)
      If .Item("ccno") > 0 Then
        sb.Append(MyUtils.JustifyLeft(CCText, 22))
      Else
        sb.Append(MyUtils.JustifyLeft("", 22))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("ccno"), 6))
      Else
        sb.Append(Format(.Item("ccno"), "00000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("cdate"), 9))
      Else
        sb.Append(Format(.Item("cdate"), "00000000"))
      End If
      sb.Append(CComma)
      If WrkNewOwner Then
        sb.Append(MyUtils.JustifyLeft(COwtext & WrkGLYear, 26))
        sb.Append(CComma)
        sb.Append(MyUtils.JustifyLeft(.Item("name"), 35))
        sb.Append(CComma)
      Else
        sb.Append(MyUtils.JustifyLeft("", 26))
        sb.Append(CComma)
        sb.Append(MyUtils.JustifyLeft("", 35))
        sb.Append(CComma)
      End If
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 11))
      Else
        sb.Append("0000000000") 'Tax Base Before
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "###.000"), 8))
      Else
        sb.Append("000000") 'Mill Rate Before
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(WrkComment, 45)) 'User Message
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("smap"), 8))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("unit#"), 7)) 'Unit
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTownBenefit, "fixed"), 9))
      Else
        WrkInteger = WrkTownBenefit * 100
        sb.Append(Format(WrkInteger, "0000000"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(WrkScanLine, 70))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkSewerUse, "fixed"), 13))
      Else
        WrkInteger = WrkSewerUse * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkSewerUse1st, "fixed"), 13))
      Else
        WrkInteger = WrkSewerUse1st * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkSewerUse2nd, "fixed"), 13))
      Else
        WrkInteger = WrkSewerUse2nd * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
      Else
        sb.Append("00000000000") 'Sewer Use 3rd
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
      Else
        sb.Append("00000000000") 'Sewer Use 4th
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal + WrkSewerUse, "fixed"), 13))
      Else
        WrkInteger = (WrkTaxTotal + WrkSewerUse) * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTax1st + WrkSewerUse1st, "fixed"), 13))
      Else
        WrkInteger = (WrkTax1st + WrkSewerUse1st) * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTax2nd + WrkSewerUse2nd, "fixed"), 13))
      Else
        WrkInteger = (WrkTax2nd + WrkSewerUse2nd) * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTax3rd, "fixed"), 13))
      Else
        WrkInteger = WrkTax3rd * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkTax4th, "fixed"), 13))
      Else
        WrkInteger = WrkTax4th * 100
        sb.Append(Format(WrkInteger, "00000000000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
      Else
        sb.Append("00000000000") 'City Tax 
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "###.000"), 8))
      Else
        sb.Append("000000") 'City Mill Rate
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
      Else
        sb.Append("00000000000") 'Fire Dist Tax 
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "###.000"), 8))
      Else
        sb.Append("000000") 'Fire Dist Mill Rate
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 7)) 'Sewer Units
      Else
        sb.Append("00000") 'Sewer Units
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 9)) 'Sewer Units
      Else
        sb.Append("0000000") 'Sewer Rate
      End If
      If WrkBarcode Then
        sb.Append(CComma)
        sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
      End If
    End With

    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Const CCText As String = "ADJUSTED TAX:"
    Const CTwld As String = "TAX WOULD BE:"
    Const CEtitl1 As String = "FROZEN TAX IS: "
    Const CEtitl2 As String = "C/E BENEFIT IS:"
    Const COwtext As String = "OWNER OF RECORD 10/01/"
    Dim WrkSewerUse As Decimal
    Dim WrkSewerUse1st As Decimal
    Dim WrkSewerUse2nd As Decimal

    With DsTXREALC.Tables(0).Rows(I)
      sb = New StringBuilder
      sb.Append(CQuote)
      If .Item("btc") = "BT" Then
        sb.Append(MyBTCode)
      End If
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkList)
      sb.Append(CComma)
      sb.Append(WrkGLYear)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkType)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      If WrkNewOwner Then
        sb.Append(WrkNewName)
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(String.Empty)
        sb.Append(CQuote)
        sb.Append(CComma)
      Else
        sb.Append(.Item("name"))
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(.Item("sname"))
        sb.Append(CQuote)
        sb.Append(CComma)
      End If
      sb.Append(CQuote)
      sb.Append(.Item("add1"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("add2"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("city"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("state"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Format(.Item("zip5"), "00000"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Format(.Item("zip4"), "0000"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkTaxTotal, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax1st, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax2nd, "fixed"))
      sb.Append(CComma)
      sb.Append(WrkGross)
      sb.Append(CComma)
      sb.Append(WrkExempt)
      sb.Append(CComma)
      sb.Append(WrkNet)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("loc#"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("loc"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("bkcd"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("map"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("vol"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("pge"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("dist"))
      sb.Append(CComma)
      sb.Append(Format(MrateMillrt * 1000, "###.000"))
      sb.Append(CComma)
      sb.Append(myTOWN._TOWNBR)
      sb.Append(CComma)
      If WrkSTBenefit > 0 Then
        sb.Append(CQuote)
        sb.Append(CTwld)
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(Format(WrkTaxTotal + WrkSTBenefit + WrkTownBenefit, "fixed"))
      Else
        sb.Append(CQuote)
        sb.Append(MyUtils.JustifyLeft("", 13))
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(0)
      End If
      sb.Append(CComma)
      If WrkSTBenefit > 0 Then
        If .Item("fccod") = "F" Then
          sb.Append(CQuote)
          sb.Append(CEtitl1)
          sb.Append(CQuote)
        Else
          sb.Append(CQuote)
          sb.Append(CEtitl2)
          sb.Append(CQuote)
        End If
      Else
        sb.Append(CQuote)
        sb.Append(CQuote)
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkSTBenefit, "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("fccod"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("fcyr"))
      sb.Append(CComma)
      sb.Append(CQuote)
      If .Item("ccno") > 0 Then
        sb.Append(CCText)
      Else
        sb.Append("")
      End If
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("ccno"))
      sb.Append(CComma)
      If .Item("ccno") > 0 Then
        sb.Append(Format(MyUtils.GetDBDate(.Item("cdate")), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(CComma)
      If WrkNewOwner Then
        sb.Append(CQuote)
        sb.Append(COwtext & WrkGLYear)
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(.Item("name"))
        sb.Append(CQuote)
        sb.Append(CComma)
      Else
        sb.Append(CQuote)
        sb.Append(CQuote)
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(CQuote)
        sb.Append(CComma)
      End If
      sb.Append(CQuote)
      sb.Append(MyFrmTX301B.TxtStateMoney.Text)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(MyFrmTX301B.TxtStateMillRate.Text)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkComment) 'User Message
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("smap"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("unit#")) 'Unit
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkTownBenefit, "fixed"))
      sb.Append(CComma)
      sb.Append(WrkScanLine)
      sb.Append(CComma)
      sb.Append(Format(WrkSewerUse, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkSewerUse1st, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkSewerUse2nd, "fixed"))
      sb.Append(CComma)
      sb.Append(0) 'Sewer Use 3rd
      sb.Append(CComma)
      sb.Append(0) 'Sewer Use 4th
      sb.Append(CComma)
      sb.Append(Format(WrkTaxTotal + WrkSewerUse, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax1st + WrkSewerUse1st, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax2nd + WrkSewerUse2nd, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax3rd, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax4th, "fixed"))
      sb.Append(CComma)
      sb.Append("0.00") 'City Tax 
      sb.Append(CComma)
      sb.Append("0.000")  'City Mill Rate
      sb.Append(CComma)
      sb.Append("0.00") 'Fire Dist Tax 
      sb.Append(CComma)
      sb.Append("0.000")  'Fire Dist Mill Rate
      sb.Append(CComma)
      sb.Append(0) 'Sewer Units
      sb.Append(CComma)
      sb.Append(0) 'Sewer Rate
      sb.Append(CComma)
      sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
      sb.Append(CComma)
      sb.Append(Mid(WrkGLYear, 3, 2) & WrkType & WrkList)
      sb.Append(CComma)
      sb.Append(Format(WrkDeferT, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDefer1st, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDefer2nd, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDefer3rd, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDefer4th, "fixed"))
    End With
    Return sb.ToString
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("BACK TAX CODE")
    sb.Append(CComma)
    sb.Append("LIST NO")
    sb.Append(CComma)
    sb.Append("YEAR")
    sb.Append(CComma)
    sb.Append("TYPE")
    sb.Append(CComma)
    sb.Append("NAME")
    sb.Append(CComma)
    sb.Append("SECOND NAME")
    sb.Append(CComma)
    sb.Append("ADDRESS 1")
    sb.Append(CComma)
    sb.Append("ADDRESS 2")
    sb.Append(CComma)
    sb.Append("CITY")
    sb.Append(CComma)
    sb.Append("STATE")
    sb.Append(CComma)
    sb.Append("ZIP5")
    sb.Append(CComma)
    sb.Append("ZIP4")
    sb.Append(CComma)
    sb.Append("TOTAL TAX DUE")
    sb.Append(CComma)
    sb.Append("1ST PMT DUE")
    sb.Append(CComma)
    sb.Append("2ND PMT DUE")
    sb.Append(CComma)
    sb.Append("GROSS ASSESSMENT")
    sb.Append(CComma)
    sb.Append("TOTAL EXEMPTION")
    sb.Append(CComma)
    sb.Append("NET ASSESSMENT")
    sb.Append(CComma)
    sb.Append("LOCATION #")
    sb.Append(CComma)
    sb.Append("LOCATION NAME")
    sb.Append(CComma)
    sb.Append("BANK CODE")
    sb.Append(CComma)
    sb.Append("MAP/LOT")
    sb.Append(CComma)
    sb.Append("VOLUME")
    sb.Append(CComma)
    sb.Append("PAGE")
    sb.Append(CComma)
    sb.Append("DISTRICT")
    sb.Append(CComma)
    sb.Append("MILL RATE")
    sb.Append(CComma)
    sb.Append("TOWN NO.")
    sb.Append(CComma)
    sb.Append("TAX WOULD BE TEXT")
    sb.Append(CComma)
    sb.Append("ELDERLY TAX AMOUNT")
    sb.Append(CComma)
    sb.Append("ELDERLY TITLE")
    sb.Append(CComma)
    sb.Append("ELDERLY TAX AMOUNT")
    sb.Append(CComma)
    sb.Append("ELDERLY CODE F/C")
    sb.Append(CComma)
    sb.Append("ELDERLY YEAR")
    sb.Append(CComma)
    sb.Append("C OF C TEXT")
    sb.Append(CComma)
    sb.Append("C OF C NO")
    sb.Append(CComma)
    sb.Append("C OF C DATE")
    sb.Append(CComma)
    sb.Append("OWNER TEXT")
    sb.Append(CComma)
    sb.Append("OWNER NAME")
    sb.Append(CComma)
    sb.Append("TAX BASE BEFORE")
    sb.Append(CComma)
    sb.Append("MILL RATE BEFORE")
    sb.Append(CComma)
    sb.Append("USER MESSAGE")
    sb.Append(CComma)
    sb.Append("SURVEY MAP")
    sb.Append(CComma)
    sb.Append("UNIT NO")
    sb.Append(CComma)
    sb.Append("ELDERLY TOWN BENEFIT")
    sb.Append(CComma)
    sb.Append("OCR SCAN LINE")
    sb.Append(CComma)
    sb.Append("SEWER DUE")
    sb.Append(CComma)
    sb.Append("SEWER DUE 1ST")
    sb.Append(CComma)
    sb.Append("SEWER DUE 2ND")
    sb.Append(CComma)
    sb.Append("SEWER DUE 3RD")
    sb.Append(CComma)
    sb.Append("SEWER DUE 4TH")
    sb.Append(CComma)
    sb.Append("TOTAL DUE")
    sb.Append(CComma)
    sb.Append("TOTAL DUE 1ST")
    sb.Append(CComma)
    sb.Append("TOTAL DUE 2ND")
    sb.Append(CComma)
    sb.Append("TAX DUE 3RD")
    sb.Append(CComma)
    sb.Append("TAX DUE 4TH")
    sb.Append(CComma)
    sb.Append("CITY TAX DUE")
    sb.Append(CComma)
    sb.Append("CITY MILL RATE")
    sb.Append(CComma)
    sb.Append("FIRE TAX DUE")
    sb.Append(CComma)
    sb.Append("FIRE MILL RATE")
    sb.Append(CComma)
    sb.Append("SEWER UNITS")
    sb.Append(CComma)
    sb.Append("SEWER RATE")
    sb.Append(CComma)
    sb.Append("BAR CODE")
    sb.Append(CComma)
    sb.Append("ACCOUNT ID")
    sb.Append(CComma)
    sb.Append("TOTAL DEFER")
    sb.Append(CComma)
    sb.Append("DEFER 1ST")
    sb.Append(CComma)
    sb.Append("DEFER 2ND")
    sb.Append(CComma)
    sb.Append("DEFER 3RD")
    sb.Append(CComma)
    sb.Append("DEFER 4TH")
    Return sb.ToString
  End Function
  Private Sub WriteREInvoice(ByVal I As Integer)
    With DsTXREALC.Tables(0).Rows(I)
      myTXINV.GetOneRecordP(WrkList, WrkGLYear, WrkType)
      If .Item("btc") = "BT" Then
        myTXINV._ICODE = "B"
      Else
        myTXINV._ICODE = ""
      End If
      If WrkDeferT > 0 Then
        myTXINV._ICODE = "D"
      End If
      myTXINV._LISTNo = WrkList
      myTXINV._YEAR = WrkGLYear
      myTXINV._TYPE = WrkType
      myTXINV._NAME = .Item("name")
      myTXINV._SNAME = .Item("sname")
      myTXINV._ADD1 = .Item("add1")
      myTXINV._ADD2 = .Item("add2")
      myTXINV._CITY = .Item("city")
      myTXINV._STATE = .Item("state")
      myTXINV._ZIP5 = Format(.Item("zip5"), "00000")
      myTXINV._ZIP4 = Format(.Item("zip4"), "0000")
      If WrkUpdateDist Then
        myTXINV._DIST = .Item("dist")
      Else
        myTXINV._DIST = 0
      End If
      myTXINV._PDST = .Item("pdst")
      myTXINV._TAXT = WrkTaxTotal + WrkDeferT
      myTXINV._TAX1 = WrkTax1st + WrkDefer1st
      myTXINV._TAX2 = WrkTax2nd + WrkDefer2nd
      myTXINV._TX3RD = WrkTax3rd + WrkDefer3rd
      myTXINV._TX4TH = WrkTax4th + WrkDefer4th
      myTXINV._BALD = WrkTaxTotal
      myTXINV._DEFERT = WrkDeferT
      myTXINV._DEFER1 = WrkDefer1st
      myTXINV._DEFER2 = WrkDefer2nd
      myTXINV._DEFER3 = WrkDefer3rd
      myTXINV._DEFER4 = WrkDefer4th
      myTXINV._GROSS = WrkGross
      myTXINV._TOTEXP = WrkExempt
      myTXINV._NETASS = WrkNet
      myTXINV._LOCNo = MyUtils.JustifyRight(.Item("loc#"), 7)
      myTXINV._LOC = .Item("loc")
      myTXINV._BKCD = .Item("bkcd")
      myTXINV._MAP = .Item("map")
      myTXINV._VOL = .Item("vol")
      myTXINV._BKSR = .Item("bksv")
      myTXINV._MAP = .Item("map")
      myTXINV._VOL = .Item("vol")
      myTXINV._IPAGE = .Item("pge")
      myTXINV._FRCD = .Item("fccod")
      myTXINV._FRYR = .Item("fcyr")
      Select Case WrkFrozenCode
        Case "C"
          myTXINV._FTAX = WrkSTBenefit
        Case "F"
          myTXINV._FTAX = WrkTaxTotal
        Case Else
          myTXINV._FTAX = 0
      End Select
      myTXINV._TWNBN = WrkTownBenefit
      myTXINV._CPERC = .Item("cperc")
      myTXINV._CMAX = .Item("cmax")
      myTXINV._CMIN = .Item("cmin")
      myTXINV._IPPCD1 = WrkCode(0)
      myTXINV._IPPCD2 = WrkCode(1)
      myTXINV._IPPCD3 = WrkCode(2)
      myTXINV._IPPCD4 = WrkCode(3)
      myTXINV._IPPCD5 = WrkCode(4)
      myTXINV._IPPCD6 = WrkCode(5)
      myTXINV._IPPCD7 = WrkCode(6)
      If Not WrkCC Then
        myTXINV._ETCA = ""
        myTXINV._OAS1 = WrkAss(0)
        myTXINV._OAS2 = WrkAss(1)
        myTXINV._OAS3 = WrkAss(2)
        myTXINV._OAS4 = WrkAss(3)
        myTXINV._OAS5 = WrkAss(4)
        myTXINV._OAS6 = WrkAss(5)
        myTXINV._OAS7 = WrkAss(6)
        myTXINV._EXCD1 = WrkExcd(0)
        myTXINV._EXCD2 = WrkExcd(1)
        myTXINV._EXCD3 = WrkExcd(2)
        myTXINV._EXCD4 = WrkExcd(3)
        myTXINV._EXCD5 = WrkExcd(4)
        myTXINV._EXCD6 = WrkExcd(5)
        myTXINV._EXCD7 = WrkExcd(6)
        myTXINV._EXAM1 = WrkExam(0)
        myTXINV._EXAM2 = WrkExam(1)
        myTXINV._EXAM3 = WrkExam(2)
        myTXINV._EXAM4 = WrkExam(3)
        myTXINV._EXAM5 = WrkExam(4)
        myTXINV._EXAM6 = WrkExam(5)
        myTXINV._EXAM7 = WrkExam(6)
      Else
        myTXINV._ETCA = "Y"
        myTXINV._OAS1 = WrkCCAss(0)
        myTXINV._OAS2 = WrkCCAss(1)
        myTXINV._OAS3 = WrkCCAss(2)
        myTXINV._OAS4 = WrkCCAss(3)
        myTXINV._OAS5 = WrkCCAss(4)
        myTXINV._OAS6 = WrkCCAss(5)
        myTXINV._OAS7 = WrkCCAss(6)
        myTXINV._EXCD1 = WrkCCExcd(0)
        myTXINV._EXCD2 = WrkCCExcd(1)
        myTXINV._EXCD3 = WrkCCExcd(2)
        myTXINV._EXCD4 = WrkCCExcd(3)
        myTXINV._EXCD5 = WrkCCExcd(4)
        myTXINV._EXCD6 = WrkCCExcd(5)
        myTXINV._EXCD7 = WrkCCExcd(6)
        myTXINV._EXAM1 = WrkCCExam(0)
        myTXINV._EXAM2 = WrkCCExam(1)
        myTXINV._EXAM3 = WrkCCExam(2)
        myTXINV._EXAM4 = WrkCCExam(3)
        myTXINV._EXAM5 = WrkCCExam(4)
        myTXINV._EXAM6 = WrkCCExam(5)
        myTXINV._EXAM7 = WrkCCExam(6)
      End If
      myTXINV._UNIT1 = .Item("unit1")
      myTXINV._UNIT2 = .Item("unit2")
      myTXINV._UNIT3 = .Item("unit3")
      myTXINV._UNIT4 = .Item("unit4")
      myTXINV._UNIT5 = .Item("unit5")
      myTXINV._UNIT6 = .Item("unit6")
      myTXINV._UNIT7 = .Item("unit7")
      myTXINV._LETT = .Item("lett")
    End With
    myTXINV.AddOneRecordP()
    If myTXINV.ErrMsg <> "" Then
      WriteErrorLog(myTXINV.ErrMsg)
      Exit Sub
    End If
  End Sub
  Private Sub BufferBanksEscrow()
    Dim I As Integer
    Dim J As Integer

    Dim myTXBANKS As TXBANKS.MyData
    Dim dsTXBANKS As DataSet = New DataSet

    myTXBANKS = New TXBANKS.MyData(myDBConnect)

    J = -1
    dsTXBANKS = myTXBANKS.GetAllData
    For I = 0 To dsTXBANKS.Tables(0).Rows.Count - 1
      With dsTXBANKS.Tables(0).Rows(I)
        J = J + 1
        WrkBanksCode(J) = .Item("bkcode")
        If .Item("bkprnt") = "Y" Then
          WrkBanksPrnt(J) = True
        End If
      End With
    Next

  End Sub
  Private Function LookupBanksEscrow(ByVal Code As String) As Boolean
    Dim I As Integer

    If Trim(Code) = "" Then Return True

    For I = 0 To WrkBanksCode.GetUpperBound(0)
      If Trim(WrkBanksCode(I)) = "" Then
        Return False
      End If
      If Trim(Code) = Trim(WrkBanksCode(I)) Then
        Return WrkBanksPrnt(I)
      End If
    Next

  End Function
  Public Function GetCCDesc(ByVal CCNo As Integer) As String
    Dim WrkCCDesc As String

    WrkCCDesc = ""
    If CCNo = 0 Then Return ""

    myTXCOEB.GetOneRecordP(CCNo)
    If myTXCOEB.RecordNotFound Then Return ""

    With myTXCOEB
      WrkCCDesc = Trim(._CDESC)
    End With

    Return WrkCCDesc
  End Function

End Module
