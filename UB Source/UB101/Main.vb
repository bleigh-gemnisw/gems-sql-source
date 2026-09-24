Module Main
  Public MyFrmUB101 As FrmUB101
	Public MyFrmUB101B As FrmUB101B
	Public MyFrmUB101C As FrmUB101C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB101 = New FrmUB101
	Application.Run(MyFrmUB101)
End Sub
End Module






