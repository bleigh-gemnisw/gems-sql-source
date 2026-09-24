Module PostBCHHDR

	Dim myBCHHDR As BCHHDR.myData
  Dim myPOMBCHQ As POMBCHQ.MyData
  Dim myPOMBCH As POMBCH.MyData
  Dim myPOMBCD As POMBCD.MyData
  Dim myPOMBCDL1 As POMBCDL1.MyData
  Dim myPOMAST As POMAST.MyData
  Dim myPOSUMF As POSUMF.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.myData
  Dim myGNET As GNET.MyData
  Dim myFNDSEC As FNDSEC.myData
  Dim myLEDGER As LEDGER.myData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myFrmProgress As FrmProgress
  Dim FundCtl(25) As Integer
  Dim FundCtlAmt(25) As Decimal
  Dim WrkSrcde As String
  Dim WrkRefNo As Integer
  Dim WrkPostDate As Integer
  Dim ds As DataSet = New DataSet
Public Sub PstBCHHDR(ByVal BatchNo As Integer)

  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkQry As String
  Dim WrkSort As String
  Dim Counter As Integer
  Dim WrkRecovery As Boolean
  Dim WrkRecoveryNormal As Boolean
  Dim WrkRecoverySeq As Integer
  Dim WrkPosted As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim Answer As Integer

  myPOMBCHQ = New POMBCHQ.MyData()
  myPOMBCHQ.MyDBConn = myDBConnect
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myPOMBCH = New POMBCH.MyData()
  myPOMBCH.MyDBConn = myDBConnect
  myPOMBCD = New POMBCD.MyData()
  myPOMBCD.MyDBConn = myDBConnect
  myPOMBCDL1 = New POMBCDL1.MyData()
  myPOMBCDL1.MyDBConn = myDBConnect
  myPOMAST = New POMAST.MyData()
  myPOMAST.MyDBConn = myDBConnect
  myPOSUMF = New POSUMF.MyData()
  myPOSUMF.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect
  myGLFUND = New GLFUND.MyData()
  myGLFUND.MyDBConn = myDBConnect
  myGNET = New GNET.MyData()
  myGNET.MyDBConn = myDBConnect
  myFNDSEC = New FNDSEC.myData()
  myFNDSEC.MyDBConn = myDBConnect
  myLEDGER = New LEDGER.MyData()
  myLEDGER.MyDBConn = myDBConnect
  myLEDGERL1 = New LEDGERL1.MyData()
  myLEDGERL1.MyDBConn = myDBConnect

  myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
  WrkSrcde = 4
  Counter = 0
  Array.Clear(FundCtl, 0, 25)
  Array.Clear(FundCtlAmt, 0, 25)
  WrkRecovery = False
  WrkRecoveryNormal = False
  If myBCHHDR.RecordNotFound Then Exit Sub

  With myBCHHDR
    If Trim(._STATS) = "P" Then
      MsgBox("This process will automatically determine what needs to be done to finish the batch posting", MsgBoxStyle.Exclamation, "Batch has partially posted. Batch recovery will start.")
      WrkRecovery = True
    Else
      ._STATS = "P"
      .UpdateOneRecordP()
    End If
  End With

  WrkAnd = " and "
  WrkOr = " or "
  WrkQry = "BCHNO = " & BatchNo
  WrkSort = ""
  myPOMBCHQ.OpenQry(WrkSort, WrkQry)

  myFrmProgress = New FrmProgress
  myFrmProgress.Text = "Posting Batch"
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

  Counter = 0

