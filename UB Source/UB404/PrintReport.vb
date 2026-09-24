Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myUTCUSTQ As UTCUSTQ.MyData
  Dim myUTCUSTAS As UTCUSTAS.MyData
  Dim myUTCUSTRT As UTCUSTRT.MyData

  Dim ds As DataSet = New DataSet
  Dim DsUTCUST As DataSet = New DataSet
  Dim dr As Data.DataRow

  'Screen fields
  Dim WrkDist As Integer
  Dim WrkPhase As Integer
  Dim WrkDistto As Integer
  Dim WrkPhaseto As Integer
  Dim WrkSortBy As String
  Dim WrkReport As Boolean
  Dim WrkAddress As Boolean

  'Common Work fields
  Dim wrkadist As Integer
  Dim wrkaphase As Integer
  Dim WrkListNo As Integer
  Dim WrkTaxType As String
  Dim WrkUBType As String
  Dim WrkBillDesc As String
  Dim WrkFamily As String
  Dim WrkCode As String
  Dim WrkMeterReadingDate As Date

  'Assessment Work Fields
  Dim WrkOrigAssmnt As Decimal
  Dim WrkBillAmt As Decimal
  Dim WrkReading As Long
  Dim WrkTaxTotal As Decimal
  Dim WrkBond As Decimal
  Dim WrkBillsLeft As Integer
  Dim WrkYearNo As Integer
  Dim WrkAssmntLeft As Decimal
  Dim WrkAssmntAdjust As Decimal
  'Deliquent work fields
  Dim WrkDelqInterest As Decimal
  Dim WrkDelqLien As Decimal
  Dim WrkDelqBond As Decimal
  Dim WrkDelqPrincipal As Decimal
  'Assessment Calcs
  Dim MyUBCalcBillA As UBCalcBill.BillAssessment
  Dim MyUBCalcBillAmort As UBCalcBill.Amort
  'Metered Calcs
  Dim MyUBCalcReading As UBCalcReading.MyData
  Dim MyUBCalcBillMeter As UBCalcBill.MeteredUse
  Dim MyUBCalcBillM As UBCalcBill.BillMetered
  'Usage Calcs
  Dim MyUBCalcBillU As UBCalcBill.BillUsage
  Public Sub PrtReport()
    myUTCUSTQ = New UTCUSTQ.MyData(myDBConnect)
    myUTCUSTAS = New UTCUSTAS.MyData(myDBConnect)
    myUTCUSTRT = New UTCUSTRT.MyData(myDBConnect)
    MyUBCalcBillA = New UBCalcBill.BillAssessment(myDBConnect)
    MyUBCalcBillAmort = New UBCalcBill.Amort(myDBConnect)
    MyUBCalcReading = New UBCalcReading.MyData(myDBConnect)
    MyUBCalcBillMeter = New UBCalcBill.MeteredUse(myDBConnect)
    MyUBCalcBillM = New UBCalcBill.BillMetered(myDBConnect)
    MyUBCalcBillU = New UBCalcBill.BillUsage(myDBConnect)

    With MyFrmUB404B
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistto = MyUtils.CnvSng(.TxtDistTo.Text)
      WrkPhase = MyUtils.CnvSng(.TxtPhase.Text)
      WrkPhaseto = MyUtils.CnvSng(.TxtPhaseTo.Text)
      WrkUBType = .TxtUBType.Text
      WrkMeterReadingDate = .DtPckRead.Value
    End With

    If WrkDist = 0 And WrkDistto = 0 Then
      WrkDistto = 999
      If WrkPhase = 0 And WrkPhaseto = 0 Then
        WrkPhaseto = 9
      End If
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .WrkUBType = WrkUBType
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
      .Columns.Add("BillAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Reading", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim WrkAnd As String

    WrkFamily = GetUTTYPEFamily(WrkUBType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = ""

    If WrkDistto > WrkDist Then
      WrkQry = "cudst>=" & WrkDist & WrkAnd & "cudst<=" & WrkDistto
    Else
      WrkQry = "cudst=" & WrkDist
    End If

    WrkSort = "CUACCT"
    DsUTCUST = myUTCUSTQ.GetQry(WrkSort, WrkQry, 0)

    If DsUTCUST.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    For I = 0 To (DsUTCUST.Tables(0).Rows.Count - 1)
      With DsUTCUST.Tables(0).Rows(I)

        'filter phase..  cannot go phae to phase in call cases  as i can run dist 1 phase 3 to dist 4 phase 2
        wrkaphase = .Item("cuphas")
        wrkadist = .Item("cudst")

        If WrkDist = WrkDistto Then
          If wrkaphase < WrkPhase Or wrkaphase > WrkPhaseto Then GoTo NextRec
        End If
        If WrkDist < WrkDistto Then
          If wrkaphase < WrkPhase And wrkadist = WrkDist Then GoTo NextRec
          If wrkaphase > WrkPhaseto And wrkadist = WrkDistto Then GoTo NextRec
        End If
        ' end phase filter.

        WrkListNo = .Item("cuacct")
        WrkCode = GetRateCode(WrkUBType)

        If Trim(WrkCode) = "" Then GoTo NextRec

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

        AddrLine = MyUtils.SetAddrLine(.Item("cunam1"), .Item("cunam2"), .Item("cuadd1"),
      .Item("cuadd2"), .Item("cucity"), .Item("cust"), 0, 0, .Item("cuzip"))
      End With

      'Report
      dr = ds.Tables(0).NewRow
      dr.Item("listno") = WrkListNo
      dr.Item("BillType") = WrkBillDesc
      dr.Item("billamt") = WrkBillAmt
      dr.Item("reading") = WrkReading
      ds.Tables(0).Rows.Add(dr)

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsUTCUST.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    myFrmProgress.Close()
    myUTCUSTQ.CloseFile()
  End Sub
  Private Sub CalcAssmnt(ByVal I As Integer)

    WrkOrigAssmnt = 0
    WrkAssmntLeft = 0
    WrkBillAmt = 0
    WrkBond = 0
    WrkTaxTotal = 0

    myUTCUSTAS.GetOneRecordP(WrkListNo, WrkUBType)
    If myUTCUSTAS.RecordNotFound Then Exit Sub

    With MyUBCalcBillA
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_DwellUnits = DsUTCUST.Tables(0).Rows(I).Item("cuaunt")
      .In_PropVal = DsUTCUST.Tables(0).Rows(I).Item("cupval")
      .In_Footage = DsUTCUST.Tables(0).Rows(I).Item("cufoot")
      .In_Acreage = DsUTCUST.Tables(0).Rows(I).Item("cuacre")
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
      .In_Balance = 0
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      .In_NumBills = myUTCUSTAS._CAPNO
      .In_OverrideBill = myUTCUSTAS._CAOVR
      .In_PctDeferred = myUTCUSTAS._CADEP
      .CalcAmort()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
      WrkBond = MyUtils.FmtCurrency(.Out_Bond)
      WrkTaxTotal = MyUtils.FmtCurrency(.Out_Bill + .Out_Bond)
    End With
  End Sub
  Private Sub CalcMetered(ByVal I As Integer)
    Dim WrkReadingCurr As Integer
    Dim WrkReadingPrev As Integer
    Dim WrkReading2 As Integer
    Dim WrkReading3 As Integer

    WrkReading = 0
    With MyUBCalcReading
      .In_ListNo = WrkListNo
      .In_RateType = WrkUBType
      If MyFrmUB404B.RbPerAnnual.Checked Then
        .In_AnnualBill = True
      Else
        .In_AnnualBill = False
      End If
      .In_BillDate = WrkMeterReadingDate
      .GetMeterReadings()
      WrkReadingCurr = .Out_MeterReadCurr
      WrkReadingPrev = .Out_MeterReadPrev
      WrkReading2 = .Out_MeterRead2
      WrkReading3 = .Out_MeterRead3
    End With

    With MyUBCalcBillMeter
      .In_RateType = WrkUBType
      .In_MeterSize = DsUTCUST.Tables(0).Rows(I).Item("cumsiz")
      .In_MeterReadCurr = WrkReadingCurr
      .In_MeterReadPrev = WrkReadingPrev
      .In_MeterRead2 = WrkReading2
      .In_MeterRead3 = WrkReading3
      .In_Units = DsUTCUST.Tables(0).Rows(I).Item("cuunit")
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = DsUTCUST.Tables(0).Rows(I).Item("cuedu")
      End If
      .CalcMeteredUse()
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
      WrkReading = MyUBCalcBillMeter.Out_TotalUse
    End With

    WrkTaxTotal = WrkBillAmt
  End Sub
  Private Sub CalcUsage(ByVal I As Integer)
    With MyUBCalcBillU
      .In_RateType = WrkUBType
      .In_RateCode = WrkCode
      If WrkUBType = "U" Then
        .In_Fixtures = DsUTCUST.Tables(0).Rows(I).Item("cusfix")
        .In_SurChg = DsUTCUST.Tables(0).Rows(I).Item("cuschr")
      Else
        .In_Fixtures = DsUTCUST.Tables(0).Rows(I).Item("cuwfix")
        .In_SurChg = 0
      End If
      .In_Units = DsUTCUST.Tables(0).Rows(I).Item("cuunit")
      .In_Extras = DsUTCUST.Tables(0).Rows(I).Item("cuxtra")
      If MyEDU1 Then
        .In_EDUs = 1
      Else
        .In_EDUs = DsUTCUST.Tables(0).Rows(I).Item("cuedu")
      End If
      .CalcUsage()
      WrkBillAmt = MyUtils.FmtCurrency(.Out_Bill)
    End With

    WrkTaxTotal = WrkBillAmt
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






