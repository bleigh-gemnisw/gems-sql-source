
Module Main
  Public MyFrmAP602 As FrmAP602
  Public MyFrmAP602B As FrmAP602B


Sub Main()
  StartUp()
    GetSecurity("", False)
    If InStr(s_rights, "FI") <= 0 Then
      GetSecurity()
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmAP602 = New FrmAP602
  Application.Run(MyFrmAP602)
  End Sub
End Module
