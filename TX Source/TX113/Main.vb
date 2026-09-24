
Module Main
  Public MyFrmTX113 As FrmTX113
  Public MyFrmTX113B As FrmTX113B
  Public MyFrmTX113C As FrmTX113C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX113 = New FrmTX113
  Application.Run(MyFrmTX113)
  Exit Sub

  End Sub
End Module






