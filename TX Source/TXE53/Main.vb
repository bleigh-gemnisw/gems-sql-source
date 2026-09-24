Module Main
	'To automate, use /auto in place of userid
 Public MyFrmTXE53 As FrmTXE53
 Public MyFrmTXE53B As FrmTXE53B
 Public MyFrmSelTypes As FrmSelTypes
 Public MyAppSettings As AppSettings
 Public MyAutomate As Boolean
 Public MyTypes As String
 Public MyFormat As String

Sub Main()
 StartUp()
 Select Case UCase(MyUserID)
 Case "/AUTO"
  MyAutomate = True
 Case Else
  GetSecurity() '#sec
 End Select
 GetAppSettings()

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

 MyFrmTXE53 = New FrmTXE53
 Application.Run(MyFrmTXE53)
 Exit Sub

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






