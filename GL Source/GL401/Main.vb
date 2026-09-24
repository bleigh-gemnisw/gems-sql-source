Imports System.Text
Module Main
  Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
  Public MyFrmDltBch As FrmDltBch
  Public MyFrmGL401 As FrmGL401
  Public MyFrmGL401B As FrmGL401B
  Public MyFrmGL401B_Import As FrmGL401B_Import
  Public MyFrmGL401B_New As FrmGL401B_New
  Public MyFrmGL401C As FrmGL401C
  Public MyFrmGL401D As FrmGL401D
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmPrinters As FrmPrinters
  Public MyPrtLayout As FrmPrtLayout
  Public DataPath As String
  Public MyBatch As String
  Public MyFundSec As Boolean
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings
  Public cMbrName As String = "GLEBCH"

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

    MyFrmGL401 = New FrmGL401
    Application.Run(MyFrmGL401)
  End Sub
  Private Function GetGNET(ByVal Key As String) As String
    Dim myGNET As GNET.MyData

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
    Dim myFNDSEC As FNDSEC.MyData

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
  Public Function GetGLACCTDesc(ByVal PFund As Integer, ByVal PSubFund As Integer,
  ByVal PDept As Integer, ByVal PObject As Integer, ByVal PFunction As Integer,
  ByVal PSubFunc As Integer) As String
    Dim myGLACCT As GLACCT.MyData

    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    If PFund = 0 Then
      Return ""
    End If

    myGLACCT.GetOneRecordP(PFund, PSubFund, PDept, PObject, PFunction, PSubFunc)
    If Not myGLACCT.RecordNotFound Then
      GetGLACCTDesc = Trim(myGLACCT._GLDSC)
    Else
      GetGLACCTDesc = "*** Unknown ***"
    End If
    Return GetGLACCTDesc

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
