Module Common
  Public MyDBName As String
  Public MyUserID As String
  Public MyServer As String
  Public myDBConnect As SQLConnect.DBConnection
  Public myTOWN As TOWN.myData
  Public MyUtils As Utils.Util
  Public Sub GetTown()
    myTOWN = New TOWN.MyData()
    myTOWN.MyDBConn = myDBConnect
    myTOWN.GetOneRecordP(1)
  End Sub
  Public Sub ShowSplash()
    Dim MySplash As Splash.FrmSplash

    MySplash = New Splash.FrmSplash
    With MySplash
      .UserID = MyUserID
      .Rights = s_rights
      .Product = Application.ProductName
      .Company = Application.CompanyName
      .LoadForm()
    End With
  End Sub
  Public Sub StartUp()
    Dim TestCmd() As String

    MyUserID = ""
    MyDBName = "gemsdata"
    TestCmd = GetCommandLineArgs()
    If UBound(TestCmd) > 0 Then
      If Trim(TestCmd(0)) > "" Then
        MyDBName = TestCmd(0)
      End If
      If Trim(TestCmd(1)) > "" Then
        MyUserID = TestCmd(1)
      End If
    End If

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    GetTown()
    MyServer = UCase(myDBConnect.ServerName)
    MyUtils = New Utils.Util
  End Sub
End Module






