Module Main
  Public MyFrmGL730 As FrmGL730
  Public MyFrmGL730B As FrmGL730B
 Sub Main()
    StartUp()
    GetTown()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL730 = New FrmGL730
    Application.Run(MyFrmGL730)

   End Sub
End Module
