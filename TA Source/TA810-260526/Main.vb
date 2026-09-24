
Module Main
  Public MyFrmCrViewer As FrmCrViewer
  Public MyFrmTA810 As FrmTA810
  Public MyFrmTA810_NEW As FrmTA810_NEW
  Public MyFrmTA8101R As FrmTA8101R
  Public MyFrmTA8102R As FrmTA8102R
  Public MyFrmTA8103R As FrmTA8103R
  Public MyFrmTA8104R As FrmTA8104R
  Public MyFrmTA8105R As FrmTA8105R
  Public MyFrmListCCHist As FrmListCCHist
  Public MyFrmListCodes As FrmListCodes
  Public MyFrmListCResn As FrmListCResn
  Public MyFrmListExempt As FrmListExempt
  Public MyFrmListExemption As FrmListExemption
  Public MyFrmListMVDC As FrmListMVDC
  Public MyFrmListMvpct As FrmListMvpct
  Public MyFrmListPPRPC As FrmListPPRPC
  Public MyFrmListRealC As FrmListRealC
  Public MyFrmListSUPPC As FrmListSUPPC
  Public MyFrmListSource As FrmListSource
  Public MyFrmPrinters As FrmPrinters
  Public MyGLYear As Integer
	'MK 9/26/25 Begin  
	Public MySuppYear As Integer
	'MK 9/26/25 End  
	Public MyAppSettings As AppSettings
	Public MyGetTXMVPCT As GetTXMVPCT
	Public MyOpenCC As Boolean
	Public MyProrateRound As Boolean
	Public MyBookPct As Decimal
	Public MyMinValue As Integer
	Sub Main()
		StartUp()
		GetSecurity()
		GetAppSettings()
		MyGetTXMVPCT = New GetTXMVPCT
		MyOpenCC = GetGNET("OPNCC")
		MyProrateRound = GetGNET("CCRND")
		MyGLYear = GetControlGLYear()
		'MK 9/26/25 Begin  
		MySuppYear = MyGLYear
		If Today.Month >= 7 Then
			MySuppYear = MyGLYear - 1
		Else
			MySuppYear = MyGLYear
		End If
		'MK 9/26/25 End

#If Not DEBUG Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA810 = New FrmTA810
    Application.Run(MyFrmTA810)
  End Sub
  Public Function GetTXBanksDesc(ByVal Code As String) As String
    Dim myTXBANKS As TXBANKS.myData

    myTXBANKS = New TXBANKS.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXBANKS.GetOneRecordP(Code)
    If Not myTXBANKS.RecordNotFound Then
      GetTXBanksDesc = Trim(myTXBANKS._BKNAME)
    Else
      GetTXBanksDesc = "*** Unknown ***"
    End If
    Return GetTXBanksDesc

  End Function
	Public Function GetTXCodeDesc(ByVal Code As Integer, ByVal Type As String) As String
		Dim myTXCode As TXCode.myData

		myTXCode = New TXCode.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = 0 Then
			Return ""
		End If

		myTXCode.GetOneRecordP(Code, Type)
		If Not myTXCode.RecordNotFound Then
			GetTXCodeDesc = Trim(myTXCode._TCDESC)
		Else
			GetTXCodeDesc = "*** Unknown ***"
		End If
		Return GetTXCodeDesc

	End Function
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
	Public Function GetTXExem(ByVal Code As String) As String()
		Dim Wrkstr(1) As String
		Dim myTXEXEM As TXEXEM.myData

		myTXEXEM = New TXEXEM.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Wrkstr(0) = ""
			Wrkstr(1) = ""
			Return Wrkstr
		End If

		myTXEXEM.GetOneRecordP(Code)
		If Not myTXEXEM.RecordNotFound Then
			Wrkstr(0) = myTXEXEM._TFIXAM
			Wrkstr(1) = Trim(myTXEXEM._TDESC)
		Else
			Wrkstr(1) = "*** Unknown ***"
		End If
		Return Wrkstr

	End Function
	Public Function GetTXHome(ByVal Code As Decimal) As String()
		 Dim Wrkstr(1) As String
		 Dim myTXHOME As TXHOME.MyData

		 myTXHOME = New TXHOME.mydata(MyDBConnect)
		 If IsNothing(Code) Then
			 Return Wrkstr
		 End If

		 myTXHOME.GetOneRecordP(Code)
		 If Not myTXHOME.RecordNotFound Then
			 Wrkstr(0) = myTXHOME._CRMIN
			 Wrkstr(1) = myTXHOME._CRMAX
		 Else
			 Wrkstr(1) = "*** Unknown ***"
		 End If
		 Return Wrkstr

	End Function
	'Public Function GetTXMVPCT(ByVal Type As String, ByVal Code As String) As String()
	'	Dim Wrkstr(1) As String
	'	Dim myTXMVPCT As TXMVPCT.MyData

	'	myTXMVPCT = New TXMVPCT.MyData(myDBConnect)
	'	If IsNothing(Code) Then
	'		Return Wrkstr
	'	End If

	'	myTXMVPCT.GetOneRecordP(Type, Code)
	'	If Not myTXMVPCT.RecordNotFound Then
	'		With myTXMVPCT
	'			Wrkstr(0) = Format(._PCT, ".###")
	'			Wrkstr(1) = ._MONTH
	'		End With
	'	Else
	'		Wrkstr(1) = "*** Unknown ***"
	'	End If
	'	Return Wrkstr
	'End Function
	Public Function GetTXMVPCTL1(ByVal Type As String, ByVal Month As Integer) As String()
		Dim Wrkstr(1) As String
		Dim myTXMVPCTL1 As TXMVPCTL1.MyData

		myTXMVPCTL1 = New TXMVPCTL1.MyData(myDBConnect)
		If IsNothing(Month) Then
			Return Wrkstr
		End If

		myTXMVPCTL1.GetOneRecordP(Type, Month)
		If Not myTXMVPCTL1.RecordNotFound Then
			With myTXMVPCTL1
				Wrkstr(0) = Format(myTXMVPCTL1._PCT, ".###")
				Wrkstr(1) = Trim(myTXMVPCTL1._CODE)
			End With
		Else
			Wrkstr(1) = "*** Unknown ***"
		End If
		Return Wrkstr

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
Public Function NextControlCCNo() As Integer
		 Dim myTXCNTL As TXCNTL.myData
		 Dim WrkNextCCNo As Integer

		 myTXCNTL = New TXCNTL.mydata(MyDBConnect)
     myTXCNTL.GetOneRecordP("")
		 If Not myTXCNTL.RecordNotFound Then
			 WrkNextCCNo = myTXCNTL._COFC + 1
			 If WrkNextCCNo > 99999 Then
					WrkNextCCNo = 1
			 End If
			 myTXCNTL._COFC = WrkNextCCNo
			 myTXCNTL.UpdateOneRecordP()
			 Return WrkNextCCNo
		 End If

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
  Public Function GetControlGLYear() As Integer
     Dim myTXCNTL As TXCNTL.myData

     myTXCNTL = New TXCNTL.mydata(MyDBConnect)
     myTXCNTL.GetOneRecordP("")
     If Not myTXCNTL.RecordNotFound Then
       Return myTXCNTL._ASRGL
     Else
       Return 0
     End If

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






