Module Main
  Public MyFrmTAP20 As FrmTAP20
	Public MyFrmTAP20B As FrmTAP20B
	Public MyCrViewer As FrmCrViewer

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTAP20 = New FrmTAP20
		Application.Run(MyFrmTAP20)
	End Sub
End Module






