Module Main
  Public MyFrmTS003 As FrmTS003
  Public MyFrmTS003B As FrmTS003B
  Public MyFrmTS003C As FrmTS003C
Sub Main()
  StartUp()
  GetSecurity()  '#sec
#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If
  MyFrmTS003 = New FrmTS003
  Application.Run(MyFrmTS003)

End Sub
End Module






