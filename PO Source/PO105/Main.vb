Imports System.Text
Module Main
  Public MyFrmPO105 As FrmPO105
  Public MyFrmPO105B As FrmPO105B
  Public MyFrmPO105C As FrmPO105C
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmPO105 = New FrmPO105
  Application.Run(MyFrmPO105)
  End Sub
End Module
