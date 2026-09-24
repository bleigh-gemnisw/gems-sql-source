
Module Main
  Public MyFrmTO207 As FrmTO207
  Public MyFrmTO207B As FrmTO207B
  Public MyCRViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTO207 = New FrmTO207
  Application.Run(MyFrmTO207)

End Sub
End Module






