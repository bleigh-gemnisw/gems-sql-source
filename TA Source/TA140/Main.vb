Module Main
  Public MyFrmTA140 As FrmTA140
  Public MyFrmTA140B As FrmTA140B
  Public MyFrmTA140C As FrmTA140C
Sub Main()
  StartUp()
  GetSecurity()
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTA140 = New FrmTA140
	Application.Run(MyFrmTA140)

End Sub
End Module






