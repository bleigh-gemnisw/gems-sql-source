Module ProcessPP
  Dim myTXPPRPCQ As TXPPRPCQ.MyData
  Dim myTXBAA As TXBAA.MyData
  Dim myTXPPRA As TXPPRA.MyData

  Dim WrkYear As Integer
  Dim WrkTotBTR As Integer
  Const WrkType As String = "P"

  Public Sub ProcPP()
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkCount As Integer

    Counter = 0
    WrkQry = ""
    WrkSort = "List#"
    myTXPPRPCQ = New TXPPRPCQ.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)
    myTXPPRA = New TXPPRA.MyData(myDBConnect)

    With MyFrmTAD04B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    WrkCount = myTXPPRA.GetIsPosted(WrkYear)
    If WrkCount > 0 Then 'if already archived then abort
      MyArchived = True
      Exit Sub
    End If

    MyFrmProgress = New FrmProgress
    MyFrmProgress.LblMsg.Text = "Personal Property"
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    MyFrmTAD04B.LblPP.Visible = True
    Application.DoEvents()

    myTXPPRPCQ.OpenQry(WrkSort, WrkQry)
ReadNext:
    myTXPPRPCQ.ReadQry()
    If Not myTXPPRPCQ.IsEOF Then
      With myTXPPRPCQ
        Counter = Counter + 1
        myTXPPRA.GetOneRecordP(._LISTNO, WrkYear)
        If myTXPPRA.RecordNotFound Then
          myTXPPRA._CAT = ._CAT
          myTXPPRA._LISTNo = ._LISTNO
          myTXPPRA._TXYEAR = WrkYear
          myTXPPRA._NAME = ._NAME
          myTXPPRA._SNAME = ._SNAME
          myTXPPRA._ADD1 = ._ADD1
          myTXPPRA._ADD2 = ._ADD2
          myTXPPRA._CITY = ._CITY
          myTXPPRA._STATE = ._STATE
          myTXPPRA._ZIP5 = ._ZIP5
          myTXPPRA._ZIP4 = ._ZIP4
          myTXPPRA._LOCNo = ._LOCNO
          myTXPPRA._LOC = ._LOC
          myTXPPRA._DIST = ._DIST
          myTXPPRA._PDST = ._PDST
          myTXPPRA._GROSS = ._GROSS
          myTXPPRA._NET = ._NET
          If ._BTR <> 0 Then
            myTXBAA.GetOneRecordP(._LISTNO, WrkType, WrkYear)
            myTXPPRA._ASS1 = myTXBAA._ASS1
            myTXPPRA._ASS2 = myTXBAA._ASS2
            myTXPPRA._ASS3 = myTXBAA._ASS3
            myTXPPRA._ASS4 = myTXBAA._ASS4
            myTXPPRA._ASS5 = myTXBAA._ASS5
            myTXPPRA._ASS6 = myTXBAA._ASS6
            myTXPPRA._ASS7 = myTXBAA._ASS7
            myTXPPRA._CODE1 = myTXBAA._CODE1
            myTXPPRA._CODE2 = myTXBAA._CODE2
            myTXPPRA._CODE3 = myTXBAA._CODE3
            myTXPPRA._CODE4 = myTXBAA._CODE4
            myTXPPRA._CODE5 = myTXBAA._CODE5
            myTXPPRA._CODE6 = myTXBAA._CODE6
            myTXPPRA._CODE7 = myTXBAA._CODE7
            WrkTotBTR = myTXBAA._BASS1 + myTXBAA._BASS2 + myTXBAA._BASS3 + myTXBAA._BASS4 + myTXBAA._BASS5
            WrkTotBTR = WrkTotBTR + myTXBAA._BASS6 + myTXBAA._BASS7 + myTXBAA._BASS8 + myTXBAA._BASS9 + myTXBAA._BASSA
            myTXPPRA._BTR = WrkTotBTR
            myTXPPRA._DNBTR = myTXBAA._DNBTR
            myTXPPRA._DTBTR = myTXBAA._DTBTR
          Else
            myTXPPRA._ASS1 = ._ASS1
            myTXPPRA._ASS2 = ._ASS2
            myTXPPRA._ASS3 = ._ASS3
            myTXPPRA._ASS4 = ._ASS4
            myTXPPRA._ASS5 = ._ASS5
            myTXPPRA._ASS6 = ._ASS6
            myTXPPRA._ASS7 = ._ASS7
            myTXPPRA._ASS8 = ._ASS8
            myTXPPRA._ASS9 = ._ASS9
            myTXPPRA._ASS10 = ._ASS10
            myTXPPRA._CODE1 = ._CODE1
            myTXPPRA._CODE2 = ._CODE2
            myTXPPRA._CODE3 = ._CODE3
            myTXPPRA._CODE4 = ._CODE4
            myTXPPRA._CODE5 = ._CODE5
            myTXPPRA._CODE6 = ._CODE6
            myTXPPRA._CODE7 = ._CODE7
            myTXPPRA._CODE8 = ._CODE8
            myTXPPRA._CODE9 = ._CODE9
            myTXPPRA._CODEA = ._CODEA
            myTXPPRA._BTR = ._BTR
            myTXPPRA._DNBTR = ._DNBTR
            myTXPPRA._DTBTR = ._DTBTR
          End If
          myTXPPRA._UNIT1 = ._UNIT1
          myTXPPRA._UNIT2 = ._UNIT2
          myTXPPRA._UNIT3 = ._UNIT3
          myTXPPRA._UNIT4 = ._UNIT4
          myTXPPRA._UNIT5 = ._UNIT5
          myTXPPRA._UNIT6 = ._UNIT6
          myTXPPRA._UNIT7 = ._UNIT7
          myTXPPRA._EXCD1 = ._EXCD1
          myTXPPRA._EXCD2 = ._EXCD2
          myTXPPRA._EXCD3 = ._EXCD3
          myTXPPRA._EXCD4 = ._EXCD4
          myTXPPRA._EXCD5 = ._EXCD5
          myTXPPRA._EXCD6 = "" '._EXCD6
          myTXPPRA._EXCD7 = "" '._EXCD7
          myTXPPRA._EXAM1 = ._EXAM1
          myTXPPRA._EXAM2 = ._EXAM2
          myTXPPRA._EXAM3 = ._EXAM3
          myTXPPRA._EXAM4 = ._EXAM4
          myTXPPRA._EXAM5 = ._EXAM5
          myTXPPRA._EXAM6 = 0 '._EXAM6
          myTXPPRA._EXAM7 = 0 '._EXAM7
          myTXPPRA._CCNO = ._CCNO
          myTXPPRA._CCGRS = ._CCGRS
          myTXPPRA._CCEX = ._CCEX
          myTXPPRA._CCRS = ._CCRS
          myTXPPRA._CDATE = ._CDATE
          myTXPPRA._CASS1 = ._CASS1
          myTXPPRA._CASS2 = ._CASS2
          myTXPPRA._CASS3 = ._CASS3
          myTXPPRA._CASS4 = ._CASS4
          myTXPPRA._CASS5 = ._CASS5
          myTXPPRA._CASS6 = ._CASS6
          myTXPPRA._CASS7 = ._CASS7
          myTXPPRA._CCCD1 = ._CCCD1
          myTXPPRA._CCCD2 = ._CCCD2
          myTXPPRA._CCCD3 = ._CCCD3
          myTXPPRA._CCCD4 = ._CCCD4
          myTXPPRA._CCCD5 = ._CCCD5
          myTXPPRA._CCCD6 = "" '._CCCD6
          myTXPPRA._CCCD7 = "" '._CCCD7
          myTXPPRA._CEXA1 = ._CEXA1
          myTXPPRA._CEXA2 = ._CEXA2
          myTXPPRA._CEXA3 = ._CEXA3
          myTXPPRA._CEXA4 = ._CEXA4
          myTXPPRA._CEXA5 = ._CEXA5
          myTXPPRA._CEXA6 = 0 '._CEXA6
          myTXPPRA._CEXA7 = 0 '._CEXA7
          myTXPPRA._BTC = ._BTC
          myTXPPRA._SSNo = ._SSNO
          myTXPPRA._SS2 = ._SS2
          myTXPPRA._OID = ._OID
          myTXPPRA._LETT = ._LETT
          myTXPPRA._TYPE = ._TYPE
          myTXPPRA._TIN = ._TIN
          myTXPPRA._BUSTY = ._BUSTY
          myTXPPRA._SQFT = ._SQFT
          myTXPPRA._BUS = ._BUS
          myTXPPRA._RDATE = ._RDATE
          myTXPPRA._ADYR = ._ADYR
          myTXPPRA._PHONE = "" '._PHONE
          myTXPPRA._EMAIL = "" '._EMAIL
          myTXPPRA._PRF = ._PRF
          myTXPPRA._CHDATE = ._CHDATE
          myTXPPRA._CHTIME = ._CHTIME
          myTXPPRA.AddOneRecordP()
          If myTXPPRA.ErrMsg <> "" Then
            WriteErrorLog(myTXPPRA.ErrMsg)
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
    myTXPPRPCQ.CloseFile()

  End Sub
End Module






