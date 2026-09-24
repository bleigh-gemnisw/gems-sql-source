
Module Main
  Public MyFrmGL111 As FrmGL111
  Public MyFrmGL111B As FrmGL111B
  Public MyFrmListFund As FrmListFund
  Public MyFrmListObj As FrmListObj
  Sub Main()
    StartUp()
    GetSecurity() '#sec

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL111 = New FrmGL111
    Application.Run(MyFrmGL111)
  End Sub
End Module






