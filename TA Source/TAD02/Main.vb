Module Main
  Public MyFrmTAD02 As FrmTAD02
  Public MyFrmTAD02B As FrmTAD02B

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTAD02 = New FrmTAD02
  Application.Run(MyFrmTAD02)
End Sub
End Module






