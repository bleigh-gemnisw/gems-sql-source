Imports System.Text
Module Main
  Public MyFrmGLA47 As FrmGLA47
  Public MyFrmGLA47B As FrmGLA47B
  Public MyFrmGLA47C As FrmGLA47C
  Public MyCrViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA47 = New FrmGLA47
  Application.Run(MyFrmGLA47)
  Exit Sub

  End Sub
End Module
