Imports System.Text
Imports System.IO
Public Class FrmAvon
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTOWN As TOWN
  Dim MyTXCODE As TXCODE
  Dim MyTXCOEA As TXCOEA
  Dim MyTXMRATE As TXMRATE
  Dim MyTXPROF As TXPROF
  Dim MyTXTYPE As TXTYPE
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyTXREAL As TXREAL
  Dim MyTXPPRP As TXPPRP
  Dim MyTXMVD As TXMVD
  Dim MyTXSUPP As TXSUPP
  Dim MyTXPPRA As TXPPRA
  Dim MyTXVEH As TXVEH
  Dim MyTXVCUS As TXVCUS
  Dim MyTXVCLS As TXVCLS
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTAS As UTCUSTAS
  Dim MyUTCUSTRT As UTCUSTRT
  Dim MyUTXREF As UTXREF
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkCity As String
  Dim WrkLoc As String
  Dim WrkLocNo As String
  Dim WrkState As String
  Dim WrkFile As String
  Public WrkTXCode(100) As Integer
  Public WrkTXGrp(100) As String
  Dim ProfYear(250) As Integer
  Dim ProfType(250) As String
  Dim ProfNumBills(250) As Integer
  Const cAssPct As Decimal = 0.7
  Const cClassicVehicle As Integer = 500
  Const cMinValue As Integer = 200
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
    TxtGLYear.Text = "2022"
  End Sub
  Private Sub InitFiles()
    MyTOWN = New TOWN(myDBConnect2.MyConn2)
    'MyTXCODE = New TXCODE(myDBConnect2.MyConn2)
    'MyTXCOEA = New TXCOEA(myDBConnect2.MyConn2)
    'MyTXMRATE = New TXMRATE(myDBConnect2.MyConn2)
    'MyTXMVD = New TXMVD(myDBConnect2.MyConn2)
    'MyTXPPRP = New TXPPRP(myDBConnect2.MyConn2)
    'MyTXPROF = New TXPROF(myDBConnect2.MyConn2)
    MyTXREAL = New TXREAL(myDBConnect2.MyConn2)
    'MyTXPPRA = New TXPPRA(myDBConnect2.MyConn2)
    'MyTXTYPE = New TXTYPE(myDBConnect2.MyConn2)
    'MyTXVCLS = New TXVCLS(myDBConnect2.MyConn2)
    MyTXINV = New TXINV(myDBConnect2.MyConn2)
    MyTXHST = New TXHST(myDBConnect2.MyConn2)
    MyUTCUST = New UTCUST(myDBConnect2.MyConn2)
    MyUTCUSTAS = New UTCUSTAS(myDBConnect2.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnect2.MyConn2)
    'MyUTXREF = New UTXREF(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvAvon.csv")
    ProgBar1.Visible = True
    WrkGLYear = CnvSng(TxtGLYear.Text)
    With MyTOWN
      .GetOneRecordP(1)
    End With
    WriteUTAS2()
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub

  Private Sub Donotrun()
    'WriteTOWN()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "PROF" & vbCrLf
    'WriteMRATE_PROF()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TYPE" & vbCrLf
    'WriteTYPE("TAX_BILL_TYPES")
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "INVup" & vbCrLf
    'UpdateINV(False)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "INVup2" & vbCrLf
    'UpdateINV(True)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "INVup" & vbCrLf
    'WriteINV(False)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "INVup2" & vbCrLf
    'WriteINV(True)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "INV" & vbCrLf
    'WriteINV(False)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "HST" & vbCrLf
    'WriteHST_COEA(False)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "PrvINV" & vbCrLf
    'WriteINV(True)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "PrvHST" & vbCrLf
    'WriteHST_COEA(True)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "DlqINV" & vbCrLf
    'WriteDlqINV()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "DlqHST" & vbCrLf
    'WriteDlqHST_COEA()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "CC" & vbCrLf
    'CheckCC()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "REC" & vbCrLf
    'WriteREC()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "PP" & vbCrLf
    'WritePP()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "PPA" & vbCrLf
    'WritePPA()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "MV" & vbCrLf
    'UpdateMV()
    'WriteMV("TXMVD", WrkGLYear)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "SU" & vbCrLf
    'WriteSU("TXSUPP", WrkGLYear - 1)
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "VCLS" & vbCrLf
    'WriteVCLS()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "VCUS" & vbCrLf
    'WriteVEH_VCUS("MOTOR_CIVLS")
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UT" & vbCrLf
    'WriteUT()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UT2" & vbCrLf
    'WriteUT2()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTAS" & vbCrLf
    'WriteUTAS()
    'UpdateUTAS()
    'MsgBox("Run Real to UB Bridge to add records to UTCUST", MsgBoxStyle.Information, "Conversion")
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTXREF" & vbCrLf
    'WriteUTXREF()
  End Sub

  Private Sub SplitCityST(ByVal WrkCityST As String)
    Dim Pos As Integer
    WrkCity = ""
    WrkState = ""
    WrkCityST = Replace(WrkCityST, "  ", " ")
    WrkCityST = Replace(WrkCityST, ",", " ")
    WrkCityST = Replace(WrkCityST, ".", "")
    WrkCityST = Replace(WrkCityST, " CONN", " CT")
    WrkCityST = Replace(WrkCityST, " TEXAS", " TX")
    WrkCityST = Replace(WrkCityST, " INDIANA,", " IN")
    Pos = InStrRev(WrkCityST, " ")
    If Len(WrkCityST) = Pos + 2 Then
      WrkCity = Mid(WrkCityST, 1, Pos - 1)
      WrkState = Mid(WrkCityST, Pos + 1, 2)
    Else
      WrkCity = WrkCityST
      WrkState = ""
    End If
  End Sub
  Private Sub SplitLoc(ByVal WrkStr As String)
    Dim Pos As Integer
    WrkLoc = ""
    WrkLocNo = ""
    Pos = InStr(WrkStr, " ")
    If Pos > 0 Then
      WrkLocNo = Mid(WrkStr, 1, Pos - 1)
      WrkLocNo = JustifyRight(WrkLocNo, 7)
      WrkLoc = Mid(WrkStr, Pos + 1, 25)
    Else
      WrkLoc = WrkStr
      WrkLocNo = ""
    End If
  End Sub

  Private Sub WriteTOWN()
    'Dim ds As DataSet = New DataSet
    'Dim I As Integer
    'myDBConnect2.DeleteRecords2("TOWN")
    'I = 0
    'With MyTOWN
    '  .GetOneRecordP(1)
    '  ._ADDR1 = ds.Tables(0).Rows(I).Item("street")
    '  ._ADDR2 = ""
    '  ._ASSR = ds.Tables(0).Rows(I).Item("assr_name")
    '  ._CEREC = ""
    '  ._CITY = ds.Tables(0).Rows(I).Item("city")
    '  ._CLERK = ""
    '  ._COLCTR = ""
    '  ._COUNTY = ""
    '  ._PHONE = ""
    '  ._RECCOD = ""
    '  ._TOWN = ds.Tables(0).Rows(I).Item("town_title")
    '  ._TOWNBR = ds.Tables(0).Rows(I).Item("town_code")
    '  ._ZIP = ds.Tables(0).Rows(I).Item("zip1")
    '  .AddOneRecordP()
    '  If .ErrMsg <> String.Empty Then
    '    sw.WriteLine("TOWN " & .ErrMsg)
    '  End If
    'End With
    'ds = Nothing
  End Sub
  Private Sub WriteMRATE_PROF()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileMRATE, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkYear As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    myDBConnect2.DeleteRecords2("TXMRATE")
    '    myDBConnect2.DeleteRecords2("TXPROF")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      GoTo WrapUp
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    With MyTXMRATE
    '      WrkYear = CnvSng(RecArray(0))
    '      If WrkYear = 9999 Then GoTo NextLine
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkYear, "", 0)
    '      If .RecordNotFound Then
    '        ._DIST = 0
    '        ._MRDESC = "TOWN WIDE"
    '        ._MRFIRE = 0
    '        ._MRRATE = CnvSng(RecArray(1)) / 1000
    '        ._TYPE = ""
    '        ._YEAR = WrkYear
    '        .AddOneRecordP()
    '        If .ErrMsg <> String.Empty Then
    '          sw.WriteLine("TXMRATE " & "" & WrkYear & " " & .ErrMsg)
    '        End If
    '      End If
    '    End With
    '    WritePROF("M", WrkYear, RecArray(3), RecArray(4))
    '    WritePROF("P", WrkYear, RecArray(3), RecArray(4))
    '    WritePROF("R", WrkYear, RecArray(3), RecArray(4))
    '    WritePROF("X", WrkYear, RecArray(3), RecArray(4))
    '    WritePROF("S", WrkYear, RecArray(4), #1/1/1900#)

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '.Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine

    'WrapUp:
    '    WritePROF("C", 2023, #4/1/2023#, #10/1/2023#)
  End Sub
  Private Sub WritePROF(ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkDate1 As Date, ByVal WrkDate2 As Date)
    'Dim WrkDate As Date
    'With MyTXPROF
    '  .GetOneRecordP(WrkType, WrkYear, "", 0)
    '  If .RecordNotFound Then
    '    ._DIST = 0
    '    ._PHS = ""
    '    ._POSTED = "Y"
    '    If WrkDate2 = #1/1/1900# Then
    '      ._PRPERD = 1
    '      ._PRDUE1 = ConvertDateMDY(WrkDate1)
    '      ._PRDUE2 = 0
    '      WrkDate = DateAdd(DateInterval.Month, 1, WrkDate1)
    '      ._PRGRD1 = ConvertDateMDY(WrkDate)
    '      ._PRGRD2 = 0
    '    Else
    '      ._PRPERD = 2
    '      ._PRDUE1 = ConvertDateMDY(WrkDate1)
    '      ._PRDUE2 = ConvertDateMDY(WrkDate2)
    '      WrkDate = DateAdd(DateInterval.Month, 1, WrkDate1)
    '      ._PRGRD1 = ConvertDateMDY(WrkDate)
    '      WrkDate = DateAdd(DateInterval.Month, 1, WrkDate2)
    '      ._PRGRD2 = ConvertDateMDY(WrkDate)
    '    End If
    '    ._PRDUE3 = 0
    '      ._PRDUE4 = 0
    '      ._PRGRD3 = 0
    '      ._PRGRD4 = 0
    '      ._PRINT = 0.015
    '      ._PRLIEN = 24
    '      ._PRMINI = 2.0
    '      ._PRPAYC = "UE"
    '      ._PRPENI = 0
    '      ._PRSBIL = 0
    '      ._PRTYPE = WrkType
    '      ._PRWAV = 0
    '      ._PRYEAR = WrkYear
    '      .AddOneRecordP()
    '      If .ErrMsg <> String.Empty Then
    '        sw.WriteLine("TXPROF " & "" & WrkYear & " " & .ErrMsg)
    '      End If
    '    End If
    'End With
  End Sub
  Private Sub WriteTYPE()
    'Dim ds As DataSet = New DataSet
    'Dim WrkType As String
    'Dim I As Integer
    'Dim WrkPct As Decimal
    'Dim SavePct As Decimal
    'Dim Counter As Decimal
    'myDBConnect2.DeleteRecords2("TXTYPE")
    'For I = 0 To ds.Tables(0).Rows.Count - 1
    '  With MyTXTYPE
    '    Counter = Counter + 1
    '    WrkType = GetTaxType(ds.Tables(0).Rows(I).Item("bill_type"))
    '    .GetOneRecordP(WrkType)
    '    If .RecordNotFound Then
    '      ._TXFAM = GetTaxFamily(ds.Tables(0).Rows(I).Item("bill_type"))
    '      ._TXREV = ""
    '      ._TYCODE = WrkType
    '      If Trim(ds.Tables(0).Rows(I).Item("long_type_desc")) <> "" Then
    '        ._TYDESC = ds.Tables(0).Rows(I).Item("long_type_desc")
    '      Else
    '        ._TYDESC = ds.Tables(0).Rows(I).Item("type_desc")
    '      End If
    '      .AddOneRecordP()
    '      If .ErrMsg <> String.Empty Then
    '        sw.WriteLine("TXTYPE " & WrkType & " " & .ErrMsg)
    '      End If
    '    End If
    '  End With

    '  WrkPct = (Counter / 10) Mod 100
    '  If SavePct <> WrkPct Then
    '    ProgBar1.Value = WrkPct
    '    LblMsg.Text = "Records processed: " & Counter
    '    '.Refresh()
    '    SavePct = WrkPct
    '    Application.DoEvents()
    '  End If
    'Next
    'ds = Nothing
  End Sub
  Private Sub BufferProf()
    Dim ds As DataSet = New DataSet
    For I = 0 To ds.Tables(0).Rows.Count - 1
      ProfType(I) = GetTaxType(ds.Tables(0).Rows(I).Item("mill_type"))
      ProfYear(I) = ds.Tables(0).Rows(I).Item("mill_year")
      ProfNumBills(I) = ds.Tables(0).Rows(I).Item("mill_no_of_inst")
    Next
    ds = Nothing

  End Sub
  Private Function LookupProf(ByVal Year As Integer, ByVal Type As String) As Integer
    Dim I As Integer

    For I = 0 To ProfYear.GetUpperBound(0)
      If ProfYear(I) = 0 Then
        Return -1
      End If
      If Year = ProfYear(I) And Type = ProfType(I) Then
        Return I
      End If
    Next

    Return I
  End Function
  Private Sub WriteINV(ByVal UseOld As Boolean)
    '    Dim WrkStream As FileStream
    '    Dim sr As StreamReader
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkType As String
    '    Dim WrkYear As Integer
    '    Dim WrkEldBen As Decimal
    '    Dim WrkDate As Integer
    '    Dim WrkAdj As Boolean
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim WrkStr As String
    '    Dim Pos As Integer
    '    Dim I As Integer

    '    WrkFile = "INV"
    '    If UseOld Then
    '      WrkStream = New FileStream(MyAppSettings.FilePrvINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Else
    '      WrkStream = New FileStream(MyAppSettings.FileINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '      'myDBConnect2.DeleteRecords2("TXINV")
    '    End If
    '    sr = New StreamReader(WrkStream)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = Replace(sr.ReadLine, "'", "")
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    If CnvSng(RecArray(50)) > 0 Then
    '      WrkListNo = CnvSng(RecArray(50))
    '    Else
    '      WrkListNo = CnvListNoAlpha(RecArray(49))
    '    End If
    '    If WrkListNo = 0 Then
    '      GoTo ShowPct
    '    End If
    '    SplitCityST(Trim(RecArray(5)))
    '    With MyTXINV
    '      Counter = Counter + 1
    '      WrkType = GetTaxType(Trim(RecArray(51)))
    '      WrkYear = RecArray(1)
    '      If WrkType <> "U" Then
    '        GoTo ShowPct
    '      End If
    '      ._ABAT = 0
    '      ._ACD = ""
    '      ._ACCTN = ""
    '      ._ADATE = 0
    '      ._ADD1 = ConvertString("Add1", RecArray(4), 35)
    '      ._ADD2 = ConvertString("Add2", "", 35)
    '      ._AGY = ""
    '      ._ASS = ""
    '      ._BKCD = ""
    '      ._BKSR = ""
    '      ._BODY = ""
    '      ._BOND = 0
    '      ._BONDP = 0
    '      ._BONT = 0
    '      ._CASS1 = 0
    '      ._CASS2 = 0
    '      ._CASS3 = 0
    '      ._CASS4 = 0
    '      ._CASS5 = 0
    '      ._CASS6 = 0
    '      ._CASS7 = 0
    '      ._CASS8 = 0
    '      ._CASS9 = 0
    '      ._CASS10 = 0
    '      ._CCCD1 = ""
    '      ._CCCD2 = ""
    '      ._CCCD3 = ""
    '      ._CCCD4 = ""
    '      ._CCCD5 = ""
    '      ._CCCD6 = ""
    '      ._CCCD7 = ""
    '      ._CCM = ""
    '      If Trim(RecArray(42)) <> "" Then
    '        ._CDATE = ConvertDate(RecArray(42))
    '      Else
    '        ._CDATE = 0
    '      End If
    '      WrkDate = CnvSng((WrkYear + 1) & "0701")
    '      WrkEldBen = CnvSng(RecArray(13))
    '      ._CCNO = 0
    '      ._CCRSN = ""
    '      ._CCTX1 = 0
    '      ._CCTX2 = 0
    '      ._CCTX3 = 0
    '      ._CCTX4 = 0
    '      ._CCETAX = 0
    '      ._CCEXP = 0
    '      ._CEODC = ""
    '      ._CEXA1 = 0
    '      ._CEXA2 = 0
    '      ._CEXA3 = 0
    '      ._CEXA4 = 0
    '      ._CEXA5 = 0
    '      ._CEXA6 = 0
    '      ._CEXA7 = 0
    '      ._CGRS = 0
    '      ._CHDATE = 0
    '      WrkAdj = False
    '      If WrkType <> "X" Then
    '        If CnvSng(RecArray(31)) + CnvSng(RecArray(32)) <> 0 Or RecArray(40) > 0 Then
    '          If ._CDATE < WrkDate Then
    '            WrkAdj = True
    '            GoTo SkipCC
    '          End If
    '          If RecArray(40) > 0 Then
    '            ._CCNO = CnvSng(RecArray(40))
    '            ._CCRSN = "U"
    '          Else
    '            ._CCNO = 99999
    '            ._CCRSN = "C"
    '          End If
    '          ._CCTX1 = CnvSng(RecArray(27)) + CnvSng(RecArray(31))
    '          ._CCTX2 = CnvSng(RecArray(28)) + CnvSng(RecArray(32))
    '          ._CCTX3 = 0
    '          ._CCTX4 = 0
    '          ._CCETAX = ._CCTX1 + ._CCTX2
    '        End If
    '      End If
    'SkipCC:
    '      ._CHTIME = 0
    '      ._CIRAD = 0
    '      ._CITY = ConvertString("City", WrkCity, 25)
    '      ._CLASS = 0 ' CnvSng(RecArray(25))
    '      ._CMAX = 0
    '      ._CMIN = 0
    '      ._CMVDC = ""
    '      ._CPERC = 0
    '      ._DECD = ""
    '      ._DIST = 0
    '      If Trim(RecArray(43)) <> "" Then
    '        ._DOB = ConvertDate(RecArray(43))
    '      Else
    '        ._DOB = 0
    '      End If
    '      ._ETC1 = ""
    '      ._ETC2 = ""
    '      ._ETC3 = ""
    '      ._ETC4 = ""
    '      ._ETC5 = ""
    '      ._ETC6 = ""
    '      ._ETC7 = ""
    '      ._ETC8 = ""
    '      ._ETC9 = ""
    '      ._ETCA = ""
    '      ._EXAM1 = CnvSng(RecArray(14))
    '      ._EXAM2 = 0
    '      ._EXAM3 = 0
    '      ._EXAM4 = 0
    '      ._EXAM5 = 0
    '      ._EXAM6 = 0
    '      ._EXAM7 = 0
    '      ._EXCD1 = ""
    '      ._EXCD2 = ""
    '      ._EXCD3 = ""
    '      ._EXCD4 = ""
    '      ._EXCD5 = ""
    '      ._EXCD6 = ""
    '      ._EXCD7 = ""
    '      ._FASS = 0
    '      ._FEC1 = ""
    '      ._FEC2 = ""
    '      ._FEC3 = ""
    '      ._FEC4 = ""
    '      ._FEC5 = ""
    '      ._FED1 = 0
    '      ._FED2 = 0
    '      ._FED3 = 0
    '      ._FED4 = 0
    '      ._FED5 = 0
    '      If WrkEldBen > 0 Then
    '        ._FRCD = "C"
    '        ._FRYR = WrkYear
    '        ._FTAX = WrkEldBen
    '      Else
    '        ._FRCD = ""
    '        ._FRYR = 0
    '        ._FTAX = 0
    '      End If
    '      ._GROSS = CnvSng(RecArray(15))
    '      ._ICODE = ""
    '      ._ICVACD = ""
    '      ._ICVCLS = 0
    '      ._ICVGRS = 0
    '      ._ICVIDNo = ""
    '      ._ICVMKE = ""
    '      ._ICVMOD = ""
    '      ._ICVREG = ""
    '      ._ICVYR = 0
    '      ._ILEASE = ""
    '      ._IMVIDNo = ConvertString("VIN", RecArray(24), 17)
    '      ._IMVREG = ConvertString("Regno", RecArray(23), 7)
    '      ._INPCT = 0
    '      ._INTPD = CnvSng(RecArray(29)) + CnvSng(RecArray(30))
    '      ._INTY = 0
    '      ._IPPCD1 = 0
    '      ._IPPCD2 = 0
    '      ._IPPCD3 = 0
    '      ._IPPCD4 = 0
    '      ._IPPCD5 = 0
    '      ._IPPCD6 = 0
    '      ._IPPCD7 = 0
    '      ._IPPCD8 = 0
    '      ._IPPCD9 = 0
    '      ._IPPCDA = 0
    '      ._LETT = Mid(RecArray(2), 1, 1)
    '      ._LIEN = ""
    '      ._LISTNo = WrkListNo
    '      ._LNPD = CnvSng(RecArray(34))
    '      Select Case Trim(RecArray(51))
    '        Case "P"
    '          ._LOC = ConvertString("Loc", Mid(RecArray(18), 6, 40), 25)
    '          ._LOCNo = JustifyRight(CnvSng(Mid(RecArray(18), 1, 4)), 7)
    '        Case "R"
    '          ._LOC = ConvertString("Loc", Mid(RecArray(17), 7, 40), 25)
    '          ._LOCNo = JustifyRight(CnvSng(Mid(RecArray(17), 1, 5)), 7)
    '        Case Else
    '          ._LOC = ""
    '          ._LOCNo = ""
    '      End Select
    '      If CnvSng(._LOCNo) = 0 Then ._LOCNo = ""
    '      ._MAKE = Mid(RecArray(22), 1, 5)
    '      ._MAP = Trim(RecArray(21))
    '      ._MODEL = ""
    '      ._MVFLAG = ""
    '      ._MVYR = CnvSng(RecArray(26))
    '      ._NAME = ConvertString("Name", RecArray(2), 35)
    '      ._NEWPAY = 0
    '      ._SNAME = ConvertString("Sname", RecArray(3), 35)
    '      ._OAS1 = 0
    '      ._OAS10 = 0
    '      ._OAS2 = 0
    '      ._OAS3 = 0
    '      ._OAS4 = 0
    '      ._OAS5 = 0
    '      ._OAS6 = 0
    '      ._OAS7 = 0
    '      ._OAS8 = 0
    '      ._OAS9 = 0
    '      If CnvSng(RecArray(60)) <> 0 Then
    '        ._OID = CnvSng(RecArray(60))
    '      Else
    '        ._OID = ""
    '      End If
    '      ._PCD = ""
    '      If WrkType = "X" Then
    '        If Trim(RecArray(42)) <> "" Then
    '          ._PDAT = ConvertDate(RecArray(42))
    '          ._CDATE = 0
    '        Else
    '          ._PDAT = WrkDate
    '          ._CDATE = 0
    '        End If
    '      Else
    '        ._PDAT = 0
    '      End If
    '      ._PDST = 0
    '      ._PHASE = 0
    '      ._PINPD = ""
    '      ._PDST = 0
    '      ._PRF = ""
    '      ._PRINT = 0
    '      ._PRLIN = 0
    '      ._PRPRI = 0
    '      ._RLST = CnvSng(RecArray(0))
    '      ._SS2 = CnvSng(RecArray(59))
    '      ._SSNo = CnvSng(RecArray(58))
    '      ._STATE = WrkState
    '      ._STCD1 = ""
    '      ._STCD2 = ""
    '      ._STCD3 = ""
    '      ._STCD4 = ""
    '      ._STCD5 = ""
    '      ._SUSCD = ""
    '      ._SUSDT = 0
    '      ._TIN = ""
    '      ._TOTEXP = 0
    '      ._TWNBN = 0
    '      If Trim(RecArray(41)) <> "" Then
    '        ._TXIDT = ConvertDate(RecArray(41))
    '      Else
    '        ._TXIDT = 0
    '      End If
    '      ._TXINT = 0
    '      ._TYPE = WrkType
    '      ._UNIT1 = 0
    '      ._UNIT2 = 0
    '      ._UNIT3 = 0
    '      ._UNIT4 = 0
    '      ._UNIT5 = 0
    '      ._UNIT6 = 0
    '      ._UNIT7 = 0
    '      ._UNIT8 = 0
    '      ._UNIT9 = 0
    '      ._UNITA = 0
    '      WrkStr = Trim(RecArray(20))
    '      Pos = InStr(WrkStr, "/")
    '      If Pos > 0 Then
    '        ._VOL = Mid(WrkStr, 1, Pos - 1)
    '        ._IPAGE = Mid(WrkStr, Pos + 1, 4)
    '      Else
    '        ._VOL = ""
    '        ._IPAGE = ""
    '      End If
    '      ._XDATE = 0
    '      ._YEAR = CnvSng(RecArray(1))
    '      ._ZIP4 = CnvSng(RecArray(7))
    '      ._ZIP5 = CnvSng(RecArray(6))
    '      ._NETASS = ._GROSS - ._EXAM1
    '      If WrkType <> "S" Then
    '        ._TAX1 = CnvSng(RecArray(27))
    '        ._TAX2 = CnvSng(RecArray(28))
    '      Else
    '        ._TAX1 = CnvSng(RecArray(28))
    '        ._TAX2 = 0
    '      End If
    '      If WrkType = "X" Or WrkAdj Then
    '          ._TAX1 = CnvSng(RecArray(27)) + CnvSng(RecArray(31))
    '          ._TAX2 = CnvSng(RecArray(28)) + CnvSng(RecArray(32))
    '          If WrkType <> "X" Then
    '            If RecArray(40) > 0 Then
    '              ._CCM = "CC " & ._CDATE
    '            Else
    '              ._CCM = "Adjusted"
    '            End If
    '            ._CDATE = 0
    '          End If
    '        End If
    '        ._TX3RD = 0
    '      ._TX4TH = 0
    '      ._TAXT = ._TAX1 + ._TAX2
    '      ._PAYREC = CnvSng(RecArray(35)) + CnvSng(RecArray(36))
    '      If ._CCNO > 0 Then
    '        ._BALD = ._CCETAX - ._PAYREC
    '      Else
    '        ._BALD = ._TAXT - ._PAYREC
    '      End If
    '      .InsertOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine(WrkFile & ",error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
    '      End If
    '    End With

    'ShowPct:
    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub UpdateINV(ByVal UseOld As Boolean)
    '    Dim WrkStream As FileStream
    '    Dim sr As StreamReader
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkType As String
    '    Dim WrkYear As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "INV"
    '    If UseOld Then
    '      WrkStream = New FileStream(MyAppSettings.FilePrvINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Else
    '      WrkStream = New FileStream(MyAppSettings.FileINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '      'myDBConnect2.DeleteRecords2("TXINV")
    '    End If
    '    sr = New StreamReader(WrkStream)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = Replace(sr.ReadLine, "'", "")
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    If CnvSng(RecArray(50)) > 0 Then
    '      WrkListNo = CnvSng(RecArray(50))
    '    Else
    '      WrkListNo = CnvListNoAlpha(RecArray(49))
    '    End If
    '    If WrkListNo = 0 Then
    '      GoTo ShowPct
    '    End If
    '    SplitCityST(Trim(RecArray(5)))
    '    With MyTXINV
    '      Counter = Counter + 1
    '      WrkType = GetTaxType(Trim(RecArray(51)))
    '      WrkYear = RecArray(1)
    '      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
    '      If WrkType = "M" Or WrkType = "S" Then
    '        If CnvSng(RecArray(60)) <> 0 Then
    '          ._OID = CnvSng(RecArray(60))
    '        Else
    '          ._OID = ""
    '        End If
    '        ._SS2 = CnvSng(RecArray(59))
    '        ._SSNo = CnvSng(RecArray(58))
    '        .UpdateOneRecordP()
    '        If .ErrMsg <> "" Then
    '          sw.WriteLine(WrkFile & ",error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
    '        End If
    '      End If
    '    End With

    'ShowPct:
    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteHST_COEA(ByVal UseOld As Boolean)
    '    Dim WrkStream As FileStream
    '    Dim sr As StreamReader
    '    Const cMaxInt As Decimal = 99999.99
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkType As String
    '    Dim WrkAssrList As Integer
    '    Dim WrkYear As Integer
    '    Dim WrkRecID As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "HST"
    '    If UseOld Then
    '      WrkStream = New FileStream(MyAppSettings.FilePrvHST, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Else
    '      WrkStream = New FileStream(MyAppSettings.FileHST, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '      'myDBConnect2.DeleteRecords2("TXCOEA")
    '      'myDBConnect2.DeleteRecords2("TXHST")
    '    End If
    '    sr = New StreamReader(WrkStream)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    '    Counter = MyTXHST.AutoGenKey - 1

    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    WrkAssrList = CnvSng(RecArray(0))
    '    WrkYear = CnvSng(RecArray(15))
    '    MyTXINV.GetAssrListNo(WrkAssrList, WrkYear)
    '    If MyTXINV.RecordNotFound Then
    '      sw.WriteLine(WrkFile & ",missing:," & WrkAssrList & " " & WrkYear)
    '      GoTo NextLine
    '    End If
    '    WrkListNo = MyTXINV._LISTNo
    '    WrkType = MyTXINV._TYPE
    '    If WrkType <> "U" Then
    '      GoTo ShowPct
    '    End If
    '    If CnvSng(RecArray(11)) > 0 Then 'C/C History records write to TXCOEA
    '      MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    '      If MyTXINV._CCNO > 0 Then
    '        With MyTXCOEA
    '          .GetOneRecordP(CnvSng(RecArray(11)))
    '          If Not MyTXCOEA.RecordNotFound Then
    '            sw.WriteLine("TXCOEA dup:," & WrkAssrList & " " & WrkYear)
    '            GoTo NextLine
    '          End If
    '          ._ASS1 = MyTXINV._GROSS
    '          ._CCNO = CnvSng(RecArray(11))
    '          ._CDATE = MyTXINV._CDATE
    '          ._CDESC = Mid(RecArray(10), 1, 25)
    '          ._CETAX = MyTXINV._CCETAX
    '          ._CHDATE = SetDBDate(RecArray(1))
    '          ._CGRS = MyTXINV._GROSS
    '          ._CHTIME = 0
    '          ._CTXOV = "N"
    '          ._CNETAS = MyTXINV._NETASS + CnvSng(RecArray(13))
    '          ._GRCHG = CnvSng(RecArray(13))
    '          ._LISTNo = WrkListNo
    '          ._NAME = MyTXINV._NAME
    '          ._TYPE = WrkType
    '          ._YEAR = WrkYear
    '          ._RSNCD = "U"
    '          .AddOneRecordP()
    '        End With
    '      End If
    '    End If

    '    With MyTXHST
    '      Counter = Counter + 1
    '      WrkRecID = Counter
    '      Select Case Trim(RecArray(3))
    '        Case "A"
    '          ._ADJCD = "A"
    '        Case "R"
    '          ._ADJCD = "R"
    '        Case Else
    '          ._ADJCD = ""
    '      End Select
    '      ._BATCHA = ""
    '      ._BATCHN = CnvSng(RecArray(14))
    '      ._BATCHS = CnvSng(RecArray(12))
    '      ._CASH = 0
    '      If Trim(RecArray(1)) <> "" Then
    '        ._CDATE = ConvertDate(RecArray(1))
    '      Else
    '        ._CDATE = 0
    '      End If
    '      If Trim(RecArray(1)) <> "" Then
    '        ._CHDATE = ConvertDate(RecArray(1))
    '      Else
    '        ._CHDATE = 0
    '      End If
    '      ._CHECK = 0
    '      ._CHTIME = 0
    '      ._COMM = Mid(RecArray(10), 1, 20)
    '      ._CORC = ""
    '      ._CREDIT = 0
    '      ._DIST = 0
    '      If CnvSng(RecArray(5)) + CnvSng(RecArray(7)) <= cMaxInt Then
    '        ._IAMT = CnvSng(RecArray(5)) + CnvSng(RecArray(7))
    '      Else
    '        ._IAMT = cMaxInt
    '        sw.WriteLine(WrkFile & ",HST Iamt:," & CnvSng(RecArray(5)) + CnvSng(RecArray(7)))
    '      End If
    '      ._INTOR = 0
    '      ._LAMT = CnvSng(RecArray(8))
    '      ._LISTNO = WrkListNo
    '      ._PAMT = CnvSng(RecArray(4)) + CnvSng(RecArray(6))
    '      ._PCAMT = CnvSng(RecArray(9))
    '      If ._ADJCD = "" Then
    '        If ._PAMT < 0 Or ._IAMT < 0 Or ._PCAMT < 0 Or ._IAMT < 0 Then
    '          ._ADJCD = "A"
    '        End If
    '      End If
    '      If Trim(RecArray(1)) <> "" Then
    '        ._PDATE = ConvertDate(RecArray(1))
    '      Else
    '        ._PDATE = 0
    '      End If
    '      If ._PCAMT <> 0 Then
    '        ._PENCD = "UK"
    '      Else
    '        ._PENCD = ""
    '      End If
    '      ._PRF = ""
    '      ._RCODE = ""
    '      ._RECID = WrkRecID
    '      ._REF = ""
    '      ._SUSCD = ""
    '      ._THAJCD = ""
    '      ._THINPD = 0
    '      ._TYPE = WrkType
    '      ._YEAR = WrkYear
    '      'Skip Pro rate adjustment history
    '      If WrkType = "X" And ._BATCHN = 0 And ._ADJCD = "A" Then
    '        GoTo NextLine
    '      End If
    '      'Skip C/C adjustment history
    '      If MyTXINV._CCNO > 0 And MyTXINV._CCNO < 99999 And ._BATCHN = 0 And ._ADJCD = "A" Then
    '        GoTo NextLine
    '      End If
    '      'Skip Homeowner benefit
    '      If Trim(._COMM) = "HOMEOWNER BENEFIT" And ._BATCHN = 0 And ._ADJCD = "A" Then
    '        GoTo NextLine
    '      End If
    '      .InsertOneRecordP()
    '    End With

    'ShowPct:
    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '.Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteDlqINV()
    '    Dim WrkStream As FileStream
    '    Dim sr As StreamReader
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkType As String
    '    Dim WrkYear As Integer
    '    Dim WrkEldBen As Decimal
    '    Dim WrkDate As Integer
    '    Dim WrkStcd1 As String
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim WrkStr As String
    '    Dim Pos As Integer
    '    Dim I As Integer

    '    WrkFile = "INV"
    '    WrkStream = New FileStream(MyAppSettings.FileDlqINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    sr = New StreamReader(WrkStream)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = Replace(sr.ReadLine, "'", "")
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    If CnvSng(RecArray(55)) > 0 Then
    '      WrkListNo = CnvSng(RecArray(55))
    '    Else
    '      WrkListNo = CnvListNoAlpha(RecArray(54))
    '    End If
    '    SplitCityST(Trim(RecArray(7)))
    '    With MyTXINV
    '      WrkType = GetTaxType(Trim(RecArray(2)))
    '      WrkYear = RecArray(0)
    '      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
    '      Counter = Counter + 1
    '      If .RecordNotFound Then
    '        ._ABAT = 0
    '        ._ACD = ""
    '        ._ACCTN = ""
    '        ._ADATE = 0
    '        WrkStcd1 = ""
    '        If Mid(RecArray(6), 1, 1) = "*" Then
    '          ._ADD1 = ConvertString("Add1", RecArray(6), 35)
    '          ._ADD1 = Replace(._ADD1, "*", "")
    '          WrkStcd1 = "N"
    '        Else
    '          ._ADD1 = ConvertString("Add1", RecArray(6), 35)
    '        End If
    '        ._ADD2 = ConvertString("Add2", "", 35)
    '        ._AGY = ""
    '        ._ASS = ""
    '        ._BKCD = ""
    '        ._BKSR = ""
    '        ._BODY = ""
    '        ._BOND = 0
    '        ._BONDP = 0
    '        ._BONT = 0
    '        ._CASS1 = 0
    '        ._CASS2 = 0
    '        ._CASS3 = 0
    '        ._CASS4 = 0
    '        ._CASS5 = 0
    '        ._CASS6 = 0
    '        ._CASS7 = 0
    '        ._CASS8 = 0
    '        ._CASS9 = 0
    '        ._CASS10 = 0
    '        ._CCCD1 = ""
    '        ._CCCD2 = ""
    '        ._CCCD3 = ""
    '        ._CCCD4 = ""
    '        ._CCCD5 = ""
    '        ._CCCD6 = ""
    '        ._CCCD7 = ""
    '        ._CCM = ""
    '        If Trim(RecArray(46)) <> "" Then
    '          ._CDATE = ConvertDate(RecArray(46))
    '        Else
    '          ._CDATE = 0
    '        End If
    '        WrkDate = CnvSng((WrkYear + 1) & "0701")
    '          WrkEldBen = CnvSng(RecArray(15))
    '          ._CCNO = 0
    '          ._CCRSN = ""
    '          ._CCTX1 = 0
    '          ._CCTX2 = 0
    '          ._CCTX3 = 0
    '          ._CCTX4 = 0
    '          ._CCETAX = 0
    '          ._CCEXP = 0
    '          ._CEODC = ""
    '          ._CEXA1 = 0
    '          ._CEXA2 = 0
    '          ._CEXA3 = 0
    '          ._CEXA4 = 0
    '          ._CEXA5 = 0
    '          ._CEXA6 = 0
    '          ._CEXA7 = 0
    '          ._CGRS = 0
    '          If (CnvSng(RecArray(37)) + CnvSng(RecArray(38))) <> 0 Or RecArray(44) > 0 Then
    '            If RecArray(44) > 0 Then
    '              ._CCNO = CnvSng(RecArray(44))
    '              ._CCRSN = "U"
    '            Else
    '              ._CCNO = 99999
    '              ._CCRSN = "U"
    '              ._CDATE = WrkDate
    '            End If
    '            ._CCTX1 = CnvSng(RecArray(33)) + CnvSng(RecArray(37))
    '            ._CCTX2 = CnvSng(RecArray(34)) + CnvSng(RecArray(38))
    '            ._CCTX3 = 0
    '            ._CCTX4 = 0
    '            ._CCETAX = ._CCTX1 + ._CCTX2
    '          End If
    '          ._CHDATE = 0
    '          ._CHTIME = 0
    '          ._CIRAD = 0
    '          ._CITY = ConvertString("City", WrkCity, 25)
    '          ._CLASS = CnvSng(RecArray(30))
    '          ._CMAX = 0
    '          ._CMIN = 0
    '          ._CMVDC = ""
    '          ._CPERC = 0
    '          ._DECD = ""
    '          ._DIST = 0
    '          If Trim(RecArray(29)) <> "" Then
    '            ._DOB = ConvertDate(RecArray(29))
    '          Else
    '            ._DOB = 0
    '          End If
    '          ._ETC1 = ""
    '          ._ETC2 = ""
    '          ._ETC3 = ""
    '          ._ETC4 = ""
    '          ._ETC5 = ""
    '          ._ETC6 = ""
    '          ._ETC7 = ""
    '          ._ETC8 = ""
    '          ._ETC9 = ""
    '          ._ETCA = ""
    '          ._EXAM1 = CnvSng(RecArray(16))
    '          ._EXAM2 = 0
    '          ._EXAM3 = 0
    '          ._EXAM4 = 0
    '          ._EXAM5 = 0
    '          ._EXAM6 = 0
    '          ._EXAM7 = 0
    '          ._EXCD1 = ""
    '          ._EXCD2 = ""
    '          ._EXCD3 = ""
    '          ._EXCD4 = ""
    '          ._EXCD5 = ""
    '          ._EXCD6 = ""
    '          ._EXCD7 = ""
    '          ._FASS = 0
    '          ._FEC1 = ""
    '          ._FEC2 = ""
    '          ._FEC3 = ""
    '          ._FEC4 = ""
    '          ._FEC5 = ""
    '          ._FED1 = 0
    '          ._FED2 = 0
    '          ._FED3 = 0
    '          ._FED4 = 0
    '          ._FED5 = 0
    '          If WrkEldBen > 0 Then
    '            ._FRCD = "C"
    '            ._FRYR = WrkYear
    '            ._FTAX = WrkEldBen
    '          Else
    '            ._FRCD = ""
    '            ._FRYR = 0
    '            ._FTAX = 0
    '          End If
    '          ._GROSS = CnvSng(RecArray(18))
    '          ._ICODE = RecArray(31) 'S=Suspense
    '          If Trim(RecArray(51)) = "X" Then 'Deleted?
    '            ._ICODE = "I"
    '          End If
    '          ._ICVACD = ""
    '          ._ICVCLS = 0
    '          ._ICVGRS = 0
    '          ._ICVIDNo = ""
    '          ._ICVMKE = ""
    '          ._ICVMOD = ""
    '          ._ICVREG = ""
    '          ._ICVYR = 0
    '          ._ILEASE = ""
    '          ._IMVIDNo = ConvertString("VIN", RecArray(27), 17)
    '          ._IMVREG = ConvertString("Regno", RecArray(26), 7)
    '          ._INPCT = 0
    '          ._INTPD = CnvSng(RecArray(35)) + CnvSng(RecArray(36))
    '          ._INTY = 0
    '          ._IPPCD1 = 0
    '          ._IPPCD2 = 0
    '          ._IPPCD3 = 0
    '          ._IPPCD4 = 0
    '          ._IPPCD5 = 0
    '          ._IPPCD6 = 0
    '          ._IPPCD7 = 0
    '          ._IPPCD8 = 0
    '          ._IPPCD9 = 0
    '          ._IPPCDA = 0
    '          ._LETT = Mid(RecArray(4), 1, 1)
    '          ._LIEN = ""
    '          ._LISTNo = WrkListNo
    '          ._LNPD = CnvSng(RecArray(39))
    '          Select Case Trim(RecArray(2))
    '            Case "P"
    '              ._LOC = ConvertString("Loc", Mid(RecArray(21), 6, 40), 25)
    '              ._LOCNo = JustifyRight(CnvSng(Mid(RecArray(21), 1, 4)), 7)
    '            Case "R"
    '              ._LOC = ConvertString("Loc", Mid(RecArray(20), 7, 40), 25)
    '              ._LOCNo = JustifyRight(CnvSng(Mid(RecArray(20), 1, 5)), 7)
    '            Case Else
    '              ._LOC = ""
    '              ._LOCNo = ""
    '          End Select
    '          If CnvSng(._LOCNo) = 0 Then ._LOCNo = ""
    '          ._MAKE = Mid(RecArray(25), 1, 5)
    '          ._MAP = Trim(RecArray(24))
    '          ._MODEL = ""
    '          ._MVFLAG = ""
    '          ._MVYR = CnvSng(RecArray(32))
    '          ._NAME = ConvertString("Name", RecArray(4), 35)
    '          ._NEWPAY = 0
    '          ._SNAME = ConvertString("Sname", RecArray(5), 35)
    '          ._OAS1 = 0
    '          ._OAS10 = 0
    '          ._OAS2 = 0
    '          ._OAS3 = 0
    '          ._OAS4 = 0
    '          ._OAS5 = 0
    '          ._OAS6 = 0
    '          ._OAS7 = 0
    '          ._OAS8 = 0
    '          ._OAS9 = 0
    '          If CnvSng(RecArray(63)) <> 0 Then
    '            ._OID = CnvSng(RecArray(63))
    '          Else
    '            ._OID = ""
    '          End If
    '          ._PCD = ""
    '          ._PDAT = 0
    '          ._PDST = 0
    '          ._PHASE = 0
    '          ._PINPD = ""
    '          ._PDST = 0
    '          ._PRF = "DLQ"
    '          ._PRINT = 0
    '          ._PRLIN = 0
    '          ._PRPRI = 0
    '          ._RLST = CnvSng(RecArray(1))
    '          ._SS2 = CnvSng(RecArray(62))
    '          ._SSNo = CnvSng(RecArray(61))
    '          ._STATE = WrkState
    '          ._STCD1 = WrkStcd1
    '          ._STCD2 = ""
    '          ._STCD3 = ""
    '          ._STCD4 = ""
    '          ._STCD5 = ""
    '          If Trim(RecArray(31)) = "S" Then 'S=Suspense
    '            ._SUSCD = "U"
    '            ._SUSDT = ConvertDate(RecArray(30))
    '          Else
    '            ._SUSCD = ""
    '            ._SUSDT = 0
    '          End If
    '          ._TIN = ""
    '          ._TOTEXP = 0
    '          ._TWNBN = 0
    '          If Trim(RecArray(45)) <> "" Then
    '            ._TXIDT = ConvertDate(RecArray(45))
    '          Else
    '            ._TXIDT = 0
    '          End If
    '          ._TXINT = 0
    '          ._TYPE = WrkType
    '          ._UNIT1 = 0
    '          ._UNIT2 = 0
    '          ._UNIT3 = 0
    '          ._UNIT4 = 0
    '          ._UNIT5 = 0
    '          ._UNIT6 = 0
    '          ._UNIT7 = 0
    '          ._UNIT8 = 0
    '          ._UNIT9 = 0
    '          ._UNITA = 0
    '          WrkStr = Trim(RecArray(23))
    '          Pos = InStr(WrkStr, "/")
    '          If Pos > 0 Then
    '            ._VOL = Mid(WrkStr, 1, Pos - 1)
    '            ._IPAGE = Mid(WrkStr, Pos + 1, 4)
    '          Else
    '            ._VOL = ""
    '            ._IPAGE = ""
    '          End If
    '          ._XDATE = 0
    '          ._YEAR = CnvSng(RecArray(0))
    '          ._ZIP4 = CnvSng(RecArray(9))
    '          ._ZIP5 = CnvSng(RecArray(8))
    '          ._NETASS = ._GROSS - ._EXAM1
    '          ._TAX1 = CnvSng(RecArray(33))
    '          ._TAX2 = CnvSng(RecArray(34))
    '          ._TX3RD = 0
    '          ._TX4TH = 0
    '          ._TAXT = ._TAX1 + ._TAX2
    '          ._PAYREC = CnvSng(RecArray(41)) + CnvSng(RecArray(42))
    '          If ._CCNO > 0 Then
    '            ._BALD = ._CCETAX - ._PAYREC
    '          Else
    '            ._BALD = ._TAXT - ._PAYREC
    '          End If
    '        .InsertOneRecordP()
    '        If .ErrMsg <> "" Then
    '            sw.WriteLine(WrkFile & " error:," & WrkListNo & " " & WrkYear & " " & WrkType & " " & .ErrMsg)
    '          End If
    '        Else
    '          If Trim(RecArray(46)) <> "" Then
    '          ._CDATE = ConvertDate(RecArray(46))
    '        End If
    '        WrkDate = CnvSng((WrkYear + 1) & "0701")
    '        If (CnvSng(RecArray(37)) + CnvSng(RecArray(38))) <> 0 Or RecArray(44) > 0 Then
    '          If RecArray(44) > 0 Then
    '            ._CCNO = CnvSng(RecArray(44))
    '            ._CCRSN = "U"
    '          Else
    '            ._CCNO = 99999
    '            ._CCRSN = "U"
    '            ._CDATE = WrkDate
    '          End If
    '        End If
    '        ._CCTX1 = CnvSng(RecArray(33)) + CnvSng(RecArray(37))
    '        ._CCTX2 = CnvSng(RecArray(34)) + CnvSng(RecArray(38))
    '        ._CCTX3 = 0
    '        ._CCTX4 = 0
    '        ._CCETAX = ._CCTX1 + ._CCTX2
    '        ._LNPD = CnvSng(RecArray(39))
    '        If Trim(RecArray(45)) <> "" Then
    '          ._TXIDT = ConvertDate(RecArray(45))
    '        Else
    '          ._TXIDT = 0
    '        End If
    '        ._PAYREC = CnvSng(RecArray(41)) + CnvSng(RecArray(42))
    '        If ._CCNO > 0 Then
    '          ._BALD = ._CCETAX - ._PAYREC
    '        Else
    '          ._BALD = ._TAXT - ._PAYREC
    '        End If
    '        ._PRF = "DLQ"
    '        .UpdateOneRecordP()
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteDlqHST_COEA()
    '    Dim WrkStream As FileStream
    '    Dim sr As StreamReader
    '    Const cMaxInt As Decimal = 99999.99
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkType As String
    '    Dim WrkAssrList As Integer
    '    Dim WrkYear As Integer
    '    Dim WrkRecID As Integer
    '    Dim WrkDate As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "HST"
    '    WrkStream = New FileStream(MyAppSettings.FileDlqHST, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    sr = New StreamReader(WrkStream)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    '    Counter = MyTXHST.AutoGenKey - 1

    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    WrkAssrList = CnvSng(RecArray(1))
    '    WrkYear = CnvSng(RecArray(0))
    '    MyTXINV.GetAssrListNo(WrkAssrList, WrkYear)
    '    If MyTXINV.RecordNotFound Then
    '      sw.WriteLine(WrkFile & ",missing:," & WrkAssrList & " " & WrkYear)
    '      GoTo NextLine
    '    End If
    '    WrkListNo = MyTXINV._LISTNo
    '    WrkType = MyTXINV._TYPE
    '    If WrkYear = 2020 And WrkType <> "U" Then
    '      WrkDate = CnvSng((WrkYear + 2) & "0701")
    '      If ConvertDate(RecArray(2)) < WrkDate Then
    '        GoTo ShowPct
    '      End If
    '    End If
    '    If CnvSng(RecArray(13)) > 0 Then 'C/C History records write to TXCOEA
    '      MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    '      With MyTXCOEA
    '        .GetOneRecordP(CnvSng(RecArray(13)))
    '        If Not MyTXCOEA.RecordNotFound Then
    '          sw.WriteLine("TXCOEA dup:," & WrkAssrList & " " & WrkYear)
    '          GoTo NextLine
    '        End If
    '        ._ASS1 = MyTXINV._GROSS
    '        ._CCNO = CnvSng(RecArray(13))
    '        ._CDATE = MyTXINV._CDATE
    '        ._CDESC = Mid(RecArray(11), 1, 25)
    '        ._CETAX = MyTXINV._CCETAX
    '        ._CHDATE = SetDBDate(RecArray(2))
    '        ._CGRS = MyTXINV._GROSS
    '        ._CHTIME = 0
    '        ._CTXOV = "N"
    '        ._CNETAS = MyTXINV._NETASS + CnvSng(RecArray(15))
    '        ._GRCHG = CnvSng(RecArray(15))
    '        ._LISTNo = WrkListNo
    '        ._NAME = MyTXINV._NAME
    '        ._TYPE = WrkType
    '        ._YEAR = WrkYear
    '        ._RSNCD = "U"
    '        ._PRF = "DLQ"
    '        .AddOneRecordP()
    '      End With
    '      GoTo NextLine
    '    End If

    '    With MyTXHST
    '      Counter = Counter + 1
    '      WrkRecID = Counter
    '      Select Case Trim(RecArray(4))
    '        Case "A"
    '          ._ADJCD = "A"
    '          ._RCODE = ""
    '        Case "R"
    '          ._ADJCD = "R"
    '          ._RCODE = ""
    '        Case "S"
    '          ._ADJCD = ""
    '          ._RCODE = "S"
    '        Case Else
    '          ._ADJCD = ""
    '          ._RCODE = ""
    '      End Select
    '      ._BATCHA = ""
    '      ._BATCHN = CnvSng(RecArray(14))
    '      ._BATCHS = CnvSng(RecArray(12))
    '      ._CASH = 0
    '      If Trim(RecArray(2)) <> "" Then
    '        ._CDATE = ConvertDate(RecArray(2))
    '      Else
    '        ._CDATE = 0
    '      End If
    '      If Trim(RecArray(2)) <> "" Then
    '        ._CHDATE = ConvertDate(RecArray(2))
    '      Else
    '        ._CHDATE = 0
    '      End If
    '      ._CHECK = 0
    '      ._CHTIME = 0
    '      ._COMM = Mid(RecArray(11), 1, 20)
    '      ._CORC = ""
    '      ._CREDIT = 0
    '      ._DIST = 0
    '      If CnvSng(RecArray(6)) + CnvSng(RecArray(8)) <= cMaxInt Then
    '        ._IAMT = CnvSng(RecArray(6)) + CnvSng(RecArray(8))
    '      Else
    '        ._IAMT = cMaxInt
    '        sw.WriteLine(WrkFile & ",HST Iamt:," & CnvSng(RecArray(6)) + CnvSng(RecArray(8)))
    '      End If
    '      ._INTOR = 0
    '      ._LAMT = CnvSng(RecArray(9))
    '      ._LISTNO = WrkListNo
    '      ._PAMT = CnvSng(RecArray(5)) + CnvSng(RecArray(7))
    '      If ._RCODE = "S" Then
    '        ._PCAMT = MyTXINV._BALD
    '      Else
    '        ._PCAMT = 0
    '      End If
    '      If ._ADJCD = "" Then
    '        If ._PAMT < 0 Or ._IAMT < 0 Or ._PCAMT < 0 Or ._IAMT < 0 Then
    '          ._ADJCD = "A"
    '        End If
    '      End If
    '      If Trim(RecArray(2)) <> "" Then
    '        ._PDATE = ConvertDate(RecArray(2))
    '      Else
    '        ._PDATE = 0
    '      End If
    '      ._PENCD = ""
    '      ._PRF = "DLQ"
    '      ._RECID = WrkRecID
    '      ._REF = ""
    '      ._SUSCD = ""
    '      ._THAJCD = ""
    '      ._THINPD = 0
    '      ._TYPE = WrkType
    '      ._YEAR = WrkYear
    '      'Skip C/C adjustment history
    '      If MyTXINV._CCNO > 0 And MyTXINV._CCNO < 99999 And ._BATCHN = 0 And ._ADJCD = "A" Then
    '        GoTo NextLine
    '      End If
    '      'Skip Homeowner benefit
    '      If CnvSng(RecArray(13)) = 0 And ._BATCHN = 0 And ._ADJCD = "A" Then
    '        GoTo NextLine
    '      End If
    '      .InsertOneRecordP()
    '    End With

    'ShowPct:
    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '.Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub CheckCC()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkType As String
    Dim WrkCCNo As Integer
    Dim WrkAssrList As Integer
    Dim WrkYear As Integer
    Dim WrkDiff As Decimal
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "CC"
    WrkStream = New FileStream(MyAppSettings.FileCC, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    Counter = Counter + 1
    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkAssrList = CnvSng(RecArray(1))
    WrkYear = CnvSng(RecArray(0))
    WrkCCNo = CnvSng(RecArray(10))
    If WrkYear < 2007 Then
      GoTo SkipRec
    End If
    If WrkCCNo = 0 Then
      GoTo SkipRec
    End If
    MyTXINV.GetAssrListNo(WrkAssrList, WrkYear)
    If MyTXINV.RecordNotFound Then
      sw.WriteLine(WrkFile & " missing:," & WrkAssrList & "," & WrkYear)
      GoTo SkipRec
    End If
    WrkListNo = MyTXINV._LISTNo
    WrkType = MyTXINV._TYPE
    With MyTXINV
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      WrkDiff = ._TAXT - ._CCETAX + CnvSng(RecArray(12)) + CnvSng(RecArray(13))
      If WrkDiff <> 0 Then
        sw.WriteLine(WrkFile & " INV Diff:," & WrkCCNo & "," & WrkYear & "," & WrkDiff)
      End If
    End With
    With MyTXCOEA
      .GetOneRecordP(WrkCCNo)
      If Not .RecordNotFound Then
        WrkDiff = MyTXINV._TAXT - ._CETAX + CnvSng(RecArray(12)) + CnvSng(RecArray(13))
        If WrkDiff <> 0 Then
          sw.WriteLine(WrkFile & " COEA Diff:," & WrkCCNo & "," & WrkYear & "," & WrkDiff)
        End If
      Else
        sw.WriteLine(WrkFile & " COEA Missing:," & WrkCCNo & "," & WrkYear)
      End If
    End With

SkipRec:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      '.Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteREC()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileRE, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkCodes(6) As Integer
    '    Dim WrkAss(6) As Integer
    '    Dim WrkAcres(6) As Decimal
    '    Dim WrkUnits(6) As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer
    '    Dim J As Integer

    '    WrkFile = "RE"
    '    BufferCodes("R")
    '    'myDBConnect2.DeleteRecords2("TXREAL")
    '    myDBConnect2.DeleteRecords2("TXREALC")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    If RecArray(10) = "" Then
    '      GoTo NextLine
    '    End If
    '    Array.Clear(WrkCodes, 0, 6)
    '    Array.Clear(WrkAss, 0, 6)
    '    Array.Clear(WrkAcres, 0, 6)
    '    Array.Clear(WrkUnits, 0, 6)
    '    J = -1
    '    If CnvSng(RecArray(37)) > 0 And CnvSng(RecArray(38)) > 0 Then
    '      J = J + 1
    '      WrkCodes(J) = RecArray(37)
    '      WrkAss(J) = CnvSng(RecArray(38))
    '      If LookupCodeGrp(WrkCodes(J)) = "B" Then
    '        WrkAcres(J) = 0
    '        WrkUnits(J) = CnvSng(RecArray(36))
    '      Else
    '        WrkAcres(J) = CnvSng(RecArray(36))
    '        WrkUnits(J) = 0
    '      End If
    '    End If
    '    If CnvSng(RecArray(40)) > 0 And CnvSng(RecArray(41)) > 0 Then
    '      J = J + 1
    '      WrkCodes(J) = RecArray(40)
    '      WrkAss(J) = CnvSng(RecArray(41))
    '      If LookupCodeGrp(WrkCodes(J)) = "B" Then
    '        WrkAcres(J) = 0
    '        WrkUnits(J) = CnvSng(RecArray(39))
    '      Else
    '        WrkAcres(J) = CnvSng(RecArray(39))
    '        WrkUnits(J) = 0
    '      End If
    '    End If
    '    If CnvSng(RecArray(43)) > 0 And CnvSng(RecArray(44)) > 0 Then
    '      J = J + 1
    '      WrkCodes(J) = RecArray(43)
    '      WrkAss(J) = CnvSng(RecArray(44))
    '      If LookupCodeGrp(WrkCodes(J)) = "B" Then
    '        WrkAcres(J) = 0
    '        WrkUnits(J) = CnvSng(RecArray(42))
    '      Else
    '        WrkAcres(J) = CnvSng(RecArray(42))
    '        WrkUnits(J) = 0
    '      End If
    '    End If
    '    If CnvSng(RecArray(46)) > 0 And CnvSng(RecArray(47)) > 0 Then
    '      J = J + 1
    '      WrkCodes(J) = RecArray(46)
    '      WrkAss(J) = CnvSng(RecArray(47))
    '      If LookupCodeGrp(WrkCodes(J)) = "B" Then
    '        WrkAcres(J) = 0
    '        WrkUnits(J) = CnvSng(RecArray(45))
    '      Else
    '        WrkAcres(J) = CnvSng(RecArray(45))
    '        WrkUnits(J) = 0
    '      End If
    '    End If
    '    If CnvSng(RecArray(49)) > 0 And CnvSng(RecArray(50)) > 0 Then
    '      J = J + 1
    '      WrkCodes(J) = RecArray(49)
    '      WrkAss(J) = CnvSng(RecArray(50))
    '      If LookupCodeGrp(WrkCodes(J)) = "B" Then
    '        WrkAcres(J) = 0
    '        WrkUnits(J) = CnvSng(RecArray(48))
    '      Else
    '        WrkAcres(J) = CnvSng(RecArray(48))
    '        WrkUnits(J) = 0
    '      End If
    '    End If

    '    SplitCityST(Trim(RecArray(20)))
    '    With MyTXREAL
    '      Counter = Counter + 1
    '      WrkListNo = RecArray(0)
    '      .GetOneRecordP(WrkListNo)
    '      ._AACRE = 0
    '      ._ACCTN = ""
    '      ._ACRE1 = WrkAcres(0)
    '      ._ACRE2 = WrkAcres(1)
    '      ._ACRE3 = WrkAcres(2)
    '      ._ACRE4 = WrkAcres(3)
    '      ._ACRE5 = WrkAcres(4)
    '      ._ACRE6 = 0
    '      ._ACRE7 = 0
    '      ._ADD1 = ConvertString("Add1", RecArray(19), 35)
    '      ._ADD2 = ConvertString("Add2", "", 35)
    '      ._AEDATE = 0
    '      ._AIDTE = 0
    '      ._ASS1 = WrkAss(0)
    '      ._ASS2 = WrkAss(1)
    '      ._ASS3 = WrkAss(2)
    '      ._ASS4 = WrkAss(3)
    '      ._ASS5 = WrkAss(4)
    '      ._ASS6 = 0
    '      ._ASS7 = 0
    '      ._BKCD = ""
    '      ._BKSV = ""
    '      ._BTC = ""
    '      ._BTR = 0
    '      ._CARD = ""
    '      ._CASS1 = 0
    '      ._CASS2 = 0
    '      ._CASS3 = 0
    '      ._CASS4 = 0
    '      ._CASS5 = 0
    '      ._CASS6 = 0
    '      ._CASS7 = 0
    '      If Trim(RecArray(2)) <> "" Then
    '        ._CAT = "3"
    '        ._EXMPT = Trim(RecArray(2))
    '      Else
    '        ._CAT = "1"
    '        ._EXMPT = ""
    '      End If
    '      ._CCCD1 = ""
    '      ._CCCD2 = ""
    '      ._CCCD3 = ""
    '      ._CCCD4 = ""
    '      ._CCCD5 = ""
    '      ._CCCD6 = ""
    '      ._CCCD7 = ""
    '      ._CCEX = 0
    '      ._CCGRS = 0
    '      ._CCNO = 0
    '      ._CCRS = ""
    '      ._CDATE = 0
    '      ._CENBK = 0
    '      ._CENTR = 0
    '      ._CEXA1 = 0
    '      ._CEXA2 = 0
    '      ._CEXA3 = 0
    '      ._CEXA4 = 0
    '      ._CEXA5 = 0
    '      ._CEXA6 = 0
    '      ._CEXA7 = 0
    '      ._CHDATE = 0
    '      ._CHTIME = 0
    '      ._CIRAD = 0
    '      ._CITY = ConvertString("City", WrkCity, 25)
    '      ._CMAX = 0
    '      ._CMIN = 0
    '      ._CODE1 = CnvSng(WrkCodes(0))
    '      ._CODE2 = CnvSng(WrkCodes(1))
    '      ._CODE3 = CnvSng(WrkCodes(2))
    '      ._CODE4 = CnvSng(WrkCodes(3))
    '      ._CODE5 = CnvSng(WrkCodes(4))
    '      ._CODE6 = 0
    '      ._CODE7 = 0
    '      ._CPERC = 0
    '      ._DIST = 0
    '      ._DNBTR = 0
    '      ._DTBTR = 0
    '      ._EXAM1 = CnvSng(RecArray(159))
    '      ._EXAM2 = CnvSng(RecArray(161))
    '      ._EXAM3 = CnvSng(RecArray(163))
    '      ._EXAM4 = CnvSng(RecArray(165))
    '      ._EXAM5 = CnvSng(RecArray(167))
    '      ._EXAM6 = 0
    '      ._EXAM7 = 0
    '      ._EXCD1 = Trim(RecArray(158))
    '      ._EXCD2 = Trim(RecArray(160))
    '      ._EXCD3 = Trim(RecArray(162))
    '      ._EXCD4 = Trim(RecArray(164))
    '      ._EXCD5 = Trim(RecArray(166))
    '      ._EXCD6 = ""
    '      ._EXCD7 = ""
    '      ._FASS = 0
    '      ._FCCOD = ""
    '      ._FCYR = 0
    '      ._FTAX = 0
    '      ._GROSS = ._ASS1 + ._ASS2 + ._ASS3 + ._ASS4 + ._ASS5
    '      ._LETT = Mid(RecArray(62), 1, 1)
    '      ._LISTNO = WrkListNo
    '      ._LOC = ConvertString("Loc", RecArray(5), 25)
    '      ._LOCNO = JustifyRight(RecArray(4), 7)
    '      ._MAP = ConvertString("Map", CnvSng(RecArray(9)), 17)
    '      RecArray(62) = Replace(Trim(RecArray(62)), "  ", " ")
    '      ._NAME = ConvertString("Name", RecArray(62), 35)
    '      RecArray(63) = Replace(Trim(RecArray(63)), "  ", " ")
    '      ._SNAME = ConvertString("Sname", RecArray(63), 35)
    '      ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5
    '      ._OID = ""
    '      ._PDST = 0
    '      ._PERC = 0
    '      ._PGE = ConvertString("Pge", RecArray(65), 5)
    '      ._PRF = ""
    '      ._PURDT = 0
    '      ._PURPR = 0
    '      ._RLST = 0
    '      ._SEWER = ""
    '      ._SMAP = ""
    '      ._SS2 = 0
    '      ._SSNO = 0
    '      ._STATE = ConvertString("State", WrkState, 2)
    '      ._TIN = ""
    '      ._TWNBN = 0
    '      ._TYPE = "R"
    '      ._UNIT1 = WrkUnits(0)
    '      ._UNIT2 = WrkUnits(1)
    '      ._UNIT3 = WrkUnits(2)
    '      ._UNIT4 = WrkUnits(3)
    '      ._UNIT5 = WrkUnits(4)
    '      ._UNIT6 = 0
    '      ._UNIT7 = 0
    '      ._UNITNO = ""
    '      ._VOL = ConvertString("Vol", RecArray(64), 5)
    '      ._VTYR = 0
    '      ._WMAIL = ""
    '      ._ZIP4 = CnvSng(RecArray(22))
    '      ._ZIP5 = CnvSng(RecArray(21))
    '      .AddOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("RE " & WrkListNo & " " & .ErrMsg)
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WritePP()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FilePP, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkCodes(6) As Integer
    '    Dim WrkAss(6) As Integer
    '    Dim WrkUnits(6) As Decimal
    '    Const cMaxAmount As Long = 9999999
    '    Dim I As Integer
    '    Dim J As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal

    '    WrkFile = "PP"
    '    myDBConnect2.DeleteRecords2("TXPPRP")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header

    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If
    '    strBuffer = Replace(strBuffer, "'", "")
    '    strBuffer = Replace(strBuffer, "21a", "21")
    '    strBuffer = Replace(strBuffer, "21b", "21")
    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    Array.Clear(WrkCodes, 0, 6)
    '    Array.Clear(WrkAss, 0, 6)
    '    Array.Clear(WrkUnits, 0, 6)
    '    SplitCityST(Trim(RecArray(5)))

    '    With MyTXPPRP
    '      Counter = Counter + 1
    '      J = -1
    '      If CnvSng(RecArray(15)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(13))
    '        WrkAss(J) = RecArray(15)
    '        WrkUnits(J) = CnvSng(RecArray(14))
    '      End If
    '      If CnvSng(RecArray(18)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(16))
    '        WrkAss(J) = RecArray(18)
    '        WrkUnits(J) = CnvSng(RecArray(17))
    '      End If
    '      If CnvSng(RecArray(21)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(19))
    '        WrkAss(J) = RecArray(21)
    '        WrkUnits(J) = CnvSng(RecArray(20))
    '      End If
    '      If CnvSng(RecArray(24)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(22))
    '        WrkAss(J) = RecArray(24)
    '        WrkUnits(J) = CnvSng(RecArray(23))
    '      End If
    '      If CnvSng(RecArray(27)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(25))
    '        WrkAss(J) = RecArray(27)
    '        WrkUnits(J) = CnvSng(RecArray(26))
    '      End If
    '      If CnvSng(RecArray(28)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = 25
    '        WrkAss(J) = RecArray(28)
    '        WrkUnits(J) = 0
    '      End If
    '      WrkListNo = RecArray(0)
    '      .GetOneRecordP(WrkListNo)
    '      ._ADD1 = ConvertString("Add1", RecArray(4), 35)
    '      ._ADD2 = ConvertString("Add2", "", 35)
    '      ._ADYR = 0
    '      ._ASS1 = WrkAss(0)
    '      ._ASS2 = WrkAss(1)
    '      ._ASS3 = WrkAss(2)
    '      ._ASS4 = WrkAss(3)
    '      ._ASS5 = WrkAss(4)
    '      ._ASS6 = WrkAss(5)
    '      ._ASS7 = WrkAss(6)
    '      ._ASS8 = 0
    '      ._ASS9 = 0
    '      ._ASS10 = 0
    '      ._BTC = ""
    '      ._BTR = 0
    '      ._BUS = ""
    '      ._BUSTY = ""
    '      ._CASS1 = 0
    '      ._CASS2 = 0
    '      ._CASS3 = 0
    '      ._CASS4 = 0
    '      ._CASS5 = 0
    '      ._CASS6 = 0
    '      ._CASS7 = 0
    '      ._CASS8 = 0
    '      ._CASS9 = 0
    '      ._CASSA = 0
    '      ._CAT = "5"
    '      ._CCCD1 = ""
    '      ._CCCD2 = ""
    '      ._CCCD3 = ""
    '      ._CCCD4 = ""
    '      ._CCCD5 = ""
    '      ._CCEX = 0
    '      ._CCGRS = 0
    '      ._CCNO = 0
    '      ._CCRS = ""
    '      ._CDATE = 0
    '      ._CEXA1 = 0
    '      ._CEXA2 = 0
    '      ._CEXA3 = 0
    '      ._CEXA4 = 0
    '      ._CEXA5 = 0
    '      ._CHDATE = 0
    '      ._CHTIME = 0
    '      ._CITY = WrkCity
    '      ._CODE1 = WrkCodes(0)
    '      ._CODE2 = WrkCodes(1)
    '      ._CODE3 = WrkCodes(2)
    '      ._CODE4 = WrkCodes(3)
    '      ._CODE5 = WrkCodes(4)
    '      ._CODE6 = WrkCodes(5)
    '      ._CODE7 = WrkCodes(6)
    '      ._CODE8 = 0
    '      ._CODE9 = 0
    '      ._CODEA = 0
    '      ._DIST = 0
    '      ._DNBTR = ""
    '      ._DTBTR = 0
    '      If CnvSng(RecArray(30)) > cMaxAmount Then
    '        ._EXAM1 = cMaxAmount
    '        sw.WriteLine("PP Exam1 " & WrkListNo & " " & CnvSng(RecArray(30)))
    '      Else
    '        ._EXAM1 = CnvSng(RecArray(30))
    '      End If
    '      If CnvSng(RecArray(32)) > cMaxAmount Then
    '        ._EXAM2 = cMaxAmount
    '        sw.WriteLine("PP Exam2 " & WrkListNo & " " & CnvSng(RecArray(32)))
    '      Else
    '        ._EXAM2 = CnvSng(RecArray(32))
    '      End If
    '      If CnvSng(RecArray(34)) > cMaxAmount Then
    '        ._EXAM3 = cMaxAmount
    '        sw.WriteLine("PP Exam3 " & WrkListNo & " " & CnvSng(RecArray(34)))
    '      Else
    '        ._EXAM3 = CnvSng(RecArray(34))
    '      End If
    '      If CnvSng(RecArray(36)) > cMaxAmount Then
    '        ._EXAM4 = cMaxAmount
    '        sw.WriteLine("PP Exam4 " & WrkListNo & " " & CnvSng(RecArray(36)))
    '      Else
    '        ._EXAM4 = CnvSng(RecArray(36))
    '      End If
    '      If CnvSng(RecArray(38)) > cMaxAmount Then
    '        ._EXAM5 = cMaxAmount
    '        sw.WriteLine("PP Exam5 " & WrkListNo & " " & CnvSng(RecArray(38)))
    '      Else
    '        ._EXAM5 = CnvSng(RecArray(38))
    '      End If
    '      ._EXCD1 = Trim(RecArray(29))
    '      ._EXCD2 = Trim(RecArray(31))
    '      ._EXCD3 = Trim(RecArray(33))
    '      ._EXCD4 = Trim(RecArray(35))
    '      ._EXCD5 = Trim(RecArray(37))
    '      ._GROSS = CnvSng(RecArray(12))
    '      ._LETT = Mid(RecArray(2), 1, 1)
    '      ._LISTNO = WrkListNo
    '      ._LOCNO = JustifyRight(RecArray(8), 7)
    '      ._LOC = ConvertString("Loc", RecArray(9), 25)
    '      ._NAME = ConvertString("Name", RecArray(2), 35)
    '      ._SNAME = ConvertString("Sname", "", 35)
    '      ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5
    '      ._OID = ""
    '      ._PDST = 0
    '      ._PRF = ""
    '      ._RDATE = 0
    '      ._SQFT = 0
    '      ._SS2 = 0
    '      ._SSNO = 0
    '      ._STATE = WrkState
    '      ._TIN = ""
    '      ._TYPE = "P"
    '      ._UNIT1 = 0 'WrkUnits(0)
    '      ._UNIT2 = 0 'WrkUnits(1)
    '      ._UNIT3 = 0 'WrkUnits(2)
    '      ._UNIT4 = 0 'WrkUnits(3)
    '      ._UNIT5 = 0 'WrkUnits(4)
    '      ._UNIT6 = 0 'WrkUnits(5)
    '      ._UNIT7 = 0 'WrkUnits(6)
    '      ._UNIT8 = 0
    '      ._UNIT9 = 0
    '      ._UNITA = 0
    '      ._ZIP4 = CnvSng(RecArray(7))
    '      ._ZIP5 = CnvSng(RecArray(6))
    '      .AddOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("PP " & WrkListNo & " " & .ErrMsg)
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WritePPA()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FilePPA, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkCodes(6) As Integer
    '    Dim WrkAss(6) As Integer
    '    Dim WrkUnits(6) As Decimal
    '    Const cMaxAmount As Long = 9999999
    '    Dim I As Integer
    '    Dim J As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal

    '    WrkFile = "PPA"
    '    'myDBConnect2.DeleteRecords2("TXPPRA")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header

    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If
    '    strBuffer = Replace(strBuffer, "'", "")
    '    strBuffer = Replace(strBuffer, "21a", "21")
    '    strBuffer = Replace(strBuffer, "21b", "21")
    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    Array.Clear(WrkCodes, 0, 6)
    '    Array.Clear(WrkAss, 0, 6)
    '    Array.Clear(WrkUnits, 0, 6)
    '    SplitCityST(Trim(RecArray(5)))

    '    With MyTXPPRA
    '      Counter = Counter + 1
    '      J = -1
    '      If CnvSng(RecArray(15)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(13))
    '        WrkAss(J) = RecArray(15)
    '        WrkUnits(J) = CnvSng(RecArray(14))
    '      End If
    '      If CnvSng(RecArray(18)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(16))
    '        WrkAss(J) = RecArray(18)
    '        WrkUnits(J) = CnvSng(RecArray(17))
    '      End If
    '      If CnvSng(RecArray(21)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(19))
    '        WrkAss(J) = RecArray(21)
    '        WrkUnits(J) = CnvSng(RecArray(20))
    '      End If
    '      If CnvSng(RecArray(24)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(22))
    '        WrkAss(J) = RecArray(24)
    '        WrkUnits(J) = CnvSng(RecArray(23))
    '      End If
    '      If CnvSng(RecArray(27)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = CnvSng(RecArray(25))
    '        WrkAss(J) = RecArray(27)
    '        WrkUnits(J) = CnvSng(RecArray(26))
    '      End If
    '      If CnvSng(RecArray(28)) > 0 Then
    '        J = J + 1
    '        WrkCodes(J) = 25
    '        WrkAss(J) = RecArray(28)
    '        WrkUnits(J) = 0
    '      End If
    '      WrkListNo = RecArray(0)
    '      .GetOneRecordP(WrkListNo, CnvSng(TxtGLYear.Text))
    '      ._ADD1 = ConvertString("Add1", RecArray(4), 35)
    '      ._ADD2 = ConvertString("Add2", "", 35)
    '      ._ADYR = 0
    '      ._ASS1 = WrkAss(0)
    '      ._ASS2 = WrkAss(1)
    '      ._ASS3 = WrkAss(2)
    '      ._ASS4 = WrkAss(3)
    '      ._ASS5 = WrkAss(4)
    '      ._ASS6 = WrkAss(5)
    '      ._ASS7 = WrkAss(6)
    '      ._ASS8 = 0
    '      ._ASS9 = 0
    '      ._ASS10 = 0
    '      ._BTC = ""
    '      ._BTR = 0
    '      ._BUS = ""
    '      ._BUSTY = ""
    '      ._CASS1 = 0
    '      ._CASS2 = 0
    '      ._CASS3 = 0
    '      ._CASS4 = 0
    '      ._CASS5 = 0
    '      ._CASS6 = 0
    '      ._CASS7 = 0
    '      ._CASS8 = 0
    '      ._CASS9 = 0
    '      ._CASSA = 0
    '      ._CAT = "5"
    '      ._CCCD1 = ""
    '      ._CCCD2 = ""
    '      ._CCCD3 = ""
    '      ._CCCD4 = ""
    '      ._CCCD5 = ""
    '      ._CCEX = 0
    '      ._CCGRS = 0
    '      ._CCNO = 0
    '      ._CCRS = ""
    '      ._CDATE = 0
    '      ._CEXA1 = 0
    '      ._CEXA2 = 0
    '      ._CEXA3 = 0
    '      ._CEXA4 = 0
    '      ._CEXA5 = 0
    '      ._CHDATE = 0
    '      ._CHTIME = 0
    '      ._CITY = WrkCity
    '      ._CODE1 = WrkCodes(0)
    '      ._CODE2 = WrkCodes(1)
    '      ._CODE3 = WrkCodes(2)
    '      ._CODE4 = WrkCodes(3)
    '      ._CODE5 = WrkCodes(4)
    '      ._CODE6 = WrkCodes(5)
    '      ._CODE7 = WrkCodes(6)
    '      ._CODE8 = 0
    '      ._CODE9 = 0
    '      ._CODEA = 0
    '      ._DIST = 0
    '      ._DNBTR = ""
    '      ._DTBTR = 0
    '      If CnvSng(RecArray(30)) > cMaxAmount Then
    '        ._EXAM1 = cMaxAmount
    '        sw.WriteLine("PP Exam1 " & WrkListNo & " " & CnvSng(RecArray(30)))
    '      Else
    '        ._EXAM1 = CnvSng(RecArray(30))
    '      End If
    '      If CnvSng(RecArray(32)) > cMaxAmount Then
    '        ._EXAM2 = cMaxAmount
    '        sw.WriteLine("PP Exam2 " & WrkListNo & " " & CnvSng(RecArray(32)))
    '      Else
    '        ._EXAM2 = CnvSng(RecArray(32))
    '      End If
    '      If CnvSng(RecArray(34)) > cMaxAmount Then
    '        ._EXAM3 = cMaxAmount
    '        sw.WriteLine("PP Exam3 " & WrkListNo & " " & CnvSng(RecArray(34)))
    '      Else
    '        ._EXAM3 = CnvSng(RecArray(34))
    '      End If
    '      If CnvSng(RecArray(36)) > cMaxAmount Then
    '        ._EXAM4 = cMaxAmount
    '        sw.WriteLine("PP Exam4 " & WrkListNo & " " & CnvSng(RecArray(36)))
    '      Else
    '        ._EXAM4 = CnvSng(RecArray(36))
    '      End If
    '      If CnvSng(RecArray(38)) > cMaxAmount Then
    '        ._EXAM5 = cMaxAmount
    '        sw.WriteLine("PP Exam5 " & WrkListNo & " " & CnvSng(RecArray(38)))
    '      Else
    '        ._EXAM5 = CnvSng(RecArray(38))
    '      End If
    '      ._EXCD1 = Trim(RecArray(29))
    '      ._EXCD2 = Trim(RecArray(31))
    '      ._EXCD3 = Trim(RecArray(33))
    '      ._EXCD4 = Trim(RecArray(35))
    '      ._EXCD5 = Trim(RecArray(37))
    '      ._GROSS = CnvSng(RecArray(12))
    '      ._LETT = Mid(RecArray(2), 1, 1)
    '      ._LISTNO = WrkListNo
    '      ._LOCNO = JustifyRight(RecArray(8), 7)
    '      ._LOC = ConvertString("Loc", RecArray(9), 25)
    '      ._NAME = ConvertString("Name", RecArray(2), 35)
    '      ._SNAME = ConvertString("Sname", "", 35)
    '      ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5
    '      ._OID = ""
    '      ._PDST = 0
    '      ._PRF = ""
    '      ._RDATE = 0
    '      ._SQFT = 0
    '      ._SS2 = 0
    '      ._SSNO = 0
    '      ._STATE = WrkState
    '      ._TIN = ""
    '      ._TXYEAR = CnvSng(TxtGLYear.Text)
    '      ._TYPE = "P"
    '      ._UNIT1 = 0 'WrkUnits(0)
    '      ._UNIT2 = 0 'WrkUnits(1)
    '      ._UNIT3 = 0 'WrkUnits(2)
    '      ._UNIT4 = 0 'WrkUnits(3)
    '      ._UNIT5 = 0 'WrkUnits(4)
    '      ._UNIT6 = 0 'WrkUnits(5)
    '      ._UNIT7 = 0 'WrkUnits(6)
    '      ._UNIT8 = 0
    '      ._UNIT9 = 0
    '      ._UNITA = 0
    '      ._ZIP4 = CnvSng(RecArray(7))
    '      ._ZIP5 = CnvSng(RecArray(6))
    '      .AddOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("PPA " & WrkListNo & " " & .ErrMsg)
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteMV(ByVal WrkFileName As String, WrkYear As Integer)
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileMV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "MV"
    '    myDBConnect2.DeleteRecords2(WrkFileName)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    SplitCityST(Trim(RecArray(33)))
    '    With MyTXMVD
    '      Counter = Counter + 1
    '      WrkListNo = CnvListNoAlpha(RecArray(0))
    '      .GetOneRecordP(WrkListNo)
    '      ._ADD1 = ConvertString("Add1", RecArray(32), 35)
    '      ._ADD2 = ConvertString("Add1", "", 35)
    '      ._ASS = ""
    '      ._BODY = RecArray(8)
    '      ._BTC = ""
    '      ._BTR = 0
    '      ._CAT = "1"
    '      ._CCCD1 = ""
    '      ._CCCD2 = ""
    '      ._CCCD3 = ""
    '      ._CCCD4 = ""
    '      ._CCCD5 = ""
    '      ._CCEX = 0
    '      ._CCGRS = 0
    '      ._CCNO = 0
    '      ._CCRS = ""
    '      ._CDATE = 0
    '      ._CEXA1 = 0
    '      ._CEXA2 = 0
    '      ._CEXA3 = 0
    '      ._CEXA4 = 0
    '      ._CEXA5 = 0
    '      ._CHDATE = 0
    '      ._CHTIME = 0
    '      ._CLASS = 0
    '      ._CYCLE = 0
    '      If CnvSng(RecArray(9)) < 10 Then
    '        ._CYLAX = CnvSng(RecArray(9))
    '      Else
    '        ._CYLAX = 0
    '      End If
    '      ._CITY = ConvertString("City", WrkCity, 25)
    '      ._DIST = 0
    '      ._DNBTR = 0
    '      ._DOB = ConvertDateAlpha(RecArray(24))
    '      ._DTBTR = 0
    '      ._EXAM1 = CnvSng(RecArray(44))
    '      ._EXAM2 = CnvSng(RecArray(46))
    '      ._EXAM3 = CnvSng(RecArray(48))
    '      ._EXAM4 = CnvSng(RecArray(50))
    '      ._EXAM5 = CnvSng(RecArray(52))
    '      ._EXCD1 = Trim(RecArray(43))
    '      ._EXCD2 = Trim(RecArray(45))
    '      ._EXCD3 = Trim(RecArray(47))
    '      ._EXCD4 = Trim(RecArray(49))
    '      ._EXCD5 = Trim(RecArray(51))
    '      ._GWT = CnvSng(RecArray(11))
    '      ._LEASE = Trim(RecArray(36))
    '      ._LETT = Mid(RecArray(18), 1, 1)
    '      ._LISTNO = WrkListNo
    '      ._LNVAL = CnvSng(RecArray(57))
    '      ._LOC = ""
    '      ._LOCNO = ""
    '      ._LWT = CnvSng(RecArray(10))
    '      ._MAKE = Mid(RecArray(3), 1, 5)
    '      ._MODEL = Mid(RecArray(5), 1, 8)
    '      ._MSRP = CnvSng(RecArray(58))
    '      ._NADA = ""
    '      ._NAME = ConvertString("Name", RecArray(18), 35)
    '      ._SNAME = ConvertString("Sname", RecArray(25), 35)
    '      ._OASS = ""
    '      ._OCLS = 0
    '      ._OCODE = 0
    '      ._OID = CnvSng(RecArray(73))
    '      ._OLIST = 0
    '      ._OMAKE = ""
    '      ._OMOD = ""
    '      ._OPVAL = 0
    '      ._OREGNO = ""
    '      ._ORIG = 0
    '      ._OVAL = 0
    '      ._OVIN = ""
    '      ._OYEAR = 0
    '      ._PCCOD = 0
    '      ._PCLR = CnvColorAbbr(RecArray(12))
    '      ._PDST = 0
    '      ._PNET = 0
    '      ._PREG = ""
    '      ._PRF = ""
    '      ._RAD1 = ConvertString("Rad1", RecArray(66), 35)
    '      ._RAD2 = ""
    '      ._RATE = 70
    '      ._RCODE = 0
    '      ._RCTY = ConvertString("Rcty", RecArray(67), 25)
    '      ._REGNO = RecArray(7)
    '      ._RST = ConvertString("Rst", RecArray(68), 2)
    '      ._RZ4 = 0 'CnvSng(RecArray(69)) full zip
    '      ._RZ5 = 0 'CnvSng(RecArray(69))
    '      ._SCAP = 0
    '      ._SCLR = ""
    '      ._SEAT = 0
    '      ._SS2 = CnvSng(RecArray(71))
    '      ._SSNO = CnvSng(RecArray(72))
    '      ._STATE = WrkState
    '      ._TDATE = 0
    '      ._TIN = ""
    '      ._TRVAL = CnvSng(RecArray(56))
    '      ._TYPE = "M"
    '      ._VALUE = CnvSng(RecArray(16))
    '      ._VINNO = ConvertString("VIN", RecArray(6), 17)
    '      ._XDATE = 0
    '      ._YEAR = CnvSng(RecArray(4))
    '      ._ZIP4 = CnvSng(RecArray(35))
    '      ._ZIP5 = CnvSng(RecArray(34))
    '      .AddOneRecordP()
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub UpdateMV()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileMV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "MV"
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    SplitCityST(Trim(RecArray(33)))
    '    With MyTXMVD
    '      Counter = Counter + 1
    '      WrkListNo = CnvListNoAlpha(RecArray(0))
    '      .GetOneRecordP(WrkListNo)
    '      'If ._CLASS = 0 Then
    '      ' MyTXVCLS.GetOneRecordP(RecArray(2))
    '      'If Not .RecordNotFound Then
    '      '._CLASS = MyTXVCLS._CLASS
    '      '.UpdateOneRecordP()
    '      'End If
    '      'End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteSU(ByVal WrkFileName As String, WrkYear As Integer)
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileSU, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim WrkOListNo As Integer
    '    Dim RecArray As String()
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim WrkCredit As Boolean
    '    Dim I As Integer

    '    WrkFile = "SU"
    '    MyTXSUPP = New TXSUPP(myDBConnect2.MyConn2, WrkFileName)
    '    myDBConnect2.DeleteRecords2(WrkFileName)
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    SplitCityST(Trim(RecArray(32)))
    '    With MyTXSUPP
    '      Counter = Counter + 1
    '      WrkListNo = CnvListNoAlpha(RecArray(0))
    '      WrkOListNo = CnvListNoAlpha(RecArray(84))
    '      .GetOneRecordP(WrkListNo)
    '      ._ADD1 = ConvertString("Add1", RecArray(31), 35)
    '      ._ADD2 = ConvertString("Add1", "", 35)
    '      If CnvSng(RecArray(76)) > 0 Then
    '        WrkCredit = True
    '      Else
    '        WrkCredit = False
    '      End If
    '      ._ASS = Trim(RecArray(74))
    '      '._ASS = GetSupCD(RecArray(75), WrkCredit)
    '      ._BODY = RecArray(8)
    '      ._BTC = ""
    '      ._BTR = 0
    '      ._CAT = "1"
    '      ._CCCD1 = ""
    '      ._CCCD2 = ""
    '      ._CCCD3 = ""
    '      ._CCCD4 = ""
    '      ._CCCD5 = ""
    '      ._CCEX = 0
    '      ._CCGRS = 0
    '      ._CCNO = 0
    '      ._CCRS = ""
    '      ._CDATE = 0
    '      ._CEXA1 = 0
    '      ._CEXA2 = 0
    '      ._CEXA3 = 0
    '      ._CEXA4 = 0
    '      ._CEXA5 = 0
    '      ._CHDATE = 0
    '      ._CHTIME = 0
    '      ._CLASS = 0
    '      ._CYCLE = 0
    '      ._CYLAX = 0
    '      ._CITY = ConvertString("City", WrkCity, 25)
    '      ._DIST = 0
    '      ._DOB = ConvertDateAlpha(RecArray(23))
    '      ._EXAM1 = CnvSng(RecArray(43))
    '      ._EXAM2 = CnvSng(RecArray(45))
    '      ._EXAM3 = CnvSng(RecArray(47))
    '      ._EXAM4 = CnvSng(RecArray(49))
    '      ._EXAM5 = CnvSng(RecArray(51))
    '      ._EXCD1 = Trim(RecArray(42))
    '      ._EXCD2 = Trim(RecArray(44))
    '      ._EXCD3 = Trim(RecArray(46))
    '      ._EXCD4 = Trim(RecArray(48))
    '      ._EXCD5 = Trim(RecArray(50))
    '      ._GWT = CnvSng(RecArray(11))
    '      ._LEASE = Trim(RecArray(35))
    '      ._LETT = Mid(RecArray(17), 1, 1)
    '      ._LISTNO = WrkListNo
    '      ._LNVAL = CnvSng(RecArray(56))
    '      ._LWT = CnvSng(RecArray(10))
    '      ._MAKE = Mid(RecArray(3), 1, 5)
    '      ._MODEL = Mid(RecArray(5), 1, 8)
    '      ._MSRP = CnvSng(RecArray(58))
    '      ._NADA = ""
    '      ._NAME = ConvertString("Name", RecArray(17), 35)
    '      ._SNAME = ConvertString("Sname", RecArray(24), 35)
    '      If CnvSng(RecArray(76)) > 0 Then
    '        ._OASS = ._ASS
    '      Else
    '        ._OASS = ""
    '      End If
    '      ._OCLS = 0
    '      ._OCODE = 0
    '      ._OID = CnvSng(RecArray(72))
    '      ._OLIST = WrkOListNo
    '      ._OMAKE = Mid(RecArray(80), 1, 5)
    '      ._OMOD = Mid(RecArray(79), 1, 8)
    '      ._OPVAL = 0
    '      ._OREGNO = RecArray(78)
    '      ._ORIG = 0
    '      ._OVAL = CnvSng(RecArray(82))
    '      ._OVIN = ConvertString("OVIN", RecArray(81), 17)
    '      ._OYEAR = CnvSng(RecArray(76))
    '      ._PCCOD = 0
    '      ._PCLR = CnvColorAbbr(RecArray(12))
    '      ._PDST = 0
    '      ._PNET = CnvSng(RecArray(85))
    '      ._PREG = ""
    '      ._PRF = ""
    '      ._PVAL = 0
    '      ._RATE = 70
    '      ._RCODE = 0
    '      ._REGNO = RecArray(7)
    '      ._SCAP = 0
    '      ._SCLR = ""
    '      ._SEAT = 0
    '      ._SS2 = CnvSng(RecArray(72))
    '      ._SSNO = CnvSng(RecArray(71))
    '      ._STATE = WrkState
    '      ._TDATE = 0
    '      ._TIN = ""
    '      ._TRVAL = CnvSng(RecArray(55))
    '      ._TYPE = "S"
    '      ._VALUE = CnvSng(RecArray(16))
    '      ._VINNO = ConvertString("VIN", RecArray(6), 17)
    '      ._XDATE = 0
    '      ._YEAR = CnvSng(RecArray(4))
    '      ._ZIP4 = CnvSng(RecArray(34))
    '      ._ZIP5 = CnvSng(RecArray(33))
    '      .AddOneRecordP()
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      '          .Refresh()
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteVCLS()
    '    Dim mystream As System.IO.Stream
    '    Dim sArray As String()
    '    Dim WrkStr As String
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal

    '    myDBConnect2.DeleteRecords2("TXVCLS")
    '    mystream = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream("CnvAvon.txvcls.csv")

    '    Using reader As New IO.StreamReader(mystream)
    '      ' Read the contents in MsgBox for example
    'ReadNext:
    '      If reader.EndOfStream Then Exit Sub
    '      WrkStr = reader.ReadLine
    '      sArray = Parse(WrkStr, ",")
    '      With MyTXVCLS
    '        Counter = Counter + 1
    '        .GetOneRecordP(sArray(0))
    '        ._CLASS = CnvSng(sArray(1))
    '        ._DESC = sArray(0)
    '        .AddOneRecordP()
    '      End With

    '      WrkPct = (Counter / 10) Mod 100
    '      If SavePct <> WrkPct Then
    '        ProgBar1.Value = WrkPct
    '        LblMsg.Text = "Records processed: " & Counter
    '        SavePct = WrkPct
    '        Application.DoEvents()
    '      End If
    '      GoTo ReadNext
    '    End Using
  End Sub
  Private Sub WriteVEH_VCUS(ByVal WrkFromFile As String)
    'Dim ds As DataSet = New DataSet
    'Dim WrkVehID As Integer
    'Dim WrkPName As String
    'Dim WrkSName As String
    'Dim WrkLname As String
    'Dim WrkValue As Integer
    'Dim WrkTrVal As Integer
    'Dim WrkLnVal As Integer
    'Dim WrkClass As Integer
    'Dim WrkNewValue As Integer
    'Dim I As Integer
    'Dim J As Integer
    'Dim WrkPct As Decimal
    'Dim SavePct As Decimal
    'Dim Counter As Decimal

    'MyTXVEH = New TXVEH(myDBConnect2.MyConn2)
    'MyTXVCUS = New TXVCUS(myDBConnect2.MyConn2)
    'myDBConnect2.DeleteRecords2("TXVEH")
    'myDBConnect2.DeleteRecords2("TXVCUS")
    ''ds = myDBConnect.RunQuery(WrkFromFile, "")
    'For I = 0 To ds.Tables(0).Rows.Count - 1
    '  Counter = Counter + 1
    '  WrkPName = ""
    '  If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName")) <> String.Empty Then
    '    WrkPName = Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName"))
    '  Else
    '    WrkPName = Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerLastName"))
    '    If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerFirstName")) <> String.Empty Then
    '      WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerFirstName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerMiddleName")) <> String.Empty Then
    '      WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerMiddleName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerSuffix")) <> String.Empty Then
    '      WrkPName = WrkPName & " " & Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerSuffix"))
    '    End If
    '  End If

    '  WrkSName = ""
    '  If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerOrganizationName")) <> String.Empty Then
    '    WrkSName = Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerOrganizationName"))
    '  Else
    '    WrkSName = Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerLastName"))
    '    If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerFirstName")) <> String.Empty Then
    '      WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerFirstName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerMiddleName")) <> String.Empty Then
    '      WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerMiddleName"))
    '    End If
    '    If Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerSuffix")) <> String.Empty Then
    '      WrkSName = WrkSName & " " & Trim(ds.Tables(0).Rows(I).Item("SecondaryOwnerSuffix"))
    '    End If
    '  End If
    '  WrkClass = GetTXVCLSCode(ds.Tables(0).Rows(I).Item("PlateClassName"))

    '  'Calculate Assessment Values
    '  WrkValue = CnvSng(ds.Tables(0).Rows(I).Item("AdjustedRetailValue")) * cAssPct
    '  WrkTrVal = CnvSng(ds.Tables(0).Rows(I).Item("AdjustedTradeInValue")) * cAssPct
    '  WrkLnVal = CnvSng(ds.Tables(0).Rows(I).Item("SalesPriceAmount")) * cAssPct
    '  If cMinValue > WrkValue And WrkValue > 0 Then
    '    WrkNewValue = cMinValue
    '  Else
    '    WrkNewValue = WrkValue
    '  End If
    '  'Class 25 = Classic vehicle
    '  If WrkClass = 25 Then
    '    WrkNewValue = cClassicVehicle
    '  End If
    '  'Round down to nearest 10 dollars
    '  J = WrkNewValue Mod 10
    '  If J <> 0 Then
    '    WrkNewValue = WrkNewValue - J
    '  End If

    '  WrkFile = "TXVEH"
    '  With MyTXVEH
    '    WrkVehID = CnvSng(ds.Tables(0).Rows(I).Item("VehicleID"))
    '    If WrkVehID > 0 Then
    '      .GetOneRecordP(WrkVehID)
    '      ._BODY = ConvertString("Body", ds.Tables(0).Rows(I).Item("BodyStyle"), 30)
    '      If Trim(ds.Tables(0).Rows(I).Item("FileCreationDate")) <> "" Then
    '        ._CHDATE = SetDBDate(ds.Tables(0).Rows(I).Item("FileCreationDate"))
    '      Else
    '        ._CHDATE = 0
    '      End If
    '      ._CLASS = WrkClass
    '      ._CLASSD = ds.Tables(0).Rows(I).Item("PlateClassName")
    '      If CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders")) < 10 Then
    '        ._CYLAX = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfCylinders"))
    '      Else
    '        ._CYLAX = 0
    '      End If
    '      ._DADD1 = ConvertString("DAdd1", ds.Tables(0).Rows(I).Item("DomiciledAddressLine1"), 35)
    '      ._DADD2 = ConvertString("DAdd2", ds.Tables(0).Rows(I).Item("DomiciledAddressLine2"), 35)
    '      ._DCITY = ConvertString("DCity", ds.Tables(0).Rows(I).Item("DomiciledAddressCity"), 25)
    '      ._DSTATE = ds.Tables(0).Rows(I).Item("DomiciledAddressStateCode")
    '      ._DZIPA = ds.Tables(0).Rows(I).Item("DomiciledAddressZip")
    '      ._ENDDT = SetDBDate(ds.Tables(0).Rows(I).Item("RegistrationEndDate"))
    '      ._GWT = CnvSng(ds.Tables(0).Rows(I).Item("GVWR"))
    '      WrkLname = String.Empty
    '      If ds.Tables(0).Rows(I).Item("LesseeOrganizationName") <> String.Empty Then
    '        ._LBUS = "Y"
    '        WrkLname = ds.Tables(0).Rows(I).Item("LesseeOrganizationName")
    '      Else
    '        ._LBUS = "N"
    '        WrkLname = ds.Tables(0).Rows(I).Item("LesseeLastName")
    '        If ds.Tables(0).Rows(I).Item("LesseeFirstName") <> String.Empty Then
    '          WrkLname = WrkLname & " " & ds.Tables(0).Rows(I).Item("LesseeFirstName")
    '        End If
    '        If ds.Tables(0).Rows(I).Item("LesseeMiddleName") <> String.Empty Then
    '          WrkLname = WrkLname & " " & ds.Tables(0).Rows(I).Item("LesseeMiddleName")
    '        End If
    '      End If
    '      If WrkLname <> String.Empty Then
    '        ._LEASE = "Y"
    '      Else
    '        ._LEASE = ""
    '        ._LBUS = ""
    '      End If
    '      ._LNAME = ConvertString("LName", WrkLname, 35)
    '      ._LCUST = CnvSng(ds.Tables(0).Rows(I).Item("LesseeVestedPartyID"))
    '      ._LADD1 = ConvertString("LAdd1", ds.Tables(0).Rows(I).Item("LesseeResidencyAddressLine1"), 35)
    '      ._LADD2 = ConvertString("LAdd2", ds.Tables(0).Rows(I).Item("LesseeResidencyAddressLine2"), 35)
    '      ._LCITY = ConvertString("LCity", ds.Tables(0).Rows(I).Item("LesseeResidencyCity"), 35)
    '      ._LSTATE = ds.Tables(0).Rows(I).Item("LesseeResidencyState")
    '      ._LZIPA = FormatZip(ds.Tables(0).Rows(I).Item("LesseeResidencyZip"))
    '      ._LNVAL = WrkLnVal
    '      ._LWT = CnvSng(ds.Tables(0).Rows(I).Item("UnladenWeight"))
    '      ._MSRP = CnvSng(ds.Tables(0).Rows(I).Item("MSRP"))
    '      ._NADA = ds.Tables(0).Rows(I).Item("NADAReturnCodes")
    '      ._ORIG = WrkValue
    '      ._PCUST = CnvSng(ds.Tables(0).Rows(I).Item("PrimaryOwnerCustomerID"))
    '      ._REGID = CnvSng(ds.Tables(0).Rows(I).Item("VehicleRegistrationID"))
    '      ._REGNO = ds.Tables(0).Rows(I).Item("PlateNumber")
    '      If ds.Tables(0).Rows(I).Item("FineIndicator") Then
    '        ._RGLATE = "Y"
    '      Else
    '        ._RGLATE = ""
    '      End If
    '      ._SCUST = CnvSng(ds.Tables(0).Rows(I).Item("SecondaryOwnerCustomerID"))
    '      ._SEAT = CnvSng(ds.Tables(0).Rows(I).Item("NumberOfSeats"))
    '      ._STRDT = SetDBDate(ds.Tables(0).Rows(I).Item("RegistrationStartDate"))
    '      ._TRVAL = WrkTrVal
    '      ._VINNO = ConvertString("VIN", ds.Tables(0).Rows(I).Item("VIN"), 17)
    '      ._VMAKE = ConvertString("Make", ds.Tables(0).Rows(I).Item("Make"), 15)
    '      ._VMODEL = ConvertString("Model", ds.Tables(0).Rows(I).Item("Model"), 15)
    '      ._VPCLR = ds.Tables(0).Rows(I).Item("PrimaryColor")
    '      ._VSCLR = ds.Tables(0).Rows(I).Item("SecondaryColor")
    '      ._YEAR = CnvSng(ds.Tables(0).Rows(I).Item("Year"))
    '      If .RecordNotFound Then
    '        ._VEHID = WrkVehID
    '        .AddOneRecordP()
    '      Else
    '        .UpdateOneRecordP()
    '      End If
    '    End If
    '  End With

    '  If MyTXVEH._PCUST > 0 Then
    '    WrkFile = "TXVCUS"
    '    With MyTXVCUS
    '      .GetOneRecordP(MyTXVEH._PCUST)
    '      ._ADD1 = ConvertString("Add1", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingAddressLine1"), 35)
    '      ._ADD2 = ConvertString("Add2", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingAddressLine2"), 35)
    '      ._CHDATE = MyTXVEH._CHDATE
    '      ._CITY = ConvertString("City", ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingCity"), 25)
    '      ._CONFID = ds.Tables(0).Rows(I).Item("PrimaryOwnerConfidential")
    '      If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerDOB")) <> "" Then
    '        ._DOB = SetDBDate(ds.Tables(0).Rows(I).Item("PrimaryOwnerDOB"))
    '      Else
    '        ._DOB = 0
    '      End If
    '      If Trim(ds.Tables(0).Rows(I).Item("PrimaryOwnerOrganizationName")) <> String.Empty Then
    '        ._BUS = "Y"
    '      Else
    '        ._BUS = "N"
    '      End If
    '      ._NAME = ConvertString("PName", WrkPName, 35)
    '      ._RADD1 = ConvertString("Radd1", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyAddressLine1"), 35)
    '      ._RADD2 = ConvertString("Radd2", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyAddressLine2"), 35)
    '      ._RCITY = ConvertString("Rcity", ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyCity"), 35)
    '      ._RSTATE = ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyState")
    '      ._RZIPA = FormatZip(ds.Tables(0).Rows(I).Item("PrimaryOwnerResidencyZip"))
    '      ._SEX = Mid(ds.Tables(0).Rows(I).Item("PrimaryOwnerGender"), 1, 1)
    '      ._STATE = ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingState")
    '      ._ZIPA = FormatZip(ds.Tables(0).Rows(I).Item("PrimaryOwnerMailingZip"))
    '      If .RecordNotFound Then
    '        ._CUSTID = MyTXVEH._PCUST
    '        .AddOneRecordP()
    '      Else
    '        .UpdateOneRecordP()
    '      End If
    '    End With
    '  End If

    '  WrkPct = (Counter / 10) Mod 100
    '  If SavePct <> WrkPct Then
    '    ProgBar1.Value = WrkPct
    '    LblMsg.Text = "Records processed: " & Counter
    '    '.Refresh()
    '    SavePct = WrkPct
    '    Application.DoEvents()
    '  End If
    'Next
    'ds = Nothing
  End Sub
  Private Sub WriteUT()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "UT"
    '    myDBConnect2.DeleteRecords2("UTCUST")
    '    myDBConnect2.DeleteRecords2("UTCUSTRT")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    WrkListNo = RecArray(0)
    '    MyTXREAL.GetOneRecordP(WrkListNo)
    '    With MyUTCUST
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkListNo)
    '      ._CUACCT = WrkListNo
    '      ._CUACRE = 0
    '      ._CUADD1 = Trim(MyTXREAL._ADD1)
    '      ._CUADD2 = Trim(MyTXREAL._ADD2)
    '      ._CUADDX = ""
    '      ._CUAPLNO = 0
    '      ._CUAPMT = 0
    '      ._CUAPMT = 0
    '      ._CUAUNT = 0
    '      ._CUCITY = Trim(MyTXREAL._CITY)
    '      ._CUCNTNO = ""
    '      ._CUDST = 0
    '      ._CUFOOT = 0
    '      ._CUFUND = 0
    '      ._CULOC = Trim(MyTXREAL._LOC)
    '      ._CULOCNO = MyTXREAL._LOCNO
    '      ._CUMAD1 = ""
    '      ._CUMAD2 = ""
    '      ._CUMAP = ""
    '      ._CUMCTY = ""
    '      ._CUMETN = ""
    '      ._CUMETP = ""
    '      If Trim(RecArray(4)) = "PUBLIC" Then
    '        ._CUMSIZ = "1"
    '        ._CUEDU = 1
    '      Else
    '        ._CUMSIZ = "2"
    '        ._CUEDU = 0
    '      End If
    '      ._CUMST = ""
    '      ._CUMZIP = ""
    '      ._CUNAM1 = Trim(MyTXREAL._NAME)
    '      ._CUNAM2 = Trim(MyTXREAL._SNAME)
    '      ._CUPAGE = ""
    '      If Trim(RecArray(4)) = "PUBLIC" Then
    '        ._CUPCAT = "RES"
    '      Else
    '        ._CUPCAT = "WEL"
    '      End If
    '      ._CUPHAS = 0
    '      ._CUPVAL = 0
    '      ._CUREGN = ""
    '      ._CUROUT = ""
    '      ._CUSCHR = 0
    '      ._CUSDES = ""
    '      ._CUSECT = ""
    '      ._CUSERN = ""
    '      ._CUSFIX = 0
    '      ._CUST = Trim(MyTXREAL._STATE)
    '      ._CUTELNO = ""
    '      ._CUTIE = 0
    '      ._CUUNIT = 0
    '      ._CUUPMT = 0
    '      ._CUVOLM = ""
    '      ._CUWFIX = 0
    '      ._CUXREF = ""
    '      ._CUXTRA = 0
    '      ._CUZIP = Format(MyTXREAL._ZIP5, "00000")
    '      ._CUZONE = ""
    '      ._CYC = ""
    '      ._OID = ""
    '      .AddOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("UT " & WrkListNo & " " & .ErrMsg)
    '      End If
    '    End With

    '    With MyUTCUSTRT
    '      Counter = Counter + 1
    '      WrkListNo = RecArray(0)
    '      .GetOneRecordP(WrkListNo, "U")
    '      If Trim(RecArray(4)) = "PUBLIC" Then
    '        ._CRACCT = WrkListNo
    '        ._CRCODE = "RES"
    '        ._CRTYPE = "U"
    '      Else
    '        ._CRACCT = WrkListNo
    '        ._CRCODE = "WEL"
    '        ._CRTYPE = "U"
    '      End If
    '      .AddOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("UTRT " & WrkListNo & " " & .ErrMsg)
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteUT2()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "UT2"
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    WrkListNo = RecArray(3)
    '    MyTXREAL.GetOneRecordP(WrkListNo)
    '    With MyUTCUST
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkListNo)
    '      If .RecordNotFound Then
    '        ._CUACCT = WrkListNo
    '        ._CUACRE = 0
    '        ._CUADD1 = Trim(MyTXREAL._ADD1)
    '        ._CUADD2 = Trim(MyTXREAL._ADD2)
    '        ._CUADDX = ""
    '        ._CUAPLNO = 0
    '        ._CUAPMT = 0
    '        ._CUAPMT = 0
    '        ._CUAUNT = 0
    '        ._CUCITY = Trim(MyTXREAL._CITY)
    '        ._CUCNTNO = ""
    '        ._CUDST = 0
    '        ._CUEDU = 0
    '        ._CUFOOT = 0
    '        ._CUFUND = 0
    '        ._CULOC = Trim(MyTXREAL._LOC)
    '        ._CULOCNO = MyTXREAL._LOCNO
    '        ._CUMAD1 = ""
    '        ._CUMAD2 = ""
    '        ._CUMAP = ""
    '        ._CUMCTY = ""
    '        ._CUMETN = ""
    '        ._CUMETP = ""
    '        ._CUMSIZ = "3"
    '        ._CUMST = ""
    '        ._CUMZIP = ""
    '        ._CUNAM1 = Trim(MyTXREAL._NAME)
    '        ._CUNAM2 = Trim(MyTXREAL._SNAME)
    '        ._CUPAGE = ""
    '        ._CUPCAT = "COM"
    '        ._CUPHAS = 0
    '        ._CUPVAL = 0
    '        ._CUREGN = ""
    '        ._CUROUT = ""
    '        ._CUSCHR = 0
    '        ._CUSDES = ""
    '        ._CUSECT = ""
    '        ._CUSERN = ""
    '        ._CUSFIX = 0
    '        ._CUST = Trim(MyTXREAL._STATE)
    '        ._CUTELNO = ""
    '        ._CUTIE = 0
    '        ._CUUNIT = 0
    '        ._CUUPMT = 0
    '        ._CUVOLM = ""
    '        ._CUWFIX = 0
    '        ._CUXREF = ""
    '        ._CUXTRA = 0
    '        ._CUZIP = Format(MyTXREAL._ZIP5, "00000")
    '        ._CUZONE = ""
    '        ._CYC = ""
    '        ._OID = ""
    '        .AddOneRecordP()
    '        If .ErrMsg <> "" Then
    '          sw.WriteLine("UT2 " & WrkListNo & " " & .ErrMsg)
    '        End If
    '      End If
    '    End With

    '    With MyUTCUSTRT
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkListNo, "C")
    '      If .RecordNotFound Then
    '        ._CRACCT = WrkListNo
    '        ._CRCODE = "COM"
    '        ._CRTYPE = "U"
    '        .AddOneRecordP()
    '        If .ErrMsg <> "" Then
    '          sw.WriteLine("UTRT2 " & WrkListNo & " " & .ErrMsg)
    '        End If
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteUTAS()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTAS, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkNoUB As Boolean
    '    Dim WrkIsName As Boolean
    '    Dim WrkStr As String
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer
    '    Dim Pos As Integer

    '    WrkFile = "UTAS"
    '    myDBConnect2.DeleteRecords2("UTCUSTAS")
    '    myDBConnect2.DeleteRecords2("UTCUSTRT", "CRTYPE='A'")
    '    myDBConnect2.DeleteRecords2("TXINV", "YEAR=2000 and TYPE='A'")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    If Trim(RecArray(17)) = "" Then
    '      GoTo NextLine
    '    End If
    '    SplitLoc(Trim(RecArray(18)))
    '    WrkNoUB = False
    '    With MyUTCUST
    '      .GetOneRecordPLoc(WrkLoc, WrkLocNo)
    '      If Trim(._CULOC) <> WrkLoc Or ._CULOCNO <> WrkLocNo Then
    '        With MyTXREAL
    '          WrkNoUB = True
    '          .GetOneRecordPLoc(WrkLoc, WrkLocNo)
    '          If Trim(._LOC) <> WrkLoc Or ._LOCNO <> WrkLocNo Then
    '            sw.WriteLine("UTAS No Loc " & RecArray(0) & " " & Trim(RecArray(18)))
    '            GoTo NextLine
    '          End If
    '          WrkListNo = ._LISTNO
    '          If Trim(._SEWER) <> "Y" Then
    '            ._SEWER = "Y"
    '            .UpdateOneRecordP()
    '          End If
    '        End With
    '      End If
    '      If Not WrkNoUB Then
    '        WrkListNo = ._CUACCT
    '      End If
    '    End With

    '    With MyUTCUSTAS
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkListNo, "A")
    '      If .RecordNotFound Then
    '        ._CAACCT = WrkListNo
    '        ._CAADJ = CnvSng(RecArray(2))
    '        ._CAAMT = CnvSng(RecArray(12))
    '        ._CADEF = 0
    '        ._CADEP = 0
    '        ._CALAT = 0
    '        ._CAOVR = CnvSng(RecArray(3))
    '        If ._CAADJ - ._CAAMT > 0 Then
    '          ._CAPNO = CnvSng(RecArray(1))
    '        Else
    '          ._CAPNO = 1
    '        End If
    '        ._CATYPE = "A"
    '        ._CAUNIF = 0
    '        Try
    '          .AddOneRecordP()
    '        Catch
    '          If .ErrMsg <> "" Then
    '            sw.WriteLine("UTAS " & RecArray(0) & " AddRecord " & .ErrMsg)
    '            GoTo NextLine
    '          End If
    '        End Try
    '      Else
    '        sw.WriteLine("UTAS " & RecArray(0) & " " & WrkListNo & " DupRecord")
    '        GoTo NextLine
    '      End If
    '    End With

    '    With MyUTCUSTRT
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkListNo, "A")
    '      ._CRACCT = WrkListNo
    '      ._CRCODE = "1"
    '      If CnvSng(RecArray(7)) = 10 Then
    '        Select Case CnvSng(RecArray(8))
    '          Case 3.25
    '            ._CRCODE = "2"
    '          Case 4.75
    '            ._CRCODE = "3"
    '          Case 5.5
    '            ._CRCODE = "4"
    '          Case Else
    '        End Select
    '      End If
    '      ._CRTYPE = "A"
    '        Try
    '        .AddOneRecordP()
    '      Catch
    '        If .ErrMsg <> "" Then
    '          sw.WriteLine("UTRT " & RecArray(0) & " " & .ErrMsg)
    '        End If
    '      End Try
    '    End With

    '    SplitCityST(Trim(RecArray(21)))
    '    With MyTXINV
    '      .ClearFields()
    '      WrkIsName = False
    '      Pos = 1
    '      ._ICODE = "I"
    '      WrkStr = Replace(RecArray(19), "'", "")
    '      WrkStr = Trim(WrkStr)
    '      If Mid(WrkStr, 1, 1) = "/" Or Mid(WrkStr, 1, 1) = "%" Then
    '        WrkIsName = True
    '        Pos = 2
    '      End If
    '      If Strings.Right(Trim(RecArray(17)), 1) = "&" Or Strings.Right(Trim(RecArray(17)), 3) = "AND" Then
    '        WrkIsName = True
    '      End If
    '      If WrkIsName Then
    '        ._SNAME = ConvertString("Sname", Mid(WrkStr, Pos, 50), 35)
    '      Else
    '        ._ADD1 = ConvertString("Add1", WrkStr, 35)
    '      End If
    '      WrkStr = Trim(Replace(RecArray(20), "'", ""))
    '      If Trim(._ADD1) = "" Then
    '        ._ADD1 = ConvertString("Add2", WrkStr, 35)
    '        ._ADD2 = ""
    '      Else
    '        ._ADD2 = ConvertString("Add2", WrkStr, 35)
    '      End If
    '      ._CDATE = 0
    '        ._CITY = ConvertString("City", WrkCity, 25)
    '      If Trim(RecArray(10)) = "D" Then
    '        ._CCM = "Deferred"
    '      Else
    '        ._CCM = ""
    '      End If
    '      ._INTPD = 0
    '      ._LETT = Mid(RecArray(17), 1, 1)
    '      ._LISTNo = WrkListNo
    '      ._LNPD = CnvSng(RecArray(23))
    '      ._LOC = WrkLoc
    '      ._LOCNo = WrkLocNo
    '      WrkStr = Replace(RecArray(17), "'", "")
    '      WrkStr = Replace(WrkStr, ",", " ")
    '      ._NAME = ConvertString("Name", WrkStr, 35)
    '      ._RLST = 0
    '      ._STATE = WrkState
    '      If Trim(RecArray(14)) <> "" Then
    '        ._TXIDT = ConvertDate(RecArray(14))
    '      Else
    '        ._TXIDT = 0
    '      End If
    '      ._TYPE = "A"
    '      ._VOL = Trim(RecArray(4))
    '      ._IPAGE = Trim(RecArray(5))
    '      ._YEAR = 2000
    '      ._ZIP4 = 0
    '      ._ZIP5 = CnvSng(RecArray(22))
    '      ._TAX1 = CnvSng(RecArray(2))
    '      ._TAX2 = 0
    '      ._TAXT = ._TAX1 + ._TAX2
    '      ._PAYREC = CnvSng(RecArray(12))
    '      ._BOND = CnvSng(RecArray(13))
    '      ._BONDP = CnvSng(RecArray(13))
    '      ._BALD = ._TAXT - ._PAYREC
    '      .InsertOneRecordP()
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("UTAS-INV " & RecArray(0) & " " & .ErrMsg)
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteUTAS2()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTAS2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkNoUB As Boolean
    Dim WrkIsName As Boolean
    Dim WrkStr As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim Pos As Integer

    WrkFile = "UTAS"
    myDBConnect2.DeleteRecords2("UTCUSTRT", "CRTYPE='B'")
    myDBConnect2.DeleteRecords2("TXINV", "YEAR=2000 and TYPE='B'")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    If Trim(RecArray(17)) = "" Then
      GoTo NextLine
    End If
    SplitLoc(Trim(RecArray(18)))
    WrkNoUB = False
    With MyUTCUST
      .GetOneRecordPLoc(WrkLoc, WrkLocNo)
      If Trim(._CULOC) <> WrkLoc Or ._CULOCNO <> WrkLocNo Then
        With MyTXREAL
          WrkNoUB = True
          .GetOneRecordPLoc(WrkLoc, WrkLocNo)
          If Trim(._LOC) <> WrkLoc Or ._LOCNO <> WrkLocNo Then
            sw.WriteLine("UTAS No Loc " & RecArray(0) & " " & Trim(RecArray(18)))
            GoTo NextLine
          End If
          WrkListNo = ._LISTNO
          If Trim(._SEWER) <> "Y" Then
            ._SEWER = "Y"
            .UpdateOneRecordP()
          End If
        End With
      End If
      If Not WrkNoUB Then
        WrkListNo = ._CUACCT
      End If
    End With

    With MyUTCUSTAS
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo, "B")
      If .RecordNotFound Then
        ._CAACCT = WrkListNo
        ._CAADJ = CnvSng(RecArray(2))
        ._CAAMT = CnvSng(RecArray(12))
        ._CADEF = 0
        ._CADEP = 0
        ._CALAT = 0
        ._CAOVR = CnvSng(RecArray(3))
        If ._CAADJ - ._CAAMT > 0 Then
          ._CAPNO = CnvSng(RecArray(1))
        Else
          ._CAPNO = 1
        End If
        ._CATYPE = "B"
        ._CAUNIF = 0
        Try
          .AddOneRecordP()
        Catch
          If .ErrMsg <> "" Then
            sw.WriteLine("UTAS " & RecArray(0) & " AddRecord " & .ErrMsg)
            GoTo NextLine
          End If
        End Try
      Else
        sw.WriteLine("UTAS " & RecArray(0) & " " & WrkListNo & " DupRecord")
        GoTo NextLine
      End If
    End With

    With MyUTCUSTRT
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo, "B")
      ._CRACCT = WrkListNo
      ._CRCODE = "1"
      ._CRTYPE = "B"
      Try
        .AddOneRecordP()
      Catch
        If .ErrMsg <> "" Then
          sw.WriteLine("UTRT " & RecArray(0) & " " & .ErrMsg)
        End If
      End Try
    End With

    SplitCityST(Trim(RecArray(21)))
    With MyTXINV
      .ClearFields()
      WrkIsName = False
      Pos = 1
      ._ICODE = "I"
      WrkStr = Replace(RecArray(19), "'", "")
      WrkStr = Trim(WrkStr)
      If Mid(WrkStr, 1, 1) = "/" Or Mid(WrkStr, 1, 1) = "%" Then
        WrkIsName = True
        Pos = 2
      End If
      If Strings.Right(Trim(RecArray(17)), 1) = "&" Or Strings.Right(Trim(RecArray(17)), 3) = "AND" Then
        WrkIsName = True
      End If
      If WrkIsName Then
        ._SNAME = ConvertString("Sname", Mid(WrkStr, Pos, 50), 35)
      Else
        ._ADD1 = ConvertString("Add1", WrkStr, 35)
      End If
      WrkStr = Trim(Replace(RecArray(20), "'", ""))
      If Trim(._ADD1) = "" Then
        ._ADD1 = ConvertString("Add2", WrkStr, 35)
        ._ADD2 = ""
      Else
        ._ADD2 = ConvertString("Add2", WrkStr, 35)
      End If
      ._CDATE = 0
      ._CITY = ConvertString("City", WrkCity, 25)
      If Trim(RecArray(10)) = "D" Then
        ._CCM = "Deferred"
      Else
        ._CCM = ""
      End If
      ._INTPD = 0
      ._LETT = Mid(RecArray(17), 1, 1)
      ._LISTNo = WrkListNo
      ._LNPD = CnvSng(RecArray(23))
      ._LOC = WrkLoc
      ._LOCNo = WrkLocNo
      WrkStr = Replace(RecArray(17), "'", "")
      WrkStr = Replace(WrkStr, ",", " ")
      ._NAME = ConvertString("Name", WrkStr, 35)
      ._RLST = 0
      ._STATE = WrkState
      If Trim(RecArray(14)) <> "" Then
        ._TXIDT = ConvertDate(RecArray(14))
      Else
        ._TXIDT = 0
      End If
      ._TYPE = "B"
      ._VOL = Trim(RecArray(4))
      ._IPAGE = Trim(RecArray(5))
      ._YEAR = 2000
      ._ZIP4 = 0
      ._ZIP5 = CnvSng(RecArray(22))
      ._TAX1 = CnvSng(RecArray(2))
      ._TAX2 = 0
      ._TAXT = ._TAX1 + ._TAX2
      ._PAYREC = CnvSng(RecArray(12))
      ._BOND = CnvSng(RecArray(13))
      ._BONDP = CnvSng(RecArray(13))
      ._BALD = ._TAXT - ._PAYREC
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine("UTAS-INV " & RecArray(0) & " " & .ErrMsg)
      End If
    End With

    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub UpdateUTAS()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTAS, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim WrkFileSize As Integer
    '    Dim RecArray As String()
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "UTAS"
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    WrkListNo = CnvSng(RecArray(0))
    '    If WrkListNo = 0 Then
    '      GoTo NextLine
    '    End If
    '    With MyUTCUST
    '      .GetOneRecordP(WrkListNo)
    '      If Not .RecordNotFound Then
    '        ._CUZONE = Trim(RecArray(9))
    '        .UpdateOneRecordP()
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Sub WriteUTXREF()
    '    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTXREF, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    '    Dim sr As StreamReader = New StreamReader(WrkStream)
    '    Dim RecArray As String()
    '    Dim WrkClass As String
    '    Dim WrkXref As String
    '    Dim WrkFileSize As Integer
    '    Dim WrkPct As Decimal
    '    Dim SavePct As Decimal
    '    Dim Counter As Decimal
    '    Dim I As Integer

    '    WrkFile = "UTXREF"
    '    'myDBConnect2.DeleteRecords2("UTXREF")
    '    WrkFileSize = WrkStream.Length
    '    strBuffer = sr.ReadLine 'Skip Header
    'NextLine:
    '    strBuffer = sr.ReadLine
    '    If Trim(strBuffer) = String.Empty Then
    '      Exit Sub
    '    End If

    '    I = I + strBuffer.Length
    '    RecArray = Parse(strBuffer, ",")
    '    WrkListNo = CnvSng(RecArray(10))
    '    WrkClass = Trim(RecArray(5))
    '    WrkXref = CnvSng(RecArray(3))

    '    With MyUTCUST
    '      .GetOneRecordP(WrkListNo)
    '      If .RecordNotFound Then
    '        GoTo NextLine
    '      End If
    '      If Trim(._CUPCAT) = "COM" And WrkClass = "RES" Then
    '        GoTo NextLine
    '      End If
    '    End With

    '    With MyUTXREF
    '      Counter = Counter + 1
    '      .GetOneRecordP(WrkListNo, "", WrkXref)
    '      If .RecordNotFound Then
    '        ._CXACCT = WrkListNo
    '        ._CXCODE = ""
    '        ._CXREF = WrkXref
    '        ._CXUSE = ""
    '        .AddOneRecordP()
    '      End If
    '      If .ErrMsg <> "" Then
    '        sw.WriteLine("UTXREF " & WrkListNo & " " & .ErrMsg)
    '      End If
    '    End With

    '    WrkPct = (Counter / 10) Mod 100
    '    If SavePct <> WrkPct Then
    '      ProgBar1.Value = WrkPct
    '      LblMsg.Text = "Records processed: " & Counter
    '      SavePct = WrkPct
    '      Application.DoEvents()
    '    End If
    '    GoTo NextLine
  End Sub
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine(WrkFile & "," & WrkListNo & "," & WrkField & "," & WrkStr & "," & ReturnStr)
    End If

    Return ReturnStr
  End Function
  Private Function ConvertDate(ByVal DateIn As Date) As Integer

    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDate(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateAlpha(ByVal DateIn As String) As Integer
    'IE: 31-Mar-1999

    Dim WrkMonth As Integer
    Dim ReturnDate As Integer
    Select Case Mid(DateIn, 4, 3).ToUpper
      Case "JAN"
        WrkMonth = 1
      Case "FEB"
        WrkMonth = 2
      Case "MAR"
        WrkMonth = 3
      Case "APR"
        WrkMonth = 4
      Case "MAY"
        WrkMonth = 5
      Case "JUN"
        WrkMonth = 6
      Case "JUL"
        WrkMonth = 7
      Case "AUG"
        WrkMonth = 8
      Case "SEP"
        WrkMonth = 9
      Case "OCT"
        WrkMonth = 10
      Case "NOV"
        WrkMonth = 11
      Case "DEC"
        WrkMonth = 12
      Case Else
    End Select
    If Trim(DateIn) <> "" Then
      ReturnDate = Mid(DateIn, 8, 4) & WrkMonth & Mid(DateIn, 1, 2)
    Else
      ReturnDate = 0
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateMDY(ByVal DateIn As Date) As Integer

    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDateMDY(DateIn)
    End If

    Return ReturnDate
  End Function
  Private Function GetSupCD(ByVal DateIn As String, ByVal IsCredit As Boolean) As String
    'IE: 31-Mar-1999
    Dim WrkMonth As String
    Dim ReturnCode As String
    WrkMonth = Mid(DateIn, 4, 3)
    Select Case WrkMonth.ToUpper
      Case "NOV"
        If IsCredit Then
          ReturnCode = "O"
        Else
          ReturnCode = "B"
        End If
      Case "DEC"
        If IsCredit Then
          ReturnCode = "P"
        Else
          ReturnCode = "C"
        End If
      Case "JAN"
        If IsCredit Then
          ReturnCode = "Q"
        Else
          ReturnCode = "D"
        End If
      Case "FEB"
        If IsCredit Then
          ReturnCode = "R"
        Else
          ReturnCode = "E"
        End If
      Case "MAR"
        If IsCredit Then
          ReturnCode = "S"
        Else
          ReturnCode = "F"
        End If
      Case "APR"
        If IsCredit Then
          ReturnCode = "T"
        Else
          ReturnCode = "G"
        End If
      Case "MAY"
        If IsCredit Then
          ReturnCode = "U"
        Else
          ReturnCode = "H"
        End If
      Case "JUN"
        If IsCredit Then
          ReturnCode = "W"
        Else
          ReturnCode = "I"
        End If
      Case "JUL"
        If IsCredit Then
          ReturnCode = "V"
        Else
          ReturnCode = "J"
        End If
      Case Else
        If IsCredit Then
          ReturnCode = "N"
        Else
          ReturnCode = "A"
        End If
    End Select
    Return ReturnCode
  End Function
  Private Function FormatZip(ByVal WrkZip As String) As String
    Dim Pos As Integer
    Dim WrkZipA As String

    If Trim(WrkZip) <> "" Then
      If Len(WrkZip) > 5 Then
        Pos = InStr(WrkZip, "-")
        If Pos = 0 Then
          WrkZipA = Mid(WrkZip, 1, 5) & "-" & Mid(WrkZip, 6, 4)
        Else
          WrkZipA = WrkZip
        End If
      Else
        WrkZipA = WrkZip
      End If
    Else
      WrkZipA = ""
    End If

    Return WrkZipA
  End Function
  Public Function GetTXVCLSCode(ByVal Desc As String) As Integer

    If Desc = "" Then
      Return 0
    End If

    MyTXVCLS.GetOneRecordP(Desc)
    If Not MyTXVCLS.RecordNotFound Then
      GetTXVCLSCode = MyTXVCLS._CLASS
    Else
      GetTXVCLSCode = 0
    End If
    Return GetTXVCLSCode

  End Function
  Public Function CnvListNoAlpha(ByVal WrkStr As String) As Integer
    Dim WrkNum As Integer
    Dim WrkAsc As Integer

    If Trim(WrkStr) <> "" Then
      WrkAsc = Asc(Mid(WrkStr, 1, 1)) - 64
      WrkNum = WrkAsc & Mid(WrkStr, 2, 5)
    Else
      WrkNum = 0
    End If
    Return WrkNum

  End Function
  Private Function CnvColorAbbr(ByVal WrkColor As String) As String

    Dim WrkAbbr As String

    WrkAbbr = ""
    Select Case Trim(WrkColor)
      Case "Beige"
        WrkAbbr = "BGE"
      Case "Black"
        WrkAbbr = "BLK"
      Case "Blue"
        WrkAbbr = "BLU"
      Case "Brown"
        WrkAbbr = "BRN"
      Case "Gold"
        WrkAbbr = "GLD"
      Case "Gray"
        WrkAbbr = "GRY"
      Case "Green"
        WrkAbbr = "GRN"
      Case "Orange"
        WrkAbbr = "ORN"
      Case "Purple"
        WrkAbbr = "PUR"
      Case "Red"
        WrkAbbr = "RED"
      Case "Tan"
        WrkAbbr = "TAN"
      Case "Unk"
        WrkAbbr = ""
      Case "White"
        WrkAbbr = "WHT"
      Case "Yellow"
        WrkAbbr = "YEL"
      Case Else
        WrkAbbr = UCase(Mid(WrkColor, 1, 3))
    End Select

    Return WrkAbbr
  End Function
  Public Sub BufferCodes(ByVal WrkType As String)
    Dim I As Integer

    Dim dsTXCode As DataSet = New DataSet

    dsTXCode = MyTXCODE.GetAllType(WrkType)
    For I = 0 To dsTXCode.Tables(0).Rows.Count - 1
      With dsTXCode.Tables(0).Rows(I)
        WrkTXCode(I) = .Item("tccode")
        WrkTXGrp(I) = .Item("tcgrp")
      End With
    Next

  End Sub
  Public Function LookupCodeGrp(ByVal Code As Integer) As String
    Dim I As Integer
    Dim WrkResult As String

    For I = 0 To WrkTXCode.GetUpperBound(0)
      If WrkTXCode(I) = 0 Then
        Return ""
      End If
      If Code = WrkTXCode(I) Then
        WrkResult = WrkTXGrp(I)
        Return WrkResult
      End If
    Next

    Return ""
  End Function
End Class