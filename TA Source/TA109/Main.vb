Module Main
  Public MyFrmTA109 As FrmTA109
  Public MyFrmTA109B As FrmTA109B
  Public MyFrmTA109C As FrmTA109C
Sub Main()
  StartUp()
  GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA109 = New FrmTA109
  Application.Run(MyFrmTA109)

End Sub
End Module






