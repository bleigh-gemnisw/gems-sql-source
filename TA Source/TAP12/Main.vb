Module Main
  Public MyFrmTAP12 As FrmTAP12
	Public MyFrmTAP12B As FrmTAP12B
	Public MyFrmTAP12C As FrmTAP12C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTAP12 = New FrmTAP12
	Application.Run(MyFrmTAP12)

End Sub
End Module






