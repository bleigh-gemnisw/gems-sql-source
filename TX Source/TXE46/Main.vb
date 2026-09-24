'TXINV: Update LOC: LOCNO:
Module Main
  Public MyFrmTXE46 As FrmTXE46
  Public MyFrmTXE46B As FrmTXE46B
  Public MyFrmListTypes As FrmListTypes
  Public MyCrViewer As FrmCrViewer
  Public MyBlocking As Boolean
  Public MyType As String
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings

  Sub Main()
    StartUp()
    GetSecurity()  '#sec
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXE46 = New FrmTXE46
    Application.Run(MyFrmTXE46)
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
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim mytxtype As TXTYPE.MyData

    mytxtype = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXTypeFamily = ""
    mytxtype.GetOneRecordP(Code)
    If Not mytxtype.RecordNotFound Then
      GetTXTypeFamily = Trim(mytxtype._TXFAM)
    Else
      GetTXTypeFamily = ""
    End If
    Return GetTXTypeFamily

  End Function
End Module






