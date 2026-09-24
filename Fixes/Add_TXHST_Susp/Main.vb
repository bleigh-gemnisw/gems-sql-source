Module Main
  Public MyDBName As String
  Public MyUserID As String
  Public myDBConnect As DBConnect.DBConnection
  Public dsTown As DataSet = New DataSet
  Public MyFrmFix As FrmFix
  Public MyFrmFixB As FrmFixB

  Public MyAS400 As Boolean

Sub Main()

#If Not Debug Then
    AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GlobalUnhandler
    AddHandler Application.ThreadException, AddressOf GlobalThreadHandler
#End If

  MyFrmFix = New FrmFix
  Application.Run(MyFrmFix)
End Sub
End Module
