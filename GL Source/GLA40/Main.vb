Imports System.Text
Module Main
  Public MyFrmGLA40 As FrmGLA40
  Public MyFrmGLA40B As FrmGLA40B
  Public MyFrmGLA40C As FrmGLA40C
  Public MyCrViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA40 = New FrmGLA40
  Application.Run(MyFrmGLA40)
  Exit Sub

  End Sub
End Module
