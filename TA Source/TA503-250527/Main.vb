Module Main
    Public MyFrmTA503 As FrmTA503
    Public MyFrmTA503B As FrmTA503B
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA503 = New FrmTA503
    Application.Run(MyFrmTA503)
   End Sub
End Module






