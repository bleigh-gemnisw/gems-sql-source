Module Main
  Public MyFrmGL530 As FrmGL530
  Public MyFrmGL530B As FrmGL530B
  Public MyCrViewer As FrmCrViewer
  Sub main()
    StartUp()
    'GetSecurity()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL530 = New FrmGL530
    Application.Run(MyFrmGL530)
  End Sub
End Module
