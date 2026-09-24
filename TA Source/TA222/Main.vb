
Module Main
  Public MyFrmTA222 As FrmTA222
  Public MyFrmTA222B As FrmTA222B
  
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA222 = New FrmTA222
    Application.Run(MyFrmTA222)
  End Sub
End Module






