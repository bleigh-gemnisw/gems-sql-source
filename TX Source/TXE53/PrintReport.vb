Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.myData
  Dim myCASHINT As CASHINT.MyData

  Dim WrkIntDate As Date
  Dim WrkFormat As String
  Dim WrkFilePath As String
  Dim WrkHeader As Boolean
  Dim WrkImplicit As Boolean
  Dim WrkAddress As String
  Dim WrkUser As String
  Dim WrkPasssword As String
  Dim WrkPort As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)

    If MyAutomate Then
      WrkIntDate = Date.Today
      MyTypes = MyAppSettings.Types
      MyFormat = MyAppSettings.Format
      WrkFilePath = MyAppSettings.FilePath
      WrkHeader = MyAppSettings.Header
      WrkImplicit = MyAppSettings.Implicit
      WrkAddress = MyAppSettings.Address
      WrkUser = MyAppSettings.User
      WrkPasssword = MyAppSettings.Password
      WrkPort = MyAppSettings.Port
    Else
      With MyFrmTXE53B
        WrkIntDate = Date.Today
        MyTypes = .TxtTypes.Text
        WrkFilePath = MyFrmTXE53B.LblFilePath.Text
        If MyFrmTXE53B.RbGeneric.Checked Then MyFormat = ""
        If MyFrmTXE53B.RbView.Checked Then MyFormat = "VP"
        WrkHeader = MyFrmTXE53B.ChkHeader.Checked
        WrkImplicit = MyFrmTXE53B.ChkImplicit.Checked
        WrkAddress = MyFrmTXE53B.TxtAddress.Text
        WrkUser = MyFrmTXE53B.TxtUser.Text
        WrkPasssword = MyFrmTXE53B.TxtPassword.Text
        WrkPort = MyUtils.CnvSng(MyFrmTXE53B.TxtPort.Text)
      End With
    End If

    WrkIntDate = Date.Today
    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkDelq As Boolean
    Dim WrkDue As Decimal
    Dim WrkGracePeriod As Boolean
    Dim WrkFileName As String
    Dim SaveType As String
    Dim SaveLoc As String
    Dim SaveLocNo As String
    Dim SaveMap As String
    Dim SaveList As Integer
    Dim SaveName As String
    Dim SaveSname As String
    Dim Counter As Integer
    Dim WrkStartYear As Integer
    Dim sw As StreamWriter = New StreamWriter(WrkFilePath)

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0

    WrkStartYear = Today.Year - 3
    WrkSort = "LIST#, TYPE, YEAR desc, LOC, LOC#"
    WrkQry = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "YEAR >= " & WrkStartYear
    If MyFormat = "VP" Then
      WrkQry = WrkQry & " and BALD>0"
    End If
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    If MyAutomate Then
      myFrmProgress.Text = "TXE53 - Creating file..."
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    If WrkHeader Then
      sw.WriteLine(BuildHeader)
    End If
    Counter = 0
    SaveType = String.Empty
    SaveLoc = String.Empty
    SaveLocNo = String.Empty
    SaveMap = String.Empty
    SaveName = String.Empty
    SaveSname = String.Empty
    WrkDelq = False

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If SaveType <> "" Then
          If SaveType <> ._TYPE Or SaveLoc <> Trim(._LOC) Or SaveLocNo <> Trim(._LOCNo) Then
            Select Case MyFormat
              Case "VP"
                sw.WriteLine(BuildFileView(SaveType, SaveLoc, SaveLocNo, SaveList, SaveMap, SaveName, SaveSname))
              Case Else
                sw.WriteLine(BuildFile(SaveType, SaveLoc, SaveLocNo, SaveList, SaveMap, SaveName, WrkDelq))
            End Select
            WrkDelq = False
          End If
        End If
        SaveType = ._TYPE
        SaveLoc = Trim(._LOC)
        SaveLocNo = Trim(._LOCNo)
        SaveMap = Trim(._MAP)
        SaveList = ._LISTNo
        SaveName = Trim(._NAME)
        SaveSname = Trim(._SNAME)
        WrkDue = 0
        If ._BALD > 0 Then
          If Not WrkDelq Then
            CalcInterest(._LISTNo, ._TYPE, ._YEAR, 0, 0, 0, 0, 0, 0, WrkDue, WrkGracePeriod)
          End If
          If WrkDue > 0 And Not WrkGracePeriod Then
            WrkDelq = True
          End If
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

    Select Case MyFormat
      Case "VP"
        sw.WriteLine(BuildFileView(SaveType, SaveLoc, SaveLocNo, SaveList, SaveMap, SaveName, SaveSname))
      Case Else
        sw.WriteLine(BuildFile(SaveType, SaveLoc, SaveLocNo, SaveList, SaveMap, SaveName, WrkDelq))
    End Select
    sw.Flush()
    sw.Close()
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

    If WrkAddress <> "" Then
      Select Case MyFormat
        Case "VP"
          WrkFileName = "mpermit.csv"
        Case Else
          WrkFileName = "taxdelq.csv"
      End Select
      PutFile(WrkFilePath, WrkFileName)
    End If

    If MyAutomate Then
      WriteLogAuto()
      Application.Exit()
    End If

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
  Private Function BuildHeader() As String
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim WrkStr As String
    sb = New StringBuilder
    sb.Append(CQuote)
    sb.Append("TYPE")
    sb.Append(CQuote)
    sb.Append(CComma)
    sb.Append(CQuote)
    sb.Append("LIST#")
    sb.Append(CQuote)
    sb.Append(CComma)
    sb.Append(CQuote)
    sb.Append("MAP")
    sb.Append(CQuote)
    sb.Append(CComma)
    sb.Append(CQuote)
    sb.Append("LOC NO")
    sb.Append(CQuote)
    sb.Append(CComma)
    sb.Append(CQuote)
    sb.Append("LOCATION")
    sb.Append(CQuote)
    sb.Append(CComma)
    sb.Append(CQuote)
    sb.Append("NAME")
    sb.Append(CQuote)
    sb.Append(CComma)
    sb.Append(CQuote)
    sb.Append("DELQ?")
    sb.Append(CQuote)
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildFile(ByVal WrkType As String, ByVal WrkLoc As String, ByVal WrkLocNo As String,
  ByVal WrkList As Integer, ByVal WrkMap As String, ByVal WrkName As String, ByVal WrkDelq As Boolean) As String
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim WrkStr As String
    With myTXINVQ
      sb = New StringBuilder
      sb.Append(CQuote)
      sb.Append(WrkType)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Format(WrkList, "000000"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkMap)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkLocNo)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkLoc)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkName)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      If WrkDelq Then
        sb.Append("Y")
      Else
        sb.Append("N")
      End If
      sb.Append(CQuote)
      WrkStr = sb.ToString
      sb = Nothing
      Return WrkStr
    End With
  End Function
  Private Function BuildFileView(ByVal WrkType As String, ByVal WrkLoc As String, ByVal WrkLocNo As String,
  ByVal WrkList As Integer, ByVal WrkMap As String, ByVal WrkName As String, ByVal WrkSname As String) As String
    Const CComma As String = ","
    Const CQuote As String = Chr(34)
    Dim sb As StringBuilder
    Dim WrkStr As String
    With myTXINVQ
      sb = New StringBuilder
      sb.Append(CQuote)
      sb.Append(WrkType)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkMap)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Format(WrkList, "000000"))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkLocNo)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkLoc)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkName)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(WrkSname)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(CQuote)
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
