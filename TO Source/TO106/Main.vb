Module Main
    Public MyFrmTO106 As FrmTO106
    Public MyFrmTO106B As FrmTO106B
    Public MyFrmListDist As FrmListDist
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO106 = New FrmTO106
    Application.Run(MyFrmTO106)
   End Sub
  End Module






