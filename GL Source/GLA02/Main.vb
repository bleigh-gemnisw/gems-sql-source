Imports System.Text
Module Main
    Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
    Public MyCrViewer As FrmCrViewer
    Public MyFrmDltBch As FrmDltBch
    Public MyFrmGLA02 As FrmGLA02
		Public MyFrmGLA02B As FrmGLA02B
    Public MyFrmGLA02B_Import As FrmGLA02B_Import
    Public MyFrmGLA02B_New As FrmGLA02B_New
		Public MyFrmGLA02C As FrmGLA02C
		Public MyFrmGLA02D As FrmGLA02D
		Public MyFrmGLA02E As FrmGLA02E
    Public MyFrmListGLAcct As FrmListGLAcct
    Public MyFrmListFund As FrmListFund
		Public DataPath As String
    Public MyBatch As String
    Public MyFundSec As Boolean
    Public MyReportLandscape As Boolean
    Public MyAppSettings As AppSettings

	 Sub Main()
    StartUp()
    DataPath = System.AppDomain.CurrentDomain.BaseDirectory()
		GetSecurity()
    getappsettings()
    MyFundSec = False
    If GetGNET("FNDSC") = "Y" Then
      MyFundSec = True
    End If

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA02 = New FrmGLA02
  Application.Run(MyFrmGLA02)
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
Public Function GetFNDSEC(ByVal Fund As Integer) As Boolean

 If Not MyFundSec Then Return True
 Dim myFNDSEC As FNDSEC.myData

 myFNDSEC = New FNDSEC.MyData()
 myFNDSEC.MyDBConn = myDBConnect
 With myFNDSEC
   'Check All funds
   .GetOneRecordP(MyUserID, 0)
    If Not .RecordNotFound Then
      myFNDSEC.CloseFile()
      myFNDSEC = Nothing
      Return True
    End If
   .GetOneRecordP(MyUserID, Fund)
    If Not .RecordNotFound Then
      myFNDSEC.CloseFile()
      myFNDSEC = Nothing
      Return True
    End If
 End With

 MsgBox("You don't have authority to Fund " & Fund, MsgBoxStyle.Information, "Permisson Denied")
 myFNDSEC.CloseFile()
 myFNDSEC = Nothing
 Return False
End Function
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

 If Fund > 0 Then
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
  sb.Append(Format(SFunc, "0000"))
 Else
  sb.Append(String.Empty)
 End If
 Return sb.ToString
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
