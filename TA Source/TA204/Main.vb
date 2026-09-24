
Module Main
  Public MyFrmTA204 As FrmTA204
  Public MyFrmTA204B As FrmTA204B
  Public MyCrViewer As FrmCrViewer
  Public MyTypes As String
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA204 = New FrmTA204
    Application.Run(MyFrmTA204)

   End Sub
End Module






