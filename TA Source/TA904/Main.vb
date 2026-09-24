
Module Main
  Public MyFrmTA904 As FrmTA904
  Public MyFrmTA904B As FrmTA904B
  Public MyPrtLayout As FrmPrtLayout

    Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA904 = New FrmTA904
    Application.Run(MyFrmTA904)
    End Sub
End Module






