
Module Main
  Public MyFrmTX104 As FrmTX104
  Public MyFrmTX104B As FrmTX104B
  Public MyFrmTX104C As FrmTX104C


Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX104 = New FrmTX104
  Application.Run(MyFrmTX104)
  End Sub
End Module






