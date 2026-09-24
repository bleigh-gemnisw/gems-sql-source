Module Main
    Public MyFrmTX203 As FrmTX203
    Public MyFrmTX203B As FrmTX203B
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX203 = New FrmTX203
    Application.Run(MyFrmTX203)
   End Sub
  End Module






