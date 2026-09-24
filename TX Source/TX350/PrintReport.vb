Imports System.Text
Imports System.io
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXINV As TXINV.myData

Dim ds As DataSet = New DataSet
Dim dsEscrow As DataSet = New DataSet
Dim dsBill As DataSet = New DataSet
Dim dsTot As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drBill As Data.DataRow
Dim drTot As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkDist As Integer
Dim WrkUpdate As Boolean
Dim WrkSortBy As String
Dim WrkElderly As Boolean
Dim WrkBarcode As Boolean
Dim WrkCSV As Boolean
Dim WrkHeadings As Boolean
Dim WrkComment As String
Dim WrkFamily As String

Dim WrkTotDesc(1) As String
Dim WrkTotCount(1) As Integer
Dim WrkTotGross(1) As Long
Dim WrkTotExemption(1) As Long
Dim WrkTotNet(1) As Long
Dim WrkTotTax(1) As Decimal
Dim WrkList As Integer
Dim WrkType As String
Dim WrkGross As Long
Dim WrkExemption As Long
Dim WrkNet As Long
Dim WrkTaxAmount As Decimal
Dim WrkTaxTotal As Decimal
Dim WrkWaivered As Boolean
Dim WrkNonEscrow As Boolean
Dim WrkNonEscrowBank As Boolean
Dim WrkBank As String
Dim WrkAlternative As Boolean
Dim WrkCC As Boolean
Dim WrkScanLine As String
Dim WrkPropDesc As String
Dim WrkPropDescFile As String

'Buffer Banks (RE)
Dim WrkBanksCode(400) As String
Dim WrkBanksPrnt(400) As Boolean
'Buffer Description (PP)
Dim WrkPPCode(100) As Integer
Dim WrkPPDesc(100) As String



 Public Sub PrtReport()
  myTXINVQ = New TXINVQ.mydata(MyDBConnect)
  myTXINV = New TXINV.mydata(MyDBConnect)

 'Clear Totals
 Array.Clear(WrkTotCount, 0, 1)
 Array.Clear(WrkTotNet, 0, 1)
 Array.Clear(WrkTotTax, 0, 1)

 With MyFrmTX350B
  WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
  WrkDist = MyUtils.CnvSng(.TxtDist.Text)
  WrkType = .TxtType.Text
  If .RbSortName.Checked Then
   WrkSortBy = "Name"
  End If
  If .RbSortZip.Checked Then
   WrkSortBy = "Zip"
  End If
  WrkElderly = .ChkElderly.Checked
  WrkUpdate = .ChkUpdate.Checked
  WrkNonEscrow = .RbSelNon.Checked
  WrkNonEscrowBank = .RbSelNonBanks.Checked
  WrkBank = .TxtBankCd.Text
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

 If WrkNonEscrow Or WrkNonEscrowBank Then
  BufferBanksEscrow()
 End If
 WrkFamily = GetTXTypeFamily(WrkType)
 If WrkFamily = "P" Then
  BufferPPDesc()
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
  .WrkGraceDate1 = ProfGrDt(0)
  .WrkMillRt = MrateMillrt * 1000
  .WrkType = WrkType
  .WrkFamily = WrkFamily
  .WrkPost = WrkUpdate
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
Dim K As Integer
Dim WrkAnd As String
Dim WrkBillType As String
Dim WrkCreateBill As Boolean
Dim WrkEscrowPrint As Boolean
Dim WrkBankCode As String
Dim Counter As Integer

WrkBillType = GetTXTypeDesc(WrkType) & " TAX BILL"
WrkFamily = GetTXTypeFamily(WrkType)

If MyServer = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
End If

WrkQry = "icode<>'I'" & WrkAnd & "YEAR=" & WrkGLYear & WrkAnd & "TYPE=" & MyUtils.Quo(WrkFamily) & WrkAnd & "FRCD<>'F'"
If WrkBank <> String.Empty Then
  WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBank)
End If
If Not WrkElderly Then
  WrkQry = WrkQry & WrkAnd & "FRCD<>'C'"
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

myTXINVQ.OpenQry(WrkSort, WrkQry)

If MyFrmTX350B.LblFilePath.Text <> String.Empty Then
  sw = New StreamWriter(MyFrmTX350B.LblFilePath.Text)
End If

If WrkHeadings Then
 Select Case WrkFamily
 Case "R"
   sw.WriteLine(HeadingsRECSV)
 Case "P"
   sw.WriteLine(HeadingsPPCSV)
 Case "M"
   sw.WriteLine(HeadingsMVCSV)
 Case "S"
   sw.WriteLine(HeadingsMSCSV)
 End Select
End If

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

GetTaxProfile(WrkType, WrkGLYear, "", WrkDist)
GetMillRate(WrkGLYear, WrkType, WrkDist)

