Imports System.IO
Imports System.text
Module Main
Public ds As DataSet = New DataSet
Public dsDtl As DataSet = New DataSet
Public MyFileName As String
Dim WrkDescr(100) As String
Dim WrkCount(100) As Integer
Public myStartDate As Date
Public myEndDate As Date
Public MyFrmMainB As FrmMainB
Public Sub ReadDir(ByVal WrkFileExport As String)
  Dim en As System.Collections.IEnumerator
  Dim myDr As Data.DataRow
  Dim s() As String
  Dim WrkPath As String
  Dim WrkFileName As String
  Dim WrkLen As Integer
  Dim WrkError As String
  Dim WrkTotCount As Integer
  Dim Pos As Integer
  Dim Pos2 As Integer
  Dim J As Integer
  Dim K As Integer

  Array.Clear(WrkDescr, 0, 100)
  Array.Clear(WrkCount, 0, 100)
  FrmMain.LblTotCount.Text = ""
  WrkPath = LCase(GetDataPath())
  If Right(WrkPath, 4) = "rwa\" Then
    WrkLen = Len(WrkPath)
    WrkPath = Mid(WrkPath, 1, WrkLen - 4) & "logs\"
  End If

  s = System.IO.Directory.GetFiles(WrkPath, "*.log")

  en = s.GetEnumerator
  While en.MoveNext
    WrkFileName = Replace(en.Current, WrkPath, "")
    Pos = InStr(WrkFileName, "Auto")
    If Pos = 0 Then
      WrkError = GetErrorDesc(en.Current)
      If WrkError <> String.Empty Then
        K = LookupDesc(WrkError)
        WrkDescr(K) = WrkError
        WrkCount(K) = WrkCount(K) + 1
        myDr = dsDtl.Tables(0).NewRow
        myDr("Descr") = WrkError
        Pos = InStr(WrkFileName, "-")
        myDr("User") = Mid(WrkFileName, 1, Pos - 1)
        Pos2 = InStr(Pos + 1, WrkFileName, "-")
        myDr("Program") = Mid(WrkFileName, Pos + 1, Pos2 - Pos - 1)
        myDr("Date") = Replace(Mid(WrkFileName, Pos2 + 1, 99), ".Log", "")
        dsDtl.Tables(0).Rows.Add(myDr)
      End If
    End If
  End While

  WrkTotCount = 0
  For J = 0 To 100
    If WrkCount(J) = 0 Then Exit For
    myDr = ds.Tables(0).NewRow
    myDr("Descr") = WrkDescr(J)
    myDr("Count") = WrkCount(J)
    WrkTotCount = WrkTotCount + WrkCount(J)
    ds.Tables(0).Rows.Add(myDr)
  Next
  FrmMain.LblTotCount.Text = WrkTotCount

  If WrkFileExport <> String.Empty Then
    ExportLogs(WrkFileExport)
  End If

End Sub
Private Function GetErrorDesc(ByVal FileName As String) As String
	Dim sr As StreamReader
	Dim strBuffer As String
	Dim WrkTimeStamp As Date
	Dim I As Integer

	WrkTimeStamp = System.IO.File.GetLastWriteTime(FileName).Date
	If WrkTimeStamp < myStartDate Then Return String.Empty
	If WrkTimeStamp > myEndDate Then Return String.Empty

	sr = New StreamReader(FileName)
	I = 0
	strBuffer = sr.ReadLine

NextLine:
  strBuffer = sr.ReadLine
	If sr.EndOfStream Then
		Return String.Empty
	End If
	I = I + strBuffer.Length
	If strBuffer <> String.Empty Then
    strBuffer = Replace(strBuffer, Chr(34), "")
    strBuffer = Replace(strBuffer, Chr(39), "")
    Return strBuffer
	End If
GoTo NextLine

End Function
Private Function LookupDesc(ByVal Desc As String) As Integer
		 Dim I As Integer

		 For I = 0 To WrkDescr.GetUpperBound(0)
			 If WrkDescr(I) & "" = "" Then
				 Return I
			 End If
			 If Desc = WrkDescr(I) Then
				 Return I
			 End If
		Next

End Function
Private Sub ExportLogs(ByVal WrkFileName As String)
	Dim sw As StreamWriter
	Dim sb As StringBuilder
	Dim WrkPath As String
	Dim I As Integer

	WrkPath = LCase(GetDataPath())
	sw = New StreamWriter(WrkPath & WrkFileName)
	sb = New StringBuilder

	For I = 0 To ds.Tables(0).Rows.Count - 1
		sb = New StringBuilder
		sb.Append(ds.Tables(0).Rows(I).Item("descr"))
		sb.Append(",")
		sb.Append(ds.Tables(0).Rows(I).Item("count"))
		sw.WriteLine(sb.ToString)
		sb = Nothing
	Next
	sw.Flush()
	sw.Close()

End Sub
End Module
