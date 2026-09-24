Module Main
  Public MyFrmIA101 As FrmIA101
  Public MyFrmIA101B As FrmIA101B
  Public MyFrmIA101C As FrmIA101C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmIA101 = New FrmIA101
  Application.Run(MyFrmIA101)

End Sub
End Module
