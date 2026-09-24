Module Main
    Public MyFrmTO121 As FrmTO121
    Public MyFrmTO121B As FrmTO121B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO121 = New FrmTO121
    Application.Run(MyFrmTO121)
   End Sub
  End Module






