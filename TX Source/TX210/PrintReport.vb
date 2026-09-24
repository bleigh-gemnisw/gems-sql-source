Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Public MyReportCancel As Boolean
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXINV As TXINVQ.myData
Dim myTXHSTL4 As TXHSTL4.myData
Dim ds1 As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkGLYear As Integer
Dim WrkFrom As Integer
Dim WrkTo As Integer
Dim WrkDist As Integer
Dim WrkDistAll As Boolean
Dim WrkPhs As String
Dim WrkSortBy As String

Dim WrkTotGross As Decimal
Dim WrkTotExempt As Decimal
Dim WrkTotNet As Decimal
Dim WrkTotTax As Decimal
Dim WrkTotTax1 As Decimal
Dim WrkTotTax2 As Decimal
Dim WrkTotAccts As Integer
Dim WrkTotUnpaidAccts As Integer
Dim WrkTotUnpaidBal As Decimal
Dim WrkTotSusAccts As Integer
Dim WrkTotSusTax As Decimal
Dim WrkBCCGross As Decimal
Dim WrkBCCExempt As Decimal
Dim WrkBCCNet As Decimal
Dim WrkBCCTax As Decimal
Dim WrkBCCTax1 As Decimal
Dim WrkBCCTax2 As Decimal
Dim WrkCC As Boolean
Dim WrkTotCCGross As Decimal
Dim WrkTotCCExempt As Decimal
Dim WrkTotCCTax As Decimal
Dim WrkTotCCTax1 As Decimal
Dim WrkTotCCTax2 As Decimal
Dim WrkSuspense As Boolean
  Public Sub PrtReport()
  myTXINV = New TXINVQ.mydata(MyDBConnect)
	myTXHSTL4 = New TXHSTL4.mydata(MyDBConnect)

  With MyFrmTX210B
    WrkType = .TxtType.Text
    WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
    WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
    WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
    WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    WrkDistAll = False
    If .TxtDist.Text = "" Then
      WrkDistAll = True
    End If
    If .RbSortName.Checked Then
      WrkSortBy = "Name"
    End If
    If .RbSortList.Checked Then
      WrkSortBy = "List"
    End If
  End With

  InitSharedFiles()
  If ds1.Tables.Count = 0 Then
    BuildDS(ds1)
    BuildDS2(ds2)
    If WrkType = "P" Then
      BufferPPDesc(WrkType)
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

Private Sub ClearTotals()
  WrkTotGross = 0
  WrkTotExempt = 0
  WrkTotNet = 0
  WrkTotTax = 0
  WrkTotTax1 = 0
  WrkTotTax2 = 0
  WrkTotAccts = 0
  WrkTotUnpaidAccts = 0
  WrkTotUnpaidBal = 0
  WrkTotSusAccts = 0
  WrkTotSusTax = 0
  WrkBCCGross = 0
  WrkBCCExempt = 0
  WrkBCCNet = 0
  WrkBCCTax = 0
  WrkBCCTax1 = 0
  WrkBCCTax2 = 0
  WrkTotCCGross = 0
  WrkTotCCExempt = 0
  WrkTotCCTax = 0
  WrkTotCCTax1 = 0
  WrkTotCCTax2 = 0

End Sub
Private Sub GetDetail()
Dim WrkList As Integer
Dim WrkYear As Integer
Dim AddrLine() As String
Dim WrkTypeDesc As String
Dim WrkTypeFamily As String
Dim WrkPaid As Decimal
Dim WrkIntPaid As Decimal
Dim WrkLienPaid As Decimal
Dim WrkCCNo As Integer
Dim WrkCCGrossChg As Integer
Dim WrkCCExemptChg As Integer
Dim WrkCCTax As Decimal
Dim WrkCCTax1 As Decimal
Dim WrkCCTax2 As Decimal
Dim WrkCCDate As Date
Dim WrkSort As String
Dim WrkQry As String
Dim I As Integer
Dim WrkAnd As String
Dim WrkFrozenCode As String
Dim Counter As Integer

If myDBConnect.ServerName = "DB2" Then
  WrkAnd = " *and "
Else
  WrkAnd = " and "
 End If

