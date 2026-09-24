Imports System.Text
Module Main
  Public MyFrmPO104 As FrmPO104
  Public MyFrmPO104B As FrmPO104B
  Public MyFrmPO104C As FrmPO104C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPO104 = New FrmPO104
  Application.Run(MyFrmPO104)
  End Sub
End Module
