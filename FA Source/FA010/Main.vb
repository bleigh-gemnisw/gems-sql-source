Module Main
  Public MyFrmFA010 As FrmFA010
	Public MyFrmFA010B As FrmFA010B
	Public MyFrmFA010C As FrmFA010C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA010 = New FrmFA010
	Application.Run(MyFrmFA010)
End Sub
End Module
