
Module Main
  Public MyFrmTX112 As FrmTX112
  Public MyFrmTX112B As FrmTX112B
  Public MyFrmTX112C As FrmTX112C

Sub Main()
  StartUp()
  GetSecurity() '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmTX112 = New FrmTX112
  Application.Run(MyFrmTX112)
  Exit Sub

  End Sub
End Module






