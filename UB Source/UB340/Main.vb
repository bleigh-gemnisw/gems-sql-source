Module Main
  Public MyCrViewer As FrmCrViewer
  Public MyFrmUB340 As FrmUB340
	Public MyFrmUB340B As FrmUB340B

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmUB340 = New FrmUB340
		Application.Run(MyFrmUB340)
	End Sub
End Module






