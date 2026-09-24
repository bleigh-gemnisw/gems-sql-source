Module Main
  Public MyFrmTX802 As FrmTX802
  Public MyFrmTX802B As FrmTX802B
  Public MyFrmListBanks As FrmListBanks
  Public MyFrmListBser As FrmListBser
  Public MyCrViewer As FrmCrViewer
  Public MyPrtLayout As FrmPrtLayout
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings
  Public MyList7 As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    If GetGNET("LIST7") = "Y" Then MyList7 = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX802 = New FrmTX802
    Application.Run(MyFrmTX802)
  End Sub
  Private Function GetGNET(ByVal Key As String) As String
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    myGNET.GetOneRecordP(Key)
    With myGNET
      If .RecordNotFound Then Return String.Empty
      Return ._VALUE
    End With

  End Function
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Public Sub SaveAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
  End Sub
  Public Function GetTXBanksDesc(ByVal Code As String) As String
    Dim myTXBANKS As TXBANKS.MyData

    myTXBANKS = New TXBANKS.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXBANKS.GetOneRecordP(Code)
    If Not myTXBANKS.RecordNotFound Then
      GetTXBanksDesc = Trim(myTXBANKS._BKNAME)
    Else
      GetTXBanksDesc = "*** Unknown ***"
    End If
    Return GetTXBanksDesc

  End Function
End Module






