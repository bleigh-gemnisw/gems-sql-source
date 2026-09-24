Module Main
  Public MyFrmTA104 As FrmTA104
  Public MyFrmTA104B As FrmTA104B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTA104 = New FrmTA104
	Application.Run(MyFrmTA104)

End Sub
End Module






