
Module Main
  Public MyFrmTO208 As FrmTO208
  Public MyFrmTO208B As FrmTO208B
  Public MyCrViewer As FrmCrViewer
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO208 = New FrmTO208
    Application.Run(MyFrmTO208)

   End Sub
End Module






