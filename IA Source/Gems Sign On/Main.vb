Module Main
  Public MyDBName As String
  Public myDBConnect As SQLConnect.DBConnection
  Public MyUserID As String
  Public dsTown As DataSet = New DataSet
  Public MyFrmSignon As FrmSignOn
  Public DataPath As String
  Public MyAppSettings As AppSettings
  Public MyDBSettings As AppSettings
  Public MyUtils As Utils.Util

Sub Main()
    MyUtils = New Utils.Util

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    GetAppSettings()
    GetDBSettings()
    DataPath = MyUtils.GetDataPath()

    MyFrmSignon = New FrmSignOn
    Application.Run(MyFrmSignon)

   End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String
    Dim WrkFileExists As Boolean

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    WrkFileExists = MyUtils.CheckFileExists(WrkXMLPath)
    If Not WrkFileExists Then
      'Need double slashes for network path 
      WrkXMLPath = Replace(WrkXMLPath, "\", "\\")
      'Remove extra slashes if network path 
      WrkXMLPath = Replace(WrkXMLPath, "\\\\", "\\")
    End If

    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      Try
        MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      Catch
        MsgBox("Check file or delete it to reset - " & WrkXMLPath, MsgBoxStyle.Information, "Error Reading Settings")
      End Try
      sr.Close()
    Else
      MyAppSettings = New AppSettings
      'CreateAppSettings()
    End If
  End Sub
Public Sub SaveAppSettings()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sw As IO.StreamWriter
  Dim WrkProgName As String
  Dim WrkXMLPath As String

  With MyAppSettings
    .DatabaseName = MyFrmSignon.CboDatabase.Text
  End With

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
  sw = New IO.StreamWriter(WrkXMLPath)
  xs.Serialize(sw, MyAppSettings)
  sw.Close()
End Sub
  Public Sub GetDBSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String
    Dim WrkFileExists As Boolean

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\SQLConnect.xml"
    WrkFileExists = MyUtils.CheckFileExists(WrkXMLPath)
    If Not WrkFileExists Then
      'Need double slashes for network path 
      WrkXMLPath = Replace(WrkXMLPath, "\", "\\")
      'Remove extra slashes if network path 
      WrkXMLPath = Replace(WrkXMLPath, "\\\\", "\\")
    End If

    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyDBSettings = New AppSettings
      Try
        MyDBSettings = CType(xs.Deserialize(sr), AppSettings)
      Catch
        MsgBox("Check file or delete it to reset - " & WrkXMLPath, MsgBoxStyle.Information, "Error Reading Settings")
      End Try
      sr.Close()
    Else
      MyDBSettings = New AppSettings
    End If
  End Sub
Public Sub LaunchEXE(ByVal WrkBtnName As String, ByVal WrkDBName As String, ByVal WrkUserID As String, _
  Optional ByVal WrkParm As String = "")
  Dim WrkProgName As String
  Dim WrkEXE As String
  Dim WrkVal As Integer
  Dim Pos As Integer

  WrkProgName = Replace(WrkBtnName, "btn", "", , , CompareMethod.Text)
  Pos = InStr(WrkProgName, ".exe", CompareMethod.Text)
  If Pos = 0 Then
    WrkProgName = WrkProgName & ".exe"
  End If
  WrkEXE = DataPath & WrkProgName & " " & WrkDBName & " " & _
    WrkUserID & " " & WrkParm

  Try
    WrkVal = Shell(WrkEXE, AppWinStyle.NormalFocus)
    If WrkVal = 0 Then
      MsgBox("Error running program " & WrkEXE & ". Please contact Hotline", MsgBoxStyle.Critical, "Program error")
    End If
  Catch
    MsgBox("Error running program " & WrkEXE & " .Please contact Hotline", MsgBoxStyle.Critical, "Program error")
  End Try
End Sub
End Module
