Imports System.IO
Imports System.Runtime.CompilerServices.RuntimeHelpers
Imports System.Text
Module ImportData
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim sw As StreamWriter
  Dim WrkAcct(10000) As String
  Dim WrkType As String
  Dim WrkYear As Integer

  Public Sub Impdata()
    Dim WrkStream As FileStream = New FileStream(MyFrmFixB.LblAMSPath.Text, FileMode.Open, FileAccess.Read)
    Dim WrkStream2 As FileStream = New FileStream(MyFrmFixB.LblBaldPath.Text, FileMode.Open, FileAccess.Read)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim sr2 As StreamReader = New StreamReader(WrkStream2)
    Dim sArray() As String
    Dim WrkKey As String
    Dim strBuffer As String
    Dim J As Integer
    Dim Counter As Integer

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    J = -1

NextRec:
    strBuffer = sr2.ReadLine 'Skip Heading
    If Trim(strBuffer) = String.Empty Then
      strBuffer = sr.ReadLine
      sw = New StreamWriter(MyFrmFixB.LblNewPath.Text)
      sw.WriteLine(strBuffer)
      GoTo WriteFile
    End If
    sArray = Parse(strBuffer, ",")
    J = J + 1
    WrkAcct(J) = Mid(sArray(2), 3, 2) & sArray(3) & sArray(1)
    GoTo NextRec

WriteFile:
    Counter = Counter + 1
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      GoTo AllDone
    End If

    sArray = Parse(strBuffer, ",")
    WrkKey = sArray(7)
    If LookupKey(WrkKey) Then
      sw.WriteLine(strBuffer)
    End If

    With myFrmProgress
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        .ProgBar1.Value = WrkPct
        .LblMsg.Text = "Records processed: " & Counter
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
    GoTo WriteFile

AllDone:
    sw.Flush()
    sw.Close()
    myFrmProgress.Close()
  End Sub
  Private Function LookupKey(ByVal Key As String) As Boolean
    Dim I As Integer

    For I = 0 To WrkAcct.GetUpperBound(0)
      If Trim(WrkAcct(I)) = "" Then
        Return False
      End If
      If Trim(Key) = Trim(WrkAcct(I)) Then
        Return True
      End If
    Next

    Return False
  End Function
End Module
