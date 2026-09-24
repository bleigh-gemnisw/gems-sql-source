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
      .Columns.Add("NURSINGHOME", Type.GetType("System.String"))
      .Columns.Add("DISABLED", Type.GetType("System.String"))
      .Columns.Add("TAXRETURNYES", Type.GetType("System.String"))
      .Columns.Add("TAXRETURNNO", Type.GetType("System.String"))
      .Columns.Add("INCOME", Type.GetType("System.Decimal"))
      .Columns.Add("INTEREST", Type.GetType("System.Decimal"))
      .Columns.Add("SSRR", Type.GetType("System.Decimal"))
      .Columns.Add("OTHER", Type.GetType("System.Decimal"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("RELATE", Type.GetType("System.String"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("RECEIVEDMO", Type.GetType("System.String"))
      .Columns.Add("RECEIVEDDAY", Type.GetType("System.String"))
      .Columns.Add("RECEIVEDYEAR", Type.GetType("System.String"))
      .Columns.Add("PROPCT", Type.GetType("System.Decimal"))
      .Columns.Add("PGROSS", Type.GetType("System.Int32"))
      .Columns.Add("GROSS", Type.GetType("System.Int32"))
      .Columns.Add("XBLIND", Type.GetType("System.Int32"))
      .Columns.Add("XDISAB", Type.GetType("System.Int32"))
      .Columns.Add("XVET", Type.GetType("System.Int32"))
      .Columns.Add("XLOCAL", Type.GetType("System.Int32"))
      .Columns.Add("XADDL", Type.GetType("System.Int32"))
      .Columns.Add("NET", Type.GetType("System.Int32"))
      .Columns.Add("MILLRATE", Type.GetType("System.Decimal"))
      .Columns.Add("FRZTAX", Type.GetType("System.Decimal"))
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

    With MyFrmTO221C
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
      dr.Item("city") = .TxtPCity.Text
      dr.Item("state") = .TxtPState.Text
      If .TxtPZip.Text <> "" Then
        dr.Item("zip") = Format(MyUtils.CnvSng(.TxtPZip.Text), "00000")
      End If
      dr.Item("maddr") = .TxtMAddr.Text
      dr.Item("mcity") = .TxtMCity.Text
      dr.Item("mstate") = .TxtMState.Text
      If .TxtMZip.Text <> "" Then
        dr.Item("mzip") = Format(MyUtils.CnvSng(.TxtMZip.Text), "00000")
      End If
      If .RbCivil.Checked Then
        dr.Item("civilunion") = "X"
      End If
      If .RbMarried.Checked Then
        dr.Item("married") = "X"
      End If
      If .RbUnmarried.Checked Then
        dr.Item("unmarried") = "X"
      End If
      If .RbSurviving.Checked Then
        dr.Item("surviving") = "X"
      End If
      If .ChkNursingHome.Checked Then
        dr.Item("nursinghome") = "X"
      End If
      If .ChkDisabled.Checked Then
        dr.Item("disabled") = "X"
      End If
      If .ChkTaxReturn.Checked Then
        dr.Item("taxreturnyes") = "X"
      Else
        dr.Item("taxreturnno") = "X"
      End If
      dr.Item("income") = MyUtils.CnvSng(.TxtIncome.Text)
      dr.Item("interest") = MyUtils.CnvSng(.TxtInterest.Text)
      dr.Item("ssrr") = MyUtils.CnvSng(.TxtSSRR.Text)
      dr.Item("other") = MyUtils.CnvSng(.TxtOther.Text)
      dr.Item("total") = MyUtils.CnvSng(.LblTotal.Text)
      dr.Item("signedmo") = Format(.DtPckSigned.Value.Month, "00")
      dr.Item("signedday") = Format(.DtPckSigned.Value.Day, "00")
      dr.Item("signedyear") = .DtPckSigned.Value.Year
      If MyUtils.CnvSng(.MskTxtPhone.Text) > 0 Then
        dr.Item("phone") = Format(MyUtils.CnvSng(.MskTxtPhone.Text), "(###) ###-0000")
      End If
      dr.Item("relate") = .TxtRelate.Text
      dr.Item("propct") = MyUtils.CnvSng(.TxtPropPct.Text)
      If .DtPckReceived.Checked Then
        dr.Item("receivedmo") = Format(.DtPckReceived.Value.Month, "00")
        dr.Item("receivedday") = Format(.DtPckReceived.Value.Day, "00")
        dr.Item("receivedyear") = .DtPckReceived.Value.Year
      End If
      dr.Item("pgross") = MyUtils.CnvSng(.TxtPGross.Text)
      dr.Item("gross") = MyUtils.CnvSng(.LblAppGross.Text)
      dr.Item("xblind") = MyUtils.CnvSng(.TxtBlind.Text)
      dr.Item("xdisab") = MyUtils.CnvSng(.TxtDisabled.Text)
      dr.Item("xvet") = MyUtils.CnvSng(.TxtVet.Text)
      dr.Item("xlocal") = MyUtils.CnvSng(.TxtLocal.Text)
      dr.Item("xaddl") = MyUtils.CnvSng(.TxtAddlVet.Text)
      dr.Item("net") = MyUtils.CnvSng(.LblNet.Text)
      dr.Item("millrate") = MyUtils.CnvSng(.LblMillRate.Text)
      If MyUtils.CnvSng(.TxtFrzTax.Text) > 0 Then
        dr.Item("frztax") = MyUtils.CnvSng(.TxtFrzTax.Text)
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


