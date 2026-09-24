
Module Main
  Public MyFrmGL114 As FrmGL114
  Public MyFrmGL114B As FrmGL114B
  Public MyFrmGL114C As FrmGL114C
  Public MyFrmListFund As FrmListFund
Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmGL114 = New FrmGL114
  Application.Run(MyFrmGL114)
  End Sub
End Module
