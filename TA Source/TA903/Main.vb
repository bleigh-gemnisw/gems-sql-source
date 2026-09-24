
Module Main
  Public MyFrmTA903 As FrmTA903
  Public MyFrmTA903B As FrmTA903B
  Public MyPrtLayout As FrmPrtLayout

  Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA903 = New FrmTA903
    Application.Run(MyFrmTA903)
    End Sub
End Module






