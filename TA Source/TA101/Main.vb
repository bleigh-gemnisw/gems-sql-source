Module Main
  Public MyFrmTA101 As FrmTA101
	Public MyFrmTA101B As FrmTA101B
	Public MyFrmTA101C As FrmTA101C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA101 = New FrmTA101
  Application.Run(MyFrmTA101)
End Sub
End Module
