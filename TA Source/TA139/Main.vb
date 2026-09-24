
Module Main
  Public MyFrmTA139 As FrmTA139
  Public MyFrmTA139B As FrmTA139B

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA139 = New FrmTA139
  Application.Run(MyFrmTA139)
  End Sub
End Module






