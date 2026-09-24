Imports System.io
Imports System.Text
Module ProcessFile

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkFile As String
Dim WrkAddr As Boolean
Dim WrkPostal As Boolean
Dim WrkImport As Boolean
Dim WrkExport As Boolean
Dim WrkSetPost As Boolean
Dim WrkGroupID As String
Dim myDBUtils As DBUtils
Public Sub ProcTable()

With MyFrmMainB
  WrkImport = .RbImport.Checked
  WrkExport = .RbExport.Checked
  If MyAppSettings.IsRPM Then
    WrkFile = .LblName.Text
  Else
    WrkFile = .LblName.Text & "2"
  End If
  WrkAddr = .ChkAddr.Checked
  WrkPostal = .ChkPostal.Checked
  WrkSetPost = .RbSetPostal.Checked
  WrkGroupID = .TxtGroupID.Text
End With

If WrkFile = String.Empty Then Exit Sub

If MyFrmMainB.LblFilePath.Text <> String.Empty Then
  If WrkImport And WrkAddr Then
    GetFile(MyFrmMainB.LblFilePath.Text)
  End If
  If WrkImport And WrkPostal Then
    GetPostal(MyFrmMainB.LblFilePath.Text)
  End If
  If WrkExport And WrkPostal Then
    CreatePostal(MyFrmMainB.LblFilePath.Text)
  End If
End If
If WrkSetPost Then
  SetPostBarCode()
End If

With MyFrmMainB
  .ChkAddr.Checked = False
  .ChkPostal.Checked = False
