Module Main
  Public MyFrmTX115 As FrmTX115
  Public MyFrmTX115B As FrmTX115B
  Public MyFrmTX115C As FrmTX115C

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX115 = New FrmTX115
  Application.Run(MyFrmTX115)
End Sub
End Module
