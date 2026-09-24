Imports System.Text
Imports System.IO
Public Class FrmAvon
  Dim sw As StreamWriter
  Dim strBuffer As String
  Public myDBConnect2 As DBConnection
  Dim MyTXINV As TXINV
  Dim MyTXHST As TXHST
  Dim WrkFile As String
  Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    GetAppSettings()
    myDBConnect2 = New DBConnection()
    myDBConnect2.Open2()
  End Sub
  Private Sub InitFiles()
    MyTXINV = New TXINV(myDBConnect2.MyConn2)
    MyTXHST = New TXHST(myDBConnect2.MyConn2)
  End Sub
  Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles BtnConvert.Click
    InitFiles()
    sw = New StreamWriter(GetDataPath() & "CnvAvonu21.csv")
    ProgBar1.Visible = True
    WriteDlqHST()
    sw.Flush()
    sw.Close()
    ProgBar1.Visible = False
    LblMsg.Text = ""
    TxtErrorMsg.Text = TxtErrorMsg.Text & " DONE"
  End Sub

  Private Sub UpdateINV(ByVal WrkListno As Integer, ByVal WrkYear As Integer, ByVal WrkType As String,
   ByVal WrkPamt As Decimal, ByVal WrkPdate As Integer)
    WrkFile = "INV"
    With MyTXINV
      .GetOneRecordP(WrkListno, WrkYear, WrkType)
      ._BALD = ._BALD - WrkPamt
      ._PAYREC = ._PAYREC + WrkPamt
      ._TXIDT = WrkPdate
      .UpdateOneRecordP()
      If .ErrMsg <> "" Then
        sw.WriteLine(WrkFile & " error:," & WrkListno & "," & WrkYear & "," & .ErrMsg)
      Else
        sw.WriteLine(WrkFile & " paid:," & WrkListno & "," & WrkYear & "," & WrkPamt & "," & WrkPdate)
      End If
    End With
  End Sub
  Private Sub WriteDlqHST()
    Dim WrkStream As FileStream
    Dim sr As StreamReader
    Const cMaxInt As Decimal = 99999.99
    Dim WrkFileSize As Integer
    Dim RecArray As String()
    Dim WrkType As String
    Dim WrkAssrList As Integer
    Dim WrkListNo As Integer
    Dim WrkYear As Integer
    Dim WrkRecID As Integer
    Dim WrkDate As Integer
    Dim WrkPct As Decimal
    Dim SavePct As Decimal
    Dim Counter As Decimal
    Dim I As Integer

    WrkFile = "HST"
    WrkStream = New FileStream(MyAppSettings.FileDlqHST, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
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
    WrkAssrList = CnvSng(RecArray(1))
    WrkYear = CnvSng(RecArray(0))
    If WrkYear <> 2021 Then
      GoTo ShowPct
    End If
    MyTXINV.GetAssrListNo(WrkAssrList, WrkYear)
    If MyTXINV.RecordNotFound Then
      sw.WriteLine(WrkFile & ",missing:," & WrkAssrList & " " & WrkYear)
      GoTo NextLine
    End If
    WrkListNo = MyTXINV._LISTNo
    WrkType = MyTXINV._TYPE
    If WrkType <> "U" Then
      GoTo ShowPct
    End If
    WrkDate = 20220701
    If ConvertDate(RecArray(2)) < WrkDate Then
      GoTo ShowPct
    End If

    With MyTXHST
      Counter = Counter + 1
      WrkRecID = Counter
      ._RCODE = ""
      ._ADJCD = ""
      If RecArray(4) = "A" Then
        ._ADJCD = "A"
        ._RCODE = "V"
      End If
      ._BATCHA = ""
      ._BATCHN = CnvSng(RecArray(14))
      ._BATCHS = CnvSng(RecArray(12))
      ._CASH = 0
      If Trim(RecArray(2)) <> "" Then
        ._CDATE = ConvertDate(RecArray(2))
      Else
        ._CDATE = 0
      End If
      If Trim(RecArray(2)) <> "" Then
        ._CHDATE = ConvertDate(RecArray(2))
      Else
        ._CHDATE = 0
      End If
      ._CHECK = 0
      ._CHTIME = 0
      ._COMM = Mid(RecArray(11), 1, 20)
      ._CORC = ""
      ._CREDIT = 0
      ._DIST = 0
      If CnvSng(RecArray(6)) + CnvSng(RecArray(8)) <= cMaxInt Then
        ._IAMT = CnvSng(RecArray(6)) + CnvSng(RecArray(8))
      Else
        ._IAMT = cMaxInt
        sw.WriteLine(WrkFile & ",HST Iamt:," & CnvSng(RecArray(6)) + CnvSng(RecArray(8)))
      End If
      ._INTOR = 0
      ._LAMT = CnvSng(RecArray(9))
      ._LISTNO = WrkListNo
      ._PAMT = CnvSng(RecArray(5)) + CnvSng(RecArray(7))
      If ._RCODE = "S" Then
        ._PCAMT = MyTXINV._BALD
      Else
        ._PCAMT = 0
      End If
      If ._ADJCD = "" Then
        If ._PAMT < 0 Or ._IAMT < 0 Or ._PCAMT < 0 Or ._IAMT < 0 Then
          ._ADJCD = "A"
        End If
      End If
      If Trim(RecArray(2)) <> "" Then
        ._PDATE = ConvertDate(RecArray(2))
      Else
        ._PDATE = 0
      End If
      ._PENCD = ""
      ._PRF = "DLQ-U21"
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
      UpdateINV(WrkListNo, WrkYear, WrkType, ._PAMT, ._PDATE)
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