
Module Main
  Public MyFrmTS002 As FrmTS002
  Public MyFrmTS002B As FrmTS002B
  Public MyFrmTS002C As FrmTS002C


Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTS002 = New FrmTS002
  Application.Run(MyFrmTS002)
  End Sub
End Module