ReadNext:
 myTXINVQ.ReadQry()
 If Not myTXINVQ.IsEOF Then
 With myTXINVQ
  Counter = Counter + 1
    WrkList = ._LISTNo
    WrkGross = 0
    WrkExemption = 0
    WrkNet = 0
    If ._CCNO > 0 Then
      If ._CCETAX > 0 Then
        WrkGross = ._CGRS
        WrkExemption = ._CCEXP
        WrkNet = ._CGRS - ._CCEXP
      End If
    Else
      WrkGross = ._GROSS
      WrkExemption = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
      WrkNet = ._NETASS
    End If
    WrkTaxTotal = MyUtils.Round(WrkNet * MrateMillrt, 2)
    WrkBankCode = Trim(._BKCD)

    K = 0
    WrkWaivered = False
    If ProfWaiver >= WrkTaxTotal Then 'Waivered
      WrkWaivered = True
      K = 1
    End If

    WrkTotCount(K) = WrkTotCount(K) + 1
    WrkTotGross(K) = WrkTotGross(K) + WrkGross
    WrkTotExemption(K) = WrkTotExemption(K) + WrkExemption
    WrkTotNet(K) = WrkTotNet(K) + WrkNet
    If WrkWaivered Then
      WrkTotTax(K) = WrkTotTax(K) + WrkTaxTotal
    Else
      WrkTotTax(K) = WrkTotTax(K) + WrkTaxTotal
    End If
    If WrkFamily = "P" Then
      WrkPropDesc = LookupPPDesc(._IPPCD1)
      If ._IPPCD2 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD2)
      End If
      If ._IPPCD3 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD3)
      End If
      If ._IPPCD4 > 0 Then
        WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(._IPPCD4)
      End If
      WrkPropDescFile = Replace(WrkPropDesc, ",", "-")
    End If

    'Create Report
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = ._LISTNo
    AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
    dr.Item("addr1") = AddrLine(0)
    dr.Item("gross") = WrkGross
    dr.Item("exemption") = WrkExemption
    dr.Item("net") = WrkNet
    dr.Item("taxtot") = WrkTaxTotal
    Select Case K
    Case 0
      dr.Item("group") = ""
    Case 1
      dr.Item("group") = "Waivered"
    End Select
    ds.Tables(0).Rows.Add(dr)

    'Filter - Omit Zero Bills and Waivered
    If WrkTaxTotal <= ProfWaiver Then
      GoTo NextRec
    End If

    WrkCreateBill = False
    'Filter - Check Non Escrow 
    If WrkNonEscrow Then
      If WrkBankCode <> String.Empty Or Trim(myTXINVQ._BKSR) <> String.Empty Then
        'Create Escrow List
        dr = dsEscrow.Tables(0).NewRow
        dr.Item("listno") = WrkList
        dr.Item("addr1") = AddrLine(0)
        dr.Item("gross") = WrkGross
        dr.Item("exemption") = WrkExemption
        dr.Item("net") = WrkNet
        dr.Item("taxtot") = WrkTaxTotal
        If WrkBankCode <> String.Empty Then
          dr.Item("group") = "CD:" & WrkBankCode
        Else
          dr.Item("group") = "SV:" & Trim(myTXINVQ._BKSR)
        End If
        dsEscrow.Tables(0).Rows.Add(dr)
        GoTo WriteExport
      End If
    End If

    'Filter - Check Non Escrow Plus Banks
    If WrkNonEscrowBank Then
      WrkEscrowPrint = LookupBanksEscrow(Trim(myTXINVQ._BKCD))
      If Not WrkEscrowPrint Or Trim(myTXINVQ._BKSR) <> String.Empty Then
        'Create Escrow List
        dr = dsEscrow.Tables(0).NewRow
        dr.Item("listno") = WrkList
        dr.Item("addr1") = AddrLine(0)
        dr.Item("gross") = WrkGross
        dr.Item("exemption") = WrkExemption
        dr.Item("net") = WrkNet
        dr.Item("taxtot") = WrkTaxTotal
        If Not WrkEscrowPrint Then
          dr.Item("group") = "CD:" & WrkBankCode
        Else
          dr.Item("group") = "SV:" & Trim(myTXINVQ._BKSR)
        End If
        dsEscrow.Tables(0).Rows.Add(dr)
        GoTo WriteExport
      End If
    End If

    WrkCreateBill = True

    If MyFrmTX350B.RbPrtBill.Checked Or MyFrmTX350B.LblFilePath.Text <> String.Empty Then
      If myTXFMBILL._SCAN = "W" Then
        WrkScanLine = BuildScanLineWebster(WrkList, WrkGLYear, WrkFamily, WrkTaxTotal, WrkTaxTotal, 0, "")
      Else
        WrkScanLine = BuildScanLine(WrkList, WrkGLYear, WrkFamily, WrkTaxTotal, WrkTaxTotal, "")
      End If
    End If

   'Filter - Print No Bills
    If MyFrmTX350B.RbPrtNoBill.Checked Then
      GoTo WriteExport
    End If

    'Create Billing File
    drBill = dsBill.Tables(0).NewRow
    drBill.Item("BillType") = WrkBillType
    drBill.Item("listno") = WrkList
    drBill.Item("year") = WrkGLYear
    drBill.Item("addr1") = AddrLine(0)
    drBill.Item("addr2") = AddrLine(1)
    drBill.Item("addr3") = AddrLine(2)
    drBill.Item("addr4") = AddrLine(3)
    drBill.Item("addr5") = AddrLine(4)
    drBill.Item("bank") = ._BKCD
    drBill.Item("gross") = WrkGross
    drBill.Item("exemption") = WrkExemption
    drBill.Item("net") = WrkNet
    drBill.Item("taxtot") = WrkTaxTotal
    Select Case WrkFamily
    Case "R"
      drBill.Item("propdesc") = Trim(._LOCNo) & " " & ._LOC
    Case "P"
      drBill.Item("propdesc") = WrkPropDesc
    End Select
    drBill.Item("propdesc2") = ""
    drBill.Item("barcode") = BuildBarCode(WrkList, WrkType, WrkGLYear)
    drBill.Item("scanline") = WrkScanLine
    dsBill.Tables(0).Rows.Add(drBill)

