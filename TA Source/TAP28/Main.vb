
Module Main
  Public MyFrmTAP28 As FrmTAP28
  Public MyFrmTAP28B As FrmTAP28B
  'Public MyPrtLayout As FrmPrtLayout
  Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTAP28 = New FrmTAP28
    Application.Run(MyFrmTAP28)
    End Sub
End Module






