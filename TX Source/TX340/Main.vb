Module Main
  Public MyFrmTX340 As FrmTX340
	Public MyFrmTX340B As FrmTX340B
	Public MyCRViewer As FrmCrViewer

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTX340 = New FrmTX340
		Application.Run(MyFrmTX340)
	End Sub
End Module






