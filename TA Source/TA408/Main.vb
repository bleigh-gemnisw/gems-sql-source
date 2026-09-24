Module Main
    Public MyFrmTA408 As FrmTA408
    Public MyFrmTA408B As FrmTA408B
    Public MyFrmListCodes As FrmListCodes
    Public MyCrViewer As FrmCrViewer
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

    MyFrmTA408 = New FrmTA408
    Application.Run(MyFrmTA408)
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
Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
     Dim myTXCode As TXCode.myData

     myTXCode = New TXCode.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = 0 Then
       Return ""
     End If

     myTXCode.GetOneRecordP(Code, Type)
     If Not myTXCode.RecordNotFound Then
       GetTXCodeDesc = Trim(myTXCode._TCDESC)
     Else
       GetTXCodeDesc = "*** Unknown ***"
     End If
     Return GetTXCodeDesc

  End Function
End Module






