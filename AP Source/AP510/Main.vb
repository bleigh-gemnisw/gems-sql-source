
Module Main
  Public MyFrmAP510 As FrmAP510
	Public MyFrmAP510B As FrmAP510B
	Public MyFrmListApebnk As FrmListApebnk
	Public MyCRViewer As FrmCrViewer
	Public MyPrtLayout As FrmPrtLayout
  Public MyPRPrefix As String
  Public MyAP As String
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings

Sub Main()
  StartUp()
  GetSecurity() '#sec
  GetAppSettings()

  MyPRPrefix = "B"
  If myTOWN._TOWNBR = 37 Then
    MyPRPrefix = "D"
  End If

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

 MyFrmAP510 = New FrmAP510
 Application.Run(MyFrmAP510)
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
