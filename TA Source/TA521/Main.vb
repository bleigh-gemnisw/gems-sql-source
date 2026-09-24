Module Main
    Public MyFrmTA521 As FrmTA521
    Public MyFrmTA521B As FrmTA521B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA521 = New FrmTA521
    Application.Run(MyFrmTA521)
   End Sub
  End Module