ReadNext:
 myPOMBCHQ.ReadQry()
 If Not myPOMBCHQ.IsEOF Then
  With myPOMBCHQ
   Counter = Counter + 1
    WrkPosted = False
    If WrkRecovery And Not WrkRecoveryNormal Then
      If Not WrkPosted Then
        WrkRecoveryNormal = True
        myFrmProgress.Text = "Creating Report...(Recovery Seq = " & WrkRecoverySeq & ")"
        myFrmProgress.Refresh()
        Answer = MsgBox("Posting will continue with sequence " & WrkRecoverySeq & ". If this is not correct click CANCEL", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Batch posting recovery mode")
        If Answer = MsgBoxResult.Cancel Then
          myFrmProgress.Close()
          Application.DoEvents()
          GoTo Cleanup
        End If
        Application.DoEvents()
      End If
    End If
    WritePOMAST()
    WriteLEDGER()
  End With

SkipHst:
    With myFrmProgress
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

  myFrmProgress.Close()
  Application.DoEvents()

  WriteControl(BatchNo)
  myPOMBCH.DeleteBatch(BatchNo)
  myPOMBCD.DeleteBatch(BatchNo)
  myBCHHDR.DeleteOneRecordP()

Cleanup:
  'Memory Cleanup
  myBCHHDR = Nothing
  myPOMBCH = Nothing
  If WrkRecovery Then
    MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
  End If

End Sub
  Private Sub WritePOMAST()
    Dim dsFile As DataSet = New DataSet
    Dim dsFile2 As DataSet = New DataSet
    Dim WrkSeq As Integer
    Dim WrkStr As String
    Dim WrkAcct As Decimal
    Dim WrkAmount As Decimal
    Dim I As Integer

    'Header (Seq 0)
    With myPOMAST
      .GetOneRecordP(myPOMBCHQ._FSCYR, myPOMBCHQ._PONBR, myPOMBCHQ._POSUFX, 0, 0)
      If Not .RecordNotFound Then Exit Sub
      ._AMTGR = myPOMBCHQ._AMTGR
      ._AMTNT = myPOMBCHQ._AMTNT
      ._BCHNO = myPOMBCHQ._BCHNO
      ._CMPCD = ""
      ._DPNBD = myPOMBCHQ._DPNBD
      ._DPNBR = 0
      ._DPNBS = myPOMBCHQ._DPNBS
      ._DSCDL = myPOMBCHQ._DSCDL
      ._EXVAL = 0
      ._FDNBD = myPOMBCHQ._FDNBD
      ._FDNBR = 0
      ._FDNBS = myPOMBCHQ._FDNBS
      ._FNPGD = myPOMBCHQ._FNPGD
      ._FNPGM = 0
      ._FNPGS = myPOMBCHQ._FNPGS
      ._FSCYR = myPOMBCHQ._FSCYR
      ._INUSE = ""
      ._ITDSC = ""
      ._ITNBR = ""
      ._LLOCN = myPOMBCHQ._LLOCN
      ._LNE = myPOMBCHQ._LNE
      ._MNAYN = ""
      ._OBNBD = myPOMBCHQ._OBNBD
      ._OBNBR = 0
      ._OBNBS = myPOMBCHQ._OBNBS
      ._ORDSP = myPOMBCHQ._ORDSP
      ._ORSHP = myPOMBCHQ._ORSHP
      ._PODYN = ""
      ._POFAQ = 0
      ._POFXR = ""
      ._PONBR = myPOMBCHQ._PONBR
      ._POPEN = myPOMBCHQ._AMTNT
      ._POPST = myPOMBCHQ._POPST
      ._POSEQ = 0
      ._POSUF = myPOMBCHQ._POSUFX
      ._POUSE = ""
      ._PRJ = myPOMBCHQ._PRJ
      ._PRTFG = ""
      ._QTRCP = 0
      ._QTRCU = 0
      ._RACTD = myPOMBCHQ._RACTD
      ._RADR1 = myPOMBCHQ._RADR1
      ._RADR2 = myPOMBCHQ._RADR2
      ._RADR3 = myPOMBCHQ._RADR3
      ._RADR4 = myPOMBCHQ._RADR4
      ._RENTC = myPOMBCHQ._RENTC
      ._RENTD = myPOMBCHQ._RENTD
      ._RNAME = myPOMBCHQ._RNAME
      ._RQNBR = myPOMBCHQ._RQNBR
      ._RQQTY = 0
      ._RSQDG = 0
      ._RZIP = myPOMBCHQ._RZIP
      ._RZIPE = myPOMBCHQ._RZIPE
      ._SADR1 = myPOMBCHQ._SADR1
      ._SADR2 = myPOMBCHQ._SADR2
      ._SADR3 = myPOMBCHQ._SADR3
      ._SADR4 = myPOMBCHQ._SADR4
      ._SFUDD = myPOMBCHQ._SFUDD
      ._SFUND = 0
      ._SFUNS = myPOMBCHQ._SFUNS
      ._SHPDL = myPOMBCHQ._SHPDL
      ._SNAME = myPOMBCHQ._SNAME
      ._SUBFD = myPOMBCHQ._SUBFD
      ._SUBFN = 0
      ._SUBFS = myPOMBCHQ._SUBFS
      ._SZIP = myPOMBCHQ._SZIP
      ._SZIPE = myPOMBCHQ._SZIPE
      ._TOTVL = 0
      ._UNITP = 0
      ._UNMSR = ""
      ._VENNM = myPOMBCHQ._VENNM
      ._VNDNR = myPOMBCHQ._VNDNR
      ._VNNAM = myPOMBCHQ._VNNAM
      .AddOneRecordP()
    End With

    With myPOMBCHQ
      dsFile = myPOMBCDL1.GetViewbyPOnbr(._BCHNO, ._PONBR, 0)
    End With

    'Detail
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      WrkSeq = dsFile.Tables(0).Rows(I).Item("poseq") * 10
      With myPOMAST
        .GetOneRecordP(myPOMBCHQ._FSCYR, myPOMBCHQ._PONBR, myPOMBCHQ._POSUFX, WrkSeq, 0)
        If .RecordNotFound Then
          If dsFile.Tables(0).Rows(I).Item("exval") >= 0 Then
            ._AMTGR = 0
            ._AMTNT = 0
            ._BCHNO = myPOMBCHQ._BCHNO
            ._CMPCD = ""
            ._DPNBD = 0
            ._DPNBR = dsFile.Tables(0).Rows(I).Item("dpnbr")
            ._DPNBS = 0
            ._DSCDL = 0
            ._EXVAL = dsFile.Tables(0).Rows(I).Item("exval")
            ._FDNBD = 0
            ._FDNBR = dsFile.Tables(0).Rows(I).Item("fdnbr")
            ._FDNBS = 0
            ._FNPGD = 0
            ._FNPGM = dsFile.Tables(0).Rows(I).Item("fnpgm")
            ._FNPGS = 0
            ._FSCYR = myPOMBCHQ._FSCYR
            ._INUSE = ""
            ._ITDSC = dsFile.Tables(0).Rows(I).Item("itdsc")
            ._ITNBR = dsFile.Tables(0).Rows(I).Item("itnbr")
            ._LLOCN = ""
            ._LNE = 0
            ._MNAYN = ""
            ._OBNBD = 0
            ._OBNBR = dsFile.Tables(0).Rows(I).Item("obnbr")
            ._OBNBS = 0
            ._ORDSP = 0
            ._ORSHP = 0
            ._PODYN = ""
            ._POFAQ = 0
            ._POFXR = ""
            ._PONBR = myPOMBCHQ._PONBR
            ._POPEN = 0
            ._POPST = myPOMBCHQ._POPST
            ._POSEQ = WrkSeq
            ._POSUF = myPOMBCHQ._POSUFX
            ._POUSE = ""
            ._PRJ = 0
            ._PRTFG = ""
            ._QTRCP = 0
            ._QTRCU = 0
            ._RACTD = 0
            ._RADR1 = ""
            ._RADR2 = ""
            ._RADR3 = ""
            ._RADR4 = ""
            ._RENTC = 0
            ._RENTD = 0
            ._RNAME = ""
            ._RQNBR = myPOMBCHQ._RQNBR
            ._RQQTY = dsFile.Tables(0).Rows(I).Item("rqqty")
            ._RSQDG = 0
            ._RZIP = ""
            ._RZIPE = ""
            ._SADR1 = ""
            ._SADR2 = ""
            ._SADR3 = ""
            ._SADR4 = ""
            ._SFUDD = 0
            ._SFUND = dsFile.Tables(0).Rows(I).Item("sfund")
            ._SFUNS = 0
            ._SHPDL = 0
            ._SNAME = ""
            ._SUBFD = 0
            ._SUBFN = dsFile.Tables(0).Rows(I).Item("subfn")
            ._SUBFS = 0
            ._SZIP = ""
            ._SZIPE = ""
            ._TOTVL = 0
            ._UNITP = dsFile.Tables(0).Rows(I).Item("unitp")
            ._UNMSR = dsFile.Tables(0).Rows(I).Item("unmsr")
            ._VENNM = ""
            ._VNDNR = ""
            ._VNNAM = ""
            .AddOneRecordP()
          End If
        End If
      End With
    Next

    With myPOMBCHQ
      dsFile2 = myPOMBCDL1.GetSumbyAcct(._BCHNO, ._PONBR)
    End With
    For I = 0 To dsFile2.Tables(0).Rows.Count - 1
      With myPOSUMF
        WrkStr = BuildAcct(dsFile2.Tables(0).Rows(I).Item("fdnbr"),
       dsFile2.Tables(0).Rows(I).Item("sfund"), dsFile2.Tables(0).Rows(I).Item("dpnbr"),
       dsFile2.Tables(0).Rows(I).Item("obnbr"), dsFile2.Tables(0).Rows(I).Item("fnpgm"),
       dsFile2.Tables(0).Rows(I).Item("subfn"))
        WrkAcct = Replace(WrkStr, "-", "")
        WrkAmount = dsFile2.Tables(0).Rows(I).Item("wrksum")
        .GetOneRecordP(myPOMBCHQ._FSCYR, myPOMBCHQ._PONBR, WrkAcct)
        ._POOPN = WrkAmount
        ._POAMT = WrkAmount
        If .RecordNotFound Then
          ._FSCYR = myPOMBCHQ._FSCYR
          ._PONBR = myPOMBCHQ._PONBR
          ._ACCT = WrkAcct
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End With
    Next
  End Sub
  Private Sub WriteLEDGER()
  Dim dsFile As DataSet = New DataSet
  Dim WrkPosted As Boolean
  dim WrkVennm as string
  Dim I As Integer
  Dim K As Integer

  With myPOMBCHQ
    dsFile = myPOMBCDL1.GetSumbyAcct(._BCHNO, ._PONBR)
    WrkVennm=Left(Trim(._VENNM), 20)
    WrkVennm= Replace(WrkVennm,"'","")
  End With
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With myLEDGER
        With dsFile.Tables(0).Rows(I)
          myGLACCT.GetOneRecordP(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), .Item("FNPGM"), .Item("SUBFN"))
        End With
        WrkPosted = myLEDGERL1.IsPosted(myPOMBCHQ._BCHNO, I + 1, I + 1, myPOMBCHQ._POPST)
        If Not WrkPosted Then
          If dsFile.Tables(0).Rows(I).Item("wrksum") >= 0 Then
            ._AMTYP = "D"
          Else
            ._AMTYP = "C"
          End If
          ._AUTOG = String.Empty
          ._BALFC = String.Empty
          ._BCHNO = myPOMBCHQ._BCHNO
          ._CBLCD = String.Empty
          ._CHKN = 0
          ._CNTRL = 0
          ._DATED = MyUtils.SetDBDateMDY(Date.Today)
          ._DPNBR = dsFile.Tables(0).Rows(I).Item("dpnbr")
          ._GLPST = String.Empty
          ._GLTYP = myGLACCT._GLTYP
          ._FDNBR = dsFile.Tables(0).Rows(I).Item("fdnbr")
          ._FNPGM = dsFile.Tables(0).Rows(I).Item("fnpgm")
          ._FSCYR = myPOMBCHQ._FSCYR
          ._INVNR = ""
          ._JRNSQ = I + 1
          ._OBNBR = dsFile.Tables(0).Rows(I).Item("obnbr")
          ._ORIG = 0
          ._PONBR = myPOMBCHQ._PONBR
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._RECLS = String.Empty
          ._REFNO = myPOMBCHQ._PONBR
          ._ROCR = String.Empty
          ._SFUND = dsFile.Tables(0).Rows(I).Item("sfund")
          ._SRCDE = WrkSrcde
          ._SUBFN = dsFile.Tables(0).Rows(I).Item("subfn")
          ._TRAMT = dsFile.Tables(0).Rows(I).Item("wrksum")
          ._TDESC = WrkVennm
          ._TRFTO = String.Empty
          ._TRNBR = I + 1
          ._TRTYP = "E"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
        End If
      End With

      K = LookupFundCtl(dsFile.Tables(0).Rows(I).Item("fdnbr"))
      FundCtl(K) = dsFile.Tables(0).Rows(I).Item("fdnbr")
      FundCtlAmt(K) = FundCtlAmt(K) + dsFile.Tables(0).Rows(I).Item("wrksum")
    Next

    'Ledger Report - Shipping 
    With myLEDGER
    If myPOMBCHQ._SHPDL > 0 Then
      I = I + 1
      WrkPosted = myLEDGERL1.IsPosted(myPOMBCHQ._BCHNO, I, I, myPOMBCHQ._POPST)
      If Not WrkPosted Then
        myGLACCT.GetOneRecordP(myPOMBCHQ._FDNBS, myPOMBCHQ._SFUNS, myPOMBCHQ._DPNBS, _
         myPOMBCHQ._OBNBS, myPOMBCHQ._FNPGS, myPOMBCHQ._SUBFS)
        If myPOMBCHQ._SHPDL >= 0 Then
          ._AMTYP = "D"
        Else
          ._AMTYP = "C"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = myPOMBCHQ._BCHNO
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = myPOMBCHQ._DPNBS
        ._GLPST = String.Empty
        ._GLTYP = myGLACCT._GLTYP
        ._FDNBR = myPOMBCHQ._FDNBS
        ._FNPGM = myPOMBCHQ._FNPGS
        ._FSCYR = myPOMBCHQ._FSCYR
        ._INVNR = ""
        ._JRNSQ = I
        ._OBNBR = myPOMBCHQ._OBNBS
        ._ORIG = 0
        ._PONBR = myPOMBCHQ._PONBR
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
        ._RECLS = String.Empty
        ._REFNO = myPOMBCHQ._PONBR
        ._ROCR = String.Empty
        ._SFUND = myPOMBCHQ._SFUNS
        ._SRCDE = WrkSrcde
        ._SUBFN = myPOMBCHQ._SUBFS
        ._TRAMT = myPOMBCHQ._SHPDL
        ._TDESC = WrkVennm 
        ._TRFTO = String.Empty
        ._TRNBR = I
        ._TRTYP = "X"
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        .InsertOneRecordP()
      End If
    End If

   'Ledger Report - Discount
    If myPOMBCHQ._SHPDL > 0 Then
      I = I + 1
      WrkPosted = myLEDGERL1.IsPosted(myPOMBCHQ._BCHNO, I, I, myPOMBCHQ._POPST)
      If Not WrkPosted Then
        myGLACCT.GetOneRecordP(myPOMBCHQ._FDNBD, myPOMBCHQ._SFUDD, myPOMBCHQ._DPNBD, _
         myPOMBCHQ._OBNBD, myPOMBCHQ._FNPGD, myPOMBCHQ._SUBFD)
        If myPOMBCHQ._DSCDL >= 0 Then
          ._AMTYP = "C"
        Else
          ._AMTYP = "D"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = myPOMBCHQ._BCHNO
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = myPOMBCHQ._DPNBD
        ._GLPST = String.Empty
        ._GLTYP = myGLACCT._GLTYP
        ._FDNBR = myPOMBCHQ._FDNBD
        ._FNPGM = myPOMBCHQ._FNPGD
        ._FSCYR = myPOMBCHQ._FSCYR
        ._INVNR = ""
        ._JRNSQ = I
        ._OBNBR = myPOMBCHQ._OBNBD
        ._ORIG = 0
        ._PONBR = myPOMBCHQ._PONBR
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
        ._RECLS = String.Empty
        ._REFNO = myPOMBCHQ._PONBR
        ._ROCR = String.Empty
        ._SFUND = myPOMBCHQ._SFUDD
        ._SRCDE = WrkSrcde
        ._SUBFN = myPOMBCHQ._SUBFD
        ._TRAMT = myPOMBCHQ._DSCDL
        ._TDESC = WrkVennm 
        ._TRFTO = String.Empty
        ._TRNBR = I
        ._TRTYP = "X"
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        .InsertOneRecordP()
      End If
    End If
  End With

