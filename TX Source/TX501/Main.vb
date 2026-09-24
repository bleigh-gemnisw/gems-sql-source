Module Main
    Public MyFrmTX501 As FrmTX501
    Public MyFrmTX501B As FrmTX501B
    Public MyCrViewer As FrmCrViewer
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX501 = New FrmTX501
    Application.Run(MyFrmTX501)
   End Sub
End Module






