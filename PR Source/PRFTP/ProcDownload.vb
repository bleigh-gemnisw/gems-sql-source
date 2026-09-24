Imports System.Text
Imports System.IO
Module ProcDownload
  Dim WrkFilePath As String
  Dim WrkHost As String
  Dim WrkUser As String
  Dim WrkPassword As String
  Const cQuote As Char = Chr(34)
  Public Sub ProcDown()
    With MyFrmPRFTPB
      WrkHost = .TxtHost.Text
      WrkUser = .TxtUser.Text
      WrkPassword = .TxtPassword.Text
    End With

    With MyFrmPRFTPB
      If .RbDirect.Checked Then
        ExportDirect()
      End If
      If .RbQuarterly.Checked Then
        ExportQuarterly()
      End If
      If .RbFederal.Checked Then
        ExportFederal()
      End If
      If .RbState.Checked Then
        ExportState()
      End If
      If .RbCkhist.Checked Then
        ExportCKHIST()
      End If
    End With

  End Sub
  Public Sub ExportDirect()

    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmPRFTPB.LblFilePath.Text)
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim WrkTotal As Boolean
    Dim I As Integer
    Dim Counter As Integer

    GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "ddtran.txt", "DDTRAN", MyLibraryName)
    With MyFrmPRFTPB
      WrkTotal = .ChkDirectTotal.Checked
    End With
    WrkStream = New FileStream(MyUtils.GetDataPath & "ddtran.txt", FileMode.Open, FileAccess.Read)
    sr = New StreamReader(WrkStream)
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length

    If Not WrkTotal Or Mid(strBuffer, 1, 3) <> "627" Then
      Counter = Counter + 1
      sb = New StringBuilder
      sb.Append(strBuffer)
      sw.WriteLine(sb.ToString)
    End If

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    sw.Close()
    MyFrmProgress.Close()
    MsgBox(Counter & " records exported", MsgBoxStyle.Information, "Export is done")
  End Sub
  Public Sub ExportQuarterly()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmPRFTPB.LblFilePath.Text)
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer
    Dim Counter As Integer

    GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "wagedata.txt", "WAGEDATA", "QS36F")
    WrkStream = New FileStream(MyUtils.GetDataPath & "wagedata.txt", FileMode.Open, FileAccess.Read)
    sr = New StreamReader(WrkStream)
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length

    Counter = Counter + 1
    sb = New StringBuilder
    sb.Append(strBuffer)
    sw.WriteLine(sb.ToString)

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    sw.Close()
    MyFrmProgress.Close()
    MsgBox(Counter & " records exported", MsgBoxStyle.Information, "Export is done")
  End Sub
  Public Sub ExportFederal()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmPRFTPB.LblFilePath.Text)
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer
    Dim Counter As Integer

    GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "mmref.txt", "MMREF", "QS36F")
    WrkStream = New FileStream(MyUtils.GetDataPath & "mmref.txt", FileMode.Open, FileAccess.Read)
    sr = New StreamReader(WrkStream)
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length

    Counter = Counter + 1
    sb = New StringBuilder
    sb.Append(strBuffer)
    sw.WriteLine(sb.ToString)

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    sw.Close()
    MyFrmProgress.Close()
    MsgBox(Counter & " records exported", MsgBoxStyle.Information, "Export is done")
  End Sub
  Public Sub ExportState()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmPRFTPB.LblFilePath.Text)
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer
    Dim Counter As Integer

    GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "mmrefs.txt", "MMREFS", "QS36F")
    WrkStream = New FileStream(MyUtils.GetDataPath & "mmrefs.txt", FileMode.Open, FileAccess.Read)
    sr = New StreamReader(WrkStream)
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length

    Counter = Counter + 1
    sb = New StringBuilder
    sb.Append(strBuffer)
    sw.WriteLine(sb.ToString)

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    sw.Close()
    MyFrmProgress.Close()
    MsgBox(Counter & " records exported", MsgBoxStyle.Information, "Export is done")
  End Sub
  Public Sub ExportCKHIST()
    Dim sb As StringBuilder
    Dim sw As StreamWriter = New StreamWriter(MyFrmPRFTPB.LblFilePath.Text)
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim strBuffer As String
    Dim WrkFileSize As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim I As Integer
    Dim Counter As Integer

    GetFile(WrkHost, WrkUser, WrkPassword, MyUtils.GetDataPath & "ckhist.txt", "CKHIST", "QS36F")
    WrkStream = New FileStream(MyUtils.GetDataPath & "ckhist.txt", FileMode.Open, FileAccess.Read)
    sr = New StreamReader(WrkStream)
    MyFrmProgress = New FrmProgress
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    WrkFileSize = WrkStream.Length
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo Done
    End If

    I = I + strBuffer.Length

    Counter = Counter + 1
    sb = New StringBuilder
    sb.Append(Trim(Mid(strBuffer, 1, 7))) 'Empno
    sb.Append(",")
    sb.Append(Trim(Mid(strBuffer, 8, 1))) 'Porv
    sb.Append(",")
    sb.Append(cQuote)
    sb.Append(Trim(Mid(strBuffer, 40, 9))) 'Emname
    sb.Append(cQuote)
    sb.Append(",")
    sb.Append(Mid(strBuffer, 49, 7)) 'cknum
    sb.Append(",")
    sb.Append(Mid(strBuffer, 56, 6)) 'ckdate
    sb.Append(",")
    sb.Append(Mid(strBuffer, 63, 9)) 'ckamt
    sb.Append(",")
    sb.Append(Trim(Mid(strBuffer, 72, 1))) 'ckcode
    sb.Append(",")
    sb.Append(Mid(strBuffer, 97, 8)) 'chkdte
    sw.WriteLine(sb.ToString)

NextRec:
    With MyFrmProgress
      WrkPct = I / WrkFileSize
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo NextLine

Done:
    sr.Close()
    sw.Close()
    MyFrmProgress.Close()
    MsgBox(Counter & " records exported", MsgBoxStyle.Information, "Export is done")
  End Sub
End Module
