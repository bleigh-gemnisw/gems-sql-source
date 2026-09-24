Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINV As TXINVQ.myData
  Dim myTXMVFEE As TXMVFEE.myData
  Dim mycashint As CASHINT.MyData

  Dim ds As DataSet = New DataSet
  Dim dsBill As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drBill As Data.DataRow

  Dim WrkType As String
  Dim WrkFamily As String
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkIntDate As Date
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPhase As String
  Dim WrkOmitSuspense As Boolean
  Dim WrkOmitBanks As Boolean
  Dim WrkInGracePeriod As Boolean
  Dim WrkOmitBelow As Decimal
  Dim WrkOmitAbove As Decimal
  Dim WrkInvCode As String
  Dim WrkBankCode As String
  Dim WrkLease As String
  Dim WrkSortBy As String
  Dim WrkRefresh As Boolean
  Dim WrkBills As Boolean
  Dim WrkCSV As Boolean
  Dim WrkHeadings As Boolean
  'Shared fields
  Dim WrkInterest As Decimal
  Dim WrkInterestPaid As Decimal
  Dim WrkBond As Decimal
  Dim WrkLien As Decimal
  Dim WrkDue As Decimal
  Dim WrkTax As Decimal
  Dim WrkFee As Decimal
  Dim WrkCode(9) As Integer
  Dim WrkPropDesc As String
  Dim WrkPropDesc2 As String
  Dim WrkPropDesc3 As String
  Dim WrkPropDesc4 As String
  Dim WrkPPCode(100) As Integer
  Dim WrkPPDesc(100) As String
  Dim WrkSelStatus As String
  Dim WrkMillRate As Decimal
  Dim WrkMillFire As Decimal
  Public Sub PrtReport()
    myTXINV = New TXINVQ.mydata(MyDBConnect)
    myTXMVFEE = New TXMVFEE.mydata(MyDBConnect)
    mycashint = New CASHINT.mydata(MyDBConnect)

    With MyFrmTX303B
      WrkType = .TxtType.Text
      WrkSelStatus = .TxtStatus.Text
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkIntDate = .DtPckInt.Value
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkOmitSuspense = False
      If .ChkOmitSuspense.Checked Then
        WrkOmitSuspense = True
      End If
      WrkInGracePeriod = False
      If .ChkInGracePeriod.Checked Then
        WrkInGracePeriod = True
      End If
      WrkOmitBelow = MyUtils.CnvSng(.TxtOmitBelow.Text)
      WrkOmitAbove = MyUtils.CnvSng(.TxtOmitAbove.Text)
      WrkInvCode = .TxtInvCode.Text
      WrkBankCode = .TxtBankCode.Text
      WrkLease = Trim(.TxtLease.Text)
      If .RbSortName.Checked Then
        WrkSortBy = "Name"
      End If
      If .RbSortZip.Checked Then
        WrkSortBy = "Zip"
      End If
      If .RbSortList.Checked Then
        WrkSortBy = "List"
      End If
      WrkBills = .ChkBills.Checked
      WrkCSV = .RbCSV.Checked
      WrkHeadings = .ChkHeadings.Checked
    End With

    If ds.Tables.Count = 0 Then
      InitFiles()
      BuildDS(ds)
      BuildDSBill(dsBill)
    Else
      ds.Clear()
      dsBill.Clear()
    End If

    BufferMillRate()
    If WrkFamily = "P" Then
      BufferPPDesc()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .wrkds = ds
      .wrkds2 = dsBill
      .WrkType = WrkType
      .WrkInterestDate = MyFrmTX303B.DtPckInt.Value
      MyCrViewer.Show()
    End With

  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim AddrLine() As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim WrkBillType As String
    Dim WrkTotCount As Integer
    Dim WrkTotTax As Decimal
    Dim WrkTotFee As Decimal
    Dim WrkTotInt As Decimal
    Dim WrkTotLien As Decimal
    Dim WrkTotal As Decimal
    Dim WrkOldOwner As String
    Dim WrkGracePeriod As Boolean
    Dim WrkDate As Date
    Dim SaveYear As Integer
    Dim SaveDist As Integer
    Dim Counter As Integer
    Dim Pos As Integer
    Dim K As Integer

    Select Case myTOWN._TOWNBR
      Case 72 'Ledyard
        WrkBillType = "DELINQUENT NOTICE-" & GetTXTypeDesc(WrkType)
      Case Else 'Generic 
        WrkBillType = "DELINQUENT BILL-" & GetTXTypeDesc(WrkType)
    End Select

    WrkFamily = GetTXTypeFamily(WrkType)
    WrkPhase = ""
    Counter = 0
    WrkTotCount = 0
    WrkTotTax = 0
    WrkTotFee = 0
    WrkTotInt = 0
    WrkTotLien = 0
    WrkTotal = 0

    If MyServer = "DB2" Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    myTXMVFEE.GetOneRecordP(1)
    If Not myTXMVFEE.RecordNotFound Then
      WrkFee = myTXMVFEE._MVFEE
    End If

    WrkQry = "icode<>'I'" & WrkAnd & "type = " & MyUtils.Quo(WrkType) & WrkAnd & "bald > 0"
    If WrkFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear & WrkAnd & "YEAR <= " & WrkToYear
    End If

    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    If WrkOmitSuspense Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>'S'"
    End If

    If WrkInvCode <> "" Then
      WrkQry = WrkQry & WrkAnd & "ICODE<>" & MyUtils.Quo(WrkInvCode)
    End If

    If WrkBankCode <> "" Then
      WrkQry = WrkQry & WrkAnd & "BKCD=" & MyUtils.Quo(WrkBankCode)
    End If

    If WrkLease <> "" Then
      WrkQry = WrkQry & WrkAnd & "ILEASE=" & MyUtils.Quo(WrkLease)
    End If

    WrkSort = ""
    SaveYear = 0
    SaveDist = 0
    Select Case WrkSortBy
      Case "Name"
        WrkSort = "NAME"
      Case "Zip"
        WrkSort = "ZIP5, NAME"
      Case "List"
        WrkSort = "LIST#"
    End Select

    If MyFrmTX303B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmTX303B.LblFilePath.Text)
    End If

    If WrkHeadings Then
      sw.WriteLine(HeadingsCSV)
    End If

    myTXINV.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXINV.ReadQry()
    If Not myTXINV.IsEOF Then
      With myTXINV
        Counter = Counter + 1
        'Filter - Omit Unposted Zero Balances 
        If (._BALD - ._NEWPAY) <= 0 Then
          GoTo NextRec
        End If
        'Filter - Omit Bank Coded
        If WrkOmitBanks Then
          If Trim(._BKCD) <> "" Then GoTo NextRec
        End If
        'Filter - Omit Status Codes
        If Trim(WrkSelStatus) > "" Then   ' filter status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkSelStatus, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then GoTo NextRec
        End If

        GetTaxProfile(WrkType, ._YEAR, WrkPhase, WrkDist)
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

        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkFee, WrkLien, WrkBond, WrkTax, WrkDue, WrkInterestPaid, WrkGracePeriod)
        'Filter - Omit below amount due 
        If WrkDue < WrkOmitBelow Or WrkDue = 0 Then
          GoTo NextRec
        End If
        'Filter - Omit above amount due 
        If WrkOmitAbove > 0 And WrkDue > WrkOmitAbove Then
          GoTo NextRec
        End If
        'Filter - Omit In Grace Period unless selected
        If Not WrkInGracePeriod And WrkGracePeriod Then
          GoTo NextRec
        End If

        WrkFamily = GetTXTypeFamily(WrkType)
        WrkPropDesc = String.Empty
        WrkPropDesc2 = String.Empty
        WrkPropDesc3 = String.Empty
        WrkPropDesc4 = String.Empty
        Select Case WrkFamily
          Case "M", "S"
            WrkPropDesc = Trim(._MAKE)
            WrkPropDesc2 = Trim(._IMVIDNo)
            WrkPropDesc3 = ._MVYR
            WrkPropDesc4 = Trim(._IMVREG)
          Case "R"
            WrkPropDesc = Trim(._LOCNo) & " " & ._LOC
            WrkPropDesc2 = String.Empty
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
          Case Else
            WrkPropDesc = Trim(._LOCNo) & " " & ._LOC
        End Select
        K = LookupMillRate(._YEAR, ._TYPE, ._DIST)
        If K >= 0 Then
          WrkMillRate = WrkMrrate(K)
          WrkMillFire = WrkMrfire(K)
        Else
          WrkMillRate = 0
          WrkMillFire = 0
        End If

        'Filter - Print No Bills
        If Not MyFrmTX303B.ChkBills.Checked Then
          GoTo Report
        End If

        'Create Bills
        drBill = dsBill.Tables(0).NewRow
        drBill.Item("billtype") = WrkBillType
        drBill.Item("listno") = ._LISTNo
        drBill.Item("type") = WrkType
        drBill.Item("year") = ._YEAR
        WrkOldOwner = ""
        Pos = InStr(._SNAME, "N/O", CompareMethod.Text)
        If Pos > 0 Then
          AddrLine = MyUtils.SetAddrLine(Mid(._SNAME, 5, 30), "", ._ADD1, ._ADD2,
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
          WrkOldOwner = Trim(._NAME)
        Else
          AddrLine = MyUtils.SetAddrLine(._NAME, ._SNAME, ._ADD1, ._ADD2,
        ._CITY, ._STATE, ._ZIP5, ._ZIP4)
        End If
        drBill.Item("addr1") = AddrLine(0)
        drBill.Item("addr2") = AddrLine(1)
        drBill.Item("addr3") = AddrLine(2)
        drBill.Item("addr4") = AddrLine(3)
        drBill.Item("addr5") = AddrLine(4)
        If ._MVFLAG = "Y" Then
          drBill.Item("mvfee") = WrkFee
        Else
          drBill.Item("mvfee") = 0
        End If
        If ._CCNO = 0 Then
          drBill.Item("taxtot") = ._TAXT
          drBill.Item("tax1st") = ._TAX1
          drBill.Item("tax2nd") = ._TAX2
          drBill.Item("gross") = ._GROSS
          drBill.Item("exemption") = ._TOTEXP
          drBill.Item("credit") = ._ICVGRS
          drBill.Item("net") = ._NETASS
        Else
          drBill.Item("taxtot") = ._CCETAX
          drBill.Item("tax1st") = ._CCTX1
          drBill.Item("tax2nd") = ._CCTX2
          drBill("exemption") = ._CCEXP
          drBill("credit") = 0
          drBill("net") = ._CGRS - ._CCEXP
        End If
        If WrkPropDesc3 = String.Empty Then
          drBill.Item("propdesc") = WrkPropDesc
        Else
          drBill.Item("propdesc") = WrkPropDesc & " " & WrkPropDesc3 & " " & WrkPropDesc4
        End If
        drBill.Item("propdesc2") = WrkPropDesc2
        drBill.Item("payrec") = ._PAYREC
        drBill.Item("intpaid") = WrkInterestPaid
        drBill.Item("bondpaid") = ._BONDP
        drBill.Item("lastpaydt") = MyUtils.GetDBDate(._TXIDT)
        drBill.Item("unpaidtax") = WrkTax
        drBill.Item("unpaidbond") = WrkBond
        drBill.Item("interest") = WrkInterest
        drBill.Item("fee") = WrkFee
        drBill.Item("bond") = ._BOND
        drBill.Item("lien") = WrkLien
        drBill.Item("total") = WrkDue
        drBill.Item("backtax") = False
        If ._ICODE = "B" Then
          drBill.Item("backtax") = True
        End If
        drBill.Item("barcode") = BuildBarCode(._LISTNo, WrkType, ._YEAR)
      End With
      drBill.Item("millrt") = WrkMillRate * 1000
      WrkDate = MyUtils.GetDBDateMDY(myTXPROF._PRDUE1)
      drBill.Item("duedt1") = WrkDate.ToString("M/d/yyyy")
      If myTXPROF._PRDUE2 > 0 Then
        WrkDate = MyUtils.GetDBDateMDY(myTXPROF._PRDUE2)
        drBill.Item("duedt2") = WrkDate.ToString("M/d/yyyy")
      Else
        drBill.Item("duedt2") = String.Empty
      End If
      dsBill.Tables(0).Rows.Add(drBill)

Report:
      If MyFrmTX303B.LblFilePath.Text <> String.Empty Then
        If WrkCSV Then
          sw.WriteLine(DownloadCSV)
        Else
          sw.WriteLine(DownloadFixed)
        End If
      End If
      WrkTotCount = WrkTotCount + 1
      WrkTotTax = WrkTotTax + WrkTax
      WrkTotInt = WrkTotInt + WrkInterest
      WrkTotFee = WrkTotFee + WrkFee
      WrkTotLien = WrkTotLien + WrkLien
      WrkTotal = WrkTotal + WrkDue

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
    dr = ds.Tables(0).NewRow
    dr.Item("description") = "Delinquent Bills"
    dr.Item("count") = WrkTotCount
    dr.Item("tax") = WrkTotTax
    dr.Item("interest") = WrkTotInt
    dr.Item("fee") = WrkTotFee
    dr.Item("lien") = WrkTotLien
    dr.Item("total") = WrkTotal
    ds.Tables(0).Rows.Add(dr)

    myFrmProgress.Close()
    myTXINV.CloseFile()
    If MyFrmTX303B.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If

  End Sub
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutFee As Decimal,
    ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutInterestPaid As Decimal, ByRef OutGracePeriod As Boolean)
    With mycashint
      .In_IntDate = WrkIntDate
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
      OutInterestPaid = Format(.Out_IntPaid, "standard")
      OutGracePeriod = .Out_GracePeriod
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
  Private Function DownloadFixed() As String
    Dim sb As StringBuilder
    Dim WrkInteger As Integer

    With myTXINV
      sb = New StringBuilder
      sb.Append(MyUtils.JustifyLeft(._NAME, 35))
      sb.Append(MyUtils.JustifyLeft(._SNAME, 35))
      sb.Append(MyUtils.JustifyLeft(._ADD1, 35))
      sb.Append(MyUtils.JustifyLeft(._ADD2, 35))
      sb.Append(MyUtils.JustifyLeft(._CITY, 25))
      sb.Append(MyUtils.JustifyLeft(._STATE, 2))
      sb.Append(Format(._ZIP5, "00000"))
      sb.Append(Format(._ZIP4, "0000"))
      sb.Append(Format(._LISTNo, "000000"))
      sb.Append(Format(._YEAR, "0000"))
      sb.Append(._TYPE)
      If WrkPropDesc3 = String.Empty Then
        sb.Append(MyUtils.JustifyLeft(WrkPropDesc, 17))
      Else
        sb.Append(MyUtils.JustifyLeft(WrkPropDesc & " " & WrkPropDesc3 & " " & WrkPropDesc4, 17))
      End If
      WrkInteger = WrkTax * 100
      sb.Append(Format(WrkInteger, "000000000"))
      WrkInteger = WrkInterest * 100
      sb.Append(Format(WrkInteger, "00000000000"))
      sb.Append(._LIEN)
      WrkInteger = WrkDue * 100
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(" ") 'Calc
      WrkInteger = WrkDue * 100
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(" ") 'Detail
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Month, "00"))
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Day, "00"))
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Year, "0000"))
      sb.Append(MyUtils.JustifyLeft(._VOL, 5))
      sb.Append(MyUtils.JustifyLeft(._IPAGE, 5))
      sb.Append(MyUtils.JustifyLeft(._MAP, 17))
      sb.Append(myTXINV._ICODE)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Month, "00"))
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Day, "00"))
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Year, "0000"))
      WrkInteger = WrkLien * 100
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(Format(myTXPROF._PRDUE1, "00000000"))
      sb.Append("000") 'Month
      sb.Append(Format(._DIST, "000"))
      sb.Append(._BKCD)
      sb.Append(Format(._GROSS, "000000000"))
      WrkInteger = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      sb.Append(Format(WrkInteger, "000000000"))
      sb.Append(Format(._NETASS, "000000000"))
      sb.Append(Format(._PAYREC, "00000000000"))
      sb.Append(Format(._NEWPAY, "00000000000"))
      WrkInteger = WrkMillRate * 1000
      sb.Append(Format(WrkInteger, "000000"))
      WrkInteger = WrkMillFire * 1000
      sb.Append(Format(WrkInteger, "000000"))
      WrkInteger = ._TAXT * 100
      sb.Append(Format(WrkInteger, "00000000000"))
      sb.Append(MyUtils.JustifyLeft(WrkPropDesc2, 20))
      WrkInteger = (WrkMillRate - WrkMillFire) * 1000
      sb.Append(Format(WrkInteger, "000000"))
      WrkInteger = WrkMillFire * 1000
      sb.Append(Format(WrkInteger, "000000"))
      sb.Append(Format(0, "000000000")) 'City Due
      sb.Append(Format(0, "000000000")) 'Fire Due
      sb.Append(Format(._ZIP5, "00000"))
      sb.Append(Format(._ZIP4, "0000"))
      sb.Append(Format(myTXPROF._PRDUE1, "00000000")) 'Due Date
    End With

    Return sb.ToString
  End Function
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Dim WrkNumber As Decimal
    Dim WrkComma As String
    Dim WrkQuote As String

    WrkComma = ","
    WrkQuote = Chr(34)

    With myTXINV
      sb = New StringBuilder
      sb.Append(WrkQuote)
      sb.Append(Trim(._NAME))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._SNAME))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._ADD1))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._ADD2))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._CITY))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._STATE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Format(._ZIP5, "00000"))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Format(._ZIP4, "0000"))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(._LISTNo)
      sb.Append(WrkComma)
      sb.Append(._YEAR)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(._TYPE)
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(WrkPropDesc))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(WrkPropDesc2))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(WrkPropDesc3))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(WrkPropDesc4))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(Format(WrkTax, "fixed"))
      sb.Append(WrkComma)
      sb.Append(Format(WrkInterest, "fixed"))
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(._LIEN)
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(" ") 'Calc
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(Format(WrkDue, "fixed"))
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(" ") 'Detail
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Month, "00"))
      sb.Append(WrkComma)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Day, "00"))
      sb.Append(WrkComma)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Year, "0000"))
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._VOL))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._IPAGE))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._MAP))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(myTXINV._ICODE)
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Month, "00"))
      sb.Append(WrkComma)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Day, "00"))
      sb.Append(WrkComma)
      sb.Append(Format(MyFrmTX303B.DtPckInt.Value.Year, "0000"))
      sb.Append(WrkComma)
      sb.Append(Format(WrkLien, "fixed"))
      sb.Append(WrkComma)
      sb.Append(myTXPROF._PRDUE1)
      sb.Append(WrkComma)
      sb.Append("") 'Month
      sb.Append(WrkComma)
      sb.Append(._DIST)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(._BKCD)
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(Format(._GROSS, "000000000"))
      sb.Append(WrkComma)
      WrkNumber = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      sb.Append(WrkNumber)
      sb.Append(WrkComma)
      sb.Append(._NETASS)
      sb.Append(WrkComma)
      sb.Append(Format(._PAYREC, "fixed"))
      sb.Append(WrkComma)
      sb.Append(Format(._NEWPAY, "fixed"))
      sb.Append(WrkComma)
      sb.Append(Format(WrkMillRate * 1000, "000.000"))
      sb.Append(WrkComma)
      sb.Append(Format(WrkMillFire * 1000, "000.000"))
      sb.Append(WrkComma)
      sb.Append(Format(._TAXT, "fixed"))
      sb.Append(WrkComma)
      sb.Append(WrkPropDesc2)
      sb.Append(WrkComma)
      WrkNumber = ((WrkMillRate - WrkMillFire) * 1000)
      sb.Append(Format(WrkNumber, "000.000"))
      sb.Append(WrkComma)
      sb.Append(Format(WrkMillFire * 1000, "000.000"))
      sb.Append(WrkComma)
      sb.Append(Format(0, "fixed")) 'City Due
      sb.Append(WrkComma)
      sb.Append(Format(0, "fixed")) 'Fire Due
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Format(._ZIP5, "00000"))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Format(._ZIP4, "0000"))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(Format(MyUtils.GetDBDateMDY(myTXPROF._PRDUE1), "M/d/yyyy")) 'Due Date
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._STCD1))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._STCD2))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._STCD3))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._STCD4))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._STCD5))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      sb.Append(WrkFee)
      Return sb.ToString
    End With
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim WrkComma As String

    WrkComma = ","
    sb = New StringBuilder
    sb.Append("NAME")
    sb.Append(WrkComma)
    sb.Append("SECOND NAME")
    sb.Append(WrkComma)
    sb.Append("ADDRESS 1")
    sb.Append(WrkComma)
    sb.Append("ADDRESS 2")
    sb.Append(WrkComma)
    sb.Append("CITY")
    sb.Append(WrkComma)
    sb.Append("STATE")
    sb.Append(WrkComma)
    sb.Append("ZIP CODE")
    sb.Append(WrkComma)
    sb.Append("ZIP PLUS4")
    sb.Append(WrkComma)
    sb.Append("LISTNO")
    sb.Append(WrkComma)
    sb.Append("TAX YEAR")
    sb.Append(WrkComma)
    sb.Append("TYPE")
    sb.Append(WrkComma)
    sb.Append("PROPERTY DESCRIPTION")
    sb.Append(WrkComma)
    sb.Append("PROPERTY DESCRIPTION 2")
    sb.Append(WrkComma)
    sb.Append("PROPERTY DESCRIPTION 3")
    sb.Append(WrkComma)
    sb.Append("PROPERTY DESCRIPTION 4")
    sb.Append(WrkComma)
    sb.Append("TAX DUE")
    sb.Append(WrkComma)
    sb.Append("INTEREST")
    sb.Append(WrkComma)
    sb.Append("LIEN CODE")
    sb.Append(WrkComma)
    sb.Append("CALC (Not used)")
    sb.Append(WrkComma)
    sb.Append("BALANCE DUE")
    sb.Append(WrkComma)
    sb.Append("DETL (Not Used)")
    sb.Append(WrkComma)
    sb.Append("INTEREST MONTH")
    sb.Append(WrkComma)
    sb.Append("INTEREST DAY")
    sb.Append(WrkComma)
    sb.Append("INTEREST YEAR")
    sb.Append(WrkComma)
    sb.Append("VOLUME")
    sb.Append(WrkComma)
    sb.Append("PAGE")
    sb.Append(WrkComma)
    sb.Append("MAP/LOT")
    sb.Append(WrkComma)
    sb.Append("B = BACK TAX")
    sb.Append(WrkComma)
    sb.Append("COMP MONTH")
    sb.Append(WrkComma)
    sb.Append("COMP DAY")
    sb.Append(WrkComma)
    sb.Append("COMP YEAR")
    sb.Append(WrkComma)
    sb.Append("LIEN AMT")
    sb.Append(WrkComma)
    sb.Append("DUE DATE 1")
    sb.Append(WrkComma)
    sb.Append("MONTH")
    sb.Append(WrkComma)
    sb.Append("DISTRICT")
    sb.Append(WrkComma)
    sb.Append("BANK CODE")
    sb.Append(WrkComma)
    sb.Append("GROSS ASSMNT")
    sb.Append(WrkComma)
    sb.Append("EXEMPTION")
    sb.Append(WrkComma)
    sb.Append("NET ASSMNT")
    sb.Append(WrkComma)
    sb.Append("PAYMENTS RECEIVED")
    sb.Append(WrkComma)
    sb.Append("UNPOSTED PAYMENTS")
    sb.Append(WrkComma)
    sb.Append("MILL RATE")
    sb.Append(WrkComma)
    sb.Append("FIRE MILL RATE")
    sb.Append(WrkComma)
    sb.Append("ORIG BILL")
    sb.Append(WrkComma)
    sb.Append("PROPERTY DESCRIPTION")
    sb.Append(WrkComma)
    sb.Append("CITY MILL RATE")
    sb.Append(WrkComma)
    sb.Append("FIRE MILL RATE")
    sb.Append(WrkComma)
    sb.Append("CITY TAX DUE")
    sb.Append(WrkComma)
    sb.Append("FIRE TAX DUE")
    sb.Append(WrkComma)
    sb.Append("ZIP 5")
    sb.Append(WrkComma)
    sb.Append("ZIP 4")
    sb.Append(WrkComma)
    sb.Append("DUE DATE")
    sb.Append(WrkComma)
    sb.Append("STATUS CODE 1")
    sb.Append(WrkComma)
    sb.Append("STATUS CODE 2")
    sb.Append(WrkComma)
    sb.Append("STATUS CODE 3")
    sb.Append(WrkComma)
    sb.Append("STATUS CODE 4")
    sb.Append(WrkComma)
    sb.Append("STATUS CODE 5")
    sb.Append(WrkComma)
    sb.Append("FEES")
    Return sb.ToString
  End Function
End Module






