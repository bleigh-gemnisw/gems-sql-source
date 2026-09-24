
Module Main
  Public MyFrmTA133 As FrmTA133
  Public MyFrmTA133B As FrmTA133B

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA133 = New FrmTA133
  Application.Run(MyFrmTA133)
  End Sub
End Module






