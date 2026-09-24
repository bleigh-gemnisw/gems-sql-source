Imports System.io
Imports System.Text
Module PrintReport

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myVENDORQ As VENDORQ.MyData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

Dim WrkVencat As String
Dim WrkShowVenno As Boolean
Dim WrkMaxLen As Integer
Dim WrkMod As Integer
Dim WrkHAdjust1 As Integer
Dim WrkHAdjust2 As Integer
Dim WrkHAdjust3 As Integer
Dim WrkAnd As String
Dim WrkOr As String

  Public Sub PrtReport()

  myVENDORQ = New VENDORQ.MyData()
  myVENDORQ.MyDBConn = myDBConnect

  With MyFrmAP305B
    WrkVencat = .TxtVncat.Text
    WrkShowVenno = .ChkVenno.Checked
    If .Rb1Across.Checked Then WrkMod = 1
    If .Rb2Across.Checked Then WrkMod = 2
    If .Rb3Across.Checked Then WrkMod = 3
    WrkMaxLen = MyUtils.CnvSng(.TxtMaxLen.Text)
    WrkHAdjust1 = MyUtils.CnvSng(.TxtHAdjust1.Text)
    WrkHAdjust2 = MyUtils.CnvSng(.TxtHAdjust2.Text)
    WrkHAdjust3 = MyUtils.CnvSng(.TxtHAdjust3.Text)
  End With

  If ds.Tables.Count = 0 Then
    BuildDs(ds)
  Else
    ds.Clear()
  End If
  GetDetail()

Done:
 MyCRViewer = New FrmCrViewer
 With MyCRViewer
  .wrkds = ds
  .Show()
 End With
 End Sub
Private Sub BuildDS(ByRef ds As DataSet)
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("line0", Type.GetType("System.String"))
    .Columns.Add("line1", Type.GetType("System.String"))
    .Columns.Add("line2", Type.GetType("System.String"))
    .Columns.Add("line3", Type.GetType("System.String"))
    .Columns.Add("line4", Type.GetType("System.String"))
    .Columns.Add("line5", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
Dim WrkQry As String
Dim WrkSort As String
Dim WrkLine As String
Dim AddrLine() As String
Dim sb0 As StringBuilder = New StringBuilder
Dim sb1 As StringBuilder = New StringBuilder
Dim sb2 As StringBuilder = New StringBuilder
Dim sb3 As StringBuilder = New StringBuilder
Dim sb4 As StringBuilder = New StringBuilder
Dim sb5 As StringBuilder = New StringBuilder
Dim WrkNew As Boolean
Dim Counter As Integer

WrkAnd = " and "
WrkOr = " or "

If WrkVencat <> "" Then
  WrkQry = "VNCAT = " & MyUtils.Quo(WrkVencat)
Else
  WrkQry = ""
End If
WrkSort = "VSORT"
Counter = 0
myVENDORQ.OpenQry(WrkSort, WrkQry)

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

ReadNext:
 myVENDORQ.ReadQry()
 If Not myVENDORQ.IsEOF Then
  Counter = Counter + 1

  'Create Report
  With myVENDORQ
    WrkLine = ""
    If WrkShowVenno Then
      WrkLine = ._VNDNR
    End If
    sb0.Append(MyUtils.JustifyLeft(WrkLine, WrkMaxLen))
    AddrLine = SetVndrAddrLine(._VENNM, ._VADD1, ._VADD2, _
      ._VADD3, ._VADD4, ._VZIP, ._VZIPE)
    sb1.Append(MyUtils.JustifyLeft(AddrLine(0), WrkMaxLen))
    sb2.Append(MyUtils.JustifyLeft(AddrLine(1), WrkMaxLen))
    sb3.Append(MyUtils.JustifyLeft(AddrLine(2), WrkMaxLen))
    sb4.Append(MyUtils.JustifyLeft(AddrLine(3), WrkMaxLen))
    sb5.Append(MyUtils.JustifyLeft(AddrLine(4), WrkMaxLen))
    'Adjust space between 1st and 2nd columns
    If WrkMod > 1 And Counter Mod WrkMod = 1 And WrkHAdjust2 > 0 Then
     sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
     sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
     sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
     sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
     sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
     sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust2))
    End If
    'Adjust space between 2nd and 3rd columns
    If WrkMod > 2 And Counter Mod WrkMod = 2 And WrkHAdjust3 > 0 Then
     sb0.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
     sb1.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
     sb2.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
     sb3.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
     sb4.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
     sb5.Append(MyUtils.JustifyLeft("", WrkHAdjust3))
    End If
    If Counter Mod WrkMod = 0 Then
      dr = ds.Tables(0).NewRow
      If WrkShowVenno Then
        dr.Item("line0") = sb0.ToString
      Else
        dr.Item("line0") = String.Empty
      End If
      dr.Item("line1") = sb1.ToString
      dr.Item("line2") = sb2.ToString
      dr.Item("line3") = sb3.ToString
      dr.Item("line4") = sb4.ToString
      dr.Item("line5") = sb5.ToString
      ds.Tables(0).Rows.Add(dr)
      sb0.Clear()
      sb1.Clear()
      sb2.Clear()
      sb3.Clear()
      sb4.Clear()
      sb5.Clear()
      WrkNew = True
    End If
  End With

