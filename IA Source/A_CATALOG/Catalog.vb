Imports System.IO
Module Catalog

Dim sw As StreamWriter
Dim sr As StreamReader
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SubDir", Type.GetType("System.String"))
      .Columns.Add("FileName", Type.GetType("System.String"))
      .Columns.Add("LocalDate", Type.GetType("System.DateTime"))
      .Columns.Add("LocalVersion", Type.GetType("System.String"))
      .Columns.Add("RemoteDate", Type.GetType("System.DateTime"))
      .Columns.Add("RemoteVersion", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Public Sub ShowGEMSFiles()
  Dim WrkFileName As String
  Dim WrkPgmName As String
  Dim WrkDirName As String
  Dim WrkRptDirName As String
  Dim WrkTownDirName As String

  BuildDS()

  WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
  Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

  With myFileVersionInfo
    WrkPgmName = .InternalName
  End With

  'Remove program name from path
  WrkDirName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)
  sw = New StreamWriter(WrkDirName & "A_Catalog.Txt")
  ReadDir(WrkDirName)

  WrkRptDirName = WrkDirName & "Reports\"
  ReadDir(WrkRptDirName)

  If MyTownNo <> "" Then
    WrkTownDirName = WrkDirName & MyTownNo & "\Reports\"
    ReadDir(WrkTownDirName)
  End If

  sw.Close()
  MsgBox("send file (A_CATALOG.TXT) to support", MsgBoxStyle.Information, "Export completed")
End Sub
Private Sub ReadDir(ByVal WrkDirName As String)
  Dim en As System.Collections.IEnumerator
  Dim d() As String
  Dim PosData As Integer
  Dim WrkDate As Date
  Dim WrkFileName2 As String

  d = System.IO.Directory.GetFiles(WrkDirName)
  en = d.GetEnumerator
  While en.MoveNext
     PosData = InStr(CStr(en.Current), ".exe")
     If PosData = 0 Then
       PosData = InStr(CStr(en.Current), ".dll")
     End If
     If PosData = 0 Then
       PosData = InStr(CStr(en.Current), ".rpt")
     End If
     If PosData > 0 Then
       WrkDate = System.IO.File.GetLastWriteTime(en.Current)
       Dim myFileVersionInfo2 As FileVersionInfo = FileVersionInfo.GetVersionInfo(en.Current)
      'Remove path name from path
       WrkFileName2 = Replace(en.Current, WrkDirName, "", , , CompareMethod.Text)
       sw.Write(WrkFileName2 & ",")
       sw.Write(WrkDate & ",")
       sw.Write(myFileVersionInfo2.FileVersion)
       sw.WriteLine()
     End If
  End While

End Sub
Public Sub CompareGEMSFiles()
  Dim WrkFileName As String
  Dim WrkPgmName As String
  Dim WrkDirName As String
  Dim WrkRptDirName As String
  Dim WrkTownDirName As String

  WrkFileName = System.Reflection.Assembly.GetExecutingAssembly.Location
  Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(WrkFileName)

  With myFileVersionInfo
    WrkPgmName = .InternalName
  End With

  'Remove program name from path
  WrkDirName = Replace(WrkFileName, WrkPgmName, "", , , CompareMethod.Text)
  sr = New StreamReader(WrkDirName & "A_Catalog.Txt")
  CompareDir(WrkDirName)

  WrkRptDirName = WrkDirName & "Reports\"
  CompareDir(WrkRptDirName)

  If MyTownNo <> "" Then
    WrkTownDirName = WrkDirName & MyTownNo & "\Reports\"
    CompareDir(WrkTownDirName)
  End If

  sr.Close()
End Sub
Private Sub CompareDir(ByVal WrkDirName As String)
  Dim en As System.Collections.IEnumerator
  Dim d() As String
  Dim PosData As Integer
  Dim PosStart As Integer
  Dim WrkFileName2 As String
  Dim WrkDate As Date
  Dim WrkDate2 As Date
  Dim NoDate As Date
  Dim myDr As Data.DataRow
  Dim WrkStr As String
  Dim WrkFileMatched As Boolean
  Dim WrkFileSame As Boolean
  Dim WrkVersion As String
  Dim WrkRemoteFileName As String

  d = System.IO.Directory.GetFiles(WrkDirName)
  WrkFileMatched = True
  WrkStr = ""

  en = d.GetEnumerator
  While en.MoveNext
CheckNextFile:
     WrkFileSame = False
     PosData = InStr(CStr(en.Current), ".exe")
     If PosData = 0 Then
       PosData = InStr(CStr(en.Current), ".dll")
     End If
     If PosData = 0 Then
       PosData = InStr(CStr(en.Current), ".rpt")
     End If
     If PosData > 0 Then
       Dim myFileVersionInfo2 As FileVersionInfo = FileVersionInfo.GetVersionInfo(en.Current)
      'Remove path name from path
       WrkFileName2 = Trim(Replace(en.Current, WrkDirName, "", , , CompareMethod.Text)) '.ToUpper)
       myDr = ds.Tables(0).NewRow
       myDr("SubDir") = WrkDirName
       myDr("FileName") = WrkFileName2
       myDr("LocalDate") = System.IO.File.GetLastWriteTime(en.Current)
       myDr("LocalVersion") = myFileVersionInfo2.FileVersion
       If WrkFileMatched Then
         WrkStr = sr.ReadLine()
       End If
       If WrkStr Is Nothing Then Exit Sub
       WrkFileMatched = False
       PosData = InStr(WrkStr, ",")
       WrkRemoteFileName = Mid(WrkStr, 1, PosData - 1) '.ToUpper
       'Matched File Name
       If WrkRemoteFileName.ToUpper = WrkFileName2.ToUpper Then
         WrkFileMatched = True
         PosStart = PosData + 1
         PosData = InStr(PosStart, WrkStr, ",")
         WrkDate = Mid(WrkStr, PosStart, PosData - PosStart)
         myDr("RemoteDate") = WrkDate
         WrkVersion = Trim(Mid(WrkStr, PosData + 1, 99))
         myDr("RemoteVersion") = WrkVersion
          'Same Version and Date/Time within 5 seconds? 
          WrkDate2 = System.IO.File.GetLastWriteTime(en.Current)
          If myFileVersionInfo2.FileVersion = "" Then
            If Math.Abs(DateDiff(DateInterval.Second, WrkDate, WrkDate2)) < 60 Then
              WrkFileSame = True
            End If
          Else
            If myFileVersionInfo2.FileVersion = WrkVersion Then
              WrkFileSame = True
            End If
          End If
       End If
       'Missing File Name  
       If WrkRemoteFileName < WrkFileName2 Then
         PosData = InStr(WrkStr, ",")
         WrkFileMatched = True
         myDr("FileName") = WrkRemoteFileName
         myDr("LocalDate") = NoDate
         myDr("LocalVersion") = ""
         PosStart = PosData + 1
         PosData = InStr(PosStart, WrkStr, ",")
         WrkDate = Mid(WrkStr, PosStart, PosData - PosStart)
         myDr("RemoteDate") = WrkDate
         WrkVersion = Trim(Mid(WrkStr, PosData + 1, 99))
         myDr("RemoteVersion") = WrkVersion
       End If
       If Not WrkFileSame Then
         ds.Tables(0).Rows.Add(myDr)
       End If
       If WrkRemoteFileName < WrkFileName2 Then
         GoTo CheckNextFile
       End If
     End If
  End While
End Sub
End Module
