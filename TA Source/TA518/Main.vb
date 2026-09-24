
Module Main
  Public MyFrmTA518 As FrmTA518
  Public MyFrmTA518B As FrmTA518B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA518 = New FrmTA518
    Application.Run(MyFrmTA518)

   End Sub
End Module






