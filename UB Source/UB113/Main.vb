Module Main
  Public MyFrmUB113 As FrmUB113
  Public MyFrmUB113B As FrmUB113B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmUB113 = New FrmUB113
	Application.Run(MyFrmUB113)

End Sub
End Module







