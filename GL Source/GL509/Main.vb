
Module Main
  Public MyFrmGL509 As FrmGL509
  Public MyFrmGL509B As FrmGL509B
  Public MyFrmListFund As FrmListFund
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL509 = New FrmGL509
    Application.Run(MyFrmGL509)

   End Sub
  
  
  
  
End Module
