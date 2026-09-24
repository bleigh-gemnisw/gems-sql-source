Module PrintForms
	 Dim myTXFMSTMT As TXFMSTMT.myData
	 Dim myTXENDRS As TXENDRS.myData
   Dim myTXINV As TXINV.myData
   Dim myTXINV2 As TXINV.myData
   Dim myTXHSTL3 As TXHSTL3.myData
   Dim myTXMRATE As TXMRATE.myData
   Dim myTXCOEA As TXCOEA.myData
   Dim myTXPROF As TXPROF.myData
   Dim myCASHINT As CASHINT.MyData
   Dim myCASHINT2 As CASHINT.MyData
   Dim ds2 As DataSet

	Public Sub PrtReceipt(ByVal Wrkds As DataSet, ByVal WrkValidation As Boolean, ByVal WrkReceipt As Boolean)
	 Dim myreportK As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	 Dim myreportK2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	 Dim ReportPath As String
	 Dim WrkHeading As String
	 Dim WrkHeading2 As String
	 Dim WrkReceiptHeading As String
	 Dim WrkReceiptHeading2 As String
   Dim Good As Boolean

   If MyAppSettings.ValidatePrinter <> "" Then
      Good = MyUtils.CheckPrinterExists(MyAppSettings.ValidatePrinter)
      If Not Good Then
        MsgBox("Validation Printer " & MyAppSettings.ValidatePrinter & " does not exist. Click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Exit Sub
      End If
    End If

   If MyAppSettings.ReceiptPrinter <> "" Then
      Good = MyUtils.CheckPrinterExists(MyAppSettings.ReceiptPrinter)
      If Not Good Then
        MsgBox("Receipt Printer " & MyAppSettings.ReceiptPrinter & " does not exist. Click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Exit Sub
      End If
    End If

  If MyAppSettings.ValidateModel = "TM-U675" Then
   ReportPath = MyUtils.GetReportPath("PrtTXA09KB.rpt", myTOWN._TOWNBR)
  Else
   ReportPath = MyUtils.GetReportPath("PrtTXA09K.rpt", myTOWN._TOWNBR)
  End If
   WrkHeading = Trim(Replace(myTOWN._TOWN, "TOWN OF ", String.Empty, 1, -1, CompareMethod.Text))
   WrkHeading2 = String.Empty
   WrkReceiptHeading = WrkHeading
   WrkReceiptHeading2 = WrkHeading2

   'Salem
   If myTOWN._TOWNBR = 121 Then
     WrkReceiptHeading = Trim(myTOWN._TOWN)
     WrkReceiptHeading2 = "Retain for your records"
   End If

   If WrkValidation Then
     With myreportK
      .Load(ReportPath)
      .PrintOptions.PrinterName = MyAppSettings.ValidatePrinter
      .SetDataSource(Wrkds)
      .SetParameterValue("MyHeading", WrkHeading)
      .SetParameterValue("MyHeading2", WrkHeading2)
      .SetParameterValue("MyValidateTotal", MyAppSettings.ValidateTotal)
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
     End With
   End If

  'Added next for customer receipt production
  If WrkReceipt Then
    With myreportK2
      .Load(ReportPath)
      .PrintOptions.PrinterName = MyAppSettings.ReceiptPrinter
      .SetDataSource(Wrkds)
      .SetParameterValue("MyHeading", WrkReceiptHeading)
      .SetParameterValue("MyHeading2", WrkReceiptHeading2)
      .SetParameterValue("MyValidateTotal", MyAppSettings.ValidateTotal)
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
    End With
   End If
End Sub
  Public Sub PrtEndorse(ByVal WrkBatchSeqNo As Long, ByVal WrkTotDue As Decimal)
    'This report must be external due to printer issues (only prints blank lines)
    Dim WrkDate As String
    Dim myreportL As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim ReportPath As String

    WrkDate = Format(MyReceiptDate, "M/d/yyyy")
    If MyAppSettings.ValidateModel = "TM-U675" Then
      ReportPath = MyUtils.GetReportPath("PrtTXA09LB.rpt", myTOWN._TOWNBR)
    Else
      ReportPath = MyUtils.GetReportPath("PrtTXA09L.rpt", myTOWN._TOWNBR)
    End If
    With myreportL
      .Load(ReportPath)
      .PrintOptions.PrinterName = MyAppSettings.ValidatePrinter
      .SetParameterValue("MyUserID", MyUserID)
      .SetParameterValue("EL1", Trim(myTXENDRS._EL1))
      .SetParameterValue("EL2", Trim(myTXENDRS._EL2))
      .SetParameterValue("EL3", Trim(myTXENDRS._EL3))
      .SetParameterValue("EL4", Trim(myTXENDRS._EL4))
      .SetParameterValue("EL5", Trim(myTXENDRS._EL5))
      .SetParameterValue("EL6", Trim(myTXENDRS._EL6))
      .SetParameterValue("EL7", Trim(myTXENDRS._EL7))
      .SetParameterValue("EL8", Trim(myTXENDRS._EL8))
      .SetParameterValue("MyBatchNo", MyBatchNo)
      .SetParameterValue("MyBatchSeqNo", WrkBatchSeqNo)
      .SetParameterValue("MyRecDt", WrkDate)
      .SetParameterValue("TotalDue", WrkTotDue)
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
    End With
  End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    ds2 = New DataSet
    With myTable
      .TableName = "mytable2"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("AcctID", Type.GetType("System.String"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Bank", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("MillRT", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("Tax3rd", Type.GetType("System.Decimal"))
      .Columns.Add("Tax4th", Type.GetType("System.Decimal"))
      .Columns.Add("OtherTot", Type.GetType("System.Decimal"))
      .Columns.Add("Other1st", Type.GetType("System.Decimal"))
      .Columns.Add("Other2nd", Type.GetType("System.Decimal"))
      .Columns.Add("BillTot", Type.GetType("System.Decimal"))
      .Columns.Add("Bill1st", Type.GetType("System.Decimal"))
      .Columns.Add("Bill2nd", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("DueDt1", Type.GetType("System.String"))
      .Columns.Add("DueDt2", Type.GetType("System.String"))
      .Columns.Add("DueDt3", Type.GetType("System.String"))
      .Columns.Add("DueDt4", Type.GetType("System.String"))
      .Columns.Add("PayRec", Type.GetType("System.Decimal"))
      .Columns.Add("BondPaid", Type.GetType("System.Decimal"))
      .Columns.Add("IntPaid", Type.GetType("System.Decimal"))
      .Columns.Add("LastPayDt", Type.GetType("System.String"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("UnPaidTax", Type.GetType("System.Decimal"))
      .Columns.Add("UnPaidBond", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("BarCode", Type.GetType("System.String"))
      .Columns.Add("InterestDt", Type.GetType("System.DateTime"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDt", Type.GetType("System.String"))
      .Columns.Add("StateBen", Type.GetType("System.Decimal"))
      .Columns.Add("LocalBen", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
  Sub AddOneRecord(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer,
 ByVal WrkInterestDate As Date)
    Dim myDr As Data.DataRow
    Dim AddrLine As String()
    Dim WrkName As String
    Dim WrkName2 As String
    Dim WrkFamily As String
    Dim WrkPhase As String

    myCASHINT = New CASHINT.MyData(myDBConnect)
    myCASHINT2 = New CASHINT.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINV2 = New TXINV.MyData(myDBConnect)
    myTXMRATE = New TXMRATE.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)
    myTXCOEA = New TXCOEA.MyData(myDBConnect)

    With myCASHINT
      .In_IntDate = WrkInterestDate
      .In_ListNo = WrkListNo
      .In_Type = WrkType
      .In_Year = WrkYear
      .CalcInterest()
    End With
    myDr = ds2.Tables(0).NewRow
    With myTXINV
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      WrkFamily = GetTXTypeFamily(WrkType)
      myDr("ListNo") = WrkListNo
      If WrkFamily = "A" Or WrkFamily = "U" Then
        myDr("BillType") = GetTXTypeDesc(WrkType) & " BILL"
      Else
        myDr("BillType") = GetTXTypeDesc(WrkType) & " TAX BILL"
      End If
      myDr("Type") = WrkType
      myDr("Year") = WrkYear
      myDr("AcctId") = Mid(WrkYear, 3, 2) & WrkType & WrkListNo
      WrkName = Trim(._NAME)
      WrkName2 = Trim(._SNAME)
      If InStr(._SNAME, "N/O ") > 0 Then
        WrkName = Replace(Trim(._SNAME), "N/O ", "")
        WrkName2 = ""
      End If
      If InStr(._SNAME, " N/O") > 0 Then
        WrkName = Replace(Trim(._SNAME), " N/O", "")
        WrkName2 = ""
      End If
      AddrLine = MyUtils.SetAddrLine(WrkName, WrkName2, ._ADD1,
     ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
      myDr("Addr1") = AddrLine(0)
      myDr("Addr2") = AddrLine(1)
      myDr("Addr3") = AddrLine(2)
      myDr("Addr4") = AddrLine(3)
      myDr("Addr5") = AddrLine(4)
      myDr("bank") = Trim(._BKCD)
      myDr("gross") = ._GROSS
      myDr("exemption") = ._TOTEXP
      myDr("credit") = ._ICVGRS
      myDr("net") = ._NETASS
      If ._CCNO = 0 Then
        myDr("taxtot") = ._TAXT
        myDr("tax1st") = ._TAX1
        myDr("tax2nd") = ._TAX2
        myDr("tax3rd") = ._TX3RD
        myDr("tax4th") = ._TX4TH
        myDr("gross") = ._GROSS
        myDr("exemption") = ._TOTEXP
        myDr("credit") = ._ICVGRS
        myDr("net") = ._NETASS
        myDr("ccno") = 0
        myDr("ccdt") = ""
      Else
        myDr("taxtot") = ._CCETAX
        myDr("tax1st") = ._CCTX1
        myDr("tax2nd") = ._CCTX2
        myDr("tax3rd") = ._CCTX3
        myDr("tax4th") = ._CCTX4
        myTXCOEA.GetOneRecordP(._CCNO)
        myDr("gross") = ._CGRS
        myDr("exemption") = ._CCEXP
        myDr("credit") = myTXCOEA._NEWMVC
        myDr("net") = myTXCOEA._CNETAS
        myDr("ccno") = ._CCNO
        myDr("ccdt") = Format(MyUtils.GetDBDate(._CDATE), "short date")
      End If
      myDr("othertot") = 0
      myDr("other1st") = 0
      myDr("other2nd") = 0
      myDr("billtot") = 0
      myDr("bill1st") = 0
      myDr("bill2nd") = 0
      Select Case WrkFamily
        Case "M", "S"
          If MyAppSettings.DupBillPublicData Then
            myDr("propdesc") = ._MVYR & " " & Trim(._MAKE) & " " &
          Trim(._MODEL) & " " & Trim(._IMVIDNo) & " " & Trim(._IMVREG)
          Else
            myDr("propdesc") = ._MVYR & " " & Trim(._MAKE) & " " &
          Trim(._MODEL)
          End If
          If Trim(._ICVREG) <> String.Empty Then
            If MyAppSettings.DupBillPublicData Then
              myDr.Item("propdesc2") = ._ICVYR & " " & Trim(._ICVMKE) & " " &
            Trim(._ICVMOD) & " " & Trim(._ICVIDNo) & " " & Trim(._ICVREG)
            Else
              myDr.Item("propdesc2") = ._ICVYR & " " & Trim(._ICVMKE) & " " &
            Trim(._ICVMOD)
            End If
          End If
        Case "R"
          If MyDupBillCombinedRU Then
            With myTXINV2
              .GetOneRecordP(WrkListNo, WrkYear, "U")
              If Not .RecordNotFound Then
                If ._CCNO = 0 Then
                  myDr("othertot") = ._TAXT
                  myDr("other1st") = ._TAX1
                  myDr("other2nd") = ._TAX2
                Else
                  myDr("othertot") = ._CCETAX
                  myDr("other1st") = ._CCTX1
                  myDr("other2nd") = ._CCTX2
                End If
              End If
            End With
            myDr("billtot") = myDr("taxtot") + myDr("othertot")
            myDr("bill1st") = myDr("tax1st") + myDr("other1st")
            myDr("bill2nd") = myDr("tax2nd") + myDr("other2nd")
          End If
          myDr("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
          myDr("propdesc2") = "Map: " & Trim(._MAP)
        Case Else
          myDr("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
          myDr("propdesc2") = String.Empty
      End Select
      myDr("payrec") = ._PAYREC
      If WrkType = "R" And MyDupBillCombinedRU Then
        With myTXINV2
          If Not .RecordNotFound Then
            myDr("payrec") = myDr("payrec") + ._PAYREC
          End If
        End With
      End If
      If ._TXIDT > 0 Then
        myDr("lastpaydt") = Format(MyUtils.GetDBDate(._TXIDT), "short date")
      Else
        myDr("lastpaydt") = ""
      End If
      myDr("bond") = ._BOND
      myDr("bondpaid") = ._BONDP
      myDr("interest") = myCASHINT.Out_Int
      myDr("intpaid") = myCASHINT.Out_IntPaid
      myDr("unpaidtax") = myCASHINT.Out_Prin
      myDr("unpaidbond") = myCASHINT.Out_Bond
      myDr("fees") = myCASHINT.Out_Fee
      myDr("lien") = myCASHINT.Out_Lien
      myDr("total") = myCASHINT.Out_Tot
      If WrkType = "R" And MyDupBillCombinedRU Then
        With myCASHINT2
          .In_IntDate = WrkInterestDate
          .In_ListNo = WrkListNo
          .In_Type = "U"
          .In_Year = WrkYear
          .CalcInterest()
        End With
        With myTXINV2
          If Not .RecordNotFound Then
            myDr("interest") = myDr("interest") + myCASHINT2.Out_Int
            myDr("intpaid") = myDr("intpaid") + myCASHINT2.Out_IntPaid
            myDr("unpaidtax") = myDr("unpaidtax") + myCASHINT2.Out_Prin
            myDr("unpaidbond") = myDr("unpaidbond") + myCASHINT2.Out_Bond
            myDr("fees") = myDr("fees") + myCASHINT2.Out_Fee
            myDr("lien") = myDr("lien") + myCASHINT2.Out_Lien
            myDr("total") = myDr("total") + myCASHINT2.Out_Tot
            If ._TXIDT > 0 And ._TXIDT > myTXINV._TXIDT Then
              myDr("lastpaydt") = Format(MyUtils.GetDBDate(._TXIDT), "short date")
            End If
          End If
        End With
      End If
      myDr("backtax") = False
      If Trim(._ICODE) = "B" Then
        myDr("backtax") = True
      End If
      myDr("barcode") = BuildBarCode(WrkListNo, WrkType, WrkYear)
      myDr("interestdt") = MyInterestDate
      myDr("stateben") = ._FTAX
      myDr("localben") = ._TWNBN
    End With

    myTXMRATE.GetOneRecordP(WrkYear, WrkType, myTXINV._DIST)
    If myTXMRATE.RecordNotFound Then
      myTXMRATE.GetOneRecordP(WrkYear, "", myTXINV._DIST)
    End If
    If Not myTXMRATE.RecordNotFound Then
      With myTXMRATE
        myDr("millrt") = ._MRRATE * 1000
      End With
    End If

    If myTXINV._PHASE > 0 Then
      WrkPhase = myTXINV._PHASE
    Else
      WrkPhase = ""
    End If
    myTXPROF.GetOneRecordP(WrkType, WrkYear, WrkPhase, myTXINV._DIST)
    If myTXINV._TYPE = "X" Then
      myDr("duedt1") = Format(MyUtils.GetDBDate(myTXINV._PDAT), "M/d/yyyy")
      myDr("duedt2") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE2), "M/d/yyyy")
      myDr("duedt3") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE3), "M/d/yyyy")
      myDr("duedt4") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE4), "M/d/yyyy")
    Else
      myDr("duedt1") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE1), "M/d/yyyy")
      myDr("duedt2") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE2), "M/d/yyyy")
      myDr("duedt3") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE3), "M/d/yyyy")
      myDr("duedt4") = Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE4), "M/d/yyyy")
    End If
    ds2.Tables(0).Rows.Add(myDr)

  End Sub
  Sub AddOneRecordLienRel(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer)
  Dim dstxhst As DataSet = New DataSet
  Dim myDr As Data.DataRow
  Dim AddrLine As String()
  Dim WrkFamily As String
  Dim WrkLienedAmt As Double
  Dim I As Integer

  myCASHINT = New CASHINT.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)
  myTXHSTL3 = New TXHSTL3.mydata(MyDBConnect)

  With myCASHINT
   .In_IntDate = MyInterestDate
   .In_ListNo = WrkListNo
   .In_Type = WrkType
   .In_Year = WrkYear
   .CalcInterest()
  End With

    myDr = ds2.Tables(0).NewRow
    With myTXINV
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      myDr("SortData") = ""
      myDr("ListNo") = WrkListNo
      myDr("BillType") = GetTXTypeDesc(WrkType)
      myDr("Type") = WrkType
      myDr("Year") = WrkYear
      AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, _
       ._ADD2, ._CITY, ._STATE, ._ZIP5, ._ZIP4)
      myDr("Addr1") = AddrLine(0)
      myDr("Addr2") = AddrLine(1)
      myDr("Addr3") = AddrLine(2)
      myDr("Addr4") = AddrLine(3)
      myDr("Addr5") = AddrLine(4)
      'Use Liened amount from History instead of Tax Total 
      WrkLienedAmt = 0
      dstxhst = myTXHSTL3.GetViewbyList(WrkYear, WrkListNo, WrkType, 99999999, 999)
      If dstxhst.Tables(0).Rows.Count > 0 Then
        For I = 0 To dstxhst.Tables(0).Rows.Count - 1
          With dstxhst.Tables(0).Rows(I)
            If .Item("batcha") = "L" Then
              WrkLienedAmt = .Item("pamt")
              Exit For
            End If
          End With
        Next
      End If
      dstxhst.Clear()
      dstxhst = Nothing
      myDr("taxtot") = WrkLienedAmt
      WrkFamily = GetTXTypeFamily(WrkType)
      Select Case WrkFamily
      Case "M", "S"
        myDr("propdesc") = Trim(._MAKE) & " " & ._MVYR & " " & Trim(._IMVREG) & _
          " " & Trim(._IMVIDNo)
      Case "R"
        myDr("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
        myDr("propdesc2") = Trim(._VOL) & "/" & Trim(._IPAGE)
      Case Else
        myDr("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
        myDr("propdesc2") = String.Empty
      End Select
      myDr("total") = myCASHINT.Out_Tot
    End With

    ds2.Tables(0).Rows.Add(myDr)

End Sub
  Public Sub PrtLienRel(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer)
   Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
   Dim ReportName As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim Good As Boolean

   If MyAppSettings.DupBillPrinter <> "" Then
      Good = MyUtils.CheckPrinterExists(MyAppSettings.DupBillPrinter)
      If Not Good Then
        MsgBox("Duplicate Bill Printer " & MyAppSettings.DupBillPrinter & " does not exist. Click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Exit Sub
      End If
    End If

   BuildDS2()
   AddOneRecordLienRel(WrkListNo, WrkType, WrkYear)
  'Check for Lien Release for Tax Type
   GetTXFMSTMT(WrkType)
   If Trim(myTXFMSTMT._LINE1) = String.Empty Then
     GetTXFMSTMT(" ")
   End If
   ReportName = "PrtTXA09M" & WrkType & ".rpt"
   ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   WrkExists = MyUtils.CheckFileExists(ReportPath)
   'If not found then use default Lien Release 
   If Not WrkExists Then
     ReportName = "PrtTXA09M.rpt"
     ReportPath = MyUtils.GetReportPath(ReportName, myTOWN._TOWNBR, MyCustomDir)
   End If

   With myreport
    .Load(ReportPath)
    .PrintOptions.PrinterName = MyAppSettings.DupBillPrinter
    .SetDataSource(ds2)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyTownCounty", Trim(myTOWN._COUNTY))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
    .SetParameterValue("MySigned", Trim(myTXFMSTMT._SIGNED))
    .SetParameterValue("MyClerk", Trim(myTXFMSTMT._CLERK))
    .SetParameterValue("MyTownShort", Trim(myTXFMSTMT._TWNAME))
    .PrintToPrinter(1, False, 0, 0)
    .Close()
    .Dispose()
   End With

   myTXFMSTMT.CloseFile()
   myTXFMSTMT = Nothing
  End Sub
  'Public Sub PrtMVRel(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, _
  '  ByVal WrkInterestDate As Date)
  ' Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
  ' Dim ReportPath As String
  ' Dim Good As Boolean

  ' If MyAppSettings.DupBillPrinter <> "" Then
  '    Good = MyUtils.CheckPrinterExists(MyAppSettings.DupBillPrinter)
  '    If Not Good Then
  '      MsgBox("Duplicate Bill Printer " & MyAppSettings.DupBillPrinter & " does not exist. Click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
  '      Exit Sub
  '    End If
  '  End If

  ' BuildDS2()
  ' AddOneRecord(WrkListNo, WrkType, WrkYear, WrkInterestDate)
  ' GetTXFMSTMT(" ")
  ' ReportPath = MyUtils.GetReportPath("PrtTXA09N.rpt", myTOWN._TOWNBR, MyCustomDir)
  ' With myreport
  '  .Load(ReportPath)
  '  .PrintOptions.PrinterName = MyAppSettings.DupBillPrinter
  '  .SetDataSource(ds2)
  '  .SetParameterValue("MyUserID", MyUserID)
  '  .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
  '  .SetParameterValue("MyTownNo", myTOWN._TOWNBR)
  '  .SetParameterValue("MyTitle", Trim(myTXFMSTMT._TITLE))
  '  .PrintToPrinter(1, False, 0, 0)
  '  .Close()
  '  .Dispose()
  ' End With

  ' myTXFMSTMT.CloseFile()
  ' myTXFMSTMT = Nothing
  'End Sub
  Public Sub PrtDupBill(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, _
  ByVal WrkInterestDate As Date, ByVal WrkPrinter As String)

   Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
   Dim WrkRptName As String
   Dim WrkFamily As String
   Dim ReportPath As String
   Dim WrkExists As Boolean
   Dim Good As Boolean

   If WrkPrinter <> "" Then
      Good = MyUtils.CheckPrinterExists(WrkPrinter)
      If Not Good Then
        MsgBox("Bill Printer " & WrkPrinter & " does not exist. Click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Exit Sub
      End If
    End If

   BuildDS2()
   AddOneRecord(WrkListNo, WrkType, WrkYear, WrkInterestDate)
   GetTXFMSTMT(WrkType)
   If Trim(myTXFMSTMT._LINE1) = String.Empty Then
     GetTXFMSTMT(" ")
   End If
   WrkRptName = "PrtTXA09O.rpt"
   With ds2.Tables(0).Rows(0)
     WrkFamily = GetTXTypeFamily(WrkType)
     Select Case WrkFamily
     Case "A"
       WrkRptName = "PrtTXA09OAS.rpt"
     Case "U"
       WrkRptName = "PrtTXA09OUS.rpt"
     Case "P"
       WrkRptName = "PrtTXA09OPP.rpt"
     Case "M"
       WrkRptName = "PrtTXA09OMV.rpt"
     Case "S"
       WrkRptName = "PrtTXA09OMS.rpt"
       ReportPath = MyUtils.GetReportPath(WrkRptName, myTOWN._TOWNBR, MyCustomDir)
       WrkExists = MyUtils.CheckFileExists(ReportPath)
       If Not WrkExists Then
         WrkRptName = "PrtTXA09OMV.rpt"
       End If
     End Select
   End With

   If MyDupBillCombinedRU And WrkType = "R" Then
     WrkRptName = "PrtTXA09ORU.rpt"
   End If

   'Check for bill type format
   ReportPath = MyUtils.GetReportPath("PrtTXA09O" & WrkType & ".rpt", myTOWN._TOWNBR, MyCustomDir)
   WrkExists = MyUtils.CheckFileExists(ReportPath)
   If WrkExists Then
     WrkRptName = "PrtTXA09O" & WrkType & ".rpt"
   End If

   ReportPath = MyUtils.GetReportPath(WrkRptName, myTOWN._TOWNBR, MyCustomDir)
   With myreport
    .Load(ReportPath)
    .PrintOptions.PrinterName = WrkPrinter
    .SetDataSource(ds2)
    .SetParameterValue("MyUserID", MyUserID)
    .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
    .SetParameterValue("MyPayTo", Trim(myTXFMSTMT._PAYTO))
    .SetParameterValue("MyLine1", Trim(myTXFMSTMT._LINE1))
    .SetParameterValue("MyLine2", Trim(myTXFMSTMT._LINE2))
    .SetParameterValue("MyLine3", Trim(myTXFMSTMT._LINE3))
    .SetParameterValue("MyLine4", Trim(myTXFMSTMT._LINE4))
    .SetParameterValue("MyLine5", Trim(myTXFMSTMT._LINE5))
    .PrintToPrinter(1, False, 0, 0)
    .Close()
    .Dispose()
   End With

   myTXFMSTMT.CloseFile()
   myTXFMSTMT = Nothing
  End Sub
  Public Sub PrtLetter(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, _
    ByVal WrkInterestDate As Date)
   Dim myreport As New CrystalDecisions.CrystalReports.Engine.ReportDocument
   Dim ReportPath As String

   BuildDS2()
   AddOneRecord(WrkListNo, WrkType, WrkYear, WrkInterestDate)
   ReportPath = MyUtils.GetReportPath("PrtTXA09Let.rpt", myTOWN._TOWNBR, MyCustomDir)
   With myreport
    .Load(ReportPath)
    .PrintOptions.PrinterName = MyAppSettings.DupBillPrinter
    .SetDataSource(ds2)
    .PrintToPrinter(1, False, 0, 0)
    .Close()
    .Dispose()
   End With
  End Sub
Public Sub GetTXFMSTMT(ByVal WrkType As String)
  myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)

  myTXFMSTMT.GetOneRecordP(WrkType)
End Sub
Public Sub GetEndorsement(ByVal WrkBatchSeqNo As Integer, ByVal WrkTotCheck As Decimal)
  myTXENDRS = New TXENDRS.mydata(MyDBConnect)
  myTXENDRS.GetOneRecordP(MyEndorseType)
  If myTXENDRS.RecordNotFound Then
    myTXENDRS.GetOneRecordP(String.Empty)
  End If
  PrtEndorse(WrkBatchSeqNo, WrkTotCheck)
  myTXENDRS.CloseFile()
  myTXENDRS = Nothing
End Sub
Public Function BuildBarCode(ByVal WrkList As Integer, ByVal WrkType As String, _
  ByVal WrkGLYear As Integer) As String
  Dim WrkBarCode As String

  WrkBarCode = "*" & Format(WrkList, "000000") & WrkType & WrkGLYear & "*"
  Return WrkBarCode
End Function
End Module






