Imports System.Text
Imports System.IO
Imports System.Data.Common

Module PrintReportSU

  ' One shared AppSettings instance for this program
  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPCQ As TXSUPPCQ.MyData
  Dim myTPaymnt As TPAYMNT.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXCOEB As TXCOEB.MyData
  Dim myTXMVPCT As TXMVPCT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsBill As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim DsTXSUPP As DataSet = New DataSet
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
  Dim WrkComment As String
  Dim WrkAlternative As Boolean
  Dim WrkBarcode As Boolean
  Dim WrkCSV As Boolean
  Dim WrkHeadings As Boolean

  Dim WrkExcd(4) As String
  Dim WrkCCExcd(4) As String
  Dim WrkExam(4) As Integer
  Dim WrkCCExam(4) As String
  Dim WrkTotDesc(6) As String
  Dim WrkTotCount(6) As Integer
  Dim WrkTotGross(6) As Long
  Dim WrkTotExemption(6) As Long
  Dim WrkTotNet(6) As Long
  Dim WrkTotProrate(6) As Decimal
  Dim WrkTotCredit(6) As Decimal
  Dim WrkTotTax(6) As Decimal
  Dim WrkTot1st(6) As Decimal
  Dim WrkTot2nd(6) As Decimal
  Dim WrkList As Integer
  Dim WrkType As String
  Dim WrkGross As Integer
  Dim WrkExempt As Integer
  Dim WrkNet As Integer
  Dim WrkOGross As Integer
  Dim WrkProrate As Integer
  Dim WrkProratePct As Decimal
  Dim WrkSale As Integer
  Dim WrkSalePct As Decimal
  Dim WrkCredit As Integer
  Dim WrkCreditPct As Decimal
  Dim WrkTaxAmount As Decimal
  Dim WrkTaxTotal As Decimal
  Dim WrkTax1st As Decimal
  Dim WrkTax2nd As Decimal
  Dim WrkMVCred As Integer
  Dim WrkWaivered As Decimal
  Dim WrkCC As Boolean
  Dim WrkCCDesc As String
  Dim WrkScanLine As String
  Dim WrkPropDesc As String
  Dim WrkBillCount As Integer
  'Buffered files
  Dim WrkSupCode(25) As String
  Dim WrkSupMonth(25) As String
  Dim WrkSupPct(25) As Decimal
  Public Sub PrtReportSU()

    myTXSUPPCQ = New TXSUPPCQ.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXCOEB = New TXCOEB.MyData(myDBConnect)
    myTXMVPCT = New TXMVPCT.MyData(myDBConnect)

    'Clear Totals
    Array.Clear(WrkTotCount, 0, 7)
    Array.Clear(WrkTotGross, 0, 7)
    Array.Clear(WrkTotExemption, 0, 7)
    Array.Clear(WrkTotNet, 0, 7)
    Array.Clear(WrkTotTax, 0, 7)
    Array.Clear(WrkTot1st, 0, 7)
    Array.Clear(WrkTot2nd, 0, 7)

    With MyFrmTX301B
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
      WrkComment = .TxtComment.Text
      WrkAlternative = .ChkAlternative.Checked
      WrkBarcode = .ChkBarcode.Checked
      WrkCSV = .RbCSV.Checked
      WrkHeadings = .ChkHeadings.Checked
    End With
    WrkType = "S"

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSBill(dsBill)
      BuildDSTot(dsTot)
      BufferTXSupcd()
    Else
      ds.Clear()
      dsBill.Clear()
      dsTot.Clear()
    End If

    If WrkExCode(0) = Nothing Then
      BufferExem()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
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
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkBillType As String
    Dim WrkFamily As String
    Dim WrkVIN As Boolean

    WrkPhase = ""
    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, WrkType, WrkDist)
    WrkBillType = GetTXTypeDesc(WrkType) & " TAX BILL"
    WrkFamily = GetTXTypeFamily(WrkType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "Cat <> 2"
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    Select Case WrkSortBy
      Case "Name"
        WrkSort = "NAME"
      Case "Zip"
        WrkSort = "ZIP5, NAME"
      Case Else
        WrkSort = ""
    End Select

    GetTXFMBILL(WrkType)
    If Trim(myTXFMBILL._LINE1) = String.Empty Then
      GetTXFMBILL(" ")
    End If

    DsTXSUPP = myTXSUPPCQ.GetQry(WrkSort, WrkQry, 0)
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub

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

    WrkBillCount = 0

    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With DsTXSUPP.Tables(0).Rows(I)
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
        If WrkCC Then
          WrkExempt = .Item("ccex")
          With myTXCOEB
            .GetOneRecordP(DsTXSUPP.Tables(0).Rows(I).Item("ccno"))
            WrkGross = ._CGRS
            WrkProratePct = CalcMvPct("P", ._CT2MC1)
            WrkProrate = CalcAssmt(._CGRS, WrkProratePct)
            WrkSale = 0
            WrkSalePct = 0
            If Trim(._CT2MC2) <> "" Then
              WrkSalePct = CalcMvPct("S", ._CT2MC2)
              WrkSale = CalcAssmt(._CGRS, WrkSalePct)
            End If
            WrkCreditPct = CalcMvPct("C", ._CT2MC3)
            WrkCredit = CalcAssmt(._NEWMVC, WrkCreditPct)
          End With
        Else
          WrkGross = .Item("value") + .Item("btr")
          WrkOGross = .Item("oval") + .Item("btr")
          For J = 0 To 4
            If Trim(WrkExcd(J)) <> "" And WrkExam(J) = 0 Then
              K = LookupExem(WrkExcd(J))
              WrkExempt = WrkExempt + WrkExFixedAmt(K)
            Else
              WrkExempt = WrkExempt + WrkExam(J)
            End If
          Next
          WrkProratePct = CalcPct(.Item("ass"))
          WrkProrate = CalcAssmt(WrkGross, WrkProratePct)
          WrkCreditPct = CalcPct(.Item("oass"))
          WrkCredit = CalcAssmt(WrkOGross, WrkCreditPct)
          WrkSale = 0
        End If

        If WrkCredit > WrkProrate Then
          WrkCredit = WrkProrate
        End If
        WrkNet = WrkProrate - WrkCredit - WrkSale - WrkExempt
        If WrkNet < 0 Then WrkNet = 0
        If .Item("Cat") = "1" Then
          WrkTaxTotal = WrkNet * MrateMillrt
        Else
          WrkTaxTotal = 0
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
          WrkWaivered = .Out_Waivered
        End With

        'Determine which totals to add to
        K = 0 'Regular Tax
        If WrkCC Then 'C/C Net
          K = 1
        End If
        If WrkWaivered > 0 Then 'Waivered
          K = 3
        End If
        If WrkTaxTotal = 0 And K = 0 And .Item("cat") = "1" Then 'Net Zero Tax
          K = 4
        End If
        If WrkTaxTotal = 0 And K = 0 And .Item("cat") = "2" Then 'Non Taxable
          K = 5
        End If
        If WrkTaxTotal = 0 And K = 0 And .Item("cat") = "3" Then 'Tax Exempt
          K = 6
        End If
        WrkTotCount(K) = WrkTotCount(K) + 1
        WrkTotGross(K) = WrkTotGross(K) + WrkGross
        WrkTotExemption(K) = WrkTotExemption(K) + WrkExempt
        WrkTotNet(K) = WrkTotNet(K) + WrkNet
        If WrkSale > 0 Then
          WrkTotProrate(K) = WrkTotProrate(K) + WrkSale
        Else
          WrkTotProrate(K) = WrkTotProrate(K) + WrkProrate
        End If
        WrkTotCredit(K) = WrkTotCredit(K) + WrkCredit
        If WrkWaivered > 0 Then
          WrkTotTax(K) = WrkTotTax(K) + WrkWaivered
        Else
          WrkTotTax(K) = WrkTotTax(K) + WrkTaxTotal
        End If
        WrkTot1st(K) = WrkTot1st(K) + WrkTax1st
        WrkTot2nd(K) = WrkTot2nd(K) + WrkTax2nd
        'C/C Credit Net 
        If WrkCredit > 0 Then
          WrkTotNet(2) = WrkTotNet(2) + WrkCredit
        End If
        'Create Report
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = WrkList
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("gross") = WrkGross
        dr.Item("exemption") = WrkExempt
        dr.Item("prorate") = WrkProrate
        dr.Item("credit") = WrkCredit
        dr.Item("net") = WrkNet
        dr.Item("taxtot") = WrkTaxTotal
        Select Case K
          Case 0
            dr.Item("group") = ""
          Case 1
            dr.Item("group") = "C/C Net"
          Case 2
            dr.Item("group") = "C/C Credit"
          Case 3
            dr.Item("group") = "Waivered"
          Case 4
            dr.Item("group") = "Net Zero Tax"
          Case 5
            dr.Item("group") = "Non Taxable"
          Case 6
            dr.Item("group") = "Tax Exempt"
        End Select
        ds.Tables(0).Rows.Add(dr)

        'Filter - Omit Zero Bills 
        If WrkTaxTotal = 0 Then
          GoTo WriteInvoice
        End If

        WrkBillCount = WrkBillCount + 1
        If MyFrmTX301B.RbPrtBill.Checked Or MyFrmTX301B.LblFilePath.Text <> String.Empty Then
          Select Case myTXFMBILL._SCAN
            Case "S"
              WrkScanLine = BuildScanLineSewer(WrkList, WrkGLYear, WrkType, WrkTaxTotal,
         WrkTax1st, WrkTax2nd, 0, 0, .Item("btc"))
            Case "W"
              WrkScanLine = BuildScanLineWebster(WrkList, WrkGLYear, WrkType, WrkTaxTotal,
         WrkTax1st, WrkTax2nd, 0, 0, .Item("btc"))
            Case Else
              WrkScanLine = BuildScanLine(WrkList, WrkGLYear, WrkType, WrkTaxTotal, WrkTax1st, .Item("btc"))
          End Select
        End If

        'Filter - Print No Bills
        If MyFrmTX301B.RbPrtNoBill.Checked Then
          GoTo WriteExport
        End If

        'Create Billing File
        drBill = dsBill.Tables(0).NewRow
        drBill.Item("BillType") = WrkBillType
        drBill.Item("listno") = WrkList
        drBill.Item("year") = WrkGLYear
        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        drBill.Item("addr1") = AddrLine(0)
        drBill.Item("addr2") = AddrLine(1)
        drBill.Item("addr3") = AddrLine(2)
        drBill.Item("addr4") = AddrLine(3)
        drBill.Item("addr5") = AddrLine(4)
        drBill.Item("gross") = WrkGross
        drBill.Item("exemption") = WrkExempt
        drBill.Item("net") = WrkNet
        drBill.Item("prorate") = WrkProrate
        drBill.Item("credit") = WrkCredit
        drBill.Item("taxtot") = WrkTaxTotal
        drBill.Item("tax1st") = WrkTax1st
        drBill.Item("tax2nd") = WrkTax2nd
        drBill.Item("propdesc") = BuildPropDesc(I)
        WrkVIN = True
        drBill.Item("propdesc2") = BuildPropDesc2(I, WrkVIN)
        drBill.Item("addldesc") = BuildAddlDesc()
        drBill.Item("addldesc2") = BuildAddlDesc2()
        If Trim(.Item("oass")) <> "" Then
          K = LookupTxSupcd(.Item("oass"))
          drBill.Item("addldesc3") = .Item("oass") & "-" & WrkSupMonth(K)
        Else
          K = LookupTxSupcd(.Item("ass"))
          drBill.Item("addldesc3") = .Item("ass") & "-" & WrkSupMonth(K)
        End If
        If .Item("btc") = "BT" Then
          drBill.Item("backtax") = True
        Else
          drBill.Item("backtax") = False
        End If
        drBill.Item("barcode") = BuildBarCode(WrkList, WrkType, WrkGLYear)
        drBill.Item("postnet") = BuildPostNet(.Item("zip5"), .Item("zip4"))
        drBill.Item("scanline") = WrkScanLine
        drBill.Item("ccno") = .Item("ccno")
        drBill.Item("ccdesc") = WrkCCDesc
        drBill.Item("ccdate") = MyUtils.GetDBDate(.Item("cdate"))
      End With
      dsBill.Tables(0).Rows.Add(drBill)
WriteExport:
      If MyFrmTX301B.LblFilePath.Text <> String.Empty Then
        If WrkCSV Then
          sw.WriteLine(DownloadCSV(I))
        Else
          sw.WriteLine(DownloadMSBill(I))
        End If
      End If

WriteInvoice:
      If WrkUpdate Then
        WriteMSInvoice(I)
      End If

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

    'Bill Totals
    For K = 0 To 6
      drTot = dsTot.Tables(0).NewRow
      Select Case K
        Case 0
          drTot.Item("description") = "Regular Tax"
        Case 1
          drTot.Item("description") = "C/C Net"
        Case 2
          drTot.Item("description") = "C/C Credit"
        Case 3
          drTot.Item("description") = "Waivered"
        Case 4
          drTot.Item("description") = "Net Zero Tax"
        Case 5
          drTot.Item("description") = "Non Taxable"
        Case 6
          drTot.Item("description") = "Tax Exempt"
      End Select
      drTot.Item("count") = WrkTotCount(K)
      drTot.Item("gross") = WrkTotGross(K)
      drTot.Item("exemption") = WrkTotExemption(K)
      drTot.Item("net") = WrkTotNet(K)
      drTot.Item("prorate") = WrkTotProrate(K)
      drTot.Item("credit") = WrkTotCredit(K)
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
    myTXSUPPCQ.CloseFile()

  End Sub
  Private Function DownloadMSBill(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const CCText As String = "ADJUSTED TAX:"
    Const CComma As String = ","
    Dim WrkInteger As Integer
    Dim K As Integer

    With DsTXSUPP.Tables(0).Rows(I)
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
      sb.Append(MyUtils.JustifyLeft(.Item("name"), 35))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("sname"), 35))
      sb.Append(CComma)
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
      sb.Append(MyUtils.JustifyLeft(.Item("regno"), 8))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("model"), 8))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("make"), 5))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("year"), 5))
      Else
        sb.Append(Format(.Item("year"), "0000"))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("class"), 3))
      Else
        sb.Append(Format(.Item("class"), "00"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("vinno"), 17))
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
      sb.Append(MyUtils.JustifyLeft(WrkComment, 30)) 'User Message
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft("", 30)) 'User Message
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("oyear"), 5))
      Else
        sb.Append(Format(.Item("oyear"), "0000"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("omake"), 5))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(.Item("ocls"), 3))
      Else
        sb.Append(Format(.Item("ocls"), "00"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("oreg#"), 8))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("ovin"), 17))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(.Item("omod"), 8))
      sb.Append(CComma)
      sb.Append("NEWEST VEHICLE")
      sb.Append(CComma)
      If .Item("oass") = String.Empty Then
        K = LookupTxSupcd(.Item("ass"))
        sb.Append(MyUtils.JustifyLeft(.Item("ass") & " " & WrkSupMonth(K), 5))
      Else
        K = LookupTxSupcd(.Item("oass"))
        sb.Append(MyUtils.JustifyLeft(.Item("oass") & " " & WrkSupMonth(K), 5))
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkGross, 10))
      Else
        sb.Append(Format(WrkGross, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append("X")
      sb.Append(CComma)
      WrkInteger = WrkProratePct * 1000
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkProratePct, "#.000"), 6))
      Else
        sb.Append(Format(WrkInteger, "0000"))
      End If
      sb.Append(CComma)
      sb.Append("=")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkProrate, 10))
      Else
        sb.Append(Format(WrkProrate, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append("PREVIOUS VEHICLE")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkOGross, 10))
      Else
        sb.Append(Format(WrkOGross, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append("X")
      sb.Append(CComma)
      WrkInteger = WrkCreditPct * 1000
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkCreditPct, "#.000"), 6))
      Else
        sb.Append(Format(WrkInteger, "0000"))
      End If
      sb.Append(CComma)
      sb.Append("=")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkCredit, 8))
      Else
        sb.Append(Format(WrkCredit, "0000000"))
      End If
      sb.Append(CComma)
      sb.Append("NET CALCULATION")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkProrate, 10))
      Else
        sb.Append(Format(WrkProrate, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append("-")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkCredit, 8))
      Else
        sb.Append(Format(WrkCredit, "0000000"))
      End If
      sb.Append(CComma)
      sb.Append("-")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkExempt, 8))
      Else
        sb.Append(Format(WrkExempt, "0000000"))
      End If
      sb.Append(CComma)
      sb.Append("=")
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(WrkNet, 10))
      Else
        sb.Append(Format(WrkNet, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(WrkScanLine, 70))
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
      sb.Append(MyUtils.JustifyLeft(.Item("lease"), 2))
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
    Dim K As Integer

    With DsTXSUPP.Tables(0).Rows(I)
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
      sb.Append(.Item("name"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("sname"))
      sb.Append(CQuote)
      sb.Append(CComma)
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
      sb.Append(.Item("regno"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("model"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("make"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("year"))
      sb.Append(CComma)
      sb.Append(.Item("class"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("vinno"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("dist"))
      sb.Append(CComma)
      sb.Append(Format(MrateMillrt * 1000, "###.000"))
      sb.Append(CComma)
      sb.Append(myTOWN._TOWNBR)
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
      sb.Append(WrkComment) 'User Message 2
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("oyear"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("omake"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(.Item("ocls"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("oreg#"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("ovin"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("omod"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("NEWEST VEHICLE")
      sb.Append(CQuote)
      sb.Append(CComma)
      If Trim(.Item("oass")) = String.Empty Then
        K = LookupTxSupcd(.Item("ass"))
        sb.Append(MyUtils.JustifyLeft(.Item("ass") & " " & WrkSupMonth(K), 5))
      Else
        K = LookupTxSupcd(.Item("oass"))
        sb.Append(MyUtils.JustifyLeft(.Item("oass") & " " & WrkSupMonth(K), 5))
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkGross, "000000000"))
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("X")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkProratePct)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("=")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkProrate)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("PREVIOUS VEHICLE")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkOGross)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("X")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkCreditPct)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("=")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkCredit)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("NET CALCULATION")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkProrate)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("-")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkCredit)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("-")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkExempt)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append("=")
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(WrkNet)
      sb.Append(CComma)
      sb.Append(WrkScanLine)
      sb.Append(CComma)
      sb.Append("0.00") 'City Tax 
      sb.Append(CComma)
      sb.Append("0.000")  'City Mill Rate
      sb.Append(CComma)
      sb.Append("0.00") 'Fire Dist Tax 
      sb.Append(CComma)
      sb.Append("0.000")  'Fire Dist Mill Rate
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(.Item("lease"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
      sb.Append(CComma)
      sb.Append(Mid(WrkGLYear, 3, 2) & WrkType & WrkList)

      ' Build unique account ID string used for the online cart (matches the ACCOUNT ID column)
      Dim qrAcctId_SU As String = Mid(WrkGLYear.ToString("0000"), 3, 2) & WrkType & WrkList.ToString("000000")

      ' Append a new CSV column for the QR URL
      sb.Append(CComma)

      ' Build the pieces of the QR payload expected by qr_add.php
      Dim ownerName_SU As String = CStr(.Item("name")) & " " & CStr(.Item("sname"))
      Dim desc_SU As String = CStr(.Item("year")) & " " & CStr(.Item("make")) & " " &
                              CStr(.Item("model")) & " " & CStr(.Item("vinno")) & "  " &
                              CStr(.Item("regno"))
      Dim productId_SU As String = WrkType & WrkGLYear.ToString("0000")

      ' Let AppSettings build the full QR URL
      Dim qrUrl_SU As String = BuildQrUrl(
        acctId:=qrAcctId_SU,
        productId:=productId_SU,
        price:=WrkTaxTotal,
        txName:=ownerName_SU,
        txType:=WrkType,
        txDesc:=desc_SU
      )

      ' Write QR URL into the CSV
      sb.Append(CQuote)
      sb.Append(qrUrl_SU)
      sb.Append(CQuote)
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
    sb.Append("REGNO")
    sb.Append(CComma)
    sb.Append("MODEL")
    sb.Append(CComma)
    sb.Append("MAKE")
    sb.Append(CComma)
    sb.Append("VEHICLE YEAR")
    sb.Append(CComma)
    sb.Append("CLASS")
    sb.Append(CComma)
    sb.Append("VINNO")
    sb.Append(CComma)
    sb.Append("DISTRICT")
    sb.Append(CComma)
    sb.Append("MILL RATE")
    sb.Append(CComma)
    sb.Append("TOWN NO.")
    sb.Append(CComma)
    sb.Append("C OF C TEXT")
    sb.Append(CComma)
    sb.Append("C OF C NO")
    sb.Append(CComma)
    sb.Append("C OF C DATE")
    sb.Append(CComma)
    sb.Append("TAX BASE BEFORE")
    sb.Append(CComma)
    sb.Append("MILL RATE BEFORE")
    sb.Append(CComma)
    sb.Append("USER MESSAGE 1")
    sb.Append(CComma)
    sb.Append("USER MESSAGE 2")
    sb.Append(CComma)
    sb.Append("CREDIT VEHICLE YEAR")
    sb.Append(CComma)
    sb.Append("CREDIT VEHICLE MAKE")
    sb.Append(CComma)
    sb.Append("CLASS")
    sb.Append(CComma)
    sb.Append("CREDIT VEHICLE REGNO")
    sb.Append(CComma)
    sb.Append("VIN #")
    sb.Append(CComma)
    sb.Append("MODEL")
    sb.Append(CComma)
    sb.Append("NEW VEH. TEXT")
    sb.Append(CComma)
    sb.Append("MONTH/ CODE")
    sb.Append(CComma)
    sb.Append("GROSS ASSESSMENT")
    sb.Append(CComma)
    sb.Append("X")
    sb.Append(CComma)
    sb.Append("PERCENTAGE")
    sb.Append(CComma)
    sb.Append("EQUAL SIGN")
    sb.Append(CComma)
    sb.Append("PARTIAL ASSESMENT")
    sb.Append(CComma)
    sb.Append("PREVIOUS VEHICLE")
    sb.Append(CComma)
    sb.Append("OLD GROSS")
    sb.Append(CComma)
    sb.Append("X")
    sb.Append(CComma)
    sb.Append("PERCENTAGE")
    sb.Append(CComma)
    sb.Append("EQUAL SIGN")
    sb.Append(CComma)
    sb.Append("CREDIT")
    sb.Append(CComma)
    sb.Append("NET CALC TITLE")
    sb.Append(CComma)
    sb.Append("PARTIAL ASSESMENT")
    sb.Append(CComma)
    sb.Append("-")
    sb.Append(CComma)
    sb.Append("CREDIT")
    sb.Append(CComma)
    sb.Append("-")
    sb.Append(CComma)
    sb.Append("EXEMPT")
    sb.Append(CComma)
    sb.Append("EQUAL SIGN")
    sb.Append(CComma)
    sb.Append("NET ASSESSMENT")
    sb.Append(CComma)
    sb.Append("OCR SCAN LINE")
    sb.Append(CComma)
    sb.Append("CITY TAX DUE")
    sb.Append(CComma)
    sb.Append("CITY MILL RATE")
    sb.Append(CComma)
    sb.Append("FIRE TAX DUE")
    sb.Append(CComma)
    sb.Append("FIRE MILL RATE")
    sb.Append(CComma)
    sb.Append("LEASE CODE")
    sb.Append(CComma)
    sb.Append("BAR CODE")
    sb.Append(CComma)
    sb.Append("ACCOUNT ID")
    sb.Append(CComma)

    sb.Append("QR URL")  ' ADDED: CSV column header for QR URL

    Return sb.ToString
  End Function
  Private Sub WriteMSInvoice(ByVal I As Integer)
    Dim ds2 As DataSet = New DataSet
    Dim Pos As Integer
    With DsTXSUPP.Tables(0).Rows(I)
      myTXINV.GetOneRecordP(WrkList, WrkGLYear, WrkType)
      If .Item("btc") = "BT" Then
        myTXINV._ICODE = "B"
      Else
        myTXINV._ICODE = ""
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
      Pos = InStr(.Item("rad1"), " ", CompareMethod.Text)
      If Pos > 0 Then
        myTXINV._LOC = Mid(.Item("rad1"), Pos + 1, 25)
        myTXINV._LOCNo = MyUtils.JustifyRight(Mid(.Item("rad1"), 1, Pos - 1), 7)
      Else
        Pos = InStr(.Item("add1"), " ", CompareMethod.Text)
        If Pos > 0 Then
          myTXINV._LOC = Mid(.Item("add1"), Pos + 1, 25)
          myTXINV._LOCNo = MyUtils.JustifyRight(Mid(.Item("add1"), 1, Pos - 1), 7)
        Else
          myTXINV._LOC = Mid(.Item("add1"), 1, 25)
          myTXINV._LOCNo = ""
        End If
      End If
      If WrkUpdateDist Then
        myTXINV._DIST = .Item("dist")
      Else
        myTXINV._DIST = 0
      End If
      myTXINV._PDST = .Item("pdst")
      myTXINV._TAXT = WrkTaxTotal
      myTXINV._TAX1 = WrkTax1st
      myTXINV._TAX2 = WrkTax2nd
      myTXINV._BALD = WrkTaxTotal
      myTXINV._GROSS = WrkGross
      myTXINV._TOTEXP = WrkExempt
      myTXINV._NETASS = WrkNet
      myTXINV._MVYR = .Item("year")
      myTXINV._MAKE = .Item("make")
      myTXINV._MODEL = .Item("model")
      myTXINV._BODY = .Item("body")
      myTXINV._CLASS = .Item("class")
      myTXINV._IMVREG = .Item("regno")
      myTXINV._IMVIDNo = .Item("vinno")
      myTXINV._DOB = .Item("dob")
      myTXINV._ILEASE = .Item("lease")
      myTXINV._ICVACD = .Item("oass")
      myTXINV._ICVYR = .Item("oyear")
      myTXINV._ICVMKE = .Item("omake")
      myTXINV._ICVMOD = .Item("omod")
      myTXINV._ICVCLS = .Item("ocls")
      myTXINV._ICVREG = .Item("oreg#")
      myTXINV._ICVIDNo = .Item("ovin")
      myTXINV._ICVGRS = WrkOGross
      myTXINV._OAS1 = WrkGross
      myTXINV._ASS = .Item("ass")
      If Not WrkCC Then
        myTXINV._ETCA = ""
        myTXINV._EXCD1 = WrkExcd(0)
        myTXINV._EXCD2 = WrkExcd(1)
        myTXINV._EXCD3 = WrkExcd(2)
        myTXINV._EXCD4 = WrkExcd(3)
        myTXINV._EXCD5 = WrkExcd(4)
        myTXINV._EXAM1 = WrkExam(0)
        myTXINV._EXAM2 = WrkExam(1)
        myTXINV._EXAM3 = WrkExam(2)
        myTXINV._EXAM4 = WrkExam(3)
        myTXINV._EXAM5 = WrkExam(4)
      Else
        myTXINV._ETCA = "Y"
        myTXINV._EXCD1 = WrkCCExcd(0)
        myTXINV._EXCD2 = WrkCCExcd(1)
        myTXINV._EXCD3 = WrkCCExcd(2)
        myTXINV._EXCD4 = WrkCCExcd(3)
        myTXINV._EXCD5 = WrkCCExcd(4)
        myTXINV._EXAM1 = WrkCCExam(0)
        myTXINV._EXAM2 = WrkCCExam(1)
        myTXINV._EXAM3 = WrkCCExam(2)
        myTXINV._EXAM4 = WrkCCExam(3)
        myTXINV._EXAM5 = WrkCCExam(4)
      End If
      myTXINV._LETT = .Item("lett")
      myTXINV._OID = .Item("oid")
      myTXINV._SSNo = .Item("ss#")
      myTXINV._SS2 = .Item("ss2")
    End With
    myTXINV.AddOneRecordP()
    If myTXINV.ErrMsg <> "" Then
      WriteErrorLog(myTXINV.ErrMsg)
      Exit Sub
    End If
  End Sub
  Private Sub BufferTXSupcd()
    Dim I As Integer

    Dim myTXSUPCD As TXSUPCD.MyData
    Dim dsTXSupcd As DataSet = New DataSet

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)

    dsTXSupcd = myTXSUPCD.PosData("")
    For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupMonth(I) = .Item("smon")
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
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    WrkPct = WrkSupPct(K)
    Return WrkPct
  End Function
  Public Function CalcMvPct(ByVal WrkType As String, ByVal WrkCode As String) As Decimal
    Dim WrkAmount As Decimal

    myTXMVPCT.GetOneRecordP(WrkType, WrkCode)
    If myTXMVPCT.RecordNotFound Then Exit Function

    With myTXMVPCT
      WrkAmount = ._PCT
    End With

    Return WrkAmount
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Decimal

    If MyProRateRound Then
      WrkProRate = MyUtils.Round10(Value * Pct, 0)
    Else
      WrkProRate = MyUtils.Round(Value * Pct, 0)
    End If
    Return WrkProRate
  End Function
  Public Function BuildPropDesc(ByVal I As Integer) As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    With DsTXSUPP.Tables(0).Rows(I)
      sb.Append(.Item("year"))
      sb.Append(" ")
      sb.Append(MyUtils.JustifyLeft(.Item("make"), 6))
      sb.Append(MyUtils.JustifyLeft(.Item("model"), 9))
      sb.Append(MyUtils.JustifyLeft(.Item("vinno"), 18))
      sb.Append(MyUtils.JustifyLeft(.Item("regno"), 8))
    End With

    Return sb.ToString
  End Function
  Public Function BuildPropDesc2(ByVal I As Integer, ByVal VIN As Boolean) As String
    Dim sb As StringBuilder


    sb = New StringBuilder
    With DsTXSUPP.Tables(0).Rows(I)
      If .Item("oyear") = 0 Then
        Return ""
      End If
      sb.Append(.Item("oyear"))
      sb.Append(" ")
      sb.Append(MyUtils.JustifyLeft(.Item("omake"), 6))
      sb.Append(MyUtils.JustifyLeft(.Item("omod"), 9))
      If VIN Then
        sb.Append(MyUtils.JustifyLeft(.Item("ovin"), 18))
      End If
      sb.Append(MyUtils.JustifyLeft(.Item("oreg#"), 8))
    End With

    Return sb.ToString
  End Function
  Public Function BuildAddlDesc() As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    sb.Append(MyUtils.JustifyRight(Format(WrkGross, "###,###"), 7))
    sb.Append(" X ")
    sb.Append(Format(WrkProratePct, ".000"))
    sb.Append(" = ")
    sb.Append(MyUtils.JustifyRight(Format(WrkProrate, "###,###"), 7))

    Return sb.ToString
  End Function
  Public Function BuildAddlDesc2() As String
    Dim sb As StringBuilder

    If WrkOGross = 0 Then
      Return ""
    End If
    sb = New StringBuilder
    sb.Append(MyUtils.JustifyRight(Format(WrkOGross, "###,###"), 7))
    sb.Append(" X ")
    sb.Append(Format(WrkCreditPct, ".000"))
    sb.Append(" = ")
    sb.Append(MyUtils.JustifyRight(Format(WrkCredit, "###,###"), 7))

    Return sb.ToString
  End Function
End Module

