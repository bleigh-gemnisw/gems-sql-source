Module Main
  Public MyFrmTA107 As FrmTA107
  Public MyFrmTA107B As FrmTA107B
  Public MyFrmTA107C As FrmTA107C
Sub Main()
  StartUp()
  GetSecurity()
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTA107 = New FrmTA107
	Application.Run(MyFrmTA107)

End Sub
End Module






