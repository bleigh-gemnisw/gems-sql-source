Module Main
  Public MyFrmGL208 As FrmGL208
  Public MyFrmGL208B As FrmGL208B
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

    MyFrmGL208 = New FrmGL208
    Application.Run(MyFrmGL208)
   End Sub
End Module
