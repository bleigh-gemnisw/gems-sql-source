Imports System.IO
Module Main
  Public MyAppSettings As AppSettings
  Public MyUtils As Utils.Util
  Public ds As DataSet = New DataSet
  Public WrkSearch As String
  Public WrkSourceType As String
  Public WrkComments As Boolean
  Public WrkNumPgms As Integer
  Public WrkNumMods As Integer
  Public Sub ShowFolders(ByVal FolderName As String)
    Dim s() As String
    Dim en As System.Collections.IEnumerator
    Dim SaveNumMods As Integer

    s = System.IO.Directory.GetDirectories(MyAppSettings.FilePath & "\" & FolderName)
    en = s.GetEnumerator

    While en.MoveNext
      SaveNumMods = WrkNumMods
      If InStr(CStr(en.Current), "-") = 0 Then 'Omit directories with a "-" in them (backup copy)
        ShowFiles(CStr(en.Current))
        If SaveNumMods <> WrkNumMods Then
          WrkNumPgms = WrkNumPgms + 1
        End If
      End If
    End While
  End Sub
  Private Sub ShowFiles(ByVal DirName As String)
    Dim d() As String
    Dim en As System.Collections.IEnumerator
    Dim PosData As Integer
    Dim Good As Boolean

    d = System.IO.Directory.GetFiles(DirName)
    en = d.GetEnumerator

    While en.MoveNext
      'Skip designers
      PosData = InStr(CStr(en.Current), ".Designer")
      'Skip common.vb
      If PosData > 0 Then Continue While
      PosData = InStr(CStr(en.Current), "Common.vb")
      'Skip utils.vb
      If PosData > 0 Then Continue While
      PosData = InStr(CStr(en.Current), "Util.vb")
      If PosData > 0 Then Continue While
      'Skip utils.vb
      PosData = InStr(CStr(en.Current), "Utils.vb")
      If PosData > 0 Then Continue While

      Select Case WrkSourceType
        Case "VB"
          PosData = InStr(CStr(en.Current), ".vbproj")
          If PosData = 0 Then
            PosData = InStr(CStr(en.Current), ".vb")
            If PosData > 0 Then
              Good = ReadMyData(CStr(en.Current))
              If Good Then
                WrkNumMods = WrkNumMods + 1
              End If
            End If
          End If
          PosData = InStr(CStr(en.Current), ".vrproj")
          If PosData = 0 Then
            PosData = InStr(CStr(en.Current), ".vr")
            If PosData > 0 Then
              Good = ReadMyData(CStr(en.Current))
              If Good Then
                WrkNumMods = WrkNumMods + 1
              End If
            End If
          End If
        Case "XSD"
          PosData = InStr(CStr(en.Current), ".xsd")
          If PosData > 0 Then
            Good = ReadMyData(CStr(en.Current))
            If Good Then
              WrkNumMods = WrkNumMods + 1
            End If
          End If
        Case "PROJ"
          PosData = InStr(CStr(en.Current), ".vbproj")
          If PosData > 0 Then
            Good = ReadMyData(CStr(en.Current))
            If Good Then
              WrkNumMods = WrkNumMods + 1
            End If
          End If
      End Select
    End While
  End Sub

  Private Function ReadMyData(ByVal FileName As String) As Boolean
    Dim objStream As New FileStream(FileName, FileMode.Open)
    Dim objReader As New StreamReader(objStream)
    Dim strBuffer As String
    Dim PosData As Integer
    Dim Good As Boolean

    Good = False
NextLine:
    strBuffer = objReader.ReadLine
    If strBuffer Is Nothing Then
      objStream.Close()
      objReader.Close()
      Return Good
    End If

    If WrkComments Then
      If Mid(Trim(strBuffer), 1, 1) <> "'" Then GoTo NextLine 'Omit non comments
    Else
      If Mid(Trim(strBuffer), 1, 1) = "'" Then GoTo NextLine 'Omit comments
    End If

    If WrkSourceType = "VB" Or WrkSourceType = "XSD" Or WrkSourceType = "PROJ" Then
      PosData = InStr(strBuffer, WrkSearch, CompareMethod.Text)
      If PosData > 0 Then
        Dim myDr As Data.DataRow
        myDr = ds.Tables(0).NewRow
        FileName = Replace(FileName, MyAppSettings.FilePath & "\", "")
        myDr("SourceName") = FileName
        myDr("FileName") = Trim(strBuffer)
        ds.Tables(0).Rows.Add(myDr)
        Good = True
      End If
    Else
      PosData = InStr(strBuffer, "<OldToolsVersion", CompareMethod.Text)
      If PosData > 0 Then
        strBuffer = objReader.ReadLine
        PosData = InStr(strBuffer, "<TargetFrameworkVersion>", CompareMethod.Text)
        If PosData > 0 Then
          PosData = InStr(strBuffer, "<TargetFrameworkVersion>V4.8", CompareMethod.Text)
          If PosData = 0 Then
            Dim myDr As Data.DataRow
            myDr = ds.Tables(0).NewRow
            FileName = Replace(FileName, MyAppSettings.FilePath & "\", "")
            myDr("SourceName") = FileName
            myDr("FileName") = Trim(strBuffer)
            ds.Tables(0).Rows.Add(myDr)
            Good = True
          End If
        End If
      End If

      PosData = InStr(strBuffer, "<MyType>WindowsFormsWithCustomSubMain", CompareMethod.Text)
      If PosData > 0 Then
        strBuffer = objReader.ReadLine
        PosData = InStr(strBuffer, "<TargetFrameworkVersion>", CompareMethod.Text)
        If PosData > 0 Then
          PosData = InStr(strBuffer, "<TargetFrameworkVersion>V4.8", CompareMethod.Text)
          If PosData = 0 Then
            Dim myDr As Data.DataRow
            myDr = ds.Tables(0).NewRow
            FileName = Replace(FileName, MyAppSettings.FilePath & "\", "")
            myDr("SourceName") = FileName
            myDr("FileName") = Trim(strBuffer)
            ds.Tables(0).Rows.Add(myDr)
            Good = True
          End If
        End If
      End If
    End If
    GoTo NextLine

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
