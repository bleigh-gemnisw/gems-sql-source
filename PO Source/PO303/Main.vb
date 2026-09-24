Module Main
  Public MyFrmPO303 As FrmPO303
  Public MyFrmPO303B As FrmPO303B
  Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmPO303 = New FrmPO303
  Application.Run(MyFrmPO303)

End Sub
End Module
