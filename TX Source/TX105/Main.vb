
Module Main
  Public MyFrmTX105 As FrmTX105
  Public MyFrmTX105B As FrmTX105B
  Public MyFrmTX105C As FrmTX105C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  GetTown()
  MyFrmTX105 = New FrmTX105
  Application.Run(MyFrmTX105)
  End Sub
End Module






