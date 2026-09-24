
Module Main
  Public MyFrmTAC01 As FrmTAC01
  Public MyFrmTAC01B As FrmTAC01B
	Public MyCrViewer As FrmCrViewer
  Public MyAppSettings As AppSettings
  Public MyPhaseIn As Boolean

  Sub Main()
    StartUp()
    GetSecurity()
    GetAppSettings()
    If GetGNET("PHASE") = "Y" Then MyPhaseIn = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
		MyFrmTAC01 = New FrmTAC01
    Application.Run(MyFrmTAC01)
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
  Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
    Dim myTXCODE As TXCODE.MyData

    myTXCODE = New TXCODE.MyData(myDBConnect)
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
  Public Function StripDash(ByVal Code As String) As Integer
		Dim WrkCode As Integer

		If Mid(Code, 2, 1) = "-" Then
			WrkCode = Mid(Code, 1, 1) & Mid(Code, 3, 1)
		Else
      WrkCode = MyUtils.CnvSng(Code)
		End If
		Return WrkCode
	End Function
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String
    Dim WrkFileExists As Boolean

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & " " & MyUtils.GetComputerName() & ".xml"
    WrkFileExists = MyUtils.CheckFileExists(WrkXMLPath)
    If Not WrkFileExists Then
      'Need double slashes for network path 
      WrkXMLPath = Replace(WrkXMLPath, "\", "\\")
      'Remove extra slashes if network path 
      WrkXMLPath = Replace(WrkXMLPath, "\\\\", "\\")
    End If

    If WrkFileExists Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      Try
        MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      Catch
        MsgBox("Check file or delete it to reset - " & WrkXMLPath, MsgBoxStyle.Information, "Error Reading Settings")
      End Try
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
End Module






