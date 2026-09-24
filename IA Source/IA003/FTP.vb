Imports System.IO
Module FTP
Dim WrkFTP As New clsFTP(cHostIP, "", cRemoteUser, cRemotePassword, 21)
Const cHostIP As String = "gemsupdate.rwainc.com"
Const cRemoteUser As String = "anonymous"
Const cRemotePassword As String = ""
Const cGMTOffset As Double = -5

Public Function RunUpdate() As Boolean
	Dim WrkLogIn As Boolean = WrkFTP.Login()
	Dim Good As Boolean
  WrkFTP.ChangeDirectory("GEMS_NET9")
	WrkFTP.SetBinaryMode(False)

	Good = DirectUpdate("GNETPGM.XML")
	WrkFTP.CloseConnection()
	Return Good
End Function

Private Function DirectUpdate(ByVal WrkName As String) As Boolean
	Dim WrkDirName As String
	Dim WrkFile As String
	Dim WrkFileInfo As FileInfo
	Dim WrkSize As Integer

  WrkDirName = MyUtils.GetDataPath()
	WrkFile = WrkDirName & WrkName

	Try
		WrkSize = WrkFTP.GetFileSize(WrkName)
	Catch ex As Exception
		Return False
	End Try

	WrkFTP.DownloadFile(WrkName, WrkFile)
	WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
	WrkFileInfo.LastWriteTime = WrkFTP.GetFileDate(WrkName, cGMTOffset)
	Return True

End Function
Private Function IsFileOpen(ByVal FileName As String) As Boolean
  ' Check to see if file is in use
  Dim fs As FileStream
  Dim WrkExists As Boolean
  Dim WrkOpen As Boolean

  WrkOpen = False

  WrkExists = MyUtils.CheckFileExists(FileName)
  If Not WrkExists Then
    Return WrkOpen
  End If

  Try
    fs = New FileStream(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
	Catch ex As Exception
		MsgBox(ex.Message)
		WrkOpen = True
  Finally
  End Try

  If Not IsNothing(fs) Then
    fs.Close()
  End If
  Return WrkOpen
End Function
End Module
