
Module Main
  Public MyFrmBD103 As FrmBD103
  Public MyFrmBD103B As FrmBD103B
  Public MyFrmBD103C As FrmBD103C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmBD103 = New FrmBD103
  Application.Run(MyFrmBD103)
  Exit Sub

  End Sub
End Module






