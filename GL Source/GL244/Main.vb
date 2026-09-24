Module Main
  Public MyFrmGL244 As FrmGL244
  Public MyFrmGL244B As FrmGL244B
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

    MyFrmGL244 = New FrmGL244
    Application.Run(MyFrmGL244)
   End Sub
End Module
