
Module Main
  Public MyFrmTA111 As FrmTA111
  Public MyFrmTA111B As FrmTA111B
  Public MyFrmTA111C As FrmTA111C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA111 = New FrmTA111
  Application.Run(MyFrmTA111)
  End Sub
End Module






