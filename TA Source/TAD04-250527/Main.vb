Module Main
  Public MyFrmTAD04 As FrmTAD04
  Public MyFrmTAD04B As FrmTAD04B
  Public MyFrmProgress As FrmProgress
  Public MyArchived As Boolean

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTAD04 = New FrmTAD04
  Application.Run(MyFrmTAD04)
End Sub
End Module






