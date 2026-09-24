Imports System.io
Imports System.Text
Module PrintReport

  Public MyReportCancel As Boolean
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVDTL As TXINVDTL.MyData
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTMETER As UTMETER.MyData
  Dim myUTMUSER As UTMUSER.MyData
  Dim myUTRATEMT As UTRATEMT.MyData
  Dim myUTRATEUS As UTRATEUS.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTPaymnt As TPAYMNT.MyData
  Dim myUTBLHS As UTBLHS.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXINVLK As TXINVLK.MyData
  Dim myCashInt As CASHINT.MyData
  Dim myUTCNTL As UTCNTL.MyData
  Dim myUTCOEAQ As UTCOEAQ.MyData
  Dim myUTCOEA As UTCOEA.MyData
  Dim myTXREALC As TXREALC.MyData

  Dim ds As DataSet = New DataSet
  Dim dsBill As DataSet = New DataSet
  Dim DsUTCUSTMT As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drBill As Data.DataRow

  'TXPROF
  Dim ProfPerd As Integer
  Dim ProfTxDt(3) As Date
  Dim ProfGrDt(3) As Date
  Dim ProfWaiver As Decimal
  Dim ProfPrint As Decimal
  Dim ProfMini As Decimal
  Dim ProfPosted As String
  'Screen fields
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkUpdate As Boolean
  Dim WrkUpdateDist As Boolean
  Dim WrkSortBy As String
  Dim WrkInterestDate As Date
  Dim WrkMeterReadingDate As Date
  Dim WrkReport As Boolean
  Dim WrkAddress As Boolean
  Dim WrkBills As Boolean
  Dim WrkServiceFrom As Date
  Dim WrkServiceTo As Date
  Dim WrkAddlBillDesc As String
  Dim WrkComment1 As String
  Dim WrkComment2 As String
  'Common Work fields
  Dim WrkListNo As Integer
  Dim WrkTaxTypeA As String
  Dim WrkUBTypeA As String
  Dim WrkTaxTot As Decimal
  Dim WrkTax1stA As Decimal
  Dim WrkTax2ndA As Decimal
  Dim WrkTax3rdA As Decimal
  Dim WrkTax4thA As Decimal
  Dim WrkBaseRateA As Decimal
  Dim WrkMeterSizeA As String
  Dim WrkTaxTypeB As String
  Dim WrkUBTypeB As String
  Dim WrkTax1stB As Decimal
  Dim WrkTax2ndB As Decimal
  Dim WrkTax3rdB As Decimal
  Dim WrkTax4thB As Decimal
  Dim WrkBaseRateB As Decimal
  Dim WrkMeterSizeB As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCodeA As String
  Dim WrkCodeDescA As String
  Dim WrkCodeB As String
  Dim WrkCodeDescB As String
  Dim WrkRateDesc1A As String
  Dim WrkRateDesc1B As String
  Dim WrkRateDesc2A As String
  Dim WrkRateDesc2B As String
  Dim WrkPeriod As Integer
  Dim WrkPeriodDesc As String
  Dim WrkBillingPeriodDates As String
  Dim WrkScanLine As String
  Dim WrkActualCurr As Integer
  Dim WrkActualPrev As Integer
  Dim WrkReadingCurr As Integer
  Dim WrkReadingPrev As Integer
  Dim WrkReading2 As Integer
  Dim WrkReading3 As Integer
  Dim WrkWarning As Boolean
  Dim WrkCancel As Boolean
  Dim WrkBillAmtA As Decimal
  Dim WrkBillAmtB As Decimal
  Dim WrkBillAmtC As Decimal
  'Metered work fields
  Dim WrkTotalUse As Integer
  Dim WrkActualUse As Integer
  'Deliquent work fields
  Dim WrkDelqInterestA As Decimal
  Dim WrkDelqFeeA As Decimal
  Dim WrkDelqLienA As Decimal
  Dim WrkDelqPrincipalA As Decimal
  Dim WrkBackTaxAmtA As Decimal
  Dim WrkDelqInterestB As Decimal
  Dim WrkDelqFeeB As Decimal
  Dim WrkDelqLienB As Decimal
  Dim WrkDelqPrincipalB As Decimal
  Dim WrkBackTaxAmtB As Decimal
  'Misc fields
  Dim WrkBankcd As String
  Dim WrkMeterUserChg1 As Decimal
  Dim WrkMeterUserChg2 As Decimal
  Dim WrkMeterUserChg3 As Decimal
  'Metered Calcs
  Dim MyUBCalcReading As UBCalcReading.MyData
  Dim MyUBCalcBillMeter As UBCalcBill.MeteredUse
  Dim MyUBCalcBillM As UBCalcBill.BillMetered
  'Usage Calcs
  Dim MyUBCalcBillU As UBCalcBill.BillUsage

  Public Sub PrtReport()
    Dim WrkPhaseA As String
    Dim Answer As Integer

    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTMETER = New UTMETER.MyData(myDBConnect)
    myUTMUSER = New UTMUSER.MyData(myDBConnect)
    myUTRATEMT = New UTRATEMT.MyData(myDBConnect)
    myUTRATEUS = New UTRATEUS.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)
    myUTBLHS = New UTBLHS.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINVLK = New TXINVLK.MyData(myDBConnect)
    myCashInt = New CASHINT.MyData(myDBConnect)
    myUTCNTL = New UTCNTL.MyData(myDBConnect)
    myUTCOEAQ = New UTCOEAQ.MyData(myDBConnect)
    myUTCOEA = New UTCOEA.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    MyUBCalcReading = New UBCalcReading.MyData(myDBConnect)
    MyUBCalcBillMeter = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBillM = New UBCalcBill.BillMetered(myDBConnect)
    MyUBCalcBillU = New UBCalcBill.BillUsage(myDBConnect)

    With MyFrmUB409B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkDist = 0
      WrkPhase = 0
      WrkUBTypeA = Mid(.TxtUBTypes.Text, 1, 1)
      WrkUBTypeB = Mid(.TxtUBTypes.Text, 2, 1)
      WrkUBTypeA = Mid(.TxtUBTypes.Text, 1, 1)
      WrkUBTypeB = Mid(.TxtUBTypes.Text, 2, 1)
      If myTOWN._TOWNBR = 219 And Len(Trim(.TxtUBTypes.Text)) = 1 Then 'Kensington (Fireline)
        WrkUBTypeA = ""
        WrkUBTypeB = Mid(.TxtUBTypes.Text, 1, 1)
      End If
      WrkDistAll = True
      WrkInterestDate = .DtPckInterest.Value
      WrkMeterReadingDate = .DtPckRead.Value
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortLocation.Checked Then
        WrkSortBy = "Location"
      End If
      WrkReport = .ChkReport.Checked
      WrkAddress = .ChkAddress.Checked
      WrkBills = .ChkBills.Checked
      WrkUpdate = .ChkUpdate.Checked
      WrkUpdateDist = .ChkUpdateDist.Checked
      If .DtPckServiceFrom.Checked Then
        WrkServiceFrom = .DtPckServiceFrom.Value
      End If
      If .DtPckServiceTo.Checked Then
        WrkServiceTo = .DtPckServiceTo.Value
      End If
      WrkAddlBillDesc = .TxtAddlBillDesc.Text
      WrkComment1 = .TxtComment1.Text
      WrkComment2 = .TxtComment2.Text
      If MyFrmUB409B.RbPerJan.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "January"
      End If
      If MyFrmUB409B.RbPerFeb.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "February"
      End If
      If MyFrmUB409B.RbPerMar.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "March"
      End If
      If MyFrmUB409B.RbPerApr.Checked Then
        WrkPeriod = 2
        WrkPeriodDesc = "April"
      End If
      If MyFrmUB409B.RbPerMay.Checked Then
        WrkPeriod = 2
        WrkPeriodDesc = "May"
      End If
      If MyFrmUB409B.RbPerApr.Checked Then
        WrkPeriod = 2
        WrkPeriodDesc = "June"
        WrkDist = 6
      End If
      If MyFrmUB409B.RbPerJul.Checked Then
        WrkPeriod = 3
        WrkPeriodDesc = "July"
      End If
      If MyFrmUB409B.RbPerAug.Checked Then
        WrkPeriod = 3
        WrkPeriodDesc = "August"
      End If
      If MyFrmUB409B.RbPerSep.Checked Then
        WrkPeriod = 3
        WrkPeriodDesc = "September"
      End If
      If MyFrmUB409B.RbPerOct.Checked Then
        WrkPeriod = 4
        WrkPeriodDesc = "Octomber"
      End If
      If MyFrmUB409B.RbPerNov.Checked Then
        WrkPeriod = 4
        WrkPeriodDesc = "November"
      End If
      If MyFrmUB409B.RbPerDec.Checked Then
        WrkPeriod = 4
        WrkPeriodDesc = "December"
      End If
    End With

    If WrkUpdate Then
      Answer = MsgBox("Click OK to continue with posting or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirm POSTING Run")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
    End If

    WrkTaxTypeA = GetUTTYPETaxType(WrkUBTypeA)
    WrkTaxTypeB = GetUTTYPETaxType(WrkUBTypeB)
    WrkBillDesc = GetUTTypeDesc(WrkUBTypeA)
    WrkFamily = GetUTTYPEFamily(WrkUBTypeB)
    If WrkFamily = "" Then
      WrkFamily = GetUTTYPEFamily(WrkUBTypeA)
    End If
    If WrkUBTypeA <> "" Then
      GetTXFMBILL(WrkTaxTypeA)
    Else
      GetTXFMBILL(WrkTaxTypeB)
    End If
    If Trim(myTXFMBILL._LINE1) = String.Empty Then
      GetTXFMBILL(" ")
    End If
    If WrkPhase = 0 Then
      WrkPhaseA = ""
    Else
      WrkPhaseA = WrkPhase
    End If
    If WrkUBTypeA <> "" Then
      myTXPROF.GetOneRecordP(WrkTaxTypeA, WrkYear, WrkPhaseA, WrkDist)
    Else
      myTXPROF.GetOneRecordP(WrkTaxTypeB, WrkYear, WrkPhaseA, WrkDist)
    End If
    If Not myTXPROF.RecordNotFound Then
      With myTXPROF
        ProfPerd = ._PRPERD
        ProfTxDt(0) = MyUtils.GetDBDateMDY(._PRDUE1)
        ProfTxDt(1) = MyUtils.GetDBDateMDY(._PRDUE2)
        ProfTxDt(2) = MyUtils.GetDBDateMDY(._PRDUE3)
        ProfTxDt(3) = MyUtils.GetDBDateMDY(._PRDUE4)
        ProfGrDt(0) = MyUtils.GetDBDateMDY(._PRGRD1)
        ProfGrDt(1) = MyUtils.GetDBDateMDY(._PRGRD2)
        ProfGrDt(2) = MyUtils.GetDBDateMDY(._PRGRD3)
        ProfGrDt(3) = MyUtils.GetDBDateMDY(._PRGRD4)
        ProfWaiver = ._PRWAV
        ProfPrint = ._PRINT
        ProfMini = ._PRMINI
        ProfPosted = ._POSTED
      End With
    Else
      MsgBox("Type: " & WrkTaxTypeA & vbCrLf & "Year: " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
      Exit Sub
    End If

    If ProfPosted <> "" Then

      Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills have already been Posted")
      If Answer = MsgBoxResult.Cancel Then Exit Sub

    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDSBill()
    Else
      ds.Clear()
      dsBill.Clear()
    End If

    GetDetail()
    If WrkUpdate And WrkPeriod > 1 Then
      UpdateUTCOEA(WrkTaxTypeA)
      UpdateUTCOEA(WrkTaxTypeB)
    End If

Done:
    myUTMUSER.GetOneRecordP(1)
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = dsBill
      If WrkUBTypeA <> "" Then
        .WrkUBType = WrkUBTypeA
      Else
        .WrkUBType = WrkUBTypeB
      End If
      .WrkInterestRate = ProfPrint * 100
      .WrkMinInterest = ProfMini
      .WrkComment1 = WrkComment1
      .WrkComment2 = WrkComment2
      .WrkAddlBillDesc = WrkAddlBillDesc
      .WrkDueDate1 = Format(ProfTxDt(0), "M/d/yyyy")
      .WrkGraceDate1 = Format(ProfGrDt(0), "M/d/yyyy")
      .WrkProfPerd = ProfPerd
      .WrkPeriod = WrkPeriod
      .WrkPeriodDesc = WrkPeriodDesc
      .WrkServiceFrom = Format(WrkServiceFrom, "M/d/yyyy")
      .WrkServiceTo = Format(WrkServiceTo, "M/d/yyyy")
      .WrkUser1Desc = Trim(myUTMUSER._USER1)
      .WrkUser2Desc = Trim(myUTMUSER._USER2)
      .WrkUser3Desc = Trim(myUTMUSER._USER3)
      .Show()
    End With

    If Not WrkUpdate Or WrkCancel Then Exit Sub
    'reset screen back to defaults when posting
    With MyFrmUB409B
      .LblFilePath.Text = ""
      .TxtUBTypes.Text = ""
      .TxtYear.Text = ""
      .ChkAddress.Checked = False
      .ChkBills.Checked = False
      .ChkUpdate.Checked = False
      .ChkUpdateDist.Checked = False
    End With
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("RateCode", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropLoc", Type.GetType("System.String"))
      .Columns.Add("Units", Type.GetType("System.Decimal"))
      .Columns.Add("Usage", Type.GetType("System.Int32"))
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmta", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmtb", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmtc", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDSBill()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Units", Type.GetType("System.Decimal"))
      .Columns.Add("EDUs", Type.GetType("System.Int32"))
      .Columns.Add("CurrRead", Type.GetType("System.Int32"))
      .Columns.Add("PrevRead", Type.GetType("System.Int32"))
      .Columns.Add("Usage", Type.GetType("System.Int32"))
      .Columns.Add("RateCodeA", Type.GetType("System.String"))
      .Columns.Add("RateCodeA2", Type.GetType("System.String"))
      .Columns.Add("RateCodeA3", Type.GetType("System.String"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmtA", Type.GetType("System.Decimal"))
      .Columns.Add("BalanceA", Type.GetType("System.Decimal"))
      .Columns.Add("InterestA", Type.GetType("System.Decimal"))
      .Columns.Add("LienA", Type.GetType("System.Decimal"))
      .Columns.Add("RateCodeB", Type.GetType("System.String"))
      .Columns.Add("RateCodeB2", Type.GetType("System.String"))
      .Columns.Add("RateCodeB3", Type.GetType("System.String"))
      .Columns.Add("BillAmtB", Type.GetType("System.Decimal"))
      .Columns.Add("BalanceB", Type.GetType("System.Decimal"))
      .Columns.Add("InterestB", Type.GetType("System.Decimal"))
      .Columns.Add("LienB", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("MapBlock", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("Barcode", Type.GetType("System.String"))
      .Columns.Add("AcctIDA", Type.GetType("System.String"))
      .Columns.Add("AcctIDB", Type.GetType("System.String"))
      .Columns.Add("Route", Type.GetType("System.String"))
      .Columns.Add("MeterNo", Type.GetType("System.String"))
    End With
    dsBill.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""
    If Not WrkDistAll Then
      WrkQry = "cudst=" & WrkDist
    End If
    If WrkPhase > 0 Then
      If WrkQry = String.Empty Then
        WrkQry = "cuphas = " & WrkPhase
      Else
        WrkQry = WrkQry & WrkAnd & "cuphas = " & WrkPhase
      End If
    End If

    WrkSort = ""
    Counter = 0
    WrkWarning = False
    WrkCancel = False
    Select Case WrkSortBy
      Case "List"
        WrkSort = "CUACCT"
      Case "Name"
        WrkSort = "CUNAM1"
      Case "Location"
        WrkSort = "CULOC, CULOC#"
    End Select

    If MyFrmUB409B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmUB409B.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

    'WrkQry = "CUACCT=4" 'Testing only
    myUTCUSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCUSTQ.ReadQry()
    If Not myUTCUSTQ.IsEOF Then
      With myUTCUSTQ
        Counter = Counter + 1
        WrkListNo = ._CUACCT
        WrkCodeA = GetRateCode(WrkUBTypeA)
        WrkCodeB = GetRateCode(WrkUBTypeB)
        If WrkCodeA = "" And WrkCodeB = "" Then GoTo NextRec
        WrkScanLine = ""
        WrkScanLine = String.Empty
        ClearAmounts()
        If WrkTaxTypeA <> "" Then
          CalcBillAmounts("A", WrkTaxTypeA)
        End If
        If WrkTaxTypeB <> "" Then
          CalcBillAmounts("B", WrkTaxTypeB)
        End If
        'Filter - Omit Zero Bills 
        If WrkBillAmtA <= 0 And WrkBillAmtB <= 0 Then
          GoTo NextRec
        End If
        'Worthington: Take User charge 1 from Bill B and put into Bill C (seperate user charge 1)
        If myTOWN._TOWNBR = 220 Then
          WrkBillAmtB = WrkBillAmtB - WrkMeterUserChg1
          WrkBillAmtC = WrkMeterUserChg1
        End If

        If Trim(._CUMAD1) <> "" Then
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUMAD1, ._CUMAD2, ._CUMCTY, ._CUMST, 0, 0, ._CUMZIP)
        Else
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
        End If

        WrkTaxTot = WrkBillAmtA + WrkDelqPrincipalA + WrkDelqInterestA + WrkDelqLienA + WrkDelqFeeA
        WrkTaxTot = WrkTaxTot + WrkBillAmtB + WrkDelqPrincipalB + WrkDelqInterestB + WrkDelqLienB + WrkDelqFeeB + WrkBillAmtC
        If WrkScanLine = String.Empty Then
          If myTXFMBILL._SCAN = "W" Then
            WrkScanLine = BuildScanLineWebster(WrkListNo, WrkYear, "", WrkBillAmtA + WrkBillAmtB, WrkTax1stA + WrkTax1stB,
             WrkTax2ndA + WrkTax2ndB, "")
          Else
            WrkScanLine = BuildScanLine(WrkListNo, WrkYear, "", WrkBillAmtA + WrkBillAmtB, WrkTax1stA + WrkTax1stB,
             WrkTax2ndA + WrkTax2ndB)
          End If
        End If
        WrkBackTaxAmtA = WrkDelqPrincipalA + WrkDelqLienA + WrkDelqFeeA + WrkDelqInterestA
        WrkBankcd = ""
        If MyUBBNK Then
          myTXREALC.GetOneRecordP(._CUACCT)
          If Not myTXREALC.RecordNotFound Then
            WrkBankcd = Trim(myTXREALC._BKCD)
          End If
        End If

        'Filter - Print No Bills
        If Not MyFrmUB409B.ChkBills.Checked Then
          GoTo Report
        End If

        'Create Bills
        drBill = dsBill.Tables(0).NewRow
        drBill.Item("BillType") = WrkBillDesc & " BILL"
        drBill.Item("listno") = WrkListNo
        drBill.Item("year") = WrkYear
        drBill.Item("addr1") = AddrLine(0)
        drBill.Item("addr2") = AddrLine(1)
        drBill.Item("addr3") = AddrLine(2)
        drBill.Item("addr4") = AddrLine(3)
        drBill.Item("addr5") = AddrLine(4)
        drBill.Item("tax1st") = WrkTax1stA + WrkTax1stB
        drBill.Item("tax2nd") = WrkTax2ndA + WrkTax2ndB
        Select Case WrkFamily
          Case "M"
            drBill.Item("currread") = WrkActualCurr
            drBill.Item("prevread") = WrkActualPrev
            drBill.Item("usage") = WrkTotalUse
            drBill.Item("units") = ._CUUNIT
            If MyEDU1 Then
              drBill.Item("edus") = 1
            Else
              drBill.Item("edus") = ._CUEDU
            End If
          Case "U"
            drBill.Item("units") = ._CUUNIT
            If MyEDU1 Then
              drBill.Item("edus") = 1
            Else
              drBill.Item("edus") = ._CUEDU
            End If
        End Select
        drBill.Item("billamta") = WrkBillAmtA
        drBill.Item("balancea") = WrkDelqPrincipalA
        drBill.Item("interesta") = WrkDelqInterestA
        drBill.Item("liena") = WrkDelqLienA + WrkDelqFeeA
        If myTOWN._TOWNBR = 219 Then
          If WrkBillAmtA > 0 Then
            drBill.Item("ratecodea") = WrkCodeA & " SEWER"
            drBill.Item("ratecodea2") = "1.00 Minimum at $" & Format(WrkBaseRateA, "Fixed")
            If WrkTotalUse > 5 Then
              myUTRATEMT.GetOneRecordP(WrkUBTypeA, WrkCodeA, 99999999)
              drBill.Item("ratecodea3") = (WrkTotalUse - 5) & " /100 CU FT at $" & Format(myUTRATEMT._RMRATE, "Fixed")
            Else
              drBill.Item("ratecodea3") = ""
            End If
          End If
          If WrkBillAmtB > 0 Then
            If WrkPeriod = 0 Then
              drBill.Item("ratecodeb") = WrkCodeB & " FIRELINE"
              drBill.Item("ratecodeb2") = ._CUUNIT & " Fireline at $" & Format(WrkBaseRateB, "Fixed")
              drBill.Item("ratecodeb3") = ""
            Else
              drBill.Item("ratecodeb") = WrkCodeB & " WATER"
              drBill.Item("ratecodeb2") = "1.00 Minimum at $" & Format(WrkBaseRateB, "Fixed")
              If WrkTotalUse > 5 Then
                myUTRATEMT.GetOneRecordP(WrkUBTypeB, WrkCodeB, 99999999)
                drBill.Item("ratecodeb3") = (WrkTotalUse - 5) & " /100 CU FT at $" & Format(myUTRATEMT._RMRATE, "Fixed")
              Else
                drBill.Item("ratecodeb3") = ""
              End If
            End If
          End If
        End If
        drBill.Item("billamtb") = WrkBillAmtB
        drBill.Item("balanceb") = WrkDelqPrincipalB
        drBill.Item("interestb") = WrkDelqInterestB
        drBill.Item("lienb") = WrkDelqLienB + WrkDelqFeeB
        drBill.Item("taxtot") = WrkTaxTot
        drBill.Item("propdesc") = Trim(._CULOCNO) & " " & Trim(._CULOC)
        drBill.Item("mapblock") = Trim(._CUMAP)
        drBill.Item("barcode") = BuildBarCode(WrkListNo, "-", WrkYear)
        drBill.Item("acctida") = Mid(WrkYear, 3, 2) & WrkUBTypeA & WrkListNo
        drBill.Item("acctidb") = Mid(WrkYear, 3, 2) & WrkUBTypeB & WrkListNo
        drBill.Item("route") = Trim(._CUROUT)
        drBill.Item("meterno") = Trim(._CUMETN)
      End With
      dsBill.Tables(0).Rows.Add(drBill)

Report:
      'Filter - No Report
      If Not MyFrmUB409B.ChkReport.Checked Then
        GoTo WriteInvoice
      End If

      'Billing Report
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = WrkListNo
      dr.Item("BillType") = WrkBillDesc
      dr.Item("RateCode") = WrkCodeA
      dr.Item("year") = WrkYear
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("proploc") = Trim(myUTCUSTQ._CULOCNO) & " " & Trim(myUTCUSTQ._CULOC)
      Select Case WrkFamily
        Case "A"
          dr.Item("units") = myUTCUSTQ._CUAUNT
        Case "M"
          dr.Item("usage") = WrkTotalUse
        Case "U"
          dr.Item("units") = myUTCUSTQ._CUUNIT
      End Select
      dr.Item("billamt") = WrkBillAmtA + WrkBillAmtB + WrkBillAmtC
      dr.Item("billamta") = WrkBillAmtA
      dr.Item("billamtb") = WrkBillAmtB
      dr.Item("billamtc") = WrkBillAmtC
      dr.Item("balance") = WrkDelqPrincipalA + WrkDelqPrincipalB
      dr.Item("interest") = WrkDelqInterestA + WrkDelqInterestA
      dr.Item("lien") = WrkDelqLienA + WrkDelqFeeA + WrkDelqLienB + WrkDelqFeeB
      dr.Item("taxtot") = WrkTaxTot
      ds.Tables(0).Rows.Add(dr)
WriteInvoice:
      If MyFrmUB409B.LblFilePath.Text <> String.Empty Then
        sw.WriteLine(DownloadCSV(AddrLine))
      End If
      If WrkUpdate Then
        WriteInvoice(WrkTaxTypeA, WrkBillAmtA, WrkTax1stA, WrkTax2ndA, WrkTax3rdA, WrkTax4thA, WrkDelqPrincipalA)
        WriteInvoice(WrkTaxTypeB, WrkBillAmtB, WrkTax1stB, WrkTax2ndB, WrkTax3rdB, WrkTax4thB, WrkDelqPrincipalB)
        If WrkCancel Then
          ds.Clear()
          dsBill.Clear()
          GoTo Cleanup
        End If
        WriteUTBLHS(WrkTaxTypeA, WrkBillAmtA)
        WriteUTBLHS(WrkTaxTypeB, WrkBillAmtB)
      End If

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    If WrkUpdate Then
      UpdateTXPROF()
    End If

Cleanup:
    If MyFrmUB409B.LblFilePath.Text <> String.Empty Then
      sw.Close()
    End If

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
    myTXPROF.CloseFile()
  End Sub
  Private Sub ClearAmounts()
    WrkBillAmtA = 0
    WrkTax1stA = 0
    WrkTax2ndA = 0
    WrkTax3rdA = 0
    WrkTax4thA = 0
    WrkBillAmtB = 0
    WrkTax1stB = 0
    WrkTax2ndB = 0
    WrkTax3rdB = 0
    WrkTax4thB = 0
    WrkDelqInterestA = 0
    WrkDelqFeeA = 0
    WrkDelqLienA = 0
    WrkDelqPrincipalA = 0
    WrkDelqInterestB = 0
    WrkDelqFeeB = 0
    WrkDelqLienB = 0
    WrkDelqPrincipalB = 0
  End Sub
  Private Sub CalcBillAmounts(ByVal WrkLtr As String, ByVal WrkType As String)
    Dim WrkMetersize As String
    Dim WrkBaseRate As Decimal
    Dim WrkBillAmt As Decimal
    Dim WrkTax1st As Decimal
    Dim WrkTax2nd As Decimal
    Dim WrkTax3rd As Decimal
    Dim WrkTax4th As Decimal
    Select Case WrkFamily
      Case "M"
        CalcMetered(WrkLtr, WrkType, WrkBillAmt)
        WrkMetersize = GetUTMETERDesc(WrkType, Trim(myUTCUSTQ._CUMSIZ))
        WrkBaseRate = GetUTMETERRate(WrkType, Trim(myUTCUSTQ._CUMSIZ))
      Case "U"
        CalcUsage(WrkLtr, WrkType, WrkBillAmt)
        WrkMetersize = ""
        If WrkLtr = "A" Then
          WrkBaseRate = GetUTRATEUSRate(WrkType, WrkCodeA)
        Else
          WrkBaseRate = GetUTRATEUSRate(WrkType, WrkCodeB)
        End If
      Case Else
        WrkMetersize = ""
        WrkBaseRate = 0
    End Select

    ' PROBABLY NEED TO CHANGE THIS HERE
    WrkTax1st = 0
    WrkTax2nd = 0
    WrkTax3rd = 0
    WrkTax4th = 0


    ' need to change in here also
    If MyFrmUB409B.RbPerJan.Checked Then
      WrkTax1st = WrkBillAmt
    End If
    If MyFrmUB409B.RbPerFeb.Checked Then
      WrkTax2nd = WrkBillAmt
    End If
    If MyFrmUB409B.RbPerMar.Checked Then
      WrkTax3rd = WrkBillAmt
    End If
    If MyFrmUB409B.RbPerApr.Checked Then
      WrkTax4th = WrkBillAmt
    End If

    If WrkLtr = "A" Then
      WrkMeterSizeA = WrkMetersize
      WrkBaseRateA = WrkBaseRate
      WrkBillAmtA = WrkBillAmt
      WrkTax1stA = WrkTax1st
      WrkTax2ndA = WrkTax2nd
      WrkTax3rdA = WrkTax3rd
      WrkTax4thA = WrkTax4th
    Else
      WrkMeterSizeB = WrkMetersize
      WrkBaseRateB = WrkBaseRate
      WrkBillAmtB = WrkBillAmt
      WrkTax1stB = WrkTax1st
      WrkTax2ndB = WrkTax2nd
      WrkTax3rdB = WrkTax3rd
      WrkTax4thB = WrkTax4th
    End If
  End Sub
  Private Sub WriteInvoice(ByVal WrkTaxType As String, ByVal WrkBillAmt As Decimal, ByVal WrkTax1st As Decimal, ByVal WrkTax2nd As Decimal,
     ByVal WrkTax3rd As Decimal, ByVal WrkTax4th As Decimal, ByVal WrkDelqPrincipal As Decimal)
    Dim Answer As Integer

    If WrkBillAmt = 0 Then Exit Sub

    myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkTaxType)
    If Not WrkWarning And Not myTXINV.RecordNotFound And WrkPeriod = 0 Then
      Answer = MsgBox(WrkYear & " Bills have already been POSTED! Amounts will be added to those bills" &
      vbCrLf & "Continue posting or CANCEL?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Confirm Bill Posting (Annual)")
      If Answer = vbCancel Then
        WrkCancel = True
        Exit Sub
      End If
    End If
    WrkWarning = True

    With myUTCUSTQ
      If myTXINV.RecordNotFound Then
        myTXINV._LISTNo = WrkListNo
        myTXINV._YEAR = WrkYear
        myTXINV._TYPE = WrkTaxType
      End If

      myTXINV._NAME = ._CUNAM1
      myTXINV._SNAME = ._CUNAM2
      If Trim(._CUMAD1) <> "" Then
        myTXINV._ADD1 = ._CUMAD1
        myTXINV._ADD2 = ._CUMAD2
        myTXINV._CITY = ._CUMCTY
        myTXINV._STATE = ._CUMST
        myTXINV._ZIP5 = MyUtils.CnvSng(Mid(._CUMZIP, 1, 5))
        If Len(._CUMZIP) > 5 Then
          myTXINV._ZIP4 = MyUtils.CnvSng(Mid(._CUMZIP, 7, 4))
        End If
      Else
        myTXINV._ADD1 = ._CUADD1
        myTXINV._ADD2 = ._CUADD2
        myTXINV._CITY = ._CUCITY
        myTXINV._STATE = ._CUST
        myTXINV._ZIP5 = MyUtils.CnvSng(Mid(._CUZIP, 1, 5))
        If Len(._CUZIP) > 5 Then
          myTXINV._ZIP4 = MyUtils.CnvSng(Mid(._CUZIP, 7, 4))
        End If
      End If
      If WrkUpdateDist Then
        myTXINV._DIST = ._CUDST
        myTXINV._PHASE = ._CUPHAS
      Else
        myTXINV._DIST = 0
        myTXINV._PHASE = 0
      End If
      myTXINV._PDST = ._CUDST
      ' all gets added to the 1st bucket and taxt   not using the other periods.
      myTXINV._TAXT = myTXINV._TAXT + WrkBillAmt
      myTXINV._TAX1 = myTXINV._TAX1 + WrkBillAmt

      'Increase previous C/C by 2nd, 3rd or 4th bill amount
      If myTXINV._CCNO > 0 Then
        If MyFrmUB409B.RbPerFeb.Checked Or MyFrmUB409B.RbPerMar.Checked Or MyFrmUB409B.RbPerApr.Checked Then
          ' not sure if this is correct but hey we go with it.
          myTXINV._CCETAX = myTXINV._CCETAX + WrkBillAmt
          myTXINV._CCTX2 = myTXINV._CCTX2 + WrkBillAmt

        End If
      End If
      myTXINV._BALD = myTXINV._BALD + WrkBillAmt
      myTXINV._BOND = 0
      myTXINV._LOCNo = ._CULOCNO
      myTXINV._LOC = ._CULOC
      myTXINV._MAP = ._CUMAP
      myTXINV._VOL = ._CUVOLM
      myTXINV._IPAGE = ._CUPAGE
      myTXINV._LETT = Mid(._CUNAM1, 1, 1)
      If MyUBBNK Then
        myTXINV._BKCD = WrkBankcd
      End If
      If Not myTXINV.RecordNotFound Then
        myTXINV.UpdateOneRecordP()
        If myTXINV.ErrMsg <> "" Then
          WriteErrorLog(myTXINV.ErrMsg)
          Exit Sub
        End If
      Else
        myTXINV.AddOneRecordP()
        If myTXINV.ErrMsg <> "" Then
          WriteErrorLog(myTXINV.ErrMsg)
          Exit Sub
        End If
      End If
      ' Update the tax invoice detail file..
      With myTXINVDTL
        .GetOneRecordP(WrkListNo, WrkYear, WrkTaxType, WrkPeriod, "MTH")
        If .RecordNotFound Then
          ._LISTNo = WrkListNo
          ._YEAR = WrkYear
          ._TYPE = WrkTaxType
          ._PERD = WrkPeriod
          ._CODE = "MTH"
          ._AMOUNT = WrkBillAmt
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        Else
          .UpdateOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        End If
      End With
    End With
  End Sub
  Private Sub UpdateTXPROF()
    With myTXPROF
      If WrkPeriod = 0 Then
        ._POSTED = "Y"
      Else
        ._POSTED = WrkPeriod
      End If
    End With

    myTXPROF.UpdateOneRecordP()

  End Sub
  Private Sub WriteUTBLHS(ByVal WrkTaxType As String, ByVal WrkBillAmt As Decimal)

    If WrkBillAmt = 0 Then Exit Sub

    With myUTBLHS
      .GetOneRecordP(WrkListNo, WrkYear, WrkTaxType)
      ._ACCT = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkTaxType
      ._AMT1 = WrkBillAmt
      ._AMT2 = 0
      ._AMT3 = 0
      ._AMT4 = 0
      ._AMT5 = 0
      ._AMT6 = 0
      ._BILDT = MyUtils.SetDBDate(Date.Today)
      ._BLAMT = WrkBillAmt
      ._CODE1 = ""
      ._CODE2 = ""
      ._CODE3 = ""
      ._CODE4 = ""
      ._CODE5 = ""
      ._CODE6 = ""
      ._DIST = WrkDist
      ._NAME1 = myUTCUSTQ._CUNAM1
      ._NAME2 = myUTCUSTQ._CUNAM2
      ._PERIOD = WrkPeriod
      ._PHASE = WrkPhase
      If Not .RecordNotFound Then
        .UpdateOneRecordP()
      Else
        .AddOneRecordP()
      End If
    End With
  End Sub
  Private Sub UpdateUTCOEA(ByVal WrkUBType As String)
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim Counter As Integer
    Dim WrkTax As Decimal
    Dim Good As Boolean

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    Counter = 0
    WrkQry = "TYPE='" & WrkUBType & "'"
    WrkQry = WrkQry & WrkAnd & "YEAR = " & WrkYear
    WrkSort = "LIST#, CDATE, CCNO"

    myUTCOEAQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Updating Previous Adjustments"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myUTCOEAQ.ReadQry()
    If Not myUTCOEAQ.IsEOF Then
      With myUTCOEAQ
        Counter = Counter + 1
        myTXINV.GetOneRecordP(._LISTNO, ._YEAR, ._TYPE)
        If myTXINV.RecordNotFound Then GoTo NextRec
        Good = False
        myUTCOEA.GetOneRecordP(._CCNO)
        WrkTax = myTXINV._TAX2
        'Winging it here too...   not sure how C-C would be...
        If WrkTax > 0 And ._CETAX2 = 0 Then
          myUTCOEA._CETAX = ._CETAX + WrkTax
          myUTCOEA._CETAX2 = WrkTax
          Good = True
        End If


      End With

      If WrkUpdate And Good Then
        myUTCOEA.UpdateOneRecordP()
        If myUTCOEA.ErrMsg <> "" Then
          WriteErrorLog(myUTCOEA.ErrMsg)
          Exit Sub
        End If
      End If

NextRec:
      With myFrmProgress
        WrkPct = (Counter / 10) Mod 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .LblMsg.Text = "Records processed: " & Counter
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
      GoTo ReadNext
    End If

    myFrmProgress.Close()

CloseFiles:
    myUTCOEAQ.CloseFile()
  End Sub

  Private Sub CalcMetered(ByVal WrkLtr As String, ByVal WrkType As String, ByRef OutBillAmt As Decimal)
    OutBillAmt = 0 'Value will be passed to calling routine
    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkType

      .In_AnnualBill = False

      .In_BillDate = WrkMeterReadingDate
      .GetMeterReadings()
      WrkActualCurr = .Out_ActualCurr
      WrkActualPrev = .Out_ActualPrev
      WrkReadingCurr = .Out_MeterReadCurr
      WrkReadingPrev = .Out_MeterReadPrev
      WrkReading2 = .Out_MeterRead2
      WrkReading3 = .Out_MeterRead3
    End With

    With MyUBCalcBillMeter
      .In_RateType = WrkType
      .In_MeterSize = Trim(myUTCUSTQ._CUMSIZ)
      .In_MeterReadCurr = WrkReadingCurr
      .In_MeterReadPrev = WrkReadingPrev
      .In_MeterRead2 = WrkReading2
      .In_MeterRead3 = WrkReading3
      .In_Units = myUTCUSTQ._CUUNIT
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = myUTCUSTQ._CUEDU
      End If
      .CalcMeteredUse()
      WrkTotalUse = .Out_TotalUse
      WrkActualUse = .Out_ActualUse
    End With

    With MyUBCalcBillM
      .In_RateType = WrkType
      If WrkLtr = "A" Then
        .In_RateCode = WrkCodeA
      Else
        .In_RateCode = WrkCodeB
      End If
      If .In_RateCode <> "" Then
        .In_TotalUse = MyUBCalcBillMeter.Out_TotalUse
        .In_MinBill = MyUBCalcBillMeter.Out_MinBill
        .In_UseMinCharge = MyUBCalcBillMeter.Out_UseMinCharge
        .In_UnitCharge = MyUBCalcBillMeter.Out_UnitCharge
        .In_MarkupPct = MyUBCalcBillMeter.Out_MarkupPct
        .In_EDUCharge = MyUBCalcBillMeter.Out_EDUCharge
        .In_User1Charge = MyUBCalcBillMeter.Out_User1Charge
        .In_User2Charge = MyUBCalcBillMeter.Out_User2Charge
        .In_User3Charge = MyUBCalcBillMeter.Out_User3Charge
        .CalcMetered()
        If WrkLtr = "A" Then
          WrkRateDesc1A = .Out_RateCalc1
          WrkRateDesc1B = .Out_RateCalc2
        Else
          WrkRateDesc2A = .Out_RateCalc1
          WrkRateDesc2B = .Out_RateCalc2
        End If
        OutBillAmt = MyUtils.FmtCurrency(.Out_Bill)
        WrkMeterUserChg1 = .Out_User1Part
        WrkMeterUserChg2 = .Out_User2Part
        WrkMeterUserChg3 = .Out_User3Part
      End If
    End With

    If OutBillAmt = 0 Then Exit Sub
    CalcInterestListNo(WrkLtr, WrkType)
  End Sub
  Private Sub CalcUsage(ByVal WrkLtr As String, ByVal WrkType As String, ByRef OutBillAmt As Decimal)
    OutBillAmt = 0 'Value will be passed to calling routine
    With MyUBCalcBillU
      .In_RateType = WrkType
      If WrkLtr = "A" Then
        .In_RateCode = WrkCodeA
      Else
        .In_RateCode = WrkCodeB
      End If
      If WrkType = "U" Then
        .In_Fixtures = myUTCUSTQ._CUSFIX
        .In_SurChg = myUTCUSTQ._CUSCHR
      Else
        .In_Fixtures = myUTCUSTQ._CUWFIX
        .In_SurChg = 0
      End If
      .In_Units = myUTCUSTQ._CUUNIT
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = myUTCUSTQ._CUEDU
      End If
      .In_Extras = myUTCUSTQ._CUXTRA
      .CalcUsage()
      OutBillAmt = MyUtils.FmtCurrency(.Out_Bill)
    End With

    If OutBillAmt = 0 Then Exit Sub
    CalcInterestListNo(WrkLtr, WrkType)
  End Sub
  Private Function GetRateCode(ByVal WrkUBType As String) As String

    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
  Private Sub CalcInterestListNo(ByVal WrkLtr As String, ByVal WrkType As String)
    Dim ds2 As DataSet = New DataSet
    Dim WrkDelqInterest As Decimal
    Dim WrkDelqFee As Decimal
    Dim WrkDelqLien As Decimal
    Dim WrkDelqPrincipal As Decimal
    Dim I As Integer

    WrkDelqInterest = 0
    WrkDelqFee = 0
    WrkDelqLien = 0
    WrkDelqPrincipal = 0

    ds2 = myTXINVLK.GetViewbyList(WrkListNo, WrkType, 999)
    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With myCashInt
        If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
          .In_IntDate = WrkInterestDate
          .In_ListNo = WrkListNo
          .In_Type = WrkType
          .In_Year = ds2.Tables(0).Rows(I).Item("year")
          .CalcInterest()
          WrkDelqInterest = WrkDelqInterest + .Out_Int
          WrkDelqFee = WrkDelqFee + .Out_Fee
          WrkDelqLien = WrkDelqLien + .Out_Lien
          WrkDelqPrincipal = WrkDelqPrincipal + .Out_Prin
        Else
          WrkDelqPrincipal = WrkDelqPrincipal + ds2.Tables(0).Rows(I).Item("wbal")
        End If
      End With
    Next
    If WrkLtr = "A" Then
      WrkDelqInterestA = WrkDelqInterest
      WrkDelqFeeA = WrkDelqFee
      WrkDelqLienA = WrkDelqLien
      WrkDelqPrincipalA = WrkDelqPrincipal
    Else
      WrkDelqInterestB = WrkDelqInterest
      WrkDelqFeeB = WrkDelqFee
      WrkDelqLienB = WrkDelqLien
      WrkDelqPrincipalB = WrkDelqPrincipal
    End If

  End Sub
  Public Function BuildScanLine(ByVal WrkList As Integer, ByVal WrkGLYear As Integer,
 ByVal WrkType As String, ByVal WrkBillAmt As Decimal, ByVal WrkTax1st As Decimal,
 ByVal WrkBackTax As String) As String

    Dim sb As StringBuilder
    Dim WrkChk As String
    Dim WrkChkDigit1 As Integer
    Dim WrkChkDigit2 As Integer
    Dim WrkChkDigit3 As Integer
    Dim WrkChkDigit4 As Integer
    Dim WrkChkDigit5 As Integer
    Dim HoldString As String

    sb = New StringBuilder
    'Check Digit #1 = Town/Year/BT
    WrkChk = Format(myTOWN._TOWNBR, "000")
    WrkChk = WrkChk & Trim(Str(WrkGLYear))
    If WrkBackTax = "BT" Then
      WrkChk = WrkChk + "1"
    Else
      WrkChk = WrkChk + "0"
    End If
    HoldString = WrkChk
    WrkChkDigit1 = CalcModulus10(WrkChk)
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit1)

    'Check Digit #2 = Type#/List#
    WrkChk = GetTypeNo(WrkType) & Format(WrkList, "000000")
    HoldString = HoldString + WrkChk
    WrkChkDigit2 = CalcModulus10(WrkChk)
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit2)

    'Check Digit#3 = Tax Total
    WrkChk = Format(WrkBillAmt * 100, "000000000")
    HoldString = HoldString + WrkChk
    WrkChkDigit3 = CalcModulus10(WrkChk)
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit3)

    'Check Digit#4 = Tax1st this should be same amt as bill amt 
    WrkChk = Format(WrkBillAmt * 100, "000000000")
    HoldString = HoldString + WrkChk
    WrkChkDigit4 = CalcModulus10(WrkChk)
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit4)

    'Check Digit#5 = Everything 
    WrkChkDigit5 = CalcModulus10(HoldString)
    sb.Append(WrkChkDigit5)
    Return sb.ToString

  End Function
  Public Function BuildScanLineWebster(ByVal WrkList As Integer, ByVal WrkGLYear As Integer,
 ByVal WrkType As String, ByVal WrkTaxTotal As Decimal, ByVal WrkTax1st As Decimal,
 ByVal WrkTax2nd As Decimal, ByVal WrkBackTax As String) As String

    Dim sb As StringBuilder
    Dim WrkChk As String
    Dim WrkChkDigit1 As Integer
    Dim WrkChkDigit2 As Integer
    Dim WrkChkDigit3 As Integer
    Dim WrkChkDigit4 As Integer
    Dim HoldString As String

    sb = New StringBuilder
    'Check Digit #1 = Town/Year/BT/Type/List #
    WrkChk = Format(myTOWN._TOWNBR, "000")
    WrkChk = WrkChk & Mid(WrkGLYear, 3, 2)
    If WrkBackTax = "BT" Then
      WrkChk = WrkChk + "1"
    Else
      WrkChk = WrkChk + "0"
    End If
    If myTOWN._TOWNBR = 99 Then
      WrkChk = WrkChk & GetTypeNo(WrkType) & Format(WrkList, "000000")
    Else
      WrkChk = WrkChk & GetTypeNo(WrkType) & Format(WrkList, "0000000")
    End If
    WrkChkDigit1 = CalcModulus(WrkChk)
    HoldString = WrkChk + Trim(Str(WrkChkDigit1))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit1)

    'Check Digit = Tax1st/Tax2nd - since only 1  usign bull amount and making 2nd 0
    WrkChk = Format(WrkTaxTotal * 100, "00000000")
    WrkChk = WrkChk & Format(0 * 100, "00000000")
    WrkChk = WrkChk & Format(0, "00000000")
    WrkChk = WrkChk & Format(0, "00000000")
    WrkChkDigit2 = CalcModulus(WrkChk)
    HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit2))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit2)

    'Check Digit#3 = Tax Total
    WrkChk = Format(WrkTaxTotal * 100, "0000000000")
    WrkChkDigit3 = CalcModulus(WrkChk)
    HoldString = HoldString + WrkChk + Trim(Str(WrkChkDigit3))
    sb.Append(WrkChk)
    sb.Append(WrkChkDigit3)

    'Check Digit#4 = Everything 
    WrkChkDigit4 = CalcModulus(HoldString)
    sb.Append(WrkChkDigit4)
    Return sb.ToString
  End Function
  Public Function BuildBarCode(ByVal WrkList As Integer, ByVal WrkType As String, ByVal WrkGLYear As Integer) As String
    Dim WrkBarCode As String

    WrkBarCode = "*" & Format(WrkList, "000000") & WrkType & WrkGLYear & "*"
    Return WrkBarCode
  End Function
  Private Function DownloadCSV(ByVal AddrLine As String()) As String
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim ChkDate As Date
    Dim WrkChgUnit As Decimal
    Dim WrkChgEDU As Decimal
    Dim WrkChgFix As Decimal
    Dim WrkNumFix As Decimal

    With myUTCUSTQ
      sb = New StringBuilder
      sb.Append(CComma)
      sb.Append(WrkListNo)
      sb.Append(CComma)
      sb.Append(WrkYear)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(AddrLine(0))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(AddrLine(1))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(AddrLine(2))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(AddrLine(3))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(AddrLine(4))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUVOLM))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUPAGE))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUMAP))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append((Trim(._CULOCNO) & " " & Trim(._CULOC)))
      sb.Append(CQuote)
      sb.Append(CComma)
      If WrkServiceFrom <> ChkDate Then
        sb.Append(Format(WrkServiceFrom, "M/d/yyyy"))
        sb.Append(CComma)
        sb.Append(Format(WrkServiceTo, "M/d/yyyy"))
      Else
        sb.Append("")
        sb.Append(CComma)
        sb.Append("")
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkActualCurr))
      sb.Append(CComma)
      sb.Append(Format(WrkActualPrev))
      sb.Append(CComma)
      sb.Append(Format(WrkTotalUse))
      sb.Append(CComma)
      Select Case WrkFamily
        Case "M", "U"
          sb.Append(Format(._CUUNIT, "fixed"))
        Case Else
          sb.Append("0")
      End Select
      sb.Append(CComma)
      sb.Append(Format(WrkChgUnit, "fixed"))
      sb.Append(CComma)
      sb.Append(Trim(._CUROUT))
      sb.Append(CComma)
      sb.Append(Trim(._CUMETN))
      sb.Append(CComma)
      sb.Append(Format(ProfPrint, "###.000"))
      sb.Append(CComma)
      sb.Append(Format(ProfMini, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(ProfTxDt(0), "M/d/yyyy"))
      sb.Append(CComma)
      If ProfTxDt(1) <> ChkDate Then
        sb.Append(Format(ProfTxDt(1), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(CComma)
      If ProfTxDt(2) <> ChkDate Then
        sb.Append(Format(ProfTxDt(2), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(CComma)
      If ProfTxDt(3) <> ChkDate Then
        sb.Append(Format(ProfTxDt(3), "M/d/yyyy"))
      Else
        sb.Append("")
      End If
      sb.Append(CComma)
      sb.Append(WrkTaxTypeA)
      sb.Append(CComma)
      sb.Append(WrkCodeA)
      sb.Append(CComma)
      sb.Append(Format(WrkBillAmtA, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDelqPrincipalA, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDelqInterestA, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDelqLienA + WrkDelqFeeA, "fixed"))
      sb.Append(CComma)
      sb.Append(WrkTaxTypeB)
      sb.Append(CComma)
      sb.Append(WrkCodeB)
      sb.Append(CComma)
      sb.Append(Format(WrkBillAmtB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDelqPrincipalB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDelqInterestB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkDelqLienB + WrkDelqFeeB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTaxTot, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax1stA + WrkTax1stB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax2ndA + WrkTax2ndB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax3rdA + WrkTax3rdB, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax4thA + WrkTax4thB, "fixed"))
      sb.Append(CComma)
      sb.Append(BuildBarCode(WrkListNo, "-", WrkYear))
      sb.Append(CComma)
      sb.Append(Trim(WrkScanLine))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUNAM1))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUNAM2))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUADD1))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUADD2))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUCITY))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUST))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CUZIP))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._CUEDU)
      sb.Append(CComma)
      sb.Append(WrkChgEDU)
      sb.Append(CComma)
      myUTRATEMT.GetOneRecordP(WrkUBTypeA, WrkCodeA, 99999999)
      If Not myUTRATEMT.RecordNotFound Then
        sb.Append(myUTRATEMT._RMRATE)
      Else
        sb.Append(0)
      End If
      sb.Append(CComma)
      myUTRATEMT.GetOneRecordP(WrkUBTypeB, WrkCodeB, 99999999)
      If Not myUTRATEMT.RecordNotFound Then
        sb.Append(myUTRATEMT._RMRATE)
      Else
        sb.Append(0)
      End If
      sb.Append(CComma)
      If myTOWN._TOWNBR = 219 Then
        sb.Append(WrkCodeA & " SEWER")
        sb.Append(CComma)
        sb.Append("1.00 Minimum at $" & Format(WrkBaseRateA, "Fixed"))
        sb.Append(CComma)
        If WrkTotalUse > 5 Then
          myUTRATEMT.GetOneRecordP(WrkUBTypeA, WrkCodeA, 99999999)
          sb.Append((WrkTotalUse - 5) & " /100 CU FT at $" & Format(myUTRATEMT._RMRATE, "Fixed"))
        Else
          sb.Append("")
        End If
        sb.Append(CComma)
        sb.Append(WrkCodeB & " WATER")
        sb.Append(CComma)
        sb.Append("1.00 Minimum at $" & Format(WrkBaseRateB, "Fixed"))
        sb.Append(CComma)
        If WrkTotalUse > 5 Then
          myUTRATEMT.GetOneRecordP(WrkUBTypeB, WrkCodeB, 99999999)
          sb.Append((WrkTotalUse - 5) & " /100 CU FT at $" & Format(myUTRATEMT._RMRATE, "Fixed"))
        Else
          sb.Append("")
        End If
      Else
        sb.Append(CComma)
        sb.Append(CComma)
        sb.Append(CComma)
        sb.Append(CComma)
        sb.Append(CComma)
      End If
      If MyUBBNK Then
        sb.Append(CComma)
        sb.Append(CQuote)
        sb.Append(WrkBankcd)
        sb.Append(CQuote)
      End If
      sb.Append(CComma)
      sb.Append(WrkChgFix)
      sb.Append(CComma)
      sb.Append(Mid(WrkYear, 3, 2) & WrkUBTypeA & WrkListNo)
      sb.Append(CComma)
      sb.Append(Mid(WrkYear, 3, 2) & WrkUBTypeB & WrkListNo)
      sb.Append(CComma)
      sb.Append(WrkNumFix)
      sb.Append(CComma)
      sb.Append(._CUFUND)
    End With

    Return sb.ToString
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("Back Tax?")
    sb.Append(CComma)
    sb.Append("Account #")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Address Line 1")
    sb.Append(CComma)
    sb.Append("Address Line 2")
    sb.Append(CComma)
    sb.Append("Address Line 3")
    sb.Append(CComma)
    sb.Append("Address Line 4")
    sb.Append(CComma)
    sb.Append("Address Line 5")
    sb.Append(CComma)
    sb.Append("Volume")
    sb.Append(CComma)
    sb.Append("Page")
    sb.Append(CComma)
    sb.Append("Map/Block/Lot")
    sb.Append(CComma)
    sb.Append("Location")
    sb.Append(CComma)
    sb.Append("From Service Date")
    sb.Append(CComma)
    sb.Append("To Service Date")
    sb.Append(CComma)
    sb.Append("Current Meter Reading")
    sb.Append(CComma)
    sb.Append("Meter Prev/Reading 1")
    sb.Append(CComma)
    sb.Append("Usage")
    sb.Append(CComma)
    sb.Append("Units")
    sb.Append(CComma)
    sb.Append("Charge per Unit")
    sb.Append(CComma)
    sb.Append("Route")
    sb.Append(CComma)
    sb.Append("Meter No")
    sb.Append(CComma)
    sb.Append("Monthly Interest Perc")
    sb.Append(CComma)
    sb.Append("Minimum Interest Charge")
    sb.Append(CComma)
    sb.Append("1st Due Date")
    sb.Append(CComma)
    sb.Append("2nd Due Date")
    sb.Append(CComma)
    sb.Append("3rd Due Date")
    sb.Append(CComma)
    sb.Append("4th Due Date")
    sb.Append(CComma)
    sb.Append("Tax Type A")
    sb.Append(CComma)
    sb.Append("Rate Code A")
    sb.Append(CComma)
    sb.Append("Bill Amount A")
    sb.Append(CComma)
    sb.Append("Delq Principal A")
    sb.Append(CComma)
    sb.Append("Interest Amount A")
    sb.Append(CComma)
    sb.Append("Lien Amount A")
    sb.Append(CComma)
    sb.Append("Tax Type B")
    sb.Append(CComma)
    sb.Append("Rate Code B")
    sb.Append(CComma)
    sb.Append("Bill Amount B")
    sb.Append(CComma)
    sb.Append("Delq Principal B")
    sb.Append(CComma)
    sb.Append("Interest Amount B")
    sb.Append(CComma)
    sb.Append("Lien Amount B")
    sb.Append(CComma)
    sb.Append("Total Due")
    sb.Append(CComma)
    sb.Append("Tax 1st Payment")
    sb.Append(CComma)
    sb.Append("Tax 2nd Payment")
    sb.Append(CComma)
    sb.Append("Tax 3rd Payment")
    sb.Append(CComma)
    sb.Append("Tax 4th Payment")
    sb.Append(CComma)
    sb.Append("Bar Code")
    sb.Append(CComma)
    sb.Append("Scan Line")
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
    sb.Append("ZIP")
    sb.Append(CComma)
    sb.Append("EDUs")
    sb.Append(CComma)
    sb.Append("Charge Per EDU")
    sb.Append(CComma)
    sb.Append("Rate Tier A1")
    sb.Append(CComma)
    sb.Append("Rate Tier B1")
    sb.Append(CComma)
    sb.Append("Rates A1")
    sb.Append(CComma)
    sb.Append("Rates A2")
    sb.Append(CComma)
    sb.Append("Rates A3")
    sb.Append(CComma)
    sb.Append("Rates B1")
    sb.Append(CComma)
    sb.Append("Rates B2")
    sb.Append(CComma)
    sb.Append("Rates B3")
    sb.Append(CComma)
    If MyUBBNK Then
      sb.Append(CComma)
      sb.Append("RE Bank Code")
    End If
    sb.Append(CComma)
    sb.Append("Charge per Fixture")
    sb.Append(CComma)
    sb.Append("Account ID A")
    sb.Append(CComma)
    sb.Append("Account ID B")
    sb.Append(CComma)
    sb.Append("Number of Fixtures")
    sb.Append(CComma)
    sb.Append("Fund")
    Return sb.ToString
  End Function
  Public Function GetUTMETERDesc(ByVal WrkType As String, ByVal Size As String) As String
    Dim WrkResult As String

    WrkResult = ""
    myUTMETER.GetOneRecordP(WrkType, Size)
    With myUTMETER
      If .RecordNotFound Then
      Else
        WrkResult = ._MTDESC
      End If
    End With

    Return WrkResult
  End Function
  Public Function GetUTMETERRate(ByVal WrkType As String, ByVal Size As String) As Decimal
    Dim WrkResult As Decimal

    WrkResult = 0
    myUTMETER.GetOneRecordP(WrkType, Size)
    With myUTMETER
      If .RecordNotFound Then
      Else
        WrkResult = ._MTMIN
      End If
    End With

    Return WrkResult
  End Function
  Public Function GetUTRATEUSRate(ByVal WrkType As String, ByVal Code As String) As Decimal
    Dim WrkResult As Decimal

    WrkResult = 0
    myUTRATEUS.GetOneRecordP(WrkType, Code)
    With myUTRATEUS
      If .RecordNotFound Then
      Else
        WrkResult = ._RUBASE
      End If
    End With

    Return WrkResult
  End Function
End Module
