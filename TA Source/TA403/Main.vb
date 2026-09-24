Module Main
    Public MyFrmTA403 As FrmTA403
    Public MyFrmTA403B As FrmTA403B
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA403 = New FrmTA403
    Application.Run(MyFrmTA403)
   End Sub
End Module






