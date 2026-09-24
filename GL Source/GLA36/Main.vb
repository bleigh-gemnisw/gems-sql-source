Imports System.Text
Module Main
  Public MyFrmGLA36 As FrmGLA36
  Public MyFrmGLA36B As FrmGLA36B
  Public MyFrmGLA36C As FrmGLA36C
  Public MyCrViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA36 = New FrmGLA36
  Application.Run(MyFrmGLA36)
  Exit Sub

  End Sub
End Module
