Module Main
  Public MyFrmTAP10 As FrmTAP10
  Public MyFrmTAP10B As FrmTAP10B
  Public MyFrmTAP10C As FrmTAP10C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTAP10 = New FrmTAP10
  Application.Run(MyFrmTAP10)

End Sub
End Module






