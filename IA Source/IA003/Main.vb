
Module Main
  Public MyFRMIA003 As FRMIA003
  Public MyFRMIA003B As FRMIA003B
  Public MyFRMIA003C As FRMIA003C
	Public MyFRMIA003D As FrmIA003D
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFRMIA003 = New FRMIA003
    Application.Run(MyFRMIA003)
   End Sub
End Module
