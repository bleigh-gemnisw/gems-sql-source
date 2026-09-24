Module ProcessMV
  Dim myTXMVDCQ As TXMVDCQ.MyData
  Dim myTXBAA As TXBAA.MyData
  Dim myTXMVA As TXMVA.MyData

  Dim WrkYear As Integer
  Dim WrkTotBTR As Integer
  Const WrkType As String = "M"

  Public Sub ProcMV()
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkCount As Integer

    Counter = 0
    WrkQry = ""
    WrkSort = "List#"
    myTXMVDCQ = New TXMVDCQ.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)
    myTXMVA = New TXMVA.MyData(myDBConnect)

    With MyFrmTAD04B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    WrkCount = myTXMVA.GetIsPosted(WrkYear)
    If WrkCount > 0 Then 'if already archived then abort
      MyArchived = True
      Exit Sub
    End If

    MyFrmProgress = New FrmProgress
    MyFrmProgress.LblMsg.Text = "Motor Vehicle"
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    MyFrmTAD04B.LblMV.Visible = True
    Application.DoEvents()

    myTXMVDCQ.OpenQry(WrkSort, WrkQry)
ReadNext:
    myTXMVDCQ.ReadQry()
    If Not myTXMVDCQ.IsEOF Then
      With myTXMVDCQ
        Counter = Counter + 1
        myTXMVA.GetOneRecordP(._LISTNO, WrkYear)
        If myTXMVA.RecordNotFound Then
          myTXMVA._CAT = ._CAT
          myTXMVA._LISTNo = ._LISTNO
          myTXMVA._TXYEAR = WrkYear
          myTXMVA._NAME = ._NAME
          myTXMVA._SNAME = ._SNAME
          myTXMVA._ADD1 = ._ADD1
          myTXMVA._ADD2 = ._ADD2
          myTXMVA._CITY = ._CITY
          myTXMVA._STATE = ._STATE
          myTXMVA._ZIP5 = ._ZIP5
          myTXMVA._ZIP4 = ._ZIP4
          myTXMVA._DIST = ._DIST
          myTXMVA._PDST = ._PDST
          If ._BTR <> 0 Then
            myTXBAA.GetOneRecordP(._LISTNO, WrkType, WrkYear)
            WrkTotBTR = myTXBAA._BASS1
            myTXMVA._VALUE = myTXBAA._ASS1
            myTXMVA._BTR = WrkTotBTR
            myTXMVA._DNBTR = myTXBAA._DNBTR
            myTXMVA._DTBTR = myTXBAA._DTBTR
          Else
            myTXMVA._VALUE = ._VALUE
            myTXMVA._BTR = ._BTR
            myTXMVA._DNBTR = ._DNBTR
            myTXMVA._DTBTR = ._DTBTR
          End If
          myTXMVA._XDATE = ._XDATE
          myTXMVA._CLASS = ._CLASS
          myTXMVA._REGNO = ._REGNO
          myTXMVA._MAKE = ._MAKE
          myTXMVA._YEAR = ._YEAR
          myTXMVA._MODEL = ._MODEL
          myTXMVA._BODY = ._BODY
          myTXMVA._VINNO = ._VINNO
          myTXMVA._CYLAX = ._CYLAX
          myTXMVA._PCLR = ._PCLR
          myTXMVA._SCLR = ._SCLR
          myTXMVA._SEAT = ._SEAT
          myTXMVA._LWT = ._LWT
          myTXMVA._GWT = ._GWT
          myTXMVA._VALUE = ._VALUE
          myTXMVA._ASS = ._ASS
          myTXMVA._CYCLE = ._CYCLE
          myTXMVA._RCODE = ._RCODE
          myTXMVA._OCODE = ._OCODE
          myTXMVA._RATE = ._RATE
          myTXMVA._PCCOD = ._PCCOD
          myTXMVA._PREG = ._PREG
          myTXMVA._SCAP = ._SCAP
          myTXMVA._TDATE = ._TDATE
          myTXMVA._EXCD1 = ._EXCD1
          myTXMVA._EXCD2 = ._EXCD2
          myTXMVA._EXCD3 = ._EXCD3
          myTXMVA._EXCD4 = ._EXCD4
          myTXMVA._EXCD5 = ._EXCD5
          myTXMVA._EXAM1 = ._EXAM1
          myTXMVA._EXAM2 = ._EXAM2
          myTXMVA._EXAM3 = ._EXAM3
          myTXMVA._EXAM4 = ._EXAM4
          myTXMVA._EXAM5 = ._EXAM5
          myTXMVA._CCNO = ._CCNO
          myTXMVA._CCGRS = ._CCGRS
          myTXMVA._CCEX = ._CCEX
          myTXMVA._CCRS = ._CCRS
          myTXMVA._CDATE = ._CDATE
          myTXMVA._CCCD1 = ._CCCD1
          myTXMVA._CCCD2 = ._CCCD2
          myTXMVA._CCCD3 = ._CCCD3
          myTXMVA._CCCD4 = ._CCCD4
          myTXMVA._CCCD5 = ._CCCD5
          myTXMVA._CEXA1 = ._CEXA1
          myTXMVA._CEXA2 = ._CEXA2
          myTXMVA._CEXA3 = ._CEXA3
          myTXMVA._CEXA4 = ._CEXA4
          myTXMVA._CEXA5 = ._CEXA5
          myTXMVA._OCLS = ._OCLS
          myTXMVA._OMAKE = ._OMAKE
          myTXMVA._OYEAR = ._OYEAR
          myTXMVA._OMOD = ._OMOD
          myTXMVA._OBODY = "" '._OBODY
          myTXMVA._OREGNo = ._OREGNO
          myTXMVA._OVIN = ._OVIN
          myTXMVA._OASS = ._OASS
          myTXMVA._OVAL = ._OVAL
          myTXMVA._OPVAL = ._OPVAL
          myTXMVA._PNET = ._PNET
          myTXMVA._OLIST = ._OLIST
          myTXMVA._DOB = ._DOB
          myTXMVA._SSNo = ._SSNO
          myTXMVA._SS2 = ._SS2
          myTXMVA._OID = ._OID
          myTXMVA._BTC = ._BTC
          myTXMVA._LEASE = ._LEASE
          myTXMVA._ORIG = ._ORIG
          myTXMVA._TRVAL = ._TRVAL
          myTXMVA._LNVAL = ._LNVAL
          myTXMVA._MSRP = ._MSRP
          myTXMVA._NADA = ._NADA
          myTXMVA._LETT = ._LETT
          myTXMVA._TYPE = ._TYPE
          myTXMVA._TIN = ._TIN
          myTXMVA._RAD1 = ._RAD1
          myTXMVA._RAD2 = ._RAD2
          myTXMVA._RCTY = ._RCTY
          myTXMVA._RST = ._RST
          myTXMVA._RZ5 = ._RZ5
          myTXMVA._RZ4 = ._RZ4
          myTXMVA._LOC = ._LOC
          myTXMVA._LOCNO = ._LOCNO
          myTXMVA._PRF = ._PRF
          myTXMVA._CHDATE = ._CHDATE
          myTXMVA._CHTIME = ._CHTIME
          myTXMVA.AddOneRecordP()
          If myTXMVA.ErrMsg <> "" Then
            WriteErrorLog(myTXMVA.ErrMsg)
            Exit Sub
          End If
        End If
      End With

NextRec:
      With MyFrmProgress
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

    MyFrmProgress.Close()
    myTXMVDCQ.CloseFile()

  End Sub
End Module






