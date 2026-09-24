Module Main
  Public MySoftFreezeRE As Boolean
	Public MySoftFreezePP As Boolean
	Public MySoftFreezeMV As Boolean
	Public MyPhaseIn As Boolean
	Public MyNoSwr As Boolean
  Public MyFrmTA001 As FrmTA001
	Public MyFrmTA001B As FrmTA001B
  Public MyFrmTA001DMV As FrmTA001DMV
  Public MyFrmTA001MV As FrmTA001MV
	Public MyFrmTA001PP As FrmTA001PP
	Public MyFrmTA001RE As FrmTA001RE
  Public MyFrmTA001LocAmt As FrmTA001LocAmt
  Public MyFrmTA001SU As FrmTA001SU
	Public MyFrmTA001SU_CR As FrmTA001SU_CR
  Public MyFrmComments As FrmComments
	Public MyFrmListBanks As FrmListBanks
	Public MyfrmListBusty As FrmListBusty
	Public MyFrmListCodes As FrmListCodes
	Public MyFrmListExempt As FrmListExempt
	Public MyFrmListExemption As FrmListExemption
  Public MyFrmListSupCd As FrmListSupCd
  Public MyFrmListVcus As FrmListVcus
  Public MyFrmListVeh As FrmListVeh
  Public MyFrmLOG As FrmLOG
  Public MyInquiryMode As Boolean
  Public MyLocEldDarien As Boolean
  Public WrkCustID As Long 'Used for attachments
  Public Const cDarExcd1 As String = "DAC"
  Public Const cDarExcd2 As String = "DBC"
  Public Const cDarExcd3 As String = "DCC"
  Public Const cDarExcd4 As String = "DDC"

	Sub Main()
    StartUp()
    Dim TestCmd() As String
    'Parms: 
    '3 - "Inquiry" if inquiry mode or blank for normal  
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 1 Then
      If LCase(Trim(TestCmd(2))) = "inquiry" Then
        MyInquiryMode = True
      End If
    End If

    If MyInquiryMode Then
      GetSecurity()
      s_rights = "I"
      s_full = False
      s_add = False
      s_del = False
      s_chg = False
      s_edit = False
      s_post = False
    Else
      GetSecurity()
    End If
    GetControl()
    If GetGNET("PHASE") = "Y" Then MyPhaseIn = True
		If GetGNET("NOSWR") = "Y" Then MyNoSwr = True
    If GetGNET("LEDAR") = "Y" Then MyLocEldDarien = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTA001 = New FrmTA001
		Application.Run(MyFrmTA001)
	End Sub
	Public Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Single
		CalcProRate = Gross * Pct
		Return CalcProRate
	End Function
  Private Sub GetControl()
    Dim myTXCNTL As TXCNTL.myData

    MySoftFreezeRE = False
    MySoftFreezePP = False
    MySoftFreezeMV = False
    myTXCNTL = New TXCNTL.mydata(MyDBConnect)
    myTXCNTL.GetOneRecordP("")
    If Not myTXCNTL.RecordNotFound Then
      With myTXCNTL
        If ._SFR = "Y" Then
          MySoftFreezeRE = True
        End If
        If ._SFP = "Y" Then
          MySoftFreezePP = True
        End If
        If ._SFM = "Y" Then
          MySoftFreezeMV = True
        End If
      End With
    End If

  End Sub
Private Function GetGNET(ByVal Key As String) As String
	Dim myGNET As GNET.myData

	myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
	myGNET.GetOneRecordP(Key)
	With myGNET
		If .RecordNotFound Then Return String.Empty
		Return ._VALUE
	End With

End Function
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
	Public Function GetTXBustyDesc(ByVal Code As String) As String
		Dim myTXBUSTY As TXBUSTY.myData

		myTXBUSTY = New TXBUSTY.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If

		myTXBUSTY.GetOneRecordP(Code)
		If Not myTXBUSTY.RecordNotFound Then
			GetTXBustyDesc = Trim(myTXBUSTY._BTDESC)
		Else
			GetTXBustyDesc = "*** Unknown ***"
		End If
		Return GetTXBustyDesc

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
  Public Function GetTXExem(ByVal Code As String) As String()
    Dim Wrkstr(2) As String
    Dim myTXEXEM As TXEXEM.myData

    myTXEXEM = New TXEXEM.mydata(MyDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Wrkstr(0) = ""
      Wrkstr(1) = ""
      Wrkstr(2) = ""
      Return Wrkstr
    End If

    myTXEXEM.GetOneRecordP(Code)
    If Not myTXEXEM.RecordNotFound Then
      Wrkstr(0) = myTXEXEM._TFIXAM
      Wrkstr(1) = Trim(myTXEXEM._TDESC)
      Wrkstr(2) = Trim(myTXEXEM._TPERC)
    Else
      Wrkstr(1) = "*** Unknown ***"
    End If
    Return Wrkstr

  End Function
	Public Function GetTXSupCd(ByVal Code As String) As String()
		Dim Wrkstr(2) As String
		Dim myTXSUPCD As TXSUPCD.myData

		myTXSUPCD = New TXSUPCD.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Wrkstr(0) = ""
			Wrkstr(1) = ""
			Wrkstr(2) = ""
			Return Wrkstr
		End If

		myTXSUPCD.GetOneRecordP(Code)
		If Not myTXSUPCD.RecordNotFound Then
			Wrkstr(0) = Format(myTXSUPCD._SPCT, ".###")
			Wrkstr(1) = Trim(myTXSUPCD._SMON)
			Wrkstr(2) = Trim(myTXSUPCD._SCRD)
		Else
			Wrkstr(1) = "*** Unknown ***"
		End If
		Return Wrkstr

	End Function
	Public Function GetTXXPROPDesc(ByVal Code As String) As String
		Dim myTXXPROP As TXXprop.myData

		myTXXPROP = New TXXprop.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If

		myTXXPROP.GetOneRecordP(Code)
		If Not myTXXPROP.RecordNotFound Then
			GetTXXPROPDesc = Trim(myTXXPROP._TXDESC)
		Else
			GetTXXPROPDesc = "*** Unknown ***"
		End If
		Return GetTXXPROPDesc

	End Function
End Module






