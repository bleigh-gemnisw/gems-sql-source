
Module Main
  Public MyfrmCrViewer As FrmCrViewer
  Public MyFrmTA811 As FrmTA811
  Public MyFrmTA811_NEW As FrmTA811_NEW
  Public MyFrmTA8111R As FrmTA8111R
  Public MyFrmTA8112R As FrmTA8112R
  Public MyFrmTA8113R As FrmTA8113R
  Public MyFrmTA8114R As FrmTA8114R
  Public MyFrmTA8115R As FrmTA8115R
  Public MyFrmListCCHist As FrmListCCHist
  Public MyFrmListCodes As FrmListCodes
  Public MyFrmListCResn As FrmListCResn
  Public MyFrmListExemption As FrmListExemption
	Public MyFrmListInv As FrmListInv
	Public MyFrmComments As FrmComments
	Public MyFrmListMvpct As FrmListMvpct
	Public MyFrmListSource As FrmListSource
	Public MyFrmSettings As FrmSettings
	Public MyBeforeBillDate As Boolean
  Public MyAppSettings As AppSettings
  Public MyOpenCC As Boolean
  Public MyNosb As Boolean   ' added 9/20/2023
  Public MyProrateRound As Boolean
	Public MyBookPct As Decimal
	Public MyMinValue As Integer
	Public MyGLYear As Integer
	Public MySuppYear As Integer
	'MK 9/26/25 End  
	Public MyPhaseIn As Boolean
	Sub Main()
		Dim myGnetrights As GNETRIGHTS.MyData
		StartUp()
		'Check Alternative Program ID (TX710) first
		myGnetrights = New GNETRIGHTS.MyData()
		myGnetrights.MyDBConn = myDBConnect
		myGnetrights.Get_Rights(MyUserID, "TX710")
		If Not myGnetrights.s_sec Then
			GetSecurity()
		End If
		MyGLYear = GetControlGLYear()
		MySuppYear = MyGLYear
		If Today.Month >= 7 Then
			MySuppYear = MyGLYear - 1
		Else
			MySuppYear = MyGLYear
		End If
		GetAppSettings()
		MyBeforeBillDate = GetGNET("CCADT")
		MyOpenCC = GetGNET("OPNCC")
		MyProrateRound = GetGNET("CCRND")
		MyNosb = GetGNET("NOSB")   ' added 9/20/2023
		MyPhaseIn = GetGNET("PHASE")

#If Not DEBUG Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTA811 = New FrmTA811
		Application.Run(MyFrmTA811)
	End Sub
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
      End If
    Else
      GetGNET = False
    End If
    myGNET.CloseFile()
    myGNET = Nothing
    Return GetGNET

  End Function
	Public Function GetControlGLYear() As Integer
		Dim myTXCNTL As TXCNTL.MyData

		myTXCNTL = New TXCNTL.MyData(myDBConnect)
		myTXCNTL.GetOneRecordP("")
		If Not myTXCNTL.RecordNotFound Then
			Return myTXCNTL._ASRGL
		Else
			Return 0
		End If

	End Function
	Public Function GetTXBanksDesc(ByVal Code As String) As String
		Dim myTXBANKS As TXBANKS.MyData

		myTXBANKS = New TXBANKS.MyData(myDBConnect)
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
Public Function GetTXMVPCTL1(ByVal Type As String, ByVal Month As Integer) As String()
		 Dim Wrkstr(1) As String
		 Dim myTXMVPCTL1 As TXMVPCTL1.myData

		 myTXMVPCTL1 = New TXMVPCTL1.mydata(MyDBConnect)
		 If IsNothing(Month) Then
			 Return Wrkstr
		 End If

		 myTXMVPCTL1.GetOneRecordP(Type, Month)
		 If Not myTXMVPCTL1.RecordNotFound Then
			 With myTXMVPCTL1
				 Wrkstr(0) = Format(myTXMVPCTL1._pct, ".###")
				 Wrkstr(1) = Trim(myTXMVPCTL1._code)
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
			 GetTXTypeDesc = myTXTYPE._TYDESC
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
	Public Function CheckCCDate(ByVal WrkDate As Date, ByVal WrkType As String, _
		ByVal WrkYear As Integer, ByVal WrkPhs As String, ByVal WrkDist As Integer) As Date
		 Dim MyTXPROF As TXPROF.myData
		 Dim RtnDate As Date

		 MyTXPROF = New TXPROF.mydata(MyDBConnect)
		 If IsNothing(WrkDate) Then
			 Return RtnDate
		 End If

		 MyTXPROF.GetOneRecordP(WrkType, WrkYear, WrkPhs, WrkDist)
		 If MyTXPROF.RecordNotFound Then
			 Return RtnDate	'default date variable
		 End If

		 RtnDate = WrkDate
		 With MyTXPROF
       If RtnDate < MyUtils.GetDBDateMDY(._PRDUE1) Then
         RtnDate = MyUtils.GetDBDateMDY(._PRDUE1)
       End If
		 End With

		 Return RtnDate
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
Public Function NextListNo(ByVal Year As Integer, ByVal Type As String) As Integer
		 Dim myTXINVLP As TXINVLP.myData
		 Dim WrkNextListNo As Integer

		 myTXINVLP = New TXINVLP.mydata(MyDBConnect)
		 WrkNextListNo = myTXINVLP.AutoGenKey(Year, Type)
		 Return WrkNextListNo

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






