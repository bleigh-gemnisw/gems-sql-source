Module Main
  Public MyFrmFix_TAD04 As FrmFix_TAD04
  Public MyFrmFix_TAD04B As FrmFix_TAD04B
  Public MyFrmProgress As FrmProgress
  Public MyArchived As Boolean

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmFix_TAD04 = New FrmFix_TAD04
  Application.Run(MyFrmFix_TAD04)
End Sub
End Module







