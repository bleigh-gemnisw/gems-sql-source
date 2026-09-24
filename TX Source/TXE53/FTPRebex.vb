Imports System.IO
Imports Rebex.Net
Module FTPRebex
  Dim cImplicit As Boolean = MyAppSettings.Implicit
  Dim cHostIP As String = MyAppSettings.Address
  Dim cRemoteUser As String = MyAppSettings.User
  Dim cRemotePassword As String = MyAppSettings.Password
  Dim cRemotePort As Integer = MyAppSettings.Port

  Public Sub PutFile(ByVal WrkFilePath As String, ByVal WrkRemoteName As String)
    Dim WrkFTP As New Rebex.Net.Ftp
    Dim WrkConnection As Rebex.Net.FtpConnectionState

    If cRemotePort = 0 Then
      If cImplicit Then
        cRemotePort = 990
      Else
        cRemotePort = 21
      End If
    End If
    If cImplicit Then
      WrkFTP.Connect(cHostIP, cRemotePort, SslMode.Implicit)
    Else
      WrkFTP.Connect(cHostIP, cRemotePort)
    End If
    WrkFTP.Login(cRemoteUser, cRemotePassword)
    WrkConnection = WrkFTP.GetConnectionState()
    If Not MyAutomate And Not WrkConnection.Connected Then
      MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Disconnected")
      Exit Sub
    End If
    WrkFTP.TransferMode = FtpTransferMode.Zlib
    WrkFTP.TransferType = FtpTransferType.Binary
    WrkFTP.Passive = True
    WrkFTP.PutFile(WrkFilePath, WrkRemoteName)
    Application.DoEvents()
  End Sub
End Module
