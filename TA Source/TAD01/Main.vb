Module Main
  Public MyFrmTAD01 As FrmTAD01
  Public MyFrmTAD01B As FrmTAD01B
  Public MyFrmProgress As FrmProgress

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTAD01 = New FrmTAD01
  Application.Run(MyFrmTAD01)
End Sub
End Module






