Module Main
  'To automate, use /auto in place of userid
  Public MyFrmTX831 As FrmTX831
  Public MyFrmTX831B As FrmTX831B
  Public MyAppSettings As AppSettings
  Public MyAppSettings2 As AppSettings2
  Public MyAutomate As Boolean
  Public MyTypes As String
  Public MyLastDate As Integer

  Sub Main()
    StartUp()
    Select Case UCase(MyUserID)
      Case "/AUTO"
        MyAutomate = True
      Case Else
        GetSecurity() '#sec
    End Select
    GetAppSettings()
    GetAppSettings2()

#If Not DEBUG Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX831 = New FrmTX831
    Application.Run(MyFrmTX831)
    Exit Sub

  End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\TX830.xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Public Sub GetAppSettings2()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings2))
    Dim sr As IO.StreamReader
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings2 = New AppSettings2
      MyAppSettings2 = CType(xs.Deserialize(sr), AppSettings2)
      sr.Close()
    Else
      MyAppSettings2 = New AppSettings2
    End If
  End Sub
  Public Sub SaveAppSettings2()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings2))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings2)
    sw.Close()
  End Sub
End Module






