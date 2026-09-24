Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXPROF As TXPROF.MyData

  Dim WrkFilePath As String
  Dim WrkFileName As String
  Dim WrkFile As String
  Dim WrkAddress As String
  Dim WrkUser As String
  Dim WrkPassword As String
  'Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  'Product ID
  Dim WrkType(25) As String
  Dim WrkProdID(25) As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    Dim WrkDate As Date
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXPROF = New TXPROF.MyData(myDBConnect)

    WrkDate = DateAdd(DateInterval.Day, -7, Date.Now)
    MyLastDate = MyUtils.SetDBDate(WrkDate)
    If MyAutomate Then
      MyFrmTX831.SbpPgmID.Text = "TX831B"
      MyFrmTX831.SbpEnvironment.Text = myDBConnect.PgmDB
      MyTypes = MyAppSettings.Types
      WrkFilePath = MyAppSettings2.FilePath
      WrkFileName = MyAppSettings2.FileName
      WrkAddress = MyAppSettings2.Address
      WrkUser = MyAppSettings2.User
      WrkPassword = MyAppSettings2.Password
    Else
      With MyFrmTX831B
        WrkFilePath = MyFrmTX831B.TxtFilePath.Text
        WrkFileName = MyFrmTX831B.TxtFileName.Text
        WrkAddress = MyFrmTX831B.TxtAddress.Text
        WrkUser = MyFrmTX831B.TxtUser.Text
        WrkPassword = MyFrmTX831B.TxtPassword.Text
      End With
    End If

    WrkFileName = Replace(WrkFileName, "Account_ID", WrkUser)
    WrkFile = WrkFileName & ".csv"
    If Right(WrkFilePath, 1) <> "\" Then
      WrkFilePath = WrkFilePath & "\"
    End If
    BufferType()
    BufferProdID()
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkStsOmit As String
    Dim Counter As Integer
    Dim Pos As Integer
    Dim sw As StreamWriter = New StreamWriter(WrkFilePath & WrkFile)

    WrkAnd = " and "
    WrkOr = " or "

    Counter = 0

    WrkSort = "LIST#, TYPE, YEAR"
    WrkQry = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "taxt=0" & WrkAnd & "cdate>=" & MyLastDate
    WrkQry = WrkQry & WrkOr & "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "pdat>=" & MyLastDate
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    If MyAutomate Then
      myFrmProgress.Text = "TX831 - Creating file..."
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    sw.WriteLine(BuildHeader)
    WrkStsOmit = MyAppSettings.Omit & MyAppSettings.NonCodes

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
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
        sw.WriteLine(BuildFile)
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

    sw.Flush()
    sw.Close()
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

    If WrkAddress <> "" Then
      PutFile(WrkFilePath & WrkFile, WrkFile)
    End If

    If MyAutomate Then
      WriteLogAuto()
      Application.Exit()
    End If

  End Sub
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
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Function BuildHeader() As String
    Const WrkComma As String = ","
    Dim sb As StringBuilder
    Dim WrkStr As String

    sb = New StringBuilder
    sb.Append("TOWNBR")
    sb.Append(WrkComma)
    sb.Append("LISTNUM")
    sb.Append(WrkComma)
    sb.Append("YEAR")
    sb.Append(WrkComma)
    sb.Append("TYPE")
    sb.Append(WrkComma)
    sb.Append("TYPEDS")
    sb.Append(WrkComma)
    sb.Append("NAME")
    sb.Append(WrkComma)
    sb.Append("SNAME")
    sb.Append(WrkComma)
    sb.Append("ADD1")
    sb.Append(WrkComma)
    sb.Append("ADD2")
    sb.Append(WrkComma)
    sb.Append("CITY")
    sb.Append(WrkComma)
    sb.Append("STATE")
    sb.Append(WrkComma)
    sb.Append("ZIP5")
    sb.Append(WrkComma)
    sb.Append("ZIP4")
    sb.Append(WrkComma)
    sb.Append("LOCNUM")
    sb.Append(WrkComma)
    sb.Append("LOC")
    sb.Append(WrkComma)
    sb.Append("IMVREG")
    sb.Append(WrkComma)
    sb.Append("DESCRIPTION")
    sb.Append(WrkComma)
    sb.Append("PAMTD")
    sb.Append(WrkComma)
    sb.Append("IAMTD")
    sb.Append(WrkComma)
    sb.Append("FEESD")
    sb.Append(WrkComma)
    sb.Append("LAMTD")
    sb.Append(WrkComma)
    sb.Append("PCAMTD")
    sb.Append(WrkComma)
    sb.Append("AMTD")
    sb.Append(WrkComma)
    sb.Append("TOTPAY")
    sb.Append(WrkComma)
    sb.Append("BALLANCE")
    sb.Append(WrkComma)
    sb.Append("TOTDUE")
    sb.Append(WrkComma)
    sb.Append("1STDUE")
    sb.Append(WrkComma)
    sb.Append("2NDDUE")
    sb.Append(WrkComma)
    sb.Append("3RDDUE")
    sb.Append(WrkComma)
    sb.Append("4THDUE")
    sb.Append(WrkComma)
    sb.Append("1STDATE")
    sb.Append(WrkComma)
    sb.Append("2NDDATE")
    sb.Append(WrkComma)
    sb.Append("3RDDATE")
    sb.Append(WrkComma)
    sb.Append("4THDATE")
    sb.Append(WrkComma)
    sb.Append("GROSS")
    sb.Append(WrkComma)
    sb.Append("EXAM")
    sb.Append(WrkComma)
    sb.Append("NET")
    sb.Append(WrkComma)
    sb.Append("ELDBEN")
    sb.Append(WrkComma)
    sb.Append("TWNBEN")
    sb.Append(WrkComma)
    sb.Append("acctID")
    sb.Append(WrkComma)
    sb.Append("blockStatus")
    sb.Append(WrkComma)
    sb.Append("LienMsg")
    sb.Append(WrkComma)
    sb.Append("ProductID")
    sb.Append(WrkComma)
    sb.Append("itemID")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildFile() As String
    Const WrkComma As String = ","
    Const WrkQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkInterest As Decimal
    Dim WrkFees As Decimal
    Dim WrkLiens As Decimal
    Dim WrkBond As Decimal
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
    Dim WrkPropDesc As String
    Dim WrkAcctID As String
    Dim WrkAcctCode As String
    Dim WrkDue As Decimal
    Dim WrkPhase As String
    Dim K As Integer

    With myTXINVQ
      WrkAcctID = Mid(._YEAR, 3, 2) & Trim(._TYPE) & ._LISTNo
      WrkAcctCode = String.Empty
      If ._PHASE = 0 Then
        WrkPhase = String.Empty
      Else
        WrkPhase = ._PHASE
      End If
      WrkDueDate1 = String.Empty
      WrkDueDate2 = String.Empty
      WrkDueDate3 = String.Empty
      WrkDueDate4 = String.Empty
      myTXPROF.GetOneRecordP(._TYPE, ._YEAR, WrkPhase, ._DIST)
      With myTXPROF
        WrkDueDate1 = Format(MyUtils.GetDBDateMDY(._PRDUE1), "M/d/yyyy")
        If ._PRDUE2 > 0 Then WrkDueDate2 = Format(MyUtils.GetDBDateMDY(._PRDUE2), "M/d/yyyy")
        If ._PRDUE3 > 0 Then WrkDueDate3 = Format(MyUtils.GetDBDateMDY(._PRDUE3), "M/d/yyyy")
        If ._PRDUE3 > 0 Then WrkDueDate4 = Format(MyUtils.GetDBDateMDY(._PRDUE4), "M/d/yyyy")
      End With
      sb = New StringBuilder
      sb.Append(myTOWN._TOWNBR)
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
      sb.Append(WrkComma)
      sb.Append(WrkQuote)
      sb.Append(Trim(._IMVREG))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      WrkPropDesc = ""
      Select Case WrkFamily(K)
        Case "M", "S"
          WrkPropDesc = Trim(._IMVREG) & " "
          WrkPropDesc = WrkPropDesc & Trim(._MAKE) & " " & Trim(._MODEL) & " " & ._MVYR
        Case Else
          WrkPropDesc = StripChars(Trim(._LOCNo) & " " & Trim(._LOC))
      End Select
      sb.Append(WrkQuote)
      sb.Append(Mid(WrkPropDesc, 1, 30))
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      If ._CCNO > 0 Then
        sb.Append(Format(._CCETAX, "fixed"))
      Else
        sb.Append(Format(._TAXT, "fixed"))
      End If
      sb.Append(WrkComma)
      sb.Append(Format(WrkInterest, "fixed")) 'Zero
      sb.Append(WrkComma)
      sb.Append(Format(WrkFees, "fixed")) 'Zero
      sb.Append(WrkComma)
      sb.Append(Format(WrkLiens, "fixed")) 'Zero
      sb.Append(WrkComma)
      sb.Append(Format(WrkBond, "fixed")) 'Zero
      sb.Append(WrkComma)
      sb.Append(Format(WrkDue, "fixed")) 'Zero
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
      sb.Append("")
      sb.Append(WrkQuote)
      sb.Append(WrkComma)
      K = LookupProdID(._TYPE)
      If K >= 0 Then
        sb.Append(WrkProdID(K))
      Else
        sb.Append(0)
      End If
      sb.Append(WrkComma)
      sb.Append(0)
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With
  End Function
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.myData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.mydata(myDBConnect)

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

    myTXPAYID = New TXPAYID.mydata(myDBConnect)

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
  Private Function StripChars(ByVal WrkStr As String) As String
    WrkStr = Replace(WrkStr, "'", "")
    WrkStr = Replace(WrkStr, ",", "")
    WrkStr = Replace(WrkStr, Chr(34), "") 'Remove double quotes
    Return WrkStr
  End Function
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
    sw.WriteLine("Program completed normally")
    sw.Close()
  End Sub
End Module






