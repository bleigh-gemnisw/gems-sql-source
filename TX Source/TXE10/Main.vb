Module Main
    Public MyFrmTXE10 As FrmTXE10
    Public MyFrmTXE10B As FrmTXE10B
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

    MyFrmTXE10 = New FrmTXE10
    Application.Run(MyFrmTXE10)
   End Sub
End Module