WriteExport:
 If MyFrmTX350B.LblFilePath.Text <> String.Empty And WrkCreateBill Then
   Select Case WrkFamily
   Case "R"
    If WrkCSV Then
      sw.WriteLine(DownloadRECSV)
    Else
      sw.WriteLine(DownloadREBill)
    End If
   Case "P"
    If WrkCSV Then
      sw.WriteLine(DownloadPPCSV)
    Else
      sw.WriteLine(DownloadPPBill)
    End If
   Case "M"
    If WrkCSV Then
      sw.WriteLine(DownloadMVCSV)
    Else
      sw.WriteLine(DownloadMVBill)
    End If
   Case "S"
    If WrkCSV Then
      sw.WriteLine(DownloadMSCSV)
    Else
      sw.WriteLine(DownloadMSBill)
    End If
   End Select
 End If
 If WrkUpdate Then
  WriteInvoice()
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

'Bill Totals
For K = 0 To 1
  drTot = dsTot.Tables(0).NewRow
  Select Case K
  Case 0
    drTot.Item("description") = "Regular Tax"
  Case 1
    drTot.Item("description") = "Waivered"
  End Select
  drTot.Item("count") = WrkTotCount(K)
  drTot.Item("gross") = WrkTotGross(K)
  drTot.Item("exemption") = WrkTotExemption(K)
  drTot.Item("net") = WrkTotNet(K)
  drTot.Item("taxtot") = WrkTotTax(K)
  dsTot.Tables(0).Rows.Add(drTot)
Next

If MyFrmTX350B.LblFilePath.Text <> String.Empty Then
 sw.Flush()
 sw.Close()
End If
myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Function DownloadREBill() As String
  Dim sb As StringBuilder
  Const CComma As String = ","
  Dim WrkInteger As Integer

  With myTXINVQ
    sb = New StringBuilder
    sb.Append(MyUtils.JustifyRight(String.Empty, 2))
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
    sb.Append(._NAME)
    sb.Append(CComma)
    sb.Append(._SNAME)
    sb.Append(CComma)
    sb.Append(._ADD1)
    sb.Append(CComma)
    sb.Append(._ADD2)
    sb.Append(CComma)
    sb.Append(._CITY)
    sb.Append(CComma)
    sb.Append(._STATE)
    sb.Append(CComma)
    sb.Append(Format(._ZIP5, "00000"))
    sb.Append(CComma)
    sb.Append(Format(._ZIP4, "0000"))
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
    Else
     WrkInteger = WrkTaxTotal * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
    Else
     WrkInteger = WrkTaxTotal * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
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
     sb.Append(MyUtils.JustifyRight(WrkExemption, 10))
    Else
     sb.Append(Format(WrkExemption, "000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(WrkNet, 10))
    Else
     sb.Append(Format(WrkNet, "000000000"))
    End If
    sb.Append(CComma)
    sb.Append(._LOCNo)
    sb.Append(CComma)
    sb.Append(._LOC)
    sb.Append(CComma)
    sb.Append(._BKCD)
    sb.Append(CComma)
    sb.Append(._MAP)
    sb.Append(CComma)
    sb.Append(._VOL)
    sb.Append(CComma)
    sb.Append(._IPAGE)
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(._DIST, 4))
    Else
     sb.Append(Format(._DIST, "000"))
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
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 11))
    Else
     sb.Append("000000000")
    End If
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 15))
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 11))
    Else
     WrkInteger = 0 * 100
     sb.Append(Format(WrkInteger, "000000000"))
    End If
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 1))
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(0, 5))
    Else
     sb.Append(Format(0, "0000"))
    End If
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 22))
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(0, 6))
    Else
     sb.Append(Format(0, "00000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(0, 9))
    Else
     sb.Append(Format(0, "00000000"))
    End If
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 26))
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 35))
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
    sb.Append(MyUtils.JustifyLeft(WrkComment, 45)) 'User Message
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 8))
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft("", 7)) 'Unit
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 9))
    Else
     WrkInteger = 0 * 100
     sb.Append(Format(WrkInteger, "0000000"))
    End If
    sb.Append(CComma)
    sb.Append(MyUtils.JustifyLeft(WrkScanLine, 70))
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
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
     sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal + 0, "fixed"), 13))
    Else
     WrkInteger = (WrkTaxTotal + 0) * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal + 0, "fixed"), 13))
    Else
     WrkInteger = (WrkTaxTotal + 0) * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
     sb.Append(Format(WrkInteger, "00000000000"))
    End If
    sb.Append(CComma)
    If WrkAlternative Then
     sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
    Else
     WrkInteger = 0 * 100
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
Private Function DownloadRECSV() As String
 Dim sb As StringBuilder
 Const CComma As String = ","
 Const CQuote As String = Chr(34)

 With myTXINVQ
  sb = New StringBuilder
  sb.Append(CQuote)
  sb.Append("")
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
  sb.Append(Trim(._NAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._SNAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD1))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD2))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._CITY))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._STATE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(WrkGross)
  sb.Append(CComma)
  sb.Append(WrkExemption)
  sb.Append(CComma)
  sb.Append(WrkNet)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._LOCNo))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._LOC))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._BKCD))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._MAP))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._VOL))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._IPAGE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(WrkDist)
  sb.Append(CComma)
  sb.Append(Format(MrateMillrt * 1000, "###.000"))
  sb.Append(CComma)
  sb.Append(myTOWN._TOWNBR)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(MyUtils.JustifyLeft("", 13))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(0)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append("")
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(0)
  sb.Append(CComma)
  sb.Append("")
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append("0")  'Tax Base Before
  sb.Append(CComma)
  sb.Append("0")  'Mill Rate Before
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(WrkComment) 'User Message
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("") 'Unit
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(WrkScanLine)
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(0) 'Sewer Use 3rd
  sb.Append(CComma)
  sb.Append(0) 'Sewer Use 4th
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
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
 End With
 Return sb.ToString
