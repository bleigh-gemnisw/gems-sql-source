Imports System.Text
Module PrintReport
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXMVDC As TXMVDCQ.myData
Dim myTXSUPPC As TXSUPPCQ.myData
Dim dsTXMVDC As DataSet = New DataSet
Dim dsTXSUPPC As DataSet = New DataSet
Dim dsMV As DataSet = New DataSet
Dim dsSU As DataSet = New DataSet
Dim dr As Data.DataRow
'General
Dim WrkAnd As String
Dim WrkOr As String
'Screen
Dim ChkMV As Boolean
Dim ChkSU As Boolean
  Public Sub PrtReport()

	myTXMVDC = New TXMVDCQ.mydata(MyDBConnect)
	myTXSUPPC = New TXSUPPCQ.mydata(MyDBConnect)

  With MyFrmTX506B
    ChkMV = .ChkMV.Checked
    ChkSU = .ChkSU.Checked
  End With

  If dsMV.Tables.Count = 0 Then
    BuildDS(dsMV)
    BuildDS(dsSU)
  Else
    dsMV.Clear()
    dsSU.Clear()
  End If

  If ChkMV Then GetDetailMV()
  If ChkSU Then GetDetailSU()

  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkdsMV = dsMV
    .wrkdsSU = dsSU
    .Show()
  End With
  End Sub
Private Sub GetDetailMV()
Dim sb As StringBuilder
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkSort = "NAME, LIST#"

WrkQry = "CAT='1'"

dsTXMVDC = myTXMVDC.GetQry(WrkSort, WrkQry, 0)
If dsTXMVDC.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (dsTXMVDC.Tables(0).Rows.Count - 1)
  With dsTXMVDC.Tables(0).Rows(I)
    dr = dsMV.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("addr1") = .Item("name")
    dr.Item("addr2") = .Item("sname")
    dr.Item("addr3") = .Item("add1")
    dr.Item("addr4") = .Item("add2")
    sb = New StringBuilder
    sb.Append(.Item("city"))
    sb.Append(", ")
    sb.Append(.Item("state"))
    sb.Append(" ")
    sb.Append(Format(.Item("zip5"), "00000"))
    If .Item("zip4") > 0 Then
      sb.Append("-")
      sb.Append(Format(.Item("zip4"), "0000"))
    End If
    dr.Item("addr5") = sb.ToString
    If .Item("dob") > 0 Then
      dr.Item("dob") = Format(MyUtils.GetDBDate(.Item("dob")), "Short Date")
    Else
      dr.Item("dob") = String.Empty
    End If
    dsMV.Tables(0).Rows.Add(dr)
    sb = Nothing
    dr = Nothing
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / dsTXMVDC.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
Application.DoEvents()

End Sub
Private Sub GetDetailSU()
Dim sb As StringBuilder
Dim WrkQry As String
Dim WrkSort As String
Dim I As Integer

If MyServer = "DB2" Then
  WrkAnd = " *and "
  WrkOr = " *or "
Else
  WrkAnd = " and "
  WrkOr = " or "
End If

WrkSort = "NAME, LIST#"

WrkQry = "CAT='1'"

dsTXSUPPC = myTXSUPPC.GetQry(WrkSort, WrkQry, 0)
If dsTXSUPPC.Tables(0).Rows.Count = 0 Then Exit Sub

myFrmProgress = New FrmProgress
myFrmProgress.Show()
myFrmProgress.Refresh()
Application.DoEvents()

For I = 0 To (dsTXSUPPC.Tables(0).Rows.Count - 1)
  With dsTXSUPPC.Tables(0).Rows(I)
    dr = dsSU.Tables(0).NewRow
    dr.Item("listno") = .Item("list#")
    dr.Item("addr1") = .Item("name")
    dr.Item("addr2") = .Item("sname")
    dr.Item("addr3") = .Item("add1")
    dr.Item("addr4") = .Item("add2")
    sb = New StringBuilder
    sb.Append(.Item("city"))
    sb.Append(", ")
    sb.Append(.Item("state"))
    sb.Append(" ")
    sb.Append(Format(.Item("zip5"), "00000"))
    If .Item("zip4") > 0 Then
      sb.Append("-")
      sb.Append(Format(.Item("zip4"), "0000"))
    End If
    dr.Item("addr5") = sb.ToString
    If .Item("dob") > 0 Then
      dr.Item("dob") = Format(MyUtils.GetDBDate(.Item("dob")), "Short Date")
    Else
      dr.Item("dob") = String.Empty
    End If
    dsSU.Tables(0).Rows.Add(dr)
    sb = Nothing
    dr = Nothing
  End With

NextRec:
With myFrmProgress
  WrkPct = ((I + 1) / dsTXSUPPC.Tables(0).Rows.Count) * 100
  If SavePct <> WrkPct Then
    .ProgBar1.Value = WrkPct
    .Refresh()
    SavePct = WrkPct
    Application.DoEvents()
  End If
End With
Next

myFrmProgress.Close()
Application.DoEvents()

End Sub
End Module






