
Module Main
  Public MyFrmTA134 As FrmTA134
  Public MyFrmTA134B As FrmTA134B

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA134 = New FrmTA134
  Application.Run(MyFrmTA134)
  End Sub
End Module






