
Module Main
  Public MyFrmTO202 As FrmTO202
  Public MyFrmTO202B As FrmTO202B
  Public MyCRViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTO202 = New FrmTO202
  Application.Run(MyFrmTO202)

End Sub
End Module






