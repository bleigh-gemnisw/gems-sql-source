Imports System.Text
Module PrintReport

  Dim Ds As DataSet = New DataSet
  Public Sub PrtReport()
    Dim MyCRViewer As FrmCrViewer
    If Ds.Tables.Count = 0 Then
      BuildDS()
    Else
      Ds.Clear()
    End If

    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    MyCRViewer.wrkds = Ds
    MyCRViewer.ShowDialog()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Type", Type.GetType("System.String"))
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
      .Columns.Add("SSA", Type.GetType("System.Decimal"))
      .Columns.Add("OTHER", Type.GetType("System.Decimal"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("ALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISRSN", Type.GetType("System.String"))
      .Columns.Add("ASSRMO", Type.GetType("System.String"))
      .Columns.Add("ASSRDAY", Type.GetType("System.String"))
      .Columns.Add("ASSRYEAR", Type.GetType("System.String"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim dr As Data.DataRow
    Dim sb As StringBuilder

    With MyFrmTO220C
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
      dr.Item("income") = MyUtils.CnvSng(.TxtIncome.Text)
      dr.Item("ssa") = MyUtils.CnvSng(.TxtSSA.Text)
      dr.Item("other") = MyUtils.CnvSng(.TxtOther.Text)
      dr.Item("total") = MyUtils.CnvSng(.LblTotal.Text)
      dr.Item("signedmo") = Format(.DtPckSigned.Value.Month, "00")
      dr.Item("signedday") = Format(.DtPckSigned.Value.Day, "00")
      dr.Item("signedyear") = .DtPckSigned.Value.Year
      If MyUtils.CnvSng(.MskTxtPhone.Text) > 0 Then
        dr.Item("phone") = Format(MyUtils.CnvSng(.MskTxtPhone.Text), "(###) ###-0000")
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
      Ds.Tables(0).Rows.Add(dr)
    End With
  End Sub

End Module

