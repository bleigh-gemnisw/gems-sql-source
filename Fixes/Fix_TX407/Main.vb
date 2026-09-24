Module Main
  Public MyFrmTX407 As FrmTX407
  Public MyFrmTX407B As FrmTX407B
  Sub Main()
    StartUp()
    MyServer = UCase(myDBConnect.ServerName)

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX407 = New FrmTX407
    Application.Run(MyFrmTX407)
  End Sub
End Module






