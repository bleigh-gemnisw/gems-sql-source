Imports System.IO
Imports Rebex.Net
Module FTPRebex
  Public Sub GetFile(ByVal cHostIp As String, ByVal cRemoteUser As String,
 ByVal cRemotePassword As String, ByVal WrkFilePath As String, ByVal WrkRemoteName As String,
 ByVal WrkRemoteDir As String)
    Dim WrkFTP As New Rebex.Net.Ftp
    Dim WrkConnection As Rebex.Net.FtpConnectionState
    'WrkFTP.LogWriter = New Rebex.FileLogWriter("c:\temp\log.txt", Rebex.LogLevel.Debug)
    WrkFTP.Timeout = 900 * 1000
    WrkFTP.Connect(cHostIp, 21)
    WrkFTP.Login(cRemoteUser, cRemotePassword)
    WrkConnection = WrkFTP.GetConnectionState()
    If Not WrkConnection.Connected Then
      MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Disconnected")
      Exit Sub
    End If
    WrkFTP.TransferMode = FtpTransferMode.Zlib
    WrkFTP.TransferType = FtpTransferType.Ascii
    WrkFTP.Passive = True
    WrkFTP.ChangeDirectory(WrkRemoteDir)
    WrkFTP.GetFile(WrkRemoteName, WrkFilePath)
    Application.DoEvents()
  End Sub
End Module






