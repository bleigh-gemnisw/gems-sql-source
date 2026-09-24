Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXCOEA As TXCOEA.MyData
  Dim myCASHINT As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsBill As DataSet = New DataSet
  Dim DsTXINV As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drBill As Data.DataRow

  Dim WrkBillAmount As Boolean
  Dim WrkGLYear As Integer
  Dim WrkDist As Integer
  Dim WrkPhase As String
  Dim WrkSortBy As String
  Dim WrkFamily As String
  Dim WrkProDue1 As Date
  Dim WrkProDue2 As Date
  Dim WrkProGrace1 As Date
  Dim WrkProGrace2 As Date
  Dim WrkTotDesc(2) As String
  Dim WrkTotCount(2) As Integer
  Dim WrkTotGross(2) As Integer
  Dim WrkTotExemption(2) As Integer
  Dim WrkTotNet(2) As Decimal
  Dim WrkTotTax(2) As Decimal
  Dim WrkTot1st(2) As Decimal
  Dim WrkTot2nd(2) As Decimal
  Dim WrkTotBalance As Decimal
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
  Dim WrkBalance As Decimal
  Dim WrkWaivered As Decimal
  Dim WrkNewOwner As Boolean
  'Personal Property
  Dim WrkCode(9) As Integer
  Dim WrkPropDesc As String
  Dim WrkPPCode(100) As Integer
  Dim WrkPPDesc(100) As String

  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXCOEA = New TXCOEA.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    With MyFrmTX702B
      If .RbBillAmount.Checked Then
        WrkBillAmount = True
      Else
        WrkBillAmount = False
      End If
      WrkType = .TxtType.Text
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortZip.Checked Then
        WrkSortBy = "Zip"
      End If
      WrkProDue1 = .DtPckProDue1.Value
      WrkProDue2 = .DtPckProDue2.Value
      WrkProGrace1 = .DtPckProGrace1.Value
      WrkProGrace2 = .DtPckProGrace2.Value
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
      BuildDSBill(dsBill)
    Else
      ds.Clear()
      dsBill.Clear()
      ClearTotals()
    End If

    If WrkFamily = "P" Then
      BufferPPDesc()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = dsBill
      .WrkDueDate1 = WrkProDue1
      .WrkDueDate2 = WrkProDue2
      .WrkGraceDate1 = WrkProGrace1
      .WrkGraceDate2 = WrkProGrace2
      .WrkMillRt = MrateMillrt * 1000
      .WrkType = WrkType
      .WrkFamily = WrkFamily
      .WrkBillAmount = WrkBillAmount
      .Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim K As Integer
    Dim WrkAnd As String
    Dim WrkBillType As String
    Dim WrkOldOwner As String
    Dim WrkBankCode As String
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkFee As Decimal
    Dim WrkLien As Decimal
    Dim WrkDue As Decimal
    Dim Pos As Integer
    Dim Counter As Integer

    WrkDist = 0
    WrkPhase = ""
    WrkBillType = GetTXTypeDesc(WrkType) & " TAX BILL"
    WrkFamily = GetTXTypeFamily(WrkType)
    WrkAnd = " and "

    WrkQry = "icode<>'I'" & WrkAnd & "type = " & MyUtils.Quo(WrkType) & WrkAnd & "year = " & WrkGLYear & WrkAnd & "ccno > 0 "
    'Filter C/C Numbers
    If MyUtils.CnvSng(MyFrmTX702B.TxtCCFrom.Text) > 0 Then
      WrkQry = WrkQry & WrkAnd & "ccno>=" & MyUtils.CnvSng(MyFrmTX702B.TxtCCFrom.Text) &
    WrkAnd & "ccno<=" & MyUtils.CnvSng(MyFrmTX702B.TxtCCTo.Text)
    End If
    'Filter C/C Dates
    If MyFrmTX702B.DtPckFrom.Checked Then
      WrkQry = WrkQry & WrkAnd & "cdate>=" & MyUtils.SetDBDate(MyFrmTX702B.DtPckFrom.Text) &
    WrkAnd & "cdate<=" & MyUtils.SetDBDate(MyFrmTX702B.DtPckTo.Text)
    End If
    'Filter C/C Reason Codes
    If MyFrmTX702B.TxtFromReason.Text <> "" Then
      WrkQry = WrkQry & WrkAnd & "ccrsn>=" & MyUtils.Quo(MyFrmTX702B.TxtFromReason.Text) &
    WrkAnd & "ccrsn<=" & MyUtils.Quo(MyFrmTX702B.TxtToReason.Text)
    End If

    Select Case WrkSortBy
      Case "Name"
        WrkSort = "BKCD, NAME, LIST#"
      Case "Zip"
        WrkSort = "ZIP5, NAME"
      Case Else
        WrkSort = ""
    End Select

    GetTaxProfile(WrkType, WrkGLYear, WrkPhase, WrkDist)
    GetMillRate(WrkGLYear, WrkType, WrkDist)

    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        WrkCode(0) = ._IPPCD1
        WrkCode(1) = ._IPPCD2
        WrkCode(2) = ._IPPCD3
        WrkCode(3) = ._IPPCD4
        WrkCode(4) = ._IPPCD5
        WrkCode(5) = ._IPPCD6
        WrkCode(6) = ._IPPCD7
        WrkCode(7) = ._IPPCD8
        WrkCode(8) = ._IPPCD9
        WrkCode(9) = ._IPPCDA
        WrkList = ._LISTNo
        WrkBankCode = Trim(._BKCD)
        WrkGross = ._CGRS
        WrkExempt = ._CCEXP
        WrkNet = WrkGross - WrkExempt
        If WrkNet < 0 Then WrkNet = 0
        WrkTaxTotal = ._CCETAX
        WrkTax1st = ._CCTX1
        WrkTax2nd = ._CCTX2
        WrkTaxAmount = ._CCETAX - ._PAYREC - ._NEWPAY
        If WrkTaxAmount < 0 Then
          GoTo NextRec
        End If
        'Determine which totals to add to
        K = 0 'Regular Tax
        If WrkWaivered > 0 Then 'Waivered
          K = 1
        End If
        If WrkTaxTotal = 0 And K = 0 Then 'Net Zero Tax
          K = 2
        End If

        'Filter - Omit Zero Bills 
        If K = 0 Then
          If WrkBillAmount Then
            If WrkTaxAmount <= 0 Then
              GoTo NextRec
            End If
          Else
            If WrkTaxAmount = 0 Then
              GoTo NextRec
            End If
          End If
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
        WrkTotBalance = WrkTotBalance + WrkTaxAmount
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkBalance, WrkDue, False)

        If myTOWN._TOWNBR = 162 And WrkGLYear = 2024 And WrkType = "P" Then 'Winchester Hard coded
          WrkInterest = 0
          WrkFee = 0
          WrkLien = 0
        End If

        If K > 0 Then 'Don't print waivered or zero tax bills
        If WrkBillAmount Then
          If WrkTaxTotal = 0 Then
            GoTo NextRec
          End If
        Else
          If WrkTaxAmount = 0 Then
            GoTo NextRec
          End If
        End If
      End If

      'Create Billing File
      drBill = dsBill.Tables(0).NewRow
      drBill("BillType") = WrkBillType
      drBill("listno") = WrkList
      drBill("year") = WrkGLYear
      WrkOldOwner = ""
      Pos = InStr(._SNAME, "N/O", CompareMethod.Text)
      If Pos > 0 Then
        '9-12-2024 - want to see full name as n/o at end.. so just show sname
        '   AddrLine = MyUtils.SetAddrLine(Mid(._SNAME, 5, 30), "", ._ADD1, ._ADD2,
        '    ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        AddrLine = MyUtils.SetAddrLine(._SNAME, "", ._ADD1, ._ADD2,
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        WrkOldOwner = ._NAME
      Else
        AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2,
      ._CITY, ._STATE, ._ZIP5, ._ZIP4)
      End If
      drBill.Item("addr1") = AddrLine(0)
      drBill.Item("addr2") = AddrLine(1)
      drBill.Item("addr3") = AddrLine(2)
      drBill.Item("addr4") = AddrLine(3)
      drBill.Item("addr5") = AddrLine(4)
      drBill.Item("bank") = Trim(._BKCD)
      drBill.Item("gross") = WrkGross
      drBill.Item("exemption") = WrkExempt
      drBill.Item("net") = WrkNet
      If WrkBillAmount Then
        drBill.Item("taxtot") = WrkTaxTotal
        drBill.Item("tax1st") = WrkTax1st
        drBill.Item("tax2nd") = WrkTax2nd
      Else
        drBill.Item("taxtot") = WrkTaxAmount
        If WrkTaxAmount <= WrkTax2nd Then
          drBill.Item("tax1st") = 0
          drBill.Item("tax2nd") = WrkTaxAmount
        Else
          drBill.Item("tax1st") = WrkTaxAmount - WrkTax2nd
          drBill.Item("tax2nd") = WrkTax2nd
        End If
      End If
      drBill.Item("unpaidtax") = WrkTaxAmount
      drBill.Item("interest") = WrkInterest
      drBill.Item("fee") = WrkFee
      drBill.Item("lien") = WrkLien
      drBill.Item("total") = WrkTaxAmount + WrkInterest + WrkFee + WrkLien
      Select Case WrkFamily
        Case "M", "S"
          drBill.Item("propdesc") = ._MVYR & " " & Trim(._MAKE) & " " &
      Trim(._MODEL) & " " & Trim(._IMVIDNo) & " " & Trim(._IMVREG)
        Case "P"
          WrkPropDesc = LookupPPDesc(WrkCode(0))
          If WrkCode(1) > 0 Then
            WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(WrkCode(1))
          End If
          If WrkCode(2) > 0 Then
            WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(WrkCode(2))
          End If
          If WrkCode(3) > 0 Then
            WrkPropDesc = WrkPropDesc & "," & LookupPPDesc(WrkCode(3))
          End If
          drBill.Item("propdesc") = WrkPropDesc
        Case "R"
          drBill.Item("propdesc") = Trim(._LOCNo) & " " & Trim(._LOC)
          drBill.Item("propdesc2") = WrkOldOwner
      End Select
      If ._ICODE = "B" Then
        drBill.Item("backtax") = True
      Else
        drBill.Item("backtax") = False
      End If
      drBill.Item("barcode") = BuildBarCode(WrkList, WrkType, WrkGLYear)
      drBill.Item("ccno") = ._CCNO
      drBill.Item("ccdate") = MyUtils.GetDBDate(._CDATE)
      drBill.Item("ccdesc") = GetCCDesc(._CCNO)
      End With
      dsBill.Tables(0).Rows.Add(drBill)

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
    For K = 0 To 2
      dr = ds.Tables(0).NewRow
      Select Case K
        Case 0
          dr.Item("description") = "Regular Tax"
        Case 1
          dr.Item("description") = "Waivered"
        Case 2
          dr.Item("description") = "Net Zero Tax"
      End Select
      dr.Item("count") = WrkTotCount(K)
      dr.Item("gross") = WrkTotGross(K)
      dr.Item("exemption") = WrkTotExemption(K)
      dr.Item("net") = WrkTotNet(K)
      dr.Item("taxtot") = WrkTotTax(K)
      dr.Item("tax1st") = WrkTot1st(K)
      dr.Item("tax2nd") = WrkTot2nd(K)
      Select Case K
        Case 0
          dr.Item("balance") = WrkTotBalance
        Case Else
          dr.Item("balance") = 0
      End Select
      ds.Tables(0).Rows.Add(dr)
    Next

    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub BufferPPDesc()
    Dim dsTXCODE As DataSet = New DataSet
    Dim I As Integer

    Dim myTXCode As TXCODE.MyData

    myTXCode = New TXCODE.MyData(myDBConnect)

    dsTXCODE = myTXCode.GetAllType(WrkType)
    For I = 0 To dsTXCODE.Tables(0).Rows.Count - 1
      With dsTXCODE.Tables(0).Rows(I)
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
  Public Function GetCCDesc(ByVal CCNo As Integer) As String
    Dim WrkCCDesc As String

    WrkCCDesc = ""
    If CCNo = 0 Then Return ""

    myTXCOEA.GetOneRecordP(CCNo)
    If myTXCOEA.RecordNotFound Then Return ""

    With myTXCOEA
      WrkCCDesc = Trim(._CDESC)
    End With

    Return WrkCCDesc
  End Function
  Private Sub ClearTotals()
    Array.Clear(WrkTotCount, 0, 2)
    Array.Clear(WrkTotGross, 0, 2)
    Array.Clear(WrkTotExemption, 0, 2)
    Array.Clear(WrkTotNet, 0, 2)
    Array.Clear(WrkTotTax, 0, 2)
    Array.Clear(WrkTot1st, 0, 2)
    Array.Clear(WrkTot2nd, 0, 2)
    WrkTotBalance = 0
  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
  ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
  ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal, ByRef OutDue As Decimal,
    ByRef OutGracePeriod As Boolean)
    With myCASHINT
      .In_IntDate = WrkProDue1
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With
  End Sub
End Module






