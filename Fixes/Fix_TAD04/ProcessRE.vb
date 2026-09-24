Module ProcessRE
Dim myTXREALCQ As TXREALCQ.myData
Dim myTXBAA As TXBAA.myData
Dim myTXREAA As TXREAA.myData

Dim WrkYear As Integer
Dim WrkTotBTR As Integer
Const WrkType As String = "R"

Public Sub ProcRE()
Dim ds As DataSet = New DataSet
Dim WrkCount As Integer
Dim Counter As Integer
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkQry As String
Dim WrkSort As String

Counter = 0
WrkQry = ""
WrkSort = "List#"
myTXREALCQ = New TXREALCQ.mydata(MyDBConnect)
myTXBAA = New TXBAA.mydata(MyDBConnect)
myTXREAA = New TXREAA.mydata(MyDBConnect)

With MyFrmFix_TAD04B
  WrkYear = MyUtils.CnvSng(.TxtYear.Text)
End With

WrkCount = myTXREAA.GetIsPosted(WrkYear)
If WrkCount > 0 Then 'if already archived then abort
  MyArchived = True
  Exit Sub
End If

MyFrmProgress = New FrmProgress
MyFrmProgress.LblMsg.Text = "Real Estate"
MyFrmProgress.Show()
MyFrmProgress.Refresh()
Application.DoEvents()

