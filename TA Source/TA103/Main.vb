Module Main
  Public MyFrmTA103 As FrmTA103
  Public MyFrmTA103B As FrmTA103B
  Public MyFrmTA103C As FrmTA103C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTA103 = New FrmTA103
  Application.Run(MyFrmTA103)

End Sub
End Module
