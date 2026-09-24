Module Main
    Public MyFrmTA215 As FrmTA215
    Public MyFrmTA215B As FrmTA215B
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

    MyFrmTA215 = New FrmTA215
    Application.Run(MyFrmTA215)
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

  Public Function GetTXXPROPDesc(ByVal Code As String) As String
     Dim myTXXPROP As TXXprop.myData

     myTXXPROP = New TXXprop.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myTXXPROP.GetOneRecordP(Code)
     If Not myTXXPROP.RecordNotFound Then
       GetTXXPROPDesc = Trim(myTXXPROP._TXDESC)
     Else
       GetTXXPROPDesc = "*** Unknown ***"
     End If
     Return GetTXXPROPDesc

  End Function
  End Module






