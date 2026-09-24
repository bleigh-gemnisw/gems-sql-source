Module Main
    Public MyFrmTA525 As FrmTA525
    Public MyFrmTA525B As FrmTA525B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA525 = New FrmTA525
    Application.Run(MyFrmTA525)
   End Sub
  End Module








