Module Main
  Public MyFrmTX401 As FrmTX401
	Public MyFrmTX401B As FrmTX401B
	Public MyFrmTX401MV As FrmTX401MV
	Public MyFrmTX401PP As FrmTX401PP
	Public MyFrmTX401RE As FrmTX401RE
	Public MyFrmTX401SU As FrmTX401SU

	Public MyFrmComments As FrmComments
	Public MyFrmListBanks As FrmListBanks
	Public MyFrmListBser As FrmListBser
	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTX401 = New FrmTX401
		Application.Run(MyFrmTX401)
	End Sub
	Public Function CalcProRate(ByVal Gross As Single, ByVal Pct As Single) As Decimal
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
Public Function GetTXBserDesc(ByVal Code As String) As String
		Dim myTXBSER As TXBSER.myData

		myTXBSER = New TXBSER.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If


		myTXBSER.GetOneRecordP(Code)
		If Not myTXBSER.RecordNotFound Then
			GetTXBserDesc = Trim(myTXBSER._BSNAME)
		Else
			GetTXBserDesc = "*** Unknown ***"
		End If
		Return GetTXBserDesc

	End Function
Public Function GetTXCRESNDesc(ByVal Code As String) As String
		Dim myTXCRESN As TXCRESN.myData

		myTXCRESN = New TXCRESN.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If


		myTXCRESN.GetOneRecordP(Code)
		If Not myTXCRESN.RecordNotFound Then
			GetTXCRESNDesc = Trim(myTXCRESN._CRDESC)
		Else
			GetTXCRESNDesc = "*** Unknown ***"
		End If
		Return GetTXCRESNdesc

	End Function
End Module






