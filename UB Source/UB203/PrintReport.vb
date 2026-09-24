' 3/ 8/23 Metered: Add EDU split calc and breakout arrays
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTMT As UTCUSTMT.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData
  Dim myTXPROF As TXPROF.MyData
  Dim myTPaymnt As TPAYMNT.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen fields
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkPhase As Integer
  Dim WrkPhas As String
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

  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTMT = New UTCUSTMT.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)

    With MyFrmUB203B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistto = MyUtils.CnvSng(.TxtDistTo.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkPhaseto = MyUtils.CnvSng(.TxtPhaseTo.Text)
      WrkUBType = .TxtUBType.Text
      WrkBillDate = .DtPckBill.Value
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
    Else
      ds.Clear()
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
      .Columns.Add("Units", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmt1", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmt2", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmt3", Type.GetType("System.Decimal"))
      .Columns.Add("BillAmt4", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkTax1st As Decimal
    Dim WrkTax2nd As Decimal
    Dim WrkTax3rd As Decimal
    Dim WrkTax4th As Decimal
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

    'MK 7/17/25 Begin
    'WrkQry = ""
    WrkQry = "RCODE<>'I'"
    'MK 7/17/25 End
    Counter = 0
    If WrkDistto > WrkDist Then
      'MK 7/17/25 Begin
      'WrkQry = "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
      WrkQry = WrkQry & WrkAnd & "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
      'MK 7/17/25 End
    Else
      'MK 7/17/25 Begin
      'WrkQry = "cudst=" & WrkDist
      WrkQry = WrkQry & WrkAnd & "cudst=" & WrkDist
      'MK 7/17/25 End
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
        'filter phase..  cannot go phase to phase in all cases as I can run dist 1 phase 3 to dist 4 phase 2
        wrkaphase = ._CUPHAS
        wrkadist = ._CUDST

        If WrkDist = WrkDistto Then
          If wrkaphase < WrkPhase Or wrkaphase > WrkPhaseto Then GoTo NextRec
        End If
        If WrkDist < WrkDistto Then
          If wrkaphase < WrkPhase And wrkadist = WrkDist Then GoTo NextRec
          If wrkaphase > WrkPhaseto And wrkadist = WrkDistto Then GoTo NextRec
        End If
        ' end phase filter.

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
        WrkPhas = ""
        'Filter - Omit Zero Bills 
        If WrkBillAmt = 0 Then
          GoTo NextRec
        End If

        If MyFrmUB203B.RbPerAnnual.Checked Then
          With myTPaymnt
            .In_ListNo = WrkListNo
            .In_Type = WrkTaxType
            .In_Year = WrkYear
            .In_Dst = wrkadist
            .In_Phs = WrkPhas
            .In_TaxT = WrkBillAmt
            .In_Tax1 = WrkBrkAmt(5) 'EDU
            .CalcPaySplit()
            WrkBillAmt = .Out_TaxT
            WrkTax1st = .Out_Tax1
            WrkTax2nd = .Out_Tax2
            WrkTax3rd = .Out_Tax3
            WrkTax4th = .Out_Tax4
          End With
        End If

        If MyFrmUB203B.RbPer1st.Checked Then
          WrkTax1st = WrkBillAmt
        End If
        If MyFrmUB203B.RbPer2nd.Checked Then
          WrkTax2nd = WrkBillAmt
        End If
        If MyFrmUB203B.RbPer3rd.Checked Then
          WrkTax3rd = WrkBillAmt
        End If
        If MyFrmUB203B.RbPer4th.Checked Then
          WrkTax4th = WrkBillAmt
        End If
        AddrLine = MyUtils.SetAddrLine(._CUNAM1, ._CUNAM2, ._CUADD1, ._CUADD2, ._CUCITY, ._CUST, 0, 0, ._CUZIP)

        'Report
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = WrkListNo
        dr.Item("BillType") = WrkBillDesc
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        Select Case WrkFamily
          Case "A"
            dr.Item("units") = ._CUAUNT
          Case "U"
            dr.Item("units") = ._CUUNIT
        End Select
        dr.Item("billamt") = WrkBillAmt
        dr.Item("billamt1") = WrkTax1st
        dr.Item("billamt2") = WrkTax2nd
        dr.Item("billamt3") = WrkTax3rd
        dr.Item("billamt4") = WrkTax4th
        ds.Tables(0).Rows.Add(dr)
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
      If MyFrmUB203B.RbPerAnnual.Checked Then
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

  Private Function GetRateCode(ByVal WrkUBType As String) As String
    GetRateCode = ""
    myUTCUSTRT.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTRT.RecordNotFound Then Exit Function

    With myUTCUSTRT
      GetRateCode = ._CRCODE
    End With
  End Function
End Module






