
Module Main
  Public MyFrmAP103 As FrmAP103
  Public MyFrmAP103B As FrmAP103B
  Public MyFrmAP103C As FrmAP103C


Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmAP103 = New FrmAP103
  Application.Run(MyFrmAP103)
  End Sub
End Module
