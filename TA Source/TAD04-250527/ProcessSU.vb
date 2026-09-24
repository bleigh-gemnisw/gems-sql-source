Module ProcessSU
Dim myTXSUPPQ As TXSUPPQ.myData
Dim myTXBAA As TXBAA.myData
Dim myTXSUPA As TXSUPA.myData

Dim WrkYear As Integer
Dim WrkTotBTR As Integer
Const WrkType As String = "S"

Public Sub ProcSU()
Dim WrkCount As Integer
Dim Counter As Integer
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkQry As String
Dim WrkSort As String

Counter = 0
WrkQry = ""
WrkSort = "List#"
myTXSUPPQ = New TXSUPPQ.mydata(MyDBConnect)
myTXBAA = New TXBAA.mydata(MyDBConnect)
myTXSUPA = New TXSUPA.mydata(MyDBConnect)

With MyFrmTAD04B
  WrkYear = MyUtils.CnvSng(.TxtYear.Text)
End With

WrkCount = myTXSUPA.GetIsPosted(WrkYear)
If WrkCount > 0 Then 'if already archived then abort
  MyArchived = True
  Exit Sub
End If

MyFrmProgress = New FrmProgress
MyFrmProgress.LblMsg.Text = "Supplemental MV"
MyFrmProgress.Show()
MyFrmProgress.Refresh()
Application.DoEvents()

