'LEDHST: Delete
Module Main
  Public MyFrmGL600 As FrmGL600
  Public MyFrmGL600B As FrmGL600B
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

    MyFrmGL600 = New FrmGL600
    Application.Run(MyFrmGL600)
    Exit Sub

  End Sub
End Module
