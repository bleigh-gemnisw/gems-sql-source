
Module Main
  Public MyFrmAP313 As FrmAP313
  Public MyFrmAP313B As FrmAP313B
  Public MyFrmListFund As FrmListFund
  Public MyFrmListVendor As FrmListVendor

 Public MyCRViewer As FrmCrViewer
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings

Sub Main()
  StartUp()
  GetSecurity() '#sec
  GetAppSettings()

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

 MyFrmAP313 = New FrmAP313
 Application.Run(MyFrmAP313)
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
