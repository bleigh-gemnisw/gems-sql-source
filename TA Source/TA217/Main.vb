
Module Main
  Public MyFrmTA217 As FrmTA217
  Public MyFrmTA217B As FrmTA217B
  Public MyFrmListDist As FrmListDist
  Public MyCrViewer As FrmCrViewer
  Public MyReportCancel As Boolean
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA217 = New FrmTA217
    Application.Run(MyFrmTA217)

   End Sub
End Module






