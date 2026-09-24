Module Main
  Public MyFrmGL220 As FrmGL220
  Public MyFrmGL220B As FrmGL220B
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

    MyFrmGL220 = New FrmGL220
    Application.Run(MyFrmGL220)
   End Sub
End Module
