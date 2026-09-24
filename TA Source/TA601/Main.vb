Module Main
  Public MyFrmTA601 As FrmTA601
  Public MyFrmTA601B As FrmTA601B
  Public MyCrViewer As FrmCrViewer

  Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA601 = New FrmTA601
  Application.Run(MyFrmTA601)
 End Sub
End Module






