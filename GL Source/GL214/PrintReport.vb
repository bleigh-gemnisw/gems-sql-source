Imports System.Text
Imports System.IO
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myLEDGERQ As LEDGERQ.MyData
  Dim myLEDHSTQ As LEDHSTQ.MyData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myLEDHSTL1 As LEDHSTL1.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkRptFmt As String
  Dim WrkFundFrom As Integer
  Dim WrkFundTo As Integer
  Dim WrkFundDesc As String
  Dim WrkSfundFrom As Integer
  Dim WrkSfundTo As Integer
  Dim WrkDeptFrom As Integer
  Dim WrkDeptTo As Integer
  Dim WrkObjFrom As Integer
  Dim WrkObjTo As Integer
  Dim WrkFuncFrom As Integer
  Dim WrkFuncTo As Integer
  Dim WrkGltyp As String
  Dim WrkSrcde As Integer
  Dim WrkDateFrom As Integer
  Dim WrkDateTo As Integer
  Dim WrkPrevDateFrom As Integer
  Dim WrkPrevDateTo As Integer
  Dim WrkPageDept As Boolean
  Dim WrkObjTot As Boolean
  Dim WrkExportNormal As Boolean
  Dim WrkShowPrevYTD As Boolean
  Dim WrkFile As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    With MyFrmGL214B
      If .RbRptNobud.Checked Then WrkRptFmt = "Nobud"
      If .RbRptNorm.Checked Then WrkRptFmt = "Normal"
      If .RbRptNormRoll.Checked Then WrkRptFmt = "NormalRoll"
      If .RbRptNormNoBrk.Checked Then WrkRptFmt = "NormalNoBrk"
      WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkPrevDateFrom = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -1, .DtPckFrom.Value))
      WrkPrevDateTo = MyUtils.SetDBDate(DateAdd(DateInterval.Year, -1, .DtPckTo.Value))
      WrkFundFrom = MyUtils.CnvSng(.TxtFundFrom.Text)
      WrkFundTo = MyUtils.CnvSng(.TxtFundTo.Text)
      WrkSfundFrom = MyUtils.CnvSng(.TxtSfundFrom.Text)
      WrkSfundTo = MyUtils.CnvSng(.TxtSfundTo.Text)
      WrkDeptFrom = MyUtils.CnvSng(.TxtDeptFrom.Text)
      WrkDeptTo = MyUtils.CnvSng(.TxtDeptTo.Text)
      WrkObjFrom = MyUtils.CnvSng(.TxtObjFrom.Text)
      WrkObjTo = MyUtils.CnvSng(.TxtObjTo.Text)
      WrkFuncFrom = MyUtils.CnvSng(.TxtFuncFrom.Text)
      WrkFuncTo = MyUtils.CnvSng(.TxtFuncTo.Text)
      If .RbTypeAll.Checked Then WrkGltyp = ""
      If .RbTypeAsset.Checked Then WrkGltyp = "A"
      If .RbTypeEquity.Checked Then WrkGltyp = "Q"
      If .RbTypeExpense.Checked Then WrkGltyp = "X"
      If .RbTypeLiability.Checked Then WrkGltyp = "L"
      If .RbTypeRevenue.Checked Then WrkGltyp = "R"
      If .RbSourceAll.Checked Then WrkSrcde = 0
      If .RbSourceAP.Checked Then WrkSrcde = 1
      If .RbSourceJE.Checked Then WrkSrcde = 2
      If .RbSourceCash.Checked Then WrkSrcde = 3
      If .RbSourceEncum.Checked Then WrkSrcde = 4
      If .RbSourcePR.Checked Then WrkSrcde = 5
      If .RbSourceTax.Checked Then WrkSrcde = 6
      WrkPageDept = .ChkPageDept.Checked
      WrkObjTot = .ChkObjTot.Checked
      WrkExportNormal = False
      If .RbExpAll.Checked Then
        WrkExportNormal = True
      End If
      WrkShowPrevYTD = .ChkPrevYTD.Checked
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmGL214B.LblFilePath.Text)
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    If MyFrmGL214B.RbFileCurr.Checked Then
      GetDetail()
    Else
      GetDetailHst()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.ds = ds
    MyCrViewer.Show()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("RollNo", Type.GetType("System.Int32"))
      .Columns.Add("Fund", Type.GetType("System.Int32"))
      .Columns.Add("FundDesc", Type.GetType("System.String"))
      .Columns.Add("Sfund", Type.GetType("System.Int32"))
      .Columns.Add("Dept", Type.GetType("System.Int32"))
      .Columns.Add("DeptDesc", Type.GetType("System.String"))
      .Columns.Add("Obj", Type.GetType("System.Int32"))
      .Columns.Add("Func", Type.GetType("System.Int32"))
      .Columns.Add("Sfunc", Type.GetType("System.Int32"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("GltypHdr", Type.GetType("System.String"))
      .Columns.Add("GltypDesc", Type.GetType("System.String"))
      .Columns.Add("Amt1", Type.GetType("System.Decimal"))
      .Columns.Add("Amt2", Type.GetType("System.Decimal"))
      .Columns.Add("Amt3", Type.GetType("System.Decimal"))
      .Columns.Add("Amt4", Type.GetType("System.Decimal"))
      .Columns.Add("Amt5", Type.GetType("System.Decimal"))
      .Columns.Add("Amt6", Type.GetType("System.Decimal"))
      .Columns.Add("Amt7", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkQryDateFrom As Integer
    Dim WrkSort As String
    Dim Counter As Integer
    Dim SaveGLType As String
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFunc As Integer
    Dim SaveSfunc As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect

    If WrkShowPrevYTD Then
      WrkQryDateFrom = WrkPrevDateFrom
    Else
      WrkQryDateFrom = WrkDateFrom
    End If
    WrkQry = "PSTDT <= " & WrkDateTo
    If WrkFundFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFundFrom
    End If
    If WrkFundTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkFundTo
    End If
    If WrkSfundFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "SFUND >= " & WrkSfundFrom
    End If
    If WrkSfundTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "SFUND <= " & WrkSfundTo
    End If
    If WrkDeptFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "DPNBR >= " & WrkDeptFrom
    End If
    If WrkDeptTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "DPNBR <= " & WrkDeptTo
    End If
    If WrkObjFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "OBNBR >= " & WrkObjFrom
    End If
    If WrkObjTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "OBNBR <= " & WrkObjTo
    End If
    If WrkFuncFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FNPGM >= " & WrkFuncFrom
    End If
    If WrkFuncTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FNPGM <= " & WrkFuncTo
    End If
    If WrkSrcde > 0 Then
      WrkQry = WrkQry & WrkAnd & "SRCDE = " & WrkSrcde
    End If
    If WrkGltyp <> "" Then
      WrkQry = WrkQry & WrkAnd & "GLTYP = " & MyUtils.Quo(WrkGltyp)
      Select Case WrkGltyp
        Case "R", "X"
          WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkQryDateFrom
        Case Else
      End Select
    Else
      WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkQryDateFrom & WrkAnd &
   "GLTYP <> 'A'" & WrkAnd & "GLTYP <> 'L'" & WrkAnd & "GLTYP <> 'Q'" &
   WrkOr & WrkQry & WrkAnd & "GLTYP <> 'R'" & WrkAnd & "GLTYP <> 'X'"
    End If
    WrkSort = "GLTYP, FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    SaveGLType = ""
    If WrkFile <> String.Empty Then
      If Not WrkExportNormal Then
        sw.WriteLine(BuildHeadings(""))
      End If
    End If

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        If WrkFile <> String.Empty Then
          If WrkExportNormal And SaveGLType <> ._GLTYP Then
            sw.WriteLine(BuildHeadings(._GLTYP))
            SaveGLType = ._GLTYP
          End If
        End If
        If SaveFund <> ._FDNBR Then
          WrkFundDesc = GetFundDesc(._FDNBR)
        End If
        If SaveFund <> ._FDNBR Or SaveSfund <> ._SFUND Or SaveDept <> ._DPNBR Or SaveObj <> ._OBNBR _
      Or SaveFunc <> ._FNPGM Or SaveSfunc <> ._SUBFN Then
          If WrkFundDesc <> "" Then
            GetBalance()
          End If
        End If
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
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

    If WrkFile <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
  End Sub
  Private Sub GetBalance()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkMult As Integer
    Dim WrkOrigBudget As Decimal
    Dim WrkBudget As Decimal
    Dim WrkExpend As Decimal
    Dim WrkEncumb As Decimal
    Dim WrkRemain As Decimal
    Dim WrkBalance As Decimal
    Dim WrkPctUsed As Decimal
    Dim WrkPrevYTD As Decimal
    Dim WrkDate As Integer
    Dim WrkGlTyp As String

    WrkOrigBudget = 0
    WrkBudget = 0
    WrkExpend = 0
    WrkEncumb = 0
    WrkRemain = 0
    WrkBalance = 0
    WrkPctUsed = 0
    WrkPrevYTD = 0
    WrkGlTyp = ""

    WrkDate = 0
    With myLEDGERQ
      Select Case ._GLTYP
        Case "R", "X"
          If WrkShowPrevYTD Then
            WrkDate = WrkPrevDateFrom
          Else
            WrkDate = WrkDateFrom
          End If
        Case "Q"
          If ._FIL10 = 9999999999 Then
            If WrkShowPrevYTD Then
              WrkDate = WrkPrevDateFrom
            Else
              WrkDate = WrkDateFrom
            End If
          End If
        Case Else
      End Select
      ds2 = myLEDGERL1.GetAllAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN, WrkDate, WrkDateTo)
    End With

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        WrkGlTyp = .Item("gltyp")
        Select Case WrkGlTyp
          Case "R", "X"
            If .Item("amtyp") = "D" Then
              WrkMult = 1
            Else
              WrkMult = -1
            End If
          Case Else
            If .Item("amtyp") = "D" Then
              WrkMult = -1
            Else
              WrkMult = 1
            End If
        End Select

        Select Case WrkGlTyp
          Case "R"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkOrigBudget = WrkOrigBudget + (.Item("orig") * WrkMult * -1)
                  WrkBudget = WrkBudget + (.Item("tramt") * WrkMult * -1)
                Case Else
                  WrkExpend = WrkExpend + (.Item("tramt") * WrkMult)
              End Select
            End If
            If WrkShowPrevYTD And .Item("pstdt") >= WrkPrevDateFrom And .Item("pstdt") <= WrkPrevDateTo Then
              Select Case .Item("trtyp")
                Case "B"
                Case Else
                  WrkPrevYTD = WrkPrevYTD + (.Item("tramt") * WrkMult)
              End Select
            End If
          Case "X"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkOrigBudget = WrkOrigBudget + (.Item("orig") * WrkMult)
                  WrkBudget = WrkBudget + (.Item("tramt") * WrkMult)
                Case "E"
                  WrkEncumb = WrkEncumb + (.Item("tramt") * WrkMult)
                Case Else
                  WrkExpend = WrkExpend + (.Item("tramt") * WrkMult)
              End Select
            End If
            If WrkShowPrevYTD And .Item("pstdt") >= WrkPrevDateFrom And .Item("pstdt") <= WrkPrevDateTo Then
              Select Case .Item("trtyp")
                Case "B"
                Case "E"
                Case Else
                  WrkPrevYTD = WrkPrevYTD + (.Item("tramt") * WrkMult)
              End Select
            End If
          Case Else
            Select Case .Item("trtyp")
              Case "E"
                '  If .Item("pstdt") >= WrkDateFrom Then
                '    WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
                '  End If
              Case Else
                WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
                If WrkShowPrevYTD And .Item("pstdt") <= WrkPrevDateTo Then
                  WrkPrevYTD = WrkPrevYTD + (.Item("tramt") * WrkMult * -1)
                End If
            End Select
        End Select
      End With
    Next

    If WrkGlTyp <> "R" Then
      WrkRemain = WrkBudget - WrkBalance - WrkExpend - WrkEncumb
    Else
      WrkRemain = WrkBudget + WrkExpend + WrkEncumb
    End If
    With myLEDGERQ
      If WrkBudget <> 0 Or WrkRemain <> 0 Or WrkPrevYTD <> 0 Then
        dr = ds.Tables(0).NewRow
        If WrkRptFmt = "NormalRoll" Then
          dr.Item("rollno") = GetAcctRoll(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        Else
          dr.Item("rollno") = 0
        End If
        dr.Item("fund") = ._FDNBR
        dr.Item("funddesc") = GetFundDesc(._FDNBR)
        dr.Item("sfund") = ._SFUND
        dr.Item("dept") = ._DPNBR
        dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
        dr.Item("obj") = ._OBNBR
        dr.Item("func") = ._FNPGM
        dr.Item("sfunc") = ._SUBFN
        dr.Item("acctdesc") = Format(._DPNBR, "0000") & "-" & Format(._OBNBR, "000") &
      "-" & Format(._FNPGM, "0000") & "-" & Format(._SUBFN, "0000") &
      " " & GetAcctDesc(._FDNBR, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr.Item("gltyp") = WrkGlTyp
        dr.Item("gltyphdr") = GetGlTypDesc(WrkGlTyp, True)
        If WrkRptFmt = "Nobud" Then
          If WrkGlTyp = "X" Then
            dr.Item("amt1") = WrkExpend
            dr.Item("amt2") = WrkEncumb
            dr.Item("amt3") = WrkRemain
            dr.Item("amt4") = 0
          Else
            dr.Item("amt1") = 0
            dr.Item("amt2") = 0
            dr.Item("amt3") = WrkRemain
            dr.Item("amt4") = 0
          End If
        Else
          If WrkBudget <> 0 Then
            WrkPctUsed = (1 - (WrkRemain / WrkBudget)) * 100
          End If
          Select Case WrkGlTyp
            Case "R"
              dr.Item("amt1") = WrkOrigBudget
              dr.Item("amt2") = WrkBudget
              dr.Item("amt3") = WrkExpend * -1
              dr.Item("amt4") = 0
              dr.Item("amt5") = WrkRemain
              dr.Item("amt6") = WrkPctUsed
              dr.Item("amt7") = WrkPrevYTD
            Case "X"
              dr.Item("amt1") = WrkOrigBudget
              dr.Item("amt2") = WrkBudget
              dr.Item("amt3") = WrkExpend
              dr.Item("amt4") = WrkEncumb
              dr.Item("amt5") = WrkRemain
              dr.Item("amt6") = WrkPctUsed
              dr.Item("amt7") = WrkPrevYTD
            Case Else
              dr.Item("amt1") = 0
              dr.Item("amt2") = 0
              dr.Item("amt3") = WrkRemain
              dr.Item("amt4") = WrkPrevYTD
              dr.Item("amt5") = 0
              dr.Item("amt6") = 0
              dr.Item("amt7") = 0
          End Select
        End If
        dr.Item("gltypdesc") = GetGlTypDesc(WrkGlTyp, False)
        ds.Tables(0).Rows.Add(dr)

        If WrkFile <> String.Empty Then
          If WrkExportNormal Then
            sw.WriteLine(BuildNormal)
          Else
            sw.WriteLine(BuildPartial(WrkGlTyp))
          End If
        End If
      End If
    End With
  End Sub
  Private Sub GetDetailHst()
    Dim WrkQry As String
    Dim WrkQryDateFrom As Integer
    Dim WrkSort As String
    Dim Counter As Integer
    Dim SaveGLType As String
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFunc As Integer
    Dim SaveSfunc As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *And "
      WrkOr = " *Or "
    Else
      WrkAnd = " And "
      WrkOr = " Or "
    End If

    myLEDHSTQ = New LEDHSTQ.MyData()
    myLEDHSTQ.MyDBConn = myDBConnect
    myLEDHSTL1 = New LEDHSTL1.MyData()
    myLEDHSTL1.MyDBConn = myDBConnect

    If WrkShowPrevYTD Then
      WrkQryDateFrom = WrkPrevDateFrom
    Else
      WrkQryDateFrom = WrkDateFrom
    End If
    WrkQry = "PSTDT <= " & WrkDateTo
    If WrkGltyp <> "" Then
      WrkQry = WrkQry & WrkAnd & "GLTYP = " & MyUtils.Quo(WrkGltyp)
    End If
    If WrkFundFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFundFrom
    End If
    If WrkFundTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkFundTo
    End If
    If WrkSfundFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "SFUND >= " & WrkSfundFrom
    End If
    If WrkSfundTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "SFUND <= " & WrkSfundTo
    End If
    If WrkDeptFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "DPNBR >= " & WrkDeptFrom
    End If
    If WrkDeptTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "DPNBR <= " & WrkDeptTo
    End If
    If WrkObjFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "OBNBR >= " & WrkObjFrom
    End If
    If WrkObjTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "OBNBR <= " & WrkObjTo
    End If
    If WrkFuncFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FNPGM >= " & WrkFuncFrom
    End If
    If WrkFuncTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FNPGM <= " & WrkFuncTo
    End If
    If WrkSrcde > 0 Then
      WrkQry = WrkQry & WrkAnd & "SRCDE = " & WrkSrcde
    End If
    If WrkGltyp <> "" Then
      WrkQry = WrkQry & WrkAnd & "GLTYP = " & MyUtils.Quo(WrkGltyp)
      Select Case WrkGltyp
        Case "R", "X"
          WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkQryDateFrom
        Case Else
      End Select
    Else
      WrkQry = WrkQry & WrkAnd & "PSTDT >= " & WrkQryDateFrom & WrkAnd &
   "GLTYP <> 'A'" & WrkAnd & "GLTYP <> 'L'" & WrkAnd & "GLTYP <> 'Q'" &
   WrkOr & WrkQry & WrkAnd & "GLTYP <> 'R'" & WrkAnd & "GLTYP <> 'X'"
    End If
    WrkSort = "GLTYP, FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    SaveGLType = ""
    If WrkFile <> String.Empty Then
      If Not WrkExportNormal Then
        sw.WriteLine(BuildHeadings(""))
      End If
    End If

ReadNext:
    myLEDHSTQ.ReadQry()
    If Not myLEDHSTQ.IsEOF Then
      With myLEDHSTQ
        Counter = Counter + 1
        If WrkFile <> String.Empty Then
          If WrkExportNormal And SaveGLType <> ._GLTYP Then
            sw.WriteLine(BuildHeadings(._GLTYP))
            SaveGLType = ._GLTYP
          End If
        End If
        If SaveFund <> ._FDNBR Then
          WrkFundDesc = GetFundDesc(._FDNBR)
        End If
        If SaveFund <> ._FDNBR Or SaveSfund <> ._SFUND Or SaveDept <> ._DPNBR Or SaveObj <> ._OBNBR _
      Or SaveFunc <> ._FNPGM Or SaveSfunc <> ._SUBFN Then
          If WrkFundDesc <> "" Then
            GetBalanceHst()
          End If
        End If
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
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

    If WrkFile <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myFrmProgress.Close()
    myLEDHSTQ.CloseFile()
  End Sub
  Private Sub GetBalanceHst()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkMult As Integer
    Dim WrkOrigBudget As Decimal
    Dim WrkBudget As Decimal
    Dim WrkExpend As Decimal
    Dim WrkEncumb As Decimal
    Dim WrkRemain As Decimal
    Dim WrkBalance As Decimal
    Dim WrkPctUsed As Decimal
    Dim WrkPrevYTD As Decimal
    Dim WrkDate As Integer
    Dim WrkGlTyp As String

    WrkOrigBudget = 0
    WrkBudget = 0
    WrkExpend = 0
    WrkEncumb = 0
    WrkRemain = 0
    WrkBalance = 0
    WrkPctUsed = 0
    WrkPrevYTD = 0
    WrkGlTyp = ""

    WrkDate = 0
    With myLEDHSTQ
      Select Case ._GLTYP
        Case "R", "X"
          If WrkShowPrevYTD Then
            WrkDate = WrkPrevDateFrom
          Else
            WrkDate = WrkDateFrom
          End If
        Case "Q"
          If ._FIL10 = 9999999999 Then
            If WrkShowPrevYTD Then
              WrkDate = WrkPrevDateFrom
            Else
              WrkDate = WrkDateFrom
            End If
          End If
        Case Else
      End Select
      ds2 = myLEDHSTL1.GetAllAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN, WrkDate, WrkDateTo)
    End With

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("amtyp") = "D" Then
          WrkMult = 1
        Else
          WrkMult = -1
        End If
        WrkGlTyp = .Item("gltyp")
        Select Case WrkGlTyp
          Case "R"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkOrigBudget = WrkOrigBudget + (.Item("orig") * WrkMult)
                  WrkBudget = WrkBudget + (.Item("tramt") * WrkMult)
                Case Else
                  WrkExpend = WrkExpend + (.Item("tramt") * WrkMult)
              End Select
            End If
            If WrkShowPrevYTD And .Item("pstdt") >= WrkPrevDateFrom And .Item("pstdt") <= WrkPrevDateTo Then
              Select Case .Item("trtyp")
                Case "B"
                Case Else
                  WrkPrevYTD = WrkPrevYTD + (.Item("tramt") * WrkMult)
              End Select
            End If
          Case "X"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkOrigBudget = WrkOrigBudget + (.Item("orig") * WrkMult)
                  WrkBudget = WrkBudget + (.Item("tramt") * WrkMult)
                Case "E"
                  WrkEncumb = WrkEncumb + (.Item("tramt") * WrkMult)
                Case Else
                  WrkExpend = WrkExpend + (.Item("tramt") * WrkMult)
              End Select
            End If
            If WrkShowPrevYTD And .Item("pstdt") >= WrkPrevDateFrom And .Item("pstdt") <= WrkPrevDateTo Then
              Select Case .Item("trtyp")
                Case "B"
                Case "E"
                Case Else
                  WrkPrevYTD = WrkPrevYTD + (.Item("tramt") * WrkMult)
              End Select
            End If
          Case Else
            Select Case .Item("trtyp")
              Case "E"
                '  If .Item("pstdt") >= WrkDateFrom Then
                '    WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
                '  End If
              Case Else
                WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
                If WrkShowPrevYTD And .Item("pstdt") <= WrkPrevDateTo Then
                  WrkPrevYTD = WrkPrevYTD + (.Item("tramt") * WrkMult * -1)
                End If
            End Select
        End Select
      End With
    Next

    If WrkGlTyp <> "R" Then
      WrkRemain = WrkBudget - WrkBalance - WrkExpend - WrkEncumb
    Else
      WrkRemain = WrkBudget + WrkExpend + WrkEncumb
    End If
    With myLEDHSTQ
      If WrkBudget <> 0 Or WrkRemain <> 0 Or WrkPrevYTD <> 0 Then
        dr = ds.Tables(0).NewRow
        If WrkRptFmt = "NormalRoll" Then
          dr.Item("rollno") = GetAcctRoll(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        Else
          dr.Item("rollno") = 0
        End If
        dr.Item("fund") = ._FDNBR
        dr.Item("funddesc") = GetFundDesc(._FDNBR)
        dr.Item("sfund") = ._SFUND
        dr.Item("dept") = ._DPNBR
        dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
        dr.Item("obj") = ._OBNBR
        dr.Item("func") = ._FNPGM
        dr.Item("sfunc") = ._SUBFN
        dr.Item("acctdesc") = Format(._DPNBR, "0000") & "-" & Format(._OBNBR, "000") &
      "-" & Format(._FNPGM, "0000") & "-" & Format(._SUBFN, "0000") &
      " " & GetAcctDesc(._FDNBR, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr.Item("gltyp") = WrkGlTyp
        dr.Item("gltyphdr") = GetGlTypDesc(WrkGlTyp, True)
        If WrkRptFmt = "Nobud" Then
          If WrkGlTyp = "X" Then
            dr.Item("amt1") = WrkExpend
            dr.Item("amt2") = WrkEncumb
            dr.Item("amt3") = WrkRemain
            dr.Item("amt4") = 0
          Else
            dr.Item("amt1") = 0
            dr.Item("amt2") = 0
            dr.Item("amt3") = WrkRemain
            dr.Item("amt4") = 0
          End If
        Else
          If WrkBudget <> 0 Then
            WrkPctUsed = (1 - (WrkRemain / WrkBudget)) * 100
          End If
          Select Case WrkGlTyp
            Case "R"
              dr.Item("amt1") = WrkOrigBudget * -1
              dr.Item("amt2") = WrkBudget
              dr.Item("amt3") = WrkExpend * -1
              dr.Item("amt4") = 0
              dr.Item("amt5") = WrkRemain
              dr.Item("amt6") = WrkPctUsed
              dr.Item("amt7") = WrkPrevYTD
            Case "X"
              dr.Item("amt1") = WrkOrigBudget
              dr.Item("amt2") = WrkBudget
              dr.Item("amt3") = WrkExpend
              dr.Item("amt4") = WrkEncumb
              dr.Item("amt5") = WrkRemain
              dr.Item("amt6") = WrkPctUsed
              dr.Item("amt7") = WrkPrevYTD
            Case Else
              dr.Item("amt1") = 0
              dr.Item("amt2") = 0
              dr.Item("amt3") = WrkRemain
              dr.Item("amt4") = WrkPrevYTD
              dr.Item("amt5") = 0
              dr.Item("amt6") = 0
              dr.Item("amt7") = 0
          End Select
        End If
        dr.Item("gltypdesc") = GetGlTypDesc(WrkGlTyp, False)
        ds.Tables(0).Rows.Add(dr)

        If WrkFile <> String.Empty Then
          If WrkExportNormal Then
            sw.WriteLine(BuildNormal)
          Else
            sw.WriteLine(BuildPartial(WrkGlTyp))
          End If
        End If
      End If
    End With
  End Sub
  Public Function BuildHeadings(WrkGlType As String)
    Dim sb As StringBuilder
    Dim WrkStr As String
    sb = New StringBuilder
    If WrkExportNormal Then
      sb.Append("G/L Type")
      sb.Append(",")
      sb.Append("Fund")
      sb.Append(",")
      sb.Append("Fund Descr")
      sb.Append(",")
      sb.Append("Dept")
      sb.Append(",")
      sb.Append("Dept Descr")
      sb.Append(",")
      sb.Append("Object")
      sb.Append(",")
      sb.Append("Function")
      sb.Append(",")
      sb.Append("SubFunction")
      sb.Append(",")
    End If
    sb.Append("Acct Number")
    sb.Append(",")
    sb.Append("Acct Descr")
    sb.Append(",")
    If WrkExportNormal Then
      Select Case WrkGlType
        Case "A", "L", "Q"
          sb.Append("")
          sb.Append(",")
          sb.Append("")
          sb.Append(",")
          sb.Append("Balance")
          sb.Append(",")
          sb.Append("")
          sb.Append(",")
          sb.Append("")
          sb.Append(",")
          sb.Append("")
        Case "R"
          sb.Append("Original Budget")
          sb.Append(",")
          sb.Append("Current Budget")
          sb.Append(",")
          sb.Append("Received")
          sb.Append(",")
          sb.Append(",")
          sb.Append("")
          sb.Append("Remaining Budget")
          sb.Append(",")
          sb.Append("Pct Used")
        Case "X"
          sb.Append("Original Budget")
          sb.Append(",")
          sb.Append("Current Budget")
          sb.Append(",")
          sb.Append("Expended")
          sb.Append(",")
          sb.Append("Encumbered")
          sb.Append(",")
          sb.Append("Remaining Budget")
          sb.Append(",")
          sb.Append("Pct Used")
      End Select
    Else
      sb.Append("Balance")
    End If
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildNormal() As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkDescr As String
    WrkStr = ""
    sb = New StringBuilder
    sb.Append(Replace(GetGlTypDesc(dr.Item("gltyp"), False), "TOTAL", ""))
    sb.Append(",")
    sb.Append(dr.Item("fund"))
    sb.Append(",")
    WrkDescr = GetFundDesc(dr.Item("fund"))
    sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
    sb.Append(",")
    sb.Append(dr.Item("dept"))
    sb.Append(",")
    WrkDescr = GetDeptDesc(dr.Item("fund"), dr.Item("dept"))
    sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
    sb.Append(",")
    sb.Append(dr.Item("obj"))
    sb.Append(",")
    sb.Append(dr.Item("func"))
    sb.Append(",")
    sb.Append(dr.Item("sfunc"))
    sb.Append(",")
    sb.Append(Format(dr.Item("fund"), "000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("dept"), "0000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("obj"), "000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("func"), "0000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("sfunc"), "0000"))
    sb.Append(",")
    WrkDescr = GetAcctDesc(dr.Item("fund"), dr.Item("dept"), dr.Item("obj"), dr.Item("func"), dr.Item("sfunc"))
    sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
    sb.Append(",")
    sb.Append(dr.Item("amt1"))
    sb.Append(",")
    sb.Append(dr.Item("amt2"))
    sb.Append(",")
    sb.Append(dr.Item("amt3"))
    sb.Append(",")
    sb.Append(dr.Item("amt4"))
    sb.Append(",")
    sb.Append(dr.Item("amt5"))
    sb.Append(",")
    sb.Append(dr.Item("amt6"))
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildPartial(WrkGlType) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkDescr As String
    sb = New StringBuilder
    sb.Append(Format(dr.Item("fund"), "000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("dept"), "0000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("obj"), "000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("func"), "0000"))
    sb.Append("-")
    sb.Append(Format(dr.Item("sfunc"), "0000"))
    sb.Append(",")
    WrkDescr = GetAcctDesc(dr.Item("fund"), dr.Item("dept"), dr.Item("obj"), dr.Item("func"), dr.Item("sfunc"))
    sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
    sb.Append(",")
    Select Case WrkGlType
      Case "A", "L", "Q"
        sb.Append(dr.Item("amt3"))
      Case Else
        sb.Append(dr.Item("amt5"))
    End Select
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
End Module
