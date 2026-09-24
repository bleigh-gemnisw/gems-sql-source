'TXINV: Update STCD1: STCD2: STCD3: STCD4: STCD5:
Module Main
  Public myds As DataSet = New DataSet
  Public MyFrmTX313 As FrmTX313
  Public MyFrmTX313B As FrmTX313B
  Public MyFrmListSts As FrmListSts
  Public MyFrmListTypes As FrmListTypes
  Public MyFrmCrViewer As FrmCrViewer
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

    MyFrmTX313 = New FrmTX313
    Application.Run(MyFrmTX313)
   End Sub
  Public Function GetTXStsDesc(ByVal Code As String) As String
     Dim myTXSTS As TXSTS.myData

     myTXSTS = New TXSTS.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXStsDesc = ""
     myTXSTS.GetOneRecordP(Code)
     If Not myTXSTS.RecordNotFound Then
       GetTXStsDesc = Trim(myTXSTS._STDESC)
     Else
       GetTXStsDesc = "*** Unknown ***"
     End If
     Return GetTXStsDesc

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






