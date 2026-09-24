Module Main
  Public MyFrmCrViewer As FrmCrViewer
	Public MyFrmUB103 As FrmUB103
	Public MyFrmUB103B As FrmUB103B
	Public MyFrmUB103C_AS As FrmUB103C_AS
	Public MyFrmUB103C_MT As FrmUB103C_MT
	Public MyFrmUB103C_US As FrmUB103C_US
	Public myFrmListType_A As FrmListType_A
	Public myFrmListType_M As FrmListType_M
	Public myFrmListType_U As FrmListType_U

Sub Main()
  StartUp()
  GetSecurity()  '#sec

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmUB103 = New FrmUB103
	Application.Run(MyFrmUB103)
End Sub
End Module






