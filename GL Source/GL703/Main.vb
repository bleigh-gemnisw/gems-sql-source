Module Main
  Public MyFrmGL703 As FrmGL703
  Public MyFrmGL703B As FrmGL703B
  Public MyFrmListFund As FrmListFund
  Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL703 = New FrmGL703
    Application.Run(MyFrmGL703)
   End Sub
End Module
