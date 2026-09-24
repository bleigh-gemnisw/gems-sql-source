Module Main
  Public MyFrmGL214 As FrmGL214
  Public MyFrmGL214B As FrmGL214B
  Public MyFrmListFund As FrmListFund
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmListObj As FrmListObj
  Public MyFrmListProg As FrmListProg
  Public MyCrViewer As FrmCrViewer
  Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL214 = New FrmGL214
    Application.Run(MyFrmGL214)
   End Sub
End Module
