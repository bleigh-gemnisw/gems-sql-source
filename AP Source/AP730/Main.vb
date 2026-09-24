Module Main
  Public MyFrmAP730 As FrmAP730
  Public MyFrmAP730B As FrmAP730B
 Sub Main()
    StartUp()
    GetTown()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP730 = New FrmAP730
    Application.Run(MyFrmAP730)

   End Sub
End Module
