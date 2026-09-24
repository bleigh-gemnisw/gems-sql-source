Module Main
    Public MyFrmTO103 As FrmTO103
    Public MyFrmTO103B As FrmTO103B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO103 = New FrmTO103
    Application.Run(MyFrmTO103)
   End Sub
  End Module






