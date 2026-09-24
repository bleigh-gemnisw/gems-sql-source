
Module Main
  Public MyFrmPK101 As FrmPK110
  Public MyFrmPK101B As FrmPK110B
  Public MyFrmPK101C As FrmPK110C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPK101 = New FrmPK110
  Application.Run(MyFrmPK101)
  Exit Sub

  End Sub
End Module