End Function
Private Function HeadingsRECSV() As String
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
 Return sb.ToString
End Function
Private Function DownloadPPBill() As String
 Dim sb As StringBuilder
 Const CComma As String = ","
 Dim WrkInteger As Integer

 With myTXINVQ
  sb = New StringBuilder
  sb.Append(MyUtils.JustifyRight(String.Empty, 2))
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
  sb.Append(._NAME)
  sb.Append(CComma)
  sb.Append(._SNAME)
  sb.Append(CComma)
  sb.Append(._ADD1)
  sb.Append(CComma)
  sb.Append(._ADD2)
  sb.Append(CComma)
  sb.Append(._CITY)
  sb.Append(CComma)
  sb.Append(._STATE)
  sb.Append(CComma)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CComma)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
  Else
   WrkInteger = WrkTaxTotal * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
  Else
   WrkInteger = WrkTaxTotal * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
  Else
   WrkInteger = 0 * 100
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
   sb.Append(MyUtils.JustifyRight(WrkExemption, 10))
  Else
   sb.Append(Format(WrkExemption, "000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(WrkNet, 10))
  Else
   sb.Append(Format(WrkNet, "000000000"))
  End If
  sb.Append(CComma)
  sb.Append(._LOCNo)
  sb.Append(CComma)
  sb.Append(._LOC)
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(WrkPropDescFile, 56))
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft("", 56)) 'Prop Desc 2
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(WrkDist, 4))
  Else
   sb.Append(Format(WrkDist, "000"))
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
  sb.Append(MyUtils.JustifyLeft("", 22))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 6))
  Else
   sb.Append(Format(0, "00000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 9))
  Else
   sb.Append(Format(0, "00000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 12))
  Else
   sb.Append("0000000000") 'Tax Base Before
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(".000", 7))
  Else
   sb.Append("000000") 'Mill Rate Before
  End If
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(WrkComment, 45)) 'User Message
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(WrkScanLine, 70))
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft("", 30)) 'EDP Text
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 11))
  Else
   sb.Append("0000000000") 'EDP Amount
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
  Else
   WrkInteger = 0 * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
  Else
   WrkInteger = 0 * 100
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
  If WrkBarcode Then
   sb.Append(CComma)
   sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
  End If
 End With
 Return sb.ToString
End Function
Private Function DownloadPPCSV() As String
 Dim sb As StringBuilder
 Const CComma As String = ","
 Const CQuote As String = Chr(34)

 With myTXINVQ
  sb = New StringBuilder
  sb.Append(CQuote)
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
  sb.Append(Trim(._NAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._SNAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD1))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD2))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._CITY))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._STATE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(WrkGross)
  sb.Append(CComma)
  sb.Append(WrkExemption)
  sb.Append(CComma)
  sb.Append(WrkNet)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._LOCNo))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._LOC))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(WrkPropDescFile)
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("") 'Prop Desc 2
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(WrkDist)
  sb.Append(CComma)
  sb.Append(Format(MrateMillrt * 1000, "###.000"))
  sb.Append(CComma)
  sb.Append(myTOWN._TOWNBR)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(0)
  sb.Append(CComma)
  sb.Append("")
  sb.Append(CComma)
  sb.Append("0")  'Tax Base Before
  sb.Append(CComma)
  sb.Append("0")  'Mill Rate Before
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(WrkComment) 'User Message
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(WrkScanLine)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("") 'EDP Text
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append("0")  'EDP Amount
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
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
 End With
 Return sb.ToString
