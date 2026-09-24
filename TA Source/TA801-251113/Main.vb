Module Main
    Public MyFrmTA801 As FrmTA801
    Public MyFrmTA801B As FrmTA801B
    Public MyFrmListCCReason As FrmListCCReason
    Public MyFrmListTypes As FrmListTypes
    Public MyCrViewer As FrmCrViewer
    Public MyReportLandscape As Boolean
    Public MyAppSettings As AppSettings
  Public MyProRateRound As Boolean
  Sub main()
    StartUp()
    'Check Alternative Program ID (TX701) first
    GetSecurity("TX701", False) 'Collector
    If Not s_sec Then
      GetSecurity()
    End If
    GetAppSettings()
    MyProRateRound = GetGNET("CCRND")

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA801 = New FrmTA801
    Application.Run(MyFrmTA801)
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

  Public Function GetTXCResnDesc(ByVal Code As String) As String
     Dim myTXCRESN As TXCRESN.myData

     myTXCRESN = New TXCRESN.mydata(MyDBConnect)
     If IsNothing(Code) Then
       Return ""
     End If

     GetTXCResnDesc = ""
     myTXCRESN.GetOneRecordP(Code)
     If Not myTXCRESN.RecordNotFound Then
       GetTXCResnDesc = Trim(myTXCRESN._CRDESC)
     Else
       GetTXCResnDesc = "*** Unknown ***"
     End If
     Return GetTXCResnDesc

  End Function
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
			Public Function GetTXMVPCT(ByVal Type As String, ByVal Code As String) As String()
		 Dim Wrkstr(1) As String
		 Dim myTXMVPCT As TXMVPCT.myData

		 myTXMVPCT = New TXMVPCT.mydata(MyDBConnect)
		 If IsNothing(Code) Then
			 Return Wrkstr
		 End If

		 myTXMVPCT.GetOneRecordP(Type, Code)
		 If Not myTXMVPCT.RecordNotFound Then
			 With myTXMVPCT
				 Wrkstr(0) = Format(._PCT, ".###")
				 Wrkstr(1) = ._MONTH
			 End With
		 Else
			 Wrkstr(1) = "*** Unknown ***"
		 End If
		 Return Wrkstr

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
End Module






