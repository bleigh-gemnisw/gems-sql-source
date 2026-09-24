Module Main
    Public MyFrmTXE25 As FrmTXE25
    Public MyFrmTXE25B As FrmTXE25B
    Public MyCrViewer As FrmCrViewer
    Public MyTypes As String
	 Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

		MyFrmTXE25 = New FrmTXE25
		Application.Run(MyFrmTXE25)
	 End Sub
End Module






