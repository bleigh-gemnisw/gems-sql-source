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
  Dim myAPEHSTL1 As APEHSTL1.MyData

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
  Dim WrkAP As String
  Dim WrkExpDtl As String
  Dim WrkDateFrom As Integer
  Dim WrkDateTo As Integer
  Dim WrkPageDept As Boolean
  Dim WrkExportNormal As Boolean
  Dim WrkFile As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Const cMaxTdesc As Integer = 23
  Public Sub PrtReport()

    With MyFrmGL212B
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
      If .RbAPDesc.Checked Then WrkAP = "Desc"
      If .RbAPVend.Checked Then WrkAP = "Vend"
      If .RbExpVendName.Checked Then WrkExpDtl = "Name"
      If .RbExpVendDesc.Checked Then WrkExpDtl = "Desc"
      WrkPageDept = .ChkPageDept.Checked
      WrkExportNormal = False
      If .RbExpAll.Checked Then
        WrkExportNormal = True
      End If
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmGL212B.LblFilePath.Text)
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
      ds2 = ds.Clone
    Else
      ds.Clear()
      ds2.Clear()
    End If

    If MyFrmGL212B.RbFileCurr.Checked Then
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
      .Columns.Add("Srcde", Type.GetType("System.Int32"))
      .Columns.Add("Source", Type.GetType("System.String"))
      .Columns.Add("BegAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Amt1", Type.GetType("System.Decimal"))
      .Columns.Add("Amt2", Type.GetType("System.Decimal"))
      .Columns.Add("Amt3", Type.GetType("System.Decimal"))
      .Columns.Add("Amt4", Type.GetType("System.Decimal"))
      .Columns.Add("Dated", Type.GetType("System.DateTime"))
      .Columns.Add("Tdesc", Type.GetType("System.String")) 'Only 212/212B
      .Columns.Add("Vennm", Type.GetType("System.String")) 'Only 212C 
      .Columns.Add("Descr", Type.GetType("System.String")) 'Only 212C 
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
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

    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect

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
    If WrkSrcde > 0 Then
      WrkQry = WrkQry & WrkAnd & "SRCDE = " & WrkSrcde
    End If

    'added for department security - 05/12/26  ken
    WrkQry = WrkQry & WrkAnd & BuildDepSecQry(MyUserID)


    WrkSort = "GLTYP, FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
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
            GetBegTramt()
          End If
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
          dr.Item("funddesc") = WrkFundDesc
          dr.Item("sfund") = ._SFUND
          dr.Item("dept") = ._DPNBR
          dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
          dr.Item("obj") = ._OBNBR
          dr.Item("func") = ._FNPGM
          dr.Item("sfunc") = ._SUBFN
          dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr.Item("gltyp") = ._GLTYP
          dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
          dr.Item("refno") = ._REFNO
          dr.Item("srcde") = ._SRCDE
          dr.Item("source") = GetSourceDesc(._SRCDE)
          dr.Item("begamt") = 0
          dr.Item("amt1") = 0
          dr.Item("amt2") = 0
          dr.Item("amt3") = 0
          dr.Item("amt4") = 0
          Select Case ._GLTYP
            Case "A", "L", "Q"
              If ._AMTYP = "D" Then
                dr.Item("amt1") = ._TRAMT
              Else
                dr.Item("amt2") = ._TRAMT * -1
              End If
              dr.Item("amt3") = dr.Item("amt1") + dr.Item("amt2")
            Case "R"
              If ._AMTYP = "D" Then
                WrkMult = -1
              Else
                WrkMult = 1
              End If
              Select Case ._TRTYP
                Case "B"
                  dr.Item("amt2") = ._TRAMT * WrkMult
                  dr.Item("amt3") = ._TRAMT * WrkMult
                Case Else
                  dr.Item("amt1") = ._TRAMT * WrkMult
                  dr.Item("amt3") = ._TRAMT * WrkMult * -1
              End Select
            Case "X"
              If ._AMTYP = "D" Then
                WrkMult = 1
              Else
                WrkMult = -1
              End If
              Select Case ._TRTYP
                Case "B"
                  dr.Item("amt3") = ._TRAMT * WrkMult
                  dr.Item("amt4") = ._TRAMT * WrkMult
                Case "E"
                  dr.Item("amt2") = ._TRAMT * WrkMult
                  dr.Item("amt4") = ._TRAMT * WrkMult * -1
                Case Else
                  dr.Item("amt1") = ._TRAMT * WrkMult
                  dr.Item("amt4") = ._TRAMT * WrkMult * -1
              End Select
          End Select
          If ._SRCDE = 1 Then
            dr.Item("descr") = GetAPDescr(True)
            dr.Item("vennm") = GetAPVend(True)
            Select Case WrkAP
              Case "Desc"
                dr.Item("tdesc") = dr.Item("descr")
              Case "Vend"
                dr.Item("tdesc") = Trim(._TDESC)
            End Select
          Else
            dr.Item("tdesc") = Trim(._TDESC)
            dr.Item("descr") = ""
            dr.Item("vennm") = Trim(._TDESC)
          End If
          dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
          dr.Item("tdesc") = Mid(dr.Item("tdesc"), 1, cMaxTdesc)
          ds.Tables(0).Rows.Add(dr)
          If WrkFile <> String.Empty Then
            If WrkExportNormal Then
              sw.WriteLine(BuildNormal)
            Else
              sw.WriteLine(BuildPartial(WrkGltyp))
            End If
          End If

          'Expended Detail
          If Trim(._GLTYP) = "X" And ._TRTYP <> "B" Then
            dr = ds2.Tables(0).NewRow
            dr.Item("fund") = ._FDNBR
            dr.Item("funddesc") = GetFundDesc(._FDNBR)
            dr.Item("sfund") = ._SFUND
            dr.Item("dept") = ._DPNBR
            dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
            dr.Item("obj") = ._OBNBR
            dr.Item("func") = ._FNPGM
            dr.Item("sfunc") = ._SUBFN
            dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
            dr.Item("gltyp") = ._GLTYP
            dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
            dr.Item("refno") = ._REFNO
            dr.Item("srcde") = ._SRCDE
            dr.Item("source") = GetSourceDesc(._SRCDE)
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
            If ._SRCDE = 1 Then
              dr.Item("descr") = GetAPDescr(True)
              dr.Item("vennm") = GetAPVend(True)
              Select Case WrkAP
                Case "Desc"
                  dr.Item("tdesc") = dr.Item("descr")
                Case "Vend"
                  dr.Item("tdesc") = Trim(._TDESC)
              End Select
            Else
              dr.Item("tdesc") = Trim(._TDESC)
              dr.Item("descr") = ""
              dr.Item("vennm") = Mid(._TDESC, 1, cMaxTDesc)
            End If
            dr.Item("tdesc") = Mid(dr.Item("tdesc"), 1, cMaxTdesc)
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
    myLEDGERQ.CloseFile()
  End Sub
  Private Sub GetBegTramt()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkTramt As Decimal

    WrkTramt = 0

    With myLEDGERQ
      ds2 = myLEDGERL1.GetAllAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN, 0, WrkDateFrom - 1)
    End With

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        Select Case .Item("gltyp")
          Case "A", "L", "Q"
            If .Item("amtyp") = "D" Then
              WrkTramt = WrkTramt + .Item("tramt")
            Else
              WrkTramt = WrkTramt - .Item("tramt")
            End If
          Case Else
        End Select
      End With
    Next

    With myLEDGERQ
      If WrkTramt <> 0 Then
        dr = ds.Tables(0).NewRow
        dr.Item("fund") = ._FDNBR
        dr.Item("funddesc") = GetFundDesc(._FDNBR)
        dr.Item("sfund") = ._SFUND
        dr.Item("dept") = ._DPNBR
        dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
        dr.Item("obj") = ._OBNBR
        dr.Item("func") = ._FNPGM
        dr.Item("sfunc") = ._SUBFN
        dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr.Item("gltyp") = ._GLTYP
        dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
        dr.Item("refno") = 0
        dr.Item("srcde") = 0
        dr.Item("source") = ""
        dr.Item("begamt") = WrkTramt
        dr.Item("amt1") = 0
        dr.Item("amt2") = 0
        dr.Item("amt3") = WrkTramt
        dr.Item("amt4") = 0
        dr.Item("tdesc") = "Beginning Balance"
        dr.Item("dated") = MyUtils.GetDBDate(WrkDateFrom)
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
    myAPEHSTL1 = New APEHSTL1.MyData()
    myAPEHSTL1.MyDBConn = myDBConnect

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

    'added for departmnet security  5/12/26  ken
    WrkQry = WrkQry & WrkAnd & BuildDepSecQry(MyUserID)


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
        If SaveFund <> ._FDNBR Or SaveSfund <> ._SFUND Or SaveDept <> ._DPNBR Or SaveObj <> ._OBNBR _
      Or SaveFunc <> ._FNPGM Or SaveSfunc <> ._SUBFN Then
          GetBegTramtHst()
        End If
        SaveFund = ._FDNBR
        SaveSfund = ._SFUND
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
        dr = ds.Tables(0).NewRow
        dr.Item("fund") = ._FDNBR
        dr.Item("funddesc") = GetFundDesc(._FDNBR)
        dr.Item("sfund") = ._SFUND
        dr.Item("dept") = ._DPNBR
        dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
        dr.Item("obj") = ._OBNBR
        dr.Item("func") = ._FNPGM
        dr.Item("sfunc") = ._SUBFN
        dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr.Item("gltyp") = ._GLTYP
        dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
        dr.Item("refno") = ._REFNO
        dr.Item("srcde") = ._SRCDE
        dr.Item("source") = GetSourceDesc(._SRCDE)
        dr.Item("begamt") = 0
        dr.Item("amt1") = 0
        dr.Item("amt2") = 0
        dr.Item("amt3") = 0
        dr.Item("amt4") = 0
        Select Case ._GLTYP
          Case "A", "L", "Q"
            If ._AMTYP = "D" Then
              dr.Item("amt1") = ._TRAMT
            Else
              dr.Item("amt2") = ._TRAMT * -1
            End If
            dr.Item("amt3") = dr.Item("amt1") + dr.Item("amt2")
          Case "R"
            If ._AMTYP = "D" Then
              WrkMult = -1
            Else
              WrkMult = 1
            End If
            Select Case ._TRTYP
              Case "B"
                dr.Item("amt2") = ._TRAMT * WrkMult
                dr.Item("amt3") = ._TRAMT * WrkMult
              Case Else
                dr.Item("amt1") = ._TRAMT * WrkMult
                dr.Item("amt3") = ._TRAMT * WrkMult * -1
            End Select
          Case "X"
            If ._AMTYP = "D" Then
              WrkMult = 1
            Else
              WrkMult = -1
            End If
            Select Case ._TRTYP
              Case "B"
                dr.Item("amt3") = ._TRAMT * WrkMult
                dr.Item("amt4") = ._TRAMT * WrkMult
              Case "E"
                dr.Item("amt2") = ._TRAMT * WrkMult
                dr.Item("amt4") = ._TRAMT * WrkMult * -1
              Case Else
                dr.Item("amt1") = ._TRAMT * WrkMult
                dr.Item("amt4") = ._TRAMT * WrkMult * -1
            End Select
        End Select
        If ._SRCDE = 1 Then
          dr.Item("descr") = GetAPDescr(False)
          dr.Item("vennm") = GetAPVend(False)
          Select Case WrkAP
            Case "Desc"
              dr.Item("tdesc") = dr.Item("descr")
            Case "Vend"
              dr.Item("tdesc") = Trim(._TDESC)
          End Select
        Else
          dr.Item("tdesc") = Trim(._TDESC)
          dr.Item("descr") = Trim(._TDESC)
          dr.Item("vennm") = ""
        End If
        dr.Item("tdesc") = Mid(dr.Item("tdesc"), 1, cMaxTdesc)
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
        If Trim(._GLTYP) = "X" And ._TRTYP <> "B" Then
          dr = ds2.Tables(0).NewRow
          dr.Item("fund") = ._FDNBR
          dr.Item("funddesc") = GetFundDesc(._FDNBR)
          dr.Item("sfund") = ._SFUND
          dr.Item("dept") = ._DPNBR
          dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
          dr.Item("obj") = ._OBNBR
          dr.Item("func") = ._FNPGM
          dr.Item("sfunc") = ._SUBFN
          dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr.Item("gltyp") = ._GLTYP
          dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
          dr.Item("refno") = ._REFNO
          dr.Item("srcde") = ._SRCDE
          dr.Item("source") = GetSourceDesc(._SRCDE)
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
          If ._SRCDE = 1 Then
            dr.Item("descr") = GetAPDescr(False)
            dr.Item("vennm") = GetAPVend(False)
            Select Case WrkAP
              Case "Desc"
                dr.Item("tdesc") = dr.Item("descr")
              Case "Vend"
                dr.Item("tdesc") = Trim(._TDESC)
            End Select
          Else
            dr.Item("tdesc") = Trim(._TDESC)
            dr.Item("descr") = ""
            dr.Item("vennm") = Trim(._TDESC)
          End If
          dr.Item("tdesc") = Mid(dr.Item("tdesc"), 1, cMaxTdesc)
          dr.Item("dated") = MyUtils.GetDBDate(._PSTDT)
          ds2.Tables(0).Rows.Add(dr)
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
  Private Sub GetBegTramtHst()
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkTramt As Decimal

    WrkTramt = 0

    With myLEDHSTQ
      ds2 = myLEDHSTL1.GetAllAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN, 0, WrkDateFrom - 1)
    End With

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        Select Case .Item("gltyp")
          Case "A", "L", "Q"
            If .Item("amtyp") = "D" Then
              WrkTramt = WrkTramt + .Item("tramt")
            Else
              WrkTramt = WrkTramt - .Item("tramt")
            End If
          Case Else
        End Select
      End With
    Next

    With myLEDHSTQ
      If WrkTramt <> 0 Then
        dr = ds.Tables(0).NewRow
        dr.Item("fund") = ._FDNBR
        dr.Item("funddesc") = GetFundDesc(._FDNBR)
        dr.Item("sfund") = ._SFUND
        dr.Item("dept") = ._DPNBR
        dr.Item("deptdesc") = GetDeptDesc(._FDNBR, ._DPNBR)
        dr.Item("obj") = ._OBNBR
        dr.Item("func") = ._FNPGM
        dr.Item("sfunc") = ._SUBFN
        dr.Item("acctdesc") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr.Item("gltyp") = ._GLTYP
        dr.Item("gltypdesc") = GetGlTypDesc(._GLTYP, True)
        dr.Item("refno") = 0
        dr.Item("srcde") = 0
        dr.Item("source") = ""
        dr.Item("begamt") = WrkTramt
        dr.Item("amt1") = 0
        dr.Item("amt2") = 0
        dr.Item("amt3") = WrkTramt
        dr.Item("amt4") = 0
        dr.Item("tdesc") = "Beginning Balance"
        dr.Item("dated") = MyUtils.GetDBDate(WrkDateFrom)
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
      sb.Append("Source")
      sb.Append(",")
      sb.Append("Ref#")
      sb.Append(",")
      Select Case WrkGlType
        Case "A", "L", "Q"
          sb.Append("Debit")
          sb.Append(",")
          sb.Append("Credit")
          sb.Append(",")
          sb.Append("")
          sb.Append(",")
          sb.Append("Transactions")
        Case "R"
          sb.Append("Received")
          sb.Append(",")
          sb.Append("Budget")
          sb.Append(",")
          sb.Append("")
          sb.Append(",")
          sb.Append("Balance")
        Case "X"
          sb.Append("Expended")
          sb.Append(",")
          sb.Append("Encumbrance")
          sb.Append(",")
          sb.Append("Budget")
          sb.Append(",")
          sb.Append("Balance")
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
    sb.Append(Chr(34) & Replace(dr.Item("tdesc"), ",", "") & Chr(34)) 'Add double quotes/remove commas
    sb.Append(",")
    sb.Append(dr.Item("source"))
    sb.Append(",")
    sb.Append(dr.Item("refno"))
    sb.Append(",")
    sb.Append(dr.Item("amt1"))
    sb.Append(",")
    sb.Append(dr.Item("amt2"))
    Select Case dr.Item("gltyp")
      Case "A", "L", "Q"
        sb.Append(",")
        sb.Append(",")
        sb.Append(dr.Item("amt3"))
      Case "R"
        sb.Append(",")
        sb.Append(",")
        sb.Append(dr.Item("amt3"))
      Case "X"
        sb.Append(",")
        sb.Append(dr.Item("amt3"))
        sb.Append(",")
        sb.Append(dr.Item("amt4"))
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
    Select Case dr.Item("gltyp")
      Case "X"
        sb.Append(dr.Item("amt4"))
      Case Else
        sb.Append(dr.Item("amt3"))
    End Select
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function GetAPDescr(ByVal IsLedger As Boolean) As String
    Dim WrkDescr As String
    Dim SaveDescr As String
    WrkDescr = ""
    If IsLedger Then
      With myLEDGERQ
        WrkDescr = myAPEHSTL1.GetLedgerDescr(._INVNR, ._REFNO)
        SaveDescr = Trim(._TDESC)
      End With
    Else
      With myLEDHSTQ
        WrkDescr = myAPEHSTL1.GetLedgerDescr(._INVNR, ._REFNO)
        SaveDescr = Trim(._TDESC)
      End With
    End If
    If WrkDescr = "" Then
      WrkDescr = SaveDescr
    End If
    Return WrkDescr
  End Function
  Private Function GetAPVend(ByVal IsLedger As Boolean) As String
    Dim WrkVend As String
    WrkVend = ""
    If IsLedger Then
      With myLEDGERQ
        WrkVend = myAPEHSTL1.GetLedgerVend(._INVNR, ._REFNO)
      End With
    Else
      With myLEDHSTQ
        WrkVend = myAPEHSTL1.GetLedgerVend(._INVNR, ._REFNO)
      End With
    End If
    Return WrkVend
  End Function
  ' begin added 05/12/26 ken -  department security   
  Private Function BuildDepSecQry(ByVal UserId As String) As String

    Dim WrkUser As String

    WrkUser = Trim(UserId)

    Return " EXISTS (SELECT 1 FROM DEPSEC " &
           " WHERE RTRIM(USRPRF) = " & MyUtils.Quo(WrkUser) &
           " AND FUND = FDNBR " &
           " AND (DEPT = 0 OR DEPT = DPNBR)) "

  End Function
  ' end added 05/12/26 ken -  department security   
End Module
