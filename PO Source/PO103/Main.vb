Imports System.Text
Module Main
  Public MyFrmPO103 As FrmPO103
  Public MyFrmPO103B As FrmPO103B
  Public MyFrmPO103C As FrmPO103C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPO103 = New FrmPO103
  Application.Run(MyFrmPO103)
  End Sub
End Module
