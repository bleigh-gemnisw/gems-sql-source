Module Main
    Public MyFrmUB341 As FrmUB341
		Public MyFrmUB341B As FrmUB341B
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

    MyFrmUB341 = New FrmUB341
    Application.Run(MyFrmUB341)
   End Sub
End Module






