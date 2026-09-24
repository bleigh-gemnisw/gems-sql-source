Module Main
  Public MyFrmTX114 As FrmTX114
	Public MyFrmTX114B As FrmTX114B
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTX114 = New FrmTX114
	Application.Run(MyFrmTX114)

End Sub
End Module
