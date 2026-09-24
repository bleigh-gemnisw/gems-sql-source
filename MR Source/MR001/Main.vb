Module Main
  Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
  Public MyFrmMR001 As FrmMR001
  Public MyFrmMR001B As FrmMR001B
  Public MyFrmMR001B_New As FrmMR001B_New
  Public MyFrmMR001C As FrmMR001C
  Public MyFrmMR001D As FrmMR001D
  Public MyFrmListCode As FrmListCode
  Public MyFrmSelCodes As FrmSelCodes
  Public MyReportLandscape As Boolean
  Public MySelCodes As String
  Public MyAppSettings As AppSettings
  Public MyTotalEntry As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    If GetGNET("MRTOT") = "Y" Then
      MyTotalEntry = True
    Else
      MyTotalEntry = False
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmMR001 = New FrmMR001
    Application.Run(MyFrmMR001)
  End Sub
  Private Function GetGNET(ByVal Key As String) As String
    Dim myGNET As GNET.myData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    myGNET.GetOneRecordP(Key)
    With myGNET
      If .RecordNotFound Then Return String.Empty
      Return ._VALUE
    End With

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
