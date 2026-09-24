Module Main
  Public MyFrmTAD03 As FrmTAD03
  Public MyFrmTAD03B As FrmTAD03B
  Public MyFrmProgress As FrmProgress

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTAD03 = New FrmTAD03
  Application.Run(MyFrmTAD03)
End Sub
End Module