NextRec:
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
  GoTo ReadNext
 End If

'Write out any remaining data
  If Not WrkNew Then
    If sb1.ToString <> String.Empty Then
      dr = ds.Tables(0).NewRow
      If WrkShowVenno Then
        dr.Item("line0") = sb0.ToString
      Else
        dr.Item("line0") = String.Empty
      End If
      dr.Item("line1") = sb1.ToString
      dr.Item("line2") = sb2.ToString
      dr.Item("line3") = sb3.ToString
      dr.Item("line4") = sb4.ToString
      dr.Item("line5") = sb5.ToString
      ds.Tables(0).Rows.Add(dr)
    End If
  End If
  sb0 = Nothing
  sb1 = Nothing
  sb2 = Nothing
  sb3 = Nothing
  sb4 = Nothing
  sb5 = Nothing
  myFrmProgress.Close()
  myVENDORQ.CloseFile()

End Sub
Public Function SetVndrAddrLine(ByVal Name As String, ByVal Add1 As String, ByVal Add2 As String, _
   ByVal Add3 As String, ByVal Add4 As String, ByVal Zip5 As String, ByVal Zip4 As String) As String()
   'Returns Address as string array. Blank lines are stripped out. 
  Dim AddrLine(4) As String
   Dim sb As StringBuilder
   Dim I As Integer

  Name = Trim(Name)
  Add1 = Trim(Add1)
  Add2 = Trim(Add2)
  Add3 = Trim(Add3)
  Add4 = Trim(Add4)
  Zip5 = Trim(Zip5)
  Zip4 = Trim(Zip4)

  AddrLine(I) = Name
  I = I + 1
  AddrLine(I) = Add1
  If Add2 <> "" Then
   I = I + 1
   AddrLine(I) = Add2
  End If
   If Add3 <> "" Then
   I = I + 1
   AddrLine(I) = Add3
  End If
   If Add4 <> "" Then
   I = I + 1
   AddrLine(I) = Add4
  End If
  If Zip5 <> "" Then
   sb = New StringBuilder
   sb.Append(Zip5)
   If Zip4 <> "" Then
    sb.Append("-")
    sb.Append(Zip4)
   End If
   AddrLine(I) = AddrLine(I) & " " & sb.ToString
  End If
  For I = 2 To 3
   If AddrLine(I) Is Nothing Then
    AddrLine(I) = ""
   End If
  Next
  Return AddrLine

End Function
Private Function DoFlipName(ByVal Name As String) As String
 Dim WrkName As String
 Dim Pos As Integer

 WrkName = ""
 Pos = InStr(Name, ",", CompareMethod.Text)
 If Pos > 0 Then
  WrkName = Trim(Mid(Name, Pos + 1, 40)) & " " & Mid(Name, 1, Pos - 1)
 Else
  WrkName = Name
 End If

 Return WrkName
End Function

End Module
