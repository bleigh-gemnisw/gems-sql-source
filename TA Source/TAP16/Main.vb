Module Main
  Public MyFrmTAP16 As FrmTAP16
  Public MyFrmTAP16B As FrmTAP16B
  Public MyFrmTAP16C As FrmTAP16C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTAP16 = New FrmTAP16
  Application.Run(MyFrmTAP16)

End Sub
End Module






