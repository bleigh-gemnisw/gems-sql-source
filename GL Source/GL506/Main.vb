
Module Main
  Public MyFrmGL506 As FrmGL506
  Public MyFrmGL506B As FrmGL506B
  Public MyFrmGL506C As FrmGL506C
  Public MyFrmListFund As FrmListFund
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL506 = New FrmGL506
  Application.Run(MyFrmGL506)
  End Sub
End Module
