Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myFAMSTRQ As FAMSTRQ.MyData
  Dim ds1 As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim DsFAMSTR As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkAcqFrom As Integer
  Dim WrkAcqTo As Integer
  Dim WrkDspFrom As Integer
  Dim WrkDspTo As Integer
  Dim WrkAsTypeFrom As String
  Dim WrkAsTypeTo As String
  Dim WrkBldgFrom As String
  Dim WrkBldgTo As String
  Dim WrkClassFrom As String
  Dim WrkClassTo As String
  Dim WrkDeptFrom As String
  Dim WrkDeptTo As String
  Dim WrkEqupFrom As String
  Dim WrkEqupTo As String
  Dim WrkUser1From As String
  Dim WrkUser1To As String
  Dim WrkUser2From As String
  Dim WrkUser2To As String
  Dim WrkUser3From As String
  Dim WrkUser3To As String
  Dim WrkAssetValFrom As Integer
  Dim WrkAssetValTo As Integer
  Dim WrkPSort As String
  Dim WrkSSort As String

  Dim WrkTAcqVal As Integer
  Dim WrkTAcqCount As Integer
  Dim WrkTDspVal As Integer
  Dim WrkTDspCount As Integer
  Dim WrkTDeprVal As Integer
  Dim WrkTNetVal As Integer
  'Buffered files
  Dim WrkAcqCode(100) As String
  Dim WrkAcqDesc(100) As String
  Dim WrkDspCode(100) As String
  Dim WrkDspDesc(100) As String

  Public Sub PrtReport()
    Dim WrkSortby As String
    myFAMSTRQ = New FAMSTRQ.MyData()
    myFAMSTRQ.MyDBConn = myDBConnect

    With MyFrmFA100B
      WrkAcqFrom = 0
      WrkAcqTo = 0
      WrkDspFrom = 0
      WrkDspTo = 0
      If .DtPckAcqFrom.Checked Then
        WrkAcqFrom = MyUtils.SetDBDate(.DtPckAcqFrom.Value)
      End If
      If .DtPckAcqTo.Checked Then
        WrkAcqTo = MyUtils.SetDBDate(.DtPckAcqTo.Value)
      End If
      If .DtPckDspTo.Checked Then
        WrkDspFrom = MyUtils.SetDBDate(.DtPckDspFrom.Value)
      End If
      If .DtPckDspTo.Checked Then
        WrkDspTo = MyUtils.SetDBDate(.DtPckDspTo.Value)
      End If
      WrkAsTypeFrom = .TxtAsTypeFrom.Text
      WrkAsTypeTo = .TxtAsTypeTo.Text
      WrkBldgFrom = .TxtBldgFrom.Text
      WrkBldgTo = .TxtBldgTo.Text
      WrkClassFrom = .TxtClassFrom.Text
      WrkClassTo = .TxtClassTo.Text
      WrkDeptFrom = .TxtDeptFrom.Text
      WrkDeptTo = .TxtDeptTo.Text
      WrkEqupFrom = .TxtEqupFrom.Text
      WrkEqupTo = .TxtEqupTo.Text
      WrkUser1From = .TxtUser1From.Text
      WrkUser1To = .TxtUser1To.Text
      WrkUser2From = .TxtUser2From.Text
      WrkUser2To = .TxtUser2To.Text
      WrkUser3From = .TxtUser3From.Text
      WrkUser3To = .TxtUser3To.Text
      WrkAssetValFrom = MyUtils.CnvSng(.TxtAssetValFrom.Text)
      WrkAssetValTo = MyUtils.CnvSng(.TxtAssetValTo.Text)

      WrkPSort = ""
      If .RbPAssetType.Checked Then
        WrkPSort = "Asset Type"
      End If
      If .RbPClassification.Checked Then
        WrkPSort = "Classification"
      End If
      If .RbPCondition.Checked Then
        WrkPSort = "Equipment Condition"
      End If
      If .RbPDepartment.Checked Then
        WrkPSort = "Department"
      End If
      If .RbPLocation.Checked Then
        WrkPSort = "Location"
      End If
      If .RbPVendor.Checked Then
        WrkPSort = "Vendor"
      End If
      If .RbPGLGrouping.Checked Then
        WrkPSort = "GLGrouping"
      End If
      If .RbPUser1.Checked Then
        WrkPSort = "User1"
      End If
      If .RbPUser2.Checked Then
        WrkPSort = "User2"
      End If
      If .RbPUser3.Checked Then
        WrkPSort = "User3"
      End If
      If .RbPUser4.Checked Then
        WrkPSort = "User4"
      End If
      If .RbPUser5.Checked Then
        WrkPSort = "User5"
      End If

      WrkSSort = ""
      If .RbSAssetType.Checked Then
        WrkSSort = "Asset Type"
      End If
      If .RbSClassification.Checked Then
        WrkSSort = "Classification"
      End If
      If .RbSCondition.Checked Then
        WrkSSort = "Equipment Condition"
      End If
      If .RbSDepartment.Checked Then
        WrkSSort = "Department"
      End If
      If .RbSLocation.Checked Then
        WrkSSort = "Location"
      End If
      If .RbSVendor.Checked Then
        WrkSSort = "Vendor"
      End If
      If .RbSGLGrouping.Checked Then
        WrkSSort = "GLGrouping"
      End If
      If .RbSUser1.Checked Then
        WrkSSort = "User1"
      End If
      If .RbSUser2.Checked Then
        WrkSSort = "User2"
      End If
      If .RbSUser3.Checked Then
        WrkSSort = "User3"
      End If
      If .RbSUser4.Checked Then
        WrkSSort = "User4"
      End If
      If .RbSUser5.Checked Then
        WrkSSort = "User5"
      End If
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
      ds2.Clear()
      ClearTotals()
    End If

    BufferAcqDesc()
    BufferDspDesc()
    GetDetail()

