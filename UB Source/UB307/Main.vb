Module Main
    Public MyFrmUB307 As FrmUB307
    Public MyFrmUB307B As FrmUB307B
    Public MyCrViewer As FrmCrViewer
  Sub Main()
    StartUp()
    GetSecurity()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB307 = New FrmUB307
    Application.Run(MyFrmUB307)
  End Sub
End Module






