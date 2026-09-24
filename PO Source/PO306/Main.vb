Imports System.Text
Module Main
  Public MyFrmPO306 As FrmPO306
  Public MyFrmPO306B As FrmPO306B
  Public MyFrmPO306C As FrmPO306C
  Public MyCrViewer As FrmCrViewer
  Public MyFrmListLoc As FrmListLoc
  Public MyFrmSettings As FrmSettings
  Public MyReportLandscape As Boolean
  Public MySelLoc As String
  Public MyCustomDir As String
  Public MyAppSettings As AppSettings
  Public MyPrinter As String
  Public MyPrinter2 As String
  Public MyPrinter3 As String
  Public MyDrawers As Boolean
  Public MyInquiryMode As Boolean
  Sub Main()
    Dim TestCmd() As String
    StartUp()

    MyInquiryMode = False
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If UCase(TestCmd(2)) = "INQUIRY" Then
        MyInquiryMode = True
      End If
    End If

    GetSecurity("", False)
    If InStr(s_rights, "FI") <= 0 Or Not MyInquiryMode Then
      GetSecurity()
    End If
    If MyInquiryMode Then
      s_full = False
      s_add = False
      s_edit = False
      s_del = False
    End If
    MyCustomDir = GetGNETValue("RPTSD")
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmPO306 = New FrmPO306
    Application.Run(MyFrmPO306)

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
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String
    Dim WrkFileExists As Boolean

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    WrkFileExists = MyUtils.CheckFileExists(WrkXMLPath)
    If Not WrkFileExists Then
      'Need double slashes for network path 
      WrkXMLPath = Replace(WrkXMLPath, "\", "\\")
      'Remove extra slashes if network path 
      WrkXMLPath = Replace(WrkXMLPath, "\\\\", "\\")
    End If

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
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer, ByVal Obj As Integer, _
 ByVal Func As Integer, ByVal Subfn As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

 sb.Append(Format(Fund, "000"))
 sb.Append("-")
 sb.Append(Format(SFund, "000"))
 sb.Append("-")
 sb.Append(Format(Dept, "0000"))
 sb.Append("-")
 sb.Append(Format(Obj, "000"))
 sb.Append("-")
 sb.Append(Format(Func, "0000"))
 sb.Append("-")
 sb.Append(Format(Subfn, "0000"))
 Return sb.ToString
End Function
End Module
