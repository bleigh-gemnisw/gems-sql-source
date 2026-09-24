Module Main
  Public MyFrmGL205 As FrmGL205
  Public MyFrmGL205B As FrmGL205B
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

    MyFrmGL205 = New FrmGL205
    Application.Run(MyFrmGL205)
   End Sub
End Module
