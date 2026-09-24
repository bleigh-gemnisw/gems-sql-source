
Module Main
  Public MyFrmAP231 As FrmAP231
  Public MyFrmAP231B As FrmAP231B
  Public MyFrmProgress As FrmProgress
  Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP231 = New FrmAP231
    Application.Run(MyFrmAP231)
    End Sub
End Module
