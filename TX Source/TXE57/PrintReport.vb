Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myCASHINT As CASHINT.MyData

  Dim WrkIntDate As Date
  Dim WrkGLYear As Integer
  Dim WrkFormat As String
  Dim WrkFilePath As String
  Dim WrkFileName As String
  Dim WrkFile As String
  Dim WrkAddress As String
  Dim WrkUser As String
  Dim WrkPasssword As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    If MyAutomate Then
      WrkIntDate = Date.Today
      MyFrmTXE57.SbpPgmID.Text = "TXE57B"
      MyFrmTXE57.SbpEnvironment.Text = myDBConnect.PgmDB
      WrkGLYear = Date.Now.Year - 1
      If Date.Now.Month < 7 Then
        WrkGLYear = WrkGLYear - 1
      End If
      MyTypes = MyAppSettings.Types
      MyFormat = MyAppSettings.Format
      WrkFilePath = MyAppSettings.FilePath
      WrkFileName = MyAppSettings.FileName
      WrkAddress = MyAppSettings.Address
      WrkUser = MyAppSettings.User
      WrkPasssword = MyAppSettings.Password
    Else
      With MyFrmTXE57B
        WrkIntDate = Date.Today
        WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
        MyTypes = .TxtTypes.Text
        WrkFilePath = MyFrmTXE57B.TxtFilePath.Text
        WrkFileName = MyFrmTXE57B.TxtFileName.Text
        WrkAddress = MyFrmTXE57B.TxtAddress.Text
        WrkUser = MyFrmTXE57B.TxtUser.Text
        WrkPasssword = MyFrmTXE57B.TxtPassword.Text
      End With
    End If

    If Right(WrkFilePath, 1) <> "\" Then
      WrkFilePath = WrkFilePath & "\"
    End If
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkQry1 As String
    Dim WrkQry2 As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim sw As StreamWriter = New StreamWriter(WrkFilePath & WrkFileName)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0

    WrkSort = "LIST#, TYPE, YEAR"
    WrkQry1 = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "YEAR = " & WrkGLYear
    WrkQry2 = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd &
  "YEAR < " & WrkGLYear & WrkAnd & "BALD>0"
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry1, MyTypes) & WrkOr & BuildSelectQryPC(WrkQry2, MyTypes)
    Else
      WrkQry = WrkQry1 & WrkOr & WrkQry2
    End If
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    If MyAutomate Then
      myFrmProgress.Text = "TXE57 - Creating file..."
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    sw.WriteLine(BuildHeader)

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
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

    PutFile(WrkFilePath & WrkFileName, WrkFileName)

    If MyAutomate Then
      WriteLogAuto()
      Application.Exit()
    End If

  End Sub
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
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
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
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Function BuildHeader() As String
    Const CComma As String = ","
    Dim sb As StringBuilder
    Dim WrkStr As String

    sb = New StringBuilder
    sb.Append("ListNo")
    sb.Append(CComma)
    sb.Append("Year")
    sb.Append(CComma)
    sb.Append("Type")
    sb.Append(CComma)
    sb.Append("Name")
    sb.Append(CComma)
    sb.Append("LocNo")
    sb.Append(CComma)
    sb.Append("Loc")
    sb.Append(CComma)
    sb.Append("Map")
    sb.Append(CComma)
    sb.Append("TaxTot")
    sb.Append(CComma)
    sb.Append("Tax1")
    sb.Append(CComma)
    sb.Append("Tax2")
    sb.Append(CComma)
    sb.Append("Tax3")
    sb.Append(CComma)
    sb.Append("Tax4")
    sb.Append(CComma)
    sb.Append("Bal1")
    sb.Append(CComma)
    sb.Append("Bal2")
    sb.Append(CComma)
    sb.Append("Bal3")
    sb.Append(CComma)
    sb.Append("Bal4")
    sb.Append(CComma)
    sb.Append("Interest")
    sb.Append(CComma)
    sb.Append("Lien")
    sb.Append(CComma)
    sb.Append("Lien Code")
    sb.Append(CComma)
    sb.Append("Gross")
    sb.Append(CComma)
    sb.Append("Exemptions")
    sb.Append(CComma)
    sb.Append("Net")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildFile() As String
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkDue As Decimal
    Dim WrkTax As Decimal
    Dim WrkBal1 As Decimal
    Dim WrkBal2 As Decimal
    Dim WrkBal3 As Decimal
    Dim WrkBal4 As Decimal
    Dim WrkInterest As Decimal
    Dim WrkLien As Decimal

    With myTXINVQ
      If ._CCNO = 0 Then
        WrkBal1 = ._TAX1
        WrkBal2 = ._TAX2
        WrkBal3 = ._TX3RD
        WrkBal4 = ._TX4TH
      Else
        WrkBal1 = ._CCTX1
        WrkBal2 = ._CCTX2
        WrkBal3 = ._CCTX3
        WrkBal4 = ._CCTX4
      End If
      If ._BALD > 0 Then
        CalcInterest(._LISTNo, ._TYPE, ._YEAR, WrkInterest, 0, 0, WrkLien, 0, WrkTax, 0, False)
      End If
      WrkDue = ._BALD
      If WrkBal4 > 0 Then
        If WrkDue >= WrkBal4 Then
          WrkDue = WrkDue - WrkBal4
        Else
          WrkBal4 = WrkDue
          WrkDue = 0
        End If
      End If
      If WrkBal3 > 0 Then
        If WrkDue >= WrkBal3 Then
          WrkDue = WrkDue - WrkBal3
        Else
          WrkBal3 = WrkDue
          WrkDue = 0
        End If
      End If
      If WrkBal2 > 0 Then
        If WrkDue >= WrkBal2 Then
          WrkDue = WrkDue - WrkBal2
        Else
          WrkBal2 = WrkDue
          WrkDue = 0
        End If
      End If
      If WrkDue >= WrkBal1 Then
        WrkDue = WrkDue - WrkBal1
      Else
        WrkBal1 = WrkDue
        WrkDue = 0
      End If
      sb = New StringBuilder
      sb.Append(._LISTNo)
      sb.Append(CComma)
      sb.Append(._YEAR)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(._TYPE)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._NAME))
      sb.Append(CQuote)
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
      sb.Append(Trim(._MAP))
      sb.Append(CQuote)
      sb.Append(CComma)
      If ._CCNO = 0 Then
        sb.Append(Format(._TAXT, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._TAX1, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._TAX2, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._TX3RD, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._TX4TH, "Fixed"))
      Else
        sb.Append(Format(._CCETAX, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._CCTX1, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._CCTX2, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._CCTX3, "Fixed"))
        sb.Append(CComma)
        sb.Append(Format(._CCTX4, "Fixed"))
      End If
      sb.Append(CComma)
      sb.Append(Format(WrkBal1, "Fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBal2, "Fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBal3, "Fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkBal4, "Fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkInterest, "Fixed"))
      sb.Append(CComma)
      sb.Append(Format(WrkLien, "Fixed"))
      sb.Append(CComma)
      sb.Append("")
      sb.Append(CComma)
      sb.Append(._GROSS)
      sb.Append(CComma)
      sb.Append(._GROSS - ._NETASS)
      sb.Append(CComma)
      sb.Append(._NETASS)
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With
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







