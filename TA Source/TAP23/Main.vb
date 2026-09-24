Module Main
  Public MyFrmTAP23 As FrmTAP23
  Public MyFrmTAP23B As FrmTAP23B
  Public MyFrmProgress As FrmProgress

  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAP23 = New FrmTAP23
    Application.Run(MyFrmTAP23)
  End Sub
End Module






