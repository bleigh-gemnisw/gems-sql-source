Imports System.Text
Imports System.IO
Module PrintReportProrate

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPROMSQ As TXPROMSQ.MyData
  Dim myTXPROMS As TXPROMS.MyData
  Dim myTPaymnt As TPAYMNT.MyData
  Dim myTXINV As TXINV.MyData

  Dim ds As DataSet = New DataSet
  Dim dsBill As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTXPROMS As DataSet = New DataSet
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
  Dim WrkProDue1 As Date
  Dim WrkProDue2 As Date
  Dim WrkProGrace1 As Date
  Dim WrkProGrace2 As Date
  Dim WrkComment As String
  Dim WrkAlternative As Boolean
  Dim WrkBarcode As Boolean
  Dim WrkCSV As Boolean
  Dim WrkHeadings As Boolean

  Dim WrkTotDesc(2) As String
  Dim WrkTotCount(2) As Integer
  Dim WrkTotGross(2) As Long
  Dim WrkTotExemption(2) As Long
  Dim WrkTotNet(2) As Long
  Dim WrkTotTax(2) As Decimal
  Dim WrkTot1st(2) As Decimal
  Dim WrkTot2nd(2) As Decimal
  Dim WrkList As Integer
  Dim WrkType As String
  Dim WrkGross As Integer
  Dim WrkExempt As Integer
  Dim WrkNet As Integer
  Dim WrkTaxAmount As Decimal
  Dim WrkTaxTotal As Decimal
  Dim WrkTax1st As Decimal
  Dim WrkTax2nd As Decimal
  Dim WrkTax3rd As Decimal
  Dim WrkTax4th As Decimal
  Dim WrkWaivered As Decimal
  Dim WrkSTBenefit As Decimal
  Dim WrkTownBenefit As Decimal
  Dim WrkScanLine As String
  Dim WrkNewOwner As Boolean
  Dim WrkBillCount As Integer

  Public Sub PrtReportProrate()

    myTXPROMSQ = New TXPROMSQ.MyData(myDBConnect)
    myTXPROMS = New TXPROMS.MyData(myDBConnect)
    myTPaymnt = New TPAYMNT.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    'Clear Totals
    Array.Clear(WrkTotCount, 0, 3)
    Array.Clear(WrkTotGross, 0, 3)
    Array.Clear(WrkTotExemption, 0, 3)
    Array.Clear(WrkTotNet, 0, 3)
    Array.Clear(WrkTotTax, 0, 3)
    Array.Clear(WrkTot1st, 0, 3)
    Array.Clear(WrkTot2nd, 0, 3)

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
      WrkProDue1 = .DtPckProDue1.Value
      WrkProDue2 = .DtPckProDue2.Value
      WrkProGrace1 = .DtPckProGrace1.Value
      WrkProGrace2 = .DtPckProGrace2.Value
      WrkComment = .TxtComment.Text
      WrkAlternative = .ChkAlternative.Checked
      WrkBarcode = .ChkBarcode.Checked
      WrkCSV = .RbCSV.Checked
      WrkHeadings = .ChkHeadings.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSBill(dsBill)
      BuildDSTot(dsTot)
    Else
      ds.Clear()
      dsBill.Clear()
      dsTot.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkdsBill = dsBill
      .wrkdsTot = dsTot
      If MyFrmTX301B.RbProrate.Checked Then
        .WrkDueDate1 = WrkProDue1
        .WrkDueDate2 = WrkProDue2
        .WrkGraceDate1 = WrkProGrace1
        .WrkGraceDate2 = WrkProGrace2
      Else
        .WrkDueDate1 = ProfTxDt(0)
        .WrkDueDate2 = ProfTxDt(1)
        .WrkGraceDate1 = ProfGrDt(0)
        .WrkGraceDate2 = ProfGrDt(1)
      End If
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
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkBillType As String
    Dim WrkFamily As String

    WrkType = "X"
    WrkPhase = ""
    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, WrkType, WrkDist)
    WrkBillType = GetTXTypeDesc(WrkType) & " TAX BILL"
    'Wilton only
    If myTOWN._TOWNBR = 161 Then
      WrkBillType = GetTXTypeDesc(WrkType)
    End If
    WrkFamily = GetTXTypeFamily(WrkType)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "post<>'X'"

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

    dsTXPROMS = myTXPROMSQ.GetQry(WrkSort, WrkQry, 0)
    If dsTXPROMS.Tables(0).Rows.Count = 0 Then Exit Sub

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

    For I = 0 To (dsTXPROMS.Tables(0).Rows.Count - 1)
      If MyReportCancel Then Exit Sub
      With dsTXPROMS.Tables(0).Rows(I)
        WrkList = .Item("list#")
        WrkGross = .Item("gross")
        WrkExempt = .Item("tex")
        WrkNet = .Item("net")
        If WrkNet < 0 Then WrkNet = 0
        WrkTaxTotal = WrkNet * MrateMillrt
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
        If WrkWaivered > 0 Then 'Waivered
          K = 1
        End If
        If WrkTaxTotal = 0 And K = 0 Then 'Net Zero Tax
          K = 2
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
            dr.Item("group") = "Waivered"
          Case 2
            dr.Item("group") = "Net Zero Tax"
        End Select
        ds.Tables(0).Rows.Add(dr)

        'Filter - Omit Zero Bills 
        If WrkTaxTotal = 0 Then
          GoTo NextRec
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
        drBill.Item("bank") = .Item("bkcd")
        drBill.Item("gross") = WrkGross
        drBill.Item("exemption") = WrkExempt
        drBill.Item("net") = WrkNet
        drBill.Item("taxtot") = WrkTaxTotal
        drBill.Item("tax1st") = WrkTax1st
        drBill.Item("tax2nd") = WrkTax2nd
        Select Case WrkFamily
          Case "M", "S"
            drBill.Item("propdesc") = .Item("make") & " " & .Item("mvyr") & " " & .Item("imvreg")
          Case "R"
            drBill.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
            drBill.Item("propdesc2") = "Map: " & .Item("map")
          Case Else
            drBill.Item("propdesc") = .Item("loc#") & " " & .Item("loc")
            drBill.Item("propdesc2") = ""
        End Select
        If .Item("btc") = "BT" Then
          drBill.Item("backtax") = True
        Else
          drBill.Item("backtax") = False
        End If
        drBill.Item("barcode") = BuildBarCode(WrkList, WrkType, WrkGLYear)
        drBill.Item("scanline") = WrkScanLine
      End With
      dsBill.Tables(0).Rows.Add(drBill)
