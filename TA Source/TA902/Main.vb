
Module Main
  Public MyFrmTA902 As FrmTA902
  Public MyFrmTA902B As FrmTA902B
  Public MyPrtLayout As FrmPrtLayout
  Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA902 = New FrmTA902
    Application.Run(MyFrmTA902)
    End Sub
End Module






