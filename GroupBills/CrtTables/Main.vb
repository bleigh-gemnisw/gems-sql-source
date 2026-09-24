Imports System.Data
Imports System.Data.SqlClient
Module Main
  Public MyFrmMain As FrmMain
  Public MyFrmMainB As FrmMainB
  Public MyConn As DBConnect.DBConnection
  Public MyAppSettings As AppSettings
  Public MyTownNo As Integer

Sub Main()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

 MyConn = New DBConnect.DBConnection("bills", "bills")
 MyConn.GetAppSettings()
 MyConn.SetPassword("bills")
 If Not MyConn.IsConnected Then
   MsgBox("Check settings and try again", MsgBoxStyle.Critical, "Connection failed")
   End
 End If

  MyFrmMain = New FrmMain
  Application.Run(MyFrmMain)
End Sub
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(GetProgramName, ".exe", "")
    WrkXMLPath = GetDataPath() & "Settings\" & MyTownNo & ".xml"
    If CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
End Module
