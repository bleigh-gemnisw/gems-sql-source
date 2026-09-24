Module Main
  Public MyFrmBD100 As FrmBD100
  Public MyFrmBD100B As FrmBD100B
  Public MyFrmBD100C As FrmBD100C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmBD100 = New FrmBD100
  Application.Run(MyFrmBD100)
End Sub
End Module






