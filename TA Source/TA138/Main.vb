
Module Main
  Public MyFrmTA138 As FrmTA138
  Public MyFrmTA138B As FrmTA138B
  Public MyFrmTA138C As FrmTA138C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA138 = New FrmTA138
  Application.Run(MyFrmTA138)
  End Sub
End Module






