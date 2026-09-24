Module Main
  Public MyCrViewer As FrmCrViewer
  Public MyFrmTXE12 As FrmTXE12
	Public MyFrmTXE12B As FrmTXE12B
	Public MyTypes As String

	Sub Main()
    StartUp()
    GetSecurity()  '#sec
		
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTXE12 = New FrmTXE12
		Application.Run(MyFrmTXE12)
	End Sub
End Module






