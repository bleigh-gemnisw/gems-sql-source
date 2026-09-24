Module Main
  Public MyFrmTAP30 As FrmTAP30
	Public MyFrmTAP30B As FrmTAP30B
	Public MyCrViewer As FrmCrViewer

	Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTAP30 = New FrmTAP30
		Application.Run(MyFrmTAP30)
	End Sub
End Module







