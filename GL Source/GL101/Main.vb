Imports System.Text
Module Main
  Public MyFrmGL101 As FrmGL101
  Public MyFrmGL101B As FrmGL101B
  Public MyFrmGL101C As FrmGL101C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL101 = New FrmGL101
  Application.Run(MyFrmGL101)
  End Sub
End Module
