Module Main
  Public MyFrmPO330 As FrmPO330
  Public MyFrmPO330B As FrmPO330B
  Public MyFrmListGLAcct As FrmListGLAcct
  Public MyFrmCr_PrtEdits As FrmCr_PrtEdits
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmPO330 = New FrmPO330
  Application.Run(MyFrmPO330)

End Sub
End Module
