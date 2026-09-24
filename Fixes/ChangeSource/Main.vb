Imports System.IO
Module Main
  Public MyAppSettings As AppSettings
  Public MyUtils As Utils.Util
  Public ds As DataSet = New DataSet
  Public WrkNumPgms As Integer
  Public WrkNumMods As Integer
  Public Sub ShowFolders(ByVal FolderName As String)
    Dim s() As String
    Dim SaveNumMods As Integer

    s = System.IO.Directory.GetDirectories(MyAppSettings.FilePath & "\" & FolderName)

    Dim en As System.Collections.IEnumerator

    en = s.GetEnumerator

    While en.MoveNext
      SaveNumMods = WrkNumMods
      ShowFiles(CStr(en.Current))
      If SaveNumMods <> WrkNumMods Then
        WrkNumPgms = WrkNumPgms + 1
      End If
    End While
  End Sub
  Private Sub ShowFiles(ByVal DirName As String)
    Dim d() As String
    Dim PosData As Integer
    Dim Good As Boolean

    PosData = InStr(DirName, ".vs")
    If PosData > 0 Then Exit Sub

    d = System.IO.Directory.GetFiles(DirName)

    Dim en As System.Collections.IEnumerator

    en = d.GetEnumerator

    While en.MoveNext
      PosData = InStr(CStr(en.Current), "MyData.vb")
      'Skip all except MyData
      If PosData = 0 Then Continue While

      Good = ReadMyData(CStr(en.Current))
      If Good Then
        WrkNumMods = WrkNumMods + 1
      End If
    End While
  End Sub

  Private Function ReadMyData(ByVal FileName As String) As Boolean
    Dim Oldlines() As String = System.IO.File.ReadAllLines(FileName)
    Dim lines() As String
    Dim Pos As Integer
    Dim I As Integer
    Dim J As Integer
    Dim Good As Boolean

    Good = False
    ReDim lines(Oldlines.GetUpperBound(0) - 1)

    For I = 0 To Oldlines.GetUpperBound(0) - 1
      lines(I) = Oldlines(I)
      Pos = InStr(Oldlines(I), "Public Sub GetOneRecordP", CompareMethod.Text)
      J = 0
      If Pos > 0 Then
NextRec:
        J = J + 1
        lines(I + J) = Oldlines(I + J)
        Pos = InStr(Oldlines(I + J), "RecordNotFound = True", CompareMethod.Text)
        If Pos = 0 Then GoTo NextRec
        lines(I + J + 1) = "        ClearFields()"
        Exit For
      End If
    Next

    J = I + J + 1
    ReDim Preserve lines(lines.GetUpperBound(0) + 1)
    '    Pos = InStr(Oldlines(I + J), "Public Sub PutFields", CompareMethod.Text)
    '    If Pos = 0 Then GoTo NextRec

    For I = J To Oldlines.GetUpperBound(0) - 1
      lines(I + 1) = Oldlines(I)
      Pos = InStr(Oldlines(I + J), "Public Property", CompareMethod.Text)
      If Pos > 0 Then

      End If
    Next
    'System.IO.File.WriteAllLines(FileName, lines)

    Dim myDr As Data.DataRow
    myDr = ds.Tables(0).NewRow
    myDr("SourceName") = FileName
    '    myDr("FileName") = Trim(strBuffer)
    ds.Tables(0).Rows.Add(myDr)

  End Function
  Public Sub GetAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sr As IO.StreamReader
    Dim WrkXMLPath As String
    Dim WrkProgName As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
    If MyUtils.CheckFileExists(WrkXMLPath) Then
      sr = New IO.StreamReader(WrkXMLPath)
      MyAppSettings = New AppSettings
      MyAppSettings = CType(xs.Deserialize(sr), AppSettings)
      sr.Close()
    Else
      MyAppSettings = New AppSettings
    End If
  End Sub
  Public Sub SaveAppSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    WrkProgName = Replace(MyUtils.GetProgramName, ".exe", "")
    WrkXMLPath = MyUtils.GetDataPath() & "Settings\" & WrkProgName & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
  End Sub
End Module
