Module Main
  Public MyFrmGL216 As FrmGL216
  Public MyFrmGL216B As FrmGL216B
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

    MyFrmGL216 = New FrmGL216
    Application.Run(MyFrmGL216)
   End Sub
End Module
