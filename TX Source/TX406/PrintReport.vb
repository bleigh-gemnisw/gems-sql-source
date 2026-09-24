Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXINVQ As TXINVQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData
  Dim myTXCOEA As TXCOEA.MyData
  Dim myTXCOEAL1 As TXCOEAL1.MyData
  Dim myTXHSTO As TXHSTO.MyData
  Dim myTXINVO As TXINVO.MyData
  Dim myTXCOEAO As TXCOEAO.MyData

  Dim ds As DataSet = New DataSet
  Dim dsTot As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkBalance As Boolean
  Dim WrkAmount As Decimal
  Dim WrkGLYear As Integer
  Dim WrkAsofDate As Date
  Dim WrkUpdate As Boolean
  Dim WrkArchive As Boolean
  Dim WrkSelType As String
  Dim WrkOmitStatus As String
  Dim WrkAnd As String
  Dim WrkOr As String
  'Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  'Totals
  Dim WrkTCount As Integer
  Dim WrkTOrigTax As Decimal
  Dim WrkTTax As Decimal
  Dim WrkTPaid As Decimal
  Dim WrkTBalance As Decimal
  Public Sub PrtReport()

    myTXINVQ = New TXINVQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)
    myTXCOEA = New TXCOEA.MyData(myDBConnect)
    myTXCOEAL1 = New TXCOEAL1.MyData(myDBConnect)
    myTXINVO = New TXINVO.MyData(myDBConnect)
    myTXHSTO = New TXHSTO.MyData(myDBConnect)
    myTXCOEAO = New TXCOEAO.MyData(myDBConnect)

    With MyFrmTX406B
      WrkBalance = .RbBalance.Checked
      WrkAmount = MyUtils.CnvSng(.TxtAmount.Text)
      WrkGLYear = MyUtils.CnvSng(.TxtGLYear.Text)
      WrkAsofDate = .DtPckAsof.Value
      WrkOmitStatus = .TxtOmitStatus.Text
      WrkUpdate = .ChkUpdate.Checked
      WrkArchive = .ChkArchive.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      dsTot.Clear()
      ClearTotals()
    End If

    BufferType()
    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .wrkds = ds
      .wrkdsTot = dsTot
      .WrkGLYear = WrkGLYear
      .WrkAsofDate = Format(WrkAsofDate, "short date")
      .Show()
    End With
  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTOrigTax = 0
    WrkTTax = 0
    WrkTPaid = 0
    WrkTBalance = 0
  End Sub
  Private Sub GetDetail()
    Dim dsinv As DataSet = New DataSet
    Dim dr As DataRow
    Dim WrkQry As String
    Dim WrkSort As String
    Dim SaveYear As Integer
    Dim SaveType As String

    Dim WrkList As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkTXType As String()
    Dim WrkOrigTax As Decimal
    Dim WrkTax As Decimal
    Dim Counter As Integer
    Dim I As Integer
    Dim Pos As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    'Filter Grand List Years
    WrkQry = "icode<>'I'" & WrkAnd & "year<=" & WrkGLYear

    If WrkBalance Then
      WrkQry = WrkQry & WrkAnd & "bald>=0" & WrkAnd & "bald<=" & WrkAmount
    End If

    MyTypes = MyFrmTX406B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE"
    dsinv = myTXINVQ.GetQry(WrkSort, WrkQry, 0)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveType = ""
    SaveYear = 0
