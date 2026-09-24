Module Main
  Public MyFrmGL212 As FrmGL212
  Public MyFrmGL212B As FrmGL212B
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmListFund As FrmListFund
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

    MyFrmGL212 = New FrmGL212
    Application.Run(MyFrmGL212)
   End Sub
End Module
