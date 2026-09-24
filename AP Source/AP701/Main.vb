Module Main
  Public MyFrmAP701 As FrmAP701
  Public MyFrmAP701B As FrmAP701B
Sub Main()
 StartUp()
 GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
 MyFrmAP701 = New FrmAP701
 Application.Run(MyFrmAP701)

End Sub
End Module
