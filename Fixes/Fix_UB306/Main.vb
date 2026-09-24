Module Main
    Public MyFrmUB306 As FrmUB306
    Public MyFrmUB306B As FrmUB306B
    Public MyCrViewer As FrmCrViewer
    Public MyFrmListUBType As FrmListUBType
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB306 = New FrmUB306
    Application.Run(MyFrmUB306)
   End Sub
End Module






