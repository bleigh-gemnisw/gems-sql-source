Module Main
  Public MyFrmTX106 As FrmTX106
  Public MyFrmTX106B As FrmTX106B
  Public MyFrmTX106C As FrmTX106C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTX106 = New FrmTX106
	Application.Run(MyFrmTX106)
	Exit Sub

	End Sub
End Module






