
Module Main
  Public MyFrmTA219 As FrmTA219
  Public MyFrmTA219B As FrmTA219B
  Public MyFrmListDist As FrmListDist
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
  Public MyReportLandscape As Boolean
  Public MyAppSettings As AppSettings
Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA219 = New FrmTA219
    Application.Run(MyFrmTA219)

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

Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
     Dim myTXCODE As TXCode.myData

     myTXCODE = New TXCode.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = 0 Then
       Return ""
     End If

     myTXCODE.GetOneRecordP(Code, Type)
     If Not myTXCODE.RecordNotFound Then
       GetTXCodeDesc = Trim(myTXCODE._TCDESC)
     Else
       GetTXCodeDesc = "*** Unknown ***"
     End If
     Return GetTXCodeDesc

  End Function
Public Function GetTXCDSFCode(ByVal Rpt As String) As Integer
     Dim myTXCDSF As TXCDSF.myData

     myTXCDSF = New TXCDSF.mydata(MyDBConnect)
     If IsNothing(Rpt) Or Rpt = String.Empty Then
       Return 0
     End If

     myTXCDSF.GetOneRecordP(Rpt)
     If Not myTXCDSF.RecordNotFound Then
       GetTXCDSFCode = myTXCDSF._TCCODE
     Else
       GetTXCDSFCode = 0
     End If
     Return GetTXCDSFCode

  End Function
End Module





