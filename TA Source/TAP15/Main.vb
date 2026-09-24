Module Main
  Public MyFrmTAP15 As FrmTAP15
  Public MyFrmTAP15B As FrmTAP15B
  Public MyFrmTAP15C As FrmTAP15C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTAP15 = New FrmTAP15
  Application.Run(MyFrmTAP15)

End Sub
End Module






