Module Main
  Public MyFrmTAD05 As FrmTAD05
  Public MyFrmTAD05B As FrmTAD05B
  Public MyFrmTAD05DMV As FrmTAD05DMV
  Public MyFrmTAD05MV As FrmTAD05MV
  Public MyFrmTAD05PP As FrmTAD05PP
  Public MyFrmTAD05RE As FrmTAD05RE
  Public MyFrmTAD05SU As FrmTAD05SU
  Public MyFrmListBanks As FrmListBanks
  Public MyfrmListBusty As FrmListBusty
  Public MyFrmListCodes As FrmListCodes
  Public MyFrmListExempt As FrmListExempt
	Public MyFrmListExemption As FrmListExemption
	Public MyFrmListSource As FrmListSource
	Public MyFrmListSupCd As FrmListSupCd
  Public MyFrmListVcus As FrmListVcus
	Public MyFrmListVeh As FrmListVeh
	Public MyBookPct As Decimal
	Public MyMinValue As Integer

	'LL add Phase In Button 2026-05-01
	Public MyPhaseIn As Boolean

	Sub Main()
    StartUp()
    Dim TestCmd() As String
    TestCmd = GetCommandLineArgs()
    GetSecurity()
	
	'LL add Phase In Button 2026-05-01
	If GetGNET("PHASE") = "Y" Then MyPhaseIn = True

#If Not Debug Then
	AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAD05 = New FrmTAD05
    Application.Run(MyFrmTAD05)
  End Sub
	Public Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Single
		CalcProRate = Gross * Pct
		Return CalcProRate
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

	'LL add Phase In Button 2026-05-01
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
End Module






