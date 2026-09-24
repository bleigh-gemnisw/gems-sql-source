Module Main
  Public MyFrmTAP17 As FrmTAP17
	Public MyFrmTAP17B As FrmTAP17B
	Public MyFrmTAP17C As FrmTAP17C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTAP17 = New FrmTAP17
	Application.Run(MyFrmTAP17)

End Sub
End Module






