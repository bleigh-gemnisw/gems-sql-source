Module Main
  Public MyFrmTX116 As FrmTX116
  Public MyFrmTX116B As FrmTX116B

  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX116 = New FrmTX116
    Application.Run(MyFrmTX116)
  End Sub
End Module






