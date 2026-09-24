Module Main
    Public MyFrmTO120 As FrmTO120
    Public MyFrmTO120B As FrmTO120B
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO120 = New FrmTO120
    Application.Run(MyFrmTO120)
   End Sub
  End Module






