Imports System.Text
Module Main
  Public MyFrmGLA42 As FrmGLA42
  Public MyFrmGLA42B As FrmGLA42B
  Public MyFrmGLA42C As FrmGLA42C
  Public MyCrViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA42 = New FrmGLA42
  Application.Run(MyFrmGLA42)
  Exit Sub

  End Sub
End Module
