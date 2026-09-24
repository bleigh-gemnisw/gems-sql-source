Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myCASHINT As CASHINT.MyData
  Dim myTXDLQ As TXDLQ.MyData
  Dim myDBUtils As DBUtils.Utils

  Dim WrkIntDate As Date
  Dim WrkFileMode As Boolean
  Dim WrkFilePath As String
  Dim WrkRemoteName As String
  Dim WrkHost As String
  Dim WrkUser As String
  Dim WrkPassword As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myCASHINT = New CASHINT.MyData(myDBConnect)
    myTXDLQ = New TXDLQ.MyData(myDBConnect)
    myDBUtils = New DBUtils.Utils(myDBConnect)

    WrkFilePath = MyUtils.GetDataPath & "txdlq.csv"
    WrkRemoteName = "txdlq.csv"
    If MyAutomate Or MyFTP Then
      WrkFileMode = MyAppSettings.FileMode
      WrkHost = MyAppSettings.Host
      WrkUser = MyAppSettings.User
      WrkPassword = GetPassword(MyAppSettings.Password)
    Else
      With MyFrmTXE48B
        WrkFileMode = .RbFile.Checked
        WrkHost = .TxtHost.Text
        WrkUser = .TxtUser.Text
        WrkPassword = .TxtPassword.Text
        MyFTP = .RbFTP.Checked
      End With
    End If

    WrkIntDate = Date.Today
    If WrkFileMode Then
      myDBUtils.DeleteAllRecs("TXDLQ")
    End If

    GetDetail()
    If MyFTP Then
      PutFile(WrkHost, WrkUser, WrkPassword, WrkFilePath, WrkRemoteName)
    End If

  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkStartYear As Integer
    Dim WrkTax As Decimal
    Dim WrkDue As Decimal
    Dim WrkDelq As Boolean
    Dim WrkGracePeriod As Boolean
    Dim SaveList As Integer
    Dim WrkComma As String
    Dim WrkQuote As String
    Dim SaveType As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkComma = ","
    WrkQuote = Chr(34)
    Counter = 0

    WrkStartYear = Today.Year - 3
    WrkQry = "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "TYPE='R'" & WrkAnd & "YEAR >= " & WrkStartYear &
  WrkOr & "icode<>'I'" & WrkAnd & "icode<>'D'" & WrkAnd & "TYPE='P'" & WrkAnd & "YEAR >= " & WrkStartYear
    WrkSort = "LIST#, TYPE, YEAR desc"
    myTXINVQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    If MyAutomate Then
      myFrmProgress.Text = "TXE48 - Creating file..."
    End If
    If MyFTP Then
      myFrmProgress.Text = "TXE48 - Creating file..."
      sw = New StreamWriter(WrkFilePath)
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    SaveList = 0
    SaveType = String.Empty
    WrkDelq = False

ReadNext:
    myTXINVQ.ReadQry()
    If Not myTXINVQ.IsEOF Then
      With myTXINVQ
        Counter = Counter + 1
        If SaveList > 0 Then
          If SaveList <> ._LISTNo Then
            If WrkFileMode Then
              WriteFile(SaveList, SaveType, WrkDelq)
            Else
              sw.WriteLine(BuildCSV(SaveList, SaveType, WrkDelq))
            End If
          End If
        End If
        SaveList = ._LISTNo
        SaveType = ._TYPE
        WrkDue = 0
        If ._BALD > 0 And Not WrkDelq Then
          CalcInterest(._LISTNo, ._TYPE, ._YEAR, 0, 0, 0, 0, 0, WrkTax, WrkDue, WrkGracePeriod)
        End If
        If WrkDue > 0 And Not WrkGracePeriod Then
          WrkDelq = True
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

    If WrkFileMode Then
      WriteFile(SaveList, SaveType, WrkDelq)
    Else
      sw.WriteLine(BuildCSV(SaveList, SaveType, WrkDelq))
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myTXINVQ.CloseFile()

    If MyAutomate Or MyFTP Then
      WriteLogAuto()
    End If

  End Sub
  Private Sub WriteFile(ByVal WrkList As Integer, ByVal WrkType As String, ByVal WrkDelq As Boolean)

    With myTXDLQ
      .GetOneRecordP(WrkList, WrkType)
      ._LISTNo = WrkList
      ._TYPE = WrkType
      If WrkDelq Then
        ._DELQ = "Y"
      Else
        ._DELQ = "N"
      End If
      .AddOneRecordP()
    End With

  End Sub
  Private Function BuildCSV(ByVal WrkList As Integer, ByVal WrkType As String, ByVal WrkDelq As Boolean) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Const WrkComma = ","
    Const WrkQuote = Chr(34)
    sb = New StringBuilder
    sb.Append(WrkList)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    sb.Append(WrkType)
    sb.Append(WrkQuote)
    sb.Append(WrkComma)
    sb.Append(WrkQuote)
    If WrkDelq Then
      sb.Append("Y")
    Else
      sb.Append("N")
    End If
    sb.Append(WrkQuote)
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
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






