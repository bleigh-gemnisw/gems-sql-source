Module Main
  Public MyDBName As String
  Public MyUserID As String
  Public myDBConnect As SQLConnect.DBConnection
  Public MyFrmFix As FrmAvon

  Sub Main()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

    MyFrmFix = New FrmAvon
    Application.Run(MyFrmFix)
  End Sub
End Module
