Module Main
  Public MyFrmTAP11 As FrmTAP11
  Public MyFrmTAP11B As FrmTAP11B
  Public MyFrmTAP11C As FrmTAP11C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTAP11 = New FrmTAP11
  Application.Run(MyFrmTAP11)

End Sub
End Module






