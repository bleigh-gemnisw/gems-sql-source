Module Main
  Public MyFrmTX118 As FrmTX118
  Public MyFrmTX118B As FrmTX118B
  Public MyFrmTX118C As FrmTX118C

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX118 = New FrmTX118
  Application.Run(MyFrmTX118)
End Sub
End Module