End Function
Private Function HeadingsPPCSV() As String
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
 sb.Append("PROPERTY DESC1")
 sb.Append(CComma)
 sb.Append("PROPERTY DESC2")
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
 sb.Append("USER MESSAGE")
 sb.Append(CComma)
 sb.Append("OCR SCAN LINE")
 sb.Append(CComma)
 sb.Append("EDP TEXT")
 sb.Append(CComma)
 sb.Append("EDP AMOUNT")
 sb.Append(CComma)
 sb.Append("TOTAL DUE 3RD")
 sb.Append(CComma)
 sb.Append("TOTAL DUE 4TH")
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
 Return sb.ToString
End Function
Private Function DownloadMVBill() As String
 Dim sb As StringBuilder
 Const CComma As String = ","
 Dim WrkInteger As Integer

 With myTXINVQ
  sb = New StringBuilder
  sb.Append(MyUtils.JustifyRight(String.Empty, 2))
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
  sb.Append(._NAME)
  sb.Append(CComma)
  sb.Append(._SNAME)
  sb.Append(CComma)
  sb.Append(._ADD1)
  sb.Append(CComma)
  sb.Append(._ADD2)
  sb.Append(CComma)
  sb.Append(._CITY)
  sb.Append(CComma)
  sb.Append(._STATE)
  sb.Append(CComma)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CComma)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
  Else
   WrkInteger = WrkTaxTotal * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
  Else
   WrkInteger = WrkTaxTotal * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
  Else
   WrkInteger = 0 * 100
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
   sb.Append(MyUtils.JustifyRight(WrkExemption, 10))
  Else
   sb.Append(Format(WrkExemption, "000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(WrkNet, 10))
  Else
   sb.Append(Format(WrkNet, "000000000"))
  End If
  sb.Append(CComma)
  sb.Append(._IMVREG)
  sb.Append(CComma)
  sb.Append(._MODEL)
  sb.Append(CComma)
  sb.Append(._MAKE)
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(._MVYR, 5))
  Else
   sb.Append(Format(._MVYR, "0000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(._CLASS, 3))
  Else
   sb.Append(Format(._CLASS, "00"))
  End If
  sb.Append(CComma)
  sb.Append(._IMVIDNo)
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(WrkDist, 4))
  Else
   sb.Append(Format(WrkDist, "000"))
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
  sb.Append(MyUtils.JustifyLeft("", 22))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 6))
  Else
   sb.Append(Format(0, "00000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 9))
  Else
   sb.Append(Format(0, "00000000"))
  End If
  sb.Append(CComma)
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
  sb.Append(MyUtils.JustifyLeft(._ILEASE, 2))
  If WrkBarcode Then
   sb.Append(CComma)
   sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
  End If
 End With

 Return sb.ToString
End Function
Private Function DownloadMVCSV() As String
 Dim sb As StringBuilder
 Const CComma As String = ","
 Const CQuote As String = Chr(34)

 With myTXINVQ
  sb = New StringBuilder
  sb.Append(CQuote)
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
  sb.Append(Trim(._NAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._SNAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD1))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD2))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._CITY))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._STATE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(WrkGross)
  sb.Append(CComma)
  sb.Append(WrkExemption)
  sb.Append(CComma)
  sb.Append(WrkNet)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._IMVREG))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._MODEL))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._MAKE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(._MVYR)
  sb.Append(CComma)
  sb.Append(._CLASS)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._IMVIDNo))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(WrkDist)
  sb.Append(CComma)
  sb.Append(Format(MrateMillrt * 1000, "###.000"))
  sb.Append(CComma)
  sb.Append(myTOWN._TOWNBR)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(0)
  sb.Append(CComma)
  sb.Append("")
  sb.Append(CComma)
  sb.Append("0")  'Tax Base Before
  sb.Append(CComma)
  sb.Append("0")  'Mill Rate Before
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(WrkComment) 'User Message
  sb.Append(CQuote)
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
  sb.Append(Trim(._ILEASE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
 End With
 Return sb.ToString
End Function
Private Function HeadingsMVCSV() As String
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
 sb.Append("USER MESSAGE")
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
 Return sb.ToString
End Function
Private Function DownloadMSBill() As String
  Dim sb As StringBuilder
  Dim WrkTxSupCd As String()
  Dim WrkProratePct As Decimal
  Dim WrkProrate As Integer
  Dim WrkCredit As Integer
  Const CComma As String = ","
  Dim WrkInteger As Integer

  With myTXINVQ
    WrkTxSupCd = GetTXSupCd(._ASS)
    WrkProratePct = MyUtils.CnvSng(WrkTxSupCd(0))
    WrkProrate = ._GROSS * WrkProratePct
    WrkCredit = ._ICVGRS * WrkProratePct
    sb = New StringBuilder
    sb.Append(MyUtils.JustifyRight(String.Empty, 2))
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
  sb.Append(._NAME)
  sb.Append(CComma)
  sb.Append(._SNAME)
  sb.Append(CComma)
  sb.Append(._ADD1)
  sb.Append(CComma)
  sb.Append(._ADD2)
  sb.Append(CComma)
  sb.Append(._CITY)
  sb.Append(CComma)
  sb.Append(._STATE)
  sb.Append(CComma)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CComma)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
  Else
   WrkInteger = WrkTaxTotal * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(WrkTaxTotal, "fixed"), 13))
  Else
   WrkInteger = WrkTaxTotal * 100
   sb.Append(Format(WrkInteger, "00000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(Format(0, "fixed"), 13))
  Else
   WrkInteger = 0 * 100
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
   sb.Append(MyUtils.JustifyRight(WrkExemption, 10))
  Else
   sb.Append(Format(WrkExemption, "000000000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(WrkNet, 10))
  Else
   sb.Append(Format(WrkNet, "000000000"))
  End If
  sb.Append(CComma)
  sb.Append(._IMVREG)
  sb.Append(CComma)
  sb.Append(._MODEL)
  sb.Append(CComma)
  sb.Append(._MAKE)
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(._MVYR, 5))
  Else
   sb.Append(Format(._MVYR, "0000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(._CLASS, 3))
  Else
   sb.Append(Format(._CLASS, "00"))
  End If
  sb.Append(CComma)
  sb.Append(._IMVIDNo)
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(WrkDist, 4))
  Else
   sb.Append(Format(WrkDist, "000"))
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
  sb.Append(MyUtils.JustifyLeft("", 22))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 6))
  Else
   sb.Append(Format(0, "00000"))
  End If
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(0, 9))
  Else
   sb.Append(Format(0, "00000000"))
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
   sb.Append(MyUtils.JustifyRight(._ICVYR, 5))
  Else
   sb.Append(Format(._ICVYR, "0000"))
  End If
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(._ICVMKE, 5))
  sb.Append(CComma)
  If WrkAlternative Then
   sb.Append(MyUtils.JustifyRight(._ICVCLS, 3))
  Else
   sb.Append(Format(._ICVCLS, "00"))
  End If
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(._ICVREG, 8))
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(._ICVIDNo, 17))
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(._ICVMOD, 8))
  sb.Append(CComma)
  sb.Append("NEWEST VEHICLE")
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(._ASS & " " & WrkTxSupCd(1), 5))
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
   sb.Append(MyUtils.JustifyRight(._ICVGRS, 10))
  Else
   sb.Append(Format(._ICVGRS, "000000000"))
  End If
  sb.Append(CComma)
  sb.Append("X")
  sb.Append(CComma)
  If ._ICVGRS > 0 Then
    WrkInteger = WrkProratePct * 1000
  Else
    WrkInteger = 0
  End If
  If WrkAlternative Then
    If ._ICVGRS > 0 Then
      sb.Append(MyUtils.JustifyRight(Format(WrkProratePct, "#.000"), 6))
    Else
      sb.Append(MyUtils.JustifyRight(Format(0, "#.000"), 6))
    End If
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
   sb.Append(MyUtils.JustifyRight(WrkExemption, 8))
  Else
   sb.Append(Format(WrkExemption, "0000000"))
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
  sb.Append(MyUtils.JustifyLeft(._ILEASE, 2))
  If WrkBarcode Then
   sb.Append(CComma)
   sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
  End If
 End With

  Return sb.ToString
