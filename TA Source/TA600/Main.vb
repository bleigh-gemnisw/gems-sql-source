Module Main
  Public MyFrmTA600 As FrmTA600
  Public MyFrmTA600B As FrmTA600B
  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA600 = New FrmTA600
    Application.Run(MyFrmTA600)
  End Sub
End Module






