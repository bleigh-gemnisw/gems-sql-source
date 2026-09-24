
Module Main
  Public MyFrmTA136 As FrmTA136
  Public MyFrmTA136B As FrmTA136B
  Public MyFrmTA136C As FrmTA136C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA136 = New FrmTA136
  Application.Run(MyFrmTA136)
  End Sub
End Module