ReadNext:
    For I = 0 To dsinv.Tables(0).Rows.Count - 1
      dr = dsinv.Tables(0).Rows(I)
      Counter = Counter + 1
      With myTXINVQ
        .GetFieldsDr(dr)
        If SaveType <> "" And SaveType <> ._TYPE Or
        SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        WrkList = ._LISTNo
        WrkType = ._TYPE
        WrkYear = ._YEAR

        'Filter - Last payment date after asof date
        If ._TXIDT > 0 Then
          If MyUtils.GetDBDate(._TXIDT) > WrkAsofDate Then
            GoTo NextRec
          End If
        End If
        'Filter - Last C/C date after asof date
        If ._CDATE > 0 Then
          If MyUtils.GetDBDate(._CDATE) > WrkAsofDate Then
            GoTo NextRec
          End If
        End If
        'Filter - Omit Status Codes
        If Trim(WrkOmitStatus) > "" Then
          Pos = 0
          If Trim(._STCD1) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD1), 1)
          End If
          If Pos = 0 And Trim(._STCD2) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD2), 1)
          End If
          If Pos = 0 And Trim(._STCD3) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD3), 1)
          End If
          If Pos = 0 And Trim(._STCD4) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD4), 1)
          End If
          If Pos = 0 And Trim(._STCD5) <> "" Then
            Pos = InStr(1, WrkOmitStatus, Trim(._STCD5), 1)
          End If
          If Pos > 0 Then GoTo NextRec
        End If

        SaveYear = ._YEAR
        SaveType = ._TYPE
        dr = ds.Tables(0).NewRow
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        WrkTXType = LookupType(._TYPE)
        dr.Item("typedesc") = WrkTXType(0)
        dr.Item("name") = Trim(._NAME)
        WrkOrigTax = ._TAXT
        If ._CCNO > 0 Then
          WrkTax = ._CCETAX
        Else
          WrkTax = ._TAXT
        End If
        dr.Item("origtax") = Format(WrkOrigTax, "fixed")
        dr.Item("tax") = Format(WrkTax, "fixed")
        dr.Item("paid") = Format(._PAYREC, "fixed")
        dr.Item("balance") = Format(._BALD, "fixed")
        ds.Tables(0).Rows.Add(dr)

        WrkTCount = WrkTCount + 1
        WrkTOrigTax = WrkTOrigTax + WrkOrigTax
        WrkTTax = WrkTTax + WrkTax
        WrkTPaid = WrkTPaid + ._PAYREC
        WrkTBalance = WrkTBalance + ._BALD

        If WrkUpdate Then
          If WrkArchive Then
            AddTXINV(WrkList, WrkYear, WrkType)
            AddTXHST(WrkList, WrkYear, WrkType)
          End If
          'AddDelTXCOEA(WrkArchive, WrkList, WrkYear, WrkType)
          DeleteTXHST(WrkList, WrkYear, WrkType)
          DeleteTXINV(WrkList, WrkYear, WrkType)
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
    Next

    WriteTotals(SaveYear, SaveType)
    myTXINVQ.CloseFile()
    myFrmProgress.Close()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTableTot As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("OrigTax", Type.GetType("System.Decimal"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

    With myTableTot
      .TableName = "mytabletot"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TOrigTax", Type.GetType("System.Decimal"))
      .Columns.Add("TTax", Type.GetType("System.Decimal"))
      .Columns.Add("TPaid", Type.GetType("System.Decimal"))
      .Columns.Add("TBalance", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTableTot)
  End Sub
  Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
    Dim WrkTXType As String()
    If WrkTCount = 0 Then Exit Sub

    dr = dsTot.Tables(0).NewRow
    dr.Item("tcount") = WrkTCount
    dr.Item("year") = SaveYear
    WrkTXType = LookupType(SaveType)
    dr.Item("typedesc") = WrkTXType(0)
    dr.Item("torigtax") = WrkTOrigTax
    dr.Item("ttax") = WrkTTax
    dr.Item("tpaid") = WrkTPaid
    dr.Item("tbalance") = WrkTBalance
    dsTot.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub AddTXINV(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)
    With myTXINVO
      .GetOneRecordP(WrkList, WrkYear, WrkType)
      ._ICODE = myTXINVQ._ICODE
      ._LISTNo = WrkList
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._NAME = myTXINVQ._NAME
      ._SNAME = myTXINVQ._SNAME
      ._ADD1 = myTXINVQ._ADD1
      ._ADD2 = myTXINVQ._ADD2
      ._CITY = myTXINVQ._CITY
      ._STATE = myTXINVQ._STATE
      ._ZIP5 = myTXINVQ._ZIP5
      ._ZIP4 = myTXINVQ._ZIP4
      ._DIST = myTXINVQ._DIST
      ._TAXT = myTXINVQ._TAXT
      ._TAX1 = myTXINVQ._TAX1
      ._TAX2 = myTXINVQ._TAX2
      ._PAYREC = myTXINVQ._PAYREC
      ._NEWPAY = myTXINVQ._NEWPAY
      ._GROSS = myTXINVQ._GROSS
      ._TOTEXP = myTXINVQ._TOTEXP
      ._NETASS = myTXINVQ._NETASS
      ._LOCNo = myTXINVQ._LOCNo
      ._LOC = myTXINVQ._LOC
      ._LIEN = myTXINVQ._LIEN
      ._SUSCD = myTXINVQ._SUSCD
      ._SUSDT = myTXINVQ._SUSDT
      ._CCNO = myTXINVQ._CCNO
      ._CCETAX = myTXINVQ._CCETAX
      ._CCTX1 = myTXINVQ._CCTX1
      ._CCTX2 = myTXINVQ._CCTX2
      ._CGRS = myTXINVQ._CGRS
      ._CCEXP = myTXINVQ._CCEXP
      ._CDATE = myTXINVQ._CDATE
      ._CCRSN = myTXINVQ._CCRSN
      ._VOL = myTXINVQ._VOL
      ._IPAGE = myTXINVQ._IPAGE
      ._MAP = myTXINVQ._MAP
      ._BKSR = myTXINVQ._BKSR
      ._BKCD = myTXINVQ._BKCD
      ._FRCD = myTXINVQ._FRCD
      ._FRYR = myTXINVQ._FRYR
      ._PCD = myTXINVQ._PCD
      ._PHASE = myTXINVQ._PHASE
      ._IPPCD1 = myTXINVQ._IPPCD1
      ._IPPCD2 = myTXINVQ._IPPCD2
      ._IPPCD3 = myTXINVQ._IPPCD3
      ._IPPCD4 = myTXINVQ._IPPCD4
      ._IPPCD5 = myTXINVQ._IPPCD5
      ._IPPCD6 = myTXINVQ._IPPCD6
      ._IPPCD7 = myTXINVQ._IPPCD7
      ._IPPCD8 = myTXINVQ._IPPCD8
      ._IPPCD9 = myTXINVQ._IPPCD9
      ._IPPCDA = myTXINVQ._IPPCDA
      ._MAKE = myTXINVQ._MAKE
      ._MVYR = myTXINVQ._MVYR
      ._MODEL = myTXINVQ._MODEL
      ._BODY = myTXINVQ._BODY
      ._CLASS = myTXINVQ._CLASS
      ._IMVIDNo = myTXINVQ._IMVIDNo
      ._IMVREG = myTXINVQ._IMVREG
      ._ILEASE = myTXINVQ._ILEASE
      ._ICVGRS = myTXINVQ._ICVGRS
      ._ICVACD = myTXINVQ._ICVACD
      ._ICVREG = myTXINVQ._ICVREG
      ._ICVMKE = myTXINVQ._ICVMKE
      ._ICVYR = myTXINVQ._ICVYR
      ._PRF = myTXINVQ._PRF
      ._CHDATE = myTXINVQ._CHDATE
      ._CHTIME = myTXINVQ._CHTIME
      ._AGY = myTXINVQ._AGY
      ._ADATE = myTXINVQ._ADATE
      ._LETT = myTXINVQ._LETT
      ._INTPD = myTXINVQ._INTPD
      ._LNPD = myTXINVQ._LNPD
      ._RPD = myTXINVQ._RPD
      ._TXIDT = myTXINVQ._TXIDT
      ._PRPRI = myTXINVQ._PRPRI
      ._PRINT = myTXINVQ._PRINT
      ._PRLIN = myTXINVQ._PRLIN
      ._TX3RD = myTXINVQ._TX3RD
      ._TX4TH = myTXINVQ._TX4TH
      ._TXINT = myTXINVQ._TXINT
      ._PDAT = myTXINVQ._PDAT
      ._MVFLAG = myTXINVQ._MVFLAG
      ._CEODC = myTXINVQ._CEODC
      ._BOND = myTXINVQ._BOND
      ._BONDP = myTXINVQ._BONDP
      ._BONT = myTXINVQ._BONT
      ._STCD1 = myTXINVQ._STCD1
      ._STCD2 = myTXINVQ._STCD2
      ._STCD3 = myTXINVQ._STCD3
      ._STCD4 = myTXINVQ._STCD4
      ._STCD5 = myTXINVQ._STCD5
      ._DOB = myTXINVQ._DOB
      ._PINPD = myTXINVQ._PINPD
      ._BALD = myTXINVQ._BALD
      ._CCTX3 = myTXINVQ._CCTX3
      ._CCTX4 = myTXINVQ._CCTX4
      ._OAS1 = myTXINVQ._OAS1
      ._OAS2 = myTXINVQ._OAS2
      ._OAS3 = myTXINVQ._OAS3
      ._OAS4 = myTXINVQ._OAS4
      ._OAS5 = myTXINVQ._OAS5
      ._OAS6 = myTXINVQ._OAS6
      ._OAS7 = myTXINVQ._OAS7
      ._OAS8 = myTXINVQ._OAS8
      ._OAS9 = myTXINVQ._OAS9
      ._OAS10 = myTXINVQ._OAS10
      ._CASS1 = myTXINVQ._CASS1
      ._CASS2 = myTXINVQ._CASS2
      ._CASS3 = myTXINVQ._CASS3
      ._CASS4 = myTXINVQ._CASS4
      ._CASS5 = myTXINVQ._CASS5
      ._CASS6 = myTXINVQ._CASS6
      ._CASS7 = myTXINVQ._CASS7
      ._CASS8 = myTXINVQ._CASS8
      ._CASS9 = myTXINVQ._CASS9
      ._CASS10 = myTXINVQ._CASS10
      ._UNIT1 = myTXINVQ._UNIT1
      ._UNIT2 = myTXINVQ._UNIT2
      ._UNIT3 = myTXINVQ._UNIT3
      ._UNIT4 = myTXINVQ._UNIT4
      ._UNIT5 = myTXINVQ._UNIT5
      ._UNIT6 = myTXINVQ._UNIT6
      ._UNIT7 = myTXINVQ._UNIT7
      ._UNIT8 = myTXINVQ._UNIT8
      ._UNIT9 = myTXINVQ._UNIT9
      ._UNITA = myTXINVQ._UNITA
      ._EXCD1 = myTXINVQ._EXCD1
      ._EXCD2 = myTXINVQ._EXCD2
      ._EXCD3 = myTXINVQ._EXCD3
      ._EXCD4 = myTXINVQ._EXCD4
      ._EXCD5 = myTXINVQ._EXCD5
      ._EXCD6 = myTXINVQ._EXCD6
      ._EXCD7 = myTXINVQ._EXCD7
      ._EXAM1 = myTXINVQ._EXAM1
      ._EXAM2 = myTXINVQ._EXAM2
      ._EXAM3 = myTXINVQ._EXAM3
      ._EXAM4 = myTXINVQ._EXAM4
      ._EXAM5 = myTXINVQ._EXAM5
      ._EXAM6 = myTXINVQ._EXAM6
      ._EXAM7 = myTXINVQ._EXAM7
      ._CCCD1 = myTXINVQ._CCCD1
      ._CCCD2 = myTXINVQ._CCCD2
      ._CCCD3 = myTXINVQ._CCCD3
      ._CCCD4 = myTXINVQ._CCCD4
      ._CCCD5 = myTXINVQ._CCCD5
      ._CCCD6 = myTXINVQ._CCCD6
      ._CCCD7 = myTXINVQ._CCCD7
      ._CEXA1 = myTXINVQ._CEXA1
      ._CEXA2 = myTXINVQ._CEXA2
      ._CEXA3 = myTXINVQ._CEXA3
      ._CEXA4 = myTXINVQ._CEXA4
      ._CEXA5 = myTXINVQ._CEXA5
      ._CEXA6 = myTXINVQ._CEXA6
      ._CEXA7 = myTXINVQ._CEXA7
      ._CPERC = myTXINVQ._CPERC
      ._CMAX = myTXINVQ._CMAX
      ._CMIN = myTXINVQ._CMIN
      ._CIRAD = myTXINVQ._CIRAD
      ._FTAX = myTXINVQ._FTAX
      ._FASS = myTXINVQ._FASS
      ._TWNBN = myTXINVQ._TWNBN
      ._ASS = myTXINVQ._ASS
      ._CMVDC = myTXINVQ._CMVDC
      ._CCM = myTXINVQ._CCM
      ._RLST = myTXINVQ._RLST
      ._PDST = myTXINVQ._PDST
      ._ICVIDNo = myTXINVQ._ICVIDNo
      ._ICVMOD = myTXINVQ._ICVMOD
      ._ICVCLS = myTXINVQ._ICVCLS
      ._OID = myTXINVQ._OID
      ._SSNo = myTXINVQ._SSNo
      ._SS2 = myTXINVQ._SS2
      ._TIN = myTXINVQ._TIN
      ._FEC1 = myTXINVQ._FEC1
      ._FEC2 = myTXINVQ._FEC2
      ._FEC3 = myTXINVQ._FEC3
      ._FEC4 = myTXINVQ._FEC4
      ._FEC5 = myTXINVQ._FEC5
      ._FED1 = myTXINVQ._FED1
      ._FED2 = myTXINVQ._FED2
      ._FED3 = myTXINVQ._FED3
      ._FED4 = myTXINVQ._FED4
      ._FED5 = myTXINVQ._FED5
      ._ABAT = myTXINVQ._ABAT
      ._ACD = myTXINVQ._ACD
      ._DECD = myTXINVQ._DECD
      ._INTY = myTXINVQ._INTY
      ._INPCT = myTXINVQ._INPCT
      ._ETC1 = myTXINVQ._ETC1
      ._ETC2 = myTXINVQ._ETC2
      ._ETC3 = myTXINVQ._ETC3
      ._ETC4 = myTXINVQ._ETC4
      ._ETC5 = myTXINVQ._ETC5
      ._ETC6 = myTXINVQ._ETC6
      ._ETC7 = myTXINVQ._ETC7
      ._ETC8 = myTXINVQ._ETC8
      ._ETC9 = myTXINVQ._ETC9
      ._ETCA = myTXINVQ._ETCA
      ._XDATE = myTXINVQ._XDATE
      .InsertOneRecordP()
    End With
  End Sub
  Private Sub AddTXHST(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)

    myTXHSTL4.SetRange(WrkList, WrkYear, WrkType, 0, False)
ReadHist:
    myTXHSTL4.ReadFileE()
    If Not myTXHSTL4.IsEOF Then
      With myTXHSTO
        .GetOneRecordP(myTXHSTL4._RECID)
        ._RECID = myTXHSTL4._RECID
        ._RCODE = myTXHSTL4._RCODE
        ._LISTNO = myTXHSTL4._LISTNO
        ._YEAR = myTXHSTL4._YEAR
        ._TYPE = myTXHSTL4._TYPE
        ._PAMT = myTXHSTL4._PAMT
        ._IAMT = myTXHSTL4._IAMT
        ._LAMT = myTXHSTL4._LAMT
        ._CORC = myTXHSTL4._CORC
        ._DIST = myTXHSTL4._DIST
        ._REF = myTXHSTL4._REF
        ._COMM = myTXHSTL4._COMM
        ._ADJCD = myTXHSTL4._ADJCD
        ._BATCHN = myTXHSTL4._BATCHN
        ._BATCHA = myTXHSTL4._BATCHA
        ._PDATE = myTXHSTL4._PDATE
        ._CDATE = myTXHSTL4._CDATE
        ._PCAMT = myTXHSTL4._PCAMT
        ._SUSCD = myTXHSTL4._SUSCD
        ._THAJCD = myTXHSTL4._THAJCD
        ._THINPD = myTXHSTL4._THINPD
        ._PENCD = myTXHSTL4._PENCD
        ._INTOR = myTXHSTL4._INTOR
        ._PRF = myTXHSTL4._PRF
        ._CHDATE = myTXHSTL4._CHDATE
        ._CHTIME = myTXHSTL4._CHTIME
        .InsertOneRecordP()
      End With
      GoTo ReadHist
    End If
  End Sub
  Private Sub AddDelTXCOEA(ByVal WrkArchive As Boolean, ByVal WrkList As Integer,
  ByVal WrkYear As Integer, ByVal WrkType As String)

    myTXCOEAL1.SetRange(WrkList, WrkYear, WrkType, 0, 0, False)
ReadCOE:
    myTXCOEAL1.ReadFileE()
    If Not myTXCOEAL1.IsEOF Then
      If WrkArchive Then
        With myTXCOEAO
          .GetOneRecordP(myTXCOEAL1._CCNO)
          ._LISTNo = myTXCOEAL1._LISTNo
          ._YEAR = myTXCOEAL1._YEAR
          ._TYPE = myTXCOEAL1._TYPE
          ._NAME = myTXCOEAL1._NAME
          ._DIST = myTXCOEAL1._DIST
          ._CCNO = myTXCOEAL1._CCNO
          ._CGRS = myTXCOEAL1._CGRS
          ._CDATE = myTXCOEAL1._CDATE
          ._PRF = myTXCOEAL1._PRF
          ._CHDATE = myTXCOEAL1._CHDATE
          ._CHTIME = myTXCOEAL1._CHTIME
          ._AFTER = myTXCOEAL1._AFTER
          ._ASS1 = myTXCOEAL1._ASS1
          ._ASS2 = myTXCOEAL1._ASS2
          ._ASS3 = myTXCOEAL1._ASS3
          ._ASS4 = myTXCOEAL1._ASS4
          ._ASS5 = myTXCOEAL1._ASS5
          ._ASS6 = myTXCOEAL1._ASS6
          ._ASS7 = myTXCOEAL1._ASS7
          ._ASS8 = myTXCOEAL1._ASS8
          ._ASS9 = myTXCOEAL1._ASS9
          ._ASS10 = myTXCOEAL1._ASS10
          ._C1CPCD = myTXCOEAL1._C1CPCD
          ._C1CSCD = myTXCOEAL1._C1CSCD
          ._C1MPCD = myTXCOEAL1._C1MPCD
          ._C1MSCD = myTXCOEAL1._C1MSCD
          ._C2CPCD = myTXCOEAL1._C2CPCD
          ._C2CSCD = myTXCOEAL1._C2CSCD
          ._C2MPCD = myTXCOEAL1._C2MPCD
          ._C2MSCD = myTXCOEAL1._C2MSCD
          ._CDESC = myTXCOEAL1._CDESC
          ._CETAX = myTXCOEAL1._CETAX
          ._CNETAS = myTXCOEAL1._CNETAS
          ._CPCD1 = myTXCOEAL1._CPCD1
          ._CPCD2 = myTXCOEAL1._CPCD2
          ._CPCD3 = myTXCOEAL1._CPCD3
          ._CPCD4 = myTXCOEAL1._CPCD4
          ._CPCD5 = myTXCOEAL1._CPCD5
          ._CPCD6 = myTXCOEAL1._CPCD6
          ._CPCD7 = myTXCOEAL1._CPCD7
          ._CPCD8 = myTXCOEAL1._CPCD8
          ._CPCD9 = myTXCOEAL1._CPCD9
          ._CPCDA = myTXCOEAL1._CPCDA
          ._CTXOV = myTXCOEAL1._CTXOV
          ._EX1 = myTXCOEAL1._EX1
          ._EX2 = myTXCOEAL1._EX2
          ._EX3 = myTXCOEAL1._EX3
          ._EX4 = myTXCOEAL1._EX4
          ._EX5 = myTXCOEAL1._EX5
          ._EX6 = myTXCOEAL1._EX6
          ._EX7 = myTXCOEAL1._EX7
          ._EXCD1 = myTXCOEAL1._EXCD1
          ._EXCD2 = myTXCOEAL1._EXCD2
          ._EXCD3 = myTXCOEAL1._EXCD3
          ._EXCD4 = myTXCOEAL1._EXCD4
          ._EXCD5 = myTXCOEAL1._EXCD5
          ._EXCD6 = myTXCOEAL1._EXCD6
          ._EXCD7 = myTXCOEAL1._EXCD7
          ._EXCHG = myTXCOEAL1._EXCHG
          ._GRCHG = myTXCOEAL1._GRCHG
          ._IMVIDNo = myTXCOEAL1._IMVIDNo
          ._NEWMVC = myTXCOEAL1._NEWMVC
          ._RSNCD = myTXCOEAL1._RSNCD
          ._SUSCD = myTXCOEAL1._SUSCD
          .AddOneRecordP()
        End With
      End If
      myTXCOEA.GetOneRecordP(myTXCOEAL1._CCNO)
      If Not myTXCOEA.RecordNotFound Then
        myTXCOEA.DeleteOneRecordP()
      End If
      GoTo ReadCOE
    End If
  End Sub
  Private Sub DeleteTXINV(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)
    myTXINV.DeleteListNo(WrkList, WrkYear, WrkType)
  End Sub
  Private Sub DeleteTXHST(ByVal WrkList As Integer, ByVal WrkYear As Integer, ByVal WrkType As String)
    myTXHST.DeleteListNo(WrkList, WrkYear, WrkType)
  End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return WrkResult
      End If
      If Type = WrkCode(I) Then
        WrkResult(0) = WrkDesc(I)
        WrkResult(1) = WrkFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function

End Module






