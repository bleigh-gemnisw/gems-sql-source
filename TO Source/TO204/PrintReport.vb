Imports System.text
Module PrintReport

Dim Ds As DataSet = New DataSet
Public Sub PrtReport(ByVal WrkPgm As String)
  Dim MyCRViewer As FrmCrViewer
  If Ds.Tables.Count = 0 Then
    BuildDS()
  Else
    Ds.Clear()
  End If

  GetDetail(WrkPgm)

Done:
  MyCRViewer = New FrmCrViewer
  MyCRViewer.wrkds = Ds
  MyCRViewer.WrkPgm = WrkPgm
  MyCRViewer.ShowDialog()
End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("ALName", Type.GetType("System.String"))
      .Columns.Add("AFName", Type.GetType("System.String"))
      .Columns.Add("AInit", Type.GetType("System.String"))
      .Columns.Add("ASSN", Type.GetType("System.String"))
      .Columns.Add("SLName", Type.GetType("System.String"))
      .Columns.Add("SFName", Type.GetType("System.String"))
      .Columns.Add("SInit", Type.GetType("System.String"))
      .Columns.Add("SSSN", Type.GetType("System.String"))
      .Columns.Add("PROPLOC", Type.GetType("System.String"))
      .Columns.Add("CITY", Type.GetType("System.String"))
      .Columns.Add("STATE", Type.GetType("System.String"))
      .Columns.Add("ZIP", Type.GetType("System.String"))
      .Columns.Add("MADDR", Type.GetType("System.String"))
      .Columns.Add("MCITY", Type.GetType("System.String"))
      .Columns.Add("MSTATE", Type.GetType("System.String"))
      .Columns.Add("MZIP", Type.GetType("System.String"))
      .Columns.Add("PHONE", Type.GetType("System.String"))
      .Columns.Add("MARRIED", Type.GetType("System.String"))
      .Columns.Add("SINGLE", Type.GetType("System.String"))
      .Columns.Add("DIVORCED", Type.GetType("System.String"))
      .Columns.Add("WIDOW", Type.GetType("System.String"))
      .Columns.Add("LEGALLY", Type.GetType("System.String"))
      .Columns.Add("INCOME", Type.GetType("System.Decimal"))
      .Columns.Add("INTEREST", Type.GetType("System.Decimal"))
      .Columns.Add("SSRR", Type.GetType("System.Decimal"))
      .Columns.Add("OTHER", Type.GetType("System.Decimal"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("DISRATINGYES", Type.GetType("System.String"))
      .Columns.Add("DISRATINGNO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("XVET", Type.GetType("System.Int32"))
      .Columns.Add("DISINCOMEYES", Type.GetType("System.String"))
      .Columns.Add("DISINCOMENO", Type.GetType("System.String"))
      .Columns.Add("QUALIFYING", Type.GetType("System.Decimal"))
      .Columns.Add("XADDL", Type.GetType("System.Int32"))
      .Columns.Add("XFULL", Type.GetType("System.Int32"))
      .Columns.Add("XLOCAL", Type.GetType("System.Int32"))
      .Columns.Add("XFULLO", Type.GetType("System.Int32"))
      .Columns.Add("RE", Type.GetType("System.String"))
      .Columns.Add("MV", Type.GetType("System.String"))
      .Columns.Add("PP", Type.GetType("System.String"))
      .Columns.Add("SU", Type.GetType("System.String"))
      .Columns.Add("RELIST", Type.GetType("System.String"))
      .Columns.Add("MVLIST", Type.GetType("System.String"))
      .Columns.Add("PPLIST", Type.GetType("System.String"))
      .Columns.Add("SULIST", Type.GetType("System.String"))
      .Columns.Add("ALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISRSN", Type.GetType("System.String"))
      .Columns.Add("ASSRMO", Type.GetType("System.String"))
      .Columns.Add("ASSRDAY", Type.GetType("System.String"))
      .Columns.Add("ASSRYEAR", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
Private Sub GetDetail(ByVal WrkPgm As String)
Dim dr As Data.DataRow
Dim sb As StringBuilder

With MyFrmTO204C
  dr = Ds.Tables(0).NewRow
  dr.Item("year") = MyUtils.CnvSng(.TxtYear.Text)
  dr.Item("listno") = MyUtils.CnvSng(.TxtListNo.Text)
  dr.Item("alname") = .TxtALName.Text
  dr.Item("afname") = .TxtAFName.Text
  dr.Item("ainit") = .TxtAInit.Text
  sb = New StringBuilder
  sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtASSN.Text, 1, 3)), "000"))
  sb.Append("  -  ")
  sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtASSN.Text, 4, 2)), "00"))
  sb.Append("  -  ")
  sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtASSN.Text, 6, 4)), "0000"))
  dr.Item("assn") = sb.ToString
  sb = Nothing
  dr.Item("slname") = .TxtSLName.Text
  dr.Item("sfname") = .TxtSFName.Text
  dr.Item("sinit") = .TxtSInit.Text
  If .TxtSLName.Text <> "" Then
    sb = New StringBuilder
    sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtSSSN.Text, 1, 3)), "000"))
    sb.Append("  -  ")
    sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtSSSN.Text, 4, 2)), "00"))
    sb.Append("  -  ")
    sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtSSSN.Text, 6, 4)), "0000"))
    dr.Item("sssn") = sb.ToString
    sb = Nothing
  End If
  dr.Item("proploc") = Trim(.TxtLocNo.Text) & " " & .TxtLoc.Text
  dr.Item("city") = .TxtCity.Text
  dr.Item("state") = .TxtState.Text
  If .TxtZip.Text <> "" Then
    dr.Item("zip") = Format(MyUtils.CnvSng(.TxtZip.Text), "00000")
  End If
  dr.Item("maddr") = .TxtMAddr.Text
  dr.Item("mcity") = .TxtMCity.Text
  dr.Item("mstate") = .TxtMState.Text
  If .TxtMZip.Text <> "" Then
    dr.Item("mzip") = Format(MyUtils.CnvSng(.TxtMZip.Text), "00000")
  End If
  If .RbMarried.Checked Then
    dr.Item("married") = "X"
  End If
  If .RbSingle.Checked Then
    dr.Item("single") = "X"
  End If
  If .RbDivorced.Checked Then
    dr.Item("divorced") = "X"
  End If
  If .RbWidow.Checked Then
    dr.Item("widow") = "X"
  End If
  If .RbLegally.Checked Then
    dr.Item("legally") = "X"
  End If
  If .ChkDisRating.Checked Then
    dr.Item("disratingyes") = "X"
  Else
    dr.Item("disratingno") = "X"
  End If
  dr.Item("income") = MyUtils.CnvSng(.TxtIncome.Text)
  dr.Item("interest") = MyUtils.CnvSng(.TxtInterest.Text)
  dr.Item("ssrr") = MyUtils.CnvSng(.TxtSSRR.Text)
  dr.Item("other") = MyUtils.CnvSng(.TxtOther.Text)
  dr.Item("total") = MyUtils.CnvSng(.LblTotal.Text)
  dr.Item("signedmo") = Format(.DtPckSigned.Value.Month, "00")
  dr.Item("signedday") = Format(.DtPckSigned.Value.Day, "00")
  dr.Item("signedyear") = .DtPckSigned.Value.Year
  If MyUtils.CnvSng(.TxtPhone.Text) > 0 Then
    dr.Item("phone") = Format(MyUtils.CnvSng(.TxtPhone.Text), "(###) ###-0000")
  End If
  Select WrkPgm
  Case "State"
    'If .ChkDisIncome.Checked Then
    '  dr.Item("disincomeyes") = "X"
    'Else
    '  dr.Item("disincomeno") = "X"
    'End If
    dr.Item("xvet") = MyUtils.CnvSng(.TxtVet.Text)
    'dr.Item("qualifying") = MyUtils.CnvSng(.LblQualifying.Text)
    dr.Item("xaddl") = MyUtils.CnvSng(.TxtAddlVet.Text)
    dr.Item("xfull") = MyUtils.CnvSng(.TxtFullAddl.Text)
    dr.Item("xlocal") = MyUtils.CnvSng(.TxtLocal.Text)
    dr.Item("xfullo") = MyUtils.CnvSng(.TxtFullLoc.Text)
    If .RbRE.Checked Then
      dr.Item("re") = "X"
      dr.Item("relist") = .LblListNo.Text
    End If
    If .RbPP.Checked Then
      dr.Item("pp") = "X"
      dr.Item("pplist") = .LblListNo.Text
    End If
    If .RbMV.Checked Then
      dr.Item("mv") = "X"
      dr.Item("mvlist") = .LblListNo.Text
    End If
    If .RbSU.Checked Then
      dr.Item("su") = "X"
      dr.Item("sulist") = .LblListNo.Text
    End If
    If .RbAllowed.Checked Then
      dr.Item("allowed") = "X"
    End If
    If .RbDisallowed.Checked Then
      dr.Item("disallowed") = "X"
    End If
    dr.Item("disrsn") = .TxtDisallowReason.Text
    If .DtPckAssr.Checked Then
      dr.Item("assrmo") = Format(.DtPckAssr.Value.Month, "00")
      dr.Item("assrday") = Format(.DtPckAssr.Value.Day, "00")
      dr.Item("assryear") = .DtPckAssr.Value.Year
    End If
  Case "Local"
    If .RbLocAllowed.Checked Then
      dr.Item("allowed") = "X"
    End If
    If .RbLocDisallowed.Checked Then
      dr.Item("disallowed") = "X"
    End If
    dr.Item("disrsn") = .TxtLocDisallowReason.Text
    If .DtPckLocAssr.Checked Then
      dr.Item("assrmo") = Format(.DtPckLocAssr.Value.Month, "00")
      dr.Item("assrday") = Format(.DtPckLocAssr.Value.Day, "00")
      dr.Item("assryear") = .DtPckLocAssr.Value.Year
    End If
  Case "EBC"
    If .RbEBCAllowed.Checked Then
      dr.Item("allowed") = "X"
    End If
    If .RbEBCDisallowed.Checked Then
      dr.Item("disallowed") = "X"
    End If
    dr.Item("disrsn") = .TxtEBCDisallowReason.Text
    If .DtPckEBCAssr.Checked Then
      dr.Item("assrmo") = Format(.DtPckEBCAssr.Value.Month, "00")
      dr.Item("assrday") = Format(.DtPckEBCAssr.Value.Day, "00")
      dr.Item("assryear") = .DtPckEBCAssr.Value.Year
    End If
  Case "FBC"
    If .RbFBCAllowed.Checked Then
      dr.Item("allowed") = "X"
    End If
    If .RbFBCDisallowed.Checked Then
      dr.Item("disallowed") = "X"
    End If
    dr.Item("disrsn") = .TxtFBCDisallowReason.Text
    If .DtPckFBCAssr.Checked Then
      dr.Item("assrmo") = Format(.DtPckFBCAssr.Value.Month, "00")
      dr.Item("assrday") = Format(.DtPckFBCAssr.Value.Day, "00")
      dr.Item("assryear") = .DtPckFBCAssr.Value.Year
    End If
  End Select
  Ds.Tables(0).Rows.Add(dr)
End With
End Sub

End Module






