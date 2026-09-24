Module Main
  Public MyFrmFA004 As FrmFA004
	Public MyFrmFA004B As FrmFA004B
	Public MyFrmFA004C As FrmFA004C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA004 = New FrmFA004
	Application.Run(MyFrmFA004)
End Sub
End Module
