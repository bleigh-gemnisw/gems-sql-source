Module Main
  Public MyFrmUB108 As FrmUB108
	Public MyFrmUB108B As FrmUB108B
	Public MyFrmUB108C As FrmUB108C

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB108 = New FrmUB108
	Application.Run(MyFrmUB108)
End Sub
End Module






