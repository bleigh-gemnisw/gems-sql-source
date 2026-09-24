
Module Main
  Public MyFrmTO116 As FrmTO116
  Public MyFrmTO116B As FrmTO116B
  Public MyFrmListCodes As FrmListCodes
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

    MyFrmTO116 = New FrmTO116
    Application.Run(MyFrmTO116)

   End Sub
End Module






