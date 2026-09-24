Module Main
  Public MyFrmTX808 As FrmTX808
  Public MyFrmTX808B As FrmTX808B
  Public myFrmSelTypes As FrmSelTypes
  Public myFrmlistbanks As FrmListBanks
  Public MyPrtLayout As FrmPrtLayout
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
  Public Mypayment As String
  Public MyList7 As Boolean
  Sub Main()
    StartUp()
    GetSecurity()
    If GetGNET("LIST7") = "Y" Then MyList7 = True

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX808 = New FrmTX808
    Application.Run(MyFrmTX808)

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
  Public Function GetTXBanksDesc(ByVal Code As String) As String
    Dim myTXBanks As TXBANKS.MyData

    myTXBanks = New TXBANKS.MyData(myDBConnect)
    If IsNothing(Code) Or Code = "" Then
      Return ""
    End If

    myTXBanks.GetOneRecordP(Code)
    If Not myTXBanks.RecordNotFound Then
      GetTXBanksDesc = Trim(myTXBanks._BKNAME)
    Else
      GetTXBanksDesc = "*** Unknown ***"
    End If
    Return GetTXBanksDesc

  End Function
  Public Function GetTXBSerDesc(ByVal Code As String) As String
		Dim myTXBser As TXBSER.myData

		myTXBser = New TXBSER.mydata(MyDBConnect)
		If IsNothing(Code) Or Code = "" Then
			Return ""
		End If

		myTXBser.GetOneRecordP(Code)
		If Not myTXBser.RecordNotFound Then
			GetTXBSerDesc = Trim(myTXBser._BSNAME)
		Else
			GetTXBSerDesc = "*** Unknown ***"
		End If
		Return GetTXBSerDesc

	End Function
End Module






