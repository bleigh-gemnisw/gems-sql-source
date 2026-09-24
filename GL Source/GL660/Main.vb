
Module Main
  Public MyFrmGL660 As FrmGL660
  Public MyFrmGL660B As FrmGL660B
  Public MyFrmGL660C As FrmGL660C


Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL660 = New FrmGL660
  Application.Run(MyFrmGL660)
  End Sub
End Module
