
Module Main
  Public MyFrmTA942 As FrmTA942
  Public MyFrmTA942B As FrmTA942B
  Sub Main()
      StartUp()
      GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA942 = New FrmTA942
    Application.Run(MyFrmTA942)
    End Sub
End Module






