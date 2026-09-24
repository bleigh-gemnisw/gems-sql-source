Module PrintForms
   Dim myBDCNTL As BDCNTL.myData
   Dim myBDRATE As BDRATE.myData
   Dim ds2 As DataSet
  Public Sub PrtPermit(WrkType As String, WrkTrandt As Date)
    Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim myreport2 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Dim ReportPath As String
    Dim WrkPermit As String
    Dim WrkPermitB As String
    Dim Good As Boolean

    myBDCNTL = New BDCNTL.mydata(MyDBConnect)
    myBDRATE = New BDRATE.mydata(MyDBConnect)

    WrkPermit = "PrtBD001.rpt"
    WrkPermitB = "PrtBD001B.rpt"
    If myTOWN._TOWNBR = 37 Then 'Derby
      If WrkTrandt <= #3/4/2021# Then
        WrkPermit = "PrtBD001-CM.rpt"
        WrkPermitB = "PrtBD001B-CM.rpt"
      End If
      If WrkTrandt >= #3/5/2021# And WrkTrandt <= #5/31/2021# Then
        WrkPermit = "PrtBD001-MB.rpt"
        WrkPermitB = "PrtBD001B-MB.rpt"
      End If
    End If
    If MyAppSettings.PermitPrinter <> "" Then
      Good = MyUtils.CheckPrinterExists(MyAppSettings.PermitPrinter)
      If Not Good Then
        MsgBox("Printer " & MyAppSettings.PermitPrinter & " does not exist. Click on settings button to change.", MsgBoxStyle.Exclamation, "Report cannot be printed")
        Exit Sub
      End If
    End If

    myBDCNTL.GetOneRecordP("")
    myBDRATE.GetFirstTier(WrkType)
    BuildDS2()
    Select Case Trim(WrkType)
      Case "DEMO"
        AddOneRecordCD()
        ReportPath = MyUtils.GetReportPath(WrkPermit, myTOWN._TOWNBR)
      Case "ELECT"
        AddOneRecordCE()
        ReportPath = MyUtils.GetReportPath(WrkPermit, myTOWN._TOWNBR)
      Case "FLIQ", "HVAC"
        AddOneRecordCH()
        ReportPath = MyUtils.GetReportPath(WrkPermit, myTOWN._TOWNBR)
      Case "P&Z"
        AddOneRecordCZ()
        ReportPath = MyUtils.GetReportPath("PrtBD001PZ.rpt", myTOWN._TOWNBR)
      Case Else
        AddOneRecordC()
        ReportPath = MyUtils.GetReportPath(WrkPermit, myTOWN._TOWNBR)
    End Select
    With myreport1
      .Load(ReportPath)
      If MyAppSettings.PermitPrinter <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.PermitPrinter
      End If
      .SetDataSource(ds2)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyReportTitle", Trim(myBDRATE._DESC))
      .SetParameterValue("MyDeptName", Trim(myBDCNTL._NAME))
      .SetParameterValue("MyAdd1", Trim(myBDCNTL._ADDR1))
      .SetParameterValue("MyCitySt", Trim(myBDCNTL._ADDR2))
      .SetParameterValue("MyPhone", "Phone: " & Trim(myBDCNTL._PHONE) & "  Fax: " & Trim(myBDCNTL._FAX))
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
    End With

    ReportPath = MyUtils.GetReportPath(WrkPermitB, myTOWN._TOWNBR)
    With myreport2
      .Load(ReportPath)
      If MyAppSettings.PermitPrinter <> "" Then
        .PrintOptions.PrinterName = MyAppSettings.PermitPrinter
      End If
      .SetDataSource(ds2)
      .SetParameterValue("MyTownName", Trim(myTOWN._TOWN))
      .SetParameterValue("MyReportTitle", Trim(myBDRATE._DESC))
      .SetParameterValue("MyDeptName", Trim(myBDCNTL._NAME))
      .SetParameterValue("MyAdd1", Trim(myBDCNTL._ADDR1))
      .SetParameterValue("MyCitySt", Trim(myBDCNTL._ADDR2))
      .SetParameterValue("MyPhone", "Phone: " & Trim(myBDCNTL._PHONE) & "  Fax: " & Trim(myBDCNTL._FAX))
      .PrintToPrinter(1, False, 0, 0)
      .Close()
      .Dispose()
    End With
  End Sub
  Private Sub BuildDS2()
    Dim myTable As New DataTable
    ds2 = New DataSet
    With myTable
      .TableName = "mytable"
      .Columns.Add("PermNo", Type.GetType("System.String"))
      .Columns.Add("PermLtr", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("TNName", Type.GetType("System.String"))
      .Columns.Add("Address", Type.GetType("System.String"))
      .Columns.Add("Phone", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Heatty", Type.GetType("System.String"))
      .Columns.Add("Tank", Type.GetType("System.String"))
      .Columns.Add("Tanklo", Type.GetType("System.String"))
      .Columns.Add("Eltype", Type.GetType("System.String"))
      .Columns.Add("Elyear", Type.GetType("System.Int32"))
      .Columns.Add("Elacct", Type.GetType("System.String"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("Fee", Type.GetType("System.Decimal"))
      .Columns.Add("PayType", Type.GetType("System.String"))
      .Columns.Add("PayRef", Type.GetType("System.String"))
      .Columns.Add("CoName", Type.GetType("System.String"))
      .Columns.Add("CoAddr", Type.GetType("System.String"))
      .Columns.Add("CoLic", Type.GetType("System.String"))
      .Columns.Add("CoPhone", Type.GetType("System.String"))
      .Columns.Add("Inspby", Type.GetType("System.String"))
      .Columns.Add("ApplDate", Type.GetType("System.DateTime"))
      .Columns.Add("ApprDate", Type.GetType("System.DateTime"))
      .Columns.Add("IntProp", Type.GetType("System.String"))
      .Columns.Add("Pzfrnt", Type.GetType("System.Boolean"))
      .Columns.Add("Pzwatr", Type.GetType("System.Boolean"))
      .Columns.Add("Pzsq", Type.GetType("System.Int32"))
      .Columns.Add("Pzuse", Type.GetType("System.Int32"))
      .Columns.Add("Bldgas", Type.GetType("System.String"))
      .Columns.Add("Consty", Type.GetType("System.String"))
      .Columns.Add("Dmsize", Type.GetType("System.String"))
      .Columns.Add("Dmstor", Type.GetType("System.Int32"))
      .Columns.Add("Dmdate", Type.GetType("System.DateTime"))
      .Columns.Add("Dmelec", Type.GetType("System.Boolean"))
      .Columns.Add("Dmgas", Type.GetType("System.Boolean"))
      .Columns.Add("Dmphon", Type.GetType("System.Boolean"))
      .Columns.Add("Dmsept", Type.GetType("System.Boolean"))
      .Columns.Add("Dmswr", Type.GetType("System.Boolean"))
      .Columns.Add("Dmwpca", Type.GetType("System.Boolean"))
    End With
    ds2.Tables.Add(myTable)
  End Sub
Sub AddOneRecordC()
  Dim myDr As Data.DataRow

  With MyFrmBD001C
    myDr = ds2.Tables(0).NewRow
    myDr("Permno") = .TxtPermitNo.Text
    myDr("Permltr") = .LblPermit.Text
    myDr("Location") = Trim(.TxtLocNo.Text) & " " & .TxtLoc.Text
    myDr("Name") = .TxtName.Text
    myDr("Tnname") = .TxtTenant.Text
    If .TxtAdd1.Text <> "" Then
      myDr("Address") = Trim(.TxtAdd1.Text) & "," & Trim(.TxtCity.Text) & "," & .TxtState.Text
    End If
    If MyUtils.CnvSng(.TxtZip5.Text) > 0 Then
      myDr("Address") = myDr("Address") & " " & Format(MyUtils.CnvSng(.TxtZip5.Text), "00000")
    End If
    myDr("Phone") = .TxtPhone.Text
    myDr("Desc") = .TxtDesc.Text
    myDr("Value") = MyUtils.CnvSng(.TxtValue.Text)
    myDr("Fee") = MyUtils.CnvSng(.LblTotal.Text)
    myDr("PayType") = ""
    If .RbCash.Checked Then
      myDr("PayType") = "Cash"
    End If
    If .RbCheck.Checked Then
      myDr("PayType") = "Check"
    End If
    If .RbCredit.Checked Then
      myDr("PayType") = "Credit"
    End If
    myDr("PayRef") = .TxtPayRef.Text
    myDr("CoName") = .TxtCoName.Text
    myDr("CoAddr") = Trim(.TxtCoAddr.Text) & "," & Trim(.TxtCoCity.Text) & "," & Trim(.TxtCoState.Text)
    If MyUtils.CnvSng(.TxtCoZip.Text) > 0 Then
      myDr("CoAddr") = myDr("CoAddr") & " " & Format(MyUtils.CnvSng(.TxtCoZip.Text), "00000")
    End If
    myDr("CoLic") = .TxtCoLic.Text
    myDr("CoPhone") = .TxtCoPhon.Text
    If .DtPckInsp.Checked Then
      myDr("Inspby") = Format(.DtPckInsp.Value, "Short Date")
    End If
    myDr("ApplDate") = .DtPckApp.Value
    myDr("ApprDate") = .DtPckTran.Value
    ds2.Tables(0).Rows.Add(myDr)
  End With
End Sub
Sub AddOneRecordCD()
  Dim myDr As Data.DataRow

  With MyFrmBD001CD
    myDr = ds2.Tables(0).NewRow
    myDr("Permno") = .TxtPermitNo.Text
    myDr("Permltr") = .LblPermit.Text
    myDr("Location") = Trim(.TxtLocNo.Text) & " " & .TxtLoc.Text
    myDr("Name") = .TxtName.Text
    myDr("Tnname") = ""
    If .TxtAdd1.Text <> "" Then
      myDr("Address") = Trim(.TxtAdd1.Text) & "," & Trim(.TxtCity.Text) & "," & .TxtState.Text
    End If
    If MyUtils.CnvSng(.TxtZip5.Text) > 0 Then
      myDr("Address") = myDr("Address") & " " & Format(MyUtils.CnvSng(.TxtZip5.Text), "00000")
    End If
    myDr("Phone") = .TxtPhone.Text
    myDr("Desc") = .TxtDesc.Text
    myDr("Value") = MyUtils.CnvSng(.TxtValue.Text)
    myDr("Fee") = MyUtils.CnvSng(.LblTotal.Text)
    myDr("PayType") = ""
    If .RbCash.Checked Then
      myDr("PayType") = "Cash"
    End If
    If .RbCheck.Checked Then
      myDr("PayType") = "Check"
    End If
    If .RbCredit.Checked Then
      myDr("PayType") = "Credit"
    End If
    myDr("PayRef") = .TxtPayRef.Text
    myDr("Bldgas") = .TxtBldgas.Text
    myDr("Consty") = .TxtConsty.Text
    myDr("Dmsize") = .TxtSize.Text
    myDr("Dmstor") = MyUtils.CnvSng(.TxtStory.Text)
    myDr("Dmdate") = .DtPckStart.Value
    myDr("Dmelec") = .ChkElec.Checked
    myDr("Dmgas") = .ChkGas.Checked
    myDr("Dmphon") = .ChkPhone.Checked
    myDr("Dmsept") = .ChkSeptic.Checked
    myDr("Dmswr") = .ChkSewer.Checked
    myDr("Dmwpca") = .ChkWPCA.Checked
    myDr("CoName") = .TxtCoName.Text
    myDr("CoAddr") = Trim(.TxtCoAddr.Text) & "," & Trim(.TxtCoCity.Text) & "," & Trim(.TxtCoState.Text)
    If MyUtils.CnvSng(.TxtCoZip.Text) > 0 Then
      myDr("CoAddr") = myDr("CoAddr") & " " & Format(MyUtils.CnvSng(.TxtCoZip.Text), "00000")
    End If
    myDr("CoLic") = .TxtCoLic.Text
    myDr("CoPhone") = .TxtCoPhon.Text
    If .DtPckInsp.Checked Then
      myDr("Inspby") = Format(.DtPckInsp.Value, "Short Date")
    End If
    myDr("ApplDate") = .DtPckApp.Value
    myDr("ApprDate") = .DtPckTran.Value
    ds2.Tables(0).Rows.Add(myDr)
  End With
End Sub
Sub AddOneRecordCE()
  Dim myDr As Data.DataRow

  With MyFrmBD001CE
    myDr = ds2.Tables(0).NewRow
    myDr("Permno") = .TxtPermitNo.Text
    myDr("Permltr") = .LblPermit.Text
    myDr("Location") = Trim(.TxtLocNo.Text) & " " & .TxtLoc.Text
    myDr("Name") = .TxtName.Text
    myDr("Tnname") = .TxtTenant.Text
    If .TxtAdd1.Text <> "" Then
      myDr("Address") = Trim(.TxtAdd1.Text) & "," & Trim(.TxtCity.Text) & "," & .TxtState.Text
    End If
    If MyUtils.CnvSng(.TxtZip5.Text) > 0 Then
      myDr("Address") = myDr("Address") & " " & Format(MyUtils.CnvSng(.TxtZip5.Text), "00000")
    End If
    myDr("Phone") = .TxtPhone.Text
    myDr("Desc") = .TxtDesc.Text
    myDr("Value") = MyUtils.CnvSng(.TxtValue.Text)
    myDr("Fee") = MyUtils.CnvSng(.LblTotal.Text)
    myDr("PayType") = ""
    If .RbCash.Checked Then
      myDr("PayType") = "Cash"
    End If
    If .RbCheck.Checked Then
      myDr("PayType") = "Check"
    End If
    If .RbCredit.Checked Then
      myDr("PayType") = "Credit"
    End If
    myDr("PayRef") = .TxtPayRef.Text
    If .RbIRC.Checked Then
      myDr("Eltype") = "IRC"
      myDr("Elyear") = myBDCNTL._IRCYR
    End If
    If .RbNec.Checked Then
      myDr("Eltype") = "NEC"
      myDr("Elyear") = myBDCNTL._NECYR
    End If
    myDr("Elacct") = .TxtElAcct.Text
    myDr("CoName") = .TxtCoName.Text
    myDr("CoAddr") = Trim(.TxtCoAddr.Text) & "," & Trim(.TxtCoCity.Text) & "," & Trim(.TxtCoState.Text)
    If MyUtils.CnvSng(.TxtCoZip.Text) > 0 Then
      myDr("CoAddr") = myDr("CoAddr") & " " & Format(MyUtils.CnvSng(.TxtCoZip.Text), "00000")
    End If
    myDr("CoLic") = .TxtCoLic.Text
    myDr("CoPhone") = .TxtCoPhon.Text
    If .DtPckInsp.Checked Then
      myDr("Inspby") = Format(.DtPckInsp.Value, "Short Date")
    End If
    myDr("ApplDate") = .DtPckApp.Value
    myDr("ApprDate") = .DtPckTran.Value
    ds2.Tables(0).Rows.Add(myDr)
  End With
End Sub
Sub AddOneRecordCH()
  Dim myDr As Data.DataRow

  With MyFrmBD001CH
    myDr = ds2.Tables(0).NewRow
    myDr("Permno") = .TxtPermitNo.Text
    myDr("Permltr") = .LblPermit.Text
    myDr("Location") = Trim(.TxtLocNo.Text) & " " & .TxtLoc.Text
    myDr("Name") = .TxtName.Text
    myDr("Tnname") = .TxtTenant.Text
    If .TxtAdd1.Text <> "" Then
      myDr("Address") = Trim(.TxtAdd1.Text) & "," & Trim(.TxtCity.Text) & "," & .TxtState.Text
    End If
    If MyUtils.CnvSng(.TxtZip5.Text) > 0 Then
      myDr("Address") = myDr("Address") & " " & Format(MyUtils.CnvSng(.TxtZip5.Text), "00000")
    End If
    myDr("Phone") = .TxtPhone.Text
    myDr("Desc") = .TxtDesc.Text
    myDr("Value") = MyUtils.CnvSng(.TxtValue.Text)
    myDr("Fee") = MyUtils.CnvSng(.LblTotal.Text)
    myDr("PayType") = ""
    If .RbCash.Checked Then
      myDr("PayType") = "Cash"
    End If
    If .RbCheck.Checked Then
      myDr("PayType") = "Check"
    End If
    If .RbCredit.Checked Then
      myDr("PayType") = "Credit"
    End If
    myDr("PayRef") = .TxtPayRef.Text
    myDr("Heatty") = .TxtHeatty.Text
    myDr("Tank") = .TxtTank.Text
    myDr("TankLo") = .TxtTankLo.Text
    myDr("CoName") = .TxtCoName.Text
    myDr("CoAddr") = Trim(.TxtCoAddr.Text) & "," & Trim(.TxtCoCity.Text) & "," & Trim(.TxtCoState.Text)
    If MyUtils.CnvSng(.TxtCoZip.Text) > 0 Then
      myDr("CoAddr") = myDr("CoAddr") & " " & Format(MyUtils.CnvSng(.TxtCoZip.Text), "00000")
    End If
    myDr("CoLic") = .TxtCoLic.Text
    myDr("CoPhone") = .TxtCoPhon.Text
    If .DtPckInsp.Checked Then
      myDr("Inspby") = Format(.DtPckInsp.Value, "Short Date")
    End If
    myDr("ApplDate") = .DtPckApp.Value
    myDr("ApprDate") = .DtPckTran.Value
    ds2.Tables(0).Rows.Add(myDr)
  End With
End Sub
Sub AddOneRecordCZ()
  Dim myDr As Data.DataRow

  With MyFrmBD001CZ
    myDr = ds2.Tables(0).NewRow
    myDr("Permno") = .TxtPermitNo.Text
    myDr("Permltr") = .LblPermit.Text
    myDr("Location") = Trim(.TxtLocNo.Text) & " " & .TxtLoc.Text
    myDr("Name") = .TxtName.Text
    myDr("Tnname") = ""
    If .TxtAdd1.Text <> "" Then
      myDr("Address") = Trim(.TxtAdd1.Text) & "," & Trim(.TxtCity.Text) & "," & .TxtState.Text
    End If
    If MyUtils.CnvSng(.TxtZip5.Text) > 0 Then
      myDr("Address") = myDr("Address") & " " & Format(MyUtils.CnvSng(.TxtZip5.Text), "00000")
    End If
    myDr("Desc") = .TxtDesc.Text
    myDr("Value") = MyUtils.CnvSng(.TxtValue.Text)
    myDr("Fee") = MyUtils.CnvSng(.LblTotal.Text)
    myDr("PayType") = ""
    If .RbCash.Checked Then
      myDr("PayType") = "Cash"
    End If
    If .RbCheck.Checked Then
      myDr("PayType") = "Check"
    End If
    If .RbCredit.Checked Then
      myDr("PayType") = "Credit"
    End If
    myDr("PayRef") = .TxtPayRef.Text
    If .DtPckInsp.Checked Then
      myDr("Inspby") = Format(.DtPckInsp.Value, "Short Date")
    End If
    myDr("ApplDate") = .DtPckApp.Value
    myDr("ApprDate") = .DtPckTran.Value
    If .RbPropOpt.Checked Then myDr("IntProp") = "Option to buy"
    If .RbPropOther.Checked Then myDr("IntProp") = "Other"
    If .RbPropOwn.Checked Then myDr("IntProp") = "Own"
    If .RbPropRent.Checked Then myDr("IntProp") = "Rent"
    myDr("Pzfrnt") = .ChkCityFront.Checked
    myDr("Pzwatr") = .ChkCityWater.Checked
    myDr("Pzsq") = MyUtils.CnvSng(.TxtPropSqFoot.Text)
    myDr("Pzuse") = MyUtils.CnvSng(.TxtFloorSqfoot.Text)
    ds2.Tables(0).Rows.Add(myDr)
  End With
End Sub
End Module