End With
MsgBox("Done", MsgBoxStyle.Information, "Processing complete")
End Sub
Private Sub GetFile(ByVal WrkFileName As String)
Dim WrkStream As FileStream = New FileStream(WrkFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
Dim sr As StreamReader = New StreamReader(WrkStream)
Dim ds2 As DataSet = New DataSet
Dim strBuffer As String
Dim WrkFileSize As Integer
Dim RecArray As String()
Dim WrkHeaders As Boolean
Dim WrkQry As String
Dim I As Integer
Dim J As Integer
Dim Counter As Integer
Dim Good As Boolean
Dim Answer As Integer

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

myDBUtils = New DBUtils

Counter = 0
WrkFileSize = WrkStream.Length

WrkHeaders = False

NextLine:
  strBuffer = sr.ReadLine
  If strBuffer Is Nothing Then
    GoTo Cleanup
  End If
  I = I + Len(strBuffer)
  If WrkHeaders = False Then
    WrkHeaders = True
    GoTo nextrecord
  End If
  Counter = Counter + 1
  RecArray = Parse(strBuffer, ",")

  WrkQry = "GROUP1='" & UCase(RecArray(2)) & "' and GROUP2='" & UCase(RecArray(3)) & "' and BKCD=''"
  ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
  For J = 0 To ds2.Tables(0).Rows.Count - 1
    Good = True
    If Len(RecArray(18)) > 35 Then
      Answer = MsgBox("PostID=" & RecArray(11), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Addr is too long")
      If Answer = MsgBoxResult.Cancel Then GoTo Cleanup
      Good = False
    End If
    If Len(RecArray(19)) > 35 Then
      Answer = MsgBox("PostID=" & RecArray(11), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Addr2 is too long")
      If Answer = MsgBoxResult.Cancel Then GoTo Cleanup
      Good = False
    End If
    If Len(RecArray(20)) > 25 Then
      Answer = MsgBox("PostID=" & RecArray(11), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Town is too long")
      If Answer = MsgBoxResult.Cancel Then GoTo Cleanup
      Good = False
    End If
    If Len(RecArray(21)) > 2 Then
      Answer = MsgBox("PostID=" & RecArray(11), MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "State is too long")
      If Answer = MsgBoxResult.Cancel Then GoTo Cleanup
      Good = False
    End If
    If WrkAddr And Good Then
      ds2.Tables(0).Rows(J).Item("addr") = UCase(RecArray(18))
      ds2.Tables(0).Rows(J).Item("addr2") = UCase(RecArray(19))
      ds2.Tables(0).Rows(J).Item("town") = UCase(RecArray(20))
      ds2.Tables(0).Rows(J).Item("state") = RecArray(21)
      If Len(RecArray(22)) = 10 Then
        ds2.Tables(0).Rows(J).Item("zip") = Mid(RecArray(22), 1, 5)
        ds2.Tables(0).Rows(J).Item("zip4") = Mid(RecArray(22), 7, 4)
      Else
        ds2.Tables(0).Rows(J).Item("zip") = RecArray(22)
        ds2.Tables(0).Rows(J).Item("zip4") = ""
      End If
    End If
    myDBUtils.UpdateOneRecordP(WrkFile, ds2)
  Next

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
Private Sub GetPostal(ByVal WrkFileName As String)
Dim ds As DataSet = New DataSet
Dim WrkStream As FileStream = New FileStream(WrkFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
Dim sr As StreamReader = New StreamReader(WrkStream)
Dim strBuffer As String
Dim sArray As String()
Dim WrkFileSize As Integer
Dim WrkQry As String
Dim I As Integer
Dim Counter As Integer

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

myDBUtils = New DBUtils
Counter = 0
WrkFileSize = WrkStream.Length

'Skip Header record
strBuffer = sr.ReadLine

NextLine:
  strBuffer = sr.ReadLine
  If strBuffer Is Nothing Then
    GoTo Cleanup
  End If
  I = I + Len(strBuffer)
  Counter = Counter + 1
  sArray = Parse(strBuffer, ",")
  WrkQry = "POSTID=" & sArray(11) & " and RECID=" & CnvSng(sArray(0)) & " and BKCD=''"
  ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
  If ds.Tables(0).Rows.Count > 0 Then
    ds.Tables(0).Rows(0).Item("PostBarCode") = sArray(5)
  '  ds.Tables(0).Rows(0).Item("PostEndorse") = sArray(6)
    ds.Tables(0).Rows(0).Item("PostSort") = CnvSng(sArray(8))
    myDBUtils.UpdateOneRecordP(WrkFile, ds)
  End If

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

CleanUp:
myFrmProgress.Close()

End Sub
Private Sub CreatePostal(ByVal WrkFileName As String)
Dim ds As DataSet = New DataSet
Dim sw As StreamWriter = New StreamWriter(WrkFileName)
Dim sb As StringBuilder
Dim CComma As String = ","
Dim CQuote As String = Chr(34)
Dim WrkQry As String
Dim WrkZip As String
Dim I As Integer
Dim Counter As Integer

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

myDBUtils = New DBUtils
Counter = 0
sw.WriteLine(HeadingsCSV)

WrkQry = "POSTID > 0"
If WrkGroupID <> "" Then
  WrkQry = WrkQry & " and GroupID = " & WrkGroupID & " and BKCD=''"
End If

ds = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
For I = 0 To ds.Tables(0).Rows.Count - 1
  sb = New StringBuilder
  sb.Append(ds.Tables(0).Rows(I).Item("recid"))
  sb.Append(CComma)
  sb.Append(ds.Tables(0).Rows(I).Item("type"))
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("group1")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("group2")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(ds.Tables(0).Rows(I).Item("iscompany"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append("")
'  sb.Append(ds.Tables(0).Rows(I).Item("im"))
  sb.Append(CComma)
  sb.Append(ds.Tables(0).Rows(I).Item("postbarcode"))
  sb.Append(CComma)
  sb.Append(ds.Tables(0).Rows(I).Item("postendorse"))
  sb.Append(CComma)
  sb.Append(ds.Tables(0).Rows(I).Item("postsort"))
  sb.Append(CComma)
  sb.Append("")
  'sb.Append(ds.Tables(0).Rows(I).Item("position"))
  sb.Append(CComma)
  sb.Append(ds.Tables(0).Rows(I).Item("groupid"))
  sb.Append(CComma)
  sb.Append(ds.Tables(0).Rows(I).Item("postid"))
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(ds.Tables(0).Rows(I).Item("firstname"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(ds.Tables(0).Rows(I).Item("lastname"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(ds.Tables(0).Rows(I).Item("suffix"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("companyname")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("name")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("name2")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("addr")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("addr2")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(StripCommas(ds.Tables(0).Rows(I).Item("town")))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  sb.Append(ds.Tables(0).Rows(I).Item("state"))
  sb.Append(CQuote)
  sb.Append(CComma)
  sb.Append(CQuote)
  WrkZip = Format(CnvSng(ds.Tables(0).Rows(I).Item("zip")), "00000")
  If ds.Tables(0).Rows(I).Item("zip4") <> "0000" Then
    WrkZip = WrkZip & "-" & Format(CnvSng(ds.Tables(0).Rows(I).Item("zip4")), "0000")
  End If
  sb.Append(WrkZip)
  sb.Append(CQuote)
  sw.WriteLine(sb.ToString)
  sb = Nothing
  Next

CleanUp:
sw.Close()
myFrmProgress.Close()

End Sub
Private Function HeadingsCSV() As String
  Dim sb As StringBuilder
  Dim CComma As String = ","

  sb = New StringBuilder
  sb.Append("RecID")
  sb.Append(CComma)
  sb.Append("Type")
  sb.Append(CComma)
  sb.Append("Group1")
  sb.Append(CComma)
  sb.Append("Group2")
  sb.Append(CComma)
  sb.Append("IsCompany")
  sb.Append(CComma)
  sb.Append("IM")
  sb.Append(CComma)
  sb.Append("Barcode")
  sb.Append(CComma)
  sb.Append("Endorsement")
  sb.Append(CComma)
  sb.Append("Sort")
  sb.Append(CComma)
  sb.Append("Position")
  sb.Append(CComma)
  sb.Append("GroupID")
  sb.Append(CComma)
  sb.Append("PostID")
  sb.Append(CComma)
  sb.Append("First Name")
  sb.Append(CComma)
  sb.Append("Last Name")
  sb.Append(CComma)
  sb.Append("Name Suffix")
  sb.Append(CComma)
  sb.Append("Business Name")
  sb.Append(CComma)
  sb.Append("Name")
  sb.Append(CComma)
  sb.Append("Name2")
  sb.Append(CComma)
  sb.Append("Address Line 1")
  sb.Append(CComma)
  sb.Append("Address Line 2")
  sb.Append(CComma)
  sb.Append("City")
  sb.Append(CComma)
  sb.Append("State")
  sb.Append(CComma)
  sb.Append("ZIP Code")
  Return sb.ToString
End Function
Public Sub SetPostBarCode()
Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim Counter As Integer
Dim WrkRecs As Integer
Dim I As Integer
Dim J As Integer
Dim WrkQry As String
Dim SaveGroupID As String
Dim SaveGroup1 As String
Dim SaveGroup2 As String
Dim WrkPostBarcode As String
Dim WrkPctDone As Decimal

myDBUtils = New DBUtils

SaveGroupID = String.Empty
SaveGroup1 = String.Empty
SaveGroup2 = String.Empty
WrkPostBarcode = String.Empty
WrkQry = "GROUPID<>'001' and postbarcode<>''"
ds = myDBUtils.GetQry(WrkFile, "GroupID, group1, group2", WrkQry, 0)
WrkRecs = ds.Tables(0).Rows.Count

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Text = "Processing: Set Group Postal Barcodes"
myFrmProgress.Refresh()
Application.DoEvents()

  For I = 0 To ds.Tables(0).Rows.Count - 1
    With ds.Tables(0).Rows(I)
      WrkPostBarcode = .Item("postbarcode")
      WrkQry = "GROUPID='" & .Item("groupid") & "' and group1='" & .Item("group1") & _
       "' and group2='" & .Item("group2") & "' and postbarcode=''"
      ds2 = myDBUtils.GetQry(WrkFile, "", WrkQry, 0)
      For J = 0 To ds2.Tables(0).Rows.Count - 1
        ds2.Tables(0).Rows(J).Item("postbarcode") = WrkPostBarcode
      Next
      myDBUtils.UpdateOneRecordP(WrkFile, ds2)
    End With
    Counter = Counter + 1

NextRec:
    With myFrmProgress
      WrkPct = (Counter / 10) Mod 100
      If SavePct <> WrkPct Then
        WrkPctDone = Math.Round(Counter / WrkRecs, 3) * 100
        .ProgBar1.Value = WrkPct
        .LblMsg.Text = "Records processed: " & Counter & " (" & WrkPctDone & "%)"
        .Refresh()
        SavePct = WrkPct
        Application.DoEvents()
      End If
    End With
  Next

End_of_file:
myFrmProgress.Close()

End Sub
End Module
