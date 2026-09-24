
Module Main
  Public MyFrmUB111 As FrmUB111
  Public MyFrmUB111B As FrmUB111B
  Public MyFrmUB111C As FrmUB111C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmUB111 = New FrmUB111
  Application.Run(MyFrmUB111)
  Exit Sub

  End Sub
End Module






