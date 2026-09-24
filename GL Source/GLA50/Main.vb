Module Main
  Public MyFrmGLA50 As FrmGLA50
  Public MyFrmGLA50B As FrmGLA50B
  Public MyCrViewer As FrmCrViewer
  Public MyBlocking As Boolean
  Public MyReportLandScape As Boolean
  Public MyBatchTotal As Decimal
  Public MyAppSettings As AppSettings

  Sub Main()
    StartUp()
    GetSecurity()  '#sec
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGLA50 = New FrmGLA50
    Application.Run(MyFrmGLA50)
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
Public Function GetBatchTypeDesc(ByVal BatchType As String) As String

   GetBatchTypeDesc = String.Empty
   Select Case BatchType
   Case "B"
     GetBatchTypeDesc = "Lockbox"
   Case "E"
     GetBatchTypeDesc = "Escrow"
   Case "K"
     GetBatchTypeDesc = "Bank"
   Case "M"
     GetBatchTypeDesc = "Misc"
   Case "P"
     GetBatchTypeDesc = "PC"
   Case "W"
     GetBatchTypeDesc = "Web"
   End Select

   Return GetBatchTypeDesc
End Function
End Module
