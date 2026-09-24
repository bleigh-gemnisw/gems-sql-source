
Module Main
  Public MyFrmGL652 As FrmGL652
  Public MyFrmGL652B As FrmGL652B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL652 = New FrmGL652
    Application.Run(MyFrmGL652)

   End Sub
  End Module
