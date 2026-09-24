
Module Main
  Public MyFrmTA504 As FrmTA504
  Public MyFrmTA504B As FrmTA504B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA504 = New FrmTA504
    Application.Run(MyFrmTA504)

   End Sub
End Module






