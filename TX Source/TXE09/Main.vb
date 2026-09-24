Module Main
    Public MyFrmTXE09 As FrmTXE09
    Public MyFrmTXE09B As FrmTXE09B
    Public MyFrmSelTypes As FrmSelTypes
    Public MyCrViewer As FrmCrViewer
    Public MyTypes As String
   Sub main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTXE09 = New FrmTXE09
    Application.Run(MyFrmTXE09)
   End Sub
End Module






