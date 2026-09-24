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
  Dim ds2 As DataSet = New DataSet
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
  Dim WrkBatchFrom As Integer
  Dim WrkBatchTo As Integer
  Dim WrkPageDept As Boolean
  Dim WrkExportNormal As Boolean
  Dim WrkFile As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    With MyFrmGL220B
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
      WrkBatchFrom = MyUtils.CnvSng(.TxtBatchFrom.Text)
      WrkBatchTo = MyUtils.CnvSng(.TxtBatchTo.Text)
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
      WrkExportNormal = False
      If .RbExpAll.Checked Then
        WrkExportNormal = True
      End If
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmGL220B.LblFilePath.Text)
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
    End If

    If MyFrmGL220B.RbFileCurr.Checked Then
      GetDetail()
    Else
      GetDetailHst()
    End If

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.ds = ds
    MyCrViewer.ds2 = ds2
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
      .Columns.Add("GltypDesc", Type.GetType("System.String"))
      .Columns.Add("Refno", Type.GetType("System.Int32"))
      .Columns.Add("Source", Type.GetType("System.String"))
      .Columns.Add("Bchno", Type.GetType("System.Int32"))
      .Columns.Add("BegAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Amt1", Type.GetType("System.Decimal"))
      .Columns.Add("Amt2", Type.GetType("System.Decimal"))
      .Columns.Add("Amt3", Type.GetType("System.Decimal"))
      .Columns.Add("Amt4", Type.GetType("System.Decimal"))
      .Columns.Add("Dated", Type.GetType("System.DateTime"))
      .Columns.Add("Tdesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim SaveGLType As String
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

    Counter = 0
    SaveGLType = ""
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
    If WrkBatchFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "BCHNO >= " & WrkBatchFrom
    End If
    If WrkBatchTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BCHNO <= " & WrkBatchTo
    End If
    If WrkSrcde > 0 Then
      WrkQry = WrkQry & WrkAnd & "SRCDE = " & WrkSrcde
    End If
    WrkSort = " FDNBR, SFUND, PSTDT, SRCDE, GLTYP, DPNBR, OBNBR, FNPGM, SUBFN "
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

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
        'Omit Control Accounts
        If ._GLTYP = "Q" And ._FIL10 = 9999999999 Then
          GoTo NextRec
        End If

        If WrkFile <> String.Empty Then
          If WrkExportNormal And SaveGLType <> ._GLTYP Then
            sw.WriteLine(BuildHeadings(._GLTYP))
            SaveGLType = ._GLTYP
          End If
        End If

        If SaveFund <> ._FDNBR Then
          WrkFundDesc = GetFundDesc(._FDNBR)
        End If
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
        If WrkFundDesc <> "" Then
          dr = ds.Tables(0).NewRow
          dr.Item("fund") = ._FDNBR
          dr.Item("funddesc") = GetFundDesc(._FDNBR)
          dr.Item("sfund") = ._SFUND
          dr.Item("dept") = ._DPNBR
          dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
          dr.Item("obj") = ._OBNBR
          dr.Item("func") = ._FNPGM
          dr.Item("sfunc") = ._SUBFN
          dr.Item("acctdesc") = Buildacct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr.Item("gltyp") = ._GLTYP
          dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
          dr.Item("refno") = ._REFNO
          Select Case ._SRCDE
            Case 1
              dr.Item("source") = "A/P"
            Case 2
              dr.Item("source") = "J/E"
            Case 3
              dr.Item("source") = "Cash"
            Case 4
              dr.Item("source") = "Encum"
            Case 5
              dr.Item("source") = "P/R"
            Case 6
              dr.Item("source") = "Taxes"
          End Select
          dr.Item("bchno") = ._BCHNO
          dr.Item("begamt") = 0
          dr.Item("amt1") = 0
          dr.Item("amt2") = 0
          dr.Item("amt3") = 0
          dr.Item("amt4") = 0
          Select Case ._AMTYP
            Case "D"
              dr.Item("amt1") = ._TRAMT
            Case "C"
              dr.Item("amt2") = ._TRAMT
          End Select
          dr.Item("amt3") = dr.Item("amt1") - dr.Item("amt2")
          dr.Item("tdesc") = Trim(._TDESC)
          dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
          ds.Tables(0).Rows.Add(dr)
          If WrkFile <> String.Empty Then
            If WrkExportNormal Then
              sw.WriteLine(BuildNormal)
            Else
              sw.WriteLine(BuildPartial(WrkGltyp))
            End If
          End If
        End If
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

  Private Sub GetDetailHst()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkMult As Integer
    Dim SaveGLType As String
    Dim SaveFund As Integer
    Dim SaveSfund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFunc As Integer
    Dim SaveSfunc As Integer

    WrkAnd = " and "
    WrkOr = " or "

    myLEDHSTQ = New LEDHSTQ.MyData()
    myLEDHSTQ.MyDBConn = myDBConnect
    myLEDHSTL1 = New LEDHSTL1.MyData()
    myLEDHSTL1.MyDBConn = myDBConnect

    Counter = 0
    SaveGLType = ""
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
    If WrkSrcde > 0 Then
      WrkQry = WrkQry & WrkAnd & "SRCDE = " & WrkSrcde
    End If
    WrkSort = "GLTYP, FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

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
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
        If WrkFundDesc <> "" Then
          dr = ds.Tables(0).NewRow
          dr.Item("fund") = ._FDNBR
          dr.Item("funddesc") = GetFundDesc(._FDNBR)
          dr.Item("sfund") = ._SFUND
          dr.Item("dept") = ._DPNBR
          dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
          dr.Item("obj") = ._OBNBR
          dr.Item("func") = ._FNPGM
          dr.Item("sfunc") = ._SUBFN
          dr.Item("acctdesc") = Buildacct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr.Item("gltyp") = ._GLTYP
          dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
          dr.Item("refno") = ._REFNO
          dr.Item("srcde") = ._SRCDE
          dr.Item("begamt") = 0
          dr.Item("amt1") = 0
          dr.Item("amt2") = 0
          dr.Item("amt3") = 0
          dr.Item("amt4") = 0
          Select Case ._AMTYP
            Case "D"
              dr.Item("amt1") = ._TRAMT
            Case "C"
              dr.Item("amt2") = ._TRAMT
          End Select
          dr.Item("amt3") = dr.Item("amt1") - dr.Item("amt2")
          dr.Item("tdesc") = Trim(._TDESC)
          dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
          ds.Tables(0).Rows.Add(dr)
          If WrkFile <> String.Empty Then
            If WrkExportNormal Then
              sw.WriteLine(BuildNormal)
            Else
              sw.WriteLine(BuildPartial(WrkGltyp))
            End If
          End If

          'Expended Detail
          If Trim(._GLTYP) = "X" And Trim(._TRTYP) <> "B" Then
            dr = ds2.Tables(0).NewRow
            dr.Item("fund") = ._FDNBR
            dr.Item("funddesc") = GetFundDesc(._FDNBR)
            dr.Item("sfund") = ._SFUND
            dr.Item("dept") = ._DPNBR
            dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
            dr.Item("obj") = ._OBNBR
            dr.Item("func") = ._FNPGM
            dr.Item("sfunc") = ._SUBFN
            dr.Item("acctdesc") = Buildacct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
            dr.Item("gltyp") = ._GLTYP
            dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
            dr.Item("refno") = ._REFNO
            dr.Item("srcde") = ._SRCDE
            dr.Item("begamt") = 0
            dr.Item("amt1") = 0
            dr.Item("amt2") = 0
            dr.Item("amt3") = 0
            dr.Item("amt4") = 0
            If ._AMTYP = "D" Then
              WrkMult = 1
            Else
              WrkMult = -1
            End If
            Select Case ._TRTYP
              Case "B"
              Case "E"
                dr.Item("amt3") = ._TRAMT * WrkMult
              Case Else
                If (._TRAMT * WrkMult) >= 0 Then
                  dr.Item("amt1") = ._TRAMT * WrkMult
                Else
                  dr.Item("amt2") = ._TRAMT * WrkMult
                End If
            End Select
            dr.Item("tdesc") = Trim(._TDESC)
            dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
            ds2.Tables(0).Rows.Add(dr)
          End If
        End If
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
      sb.Append("Date")
      sb.Append(",")
      sb.Append("Description")
      sb.Append(",")
      sb.Append("Src")
      sb.Append(",")
      sb.Append("Ref#")
      sb.Append(",")
      Select Case WrkGlType
        Case "A", "L", "Q"
          sb.Append("Debit")
          sb.Append(",")
          sb.Append("Credit")
          sb.Append(",")
          sb.Append("Transactions")
        Case "R"
          sb.Append("Received")
          sb.Append(",")
          sb.Append("Budget")
        Case "X"
          sb.Append("Expended")
          sb.Append(",")
          sb.Append("Encumbrance")
          sb.Append(",")
          sb.Append("Budget")
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

    WrkDescr = GetAcctDesc(dr.Item("fund"), dr.Item("sfund"), dr.Item("dept"), dr.Item("obj"), dr.Item("func"), dr.Item("sfunc"))
    sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
    sb.Append(",")
    sb.Append(Format(dr.Item("dated"), "Short Date"))
    sb.Append(",")
    sb.Append(Chr(34) & dr.Item("tdesc") & Chr(34)) 'Add double quotes
    sb.Append(",")
    sb.Append(dr.Item("srcde"))
    sb.Append(",")
    sb.Append(dr.Item("refno"))
    sb.Append(",")
    sb.Append(dr.Item("amt1"))
    sb.Append(",")
    sb.Append(dr.Item("amt2"))
    Select Case dr.Item("gltyp")
      Case "A", "L", "Q"
        sb.Append(",")
        sb.Append(dr.Item("amt3"))
      Case "R"
      Case "X"
        sb.Append(",")
        sb.Append(dr.Item("amt3"))
    End Select
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function BuildPartial(WrkGlType) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkDescr As String
    sb = New StringBuilder
    With myLEDHSTQ
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
      WrkDescr = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
      sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
      sb.Append(",")
      If ._GLTYP = "X" Then
        sb.Append(dr.Item("amt4"))
      Else
        sb.Append(dr.Item("amt3"))
      End If
    End With
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function Buildacct(ByVal mfund As Integer, ByVal msfund As Integer, ByVal mdept As Integer, ByVal mobj As Integer, ByVal mfnpgm As Integer, ByVal msubfn As Integer) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    Dim WrkDescr As String
    sb = New StringBuilder
    sb.Append(Format(mfund, "000"))
    sb.Append("-")
    sb.Append(Format(msfund, "000"))
    sb.Append("-")
    sb.Append(Format(mdept, "0000"))
    sb.Append("-")
    sb.Append(Format(mobj, "000"))
    sb.Append("-")
    sb.Append(Format(mfnpgm, "0000"))
    sb.Append("-")
    sb.Append(Format(msubfn, "0000"))
    sb.Append(" ")
    WrkDescr = GetAcctDesc(mfund, msfund, mdept, mobj, mfnpgm, msubfn)
    '    sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
    sb.Append(WrkDescr) 'Add double quotes


    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
End Module
