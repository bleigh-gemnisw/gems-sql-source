Module Main
  Public MyFrmFA011 As FrmFA011
	Public MyFrmFA011B As FrmFA011B
	Public MyFrmFA011C As FrmFA011C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA011 = New FrmFA011
	Application.Run(MyFrmFA011)
End Sub
End Module
