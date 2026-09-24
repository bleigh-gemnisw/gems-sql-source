
Module Main
  Public MyFrmGL661 As FrmGL661
  Public MyFrmGL661B As FrmGL661B
  Public MyFrmGL661C As FrmGL661C
  Public MyFrmDEPNARL As FrmDEPNARL
  Public MyFrmListDegrp As FrmListDeGrp
Sub Main()
  StartUp()
  GetSecurity() '#sec
	
#If Not Debug Then
		AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
		AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

	MyFrmGL661 = New FrmGL661
	Application.Run(MyFrmGL661)
	End Sub
End Module
