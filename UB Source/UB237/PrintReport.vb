Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myUTRATEMT As UTRATEMT.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen fields
  Dim WrkYear As Integer
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As Integer
  Dim WrkDistto As Integer
  Dim WrkPhaseto As Integer
  Dim WrkSortBy As String
  Dim WrkReport As Boolean
  Dim WrkAddress As Boolean
  Dim WrkBillDate As Date

  'Common Work fields
  Dim wrkadist As Integer
  Dim wrkaphase As Integer
  Dim WrkListNo As Integer
  Dim WrkTaxType As String
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCode As String
  'Assessment Work Fields
  Dim WrkOrigAssmnt As Decimal
  Dim WrkBillAmt As Decimal
  Dim WrkBond As Decimal
  Dim WrkBillsLeft As Integer
  Dim WrkYearNo As Integer
  Dim WrkAssmntLeft As Decimal
  Dim WrkAssmntAdjust As Decimal
  'Metered Work Fields
  Dim WrkTotalUse As Integer
  Dim WrkActualUse As Integer
  Dim WrkBrkAmt(5) As Decimal
  Dim WrkBrkCode(5) As String
  Dim WrkBrkPct(5) As Decimal
  Dim WrkChgUnit As Decimal
  Dim WrkRateCalcDesc1 As String
  Dim WrkRateCalcDesc2 As String
  'Totals
  Dim WrkTotTax As Decimal
  Dim WrkTotTax1 As Decimal
  Dim WrkTotTax2 As Decimal
  Dim WrkTotAccts As Integer
  Dim WrkTotUnpaidAccts As Integer
  Dim WrkTotUnpaidBal As Decimal

  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myUTRATEMT = New UTRATEMT.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    With MyFrmUB237B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistto = MyUtils.CnvSng(.TxtDistTo.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkPhaseto = MyUtils.CnvSng(.TxtPhaseTo.Text)
      WrkUBType = .TxtUBType.Text
      WrkBillDate = .DtPckBill.Value
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      If WrkDist = 0 And WrkDistto = 0 Then
        WrkDistto = 999
        If WrkPhase = 0 And WrkPhaseto = 0 Then
          WrkPhaseto = 9
        End If
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortLocation.Checked Then
        WrkSortBy = "Location"
      End If
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDS2()
    Else
      ds.Clear()
      ds2.Clear()
      ClearTotals()
    End If

    GetDetail()
    If ds.Tables(0).Rows.Count = 0 Then
      MsgBox("Returning to selection screen", MsgBoxStyle.Information, "No records found for report")
      Exit Sub
    End If

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = ds2
      .WrkUBType = WrkUBType
      Select Case WrkSortBy
        Case "List"
          .Wrksort = "By List"
        Case "Name"
          .Wrksort = "By Name"
        Case "Location"
          .Wrksort = "By Location"
      End Select
      .Wrkdistphase = "District / Phase " + WrkDist.ToString + " / " + WrkPhase.ToString _
    + " To: " + WrkDistto.ToString + " / " + WrkPhaseto.ToString
      .Show()
    End With


  End Sub
  Private Sub ClearTotals()
    WrkTotTax = 0
    WrkTotTax1 = 0
    WrkTotTax2 = 0
    WrkTotAccts = 0
    WrkTotUnpaidAccts = 0
    WrkTotUnpaidBal = 0
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("BillCalc1", Type.GetType("System.String"))
      .Columns.Add("BillCalc2", Type.GetType("System.String"))
      .Columns.Add("TaxDue", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2", Type.GetType("System.Decimal"))
      .Columns.Add("UnpaidTX", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("LienPaid", Type.GetType("System.Decimal"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
      .Columns.Add("CCETax", Type.GetType("System.Decimal"))
      .Columns.Add("CCTx1", Type.GetType("System.Decimal"))
      .Columns.Add("CCTx2", Type.GetType("System.Decimal"))
      .Columns.Add("UnpaidCC", Type.GetType("System.Decimal"))
      .Columns.Add("Pamt1", Type.GetType("System.Decimal"))
      .Columns.Add("PDate1", Type.GetType("System.DateTime"))
      .Columns.Add("Batch1", Type.GetType("System.Int32"))
      .Columns.Add("Pamt2", Type.GetType("System.Decimal"))
      .Columns.Add("PDate2", Type.GetType("System.DateTime"))
      .Columns.Add("Batch2", Type.GetType("System.Int32"))
      .Columns.Add("Pamt3", Type.GetType("System.Decimal"))
      .Columns.Add("PDate3", Type.GetType("System.DateTime"))
      .Columns.Add("Batch3", Type.GetType("System.Int32"))
      .Columns.Add("Pamt4", Type.GetType("System.Decimal"))
      .Columns.Add("PDate4", Type.GetType("System.DateTime"))
      .Columns.Add("Batch4", Type.GetType("System.Int32"))
      .Columns.Add("Pamt5", Type.GetType("System.Decimal"))
      .Columns.Add("PDate5", Type.GetType("System.DateTime"))
      .Columns.Add("Batch5", Type.GetType("System.Int32"))
      .Columns.Add("Pamt6", Type.GetType("System.Decimal"))
      .Columns.Add("PDate6", Type.GetType("System.DateTime"))
      .Columns.Add("Batch6", Type.GetType("System.Int32"))
      .Columns.Add("Pamt7", Type.GetType("System.Decimal"))
      .Columns.Add("PDate7", Type.GetType("System.DateTime"))
      .Columns.Add("Batch7", Type.GetType("System.Int32"))
      .Columns.Add("Pamt8", Type.GetType("System.Decimal"))
      .Columns.Add("PDate8", Type.GetType("System.DateTime"))
      .Columns.Add("Batch8", Type.GetType("System.Int32"))
      .Columns.Add("Pamt9", Type.GetType("System.Decimal"))
      .Columns.Add("PDate9", Type.GetType("System.DateTime"))
      .Columns.Add("Batch9", Type.GetType("System.Int32"))
      .Columns.Add("Pamt10", Type.GetType("System.Decimal"))
      .Columns.Add("PDate10", Type.GetType("System.DateTime"))
      .Columns.Add("Batch10", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDS2()
    Dim myTable2 As New DataTable
    With myTable2
      .TableName = "mytable2"
      .Columns.Add("ttax", Type.GetType("System.Decimal"))
      .Columns.Add("ttax1", Type.GetType("System.Decimal"))
      .Columns.Add("ttax2", Type.GetType("System.Decimal"))
      .Columns.Add("taccts", Type.GetType("System.Int32"))
      .Columns.Add("tunpaidaccts", Type.GetType("System.Int32"))
      .Columns.Add("tunpaidbal", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)
  End Sub

  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkTaxT As Decimal
    Dim WrkTax1st As Decimal
    Dim WrkTax2nd As Decimal
    Dim WrkTax3rd As Decimal
    Dim WrkTax4th As Decimal
    Dim WrkPaid As Decimal
    Dim WrkIntPaid As Decimal
    Dim WrkLienPaid As Decimal
    Dim WrkCC As Boolean
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim Counter As Integer
    Dim WrkAnd As String

    WrkFamily = GetUTTYPEFamily(WrkUBType)
    WrkTaxType = GetUTTYPETaxType(WrkUBType)

    myTXPROF.GetOneRecordP(WrkTaxType, WrkYear, "", 0)
    If myTXPROF.RecordNotFound Then
      MsgBox("Add year " & WrkYear, MsgBoxStyle.Critical, "Tax Profile missing")
      Exit Sub
    End If

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "RCODE<>'I'"
    Counter = 0
    If WrkDistto > WrkDist Then
      WrkQry = WrkQry & WrkAnd & "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
    Else
      WrkQry = WrkQry & WrkAnd & "cudst=" & WrkDist
    End If

    WrkSort = ""
    Select Case WrkSortBy
      Case "List"
        WrkSort = "CUACCT"
      Case "Name"
        WrkSort = "CUNAM1"
      Case "Location"
        WrkSort = "CULOC, CULOC#"
    End Select

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
        wrkaphase = ._CUPHAS
        wrkadist = ._CUDST

        If WrkDist = WrkDistto Then
          If wrkaphase < WrkPhase Or wrkaphase > WrkPhaseto Then GoTo NextRec
        End If
        If WrkDist < WrkDistto Then
          If wrkaphase < WrkPhase And wrkadist = WrkDist Then GoTo NextRec
          If wrkaphase > WrkPhaseto And wrkadist = WrkDistto Then GoTo NextRec
        End If

        WrkListNo = ._CUACCT
        WrkCode = GetRateCode(WrkUBType)

        If Trim(WrkCode) = "" Then GoTo NextRec
        Array.Clear(WrkBrkAmt, 0, 6)
        Array.Clear(WrkBrkAmt, 0, 6)
        Select Case WrkFamily
          Case "A"
            CalcAssmnt(I)
          Case "M"
            CalcMetered(I)
          Case "U"
            CalcUsage(I)
        End Select
        'Filter - Omit Zero Bills 
        If WrkBillAmt = 0 Then
          GoTo NextRec
        End If

        'Report
        WrkTotAccts += 1
        dr = ds.Tables(0).NewRow
        AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)
        With myTXINV
          .GetOneRecordP(WrkListNo, WrkYear, WrkTaxType)
          WrkTaxT = ._TAXT
          WrkTax1st = ._TAX1
          WrkTax2nd = ._TAX2
          WrkTax3rd = ._TX3RD
          WrkTax4th = ._TX4TH
          WrkCC = False
          If ._CCNO > 0 Then
            WrkCC = True
          End If
          dr.Item("ccno") = ._CCNO
          dr.Item("ccetax") = ._CCETAX
          dr.Item("unpaidcc") = ._CCETAX - WrkPaid
          dr.Item("ccdate") = MyUtils.GetDBDate(._CDATE)
          dr.Item("cctx1") = ._CCTX1
          dr.Item("cctx2") = ._CCTX2
          If dr.Item("unpaidcc") < 0 Then
            dr.Item("unpaidcc") = 0
          End If
        End With
        GetHistory(WrkListNo, WrkYear, WrkPaid, WrkIntPaid, WrkLienPaid)
        If WrkCC Then
          dr.Item("unpaidtx") = 0
        Else
          dr.Item("unpaidtx") = WrkTaxT - WrkPaid
          dr.Item("unpaidcc") = 0
        End If
        If dr.Item("unpaidtx") < 0 Then
          dr.Item("unpaidtx") = 0
        End If

        dr.Item("listno") = WrkListNo
        dr.Item("BillType") = WrkBillDesc
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("propdesc") = GetPropDesc()
        'MK 10/20/25 Begin
        WrkChgUnit = 0
        If WrkBillAmt > 0 Then
          Select Case WrkFamily
            Case "M", "U"
              If ._CUUNIT > 0 Then
                WrkChgUnit = WrkBrkAmt(2) / ._CUUNIT
              End If
          End Select
        End If
        WrkRateCalcDesc1 = ""
        WrkRateCalcDesc2 = ""
        myUTRATEMT.GetOneRecordP(WrkUBType, WrkCode, 99999999)
        If myTOWN._TOWNBR = 280 Then 'Norfolk Sewer Dist
          WrkRateCalcDesc1 = Format(._CUUNIT, "fixed") & " Hookup at $" & Format(WrkChgUnit, "Fixed")
          If WrkBrkAmt(0) > 0 Then
            WrkRateCalcDesc2 = Format(WrkTotalUse, "Fixed") & " 1000/GAL at $" & Format(myUTRATEMT._RMRATE, "Fixed")
          Else
            WrkRateCalcDesc2 = ""
          End If
        End If
        dr.Item("billcalc1") = WrkRateCalcDesc1
        dr.Item("billcalc2") = WrkRateCalcDesc2
        'MK 10/20/25 End
        dr.Item("propdesc") = GetPropDesc()
        dr.Item("taxdue") = WrkTaxT
        dr.Item("tax1") = WrkTax1st
        dr.Item("tax2") = WrkTax2nd
        dr.Item("intpaid") = WrkIntPaid
        dr.Item("lienpaid") = WrkLienPaid
        ds.Tables(0).Rows.Add(dr)

        If WrkCC Then
          WrkTotTax = WrkTotTax + dr.Item("ccetax")
          WrkTotTax1 = WrkTotTax1 + dr.Item("cctx1")
          WrkTotTax2 = WrkTotTax2 + dr.Item("cctx2")
          If dr.Item("unpaidcc") > 0 Then
            WrkTotUnpaidAccts = WrkTotUnpaidAccts + 1
            WrkTotUnpaidBal = WrkTotUnpaidBal + dr.Item("unpaidcc")
          End If
        Else
          WrkTotTax = WrkTotTax + WrkTaxT
          WrkTotTax1 = WrkTotTax1 + WrkTax1st
          WrkTotTax2 = WrkTotTax2 + WrkTax2nd
          If dr.Item("unpaidtx") > 0 Then
            WrkTotUnpaidAccts = WrkTotUnpaidAccts + 1
            WrkTotUnpaidBal = WrkTotUnpaidBal + dr.Item("unpaidtx")
          End If
        End If
      End With

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

    dr = ds2.Tables(0).NewRow
    dr.Item("ttax") = WrkTotTax
    dr.Item("ttax1") = WrkTotTax1
    dr.Item("ttax2") = WrkTotTax2
    dr.Item("taccts") = WrkTotAccts
    dr.Item("tunpaidaccts") = WrkTotUnpaidAccts
    dr.Item("tunpaidbal") = WrkTotUnpaidBal
    ds2.Tables(0).Rows.Add(dr)

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub

  Private Sub CalcAssmnt(ByVal I As Integer)
    Dim MyUBCalcBillA As UBCalcBill.BillAssessment
    Dim MyUBCalcBillAmort As UBCalcBill.Amort

    MyUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBillAmort = New UBCalcBill.Amort(myDBConnect)

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkBillAmt = 0
    WrkBond = 0
    WrkBillsLeft = 0

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

    With MyUBCalcBillAmort
      .In_OrigBill = MyUBCalcBillA.Out_OrigBill
      .In_AmtLeft = MyUBCalcBillA.Out_AmtLeft
      .In_Balance = 0  'dont need balance  was cubal which was replaced.
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = myUTCUSTAS._CAPNO
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBond = MyUtils.FmtCurrency(.Out_Bond)
      WrkBillsLeft = .Out_BillsLeft
    End With

    With myUTCUSTAS
      If WrkBillAmt > 0 Then
        WrkYearNo = ._CAPNO + 1
      Else
        WrkYearNo = 0
      End If
      WrkAssmntAdjust = ._CAADJ
    End With
  End Sub
  Private Sub CalcMetered(ByVal I As Integer)
    Dim MyUBCalcReading As UBCalcReading.MyData
    Dim MyUBCalcBill As UBCalcBill.MeteredUse
    Dim MyUBCalcBill2 As UBCalcBill.BillMetered
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkReading2 As Integer
    Dim WrkReading3 As Integer

    MyUBCalcReading = New UBCalcReading.MyData(myDBConnect)
    MyUBCalcBill = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBill2 = New UBCalcBill.BillMetered(myDBConnect)

    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkUBType
      If MyFrmUB237B.RbPerAnnual.Checked Then
        .In_AnnualBill = True
      Else
        .In_AnnualBill = False
      End If
      .In_BillDate = WrkBillDate
      .GetMeterReadings()
      WrkReadingCurr = .Out_MeterReadCurr
      WrkReadingPrev = .Out_MeterReadPrev
      WrkReading2 = .Out_MeterRead2
      WrkReading3 = .Out_MeterRead3
    End With

    With MyUBCalcBill
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
    End With

    With MyUBCalcBill2
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_TotalUse = MyUBCalcBill.Out_TotalUse
      .In_MinBill = MyUBCalcBill.Out_MinBill
      .In_UseMinCharge = MyUBCalcBill.Out_UseMinCharge
      .In_UnitCharge = MyUBCalcBill.Out_UnitCharge
      .In_MarkupPct = MyUBCalcBill.Out_MarkupPct
      .In_EDUCharge = MyUBCalcBill.Out_EDUCharge
      .In_User1Charge = MyUBCalcBill.Out_User1Charge
      .In_User2Charge = MyUBCalcBill.Out_User2Charge
      .In_User3Charge = MyUBCalcBill.Out_User3Charge
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
      WrkBrkAmt(4) = .Out_MarkupPart
      WrkBrkCode(4) = "MARKUP"
      WrkBrkAmt(5) = .Out_EDUPart
      WrkBrkCode(5) = "EDU"
    End With
  End Sub
  Public Function GetMeterReadings() As Integer()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim MaxI As Integer
    Dim Reading(14) As Integer

    ds2 = myUTCUSTMT.GetAllListNo(WrkListNo, WrkUBType, 0, 0)
    If ds2.Tables(0).Rows.Count = 0 Then
      ds2.Clear()
      ds2 = myUTCUSTMT.GetAllListNo(WrkListNo, "", 0, 0)
    End If

    'Only get Last 15 readings
    MaxI = ds2.Tables(0).Rows.Count - 1
    If MaxI > 14 Then MaxI = 14

    For I = 0 To MaxI
      With ds2.Tables(0).Rows(I)
        Reading(I) = .Item("cmread")
      End With
    Next

    Return Reading
  End Function
  Private Sub CalcUsage(ByVal I As Integer)
    Dim MyUBCalcBillU As UBCalcBill.BillUsage

    MyUBCalcBillU = New UBCalcBill.BillUsage(myDBConnect)
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
      .In_Extras = myUTCUSTQ._CUXTRA
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = myUTCUSTQ._CUEDU
      End If
      .CalcUsage()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
    End With

  End Sub
  Private Sub GetHistory(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, ByRef Out_Paid As Decimal,
 ByRef Out_IntPaid As Decimal, ByRef Out_LienPaid As Decimal)
    Dim DsTXHST As DataSet = New DataSet
    Dim I As Integer
    Dim J As Integer
    Dim WrkPamt(9) As Decimal
    Dim WrkPdate(9) As Integer
    Dim WrkBatch(9) As Integer

    Out_Paid = 0
    Out_IntPaid = 0
    Out_LienPaid = 0
    DsTXHST = myTXHSTL4.GetViewbyList(WrkListNo, WrkYear, WrkTaxType, WrkFrom, 999999)
    If DsTXHST.Tables(0).Rows.Count = 0 Then
      dr.Item("pamt1") = 0
      Exit Sub
    End If

    For I = 0 To (DsTXHST.Tables(0).Rows.Count - 1)
      With DsTXHST.Tables(0).Rows(I)
        If .Item("rcode") <> "I" And .Item("rcode") <> "V" Then
          If .Item("pdate") > WrkTo Then Exit For
          Out_IntPaid = Out_IntPaid + .Item("iamt")
          Out_LienPaid = Out_LienPaid + .Item("lamt")
          Out_Paid = Out_Paid + .Item("pamt")
          If .Item("pamt") <> 0 Then
            If J < 10 Then
              WrkPamt(J) = .Item("Pamt")
              WrkPdate(J) = .Item("Pdate")
              WrkBatch(J) = .Item("batchn")
              J = J + 1
            End If
          End If
        End If
      End With
    Next

    If WrkPamt(0) = 0 Then
      dr.Item("pamt1") = 0
      Exit Sub
    End If

    dr.Item("pamt1") = WrkPamt(0)
    dr.Item("pdate1") = MyUtils.GetDBDate(WrkPdate(0))
    dr.Item("batch1") = WrkBatch(0)
    dr.Item("pamt2") = WrkPamt(1)
    dr.Item("pdate2") = MyUtils.GetDBDate(WrkPdate(1))
    dr.Item("batch2") = WrkBatch(1)
    dr.Item("pamt3") = WrkPamt(2)
    dr.Item("pdate3") = MyUtils.GetDBDate(WrkPdate(2))
    dr.Item("batch3") = WrkBatch(2)
    dr.Item("pamt4") = WrkPamt(3)
    dr.Item("pdate4") = MyUtils.GetDBDate(WrkPdate(3))
    dr.Item("batch4") = WrkBatch(3)
    dr.Item("pamt5") = WrkPamt(4)
    dr.Item("pdate5") = MyUtils.GetDBDate(WrkPdate(4))
    dr.Item("batch5") = WrkBatch(4)
    dr.Item("pamt6") = WrkPamt(5)
    dr.Item("pdate6") = MyUtils.GetDBDate(WrkPdate(5))
    dr.Item("batch6") = WrkBatch(5)
    dr.Item("pamt7") = WrkPamt(6)
    dr.Item("pdate7") = MyUtils.GetDBDate(WrkPdate(6))
    dr.Item("batch7") = WrkBatch(6)
    dr.Item("pamt8") = WrkPamt(7)
    dr.Item("pdate8") = MyUtils.GetDBDate(WrkPdate(7))
    dr.Item("batch8") = WrkBatch(7)
    dr.Item("pamt9") = WrkPamt(8)
    dr.Item("pdate9") = MyUtils.GetDBDate(WrkPdate(8))
    dr.Item("batch9") = WrkBatch(8)
    dr.Item("pamt10") = WrkPamt(9)
    dr.Item("pdate10") = MyUtils.GetDBDate(WrkPdate(9))
    dr.Item("batch10") = WrkBatch(9)
  End Sub
  Private Function GetRateCode(ByVal WrkUBType As String) As String
    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
  Private Function GetPropDesc() As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    With myTXINV
      sb.Append(Trim(._LOCNo))
      sb.Append(" ")
      sb.Append(Trim(._LOC))
    End With
    Return sb.ToString
  End Function
End Module
