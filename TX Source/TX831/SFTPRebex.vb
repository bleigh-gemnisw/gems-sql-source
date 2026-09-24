Imports System.IO
Imports Rebex.Net
Module SFTPRebex
  Dim cHostIP As String = MyAppSettings2.Address
  Dim cRemoteUser As String = MyAppSettings2.User
  Dim cRemotePassword As String = MyAppSettings2.Password

  Public Sub PutFile(ByVal WrkFilePath As String, ByVal WrkRemoteName As String)
    Dim WrkSFTP As New Rebex.Net.Sftp
    Dim WrkConnection As Rebex.Net.SftpConnectionState

    WrkSFTP.Connect(cHostIP, 2022)
    WrkSFTP.Login(cRemoteUser, cRemotePassword)
    WrkConnection = WrkSFTP.GetConnectionState()
    If Not MyAutomate And Not WrkConnection.Connected Then
      MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Disconnected")
      Exit Sub
    End If
    WrkSFTP.TransferType = SftpTransferType.Binary
    WrkSFTP.ChangeDirectory("/ToInvoiceCloud/Invoices")
    WrkSFTP.PutFile(WrkFilePath, WrkRemoteName)
    Application.DoEvents()
  End Sub
End Module






