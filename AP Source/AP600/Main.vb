'APHST: Delete
Module Main
  Public MyFrmAP600 As FrmAP600
  Public MyFrmAP600B As FrmAP600B
  Public MyCRViewer As FrmCrViewer
  Public MyReportLandscape As Boolean
  Sub Main()
    StartUp()
    GetSecurity() '#sec

    If s_group <> "Admin" Then
      MsgBox("Admin Security Authorization required for Program", MsgBoxStyle.Exclamation, "Security Verification")
      End
    End If

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmAP600 = New FrmAP600
    Application.Run(MyFrmAP600)
    Exit Sub

  End Sub
End Module
