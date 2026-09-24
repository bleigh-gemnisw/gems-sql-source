Module Main
  Public MyFrmTA941 As FrmTA941
  Public MyFrmTA941B As FrmTA941B
  Public MyFrmTA941C As FrmTA941C
  Public MyCrViewer As FrmCrViewer
  Public MyColListNo As Integer
  Public MyColName As Integer
  Public MyColValue As Integer

 Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
  AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
  AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTA941 = New FrmTA941
  Application.Run(MyFrmTA941)
 End Sub
End Module






