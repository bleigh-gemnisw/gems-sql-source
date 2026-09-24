
Module Main
  Public MyFrmPK111 As FrmPK111
  Public MyFrmPK111B As FrmPK111B
  Public MyFrmPK111C As FrmPK111C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPK111 = New FrmPK111
  Application.Run(MyFrmPK111)
  Exit Sub

  End Sub
End Module
