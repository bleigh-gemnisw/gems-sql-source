Module Main
  Public MyFrmPK112 As FrmPK112
  Public MyFrmPK112B As FrmPK112B
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmPK112 = New FrmPK112
  Application.Run(MyFrmPK112)

End Sub
End Module
