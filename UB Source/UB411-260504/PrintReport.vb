Imports System.io
Imports System.Text
Module PrintReport

  Public MyReportCancel As Boolean
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTMETER As UTMETER.MyData
  Dim myUTMUSER As UTMUSER.MyData
  Dim myUTRATEMT As UTRATEMT.MyData
  Dim myUTRATEUS As UTRATEUS.MyData
  Dim myUTBREAK As UTBREAK.MyData
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
  Dim WrkTaxType As String
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCode As String
  Dim WrkCodeDesc As String
  Dim WrkTax1st As Decimal
  Dim WrkTax2nd As Decimal
  Dim WrkTax3rd As Decimal
  Dim WrkTax4th As Decimal
  Dim WrkPeriod As Integer
  Dim WrkPeriodDesc As String
  Dim WrkBillingPeriodDates As String
  Dim WrkBaseRate As Decimal
  Dim WrkMeterSize As String
  Dim WrkScanLine As String
  Dim WrkActualCurr As Integer
  Dim WrkActualPrev As Integer
  Dim WrkReadingCurr As Integer
  Dim WrkReadingPrev As Integer
  Dim WrkReading2 As Integer
  Dim WrkReading3 As Integer
  Dim WrkBrkAmt(6) As Decimal
  Dim WrkBrkCode(6) As String
  Dim WrkBrkPct(6) As Decimal
  Dim WrkMeterUserChg1 As Decimal
  Dim WrkMeterUserChg2 As Decimal
  Dim WrkMeterUserChg3 As Decimal
  Dim WrkWarning As Boolean
  Dim WrkCancel As Boolean
  'Assessment Work Fields
  Dim WrkOrigAssmnt As Decimal
  Dim WrkBillAmt As Decimal
  Dim WrkBond As Decimal
  Dim WrkBondSchedule As Decimal
  Dim WrkYearsLeft As Integer
  Dim WrkYearNo As Integer
  Dim WrkAssmntLeft As Decimal
  Dim WrkPayoff As Decimal
  Dim WrkAssmntAdjust As Decimal
  Dim WrkCaveat As Decimal
  Dim WrkAddCaveat As Boolean
  'Metered work fields
  Dim WrkTotalUse As Integer
  Dim WrkActualUse As Integer
  'Deliquent work fields
  Dim WrkDelqInterest As Decimal
  Dim WrkDelqFee As Decimal
  Dim WrkDelqLien As Decimal
  Dim WrkDelqBond As Decimal
  Dim WrkDelqPrincipal As Decimal
  Dim WrkBackTaxAmt As Decimal
  'Misc fields
  Dim WrkBankcd As String
  'Assessment Calcs
  Dim MyUBCalcBillA As UBCalcBill.BillAssessment
  Dim MyUBCalcBillAmort As UBCalcBill.Amort
  'Metered Calcs
  Dim MyUBCalcReading As UBCalcReading.MyData
  Dim MyUBCalcBillMeter As UBCalcBill.MeteredUse
  Dim MyUBCalcBillM As UBCalcBill.BillMetered
  Dim WrkUnitCalc As String
  Dim WrkEDUCalc As String
  Dim WrkRateDesc As String
  Dim WrkRateCalc1 As String
  Dim WrkRateCalc2 As String
  'Usage Calcs
  Dim MyUBCalcBillU As UBCalcBill.BillUsage
  'Breakout Amounts
  Dim WrkBreakAmt1 As Decimal
  Dim WrkBreakAmt2 As Decimal
  Dim WrkBreakAmt3 As Decimal
  Public Sub PrtReport()
    Dim WrkPhaseA As String
    Dim Answer As Integer

    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTMETER = New UTMETER.MyData(myDBConnect)
    myUTMUSER = New UTMUSER.MyData(myDBConnect)
    myUTRATEMT = New UTRATEMT.MyData(myDBConnect)
    myUTRATEUS = New UTRATEUS.MyData(myDBConnect)
    myUTBREAK = New UTBREAK.MyData(myDBConnect)
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
    MyUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBillAmort = New UBCalcBill.Amort(myDBConnect)
    MyUBCalcReading = New UBCalcReading.MyData(myDBConnect)
    MyUBCalcBillMeter = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBillM = New UBCalcBill.BillMetered(myDBConnect)
    MyUBCalcBillU = New UBCalcBill.BillUsage(myDBConnect)

    With MyFrmUB411B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkUBType = Trim(.TxtUBType.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
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
      WrkPeriod = 0 'Annual
      WrkPeriodDesc = "Annual"
      If MyFrmUB411B.RbPerAnnual1.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "Annual 1st Half"
      End If
      If MyFrmUB411B.RbPerAnnual2.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "Annual 2nd Half"
      End If
      If MyFrmUB411B.RbPerAnnual2post.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "Annual 2nd Posted"
      End If
      If MyFrmUB411B.RbPer1st.Checked Then
        WrkPeriod = 1
        WrkPeriodDesc = "1st Period"
      End If
      If MyFrmUB411B.RbPer2nd.Checked Then
        WrkPeriod = 2
        WrkPeriodDesc = "2nd Period"
      End If
      If MyFrmUB411B.RbPer3rd.Checked Then
        WrkPeriod = 3
        WrkPeriodDesc = "3rd Period"
      End If
      If MyFrmUB411B.RbPer4th.Checked Then
        WrkPeriod = 4
        WrkPeriodDesc = "4th Period"
      End If
    End With

    If WrkUpdate Then
      Answer = MsgBox("Click OK to continue with posting or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Confirm POSTING Run")
      If Answer = MsgBoxResult.Cancel Then Exit Sub
    End If

    WrkTaxType = GetUTTYPETaxType(WrkUBType)
    WrkBillDesc = GetUTTypeDesc(WrkUBType)
    WrkFamily = GetUTTYPEFamily(WrkUBType)
    myUTBREAK.GetOneRecordP(WrkUBType)

    WrkCaveat = 0
    If WrkFamily = "A" Then
      myUTCNTL.GetOneRecordP(0)
      If Not myUTCNTL.RecordNotFound Then
        With myUTCNTL
          WrkCaveat = ._UBCAV
        End With
      End If
    End If

    GetTXFMBILL(WrkTaxType)
    If Trim(myTXFMBILL._LINE1) = String.Empty Then
      GetTXFMBILL(" ")
    End If

    If WrkPhase = 0 Then
      WrkPhaseA = ""
    Else
      WrkPhaseA = WrkPhase
    End If
    myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, WrkPhaseA, WrkDist)
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
      MsgBox("Type: " & WrkTaxType & vbCrLf & "Year: " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
      Exit Sub
    End If

    If ProfPosted <> "" Then
      Select Case ProfPosted
        Case "1"
          If WrkPeriod = 1 Then
            Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills for 1st Period have already been Posted")
            If Answer = MsgBoxResult.Cancel Then Exit Sub
          End If
        Case "2"
          If WrkPeriod <= 2 Then
            Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills for 2nd Period have already been Posted")
            If Answer = MsgBoxResult.Cancel Then Exit Sub
          End If
        Case "3"
          If WrkPeriod <= 3 Then
            Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills for 3rd Period have already been Posted")
            If Answer = MsgBoxResult.Cancel Then Exit Sub
          End If
        Case "4"
          If WrkPeriod <= 4 Then
            Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills for 4th Period have already been Posted")
            If Answer = MsgBoxResult.Cancel Then Exit Sub
          End If
        Case "Y"
          Answer = MsgBox("Click OK to continue or Cancel to abort", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, "Bills have already been Posted")
          If Answer = MsgBoxResult.Cancel Then Exit Sub
      End Select
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
      UpdateUTCOEA()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = dsBill
      .WrkUBType = WrkUBType
      .WrkInterestRate = ProfPrint * 100
      .WrkMinInterest = ProfMini
      .WrkComment1 = WrkComment1
      .WrkComment2 = WrkComment2
      .WrkAddlBillDesc = WrkAddlBillDesc
      'Changed to select case
      Select Case WrkPeriod
        Case <= 1
          .WrkDueDate1 = Format(ProfTxDt(0), "M/d/yyyy")
          .WrkDueDate2 = Format(ProfTxDt(1), "M/d/yyyy")
          .WrkGraceDate1 = Format(ProfGrDt(0), "M/d/yyyy")
          .WrkGraceDate2 = Format(ProfGrDt(1), "M/d/yyyy")
        Case 2
          .WrkDueDate1 = Format(ProfTxDt(1), "M/d/yyyy")
          .WrkGraceDate1 = Format(ProfGrDt(1), "M/d/yyyy")
          .WrkDueDate2 = Format(ProfTxDt(1), "M/d/yyyy")
          .WrkGraceDate2 = Format(ProfGrDt(1), "M/d/yyyy")
        Case 3
          .WrkDueDate1 = Format(ProfTxDt(2), "M/d/yyyy")
          .WrkGraceDate1 = Format(ProfGrDt(2), "M/d/yyyy")
          .WrkDueDate2 = Format(ProfTxDt(2), "M/d/yyyy")
          .WrkGraceDate2 = Format(ProfGrDt(2), "M/d/yyyy")
        Case 4
          .WrkDueDate1 = Format(ProfTxDt(3), "M/d/yyyy")
          .WrkGraceDate1 = Format(ProfGrDt(3), "M/d/yyyy")
          .WrkDueDate2 = Format(ProfTxDt(3), "M/d/yyyy")
          .WrkGraceDate2 = Format(ProfGrDt(3), "M/d/yyyy")
      End Select
      .WrkProfPerd = ProfPerd
      .WrkPeriod = WrkPeriod
      .WrkPeriodDesc = WrkPeriodDesc
      .WrkServiceFrom = Format(WrkServiceFrom, "M/d/yyyy")
      .WrkServiceTo = Format(WrkServiceTo, "M/d/yyyy")
      .WrkBrkDesc1 = WrkBrkCode(0) & ""
      .WrkBrkDesc2 = WrkBrkCode(1) & ""
      .WrkBrkDesc3 = WrkBrkCode(2) & ""
      .WrkBrkDesc4 = WrkBrkCode(3) & ""
      .WrkBrkDesc5 = WrkBrkCode(4) & ""
      .WrkBrkDesc6 = WrkBrkCode(5) & ""
      .WrkBrkDesc7 = WrkBrkCode(6) & ""
      .Show()
    End With

    If Not WrkUpdate Or WrkCancel Then Exit Sub
    'reset screen back to defaults when posting
    With MyFrmUB411B
      .LblFilePath.Text = ""
      .TxtDist.Text = ""
      .TxtPhase.Text = ""
      .TxtUBType.Text = ""
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
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("BondSchedule", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("DelqBond", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("AssmntLeft", Type.GetType("System.Decimal"))
      .Columns.Add("BillsLeft", Type.GetType("System.Int32"))
      .Columns.Add("BrkAmt1", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt2", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt3", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt4", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt5", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt6", Type.GetType("System.Decimal"))
      .Columns.Add("BrkAmt7", Type.GetType("System.Decimal"))
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
      .Columns.Add("Usage", Type.GetType("System.Int32"))
      .Columns.Add("RateCode", Type.GetType("System.String"))
      .Columns.Add("RateCodeDesc", Type.GetType("System.String"))
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("DelqBond", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Caveat", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("AssmntLeft", Type.GetType("System.Decimal"))
      .Columns.Add("Payoff", Type.GetType("System.Decimal"))
      .Columns.Add("YearNo", Type.GetType("System.Decimal"))
      .Columns.Add("BillsLeft", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("MapBlock", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("Barcode", Type.GetType("System.String"))
      .Columns.Add("BreakDesc1", Type.GetType("System.String"))
      .Columns.Add("BreakAmt1", Type.GetType("System.Decimal"))
      .Columns.Add("BreakDesc2", Type.GetType("System.String"))
      .Columns.Add("BreakAmt2", Type.GetType("System.Decimal"))
      .Columns.Add("BreakDesc3", Type.GetType("System.String"))
      .Columns.Add("BreakAmt3", Type.GetType("System.Decimal"))
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("BackTaxAmt", Type.GetType("System.Decimal"))
      .Columns.Add("BreakDesc4", Type.GetType("System.String"))
      .Columns.Add("BreakAmt4", Type.GetType("System.Decimal"))
      .Columns.Add("BreakDesc5", Type.GetType("System.String"))
      .Columns.Add("BreakAmt5", Type.GetType("System.Decimal"))
      .Columns.Add("NoPayments", Type.GetType("System.Decimal"))
    End With
    dsBill.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim AddrLine() As String
    Dim WrkTaxTot As Decimal
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkBackTax As String
    Dim WrkChgUnit As Decimal
    Dim WrkChgEDU As Decimal
    Dim WrkChgFix As Decimal
    Dim WrkNumFix As Decimal
    Dim WrkRateCalcDesc1 As String
    Dim WrkRateCalcDesc2 As String
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
    'MK 7/17/25 Begin
    If WrkFamily = "M" Or WrkFamily = "U" Then
      If WrkQry = String.Empty Then
        WrkQry = "rcode<>'I'"
      Else
        WrkQry = WrkQry & WrkAnd & "rcode<>'I'"
      End If
    End If
    'MK 7/17/25 End

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

    If MyFrmUB411B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmUB411B.LblFilePath.Text)
      If MyFrmUB411B.RbFileCSV.Checked Then
        sw.WriteLine(HeadingsCSV)
      End If
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
        WrkCode = GetRateCode(WrkUBType)
        If WrkCode = "" Then GoTo NextRec
        WrkCodeDesc = GetRateCodeDesc(WrkUBType, WrkCode)
        WrkBond = 0
        WrkBondSchedule = 0
        WrkBaseRate = 0
        WrkMeterSize = ""
        WrkScanLine = ""
        WrkPayoff = 0
        WrkScanLine = String.Empty
        WrkAddCaveat = False

        Array.Clear(WrkBrkAmt, 0, 6)
        Array.Clear(WrkBrkAmt, 0, 6)
        WrkRateDesc = ""
        Select Case WrkFamily
          Case "A"
            CalcAssmnt()
            If WrkBillAmt >= WrkAssmntLeft And WrkOrigAssmnt <> WrkAssmntLeft And WrkCaveat > 0 Then  'Add caveat to Last Bill for multiple year assessment
              WrkAddCaveat = True
            End If
            WrkPayoff = WrkAssmntLeft + WrkBond + WrkDelqFee + WrkDelqBond + WrkDelqPrincipal + WrkDelqInterest + WrkDelqLien
            If WrkOrigAssmnt <> (WrkAssmntLeft + WrkBillAmt) And WrkCaveat > 0 Then  'Add caveat to Last Bill for multiple year assessment
              WrkPayoff = WrkPayoff + WrkCaveat
            End If
          Case "M"
            CalcMetered()
            WrkMeterSize = GetUTMETERDesc(WrkUBType, Trim(._CUMSIZ))
            WrkBaseRate = GetUTMETERRate(WrkUBType, Trim(._CUMSIZ))
            WrkRateDesc = GetUTRATEMTDesc(WrkUBType, WrkCode, 99999999)
          Case "U"
            CalcUsage()
            WrkBaseRate = GetUTRATEUSRate(WrkUBType, WrkCode)
        End Select

        If MyFrmUB411B.RbPerAnnual.Checked Or MyFrmUB411B.RbPerAnnual1.Checked Or MyFrmUB411B.RbPerAnnual2.Checked Then
          With myTPaymnt
            .In_ListNo = WrkListNo
            .In_Type = WrkTaxType
            .In_Year = WrkYear
            .In_Dst = WrkDist
            .In_Phs = WrkPhase
            .In_TaxT = WrkBillAmt
            .In_Tax1 = WrkBrkAmt(4) 'EDU
            .CalcPaySplit()
            WrkBillAmt = .Out_TaxT
            WrkTax1st = .Out_Tax1
            WrkTax2nd = .Out_Tax2
            WrkTax3rd = .Out_Tax3
            WrkTax4th = .Out_Tax4
          End With
        Else
          WrkTax1st = 0
          WrkTax2nd = 0
          WrkTax3rd = 0
          WrkTax4th = 0
        End If

        If MyFrmUB411B.RbPerAnnual1.Checked Then
          WrkTax2nd = 0
          WrkBillAmt = WrkTax1st
        End If
        If MyFrmUB411B.RbPerAnnual2.Checked Then
          WrkTax1st = 0
          myTXINV.GetOneRecordP(._CUACCT, WrkYear, WrkUBType)
          WrkBillAmt = myTXINV._BALD
        End If
        If MyFrmUB411B.RbPerAnnual2post.Checked Then
          myTXINV.GetOneRecordP(._CUACCT, WrkYear, WrkUBType)
          WrkBillAmt = myTXINV._BALD
          WrkTax1st = myTXINV._TAX1
          WrkTax2nd = myTXINV._TAX2
        End If
        If MyFrmUB411B.RbPer1st.Checked Then
          WrkTax1st = WrkBillAmt
        End If
        If MyFrmUB411B.RbPer2nd.Checked Then
          WrkTax2nd = WrkBillAmt
        End If
        If MyFrmUB411B.RbPer3rd.Checked Then
          WrkTax3rd = WrkBillAmt
        End If
        If MyFrmUB411B.RbPer4th.Checked Then
          WrkTax4th = WrkBillAmt
        End If

        'Filter - Omit Zero Bills 
        If WrkBillAmt <= 0 And WrkBond = 0 Then
          GoTo NextRec
        End If

        BrkRound()
        If Trim(._CUMAD1) <> "" Then
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUMAD1, ._CUMAD2, ._CUMCTY, ._CUMST, 0, 0, ._CUMZIP)
        Else
          AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
        End If

        If Not myUTBREAK.RecordNotFound Then
          If MyFrmUB411B.ChkBills.Checked Or MyFrmUB411B.LblFilePath.Text <> String.Empty Then
            CalcBreakAmts(WrkBillAmt)
          End If
        End If

        If WrkAddCaveat Then
          WrkDelqLien = WrkDelqLien + WrkCaveat
        End If
        WrkTaxTot = WrkBillAmt + WrkBond + WrkDelqPrincipal + WrkDelqInterest + WrkDelqLien + WrkDelqFee + WrkDelqBond

        WrkBackTax = String.Empty
        If WrkDelqPrincipal > 0 Then
          WrkBackTax = "BT"
        End If
        If WrkScanLine = String.Empty Then
          If myTXFMBILL._SCAN = "W" Then
            WrkScanLine = BuildScanLineWebster(WrkListNo, WrkYear, WrkUBType, WrkBillAmt, WrkTax1st, WrkTax2nd, WrkBackTax)
          Else
            WrkScanLine = BuildScanLine(WrkListNo, WrkYear, WrkUBType, WrkBillAmt, WrkTax1st, WrkBackTax)
          End If
        End If
        WrkBackTaxAmt = WrkDelqPrincipal + WrkDelqBond + WrkDelqLien + WrkDelqFee + WrkDelqInterest
        WrkBankcd = ""
        If MyUBBNK Then
          myTXREALC.GetOneRecordP(._CUACCT)
          If Not myTXREALC.RecordNotFound Then
            WrkBankcd = Trim(myTXREALC._BKCD)
          End If
        End If

        'Filter - Print No Bills
        If Not MyFrmUB411B.ChkBills.Checked Then
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
        drBill.Item("tax1st") = WrkTax1st
        drBill.Item("tax2nd") = WrkTax2nd
        drBill.Item("yearno") = WrkYearNo
        Select Case WrkFamily
          Case "A"
            drBill.Item("units") = ._CUAUNT
          Case "M"
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
        drBill.Item("ratecode") = WrkCode
        drBill.Item("ratecodedesc") = WrkCodeDesc
        drBill.Item("billsleft") = WrkYearsLeft
        drBill.Item("billamt") = WrkBillAmt
        drBill.Item("bond") = WrkBond
        drBill.Item("assmntleft") = WrkAssmntLeft
        drBill.Item("payoff") = WrkPayoff
        drBill.Item("delqbond") = WrkDelqBond
        drBill.Item("balance") = WrkDelqPrincipal
        drBill.Item("interest") = WrkDelqInterest
        drBill.Item("lien") = WrkDelqLien + WrkDelqFee
        If WrkAddCaveat Then
          drBill.Item("caveat") = WrkCaveat
        Else
          drBill.Item("caveat") = 0
        End If
        drBill.Item("taxtot") = WrkTaxTot
        Select Case WrkFamily
          Case Else
            drBill.Item("propdesc") = Trim(._CULOCNO) & " " & Trim(._CULOC)
        End Select
        drBill.Item("mapblock") = Trim(._CUMAP)
        If WrkDelqPrincipal > 0 Then
          drBill.Item("backtax") = True
        Else
          drBill.Item("backtax") = False
        End If
        drBill.Item("barcode") = BuildBarCode(WrkListNo, WrkUBType, WrkYear)
        If Not myUTBREAK.RecordNotFound Then
          drBill.Item("breakdesc1") = Trim(myUTBREAK._BDESC1)
          drBill.Item("breakamt1") = WrkBreakAmt1
          drBill.Item("breakdesc2") = Trim(myUTBREAK._BDESC2)
          drBill.Item("breakamt2") = WrkBreakAmt2
          drBill.Item("breakdesc3") = Trim(myUTBREAK._BDESC3)
          drBill.Item("breakamt3") = WrkBreakAmt3
        End If
        If myTOWN._TOWNBR = 37 Then 'Derby
          drBill.Item("breakdesc1") = "Base Charge"
          drBill.Item("breakamt1") = WrkBrkAmt(0) + WrkBrkAmt(1) + WrkBrkAmt(2) + WrkBrkAmt(3) + WrkBrkAmt(4)
          drBill.Item("breakdesc2") = "Capital Fee"
          drBill.Item("breakamt2") = WrkBrkAmt(5)
        End If

        WrkChgUnit = 0
        WrkChgEDU = 0
        WrkChgFix = 0
        WrkNumFix = 0
        If WrkBillAmt > 0 Then
          Select Case WrkFamily
            Case "M", "U"
              If ._CUUNIT > 0 Then
                WrkChgUnit = WrkBrkAmt(2) / ._CUUNIT
              End If
              If ._CUEDU > 0 Then
                WrkChgEDU = WrkBrkAmt(4) / ._CUEDU
              End If
              If WrkUBType = "U" Then
                If ._CUSFIX > 0 Then
                  WrkChgFix = WrkBrkAmt(3) / ._CUSFIX
                  WrkNumFix = ._CUSFIX
                End If
              End If
              If WrkUBType = "W" Then
                If ._CUWFIX > 0 Then
                  WrkChgFix = WrkBrkAmt(3) / ._CUWFIX
                  WrkNumFix = ._CUWFIX
                End If
              End If
          End Select
        End If

        WrkRateCalcDesc1 = ""
        WrkRateCalcDesc2 = ""
        If myTOWN._TOWNBR = 280 Then 'Norfolk Sewer Dist
          WrkRateCalcDesc1 = Format(._CUUNIT, "fixed") & " Hookup at $" & Format(WrkChgUnit, "Fixed")
          If WrkBrkAmt(0) > 0 Then
            WrkRateCalcDesc2 = Format(WrkTotalUse, "Fixed") & " 1000/GAL at $" & Format(myUTRATEMT._RMRATE, "Fixed")
          Else
            WrkRateCalcDesc2 = ""
          End If
        End If
        drBill.Item("breakdesc1") = WrkRateCalcDesc1
        drBill.Item("breakdesc2") = WrkRateCalcDesc2
        drBill.Item("acctid") = Mid(WrkYear, 3, 2) & WrkUBType & WrkListNo
        If WrkDelqPrincipal > 0 Then
          drBill.Item("backtaxamt") = WrkBackTaxAmt
        Else
          drBill.Item("backtaxamt") = 0
        End If
      End With
      drBill.Item("nopayments") = ProfPerd
      dsBill.Tables(0).Rows.Add(drBill)

Report:
      'Filter - No Report
      If Not MyFrmUB411B.ChkReport.Checked Then
        GoTo WriteInvoice
      End If

      'Billing Report
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = WrkListNo
      dr.Item("BillType") = WrkBillDesc
      dr.Item("RateCode") = WrkCode
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
          dr.Item("units") = myUTCUSTQ._CUUNIT
        Case "U"
          dr.Item("units") = myUTCUSTQ._CUUNIT
      End Select
      dr.Item("billamt") = WrkBillAmt
      dr.Item("bond") = WrkBond
      dr.Item("bondschedule") = WrkBondSchedule
      dr.Item("balance") = WrkDelqPrincipal
      dr.Item("interest") = WrkDelqInterest
      dr.Item("delqbond") = WrkDelqBond
      dr.Item("lien") = WrkDelqLien + WrkDelqFee
      dr.Item("taxtot") = WrkTaxTot
      dr.Item("assmntleft") = WrkAssmntLeft
      dr.Item("billsleft") = WrkYearsLeft
      dr.Item("brkamt1") = WrkBrkAmt(0)
      dr.Item("brkamt2") = WrkBrkAmt(1)
      dr.Item("brkamt3") = WrkBrkAmt(2)
      dr.Item("brkamt4") = WrkBrkAmt(3)
      dr.Item("brkamt5") = WrkBrkAmt(4)
      dr.Item("brkamt6") = WrkBrkAmt(5)
      dr.Item("brkamt7") = WrkBrkAmt(6)
      ds.Tables(0).Rows.Add(dr)

WriteInvoice:
      If MyFrmUB411B.LblFilePath.Text <> String.Empty Then
        If MyFrmUB411B.RbFileFixed.Checked Then
          sw.WriteLine(DownloadUTBill(AddrLine))
        Else
          sw.WriteLine(DownloadCSV(AddrLine))
        End If
      End If
      If WrkUpdate Then
        WriteInvoice(WrkAddCaveat)
        If WrkCancel Then
          ds.Clear()
          dsBill.Clear()
          GoTo Cleanup
        End If
        If WrkFamily = "A" Then
          UpdateCUSTAS()
        End If
        WriteUTBLHS()
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
    If MyFrmUB411B.LblFilePath.Text <> String.Empty Then
      sw.Close()
    End If

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
    myTXPROF.CloseFile()

  End Sub
  Private Sub WriteInvoice(ByVal WrkCaveat As Boolean)
    Dim Answer As Integer

    If (WrkBillAmt + WrkBond) = 0 Then Exit Sub

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
      If WrkDelqPrincipal > 0 Then
        If MyFrmUB411B.RbPerAnnual.Checked Or MyFrmUB411B.RbPerAnnual1.Checked Or MyFrmUB411B.RbPer1st.Checked Then
          myTXINV._ICODE = "B"
        End If
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
      myTXINV._TAXT = myTXINV._TAXT + WrkBillAmt
      myTXINV._TAX1 = myTXINV._TAX1 + WrkTax1st
      myTXINV._TAX2 = myTXINV._TAX2 + WrkTax2nd
      myTXINV._TX3RD = myTXINV._TX3RD + WrkTax3rd
      myTXINV._TX4TH = myTXINV._TX4TH + WrkTax4th
      'Increase previous C/C by 2nd, 3rd or 4th bill amount
      If myTXINV._CCNO > 0 Then
        If MyFrmUB411B.RbPer2nd.Checked Or MyFrmUB411B.RbPer3rd.Checked Or MyFrmUB411B.RbPer4th.Checked Then
          myTXINV._CCETAX = myTXINV._CCETAX + WrkBillAmt
          myTXINV._CCTX2 = myTXINV._CCTX2 + WrkTax2nd
          myTXINV._CCTX3 = myTXINV._CCTX3 + WrkTax3rd
          myTXINV._CCTX4 = myTXINV._CCTX4 + WrkTax4th
        End If
      End If
      myTXINV._BALD = myTXINV._BALD + WrkBillAmt
      myTXINV._BOND = myTXINV._BOND + WrkBond
      myTXINV._LOCNo = ._CULOCNO
      myTXINV._LOC = ._CULOC
      myTXINV._MAP = ._CUMAP
      myTXINV._VOL = ._CUVOLM
      myTXINV._IPAGE = ._CUPAGE
      myTXINV._LETT = Mid(._CUNAM1, 1, 1)
      If WrkCaveat Then
        myTXINV._LIEN = "L"
      End If
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
    End With
  End Sub
  Private Sub UpdateCUSTAS()
    If WrkBillAmt = 0 Then Exit Sub

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With myUTCUSTAS
      ._CAAMT = ._CAAMT + WrkBillAmt
      ._CAPNO = ._CAPNO + 1
    End With

    myUTCUSTAS.UpdateOneRecordP()

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
  Private Sub WriteUTBLHS()

    If (WrkBillAmt + WrkBond) = 0 Then Exit Sub

    With myUTBLHS
      .GetOneRecordP(WrkListNo, WrkYear, WrkTaxType)
      ._ACCT = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkTaxType
      ._AMT1 = WrkBrkAmt(0)
      ._AMT2 = WrkBrkAmt(1)
      ._AMT3 = WrkBrkAmt(2)
      ._AMT4 = WrkBrkAmt(3)
      ._AMT5 = WrkBrkAmt(4)
      ._AMT6 = WrkBrkAmt(5)
      ._BILDT = MyUtils.SetDBDate(Date.Today)
      ._BLAMT = WrkBillAmt
      ._CODE1 = WrkBrkCode(0)
      ._CODE2 = WrkBrkCode(1)
      ._CODE3 = WrkBrkCode(2)
      ._CODE4 = WrkBrkCode(3)
      ._CODE5 = WrkBrkCode(4)
      ._CODE6 = WrkBrkCode(5)
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
  Private Sub UpdateUTCOEA()
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
        Select Case WrkPeriod
          Case 2
            WrkTax = myTXINV._TAX2
            If WrkTax > 0 And ._CETAX2 = 0 Then
              myUTCOEA._CETAX = ._CETAX + WrkTax
              myUTCOEA._CETAX2 = WrkTax
              Good = True
            End If
          Case 3
            WrkTax = myTXINV._TX3RD
            If WrkTax > 0 And ._CETAX3 = 0 Then
              myUTCOEA._CETAX = ._CETAX + WrkTax
              myUTCOEA._CETAX3 = WrkTax
              Good = True
            End If
          Case 4
            WrkTax = myTXINV._TX4TH
            If WrkTax > 0 And ._CETAX4 = 0 Then
              myUTCOEA._CETAX = ._CETAX + WrkTax
              myUTCOEA._CETAX4 = WrkTax
              Good = True
            End If
        End Select
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
  Private Sub BrkRound()
    Dim I As Integer
    Dim WrkTot As Decimal
    Dim WrkDiff As Decimal

    For I = 0 To 5
      WrkTot = WrkTot + WrkBrkAmt(I)
    Next

    If WrkBillAmt - WrkTot = 0 Then Exit Sub

    WrkDiff = WrkBillAmt - WrkTot
    For I = 0 To 6
      If WrkBrkAmt(I) > 0 Then
        WrkBrkAmt(I) = WrkBrkAmt(I) + WrkDiff
        Exit For
      End If
    Next

  End Sub


  Private Sub CalcAssmnt()
    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkBillAmt = 0
    WrkBond = 0
    WrkBondSchedule = 0
    WrkYearsLeft = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBillA
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = myUTCUSTQ._CUAUNT
      .In_PropVal = myUTCUSTQ._CUPVAL
      .In_Footage = myUTCUSTQ._CUFOOT
      .In_Acreage = myUTCUSTQ._CUACRE
      .In_LateralFee = myUTCUSTAS._CALAT
      .In_UniformFee = myUTCUSTAS._CAUNIF
      .In_AssmntAdjust = myUTCUSTAS._CAADJ
      .In_DeferredAmt = myUTCUSTAS._CADEF
      .In_PrevBilled = myUTCUSTAS._CAAMT
      .CalcAssessment()
      WrkOrigAssmnt = MyUtils.FmtCurrency(.Out_OrigBill)
      WrkAssmntLeft = MyUtils.FmtCurrency(.Out_AmtLeft)
    End With

    If WrkAssmntLeft = 0 Then Exit Sub

    CalcInterestListNo()

    With MyUBCalcBillAmort
      .In_OrigBill = MyUBCalcBillA.Out_OrigBill
      .In_AmtLeft = MyUBCalcBillA.Out_AmtLeft
      .In_Balance = WrkDelqPrincipal
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = myUTCUSTAS._CAPNO
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBond = MyUtils.FmtCurrency(.Out_Bond)
      WrkBondSchedule = MyUtils.FmtCurrency(.Out_BondSchedule)
      WrkYearsLeft = .Out_BillsLeft
    End With

    With myUTCUSTAS
      If WrkBillAmt > 0 Then
        WrkYearNo = ._CAPNO + 1
      Else
        WrkYearNo = 0
      End If
      WrkAssmntAdjust = ._CAADJ
    End With

    With MyUBCalcBillA
      WrkBrkPct(0) = .Out_UnitPart / .Out_OrigBill
      WrkBrkAmt(0) = MyUtils.Round(WrkBillAmt * WrkBrkPct(0), 2)
      WrkBrkCode(0) = "UNIT"
      WrkBrkPct(1) = .Out_PropValPart / .Out_OrigBill
      WrkBrkAmt(1) = MyUtils.Round(WrkBillAmt * WrkBrkPct(1), 2)
      WrkBrkCode(1) = "PROPVAL"
      WrkBrkPct(2) = .Out_AcreagePart / .Out_OrigBill
      WrkBrkAmt(2) = MyUtils.Round(WrkBillAmt * WrkBrkPct(2), 2)
      WrkBrkCode(2) = "ACRE"
      WrkBrkPct(3) = .Out_FootagePart / .Out_OrigBill
      WrkBrkAmt(3) = MyUtils.Round(WrkBillAmt * WrkBrkPct(3), 2)
      WrkBrkCode(3) = "FOOTAGE"
      WrkBrkPct(4) = .Out_OtherPart / .Out_OrigBill
      WrkBrkAmt(4) = MyUtils.Round(WrkBillAmt * WrkBrkPct(4), 2)
      WrkBrkCode(4) = "OTHER"
      WrkBrkCode(5) = ""
    End With

  End Sub
  Private Sub CalcMetered()
    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkUBType
      If MyFrmUB411B.RbPerAnnual.Checked Or MyFrmUB411B.RbPerAnnual1.Checked Or MyFrmUB411B.RbPerAnnual2.Checked Then
        .In_AnnualBill = True
      Else
        .In_AnnualBill = False
      End If
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
      .In_RateType = WrkUBType
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
      WrkUnitCalc = .Out_UnitCalc
    End With

    With MyUBCalcBillM
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
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
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBrkAmt(0) = .Out_UsagePart
      WrkBrkCode(0) = "USAGE"
      WrkBrkAmt(1) = .Out_BasePart
      WrkBrkCode(1) = "BASE"
      WrkBrkAmt(2) = .Out_UnitPart
      WrkBrkCode(2) = "UNIT"
      WrkBrkAmt(3) = .Out_MinBillPart
      WrkBrkCode(3) = "MIN"
      'WrkBrkAmt(4) = .Out_MarkupPart
      'WrkBrkCode(4) = "MARKUP"
      WrkBrkAmt(4) = .Out_EDUPart
      WrkBrkCode(4) = "EDU"
      WrkRateCalc1 = .Out_RateCalc1
      WrkRateCalc2 = .Out_RateCalc2
      WrkEDUCalc = .Out_EDUCalc
      myUTMUSER.GetOneRecordP(1)
      WrkBrkAmt(5) = .Out_User1Part
      WrkBrkCode(5) = Trim(myUTMUSER._USER1)
      WrkBrkAmt(6) = .Out_User2Part
      WrkBrkCode(6) = Trim(myUTMUSER._USER2)
      WrkMeterUserChg1 = .Out_User1Part
      WrkMeterUserChg2 = .Out_User2Part
      WrkMeterUserChg3 = .Out_User3Part
    End With

    If WrkBillAmt = 0 Then Exit Sub

    CalcInterestListNo()
  End Sub
  Private Sub CalcUsage()
    With MyUBCalcBillU
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      If WrkUBType = "U" Then
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
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBrkAmt(0) = .Out_UnitPart
      WrkBrkCode(0) = "UNIT"
      WrkBrkAmt(1) = .Out_BasePart
      WrkBrkCode(1) = "BASE"
      WrkBrkAmt(2) = .Out_ExtraPart
      WrkBrkCode(2) = "EXTRA"
      WrkBrkAmt(3) = .Out_FixtPart
      WrkBrkCode(3) = "FIXTURE"
      WrkBrkAmt(4) = .Out_EDUPart
      WrkBrkCode(4) = "EDU"
      WrkBrkAmt(5) = .Out_MarkupPart
      WrkBrkCode(5) = "MARKUP"
    End With

    If WrkBillAmt = 0 Then Exit Sub

    CalcInterestListNo()
  End Sub
  Private Function GetRateCode(ByVal WrkUBType As String) As String

    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
  Private Function GetRateCodeDesc(ByVal WrkUBType As String, ByVal WrkCode As String) As String

    GetRateCodeDesc = ""
    myUTRATEMT.GetOneRecordP(WrkUBType, WrkCode, 99999999)
    If myUTRATEMT.RecordNotFound Then Exit Function

    With myUTRATEMT
      GetRateCodeDesc = Trim(._RMDESC)
    End With
  End Function
  Private Sub CalcInterestListNo()
    Dim ds2 As DataSet = New DataSet
    'MK 9/2/25 Begin
    Dim WrkLastRow As Integer
    'MK 9/2/25 End
    Dim I As Integer
    WrkDelqInterest = 0
    WrkDelqFee = 0
    WrkDelqLien = 0
    WrkDelqBond = 0
    WrkDelqPrincipal = 0

    ds2 = myTXINVLK.GetViewbyList(WrkListNo, WrkTaxType, 999)
    If ds2.Tables(0).Rows.Count = 0 Then Exit Sub

    'MK 9/2/25 Begin
    If Mid(WrkPeriodDesc, 1, 10) = "Annual 2nd" Then
      WrkLastRow = 2
    Else
      WrkLastRow = 1
    End If
    'MK 9/2/25 End
    For I = 0 To ds2.Tables(0).Rows.Count - WrkLastRow
      With myCashInt
        If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
          .In_IntDate = WrkInterestDate
          .In_ListNo = WrkListNo
          .In_Type = WrkTaxType
          .In_Year = ds2.Tables(0).Rows(I).Item("year")
          .CalcInterest()
          WrkDelqInterest = WrkDelqInterest + .Out_Int
          WrkDelqFee = WrkDelqFee + .Out_Fee
          WrkDelqLien = WrkDelqLien + .Out_Lien
          WrkDelqBond = WrkDelqBond + .Out_Bond
          WrkDelqPrincipal = WrkDelqPrincipal + .Out_Prin
        Else
          WrkDelqPrincipal = WrkDelqPrincipal + ds2.Tables(0).Rows(I).Item("wbal")
        End If
      End With
    Next

    'MK 9/12/25 Begin
    If WrkLastRow = 2 Then
      I = ds2.Tables(0).Rows.Count - 1
      With myCashInt
        If ds2.Tables(0).Rows(I).Item("wbal") > 0 Then
          .In_IntDate = WrkInterestDate
          .In_ListNo = WrkListNo
          .In_Type = WrkTaxType
          .In_Year = ds2.Tables(0).Rows(I).Item("year")
          .CalcInterest()
          WrkDelqInterest = WrkDelqInterest + .Out_Int
          WrkDelqFee = WrkDelqFee + .Out_Fee
          WrkDelqLien = WrkDelqLien + .Out_Lien
          WrkDelqBond = WrkDelqBond + .Out_Bond
        End If
      End With
    End If
    'MK 9/12/25 Begin
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

    'Check Digit#4 = Tax1st 
    WrkChk = Format(WrkTax1st * 100, "000000000")
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

    'Check Digit = Tax1st/Tax2nd
    WrkChk = Format(WrkTax1st * 100, "00000000")
    WrkChk = WrkChk & Format(WrkTax2nd * 100, "00000000")
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
  Private Function DownloadUTBill(ByVal AddrLine As String()) As String
    Dim sb As StringBuilder
    Dim WrkInteger As Integer
    Dim ChkDate As Date

    With myUTCUSTQ
      sb = New StringBuilder
      If WrkDelqPrincipal > 0 Then
        sb.Append("B")
      Else
        sb.Append(" ")
      End If
      sb.Append(Format(WrkListNo, "000000"))
      sb.Append(Format(WrkYear, "0000"))
      sb.Append(WrkTaxType)
      sb.Append(Format(WrkYearNo, "0000"))
      sb.Append(MyUtils.JustifyLeft("", 5)) 'Sewer/Water (TBD)
      sb.Append(MyUtils.JustifyLeft(AddrLine(0), 35))
      sb.Append(MyUtils.JustifyLeft(AddrLine(1), 35))
      sb.Append(MyUtils.JustifyLeft(AddrLine(2), 35))
      sb.Append(MyUtils.JustifyLeft(AddrLine(3), 35))
      sb.Append(MyUtils.JustifyLeft(AddrLine(4), 35))
      sb.Append(MyUtils.JustifyLeft(._CUVOLM, 5))
      sb.Append(MyUtils.JustifyLeft(._CUPAGE, 5))
      sb.Append(MyUtils.JustifyLeft(._CUMAP, 17))
      sb.Append(MyUtils.JustifyLeft(Trim(._CULOCNO) & " " & ._CULOC, 36))
      If WrkServiceFrom <> ChkDate Then
        sb.Append(Format(MyUtils.SetDBDateMDY(WrkServiceFrom), "00000000"))
        sb.Append(Format(MyUtils.SetDBDateMDY(WrkServiceTo), "00000000"))
      Else
        sb.Append("00000000")
        sb.Append("00000000")
      End If
      WrkInteger = (WrkBillAmt + WrkBond) * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkBond * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkDelqPrincipal * 100
      If WrkInteger >= 0 Then
        sb.Append(Format(WrkInteger, "000000000"))
      Else
        sb.Append(Format(Math.Abs(WrkInteger), "-00000000"))
      End If
      WrkInteger = WrkOrigAssmnt * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkAssmntLeft * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkDelqInterest * 100
      sb.Append(Format(WrkInteger, "00000000000"))
      WrkInteger = WrkDelqLien * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = ProfPrint * 10000
      sb.Append(Format(WrkInteger, "0000"))
      WrkInteger = ProfMini * 100
      sb.Append(Format(WrkInteger, "0000"))
      If myTOWN._TOWNBR = 162 Then
        sb.Append(Format(WrkActualCurr, "000000000"))
        sb.Append(Format(WrkActualPrev, "000000000"))
      Else
        sb.Append(Format(WrkReadingCurr, "000000000"))
        sb.Append(Format(WrkReadingPrev, "000000000"))
      End If
      sb.Append(Format(WrkTotalUse, "000000000"))
      WrkInteger = WrkTax1st * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkTax2nd * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkTax3rd * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkTax4th * 100
      sb.Append(Format(WrkInteger, "000000000"))
      Select Case WrkFamily
        Case "A"
          WrkInteger = ._CUAUNT * 100
          sb.Append(Format(WrkInteger, "00000"))
        Case "M", "U"
          WrkInteger = ._CUUNIT * 100
          sb.Append(Format(WrkInteger, "00000"))
        Case Else
          sb.Append("00000")
      End Select
      sb.Append(Format(WrkYearNo, "000"))
      sb.Append(Format(MyUtils.SetDBDateMDY(ProfTxDt(0)), "00000000"))
      If ProfTxDt(1) <> ChkDate Then
        sb.Append(Format(MyUtils.SetDBDateMDY(ProfTxDt(1)), "00000000"))
      Else
        sb.Append("00000000")
      End If
      If ProfTxDt(2) <> ChkDate Then
        sb.Append(Format(MyUtils.SetDBDateMDY(ProfTxDt(2)), "00000000"))
      Else
        sb.Append("00000000")
      End If
      If ProfTxDt(3) <> ChkDate Then
        sb.Append(Format(MyUtils.SetDBDateMDY(ProfTxDt(3)), "00000000"))
      Else
        sb.Append("00000000")
      End If
      sb.Append(MyUtils.JustifyLeft(WrkBillDesc, 25))
      WrkInteger = WrkBaseRate * 100
      sb.Append(Format(WrkInteger, "00000000000"))
      WrkInteger = WrkAssmntAdjust * 100
      sb.Append(Format(WrkInteger, "00000000000"))
      WrkInteger = WrkBreakAmt1 * 100
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(MyUtils.JustifyLeft(myUTBREAK._BDESC1, 25))
      WrkInteger = WrkBreakAmt2 * 100
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(MyUtils.JustifyLeft(myUTBREAK._BDESC2, 25))
      WrkInteger = WrkBreakAmt3 * 100
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(MyUtils.JustifyLeft(myUTBREAK._BDESC3, 25))
      sb.Append(MyUtils.JustifyLeft(WrkMeterSize, 15))
      If myTXFMBILL._SCAN = "W" Then
        sb.Append(MyUtils.JustifyLeft(WrkScanLine, 70))
      Else
        sb.Append(MyUtils.JustifyLeft(WrkScanLine, 50))
      End If
    End With

    Return sb.ToString
  End Function
  Private Function DownloadCSV(ByVal AddrLine As String()) As String
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim ChkDate As Date
    Dim WrkBillTot As Decimal
    Dim WrkChgUnit As Decimal
    Dim WrkChgEDU As Decimal
    Dim WrkChgFix As Decimal
    Dim WrkNumFix As Decimal
    Dim WrkRateCalcDesc1 As String
    Dim WrkRateCalcDesc2 As String

    With myUTCUSTQ
      sb = New StringBuilder
      sb.Append(CQuote)
      If WrkPeriodDesc = "Annual 2nd Posted" Then
        If WrkDelqPrincipal > WrkTax1st + WrkTax2nd Then
          sb.Append("B")
        Else
          sb.Append(" ")
        End If
      Else
        If WrkDelqPrincipal > 0 Then
          sb.Append("B")
        Else
          sb.Append(" ")
        End If
      End If
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkListNo)
      sb.Append(CComma)
      sb.Append(WrkYear)
      sb.Append(CComma)
      sb.Append(WrkTaxType)
      sb.Append(CComma)
      sb.Append(WrkYearNo)
      sb.Append(CComma)
      sb.Append("") 'Sewer/Water (TBD)
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
      If WrkAddCaveat Then
        WrkBillTot = WrkBillAmt + WrkBond + WrkCaveat
      Else
        WrkBillTot = WrkBillAmt + WrkBond
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkBillTot, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBillAmt, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBond, "fixed"))
      sb.Append(CComma)
      If WrkAddCaveat Then
        sb.Append(Format(WrkCaveat, "fixed"))
      Else
        sb.Append("0.00")
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkDelqPrincipal, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkOrigAssmnt, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkAssmntLeft, "fixed"))
      sb.Append(CComma)
      If myTOWN._TOWNBR = 280 Then
        sb.Append(Format(WrkDelqInterest + WrkDelqLien + WrkDelqFee, "fixed"))
        sb.Append(CComma)
        sb.Append(0)
      Else
        sb.Append(Format(WrkDelqInterest, "fixed"))
        sb.Append(CComma)
        sb.Append(Format(WrkDelqLien + WrkDelqFee, "fixed"))
      End If
      sb.Append(CComma)
      sb.Append(Format(ProfPrint, "###.000"))
      sb.Append(CComma)
      sb.Append(Format(ProfMini, "fixed"))
      sb.Append(CComma)
      If myTOWN._TOWNBR = 162 Then
        sb.Append(Format(WrkActualCurr))
      Else
        sb.Append(Format(WrkReadingCurr))
      End If
      sb.Append(CComma)
      If myTOWN._TOWNBR = 162 Then
        sb.Append(Format(WrkActualPrev))
      Else
        sb.Append(Format(WrkReadingPrev))
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkReading2))
      sb.Append(CComma)
      sb.Append(Format(WrkReading3))
      sb.Append(CComma)
      sb.Append(Format(WrkTotalUse))
      sb.Append(CComma)
      sb.Append(Format(WrkTax1st, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax2nd, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax3rd, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkTax4th, "fixed"))
      sb.Append(CComma)
      Select Case WrkFamily
        Case "A"
          sb.Append(Format(._CUAUNT, "fixed"))
        Case "M", "U"
          sb.Append(Format(._CUUNIT, "fixed"))
        Case Else
          sb.Append("0")
      End Select
      sb.Append(CComma)
      WrkChgUnit = 0
      WrkChgEDU = 0
      WrkChgFix = 0
      WrkNumFix = 0
      If WrkBillAmt > 0 Then
        Select Case WrkFamily
          Case "M", "U"
            If ._CUUNIT > 0 Then
              WrkChgUnit = WrkBrkAmt(2) / ._CUUNIT
            End If
            If ._CUEDU > 0 Then
              WrkChgEDU = WrkBrkAmt(5) / ._CUEDU
            End If
            If WrkUBType = "U" Then
              If ._CUSFIX > 0 Then
                WrkChgFix = WrkBrkAmt(3) / ._CUSFIX
                WrkNumFix = ._CUSFIX
              End If
            End If
            If WrkUBType = "W" Then
              If ._CUWFIX > 0 Then
                WrkChgFix = WrkBrkAmt(3) / ._CUWFIX
                WrkNumFix = ._CUWFIX
              End If
            End If
        End Select
      End If
      sb.Append(Format(WrkChgUnit, "fixed"))
      sb.Append(CComma)
      sb.Append(WrkYearNo)
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
      sb.Append(CQuote)
      sb.Append(Trim(WrkBillDesc))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkBaseRate)
      sb.Append(CComma)
      sb.Append(Format(WrkAssmntAdjust, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBreakAmt1, "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(myUTBREAK._BDESC1))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBreakAmt2, "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(myUTBREAK._BDESC2))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBreakAmt3, "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(myUTBREAK._BDESC3))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Trim(WrkMeterSize))
      sb.Append(CComma)
      sb.Append(BuildBarCode(WrkListNo, WrkUBType, WrkYear))
      sb.Append(CComma)
      sb.Append(Trim(WrkScanLine))
      sb.Append(CComma)
      sb.Append(Format(WrkBackTaxAmt, "fixed"))
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
      sb.Append(Format(WrkBillTot + WrkBackTaxAmt, "fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(0), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(WrkBrkCode(0)))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(1), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(WrkBrkCode(1)))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(2), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(WrkBrkCode(2)))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(3), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(WrkBrkCode(3)))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(4), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(WrkBrkCode(4)))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(5), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(WrkBrkCode(5)))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(Format(WrkBrkAmt(0) + WrkBrkAmt(1) + WrkBrkAmt(2) + WrkBrkAmt(3), "fixed"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("TotUSAGE")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._CUEDU)
      sb.Append(CComma)
      sb.Append(WrkChgEDU)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkCode)
      sb.Append(CQuote)
      sb.Append(CComma)
      myUTRATEMT.GetOneRecordP(WrkUBType, WrkCode, 99999999)
      If Not myUTRATEMT.RecordNotFound Then
        sb.Append(myUTRATEMT._RMRATE)
      Else
        sb.Append(0)
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
      sb.Append(Mid(WrkYear, 3, 2) & WrkUBType & WrkListNo)
      sb.Append(CComma)
      sb.Append(WrkNumFix)
      sb.Append(CComma)
      sb.Append(._CUFUND)
      sb.Append(CComma)
      sb.Append(WrkRateDesc)
      sb.Append(CComma)
      WrkRateCalcDesc1 = ""
      WrkRateCalcDesc2 = ""
      If myTOWN._TOWNBR = 280 Then 'Norfolk Sewer Dist
        WrkRateCalcDesc1 = Format(._CUUNIT, "fixed") & " Hookup at $" & Format(WrkChgUnit, "Fixed")
        If WrkBrkAmt(0) > 0 Then
          WrkRateCalcDesc2 = Format(WrkTotalUse, "Fixed") & " 1000/GAL at $" & Format(myUTRATEMT._RMRATE, "Fixed")
        Else
          WrkRateCalcDesc2 = ""
        End If
      End If
      sb.Append(CQuote)
      sb.Append(WrkRateCalcDesc1)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkRateCalcDesc2)
      sb.Append(CQuote)
      sb.Append(CComma)
      'MK 9/11/25 Begin
      'If WrkPeriodDesc) = "Annual 2nd Posted" Then
      'sb.Append(Format(WrkTax1 - WrkTax2nd + WrkDelqPrincipal + WrkDelqInterest + WrkDelqLien + WrkDelqFee, "Fixed"))
      If Mid(WrkPeriodDesc, 1, 10) = "Annual 2nd" Then
        sb.Append(Format(WrkBillTot - WrkTax2nd + WrkDelqPrincipal + WrkDelqInterest + WrkDelqLien + WrkDelqFee, "Fixed"))
        'MK 9/11/25 End
        sb.Append(CComma)
      Else
        sb.Append(Format(WrkTax1st + WrkDelqPrincipal + WrkDelqInterest + WrkDelqLien + WrkDelqFee, "Fixed"))
        sb.Append(CComma)
      End If
      If WrkTax1st + WrkDelqPrincipal >= 0 Then
          sb.Append(Format(WrkTax2nd, "Fixed"))
        Else
          sb.Append(Format(WrkBillAmt + WrkDelqPrincipal, "Fixed"))
      End If
      sb.Append(CComma)
      sb.Append(WrkMeterUserChg1)
      sb.Append(CComma)
      sb.Append(WrkMeterUserChg2)
      sb.Append(CComma)
      sb.Append(WrkMeterUserChg3)
    End With
    Return sb.ToString
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("BLBACK - Back Tax?")
    sb.Append(CComma)
    sb.Append("BLACT# - Account #")
    sb.Append(CComma)
    sb.Append("BLYR - Year")
    sb.Append(CComma)
    sb.Append("BLTYPE - Type")
    sb.Append(CComma)
    sb.Append("BLYEAR - Assmnt Year #")
    sb.Append(CComma)
    sb.Append("BLSAWA - Sewer/Water")
    sb.Append(CComma)
    sb.Append("BLADR1 - Address Line 1")
    sb.Append(CComma)
    sb.Append("BLADR1 - Address Line 2")
    sb.Append(CComma)
    sb.Append("BLADR1 - Address Line 3")
    sb.Append(CComma)
    sb.Append("BLADR1 - Address Line 4")
    sb.Append(CComma)
    sb.Append("BLADR5 - Address Line 5")
    sb.Append(CComma)
    sb.Append("BLVOL - Volume")
    sb.Append(CComma)
    sb.Append("BLPAGE - Page")
    sb.Append(CComma)
    sb.Append("BLMAP - Map/Block/Lot")
    sb.Append(CComma)
    sb.Append("BLLOCA - Location")
    sb.Append(CComma)
    sb.Append("BLSTDT - From Service Date")
    sb.Append(CComma)
    sb.Append("BLENDT - To Service Date")
    sb.Append(CComma)
    sb.Append("BLTOT- Total Bill Amount")
    sb.Append(CComma)
    sb.Append("BLBIL - Bill Amount")
    sb.Append(CComma)
    sb.Append("BLTBND - Bond Interest")
    sb.Append(CComma)
    sb.Append("BLCAV - Caveat Amount")
    sb.Append(CComma)
    sb.Append("BLCBAL - Delq Principal")
    sb.Append(CComma)
    sb.Append("BLBILT - Original Assessment")
    sb.Append(CComma)
    sb.Append("BLPLFT - Assmnt Principal Left")
    sb.Append(CComma)
    sb.Append("BLIAMT - Interest Amount")
    sb.Append(CComma)
    sb.Append("BLLAMT - Lien Amount")
    sb.Append(CComma)
    sb.Append("BLINT - Monthly Interest Perc")
    sb.Append(CComma)
    sb.Append("BLMIN - Minimum Interest Charge")
    sb.Append(CComma)
    sb.Append("Current Meter Reading")
    sb.Append(CComma)
    sb.Append("Meter Prev/Reading 1")
    sb.Append(CComma)
    sb.Append("Meter Reading 2")
    sb.Append(CComma)
    sb.Append("Meter Reading 3")
    sb.Append(CComma)
    sb.Append("BLTOTU - Meter Total Use")
    sb.Append(CComma)
    sb.Append("BLBIL1 - Tax 1st Payment")
    sb.Append(CComma)
    sb.Append("BLBIL2 - Tax 2nd Payment")
    sb.Append(CComma)
    sb.Append("BLBIL3- Tax 3rd Payment")
    sb.Append(CComma)
    sb.Append("BLBIL4 - Tax 4th Payment")
    sb.Append(CComma)
    sb.Append("BLUNIT - Units")
    sb.Append(CComma)
    sb.Append("BLCHGU - Charge Per Units")
    sb.Append(CComma)
    sb.Append("BLAPNO - Assmnt Installment #")
    sb.Append(CComma)
    sb.Append("BLDUE1 - 1st Due Date")
    sb.Append(CComma)
    sb.Append("BLDUE2 - 2nd Due Date")
    sb.Append(CComma)
    sb.Append("BLDUE3 - 3rd Due Date")
    sb.Append(CComma)
    sb.Append("BLDUE4 - 4th Due Date")
    sb.Append(CComma)
    sb.Append("BLCHGD - Charge Description")
    sb.Append(CComma)
    sb.Append("BLUSRT - Usage Rate")
    sb.Append(CComma)
    sb.Append("BLOAS - Assmnt Adjustment")
    sb.Append(CComma)
    sb.Append("BRK1A - Break 1 Amount")
    sb.Append(CComma)
    sb.Append("BRK1D - Break 1 Description")
    sb.Append(CComma)
    sb.Append("BRK1A - Break 2 Amount")
    sb.Append(CComma)
    sb.Append("BRK1D - Break 2 Description")
    sb.Append(CComma)
    sb.Append("BRK1A - Break 3 Amount")
    sb.Append(CComma)
    sb.Append("BRK1D - Break 3 Description")
    sb.Append(CComma)
    sb.Append("BMTDSS - Meter Size")
    sb.Append(CComma)
    sb.Append("BLBAR - Bar Code")
    sb.Append(CComma)
    sb.Append("BLSCAN - Scan Line")
    sb.Append(CComma)
    sb.Append("Back Tax Amount")
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
    sb.Append("Total Amt Due")
    sb.Append(CComma)
    sb.Append("Breakout 1 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 1 Code")
    sb.Append(CComma)
    sb.Append("Breakout 2 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 2 Code")
    sb.Append(CComma)
    sb.Append("Breakout 3 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 3 Code")
    sb.Append(CComma)
    sb.Append("Breakout 4 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 4 Code")
    sb.Append(CComma)
    sb.Append("Breakout 5 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 5 Code")
    sb.Append(CComma)
    sb.Append("Breakout 6 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 6 Code")
    sb.Append(CComma)
    sb.Append("Breakout 7 Amt")
    sb.Append(CComma)
    sb.Append("Breakout 7 Code")
    sb.Append(CComma)
    sb.Append("EDUs")
    sb.Append(CComma)
    sb.Append("Charge Per EDU")
    sb.Append(CComma)
    sb.Append("Rate Code")
    sb.Append(CComma)
    sb.Append("Rate Tier 1")
    If MyUBBNK Then
      sb.Append(CComma)
      sb.Append("RE Bank Code")
    End If
    sb.Append(CComma)
    sb.Append("Charge per Fixture")
    sb.Append(CComma)
    sb.Append("Account ID")
    sb.Append(CComma)
    sb.Append("Number of Fixtures")
    sb.Append(CComma)
    sb.Append("Fund")
    sb.Append(CComma)
    sb.Append("Rate Desc")
    sb.Append(CComma)
    sb.Append("Rate Calc Desc1")
    sb.Append(CComma)
    sb.Append("Rate Calc Desc2")
    sb.Append(CComma)
    sb.Append("Tax1st Total Due")
    sb.Append(CComma)
    sb.Append("Tax2nd Total Due")
    sb.Append(CComma)
    sb.Append("Meter User 1 Charge")
    sb.Append(CComma)
    sb.Append("Meter User 2 Charge")
    sb.Append(CComma)
    sb.Append("Meter User 3 Charge")
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
  Public Function GetUTRATEMTDesc(ByVal WrkType As String, ByVal Code As String, ByVal Tier As Integer) As String
    Dim WrkResult As String

    WrkResult = ""
    myUTRATEMT.GetOneRecordP(WrkType, Code, Tier)
    With myUTRATEMT
      If .RecordNotFound Then
      Else
        WrkResult = Trim(._RMDESC)
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
  Private Sub CalcBreakAmts(ByVal WrkBill As Decimal)
    Dim WrkBreakPct As Decimal
    Dim WrkDiff As Decimal

    WrkBreakPct = myUTBREAK._BPCT1 / 100
    WrkBreakAmt1 = Format(WrkBill * WrkBreakPct, "Fixed")

    WrkBreakPct = myUTBREAK._BPCT2 / 100
    WrkBreakAmt2 = Format(WrkBill * WrkBreakPct, "Fixed")

    WrkBreakPct = myUTBREAK._BPCT3 / 100
    WrkBreakAmt3 = Format(WrkBill * WrkBreakPct, "Fixed")

    WrkDiff = WrkBill - WrkBreakAmt1 - WrkBreakAmt2 - WrkBreakAmt3
    If WrkDiff <> 0 Then
      WrkBreakAmt1 = WrkBreakAmt1 + WrkDiff
    End If
  End Sub
End Module
