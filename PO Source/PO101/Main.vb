Imports System.Text
Module Main
  Public MyFrmPO101 As FrmPO101
  Public MyFrmPO101B As FrmPO101B
  Public MyFrmPO101C As FrmPO101C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPO101 = New FrmPO101
  Application.Run(MyFrmPO101)
  End Sub
End Module
