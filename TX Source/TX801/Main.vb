
Module Main
  Public MyFrmProgress As FrmProgress
  Public MyFrmTX801 As FrmTX801
  Public MyFrmTX801B As FrmTX801B
  Public MyPrtLayout As FrmPrtLayout
  Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTX801 = New FrmTX801
    Application.Run(MyFrmTX801)
    End Sub
End Module






