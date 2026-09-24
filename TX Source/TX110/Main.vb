Module Main
  Public MyFrmTX110 As FrmTX110
  Public MyFrmTX110B As FrmTX110B
  Public MyFrmTX110C As FrmTX110C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTX110 = New FrmTX110
	Application.Run(MyFrmTX110)
	Exit Sub
End Sub
End Module






