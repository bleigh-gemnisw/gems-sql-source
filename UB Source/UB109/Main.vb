Module Main
  Public MyFrmUB109 As FrmUB109
  Public MyFrmUB109B As FrmUB109B
  Public MyFrmUB109C As FrmUB109C
  Public MyFrmUB109D As FrmUB109D
  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmUB109 = New FrmUB109
    Application.Run(MyFrmUB109)
  End Sub
End Module






