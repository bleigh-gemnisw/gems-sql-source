Imports System.Text
Module PrintReportPP

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXPPRPQ As TXPPRPQ.MyData
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim myTXPPRAQ As TXPPRAQ.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim ds1 As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dsTotEx As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTotMC As DataSet = New DataSet
  Dim dsTotMC2 As DataSet = New DataSet
  Dim DsTXPPRP As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drErr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkNewOPM As Boolean
  Dim WrkFile As String
  Dim WrkBTR As Boolean
  Dim WrkAddendum As Boolean

  Dim WrkExcd(4) As String
  Dim WrkExam(4) As Integer
  'Totals
  Dim WrkTGross As Long
  Dim WrkTExempt As Long
  Dim WrkTNet As Long
  Dim WrkTCCGross As Long
  Dim WrkTCCExempt As Long
  Dim WrkTCCNet As Long
  Dim WrkTNumAccts As Integer
  'Buffered files
  Dim WrkCode(100) As Integer
  Dim WrkDesc(100) As String
  'Report fields
  Dim RptCode(9) As String
  Dim RptDesc(9) As String
  Dim RptGross(9) As Integer
  Dim RptExCode(4) As String
  Dim RptExam(4) As Integer
  'MC & Exemption Totals 
  Dim WrkTMCCode(100) As String
  Dim WrkTMCCount(100) As Integer
  Dim WrkTMCGross(100) As Long
  Dim WrkTMC2Code(100) As String
  Dim WrkTMC2Count(100) As Integer
  Dim WrkTMC2Gross(100) As Long
  Dim WrkTExCode(100) As String
  Dim WrkTExCount(100) As Integer
  Dim WrkTExam(100) As Long

  Public Sub PrtReportPP()

    myTXPPRPQ = New TXPPRPQ.MyData(myDBConnect)
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)
    myTXPPRAQ = New TXPPRAQ.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)

    With MyFrmTA212B
      WrkType = "P"
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
      WrkAddendum = False
      If .ChkAddendum.Checked Then
        WrkAddendum = True
      End If
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
      BuildDSErr(dsErr)
      BuildDSTot(dsTot)
      BuildDSTotEx(dsTotEx)
      BuildDSTotMC(dsTotMC, dsTotMC2)
      BufferCodes()
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
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int64"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("AssCd1", Type.GetType("System.String"))
      .Columns.Add("AssDesc1", Type.GetType("System.String"))
      .Columns.Add("AssAmt1", Type.GetType("System.Int32"))
      .Columns.Add("AssCd2", Type.GetType("System.String"))
      .Columns.Add("AssDesc2", Type.GetType("System.String"))
      .Columns.Add("AssAmt2", Type.GetType("System.Int32"))
      .Columns.Add("AssCd3", Type.GetType("System.String"))
      .Columns.Add("AssDesc3", Type.GetType("System.String"))
      .Columns.Add("AssAmt3", Type.GetType("System.Int32"))
      .Columns.Add("AssCd4", Type.GetType("System.String"))
      .Columns.Add("AssDesc4", Type.GetType("System.String"))
      .Columns.Add("AssAmt4", Type.GetType("System.Int32"))
      .Columns.Add("AssCd5", Type.GetType("System.String"))
      .Columns.Add("AssDesc5", Type.GetType("System.String"))
      .Columns.Add("AssAmt5", Type.GetType("System.Int32"))
      .Columns.Add("AssCd6", Type.GetType("System.String"))
      .Columns.Add("AssDesc6", Type.GetType("System.String"))
      .Columns.Add("AssAmt6", Type.GetType("System.Int32"))
      .Columns.Add("AssCd7", Type.GetType("System.String"))
      .Columns.Add("AssDesc7", Type.GetType("System.String"))
      .Columns.Add("AssAmt7", Type.GetType("System.Int32"))
      .Columns.Add("AssCd8", Type.GetType("System.String"))
      .Columns.Add("AssDesc8", Type.GetType("System.String"))
      .Columns.Add("AssAmt8", Type.GetType("System.Int32"))
      .Columns.Add("AssCd9", Type.GetType("System.String"))
      .Columns.Add("AssDesc9", Type.GetType("System.String"))
      .Columns.Add("AssAmt9", Type.GetType("System.Int32"))
      .Columns.Add("AssCdA", Type.GetType("System.String"))
      .Columns.Add("AssDescA", Type.GetType("System.String"))
      .Columns.Add("AssAmtA", Type.GetType("System.Int32"))
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
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
      .Columns.Add("CCGrs", Type.GetType("System.Int32"))
      .Columns.Add("CCEx", Type.GetType("System.Int32"))
      .Columns.Add("CCNet", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)
    ds2 = ds1.Clone

  End Sub
  Private Sub ClearTotals()
    WrkTGross = 0
    WrkTExempt = 0
    WrkTNet = 0
    WrkTCCGross = 0
    WrkTCCExempt = 0
    WrkTCCNet = 0
    WrkTNumAccts = 0
    ReDim WrkTMCCode(100)
    ReDim WrkTMCCount(100)
    ReDim WrkTMCGross(100)
    ReDim WrkTMC2Code(100)
    ReDim WrkTMC2Count(100)
    ReDim WrkTMC2Gross(100)
    ReDim WrkTExCode(100)
    ReDim WrkTExCount(100)
    ReDim WrkTExam(100)
  End Sub
  Private Sub GetDetail()
    Dim AddrLine() As String
    Dim WrkTypeDesc As String
    Dim WrkTypeFamily As String
    Dim WrkQry As String
    Dim WrkAssCode(9) As Integer
    Dim WrkGross(9) As Integer
    Dim WrkGrossXFoot As Integer
    Dim WrkUnit(9) As Integer
    Dim WrkExempt As Integer
    Dim WrkExemptProp As Boolean
    Dim WrkEx As Integer
    Dim WrkTotBTR As Decimal
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

    WrkQry = ""
    If Not WrkDistAll Then
      If Not WrkPrintDist Then
        WrkQry = "dist=" & WrkDist
      Else
        WrkQry = "pdst=" & WrkDist
      End If
    End If
    Select Case WrkFile
      Case "Regular"
        DsTXPPRP = myTXPPRPQ.GetQry("NAME, LIST#", WrkQry, 0)
      Case "Frozen"
        DsTXPPRP = myTXPPRPCQ.GetQry("NAME, LIST#", WrkQry, 0)
      Case "Archive"
        If WrkQry = "" Then
          WrkQry = "TXYEAR=" & MyUtils.CnvSng(WrkYear)
        Else
          WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkYear)
        End If
        DsTXPPRP = myTXPPRAQ.GetQry("NAME, LIST#", WrkQry, 0)
    End Select
    If DsTXPPRP.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

    WrkTypeDesc = GetTXTypeDesc(WrkType)
    WrkTypeFamily = GetTXTypeFamily(WrkType)

    For I = 0 To (DsTXPPRP.Tables(0).Rows.Count - 1)
      With DsTXPPRP.Tables(0).Rows(I)
        If WrkAddendum Then
          If .Item("ccno") = 0 Then
            GoTo NextRec
          End If
        End If
        If WrkPrintDist Then
          WrkDist = .Item("pdst")
        Else
          WrkDist = .Item("dist")
        End If
        WrkTNumAccts = WrkTNumAccts + 1
        If .Item("cat") <> "5" Then
          WrkExemptProp = True
          dr = ds2.Tables(0).NewRow
        Else
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
        dr.Item("location") = Trim(.Item("loc#")) & " " & .Item("loc")
        WrkAssCode(0) = .Item("code1")
        WrkAssCode(1) = .Item("code2")
        WrkAssCode(2) = .Item("code3")
        WrkAssCode(3) = .Item("code4")
        WrkAssCode(4) = .Item("code5")
        WrkAssCode(5) = .Item("code6")
        WrkAssCode(6) = .Item("code7")
        WrkAssCode(7) = .Item("code8")
        WrkAssCode(8) = .Item("code9")
        WrkAssCode(9) = .Item("codea")
        WrkGross(0) = .Item("ass1")
        WrkGross(1) = .Item("ass2")
        WrkGross(2) = .Item("ass3")
        WrkGross(3) = .Item("ass4")
        WrkGross(4) = .Item("ass5")
        WrkGross(5) = .Item("ass6")
        WrkGross(6) = .Item("ass7")
        WrkGross(7) = .Item("ass8")
        WrkGross(8) = .Item("ass9")
        WrkGross(9) = .Item("ass10")
        WrkTotBTR = 0
        If WrkBTR And .Item("btr") <> 0 Then
          If WrkFile = "Regular" Then
            myTXBTR.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTR.RecordNotFound Then
              With myTXBTR
                WrkGross(0) = WrkGross(0) + ._BASS1
                WrkGross(1) = WrkGross(1) + ._BASS2
                WrkGross(2) = WrkGross(2) + ._BASS3
                WrkGross(3) = WrkGross(3) + ._BASS4
                WrkGross(4) = WrkGross(4) + ._BASS5
                WrkGross(5) = WrkGross(5) + ._BASS6
                WrkGross(6) = WrkGross(6) + ._BASS7
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
              End With
            End If
          End If
          If WrkFile = "Frozen" Then
            myTXBTRC.GetOneRecordP(.Item("list#"), WrkType)
            If Not myTXBTRC.RecordNotFound Then
              With myTXBTRC
                WrkGross(0) = WrkGross(0) + ._BASS1
                WrkGross(1) = WrkGross(1) + ._BASS2
                WrkGross(2) = WrkGross(2) + ._BASS3
                WrkGross(3) = WrkGross(3) + ._BASS4
                WrkGross(4) = WrkGross(4) + ._BASS5
                WrkGross(5) = WrkGross(5) + ._BASS6
                WrkGross(6) = WrkGross(6) + ._BASS7
                WrkTotBTR = ._BASS1 + ._BASS2 + ._BASS3 + ._BASS4 + ._BASS5 + ._BASS6 + ._BASS7
              End With
            End If
          End If
        End If

        WrkUnit(0) = .Item("unit1")
        WrkUnit(1) = .Item("unit2")
        WrkUnit(2) = .Item("unit3")
        WrkUnit(3) = .Item("unit4")
        WrkUnit(4) = .Item("unit5")
        WrkUnit(5) = .Item("unit6")
        WrkUnit(6) = .Item("unit7")
        WrkUnit(7) = .Item("unit8")
        WrkUnit(8) = .Item("unit9")
        WrkUnit(9) = .Item("unita")
        WrkExcd(0) = .Item("excd1")
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

        'Combine Gross into OPM groups
        Array.Clear(RptCode, 0, 10)
        Array.Clear(RptDesc, 0, 10)
        Array.Clear(RptGross, 0, 10)
        WrkGrossXFoot = 0
        For J = 0 To 9
          WrkGrossXFoot = WrkGrossXFoot + WrkGross(J)
          If WrkAssCode(J) > 0 Then
            K = LookupRptCode(Format(WrkAssCode(J), "000"))
            RptCode(K) = Format(WrkAssCode(J), "000")
            RptDesc(K) = LookupOPMCode(WrkAssCode(J))
            RptGross(K) = RptGross(K) + WrkGross(J)
            'Check for Invalid Assessment Codes
            If RptDesc(K) = String.Empty Then
              drErr = dsErr.Tables(0).NewRow
              drErr.Item("listno") = .Item("list#")
              drErr.Item("addr1") = AddrLine(0)
              drErr.Item("gross") = WrkGross(J)
              drErr.Item("exempt") = 0
              drErr.Item("net") = 0
              drErr.Item("errmsg") = "Invalid Assmnt Code " & WrkAssCode(J)
              dsErr.Tables(0).Rows.Add(drErr)
            End If
          Else
            'Check for Missing Assessment Codes
            If WrkGross(J) > 0 Then
              drErr = dsErr.Tables(0).NewRow
              drErr.Item("listno") = .Item("list#")
              drErr.Item("addr1") = AddrLine(0)
              drErr.Item("gross") = WrkGross(J)
              drErr.Item("exempt") = 0
              drErr.Item("net") = 0
              drErr.Item("errmsg") = "Missing Assmnt Code"
              dsErr.Tables(0).Rows.Add(drErr)
            End If
          End If
        Next J

        'Add OPM groups to totals
        If Not WrkExemptProp Then
          For J = 0 To 9
            If Not IsNothing(RptCode(J)) Then
              K = LookupWrkTMCCode(RptCode(J))
              WrkTMCCode(K) = RptCode(J)
              WrkTMCCount(K) = WrkTMCCount(K) + 1
              WrkTMCGross(K) = WrkTMCGross(K) + RptGross(J)
            End If
          Next J
        Else
          For J = 0 To 9
            If Not IsNothing(RptCode(J)) Then
              K = LookupWrkTMC2Code(RptCode(J))
              WrkTMC2Code(K) = RptCode(J)
              WrkTMC2Count(K) = WrkTMC2Count(K) + 1
              WrkTMC2Gross(K) = WrkTMC2Gross(K) + RptGross(J)
            End If
          Next J
        End If

        dr.Item("asscd1") = RptCode(0)
        dr.Item("assdesc1") = RptDesc(0)
        dr.Item("assamt1") = RptGross(0)
        dr.Item("asscd2") = RptCode(1)
        dr.Item("assdesc2") = RptDesc(1)
        dr.Item("assamt2") = RptGross(1)
        dr.Item("asscd3") = RptCode(2)
        dr.Item("assdesc3") = RptDesc(2)
        dr.Item("assamt3") = RptGross(2)
        dr.Item("asscd4") = RptCode(3)
        dr.Item("assdesc4") = RptDesc(3)
        dr.Item("assamt4") = RptGross(3)
        dr.Item("asscd5") = RptCode(4)
        dr.Item("assdesc5") = RptDesc(4)
        dr.Item("assamt5") = RptGross(4)
        dr.Item("asscd6") = RptCode(5)
        dr.Item("assdesc6") = RptDesc(5)
        dr.Item("assamt6") = RptGross(5)
        dr.Item("asscd7") = RptCode(6)
        dr.Item("assdesc7") = RptDesc(6)
        dr.Item("assamt7") = RptGross(6)
        dr.Item("asscd8") = RptCode(7)
        dr.Item("assdesc8") = RptDesc(7)
        dr.Item("assamt8") = RptGross(7)
        dr.Item("asscd9") = RptCode(8)
        dr.Item("assdesc9") = RptDesc(8)
        dr.Item("assamt9") = RptGross(8)
        dr.Item("asscda") = RptCode(9)
        dr.Item("assdesca") = RptDesc(9)
        dr.Item("assamta") = RptGross(9)

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
              drErr.Item("errmsg") = "invalid Exemption"
              dsErr.Tables(0).Rows.Add(drErr)
            End If
          Next
        End If
        'Add Exemption Letter groups
        For J = 0 To 4
          If Not IsNothing(RptExCode(J)) Then
            K = LookupWrkTExCode(RptExCode(J))
            WrkTExCode(K) = RptExCode(J)
            WrkTExCount(K) = WrkTExCount(K) + 1
            WrkTExam(K) = WrkTExam(K) + RptExam(J)
          End If
        Next J

        dr.Item("gross") = .Item("gross") + WrkTotBTR
        dr.Item("exempt") = WrkExempt
        dr.Item("net") = .Item("net") + WrkTotBTR
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

        If WrkAddendum And .Item("ccno") > 0 Then
          dr.Item("ccno") = .Item("ccno")
          dr.Item("ccdate") = MyUtils.GetDBDate(.Item("cdate"))
          dr.Item("ccgrs") = .Item("ccgrs")
          dr.Item("ccex") = .Item("ccex")
          dr.Item("ccnet") = .Item("ccgrs") - .Item("ccex")
          WrkTCCGross = WrkTCCGross + .Item("ccgrs")
          WrkTCCExempt = WrkTCCExempt + .Item("ccex")
          WrkTCCNet = WrkTCCNet + .Item("ccgrs") - .Item("ccex")
        End If

        If WrkExemptProp Then
          ds2.Tables(0).Rows.Add(dr)
        Else
          WrkTGross = WrkTGross + dr.Item("gross")
          WrkTExempt = WrkTExempt + WrkExempt
          WrkTNet = WrkTNet + dr.Item("net")
          ds1.Tables(0).Rows.Add(dr)
        End If

        'Check for Invalid Category
        If .Item("cat") <> "5" And .Item("cat") <> "3" Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "Tax Category is invalid"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for Negative Net
        If .Item("gross") + WrkTotBTR - WrkExempt < 0 Or .Item("net") < 0 Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "Net is negative"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for Gross-exemptions<>Net 
        If .Item("gross") - WrkExempt <> .Item("net") Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "Net doesn't cross foot"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for Gross<>assessment buckets 
        If .Item("gross") + WrkTotBTR <> WrkGrossXFoot Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "Gross don't match assmnts"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for BTR<>TotBTR 
        If .Item("btr") <> WrkTotBTR Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = .Item("list#")
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "BTR amount don't match BTR File"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
      End With

