Module Main
  Public MyFrmUB104 As FrmUB104
	Public MyFrmUB104B As FrmUB104B
	Public MyFrmUB104C As FrmUB104C
	Public myFrmListType As FrmListType
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB104 = New FrmUB104
	Application.Run(MyFrmUB104)
End Sub
End Module






