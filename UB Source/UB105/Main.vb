Module Main
  Public MyFrmUB105 As FrmUB105
	Public MyFrmUB105B As FrmUB105B
	Public MyFrmUB105C As FrmUB105C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB105 = New FrmUB105
	Application.Run(MyFrmUB105)
End Sub
End Module






