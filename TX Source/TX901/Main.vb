Module Main
    Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
    Public MyFrmTX901 As FrmTX901
    Public MyFrmTX901_BCH As FrmTX901_BCH
    Public MyFrmTX901B As FrmTX901B
    Public MyFrmTX901C As FrmTX901C
    Public MyFrmTX901D As FrmTX901D
    Public MyFrmSelInv As FrmSelInv
    Public MyFrmListSResn As FrmListSResn
    Public MyFrmSelTypes As FrmSelTypes
    Public MyFrmSelYear As FrmSelYear
    Public MyBatch As String
    Public MySelTypes As String
    Public MySelYear As Integer
    Public MyBlocking As Boolean
    Public MyQrySelect As String
    Public MyGridMax As Integer
    Public MyReportLandscape As Boolean
    Public MyAppSettings As AppSettings
   Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    MyGridMax = 100

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX901 = New FrmTX901
    Application.Run(MyFrmTX901)
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
Public Function GetTXSResnDesc(ByVal Code As String) As String
     Dim myTXSRESN As TXSRESN.myData

     myTXSRESN = New TXSRESN.mydata(MyDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    myTXSRESN.GetOneRecordP(Code)
     If Not myTXSRESN.RecordNotFound Then
       GetTXSResnDesc = Trim(myTXSRESN._SRDESC)
     Else
       GetTXSResnDesc = "*** Unknown ***"
     End If
     Return GetTXSResnDesc

  End Function
End Module






