
Module Main
  Public MyFrmTXE06 As FrmTXE06
  Public MyFrmTXE06B As FrmTXE06B
  Public MyFrmListBanks As FrmListBanks
  Public MyFrmSelTypes As FrmSelTypes
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
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

    MyFrmTXE06 = New FrmTXE06
    Application.Run(MyFrmTXE06)

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
     Dim MyTXTYPE As TXTYPE.myData

     MyTXTYPE = New TXTYPE.mydata(MyDBConnect)
     If IsNothing(Code) Or Code = "" Then
       Return ""
     End If

     MyTXTYPE.GetOneRecordP(Code)
     If MyTXTYPE.RecordNotFound Then
       GetTXTypeDesc = Trim(MyTXTYPE._TYDESC)
     Else
       GetTXTypeDesc = "*** Unknown ***"
     End If
     Return GetTXTypeDesc

  End Function
 Public Function GetTXTypeFamily(ByVal Code As String) As String
		 Dim MyTXTYPE As TXTYPE.myData

		 MyTXTYPE = New TXTYPE.mydata(MyDBConnect)
		 If IsNothing(Code) Or Code = "" Then
			 Return ""
		 End If

		 MyTXTYPE.GetOneRecordP(Code)
		 If MyTXTYPE.RecordNotFound Then
			 GetTXTypeFamily = Trim(MyTXTYPE._TXFAM)
		 Else
			 GetTXTypeFamily = ""
		 End If
		 Return GetTXTypeFamily

	End Function

End Module











