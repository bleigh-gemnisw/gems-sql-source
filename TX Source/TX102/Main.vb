
Module Main
  Public MyFrmTX102 As FrmTX102
  Public MyFrmTX102B As FrmTX102B
  Public MyFrmTX102C As FrmTX102C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTX102 = New FrmTX102
	Application.Run(MyFrmTX102)
	Exit Sub

End Sub
End Module






