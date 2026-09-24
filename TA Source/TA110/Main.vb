
Module Main
  Public MyFrmTA110 As FrmTA110
  Public MyFrmTA110B As FrmTA110B
  Public MyFrmTA110C As FrmTA110C
Sub Main()
  StartUp()
  GetSecurity()

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTA110 = New FrmTA110
	Application.Run(MyFrmTA110)

End Sub
End Module






