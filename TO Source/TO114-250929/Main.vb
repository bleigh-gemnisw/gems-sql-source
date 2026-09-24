Module Main
    Public MyFrmTO114 As FrmTO114
    Public MyFrmTO114B As FrmTO114B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO114 = New FrmTO114
    Application.Run(MyFrmTO114)
   End Sub
  End Module






