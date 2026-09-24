Module Main
  Public MyFrmTO300 As FrmTO300
  Public MyFrmTO300B As FrmTO300B
  Public MyFrmTO300C As FrmTO300C
  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO300 = New FrmTO300
    Application.Run(MyFrmTO300)
  End Sub
End Module






