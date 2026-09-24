
Module Main
  Public MyFrmTAP29 As FrmTAP29
  Public MyFrmTAP29B As FrmTAP29B
  Public MyFrmListLocalCodes As FrmListLocalCodes
  Public MyCrViewer As FrmCrViewer
  Sub Main()
    StartUp()
    GetSecurity()

#If Not DEBUG Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAP29 = New FrmTAP29
    Application.Run(MyFrmTAP29)

  End Sub
End Module






