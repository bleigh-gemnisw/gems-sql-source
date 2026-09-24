Module Main
  Public MyFrmTAP13 As FrmTAP13
  Public MyFrmTAP13B As FrmTAP13B
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTAP13 = New FrmTAP13
	Application.Run(MyFrmTAP13)

End Sub
End Module






