Module Main
    Public MyFrmTXE11 As FrmTXE11
    Public MyFrmTXE11B As FrmTXE11B
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

    MyFrmTXE11 = New FrmTXE11
    Application.Run(MyFrmTXE11)
   End Sub
End Module






