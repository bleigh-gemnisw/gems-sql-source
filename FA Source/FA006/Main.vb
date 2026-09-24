Module Main
  Public MyFrmFA006 As FrmFA006
  Public MyFrmFA006B As FrmFA006B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
	GetTown()
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmFA006 = New FrmFA006
	Application.Run(MyFrmFA006)

End Sub
End Module
