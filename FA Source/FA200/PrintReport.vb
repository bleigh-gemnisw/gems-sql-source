Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myFAMSTRQ As FAMSTRQ.MyData
  Dim myFAMSTR As FAMSTR.MyData
  Dim myFAHIST As FAHIST.MyData
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
  Dim WrkFunded As String
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
  Dim WrkFiscalYear As Integer
  Dim WrkAsOfDate As Date
  Dim WrkDeprAnnually As Boolean
  Dim WrkInclDsp As Boolean
  Dim WrkPost As Boolean

  Dim WrkTAcqVal As Integer
  Dim WrkTBeforeDeprVal As Decimal
  Dim WrkTDeprVal As Decimal
  Dim WrkTAfterDeprVal As Decimal
  Dim WrkTDspVal As Integer
  Dim WrkTAssetVal As Decimal

  Public Sub PrtReport()
    Dim WrkSortby As String
    myFAMSTRQ = New FAMSTRQ.MyData()
    myFAMSTRQ.MyDBConn = myDBConnect
    myFAMSTR = New FAMSTR.MyData()
    myFAMSTR.MyDBConn = myDBConnect
    myFAHIST = New FAHIST.MyData()
    myFAHIST.MyDBConn = myDBConnect

    With MyFrmFA200B
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
      If .RbFundBoth.Checked Then WrkFunded = "Both"
      If .RbFundBusiness.Checked Then WrkFunded = "Business"
      If .RbFundGovernment.Checked Then WrkFunded = "Government"
      WrkUser1From = .TxtUser1From.Text
      WrkUser1To = .TxtUser1To.Text
      WrkUser2From = .TxtUser2From.Text
      WrkUser2To = .TxtUser2To.Text
      WrkUser3From = .TxtUser3From.Text
      WrkUser3To = .TxtUser3To.Text
      WrkAssetValFrom = MyUtils.CnvSng(.TxtAssetValFrom.Text)
      WrkAssetValTo = MyUtils.CnvSng(.TxtAssetValTo.Text)
      If .RbDspAny.Checked Then
        WrkInclDsp = True
      Else
        WrkInclDsp = False
      End If
      If .RbDeprAnnually.Checked Then
        WrkDeprAnnually = True
      Else
        WrkDeprAnnually = False
      End If
      WrkFiscalYear = MyUtils.CnvSng(.TxtFiscalYear.Text)
      If .ChkPost.Checked Then
        WrkPost = True
      Else
        WrkPost = False
      End If

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
      WrkAsOfDate = .DtPckAsof.Value
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
      ds2.Clear()
      ClearTotals()
    End If

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
    MyCrViewer.WrkAsofDate = Format(WrkAsOfDate, "short date")
    MyCrViewer.WrkFiscalYear = WrkFiscalYear
    MyCrViewer.WrkFunded = WrkFunded
    MyCrViewer.WrkPost = WrkPost
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
      .Columns.Add("Dept", Type.GetType("System.String"))
      .Columns.Add("Serial", Type.GetType("System.String"))
      .Columns.Add("GLAcct1", Type.GetType("System.String"))
      .Columns.Add("GLAcct2", Type.GetType("System.String"))
      .Columns.Add("AcqVal", Type.GetType("System.Int32"))
      .Columns.Add("AcqDate", Type.GetType("System.String"))
      .Columns.Add("LifeDate", Type.GetType("System.String"))
      .Columns.Add("LifeYears", Type.GetType("System.Int32"))
      .Columns.Add("BeforeDeprVal", Type.GetType("System.Decimal"))
      .Columns.Add("DeprVal", Type.GetType("System.Decimal"))
      .Columns.Add("AfterDeprVal", Type.GetType("System.Decimal"))
      .Columns.Add("DspVal", Type.GetType("System.Int32"))
      .Columns.Add("AssetVal", Type.GetType("System.Decimal"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("TAcqVal", Type.GetType("System.Int32"))
      .Columns.Add("TBeforeDeprVal", Type.GetType("System.Decimal"))
      .Columns.Add("TDeprVal", Type.GetType("System.Decimal"))
      .Columns.Add("TAfterDeprVal", Type.GetType("System.Decimal"))
      .Columns.Add("TDspVal", Type.GetType("System.Int32"))
      .Columns.Add("TAssetVal", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)

  End Sub
  Private Sub ClearTotals()
    WrkTAcqVal = 0
    WrkTBeforeDeprVal = 0
    WrkTDeprVal = 0
    WrkTAfterDeprVal = 0
    WrkTDspVal = 0
    WrkTAssetVal = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkSortby As String
    Dim WrkQry As String
    Dim I As Integer
    Dim WrkAnd As String
    Dim SaveGroup As String
    Dim WrkTag As String
    Dim WrkTotDepr As Decimal
    Dim WrkYears As Integer
    Dim WrkDeprFull As Decimal
    Dim WrkDepr As Decimal
    Dim WrkDeprMonth As Decimal
    Dim WrkMonths As Integer
    Dim WrkMaxMonths As Integer
    Dim WrkResVal As Decimal
    Dim WrkAcqDate As Date
    Dim WrkDspDate As Date
    Dim WrkDspVal As Integer
    Dim ChkDate As Date

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
    If MyFrmFA200B.RbFundBusiness.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV<>'Y'"
    End If
    If MyFrmFA200B.RbFundGovernment.Checked Then
      WrkQry = WrkQry & WrkAnd & "FAGOV='Y'"
    End If
    If MyFrmFA200B.RbDeprYes.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANDEP<>'Y'"
    End If
    If MyFrmFA200B.RbDeprNon.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANDEP='Y'"
    End If
    If MyFrmFA200B.RbAssetsReport.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANREP<>'Y'"
    End If
    If MyFrmFA200B.RbAssetsNon.Checked Then
      WrkQry = WrkQry & WrkAnd & "FANREP='Y'"
    End If

    If WrkSSort <> "" Then
      WrkSortby = BuildSort(WrkPSort) & "," & BuildSort(WrkSSort) & ",FADESC"
    Else
      WrkSortby = BuildSort(WrkPSort) & ",FADESC"
    End If

    DsFAMSTR = myFAMSTRQ.GetQry(WrkSortby, WrkQry, 0)
    If DsFAMSTR.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    SaveGroup = ""

    For I = 0 To (DsFAMSTR.Tables(0).Rows.Count - 1)
      With DsFAMSTR.Tables(0).Rows(I)
        dr = ds1.Tables(0).NewRow
        WrkTag = .Item("fatag")
        WrkTotDepr = .Item("faaqvl")
        WrkAcqDate = MyUtils.GetDBDate(.Item("faaqdt"))
        WrkDspDate = MyUtils.GetDBDate(.Item("fadsdt"))
        WrkDepr = 0
        WrkDspVal = 0
        WrkResVal = 0
        If WrkInclDsp Then
          If .Item("fadsdt") > 0 Then
            WrkTotDepr = .Item("faaqvl") - .Item("fadsvl")
            WrkDspVal = .Item("fadsvl")
          End If
        End If
        'Filter Net Value=0
        If WrkTotDepr = 0 Then GoTo NextRec
        'Filter if Acq Date is after Post Date
        If WrkAcqDate > WrkAsOfDate Then GoTo NextRec
        'Filter If Total Depreciation is less than Threshhold amount 
        If WrkTotDepr < GetFAASTypeThreshold(.Item("faascd")) Then GoTo NextRec
        'Filter If Total Accumulated Depreciation is equal to Total Depreciation 
        'Filter if Disposal date else write record with zero value
        If .Item("fadevl") = WrkTotDepr Then
          If .Item("fadsdt") > 0 Then
            GoTo NextRec
          Else
            GoTo WriteDepr
          End If
        End If
        'Include Construction in progress
        If .Item("faclcd") = "CONST" Then GoTo WriteDepr
        'Include Non Depreciable
        If .Item("fandep") = "Y" Then
          WrkResVal = .Item("faaqvl") - .Item("fadevl")
          GoTo WriteDepr
        End If
        'Calc Depreciation  
        If .Item("faeyr") > 0 Then
          WrkYears = .Item("faeyr")
          If Not WrkDeprAnnually Then
            WrkYears = WrkYears * 4
          End If
          WrkDeprFull = WrkTotDepr / WrkYears
        Else
          WrkDeprFull = 0
        End If
        'Filter if Depreciation=0
        If WrkDeprFull = 0 Then GoTo NextRec

        'If Life Expectancy Date is before post date, then 
        'Depreciation = Total Depreciation - Total Accumulated Depreciation
        If MyUtils.GetDBDate(.Item("faedt")) < WrkAsOfDate Then
          WrkDeprFull = WrkTotDepr - .Item("fadevl")
        End If

        'Filter if Depreciation<=0
        If WrkDeprFull <= 0 Then GoTo NextRec

        If WrkDeprAnnually Then
          WrkMaxMonths = 12
          WrkDeprMonth = WrkDeprFull / 12
        Else
          WrkMaxMonths = 3
          WrkDeprMonth = WrkDeprFull / 3
        End If

        WrkDepr = WrkDeprFull
        'If Acquisition date is before the post date and within one year, then pro rate it
        If WrkAcqDate <> ChkDate Then
          If WrkAcqDate <= WrkAsOfDate Then
            WrkMonths = DateDiff(DateInterval.Month, WrkAcqDate, WrkAsOfDate) + 1
            If WrkMonths <= WrkMaxMonths Then
              If WrkMonths > 0 Then
                WrkDepr = WrkDeprMonth * WrkMonths
              End If
            End If
          End If
        End If

        'If Disposal date is on or before post date, then pro rate it
        'Residual Value = Asset Value - Total Accumulated Depreciation
        If WrkDspDate <> ChkDate Then
          If WrkDspDate <= WrkAsOfDate Then
            WrkMonths = WrkDeprMonth - DateDiff(DateInterval.Month, WrkDspDate, WrkAsOfDate)
            If WrkMonths > 0 Then
              WrkDepr = WrkDeprMonth * WrkMonths
              If WrkDepr > WrkTotDepr - .Item("fadevl") Then
                WrkDepr = WrkTotDepr - .Item("fadevl")
                WrkDspVal = .Item("fadsvl")
              End If
            End If
          End If
        End If

        'If Residual Value < 0 then reduce depreciation
        WrkResVal = .Item("faaqvl") - WrkDepr - .Item("fadevl") - WrkDspVal
        If WrkResVal < 0 Then
          WrkDepr = WrkDepr + WrkResVal
          WrkResVal = 0
        End If
        If WrkDepr < 0 Then
          WrkDepr = 0
        End If

        'If Disposal date is after post date and using any disposal date method
        If WrkInclDsp Then
          If WrkDspDate <> ChkDate Then
            If WrkDspDate <= WrkAsOfDate Then
              '            WrkResVal = WrkTotDepr - WrkDepr - .Item("fadevl")
              WrkDspVal = .Item("fadsvl")
            End If
          End If
        End If

WriteDepr:
        WrkDepr = MyUtils.Round(WrkDepr, 2)
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
        dr.Item("dept") = .Item("fadecd")
        dr.Item("glacct1") = BldGLAcct1(I)
        dr.Item("glacct2") = BldGLAcct2(I)
        dr.Item("acqval") = .Item("faaqvl")
        dr.Item("acqdate") = Format(MyUtils.GetDBDate(.Item("faaqdt")), "M/d/yyyy")
        If .Item("faedt") > 0 Then
          dr.Item("lifedate") = Format(MyUtils.GetDBDate(.Item("faedt")), "M/d/yyyy")
          dr.Item("lifeyears") = .Item("faeyr")
        End If
        dr.Item("beforedeprval") = .Item("fadevl")
        dr.Item("deprval") = WrkDepr
        dr.Item("afterdeprval") = .Item("fadevl") + WrkDepr
        dr.Item("dspval") = WrkDspVal
        dr.Item("assetval") = WrkResVal
        'Accumulate totals
        WrkTAcqVal = WrkTAcqVal + .Item("faaqvl")
        WrkTBeforeDeprVal = WrkTBeforeDeprVal + .Item("fadevl")
        WrkTDeprVal = WrkTDeprVal + WrkDepr
        WrkTAfterDeprVal = WrkTAfterDeprVal + .Item("fadevl") + WrkDepr
        WrkTDspVal = WrkTDspVal + WrkDspVal
        WrkTAssetVal = WrkTAssetVal + WrkResVal
      End With
      ds1.Tables(0).Rows.Add(dr)
      If WrkPost And WrkDepr > 0 Then
        UpdateFAMSTR(WrkTag, WrkAsOfDate, WrkDepr)
        WriteFAHIST(WrkTag, WrkAsOfDate, WrkDepr, WrkFiscalYear)
      End If
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
    If WrkPost Then
      Dim myFACNTL As FACNTL.MyData
      myFACNTL = New FACNTL.MyData()
      myFACNTL.MyDBConn = myDBConnect
      With myFACNTL
        .GetOneRecordP("A")
        ._FCASOF = ._FCASOF + 10000 'Add one year
        .UpdateOneRecordP()
      End With
    End If
    myFrmProgress.Close()
    myFAMSTRQ.CloseFile()

  End Sub
  Private Sub WriteTotals(ByVal SaveGroup As String)
    dr2 = ds2.Tables(0).NewRow
    dr2.Item("groupid") = SaveGroup
    dr2.Item("tacqval") = WrkTAcqVal
    dr2.Item("TBeforeDeprVal") = WrkTBeforeDeprVal
    dr2.Item("tdeprval") = WrkTDeprVal
    dr2.Item("TAfterDeprVal") = WrkTAfterDeprVal
    dr2.Item("tdspval") = WrkTDspVal
    dr2.Item("TAssetVal") = WrkTAssetVal
    ds2.Tables(0).Rows.Add(dr2)
  End Sub
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
  Private Sub UpdateFAMSTR(ByVal Tag As String, ByVal AsofDate As Date,
  ByVal WrkDepr As Decimal)

    myFAMSTR.GetOneRecordP(Tag)
    If Not myFAMSTR.RecordNotFound Then
      With myFAMSTR
        ._FADEVL = ._FADEVL + WrkDepr
        ._FADEDT = MyUtils.SetDBDate(AsofDate)
        .UpdateOneRecordP()
      End With
    End If
  End Sub
  Private Sub WriteFAHIST(ByVal Tag As String, ByVal AsofDate As Date,
  ByVal Depr As Decimal, ByVal FiscalYear As Integer)

    myFAHIST.GetOneRecordP("", 0)
    With myFAHIST
      ._FHTAG = Tag
      ._FHDEDT = MyUtils.SetDBDate(AsofDate)
      ._FHDEVL = Depr
      ._FHFISC = FiscalYear
      ._FHADJ = ""
      .AddOneRecordP()
    End With
  End Sub
End Module
