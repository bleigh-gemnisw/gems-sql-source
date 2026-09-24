Module Main
  Public MyFrmTA141 As FrmTA141
  Public MyFrmTA141B As FrmTA141B
  Public MyFrmTA141C As FrmTA141C
Sub Main()
  StartUp()
  GetSecurity()
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTA141 = New FrmTA141
	Application.Run(MyFrmTA141)

End Sub
End Module







