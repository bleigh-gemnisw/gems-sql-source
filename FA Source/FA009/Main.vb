Module Main
  Public MyFrmFA009 As FrmFA009
	Public MyFrmFA009B As FrmFA009B
	Public MyFrmFA009C As FrmFA009C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA009 = New FrmFA009
	Application.Run(MyFrmFA009)
End Sub
End Module
