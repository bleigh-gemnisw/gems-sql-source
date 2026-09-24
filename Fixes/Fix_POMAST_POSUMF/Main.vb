Module Main
  Public MyDBName As String
  Public MyUserID As String
  Public myDBConnect As SQLConnect.DBConnection
  Public dsTown As DataSet = New DataSet
  Public MyFrmFix As FrmFix
  Public MyFrmFixB As FrmFixB

Sub Main()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmFix = New FrmFix
  Application.Run(MyFrmFix)
End Sub
End Module
