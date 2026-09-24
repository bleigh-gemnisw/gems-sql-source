Module Main
  Public MyFrmTA940 As FrmTA940
	Public MyFrmTA940B As FrmTA940B
  Public MyFrmProgress As FrmProgress

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTA940 = New FrmTA940
		Application.Run(MyFrmTA940)
	End Sub
End Module






