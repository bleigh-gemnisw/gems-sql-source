
Module Main
  Public MyfrmPS002 As FrmPS002
  Public MyfrmPS002B As frmPS002B
  Public MyfrmPS002C As FrmPS002C
  Public MyfrmListmfpcat As FrmListmfpcat
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyfrmPS002 = New FrmPS002
	Application.Run(MyfrmPS002)
	End Sub
End Module






