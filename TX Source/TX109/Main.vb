Module Main
  Public MyFrmTX109 As FrmTX110
  Public MyFrmTX109B As FrmTX109B
  Public MyFrmTX109C As FrmTX109C
Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmTX109 = New FrmTX110
	Application.Run(MyFrmTX109)
	Exit Sub

End Sub
End Module






