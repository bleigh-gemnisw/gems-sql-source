Imports System.IO
Module Main
Public ds As DataSet = New DataSet
Public MyTimeStamp As Date
Public MyFileName As String
Public MyFileName2 As String
Public WrkNewer As Boolean
Public MySource As String
Public Sub ShowFolders(ByVal FolderName As String)
  Dim s() As String
  s = System.IO.Directory.GetDirectories(MySource & FolderName)

  Dim en As System.Collections.IEnumerator

  en = s.GetEnumerator

  While en.MoveNext
     ShowFiles(CStr(en.Current) & "\" & MyFileName)
  End While
End Sub
Private Sub ShowFiles(ByVal FileName As String)
  Dim myDr As Data.DataRow
  Dim Found As Boolean
  Dim WrkTimeStamp As Date

  Found = System.IO.File.Exists(FileName)
  If Found Then
    WrkTimeStamp = System.IO.File.GetLastWriteTime(FileName)
    If InStr(FileName, "System", CompareMethod.Text) > 0 Then
      Exit Sub
    End If
    myDr = ds.Tables(0).NewRow
    myDr("SourceName") = FileName
    myDr("TimeStamp") = Trim(WrkTimeStamp)
    myDr("Status") = ""
    If MyTimeStamp < WrkTimeStamp Then
      myDr("Status") = "Newer"
    End If
    If MyTimeStamp > WrkTimeStamp Then
      myDr("Status") = "Older"
    End If
    If InStr(FileName, "Utils") > 0 Then
      myDr("Status") = "Utils"
    End If
    ds.Tables(0).Rows.Add(myDr)
  End If

End Sub
End Module
