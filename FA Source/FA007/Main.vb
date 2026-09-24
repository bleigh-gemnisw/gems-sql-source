Module Main
  Public MyFrmFA007 As FrmFA007
	Public MyFrmFA007B As FrmFA007B
	Public MyFrmFA007C As FrmFA007C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA007 = New FrmFA007
	Application.Run(MyFrmFA007)
End Sub
End Module
