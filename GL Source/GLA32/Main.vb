Imports System.Text
Module Main
  Public MyFrmGLA32 As FrmGLA32
  Public MyFrmGLA32B As FrmGLA32B
  Public MyFrmGLA32C As FrmGLA32C
  Public MyCrViewer As FrmCrViewer
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGLA32 = New FrmGLA32
  Application.Run(MyFrmGLA32)
  Exit Sub

  End Sub
End Module
