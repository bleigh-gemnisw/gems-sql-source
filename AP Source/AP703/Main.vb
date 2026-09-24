
Module Main
  Public MyFrmAP703 As FrmAP703
  Public MyFrmAP703B As FrmAP703B
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP703 = New FrmAP703
    Application.Run(MyFrmAP703)

   End Sub
End Module
