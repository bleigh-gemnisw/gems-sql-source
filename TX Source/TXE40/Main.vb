Module Main
    Public MyFrmTXE40 As FrmTXE40
    Public MyFrmTXE40B As FrmTXE40B
    Public MyFrmSelTypes As FrmSelTypes
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

    MyFrmTXE40 = New FrmTXE40
    Application.Run(MyFrmTXE40)
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
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeFamily = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.IsEOF Then
       GetTXTypeFamily = myTXTYPE._TXFAM
     Else
       GetTXTypeFamily = ""
     End If
     Return GetTXTypeFamily

  End Function
End Module






