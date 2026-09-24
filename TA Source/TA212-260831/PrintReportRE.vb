Imports System.Text
Module PrintReportRE

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXREALQ As TXREALQ.MyData
  Dim myTXREALCQ As TXREALCQ.MyData
  Dim myTXREAAQ As TXREAAQ.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTXBTRC As TXBTRC.MyData
  Dim myTXREALC As TXREALC.MyData
  Dim myTXPHIN As TXPHIN.MyData
  Dim ds1 As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dsErr As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dsTotEx As DataSet = New DataSet
  Dim dsTotMC As DataSet = New DataSet
  Dim dsTotMC2 As DataSet = New DataSet
  Dim dsTotExempt As DataSet = New DataSet
  Dim DsTXREAL As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim drErr As Data.DataRow

  Dim WrkType As String
  Dim WrkYear As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkNewOPM As Boolean
  Dim WrkFile As String
  Dim WrkBTR As Boolean
  Dim WrkPrintDist As Boolean
  Dim WrkAddendum As Boolean
  Dim WrkPhaseIn As Boolean
  Dim WrkListZero As Boolean

  Dim WrkExcd(6) As String
  Dim WrkExam(6) As Integer
  'Totals
  Dim WrkTFullGross As Long
  Dim WrkTPIExm As Long
  Dim WrkTGross As Long
  Dim WrkTExempt As Long
  Dim WrkTNet As Long
  Dim WrkTCCGross As Long
  Dim WrkTCCExempt As Long
  Dim WrkTCCNet As Long
  Dim WrkTNumAccts As Integer
  'Buffered files
  Dim WrkCode(100) As Integer
  Dim WrkOPM(100) As Integer
  Dim WrkExemptCode(100) As String
  Dim WrkExemptDesc(100) As String
  'Report fields
  Dim RptCode(6) As String
  Dim RptGross(6) As Long
  Dim RptExCode(6) As String
  Dim RptExam(6) As Long
  'MC & Exemption Totals
  Dim WrkTMCCode(99, 2) As String
  Dim WrkTMCCount(100, 2) As Integer
  Dim WrkTMCGross(100, 2) As Long
  Dim WrkTMC2Code(100) As String
  Dim WrkTMC2Count(100) As Integer
  Dim WrkTMC2Gross(100) As Long
  Dim WrkTExCode(100, 2) As String
  Dim WrkTExCount(100, 2) As Integer
  Dim WrkTExam(100, 2) As Long
  Dim WrkTExemptLetter(100) As String
  Dim WrkTExemptCode(100) As String
  Dim WrkTExemptDesc(100) As String
  Dim WrkTExemptCount(100) As Integer
  Dim WrkTExemptGross(100) As Long

  Public Sub PrtReportRE()

    myTXREALQ = New TXREALQ.MyData(myDBConnect)
    myTXREALCQ = New TXREALCQ.MyData(myDBConnect)
    myTXREAAQ = New TXREAAQ.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTXBTRC = New TXBTRC.MyData(myDBConnect)
    myTXREALC = New TXREALC.MyData(myDBConnect)
    myTXPHIN = New TXPHIN.MyData(myDBConnect)

    With MyFrmTA212B
      WrkType = "R"
      WrkYear = .TxtGLYear.Text
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkFile = .CboFile.SelectedItem.ToString
      WrkNewOPM = False
      If .ChkNewOPM.Checked Then
        WrkNewOPM = True
      End If
      WrkPrintDist = False
      If .ChkPrtDist.Checked Then
        WrkPrintDist = True
      End If
      WrkBTR = False
      If .ChkBAA.Checked Then
        WrkBTR = True
      End If
      WrkAddendum = False
      If .ChkAddendum.Checked Then
        WrkAddendum = True
      End If
      WrkPhaseIn = False
      If .ChkPhaseIn.Checked Then
        WrkPhaseIn = True
      End If
      WrkListZero = False
      If .ChkListZero.Checked Then
        WrkListZero = True
      End If
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
      BuildDSErr(dsErr)
    Else
      ds1.Clear()
      ds2.Clear()
      dsErr.Clear()
      dsTot.Clear()
      dsTotEx.Clear()
      dsTotMC.Clear()
      dsTotMC2.Clear()
      dsTotExempt.Clear()
      ClearTotals()
    End If

    BufferCodes()
    BufferXPROP()
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
      .WrkdsTotExempt = dsTotExempt
      .WrkType = WrkType
      .WrkBTR = WrkBTR
      .WrkListZero = WrkListZero
      .Show()
    End With

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    Dim myTableEx As New DataTable
    Dim myTableMC As New DataTable
    Dim myTableExempt As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Dist", Type.GetType("System.Int32"))
      .Columns.Add("frcd", Type.GetType("System.String"))
      .Columns.Add("frcddesc", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("ListA", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("VolPage", Type.GetType("System.String"))
      .Columns.Add("MapLot", Type.GetType("System.String"))
      .Columns.Add("FullGross", Type.GetType("System.Int64"))
      .Columns.Add("PIExm", Type.GetType("System.Int64"))
      .Columns.Add("Gross", Type.GetType("System.Int64"))
      .Columns.Add("Exempt", Type.GetType("System.Int64"))
      .Columns.Add("Net", Type.GetType("System.Int64"))
      .Columns.Add("AssCd1", Type.GetType("System.String"))
      .Columns.Add("AssAmt1", Type.GetType("System.Int32"))
      .Columns.Add("AssCd2", Type.GetType("System.String"))
      .Columns.Add("AssAmt2", Type.GetType("System.Int32"))
      .Columns.Add("AssCd3", Type.GetType("System.String"))
      .Columns.Add("AssAmt3", Type.GetType("System.Int32"))
      .Columns.Add("AssCd4", Type.GetType("System.String"))
      .Columns.Add("AssAmt4", Type.GetType("System.Int32"))
      .Columns.Add("AssCd5", Type.GetType("System.String"))
      .Columns.Add("AssAmt5", Type.GetType("System.Int32"))
      .Columns.Add("AssCd6", Type.GetType("System.String"))
      .Columns.Add("AssAmt6", Type.GetType("System.Int32"))
      .Columns.Add("AssCd7", Type.GetType("System.String"))
      .Columns.Add("AssAmt7", Type.GetType("System.Int32"))
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
      .Columns.Add("ExCd6", Type.GetType("System.String"))
      .Columns.Add("ExAmt6", Type.GetType("System.Int32"))
      .Columns.Add("ExCd7", Type.GetType("System.String"))
      .Columns.Add("ExAmt7", Type.GetType("System.Int32"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
      .Columns.Add("CCGrs", Type.GetType("System.Int32"))
      .Columns.Add("CCEx", Type.GetType("System.Int32"))
      .Columns.Add("CCNet", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)
    ds2 = ds1.Clone

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("totdesc", Type.GetType("System.String"))
      .Columns.Add("totcount", Type.GetType("System.Int32"))
      .Columns.Add("totamount", Type.GetType("System.Int64"))
    End With
    dsTot.Tables.Add(myTableTot)

    With myTableEx
      .TableName = "mytableex"
      .Columns.Add("texformat", Type.GetType("System.String"))
      .Columns.Add("texcode", Type.GetType("System.String"))
      .Columns.Add("texdesc", Type.GetType("System.String"))
      .Columns.Add("texcount", Type.GetType("System.Int32"))
      .Columns.Add("tex", Type.GetType("System.Int64"))
      .Columns.Add("texfrzcount", Type.GetType("System.Int32"))
      .Columns.Add("texfrz", Type.GetType("System.Int64"))
      .Columns.Add("texheartcount", Type.GetType("System.Int32"))
      .Columns.Add("texheart", Type.GetType("System.Int64"))
      .Columns.Add("textotcount", Type.GetType("System.Int32"))
      .Columns.Add("textot", Type.GetType("System.Int64"))
    End With
    dsTotEx.Tables.Add(myTableEx)

    With myTableMC
      .TableName = "mytablemc"
      .Columns.Add("tmcformat", Type.GetType("System.String"))
      .Columns.Add("tmccode", Type.GetType("System.String"))
      .Columns.Add("tmcdesc", Type.GetType("System.String"))
      .Columns.Add("tmccount", Type.GetType("System.Int32"))
      .Columns.Add("tmcgross", Type.GetType("System.Int64"))
      .Columns.Add("tmcfrzcount", Type.GetType("System.Int32"))
      .Columns.Add("tmcfrzgross", Type.GetType("System.Int64"))
      .Columns.Add("tmcheartcount", Type.GetType("System.Int32"))
      .Columns.Add("tmcheartgross", Type.GetType("System.Int64"))
      .Columns.Add("tmctotcount", Type.GetType("System.Int32"))
      .Columns.Add("tmctotgross", Type.GetType("System.Int64"))
    End With
    dsTotMC.Tables.Add(myTableMC)
    dsTotMC2 = dsTotMC.Clone

    With myTableExempt
      .TableName = "mytableexempt"
      .Columns.Add("texemptletter", Type.GetType("System.String"))
      .Columns.Add("texemptcode", Type.GetType("System.String"))
      .Columns.Add("texemptdesc", Type.GetType("System.String"))
      .Columns.Add("texemptcount", Type.GetType("System.Int32"))
      .Columns.Add("texemptgross", Type.GetType("System.Int64"))
    End With
    dsTotExempt.Tables.Add(myTableExempt)
  End Sub
  Private Sub ClearTotals()
    WrkTFullGross = 0
    WrkTPIExm = 0
    WrkTGross = 0
    WrkTExempt = 0
    WrkTNet = 0
    WrkTNumAccts = 0
    WrkTCCGross = 0
    WrkTCCExempt = 0
    WrkTCCNet = 0
    ReDim WrkTMCCode(100, 2)
    ReDim WrkTMCCount(100, 2)
    ReDim WrkTMCGross(100, 2)
    ReDim WrkTMC2Code(100)
    ReDim WrkTMC2Count(100)
    ReDim WrkTMC2Gross(100)
    ReDim WrkTExCode(100, 2)
    ReDim WrkTExCount(100, 2)
    ReDim WrkTExam(100, 2)
    Array.Clear(WrkTExemptCode, 0, 101)
    Array.Clear(WrkTExemptDesc, 0, 101)
    Array.Clear(WrkTExemptCount, 0, 101)
    Array.Clear(WrkTExemptGross, 0, 101)
  End Sub
  Private Sub GetDetail()
    Dim WrkListNo As Integer
    Dim AddrLine() As String
    Dim WrkTypeDesc As String
    Dim WrkTypeFamily As String
    Dim WrkOPMGroup As Integer
    Dim WrkExemptProp As Boolean
    Dim WrkElderly As Boolean
    Dim WrkQry As String
    Dim WrkRptCat As Integer
    Dim WrkAssCode(6) As Integer
    Dim WrkGross(6) As Long
    Dim WrkGrossXFoot As Long
    Dim WrkUnit(6) As Integer
    Dim WrkExempt As Long
    Dim WrkEx As Integer
    Dim WrkTotBTR As Long
    Dim WrkFrozenCode As String
    Dim WrkFullGross As Long
    Dim WrkPIExm As Long
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
        DsTXREAL = myTXREALQ.GetQry("FCCOD, NAME, LIST#", WrkQry, 0)
      Case "Frozen"
        DsTXREAL = myTXREALCQ.GetQry("FCCOD, NAME, LIST#", WrkQry, 0)
      Case "Archive"
        If WrkQry = "" Then
          WrkQry = "TXYEAR=" & MyUtils.CnvSng(WrkYear)
        Else
          WrkQry = WrkQry & WrkAnd & "TXYEAR=" & MyUtils.CnvSng(WrkYear)
        End If
        DsTXREAL = myTXREAAQ.GetQry("FCCOD, NAME, LIST#", WrkQry, 0)
    End Select
    If DsTXREAL.Tables(0).Rows.Count = 0 Then Exit Sub
    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()

    WrkTypeDesc = GetTXTypeDesc(WrkType)
    WrkTypeFamily = GetTXTypeFamily(WrkType)

    For I = 0 To (DsTXREAL.Tables(0).Rows.Count - 1)
      With DsTXREAL.Tables(0).Rows(I)
        WrkListNo = .Item("list#")
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
        If .Item("cat") = "3" Then
          WrkExemptProp = True
          dr = ds2.Tables(0).NewRow
        Else
          WrkExemptProp = False
          dr = ds1.Tables(0).NewRow
        End If
        WrkTNumAccts = WrkTNumAccts + 1
        dr.Item("dist") = WrkDist
        dr.Item("frcd") = .Item("fccod")
        dr.Item("listno") = WrkListNo
        If myTOWN._TOWNBR = 32 Then 'Coventry
          dr.Item("lista") = Format(WrkListNo, "00000")
        Else
          dr.Item("lista") = Format(WrkListNo, "000000")
        End If
        dr.Item("year") = WrkYear
        If WrkExemptProp Then
          dr.Item("typedesc") = "EXEMPT " & WrkTypeDesc
        Else
          dr.Item("typedesc") = WrkTypeDesc
        End If

        WrkRptCat = 0
        WrkFrozenCode = .Item("fccod")
        Select Case WrkFrozenCode
          Case "C"
            WrkRptCat = 2
            WrkElderly = True
            dr.Item("frcddesc") = "Elderly H.E.A.R.T."
            dr.Item("propdesc") = GetPropDesc(I, "Cir")
          Case "F"
            WrkRptCat = 1
            WrkElderly = True
            dr.Item("frcddesc") = "Frozen"
            dr.Item("propdesc") = GetPropDesc(I, "Frz")
          Case Else
            WrkElderly = False
            dr.Item("frcddesc") = ""
            dr.Item("propdesc") = ""
        End Select

        If WrkExemptProp Then
          'Add to Exempt totals
          K = LookupWrkTExemptCode(.Item("exmpt"))
          WrkTExemptLetter(K) = Left(.Item("exmpt"), 1)
          WrkTExemptCode(K) = .Item("exmpt")
          WrkTExemptDesc(K) = LookupXPROP(.Item("exmpt"))
          WrkTExemptCount(K) = WrkTExemptCount(K) + 1
          WrkTExemptGross(K) = WrkTExemptGross(K) + .Item("gross")
          dr.Item("propdesc") = .Item("exmpt") & " - " & WrkTExemptDesc(K)
          K = LookupWrkTExemptCode(Left(.Item("exmpt"), 1))
          WrkTExemptLetter(K) = Left(.Item("exmpt"), 1)
          WrkTExemptCode(K) = WrkTExemptLetter(K)
          WrkTExemptDesc(K) = LookupXPROP(WrkTExemptLetter(K))
          WrkTExemptCount(K) = 0
          WrkTExemptGross(K) = 0
        End If

        AddrLine = MyUtils.SetAddrLine(.Item("name"), .Item("sname"), .Item("add1"), .Item("add2"),
      .Item("city"), .Item("state"), .Item("zip5"), .Item("zip4"))
        dr.Item("addr1") = AddrLine(0)
        dr.Item("addr2") = AddrLine(1)
        dr.Item("addr3") = AddrLine(2)
        dr.Item("addr4") = AddrLine(3)
        dr.Item("addr5") = AddrLine(4)
        dr.Item("location") = Trim(.Item("loc#")) & " " & .Item("loc")
        dr.Item("volpage") = .Item("vol") & " " & .Item("pge")
        dr.Item("maplot") = .Item("map")
        WrkAssCode(0) = .Item("code1")
        WrkAssCode(1) = .Item("code2")
        WrkAssCode(2) = .Item("code3")
        WrkAssCode(3) = .Item("code4")
        WrkAssCode(4) = .Item("code5")
        WrkAssCode(5) = .Item("code6")
        WrkAssCode(6) = .Item("code7")
        WrkGross(0) = .Item("ass1")
        WrkGross(1) = .Item("ass2")
        WrkGross(2) = .Item("ass3")
        WrkGross(3) = .Item("ass4")
        WrkGross(4) = .Item("ass5")
        WrkGross(5) = .Item("ass6")
        WrkGross(6) = .Item("ass7")
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
        WrkExcd(0) = Trim(.Item("excd1"))
        WrkExcd(1) = Trim(.Item("excd2"))
        WrkExcd(2) = Trim(.Item("excd3"))
        WrkExcd(3) = Trim(.Item("excd4"))
        WrkExcd(4) = Trim(.Item("excd5"))
        WrkExcd(5) = Trim(.Item("excd6"))
        WrkExcd(6) = Trim(.Item("excd7"))
        WrkExam(0) = .Item("exam1")
        WrkExam(1) = .Item("exam2")
        WrkExam(2) = .Item("exam3")
        WrkExam(3) = .Item("exam4")
        WrkExam(4) = .Item("exam5")
        WrkExam(5) = .Item("exam6")
        WrkExam(6) = .Item("exam7")

        'Combine Gross into OPM groups
        Array.Clear(RptCode, 0, 7)
        Array.Clear(RptGross, 0, 7)
        WrkGrossXFoot = 0
        For J = 0 To 6
          WrkGrossXFoot = WrkGrossXFoot + WrkGross(J)
          If WrkAssCode(J) > 0 Then
            WrkOPMGroup = LookupOPMCode(WrkAssCode(J))
            'Check for Invalid Assessment Codes
            If WrkOPMGroup = 0 Or (WrkGross(J) = 0 And WrkTotBTR = 0 And .Item("ccgrs") = 0) Then
              drErr = dsErr.Tables(0).NewRow
              drErr.Item("listno") = WrkListNo
              drErr.Item("addr1") = AddrLine(0)
              drErr.Item("gross") = WrkGross(J)
              drErr.Item("exempt") = 0
              drErr.Item("net") = 0
              If WrkOPMGroup = 0 Then
                drErr.Item("errmsg") = "Invalid Assmnt Code " & WrkAssCode(J)
              Else
                drErr.Item("errmsg") = "Gross is zero, Code " & WrkAssCode(J)
              End If
              dsErr.Tables(0).Rows.Add(drErr)
            End If
            K = LookupRptCode(WrkOPMGroup)
            RptCode(K) = WrkOPMGroup
            RptGross(K) = RptGross(K) + WrkGross(J)
          Else
            'Check for Missing Assessment Codes
            If WrkGross(J) > 0 Then
              drErr = dsErr.Tables(0).NewRow
              drErr.Item("listno") = WrkListNo
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
          For J = 0 To 6
            If Not IsNothing(RptCode(J)) Then
              K = LookupWrkTMCCode(RptCode(J), 0)
              If WrkRptCat <> 0 Then
                WrkTMCCode(K, 0) = RptCode(J)
              End If
              WrkTMCCode(K, WrkRptCat) = RptCode(J)
              WrkTMCCount(K, WrkRptCat) = WrkTMCCount(K, WrkRptCat) + 1
              WrkTMCGross(K, WrkRptCat) = WrkTMCGross(K, WrkRptCat) + RptGross(J)
            End If
          Next J
        Else
          For J = 0 To 6
            If Not IsNothing(RptCode(J)) Then
              K = LookupWrkTMC2Code(RptCode(J))
              WrkTMC2Code(K) = RptCode(J)
              WrkTMC2Count(K) = WrkTMC2Count(K) + 1
              WrkTMC2Gross(K) = WrkTMC2Gross(K) + RptGross(J)
            End If
          Next J
        End If

        dr.Item("asscd1") = RptCode(0)
        dr.Item("assamt1") = RptGross(0)
        dr.Item("asscd2") = RptCode(1)
        dr.Item("assamt2") = RptGross(1)
        dr.Item("asscd3") = RptCode(2)
        dr.Item("assamt3") = RptGross(2)
        dr.Item("asscd4") = RptCode(3)
        dr.Item("assamt4") = RptGross(3)
        dr.Item("asscd5") = RptCode(4)
        dr.Item("assamt5") = RptGross(4)
        dr.Item("asscd6") = RptCode(5)
        dr.Item("assamt6") = RptGross(5)
        dr.Item("asscd7") = RptCode(6)
        dr.Item("assamt7") = RptGross(6)

        'Combine Exemptions into Letter groups
        Array.Clear(RptExCode, 0, 7)
        Array.Clear(RptExam, 0, 7)
        WrkExempt = 0
        If Not WrkExemptProp Then
          For J = 0 To 6
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
              drErr.Item("listno") = WrkListNo
              drErr.Item("addr1") = AddrLine(0)
              drErr.Item("gross") = 0
              drErr.Item("exempt") = WrkExam(J)
              drErr.Item("net") = 0
              drErr.Item("errmsg") = "Invalid Exemption " & WrkExcd(J)
              dsErr.Tables(0).Rows.Add(drErr)
            End If
          Next
        End If

        'PhaseIn
        If MyPhaseIn Then
          myTXPHIN.GetOneRecordP(WrkListNo, WrkYear)
          With myTXPHIN
            If Not .RecordNotFound Then
              WrkFullGross = ._FULGRS
            End If
          End With
          myTXREALC.GetOneRecordP(WrkListNo)
          With myTXREALC
            If Not .RecordNotFound Then
              WrkPIExm = WrkFullGross - ._GROSS
            End If
          End With
        End If

        dr.Item("fullgross") = WrkFullGross + WrkTotBTR
        dr.Item("piexm") = WrkPIExm + WrkTotBTR
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
        dr.Item("excd6") = RptExCode(5)
        dr.Item("examt6") = RptExam(5)
        dr.Item("excd7") = RptExCode(6)
        dr.Item("examt7") = RptExam(6)

        'Add Exemption Letter groups
        If Not WrkExemptProp Then
          For J = 0 To 6
            If Not IsNothing(RptExCode(J)) Then
              K = LookupWrkTExCode(RptExCode(J), 0)
              If WrkRptCat <> 0 Then
                WrkTExCode(K, 0) = RptExCode(J)
              End If
              WrkTExCode(K, WrkRptCat) = RptExCode(J)
              WrkTExCount(K, WrkRptCat) = WrkTExCount(K, WrkRptCat) + 1
              WrkTExam(K, WrkRptCat) = WrkTExam(K, WrkRptCat) + RptExam(J)
            End If
          Next J
        End If

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
          WrkTFullGross = WrkTFullGross + dr.Item("fullgross")
          WrkTPIExm = WrkTPIExm + dr.Item("piexm")
          WrkTGross = WrkTGross + dr.Item("gross")
          WrkTExempt = WrkTExempt + WrkExempt
          WrkTNet = WrkTNet + dr.Item("net")
          ds1.Tables(0).Rows.Add(dr)
        End If

        'Check for Invalid Catagory
        If .Item("cat") <> "1" And .Item("cat") <> "3" Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = WrkListNo
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "Tax catagory is invalid"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for Blank Exempt Code
        If .Item("cat") = "3" And .Item("exmpt") = String.Empty Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = WrkListNo
          drErr.Item("addr1") = AddrLine(0)
          drErr.Item("gross") = .Item("gross") + WrkTotBTR
          drErr.Item("exempt") = WrkExempt
          drErr.Item("net") = .Item("net") + WrkTotBTR
          drErr.Item("errmsg") = "Missing Tax Exempt code"
          dsErr.Tables(0).Rows.Add(drErr)
        End If
        'Check for Negative Net
        If .Item("gross") + WrkTotBTR - WrkExempt < 0 Or .Item("net") < 0 Then
          drErr = dsErr.Tables(0).NewRow
          drErr.Item("listno") = WrkListNo
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
          drErr.Item("listno") = WrkListNo
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
          drErr.Item("listno") = WrkListNo
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
          drErr.Item("listno") = WrkListNo
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
        WrkPct = ((I + 1) / DsTXREAL.Tables(0).Rows.Count) * 100
        If SavePct <> WrkPct Then
          .ProgBar1.Value = WrkPct
          .Refresh()
          SavePct = WrkPct
        End If
      End With
    Next

    'Totals
    If WrkPhaseIn Then
      dr = dsTot.Tables(0).NewRow
      dr.Item("totdesc") = "Total Gross Assessment"
      dr.Item("totcount") = WrkTNumAccts
      dr.Item("totamount") = WrkTFullGross
      dsTot.Tables(0).Rows.Add(dr)

      dr = dsTot.Tables(0).NewRow
      dr.Item("totdesc") = "Total Phase In Exemption"
      dr.Item("totcount") = 0
      dr.Item("totamount") = WrkTPIExm
      dsTot.Tables(0).Rows.Add(dr)
    End If

    dr = dsTot.Tables(0).NewRow
    If WrkPhaseIn Then
      dr.Item("totdesc") = "Total Phase In Net"
      dr.Item("totcount") = 0
    Else
      dr.Item("totdesc") = "Total Gross Assessment"
      dr.Item("totcount") = WrkTNumAccts
    End If
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
      If IsNothing(WrkTMCCode(I, 0)) Then Exit For
      dr = dsTotMC.Tables(0).NewRow
      dr.Item("tmcformat") = "A"
      dr.Item("tmccode") = WrkTMCCode(I, 0)
      dr.Item("tmcdesc") = GetTXCodeDesc(WrkTMCCode(I, 0), WrkType)
      dr.Item("tmccount") = WrkTMCCount(I, 0)
      dr.Item("tmcgross") = WrkTMCGross(I, 0)
      dr.Item("tmcfrzcount") = WrkTMCCount(I, 1)
      dr.Item("tmcfrzgross") = WrkTMCGross(I, 1)
      dr.Item("tmcheartcount") = WrkTMCCount(I, 2)
      dr.Item("tmcheartgross") = WrkTMCGross(I, 2)
      dr.Item("tmctotcount") = WrkTMCCount(I, 0) + WrkTMCCount(I, 1) + WrkTMCCount(I, 2)
      dr.Item("tmctotgross") = WrkTMCGross(I, 0) + WrkTMCGross(I, 1) + WrkTMCGross(I, 2)
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
      If IsNothing(WrkTExCode(I, 0)) Then Exit For
      dr = dsTotEx.Tables(0).NewRow
      dr.Item("texformat") = "A"
      dr.Item("texcode") = WrkTExCode(I, 0)
      K = LookupExem(WrkTExCode(I, 0))
      If K >= 0 Then
        dr.Item("texdesc") = WrkExDesc(K)
      Else
        If WrkTExCode(I, 0) = "*" Then
          dr.Item("texdesc") = "LOCAL EXEMPTIONS"
        Else
          dr.Item("texdesc") = "*** Invalid OPM Group ***"
        End If
      End If
      dr.Item("texcount") = WrkTExCount(I, 0)
      dr.Item("tex") = WrkTExam(I, 0)
      dr.Item("texfrzcount") = WrkTExCount(I, 1)
      dr.Item("texfrz") = WrkTExam(I, 1)
      dr.Item("texheartcount") = WrkTExCount(I, 2)
      dr.Item("texheart") = WrkTExam(I, 2)
      dr.Item("textotcount") = WrkTExCount(I, 0) + WrkTExCount(I, 1) + WrkTExCount(I, 2)
      dr.Item("textot") = WrkTExam(I, 0) + WrkTExam(I, 1) + WrkTExam(I, 2)
      dsTotEx.Tables(0).Rows.Add(dr)
    Next I

    For I = 0 To 100
      If IsNothing(WrkTExemptCode(I)) Then Exit For
      dr = dsTotExempt.Tables(0).NewRow
      dr.Item("texemptletter") = WrkTExemptLetter(I)
      dr.Item("texemptcode") = WrkTExemptCode(I)
      dr.Item("texemptdesc") = WrkTExemptDesc(I)
      dr.Item("texemptcount") = WrkTExemptCount(I)
      dr.Item("texemptgross") = WrkTExemptGross(I)
      dsTotExempt.Tables(0).Rows.Add(dr)
    Next I

    myFrmProgress.Close()
    myTXREALQ.CloseFile()
    myTXREALCQ.CloseFile()
    myTXREAAQ.CloseFile()

  End Sub
  Private Function GetPropDesc(ByVal I As Integer, ByVal WrkFamily As String) As String
    Dim sb As StringBuilder

    sb = New StringBuilder
    Select Case WrkFamily
      Case "Cir"
        With DsTXREAL.Tables(0).Rows(I)
          sb.Append(.Item("fcyr"))
          sb.Append("  CIR  ")
          sb.Append(FormatCurrency(.Item("ftax")))
          sb.Append("  ")
          sb.Append(Format(.Item("cperc"), ".00"))
        End With
      Case "Frz"
        With DsTXREAL.Tables(0).Rows(I)
          sb.Append(.Item("fcyr"))
          sb.Append(" FRZ ")
          sb.Append(FormatCurrency(.Item("ftax")))
        End With
      Case Else
        sb.Append(" ")
    End Select

    Return sb.ToString

  End Function
  Private Sub BufferCodes()
    Dim I As Integer

    Dim myTXCode As TXCODE.MyData
    Dim dsTXCode As DataSet = New DataSet

    Array.Clear(WrkCode, 0, 101)
    Array.Clear(WrkOPM, 0, 101)

    myTXCode = New TXCODE.MyData(myDBConnect)

    dsTXCode = myTXCode.GetAllType(WrkType)
    For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkCode(I) = .Item("tccode")
        If WrkNewOPM Then
          WrkOPM(I) = .Item("tcopmc")
        Else
          WrkOPM(I) = .Item("tccode")
        End If
      End With
    Next

  End Sub
  Private Sub BufferXPROP()
    Dim I As Integer

    Dim myTXXPROP As TXXPROP.MyData
    Dim dsTXXPROP As DataSet = New DataSet

    myTXXPROP = New TXXPROP.MyData(myDBConnect)

    dsTXXPROP = myTXXPROP.GetAllData
    For I = 0 To dsTXXPROP.Tables(0).Rows.Count - 1
      With dsTXXPROP.Tables(0).Rows(I)
        WrkExemptCode(I) = Trim(.Item("prexem"))
        WrkExemptDesc(I) = Trim(.Item("txdesc"))
      End With
    Next

  End Sub
  Private Function LookupOPMCode(ByVal Code As Integer) As Integer
    Dim I As Integer
    Dim WrkResult As Integer

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = 0 Then
        Return -1
      End If
      If Code = WrkCode(I) Then
        WrkResult = WrkOPM(I)
        Return WrkResult
      End If
    Next

  End Function
  Private Function LookupXPROP(ByVal Code As String) As String
    Dim I As Integer
    Dim WrkResult As String

    For I = 0 To WrkExemptCode.GetUpperBound(0)
      If Trim(WrkExemptCode(I)) = "" Then
        Return ""
      End If
      If Trim(Code) = Trim(WrkExemptCode(I)) Then
        WrkResult = WrkExemptDesc(I)
        Return WrkResult
      End If
    Next

    Return ""
  End Function
  Private Function LookupRptCode(ByVal Code As Integer) As Integer
    Dim I As Integer

    For I = 0 To RptCode.GetUpperBound(0)
      If RptCode(I) & "" = "" Then
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
  Private Function LookupWrkTMCCode(ByVal Code As Integer, ByVal Cat As Integer) As Integer
    Dim I As Integer

    For I = 0 To WrkTMCCode.GetUpperBound(0)
      If WrkTMCCode(I, Cat) = "" Then
        Return I
      End If
      If Code = WrkTMCCode(I, Cat) Then
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
  Private Function LookupWrkTExCode(ByVal Code As String, ByVal Cat As Integer) As Integer
    Dim I As Integer

    For I = 0 To WrkTExCode.GetUpperBound(0)
      If Trim(WrkTExCode(I, Cat)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkTExCode(I, Cat)) Then
        Return I
      End If
    Next

  End Function
  Private Function LookupWrkTExemptCode(ByVal Code As String) As Integer
    Dim I As Integer

    For I = 0 To WrkTExemptCode.GetUpperBound(0)
      If Trim(WrkTExemptCode(I)) = "" Then
        Return I
      End If
      If Trim(Code) = Trim(WrkTExemptCode(I)) Then
        Return I
      End If
    Next

  End Function
End Module






