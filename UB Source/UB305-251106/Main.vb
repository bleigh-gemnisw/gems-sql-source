Module Main
    Public MyFrmUB305 As FrmUB305
    Public MyFrmUB305B As FrmUB305B
    Public MyCrViewer As FrmCrViewer
    Public MyFrmListDist As FrmListDist
    Public MyFrmListUBType As FrmListUBType
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB305 = New FrmUB305
    Application.Run(MyFrmUB305)
   End Sub
End Module






