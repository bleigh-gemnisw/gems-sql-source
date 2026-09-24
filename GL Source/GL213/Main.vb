Module Main
  Public MyFrmGL213 As FrmGL213
  Public MyFrmGL213B As FrmGL213B
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

    MyFrmGL213 = New FrmGL213
    Application.Run(MyFrmGL213)
   End Sub
End Module