Counter = 0
WrkSort = ""
Select Case WrkSortBy
Case "Name"
  WrkSort = "YEAR desc, FRCD, NAME"
Case "List"
  WrkSort = "YEAR desc, FRCD, LIST#"
End Select

If MyFrmTX210B.RbAll.Checked Then
  WrkQry = "icode<>'I'" & WrkAnd & "TYPE='" & WrkType & "'"
Else
  WrkQry = "icode<>'I'" & WrkAnd & "TYPE='" & WrkType & "'" & WrkAnd & "YEAR = " & WrkGLYear
End If
If Not WrkDistAll Then
  WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
End If

myTXINV.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

WrkTypeDesc = GetTXTypeDesc(WrkType)
WrkTypeFamily = GetTXTypeFamily(WrkType)

ReadNext:
  myTXINV.ReadQry()
  If Not myTXINV.IsEOF Then
    With myTXINV
      Counter = Counter + 1
      WrkList = ._LISTNo
      WrkYear = ._YEAR
      WrkDist = ._DIST
      If ._PHASE <> "0" Then
        WrkPhs = ._PHASE
      Else
        WrkPhs = ""
      End If
      WrkSuspense = False
      If ._ICODE = "S" Then
        WrkSuspense = True
      End If
      dr = ds1.Tables(0).NewRow
      GetHistory(._LISTNo, ._YEAR, WrkPaid, WrkIntPaid, WrkLienPaid)
      Select Case WrkTypeFamily
      Case "A", "U"
        GetLastCC_UB(WrkDist, WrkPhs, WrkList, WrkYear, WrkPaid, WrkTo, WrkCC, WrkCCNo, WrkCCTax, WrkCCDate, _
         WrkCCGrossChg, WrkCCExemptChg)
        PaySplit(WrkDist, WrkPhs, WrkList, WrkYear, WrkCCTax, WrkCCTax1, WrkCCTax2)
        dr.Item("ccno") = WrkCCNo
        dr.Item("ccetax") = WrkCCTax
        dr.Item("unpaidcc") = WrkCCTax - WrkPaid
        dr.Item("ccdate") = WrkCCDate
        dr.Item("cctx1") = WrkCCTax1
        dr.Item("cctx2") = WrkCCTax2
        If dr.Item("unpaidcc") < 0 Then
          dr.Item("unpaidcc") = 0
        End If
      Case Else
        GetLastCC(WrkDist, WrkPhs, WrkList, WrkYear, WrkPaid, WrkTo, WrkCC, WrkCCNo, WrkCCTax, WrkCCDate, _
         WrkCCGrossChg, WrkCCExemptChg)
        PaySplit(WrkDist, WrkPhs, WrkList, WrkYear, WrkCCTax, WrkCCTax1, WrkCCTax2)
        dr.Item("ccno") = WrkCCNo
        dr.Item("ccetax") = WrkCCTax
        dr.Item("unpaidcc") = WrkCCTax - WrkPaid
        dr.Item("ccdate") = WrkCCDate
        dr.Item("cctx1") = WrkCCTax1
        dr.Item("cctx2") = WrkCCTax2
        If dr.Item("unpaidcc") < 0 Then
          dr.Item("unpaidcc") = 0
        End If
      End Select

      If WrkCC Then
        dr.Item("unpaidtx") = 0
      Else
        dr.Item("unpaidtx") = ._TAXT - WrkPaid
        dr.Item("unpaidcc") = 0
      End If
      If dr.Item("unpaidtx") < 0 Then
        dr.Item("unpaidtx") = 0
      End If

      'Filter - Balances Only 
      If MyFrmTX210B.RbBalances.Checked Then
        If dr.Item("unpaidtx") = 0 And dr.Item("unpaidcc") = 0 Then
          GoTo NextRec
        End If
      End If
      'Filter - Paid Accounts Only 
      If MyFrmTX210B.RbPaid.Checked Then
        If dr.Item("unpaidtx") > 0 Or dr.Item("unpaidcc") > 0 Then
          GoTo NextRec
        End If
      End If

      'Filter - Addendum  
      If MyFrmTX210B.RbAddendum.Checked Then
        If dr.Item("pamt1") = 0 Then
          GoTo NextRec
        End If
      End If

      'Filter - All 
      If MyFrmTX210B.RbAll.Checked Then
        If dr.Item("pamt1") = 0 And Not WrkCC Then
          GoTo NextRec
        End If
        If dr.Item("pamt1") = 0 And WrkCC Then
          If WrkCCDate < MyUtils.GetDBDate(WrkFrom) Or WrkCCDate > MyUtils.GetDBDate(WrkTo) Then
            GoTo NextRec
          End If
        End If
      End If

      WrkTotAccts = WrkTotAccts + 1
      dr.Item("frcd") = ._FRCD
      dr.Item("listno") = WrkList
      dr.Item("year") = WrkYear
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
      If WrkSortBy = "Name" Then
        dr.Item("letter") = Mid(AddrLine(0), 1, 1)
      Else
        dr.Item("letter") = String.Empty
      End If
      dr.Item("addr1") = AddrLine(0)
      dr.Item("addr2") = AddrLine(1)
      dr.Item("addr3") = AddrLine(2)
      dr.Item("addr4") = AddrLine(3)
      dr.Item("addr5") = AddrLine(4)
      dr.Item("propdesc") = GetPropDesc(I, WrkTypeFamily)
      dr.Item("propdesc2") = GetPropDesc2(I, WrkTypeFamily)
      dr.Item("gross") = ._GROSS
      dr.Item("exempt") = ._TOTEXP
      dr.Item("net") = ._NETASS
      dr.Item("suspense") = WrkSuspense
      dr.Item("taxdue") = ._TAXT
      dr.Item("tax1") = ._TAX1
      dr.Item("tax2") = ._TAX2
      dr.Item("intpaid") = WrkIntPaid
      dr.Item("lienpaid") = WrkLienPaid

      WrkBCCGross = WrkBCCGross + ._GROSS
      WrkBCCExempt = WrkBCCExempt + ._TOTEXP
      WrkBCCNet = WrkBCCNet + ._NETASS
      WrkBCCTax = WrkBCCTax + ._TAXT
      WrkBCCTax1 = WrkBCCTax1 + ._TAX1
      WrkBCCTax2 = WrkBCCTax2 + ._TAX2
      WrkTotGross = WrkTotGross + ._GROSS
      WrkTotExempt = WrkTotExempt + ._TOTEXP
      WrkTotNet = WrkTotNet + ._NETASS
      WrkTotTax = WrkTotTax + ._TAXT
      WrkTotTax1 = WrkTotTax1 + ._TAX1
      WrkTotTax2 = WrkTotTax2 + ._TAX2
      If WrkCC Then
        Select Case WrkTypeFamily
        Case "A", "U"
          WrkTotCCTax = WrkTotCCTax + WrkCCTax - dr.Item("taxdue")
          WrkTotCCTax1 = WrkTotCCTax1 + WrkCCTax1 - dr.Item("tax1")
          WrkTotCCTax2 = WrkTotCCTax2 + WrkCCTax2 - dr.Item("tax2")
          If dr.Item("unpaidcc") > 0 Then
            If Not WrkSuspense Then
              WrkTotUnpaidAccts = WrkTotUnpaidAccts + 1
              WrkTotUnpaidBal = WrkTotUnpaidBal + dr.Item("unpaidcc")
            Else
              WrkTotSusTax = WrkTotSusTax + dr.Item("unpaidcc")
              WrkTotSusAccts = WrkTotSusAccts + 1
            End If
          End If
        Case Else
          WrkTotCCGross = WrkTotCCGross + WrkCCGrossChg
          WrkTotCCExempt = WrkTotCCExempt + WrkCCExemptChg
          WrkTotCCTax = WrkTotCCTax + WrkCCTax - dr.Item("taxdue")
          WrkTotCCTax1 = WrkTotCCTax1 + WrkCCTax1 - dr.Item("tax1")
          WrkTotCCTax2 = WrkTotCCTax2 + WrkCCTax2 - dr.Item("tax2")
          If dr.Item("unpaidcc") > 0 Then
            If Not WrkSuspense Then
              WrkTotUnpaidAccts = WrkTotUnpaidAccts + 1
              WrkTotUnpaidBal = WrkTotUnpaidBal + dr.Item("unpaidcc")
            Else
              WrkTotSusTax = WrkTotSusTax + dr.Item("unpaidcc")
              WrkTotSusAccts = WrkTotSusAccts + 1
            End If
          End If
        End Select
      Else
        If dr.Item("unpaidtx") > 0 Then
          If Not WrkSuspense Then
            WrkTotUnpaidAccts = WrkTotUnpaidAccts + 1
            WrkTotUnpaidBal = WrkTotUnpaidBal + dr.Item("unpaidtx")
          Else
            WrkTotSusTax = WrkTotSusTax + dr.Item("unpaidtx")
            WrkTotSusAccts = WrkTotSusAccts + 1
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
dr.Item("tgross") = WrkTotGross + WrkTotCCGross
dr.Item("texempt") = WrkTotExempt + WrkTotCCExempt
dr.Item("tnet") = WrkTotNet + WrkTotCCGross - WrkTotCCExempt
dr.Item("ttax") = WrkTotTax + WrkTotCCTax
dr.Item("ttax1") = WrkTotTax1 + WrkTotCCTax1
dr.Item("ttax2") = WrkTotTax2 + WrkTotCCTax2
dr.Item("taccts") = WrkTotAccts
dr.Item("tunpaidaccts") = WrkTotUnpaidAccts
dr.Item("tunpaidbal") = WrkTotUnpaidBal
dr.Item("tsusaccts") = WrkTotSusAccts
dr.Item("tsustax") = WrkTotSusTax
dr.Item("bccgross") = WrkBCCGross
dr.Item("bccexempt") = WrkBCCExempt
dr.Item("bccnet") = WrkBCCNet
dr.Item("bcctax") = WrkBCCTax
dr.Item("bcctax1") = WrkBCCTax1
dr.Item("bcctax2") = WrkBCCTax2
dr.Item("ccgross") = WrkTotCCGross
dr.Item("ccexempt") = WrkTotCCExempt
dr.Item("ccnet") = WrkTotCCGross - WrkTotCCExempt
dr.Item("cctax") = WrkTotCCTax
dr.Item("cctax1") = WrkTotCCTax1
dr.Item("cctax2") = WrkTotCCTax2
ds2.Tables(0).Rows.Add(dr)
myFrmProgress.Close()

