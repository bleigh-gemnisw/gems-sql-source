Module Main
  Public MyFrmAP230 As FrmAP230
  Public MyFrmAP230B As FrmAP230B
  Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP230 = New FrmAP230
    Application.Run(MyFrmAP230)
  End Sub
End Module
