Module Main
  Public MyFrmTA106 As FrmTA106
  Public MyFrmTA106B As FrmTA106B
  Public MyFrmTA106C As FrmTA106C
Sub Main()
  StartUp()
  GetSecurity()
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
	MyFrmTA106 = New FrmTA106
	Application.Run(MyFrmTA106)

End Sub
End Module






