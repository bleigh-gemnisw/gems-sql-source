Module Main
    Public MyFrmUB302 As FrmUB302
    Public MyFrmUB302B As FrmUB302B
    Public MyCrViewer As FrmCrViewer
		Public DataPath As String
   Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB302 = New FrmUB302
    Application.Run(MyFrmUB302)
   End Sub
End Module






