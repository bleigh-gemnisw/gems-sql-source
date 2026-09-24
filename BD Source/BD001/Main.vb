'Permit Type formid (Default = C)
' DEMO=CD, ELECT=CE, FLIQ/HVAC=CH, P&Z=CZ
Module Main
  Public MyFrmBD001 As FrmBD001
  Public MyFrmBD001B As FrmBD001B
  Public MyFrmBD001C As FrmBD001C
  Public MyFrmBD001CD As FrmBD001CD
  Public MyFrmBD001CE As FrmBD001CE
  Public MyFrmBD001CH As FrmBD001CH
  Public MyFrmBD001CZ As FrmBD001CZ
  Public MyFrmBD001App As FrmBD001App
  Public MyFrmBD001D As FrmBD001D
  Public MyFrmListCon As FrmListCon
  Public MyFrmListConLic As FrmListConLic
  Public MyFrmListTypes As FrmListTypes
  Public MyFrmListReal As FrmListReal
  Public MyFrmSettings As FrmSettings
  Public MyFrmWeb As FrmWeb
  Public MyAppSettings As AppSettings
  Public MyPublic As Boolean
  Public MyPayCredit As Boolean

  Sub Main()
    Dim TestCmd() As String

    StartUp()
    GetSecurity()  '#sec
    GetAppSettings()

    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If LCase(Trim(TestCmd(2))) = "public" Then
        MyPublic = True
      End If
    End If

    MyPayCredit = GetGNET("BDCR")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmBD001 = New FrmBD001
    Application.Run(MyFrmBD001)
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






