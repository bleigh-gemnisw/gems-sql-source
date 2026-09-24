Imports System.IO
Module FTP
Public MyFTPDir As String
Dim WrkRemoteDirNo(50) As Integer
Dim WrkRemoteName(50) As String
Dim WrkRemoteSize(50) As Integer
Dim WrkRemoteDate(50) As String
Dim WrkTotalSize As Integer
Dim WrkFTP As New clsFTP(cHostIP, "", cRemoteUser, cRemotePassword, cPort)
Const cDirRoot As String = "rwa"
  Const cHostIP As String = "gemsupdate.gemnisw.com"
  Const cRemoteUser As String = "rwauser"
Const cRemotePassword As String = "only4read"
Const cGMTOffset As Double = -5
Const cPort As Double = 21

Public Sub RunUpdate()
	Dim WrkLogIn As Boolean = WrkFTP.Login()
  ReadIni()
  WrkFTP.ChangeDirectory(cDirRoot)
  WrkFTP.ChangeDirectory(MyFTPDir)
  'MsgBox(WrkFTP.RemotePath)
  WrkFTP.SetBinaryMode(True)

  DirectUpdate("A_CATALOG.exe")
	If Not WrkAutomate Then
		If MyFrmMain.RbAll.Checked Then
      DirectUpdate("C1.Win.C1TrueDBGrid.4.dll")
      DirectUpdate("Rebex.Ftp.dll")
      DirectUpdate("Rebex.Common.dll")
      DirectUpdate("Rebex.Networking.dll")
      DirectUpdate("Rebex.Sftp.dll")
    End If
	End If
	WrkFTP.CloseConnection()
End Sub

Private Sub DirectUpdate(ByVal WrkName As String)
  Dim WrkDirName As String
  Dim WrkFile As String
  Dim WrkFileInfo As FileInfo
  Dim WrkSize As Integer
  Dim SaveWriteTime As Date
  Dim WrkExists As String

  WrkDirName = GetDataPath()
  WrkFile = WrkDirName & WrkName

  Try
    WrkSize = WrkFTP.GetFileSize(WrkName)
  Catch ex As Exception
'    MsgBox("Cannot find matching file. Check with Hotline", MsgBoxStyle.Information, "Update cancelled")
    Exit Sub
  End Try

  WrkExists = CheckFileExists(WrkFile)
  If WrkExists Then
    WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
    SaveWriteTime = WrkFileInfo.LastWriteTime
    If IsFileOpen(WrkFile) Then
      MsgBox(WrkName & " is in use", MsgBoxStyle.Exclamation, "Cannot update file")
      Exit Sub
    End If
  End If

  'Never update INI file
  If WrkExists And WrkFile = WrkDirName & "A_CATALOG.INI" Then Exit Sub

  WrkFTP.DownloadFile(WrkName, WrkFile)
  WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
  WrkFileInfo.LastWriteTime = WrkFTP.GetFileDate(WrkName, cGMTOffset)
  If WrkExists Then
    WrkMsg = WrkMsg & WrkName & " " & SaveWriteTime & " has been replaced with " & WrkFileInfo.LastWriteTime & vbCrLf
  Else
    WrkMsg = WrkMsg & WrkName & " " & SaveWriteTime & " has been added" & vbCrLf
  End If

End Sub
Private Function IsFileOpen(ByVal FileName As String) As Boolean
  ' Check to see if file is in use
  Dim fs As FileStream
  Dim WrkExists As Boolean
  Dim WrkOpen As Boolean

  WrkOpen = False

  WrkExists = CheckFileExists(FileName)
  If Not WrkExists Then
    Return WrkOpen
  End If

  Try
    fs = New FileStream(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
  Catch ex As Exception
    WrkOpen = True
  Finally
  End Try

  If Not IsNothing(fs) Then
    fs.Close()
  End If
  Return WrkOpen
End Function
Public Function CheckFileExists(ByVal FileName As String) As Boolean

  Dim Results As String

  CheckFileExists = False
  Results = Dir(FileName)

  If Results <> "" Then
    CheckFileExists = True
  End If

  Return CheckFileExists

End Function
Private Sub ReadIni()
  'Sample ini file. Do NOT include text in () or this line.
  'FTP=GEMSBETA (optional, alternative FTP directory name)

  Dim sr As StreamReader
  Dim WrkDatapath As String
  Dim WrkLine As String

  WrkDatapath = GetDataPath()
  sr = New StreamReader(WrkDatapath & "A_CATALOG.INI")
  WrkLine = sr.ReadLine()
  WrkLine = sr.ReadLine()
  MyFTPDir = "GEMS_NET"
  Do While Not sr.EndOfStream
    WrkLine = sr.ReadLine()
    If Left(WrkLine, 3) = "FTP" Then
      MyFTPDir = Mid(WrkLine, 5, 10)
    End If
  Loop
  sr.Close()
End Sub
End Module
