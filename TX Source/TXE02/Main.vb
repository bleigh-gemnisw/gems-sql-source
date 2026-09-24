Module Main
  Public MyFrmTXE02 As FrmTXE02
  Public MyFrmTXE02B As FrmTXE02B
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelStatus As FrmSelStatus
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

    MyFrmTXE02 = New FrmTXE02
    Application.Run(MyFrmTXE02)
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
End Module
