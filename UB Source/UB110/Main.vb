
Module Main
  Public MyFrmUB110 As FrmUB110
  Public MyFrmUB110B As FrmUB110B
  Public MyFrmUB110C As FrmUB110C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmUB110 = New FrmUB110
  Application.Run(MyFrmUB110)
  Exit Sub

  End Sub
End Module






