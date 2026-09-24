Module Security
  Dim myGnetrights As GNETRIGHTS.MyData
  Public s_sec As Boolean
  Public s_full As Boolean
  Public s_add As Boolean
  Public s_del As Boolean
  Public s_chg As Boolean
  Public s_inq As Boolean
  Public s_edit As Boolean
  Public s_post As Boolean
  Public s_rights As String
  Dim s_err As String '
Public Sub GetSecurity(Optional ByVal MenuID As String = "", Optional ByVal EndPgm As Boolean = True)
  Dim WrkFileName As String
  Dim WrkPgmID As String

  WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
  Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

  With myFileVersionInfo
    If MenuID <> "" Then
      WrkPgmID = MenuID
    Else
      WrkPgmID = Replace(.InternalName, ".exe", "")
    End If
  End With

  myGnetrights = New GNETRIGHTS.MyData()
  With myGnetrights
    .MyDBConn = myDBConnect
    .Get_Rights(MyUserID, WrkPgmID)
    s_rights = .s_rights
    s_full = .s_full
    s_add = .s_add
    s_del = .s_del
    s_chg = .s_chg
    s_inq = .s_inq
    s_edit = .s_edit
    s_post = .s_post
    s_sec = .s_sec
  End With

  If s_sec = True Then Exit Sub
  If EndPgm Then
    MsgBox("Security Authorization required for Program id:" + WrkPgmID, MsgBoxStyle.Exclamation, "Security Verification")
    End
  End If
End Sub

End Module
