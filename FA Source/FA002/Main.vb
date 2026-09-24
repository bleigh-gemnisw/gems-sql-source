Module Main
  Public MyFrmFA002 As FrmFA002
	Public MyFrmFA002B As FrmFA002B
	Public MyFrmFA002C As FrmFA002C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA002 = New FrmFA002
	Application.Run(MyFrmFA002)
End Sub
End Module