myTXREALCQ.OpenQry(WrkSort, WrkQry)
ReadNext:
  myTXREALCQ.ReadQry()
  If Not myTXREALCQ.IsEOF Then
    With myTXREALCQ
      Counter = Counter + 1
      myTXREAA.GetOneRecordP(._LISTNO, WrkYear)
      If myTXREAA.RecordNotFound Then
        myTXREAA._CAT = ._CAT
        myTXREAA._LISTNo = ._LISTNO
        myTXREAA._TXYEAR = WrkYear
        myTXREAA._NAME = ._NAME
        myTXREAA._SNAME = ._SNAME
        myTXREAA._ADD1 = ._ADD1
        myTXREAA._ADD2 = ._ADD2
        myTXREAA._CITY = ._CITY
        myTXREAA._STATE = ._STATE
        myTXREAA._ZIP5 = ._ZIP5
        myTXREAA._ZIP4 = ._ZIP4
        myTXREAA._UNITNo = ._UNITNO
        myTXREAA._LOCNo = ._LOCNO
        myTXREAA._LOC = ._LOC
        myTXREAA._DIST = ._DIST
        myTXREAA._PDST = ._PDST
        myTXREAA._GROSS = ._GROSS
        myTXREAA._NET = ._NET
        If ._BTR <> 0 Then
          myTXBAA.GetOneRecordP(._LISTNO, WrkType, WrkYear)
          myTXREAA._ASS1 = myTXBAA._ASS1
          myTXREAA._ASS2 = myTXBAA._ASS2
          myTXREAA._ASS3 = myTXBAA._ASS3
          myTXREAA._ASS4 = myTXBAA._ASS4
          myTXREAA._ASS5 = myTXBAA._ASS5
          myTXREAA._ASS6 = myTXBAA._ASS6
          myTXREAA._ASS7 = myTXBAA._ASS7
          myTXREAA._CODE1 = myTXBAA._CODE1
          myTXREAA._CODE2 = myTXBAA._CODE2
          myTXREAA._CODE3 = myTXBAA._CODE3
          myTXREAA._CODE4 = myTXBAA._CODE4
          myTXREAA._CODE5 = myTXBAA._CODE5
          myTXREAA._CODE6 = myTXBAA._CODE6
          myTXREAA._CODE7 = myTXBAA._CODE7
          WrkTotBTR = myTXBAA._BASS1 + myTXBAA._BASS2 + myTXBAA._BASS3 + myTXBAA._BASS4 + myTXBAA._BASS5
          WrkTotBTR = WrkTotBTR + myTXBAA._BASS6 + myTXBAA._BASS7 + myTXBAA._BASS8 + myTXBAA._BASS9 + myTXBAA._BASSA
          myTXREAA._BTR = WrkTotBTR
          myTXREAA._DNBTR = myTXBAA._DNBTR
          myTXREAA._DTBTR = myTXBAA._DTBTR
        Else
          myTXREAA._ASS1 = ._ASS1
          myTXREAA._ASS2 = ._ASS2
          myTXREAA._ASS3 = ._ASS3
          myTXREAA._ASS4 = ._ASS4
          myTXREAA._ASS5 = ._ASS5
          myTXREAA._ASS6 = ._ASS6
          myTXREAA._ASS7 = ._ASS7
          myTXREAA._CODE1 = ._CODE1
          myTXREAA._CODE2 = ._CODE2
          myTXREAA._CODE3 = ._CODE3
          myTXREAA._CODE4 = ._CODE4
          myTXREAA._CODE5 = ._CODE5
          myTXREAA._CODE6 = ._CODE6
          myTXREAA._CODE7 = ._CODE7
          myTXREAA._BTR = ._BTR
          myTXREAA._DNBTR = ._DNBTR
          myTXREAA._DTBTR = ._DTBTR
        End If
        myTXREAA._UNIT1 = ._UNIT1
        myTXREAA._UNIT2 = ._UNIT2
        myTXREAA._UNIT3 = ._UNIT3
        myTXREAA._UNIT4 = ._UNIT4
        myTXREAA._UNIT5 = ._UNIT5
        myTXREAA._UNIT6 = ._UNIT6
        myTXREAA._UNIT7 = ._UNIT7
        myTXREAA._ACRE1 = ._ACRE1
        myTXREAA._ACRE2 = ._ACRE2
        myTXREAA._ACRE3 = ._ACRE3
        myTXREAA._ACRE4 = ._ACRE4
        myTXREAA._ACRE5 = ._ACRE5
        myTXREAA._ACRE6 = ._ACRE6
        myTXREAA._ACRE7 = ._ACRE7
        myTXREAA._VOL = ._VOL
        myTXREAA._PGE = ._PGE
        myTXREAA._MAP = ._MAP
        myTXREAA._SMAP = ._SMAP
        myTXREAA._EXMPT = ._EXMPT
        myTXREAA._SEWER = ._SEWER
        myTXREAA._PERC = ._PERC
        myTXREAA._FCCOD = ._FCCOD
        myTXREAA._FCYR = ._FCYR
        myTXREAA._CPERC = ._CPERC
        myTXREAA._CMAX = ._CMAX
        myTXREAA._CMIN = ._CMIN
        myTXREAA._CIRAD = ._CIRAD
        myTXREAA._FTAX = ._FTAX
        myTXREAA._FASS = ._FASS
        myTXREAA._TWNBN = ._TWNBN
        myTXREAA._VTYR = ._VTYR
        myTXREAA._EXCD1 = ._EXCD1
        myTXREAA._EXCD2 = ._EXCD2
        myTXREAA._EXCD3 = ._EXCD3
        myTXREAA._EXCD4 = ._EXCD4
        myTXREAA._EXCD5 = ._EXCD5
        myTXREAA._EXCD6 = ._EXCD6
        myTXREAA._EXCD7 = ._EXCD7
        myTXREAA._EXAM1 = ._EXAM1
        myTXREAA._EXAM2 = ._EXAM2
        myTXREAA._EXAM3 = ._EXAM3
        myTXREAA._EXAM4 = ._EXAM4
        myTXREAA._EXAM5 = ._EXAM5
        myTXREAA._EXAM6 = ._EXAM6
        myTXREAA._EXAM7 = ._EXAM7
        myTXREAA._CCNO = ._CCNO
        myTXREAA._CCGRS = ._CCGRS
        myTXREAA._CCEX = ._CCEX
        myTXREAA._CCRS = ._CCRS
        myTXREAA._CDATE = ._CDATE
        myTXREAA._CASS1 = ._CASS1
        myTXREAA._CASS2 = ._CASS2
        myTXREAA._CASS3 = ._CASS3
        myTXREAA._CASS4 = ._CASS4
        myTXREAA._CASS5 = ._CASS5
        myTXREAA._CASS6 = ._CASS6
        myTXREAA._CASS7 = ._CASS7
        myTXREAA._CCCD1 = ._CCCD1
        myTXREAA._CCCD2 = ._CCCD2
        myTXREAA._CCCD3 = ._CCCD3
        myTXREAA._CCCD4 = ._CCCD4
        myTXREAA._CCCD5 = ._CCCD5
        myTXREAA._CCCD6 = ._CCCD6
        myTXREAA._CCCD7 = ._CCCD7
        myTXREAA._CEXA1 = ._CEXA1
        myTXREAA._CEXA2 = ._CEXA2
        myTXREAA._CEXA3 = ._CEXA3
        myTXREAA._CEXA4 = ._CEXA4
        myTXREAA._CEXA5 = ._CEXA5
        myTXREAA._CEXA6 = ._CEXA6
        myTXREAA._CEXA7 = ._CEXA7
        myTXREAA._BTC = ._BTC
        myTXREAA._BKSV = ._BKSV
        myTXREAA._BKCD = ._BKCD
        myTXREAA._PURDT = ._PURDT
        myTXREAA._PURPR = ._PURPR
        myTXREAA._CENBK = ._CENBK
        myTXREAA._CENTR = ._CENTR
        myTXREAA._CARD = ._CARD
        myTXREAA._SSNo = ._SSNO
        myTXREAA._SS2 = ._SS2
        myTXREAA._OID = ._OID
        myTXREAA._LETT = ._LETT
        myTXREAA._TYPE = ._TYPE
        myTXREAA._AIDTE = ._AIDTE
        myTXREAA._AEDATE = ._AEDATE
        myTXREAA._AACRE = ._AACRE
        myTXREAA._ACCTN = ._ACCTN
        myTXREAA._WMAIL = ._WMAIL
        myTXREAA._RLST = ._RLST
        myTXREAA._TIN = ._TIN
        myTXREAA._PRF = ._PRF
        myTXREAA._CHDATE = ._CHDATE
        myTXREAA._CHTIME = ._CHTIME
        myTXREAA.AddOneRecordP()
          If myTXREAA.ErrMsg <> "" Then
            WriteErrorLog(myTXREAA.ErrMsg)
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
myTXREALCQ.CloseFile()

End Sub
End Module







