'Non Public: townbr=0 webpay can search by list# or account only
Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.myData
  Dim myTXPAYID As TXPAYID.myData
  Dim myTXMVFEE As TXMVFEE.myData
  Dim MyTXPROF As TXPROF.myData
  Dim myCASHINT As CASHINT.MyData
  Dim myTXHSTL4 As TXHSTL4.myData

  Dim ds As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkIntDate As Date
  Dim WrkFullFromYear As Integer
  Dim WrkFullToYear As Integer
  Dim WrkStsBlocked As String
  Dim WrkStsLiened As String
  Dim WrkLienMsg As String
  Dim WrkStsOmit As String
  Dim WrkStsNonCodes As String
  Dim WrkMVRegNo As Boolean
  Dim WrkBlockSusp As Boolean
  Dim WrkBlockBackTax As Boolean
  Dim WrkOmitSusp As Boolean
  Dim WrkFilePath As String
  Dim WrkWebTown As Integer
  Dim WrkWebName As String
  Dim WrkWebScript As String
  Dim WrkQRCode As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  'Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  'Product ID
  Dim WrkType(25) As String
  Dim WrkProdID(25) As Integer
  'Totals
  Dim WrkTCount As Integer
  Dim WrkTAmtDue As Decimal
  Dim WrkTInterest As Decimal
  Dim WrkTFees As Decimal
  Dim WrkTLiens As Decimal
  Dim WrkTBond As Decimal
  Dim WrkTTotal As Decimal
  'General
  Dim SaveYear As Integer
  Dim SaveType As String
  Dim sb As StringBuilder
  Dim WrkWebMsg As String
  Public Sub PrtReport()
    Dim WrkRemoteName As String
    Dim WrkAuto As Boolean

    myTXINVQ = New TXINVQ.mydata(MyDBConnect)
    myTXMVFEE = New TXMVFEE.mydata(MyDBConnect)
    MyTXPROF = New TXPROF.mydata(MyDBConnect)
    myCASHINT = New CASHINT.mydata(MyDBConnect)
    myTXHSTL4 = New TXHSTL4.mydata(MyDBConnect)

    WrkAuto = False
    If MyAutomate Or MyFTPOnly Then
      WrkAuto = True
      WrkFilePath = MyUtils.GetDataPath & "WEBPAY"
      WrkIntDate = Date.Today
      WrkFullFromYear = MyAppSettings.FromYear
      WrkFullToYear = MyAppSettings.ToYear
      WrkStsBlocked = MyAppSettings.Status
      WrkStsLiened = MyAppSettings.Liened
      WrkLienMsg = Trim(MyAppSettings.LienMsg)
      WrkStsOmit = MyAppSettings.Omit
      WrkStsNonCodes = MyAppSettings.NonCodes
      WrkMVRegNo = MyAppSettings.MVRegNo
      WrkBlockSusp = MyAppSettings.BlockSusp
      WrkBlockBackTax = MyAppSettings.BlockBackTax
      WrkOmitSusp = MyAppSettings.OmitSusp
      WrkWebTown = MyAppSettings.WebTown
      WrkWebName = MyAppSettings.WebName
      WrkWebScript = MyAppSettings.WebScript
      WrkQRCode = MyAppSettings.QRCode
      MyTypes = MyAppSettings.Types
      MyNonPublic = MyAppSettings.NonPublic
      If WrkWebName = String.Empty Then
        MsgBox("Config file is missing. Run program normally and click save settings.", MsgBoxStyle.Critical, "Cannot run in automatic mode")
        Application.Exit()
      End If
    End If

    If MyAutomate2 Or MyFTP2Only Then
      WrkAuto = True
      WrkFilePath = MyUtils.GetDataPath & "WEBPAY2"
      WrkIntDate = Date.Today
      WrkFullFromYear = MyAppSettings2.FromYear
      WrkFullToYear = MyAppSettings2.ToYear
      WrkStsBlocked = MyAppSettings2.Status
      WrkStsLiened = MyAppSettings2.Liened
      WrkLienMsg = MyAppSettings2.LienMsg
      WrkStsOmit = MyAppSettings2.Omit
      WrkStsNonCodes = MyAppSettings2.NonCodes
      WrkMVRegNo = MyAppSettings2.MVRegNo
      WrkBlockSusp = MyAppSettings2.BlockSusp
      WrkBlockBackTax = MyAppSettings2.BlockBackTax
      WrkOmitSusp = MyAppSettings2.OmitSusp
      WrkWebTown = MyAppSettings2.WebTown
      WrkWebName = MyAppSettings2.WebName
      WrkWebScript = MyAppSettings2.WebScript
      WrkQRCode = MyAppSettings2.QRCode
      MyTypes = MyAppSettings2.Types
      MyNonPublic = MyAppSettings2.NonPublic
      If WrkWebName = String.Empty Then
        MsgBox("Config file is missing. Run program normally and click save settings.", MsgBoxStyle.Critical, "Cannot run in automatic mode")
        Application.Exit()
      End If
    End If

    If Not WrkAuto Then
      With MyFrmTX830B
        If .RbPrimary.Checked Then
          WrkFilePath = MyUtils.GetDataPath & "WEBPAY"
        Else
          WrkFilePath = MyUtils.GetDataPath & "WEBPAY2"
        End If
        WrkIntDate = Date.Today
        WrkFullFromYear = MyUtils.CnvSng(.TxtGLFromYear.Text)
        WrkFullToYear = MyUtils.CnvSng(.TxtGLToYear.Text)
        WrkStsBlocked = .TxtBlocked.Text
        WrkStsLiened = .TxtLiened.Text
        WrkLienMsg = .TxtLienMsg.Text
        WrkStsOmit = .TxtOmit.Text
        WrkStsNonCodes = .TxtNonCodes.Text
        WrkBlockSusp = .ChkBlockSusp.Checked
        WrkBlockBackTax = .ChkBlockBackTax.Checked
        WrkOmitSusp = .ChkOmitSusp.Checked
        WrkWebTown = MyUtils.CnvSng(.TxtWebTown.Text)
        WrkWebName = .TxtWebName.Text
        WrkWebScript = .TxtWebScript.Text
        WrkQRCode = .ChkQRCode.Checked
        MyTypes = .TxtTypes.Text
        MyNonPublic = .TxtNonPublic.Text
      End With
    End If

    If MyFTPOnly Or MyFTP2Only Then GoTo Done

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsTot.Clear()
      ClearTotals()
    End If

    BufferType()
    BufferProdID()
    GetDetail()

