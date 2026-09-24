Imports System.Text
Imports System.IO
Public Class FrmAvon
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTXREAL As TXREAL
  Dim MyTXPPRP As TXPPRP
  Dim MyTXMVD As TXMVD
  Dim MyTXCODE As TXCODE
  Dim MyTXVCLS As TXVCLS
  Dim MyTXVEH As TXVEH
  Dim MyTXVCUS As TXVCUS
  Dim WrkFile As String
  Dim WrkListNo As Integer
  Dim WrkCity As String
  Dim WrkState As String
  Public WrkTXCode(100) As Integer
  Public WrkTXGrp(100) As String
  Const cAssPct As Decimal = 0.7
  Const cClassicVehicle As Integer = 500
  Const cMinValue As Integer = 200
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    WrkFile = ""
    LblMsg.Text = ""
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
  End Sub
  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePathRE.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePathRE.Text = .FileName
    End With
  End Sub
  Private Sub InitFiles()
    MyTXREAL = New TXREAL(myDBConnect2.MyConn2)
    MyTXPPRP = New TXPPRP(myDBConnect2.MyConn2)
    MyTXMVD = New TXMVD(myDBConnect2.MyConn2)
    MyTXCODE = New TXCODE(myDBConnect2.MyConn2)
    MyTXVCLS = New TXVCLS(myDBConnect2.MyConn2)
    MyTXVEH = New TXVEH(myDBConnect2.MyConn2)
    MyTXVCUS = New TXVCUS(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvAvonRPM.csv")
    ProgBar1.Visible = True
    If LblFilePathRE.Text <> "" Then
      WriteRE()
    End If
    If LblFilePathPP.Text <> "" Then
      WritePP()
    End If
    If LblFilePathMV.Text <> "" Then
      WriteMV()
    End If
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = "Done"
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
  Private Sub WriteRE()
    Dim WrkStream As FileStream = New FileStream(LblFilePathRE.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkCodes(6) As Integer
    Dim WrkAss(6) As Integer
    Dim WrkAcres(6) As Decimal
    Dim WrkUnits(6) As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer
    Dim J As Integer

    WrkFile = "RE"
    BufferCodes("R")
    myDBConnect2.DeleteRecords2("TXREAL")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    If RecArray(10) = "" Then
      GoTo NextLine
    End If
    Array.Clear(WrkCodes, 0, 6)
    Array.Clear(WrkAss, 0, 6)
    Array.Clear(WrkAcres, 0, 6)
    Array.Clear(WrkUnits, 0, 6)
    J = -1
    If CnvSng(RecArray(37)) > 0 And CnvSng(RecArray(38)) > 0 Then
      J = J + 1
      WrkCodes(J) = RecArray(37)
      WrkAss(J) = CnvSng(RecArray(38))
      If LookupCodeGrp(WrkCodes(J)) = "B" Then
        WrkAcres(J) = 0
        WrkUnits(J) = CnvSng(RecArray(36))
      Else
        WrkAcres(J) = CnvSng(RecArray(36))
        WrkUnits(J) = 0
      End If
    End If
    If CnvSng(RecArray(40)) > 0 And CnvSng(RecArray(41)) > 0 Then
      J = J + 1
      WrkCodes(J) = RecArray(40)
      WrkAss(J) = CnvSng(RecArray(41))
      If LookupCodeGrp(WrkCodes(J)) = "B" Then
        WrkAcres(J) = 0
        WrkUnits(J) = CnvSng(RecArray(39))
      Else
        WrkAcres(J) = CnvSng(RecArray(39))
        WrkUnits(J) = 0
      End If
    End If
    If CnvSng(RecArray(43)) > 0 And CnvSng(RecArray(44)) > 0 Then
      J = J + 1
      WrkCodes(J) = RecArray(43)
      WrkAss(J) = CnvSng(RecArray(44))
      If LookupCodeGrp(WrkCodes(J)) = "B" Then
        WrkAcres(J) = 0
        WrkUnits(J) = CnvSng(RecArray(42))
      Else
        WrkAcres(J) = CnvSng(RecArray(42))
        WrkUnits(J) = 0
      End If
    End If
    If CnvSng(RecArray(46)) > 0 And CnvSng(RecArray(47)) > 0 Then
      J = J + 1
      WrkCodes(J) = RecArray(46)
      WrkAss(J) = CnvSng(RecArray(47))
      If LookupCodeGrp(WrkCodes(J)) = "B" Then
        WrkAcres(J) = 0
        WrkUnits(J) = CnvSng(RecArray(45))
      Else
        WrkAcres(J) = CnvSng(RecArray(45))
        WrkUnits(J) = 0
      End If
    End If
    If CnvSng(RecArray(49)) > 0 And CnvSng(RecArray(50)) > 0 Then
      J = J + 1
      WrkCodes(J) = RecArray(49)
      WrkAss(J) = CnvSng(RecArray(50))
      If LookupCodeGrp(WrkCodes(J)) = "B" Then
        WrkAcres(J) = 0
        WrkUnits(J) = CnvSng(RecArray(48))
      Else
        WrkAcres(J) = CnvSng(RecArray(48))
        WrkUnits(J) = 0
      End If
    End If

    SplitCityST(Trim(RecArray(20)))
    With MyTXREAL
      Counter = Counter + 1
      WrkListNo = RecArray(0)
      .GetOneRecordP(WrkListNo)
      ._AACRE = 0
      ._ACCTN = ""
      ._ACRE1 = WrkAcres(0)
      ._ACRE2 = WrkAcres(1)
      ._ACRE3 = WrkAcres(2)
      ._ACRE4 = WrkAcres(3)
      ._ACRE5 = WrkAcres(4)
      ._ACRE6 = 0
      ._ACRE7 = 0
      ._ADD1 = ConvertString("Add1", RecArray(19), 35)
      ._ADD2 = ConvertString("Add2", "", 35)
      ._AEDATE = 0
      ._AIDTE = 0
      ._ASS1 = WrkAss(0)
      ._ASS2 = WrkAss(1)
      ._ASS3 = WrkAss(2)
      ._ASS4 = WrkAss(3)
      ._ASS5 = WrkAss(4)
      ._ASS6 = 0
      ._ASS7 = 0
      ._BKCD = ""
      ._BKSV = ""
      ._BTC = ""
      ._BTR = 0
      ._CARD = ""
      ._CASS1 = 0
      ._CASS2 = 0
      ._CASS3 = 0
      ._CASS4 = 0
      ._CASS5 = 0
      ._CASS6 = 0
      ._CASS7 = 0
      If Trim(RecArray(2)) <> "" Then
        ._CAT = "3"
        ._EXMPT = Trim(RecArray(2))
      Else
        ._CAT = "1"
        ._EXMPT = ""
      End If
      ._CCCD1 = ""
      ._CCCD2 = ""
      ._CCCD3 = ""
      ._CCCD4 = ""
      ._CCCD5 = ""
      ._CCCD6 = ""
      ._CCCD7 = ""
      ._CCEX = 0
      ._CCGRS = 0
      ._CCNO = 0
      ._CCRS = ""
      ._CDATE = 0
      ._CENBK = 0
      ._CENTR = 0
      ._CEXA1 = 0
      ._CEXA2 = 0
      ._CEXA3 = 0
      ._CEXA4 = 0
      ._CEXA5 = 0
      ._CEXA6 = 0
      ._CEXA7 = 0
      ._CHDATE = 0
      ._CHTIME = 0
      ._CIRAD = 0
      ._CITY = ConvertString("City", WrkCity, 25)
      ._CMAX = 0
      ._CMIN = 0
      ._CODE1 = CnvSng(WrkCodes(0))
      ._CODE2 = CnvSng(WrkCodes(1))
      ._CODE3 = CnvSng(WrkCodes(2))
      ._CODE4 = CnvSng(WrkCodes(3))
      ._CODE5 = CnvSng(WrkCodes(4))
      ._CODE6 = 0
      ._CODE7 = 0
      ._CPERC = 0
      ._DIST = 0
      ._DNBTR = 0
      ._DTBTR = 0
      ._EXAM1 = CnvSng(RecArray(159))
      ._EXAM2 = CnvSng(RecArray(161))
      ._EXAM3 = CnvSng(RecArray(163))
      ._EXAM4 = CnvSng(RecArray(165))
      ._EXAM5 = CnvSng(RecArray(167))
      ._EXAM6 = 0
      ._EXAM7 = 0
      ._EXCD1 = Trim(RecArray(158))
      ._EXCD2 = Trim(RecArray(160))
      ._EXCD3 = Trim(RecArray(162))
      ._EXCD4 = Trim(RecArray(164))
      ._EXCD5 = Trim(RecArray(166))
      ._EXCD6 = ""
      ._EXCD7 = ""
      ._FASS = 0
      ._FCCOD = ""
      ._FCYR = 0
      ._FTAX = 0
      ._GROSS = ._ASS1 + ._ASS2 + ._ASS3 + ._ASS4 + ._ASS5
      ._LETT = Mid(RecArray(62), 1, 1)
      ._LISTNO = WrkListNo
      ._LOC = ConvertString("Loc", RecArray(5), 25)
      ._LOCNO = JustifyRight(RecArray(4), 7)
      ._MAP = ConvertString("Map", CnvSng(RecArray(9)), 17)
      RecArray(62) = Replace(Trim(RecArray(62)), "  ", " ")
      ._NAME = ConvertString("Name", RecArray(62), 35)
      RecArray(63) = Replace(Trim(RecArray(63)), "  ", " ")
      ._SNAME = ConvertString("Sname", RecArray(63), 35)
      ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5
      ._OID = ""
      ._PDST = 0
      ._PERC = 0
      ._PGE = ConvertString("Pge", RecArray(65), 5)
      ._PRF = ""
      ._PURDT = 0
      ._PURPR = 0
      ._RLST = 0
      ._SEWER = ""
      ._SMAP = ""
      ._SS2 = 0
      ._SSNO = 0
      ._STATE = ConvertString("State", WrkState, 2)
      ._TIN = ""
      ._TWNBN = 0
      ._TYPE = "R"
      ._UNIT1 = WrkUnits(0)
      ._UNIT2 = WrkUnits(1)
      ._UNIT3 = WrkUnits(2)
      ._UNIT4 = WrkUnits(3)
      ._UNIT5 = WrkUnits(4)
      ._UNIT6 = 0
      ._UNIT7 = 0
      ._UNITNO = ""
      ._VOL = ConvertString("Vol", RecArray(64), 5)
      ._VTYR = 0
      ._WMAIL = ""
      ._ZIP4 = CnvSng(RecArray(22))
      ._ZIP5 = CnvSng(RecArray(21))
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine("RE " & WrkListNo & " " & .ErrMsg)
      End If
    End With

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
  Private Sub WritePP()
    Dim WrkStream As FileStream = New FileStream(LblFilePathPP.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkCodes(6) As Integer
    Dim WrkAss(6) As Integer
    Dim WrkUnits(6) As Decimal
    Const cMaxAmount As Long = 9999999
    Dim I As Integer
    Dim J As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal

    WrkFile = "PP"
    myDBConnect2.DeleteRecords2("TXPPRP")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If
    strBuffer = Replace(strBuffer, "'", "")
    strBuffer = Replace(strBuffer, "21a", "21")
    strBuffer = Replace(strBuffer, "21b", "21")
    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    Array.Clear(WrkCodes, 0, 6)
    Array.Clear(WrkAss, 0, 6)
    Array.Clear(WrkUnits, 0, 6)
    SplitCityST(Trim(RecArray(5)))

    With MyTXPPRP
      Counter = Counter + 1
      J = -1
      If CnvSng(RecArray(15)) > 0 Then
        J = J + 1
        WrkCodes(J) = CnvSng(RecArray(13))
        WrkAss(J) = RecArray(15)
        WrkUnits(J) = CnvSng(RecArray(14))
      End If
      If CnvSng(RecArray(18)) > 0 Then
        J = J + 1
        WrkCodes(J) = CnvSng(RecArray(16))
        WrkAss(J) = RecArray(18)
        WrkUnits(J) = CnvSng(RecArray(17))
      End If
      If CnvSng(RecArray(21)) > 0 Then
        J = J + 1
        WrkCodes(J) = CnvSng(RecArray(19))
        WrkAss(J) = RecArray(21)
        WrkUnits(J) = CnvSng(RecArray(20))
      End If
      If CnvSng(RecArray(24)) > 0 Then
        J = J + 1
        WrkCodes(J) = CnvSng(RecArray(22))
        WrkAss(J) = RecArray(24)
        WrkUnits(J) = CnvSng(RecArray(23))
      End If
      If CnvSng(RecArray(27)) > 0 Then
        J = J + 1
        WrkCodes(J) = CnvSng(RecArray(25))
        WrkAss(J) = RecArray(27)
        WrkUnits(J) = CnvSng(RecArray(26))
      End If
      If CnvSng(RecArray(28)) > 0 Then
        J = J + 1
        WrkCodes(J) = 25
        WrkAss(J) = RecArray(28)
        WrkUnits(J) = 0
      End If
      WrkListNo = RecArray(0)
      .GetOneRecordP(WrkListNo)
      ._ADD1 = ConvertString("Add1", RecArray(4), 35)
      ._ADD2 = ConvertString("Add2", "", 35)
      ._ADYR = 0
      ._ASS1 = WrkAss(0)
      ._ASS2 = WrkAss(1)
      ._ASS3 = WrkAss(2)
      ._ASS4 = WrkAss(3)
      ._ASS5 = WrkAss(4)
      ._ASS6 = WrkAss(5)
      ._ASS7 = WrkAss(6)
      ._ASS8 = 0
      ._ASS9 = 0
      ._ASS10 = 0
      ._BTC = ""
      ._BTR = 0
      ._BUS = ""
      ._BUSTY = ""
      ._CASS1 = 0
      ._CASS2 = 0
      ._CASS3 = 0
      ._CASS4 = 0
      ._CASS5 = 0
      ._CASS6 = 0
      ._CASS7 = 0
      ._CASS8 = 0
      ._CASS9 = 0
      ._CASSA = 0
      ._CAT = "5"
      ._CCCD1 = ""
      ._CCCD2 = ""
      ._CCCD3 = ""
      ._CCCD4 = ""
      ._CCCD5 = ""
      ._CCEX = 0
      ._CCGRS = 0
      ._CCNO = 0
      ._CCRS = ""
      ._CDATE = 0
      ._CEXA1 = 0
      ._CEXA2 = 0
      ._CEXA3 = 0
      ._CEXA4 = 0
      ._CEXA5 = 0
      ._CHDATE = 0
      ._CHTIME = 0
      ._CITY = WrkCity
      ._CODE1 = WrkCodes(0)
      ._CODE2 = WrkCodes(1)
      ._CODE3 = WrkCodes(2)
      ._CODE4 = WrkCodes(3)
      ._CODE5 = WrkCodes(4)
      ._CODE6 = WrkCodes(5)
      ._CODE7 = WrkCodes(6)
      ._CODE8 = 0
      ._CODE9 = 0
      ._CODEA = 0
      ._DIST = 0
      ._DNBTR = ""
      ._DTBTR = 0
      If CnvSng(RecArray(30)) > cMaxAmount Then
        ._EXAM1 = cMaxAmount
        sw.WriteLine("PP Exam1 " & WrkListNo & " " & CnvSng(RecArray(30)))
      Else
        ._EXAM1 = CnvSng(RecArray(30))
      End If
      If CnvSng(RecArray(32)) > cMaxAmount Then
        ._EXAM2 = cMaxAmount
        sw.WriteLine("PP Exam2 " & WrkListNo & " " & CnvSng(RecArray(32)))
      Else
        ._EXAM2 = CnvSng(RecArray(32))
      End If
      If CnvSng(RecArray(34)) > cMaxAmount Then
        ._EXAM3 = cMaxAmount
        sw.WriteLine("PP Exam3 " & WrkListNo & " " & CnvSng(RecArray(34)))
      Else
        ._EXAM3 = CnvSng(RecArray(34))
      End If
      If CnvSng(RecArray(36)) > cMaxAmount Then
        ._EXAM4 = cMaxAmount
        sw.WriteLine("PP Exam4 " & WrkListNo & " " & CnvSng(RecArray(36)))
      Else
        ._EXAM4 = CnvSng(RecArray(36))
      End If
      If CnvSng(RecArray(38)) > cMaxAmount Then
        ._EXAM5 = cMaxAmount
        sw.WriteLine("PP Exam5 " & WrkListNo & " " & CnvSng(RecArray(38)))
      Else
        ._EXAM5 = CnvSng(RecArray(38))
      End If
      ._EXCD1 = Trim(RecArray(29))
      ._EXCD2 = Trim(RecArray(31))
      ._EXCD3 = Trim(RecArray(33))
      ._EXCD4 = Trim(RecArray(35))
      ._EXCD5 = Trim(RecArray(37))
      ._GROSS = CnvSng(RecArray(12))
      ._LETT = Mid(RecArray(2), 1, 1)
      ._LISTNO = WrkListNo
      ._LOCNO = JustifyRight(RecArray(8), 7)
      ._LOC = ConvertString("Loc", RecArray(9), 25)
      ._NAME = ConvertString("Name", RecArray(2), 35)
      ._SNAME = ConvertString("Sname", RecArray(3), 35)
      ._NET = ._GROSS - ._EXAM1 - ._EXAM2 - ._EXAM3 - ._EXAM4 - ._EXAM5
      ._OID = ""
      ._PDST = 0
      ._PRF = ""
      ._RDATE = 0
      ._SQFT = 0
      ._SS2 = 0
      ._SSNO = 0
      ._STATE = WrkState
      ._TIN = ""
      ._TYPE = "P"
      ._UNIT1 = 0 'WrkUnits(0)
      ._UNIT2 = 0 'WrkUnits(1)
      ._UNIT3 = 0 'WrkUnits(2)
      ._UNIT4 = 0 'WrkUnits(3)
      ._UNIT5 = 0 'WrkUnits(4)
      ._UNIT6 = 0 'WrkUnits(5)
      ._UNIT7 = 0 'WrkUnits(6)
      ._UNIT8 = 0
      ._UNIT9 = 0
      ._UNITA = 0
      ._ZIP4 = CnvSng(RecArray(7))
      ._ZIP5 = CnvSng(RecArray(6))
      .AddOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine("PP " & WrkListNo & " " & .ErrMsg)
      End If
    End With

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
  Private Sub WriteMV()
    Dim WrkStream As FileStream = New FileStream(LblFilePathMV.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    Dim sr As StreamReader = New StreamReader(WrkStream)
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "MV"
    myDBConnect2.DeleteRecords2("TXMVD")
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    SplitCityST(Trim(RecArray(33)))
    With MyTXMVD
      Counter = Counter + 1
      WrkListNo = CnvListNoAlpha(RecArray(0))
      .GetOneRecordP(WrkListNo)
      ._ADD1 = ConvertString("Add1", RecArray(32), 35)
      ._ADD2 = ConvertString("Add1", "", 35)
      ._ASS = ""
      ._BODY = RecArray(8)
      ._BTC = ""
      ._BTR = 0
      ._CAT = "1"
      ._CCCD1 = ""
      ._CCCD2 = ""
      ._CCCD3 = ""
      ._CCCD4 = ""
      ._CCCD5 = ""
      ._CCEX = 0
      ._CCGRS = 0
      ._CCNO = 0
      ._CCRS = ""
      ._CDATE = 0
      ._CEXA1 = 0
      ._CEXA2 = 0
      ._CEXA3 = 0
      ._CEXA4 = 0
      ._CEXA5 = 0
      ._CHDATE = 0
      ._CHTIME = 0
      MyTXVCLS.GetOneRecordP(Trim(RecArray(2)))
      If Not MyTXVCLS.RecordNotFound Then
        ._CLASS = MyTXVCLS._CLASS
      Else
        ._CLASS = 0
      End If
      ._CYCLE = 0
      If CnvSng(RecArray(9)) < 10 Then
        ._CYLAX = CnvSng(RecArray(9))
      Else
        ._CYLAX = 0
      End If
      ._CITY = ConvertString("City", WrkCity, 25)
      ._DIST = 0
      ._DNBTR = 0
      ._DOB = ConvertDateAlpha(RecArray(24))
      ._DTBTR = 0
      ._EXAM1 = CnvSng(RecArray(44))
      ._EXAM2 = CnvSng(RecArray(46))
      ._EXAM3 = CnvSng(RecArray(48))
      ._EXAM4 = CnvSng(RecArray(50))
      ._EXAM5 = CnvSng(RecArray(52))
      ._EXCD1 = Trim(RecArray(43))
      ._EXCD2 = Trim(RecArray(45))
      ._EXCD3 = Trim(RecArray(47))
      ._EXCD4 = Trim(RecArray(49))
      ._EXCD5 = Trim(RecArray(51))
      ._GWT = CnvSng(RecArray(11))
      ._LEASE = Trim(RecArray(36))
      ._LETT = Mid(RecArray(18), 1, 1)
      ._LISTNO = WrkListNo
      ._LNVAL = CnvSng(RecArray(57))
      ._LOC = ""
      ._LOCNO = ""
      ._LWT = CnvSng(RecArray(10))
      ._MAKE = Mid(RecArray(3), 1, 5)
      ._MODEL = Mid(RecArray(5), 1, 8)
      ._MSRP = CnvSng(RecArray(59))
      ._NADA = ""
      ._NAME = ConvertString("Name", RecArray(18), 35)
      ._SNAME = ConvertString("Sname", RecArray(25), 35)
      ._OASS = ""
      ._OCLS = 0
      ._OCODE = 0
      ._OID = CnvSng(RecArray(74))
      ._OLIST = 0
      ._OMAKE = ""
      ._OMOD = ""
      ._OPVAL = 0
      ._OREGNO = ""
      ._ORIG = 0
      ._OVAL = 0
      ._OVIN = ""
      ._OYEAR = 0
      ._PCCOD = 0
      ._PCLR = CnvColorAbbr(RecArray(12))
      ._PDST = 0
      ._PNET = 0
      ._PREG = ""
      ._PRF = ""
      ._RAD1 = ConvertString("Rad1", RecArray(67), 35)
      ._RAD2 = ""
      ._RATE = 70
      ._RCODE = 0
      ._RCTY = ConvertString("Rcty", RecArray(68), 25)
      ._REGNO = RecArray(7)
      ._RST = ConvertString("Rst", RecArray(69), 2)
      ._RZ4 = 0 'CnvSng(RecArray(69)) full zip
      ._RZ5 = 0 'CnvSng(RecArray(69))
      ._SCAP = 0
      ._SCLR = ""
      ._SEAT = 0
      ._SS2 = CnvSng(RecArray(72))
      ._SSNO = CnvSng(RecArray(73))
      ._STATE = WrkState
      ._TDATE = 0
      ._TIN = ""
      ._TRVAL = CnvSng(RecArray(56))
      ._TYPE = "M"
      ._VALUE = CnvSng(RecArray(16))
      ._VINNO = ConvertString("VIN", RecArray(6), 17)
      ._XDATE = 0
      ._YEAR = CnvSng(RecArray(4))
      ._ZIP4 = CnvSng(RecArray(35))
      ._ZIP5 = CnvSng(RecArray(34))
      .AddOneRecordP()
    End With

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
      If WrkMonth < 10 Then
        ReturnDate = Mid(DateIn, 8, 4) & "0" & WrkMonth & Mid(DateIn, 1, 2)
      Else
        ReturnDate = Mid(DateIn, 8, 4) & WrkMonth & Mid(DateIn, 1, 2)
      End If
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

  Private Sub LnkFilePathPP_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePathPP.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePathPP.Text = .FileName
    End With
  End Sub

  Private Sub LnkFilePathMV_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePathMV.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePathMV.Text = .FileName
    End With
  End Sub
End Class