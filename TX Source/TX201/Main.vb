Module Main
  Public MyFrmMargins As FrmMargins
  Public MyFrmTX201 As FrmTX201
  Public MyFrmTX201B As FrmTX201B
  Public MyCrViewer As FrmCrViewer
  Public MyReportLandscape As Boolean
  Public MyReportTopMargin As Integer
  Public MyReportLeftMargin As Integer
  Public MyAppSettings As AppSettings
  Public MyProRateRound As Boolean
  Sub main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    MyProRateRound = GetGNET("CCRND")

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX201 = New FrmTX201
    Application.Run(MyFrmTX201)
  End Sub
  Public Function GetTXTypeDesc(ByVal Code As String) As String
    Dim mytxtype As TXTYPE.MyData

    mytxtype = New TXTYPE.MyData(myDBConnect)
    If IsNothing(Code) Then
      Return ""
    End If

    GetTXTypeDesc = ""
    mytxtype.GetOneRecordP(Code)
    If Not mytxtype.RecordNotFound Then
      GetTXTypeDesc = Trim(mytxtype._TYDESC)
    Else
      GetTXTypeDesc = "*** Unknown ***"
    End If
    Return GetTXTypeDesc

  End Function
  Public Function GetTXTypeFamily(ByVal Code As String) As String
    Dim mytxtype As TXTYPE.MyData

    mytxtype = New TXTYPE.MyData(myDBConnect)
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
  Public Function GetGNET(ByVal Code As String) As Boolean
    Dim myGNET As GNET.MyData

    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    If IsNothing(Code) Or Code = "" Then
      Return False
    End If

    myGNET.GetOneRecordP(Code)
    If Not myGNET.RecordNotFound Then
      If myGNET._VALUE = "Y" Then
        GetGNET = True
      Else
        GetGNET = False
      End If
    Else
      GetGNET = False
    End If
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNET
  End Function
  Public Sub GetReportMargins()
    MyReportTopMargin = MyAppSettings.PrinterTopMargin
    MyReportLeftMargin = MyAppSettings.PrinterLeftMargin
    If MyReportTopMargin = 0 Then MyReportTopMargin = 250
    If MyReportLeftMargin = 0 Then MyReportLeftMargin = 500
  End Sub
  Public Sub SetReportMargins()
    With MyAppSettings
      .PrinterLeftMargin = MyReportTopMargin
      .PrinterLeftMargin = MyReportLeftMargin
      SaveAppSettings()
    End With
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






