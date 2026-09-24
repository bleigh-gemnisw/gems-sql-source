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
  Dim WrkPageDept As Boolean
  Dim WrkFile As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    With MyFrmGL244B
      WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
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
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmGL244B.LblFilePath.Text)
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    If MyFrmGL244B.RbFileCurr.Checked Then
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
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFunc As Integer
    Dim SaveSfunc As Integer

    WrkAnd = " and "
    WrkOr = " or "

    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect

    WrkQry = "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo
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
    WrkSort = "GLTYP, FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
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
    Dim sb As StringBuilder
    Dim I As Integer
    Dim WrkMult As Integer
    Dim WrkExpend As Decimal
    Dim WrkMTDExpend As Decimal
    Dim WrkYearMonth As Integer
    Dim WrkRemain As Decimal
    Dim WrkBalance As Decimal
    Dim WrkDescr As String

    WrkExpend = 0
    WrkMTDExpend = 0
    WrkRemain = 0
    WrkBalance = 0

    With myLEDGERQ
      ds2 = myLEDGERL1.GetAllAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN, 0, WrkDateTo)
    End With
    WrkYearMonth = Mid(WrkDateTo, 1, 6)

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("amtyp") = "D" Then
          WrkMult = 1
        Else
          WrkMult = -1
        End If
        Select Case .Item("gltyp")
          Case "R"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkBalance = WrkBalance + .Item("tramt")
                Case Else
                  WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
              End Select
            End If
          Case "X"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkBalance = WrkBalance + .Item("tramt")
                Case "E"
                Case Else
                  WrkExpend = WrkExpend + (.Item("tramt") * WrkMult)
                  If Mid(.Item("pstdt"), 1, 6) = WrkYearMonth Then
                    WrkMTDExpend = WrkMTDExpend + (.Item("tramt") * WrkMult)
                  End If
              End Select
            End If
          Case Else
            Select Case .Item("trtyp")
              Case "E"
              Case Else
                WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
            End Select
        End Select
      End With
    Next

    WrkRemain = WrkBalance - WrkExpend
    With myLEDGERQ
      If WrkBalance <> 0 Or WrkRemain <> 0 Then
        dr = ds.Tables(0).NewRow
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
        dr.Item("gltyp") = ._GLTYP
        dr.Item("gltyphdr") = GetGlTypDesc(._GLTYP, True)
        dr.Item("amt1") = WrkExpend
        dr.Item("amt2") = WrkMTDExpend
        If ._GLTYP = "X" Then
          dr.Item("amt3") = WrkRemain
        Else
          dr.Item("amt3") = WrkBalance
        End If
        dr.Item("amt4") = 0
        dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, False)
        ds.Tables(0).Rows.Add(dr)

        If WrkFile <> String.Empty Then
          '      If ._GLTYP = "R" Or ._GLTYP = "X" Then
          sb = New StringBuilder
          sb.Append(Format(._FDNBR, "000"))
          sb.Append("-")
          sb.Append(Format(._DPNBR, "0000"))
          sb.Append("-")
          sb.Append(Format(._OBNBR, "000"))
          sb.Append("-")
          sb.Append(Format(._FNPGM, "0000"))
          sb.Append("-")
          sb.Append(Format(._SUBFN, "0000"))
          sb.Append(",")
          WrkDescr = GetAcctDesc(._FDNBR, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
          sb.Append(",")
          If ._GLTYP = "X" Then
            sb.Append(WrkRemain)
          Else
            sb.Append(WrkBalance)
          End If
          sw.WriteLine(sb.ToString)
          sb = Nothing
        End If
      End If
      '  End If
    End With
  End Sub
  Private Sub GetDetailHst()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
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

    myLEDHSTQ = New LEDHSTQ.MyData()
    myLEDHSTQ.MyDBConn = myDBConnect
    myLEDHSTL1 = New LEDHSTL1.MyData()
    myLEDHSTL1.MyDBConn = myDBConnect

    WrkQry = "PSTDT >= " & WrkDateFrom & WrkAnd & "PSTDT <= " & WrkDateTo
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
    WrkSort = "GLTYP, FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    myLEDHSTQ.ReadQry()
    If Not myLEDHSTQ.IsEOF Then
      With myLEDHSTQ
        Counter = Counter + 1
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
    Dim sb As StringBuilder
    Dim I As Integer
    Dim WrkMult As Integer
    Dim WrkExpend As Decimal
    Dim WrkMTDExpend As Decimal
    Dim WrkRemain As Decimal
    Dim WrkBalance As Decimal
    Dim WrkYearMonth As Integer
    Dim WrkDescr As String

    WrkExpend = 0
    WrkMTDExpend = 0
    WrkRemain = 0
    WrkBalance = 0

    With myLEDHSTQ
      ds2 = myLEDHSTL1.GetAllAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN, 0, WrkDateTo)
    End With
    WrkYearMonth = Mid(WrkDateTo, 1, 6)

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("amtyp") = "D" Then
          WrkMult = 1
        Else
          WrkMult = -1
        End If
        Select Case .Item("gltyp")
          Case "R"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkBalance = WrkBalance + .Item("tramt")
                Case Else
                  WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
              End Select
            End If
          Case "X"
            If .Item("pstdt") >= WrkDateFrom Then
              Select Case .Item("trtyp")
                Case "B"
                  WrkBalance = WrkBalance + .Item("tramt")
                Case "E"
                Case Else
                  WrkExpend = WrkExpend + (.Item("tramt") * WrkMult)
                  If Mid(.Item("pstdt"), 1, 6) = WrkYearMonth Then
                    WrkMTDExpend = WrkMTDExpend + (.Item("tramt") * WrkMult)
                  End If
              End Select
            End If
          Case Else
            Select Case .Item("trtyp")
              Case "E"
              Case Else
                WrkBalance = WrkBalance + (.Item("tramt") * WrkMult)
            End Select
        End Select
      End With
    Next

    WrkRemain = WrkBalance - WrkExpend
    With myLEDHSTQ
      If WrkBalance <> 0 Or WrkRemain <> 0 Then
        dr = ds.Tables(0).NewRow
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
        dr.Item("gltyp") = ._GLTYP
        dr.Item("gltyphdr") = GetGlTypDesc(._GLTYP, True)
        dr.Item("amt1") = WrkExpend
        dr.Item("amt2") = WrkMTDExpend
        If ._GLTYP = "X" Then
          dr.Item("amt3") = WrkRemain
        Else
          dr.Item("amt3") = WrkBalance
        End If
        dr.Item("amt4") = 0
        dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, False)
        ds.Tables(0).Rows.Add(dr)

        If WrkFile <> String.Empty Then
          '      If ._GLTYP = "R" Or ._GLTYP = "X" Then
          sb = New StringBuilder
          sb.Append(Format(._FDNBR, "000"))
          sb.Append("-")
          sb.Append(Format(._DPNBR, "0000"))
          sb.Append("-")
          sb.Append(Format(._OBNBR, "000"))
          sb.Append("-")
          sb.Append(Format(._FNPGM, "0000"))
          sb.Append("-")
          sb.Append(Format(._SUBFN, "0000"))
          sb.Append(",")
          WrkDescr = GetAcctDesc(._FDNBR, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
          sb.Append(",")
          If ._GLTYP = "X" Then
            sb.Append(WrkRemain)
          Else
            sb.Append(WrkBalance)
          End If
          sw.WriteLine(sb.ToString)
          sb = Nothing
        End If
      End If
      '  End If
    End With
  End Sub
End Module
