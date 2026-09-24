Module Main
	'To automate, use /auto in place of userid
  'To automate secondary, use /auto2 in place of userid
  'To FTP Only, use /ftp in place of userid
  'To FTP secondary Only, use /ftp2 in place of userid
  Public MyFrmTX830 As FrmTX830
	Public MyFrmTX830B As FrmTX830B
	Public MyFrmSelTypes As FrmSelTypes
	Public MyFrmSelSts As FrmSelSts
	Public MyCRViewer As FrmCrViewer
	Public MyPrtLayout As FrmPrtLayout
  'Public MyFrmWeb As FrmWeb
  Public MyTypes As String
  Public MyNonPublic As String
  Public MyStsBlocked As String
  Public MyStsLiened As String
  Public MyStsOmit As String
  Public MyStsNonCodes As String
  Public MyReportLandscape As Boolean
  Public MyAutomate As Boolean
  Public MyAutomate2 As Boolean
  Public MyFTPOnly As Boolean
  Public MyFTP2Only As Boolean
  Public MyAppSettings As AppSettings
  Public MyAppSettings2 As AppSettings
  Public MyWebNP As Boolean
Sub Main()
  StartUp()
  Select Case UCase(MyUserID)
  Case "/AUTO"
    MyAutomate = True
  Case "/AUTO2"
    MyAutomate2 = True
  Case "/FTP"
    MyFTPOnly = True
  Case "/FTP2"
    MyFTP2Only = True
  Case Else
    GetSecurity() '#sec
  End Select
  MyWebNP = GetGNET("WEBNP")
  GetAppSettings()
  GetAppSettings2()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTX830 = New FrmTX830
	Application.Run(MyFrmTX830)
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
  Public Sub GetAppSettings2()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & "-2.xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings2 = New AppSettings
      MyAppSettings2 = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings2 = New AppSettings
    End If
  End Sub
Public Sub SaveAppSettings2()
  Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
  Dim sw As IO.StreamWriter
  Dim WrkProgName As String
  Dim WrkXMLPath As String

  WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
  WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & "-2.xml"
  sw = New IO.StreamWriter(WrkXMLPath)
  xs.Serialize(sw, MyAppSettings2)
  sw.Close()
End Sub
  Public Function GetTXTypeFamily(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.RecordNotFound Then
       GetTXTypeFamily = Trim(myTXTYPE._TXFAM)
     Else
       GetTXTypeFamily = ""
     End If
     Return GetTXTypeFamily

  End Function
  Public Function GetGNET(ByVal Code As String) As Boolean
     Dim myGNET As GNET.myData

     myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
     If IsNothing(Code) Or Code = "" Then
       Return False
     End If

     myGNET.GetOneRecordP(Code)
     If Not myGNET.RecordNotFound Then
       If myGNET._VALUE = "Y" Then
         GetGNET = True
       End If
     Else
       GetGNET = False
     End If
     myGNET.CloseFile()
     myGNET = Nothing
     Return GetGNET

  End Function
End Module






