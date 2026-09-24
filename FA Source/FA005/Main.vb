Module Main
  Public MyFrmFA005 As FrmFA005
	Public MyFrmFA005B As FrmFA005B
	Public MyFrmFA005C As FrmFA005C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA005 = New FrmFA005
	Application.Run(MyFrmFA005)
End Sub
End Module
