Module Main
  Public MyFrmTO200 As FrmTO200
  Public MyFrmTO200B As FrmTO200B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTO200 = New FrmTO200
	Application.Run(MyFrmTO200)

End Sub
End Module






