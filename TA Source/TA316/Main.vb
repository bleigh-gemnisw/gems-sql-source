Module Main
    Public MyFrmTA316 As FrmTA316
    Public MyFrmTA316B As FrmTA316B
    Public MyFrmListBusty As FrmListBusty
    Public MyCrViewer As FrmCrViewer
    Public MyTypes As String
    Public MyReportLandscape As Boolean
    Public MyAppSettings As AppSettings
   Sub main()
    StartUp()
    GetSecurity()
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA316 = New FrmTA316
    Application.Run(MyFrmTA316)
   End Sub
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
Public Function GetTXBustyDesc(ByVal Code As String) As String
    Dim myTXBUSTY As TXBUSTY.myData

    myTXBUSTY = New TXBUSTY.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXBUSTY.GetOneRecordP(Code)
    If Not myTXBUSTY.RecordNotFound Then
      GetTXBustyDesc = Trim(myTXBUSTY._BTDESC)
    Else
      GetTXBustyDesc = "*** Unknown ***"
    End If
    Return GetTXBustyDesc

  End Function
End Module






