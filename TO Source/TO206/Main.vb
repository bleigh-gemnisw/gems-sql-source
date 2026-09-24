Module Main
    Public MyFrmTO206 As FrmTO206
    Public MyFrmTO206B As FrmTO206B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO206 = New FrmTO206
    Application.Run(MyFrmTO206)
   End Sub
  End Module






