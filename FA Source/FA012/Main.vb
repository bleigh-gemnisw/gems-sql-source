Module Main
  Public MyFrmFA012 As FrmFA012
	Public MyFrmFA012B As FrmFA012B
	Public MyFrmFA012C As FrmFA012C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA012 = New FrmFA012
	Application.Run(MyFrmFA012)
End Sub
End Module
