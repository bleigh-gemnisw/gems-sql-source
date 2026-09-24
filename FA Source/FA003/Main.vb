Module Main
  Public MyFrmFA003 As FrmFA003
	Public MyFrmFA003B As FrmFA003B
	Public MyFrmFA003C As FrmFA003C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmFA003 = New FrmFA003
	Application.Run(MyFrmFA003)
End Sub
End Module