myTXINV.CloseFile()

End Sub
Private Function GetPropDesc(ByVal I As Integer, ByVal WrkFamily As String) As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    Select Case WrkFamily
    Case "M", "S"
      With myTXINV
        sb.Append(Str(._MVYR))
        sb.Append(" ")
        sb.Append(Trim(._MAKE))
        sb.Append("     ")
        sb.Append(Str(._CLASS))
        sb.Append("     ")
        sb.Append(Trim(._IMVREG))
      End With
    Case "R"
      With myTXINV
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
      With myTXINV
        sb.Append(Trim(._LOCNo))
        sb.Append(" ")
        sb.Append(Trim(._LOC))
      End With
    End Select

    Return sb.ToString

End Function
Private Function GetPropDesc2(ByVal I As Integer, ByVal WrkFamily As String) As String
    Dim sb As StringBuilder
    Dim WrkDesc As String

    sb = New StringBuilder
    Select Case WrkFamily
    Case "M", "S"
      With myTXINV
        sb.Append(._IMVIDNo)
      End With
    Case "P"
      With myTXINV
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
Private Sub GetHistory(ByVal WrkListNo As Integer, ByVal WrkYear As Integer, ByRef Out_Paid As Decimal, _
 ByRef Out_IntPaid As Decimal, ByRef Out_LienPaid As Decimal)
Dim I As Integer
Dim J As Integer
Dim WrkPamt(9) As Decimal
Dim WrkPdate(9) As Integer
Dim WrkBatch(9) As Integer

Out_Paid = 0
Out_IntPaid = 0
Out_LienPaid = 0
DsTXHST = myTXHSTL4.GetViewbyList(WrkListNo, WrkYear, WrkType, WrkFrom, 999999)
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
End Module






