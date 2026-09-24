Module Main
  Public MyFrmMR101 As FrmMR101
  Public MyFrmMR101B As FrmMR101B
  Public MyFrmMR101C As FrmMR101C
Sub Main()
  StartUp()
  GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmMR101 = New FrmMR101
  Application.Run(MyFrmMR101)

End Sub
End Module
