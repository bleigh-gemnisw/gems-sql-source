Module Main
  Public MyFrmUB112 As FrmUB112
	Public MyFrmUB112B As FrmUB112B
	Public MyFrmUB112C As FrmUB112C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB112 = New FrmUB112
	Application.Run(MyFrmUB112)
End Sub
End Module






