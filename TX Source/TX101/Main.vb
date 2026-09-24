
Module Main
  Public MyCRViewer As FrmCrViewer
  Public MyFrmTX101 As FrmTX101
  Public MyFrmTX101B As FrmTX101B
  Public MyFrmTX101C As FrmTX101C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX101 = New FrmTX101
  Application.Run(MyFrmTX101)
End Sub
End Module






