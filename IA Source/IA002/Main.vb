Module Main
  Public MyFrmIA002 As FrmIA002
  Public MyFrmIA002B As FrmIA002B
  Public MyFrmIA002C As FRMIA002C
  Public MyFrmIA002D As FrmIA002D
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFRMIA002 = New FRMIA002
    Application.Run(MyFRMIA002)
   End Sub
End Module
