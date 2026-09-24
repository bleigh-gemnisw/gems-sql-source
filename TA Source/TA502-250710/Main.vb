Module Main
  Public MyFrmTA502 As FrmTA502
  Public MyFrmTA502B As FrmTA502B
  Public MyCrViewer As FrmCrViewer
  Public MyMinValue As Integer
  Public MyBookPct As Decimal
  Sub Main()
    StartUp()
    GetSecurity()

#If Not DEBUG Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA502 = New FrmTA502
    Application.Run(MyFrmTA502)
  End Sub
End Module






