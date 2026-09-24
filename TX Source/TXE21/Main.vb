Module Main
    Public MyFrmTXE21 As FrmTXE21
    Public MyFrmTXE21B As FrmTXE21B
    Public MyCrViewer As FrmCrViewer
    Public MyFrmListBanks As FrmListBanks
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

    MyFrmTXE21 = New FrmTXE21
    Application.Run(MyFrmTXE21)
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
Public Function GetTXBanksDesc(ByVal Code As String) As String
     Dim myTXBANKS As TXBANKS.myData

     myTXBANKS = New TXBANKS.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     GetTXBanksDesc = ""
     myTXBANKS.GetOneRecordP(Code)
     If Not myTXBANKS.RecordNotFound Then
       GetTXBanksDesc = Trim(myTXBANKS._BKNAME)
     Else
       GetTXBanksDesc = "*** Unknown ***"
     End If
     Return GetTXBanksDesc

  End Function
End Module






