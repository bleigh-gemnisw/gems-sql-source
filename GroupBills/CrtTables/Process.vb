Imports System.io
Imports System.Text
Module Process

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Public MyDBName As String
Public MyISRPM As Boolean
Public MyColName As Integer
Public MyColName2 As Integer
Public MyColAddr As Integer
Public MyColAddr2 As Integer
Public MyColTown As Integer
Public MyColSt As Integer
Public MyColZip As Integer
Public MyColZip4 As Integer
Public myColBkcd As String
Public Sub ProcTable()

If MyFrmMainB.TxtName.Text = "" Then Exit Sub

If MyFrmMainB.RbRPM.Checked Then
  MyDBName = GetValidName(MyFrmMainB.TxtName.Text)
  MyISRPM = True
Else
  MyDBName = GetValidName(MyFrmMainB.TxtName.Text) & "2"
  MyISRPM = False
End If
DropTable(MyDBName)
CrtTable(MyDBName)


If MyISRPM Then
  If MyFrmMainB.LblFilePathRE.Text <> String.Empty Then
    GetFile(MyFrmMainB.LblFilePathRE.Text, "R")
  End If
  If MyFrmMainB.LblFilePathPP.Text <> String.Empty Then
    GetFile(MyFrmMainB.LblFilePathPP.Text, "P")
  End If
  If MyFrmMainB.LblFilePathMV.Text <> String.Empty Then
    GetFile(MyFrmMainB.LblFilePathMV.Text, "M")
  End If
Else
  If MyFrmMainB.LblFilePathMS.Text <> String.Empty Then
    GetFile(MyFrmMainB.LblFilePathMS.Text, "S")
  End If
End If

SaveSettings()

MsgBox("Done", MsgBoxStyle.Information, "Processing complete")
End Sub
Private Sub GetFile(ByVal WrkFileName As String, ByVal WrkType As String)
Dim WrkStream As FileStream = New FileStream(WrkFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
Dim sr As StreamReader = New StreamReader(WrkStream)
Dim sb As StringBuilder
Dim strBuffer As String
Dim WrkFileSize As Integer
Dim HdrArray As String()
Dim RecArray As String()
Dim OutRecArray As String()
Dim WrkHeaders As Boolean
Dim I As Integer
Dim Counter As Integer

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

Counter = 0
WrkFileSize = WrkStream.Length

WrkHeaders = False

NextLine:
  strBuffer = sr.ReadLine
  If strBuffer Is Nothing Then
    GoTo Cleanup
  End If
  I = I + Len(strBuffer)
  sb = New StringBuilder
  If WrkHeaders = False Then
    HdrArray = Parse(strBuffer, ",")
    AssignColsWalsh(HdrArray)
    WrkHeaders = True
    GoTo nextrecord
  End If
  Counter = Counter + 1
  RecArray = Parse(strBuffer, ",")
  OutRecArray = MoveOutArray(RecArray)
  InsertRow(Counter, MyDBName, WrkType, OutRecArray)
  sb = Nothing

nextrecord:
With myFrmProgress
  WrkPct = (I / WrkFileSize) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
GoTo NextLine

Cleanup:
sr.Close()
myFrmProgress.Close()

End Sub
Private Sub AssignColsWalsh(ByVal HdrArray() As String)
 Dim I As Integer

 myColBkcd = -1
 For I = 0 To HdrArray.GetUpperBound(0) - 1
  Select Case UCase(HdrArray(I))
  Case "NAME"
    MyColName = I
  Case "SECOND NAME"
    MyColName2 = I
  Case "ADDRESS 1"
    MyColAddr = I
  Case "ADDRESS 2"
    MyColAddr2 = I
  Case "CITY"
    MyColTown = I
  Case "STATE"
    MyColSt = I
  Case "ZIP5"
    MyColZip = I
  Case "ZIP4"
    MyColZip4 = I
  Case "BANK CODE"
    myColBkcd = I
  End Select
Next

End Sub
Private Function MoveOutArray(ByVal RecArray() As String) As String()
  Dim OutArray(8) As String
  OutArray(0) = RecArray(MyColName)
  OutArray(1) = RecArray(MyColName2)
  OutArray(2) = RecArray(MyColAddr)
  OutArray(3) = RecArray(MyColAddr2)
  OutArray(4) = RecArray(MyColTown)
  OutArray(5) = RecArray(MyColSt)
  OutArray(6) = RecArray(MyColZip)
  OutArray(7) = RecArray(MyColZip4)
  If myColBkcd >= 0 Then
    OutArray(8) = RecArray(myColBkcd)
  Else
    OutArray(8) = String.Empty
  End If

  Return OutArray
End Function
'Private Sub CleanUpHeaders(ByRef SArray() As String)

' Dim I As Integer

' For I = 0 To SArray.GetUpperBound(0)
'   SArray(I) = GetValidName(SArray(I))
' Next

'End Sub
Private Function GetValidName(ByRef WrkName As String) As String

   'Remove/Change unwanted chars
   WrkName = Replace(WrkName, " ", "_")
   WrkName = Replace(WrkName, "__", "_")
   WrkName = Replace(WrkName, "$", "")
   WrkName = Replace(WrkName, "(", "")
   WrkName = Replace(WrkName, ")", "")
   WrkName = Replace(WrkName, "%", "")
   WrkName = Replace(WrkName, "-", "")
   WrkName = Replace(WrkName, "&", "")
   WrkName = Replace(WrkName, ".", "")
   WrkName = Replace(WrkName, "/", "")
   WrkName = Replace(WrkName, "1ST", "FIRST")
   WrkName = Replace(WrkName, "2ND", "SECOND")
   Return WrkName

End Function
Private Sub SaveSettings()
    Dim xs As New System.Xml.Serialization.XmlSerializer(GetType(AppSettings))
    Dim sw As IO.StreamWriter
    Dim WrkProgName As String
    Dim WrkXMLPath As String

    With MyFrmMainB
      MyAppSettings.DBName = .TxtName.Text
      MyAppSettings.IsRPM = .RbRPM.Checked
      MyAppSettings.REFile = .LblFilePathRE.Text
      MyAppSettings.PPFile = .LblFilePathPP.Text
      MyAppSettings.MVFile = .LblFilePathMV.Text
      MyAppSettings.MSFile = .LblFilePathMS.Text
    End With

    WrkProgName = Replace(GetProgramName, ".exe", "")
    WrkXMLPath = GetDataPath() & "Settings\" & MyTownNo & ".xml"
    sw = New IO.StreamWriter(WrkXMLPath)
    xs.Serialize(sw, MyAppSettings)
    sw.Close()
End Sub
End Module
