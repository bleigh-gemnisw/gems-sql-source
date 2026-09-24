Module Main
  Public MyFrmTX107 As FrmTX107
  Public MyFrmTX107B As FrmTX107B
  Public MyFrmTX107C As FrmTX107C
Sub Main()
  StartUp()
  GetSecurity() '#sec
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTX107 = New FrmTX107
	Application.Run(MyFrmTX107)
	Exit Sub
	End Sub
End Module