myTXSUPPQ.OpenQry(WrkSort, WrkQry)
ReadNext:
  myTXSUPPQ.ReadQry()
  If Not myTXSUPPQ.IsEOF Then
    With myTXSUPPQ
      Counter = Counter + 1
      myTXSUPA.GetOneRecordP(._LISTNo, WrkYear)
      If myTXSUPA.RecordNotFound Then
        myTXSUPA._CAT = ._CAT
        myTXSUPA._LISTNo = ._LISTNo
        myTXSUPA._TXYEAR = WrkYear
        myTXSUPA._NAME = ._NAME
        myTXSUPA._SNAME = ._SNAME
        myTXSUPA._ADD1 = ._ADD1
        myTXSUPA._ADD2 = ._ADD2
        myTXSUPA._CITY = ._CITY
        myTXSUPA._STATE = ._STATE
        myTXSUPA._ZIP5 = ._ZIP5
        myTXSUPA._ZIP4 = ._ZIP4
        myTXSUPA._DIST = ._DIST
        myTXSUPA._PDST = ._PDST
        If ._BTR <> 0 Then
          myTXBAA.GetOneRecordP(._LISTNo, WrkType, WrkYear)
          WrkTotBTR = myTXBAA._BASS1
          myTXSUPA._VALUE = myTXBAA._ASS1
          myTXSUPA._BTR = WrkTotBTR
          myTXSUPA._DNBTR = myTXBAA._DNBTR
          myTXSUPA._DTBTR = myTXBAA._DTBTR
        Else
          myTXSUPA._VALUE = ._VALUE
          myTXSUPA._BTR = ._BTR
          myTXSUPA._DNBTR = "" '._DNBTR
          myTXSUPA._DTBTR = 0 '._DTBTR
        End If
        myTXSUPA._XDATE = ._XDATE
        myTXSUPA._CLASS = ._CLASS
        myTXSUPA._REGNO = ._REGNO
        myTXSUPA._MAKE = ._MAKE
        myTXSUPA._YEAR = ._YEAR
        myTXSUPA._MODEL = ._MODEL
        myTXSUPA._BODY = ._BODY
        myTXSUPA._VINNO = ._VINNO
        myTXSUPA._CYLAX = ._CYLAX
        myTXSUPA._PCLR = ._PCLR
        myTXSUPA._SCLR = ._SCLR
        myTXSUPA._SEAT = ._SEAT
        myTXSUPA._LWT = ._LWT
        myTXSUPA._GWT = ._GWT
        myTXSUPA._VALUE = ._VALUE
        myTXSUPA._ASS = ._ASS
        myTXSUPA._CYCLE = ._CYCLE
        myTXSUPA._RCODE = ._RCODE
        myTXSUPA._OCODE = ._OCODE
        myTXSUPA._RATE = ._RATE
        myTXSUPA._PCCOD = ._PCCOD
        myTXSUPA._PREG = ._PREG
        myTXSUPA._SCAP = ._SCAP
        myTXSUPA._TDATE = ._TDATE
        myTXSUPA._EXCD1 = ._EXCD1
        myTXSUPA._EXCD2 = ._EXCD2
        myTXSUPA._EXCD3 = ._EXCD3
        myTXSUPA._EXCD4 = ._EXCD4
        myTXSUPA._EXCD5 = ._EXCD5
        myTXSUPA._EXAM1 = ._EXAM1
        myTXSUPA._EXAM2 = ._EXAM2
        myTXSUPA._EXAM3 = ._EXAM3
        myTXSUPA._EXAM4 = ._EXAM4
        myTXSUPA._EXAM5 = ._EXAM5
        myTXSUPA._CCNO = ._CCNO
        myTXSUPA._CCGRS = ._CCGRS
        myTXSUPA._CCEX = ._CCEX
        myTXSUPA._CCRS = ._CCRS
        myTXSUPA._CDATE = ._CDATE
        myTXSUPA._CCCD1 = ._CCCD1
        myTXSUPA._CCCD2 = ._CCCD2
        myTXSUPA._CCCD3 = ._CCCD3
        myTXSUPA._CCCD4 = ._CCCD4
        myTXSUPA._CCCD5 = ._CCCD5
        myTXSUPA._CEXA1 = ._CEXA1
        myTXSUPA._CEXA2 = ._CEXA2
        myTXSUPA._CEXA3 = ._CEXA3
        myTXSUPA._CEXA4 = ._CEXA4
        myTXSUPA._CEXA5 = ._CEXA5
        myTXSUPA._OCLS = ._OCLS
        myTXSUPA._OMAKE = ._OMAKE
        myTXSUPA._OYEAR = ._OYEAR
        myTXSUPA._OMOD = ._OMOD
        myTXSUPA._OBODY = "" '._OBODY
        myTXSUPA._OREGNo = ._OREGNo
        myTXSUPA._OVIN = ._OVIN
        myTXSUPA._OASS = ._OASS
        myTXSUPA._OVAL = ._OVAL
        myTXSUPA._OPVAL = ._OPVAL
        myTXSUPA._PVAL = ._PVAL
        myTXSUPA._PNET = ._PNET
        myTXSUPA._OLIST = ._OLIST
        myTXSUPA._DOB = ._DOB
        myTXSUPA._SSNo = ._SSNo
        myTXSUPA._SS2 = ._SS2
        myTXSUPA._OID = ._OID
        myTXSUPA._BTC = ._BTC
        myTXSUPA._LEASE = ._LEASE
        myTXSUPA._ORIG = ._ORIG
        myTXSUPA._TRVAL = ._TRVAL
        myTXSUPA._LNVAL = ._LNVAL
        myTXSUPA._MSRP = ._MSRP
        myTXSUPA._NADA = ._NADA
        myTXSUPA._LETT = ._LETT
        myTXSUPA._TYPE = ._TYPE
        myTXSUPA._TIN = ._TIN
        myTXSUPA._RAD1 = "" '._RAD1
        myTXSUPA._RAD2 = "" '._RAD2
        myTXSUPA._RCTY = "" '._RCTY
        myTXSUPA._RST = "" '._RST
        myTXSUPA._RZ5 = 0 '._RZ5
        myTXSUPA._RZ4 = 0 '._RZ4
        myTXSUPA._PRF = ._PRF
        myTXSUPA._CHDATE = ._CHDATE
        myTXSUPA._CHTIME = ._CHTIME
        myTXSUPA.AddOneRecordP()
          If myTXSUPA.ErrMsg <> "" Then
            WriteErrorLog(myTXSUPA.ErrMsg)
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
myTXSUPPQ.CloseFile()

End Sub
End Module





