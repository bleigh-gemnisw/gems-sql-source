Module Main
  Public MyFrmGLA31 As FrmGLA31
  Public MyFrmGLA31B As FrmGLA31B
  Public MyFrmListGLAcct As FrmListGLAcct

  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGLA31 = New FrmGLA31
    Application.Run(MyFrmGLA31)
  End Sub
End Module
