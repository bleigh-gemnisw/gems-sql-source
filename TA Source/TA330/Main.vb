Module Main
  Public MyFrmTA330 As FrmTA330
  Public MyFrmTA330B As FrmTA330B
  Public MyFrmLOG As FrmLOG

  Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA330 = New FrmTA330
    Application.Run(MyFrmTA330)
  End Sub
  
End Module






