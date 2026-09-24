Module Main
    Public MyFrmMargins As FrmMargins
    Public MyFrmTX210 As FrmTX210
    Public MyFrmTX210B As FrmTX210B
    Public MyFrmListTypes As FrmListTypes
    Public MyCrViewer As FrmCrViewer
    Public MyReportLandscape As Boolean
    Public MyReportTopMargin As Integer
    Public MyReportLeftMargin As Integer
    Public MyAppSettings As AppSettings
   Sub main()
    StartUp()
    GetSecurity()
    getappsettings()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX210 = New FrmTX210
    Application.Run(MyFrmTX210)
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
       GetTXTypeDesc = Trim(myTXTYPE._TYDESC)
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
	Public Function GetTXTypeFamily(ByVal Code As String) As String
		 Dim myTXTYPE As TXTYPE.myData

		 myTXTYPE = New TXTYPE.mydata(MyDBConnect)
		 If IsNothing(Code) Then
			 Return ""
		 End If

		 GetTXTypeFamily = ""
		 myTXTYPE.GetOneRecordP(Code)
		 If Not myTXTYPE.IsEOF Then
			 GetTXTypeFamily = myTXTYPE._TXFAM
		 Else
			 GetTXTypeFamily = ""
		 End If
		 Return GetTXTypeFamily

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
End Module






