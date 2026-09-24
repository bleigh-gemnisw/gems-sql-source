Module Main
  Public MyFrmIA100 As FrmIA100
  Public MyFrmIA100B As FrmIA100B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmIA100 = New FrmIA100
	Application.Run(MyFrmIA100)

End Sub
End Module
