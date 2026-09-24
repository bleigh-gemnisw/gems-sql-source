Module Main
  Public MyFrmUB106 As FrmUB106
  Public MyFrmUB106B As FrmUB106B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmUB106 = New FrmUB106
	Application.Run(MyFrmUB106)

End Sub
End Module






