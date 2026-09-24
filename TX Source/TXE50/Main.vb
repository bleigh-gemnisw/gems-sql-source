
Module Main
  Public MyFrmTXE50 As FrmTXE50
  Public MyFrmTXE50B As FrmTXE50B
  Public MyFrmSelTypes As FrmSelTypes
  Public MyFrmSelStatus As FrmSelStatus
  Public MyCRViewer As FrmCrViewer
  Public MyPrtLayout As FrmPrtLayout
  Public MyTypes As String
  Public MySts As String
  Public MyReportLandscape As Boolean
  Public CLenOrig As Integer = 864
  Public CLenExtend As Integer = 917
  Public MyAppSettings As AppSettings

Sub Main()
  StartUp()
  GetSecurity() '#sec
  GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTXE50 = New FrmTXE50
  Application.Run(MyFrmTXE50)
  Exit Sub

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






