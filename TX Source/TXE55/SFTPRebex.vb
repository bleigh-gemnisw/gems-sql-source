Imports System.IO
Imports Rebex.Net
Module SFTPRebex
Dim cHostIP As String = MyAppSettings.Address
Dim cRemoteUser As String = MyAppSettings.User
Dim cRemotePassword As String = MyAppSettings.Password

Public Sub PutFile(ByVal WrkFilePath As String, ByVal WrkRemoteName As String)
  Dim WrkSFTP As New Rebex.Net.Sftp
  Dim WrkConnection As Rebex.Net.SftpConnectionState

  WrkSFTP.Connect(cHostIP, 22)
  WrkSFTP.Login(cRemoteUser, cRemotePassword)
  WrkConnection = WrkSFTP.GetConnectionState()
  If Not MyAutomate And Not WrkConnection.Connected Then
    MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Disconnected")
    Exit Sub
  End If
  WrkSFTP.TransferType = SftpTransferType.Binary
  WrkSFTP.PutFile(WrkFilePath, WrkRemoteName)
  Application.DoEvents()
End Sub
End Module