WriteExport:
      If MyFrmTX301B.LblFilePath.Text <> String.Empty Then
        If WrkCSV Then
          sw.WriteLine(DownloadCSV(I))
        Else
          sw.WriteLine(DownloadRPBill(I))
        End If
      End If
      If WrkUpdate Then
        WriteProrateInvoice(I)
        UpdateTXPROMS()
      End If
WriteBill:

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / dsTXPROMS.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Bill Totals
    For K = 0 To 2
      drTot = dsTot.Tables(0).NewRow
      Select Case K
        Case 0
          drTot.Item("description") = "Regular Tax"
        Case 1
          drTot.Item("description") = "Waivered"
        Case 2
          drTot.Item("description") = "Net Zero Tax"
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
    myTXPROMSQ.CloseFile()

  End Sub
  Private Function DownloadRPBill(ByVal I As Integer) As String
    Dim sb As StringBuilder
    Const COwtext As String = "OWNER OF RECORD 10/01"
    Const CComma As String = ","
    Dim WrkSewerUse As Decimal
    Dim WrkSewerUse1st As Decimal
    Dim WrkSewerUse2nd As Decimal
    Dim WrkInteger As Integer

    With dsTXPROMS.Tables(0).Rows(I)
      sb = New StringBuilder
      sb.Append(MyUtils.JustifyLeft(.Item("btc"), 2))
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
      sb.Append(MyUtils.JustifyLeft(.Item("xpage"), 5))
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
      sb.Append(MyUtils.JustifyLeft("", 13))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append("        0")
      Else
        sb.Append("000000000")
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft("", 15))
      sb.Append(CComma)
      WrkInteger = WrkSTBenefit * 100
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(Format(WrkSTBenefit, "fixed"), 11))
      Else
        sb.Append(Format(WrkInteger, "000000000"))
      End If
      sb.Append(CComma)
      sb.Append(" ")
      sb.Append(CComma)
      sb.Append("0000")
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft("", 22))
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 6))
      Else
        sb.Append("00000")
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 9))
      Else
        sb.Append("00000000")
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
        sb.Append(MyUtils.JustifyRight(0, 12))
      Else
        sb.Append("0000000000") 'Tax Base Before
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 7))
      Else
        sb.Append("000000") 'Mill Rate Before
      End If
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(WrkComment, 45)) 'User Message
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(String.Empty, 8))
      sb.Append(CComma)
      sb.Append(MyUtils.JustifyLeft(String.Empty, 7)) 'Unit
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
        sb.Append(MyUtils.JustifyRight(0, 13))
      Else
        sb.Append("00000000000") 'City Tax 
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 8))
      Else
        sb.Append("000000") 'City Mill Rate
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 13))
      Else
        sb.Append("00000000000") 'Fire Dist Tax 
      End If
      sb.Append(CComma)
      If WrkAlternative Then
        sb.Append(MyUtils.JustifyRight(0, 8))
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
    Const CCText As String = ""
    Const COwtext As String = "OWNER OF RECORD 10/01/"
    Dim WrkSewerUse As Decimal
    Dim WrkSewerUse1st As Decimal
    Dim WrkSewerUse2nd As Decimal

    With dsTXPROMS.Tables(0).Rows(I)
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
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(0)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(0)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
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
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(0)
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
      sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
      sb.Append(CComma)
      sb.Append(Mid(WrkGLYear, 3, 2) & WrkType & WrkList)
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
    sb.Append("NAME")
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
    sb.Append("BAR CODE")
    sb.Append(CComma)
    sb.Append("ACCOUNT ID")
    Return sb.ToString
  End Function
  Private Sub WriteProrateInvoice(ByVal I As Integer)

    If WrkTaxTotal = 0 Then Exit Sub

    With dsTXPROMS.Tables(0).Rows(I)
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
      If WrkUpdateDist Then
        myTXINV._DIST = .Item("dist")
      Else
        myTXINV._DIST = 0
      End If
      myTXINV._PDST = 0
      myTXINV._TAXT = WrkTaxTotal
      myTXINV._TAX1 = WrkTax1st
      myTXINV._TAX2 = WrkTax2nd
      myTXINV._BALD = WrkTaxTotal
      myTXINV._GROSS = WrkGross
      myTXINV._TOTEXP = WrkExempt
      myTXINV._NETASS = WrkNet
      myTXINV._LOCNo = MyUtils.JustifyRight(.Item("loc#"), 7)
      myTXINV._LOC = .Item("loc")
      myTXINV._BKCD = .Item("bkcd")
      myTXINV._MAP = .Item("map")
      myTXINV._VOL = .Item("vol")
      myTXINV._IPAGE = .Item("xpage")
      myTXINV._UNIT1 = 1
      myTXINV._IPPCD1 = 11
      myTXINV._LETT = .Item("lett")
      myTXINV._PCD = .Item("cotype")
      myTXINV._PDAT = MyUtils.SetDBDate(WrkProDue1)
    End With
    myTXINV.AddOneRecordP()
    If myTXINV.ErrMsg <> "" Then
      WriteErrorLog(myTXINV.ErrMsg)
      Exit Sub
    End If

  End Sub
  Private Sub UpdateTXPROMS()

    myTXPROMS.GetOneRecordP(WrkList)
    If myTXPROMS.RecordNotFound Then Exit Sub

    With myTXPROMS
      ._POST = "X"
      .UpdateOneRecordP()
    End With

  End Sub
End Module