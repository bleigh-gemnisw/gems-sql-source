
Module Main
  Public MyFrmTX506 As FrmTX506
  Public MyFrmTX506B As FrmTX506B
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX506 = New FrmTX506
    Application.Run(MyFrmTX506)

   End Sub
End Module






