Module Main
  Public MyFrmFA020 As FrmFA020
  Public MyFrmFA020B As FrmFA020B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmFA020 = New FrmFA020
	Application.Run(MyFrmFA020)

End Sub
End Module
