Imports System.Text
Module Main
  Public MyFrmGL104 As FrmGL104
  Public MyFrmGL104B As FrmGL104B
  Public MyFrmGL104C As FrmGL104C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL104 = New FrmGL104
  Application.Run(MyFrmGL104)
  End Sub
End Module
