Imports System.Text
Imports System.IO
Public Class FrmAvon
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim MyUTCUST As UTCUST
  Dim WrkFile As String
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    LblMsg.Text = ""
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
  End Sub
  Private Sub InitFiles()
    MyTXINV = New TXINV(myDBConnect2.MyConn2)
    MyTXHST = New TXHST(myDBConnect2.MyConn2)
    MyUTCUST = New UTCUST(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvAvonsa.csv")
    ProgBar1.Visible = True
    WriteHST()
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
  End Sub

  Private Sub WriteINV(ByVal WrkListNo As Integer, ByVal WrkType As String, ByVal WrkYear As Integer,
   ByVal WrkPamt As Decimal, ByVal WrkPcamt As Decimal, ByVal WrkPdate As Integer)

    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    MyUTCUST.GetOneRecordP(WrkListNo)
    With MyUTCUST
      If MyTXINV.RecordNotFound Then
        MyTXINV._LISTNo = WrkListNo
        MyTXINV._YEAR = WrkYear
        MyTXINV._TYPE = WrkType
      End If
      MyTXINV._NAME = ._CUNAM1
      MyTXINV._SNAME = ._CUNAM2
      If Trim(._CUMAD1) <> "" Then
        MyTXINV._ADD1 = ._CUMAD1
        MyTXINV._ADD2 = ._CUMAD2
        MyTXINV._CITY = ._CUMCTY
        MyTXINV._STATE = ._CUMST
        MyTXINV._ZIP5 = CnvSng(Mid(._CUMZIP, 1, 5))
        If Len(._CUMZIP) > 5 Then
          MyTXINV._ZIP4 = CnvSng(Mid(._CUMZIP, 7, 4))
        End If
      Else
        MyTXINV._ADD1 = ._CUADD1
        MyTXINV._ADD2 = ._CUADD2
        MyTXINV._CITY = ._CUCITY
        MyTXINV._STATE = ._CUST
        MyTXINV._ZIP5 = CnvSng(Mid(._CUZIP, 1, 5))
        If Len(._CUZIP) > 5 Then
          MyTXINV._ZIP4 = CnvSng(Mid(._CUZIP, 7, 4))
        End If
      End If
      MyTXINV._PDST = ._CUDST
      MyTXINV._TAXT = WrkPamt
      MyTXINV._TAX1 = WrkPamt
      MyTXINV._PHASE = ._CUPHAS
      MyTXINV._TAX2 = 0
      MyTXINV._TX3RD = 0
      MyTXINV._TX4TH = 0
      MyTXINV._PAYREC = WrkPamt
      MyTXINV._BALD = 0
      MyTXINV._TXIDT = WrkPdate
      MyTXINV._BOND = WrkPcamt
      MyTXINV._BONDP = WrkPcamt
      MyTXINV._LOCNo = ._CULOCNO
      MyTXINV._LOC = ._CULOC
      MyTXINV._MAP = ._CUMAP
      MyTXINV._VOL = ._CUVOLM
      MyTXINV._IPAGE = ._CUPAGE
      MyTXINV._LETT = Mid(._CUNAM1, 1, 1)
      MyTXINV._PRF = "CNV-SA"
      If MyTXINV.RecordNotFound Then
        MyTXINV.AddOneRecordP()
      End If
    End With
  End Sub
  Private Sub WriteHST()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Const cMaxInt As Decimal = 99999.99
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkType As String
    Dim WrkSelList As Integer
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkRecID As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkStream = New FileStream("C:\temp\sewact.csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
    sr = New StreamReader(WrkStream)
    WrkFileSize = WrkStream.Length
    strBuffer = sr.ReadLine 'Skip Header
    WrkSelList = CnvSng(TxtSelList.Text)

NextLine:
    strBuffer = sr.ReadLine
    If Trim(strBuffer) = String.Empty Then
      Exit Sub
    End If

    I = I + strBuffer.Length
    RecArray = Parse(strBuffer, ",")
    WrkListNo = CnvSng(RecArray(0))
    If WrkSelList <> WrkListNo Then
      GoTo ShowPct
    End If
    If Trim(RecArray(3)) = "" Then
      GoTo ShowPct
    End If
    WrkYear = Mid(RecArray(3), 7, 4)
    If ConvertDate(RecArray(3)) >= 20230101 Then
      GoTo ShowPct
    End If
    WrkType = "A"

    With MyTXHST
      Counter = Counter + 1
      WrkRecID = .AutoGenKey
      ._RCODE = ""
      ._ADJCD = ""
      ._BATCHA = ""
      ._BATCHN = CnvSng(RecArray(19))
      ._BATCHS = CnvSng(RecArray(20))
      ._CASH = 0
      If Trim(RecArray(2)) <> "" Then
        ._CDATE = ConvertDate(RecArray(3))
        ._CHDATE = ConvertDate(RecArray(3))
        ._PDATE = ConvertDate(RecArray(3))
      Else
        ._CDATE = 0
        ._CHDATE = 0
        ._PDATE = 0
      End If
      ._CHECK = 0
      ._CHTIME = 0
      ._COMM = Mid(RecArray(14), 1, 20)
      ._CORC = ""
      ._CREDIT = 0
      ._DIST = 0
      If CnvSng(RecArray(13)) <= cMaxInt Then
        ._IAMT = CnvSng(RecArray(13))
      Else
        ._IAMT = cMaxInt
        sw.WriteLine(WrkFile & ",HST Iamt:," & CnvSng(RecArray(13)))
      End If
      ._INTOR = 0
      ._LAMT = CnvSng(RecArray(9))
      ._LISTNO = WrkListNo
      ._PAMT = CnvSng(RecArray(5)) + CnvSng(RecArray(7))
      ._PCAMT = CnvSng(RecArray(6)) + CnvSng(RecArray(8))
      If ._ADJCD = "" Then
        If ._PAMT < 0 Or ._IAMT < 0 Or ._PCAMT < 0 Or ._IAMT < 0 Then
          ._ADJCD = "A"
        End If
      End If
      If ._PCAMT > 0 Then
        ._PENCD = "BI"
      Else
        ._PENCD = ""
      End If
      ._PRF = "CNV-SA"
      ._RECID = WrkRecID
      ._REF = ""
      ._SUSCD = ""
      ._THAJCD = ""
      ._THINPD = 0
      ._TYPE = WrkType
      ._YEAR = WrkYear
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine(WrkFile & ",error:," & WrkListNo & " " & WrkYear & " " & .ErrMsg)
        GoTo ShowPct
      End If
      WriteINV(WrkListNo, WrkType, WrkYear, ._PAMT, ._PCAMT, ._PDATE)
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
End Class