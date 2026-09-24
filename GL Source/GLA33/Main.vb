Module Main
    Public MyFrmGLA33 As FrmGLA33
    Public MyFrmGLA33B As FrmGLA33B
    Public MyCrViewer As FrmCrViewer
    Public MyAS400 As Boolean
    Public DataPath As String
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

    MyFrmGLA33 = New FrmGLA33
    Application.Run(MyFrmGLA33)
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
End Module
