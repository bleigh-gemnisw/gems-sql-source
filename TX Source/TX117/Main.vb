Module Main
  Public MyFrmTX117 As FrmTX117
  Public MyFrmTX117B As FrmTX117B
  Public MyFrmTX117C As FrmTX117C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTX117 = New FrmTX117
  Application.Run(MyFrmTX117)
  Exit Sub
  End Sub
End Module