NextRec:
      With myFrmProgress
        WrkPct = ((I + 1) / DsTXPPRP.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
        End If
      End With
    Next

    'Totals
    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Gross Assessment"
    dr.Item("totcount") = WrkTNumAccts
    dr.Item("totamount") = WrkTGross
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Exemptions"
    dr.Item("totcount") = 0
    dr.Item("totamount") = WrkTExempt
    dsTot.Tables(0).Rows.Add(dr)

    dr = dsTot.Tables(0).NewRow
    dr.Item("totdesc") = "Total Net Assessment"
    dr.Item("totcount") = WrkTNumAccts
    dr.Item("totamount") = WrkTNet
    dsTot.Tables(0).Rows.Add(dr)

    'After C/C Totals
    If WrkAddendum Then
      dr = dsTot.Tables(0).NewRow
      dr.Item("totdesc") = ""
      dr.Item("totcount") = 0
      dr.Item("totamount") = 0
      dsTot.Tables(0).Rows.Add(dr)

      dr = dsTot.Tables(0).NewRow
      dr.Item("totdesc") = "After C/C Gross Assessment"
      dr.Item("totcount") = 0
      dr.Item("totamount") = WrkTCCGross
      dsTot.Tables(0).Rows.Add(dr)

      dr = dsTot.Tables(0).NewRow
      dr.Item("totdesc") = "After C/C Exemptions"
      dr.Item("totcount") = 0
      dr.Item("totamount") = WrkTCCExempt
      dsTot.Tables(0).Rows.Add(dr)

      dr = dsTot.Tables(0).NewRow
      dr.Item("totdesc") = "After C/C Net Assessment"
      dr.Item("totcount") = 0
      dr.Item("totamount") = WrkTCCNet
      dsTot.Tables(0).Rows.Add(dr)
    End If

    For I = 0 To 100
      If IsNothing(WrkTMCCode(I)) Then Exit For
      dr = dsTotMC.Tables(0).NewRow
      dr.Item("tmcformat") = "B"
      dr.Item("tmccode") = WrkTMCCode(I)
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I), WrkType)
      dr.Item("tmccount") = WrkTMCCount(I)
      dr.Item("tmcgross") = WrkTMCGross(I)
      dsTotMC.Tables(0).Rows.Add(dr)
    Next I

    For I = 0 To 100
      If IsNothing(WrkTMC2Code(I)) Then Exit For
      dr = dsTotMC2.Tables(0).NewRow
      dr.Item("tmcformat") = "B"
      dr.Item("tmccode") = WrkTMC2Code(I)
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMC2Code(I), WrkType)
      dr.Item("tmccount") = WrkTMC2Count(I)
      dr.Item("tmcgross") = WrkTMC2Gross(I)
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
    myTXPPRPQ.CloseFile()
    myTXPPRPCQ.CloseFile()
    myTXPPRAQ.CloseFile()
  End Sub
  Private Sub BufferCodes()
    Dim I As Integer

    Dim myTXCode As TXCODE.MyData
    Dim dsTXCode As DataSet = New DataSet

    myTXCode = New TXCODE.MyData(myDBConnect)

    dsTXCode = myTXCode.GetAllType(WrkType)
    For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkCode(I) = .Item("tccode")
        WrkDesc(I) = .Item("tcdesc")
      End With
    Next

  End Sub
  Private Function LookupOPMCode(ByVal Code As Integer) As String
    Dim I As Integer
    Dim WrkResult As String

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = 0 Then
        Return ""
      End If
      If Code = WrkCode(I) Then
        WrkResult = WrkDesc(I)
        Return WrkResult
      End If
    Next

    Return ""
  End Function
  Private Function LookupRptCode(ByVal Code As Integer) As Integer
    Dim I As Integer

    For I = 0 To RptCode.GetUpperBound(0)
      If RptCode(I) = 0 Then
        Return I
      End If
      If Code = RptCode(I) Then
        Return I
      End If
    Next

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

  End Function
End Module






