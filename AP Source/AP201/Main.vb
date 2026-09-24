Imports System.Text
Module Main
    Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
    Public MyFrmDltBch As FrmDltBch
    Public MyFrmAP201 As FrmAP201
    Public MyFrmAP201B As FrmAP201B
    Public MyFrmAP201B_New As FrmAP201B_New
    Public MyFrmAP201D As FrmAP201D
    Public MyFrmAP201E As FrmAP201E
    Public MyFrmListGLAcct As FrmListGLAcct
    Public MyFrmListVendor As FrmListVendor
    Public DataPath As String
    Public MyBatch As String
    Public MyPostDate As Date
    Public MyFundSec As Boolean
    Public MyReportLandscape As Boolean
    Public MyAppSettings As AppSettings

   Sub Main()
    StartUp()
    DataPath = System.AppDomain.CurrentDomain.BaseDirectory()
    GetSecurity()
    GetAppSettings()
    MyFundSec = False
    If GetGNET("FNDSC") = "Y" Then
      MyFundSec = True
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmAP201 = New FrmAP201
  Application.Run(MyFrmAP201)
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
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer,
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer, Optional ByVal Sep As String = "-") As String
    Dim sb As StringBuilder = New StringBuilder

    If Fund > 0 Then
      sb.Append(Format(Fund, "000"))
      sb.Append(Sep)
      sb.Append(Format(SFund, "000"))
      sb.Append(Sep)
      sb.Append(Format(Dept, "0000"))
      sb.Append(Sep)
      sb.Append(Format(Obj, "000"))
      sb.Append(Sep)
      sb.Append(Format(Func, "0000"))
      sb.Append(Sep)
      sb.Append(Format(SFunc, "0000"))
    Else
      sb.Append(String.Empty)
    End If
    Return sb.ToString
  End Function
  Public Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
    Dim sb As StringBuilder = New StringBuilder
    Dim WrkLen As Integer
    Dim WrkStr As Integer

    Select Case Len(In_Acct)
      Case 19
        WrkLen = 1
      Case 20
        WrkLen = 2
      Case 21
        WrkLen = 3
    End Select
    Out_Fund = Mid(In_Acct, 1, WrkLen)
    WrkStr = 1 + WrkLen
    Out_SFund = Mid(In_Acct, WrkStr, 3)
    WrkStr = WrkStr + 3
    Out_Dept = Mid(In_Acct, WrkStr, 4)
    WrkStr = WrkStr + 4
    Out_Obj = Mid(In_Acct, WrkStr, 3)
    WrkStr = WrkStr + 3
    Out_Func = Mid(In_Acct, WrkStr, 4)
    WrkStr = WrkStr + 4
    Out_Subfn = Mid(In_Acct, WrkStr, 4)
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

End Module
