Module ProcessProrate
  Dim myTXCOOQ As TXCOOQ.MyData
  Dim myTXCOOA As TXCOOA.MyData

  Dim WrkYear As Integer
  Const WrkType As String = "X"

  Public Sub ProcProrate()
    Dim WrkCount As Integer
    Dim Counter As Integer
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim WrkQry As String
    Dim WrkSort As String

    Counter = 0
    WrkQry = ""
    WrkSort = "List#"
    myTXCOOQ = New TXCOOQ.MyData(myDBConnect)
    myTXCOOA = New TXCOOA.MyData(myDBConnect)

    With MyFrmTAD04B
      WrkYear = MyUtils.CnvSng(.TxtYear.Text)
    End With

    WrkCount = myTXCOOA.GetIsPosted(WrkYear)
    If WrkCount > 0 Then 'if already archived then abort
      MyArchived = True
      Exit Sub
    End If

    MyFrmProgress = New FrmProgress
    MyFrmProgress.LblMsg.Text = "Prorations"
    MyFrmProgress.Show()
    MyFrmProgress.Refresh()
    Application.DoEvents()

    myTXCOOQ.OpenQry(WrkSort, WrkQry)
ReadNext:
    myTXCOOQ.ReadQry()
    If Not myTXCOOQ.IsEOF Then
      With myTXCOOQ
        Counter = Counter + 1
        myTXCOOA.GetOneRecordP(._LISTNo, ._DEVLT, WrkYear)
        If myTXCOOA.RecordNotFound Then
          myTXCOOA._AMT = ._AMT
          myTXCOOA._BENAMT = ._BENAMT
          myTXCOOA._CHDATE = ._CHDATE
          myTXCOOA._CHTIME = ._CHTIME
          myTXCOOA._COADD1 = ._COADD1
          myTXCOOA._COADD2 = ._COADD2
          myTXCOOA._COCITY = ._COCITY
          myTXCOOA._CONAM = ._CONAM
          myTXCOOA._CONAM2 = ._CONAM2
          myTXCOOA._COSTE = ._COSTE
          myTXCOOA._COZIP4 = ._COZIP4
          myTXCOOA._COZIP5 = ._COZIP5
          myTXCOOA._DATE = ._DATE
          myTXCOOA._DAYS = ._DAYS
          myTXCOOA._DEVLT = ._DEVLT
          myTXCOOA._LETT = ._LETT
          myTXCOOA._LISTNo = ._LISTNo
          myTXCOOA._PCD = ._PCD
          myTXCOOA._PCOAFT = ._PCOAFT
          myTXCOOA._PCOBEF = ._PCOBEF
          myTXCOOA._PCT = ._PCT
          myTXCOOA._PFLAG = ._PFLAG
          myTXCOOA._PINC = ._PINC
          myTXCOOA._PRF = ._PRF
          myTXCOOA._RLIST = ._RLIST
          myTXCOOA._TXYEAR = WrkYear
          myTXCOOA.AddOneRecordP()
          If myTXCOOA.ErrMsg <> "" Then
            WriteErrorLog(myTXCOOA.ErrMsg)
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
    myTXCOOQ.CloseFile()
  End Sub
End Module
