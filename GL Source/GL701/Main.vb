Module Main
  Public MyFrmGL701 As FrmGL701
  Public MyFrmGL701B As FrmGL701B
  Public MyFrmListFund As FrmListFund
  Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL701 = New FrmGL701
    Application.Run(MyFrmGL701)
   End Sub
End Module
