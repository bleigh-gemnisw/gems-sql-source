Module Main
  Public MyFrmAP706 As FrmAP706
  Public MyFrmAP706B As FrmAP706B
  Public MyFrmAP706C As FrmAP706C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmAP706 = New FrmAP706
  Application.Run(MyFrmAP706)
End Sub
End Module
