Imports System.Text
Module PrintReportSU

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXSUPPQ As TXSUPPQ.MyData
  Dim myTXSUPAQ As TXSUPAQ.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim ds1 As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTotEx As DataSet = New DataSet
  Dim dsTotMC As DataSet = New DataSet
  Dim dsTotMC2 As DataSet = New DataSet
  Dim DsTXSUPP As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drErr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkFile As String
  Dim WrkPrintDist As Boolean
  Dim WrkNewOPM As Boolean
  Dim WrkBTR As Boolean
  Dim WrkMVPublic As Boolean

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer
  Dim WrkExLet(4) As String
  'Totals
  Dim WrkTValue As Decimal
  Dim WrkTPartial As Decimal
  Dim WrkTCredit As Decimal
  Dim WrkTExempt As Decimal
  Dim WrkTNet As Decimal
  Dim WrkTFull As Decimal
  Dim WrkTProrate As Decimal
  Dim WrkTFullCredit As Decimal
  Dim WrkTProrateCredit As Decimal
  Dim WrkTNumAccts As Integer
  Dim WrkTNumExempt As Integer
  Dim WrkTNumCredit As Integer
  Dim WrkTNumFull As Integer
  Dim WrkTNumProrate As Integer
  Dim WrkTNumFullCredit As Integer
  Dim WrkTNumProrateCredit As Integer
  'Buffered files
  Dim WrkSupCode(25) As String
  Dim WrkSupPct(25) As Decimal
  Dim WrkSupCredit(25) As Boolean
  'Report fields
  Dim RptExCode(4) As String
  Dim RptExam(4) As Integer
  'MC & Exemption Totals 
  Dim WrkTMCCode(100) As String
  Dim WrkTMCCount(100) As Integer
  Dim WrkTMCGross(100) As Long
  Dim WrkTMCExempt(100) As Long
  Dim WrkTMCNet(100) As Long
  Dim WrkTMC2Code(100) As String
  Dim WrkTMC2Count(100) As Integer
  Dim WrkTMC2Gross(100) As Long
  Dim WrkTMC2Exempt(100) As Long
  Dim WrkTMC2Net(100) As Long
  Dim WrkTExCode(100) As String
  Dim WrkTExCount(100) As Integer
  Dim WrkTExam(100) As Long

  Public Sub PrtReportSU()

    myTXSUPPQ = New TXSUPPQ.MyData(myDBConnect)
    myTXSUPAQ = New TXSUPAQ.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)

    With MyFrmTA212B
      WrkType = "S"
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkFile = .CboFile.SelectedItem.ToString
      WrkPrintDist = False
      If .ChkPrtDist.Checked Then
        WrkPrintDist = True
      End If
      WrkNewOPM = False
      If .ChkNewOPM.Checked Then
        WrkNewOPM = True
      End If
      WrkBTR = False
      If .ChkBAA.Checked Then
        WrkBTR = True
      End If
      WrkMVPublic = False
      If .ChkMVPublic.Checked Then
        WrkMVPublic = True
      End If
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
      BuildDSErr(dsErr)
      BuildDSTot(dsTot)
      BuildDSTotEx(dsTotEx)
      BuildDSTotMC(dsTotMC, dsTotMC2)
      BufferTXSupcd()
    Else
      ds1.Clear()
      ds2.Clear()
      dsErr.Clear()
      dsTot.Clear()
      dsTotEx.Clear()
      dsTotMC.Clear()
      dsTotMC2.Clear()
      ClearTotals()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    With MyCrViewer
      .Wrkds1 = ds1
      .Wrkds2 = ds2
      .WrkdsErr = dsErr
      .WrkdsTot = dsTot
      .WrkdsTotEx = dsTotEx
      .WrkdsTotMC = dsTotMC
      .WrkdsTotMC2 = dsTotMC2
      .WrkdsTotExempt = Nothing
      .WrkType = WrkType
      .WrkBTR = WrkBTR
      .Show()
    End With

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Dist", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("ExCd1", Type.GetType("System.String"))
      .Columns.Add("ExAmt1", Type.GetType("System.Int32"))
      .Columns.Add("ExCd2", Type.GetType("System.String"))
      .Columns.Add("ExAmt2", Type.GetType("System.Int32"))
      .Columns.Add("ExCd3", Type.GetType("System.String"))
      .Columns.Add("ExAmt3", Type.GetType("System.Int32"))
      .Columns.Add("ExCd4", Type.GetType("System.String"))
      .Columns.Add("ExAmt4", Type.GetType("System.Int32"))
      .Columns.Add("ExCd5", Type.GetType("System.String"))
      .Columns.Add("ExAmt5", Type.GetType("System.Int32"))
      .Columns.Add("Ass", Type.GetType("System.String"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("MvYear", Type.GetType("System.Int32"))
      .Columns.Add("Model", Type.GetType("System.String"))
      .Columns.Add("Body", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Class", Type.GetType("System.String"))
      .Columns.Add("Cylax", Type.GetType("System.Int32"))
      .Columns.Add("Pclr", Type.GetType("System.String"))
      .Columns.Add("Value", Type.GetType("System.Int32"))
      .Columns.Add("OValue", Type.GetType("System.Int32"))
      .Columns.Add("Prorate", Type.GetType("System.Int64"))
      .Columns.Add("Credit", Type.GetType("System.Int64"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("PrPct", Type.GetType("System.Decimal"))
      .Columns.Add("CrPct", Type.GetType("System.Decimal"))
      .Columns.Add("OList", Type.GetType("System.Int32"))
      .Columns.Add("OAss", Type.GetType("System.String"))
      .Columns.Add("OMake", Type.GetType("System.String"))
      .Columns.Add("OMvYear", Type.GetType("System.Int32"))
      .Columns.Add("OModel", Type.GetType("System.String"))
      .Columns.Add("ORegno", Type.GetType("System.String"))
      .Columns.Add("OVinno", Type.GetType("System.String"))
      .Columns.Add("OClass", Type.GetType("System.String"))
    End With
    ds1.Tables.Add(myTable)
    ds2 = ds1.Clone

  End Sub
  Private Sub ClearTotals()
    WrkTValue = 0
    WrkTPartial = 0
    WrkTCredit = 0
    WrkTExempt = 0
    WrkTNet = 0
    WrkTFull = 0
    WrkTProrate = 0
    WrkTFullCredit = 0
    WrkTProrateCredit = 0
    WrkTNumAccts = 0
    WrkTNumExempt = 0
    WrkTNumCredit = 0
    WrkTNumFull = 0
    WrkTNumProrate = 0
    WrkTNumFullCredit = 0
    WrkTNumProrateCredit = 0
    ReDim WrkTMCCode(100)
    ReDim WrkTMCCount(100)
    ReDim WrkTMCGross(100)
    ReDim WrkTMCExempt(100)
    ReDim WrkTMCNet(100)
    ReDim WrkTMC2Code(100)
    ReDim WrkTMC2Count(100)
    ReDim WrkTMC2Gross(100)
    ReDim WrkTMC2Exempt(100)
    ReDim WrkTMC2Net(100)
    ReDim WrkTExCode(100)
    ReDim WrkTExCount(100)
    ReDim WrkTExam(100)
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkTypeDesc As String
    Dim WrkTypeFamily As String
    Dim WrkQry As String
    Dim WrkExempt As Integer
    Dim WrkExemptProp As Boolean
    Dim WrkEx As Integer
    Dim WrkTotBTR As Decimal
    Dim WrkAssPct As Decimal
    Dim WrkAssErr As Boolean
    Dim WrkOassErr As Boolean
    Dim WrkCredit As Boolean
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer
    Dim L As Integer
    Dim WrkAnd As String

    If myDBConnect.ServerAS400 Then
      WrkAnd = " *and "
    Else
      WrkAnd = " and "
    End If

    'MK 9/23/25 Begin
    'WrkQry = ""
    WrkQry = "CAT<>'2'"
    'MK 9/23/25 End
    If Not WrkPrintDist Then
      'MK 9/23/25 Begin
      'WrkQry = "dist=" & WrkDist
      WrkQry = WrkQry & " and dist=" & WrkDist
      'MK 9/23/25 End
    Else
      'MK 9/23/25 Begin
      'WrkQry = "pdst=" & WrkDist
      WrkQry = WrkQry & " and pdst=" & WrkDist
      'MK 9/23/25 End
    End If

    'WrkQry = "List#=40057" 'Testing
    Select Case WrkFile
      Case "Regular"
        DsTXSUPP = myTXSUPPQ.GetQry("NAME, LIST#", WrkQry, 0)
      Case "Archive"
        If WrkQry = "" Then
          WrkQry = "TXYEAR=" & MyUtils.CnvSng(WrkYear)
        Else
          WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkYear)
        End If
        DsTXSUPP = myTXSUPAQ.GetQry("NAME, LIST#", WrkQry, 0)
    End Select
    If DsTXSUPP.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkTypeDesc = GetTXTypeDesc(WrkType)
    WrkTypeFamily = GetTXTypeFamily(WrkType)

    For I = 0 To (DsTXSUPP.Tables(0).Rows.Count - 1)
      With DsTXSUPP.Tables(0).Rows(I)
        If .Item("cat") = "T" Then GoTo NextRec
        If WrkPrintDist Then
          WrkDist = .Item("pdst")
        Else
          WrkDist = .Item("dist")
        End If
        If .Item("cat") <> "1" Then
          WrkExemptProp = True
          dr = ds2.Tables(0).NewRow
        Else
          WrkTNumAccts = WrkTNumAccts + 1
          WrkExemptProp = False
          dr = ds1.Tables(0).NewRow
        End If
        dr.Item("dist") = WrkDist
        dr.Item("listno") = .Item("list#")
        dr.Item("year") = WrkYear
        If WrkExemptProp Then
          dr.Item("typedesc") = "EXEMPT " & WrkTypeDesc
        Else
          dr.Item("typedesc") = WrkTypeDesc
        End If

        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        WrkExcd(0) = Trim(.Item("excd1"))
        WrkExcd(1) = Trim(.Item("excd2"))
        WrkExcd(2) = Trim(.Item("excd3"))
        WrkExcd(3) = Trim(.Item("excd4"))
        WrkExcd(4) = Trim(.Item("excd5"))
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")

        'Combine Exemptions into Letter groups
        Array.Clear(RptExCode, 0, 5)
        Array.Clear(RptExam, 0, 5)
        WrkExempt = 0
        If Not WrkExemptProp Then
          For J = 0 To 4
            WrkEx = 0
            If WrkExcd(J) <> "" Then
              K = LookupExem(WrkExcd(J))
              'Check for Invalid exemptions
              If K = -1 Then
                drErr = dsErr.Tables(0).NewRow
                drErr.Item("listno") = .Item("list#")
                drErr.Item("addr1") = AddrLine(0)
                drErr.Item("gross") = 0
                drErr.Item("exempt") = 0
                drErr.Item("net") = 0
                drErr.Item("errmsg") = "Invalid Exemption Code - " & WrkExcd(J)
                dsErr.Tables(0).Rows.Add(drErr)
              End If
              If WrkExam(J) = 0 And K >= 0 Then
                WrkExempt = WrkExempt + WrkExFixedAmt(K)
                WrkEx = WrkExFixedAmt(K)
              Else
                WrkExempt = WrkExempt + WrkExam(J)
                WrkEx = WrkExam(J)
              End If
              If WrkNewOPM Then
                If K >= 0 Then
                  L = LookupRptExCode(WrkExLetter(K))
                  RptExCode(L) = WrkExLetter(K)
                  RptExam(L) = RptExam(L) + WrkEx
                End If
              Else
                L = LookupRptExCode(WrkExcd(J))
                RptExCode(L) = WrkExcd(J)
                RptExam(L) = RptExam(L) + WrkEx
              End If
            End If
            'Check for Missing exemptions
            If WrkExcd(J) <> "" And WrkExam(J) = 0 Or WrkExcd(J) = "" And WrkExam(J) > 0 Then
              drErr = dsErr.Tables(0).NewRow
              drErr.Item("listno") = .Item("list#")
              drErr.Item("addr1") = AddrLine(0)
              drErr.Item("gross") = 0
              drErr.Item("exempt") = WrkExam(J)
              drErr.Item("net") = 0
              drErr.Item("errmsg") = "Invalid Exemption"
              dsErr.Tables(0).Rows.Add(drErr)
            End If
          Next
        End If

        'Add Exemption groups
        For J = 0 To 4
          If Not IsNothing(RptExCode(J)) Then
            K = LookupWrkTExCode(RptExCode(J))
            WrkTExCode(K) = RptExCode(J)
            WrkTExCount(K) = WrkTExCount(K) + 1
            WrkTExam(K) = WrkTExam(K) + RptExam(J)
          End If
        Next J

        dr.Item("value") = .Item("value")
        dr.Item("exempt") = WrkExempt
        WrkTotBTR = 0
        If WrkBTR And .Item("btr") <> 0 Then
          If WrkFile = "Regular" Then
            myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTR.RecordNotFound Then
              With myTXBTR
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
                dr.Item("value") = dr.Item("value") + WrkTotBTR
              End With
            End If
          End If
        End If

        dr.Item("excd1") = RptExCode(0)
        dr.Item("examt1") = RptExam(0)
        dr.Item("excd2") = RptExCode(1)
        dr.Item("examt2") = RptExam(1)
        dr.Item("excd3") = RptExCode(2)
        dr.Item("examt3") = RptExam(2)
        dr.Item("excd4") = RptExCode(3)
        dr.Item("examt4") = RptExam(3)
        dr.Item("excd5") = RptExCode(4)
        dr.Item("examt5") = RptExam(4)

        dr.Item("make") = .Item("make")
        dr.Item("mvyear") = .Item("year")
        dr.Item("model") = .Item("model")
        dr.Item("body") = .Item("body")
        If WrkMVPublic Then
          dr.Item("regno") = .Item("regno")
        Else
          dr.Item("regno") = String.Empty
        End If
        dr.Item("vinno") = .Item("vinno")
        dr.Item("class") = Format(.Item("class"), "00")
        dr.Item("cylax") = .Item("cylax")
        dr.Item("pclr") = .Item("pclr")
        dr.Item("ovalue") = .Item("oval")
        dr.Item("ass") = .Item("ass")
        WrkAssErr = False
        WrkAssPct = CalcPct(.Item("ass"))
        If WrkAssPct > 0 Then
          dr.Item("prpct") = WrkAssPct
          dr.Item("prorate") = CalcAssmt(.Item("value"), WrkAssPct)
        Else
          dr.Item("prpct") = 0
          dr.Item("prorate") = 0
          WrkAssErr = True
        End If
        WrkOassErr = False
        dr.Item("crpct") = 0
        dr.Item("credit") = 0
        If Trim(.Item("oass")) <> "" Then
          WrkAssPct = CalcPct(.Item("oass"))
          If WrkAssPct > 0 Then
            dr.Item("crpct") = WrkAssPct
            dr.Item("credit") = CalcAssmt(.Item("oval"), WrkAssPct)
          Else
            WrkOassErr = True
          End If
        End If
        If dr.Item("credit") > dr.Item("prorate") Then
          dr.Item("credit") = dr.Item("prorate")
        End If
        dr.Item("net") = dr.Item("prorate") - dr.Item("credit") - dr.Item("exempt")
        dr.Item("olist") = .Item("olist")
        dr.Item("oass") = .Item("oass")
        dr.Item("omake") = .Item("omake")
        dr.Item("omvyear") = .Item("oyear")
        dr.Item("omodel") = .Item("omod")
        If WrkMVPublic Then
          dr.Item("oregno") = .Item("oreg#")
        Else
          dr.Item("oregno") = String.Empty
        End If
        dr.Item("ovinno") = .Item("ovin")
        dr.Item("oclass") = Format(.Item("ocls"), "00")

        If WrkExemptProp Then
          ds2.Tables(0).Rows.Add(dr)
        Else
          WrkTValue = WrkTValue + dr.Item("value")
          WrkTPartial = WrkTPartial + dr.Item("prorate")
          WrkTCredit = WrkTCredit + dr.Item("credit")
          WrkTExempt = WrkTExempt + dr.Item("exempt")
          If dr.Item("exempt") > 0 Then
            WrkTNumExempt = WrkTNumExempt + 1
          End If
          WrkTNet = WrkTNet + dr.Item("net")
          If dr.Item("prpct") = 1 Then
            WrkTNumFull = WrkTNumFull + 1
            WrkTFull = WrkTFull + dr.Item("value")
          Else
            WrkTNumProrate = WrkTNumProrate + 1
            WrkTProrate = WrkTProrate + dr.Item("value")
          End If
          If dr.Item("credit") > 0 Then
            WrkTNumCredit = WrkTNumCredit + 1
            If dr.Item("crpct") = 1 Then
              WrkTNumFullCredit = WrkTNumFullCredit + 1
              WrkTFullCredit = WrkTFullCredit + dr.Item("credit")
            Else
              WrkTNumProrateCredit = WrkTNumProrateCredit + 1
              WrkTProrateCredit = WrkTProrateCredit + dr.Item("credit")
            End If
          End If
          ds1.Tables(0).Rows.Add(dr)
        End If

        'Add OPM groups to totals
        If Not WrkExemptProp Then
          K = LookupWrkTMCCode(Format(.Item("class"), "00"))
          WrkTMCCode(K) = Format(.Item("class"), "00")
          WrkTMCCount(K) = WrkTMCCount(K) + 1
          WrkTMCGross(K) = WrkTMCGross(K) + dr.Item("value")
          WrkTMCExempt(K) = WrkTMCExempt(K) + dr.Item("exempt")
          WrkTMCNet(K) = WrkTMCNet(K) + dr.Item("value") - dr.Item("exempt")
        Else
          K = LookupWrkTMC2Code(Format(.Item("class"), "00"))
          WrkTMC2Code(K) = Format(.Item("class"), "00")
          WrkTMC2Count(K) = WrkTMC2Count(K) + 1
          WrkTMC2Gross(K) = WrkTMC2Gross(K) + dr.Item("value")
          WrkTMC2Exempt(K) = WrkTMC2Exempt(K) + dr.Item("exempt")
          WrkTMC2Net(K) = WrkTMC2Net(K) + dr.Item("value") - dr.Item("exempt")
        End If

        'Check for Invalid Category
        If .Item("cat") <> "1" And .Item("cat") <> "3" And .Item("cat") <> "T" Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value")
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") - WrkExempt
          drErr.Item("errmsg") = "Tax Category is invalid"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for Transfer
        If .Item("cat") = "T" Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") + WrkTotBTR - WrkExempt
          drErr.Item("errmsg") = "Transfer"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If dr.Item("net") < 0 Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value")
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = dr.Item("net")
          drErr.Item("errmsg") = "Net is negative"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If .Item("ccno") = 0 And .Item("value") + WrkTotBTR <= 0 Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") + WrkTotBTR - WrkExempt
          drErr.Item("errmsg") = "Gross is zero"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If .Item("ccno") > 0 And (.Item("ccgrs") - .Item("ccex")) = 0 Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("ccgrs") - .Item("ccex")
          drErr.Item("errmsg") = "C/C Gross is zero"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If WrkAssErr Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value")
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") - WrkExempt
          drErr.Item("errmsg") = "Invalid Assmnt Code"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If WrkOassErr Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value")
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") - WrkExempt
          drErr.Item("errmsg") = "Invalid Credit Assmnt Code"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        WrkCredit = CalcIsCredit(.Item("ass"))
        If WrkCredit And Trim(.Item("oass")) = "" Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value")
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") - WrkExempt
          drErr.Item("errmsg") = "Credit Vehicle is required for Assmnt Code"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        If Not WrkCredit And Trim(.Item("oass")) <> "" Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("value")
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("value") - WrkExempt
          drErr.Item("errmsg") = "Credit Vehicle is not allowed for Assmnt Code"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXSUPP.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
          Application.DoEvents()
        End If
      End With
    Next

    'Totals
    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Gross Assessment"
    dr.Item("totcount") = WrkTNumAccts
    dr.Item("totamount") = WrkTValue
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Partial Assessment"
    dr.Item("totcount") = WrkTNumAccts
    dr.Item("totamount") = WrkTPartial
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Credits"
    dr.Item("totcount") = WrkTNumCredit
    dr.Item("totamount") = WrkTCredit
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Exemptions"
    dr.Item("totcount") = WrkTNumExempt
    dr.Item("totamount") = WrkTExempt
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Net Assessment"
    dr.Item("totcount") = WrkTNumAccts
    dr.Item("totamount") = WrkTNet
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Full Assessment"
    dr.Item("totcount") = WrkTNumFull
    dr.Item("totamount") = WrkTFull
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Pro-Rated Assessment"
    dr.Item("totcount") = WrkTNumProrate
    dr.Item("totamount") = WrkTProrate
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Full Credit"
    dr.Item("totcount") = WrkTNumFullCredit
    dr.Item("totamount") = WrkTFullCredit
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Pro-Rated Credit"
    dr.Item("totcount") = WrkTNumProrateCredit
    dr.Item("totamount") = WrkTProrateCredit
    dsTot.Tables(0).Rows.Add(dr)

    For I = 0 To 100
      If IsNothing(WrkTMCCode(I)) Then Exit For
      dr = dsTotMC.Tables(0).NewRow
      dr.Item("tmcformat") = "C"
      dr.Item("tmccode") = WrkTMCCode(I)
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), "M")
      dr.Item("tmccount") = WrkTMCCount(I)
      dr.Item("tmcgross") = WrkTMCGross(I)
      dr.Item("tmcexempt") = WrkTMCExempt(I)
      dr.Item("tmcnet") = WrkTMCNet(I)
      dsTotMC.Tables(0).Rows.Add(dr)
    Next I

    For I = 0 To 100
      If IsNothing(WrkTMC2Code(I)) Then Exit For
      dr = dsTotMC2.Tables(0).NewRow
      dr.Item("tmcformat") = "C"
      dr.Item("tmccode") = WrkTMC2Code(I)
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMC2Code(I), "M")
      dr.Item("tmccount") = WrkTMC2Count(I)
      dr.Item("tmcgross") = WrkTMC2Gross(I)
      dr.Item("tmcexempt") = WrkTMC2Exempt(I)
      dr.Item("tmcnet") = WrkTMC2Net(I)
      dsTotMC2.Tables(0).Rows.Add(dr)
    Next I

    For I = 0 To 100
      If IsNothing(WrkTExCode(I)) Then Exit For
      dr = dsTotEx.Tables(0).NewRow
      dr.Item("texformat") = "B"
      dr.Item("texcode") = WrkTExCode(I)
      K = LookupExem(WrkTExCode(I))
      If K >= 0 Then
        dr.Item("texdesc") = WrkExDesc(K)
      Else
        If WrkTExCode(I) = "*" Then
          dr.Item("texdesc") = "LOCAL EXEMPTIONS"
        Else
          dr.Item("texdesc") = "*** Invalid OPM Group ***"
        End If
      End If
      dr.Item("texcount") = WrkTExCount(I)
      dr.Item("tex") = WrkTExam(I)
      dsTotEx.Tables(0).Rows.Add(dr)
    Next I

    myFrmProgress.Close()
    myTXSUPPQ.CloseFile()
    myTXSUPAQ.CloseFile()
  End Sub
  Public Function CalcPct(ByVal AssCd As String) As Decimal
    Dim K As Integer
    Dim WrkPct As Decimal

    K = LookupTxSupcd(AssCd)
    If K >= 0 Then
      WrkPct = WrkSupPct(K)
    Else
      WrkPct = -1
    End If
    Return WrkPct
  End Function
  Public Function CalcIsCredit(ByVal AssCd As String) As Boolean
    Dim K As Integer
    Dim WrkResult As Boolean

    K = LookupTxSupcd(AssCd)
    If K >= 0 Then
      WrkResult = WrkSupCredit(K)
    Else
      WrkResult = False
    End If
    Return WrkResult
  End Function
  Public Function CalcAssmt(ByVal Value As Integer, ByVal Pct As Decimal) As Integer
    Dim WrkProRate As Integer

    WrkProRate = MyUtils.Round(Value * Pct, 0)
    Return WrkProRate
  End Function
  Private Sub BufferTXSupcd()
    Dim I As Integer

    Dim myTXSUPCD As TXSUPCD.MyData
    Dim dsTXSupcd As DataSet = New DataSet

    myTXSUPCD = New TXSUPCD.MyData(myDBConnect)

    dsTXSupcd = myTXSUPCD.GetAllData
    For I = 0 To dsTXSupcd.Tables(0).Rows.Count - 1
      With dsTXSupcd.Tables(0).Rows(I)
        WrkSupCode(I) = .Item("scod")
        WrkSupPct(I) = .Item("spct")
        If .Item("scrd") = "Y" Then
          WrkSupCredit(I) = True
        Else
          WrkSupCredit(I) = False
        End If
      End With
    Next

  End Sub
  Private Function LookupTxSupcd(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkSupCode.GetUpperBound(0)
      If Trim(WrkSupCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkSupCode(I)) Then
        Return I
      End If
    Next
    Return -1

  End Function
  Private Function LookupRptExCode(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To RptExCode.GetUpperBound(0)
      If Trim(RptExCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(RptExCode(I)) Then
        Return I
      End If
    Next

    Return -1
  End Function
  Private Function LookupWrkTMCCode(ByVal Code As Integer) As Integer
    Dim I As Integer

    For I = 0 To WrkTMCCode.GetUpperBound(0)
      If WrkTMCCode(I) = "" Then
        Return I
      End If
      If Code = WrkTMCCode(I) Then
        Return I
      End If
    Next
    Return -1
  End Function
  Private Function LookupWrkTMC2Code(ByVal Code As Integer) As Integer
    Dim I As Integer

    For I = 0 To WrkTMC2Code.GetUpperBound(0)
      If WrkTMC2Code(I) = "" Then
        Return I
      End If
      If Code = WrkTMC2Code(I) Then
        Return I
      End If
    Next
    Return -1

  End Function
  Private Function LookupWrkTExCode(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkTExCode.GetUpperBound(0)
      If Trim(WrkTExCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkTExCode(I)) Then
        Return I
      End If
    Next
    Return -1

  End Function
End Module






