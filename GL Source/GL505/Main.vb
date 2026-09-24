Module Main
  Public MyFrmGL505 As FrmGL505
  Public MyFrmGL505B As FrmGL505B
Sub Main()
 StartUp()
 GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
 MyFrmGL505 = New FrmGL505
 Application.Run(MyFrmGL505)

End Sub
End Module
