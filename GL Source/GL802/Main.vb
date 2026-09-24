Imports System.Text
Module Main
  Public MyFrmGL802 As FrmGL802
  Public MyFrmGL802B As FrmGL802B
  Public MyFrmListFund As FrmListFund
  Public MyCrViewer As FrmCrViewer
  Public MyBatch As String
  Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmGL802 = New FrmGL802
    Application.Run(MyFrmGL802)

  End Sub
End Module
