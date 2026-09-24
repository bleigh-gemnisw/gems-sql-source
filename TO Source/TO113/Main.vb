
Module Main
  Public MyFrmTO113 As FrmTO113
  Public MyFrmTO113B As FrmTO113B
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO113 = New FrmTO113
    Application.Run(MyFrmTO113)

   End Sub
End Module






