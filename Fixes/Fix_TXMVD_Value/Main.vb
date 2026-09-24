
Module Main
  Public MyFrmFix As FrmFix
  Public MyFrmFixB As FrmFixB
  Sub Main()
    StartUp()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmFix = New FrmFix
    Application.Run(MyFrmFix)
  End Sub
End Module









