Module Main
  Public MyFrmTO301 As FrmTO301
  Public MyFrmTO301B As FrmTO301B
  Public MyFrmTO301C As FrmTO301C
  Public MyFrmListVCus As FrmListVcus
  Sub Main()
    StartUp()
    GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmTO301 = New FrmTO301
    Application.Run(MyFrmTO301)
  End Sub
End Module






