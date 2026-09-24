
Module Main
  Public MyFrmTAP14 As FrmTAP14
  Public MyFrmTAP14B As FrmTAP14B
  Public MyFrmTAP14C As FrmTAP14C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTAP14 = New FrmTAP14
	Application.Run(MyFrmTAP14)
	End Sub
End Module






