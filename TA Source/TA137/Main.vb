
Module Main
  Public MyFrmTA137 As FrmTA137
  Public MyFrmTA137B As FrmTA137B

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA137 = New FrmTA137
  Application.Run(MyFrmTA137)
  End Sub
End Module






