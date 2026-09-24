Module Main
  Public MyFrmTA130 As FrmTA130
	Public MyFrmTA130B As FrmTA130B

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTA130 = New FrmTA130
		Application.Run(MyFrmTA130)
	End Sub
End Module






