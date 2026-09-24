Imports System.Text
Imports System.IO
Public Class FrmMain
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTAXCOM As TAXCOM
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyUTCUST As UTCUST
  Dim MyUTCUSTAS As UTCUSTAS
  Dim MyUTCUSTMT As UTCUSTMT
  Dim MyUTCUSTRT As UTCUSTRT
  Dim MyUTXREF As UTXREF
  Dim WrkGLYear As Integer
  Dim WrkListNo As Integer
  Dim WrkCity As String
  Dim WrkLoc As String
  Dim WrkLocNo As String
  Dim WrkState As String
  Dim WrkFile As String
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
  End Sub
  Private Sub InitFiles()
    MyTAXCOM = New TAXCOM(myDBConnect2.MyConn2)
    MyTXINV = New TXINV(myDBConnect2.MyConn2)
    MyTXHST = New TXHST(myDBConnect2.MyConn2)
    MyUTCUST = New UTCUST(myDBConnect2.MyConn2)
    MyUTCUSTMT = New UTCUSTMT(myDBConnect2.MyConn2)
    MyUTCUSTAS = New UTCUSTAS(myDBConnect2.MyConn2)
    MyUTCUSTRT = New UTCUSTRT(myDBConnect2.MyConn2)
    MyUTXREF = New UTXREF(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvNorfolk.csv")
    ProgBar1.Visible = True
    WrkGLYear = 0
    WriteUTXREF
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub
  Private Sub Donotrun()
    'WriteUT()
    'WriteUTMAP()
    'WriteUTMT()
    'WriteINV()
    'WriteHST()
    'WriteTAXCOM()
    'UpdateMeterNo()
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
    WrkAddress = Replace(WrkAddress, " GREEN", " GRN")
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
    WrkAddress = Replace(WrkAddress, " VIEW", " VW")
    '    WrkAddress = Replace(WrkAddress, " ", "")
    WrkAddress = Replace(WrkAddress, ".", "")

    Return WrkAddress
  End Function
  Private Function ChgLoc(ByVal pAddress As String) As String

    Dim WrkAddress As String

    WrkAddress = pAddress
    WrkAddress = Replace(WrkAddress, "BLACKBERRY RIVER RD", "BLACKBERRY ST")
    WrkAddress = Replace(WrkAddress, "AETNA PL", "AETNA LN")
    WrkAddress = Replace(WrkAddress, "SUNSET RDG RD", "SUNSET RIDGE RD")
    Return WrkAddress
  End Function
  Private Sub SplitCityST(ByVal WrkCityST As String)
    Dim Pos As Integer
    WrkCity = ""
    WrkState = ""
    WrkCityST = Replace(WrkCityST, "  ", " ")
    WrkCityST = Replace(WrkCityST, ",", " ")
    WrkCityST = Replace(WrkCityST, ".", "")
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

  Private Sub WriteINV()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkPeriod As Integer
    Dim WrkPrin As Decimal
    Dim WrkLien As Decimal
    Dim WrkRateCode As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "INV"
    WrkStream = New FileStream(MyAppSettings.FileINV, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    myDBConnect2.DeleteRecords2("TXINV")
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
    WrkListNo = CnvSng(RecArray(0))
    WrkType = RecArray(2)
    WrkYear = Mid(RecArray(1), 1, 4)
    WrkPrin = CnvSng(RecArray(5))
    WrkLien = CnvSng(RecArray(6))
    WrkRateCode = RecArray(14)
    If WrkListNo <= 100 Then
      GoTo ShowPct
    End If
    WrkPeriod = Mid(RecArray(1), 5, 2)
    If WrkPeriod = 1 Then
      WrkYear = WrkYear - 1
    End If
    If WrkYear <= 2007 Then
      GoTo ShowPct
    End If
    If WrkType = "A" Then 'Skip Assessments
      GoTo ShowPct
    End If
    If WrkRateCode = "FL" Then
      WrkType = "F"
    End If
    With MyTXINV
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo, WrkYear, WrkType)
      If RecArray(3) = "C" Then
        Select Case WrkPeriod
          Case 1
            ._TAX2 = ._TAX2 + WrkPrin
          Case 7
            ._TAX1 = ._TAX1 + WrkPrin
        End Select
        ._TAXT = ._TAX1 + ._TAX2
        ._CCM = ""
        If WrkLien > 0 Then
          ._LIEN = "L"
        End If
      Else
        ._INTPD = ._INTPD + CnvSng(RecArray(8))
        ._LNPD = ._LNPD + WrkLien
        ._TXIDT = RecArray(9)
        ._PAYREC = ._PAYREC + WrkPrin
        If WrkLien > 0 Then
          ._LIEN = ""
        End If
      End If
      ._BALD = ._TAXT - ._PAYREC
      If .RecordNotFound Then
        MyUTCUST.GetOneRecordP(WrkListNo)
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
        .InsertOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine(WrkFile & ",Error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
      End If
    End With

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
  Private Sub WriteHST()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkPeriod As Integer
    Dim WrkPrin As Decimal
    Dim WrkLien As Decimal
    Dim WrkRecID As Integer
    Dim WrkRateCode As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "HST"
    WrkStream = New FileStream(MyAppSettings.FileHST, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    myDBConnect2.DeleteRecords2("TXHST")
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
    Counter = MyTXHST.AutoGenKey - 1

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkListNo = CnvSng(RecArray(0))
    WrkYear = Mid(RecArray(1), 1, 4)
    WrkType = RecArray(2)
    WrkPrin = CnvSng(RecArray(5))
    WrkLien = CnvSng(RecArray(6))
    WrkRateCode = RecArray(14)
    WrkPeriod = Mid(RecArray(1), 5, 2)
    If WrkPeriod = 1 Then
      WrkYear = WrkYear - 1
    End If
    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If MyTXINV.RecordNotFound Then
      GoTo ShowPct
    End If
    If WrkType = "A" Then 'Skip Assessments
      GoTo ShowPct
    End If
    If WrkYear <= 2007 Then
      GoTo ShowPct
    End If
    If RecArray(3) = "C" Then
      GoTo ShowPct
    End If
    If WrkRateCode = "FL" Then
      WrkType = "F"
    End If

    With MyTXHST
      Counter = Counter + 1
      WrkRecID = Counter
      If RecArray(13) = "V" Then
        ._RCODE = "V"
      End If
      ._ADJCD = ""
      ._BATCHA = ""
      ._BATCHN = 0
      ._BATCHS = 0
      ._CASH = 0
      ._CHECK = 0
      ._CREDIT = 0
      Select Case RecArray(11)
        Case = "C"
          ._CASH = WrkPrin
        Case = "K"
          ._CHECK = WrkPrin
        Case = "B"
          ._CREDIT = WrkPrin
      End Select
      ._CDATE = RecArray(9)
      ._CHDATE = RecArray(9)
      ._CHTIME = 0
      ._COMM = ""
      ._CORC = ""
      ._DIST = 0
      ._IAMT = CnvSng(RecArray(8))
      ._INTOR = 0
      If WrkLien <> 0 Then
        ._LAMT = WrkLien
      Else
        ._LAMT = 0
      End If
      ._LISTNO = WrkListNo
      ._PAMT = WrkPrin
      ._PCAMT = 0
      ._PENCD = ""
      If ._ADJCD = "" Then
        If ._PAMT < 0 Or ._IAMT < 0 Or ._LAMT < 0 Or ._IAMT < 0 Then
          ._ADJCD = "A"
        End If
      End If
      ._PDATE = RecArray(9)
      ._PENCD = ""
      ._PRF = RecArray(10)
      ._RCODE = ""
      ._RECID = WrkRecID
      If CnvSng(RecArray(12)) > 0 Then
        ._REF = CnvSng(RecArray(12))
      Else
        ._REF = ""
      End If
      ._SUSCD = ""
      ._THAJCD = ""
      ._THINPD = 0
      ._TYPE = WrkType
      ._YEAR = WrkYear
      .InsertOneRecordP()
    End With

ShowPct:
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
  Private Sub WriteUT()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

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
    RecArray = Parse(strBuffer, ",")
    WrkListNo = RecArray(0)
    If WrkListNo <= 100 Then
      GoTo NextLine
    End If
    With MyUTCUST
      Counter = Counter + 1
      SplitCityST(RecArray(5))
      SplitLoc(RecArray(10))
      .GetOneRecordP(WrkListNo)
      ._CUACCT = WrkListNo
      ._CUACRE = 0
      If Len(Trim(RecArray(3))) > 1 Then
        ._CUADD1 = Trim(CalcAddr(RecArray(3)))
        If Len(Trim(RecArray(4))) > 1 Then
          ._CUADD2 = Trim(CalcAddr(RecArray(4)))
        End If
      Else
        If Len(Trim(RecArray(4))) > 1 Then
          ._CUADD1 = Trim(CalcAddr(RecArray(4)))
        End If
        ._CUADD2 = ""
      End If
      ._CUADDX = ""
      ._CUAPLNO = ""
      ._CUAPMT = ""
      ._CUAPMT = ""
      ._CUAUNT = 0
      ._CUCITY = WrkCity
      ._CUCNTNO = ""
      ._CUDST = 0
      ._CUFOOT = 0
      ._CUFUND = 0
      ._CULAT = CnvSng(RecArray(137))
      ._CULONG = CnvSng(RecArray(138))
      ._CULOC = CalcAddr(WrkLoc)
      ._CULOCNO = WrkLocNo
      ._CUMAD1 = ""
      ._CUMAD2 = ""
      ._CUMAP = ""
      ._CUMCTY = ""
      ._CUMETN = Trim(RecArray(23))
      ._CUMETP = ""
      ._CUMSIZ = "1"
      ._CUEDU = 0
      ._CUMST = ""
      ._CUMZIP = ""
      If Trim(RecArray(1)) <> "" Then
        ._CUNAM1 = Replace(Trim(RecArray(1)), "'", "")
        ._CUNAM2 = Replace(Trim(RecArray(2)), "'", "")
      Else
        ._CUNAM1 = Replace(Trim(RecArray(2)), "'", "")
        ._CUNAM2 = ""
      End If
      ._CUPAGE = ""
      ._CUPCAT = ""
      ._CUPHAS = 0
      ._CUPVAL = 0
      ._CUREGN = ""
      ._CUROUT = Trim(Mid(RecArray(9), 1, 15))
      ._CUSCHR = 0
      ._CUSDES = ""
      ._CUSECT = ""
      ._CUSERN = Trim(RecArray(24))
      ._CUSFIX = 0
      ._CUST = WrkState
      ._CUTELNO = ""
      ._CUTIE = 0
      ._CUUNIT = 0
      ._CUUPMT = ""
      ._CUVOLM = ""
      ._CUWFIX = 0
      ._CUXREF = ""
      ._CUXTRA = 0
      ._CUZIP = Trim(RecArray(6))
      ._CUZONE = ""
      ._CYC = ""
      ._OID = ""
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine("UT " & WrkListNo & " " & .ErrMsg)
      End If
    End With

    If RecArray(18) <> "" Then
      With MyUTCUSTRT
        .GetOneRecordP(WrkListNo, "S")
        ._CRACCT = WrkListNo
        ._CRCODE = RecArray(18)
        ._CRTYPE = "S"
        .AddOneRecordP()
        If .ErrMsg <> "" Then
          sw.WriteLine("UTRT " & WrkListNo & " " & .ErrMsg)
        End If
      End With
    End If

    If RecArray(19) <> "" Then
      With MyUTCUSTRT
        If RecArray(19) = "FL" Then
          .GetOneRecordP(WrkListNo, "F")
        Else
          .GetOneRecordP(WrkListNo, "W")
        End If
        ._CRACCT = WrkListNo
        ._CRCODE = RecArray(19)
        If RecArray(19) = "FL" Then
          ._CRTYPE = "F"
        Else
          ._CRTYPE = "W"
        End If
        .AddOneRecordP()
          If .ErrMsg <> "" Then
          sw.WriteLine("UTRT " & WrkListNo & " " & .ErrMsg)
        End If
      End With
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
  Private Sub WriteUTMT()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTMT, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkDBDate As Integer
    Dim SaveAcct As Integer
    Dim SaveDate As Integer
    Dim SaveRead As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "UTMT"
    myDBConnect2.DeleteRecords2("UTCUSTMT")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    If Mid(RecArray(4), 1, 1) = "/" Then GoTo NextLine 'Bad Reading
    WrkListNo = CnvSng(RecArray(0))
    If WrkListNo = 0 Then GoTo NextLine
    WrkDBDate = CnvSng(RecArray(1))
    If CnvSng(RecArray(2)) = 0 Then GoTo NextLine 'Zero Reading

    With MyUTCUSTMT
      Counter = Counter + 1
      If SaveAcct <> WrkListNo Then
        SaveAcct = WrkListNo
        SaveRead = 0
      End If
      If WrkDBDate < 20200101 Then
        SaveRead = CnvSng(RecArray(2))
        GoTo NextLine
      End If
      .GetOneRecordP(WrkListNo, "", WrkDBDate)
      ._CMACCT = WrkListNo
      ._CMDATE = WrkDBDate
      ._CMREAD = CnvSng(RecArray(2))
      ._CMRESN = ""
      ._CMTYPE = ""
      If SaveRead > 0 Then
        ._CMUSE = CnvSng(RecArray(2)) - SaveRead
        If ._CMUSE < -50 Then
          ._CMUSE = CnvSng(RecArray(2)) 'New Meter
        End If
      Else
        ._CMUSE = 0
      End If
      If .RecordNotFound Then
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine("UT " & WrkListNo & " " & .ErrMsg)
      End If
      If WrkDBDate <> SaveDate Then
        SaveRead = CnvSng(RecArray(2))
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
  Private Sub WriteUTXREF()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUTXREF, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkXREF As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "UTXREF"
    myDBConnect2.DeleteRecords2("UTXREF")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkListNo = CnvSng(RecArray(0))
    WrkXREF = Trim(RecArray(3))
    If Wrkxref = "" Then GoTo NextLine

    With MyUTXREF
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo, "", WrkXREF)
      ._CXACCT = WrkListNo
      ._CXCODE = ""
      ._CXREF = WrkXREF
      ._CXUSE = ""
      If .RecordNotFound Then
        .AddOneRecordP()
      End If
      If .ErrMsg <> "" Then
        sw.WriteLine("UTXREF " & WrkListNo & " " & .ErrMsg)
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
      If WrkListNo <= 100 Then
        GoTo ShowPct
      End If
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
  Private Sub UpdateMeterNo()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileMETERNO, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim SaveLoc As String
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "MeterNo"
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
    SaveLoc = ""

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkListNo = RecArray(0)
    With MyUTCUST
      Counter = Counter + 1
      SplitLoc(RecArray(2))
      WrkLoc = CalcAddr(WrkLoc)
      WrkLoc = ChgLoc(WrkLoc)
      If WrkLocNo = "      2" Then
        Counter = Counter
      End If
      If SaveLoc <> WrkLoc & WrkLocNo Then
        .GetOneRecordPLoc(WrkLoc, WrkLocNo)
        If Not .RecordNotFound Then
          If Trim(._CUMETN) = "" Or Mid(._CUMETN, 1, 5) = "00000" Then
            ._CUSERN = ""
            ._CUMETN = ""
            If Trim(RecArray(3)) <> "MULTIPLE 001" Then
              ._CUMETN = Replace(RecArray(3), " 001", "")
              ._CUMETN = CnvSng(._CUMETN)
            Else
              If Trim(RecArray(6)) <> "MULTIPLE 001" Then
                ._CUMETN = Replace(RecArray(6), " 001", "")
                ._CUMETN = CnvSng(._CUMETN)
              End If
            End If
            If ._CUMETN <> "0" Then
              .UpdateOneRecordP()
              If .ErrMsg <> "" Then
                sw.WriteLine("UTCUST " & WrkListNo & " " & .ErrMsg)
              End If
            End If
          End If
        End If
        SaveLoc = WrkLoc & WrkLocNo
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
  Private Sub WriteUTMAP()
    Dim WrkStream As FileStream = New FileStream(MyAppSettings.FileUT, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "UT-MAP"
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkListNo = RecArray(0)
    If WrkListNo <= 100 Then
      GoTo NextLine
    End If
    With MyUTCUST
      Counter = Counter + 1
      .GetOneRecordP(WrkListNo)
      If Not .RecordNotFound Then
        ._CUMAP = Trim(RecArray(12))
        .UpdateOneRecordP()
        If .ErrMsg <> "" Then
          sw.WriteLine("UT-MAP " & WrkListNo & " " & .ErrMsg)
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
  Private Function ConvertDateMDY(ByVal DateIn As Date) As Integer

    Dim ReturnDate As Integer
    If DateIn = #1/1/1900# Then
      ReturnDate = 0
    Else
      ReturnDate = SetDBDateMDY(DateIn)
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