Imports System.Text
Module Main
  Public MyFrmGLA44 As FrmGLA44
  Public MyFrmGLA44B As FrmGLA44B
  Public MyFrmGLA44C As FrmGLA44C
  Public MyFrmGLA44D As FrmGLA44D
  Public MyCrViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA44 = New FrmGLA44
  Application.Run(MyFrmGLA44)
  Exit Sub

  End Sub
End Module