Done:
    If WrkWebTown = 0 Then
      WrkWebTown = myTOWN._TOWNBR
    End If
    If WrkWebScript = "" Then
      WrkWebScript = "webtax"
    End If
    If MyAutomate Or MyAutomate2 Or MyFTPOnly Or MyFTP2Only Then
      WrkRemoteName = "Webtax-" & Format(WrkWebTown, "000") & ".csv"
      PutFile(WrkFilePath & ".csv", WrkRemoteName)
      WrkRemoteName = "WebtaxDtl-" & Format(WrkWebTown, "000") & ".csv"
      PutFile(WrkFilePath & "dtl.csv", WrkRemoteName)
      If WrkWebName <> String.Empty Then
        NavigateWeb()
      End If
      WriteLogAuto()
      End
    Else
      MyCRViewer = New FrmCrViewer
      With MyCRViewer
        .wrkdsTot = dsTot
        .Show()
      End With
    End If

  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTAmtDue = 0
    WrkTInterest = 0
    WrkTFees = 0
    WrkTLiens = 0
    WrkTBond = 0
    WrkTTotal = 0
  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(WrkFilePath & ".csv")
    Dim sw2 As StreamWriter = New StreamWriter(WrkFilePath & "dtl.csv")
    Dim WrkQryFull As String
    Dim WrkQry As String
    Dim WrkQry2 As String
    Dim WrkQry3 As String
    Dim WrkQry4 As String
    Dim WrkSort As String
    Dim K As Integer
    Dim SaveYear As Integer
    Dim SaveType As String

    Dim WrkDue As Decimal
    Dim WrkTypes As String
    Dim WrkFee As Decimal
    Dim Pos As Integer
    Dim WrkNumber As Decimal
    Dim WrkInterestPaid As Decimal
    Dim WrkInterest As Decimal
    Dim WrkFees As Decimal
    Dim WrkLiens As Decimal
    Dim WrkBond As Decimal
    Dim WrkTax As Decimal
    Dim WrkTax1 As Decimal
    Dim WrkTax2 As Decimal
    Dim WrkTax3 As Decimal
    Dim WrkTax4 As Decimal
    Dim WrkDueDate1 As String
    Dim WrkDueDate2 As String
    Dim WrkDueDate3 As String
    Dim WrkDueDate4 As String
    Dim WrkGross As Integer
    Dim WrkExam As Integer
    Dim WrkNet As Integer
    Dim WrkBalance As Decimal
    Dim WrkPrinPaid As Decimal
    Dim WrkGracePeriod As Boolean
    Dim WrkDBToday As Integer
    Dim WrkPropDesc As String
    Dim WrkPhase As String
    Dim WrkAcctID As String
    Dim WrkAcctCode As String
    Dim WrkComma As String
    Dim WrkQuote As String
    Dim WrkNP As Boolean
    Dim Counter As Integer
    Dim UnqInv As Integer
    Dim UnqHist As Integer

    WrkComma = ","
    WrkQuote = Chr(34)
    WrkDueDate1 = String.Empty
    WrkDueDate2 = String.Empty
    WrkDueDate3 = String.Empty
    WrkDueDate4 = String.Empty

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    myTXMVFEE.GetOneRecordP(1)
    If Not myTXMVFEE.RecordNotFound Then
      WrkFee = myTXMVFEE._MVFEE
    End If

    '*** There are 4 queries: WrkQry/WrkQry2/WrkQry3/WrkQry4 ***
    WrkDBToday = MyUtils.SetDBDate(Date.Today)
    'MK 2/10/26 Begin 
    WrkQry = "icode<>'I'"
    'WrkQry = "icode<>'I'" & WrkAnd & "icode<>'D'"
    'MK 2/10/26 End 
    'Filter Grand List Years
    If WrkFullFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year>=" & WrkFullFromYear
    End If
    If WrkFullToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "year<=" & WrkFullToYear
    End If
    If WrkOmitSusp Then
      WrkQry = WrkQry & WrkAnd & "icode<>'S'"
    End If

    If MyTypes <> "" Then
      If MyServer = "DB2" Then
        WrkTypes = BuildSelectTypes(MyTypes)
        WrkQry = WrkQry & WrkAnd & WrkTypes
      Else
        WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
      End If
    End If

    '*** There are 4 queries: WrkQry/WrkQry2/WrkQry3/WrkQry4 ***
    WrkQry2 = "icode<>'I'" & WrkAnd & "bald > 0" & WrkAnd & "year<" & WrkFullFromYear
    'WrkQry2 = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "bald > 0" & WrkAnd & "year<" & WrkFullFromYear
    If WrkOmitSusp Then
      WrkQry2 = WrkQry2 & WrkAnd & "icode<>'S'"
    End If
    If MyTypes <> "" Then
      If MyServer = "DB2" Then
        WrkTypes = BuildSelectTypes(MyTypes)
        WrkQry2 = WrkQry2 & WrkAnd & WrkTypes
      Else
        WrkQry2 = BuildSelectQryPC(WrkQry2, MyTypes)
      End If
    End If

    '*** There are 4 queries: WrkQry/WrkQry2/WrkQry3/WrkQry4 ***
    WrkQry3 = ""
    WrkQry4 = ""
    If MyNonPublic <> "" Then
      WrkQry3 = "icode<>'I'"
      'WrkQry3 = "icode<>'I'" & WrkAnd & "icode<>'D'"
      'Filter Grand List Years
      If WrkFullFromYear > 0 Then
        WrkQry3 = WrkQry3 & WrkAnd & "year>=" & WrkFullFromYear
      End If
      If WrkFullToYear > 0 Then
        WrkQry3 = WrkQry3 & WrkAnd & "year<=" & WrkFullToYear
      End If
      If WrkOmitSusp Then
        WrkQry3 = WrkQry3 & WrkAnd & "icode<>'S'"
      End If
      If MyServer = "DB2" Then
        WrkTypes = BuildSelectTypes(MyNonPublic)
        WrkQry3 = WrkQry3 & WrkAnd & WrkTypes
      Else
        WrkQry3 = BuildSelectQryPC(WrkQry3, MyNonPublic)
      End If

      WrkQry4 = "icode<>'I'" & WrkAnd & "bald > 0" & WrkAnd & "year<" & WrkFullFromYear
      'WrkQry4 = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "bald > 0" & WrkAnd & "year<" & WrkFullFromYear
      If WrkOmitSusp Then
        WrkQry4 = WrkQry4 & WrkAnd & "icode<>'S'"
      End If
      If MyServer = "DB2" Then
        WrkTypes = BuildSelectTypes(MyNonPublic)
        WrkQry4 = WrkQry4 & WrkAnd & WrkTypes
      Else
        WrkQry4 = BuildSelectQryPC(WrkQry4, MyNonPublic)
      End If
    End If

    WrkSort = "YEAR, TYPE, DIST"
    'WrkQry = WrkQry & WrkAnd & "list#=40049"  'For Testing
    'WrkQry2 = WrkQry2 & WrkAnd & "list#=40049"  'For Testing
    'WrkQry3 = WrkQry3 & WrkAnd & "list#=40049"  'For Testing
    'WrkQry4 = WrkQry4 & WrkAnd & "list#=40049"  'For Testing
    If WrkQry3 = "" Then
      WrkQryFull = WrkQry & WrkOr & WrkQry2
    Else
      WrkQryFull = WrkQry & WrkOr & WrkQry2 & WrkOr & WrkQry3 & WrkOr & WrkQry4
    End If
    myTXINVQ.OpenQry(WrkSort, WrkQryFull)

    myFrmProgress = New FrmProgress
    If MyAutomate Then
      myFrmProgress.Text = "TX830 - Creating file..."
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveType = ""
    Counter = 0
    UnqInv = 1
    UnqHist = 1

    sw.WriteLine(BuildBlankInv(UnqInv))
    sw2.WriteLine(BuildBlankHist(UnqHist))

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If SaveType <> "" And SaveType <> ._TYPE Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
          SaveYear = ._YEAR
          SaveType = ._TYPE
        End If
        If SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If

        SaveYear = ._YEAR
        SaveType = ._TYPE
        If Trim(WrkStsOmit) > "" Then   ' omit status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkStsOmit, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then
            GoTo NextRec
          End If
        End If
        WrkAcctID = Mid(._YEAR, 3, 2) & Trim(._TYPE) & ._LISTNo
        WrkAcctCode = String.Empty
        If ._ICODE = "B" Then
          If WrkBlockBackTax Then
            WrkAcctCode = "I"
          Else
            WrkAcctCode = "B"
          End If
        End If
        If WrkBlockSusp And ._ICODE = "S" Then
          WrkAcctCode = "I"
        End If
        If Trim(WrkStsBlocked) <> "" Then    ' filter status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkStsBlocked, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkStsBlocked, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkStsBlocked, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkStsBlocked, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkStsBlocked, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then
            WrkAcctCode = "I"
          End If
        End If
        If Trim(WrkStsLiened) <> "" Then    ' filter status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkStsLiened, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkStsLiened, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkStsLiened, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkStsLiened, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkStsLiened, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then
            WrkAcctCode = "I"
          End If
        End If

        WrkInterest = 0
        WrkLiens = 0
        WrkBond = 0
        WrkTax = 0
        WrkDue = 0
        WrkFees = 0
        If ._BALD > 0 Then
          CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, WrkInterestPaid, WrkFees, WrkLiens, WrkBond, WrkTax, WrkDue, WrkGracePeriod)
        End If
        'Filter - Omit no amount due 
        If WrkDue <= 0 And ._YEAR < WrkFullFromYear Then
          GoTo NextRec
        End If
        'Filter - Omit In Grace Period unless selected
        '  If InStr(MyNonPublic, ._TYPE) > 0 And WrkDue > 0 And WrkGracePeriod Then
        '    GoTo NextRec
        '  End If
        'WebNP=N Omit NonPublic Paid records/WebNP=Y include all Non Public records
        'Webpay  Search by Name or List#    / Search by List#
        WrkNP = False
        If InStr(MyNonPublic, ._TYPE) > 0 Then
          If MyWebNP Then WrkNP = True
          If WrkDue <= 0 And Not WrkNP And Not WrkGracePeriod Then
            GoTo NextRec
          End If
        End If

        If Trim(WrkStsNonCodes) <> "" And Not WrkNP Then 'non public status codes
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkStsNonCodes, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkStsNonCodes, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkStsNonCodes, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkStsNonCodes, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkStsNonCodes, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then
            WrkNP = True
          End If
        End If

        If ._PHASE = 0 Then
          WrkPhase = String.Empty
        Else
          WrkPhase = ._PHASE
        End If
        If MyTXPROF._PRTYPE <> ._TYPE Or MyTXPROF._PRYEAR <> ._YEAR Or MyTXPROF._DIST <> ._DIST Then
          WrkDueDate1 = String.Empty
          WrkDueDate2 = String.Empty
          WrkDueDate3 = String.Empty
          WrkDueDate4 = String.Empty
          MyTXPROF.GetOneRecordP(._TYPE, ._YEAR, WrkPhase, ._DIST)
          With MyTXPROF
            WrkDueDate1 = Format(MyUtils.GetDBDateMDY(._PRDUE1), "M/d/yyyy")
            If ._PRDUE2 > 0 Then WrkDueDate2 = Format(MyUtils.GetDBDateMDY(._PRDUE2), "M/d/yyyy")
            If ._PRDUE3 > 0 Then WrkDueDate3 = Format(MyUtils.GetDBDateMDY(._PRDUE3), "M/d/yyyy")
            If ._PRDUE3 > 0 Then WrkDueDate4 = Format(MyUtils.GetDBDateMDY(._PRDUE4), "M/d/yyyy")
          End With
        End If

        WrkTCount = WrkTCount + 1
        WrkTAmtDue = WrkTAmtDue + WrkTax
        WrkTInterest = WrkTInterest + WrkInterest
        WrkTFees = WrkTFees + WrkFees
        WrkTLiens = WrkTLiens + WrkLiens
        WrkTBond = WrkTBond + WrkBond
        WrkTTotal = WrkTTotal + WrkDue

        'Write all fields to text file
        sb = New StringBuilder
        'Non Public: townbr=0 webpay can search by list# or account only
        If WrkNP Then
          sb.Append(0)
        Else
          sb.Append(myTOWN._TOWNBR)
        End If
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
        K = LookupType(._TYPE)
        sb.Append(WrkDesc(K))
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(StripChars(Trim(._NAME)))
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(StripChars(Trim(._SNAME)))
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        Select Case WrkFamily(K) 'No address if MV/Supp
          Case "M", "S"
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
            sb.Append(WrkComma)
            sb.Append("")
          Case Else
            sb.Append(WrkQuote)
            sb.Append(StripChars(Trim(._ADD1)))
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(StripChars(Trim(._ADD2)))
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(Trim(._CITY))
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(._STATE)
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
            sb.Append(WrkQuote)
            sb.Append(MyUtils.JustifyRight(Trim(._LOCNo), 7))
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(StripChars(Trim(._LOC)))
            sb.Append(WrkQuote)
        End Select
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        If WrkMVRegNo Then
          sb.Append(Trim(._IMVREG))
        Else
          sb.Append("")
        End If
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        WrkPropDesc = ""
        Select Case WrkFamily(K)
          Case "M", "S"
            If WrkMVRegNo Then
              WrkPropDesc = Trim(._IMVREG) & " "
            End If
            WrkPropDesc = WrkPropDesc & Trim(._MAKE) & " " & Trim(._MODEL) & " " & ._MVYR
          Case Else
            WrkPropDesc = StripChars(Trim(._LOCNo) & " " & Trim(._LOC))
        End Select
        sb.Append(WrkQuote)
        sb.Append(Mid(WrkPropDesc, 1, 30))
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(Format(WrkTax, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkInterest, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkFees, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkLiens, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkBond, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkDue, "fixed"))
        sb.Append(WrkComma)
        WrkPrinPaid = ._PAYREC + ._NEWPAY
        sb.Append(Format(WrkPrinPaid, "fixed"))
        sb.Append(WrkComma)
        If ._CCNO > 0 Then
          WrkBalance = ._CCETAX - ._PAYREC - ._NEWPAY + WrkInterest + WrkFees + WrkLiens + WrkBond
        Else
          WrkBalance = ._TAXT - ._PAYREC - ._NEWPAY + WrkInterest + WrkFees + WrkLiens + WrkBond
        End If
        sb.Append(Format(WrkBalance, "fixed"))
        sb.Append(WrkComma)
        If ._CCNO > 0 Then
          sb.Append(Format(._CCETAX, "fixed"))
        Else
          sb.Append(Format(._TAXT, "fixed"))
        End If
        sb.Append(WrkComma)
        If ._CCNO > 0 Then
          WrkTax1 = ._CCTX1
          WrkTax2 = ._CCTX2
          WrkTax3 = ._CCTX3
          WrkTax4 = ._CCTX4
          WrkGross = ._CGRS
          WrkExam = ._CEXA1 + ._CEXA2 + ._CEXA3 + ._CEXA4 + ._CEXA5 + ._CEXA6 + ._CEXA7
          WrkNet = WrkGross - WrkExam
        Else
          WrkTax1 = ._TAX1
          WrkTax2 = ._TAX2
          WrkTax3 = ._TX3RD
          WrkTax4 = ._TX4TH
          WrkGross = ._GROSS
          WrkExam = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5 + ._EXAM6 + ._EXAM7
          WrkNet = ._NETASS
        End If
        sb.Append(Format(WrkTax1, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkTax2, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkTax3, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(WrkTax4, "fixed"))
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(WrkDueDate1)
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(WrkDueDate2)
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(WrkDueDate3)
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(WrkDueDate4)
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkGross)
        sb.Append(WrkComma)
        sb.Append(WrkExam)
        sb.Append(WrkComma)
        sb.Append(WrkNet)
        sb.Append(WrkComma)
        sb.Append(Format(._FTAX, "fixed"))
        sb.Append(WrkComma)
        sb.Append(Format(._TWNBN, "fixed"))
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(WrkAcctID)
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        sb.Append(WrkAcctCode)
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        sb.Append(WrkQuote)
        If WrkAcctCode = "L" Then
          sb.Append(StripChars(WrkLienMsg))
        End If
        sb.Append(WrkQuote)
        sb.Append(WrkComma)
        K = LookupProdID(._TYPE)
        If K >= 0 Then
          sb.Append(WrkProdID(K))
        Else
          sb.Append(0)
        End If
        sb.Append(WrkComma)
        UnqInv = UnqInv + 1
        sb.Append(UnqInv)
        sw.WriteLine(sb.ToString)
        sb = Nothing

        myTXHSTL4.SetRange(._LISTNo, ._YEAR, ._TYPE, WrkDBToday, True)