End Sub
  Private Sub WriteControl(ByVal BatchNo As Integer)
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          .GetOneRecordP(FundCtl(I), 0)
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
        End With
        With myLEDGER
          If FundCtlAmt(I) > 0 Then
            ._AMTYP = "C"
          Else
            ._AMTYP = "D"
          End If
          ._AUTOG = String.Empty
          ._BALFC = String.Empty
          ._BCHNO = BatchNo
          ._CBLCD = String.Empty
          ._CHKN = 0
          ._CNTRL = 0
          ._DATED = MyUtils.SetDBDateMDY(Date.Today)
          ._DPNBR = myGLFUND._DPNBRR
          ._FDNBR = FundCtl(I)
          ._FNPGM = myGLFUND._FNPGMR
          ._FIL10 = "9999999999"
          ._FSCYR = myPOMBCHQ._FSCYR
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = myPOMBCHQ._PONBR
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBRR
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDR
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = myPOMBCHQ._BCHNO
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDR
          ._TDESC = "PO Batch " & myPOMBCHQ._BCHNO
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = 0
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
        End With

        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
        End With
        With myLEDGER
          If FundCtlAmt(I) > 0 Then
            ._AMTYP = "D"
          Else
            ._AMTYP = "C"
          End If
          ._AUTOG = String.Empty
          ._BALFC = String.Empty
          ._BCHNO = BatchNo
          ._CBLCD = String.Empty
          ._CHKN = 0
          ._CNTRL = 0
          ._DATED = MyUtils.SetDBDateMDY(Date.Today)
          ._DPNBR = myGLFUND._DPNBRE
          ._FDNBR = FundCtl(I)
          ._FNPGM = myGLFUND._FNPGME
          ._FIL10 = "9999999999"
          ._FSCYR = myPOMBCHQ._FSCYR
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = myPOMBCHQ._PONBR
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBRE
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDE
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = myPOMBCHQ._BCHNO
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDE
          ._TDESC = "PO Batch " & myPOMBCHQ._BCHNO
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = 0
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
        End With
      End If
    Next
  End Sub
  Private Function LookupFundCtl(ByVal Fund As Integer) As Integer
     Dim I As Integer

     For I = 0 To FundCtl.GetUpperBound(0)
       If FundCtl(I) = 0 Then
         Return I
       End If
       If Fund = FundCtl(I) Then
         Return I
       End If
    Next
    Return 0

End Function
End Module
