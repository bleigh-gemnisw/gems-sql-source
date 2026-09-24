Imports System.Text
Module PrintReport

  Dim Ds As DataSet = New DataSet
  Dim WrkHeader1 As String
  Dim WrkHeader2 As String
  Dim WrkHeader3 As String
  Dim WrkLimitSing As Decimal
  Dim WrkLimitMarr As Decimal
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
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("ALName", Type.GetType("System.String"))
      .Columns.Add("AFName", Type.GetType("System.String"))
      .Columns.Add("AInit", Type.GetType("System.String"))
      .Columns.Add("ADOB", Type.GetType("System.String"))
      .Columns.Add("ASSN", Type.GetType("System.String"))
      .Columns.Add("SLName", Type.GetType("System.String"))
      .Columns.Add("SFName", Type.GetType("System.String"))
      .Columns.Add("SInit", Type.GetType("System.String"))
      .Columns.Add("SDOB", Type.GetType("System.String"))
      .Columns.Add("SSSN", Type.GetType("System.String"))
      .Columns.Add("MADDR", Type.GetType("System.String"))
      .Columns.Add("MCITY", Type.GetType("System.String"))
      .Columns.Add("MSTATE", Type.GetType("System.String"))
      .Columns.Add("MZIP", Type.GetType("System.String"))
      .Columns.Add("PADDR", Type.GetType("System.String"))
      .Columns.Add("PCITY", Type.GetType("System.String"))
      .Columns.Add("PSTATE", Type.GetType("System.String"))
      .Columns.Add("PZIP", Type.GetType("System.String"))
      .Columns.Add("OWNER", Type.GetType("System.String"))
      .Columns.Add("CIVILUNION", Type.GetType("System.String"))
      .Columns.Add("MARRIED", Type.GetType("System.String"))
      .Columns.Add("UNMARRIED", Type.GetType("System.String"))
      .Columns.Add("SURVIVING", Type.GetType("System.String"))
      .Columns.Add("NURSINGHOME", Type.GetType("System.String"))
      .Columns.Add("DISABLED", Type.GetType("System.String"))
      .Columns.Add("TAXRETURNYES", Type.GetType("System.String"))
      .Columns.Add("TAXRETURNNO", Type.GetType("System.String"))
      .Columns.Add("INCOME", Type.GetType("System.Decimal"))
      .Columns.Add("INTEREST", Type.GetType("System.Decimal"))
      .Columns.Add("SSRR", Type.GetType("System.Decimal"))
      .Columns.Add("OTHER", Type.GetType("System.Decimal"))
      .Columns.Add("TOTAL", Type.GetType("System.Decimal"))
      .Columns.Add("SIGNEDMO", Type.GetType("System.String"))
      .Columns.Add("SIGNEDDAY", Type.GetType("System.String"))
      .Columns.Add("SIGNEDYEAR", Type.GetType("System.String"))
      .Columns.Add("PHONE", Type.GetType("System.String"))
      .Columns.Add("RELATE", Type.GetType("System.String"))
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
      .Columns.Add("TAX", Type.GetType("System.Decimal"))
      .Columns.Add("FRZTAX", Type.GetType("System.Decimal"))
      .Columns.Add("TABLEPCT", Type.GetType("System.Int16"))
      .Columns.Add("CREDITMAX", Type.GetType("System.Decimal"))
      .Columns.Add("CEILING", Type.GetType("System.Decimal"))
      .Columns.Add("LESSER", Type.GetType("System.Decimal"))
      .Columns.Add("MINGRANT", Type.GetType("System.Decimal"))
      .Columns.Add("CREDIT", Type.GetType("System.Decimal"))
      .Columns.Add("ALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISALLOWED", Type.GetType("System.String"))
      .Columns.Add("DISRSN", Type.GetType("System.String"))
      .Columns.Add("ASSRMO", Type.GetType("System.String"))
      .Columns.Add("ASSRDAY", Type.GetType("System.String"))
      .Columns.Add("ASSRYEAR", Type.GetType("System.String"))
      .Columns.Add("LOCPGM", Type.GetType("System.String"))
      .Columns.Add("LOCHEADER1", Type.GetType("System.String"))
      .Columns.Add("LOCHEADER2", Type.GetType("System.String"))
      .Columns.Add("LOCHEADER3", Type.GetType("System.String"))
      .Columns.Add("LOCTRF", Type.GetType("System.Decimal"))
      .Columns.Add("LOCBENEFIT", Type.GetType("System.Decimal"))
      .Columns.Add("LOCDEFERPLAN", Type.GetType("System.String"))
      .Columns.Add("LOCDEFERRAL", Type.GetType("System.Decimal"))
      .Columns.Add("LIMITSING", Type.GetType("System.Decimal"))
      .Columns.Add("LIMITMARR", Type.GetType("System.Decimal"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail(ByVal WrkPgm As String)
    Dim dr As Data.DataRow
    Dim sb As StringBuilder

    With MyFrmTO201D
      dr = Ds.Tables(0).NewRow
      dr.Item("listno") = MyUtils.CnvSng(.TxtListNo.Text)
      dr.Item("year") = MyUtils.CnvSng(.TxtYear.Text)
      dr.Item("alname") = .TxtALName.Text
      dr.Item("afname") = .TxtAFName.Text
      dr.Item("ainit") = .TxtAInit.Text
      sb = New StringBuilder
      sb.Append(Format(.DtPckADOB.Value.Month, "00"))
      sb.Append("  /  ")
      sb.Append(Format(.DtPckADOB.Value.Day, "00"))
      sb.Append("  /  ")
      sb.Append(.DtPckADOB.Value.Year)
      dr.Item("adob") = sb.ToString
      sb = Nothing
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
        sb.Append(Format(.DtPckSDOB.Value.Month, "00"))
        sb.Append("  /  ")
        sb.Append(Format(.DtPckSDOB.Value.Day, "00"))
        sb.Append("  /  ")
        sb.Append(.DtPckSDOB.Value.Year)
        dr.Item("sdob") = sb.ToString
        sb = Nothing
        sb = New StringBuilder
        sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtSSSN.Text, 1, 3)), "000"))
        sb.Append("  -  ")
        sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtSSSN.Text, 4, 2)), "00"))
        sb.Append("  -  ")
        sb.Append(Format(MyUtils.CnvSng(Mid(.MskTxtSSSN.Text, 6, 4)), "0000"))
        dr.Item("sssn") = sb.ToString
        sb = Nothing
      End If
      dr.Item("maddr") = .TxtMAddr.Text
      dr.Item("mcity") = .TxtMCity.Text
      dr.Item("mstate") = .TxtMState.Text
      dr.Item("mzip") = Format(MyUtils.CnvSng(.TxtMZip.Text), "00000")
      dr.Item("paddr") = .TxtPAddr.Text
      dr.Item("pcity") = .TxtPCity.Text
      dr.Item("pstate") = .TxtPState.Text
      If MyUtils.CnvSng(.TxtPZip.Text) > 0 Then
        dr.Item("pzip") = Format(MyUtils.CnvSng(.TxtPZip.Text), "00000")
      End If
      dr.Item("owner") = .TxtOwner.Text
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
        dr.Item("tax") = 0
        dr.Item("frztax") = MyUtils.CnvSng(.TxtFrzTax.Text)
      Else
        dr.Item("tax") = MyUtils.CnvSng(.LblTax.Text)
        dr.Item("frztax") = 0
      End If
      dr.Item("tablepct") = MyUtils.CnvSng(.TxtTablePct.Text)
      dr.Item("creditmax") = MyUtils.CnvSng(.LblCreditMax.Text)
      dr.Item("ceiling") = MyUtils.CnvSng(.TxtCeiling.Text)
      dr.Item("lesser") = MyUtils.CnvSng(.LblLesser.Text)
      dr.Item("mingrant") = MyUtils.CnvSng(.TxtMinGrant.Text)
      dr.Item("credit") = MyUtils.CnvSng(.LblCredit.Text)
      Select Case WrkPgm
        Case "State"
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
        Case Else
          dr.Item("loctrf") = MyUtils.CnvSng(.LblTRF.Text)
          dr.Item("locdeferplan") = ""
          If .RbDeferPlanA.Checked Then
            dr.Item("locdeferplan") = "Plan A (98%)"
          End If
          If .RbDeferPlanA.Checked Then
            dr.Item("locdeferplan") = "Plan B (50%)"
          End If
          dr.Item("locdeferral") = MyUtils.CnvSng(.LblLocDeferral.Text)
          dr.Item("locbenefit") = MyUtils.CnvSng(.LblLocCredit.Text)
          If .RbLocAllowed.Checked Then
            dr.Item("allowed") = "X"
          End If
          If .RbLocDisallowed.Checked Then
            dr.Item("disallowed") = "X"
          End If
          dr.Item("disrsn") = .TxtLocDisallowReason.Text
          If .DtPckAssr.Checked Then
            dr.Item("assrmo") = Format(.DtPckLocAssr.Value.Month, "00")
            dr.Item("assrday") = Format(.DtPckLocAssr.Value.Day, "00")
            dr.Item("assryear") = .DtPckLocAssr.Value.Year
          End If
          GetHeadings(WrkPgm)
          dr.Item("locpgm") = WrkPgm
          dr.Item("locheader1") = WrkHeader1
          dr.Item("locheader2") = WrkHeader2
          dr.Item("locheader3") = WrkHeader3
          dr.Item("limitsing") = WrkLimitSing
          dr.Item("limitmarr") = WrkLimitMarr
      End Select
      Ds.Tables(0).Rows.Add(dr)
    End With
  End Sub
  Private Sub GetHeadings(ByVal WrkPgm As String)
    Select Case Trim(WrkPgm)
      Case "212"
        WrkHeader1 = "APPLICATION FOR TAX CREDITS"
        WrkHeader2 = "ORDINANCE 212"
        WrkHeader3 = "TAX DEFERRAL PROGRAM FOR ELDERLY AND/OR TOTALY DISABLED RESIDENTS"
      Case "250"
        WrkHeader1 = "APPLICATION FOR TAX CREDITS"
        WrkHeader2 = "ORDINANCE 250"
        WrkHeader3 = "TAX DEFERRAL PROGRAM FOR ELDERLY AND/OR TOTALY DISABLED RESIDENTS"
      Case "LOC"
        WrkHeader1 = "APPLICATION FOR LOCAL OPTION HOMEOWNER TAX CREDIT"
        WrkHeader2 = "FILE BIENNIALLY"
        WrkHeader3 = "FILING PERIOD FEB 1 - MAY 15"
      Case "LL", "LH"
        WrkHeader1 = "LOCAL TAX CREDIT BENEFIT"
        WrkHeader2 = "PROVIDED BY LOCAL ORDINANCE"
        WrkHeader3 = "Milford Ordinance 20.5-6 as authorized by Section 12-129n CGS"
        WrkLimitSing = MyUtils.CnvSng(MyFrmTO201D.LblLocSingle.Text)
        WrkLimitMarr = MyUtils.CnvSng(MyFrmTO201D.LblLocMarried.Text)
      Case "EBC"
        WrkHeader1 = "APPLICATION FOR TOTALLY DISABLED EXEMPTION"
        WrkHeader2 = "Public Act 85-294"
        WrkHeader3 = ""
        WrkLimitSing = MyUtils.CnvSng(MyFrmTO201D.LblStSingle.Text)
        WrkLimitMarr = MyUtils.CnvSng(MyFrmTO201D.LblStMarried.Text)
      Case "FBC"
        WrkHeader1 = "APPLICATION FOR BLIND EXEMPTION"
        WrkHeader2 = "Public Act 85-294"
        WrkHeader3 = ""
        WrkLimitSing = MyUtils.CnvSng(MyFrmTO201D.LblStSingle.Text)
        WrkLimitMarr = MyUtils.CnvSng(MyFrmTO201D.LblStMarried.Text)
      Case Else
        WrkHeader1 = ""
        WrkHeader2 = ""
        WrkHeader3 = ""
    End Select
  End Sub
End Module