ReadHist:
        myTXHSTL4.ReadFilePE()
        If Not myTXHSTL4.IsEOF Then
          With myTXHSTL4
            If ._RCODE = "I" Or ._RCODE = "V" Then GoTo ReadHist
            sb = New StringBuilder
            sb.Append(._LISTNO)
            sb.Append(WrkComma)
            sb.Append(._YEAR)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(._TYPE)
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(Format(._PAMT, "fixed"))
            sb.Append(WrkComma)
            sb.Append(Format(._IAMT, "fixed"))
            sb.Append(WrkComma)
            sb.Append(Format(._LAMT, "fixed"))
            sb.Append(WrkComma)
            sb.Append(Format(._PCAMT, "fixed"))
            sb.Append(WrkComma)
            WrkNumber = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
            sb.Append(Format(WrkNumber, "fixed"))
            sb.Append(WrkComma)
            sb.Append(._CORC)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(._ADJCD)
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(._PDATE)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(Format(MyUtils.GetDBDate(._PDATE), "M/d/yyyy"))
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            sb.Append(WrkQuote)
            sb.Append(WrkAcctID)
            sb.Append(WrkQuote)
            sb.Append(WrkComma)
            UnqHist = UnqHist + 1
            sb.Append(UnqHist)
            sw2.WriteLine(sb.ToString)
            sb = Nothing
            GoTo ReadHist
          End With
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
        GoTo ReadNext
      End With
    End If

    WriteTotals(SaveYear, SaveType)
    sw.WriteLine(BuildBlankInv(UnqInv + 1))
    sw2.WriteLine(BuildBlankHist(UnqHist + 1))
    sw.Flush()
    sw.Close()
    sw2.Flush()
    sw2.Close()
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

  End Sub
  Private Sub BuildDS()
    Dim myTableTot As New DataTable
    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TAmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("TInterest", Type.GetType("System.Decimal"))
      .Columns.Add("TFees", Type.GetType("System.Decimal"))
      .Columns.Add("TLiens", Type.GetType("System.Decimal"))
      .Columns.Add("TBond", Type.GetType("System.Decimal"))
      .Columns.Add("TTotal", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub
  Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
    Dim K As Integer
    If WrkTCount = 0 Then Exit Sub

    dr = dsTot.Tables(0).NewRow
    dr.Item("tcount") = WrkTCount
    dr.Item("year") = SaveYear
    K = LookupType(SaveType)
    dr.Item("typedesc") = WrkDesc(K)
    dr.Item("tamtdue") = WrkTAmtDue
    dr.Item("tinterest") = WrkTInterest
    dr.Item("tfees") = WrkTFees
    dr.Item("tliens") = WrkTLiens
    dr.Item("tbond") = WrkTBond
    dr.Item("ttotal") = WrkTTotal
    dsTot.Tables(0).Rows.Add(dr)
    dr = Nothing
  End Sub
  Private Function BuildSelectTypes(WrkSelTypes) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If WrkSelTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(WrkSelTypes)

    For I = 1 To StrLen
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Public Sub CalcInterest(ByVal InListNo As Integer, ByVal InType As String,
    ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal,
    ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal,
    ByRef OutDue As Decimal, ByRef OutGracePeriod As Boolean)
    With myCASHINT
      .In_IntDate = WrkIntDate
      .In_ListNo = InListNo
      .In_Type = InType
      .In_Year = InYear
      .CalcInterest()
      OutInterest = Format(.Out_Int(), "standard")
      OutInterestPaid = Format(.Out_IntPaid(), "standard")
      OutLien = Format(.Out_Lien(), "standard")
      OutFee = Format(.Out_Fee(), "standard")
      OutBond = Format(.Out_Bond(), "standard")
      OutTax = Format(.Out_Prin(), "standard")
      OutDue = Format(.Out_Tot(), "standard")
      OutGracePeriod = .Out_GracePeriod
    End With
  End Sub
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.myData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.mydata(MyDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As Integer
    Dim I As Integer

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return 0
      End If
      If Type = WrkCode(I) Then
        Return I
      End If
    Next

    Return 0
  End Function
  Private Sub BufferProdID()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    Dim myTXPAYID As TXPAYID.myData
    Dim dsTXType As DataSet = New DataSet

    myTXPAYID = New TXPAYID.mydata(MyDBConnect)

    ds2 = myTXPAYID.PosData("")
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkType(I) = .Item("type")
        WrkProdID(I) = .Item("prodid")
      End With
    Next
  End Sub
  Private Function LookupProdID(ByVal Type As String) As Integer
    Dim I As Integer

    If WrkType.GetUpperBound(0) = -1 Then
      Return -1
    End If

    For I = 0 To WrkType.GetUpperBound(0)
      If Type = WrkType(I) Then
        Return I
      End If
    Next

    Return 0
  End Function
  Private Sub NavigateWeb()
    WrkWebMsg = RunScript(WrkWebScript)
  End Sub
  Private Sub WriteLogAuto()
    Dim WrkPath As String
    Dim WrkProgName As String
    Dim WrkTimestamp As String

    WrkPath = MyUtils.GetDataPath() & "Logs\"
    WrkProgName = MyUtils.GetProgramName() & " Auto"
    WrkProgName = Replace(WrkProgName, ".exe", "")
    WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath &
   "-" & WrkProgName & "-" & WrkTimestamp & ".Log")
    sw.WriteLine(WrkProgName)
    sw.WriteLine("")
    sw.WriteLine(WrkWebMsg)
    sw.WriteLine("")
    sw.WriteLine("Program completed normally")
    sw.Close()
  End Sub
  Private Function BuildBlankInv(ByVal WrkRecID As Integer)
    Dim WrkStr As String
    Const WrkComma = ","
    Const WrkQuote = Chr(34)
    sb = New StringBuilder
    sb.Append(Format(myTOWN._TOWNBR, "000"))
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(0)
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(0)
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Format(Date.Now, "M/d/yyyy"))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(WrkRecID)
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildBlankHist(ByVal WrkRecID As Integer)
    Dim WrkStr As String
    Const WrkComma = ","
    Const WrkQuote = Chr(34)
    sb = New StringBuilder
    sb = New StringBuilder
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append("")
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(0)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(Format(Date.Now, "M/d/yyyy"))
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append("")
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkRecID)
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function StripChars(ByVal WrkStr As String) As String
    WrkStr = Replace(WrkStr, "'", "")
    WrkStr = Replace(WrkStr, ",", "")
    WrkStr = Replace(WrkStr, Chr(34), "") 'Remove double quotes
    Return WrkStr
  End Function
End Module