End Function
Private Function DownloadMSCSV() As String
 Dim sb As StringBuilder
 Dim WrkTxSupCd As String()
 Dim WrkProratePct As Decimal
 Dim WrkProrate As Integer
 Dim WrkCredit As Integer
 Const CComma As String = ","
 Const CQuote As String = Chr(34)

 With myTXINVQ
  WrkTxSupCd = GetTXSupCd(._ASS)
  WrkProratePct = MyUtils.CnvSng(WrkTxSupCd(0))
  WrkProrate = ._GROSS * WrkProratePct
  WrkCredit = ._ICVGRS * WrkProratePct
  sb = New StringBuilder
  sb.Append(CQuote)
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
  sb.Append(Trim(._NAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._SNAME))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD1))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ADD2))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._CITY))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._STATE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP5, "00000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Format(._ZIP4, "0000"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(WrkTaxTotal, "fixed"))
  sb.Append(CComma)
  sb.Append(Format(0, "fixed"))
  sb.Append(CComma)
  sb.Append(WrkGross)
  sb.Append(CComma)
  sb.Append(WrkExemption)
  sb.Append(CComma)
  sb.Append(WrkNet)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._IMVREG))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._MODEL))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._MAKE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(._MVYR)
  sb.Append(CComma)
  sb.Append(._CLASS)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._IMVIDNo))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(WrkDist)
  sb.Append(CComma)
  sb.Append(Format(MrateMillrt * 1000, "###.000"))
  sb.Append(CComma)
  sb.Append(myTOWN._TOWNBR)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(0)
  sb.Append(CComma)
  sb.Append("")
  sb.Append(CComma)
  sb.Append("0")  'Tax Base Before
  sb.Append(CComma)
  sb.Append("0")  'Mill Rate Before
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(WrkComment) 'User Message
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(WrkComment) 'User Message 2
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(._ICVYR)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ICVMKE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(._ICVCLS)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ICVREG))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ICVIDNo))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(Trim(._ICVMOD))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("NEWEST VEHICLE")
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(MyUtils.JustifyLeft(._ASS & " " & WrkTxSupCd(1), 5))
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
  sb.Append(._ICVGRS)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append("X")
  sb.Append(CQuote)
  sb.Append(CComma)
  If ._ICVGRS > 0 Then
    sb.Append(WrkProratePct)
  Else
    sb.Append(0)
  End If
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
  sb.Append(WrkExemption)
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
  sb.Append(Trim(._ILEASE))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(BuildBarCode(WrkList, WrkType, WrkGLYear))
 End With
 Return sb.ToString
