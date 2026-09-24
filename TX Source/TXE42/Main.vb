Module Main
    Public MyFrmTXE42 As FrmTXE42
    Public MyFrmTXE42B As FrmTXE42B
    Public MyFrmSelTypes As FrmSelTypes
    Public MyFrmListAltID As FrmListAltID
    Public MyCrViewer As FrmCrViewer
    Public MyTypes As String
		Public MyReportLandscape As Boolean
    Public MyCustomDir As String
    Public MyAppSettings As AppSettings
   Sub main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    MyCustomDir = GetGNETValue("RPTSD")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXE42 = New FrmTXE42
    Application.Run(MyFrmTXE42)
   End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
     Dim myTXTYPE As TXTYPE.myData

     myTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeDesc = ""
     myTXTYPE.GetOneRecordP(Code)
     If Not myTXTYPE.IsEOF Then
       GetTXTypeDesc = myTXTYPE._TYDESC
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
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






