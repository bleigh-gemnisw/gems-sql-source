Module Main
    Public MyFrmTA524 As FrmTA524
    Public MyFrmTA524B As FrmTA524B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA524 = New FrmTA524
    Application.Run(MyFrmTA524)
   End Sub
  End Module








