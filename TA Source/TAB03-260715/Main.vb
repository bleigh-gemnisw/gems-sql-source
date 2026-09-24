Module Main
    Public MyFrmTAB03 As FrmTAB03
    Public MyFrmTAB03B As FrmTAB03B
    Public MyFrmListDist As FrmListDist
    Public MyFrmListExempt As FrmListExempt
    Public MyFrmListExemption As FrmListExemption
		Public MyFrmListLocalCodes As FrmListLocalCodes
    Public MyFrmSelBusty As FrmSelBusty
    Public MyFrmSelCodes As FrmSelCodes
    Public MyCrViewer As FrmCrViewer
    Public MySelCodes As String
    Public MySelBusty As String
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAB03 = New FrmTAB03
    Application.Run(MyFrmTAB03)
   End Sub
  End Module






