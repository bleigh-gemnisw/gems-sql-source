Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myGLBUDGETQ As GLBUDGETQ.MyData
  Dim myGLHEAD As GLHEAD.MyData

  Dim ds As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim SaveFund As Integer
  Dim SaveDept As Integer
  Dim SaveGltyp As String
  'GL6501
  Dim WrkExcludeTot As Boolean
  Dim WrkReportFmt As String
  Dim WrkActual5Yr As Integer
  Dim WrkActual4Yr As Integer
  Dim WrkActual3Yr As Integer
  Dim WrkActual2Yr As Integer
  Dim WrkActual1Yr As Integer
  Dim WrkExpend As Integer
  Dim WrkOriginal As Integer
  Dim WrkAmended As Integer
  Dim WrkDeptProp As Integer
  Dim WrkMayorProp As Integer
  Dim WrkTownConProp As Integer
  Dim WrkAdopted As Integer
  Dim WrkDiff As Integer
  Dim WrkDiffPct As Decimal
  Public Sub PrtReport()

    myGLBUDGETQ = New GLBUDGETQ.MyData()
    myGLBUDGETQ.MyDBConn = myDBConnect
    myGLHEAD = New GLHEAD.MyData()
    myGLHEAD.MyDBConn = myDBConnect

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsTot.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.WrkReportFmt = WrkReportFmt
    MyCrViewer.wrkds = ds
    MyCrViewer.wrkdsTot = dsTot
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ExcludeTot", Type.GetType("System.Boolean"))
      .Columns.Add("Group", Type.GetType("System.Int16"))
      .Columns.Add("GroupDesc", Type.GetType("System.String"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Actual5Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual4Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Original", Type.GetType("System.Decimal"))
      .Columns.Add("Expend", Type.GetType("System.Decimal"))
      .Columns.Add("Amended", Type.GetType("System.Decimal"))
      .Columns.Add("DeptProp", Type.GetType("System.Decimal"))
      .Columns.Add("MayorProp", Type.GetType("System.Decimal"))
      .Columns.Add("TownConProp", Type.GetType("System.Decimal"))
      .Columns.Add("Adopted", Type.GetType("System.Decimal"))
      .Columns.Add("Diff", Type.GetType("System.Decimal"))
      .Columns.Add("DiffPct", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("ExcludeTot", Type.GetType("System.Boolean"))
      .Columns.Add("Group", Type.GetType("System.Int16"))
      .Columns.Add("GroupDesc", Type.GetType("System.String"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("Dept", Type.GetType("System.Int16"))
      .Columns.Add("DeptName", Type.GetType("System.String"))
      .Columns.Add("Actual5Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual4Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual3Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual2Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Actual1Yr", Type.GetType("System.Decimal"))
      .Columns.Add("Original", Type.GetType("System.Decimal"))
      .Columns.Add("Expend", Type.GetType("System.Decimal"))
      .Columns.Add("Amended", Type.GetType("System.Decimal"))
      .Columns.Add("DeptProp", Type.GetType("System.Decimal"))
      .Columns.Add("MayorProp", Type.GetType("System.Decimal"))
      .Columns.Add("TownConProp", Type.GetType("System.Decimal"))
      .Columns.Add("Adopted", Type.GetType("System.Decimal"))
      .Columns.Add("Diff", Type.GetType("System.Decimal"))
      .Columns.Add("DiffPct", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkSelFund As Integer
    Dim WrkSelDept As Integer
    Dim WrkAcct As String
    Dim WrkOmitNoAct As Boolean
    Dim WrkGrp As Integer
    Dim WrkFile As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    With MyFrmGL650B
      If .RbPrev2.Checked Then WrkReportFmt = "Prev2"
      If .RbAdopted.Checked Then WrkReportFmt = "Adopted"
      If .RbOrig.Checked Then WrkReportFmt = "Original"
      If .RbVar.Checked Then WrkReportFmt = "Variance"
      If .RbPrev5.Checked Then WrkReportFmt = "Prev5"
      WrkSelFund = MyUtils.CnvSng(.TxtFund.Text)
      WrkSelDept = MyUtils.CnvSng(.TxtDept.Text)
      WrkOmitNoAct = .ChkOmit.Checked
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmGL650B.LblFilePath.Text)
    End If
    SaveFund = 0
    SaveDept = 0
    SaveGltyp = ""
    ClearTotals()

    WrkAnd = " and "
    WrkOr = " or "

    WrkSort = "GLTYP, DEPT"
    WrkQry = "FUND=" & WrkSelFund & WrkAnd & "GLTYP in('R','X')"
    If WrkSelDept > 0 Then
      WrkQry = WrkQry & WrkAnd & "DEPT=" & WrkSelDept
    End If
    myGLBUDGETQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    myGLHEAD.GetOneRecordP(0, 0)
    If WrkFile <> String.Empty Then
      sw.WriteLine(BuildHeading1)
      sw.WriteLine(BuildHeading2)
      sw.WriteLine(BuildHeading3)
    End If

ReadNext:
    myGLBUDGETQ.ReadQry()
    If Not myGLBUDGETQ.IsEOF Then
      With myGLBUDGETQ
        Counter = Counter + 1
        If SaveDept > 0 And SaveDept <> ._DEPT Then
          WriteTotal()
          ClearTotals()
        End If
        If WrkOmitNoAct Then
          If ._ACT1 = 0 And ._ACT2 = 0 And ._ORIG = 0 And ._EXP = 0 _
           And ._CURR = 0 And ._BAMT1 = 0 And ._BAMT2 = 0 And ._BAMT3 = 0 And ._ADOPTD = 0 Then
            GoTo NextRec
          End If
        End If
        SaveFund = ._FUND
        SaveDept = ._DEPT
        SaveGltyp = ._GLTYP
        WrkGrp = GetGLDEPGroup(SaveDept)
        WrkExcludeTot = GetGLDEPGRPExcTot(WrkGrp)
        dr = ds.Tables(0).NewRow
        dr.Item("excludetot") = WrkExcludeTot
        dr.Item("group") = ._DEPT
        dr.Item("groupdesc") = GetGLACCTDesc(._FUND, 0, ._DEPT, 0, 0, 0)
        WrkAcct = BuildAcctPart(._OBJ, ._FUNC, ._SFUNC)
        dr.Item("gltyp") = ._GLTYP
        dr.Item("acct") = WrkAcct
        dr.Item("descr") = GetGLACCTDesc(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC)
        dr.Item("actual5yr") = ._ACT5
        dr.Item("actual4yr") = ._ACT4
        dr.Item("actual3yr") = ._ACT3
        dr.Item("actual2yr") = ._ACT2
        dr.Item("actual1yr") = ._ACT1
        dr.Item("original") = ._ORIG
        dr.Item("expend") = ._EXP
        dr.Item("amended") = ._CURR
        dr.Item("deptprop") = ._BAMT1
        dr.Item("mayorprop") = ._BAMT2
        dr.Item("townconprop") = ._BAMT3
        dr.Item("adopted") = ._ADOPTD
        dr.Item("diff") = ._BAMT2 - ._CURR
        If ._CURR > 0 Then
          dr.Item("diffpct") = ((._BAMT2 - ._CURR) / ._CURR) * 100
        Else
          dr.Item("diffpct") = 0
        End If
        ds.Tables(0).Rows.Add(dr)
        If WrkFile <> String.Empty Then
          sw.WriteLine(BuildCSV)
        End If

        WrkActual5Yr = WrkActual5Yr + ._ACT5
        WrkActual4Yr = WrkActual4Yr + ._ACT4
        WrkActual3Yr = WrkActual3Yr + ._ACT3
        WrkActual2Yr = WrkActual2Yr + ._ACT2
        WrkActual1Yr = WrkActual1Yr + ._ACT1
        WrkAmended = WrkAmended + ._CURR
        WrkOriginal = WrkOriginal + ._ORIG
        WrkExpend = WrkExpend + ._EXP
        WrkDeptProp = WrkDeptProp + ._BAMT1
        WrkMayorProp = WrkMayorProp + ._BAMT2
        WrkTownConProp = WrkTownConProp + ._BAMT3
        WrkAdopted = WrkAdopted + ._ADOPTD
        WrkDiff = WrkDiff + ._BAMT2 - ._CURR
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

    WriteTotal()
    If WrkFile <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myGLBUDGETQ.CloseFile()

  End Sub
  Private Sub WriteTotal()
    Dim WrkGrp As Integer
    WrkGrp = GetGLDEPGroup(SaveDept)
    dr = dsTot.Tables(0).NewRow
    dr.Item("excludetot") = WrkExcludeTot
    dr.Item("group") = WrkGrp
    dr.Item("groupdesc") = GetGLDEPGRPDesc(WrkGrp)
    dr.Item("gltyp") = SaveGltyp
    dr.Item("dept") = SaveDept
    dr.Item("deptname") = GetGLACCTDesc(SaveFund, 0, SaveDept, 0, 0, 0)
    dr.Item("actual5yr") = WrkActual5Yr
    dr.Item("actual4yr") = WrkActual4Yr
    dr.Item("actual3yr") = WrkActual3Yr
    dr.Item("actual2yr") = WrkActual2Yr
    dr.Item("actual1yr") = WrkActual1Yr
    dr.Item("original") = WrkOriginal
    dr.Item("expend") = WrkExpend
    dr.Item("amended") = WrkAmended
    dr.Item("deptprop") = WrkDeptProp
    dr.Item("mayorprop") = WrkMayorProp
    dr.Item("townconprop") = WrkTownConProp
    dr.Item("adopted") = WrkAdopted
    dr.Item("diff") = WrkDiff
    If WrkAmended > 0 Then
      dr.Item("diffpct") = (WrkDiff / WrkAmended) * 100
    Else
      dr.Item("diffpct") = 0
    End If
    dsTot.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub ClearTotals()
    WrkActual5Yr = 0
    WrkActual4Yr = 0
    WrkActual3Yr = 0
    WrkActual2Yr = 0
    WrkActual1Yr = 0
    WrkOriginal = 0
    WrkExpend = 0
    WrkAmended = 0
    WrkDeptProp = 0
    WrkMayorProp = 0
    WrkTownConProp = 0
    WrkAdopted = 0
    WrkDiff = 0
    WrkDiffPct = 0
  End Sub
  Private Function BuildDept(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    sb.Append(Format(Fund, "000"))
    sb.Append("-")
    sb.Append(Format(SFund, "000"))
    sb.Append("-")
    sb.Append(Format(Dept, "0000"))
    Return sb.ToString
  End Function
  Private Function BuildAcctPart(ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    sb.Append(Format(Obj, "000"))
    sb.Append("-")
    sb.Append(Format(Func, "0000"))
    Return sb.ToString
  End Function
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer,
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

    If Fund > 0 Then
      sb.Append(Format(Fund, "000"))
      sb.Append("-")
      sb.Append(Format(SFund, "000"))
      sb.Append("-")
      sb.Append(Format(Dept, "0000"))
      sb.Append("-")
      sb.Append(Format(Obj, "000"))
      sb.Append("-")
      sb.Append(Format(Func, "0000"))
      sb.Append("-")
      sb.Append(Format(SFunc, "0000"))
    Else
      sb.Append(String.Empty)
    End If
    Return sb.ToString
  End Function
  Public Function BuildHeading1()
    Dim sb As StringBuilder
    Dim WrkStr As String
    sb = New StringBuilder
    sb.Append(",")
    sb.Append(",")
    Select Case WrkReportFmt
      Case "Prev5"
        sb.Append(",")
        sb.Append(",")
        sb.Append(",")
      Case Else
    End Select
    sb.Append(",")
    sb.Append(",")
    Select Case WrkReportFmt
      Case "Prev2", "Prev5"
        sb.Append("Amended")
        sb.Append(",")
        sb.Append("Actual")
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC1))
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC2))
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC3))
      Case "Adopted"
        sb.Append("")
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC1))
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC2))
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC3))
        sb.Append(",")
      Case "Original"
        sb.Append("")
        sb.Append(",")
        sb.Append("Actual")
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC1))
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC2))
        sb.Append(",")
        sb.Append(Trim(myGLHEAD._BUDC3))
      Case "Variance"
    End Select
    sb.Append(",")
    sb.Append(",")
    sb.Append(",")
    sb.Append(",")
    sb.Append(",")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Public Function BuildHeading2()
    Dim sb As StringBuilder
    Dim WrkStr As String
    sb = New StringBuilder
    sb.Append(",")
    sb.Append(",")
    Select Case WrkReportFmt
      Case "Prev5"
        sb.Append("Actual")
        sb.Append(",")
        sb.Append("Actual")
        sb.Append(",")
        sb.Append("Actual")
        sb.Append(",")
      Case Else
    End Select
    sb.Append("Actual")
    sb.Append(",")
    sb.Append("Actual")
    sb.Append(",")
    Select Case WrkReportFmt
      Case "Prev2", "Prev5"
        sb.Append("Amended")
        sb.Append(",")
        sb.Append(MyFrmGL650B.DtPckAsof.Value.Date)
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Proposed")
      Case "Adopted"
        sb.Append("Amended")
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Adopted")
      Case "Original"
        sb.Append("Original")
        sb.Append(",")
        sb.Append(MyFrmGL650B.DtPckAsof.Value.Date)
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Proposed")
        sb.Append(",")
        sb.Append("Proposed")
      Case "Variance"
    End Select
    sb.Append(",")
    sb.Append(",")
    sb.Append(",")
    sb.Append(",")
    sb.Append(",")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Public Function BuildHeading3()
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkYear As Integer

    WrkYear = MyUtils.CnvSng(MyFrmGL650B.LblToYear.Text)
    sb = New StringBuilder
    sb.Append("Acct")
    sb.Append(",")
    sb.Append("Descr")
    sb.Append(",")
    Select Case WrkReportFmt
      Case "Prev5"
        sb.Append(BuildYears(WrkYear, -6))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, -5))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, -4))
        sb.Append(",")
      Case Else
    End Select
    sb.Append(BuildYears(WrkYear, -3))
    sb.Append(",")
    sb.Append(BuildYears(WrkYear, -2))
    sb.Append(",")
    Select Case WrkReportFmt
      Case "Prev2", "Prev5"
        sb.Append(BuildYears(WrkYear, -1))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, -1))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
      Case "Adopted"
        sb.Append(BuildYears(WrkYear, -1))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
      Case "Original"
        sb.Append(BuildYears(WrkYear, -1))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, -1))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
        sb.Append(",")
        sb.Append(BuildYears(WrkYear, 0))
      Case "Variance"
    End Select
    sb.Append(",")
    sb.Append("Fund")
    sb.Append(",")
    sb.Append("Dept")
    sb.Append(",")
    sb.Append("Dept Descr")
    sb.Append(",")
    sb.Append("GL Type")
    sb.Append(",")
    sb.Append("Obj/Func")
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildCSV() As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkDesc As String
    Dim WrkAcct As String
    WrkStr = ""
    sb = New StringBuilder
    With myGLBUDGETQ
      WrkAcct = BuildAcct(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC)
      sb.Append(WrkAcct)
      sb.Append(",")
      WrkDesc = GetGLACCTDesc(._FUND, ._SFUND, ._DEPT, ._OBJ, ._FUNC, ._SFUNC)
      WrkDesc = Replace(WrkDesc, ",", "")
      sb.Append(WrkDesc)
      sb.Append(",")
      Select Case WrkReportFmt
        Case "Prev5"
          sb.Append(._ACT5)
          sb.Append(",")
          sb.Append(._ACT4)
          sb.Append(",")
          sb.Append(._ACT3)
          sb.Append(",")
        Case Else
      End Select
      sb.Append(._ACT2)
      sb.Append(",")
      sb.Append(._ACT1)
      sb.Append(",")
      Select Case WrkReportFmt
        Case "Prev2", "Prev5"
          sb.Append(._CURR)
          sb.Append(",")
          sb.Append(._EXP)
          sb.Append(",")
          sb.Append(._BAMT1)
          sb.Append(",")
          sb.Append(._BAMT2)
          sb.Append(",")
          sb.Append(._BAMT3)
        Case "Adopted"
          sb.Append(._CURR)
          sb.Append(",")
          sb.Append(._BAMT1)
          sb.Append(",")
          sb.Append(._BAMT2)
          sb.Append(",")
          sb.Append(._BAMT3)
          sb.Append(",")
          sb.Append(._ADOPTD)
        Case "Original"
          sb.Append(._ORIG)
          sb.Append(",")
          sb.Append(._EXP)
          sb.Append(",")
          sb.Append(._BAMT1)
          sb.Append(",")
          sb.Append(._BAMT2)
          sb.Append(",")
          sb.Append(._BAMT3)
        Case "Variance"
      End Select
      sb.Append(",")
      sb.Append(._FUND)
      sb.Append(",")
      sb.Append(._DEPT)
      sb.Append(",")
      WrkDesc = (GetGLACCTDesc(._FUND, 0, ._DEPT, 0, 0, 0))
      WrkDesc = Replace(WrkDesc, ",", "")
      sb.Append(WrkDesc)
      sb.Append(",")
      sb.Append(._GLTYP)
      sb.Append(",")
      WrkAcct = BuildAcctPart(._OBJ, ._FUNC, ._SFUNC)
      sb.Append(WrkAcct)
    End With
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
End Module
