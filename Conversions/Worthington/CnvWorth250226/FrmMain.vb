Imports System.Text
Imports System.IO
Imports System.Reflection
Public Class FrmMain
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTAXCOM As TAXCOM
  Dim MyTXINV As TXINV
  Dim MyTXINVDTL As TXINVDTL
  Dim MyTXHST As TXHST
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTAS As UTCUSTAS
  Dim MyUTCUSTMT As UTCUSTMT
  Dim MyUTCUSTMTD As UTCUSTMTD
  Dim MyUTCUSTRT As UTCUSTRT
  Dim MyUTXREF As UTXREF
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkCity As String
  Dim WrkLoc As String
  Dim WrkLocNo As String
  Dim WrkState As String
  Dim WrkZipA As String
  Dim WrkFile As String
  Dim WrkLocID(5000) As Integer
  Dim WrkCustID(5000) As Integer
  Dim WrkMIU(5000) As String
  Dim cLastYear As Integer = 2009
  Dim cQtrYear As Integer = 2021
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
  End Sub
  Private Sub InitFiles()
    MyTAXCOM = New TAXCOM(myDBConnect2.MyConn2)
    MyTXINV = New TXINV(myDBConnect2.MyConn2)
    MyTXINVDTL = New TXINVDTL(myDBConnect2.MyConn2)
    MyTXHST = New TXHST(myDBConnect2.MyConn2)
    MyUTCUST = New UTCUST(myDBConnect2.MyConn2)
    MyUTCUSTMT = New UTCUSTMT(myDBConnect2.MyConn2)
    MyUTCUSTMTD = New UTCUSTMTD(myDBConnect2.MyConn2)
    MyUTCUSTAS = New UTCUSTAS(myDBConnect2.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnect2.MyConn2)
    MyUTXREF = New UTXREF(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvWorth.csv")
    ProgBar1.Visible = True
    WrkGLYear = 0
    BufferLocID()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUST" & vbCrLf
    'WriteUT()
    WriteUT2()
    'WriteUT3()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTCUSTMT" & vbCrLf
    'WriteUTMT()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "UTXREF" & vbCrLf
    'WriteUTXREF()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "INV" & vbCrLf
    'WriteINV()
    'WriteINVMisc()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "HST" & vbCrLf
    'WriteHST()
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub Donotrun()
    'TxtErrorMsg.Text = TxtErrorMsg.Text & "TAXCOM" & vbCrLf
    'WriteTAXCOM()
  End Sub

  Private Function CalcAddr(ByVal pAddress As String) As String

    Dim WrkAddress As String

    WrkAddress = pAddress
    WrkAddress = Replace(WrkAddress, "'", "")
    WrkAddress = Replace(WrkAddress, "/", "")
    WrkAddress = Replace(WrkAddress, "#", "")
    WrkAddress = Replace(WrkAddress, " AVENUE", " AVE")
    WrkAddress = Replace(WrkAddress, " AVENU", " AVE")
    WrkAddress = Replace(WrkAddress, " AV", " AVE")
    WrkAddress = Replace(WrkAddress, " AVEE", " AVE")
    WrkAddress = Replace(WrkAddress, " CIRCLE", " CIR")
    WrkAddress = Replace(WrkAddress, " COURT", " CT")
    WrkAddress = Replace(WrkAddress, " DRIVE", " DR")
    WrkAddress = Replace(WrkAddress, " HEIGHTS", " HTS")
    WrkAddress = Replace(WrkAddress, " HGTS", " HTS")
    WrkAddress = Replace(WrkAddress, " HT", " HTS")
    WrkAddress = Replace(WrkAddress, " HTSS", " HTS")
    WrkAddress = Replace(WrkAddress, " LANE", " LN")
    WrkAddress = Replace(WrkAddress, " LA", " LN")
    WrkAddress = Replace(WrkAddress, " PARKWAY", " PKY")
    WrkAddress = Replace(WrkAddress, " PLACE", " PL")
    WrkAddress = Replace(WrkAddress, " ROAD", " RD")
    WrkAddress = Replace(WrkAddress, " RIDGE", " RDG")
    WrkAddress = Replace(WrkAddress, " STREET", " ST")
    WrkAddress = Replace(WrkAddress, " TERRACE", " TER")
    WrkAddress = Replace(WrkAddress, " TERR", " TER")
    '    WrkAddress = Replace(WrkAddress, " ", "")
    WrkAddress = Replace(WrkAddress, ".", "")

    Return WrkAddress
  End Function
  Private Sub SplitCityST(ByVal WrkCityST As String)
    Dim Pos As Integer
    WrkCityST = Replace(WrkCityST, ",,", ",") & ""
    WrkCity = ""
    WrkState = ""
    WrkZipA = ""
    If WrkCityST <> "" Then
      Pos = InStrRev(WrkCityST, ",")
      WrkCity = Mid(WrkCityST, 1, Pos - 1)
      WrkState = Mid(WrkCityST, Pos + 2, 2)
      WrkZipA = Mid(WrkCityST, Pos + 5, 10)
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
      WrkLoc = CalcAddr(WrkLoc)
    Else
      WrkLoc = WrkStr
      WrkLocNo = ""
    End If
  End Sub

  Private Sub WriteINV()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkYear As Integer
    Dim WrkDate As Date
    Dim WrkPeriod As Integer
    Dim WrkSewerChg As Decimal
    Dim WrkWaterChg As Decimal
    Dim WrkMeterChg As Decimal
    Dim WrkPrinPaid As Decimal
    Dim WrkPrinWater As Decimal
    Dim WrkPrinSewer As Decimal
    Dim WrkIntPaid As Decimal
    Dim WrkIntDate As Integer
    Dim WrkMonthly As Boolean
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim WrkMax As Integer
    Dim I As Integer
    Dim Pos As Integer

    WrkFile = "INV"
    WrkStream = New FileStream(MyAppSettings.FileINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    myDBConnect2.DeleteRecords2("TXINV")
    myDBConnect2.DeleteRecords2("TXINVDTL")
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = Replace(sr.ReadLine, "'", "")
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    WrkListNo = CnvSng(RecArray(3)) 'Customer ID
    WrkDate = RecArray(6)
    WrkPeriod = WrkDate.Month
    If WrkPeriod < 7 Then
      WrkYear = WrkDate.Year - 1
    Else
      WrkYear = WrkDate.Year
    End If
    If Trim(RecArray(7)) <> "" And IsDate(RecArray(7)) Then
      WrkIntDate = ConvertDate(RecArray(7))
    Else
      WrkIntDate = 0
    End If
    If WrkMax = 23 Then
      WrkMeterChg = CnvSng(RecArray(18))
      WrkWaterChg = CnvSng(RecArray(16)) + WrkMeterChg
      WrkSewerChg = CnvSng(RecArray(17))
      WrkIntPaid = CnvSng(RecArray(19))
      WrkPrinPaid = CnvSng(RecArray(20))
      If WrkPrinPaid >= WrkIntPaid Then
        WrkPrinPaid = WrkPrinPaid - WrkIntPaid
      End If
      GoTo Process
    End If

FindLine:
    strBuffer = sr.ReadLine 'Skip Header
    Pos = InStr(strBuffer, Chr(34))
    If Pos = 0 Then
      GoTo FindLine
    End If
    RecArray = Parse(strBuffer, ",")
    WrkMeterChg = CnvSng(RecArray(8))
    WrkWaterChg = CnvSng(RecArray(6)) + WrkMeterChg
    WrkSewerChg = CnvSng(RecArray(7))
    WrkIntPaid = CnvSng(RecArray(9))
    WrkPrinPaid = CnvSng(RecArray(10))
    If WrkPrinPaid >= WrkIntPaid Then
      WrkPrinPaid = WrkPrinPaid - WrkIntPaid
    End If

Process:
    Counter = Counter + 1
    If WrkYear < cLastYear Then
      GoTo ShowPct
    End If
    If Trim(RecArray(4)) = "MC" Then 'skip misc charges
      GoTo ShowPct
    End If
    WrkMonthly = CheckMonthly(WrkListNo)
    If WrkPrinPaid >= WrkWaterChg Then
      WrkPrinWater = WrkWaterChg
      WrkPrinSewer = WrkPrinPaid - WrkPrinWater
    Else
      WrkPrinWater = WrkPrinPaid
      WrkPrinSewer = 0
    End If
    If Not WrkMonthly Then
      If WrkWaterChg > 0 Then
        If WrkPrinSewer > 0 Then
          WriteTXINV(WrkListNo, "W", WrkYear, WrkPeriod, WrkWaterChg, WrkPrinWater, 0, WrkIntDate)
        Else
          WriteTXINV(WrkListNo, "W", WrkYear, WrkPeriod, WrkWaterChg, WrkPrinWater, WrkIntPaid, WrkIntDate)
          WrkIntPaid = 0
        End If
      End If
      If WrkSewerChg > 0 Or WrkIntPaid > 0 Then
        WriteTXINV(WrkListNo, "S", WrkYear, WrkPeriod, WrkSewerChg, WrkPrinSewer, WrkIntPaid, WrkIntDate)
      End If
    Else
      If WrkWaterChg > 0 Then
        If WrkPrinSewer > 0 Then
          WriteTXINV(WrkListNo, "Z", WrkYear, WrkPeriod, WrkWaterChg, WrkPrinWater, 0, WrkIntDate)
          WriteTXINVDTL(WrkListNo, "Z", WrkYear, WrkPeriod, "MO", WrkWaterChg)
        Else
          WriteTXINV(WrkListNo, "Y", WrkYear, WrkPeriod, WrkWaterChg, WrkPrinWater, WrkIntPaid, WrkIntDate)
          WriteTXINVDTL(WrkListNo, "Y", WrkYear, WrkPeriod, "MO", WrkWaterChg)
          WrkIntPaid = 0
        End If
      End If
      If WrkSewerChg > 0 Or WrkIntPaid > 0 Then
        WriteTXINV(WrkListNo, "Y", WrkYear, WrkPeriod, WrkSewerChg, WrkPrinSewer, WrkIntPaid, WrkIntDate)
        WriteTXINVDTL(WrkListNo, "Y", WrkYear, WrkPeriod, "MO", WrkSewerChg)
      End If
    End If

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteINVMisc()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkYear As Integer
    Dim WrkDate As Date
    Dim WrkPeriod As Integer
    Dim WrkMiscChg As Decimal
    Dim WrkPrinPaid As Decimal
    Dim WrkMonthly As Boolean
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim WrkMax As Integer
    Dim I As Integer
    Dim Pos As Integer

    WrkFile = "INV"
    WrkStream = New FileStream(MyAppSettings.FileINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = Replace(sr.ReadLine, "'", "")
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    WrkListNo = CnvSng(RecArray(3)) 'Customer ID
    WrkDate = RecArray(6)
    WrkPeriod = WrkDate.Month
    If WrkPeriod < 7 Then
      WrkYear = WrkDate.Year - 1
    Else
      WrkYear = WrkDate.Year
    End If
    If WrkMax = 23 Then
      WrkMiscChg = CnvSng(RecArray(4))
      WrkPrinPaid = CnvSng(RecArray(20))
      GoTo Process
    End If

FindLine:
    strBuffer = sr.ReadLine 'Skip Header
    Pos = InStr(strBuffer, Chr(34))
    If Pos = 0 Then
      GoTo FindLine
    End If
    RecArray = Parse(strBuffer, ",")
    WrkMiscChg = CnvSng(RecArray(4))
    WrkPrinPaid = CnvSng(RecArray(11))

Process:
    Counter = Counter + 1
    If WrkYear < 2021 Or WrkListNo < 100 Then
      GoTo ShowPct
    End If
    If Trim(RecArray(4)) = "RD" Then 'skip reading charges
      GoTo ShowPct
    End If
    WrkMonthly = CheckMonthly(WrkListNo)
    If Not WrkMonthly And (WrkMiscChg - WrkPrinPaid) > 0 Then
      UpdateTXINVMisc(WrkListNo, "W", WrkYear, WrkPeriod, WrkMiscChg - WrkPrinPaid)
    End If

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Function CheckMonthly(ByVal WrkListNo As Integer) As Boolean
    Dim Found As Boolean
    Select Case WrkListNo
      Case 1027 'Powerhouse
        Found = True
      Case 1047 'Strykers
        Found = True
      Case 1196 'Berlin Board of Ed
        Found = True
      Case 1673 'Marty, LLC
        Found = True
      Case 1777 'Picture Show Entertainment
        Found = True
      Case 1964 'Spin Cycle
        Found = True
      Case 2137 'Joey B Restaurant
        Found = True
      Case 2287 'Dupont
        Found = True
      Case Else
        Found = False
    End Select
    Return Found
  End Function
  Private Sub WriteTXINV(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkPeriod As Integer,
   ByVal WrkPrin As Decimal, ByVal WrkPrinPaid As Decimal, ByVal WrkIntPaid As Decimal, ByVal WrkIntDate As Integer)

    With MyTXINV
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      If WrkYear < cQtrYear Then
        Select Case WrkPeriod
          Case 7, 8, 9, 10, 11, 12
            ._TAX1 = ._TAX1 + WrkPrin
          Case 1, 2, 3, 4, 5, 6
            ._TAX2 = ._TAX2 + WrkPrin
          Case Else
            Exit Sub
        End Select
      Else
        Select Case WrkPeriod
          Case 7, 8, 9
            ._TAX1 = ._TAX1 + WrkPrin
          Case 10, 11, 12
            ._TAX2 = ._TAX2 + WrkPrin
          Case 1, 2, 3
            ._TX3RD = ._TX3RD + WrkPrin
          Case 4, 5, 6
            ._TX4TH = ._TX4TH + WrkPrin
          Case Else
            Exit Sub
        End Select
      End If
      ._TAXT = ._TAX1 + ._TAX2 + ._TX3RD + ._TX4TH
      ._CCM = ""
      ._INTPD = ._INTPD + WrkIntPaid
      ._LNPD = 0
      If WrkIntDate > ._TXIDT Then
        ._TXIDT = WrkIntDate
      End If
      ._PAYREC = ._PAYREC + WrkPrinPaid
      ._BALD = ._TAXT - ._PAYREC
      MyUTCUST.GetOneRecordP(WrkListNo)
      If MyUTCUST.RecordNotFound Then
        Exit Sub
      End If
      ._ADD1 = Trim(MyUTCUST._CUADD1)
      ._ADD2 = Trim(MyUTCUST._CUADD2)
      ._CITY = Trim(MyUTCUST._CUCITY)
      ._LETT = Mid(MyUTCUST._CUNAM1, 1, 1)
      ._LISTNo = WrkListNo
      ._LOC = Trim(MyUTCUST._CULOC)
      ._LOCNo = MyUTCUST._CULOCNO
      ._TYPE = WrkType
      ._NAME = Trim(MyUTCUST._CUNAM1)
      ._SNAME = Trim(MyUTCUST._CUNAM2)
      ._STATE = Trim(MyUTCUST._CUST)
      ._YEAR = WrkYear
      ._ZIP5 = CnvSng(Mid(MyUTCUST._CUZIP, 1, 5))
      If Len(MyUTCUST._CUZIP) > 5 Then
        ._ZIP4 = CnvSng(Mid(MyUTCUST._CUZIP, 7, 4))
      End If
      If .RecordNotFound Then
        .InsertOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine(WrkFile & ",Error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
      End If
    End With
  End Sub
  Private Sub WriteTXINVDTL(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkPeriod As Integer,
   ByVal WrkCode As String, ByVal WrkPrin As Decimal)

    With MyTXINVDTL
      MyUTCUST.GetOneRecordP(WrkListNo)
      If MyUTCUST.RecordNotFound Then
        Exit Sub
      End If
      .GetOneRecordP(WrkListNo, WrkYear, WrkType, WrkPeriod, WrkCode)
      ._LISTNo = WrkListNo
      ._TYPE = WrkType
      ._YEAR = WrkYear
      ._PERD = WrkPeriod
      ._CODE = WrkCode
      ._AMOUNT = ._AMOUNT + WrkPrin
      If .RecordNotFound Then
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine(WrkFile & ",Error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
      End If
    End With
  End Sub
  Private Sub UpdateTXINVMisc(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkPeriod As Integer,
   ByVal WrkMisc As Decimal)

    With MyTXINV
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      ._FED1 = ._FED1 + WrkMisc
      ._FEC1 = "MC"
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine(WrkFile & ",Error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
      End If
    End With
  End Sub
  Private Sub WriteHST()

    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkYear As Integer
    Dim WrkMonthly As Boolean
    Dim WrkDateBilled As Date
    Dim WrkDatePaid As Date
    Dim WrkPeriod As Integer
    Dim WrkPrinSewer As Decimal
    Dim WrkPrinWater As Decimal
    Dim WrkIntPaid As Decimal
    Dim WrkBatchNo As Integer
    Dim WrkRef As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim Good As Boolean
    Dim I As Integer

    WrkFile = "HST"
    WrkStream = New FileStream(MyAppSettings.FileHST, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    myDBConnect2.DeleteRecords2("TXHST")
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header

NextLine:
    strBuffer = Replace(sr.ReadLine, "'", "")
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If
    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkDateBilled = RecArray(25)
    WrkPeriod = WrkDateBilled.Month
    If WrkPeriod < 7 Then
      WrkYear = WrkDateBilled.Year - 1
    Else
      WrkYear = WrkDateBilled.Year
    End If
    If WrkDateBilled < #10/1/2009# Then
      GoTo ShowPct
    End If
    WrkDatePaid = RecArray(7)

Process:
    Counter = Counter + 1
    WrkListNo = CnvSng(RecArray(12))
    MyUTCUST.GetOneRecordP(WrkListNo)
    If MyUTCUST.RecordNotFound Then
      GoTo ShowPct
    End If

    WrkMonthly = CheckMonthly(WrkListNo)
    WrkPrinWater = CnvSng(RecArray(1)) + CnvSng(RecArray(3)) 'Water+Meter
    WrkPrinSewer = CnvSng(RecArray(0))
    WrkIntPaid = CnvSng(RecArray(5))
    WrkBatchNo = CnvSng(RecArray(8))
    WrkRef = RecArray(6)
    'Water
    Good = False
    If Not WrkMonthly Then
      If WrkPrinWater > 0 Then
        If WrkPrinSewer > 0 Then
          WriteTXHST(WrkListNo, "W", WrkYear, WrkBatchNo, WrkPrinWater, 0, ConvertDate(WrkDatePaid), WrkRef)
        Else
          WriteTXHST(WrkListNo, "W", WrkYear, WrkBatchNo, WrkPrinWater, WrkIntPaid, ConvertDate(WrkDatePaid), WrkRef)
          WrkIntPaid = 0
        End If
      End If
      'Sewer
      If WrkPrinSewer > 0 Or WrkIntPaid > 0 Then
        WriteTXHST(WrkListNo, "S", WrkYear, WrkBatchNo, WrkPrinSewer, WrkIntPaid, ConvertDate(WrkDatePaid), WrkRef)
      End If
    Else
      If WrkPrinWater > 0 Then
        If WrkPrinSewer > 0 Then
          WriteTXHST(WrkListNo, "Z", WrkYear, WrkBatchNo, WrkPrinWater, 0, ConvertDate(WrkDatePaid), WrkRef)
        Else
          WriteTXHST(WrkListNo, "Z", WrkYear, WrkBatchNo, WrkPrinWater, WrkIntPaid, ConvertDate(WrkDatePaid), WrkRef)
          WrkIntPaid = 0
        End If
      End If
      'Sewer
      If WrkPrinSewer > 0 Or WrkIntPaid > 0 Then
        WriteTXHST(WrkListNo, "Y", WrkYear, WrkBatchNo, WrkPrinSewer, WrkIntPaid, ConvertDate(WrkDatePaid), WrkRef)
      End If
    End If

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      '          .Refresh()
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteTXHST(WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer, ByVal WrkBatchNo As Integer,
    ByVal WrkPrin As Decimal, ByVal WrkIntPaid As Decimal, ByVal WrkDate As Integer, ByVal WrkRef As String)
    Dim WrkRecID As Decimal
    With MyTXHST
      WrkRecID = .AutoGenKey
      ._ADJCD = ""
      ._BATCHA = ""
      ._BATCHN = WrkBatchNo
      ._BATCHS = 0
      ._CASH = 0
      ._CHECK = 0
      ._CREDIT = 0
      ._CASH = 0
      ._CHECK = 0
      ._CREDIT = 0
      ._CDATE = WrkDate
      ._CHDATE = WrkDate
      ._CHTIME = 0
      ._COMM = ""
      ._CORC = ""
      ._DIST = 0
      ._IAMT = WrkIntPaid
      ._INTOR = 0
      ._LAMT = 0
      ._LISTNO = WrkListNo
      ._PAMT = WrkPrin
      ._PCAMT = 0
      ._PENCD = ""
      ._PDATE = WrkDate
      ._PENCD = ""
      ._PRF = ""
      ._RCODE = ""
      ._RECID = WrkRecID
      ._REF = WrkRef
      ._SUSCD = ""
      ._THAJCD = ""
      ._THINPD = 0
      ._TYPE = WrkType
      ._YEAR = WrkYear
      .InsertOneRecordP()
    End With
  End Sub
  Private Sub WriteUT()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim WrkCO As Boolean
    Dim WrkAcct As String
    Dim WrkMonthly As Boolean

    WrkFile = "UT"
    myDBConnect2.DeleteRecords2("UTCUST")
    myDBConnect2.DeleteRecords2("UTCUSTRT")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer.ToUpper, ",")
    WrkListNo = RecArray(1)
    WrkAcct = Trim(Mid(RecArray(27), 3, 10))
    WrkMonthly = CheckMonthly(WrkListNo)
    With MyUTCUST
      Counter = Counter + 1
      SplitLoc(RecArray(9))
      If Mid(RecArray(5), 1, 3) = "C/O" Then
        WrkCO = True
      Else
        WrkCO = False
      End If
      .GetOneRecordP(WrkListNo)
      If Not .RecordNotFound Then
        GoTo NextLine
      End If
      ._CUACCT = WrkListNo
      ._CUACRE = 0
      If WrkCO Then
        ._CUADD1 = Trim(CalcAddr(RecArray(6)))
        ._CUADD2 = ""
        ._CUNAM1 = ConvertString("CUNAM1", Replace(Trim(RecArray(4)), "'", ""), 35)
        ._CUNAM2 = ConvertString("CUNAM2", Replace(Trim(RecArray(5)), "'", ""), 35)
        SplitCityST(RecArray(7))
      Else
        If Trim(RecArray(7)) = "" Then
          ._CUADD1 = Trim(CalcAddr(RecArray(5)))
          ._CUADD2 = ""
          ._CUNAM1 = ConvertString("CUNAM1", Replace(Trim(RecArray(4)), "'", ""), 35)
          ._CUNAM2 = ""
          SplitCityST(RecArray(6))
        Else
          ._CUADD1 = ConvertString("CUADD1", Trim(CalcAddr(RecArray(5))), 25)
          ._CUADD2 = ConvertString("CUADD2", Trim(CalcAddr(RecArray(6))), 25)
          ._CUNAM1 = ConvertString("CUNAM1", Replace(Trim(RecArray(4)), "'", ""), 35)
          ._CUNAM2 = ""
          SplitCityST(RecArray(7))
        End If
      End If
      ._CUADDX = ""
      ._CUAPLNO = ""
      ._CUAPMT = ""
      ._CUAPMT = ""
      ._CUAUNT = 0
      ._CUCITY = WrkCity
      ._CUCNTNO = ""
      ._CUFOOT = 0
      ._CUFUND = 0
      ._CULAT = 0
      ._CULONG = 0
      ._CULOC = WrkLoc
      ._CULOCNO = WrkLocNo
      ._CUMAD1 = ""
      ._CUMAD2 = ""
      ._CUMAP = ""
      ._CUMCTY = ""
      ._CUMETN = ""
      ._CUMETP = ""
      ._CUMSIZ = "1"
      ._CUEDU = 0
      ._CUMST = ""
      ._CUMZIP = ""
      ._CUPAGE = ""
      Select Case Mid(RecArray(27), 1, 1)
        Case "1"
          ._CUPCAT = "RES"
          ._CUDST = 1
        Case "2"
          ._CUPCAT = "BUS"
          ._CUDST = 2
        Case "3"
          ._CUPCAT = "IND"
          ._CUDST = 3
        Case Else
          ._CUPCAT = ""
          ._CUDST = 0
      End Select
      If WrkMonthly Then
        ._CUPCAT = "MTH"
        ._CUDST = 4
      End If
      ._CUPHAS = 0
      ._CUPVAL = 0
      ._CUREGN = ""
      ._CUROUT = ""
      ._CUSCHR = 0
      ._CUSDES = ""
      ._CUSECT = ""
      ._CUSERN = ""
      ._CUSFIX = 0
      ._CUST = WrkState
      ._CUTELNO = ""
      ._CUTIE = 0
      ._CUUNIT = 0
      ._CUUPMT = ""
      ._CUVOLM = ""
      ._CUWFIX = 0
      ._CUXREF = WrkAcct
      ._CUXTRA = 0
      ._CUZIP = WrkZipA
      ._CUZONE = ""
      ._CYC = ""
      ._OID = ""
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine("UT " & WrkListNo & " " & .ErrMsg)
      End If
    End With

    If Not WrkMonthly Then
      If RecArray(17) <> "" Then
        With MyUTCUSTRT
          .GetOneRecordP(WrkListNo, "S")
          ._CRACCT = WrkListNo
          ._CRCODE = "1"
          ._CRTYPE = "S"
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            sw.WriteLine("UTRT-S " & WrkListNo & " " & .ErrMsg)
          End If
        End With
      End If

      If RecArray(18) <> "" Or RecArray(19) <> "" Then
        With MyUTCUSTRT
          .GetOneRecordP(WrkListNo, "W")
          ._CRACCT = WrkListNo
          ._CRCODE = "1"
          ._CRTYPE = "W"
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            sw.WriteLine("UTRT-W " & WrkListNo & " " & .ErrMsg)
          End If
        End With
      End If
    End If

    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub BufferLocID()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTXREF, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim TempBuffer As String
    Dim WrkMax As Integer
    Dim I As Integer
    Dim J As Integer

    J = 0
    If WrkLocID(0) > 0 Then 'Already populated
      Exit Sub
    End If

    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = Replace(sr.ReadLine, "'", "")
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax = 30 Then
      GoTo Process
    End If

FindLine: 'Combine lines until there is a full record
    TempBuffer = sr.ReadLine
    strBuffer = strBuffer + TempBuffer
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax <> 30 Then
      GoTo FindLine
    End If

Process:
    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    If Trim(RecArray(21)) <> "" Then
      WrkLocID(J) = RecArray(0)
      WrkCustID(J) = RecArray(1)
      WrkMIU(J) = RecArray(21)
      J = J + 1
    End If
    GoTo NextLine
  End Sub
  Public Function LookupLocID(ByVal LocID As Integer) As Integer
    Dim I As Integer

    For I = 0 To WrkCustID.GetUpperBound(0)
      If Trim(WrkLocID(I)) = 0 Then
        Return -1
      End If
      If Trim(LocID = WrkLocID(I)) Then
        Return I
      End If
    Next
    Return -1
  End Function
  Private Sub WriteUT2()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT2, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim K As Integer

    WrkFile = "UT"
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    strBuffer = Replace(strBuffer, Chr(34), "")
    strBuffer = Replace(strBuffer, Chr(34), "-")
    RecArray = Parse(strBuffer, ",")
    K = LookupLocID(RecArray(0))
    If K < 0 Then
      GoTo NextLine
    End If

    WrkListNo = WrkCustID(K)
    With MyUTCUST
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo)
      If Not .RecordNotFound Then
        ._CUMETN = RecArray(5)
        ._CUMSIZ = "1"
        ._CUSDES = Trim(RecArray(3))
        .UpdateOneRecordP()
        If .ErrMsg <> "" Then
          sw.WriteLine("UT2 " & WrkListNo & " " & .ErrMsg)
        End If
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
  Private Sub WriteUT3()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT3, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim TempBuffer As String
    Dim WrkName As String
    Dim WrkMonthly As Boolean
    Dim WrkMax As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "UT3"
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax = 13 Then
      GoTo Process
    End If

FindLine: 'Combine lines until there is a full record
    TempBuffer = sr.ReadLine
    strBuffer = strBuffer + TempBuffer
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax <> 13 Then
      GoTo FindLine
    End If

Process:
    If Trim(RecArray(8)) = "I" Then
      GoTo ShowPct
    End If
    WrkListNo = CnvSng(RecArray(0))
    WrkName = ""
    If Trim(RecArray(2)) <> "" Then
      WrkName = Trim(RecArray(1)) & " " & RecArray(2)
    Else
      WrkName = RecArray(1)
    End If
    WrkName = UCase(WrkName)
    WrkName = Replace(WrkName, ",", "")
    With MyUTCUST
      Counter = Counter + 1
      WrkMonthly = CheckMonthly(WrkListNo)
      .GetOneRecordP(WrkListNo)
      If Not .RecordNotFound Then
        ._CUNAM1 = ConvertString("CUNAM1", WrkName, 35)
        ._CUNAM2 = ""
        ._CUTELNO = ConvertString("CUTELNO", RecArray(9), 15)
        .UpdateOneRecordP()
        If .ErrMsg <> "" Then
          sw.WriteLine("UT3 " & WrkListNo & " " & .ErrMsg)
        End If
      Else
        SplitLoc(CalcAddr(UCase(RecArray(3))))
        ._CUACCT = WrkListNo
        ._CUACRE = 0
        ._CUADD1 = Trim(CalcAddr(UCase(RecArray(3))))
        ._CUADD2 = Trim(UCase(RecArray(4)))
        ._CUNAM1 = ConvertString("CUNAM1", WrkName, 35)
        ._CUNAM2 = ""
        ._CUADDX = ""
        ._CUAPLNO = ""
        ._CUAPMT = ""
        ._CUAPMT = ""
        ._CUAUNT = 0
        ._CUCITY = Trim(UCase(RecArray(5)))
        ._CUCNTNO = ""
        ._CUFOOT = 0
        ._CUFUND = 0
        ._CULAT = 0
        ._CULONG = 0
        ._CULOC = WrkLoc
        ._CULOCNO = WrkLocNo
        ._CUMAD1 = ""
        ._CUMAD2 = ""
        ._CUMAP = ""
        ._CUMCTY = ""
        ._CUMETN = ""
        ._CUMETP = ""
        ._CUMSIZ = "1"
        ._CUEDU = 0
        ._CUMST = ""
        ._CUMZIP = ""
        ._CUPAGE = ""
        If WrkMonthly Then
          ._CUPCAT = "MTH"
          ._CUDST = 4
        End If
        ._CUPHAS = 0
        ._CUPVAL = 0
        ._CUREGN = ""
        ._CUROUT = ""
        ._CUSCHR = 0
        ._CUSDES = ""
        ._CUSECT = ""
        ._CUSERN = ""
        ._CUSFIX = 0
        ._CUST = RecArray(6)
        ._CUTELNO = ""
        ._CUTIE = 0
        ._CUUNIT = 0
        ._CUUPMT = ""
        ._CUVOLM = ""
        ._CUWFIX = 0
        ._CUXREF = ""
        ._CUXTRA = 0
        ._CUZIP = Trim(RecArray(7))
        ._CUZONE = ""
        ._CYC = ""
        ._OID = ""
        .AddOneRecordP()
      End If

      If WrkMonthly Then
        With MyUTCUSTRT
          .GetOneRecordP(WrkListNo, "Y")
          ._CRACCT = WrkListNo
          ._CRCODE = "1"
          ._CRTYPE = "Y"
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            sw.WriteLine("UTRT-Y " & WrkListNo & " " & .ErrMsg)
          End If
        End With

        With MyUTCUSTRT
          .GetOneRecordP(WrkListNo, "Z")
          ._CRACCT = WrkListNo
          ._CRCODE = "1"
          ._CRTYPE = "Z"
          .AddOneRecordP()
          If .ErrMsg <> "" Then
            sw.WriteLine("UTRT-Z " & WrkListNo & " " & .ErrMsg)
          End If
        End With
      End If
    End With

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteUTMT()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim TempBuffer As String
    Dim WrkMax As Integer
    Dim WrkDate As Date
    Dim WrkDBDate As Integer
    Dim WrkRead As Integer
    Dim WrkUse As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim K As Integer

    WrkFile = "UTMT"
    myDBConnect2.DeleteRecords2("UTCUSTMT")
    myDBConnect2.DeleteRecords2("UTCUSTMTD")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = Replace(sr.ReadLine, "'", "")
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    WrkListNo = CnvSng(RecArray(3)) 'Customer ID
    If WrkMax = 23 Then
      GoTo Process
    End If

FindLine: 'Combine lines until there is a full record
    TempBuffer = sr.ReadLine
    strBuffer = strBuffer + TempBuffer
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax <> 23 Then
      GoTo FindLine
    End If

Process:
    Counter = Counter + 1
    WrkDate = RecArray(6)
    WrkDBDate = ConvertDate(WrkDate)
    If WrkDate.Year < cLastYear Then
      GoTo ShowPct
    End If
    If Trim(RecArray(4)) = "MC" Then 'skip misc charges
      GoTo ShowPct
    End If
    WrkRead = CnvSng(RecArray(10))
    WrkUse = CnvSng(RecArray(12))

    With MyUTCUST
      .GetOneRecordP(WrkListNo)
      If .RecordNotFound Then
        GoTo ShowPct
      End If
    End With

    With MyUTCUSTMT
      Counter = Counter + 1
      If WrkDBDate < 20210101 Or WrkRead = 0 Then
        GoTo NextLine
      End If
      .GetOneRecordP(WrkListNo, "", WrkDBDate)
      ._CMRESN = ""
      ._CMTYPE = ""
      If .RecordNotFound Then
        ._CMACCT = WrkListNo
        ._CMDATE = WrkDBDate
        ._CMREAD = WrkRead
        ._CMUSE = WrkUse
        .AddOneRecordP()
      Else
        ._CMUSE = ._CMUSE + WrkUse
        ._CMREAD = ._CMUSE
        .UpdateOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine("UTMT " & WrkListNo & " " & .ErrMsg)
      End If
    End With

    K = LookupLocID(RecArray(2))
    If K < 0 Then
      GoTo NextLine
    End If
    If WrkListNo = 0 Then
      GoTo NextLine
    End If
    With MyUTCUSTMTD
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo, WrkMIU(K), "", WrkDBDate)
      ._CMRESN = ""
      ._CMTYPE = ""
      ._CMACCT = WrkListNo
      ._CMDATE = WrkDBDate
      ._CMXREF = WrkMIU(K)
      ._CMDESC1 = ""
      ._CMDESC2 = ""
      If .RecordNotFound Then
        ._CMREAD = WrkRead
        ._CMUSE = WrkUse
        .AddOneRecordP()
      Else
        ._CMREAD = WrkRead
        ._CMUSE = ._CMUSE + WrkUse
        .UpdateOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine("UTMTD " & WrkListNo & " " & .ErrMsg)
      End If
    End With

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteUTXREF()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTXREF, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim TempBuffer As String
    Dim WrkMax As Integer
    Dim WrkCode As String
    Dim WrkXRef As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "UTXREF"
    myDBConnect2.DeleteRecords2("UTXREF")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = Replace(sr.ReadLine, "'", "")
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax = 30 Then
      GoTo Process
    End If

FindLine: 'Combine lines until there is a full record
    TempBuffer = sr.ReadLine
    strBuffer = strBuffer + TempBuffer
    RecArray = Parse(strBuffer, ",")
    WrkMax = RecArray.GetUpperBound(0)
    If WrkMax <> 30 Then
      GoTo FindLine
    End If

Process:
    WrkListNo = CnvSng(RecArray(1)) 'Customer ID
    WrkCode = ""
    WrkXRef = Trim(RecArray(21))
    If Trim(WrkXRef) = "" Then
      GoTo ShowPct
    End If
    If RecArray(6) = "I" Then
      GoTo ShowPct
    End If
    With MyUTXREF
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo, WrkCode, WrkXRef)
      ._CXACCT = WrkListNo
      ._CXCODE = WrkCode
      ._CXREF = WrkXRef
      ._CXUSE = ""
      If .RecordNotFound Then
        .AddOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine("UTXREF " & WrkListNo & " " & .ErrMsg)
      End If
    End With

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Sub WriteTAXCOM()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim SaveList As Integer
    Dim WrkYear As Integer
    Dim WrkType As String
    Dim WrkSeq As Integer
    Dim WrkStr As String
    Dim BuildStr As String
    Dim WrkNewList As Boolean
    Dim WrkLen As Integer
    Dim WrkRecs As Integer
    Dim WrkPos As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim WrkEof As Boolean
    Dim I As Integer

    WrkFile = "TAXCOM"
    WrkStream = New FileStream(MyAppSettings.FileTAXCOM, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    myDBConnect2.DeleteRecords2("TAXCOM")
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
    SaveList = 0
    WrkNewList = True
    WrkYear = 0
    WrkType = "U"
    WrkStr = ""
    BuildStr = ""
    Counter = 0

NextLine:
    strBuffer = sr.ReadLine
    If sr.EndOfStream Then
      WrkLen = Len(BuildStr)
      WrkRecs = Math.Ceiling(WrkLen / 60)
      For I = 0 To WrkRecs - 1
        WrkPos = (I * 60) + 1
        With MyTAXCOM
          WrkSeq = WrkSeq + 1
          .GetOneRecordP(SaveList, WrkType, 0, WrkSeq)
          ._CMNT = Mid(BuildStr, WrkPos, 60)
          ._CSEQ = WrkSeq
          ._LISTNO = WrkListNo
          ._TYPE = WrkType
          ._YEAR = WrkYear
          .AddOneRecordP()
        End With
      Next
      sr.Close()
      Exit Sub
    End If
    If Trim(strBuffer) = String.Empty Then
      GoTo NextLine
    End If

    Counter = Counter + 1
    WrkEof = False
    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    If WrkNewList Then
      WrkLen = Len(Trim(BuildStr))
      WrkRecs = Math.Ceiling(WrkLen / 60)
      If WrkLen > 0 Then
        For I = 0 To WrkRecs - 1
          WrkPos = (I * 60) + 1
          With MyTAXCOM
            WrkSeq = WrkSeq + 1
            .GetOneRecordP(SaveList, WrkType, 0, WrkSeq)
            ._CMNT = Mid(BuildStr, WrkPos, 60)
            ._CSEQ = WrkSeq
            ._LISTNO = WrkListNo
            ._TYPE = WrkType
            ._YEAR = WrkYear
            .AddOneRecordP()
          End With
        Next
      End If
      WrkSeq = 0
      WrkNewList = True
      WrkListNo = CnvSng(RecArray(0))
      Select Case UBound(RecArray, 1)
        Case 0
          WrkStr = Trim(RecArray(0))
        Case 1
          WrkStr = Trim(RecArray(1))
        Case 2
          WrkStr = Trim(RecArray(2))
      End Select
      BuildStr = ""
    Else
      Select Case UBound(RecArray, 1)
        Case 0
          WrkStr = Trim(RecArray(0))
        Case 1
          WrkStr = Trim(RecArray(1))
        Case 2
          WrkStr = Trim(RecArray(2))
      End Select
    End If
    SaveList = WrkListNo
    If WrkStr = "*" Then
      If UBound(RecArray, 1) = 2 Then
        BuildStr = BuildStr & "  " & Trim(RecArray(1))
      Else
        BuildStr = BuildStr & "  " & Trim(RecArray(0))
      End If
      WrkNewList = True
      GoTo ShowPct
    End If
    BuildStr = BuildStr & "  " & WrkStr
    WrkNewList = False

ShowPct:
    WrkPct = (Counter / 10) Mod 100
    If SavePct <> WrkPct Then
      ProgBar1.Value = WrkPct
      LblMsg.Text = "Records processed: " & Counter
      SavePct = WrkPct
      Application.DoEvents()
    End If
    GoTo NextLine
  End Sub
  Private Function ConvertString(ByVal WrkField As String, ByVal WrkStr As String, ByVal WrkLen As Integer) As String

    Dim ReturnStr As String
    WrkStr = Trim(WrkStr)
    ReturnStr = Mid(WrkStr, 1, WrkLen)
    If Len(WrkStr) > WrkLen Then
      sw.WriteLine(WrkFile & "," & WrkListNo & "," & WrkField & "," & Chr(34) & WrkStr & Chr(34) & "," & Chr(34) & ReturnStr & Chr(34))
    End If

    Return ReturnStr
  End Function
  Private Function ConvertDate(ByVal DateIn As Date) As Integer
    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      If IsDate(DateIn) Then
        ReturnDate = SetDBDate(DateIn)
      Else
        ReturnDate = 0
      End If
    End If

    Return ReturnDate
  End Function
  Private Function ConvertDateMDY(ByVal DateIn As Date) As Integer

    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      If IsDate(DateIn) Then
        ReturnDate = SetDBDateMDY(DateIn)
      Else
        ReturnDate = 0
      End If
    End If
    Return ReturnDate
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
End Class