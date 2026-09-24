
Module Main
  Public MyFrmTX310 As FrmTX310
  Public MyFrmTX310B As FrmTX310B
  Public MyCrViewer As FrmCrViewer
  Public MyReportLandscape As Boolean
  Public My2NDNO As Boolean
  Public MyAppSettings As AppSettings
Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    My2NDNO = False
    If GetGNETValue("2NDNO") = "Y" Then
      My2NDNO = True
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX310 = New FrmTX310
    Application.Run(MyFrmTX310)

   End Sub
  Public Function GetGNETValue(ByVal Code As String) As String
     Dim myGNET As GNET.myData

     myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
     If IsNothing(Code) Or Code = "" Then
       Return String.Empty
     End If

     GetGNETValue = String.Empty
     myGNET.GetOneRecordP(Code)
     If Not myGNET.RecordNotFound Then
       GetGNETValue = myGNET._VALUE
     End If
     Return GetGNETValue

  End Function
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






