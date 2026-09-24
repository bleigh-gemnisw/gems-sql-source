Module Main
    Public MyFrmTO104 As FrmTO104
    Public MyFrmTO104B As FrmTO104B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO104 = New FrmTO104
    Application.Run(MyFrmTO104)
   End Sub
  End Module






