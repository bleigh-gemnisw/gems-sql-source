Imports System.text
Imports System.IO
Imports Rebex.Net
Module FTPRebex
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim WrkRemoteDirNo(5000) As Integer
  Dim WrkRemoteName(5000) As String
  Dim WrkRemoteSize(5000) As Integer
  Dim WrkRemoteDate(5000) As String
  Dim WrkRemoteAction(5000) As String
  Dim WrkTotalSize As Integer
  Dim sb As StringBuilder
  Const cDirRoot As String = "rwa"
  Const cHostIP As String = "gemsupdates.gemnisw.com"
  Const cRemoteUser As String = "rwauser"
  Const cRemotePassword As String = "only4read"
  Const cGMTOffset As Double = -5
  Const cPort As Integer = 21
  Const cCertAccept As Boolean = True 'Accept all certificates
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("FileType", Type.GetType("System.String"))
      .Columns.Add("PathName", Type.GetType("System.String"))
      .Columns.Add("FileName", Type.GetType("System.String"))
      .Columns.Add("RemoteDate", Type.GetType("System.String"))
      .Columns.Add("RemoteSize", Type.GetType("System.Int32"))
      .Columns.Add("LocalDate", Type.GetType("System.String"))
      .Columns.Add("LocalSize", Type.GetType("System.Int32"))
      .Columns.Add("Action", Type.GetType("System.String"))
      .Columns.Add("DirNo", Type.GetType("System.Int16"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub CheckFiles(ByRef Cancel As Boolean)
    Dim WrkFTP As New Rebex.Net.Ftp
    Dim WrkConnection As Rebex.Net.FtpConnectionState
    Dim WrkDirName As String
    Dim WrkRptDirName As String
    Dim WrkTownDirName As String
    Dim WrkTownDirName2 As String
    Dim WrkHelpDirName As String
    Dim WrkFileList As FtpItemCollection
    Dim WrkItem As Rebex.Net.FtpItem
    Dim WrkName As String
    Dim WrkDatapath As String
    Dim J As Integer

    Cancel = False
    WrkTotalSize = 0
    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    If MyDebug Then
      WrkDatapath = GetDataPath()
      WrkFTP.LogWriter = New Rebex.FileLogWriter(WrkDatapath & "rebexlog.txt", Rebex.LogLevel.Debug)
    End If

    WrkFTP.Settings.SslAcceptAllCertificates = cCertAccept
    Try
      WrkFTP.Connect(cHostIP, cPort, SslMode.Explicit)
    Catch
    End Try

    WrkFTP.Passive = True
    If MyAutomate Then
      sb = New StringBuilder
    End If

    WrkConnection = WrkFTP.GetConnectionState()
    If Not WrkConnection.Connected Then
      If MyAutomate Then
        sb.AppendLine("Cannot connect to FTP Server, Code: " & WrkConnection.NativeErrorCode)
        WriteLogAuto()
        End
      Else
        MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Cannot connect to FTP Server")
        Cancel = True
        Exit Sub
      End If
    End If
    WrkFTP.Login(cRemoteUser, cRemotePassword)

    'Programs
    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "STEP 1: Get Program List"
    If MyAutomate Then
      myFrmProgress.Text = "Get Updates (Automatic mode)"
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFTP.ChangeDirectory(cDirRoot)
    WrkFTP.ChangeDirectory(MyFTPDir)
    WrkFileList = WrkFTP.GetList()
    WrkFileList.Sort()
    J = 0
    For Each WrkItem In WrkFileList
      If WrkItem.IsDirectory Then Continue For
      WrkName = WrkItem.Name ' .ToUpper()
      If WrkName.ToUpper = "A_CATALOG.EXE" Then Continue For
      If WrkName.ToUpper = "A_CATALOG.INI" Then Continue For
      If WrkName.ToUpper = "C1.WIN.C1TRUEDBGRID.4.DLL" Then Continue For
      If WrkName.ToUpper = "REBEX.FTP.DLL" Then Continue For
      If WrkName.ToUpper = "REBEX.SFTP.DLL" Then Continue For
      If WrkName.ToUpper = "REBEX.NETWORKING.DLL" Then Continue For
      If WrkName.ToUpper = "REBEX.COMMON.DLL" Then Continue For
      WrkRemoteDirNo(J) = 1
      WrkRemoteName(J) = WrkName
      WrkRemoteSize(J) = WrkItem.Length
      WrkRemoteDate(J) = Format(WrkItem.Modified, "M/d/yyyy H:mm")
      WrkRemoteAction(J) = ""
      J = J + 1
    Next

    'Reports
    myFrmProgress.LblMsg.Text = "STEP 2: Get Reports List"
    myFrmProgress.ProgBar1.Value = 33
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFTP.ChangeDirectory("Reports")
    WrkFileList = WrkFTP.GetList()
    WrkFileList.Sort()
    For Each WrkItem In WrkFileList
      WrkName = WrkItem.Name '.ToUpper()
      WrkRemoteDirNo(J) = 2
      WrkRemoteName(J) = WrkName
      WrkRemoteSize(J) = WrkItem.Length
      WrkRemoteDate(J) = Format(WrkItem.Modified, "M/d/yyyy H:mm")
      WrkRemoteAction(J) = ""
      J = J + 1
    Next

    'Help 
    myFrmProgress.LblMsg.Text = "STEP 3: Get Help Files"
    myFrmProgress.ProgBar1.Value = 50
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFTP.ChangeDirectory("..")
    WrkFTP.ChangeDirectory("GemsHelp")
    WrkFileList = WrkFTP.GetList()
    WrkFileList.Sort()
    For Each WrkItem In WrkFileList
      WrkName = WrkItem.Name ' .ToUpper()
      WrkRemoteDirNo(J) = 3
      WrkRemoteName(J) = WrkName
      WrkRemoteSize(J) = WrkItem.Length
      WrkRemoteDate(J) = Format(WrkItem.Modified, "M/d/yyyy H:mm")
      WrkRemoteAction(J) = ""
      J = J + 1
    Next

    'Custom 
    myFrmProgress.LblMsg.Text = "STEP 4: Get Custom List"
    myFrmProgress.ProgBar1.Value = 66
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFTP.ChangeDirectory("..")
    WrkFTP.ChangeDirectory(MyTownNo)
    WrkFTP.ChangeDirectory("Reports")
    WrkFileList = WrkFTP.GetList()
    WrkFileList.Sort()
    For Each WrkItem In WrkFileList
      WrkName = WrkItem.Name ' .ToUpper()
      WrkRemoteDirNo(J) = 4
      WrkRemoteName(J) = WrkName
      WrkRemoteSize(J) = WrkItem.Length
      WrkRemoteDate(J) = Format(WrkItem.Modified, "M/d/yyyy H:mm")
      WrkRemoteAction(J) = ""
      J = J + 1
    Next

    'Check for additional Custom 
    If MyCustom <> String.Empty Then
      myFrmProgress.LblMsg.Text = "STEP 5: Get 2nd Custom List"
      myFrmProgress.ProgBar1.Value = 83
      myFrmProgress.Refresh()
      Application.DoEvents()
      WrkFTP.ChangeDirectory("..")
      WrkFTP.ChangeDirectory("Reports" & MyCustom)
      WrkFileList = WrkFTP.GetList()
      WrkFileList.Sort()
      For Each WrkItem In WrkFileList
        WrkName = WrkItem.Name ' .ToUpper()
        WrkRemoteDirNo(J) = 5
        WrkRemoteName(J) = WrkName
        WrkRemoteSize(J) = WrkItem.Length
        WrkRemoteDate(J) = Format(WrkItem.Modified, "M/d/yyyy H:mm")
        WrkRemoteAction(J) = ""
        J = J + 1
      Next
    End If

    WrkFTP.Disconnect()

    WrkDirName = GetDataPath()
    CompareDirFTP("Program", WrkDirName, 1)

    WrkRptDirName = WrkDirName & "Reports\"
    CompareDirFTP("Report", WrkRptDirName, 2)

    WrkHelpDirName = WrkDirName & "GemsHelp\"
    CompareDirFTP("Help", WrkHelpDirName, 3)

    If MyTownNo <> "" Then
      WrkTownDirName = WrkDirName & MyTownNo & "\Reports\"
      CompareDirFTP("Custom", WrkTownDirName, 4)
      If MyCustom <> "" Then
        WrkTownDirName2 = WrkDirName & MyTownNo & "\Reports" & MyCustom & "\"
        CompareDirFTP("Custom2", WrkTownDirName2, 5)
      End If
    End If

    If Not MyAutomate Then
      MyFrmMain.DataGrdView.DataSource = ds.Tables(0)
      With MyFrmMain.DataGrdView
        .RowHeadersWidth = 25
        .Columns(0).Width = 80
        .Columns(1).Visible = False
        .Columns(2).Width = 170
        .Columns(3).HeaderText = "RWA Date/Time"
        .Columns(3).Width = 110
        .Columns(4).HeaderText = "RWA Size"
        .Columns(4).Width = 70
        .Columns(5).HeaderText = "Local Date/Time"
        .Columns(5).Width = 110
        .Columns(6).HeaderText = "Local Size"
        .Columns(6).Width = 70
        .Columns(7).HeaderText = "Apply Action"
        .Columns(7).Width = 80
        .Columns(8).Visible = False
      End With
    End If

    myFrmProgress.Close()
    Application.DoEvents()
  End Sub
  Private Sub CompareDirFTP(ByVal WrkDirType As String, ByVal WrkDirName As String, ByVal WrkDirNo As Integer)
    Dim en As System.Collections.IEnumerator
    Dim WrkFiles() As String
    Dim PosData As Integer
    Dim myDr As Data.DataRow
    Dim WrkStr As String
    Dim WrkLocalName As String
    Dim WrkLocalDate As Date
    Dim WrkLocalAdjDate As Date
    Dim I As Integer
    Dim WrkFileInfo As System.IO.FileInfo
    Dim WrkApp As String
    Dim PosApp As Integer
    Dim WrkSame As Boolean
    Dim drSel() As DataRow
    Dim WrkSelect As String

    WrkFiles = System.IO.Directory.GetFiles(WrkDirName)
    WrkStr = ""
    I = 0

    'Sort to put files in same order as FTP array
    Array.Sort(WrkFiles)
    en = WrkFiles.GetEnumerator
    While en.MoveNext
CheckNextFile:
      '     If WrkRemoteDirNo(I) = 0 Then Exit While
      '     If WrkDirNo > WrkRemoteDirNo(I) Then
      '       I = I + 1
      '       GoTo CheckNextFile
      '     End If
      '     If WrkDirNo < WrkRemoteDirNo(I) Then Exit While
      WrkLocalName = Replace(en.Current, WrkDirName, "", , , CompareMethod.Text) '.ToUpper
      'Only look at EXE, DLL, RPT, CHM or CONFIG files 
      PosData = InStr(WrkLocalName, ".exe", CompareMethod.Text)
      If PosData = 0 Then
        PosData = InStr(WrkLocalName, ".dll", CompareMethod.Text)
      End If
      If PosData = 0 Then
        PosData = InStr(WrkLocalName, ".rpt", CompareMethod.Text)
      End If
      If PosData = 0 Then
        PosData = InStr(WrkLocalName, ".chm", CompareMethod.Text)
      End If
      If PosData = 0 Then
        PosData = InStr(WrkLocalName, ".config", CompareMethod.Text)
      End If
      If PosData > 0 Then
LocalFile:
        '       If WrkDirNo <> WrkRemoteDirNo(I) Then Continue While
        'Can't update myself (A_CATALOG) so skip it 
        If WrkLocalName.ToUpper = "A_CATALOG.EXE" Then Continue While
        'Don't update True Grid 
        If WrkLocalName.ToUpper = "C1.WIN.C1TRUEDBGRID.4.DLL" Then Continue While
        'Can't update Rebex FTP DLL's (in use) 
        If WrkLocalName.ToUpper = "REBEX.FTP.DLL" Then Continue While
        If WrkLocalName.ToUpper = "REBEX.SFTP.DLL" Then Continue While
        If WrkLocalName.ToUpper = "REBEX.NETWORKING.DLL" Then Continue While
        If WrkLocalName.ToUpper = "REBEX.COMMON.DLL" Then Continue While

        WrkLocalDate = System.IO.File.GetLastWriteTime(en.Current)
        'Matching File - check time if different then update it
        I = LookupRemote(WrkDirNo, WrkLocalName)
        If I >= 0 Then
          WrkFileInfo = My.Computer.FileSystem.GetFileInfo(en.Current)
          myDr = ds.Tables(0).NewRow
          myDr("FileType") = WrkDirType
          myDr("PathName") = WrkDirName
          myDr("FileName") = WrkRemoteName(I)
          myDr("RemoteDate") = WrkRemoteDate(I)
          myDr("RemoteSize") = WrkRemoteSize(I)
          myDr("LocalDate") = Format(WrkLocalDate, "M/d/yyyy H:mm")
          myDr("LocalSize") = WrkFileInfo.Length
          myDr("Action") = "UPDATE"
          myDr("DirNo") = WrkDirNo
          WrkRemoteAction(I) = myDr("Action")
          'Check for time difference
          If WrkRemoteDate(I) <> myDr("LocalDate") Then
            WrkLocalAdjDate = DateAdd(DateInterval.Hour, 1, WrkLocalDate)
            WrkSame = False
            If WrkRemoteDate(I) = Format(WrkLocalAdjDate, "M/d/yyyy H:mm") Then
              WrkSame = True
            End If
            If Not WrkSame Then
              WrkLocalAdjDate = DateAdd(DateInterval.Hour, -1, WrkLocalDate)
              If WrkRemoteDate(I) = Format(WrkLocalAdjDate, "M/d/yyyy H:mm") Then
                WrkSame = True
              End If
            End If
            If Not WrkSame Then
              ds.Tables(0).Rows.Add(myDr)
              WrkTotalSize = WrkTotalSize + WrkRemoteSize(I)
            End If
          End If
          '         I = I + 1
          Continue While
        End If
        'Local File exists but missing Remote File (Delete)
        If I < 0 Then
          WrkFileInfo = My.Computer.FileSystem.GetFileInfo(en.Current)
          myDr = ds.Tables(0).NewRow
          myDr("FileType") = WrkDirType
          myDr("PathName") = WrkDirName
          myDr("FileName") = WrkLocalName
          myDr("RemoteDate") = ""
          myDr("RemoteSize") = 0
          myDr("LocalDate") = Format(WrkLocalDate, "M/d/yyyy H:mm")
          myDr("LocalSize") = WrkFileInfo.Length
          myDr("Action") = "DELETE"
          myDr("DirNo") = WrkDirNo
          ds.Tables(0).Rows.Add(myDr)
          Continue While
        End If
      End If
    End While

NextMissing:
    'Missing Remote File (Add)
    For I = 0 To WrkRemoteName.GetUpperBound(0)
      If WrkRemoteAction(I) & "" <> "" Then Continue For
      If WrkDirNo <> WrkRemoteDirNo(I) Then Continue For
      WrkSelect = "filename='" & WrkRemoteName(I) & "' and dirno=" & WrkRemoteDirNo(I)
      drSel = ds.Tables(0).Select(WrkSelect)
      If drSel.GetUpperBound(0) = -1 Then
        'EXE & CONFIG must be installed app in order to add it.
        PosApp = -1
        PosData = InStr(WrkRemoteName(I), ".exe", CompareMethod.Text)
        WrkApp = Mid(WrkRemoteName(I), 1, 2)
        If PosData > 0 Then
          'A_, GE & Version program(s) are added regardless of apps installed 
          If Mid(WrkRemoteName(I), 1, 2) = "A_" Or Mid(WrkRemoteName(I), 1, 2) = "GE" Or Mid(WrkRemoteName(I), 1, 7) = "Version" Then
            PosApp = 1
          Else
            PosApp = InStr(MyApps, WrkApp, CompareMethod.Text)
          End If
        End If
        PosData = InStr(WrkRemoteName(I), ".config", CompareMethod.Text)
        If PosData > 0 Then
          PosApp = InStr(MyApps, WrkApp, CompareMethod.Text)
        End If
        'Only Add these file groups if installed otherwise install everything else
        Select Case WrkApp
          Case "AR", "AP", "BD", "FA", "GL", "MF", "MR", "PK", "PO", "PR"
            PosApp = 0
            PosData = InStr(MyApps, WrkApp, CompareMethod.Text)
            If PosData > 0 Then PosApp = 1
          Case Else
            'Only allow adds if at least 1 app is installed
            If Len(MyApps) > 0 Then
              If PosData = 0 Then
                PosData = InStr(WrkRemoteName(I), ".dll", CompareMethod.Text)
                If PosData > 0 Then PosApp = 1
              End If
              If PosData = 0 Then
                PosData = InStr(WrkRemoteName(I), ".rpt", CompareMethod.Text)
                If PosData > 0 Then PosApp = 1
              End If
              If PosData = 0 Then
                PosData = InStr(WrkRemoteName(I), ".chm", CompareMethod.Text)
                If PosData > 0 Then PosApp = 1
              End If
            End If
        End Select

        If PosApp > 0 Then
          myDr = ds.Tables(0).NewRow
          myDr("FileType") = WrkDirType
          myDr("PathName") = WrkDirName
          myDr("FileName") = WrkRemoteName(I)
          myDr("RemoteDate") = WrkRemoteDate(I)
          myDr("RemoteSize") = WrkRemoteSize(I)
          myDr("LocalDate") = ""
          myDr("LocalSize") = 0
          myDr("Action") = "ADD"
          myDr("DirNo") = WrkDirNo
          WrkRemoteAction(I) = myDr("Action")
          ds.Tables(0).Rows.Add(myDr)
          WrkTotalSize = WrkTotalSize + WrkRemoteSize(I)
        End If
      End If
    Next

  End Sub
  Private Function LookupRemote(ByVal DirNo As Integer, ByVal Name As String) As Integer
    Dim I As Integer

    For I = 0 To WrkRemoteName.GetUpperBound(0)
      If WrkRemoteDirNo(I) = 0 Then Exit For
      If DirNo = WrkRemoteDirNo(I) And Name.ToUpper = WrkRemoteName(I).ToUpper Then
        Return I
      End If
    Next
    Return -1
  End Function
  Public Sub ApplyFiles()
    Dim WrkFTP As New Rebex.Net.Ftp
    Dim WrkConnection As Rebex.Net.FtpConnectionState
    Dim WrkFile As String
    Dim WrkFileInfo As FileInfo
    Dim WrkRemoteSize As Integer
    Dim WrkDataPath As String
    Dim WrkInUse As Boolean
    Dim I As Integer

    WrkInUse = False
    If ds.Tables(0).Rows.Count = 0 Then Exit Sub

    If MyDebug Then
      WrkDataPath = GetDataPath()
      WrkFTP.LogWriter = New Rebex.FileLogWriter(WrkDataPath & "rebexlog.txt", Rebex.LogLevel.Debug)
    End If

    WrkFTP.Settings.SslAcceptAllCertificates = cCertAccept
    Try
      WrkFTP.Connect(cHostIP, cPort, SslMode.Explicit)
    Catch
      Exit Sub
    End Try
    WrkFTP.Login(cRemoteUser, cRemotePassword)
    WrkPct = 0
    SavePct = 0

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Applying Updates"
    If MyAutomate Then
      myFrmProgress.Text = "Applying Updates (Automatic mode)"
      myFrmProgress.LblMsg.Text = String.Empty
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    'Programs
    Try
      WrkFTP.ChangeDirectory(cDirRoot)
    Catch
      Exit Sub
    End Try
    WrkFTP.ChangeDirectory(MyFTPDir)
    WrkFTP.TransferMode = FtpTransferMode.Zlib
    WrkFTP.TransferType = FtpTransferType.Binary
    WrkFTP.Passive = True

    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If .Item("FileType") = "Program" Then
          WrkFile = .Item("pathname") & .Item("FileName")
          If IsFileOpen(WrkFile) Then
            If Not MyAutomate Then
              WrkInUse = True
              '              MsgBox(.Item("FileName") & " is in use and will be skipped", MsgBoxStyle.Exclamation, "Cannot update file")
            Else
              sb.AppendLine(.Item("FileName") & " was skipped (in use)")
            End If
            Continue For
          End If
          If .Item("RemoteSize") > 0 Then
            WrkConnection = WrkFTP.GetConnectionState()
            If Not WrkConnection.Connected Then
              If Not MyAutomate Then
                MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Disconnected")
              Else
                sb.AppendLine("Disconnected, Code: " & WrkConnection.NativeErrorCode)
              End If
              Exit Sub
            End If
            Try
              WrkFTP.GetFile(.Item("FileName"), WrkFile)
            Catch
              Exit Sub
            End Try
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName") & " " & .Item("RemoteDate"))
            End If
            WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
            WrkFileInfo.LastWriteTime = .Item("remotedate")
            WrkRemoteSize = WrkRemoteSize + .Item("RemoteSize")
          Else
            My.Computer.FileSystem.DeleteFile(WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName"))
            End If
          End If
          With myFrmProgress
            If WrkTotalSize > 0 Then
              WrkPct = (WrkRemoteSize / WrkTotalSize) * 100
            End If
            If SavePct <> WrkPct Then
              .ProgBar1.Value = WrkPct
              .Refresh()
              SavePct = WrkPct
              Application.DoEvents()
            End If
          End With
        End If
      End With
    Next

    'Reports
    WrkFTP.ChangeDirectory("Reports")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If .Item("FileType") = "Report" Then
          WrkFile = .Item("pathname") & .Item("FileName")
          If .Item("RemoteSize") > 0 Then
            WrkFTP.GetFile(.Item("FileName"), WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName") & " " & .Item("RemoteDate"))
            End If
            WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
            WrkFileInfo.LastWriteTime = .Item("remotedate")
            WrkRemoteSize = WrkRemoteSize + .Item("RemoteSize")
          Else
            WrkFile = .Item("pathname") & .Item("FileName")
            My.Computer.FileSystem.DeleteFile(WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName"))
            End If
          End If
          With myFrmProgress
            If WrkTotalSize > 0 Then
              WrkPct = (WrkRemoteSize / WrkTotalSize) * 100
            End If
            If SavePct <> WrkPct Then
              .ProgBar1.Value = WrkPct
              .Refresh()
              SavePct = WrkPct
              Application.DoEvents()
            End If
          End With
        End If
      End With
    Next

    'Help 
    WrkFTP.ChangeDirectory("..")
    WrkFTP.ChangeDirectory("GemsHelp")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If .Item("FileType") = "Help" Then
          WrkFile = .Item("pathname") & .Item("FileName")
          If .Item("RemoteSize") > 0 Then
            WrkFTP.GetFile(.Item("FileName"), WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName") & " " & .Item("RemoteDate"))
            End If
            WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
            WrkFileInfo.LastWriteTime = .Item("remotedate")
            WrkRemoteSize = WrkRemoteSize + .Item("RemoteSize")
          Else
            WrkFile = .Item("pathname") & .Item("FileName")
            My.Computer.FileSystem.DeleteFile(WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName"))
            End If
          End If
          With myFrmProgress
            If WrkTotalSize > 0 Then
              WrkPct = (WrkRemoteSize / WrkTotalSize) * 100
            End If
            If SavePct <> WrkPct Then
              .ProgBar1.Value = WrkPct
              .Refresh()
              SavePct = WrkPct
              Application.DoEvents()
            End If
          End With
        End If
      End With
    Next

    'Custom 
    WrkFTP.ChangeDirectory("..")
    WrkFTP.ChangeDirectory(MyTownNo)
    WrkFTP.ChangeDirectory("Reports")
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If .Item("FileType") = "Custom" Then
          WrkFile = .Item("pathname") & .Item("FileName")
          If .Item("RemoteSize") > 0 Then
            WrkFTP.GetFile(.Item("FileName"), WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName") & " " & .Item("RemoteDate"))
            End If
            WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
            WrkFileInfo.LastWriteTime = .Item("remotedate")
            WrkRemoteSize = WrkRemoteSize + .Item("RemoteSize")
          Else
            WrkFile = .Item("pathname") & .Item("FileName")
            My.Computer.FileSystem.DeleteFile(WrkFile)
            If MyAutomate Then
              sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName"))
            End If
          End If
          With myFrmProgress
            If WrkTotalSize > 0 Then
              WrkPct = (WrkRemoteSize / WrkTotalSize) * 100
            End If
            If SavePct <> WrkPct Then
              .ProgBar1.Value = WrkPct
              .Refresh()
              SavePct = WrkPct
              Application.DoEvents()
            End If
          End With
        End If
      End With
    Next

    '2nd Custom 
    'If MyCustom <> String.Empty Then
    '  WrkFTP.ChangeDirectory("..")
    '  WrkFTP.ChangeDirectory("Reports" & MyCustom)
    '  For I = 0 To ds.Tables(0).Rows.Count - 1
    '    With ds.Tables(0).Rows(I)
    '      If .Item("FileType") = "Custom2" Then
    '        WrkFile = .Item("pathname") & .Item("FileName")
    '        If .Item("RemoteSize") > 0 Then
    '          WrkFTP.GetFile(.Item("FileName"), WrkFile)
    '          If MyAutomate Then
    '            sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName") & " " & .Item("RemoteDate"))
    '          End If
    '          WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
    '          WrkFileInfo.LastWriteTime = .Item("remotedate")
    '          WrkRemoteSize = WrkRemoteSize + .Item("RemoteSize")
    '        Else
    '          WrkFile = .Item("pathname") & .Item("FileName")
    '          My.Computer.FileSystem.DeleteFile(WrkFile)
    '          If MyAutomate Then
    '            sb.AppendLine(.Item("Action") & " " & .Item("FileType") & " " & .Item("FileName"))
    '          End If
    '        End If
    '        With myFrmProgress
    '          If WrkTotalSize > 0 Then
    '            WrkPct = (WrkRemoteSize / WrkTotalSize) * 100
    '          End If
    '          If SavePct <> WrkPct Then
    '            .ProgBar1.Value = WrkPct
    '            .Refresh()
    '            SavePct = WrkPct
    '            Application.DoEvents()
    '          End If
    '        End With
    '      End If
    '    End With
    '  Next
    'End If

    myFrmProgress.Close()
    WrkFTP.Disconnect()
    Application.DoEvents()
    If Not MyAutomate Then
      If WrkInUse Then
        MsgBox("WARNING", MsgBoxStyle.Information, "Some items are in use. Check Updates to view.")
      Else
        MsgBox("DONE!", MsgBoxStyle.Information, "Items have been applied")
      End If
    Else
      sb.AppendLine("DONE!")
    End If
    ds.Clear()

  End Sub
  Public Sub AutomaticUpdate()
    Dim WrkCancel As Boolean

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    CheckFiles(WrkCancel)
    If Not WrkCancel Then
      If ds.Tables(0).Rows.Count > 0 Then
        ApplyFiles()
      Else
        sb.AppendLine("All programs are current")
      End If
    End If
    WriteLogAuto()
    Windows.Forms.Cursor.Current = Cursors.Default
  End Sub
  Private Sub WriteLogAuto()
    Dim WrkPath As String
    Dim WrkProgName As String
    Dim WrkTimestamp As String

    WrkPath = GetDataPath() & "Logs\"
    WrkProgName = GetProgramName() & " Auto"
    WrkProgName = Replace(WrkProgName, ".exe", "")
    WrkTimestamp = Format(Date.Now, "MMddyyyy HHmmss")
    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(WrkPath &
      "-" & WrkProgName & "-" & WrkTimestamp & ".Log")
    sw.WriteLine(WrkProgName)
    sw.WriteLine("")
    sw.WriteLine(sb.ToString)
    sw.Close()
  End Sub
  Public Sub HotlineUpdate(ByRef Cancel As Boolean)
    Dim WrkFTP As New Rebex.Net.Ftp
    Dim WrkConnection As Rebex.Net.FtpConnectionState
    Dim WrkFile As String
    Dim WrkFileInfo As FileInfo
    Dim WrkHotline As String
    Dim WrkDirName As String
    Dim WrkMsg As String
    Dim WrkDate As Date
    Dim SaveWriteTime As Date

    Cancel = False
    WrkFTP.Settings.SslAcceptAllCertificates = cCertAccept
    Try
      WrkFTP.Connect(cHostIP, cPort, SslMode.Explicit)
    Catch
    End Try

    WrkConnection = WrkFTP.GetConnectionState()
    If Not WrkConnection.Connected Then
      MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Cannot connect to FTP Server")
      Cancel = True
      Exit Sub
    End If
    WrkFTP.Login(cRemoteUser, cRemotePassword)
    WrkFTP.TransferType = FtpTransferType.Binary
    WrkFTP.Passive = True

    'RWA
    WrkHotline = MyFrmMain.TxtHotline.Text
    WrkDirName = GetDataPath()
    WrkFile = String.Empty

    If MyFrmMain.RbHotProgram.Checked Then
      WrkFTP.ChangeDirectory(cDirRoot)
      WrkFTP.ChangeDirectory(MyFTPDir)
      WrkFile = WrkDirName & WrkHotline
    End If
    If MyFrmMain.RbHotReport.Checked Then
      WrkFTP.ChangeDirectory(cDirRoot)
      WrkFTP.ChangeDirectory(MyFTPDir)
      WrkFTP.ChangeDirectory("Reports")
      WrkFile = WrkDirName & "Reports\" & WrkHotline
    End If
    If MyFrmMain.RbHotCustom.Checked Then
      WrkFTP.ChangeDirectory(cDirRoot)
      WrkFTP.ChangeDirectory(MyFTPDir)
      WrkFTP.ChangeDirectory(MyTownNo)
      WrkFTP.ChangeDirectory("Reports")
      WrkFile = WrkDirName & MyTownNo & "\Reports\" & WrkHotline
    End If

    If Not WrkFTP.FileExists(WrkHotline) Then
      MsgBox("Cannot find matching file. Check with Hotline", MsgBoxStyle.Information, "Update cancelled")
      Exit Sub
    End If

    WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
    SaveWriteTime = WrkFileInfo.LastWriteTime
    If IsFileOpen(WrkFile) Then
      MsgBox(WrkHotline & " is in use", MsgBoxStyle.Exclamation, "Cannot update file")
      Exit Sub
    End If

    WrkFTP.GetFile(WrkHotline, WrkFile)
    WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
    WrkDate = WrkFTP.GetFileDateTime(WrkHotline)
    WrkFileInfo.LastWriteTime = DateAdd(DateInterval.Hour, cGMTOffset, WrkDate)
    WrkMsg = WrkHotline & " " & SaveWriteTime & " has been replaced with " & WrkFileInfo.LastWriteTime

    MsgBox(WrkMsg, MsgBoxStyle.Information, "Update has finished")

  End Sub
  Public Sub DirectoryUpdate(ByVal DirName As String, ByRef Cancel As Boolean)
    Dim WrkFTP As New Rebex.Net.Ftp
    Dim WrkConnection As Rebex.Net.FtpConnectionState
    Dim WrkFile As String
    Dim WrkFileInfo As FileInfo
    Dim WrkFileList As FtpItemCollection
    Dim WrkItem As FtpItem
    Dim WrkName As String
    Dim WrkLocalDate As Date
    Dim WrkLocalDateStr As String
    Dim WrkLocalAdjDate As Date
    Dim WrkRemoteSize As Integer
    Dim WrkRemoteDate As String
    Dim WrkDirName As String
    Dim I As Integer

    Cancel = False
    WrkFTP.Settings.SslAcceptAllCertificates = cCertAccept
    Try
      WrkFTP.Connect(cHostIP, cPort, SslMode.Explicit)
    Catch
    End Try

    WrkConnection = WrkFTP.GetConnectionState()
    If Not WrkConnection.Connected Then
      MsgBox("Code: " & WrkConnection.NativeErrorCode, MsgBoxStyle.Critical, "Cannot connect to FTP Server")
      Cancel = True
      Exit Sub
    End If
    WrkFTP.Login(cRemoteUser, cRemotePassword)

    'Programs/RWA
    WrkDirName = GetDataPath() & DirName & "\"
    WrkFTP.ChangeDirectory(cDirRoot)
    WrkFTP.ChangeDirectory(MyFTPDir)
    WrkFTP.ChangeDirectory(DirName)
    WrkFTP.TransferType = FtpTransferType.Binary
    WrkFTP.Passive = True

    'RWA
    WrkFileList = WrkFTP.GetList()
    For Each WrkItem In WrkFileList
      WrkName = WrkItem.Name ' .ToUpper()
      WrkRemoteSize = WrkItem.Length
      WrkRemoteDate = Format(WrkItem.Modified, "M/d/yyyy H:mm")

      WrkFile = WrkDirName & WrkName
      If WrkRemoteSize > 0 Then
        'Check for time difference
        WrkLocalDate = System.IO.File.GetLastWriteTime(WrkFile)
        WrkLocalDateStr = Format(WrkLocalDate, "M/d/yyyy H:mm")
        If WrkRemoteDate(I) <> WrkLocalDateStr Then
          WrkLocalAdjDate = DateAdd(DateInterval.Hour, 1, WrkLocalDate)
          'Include if time difference isn't exactly one hour (daylight saving)
          If WrkRemoteDate(I) <> Format(WrkLocalAdjDate, "M/d/yyyy H:mm") Then
            WrkFTP.GetFile(WrkName, WrkFile)
            WrkFileInfo = My.Computer.FileSystem.GetFileInfo(WrkFile)
            WrkFileInfo.LastWriteTime = WrkRemoteDate
          End If
        End If
      Else
        WrkFile = WrkDirName & WrkName
        My.Computer.FileSystem.DeleteFile(WrkFile)
      End If
    Next

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
  Public Function CheckDirExists(ByVal DirName As String) As Boolean

    CheckDirExists = False
    If System.IO.Directory.Exists(DirName) Then
      CheckDirExists = True
    End If

    Return CheckDirExists

  End Function
End Module
