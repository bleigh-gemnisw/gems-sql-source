Module Main
  Public MyFrmTAD07 As FrmTAD07
  Public MyFrmTAD07B As FrmTAD07B
  Public MyFrmProgress As FrmProgress

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTAD07 = New FrmTAD07
  Application.Run(MyFrmTAD07)
End Sub
End Module






