
Module Main
  Public MyFrmTA509 As FrmTA509
	Public MyFrmTA509B As FrmTA509B
	Public MyFrmListCodes As FrmListCodes
  'MK 7/21/25 Begin
  Public MyFrmListSource As FrmListSource
  'MK 7/21/25 End
  Public MyFrmSettings As FrmSettings
  Public MyCrViewer As FrmCrViewer
	Public MyBookPct As Decimal
	Public MyMinValue As Integer
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

    MyFrmTA509 = New FrmTA509
    Application.Run(MyFrmTA509)

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
 Public Function GetTXSupCd(ByVal Code As String) As String()
    Dim Wrkstr(1) As String
    Dim myTXSUPCD As TXSUPCD.myData

    myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Wrkstr(0) = ""
      Wrkstr(1) = ""
      Return Wrkstr
    End If

    myTXSUPCD.GetOneRecordP(Code)
    If Not myTXSUPCD.RecordNotFound Then
      Wrkstr(0) = Format(myTXSUPCD._SPCT, ".###")
      Wrkstr(1) = Trim(myTXSUPCD._SMON)
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
End Module






