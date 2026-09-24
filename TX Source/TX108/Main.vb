Module Main
  Public MyFrmTX108 As FrmTX108
  Public MyFrmTX108B As FrmTX108B
  Public MyFrmTX108C As FrmTX108C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTX108 = New FrmTX108
	Application.Run(MyFrmTX108)
	Exit Sub

	End Sub
End Module






