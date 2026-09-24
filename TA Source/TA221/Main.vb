
Module Main
  Public MyFrmTA221 As FrmTA221
  Public MyFrmTA221B As FrmTA221B
Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA221 = New FrmTA221
    Application.Run(MyFrmTA221)

   End Sub
End Module






