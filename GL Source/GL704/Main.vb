Module Main
  Public MyFrmGL704 As FrmGL704
  Public MyFrmGL704B As FrmGL704B
  Public MyFrmListFund As FrmListFund
  Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL704 = New FrmGL704
    Application.Run(MyFrmGL704)
   End Sub
End Module
