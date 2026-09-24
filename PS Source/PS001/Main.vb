
Module Main
  Public MyFrmPS001 As FrmPS001
  Public MyFrmPS001B As FrmPS001B
  Public MyFrmPS001C As FrmPS001C
Sub Main()
  StartUp()
  GetSecurity() '#sec
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmPS001 = New FrmPS001
	Application.Run(MyFrmPS001)
	End Sub
End Module