End Function
Private Function HeadingsMSCSV() As String
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
 Return sb.ToString
End Function
Private Sub WriteInvoice()

 If WrkTaxTotal = 0 Then Exit Sub

    With myTXINVQ
      myTXINV.GetOneRecordP(WrkList, WrkGLYear, WrkType)
      myTXINV._ICODE = ""
      myTXINV._LISTNo = WrkList
      myTXINV._YEAR = WrkGLYear
      myTXINV._TYPE = WrkType
      myTXINV._NAME = ._NAME
      myTXINV._SNAME = ._SNAME
      myTXINV._ADD1 = ._ADD1
      myTXINV._ADD2 = ._ADD2
      myTXINV._CITY = ._CITY
      myTXINV._STATE = ._STATE
      myTXINV._ZIP5 = Format(._ZIP5, "00000")
      myTXINV._ZIP4 = Format(._ZIP4, "0000")
      myTXINV._DIST = WrkDist
      myTXINV._PDST = 0
      myTXINV._TAXT = WrkTaxTotal
      myTXINV._TAX1 = WrkTaxTotal
      myTXINV._TAX2 = 0
      myTXINV._TX3RD = 0
      myTXINV._TX4TH = 0
      myTXINV._BALD = WrkTaxTotal
      myTXINV._GROSS = WrkGross
      myTXINV._TOTEXP = WrkExemption
      myTXINV._NETASS = WrkNet
      myTXINV._LOCNo = ._LOCNo
      myTXINV._LOC = ._LOC
      myTXINV._BKCD = ._BKCD
      myTXINV._MAP = ._MAP
      myTXINV._VOL = ._VOL
      myTXINV._BKSR = ._BKSR
      myTXINV._IPAGE = ._IPAGE
      myTXINV._FRCD = ""
      myTXINV._FRYR = 0
      myTXINV._FTAX = 0
      myTXINV._TWNBN = 0
      myTXINV._CPERC = 0
      myTXINV._CMAX = 0
      myTXINV._CMIN = 0
      myTXINV._IPPCD1 = ._IPPCD1
      myTXINV._IPPCD2 = ._IPPCD2
      myTXINV._IPPCD3 = ._IPPCD3
      myTXINV._IPPCD4 = ._IPPCD4
      myTXINV._IPPCD5 = ._IPPCD5
      myTXINV._IPPCD6 = ._IPPCD6
      myTXINV._IPPCD7 = ._IPPCD7
      myTXINV._IPPCD8 = ._IPPCD8
      myTXINV._IPPCD9 = ._IPPCD9
      myTXINV._IPPCDA = ._IPPCDA
      myTXINV._MVYR = ._MVYR
      myTXINV._MAKE = ._MAKE
      myTXINV._MODEL = ._MODEL
      myTXINV._BODY = ._BODY
      myTXINV._CLASS = ._CLASS
      myTXINV._IMVREG = ._IMVREG
      myTXINV._IMVIDNo = ._IMVIDNo
      myTXINV._DOB = ._DOB
      myTXINV._ILEASE = ._ILEASE
      myTXINV._ASS = ._ASS
      myTXINV._ICVACD = ._ICVACD
      myTXINV._ICVMKE = ._ICVMKE
      myTXINV._ICVMOD = ._ICVMOD
      myTXINV._ICVCLS = ._ICVCLS
      myTXINV._ICVREG = ._ICVREG
      myTXINV._ICVIDNo = ._ICVIDNo
      myTXINV._ICVGRS = ._ICVGRS
      myTXINV._ICVYR = ._ICVYR
      myTXINV._ETCA = ""
      If ._CCNO > 0 Then
        myTXINV._OAS1 = ._CASS1
        myTXINV._OAS2 = ._CASS2
        myTXINV._OAS3 = ._CASS3
        myTXINV._OAS4 = ._CASS4
        myTXINV._OAS5 = ._CASS5
        myTXINV._OAS6 = ._CASS6
        myTXINV._OAS7 = ._CASS7
        myTXINV._OAS8 = ._CASS8
        myTXINV._OAS9 = ._CASS9
        myTXINV._OAS10 = ._CASS10
        myTXINV._EXCD1 = ._CCCD1
        myTXINV._EXCD2 = ._CCCD2
        myTXINV._EXCD3 = ._CCCD3
        myTXINV._EXCD4 = ._CCCD4
        myTXINV._EXCD5 = ._CCCD5
        myTXINV._EXCD6 = ._CCCD6
        myTXINV._EXCD7 = ._CCCD7
        myTXINV._EXAM1 = ._CEXA1
        myTXINV._EXAM2 = ._CEXA2
        myTXINV._EXAM3 = ._CEXA3
        myTXINV._EXAM4 = ._CEXA4
        myTXINV._EXAM5 = ._CEXA5
        myTXINV._EXAM6 = ._CEXA6
        myTXINV._EXAM7 = ._CEXA7
      Else
        myTXINV._OAS1 = ._OAS1
        myTXINV._OAS2 = ._OAS2
        myTXINV._OAS3 = ._OAS3
        myTXINV._OAS4 = ._OAS4
        myTXINV._OAS5 = ._OAS5
        myTXINV._OAS6 = ._OAS6
        myTXINV._OAS7 = ._OAS7
        myTXINV._OAS8 = ._OAS8
        myTXINV._OAS9 = ._OAS9
        myTXINV._OAS10 = ._OAS10
        myTXINV._EXCD1 = ._EXCD1
        myTXINV._EXCD2 = ._EXCD2
        myTXINV._EXCD3 = ._EXCD3
        myTXINV._EXCD4 = ._EXCD4
        myTXINV._EXCD5 = ._EXCD5
        myTXINV._EXCD6 = ._EXCD6
        myTXINV._EXCD7 = ._EXCD7
        myTXINV._EXAM1 = ._EXAM1
        myTXINV._EXAM2 = ._EXAM2
        myTXINV._EXAM3 = ._EXAM3
        myTXINV._EXAM4 = ._EXAM4
        myTXINV._EXAM5 = ._EXAM5
        myTXINV._EXAM6 = ._EXAM6
        myTXINV._EXAM7 = ._EXAM7
      End If
      myTXINV._UNIT1 = ._UNIT1
      myTXINV._UNIT2 = ._UNIT2
      myTXINV._UNIT3 = ._UNIT3
      myTXINV._UNIT4 = ._UNIT4
      myTXINV._UNIT5 = ._UNIT5
      myTXINV._UNIT6 = ._UNIT6
      myTXINV._UNIT7 = ._UNIT7
      myTXINV._UNIT8 = ._UNIT8
      myTXINV._UNIT9 = ._UNIT9
      myTXINV._UNITA = ._UNITA
      myTXINV._LETT = ._LETT
    End With
    myTXINV.AddOneRecordP()
