Module Main
    Public MyFrmTO105 As FrmTO105
    Public MyFrmTO105B As FrmTO105B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO105 = New FrmTO105
    Application.Run(MyFrmTO105)
   End Sub
  End Module






