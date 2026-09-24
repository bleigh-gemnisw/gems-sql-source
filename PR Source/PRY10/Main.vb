
Module Main
  Public MyFrmPRY10 As FrmPRY10
  Public MyFrmPRY10B As FrmPRY10B
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmPRY10 = New FrmPRY10
    Application.Run(MyFrmPRY10)

   End Sub
End Module
