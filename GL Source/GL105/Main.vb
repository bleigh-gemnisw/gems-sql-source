Imports System.Text
Module Main
  Public MyFrmGL105 As FrmGL105
  Public MyFrmGL105B As FrmGL105B
  Public MyFrmGL105C As FrmGL105C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL105 = New FrmGL105
  Application.Run(MyFrmGL105)
  End Sub
End Module
