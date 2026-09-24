Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINVQ As TXINVQ.myData
Dim myTXHSTL4 As TXHSTL4.myData
Dim myTXCOEAL1 As TXCOEAL1.myData
Dim myUTCOEAL1 As UTCOEAL1.myData
Dim myTPaymnt As TPAYMNT.MyData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXINV As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim DsTXCOEA As DataSet = New DataSet
Dim DsUTCOEA As DataSet = New DataSet
Dim dr As Data.DataRow

'Screen fields
Dim WrkType As String
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkFromCCNo As Integer
Dim WrkToCCNo As Integer
Dim WrkFromReason As String
Dim WrkToReason As String
Dim WrkDist As Integer
Dim WrkPhs As String

Dim WrkTGross As Decimal
Dim WrkTExempt As Decimal
Dim WrkTNet As Decimal
Dim WrkTTax As Decimal
Dim WrkTTax1 As Decimal
Dim WrkTTax2 As Decimal
Dim WrkTAccts As Integer
Dim WrkTUnpaidAccts As Integer
Dim WrkTUnpaidBal As Decimal
Dim WrkTSusAccts As Integer
Dim WrkTSusTax As Decimal
Dim WrkBCCGross As Decimal
Dim WrkBCCExempt As Decimal
Dim WrkBCCNet As Decimal
Dim WrkBCCTax As Decimal
Dim WrkBCCTax1 As Decimal
Dim WrkBCCTax2 As Decimal
Dim WrkCC As Boolean
Dim WrkCCGross As Decimal
Dim WrkCCExempt As Decimal
Dim WrkCCTax As Decimal
Dim WrkCCTax1 As Decimal
Dim WrkCCTax2 As Decimal
Dim WrkSuspense As Boolean
Dim WrkPPCode(100) As Integer
Dim WrkPPDesc(100) As String
  Public Sub PrtReport()
	myTXINVQ = New TXINVQ.mydata(MyDBConnect)
	myTXHSTL4 = New TXHSTL4.mydata(MyDBConnect)
	myTXCOEAL1 = New TXCOEAL1.mydata(MyDBConnect)
	myUTCOEAL1 = New UTCOEAL1.mydata(MyDBConnect)
  myTPaymnt = New TPAYMNT.mydata(MyDBConnect)

  With MyFrmTX211B
    WrkType = .TxtType.Text
    If .DtPckFrom.Checked Then
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    Else
      WrkFrom = 0
    End If
    If .DtPckTo.Checked Then
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    Else
      WrkTo = 0
    End If
    WrkFromCCNo = MyUtils.CnvSng(.TxtFromCCNo.Text)
    WrkToCCNo = MyUtils.CnvSng(.TxtToCCNo.Text)
    WrkFromReason = .TxtFromReason.Text
    WrkToReason = .TxtToReason.Text
  End With

  If ds1.Tables.Count = 0 Then
    BuildDS()
    If WrkType = "P" Then
      BufferPPDesc()
    End If
  Else
    ds1.Clear()
    ds2.Clear()
    ClearTotals()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  MyCrViewer.Wrkds1 = ds1
  MyCrViewer.Wrkds2 = ds2
  MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("frcd", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Bkcd", Type.GetType("System.String"))
      .Columns.Add("frcddesc", Type.GetType("System.String"))
      .Columns.Add("Fryr", Type.GetType("System.Int32"))
      .Columns.Add("Gross", Type.GetType("System.Int64"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("Suspense", Type.GetType("System.Boolean"))
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
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("tgross", Type.GetType("System.Int64"))
      .Columns.Add("texempt", Type.GetType("System.Int64"))
      .Columns.Add("tnet", Type.GetType("System.Int64"))
      .Columns.Add("ttax", Type.GetType("System.Decimal"))
      .Columns.Add("ttax1", Type.GetType("System.Decimal"))
      .Columns.Add("ttax2", Type.GetType("System.Decimal"))
      .Columns.Add("taccts", Type.GetType("System.Int32"))
      .Columns.Add("tunpaidaccts", Type.GetType("System.Int32"))
      .Columns.Add("tunpaidbal", Type.GetType("System.Decimal"))
      .Columns.Add("tsusaccts", Type.GetType("System.Int32"))
      .Columns.Add("tsustax", Type.GetType("System.Decimal"))
      .Columns.Add("bccgross", Type.GetType("System.Int64"))
      .Columns.Add("bccexempt", Type.GetType("System.Int64"))
      .Columns.Add("bccnet", Type.GetType("System.Int64"))
      .Columns.Add("bcctax", Type.GetType("System.Decimal"))
      .Columns.Add("bcctax1", Type.GetType("System.Decimal"))
      .Columns.Add("bcctax2", Type.GetType("System.Decimal"))
      .Columns.Add("ccgross", Type.GetType("System.Int64"))
      .Columns.Add("ccexempt", Type.GetType("System.Int64"))
      .Columns.Add("ccnet", Type.GetType("System.Int64"))
      .Columns.Add("cctax", Type.GetType("System.Decimal"))
      .Columns.Add("cctax1", Type.GetType("System.Decimal"))
      .Columns.Add("cctax2", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
Private Sub ClearTotals()
  WrkTGross = 0
  WrkTExempt = 0
  WrkTNet = 0
  WrkTTax = 0
  WrkTTax1 = 0
  WrkTTax2 = 0
  WrkTAccts = 0
  WrkTUnpaidAccts = 0
  WrkTUnpaidBal = 0
  WrkTSusAccts = 0
  WrkTSusTax = 0
  WrkBCCGross = 0
  WrkBCCExempt = 0
  WrkBCCNet = 0
  WrkBCCTax = 0
  WrkBCCTax1 = 0
  WrkBCCTax2 = 0
  WrkCCGross = 0
  WrkCCExempt = 0
  WrkCCTax = 0
  WrkCCTax1 = 0
  WrkCCTax2 = 0

End Sub
Private Sub GetDetail()
Dim AddrLine() As String
Dim WrkTypeDesc As String
Dim WrkTypeFamily As String
Dim WrkPaid As Decimal
Dim WrkIntPaid As Decimal
Dim WrkLienPaid As Decimal
Dim WrkSort As String
Dim WrkQry As String
Dim Counter As Integer
Dim WrkAnd As String
Dim WrkFrozenCode As String
Dim SaveType As String

If myDBConnect.ServerName = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

Counter = 0
WrkSort = "TYPE, NAME, LIST#"
WrkQry = "icode<>'I'" & WrkAnd & "CCNO > 0"
If WrkType <> "" Then
  WrkQry = WrkQry & WrkAnd & "TYPE=" & MyUtils.Quo(WrkType)
End If
If WrkFrom > 0 Then
  WrkQry = WrkQry & WrkAnd & "CDATE>=" & WrkFrom
End If
If WrkTo > 0 Then
  WrkQry = WrkQry & WrkAnd & "CDATE<=" & WrkTo
End If
If WrkFromCCNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "CCNO>=" & WrkFromCCNo
End If
If WrkToCCNo > 0 Then
  WrkQry = WrkQry & WrkAnd & "CCNO<=" & WrkToCCNo
End If
If WrkFromReason <> "" Then
  WrkQry = WrkQry & WrkAnd & "CCRSN>=" & MyUtils.Quo(WrkFromReason)
End If
If WrkToReason <> "" Then
  WrkQry = WrkQry & WrkAnd & "CCRSN<=" & MyUtils.Quo(WrkToReason)
End If

myTXINVQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

SaveType = ""
WrkTypeDesc = ""
WrkTypeFamily = ""

ReadNext:
  myTXINVQ.ReadQry()
  If Not myTXINVQ.IsEOF Then
    With myTXINVQ
      Counter = Counter + 1
      If SaveType <> ._TYPE Then
        WrkTypeDesc = GetTXTypeDesc(._TYPE)
        WrkTypeFamily = GetTXTypeFamily(._TYPE)
      End If

      SaveType = ._TYPE
      WrkDist = ._DIST
      If ._PHASE <> 0 Then
        WrkPhs = ._PHASE
      Else
        WrkPhs = ""
      End If
      WrkSuspense = False
      If ._ICODE = "I" Then GoTo NextRec
      If ._ICODE = "S" Then
        WrkSuspense = True
      End If
      dr = ds1.Tables(0).NewRow
      WrkTAccts = WrkTAccts + 1
      dr.Item("frcd") = ._FRCD
      dr.Item("listno") = ._LISTNo
      dr.Item("year") = ._YEAR
      dr.Item("type") = ._TYPE
      dr.Item("typedesc") = WrkTypeDesc
      dr.Item("bkcd") = ._BKCD
      WrkFrozenCode = ._FRCD
      Select Case WrkFrozenCode
      Case "C"
        dr.Item("frcddesc") = "Elderly H.E.A.R.T."
      Case "F"
        dr.Item("frcddesc") = "Frozen"
      Case Else
        dr.Item("frcddesc") = ""
      End Select
      dr.Item("fryr") = ._FRYR
      AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2, _
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("propdesc") = GetPropDesc(WrkTypeFamily)
      dr.Item("propdesc2") = GetPropDesc2(WrkTypeFamily)
      dr.Item("gross") = ._GROSS
      dr.Item("exempt") = ._TOTEXP
      dr.Item("net") = ._NETASS
      dr.Item("suspense") = WrkSuspense
      dr.Item("taxdue") = ._TAXT
      dr.Item("tax1") = ._TAX1
      dr.Item("tax2") = ._TAX2
      GetHistory(._LISTNo, ._YEAR, ._TYPE, WrkPaid, WrkIntPaid, WrkLienPaid)
      dr.Item("unpaidtx") = dr.Item("taxdue") - WrkPaid
      If dr.Item("unpaidtx") < 0 Then
        dr.Item("unpaidtx") = 0
      End If
      dr.Item("intpaid") = WrkIntPaid
      dr.Item("lienpaid") = WrkLienPaid
      Select Case WrkTypeFamily
      Case "A", "U"
        GetLastCC_UB(._LISTNo, ._YEAR, ._TYPE, WrkPaid)
      Case Else
        GetLastCC(._LISTNo, ._YEAR, ._TYPE, WrkPaid)
      End Select
      If WrkCC Then
        dr.Item("unpaidtx") = 0
      Else
        dr.Item("unpaidcc") = 0
      End If

      WrkBCCGross = WrkBCCGross + ._GROSS
      WrkBCCExempt = WrkBCCExempt + ._TOTEXP
      WrkBCCNet = WrkBCCNet + ._NETASS
      WrkBCCTax = WrkBCCTax + ._TAXT
      WrkBCCTax1 = WrkBCCTax1 + ._TAX1
      WrkBCCTax2 = WrkBCCTax2 + ._TAX2
      WrkTGross = WrkTGross + ._GROSS
      WrkTExempt = WrkTExempt + ._TOTEXP
      WrkTNet = WrkTNet + ._NETASS
      WrkTTax = WrkTTax + ._TAXT
      WrkTTax1 = WrkTTax1 + ._TAX1
      WrkTTax2 = WrkTTax2 + ._TAX2
      If WrkCC Then
        Select Case WrkTypeFamily
        Case "A", "U"
          With DsUTCOEA.Tables(0).Rows(0)
            WrkCCGross = 0
            WrkCCExempt = 0
            WrkCCTax = WrkCCTax + .Item("cetax") - dr.Item("taxdue")
            WrkCCTax1 = WrkCCTax1 + dr.Item("cctx1") - dr.Item("tax1")
            WrkCCTax2 = WrkCCTax2 + dr.Item("cctx2") - dr.Item("tax2")
            If dr.Item("unpaidcc") > 0 Then
              If Not WrkSuspense Then
                WrkTUnpaidAccts = WrkTUnpaidAccts + 1
                WrkTUnpaidBal = WrkTUnpaidBal + dr.Item("unpaidcc")
              Else
                WrkTSusTax = WrkTSusTax + dr.Item("unpaidcc")
                WrkTSusAccts = WrkTSusAccts + 1
              End If
            End If
          End With
        Case Else
          With DsTXCOEA.Tables(0).Rows(0)
            WrkCCGross = WrkCCGross + .Item("grchg")
            WrkCCExempt = WrkCCExempt + .Item("exchg")
            WrkCCTax = WrkCCTax + .Item("cetax") - dr.Item("taxdue")
            WrkCCTax1 = WrkCCTax1 + dr.Item("cctx1") - dr.Item("tax1")
            WrkCCTax2 = WrkCCTax2 + dr.Item("cctx2") - dr.Item("tax2")
            If dr.Item("unpaidcc") > 0 Then
              If Not WrkSuspense Then
                WrkTUnpaidAccts = WrkTUnpaidAccts + 1
                WrkTUnpaidBal = WrkTUnpaidBal + dr.Item("unpaidcc")
              Else
                WrkTSusTax = WrkTSusTax + dr.Item("unpaidcc")
                WrkTSusAccts = WrkTSusAccts + 1
              End If
            End If
          End With
        End Select
      Else
        If dr.Item("unpaidtx") > 0 Then
          If Not WrkSuspense Then
            WrkTUnpaidAccts = WrkTUnpaidAccts + 1
            WrkTUnpaidBal = WrkTUnpaidBal + dr.Item("unpaidtx")
          Else
            WrkTSusTax = WrkTSusTax + dr.Item("unpaidtx")
            WrkTSusAccts = WrkTSusAccts + 1
          End If
        End If
      End If
    End With
    ds1.Tables(0).Rows.Add(dr)

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
dr.Item("tgross") = WrkTGross + WrkCCGross
dr.Item("texempt") = WrkTExempt + WrkCCExempt
dr.Item("tnet") = WrkTNet + WrkCCGross - WrkCCExempt
dr.Item("ttax") = WrkTTax + WrkCCTax
dr.Item("ttax1") = WrkTTax1 + WrkCCTax1
dr.Item("ttax2") = WrkTTax2 + WrkCCTax2
dr.Item("taccts") = WrkTAccts
dr.Item("tunpaidaccts") = WrkTUnpaidAccts
dr.Item("tunpaidbal") = WrkTUnpaidBal
dr.Item("tsusaccts") = WrkTSusAccts
dr.Item("tsustax") = WrkTSusTax
dr.Item("bccgross") = WrkBCCGross
dr.Item("bccexempt") = WrkBCCExempt
dr.Item("bccnet") = WrkBCCNet
dr.Item("bcctax") = WrkBCCTax
dr.Item("bcctax1") = WrkBCCTax1
dr.Item("bcctax2") = WrkBCCTax2
dr.Item("ccgross") = WrkCCGross
dr.Item("ccexempt") = WrkCCExempt
dr.Item("ccnet") = WrkCCGross - WrkCCExempt
dr.Item("cctax") = WrkCCTax
dr.Item("cctax1") = WrkCCTax1
dr.Item("cctax2") = WrkCCTax2
ds2.Tables(0).Rows.Add(dr)
myFrmProgress.Close()
myTXINVQ.CloseFile()

End Sub
Private Function GetPropDesc(ByVal WrkFamily As String) As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    Select Case WrkFamily
    Case "M", "S"
      With myTXINVQ
        sb.Append(Str(._MVYR))
        sb.Append(" ")
        sb.Append(Trim(._MAKE))
        sb.Append("     ")
        sb.Append(Str(._CLASS))
        sb.Append("     ")
        sb.Append(Trim(._IMVREG))
      End With
    Case "R"
      With myTXINVQ
        sb.Append(Trim(._LOCNo))
        sb.Append(" ")
        sb.Append(Trim(._LOC))
        sb.Append("     ")
        sb.Append(Trim(._MAP))
        sb.Append("     ")
        sb.Append(Trim(._VOL))
        sb.Append(" ")
        sb.Append(Trim(._IPAGE))
      End With
    Case Else
      With myTXINVQ
        sb.Append(Trim(._LOCNo))
        sb.Append(" ")
        sb.Append(Trim(._LOC))
      End With
    End Select

    Return sb.ToString

End Function
Private Function GetPropDesc2(ByVal WrkFamily As String) As String
    Dim sb As StringBuilder
    Dim WrkDesc As String

    sb = New StringBuilder
    Select Case WrkFamily
    Case "M", "S"
      With myTXINVQ
        sb.Append(._IMVIDNo)
      End With
    Case "P"
      With myTXINVQ
        WrkDesc = LookupPPDesc(._IPPCD1)
        sb.Append("-")
        sb.Append(Trim(WrkDesc))
        sb.Append(" ")
        WrkDesc = LookupPPDesc(._IPPCD2)
        If WrkDesc <> "" Then
          sb.Append("-")
          sb.Append(Trim(WrkDesc))
          sb.Append(" ")
        End If
      End With
    Case Else
      sb.Append(" ")
    End Select

    Return sb.ToString

End Function
Private Sub GetHistory(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, _
 ByVal WrkType As String, ByRef Out_Paid As Decimal, ByRef Out_IntPaid As Decimal, _
 ByRef Out_LienPaid As Decimal)
Dim I As Integer
Dim J As Integer
Dim WrkPamt(9) As Decimal
Dim WrkPdate(9) As Integer
Dim WrkBatch(9) As Integer

Out_Paid = 0
Out_IntPaid = 0
Out_LienPaid = 0
DsTXHST = myTXHSTL4.GetViewbyList(WrkListNo, WrkYear, WrkType, 0, 999999)
If DsTXHST.Tables(0).Rows.Count = 0 Then
  dr.Item("pamt1") = 0
  Exit Sub
End If

For I = 0 To (DsTXHST.Tables(0).Rows.Count - 1)
  With DsTXHST.Tables(0).Rows(I)
    If .Item("rcode") <> "I" And .Item("rcode") <> "V" Then
'      If .Item("pdate") >= WrkFrom And .Item("pdate") <= WrkTo Then
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
'      End If
    End If
  End With
Next

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
Private Sub GetLastCC(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, _
  ByVal WrkType As String, ByVal WrkPaid As Decimal)
  Dim WrkOutTax1 As Decimal
  Dim WrkOutTax2 As Decimal

    WrkCC = False
    DsTXCOEA = myTXCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkTo)
    If DsTXCOEA.Tables(0).Rows.Count > 0 Then
      With DsTXCOEA.Tables(0).Rows(0)
        WrkCC = True
        dr.Item("ccno") = .Item("ccno")
        dr.Item("ccetax") = .Item("cetax")
        dr.Item("unpaidcc") = .Item("cetax") - WrkPaid
        dr.Item("ccdate") = MyUtils.GetDBDate(.Item("cdate"))
        PaySplit(WrkListNo, WrkYear, WrkType, .Item("cetax"), WrkOutTax1, WrkOutTax2)
        dr.Item("cctx1") = WrkOutTax1
        dr.Item("cctx2") = WrkOutTax2
        If dr.Item("unpaidcc") < 0 Then
          dr.Item("unpaidcc") = 0
        End If
      End With
    End If

End Sub
Private Sub GetLastCC_UB(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, _
  ByVal WrkType As String, ByVal WrkPaid As Decimal)
  Dim WrkOutTax1 As Decimal
  Dim WrkOutTax2 As Decimal

    WrkCC = False
    DsUTCOEA = myUTCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkTo)
    If DsUTCOEA.Tables(0).Rows.Count > 0 Then
      With DsUTCOEA.Tables(0).Rows(0)
        WrkCC = True
        dr.Item("ccno") = .Item("ccno")
        dr.Item("ccetax") = .Item("cetax")
        dr.Item("unpaidcc") = .Item("cetax") - WrkPaid
        dr.Item("ccdate") = MyUtils.GetDBDate(.Item("cdate"))
        PaySplit(WrkListNo, WrkYear, WrkType, .Item("cetax"), WrkOutTax1, WrkOutTax2)
        dr.Item("cctx1") = WrkOutTax1
        dr.Item("cctx2") = WrkOutTax2
        If dr.Item("unpaidcc") < 0 Then
          dr.Item("unpaidcc") = 0
        End If
      End With
    End If

End Sub
Private Sub PaySplit(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, _
    ByVal WrkType As String, ByVal WrkTax As Decimal, _
    ByRef Out_Tax1 As Decimal, ByRef Out_Tax2 As Decimal)
  With myTPaymnt
    .In_Dst = WrkDist
    .In_ListNo = WrkListNo
    .In_Phs = WrkPhs
    .In_Type = WrkType
    .In_Year = WrkYear
    .In_TaxT = WrkTax
    .CalcPaySplit()
    Out_Tax1 = .Out_Tax1
    Out_Tax2 = .Out_Tax2
  End With
End Sub
Private Sub BufferPPDesc()
     Dim I As Integer

		 Dim myTXCode As TXCode.myData
     Dim dsTXCode As DataSet = New DataSet

		 myTXCode = New TXCode.mydata(MyDBConnect)

     dsTXCode = myTXCode.GetAllType(WrkType)
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
End Module






