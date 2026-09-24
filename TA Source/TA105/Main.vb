Module Main
  Public MyFrmTA105 As FrmTA105
  Public MyFrmTA105B As FrmTA105B
  Public MyFrmTA105C As FrmTA105C
Sub Main()
  StartUp()
  GetSecurity()
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTA105 = New FrmTA105
	Application.Run(MyFrmTA105)

End Sub
End Module






