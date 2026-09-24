Module Main
  Public MyFrmBD102 As FrmBD102
  Public MyFrmBD102B As FrmBD102B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmBD102 = New FrmBD102
  Application.Run(MyFrmBD102)

End Sub
End Module






