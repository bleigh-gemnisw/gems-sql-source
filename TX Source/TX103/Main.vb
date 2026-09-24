
Module Main
  Public MyFrmTX103 As FrmTX101
  Public MyFrmTX103B As FrmTX103B
  Public MyFrmTX103C As FrmTX103C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX103 = New FrmTX101
  Application.Run(MyFrmTX103)
  Exit Sub

  End Sub
End Module






