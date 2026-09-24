
Module Main
  Public MyFrmTS001 As FrmTS001
  Public MyFrmTS001B As FrmTS001B
  Public MyFrmTS001C As FrmTS001C


Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTS001 = New FrmTS001
  Application.Run(MyFrmTS001)
  End Sub
End Module






