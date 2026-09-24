Module Main
  Public MyFrmTA108 As FrmTA108
  Public MyFrmTA108B As FrmTA108B
  Public MyFrmTA108C As FrmTA108C
Sub Main()
  StartUp()
  GetSecurity()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTA108 = New FrmTA108
	Application.Run(MyFrmTA108)

End Sub
End Module






