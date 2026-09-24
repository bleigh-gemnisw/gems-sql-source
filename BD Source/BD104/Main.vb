Module Main
  Public MyFrmBD104 As FrmBD104
  Public MyFrmBD104B As FrmBD104B

  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmBD104 = New FrmBD104
    Application.Run(MyFrmBD104)
  End Sub
End Module