Done:

    WrkSortby = " by " & WrkPSort
    If WrkSSort <> "" Then
      WrkSortby = WrkSortby & ", " & WrkSSort
    End If
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds1 = ds1
    MyCrViewer.Wrkds2 = ds2
    MyCrViewer.WrkSortby = WrkSortby
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("Tag", Type.GetType("System.String"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Serial", Type.GetType("System.String"))
      .Columns.Add("GLAcct1", Type.GetType("System.String"))
      .Columns.Add("GLAcct2", Type.GetType("System.String"))
      .Columns.Add("AcqVal", Type.GetType("System.Int32"))
      .Columns.Add("AcqDesc", Type.GetType("System.String"))
      .Columns.Add("AcqDate", Type.GetType("System.String"))
      .Columns.Add("LifeDate", Type.GetType("System.String"))
      .Columns.Add("DspVal", Type.GetType("System.Int32"))
      .Columns.Add("DspDesc", Type.GetType("System.String"))
      .Columns.Add("DspDate", Type.GetType("System.String"))
      .Columns.Add("DeprVal", Type.GetType("System.Int32"))
      .Columns.Add("NetVal", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("TAcqVal", Type.GetType("System.Int32"))
      .Columns.Add("TAcqCount", Type.GetType("System.Int32"))
      .Columns.Add("TDspVal", Type.GetType("System.Int32"))
      .Columns.Add("TDspCount", Type.GetType("System.Int32"))
      .Columns.Add("TDeprVal", Type.GetType("System.Int32"))
      .Columns.Add("TNetVal", Type.GetType("System.Int32"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
  Private Sub ClearTotals()
    WrkTAcqVal = 0
    WrkTAcqCount = 0
    WrkTDspVal = 0
    WrkTDspCount = 0
    WrkTDeprVal = 0
    WrkTNetVal = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkSortby As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim SaveGroup As String
    Dim WrkNetVal As Integer

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    WrkQry = "FASTAT='A'"
    WrkSortby = ""
    If WrkAsTypeFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAASCD >= " & MyUtils.Quo(WrkAsTypeFrom)
    End If
    If WrkAsTypeTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAASCD <= " & MyUtils.Quo(WrkAsTypeTo)
    End If
    If WrkAcqFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQDT >= " & WrkAcqFrom
    End If
    If WrkAcqTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQDT <= " & WrkAcqTo
    End If
    If WrkDspFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FADSDT >= " & WrkDspFrom
    End If
    If WrkDspTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FADSDT <= " & WrkDspTo
    End If
    If WrkBldgFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FABLCD >= " & MyUtils.Quo(WrkBldgFrom)
    End If
    If WrkBldgTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FABLCD <= " & MyUtils.Quo(WrkBldgTo)
    End If
    If WrkClassFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FACLCD >= " & MyUtils.Quo(WrkClassFrom)
    End If
    If WrkClassTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FACLCD <= " & MyUtils.Quo(WrkClassTo)
    End If
    If WrkDeptFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FADECD >= " & MyUtils.Quo(WrkDeptFrom)
    End If
    If WrkDeptTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FADECD <= " & MyUtils.Quo(WrkDeptTo)
    End If
    If WrkEqupFrom <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAEQCD >= " & MyUtils.Quo(WrkEqupFrom)
    End If
    If WrkEqupTo <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAEQCD <= " & MyUtils.Quo(WrkEqupTo)
    End If
    If WrkUser1From <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU1CD >= " & MyUtils.Quo(WrkUser1From)
    End If
    If WrkUser1To <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU1CD <= " & MyUtils.Quo(WrkUser1To)
    End If
    If WrkUser2From <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU2CD >= " & MyUtils.Quo(WrkUser1From)
    End If
    If WrkUser2To <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU2CD <= " & MyUtils.Quo(WrkUser1To)
    End If
    If WrkUser3From <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU3CD >= " & MyUtils.Quo(WrkUser2From)
    End If
    If WrkUser3To <> "" Then
      WrkQry = WrkQry & WrkAnd & "FAU3CD <= " & MyUtils.Quo(WrkUser3To)
    End If
    If WrkAssetValFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQVL >= " & WrkAssetValFrom
    End If
    If WrkAssetValTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FAAQVL <= " & WrkAssetValTo
    End If
    If MyFrmFA100B.RbFundBusiness.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV<>'Y'"
    End If
    If MyFrmFA100B.RbFundGovernment.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV='Y'"
    End If
    If MyFrmFA100B.RbDeprYes.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANDEP<>'Y'"
    End If
    If MyFrmFA100B.RbDeprNon.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANDEP='Y'"
    End If
    If MyFrmFA100B.RbAssetsReport.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANREP<>'Y'"
    End If
    If MyFrmFA100B.RbAssetsNon.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANREP='Y'"
    End If
    If Not MyFrmFA100B.ChkInclDsp.Checked Then
      WrkQry = WrkQry & WrkAnd & "FADSCD=' '"
    End If

    If WrkSSort <> "" Then
      WrkSortby = BuildSort(WrkPSort) & "," & BuildSort(WrkSSort) & ",FADESC"
    Else
      WrkSortby = BuildSort(WrkPSort) & ",FADESC"
    End If

    DsFAMSTR = myFAMSTRQ.GetQry(WrkSortby, WrkQry, 0)
    If DsFAMSTR.Tables(0).Rows.Count = 0 Then
      myFAMSTRQ.CloseFile()
      Exit Sub
    End If

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SaveGroup = ""

    For I = 0 To (DsFAMSTR.Tables(0).Rows.Count - 1)
      With DsFAMSTR.Tables(0).Rows(I)
        dr = ds1.Tables(0).NewRow
        Select Case WrkPSort
          Case "Asset Type"
            dr.Item("groupid") = .Item("faascd") & "-" & GetFAASTypeDesc(.Item("faascd"))
          Case "Classification"
            dr.Item("groupid") = .Item("faclcd") & "-" & GetFAClassDesc(.Item("faclcd"))
          Case "Equipment Condition"
            dr.Item("groupid") = .Item("faeqcd") & "-" & GetFAEqupDesc(.Item("faeqcd"))
          Case "Department"
            dr.Item("groupid") = .Item("fadecd") & "-" & GetFADeptDesc(.Item("fadecd"))
          Case "Location"
            dr.Item("groupid") = .Item("fablcd") & "-" & GetFABldgDesc(.Item("fablcd"))
          Case "GL Grouping"
            dr.Item("groupid") = .Item("faglgp")
          Case "Vendor"
            dr.Item("groupid") = .Item("favend")
          Case "User1"
            dr.Item("groupid") = .Item("fau1cd") & "-" & GetFAUser1Desc(.Item("fau1cd"))
          Case "User2"
            dr.Item("groupid") = .Item("fau2cd") & "-" & GetFAUser2Desc(.Item("fau2cd"))
          Case "User3"
            dr.Item("groupid") = .Item("fau3cd") & "-" & GetFAUser3Desc(.Item("fau3cd"))
          Case "User4"
            dr.Item("groupid") = .Item("fau4tx")
          Case "User5"
            dr.Item("groupid") = .Item("fau5tx")
        End Select
        If SaveGroup <> "" And SaveGroup <> dr.Item("groupid") Then
          WriteTotals(SaveGroup)
          ClearTotals()
        End If
        SaveGroup = dr.Item("groupid")
        dr.Item("tag") = .Item("fatag")
        dr.Item("serial") = .Item("faserl")
        dr.Item("desc") = .Item("fadesc")
        dr.Item("glacct1") = BldGLAcct1(I)
        dr.Item("glacct2") = BldGLAcct2(I)
        dr.Item("acqval") = .Item("faaqvl")
        dr.Item("acqdesc") = LookupAcqDesc(.Item("faaqcd"))
        dr.Item("acqdate") = Format(MyUtils.GetDBDate(.Item("faaqdt")), "M/d/yyyy")
        If .Item("faedt") > 0 Then
          dr.Item("lifedate") = Format(MyUtils.GetDBDate(.Item("faedt")), "M/d/yyyy")
        End If
        dr.Item("dspval") = .Item("fadsvl")
        dr.Item("dspdesc") = LookupDspDesc(.Item("fadscd"))
        If .Item("fadsdt") > 0 Then
          dr.Item("dspdate") = Format(MyUtils.GetDBDate(.Item("fadsdt")), "M/d/yyyy")
        End If
        dr.Item("deprval") = .Item("fadevl")
        WrkNetVal = MyUtils.Round(.Item("faaqvl"), 0) - MyUtils.Round(.Item("fadsvl"), 0) - MyUtils.Round(.Item("fadevl"), 0)
        If WrkNetVal < 0 Then WrkNetVal = 0
        dr.Item("netval") = WrkNetVal
        If .Item("faaqvl") > 0 Then
          WrkTAcqCount = WrkTAcqCount + 1
          WrkTAcqVal = WrkTAcqVal + .Item("faaqvl")
        End If
        If .Item("fadsvl") > 0 Then
          WrkTDspCount = WrkTDspCount + 1
          WrkTDspVal = WrkTDspVal + .Item("fadsvl")
        End If
        WrkTDeprVal = WrkTDeprVal + .Item("fadevl")
        WrkTNetVal = WrkTNetVal + WrkNetVal
      End With
      ds1.Tables(0).Rows.Add(dr)
NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / (DsFAMSTR.Tables(0).Rows.Count)) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    WriteTotals(SaveGroup)
    myFrmProgress.Close()
    myFAMSTRQ.CloseFile()

  End Sub
  Private Sub WriteTotals(ByVal SaveGroup As String)
    dr2 = ds2.Tables(0).NewRow
    dr2.Item("groupid") = SaveGroup
    dr2.Item("tacqval") = WrkTAcqVal
    dr2.Item("tacqcount") = WrkTAcqCount
    dr2.Item("tdspcount") = WrkTDspCount
    dr2.Item("tdspval") = WrkTDspVal
    dr2.Item("tdeprval") = WrkTDeprVal
    dr2.Item("tnetval") = WrkTNetVal
    ds2.Tables(0).Rows.Add(dr2)
  End Sub
  Private Sub BufferAcqDesc()
    Dim I As Integer

    Dim myFAAQUMT As FAAQUMT.MyData
    Dim dsFAAQUMT As DataSet = New DataSet

    myFAAQUMT = New FAAQUMT.MyData()
    myFAAQUMT.MyDBConn = myDBConnect

    dsFAAQUMT = myFAAQUMT.PosData("")
    For I = 0 To dsFAAQUMT.Tables(0).Rows.Count - 1
      With dsFAAQUMT.Tables(0).Rows(I)
        WrkAcqCode(I) = .Item("aqcode")
        WrkAcqDesc(I) = .Item("aqdesc")
      End With
    Next

  End Sub
  Private Function LookupAcqDesc(ByVal Code As String) As String
    Dim I As Integer
    Dim WrkDesc As String

    For I = 0 To WrkAcqCode.GetUpperBound(0)
      If WrkAcqCode(I) Is Nothing Then
        Return ""
      End If
      If Code = WrkAcqCode(I) Then
        WrkDesc = WrkAcqDesc(I)
        Return WrkDesc
      End If
    Next

    Return ""
  End Function
  Private Sub BufferDspDesc()
    Dim I As Integer

    Dim myFADSPMT As FADSPMT.MyData
    Dim dsFADSPMT As DataSet = New DataSet

    myFADSPMT = New FADSPMT.MyData()
    myFADSPMT.MyDBConn = myDBConnect

    dsFADSPMT = myFADSPMT.PosData("")
    For I = 0 To dsFADSPMT.Tables(0).Rows.Count - 1
      With dsFADSPMT.Tables(0).Rows(I)
        WrkDspCode(I) = .Item("dscode")
        WrkDspDesc(I) = .Item("dsdesc")
      End With
    Next

  End Sub
  Private Function LookupDspDesc(ByVal Code As String) As String
    Dim I As Integer
    Dim WrkDesc As String

    For I = 0 To WrkDspCode.GetUpperBound(0)
      If WrkDspCode(I) Is Nothing Then
        Return ""
      End If
      If Code = WrkDspCode(I) Then
        WrkDesc = WrkDspDesc(I)
        Return WrkDesc
      End If
    Next

    Return ""
  End Function
  Private Function BldGLAcct1(ByVal I As Integer) As String

    Dim sb As StringBuilder = New StringBuilder

    With DsFAMSTR.Tables(0).Rows(I)
      If .Item("fafnd") = 0 Then Return ""
      sb.Append(Format(.Item("fafnd"), "000"))
      sb.Append("-")
      sb.Append(Format(.Item("fasfnd"), "000"))
      sb.Append("-")
      sb.Append(Format(.Item("fadpt"), "0000"))
      sb.Append("-")
      sb.Append(Format(.Item("faobj"), "000"))
      sb.Append("-")
      sb.Append(Format(.Item("fafcn"), "0000"))
      sb.Append("-")
      sb.Append(Format(.Item("fasfcn"), "0000"))
    End With

    Return sb.ToString
  End Function
  Private Function BldGLAcct2(ByVal I As Integer) As String

    Dim sb As StringBuilder = New StringBuilder

    With DsFAMSTR.Tables(0).Rows(I)
      If .Item("fafnd2") = 0 Then Return ""
      sb.Append(Format(.Item("fafnd2"), "000"))
      sb.Append("-")
      sb.Append(Format(.Item("fasfn2"), "000"))
      sb.Append("-")
      sb.Append(Format(.Item("fadpt2"), "0000"))
      sb.Append("-")
      sb.Append(Format(.Item("faobj2"), "000"))
      sb.Append("-")
      sb.Append(Format(.Item("fafcn2"), "0000"))
      sb.Append("-")
      sb.Append(Format(.Item("fasfc2"), "0000"))
    End With

    Return sb.ToString
  End Function
End Module
