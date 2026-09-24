'TXINV: Update ADD1: ADD2: CITY: NAME: STATE: ZIP4: ZIP5:
Module Main
 Public MyFrmTXE49 As FrmTXE49
 Public MyFrmTXE49B As FrmTXE49B
 Public MyFrmListTypes As FrmListTypes
 Public MyCrViewer As FrmCrViewer
 Public MyBlocking As Boolean
 Public MyType As String
 Public MyReportLandscape As Boolean
 Public MyAppSettings As AppSettings
 Public My2NDNO As Boolean

 Sub Main()
  StartUp()
  GetSecurity()  '#sec
  GetAppSettings()
  If GetGNETValue("2NDNO") = "Y" Then
    My2NDNO = True
  End If

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTXE49 = New FrmTXE49
  Application.Run(MyFrmTXE49)
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
  Public Function GetTXTypeFamily(ByVal Code As String) As String
     Dim mytxtype As TXTYPE.myData

     mytxtype = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXTypeFamily = ""
     mytxtype.GetOneRecordP(Code)
     If Not mytxtype.RecordNotFound Then
       GetTXTypeFamily = Trim(mytxtype._TXFAM)
     Else
       GetTXTypeFamily = ""
     End If
     Return GetTXTypeFamily

  End Function
End Module






