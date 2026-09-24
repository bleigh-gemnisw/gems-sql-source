'TXINV: Update MVFLAG:
Module Main
  Public MyFrmTX407 As FrmTX407
  Public MyFrmTX407B As FrmTX407B
  Public MyFrmTX407C As FrmTX407C
  Public MyCrViewer As FrmCrViewer
  Public MyCrViewer2 As FrmCrViewer2
  Public MyFrmListSuspReason As New FrmListSuspReason
  Public MyBlocking As Boolean
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings
  Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()

    MyServer = UCase(myDBConnect.ServerName)

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX407 = New FrmTX407
    Application.Run(MyFrmTX407)
  End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
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
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
  End Sub
End Module






