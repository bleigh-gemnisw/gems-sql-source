Module Main
  Public MyFrmFA008 As FrmFA008
	Public MyFrmFA008B As FrmFA008B
	Public MyFrmFA008C As FrmFA008C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA008 = New FrmFA008
	Application.Run(MyFrmFA008)
End Sub
End Module
