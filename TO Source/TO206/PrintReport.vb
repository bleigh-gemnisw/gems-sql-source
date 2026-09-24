Module PrintReport
Public Sub PrtReport()
    Dim dr As Data.DataRow
    Dim WrkYear As Integer
    Dim WrkDist As Integer
    Dim WrkMill As Decimal
    Dim WrkMVMill As Decimal

    With MyFrmTO206B
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      BufferExem()
    Else
      ds.Clear()
      dsDtl.Clear()
      ClearSharedTotals()
    End If

    GetTXPROF("R", WrkYear, "", WrkDist)
    WrkREDueDate2 = String.Empty
    WrkREDueDate3 = String.Empty
    WrkREDueDate4 = String.Empty
    With myTXPROF
      WrkREDueDate1 = Format(MyUtils.GetDBDateMDY(._PRDUE1), "M/d/yyyy")
      If ._PRDUE2 > 0 Then
        WrkREDueDate2 = Format(MyUtils.GetDBDateMDY(._PRDUE2), "M/d/yyyy")
      End If
      If ._PRDUE3 > 0 Then
        WrkREDueDate3 = Format(MyUtils.GetDBDateMDY(._PRDUE3), "M/d/yyyy")
      End If
      If ._PRDUE4 > 0 Then
        WrkREDueDate4 = Format(MyUtils.GetDBDateMDY(._PRDUE4), "M/d/yyyy")
      End If
    End With
    GetTXPROF("P", WrkYear, "", WrkDist)
    WrkPPDueDate2 = String.Empty
    WrkPPDueDate3 = String.Empty
    WrkPPDueDate4 = String.Empty
    With myTXPROF
      WrkPPDueDate1 = Format(MyUtils.GetDBDateMDY(._PRDUE1), "M/dd/yyyy")
      If ._PRDUE2 > 0 Then
        WrkPPDueDate2 = Format(MyUtils.GetDBDateMDY(._PRDUE2), "M/d/yyyy")
      End If
      If ._PRDUE3 > 0 Then
        WrkPPDueDate3 = Format(MyUtils.GetDBDateMDY(._PRDUE3), "M/d/yyyy")
      End If
      If ._PRDUE4 > 0 Then
        WrkPPDueDate4 = Format(MyUtils.GetDBDateMDY(._PRDUE4), "M/d/yyyy")
      End If
    End With
    GetTXPROF("M", WrkYear, "", WrkDist)
    WrkMVDueDate2 = String.Empty
    WrkMVDueDate3 = String.Empty
    WrkMVDueDate4 = String.Empty
    With myTXPROF
      WrkMVDueDate1 = Format(MyUtils.GetDBDateMDY(._PRDUE1), "M/dd/yyyy")
      If ._PRDUE2 > 0 Then
        WrkMVDueDate2 = Format(MyUtils.GetDBDateMDY(._PRDUE2), "M/d/yyyy")
      End If
      If ._PRDUE3 > 0 Then
        WrkMVDueDate3 = Format(MyUtils.GetDBDateMDY(._PRDUE3), "M/d/yyyy")
      End If
      If ._PRDUE4 > 0 Then
        WrkMVDueDate4 = Format(MyUtils.GetDBDateMDY(._PRDUE4), "M/d/yyyy")
      End If
    End With

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Processing Supplemental MV..."
    myFrmProgress.ProgBar1.Value = 0
    myFrmProgress.Refresh()
    myFrmProgress.Show()
    Application.DoEvents()
    GetTXMRATE(WrkYear - 1, "S", WrkDist)
    PrtReportSU()
    myFrmProgress.LblMsg.Text = "Processing Real Estate..."
    myFrmProgress.ProgBar1.Value = 0
    myFrmProgress.Refresh()
    Application.DoEvents()
    GetTXMRATE(WrkYear, "R", WrkDist)
    PrtReportRE()
    myFrmProgress.LblMsg.Text = "Processing Motor Vehicle..."
    myFrmProgress.ProgBar1.Value = 0
    myFrmProgress.Refresh()
    Application.DoEvents()
    GetTXMRATE(WrkYear, "M", WrkDist)
    PrtReportMV()
    myFrmProgress.LblMsg.Text = "Processing Personal Property..."
    myFrmProgress.ProgBar1.Value = 0
    myFrmProgress.Refresh()
    Application.DoEvents()
    GetTXMRATE(WrkYear, "P", WrkDist)
    PrtReportPP()
    myFrmProgress.Close()
    Application.DoEvents()
    GetOPMColl()

    WrkMill = myTXMRATE._MRRATE
    WrkMVmill = 0
    myTXMRATE.GetOneRecordP(WrkYear, "M", WrkDist)
    If Not myTXMRATE.RecordNotFound Then
      WrkMVmill = myTXMRATE._MRRATE
    End If
    dr = ds.Tables(0).NewRow
    dr.Item("address") = WrkAddress
    dr.Item("townzip") = WrkTownZip
    dr.Item("phone") = WrkPhone
    dr.Item("email") = WrkEMail
    With MyFrmTO206B
      If .RbMunTown.Checked Then dr.Item("muntown") = "X"
      If .RbMunBur.Checked Then dr.Item("munbur") = "X"
      If .RbMunCity.Checked Then dr.Item("muncity") = "X"
      If .RbDistFire.Checked Then dr.Item("distfire") = "X"
      If .RbDistSewer.Checked Then dr.Item("distsewer") = "X"
      If .RbDistLighting.Checked Then dr.Item("distlighting") = "X"
      If .RbDistVillage.Checked Then dr.Item("distvillage") = "X"
      If .RbDistBeach.Checked Then dr.Item("distbeach") = "X"
      If .RbDistImprovement.Checked Then dr.Item("distimprovement") = "X"
      dr.Item("distother") = .TxtDistOther.Text
      If .RbCollApp.Checked Then dr.Item("collapp") = "X"
      If .RbCollElect.Checked Then dr.Item("collelect") = "X"
      If .ChkCreditCard.Checked Then
        dr.Item("creditcardyes") = "X"
        dr.Item("creditcardno") = ""
      Else
        dr.Item("creditcardyes") = ""
        dr.Item("creditcardno") = "X"
      End If
      dr.Item("collected") = MyUtils.CnvSng(.TxtCollected.Text)
      If .ChkCreditAll.Checked Then
        dr.Item("creditallyes") = "X"
        dr.Item("creditallno") = ""
      Else
        dr.Item("creditallyes") = ""
        dr.Item("creditallno") = "X"
      End If
      dr.Item("creditrestrict") = .TxtCreditRestrict.Text
      If .ChkLiens.Checked Then
        dr.Item("liensyes") = "X"
        dr.Item("liensno") = ""
      Else
        dr.Item("liensyes") = ""
        dr.Item("liensno") = "X"
      End If
      dr.Item("millrateday") = .TxtMillRateDay.Text
      dr.Item("millratemonth") = .TxtMillRateMonth.Text
      dr.Item("millrate") = WrkMill * 1000
      dr.Item("millratemv") = WrkMVMill * 1000
      dr.Item("millrateauthority") = .TxtMillRateAuthority.Text
    End With
    dr.Item("totre") = WrkTotalRE
    dr.Item("totmv") = WrkTotalMV
    dr.Item("totpp") = WrkTotalPP
    dr.Item("tot") = WrkTotalRE + WrkTotalMV + WrkTotalPP
    dr.Item("totsu") = WrkTotalSU
    dr.Item("reduedate1") = WrkREDueDate1
    dr.Item("reduedate2") = WrkREDueDate2
    dr.Item("reduedate3") = WrkREDueDate3
    dr.Item("reduedate4") = WrkREDueDate4
    dr.Item("ppduedate1") = WrkPPDueDate1
    dr.Item("ppduedate2") = WrkPPDueDate2
    dr.Item("ppduedate3") = WrkPPDueDate3
    dr.Item("ppduedate4") = WrkPPDueDate4
    dr.Item("mvduedate1") = WrkMVDueDate1
    dr.Item("mvduedate2") = WrkMVDueDate2
    dr.Item("mvduedate3") = WrkMVDueDate3
    dr.Item("mvduedate4") = WrkMVDueDate4
    ds.Tables(0).Rows.Add(dr)

    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds = ds
      .WrkdsDtl = dsDtl
      .Show()
    End With
End Sub

End Module






