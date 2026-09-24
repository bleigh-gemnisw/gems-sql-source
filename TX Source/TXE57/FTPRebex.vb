Imports System.IO
Imports Rebex.Net
Module FTPRebex
	Const cHostIP As String = "gemsnt.com"
	Const cRemoteUser As String = "gemsfiles+gemsnt.com"
	Const cRemotePassword As String = "Jem$36filez"

	Public Sub PutFile(ByVal WrkFilePath As String, ByVal WrkRemoteName As String)
		Dim WrkFTP As New Rebex.Net.Ftp
		Dim WrkConnection As Rebex.Net.FtpConnectionState

		'WrkFTP.LogWriter = New Rebex.FileLogWriter(WrkFilePath & "-log.txt", Rebex.LogLevel.Debug)
		'  WrkFTP.Settings.DoNotDetectFeatures = False
		WrkFTP.Timeout = 900 * 1000
		WrkFTP.Connect(cHostIP, 21)
		WrkFTP.Login(cRemoteUser, cRemotePassword)
		WrkConnection = WrkFTP.GetConnectionState()
		If Not WrkConnection.Connected Then
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






