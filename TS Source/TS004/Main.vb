
Module Main
  Public MyfrmTS004 As FrmTS004
  Public MyfrmTS004B As FrmTS004B
  Public MyfrmTS004C As FrmTS004C
  Public MyfrmListmftcls As FrmListmftcls
  Public MyfrmListmftptyp As FrmListmftptyp
  Public MyfrmListmfttype As FrmListmfttype
  Public MyCrViewer As FrmCrViewer

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyfrmTS004 = New FrmTS004
  Application.Run(MyFrmTS004)
  End Sub
End Module






