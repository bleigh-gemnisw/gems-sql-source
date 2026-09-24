
Module Main
  Public MyFrmBD101 As FrmBD101
  Public MyFrmBD101B As FrmBD101B
  Public MyFrmBD101C As FrmBD101C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmBD101 = New FrmBD101
  Application.Run(MyFrmBD101)
  Exit Sub

  End Sub
End Module