End Sub
Private Sub BufferBanksEscrow()
   Dim I As Integer
   Dim J As Integer

   Dim myTXBANKS As TXBANKS.myData
     Dim dsTXBANKS As DataSet = New DataSet

   myTXBANKS = New TXBANKS.mydata(MyDBConnect)

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

     If Code = "" Then Return True

     For I = 0 To WrkBanksCode.GetUpperBound(0)
      If Trim(WrkBanksCode(I)) = "" Then
        Return False
      End If
      If Trim(Code) = Trim(WrkBanksCode(I)) Then
        Return WrkBanksPrnt(I)
      End If
    Next

End Function
Private Sub BufferPPDesc()
     Dim I As Integer

   Dim myTXCode As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

   myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkFamily)
     For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkPPCode(I) = .Item("tccode")
        WrkPPDesc(I) = .Item("tcdesc")
      End With
    Next

End Sub
Private Function LookupPPDesc(ByVal Code As Integer) As String
     Dim I As Integer
     Dim WrkDesc As String

     For I = 0 To WrkPPCode.GetUpperBound(0)
       If WrkPPCode(I) = 0 Then
         Return ""
       End If
       If Code = WrkPPCode(I) Then
         WrkDesc = WrkPPDesc(I)
         Return WrkDesc
       End If
    Next

    Return ""
End Function
 Public Function GetTXSupCd(ByVal Code As String) As String()
  Dim Wrkstr(2) As String
  Dim myTXSUPCD As TXSUPCD.myData

  myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)
  If IsNothing(Code) Or Code = "" Then
   Wrkstr(0) = ""
   Wrkstr(1) = ""
   Wrkstr(2) = ""
   Return Wrkstr
  End If

  myTXSUPCD.GetOneRecordP(Code)
  If Not myTXSUPCD.RecordNotFound Then
   Wrkstr(0) = Format(myTXSUPCD._SPCT, ".000")
   Wrkstr(1) = Trim(myTXSUPCD._SMON)
   Wrkstr(2) = Trim(myTXSUPCD._SCRD)
  Else
   Wrkstr(1) = "*** Unknown ***"
  End If
  Return Wrkstr

 End Function
End Module






