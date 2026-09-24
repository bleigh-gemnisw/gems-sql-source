
Module Main
  Public MyFrmTA901 As FrmTA901
  Public MyFrmTA901B As FrmTA901B
  Public MyPrtLayout As FrmPrtLayout

Sub Main()
    StartUp()
    GetSecurity()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTA901 = New FrmTA901
    Application.Run(MyFrmTA901)
  End Sub
End Module
