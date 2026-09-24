Module PostBCHHDR

  Dim myBCHHDR As BCHHDR.MyData
  Dim myAPEBCHQ As APEBCHQ.MyData
  Dim myAPEBCH As APEBCH.MyData
  Dim myAPEBCD As APEBCD.MyData
  Dim myAPEBCDL1 As APEBCDL1.MyData
  Dim myAPEOPN As APEOPN.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myGNET As GNET.MyData
  Dim myFNDSEC As FNDSEC.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myPOMAST As POMAST.MyData
  Dim myPOSUMF As POSUMF.MyData
  Dim myPOSUMFL1 As POSUMFL1.MyData
  Dim myFrmProgress As FrmProgress
  Dim FundCtl(100) As Integer
  Dim FundCtlAmt(100) As Decimal
  Dim FundCtlAP(100) As Decimal
  Dim FundCtlExp(100) As Decimal
  Dim FundCtlRev(100) As Decimal
  Dim WrkSrcde As String
  Dim WrkRefNo As Integer
  Dim WrkPostDate As Integer
  Dim ds As DataSet = New DataSet
  Public Sub PstBCHHDR(ByVal BatchNo As Integer)

    Dim dsRec As DataSet = New DataSet
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

    myAPEBCHQ = New APEBCHQ.MyData()
    myAPEBCHQ.MyDBConn = myDBConnect
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myAPEBCH = New APEBCH.MyData()
    myAPEBCH.MyDBConn = myDBConnect
    myAPEBCD = New APEBCD.MyData()
    myAPEBCD.MyDBConn = myDBConnect
    myAPEBCDL1 = New APEBCDL1.MyData()
    myAPEBCDL1.MyDBConn = myDBConnect
    myAPEOPN = New APEOPN.MyData()
    myAPEOPN.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    myFNDSEC = New FNDSEC.MyData()
    myFNDSEC.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    myPOSUMF = New POSUMF.MyData()
    myPOSUMF.MyDBConn = myDBConnect
    myPOSUMFL1 = New POSUMFL1.MyData()
    myPOSUMFL1.MyDBConn = myDBConnect

    myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
    WrkSrcde = 1
    Counter = 0
    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)
    Array.Clear(FundCtlAP, 0, 100)
    Array.Clear(FundCtlExp, 0, 100)
    Array.Clear(FundCtlRev, 0, 100)
    WrkRecovery = False
    WrkRecoveryNormal = False
    If myBCHHDR.RecordNotFound Then Exit Sub

    With myBCHHDR
      If Trim(._STATS) = "P" Then
        MsgBox("This process will automatically determine what needs to be done to finish the batch posting", MsgBoxStyle.Exclamation, "Batch has partially posted. Batch recovery will start.")
        WrkRecovery = True
      Else
        ._STATS = "P"
        '      .UpdateOneRecordP()
      End If
    End With

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "BCHNO = " & BatchNo
    WrkSort = "VNDNR,INVNO,SEQNO"
    myAPEBCHQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Posting Batch"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    myAPEBCHQ.ReadQry()
    If Not myAPEBCHQ.IsEOF Then
      With myAPEBCHQ
        Counter = Counter + 1
        WrkPosted = False
        WrkRecoverySeq = 0
        If WrkRecovery And Not WrkRecoveryNormal Then
          If Not WrkPosted Then
            dsRec = myLEDGERL1.GetRecoveryTran(._BCHNO, ._PPDT8)
            If dsRec.Tables(0).Rows.Count > 0 Then
              WrkRecoverySeq = dsRec.Tables(0).Rows(0).Item("jrnsq")
            End If
            WrkRecoveryNormal = True
            myFrmProgress.Text = "Creating Report..."
            myFrmProgress.Refresh()
            Answer = MsgBox("Posting will continue after Seq " & WrkRecoverySeq & ". If this is not correct click CANCEL",
         MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Batch posting recovery mode")
            If Answer = MsgBoxResult.Cancel Then
              myFrmProgress.Close()
              Application.DoEvents()
              GoTo Cleanup
            End If
            Application.DoEvents()
          End If
        End If
        If WrkRecovery Then
          If WrkRecoverySeq >= ._SEQNO Then
            GoTo SkipHst
          End If
        End If
        WriteAPEOPN()
        UpdateVendor(myAPEBCHQ._AMTNT)
        WriteLEDGER()
        UpdatePO()
        UpdatePOSUMF()
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
    myAPEBCH.DeleteBatch(BatchNo)
    myAPEBCD.DeleteBatch(BatchNo)
    myBCHHDR.DeleteOneRecordP()

Cleanup:
    'Memory Cleanup
    myBCHHDR = Nothing
    myAPEBCH = Nothing
    If WrkRecovery Then
      MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
    End If

  End Sub
  Private Sub WriteAPEOPN()
    Dim dsFile As DataSet = New DataSet
    Dim I As Integer

    myVENDOR.GetOneRecordP(myAPEBCHQ._VNDNR)
    dsFile = myAPEBCDL1.GetViewbySeqno(myAPEBCHQ._BCHNO, myAPEBCHQ._SEQNO, 0)
    'Header Record (Seqno=0)
    With myAPEOPN
      .GetOneRecordP(myAPEBCHQ._VNDNR, myAPEBCHQ._INVNO, 0)
      ._AMTDS = myAPEBCHQ._AMTDS
      ._AMTGR = myAPEBCHQ._AMTGR
      ._AMTNT = myAPEBCHQ._AMTNT
      ._AMTOP = myAPEBCHQ._AMTNT
      ._AMTPD = 0
      ._AMTSH = 0
      ._APPST = MyUtils.SetDBDateMDY(MyUtils.GetDBDate(myAPEBCHQ._APPST))
      ._BCHNO = myAPEBCHQ._BCHNO
      ._BNKCD = myAPEBCHQ._BNKCD
      ._CHKPD = 0
      ._CSHYN = myAPEBCHQ._CSHYN
      ._DPNBR = 0
      ._DSCTX = myAPEBCHQ._DSCTX
      ._DUED8 = myAPEBCHQ._DUED8
      ._F1099 = myAPEBCHQ._F1099
      ._FA = ""
      ._FDNBR = dsFile.Tables(0).Rows(0).Item("fdnbr")
      ._FNPGM = 0
      ._FSCYR = myAPEBCHQ._FSCYR
      ._HINV = myAPEBCHQ._HINV
      ._INVD8 = MyUtils.SetDBDateMDY(MyUtils.GetDBDate(myAPEBCHQ._INVD8))
      ._INVNO = myAPEBCHQ._INVNO
      ._LEOPN = myAPEBCHQ._LEOPN
      ._LSTP8 = 0
      ._LSTPD = 0
      ._OBNBR = 0
      ._OTIME = ""
      ._PAYAM = 0
      ._PAYBN = ""
      ._PAYCK = 0
      ._PAYPD = 0
      ._PONBR = myAPEBCHQ._PONBR
      ._PPDT8 = myAPEBCHQ._PPDT8
      ._PRJ = myAPEBCHQ._PRJ
      ._RECNO = 0
      ._RPRF = MyUserID
      ._SFUND = 0
      ._SLTPY = ""
      ._SUBFN = 0
      ._VENNM = myAPEBCHQ._VENNM
      ._VNCAT = myVENDOR._VNCAT
      ._VNDNR = myAPEBCHQ._VNDNR
      ._VSORT = myVENDOR._VSORT
      If .RecordNotFound Then
        .AddOneRecordP()
      End If
    End With

    'Detail Records
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With myAPEOPN
        .GetOneRecordP(myAPEBCHQ._VNDNR, myAPEBCHQ._INVNO, dsFile.Tables(0).Rows(I).Item("recno") * 10)
        ._AMTDS = 0
        ._AMTGR = dsFile.Tables(0).Rows(I).Item("amtnt")
        ._AMTNT = 0
        ._AMTOP = myAPEBCHQ._AMTNT
        ._AMTPD = 0
        ._AMTSH = 0
        ._APPST = MyUtils.SetDBDateMDY(MyUtils.GetDBDate(myAPEBCHQ._APPST))
        ._BCHNO = myAPEBCHQ._BCHNO
        ._BNKCD = myAPEBCHQ._BNKCD
        ._CHKPD = 0
        ._CSHYN = myAPEBCHQ._CSHYN
        ._DPNBR = dsFile.Tables(0).Rows(I).Item("dpnbr")
        ._DSCTX = ""
        ._DUED8 = myAPEBCHQ._DUED8
        ._F1099 = ""
        ._FA = ""
        ._FDNBR = dsFile.Tables(0).Rows(I).Item("fdnbr")
        ._FNPGM = dsFile.Tables(0).Rows(I).Item("fnpgm")
        ._FSCYR = myAPEBCHQ._FSCYR
        ._HINV = myAPEBCHQ._HINV
        ._INVD8 = MyUtils.SetDBDateMDY(MyUtils.GetDBDate(myAPEBCHQ._INVD8))
        ._INVNO = myAPEBCHQ._INVNO
        ._LEOPN = myAPEBCHQ._LEOPN
        ._LSTP8 = 0
        ._LSTPD = 0
        ._OBNBR = dsFile.Tables(0).Rows(I).Item("obnbr")
        ._OTIME = ""
        ._PAYAM = 0
        ._PAYBN = ""
        ._PAYCK = 0
        ._PAYPD = 0
        ._PONBR = myAPEBCHQ._PONBR
        ._PPDT8 = myAPEBCHQ._PPDT8
        ._PRJ = myAPEBCHQ._PRJ
        ._RECNO = dsFile.Tables(0).Rows(I).Item("recno") * 10
        ._RPRF = MyUserID
        ._SFUND = dsFile.Tables(0).Rows(I).Item("sfund")
        ._SLTPY = ""
        ._SUBFN = dsFile.Tables(0).Rows(I).Item("subfn")
        ._VENNM = myAPEBCHQ._VENNM
        ._VNCAT = myVENDOR._VNCAT
        ._VNDNR = myAPEBCHQ._VNDNR
        ._VSORT = myVENDOR._VSORT
        If .RecordNotFound Then
          .AddOneRecordP()
        End If
      End With
    Next
  End Sub
  Private Sub WriteLEDGER()
    Dim dsFile As DataSet = New DataSet
    Dim dsSum As DataSet = New DataSet
    Dim WrkAcct As String
    Dim WrkPOopn As Decimal
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer

    dsFile = myAPEBCDL1.GetSumbyAcct(myAPEBCHQ._BCHNO, myAPEBCHQ._SEQNO)
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      myGLACCT.GetOneRecordP(dsFile.Tables(0).Rows(I).Item("fdnbr"), dsFile.Tables(0).Rows(I).Item("sfund"),
       dsFile.Tables(0).Rows(I).Item("dpnbr"), dsFile.Tables(0).Rows(I).Item("obnbr"), dsFile.Tables(0).Rows(I).Item("fnpgm"),
       dsFile.Tables(0).Rows(I).Item("subfn"))
      With myLEDGER
        'Encumbrance
        If myAPEBCHQ._PONBR > 0 And myAPEBCHQ._POLIQ = "" Then
          If dsFile.Tables(0).Rows(I).Item("wrksum") > 0 Then
            ._AMTYP = "C"
          Else
            ._AMTYP = "D"
          End If
          ._AUTOG = String.Empty
          ._BALFC = String.Empty
          ._BCHNO = myAPEBCHQ._BCHNO
          ._CBLCD = String.Empty
          ._CHKN = 0
          ._CNTRL = 0
          ._DATED = MyUtils.SetDBDateMDY(Date.Today)
          ._DPNBR = dsFile.Tables(0).Rows(I).Item("dpnbr")
          ._GLPST = String.Empty
          ._GLTYP = myGLACCT._GLTYP
          ._FDNBR = dsFile.Tables(0).Rows(I).Item("fdnbr")
          ._FIL10 = 0
          ._FNPGM = dsFile.Tables(0).Rows(I).Item("fnpgm")
          ._FSCYR = myAPEBCHQ._FSCYR
          ._INVNR = myAPEBCHQ._INVNO
          ._JRNSQ = myAPEBCHQ._SEQNO
          ._OBNBR = dsFile.Tables(0).Rows(I).Item("obnbr")
          ._ORIG = 0
          ._PONBR = myAPEBCHQ._PONBR
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._RECLS = String.Empty
          ._REFNO = myAPEBCHQ._PONBR
          ._ROCR = String.Empty
          ._SFUND = dsFile.Tables(0).Rows(I).Item("sfund")
          ._SRCDE = WrkSrcde
          ._SUBFN = dsFile.Tables(0).Rows(I).Item("subfn")
          WrkPOopn = 0
          With dsFile.Tables(0).Rows(I)
            WrkAcct = BuildAcct(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), .Item("FNPGM"), .Item("SUBFN"))
          End With
          dsSum = myPOSUMFL1.GetAllPONo(myAPEBCHQ._FSCYR, myAPEBCHQ._PONBR, 0)
          For J = 0 To dsSum.Tables(0).Rows.Count - 1
            If dsSum.Tables(0).Rows(J).Item("acct") = Replace(WrkAcct, "-", "") Then
              WrkPOopn = WrkPOopn + dsSum.Tables(0).Rows(J).Item("poopn")
            End If
          Next
          If dsFile.Tables(0).Rows(I).Item("wrksum") > 0 Then
            If myAPEBCHQ._LEOPN = "P" Then
              If dsFile.Tables(0).Rows(I).Item("wrksum") <= WrkPOopn Then
                ._TRAMT = Math.Abs(dsFile.Tables(0).Rows(I).Item("wrksum"))
              Else
                ._TRAMT = WrkPOopn
              End If
            Else
                ._TRAMT = WrkPOopn
            End If
          Else
            ._TRAMT = Math.Abs(dsFile.Tables(0).Rows(I).Item("wrksum"))
          End If
          ._TDESC = Mid(Replace(myAPEBCHQ._VENNM, "'", ""), 1, 30)
          ._TRFTO = String.Empty
          ._TRNBR = myAPEBCHQ._BCHNO
          ._TRTYP = "E"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          If ._TRAMT <> 0 Then
            .InsertOneRecordP()
          End If
          If .ErrMsg <> "" Then
            WriteErrorLog("Encumb: " & .ErrMsg)
            Application.Exit()
          End If
        End If

        'Expenditure/Revenue
        If dsFile.Tables(0).Rows(I).Item("wrksum") > 0 Then
          ._AMTYP = "D"
        Else
          ._AMTYP = "C"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = myAPEBCHQ._BCHNO
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = dsFile.Tables(0).Rows(I).Item("dpnbr")
        ._GLPST = String.Empty
        ._GLTYP = myGLACCT._GLTYP
        ._FDNBR = dsFile.Tables(0).Rows(I).Item("fdnbr")
        ._FIL10 = 0
        ._FNPGM = dsFile.Tables(0).Rows(I).Item("fnpgm")
        ._FSCYR = myAPEBCHQ._FSCYR
        ._INVNR = myAPEBCHQ._INVNO
        ._JRNSQ = myAPEBCHQ._SEQNO
        ._OBNBR = dsFile.Tables(0).Rows(I).Item("obnbr")
        ._ORIG = 0
        ._PONBR = myAPEBCHQ._PONBR
        ._PRF = Mid(MyUserID, 1, 10)
        ._PSTDT = myBCHHDR._PSDT
        ._RECLS = String.Empty
        ._REFNO = myAPEBCHQ._PONBR
        ._ROCR = String.Empty
        ._SFUND = dsFile.Tables(0).Rows(I).Item("sfund")
        ._SRCDE = WrkSrcde
        ._SUBFN = dsFile.Tables(0).Rows(I).Item("subfn")
        ._TRAMT = Math.Abs(dsFile.Tables(0).Rows(I).Item("wrksum"))
        ._TDESC = Mid(Replace(myAPEBCHQ._VENNM, "'", ""), 1, 30)
        ._TRFTO = String.Empty
        ._TRNBR = myAPEBCHQ._BCHNO
        ._TRTYP = "X"
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog("Expend: " & .ErrMsg)
          Application.Exit()
        End If
      End With
      K = LookupFundCtl(dsFile.Tables(0).Rows(I).Item("FDNBR"))
      FundCtl(K) = dsFile.Tables(0).Rows(I).Item("FDNBR")
      FundCtlAP(K) = FundCtlAP(K) + dsFile.Tables(0).Rows(I).Item("wrksum")
      If myGLACCT._GLTYP = "X" Then
        FundCtlExp(K) = FundCtlExp(K) + dsFile.Tables(0).Rows(I).Item("wrksum")
      End If
      If myGLACCT._GLTYP = "R" Then
        FundCtlRev(K) = FundCtlRev(K) + dsFile.Tables(0).Rows(I).Item("wrksum")
      End If
      If myAPEBCHQ._PONBR > 0 Then
        If myAPEBCHQ._LEOPN = "P" Then
          If dsFile.Tables(0).Rows(I).Item("wrksum") <= WrkPOopn Then
            FundCtlAmt(K) = FundCtlAmt(K) + dsFile.Tables(0).Rows(I).Item("wrksum")
          Else
            FundCtlAmt(K) = FundCtlAmt(K) + WrkPOopn
          End If
        Else
            FundCtlAmt(K) = FundCtlAmt(K) + WrkPOopn
        End If
      End If
    Next

  End Sub
  Private Sub WriteControl(ByVal BatchNo As Integer)
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtlAP(I) <> 0 Then
        With myGLFUND
          'A/P Control 
          .GetOneRecordP(FundCtl(I), 0)
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDA, ._DPNBRA, ._OBNBRA, ._FNPGMA, ._SUBFNA)
        End With
        With myLEDGER
          If FundCtlAP(I) > 0 Then
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
          ._DPNBR = myGLFUND._DPNBRA
          ._FDNBR = FundCtl(I)
          ._FIL10 = 0
          ._FNPGM = myGLFUND._FNPGMA
          ._FSCYR = 0
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBRA
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDA
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = myAPEBCHQ._BCHNO
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDA
          ._TDESC = "AP Batch " & myAPEBCHQ._BCHNO
          ._TRAMT = Math.Abs(FundCtlAP(I))
          ._TRFTO = String.Empty
          ._TRNBR = BatchNo
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("A/P: " & .ErrMsg)
            Application.Exit()
          End If
        End With
      End If

      'Reserve for Encumbrance 
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          .GetOneRecordP(FundCtl(I), 0)
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
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
          ._DPNBR = myGLFUND._DPNBRR
          ._FDNBR = FundCtl(I)
          ._FIL10 = "9999999999"
          ._FNPGM = myGLFUND._FNPGMR
          ._FSCYR = 0
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBRR
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDR
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = myAPEBCHQ._BCHNO
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDR
          ._TDESC = "AP Batch " & myAPEBCHQ._BCHNO
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = BatchNo
          ._TRTYP = "E"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("Reserve: " & .ErrMsg)
            Application.Exit()
          End If
        End With
      End If

      'Expenditure Control
      If FundCtlExp(I) <> 0 Then
        With myGLFUND
          .GetOneRecordP(FundCtl(I), 0)
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
        End With
        With myLEDGER
          If FundCtlExp(I) > 0 Then
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
          ._DPNBR = myGLFUND._DPNBR2
          ._FDNBR = FundCtl(I)
          ._FIL10 = "9999999999"
          ._FNPGM = myGLFUND._FNPGM2
          ._FSCYR = 0
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBR2
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUND2
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = myAPEBCHQ._BCHNO
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUND2
          ._TDESC = "AP Batch " & myAPEBCHQ._BCHNO
          ._TRAMT = Math.Abs(FundCtlExp(I))
          ._TRFTO = String.Empty
          ._TRNBR = BatchNo
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("ExpCtl: " & .ErrMsg)
            Application.Exit()
          End If
        End With
      End If

      'Revenue Control
      If FundCtlRev(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
        End With
        With myLEDGER
          If FundCtlRev(I) > 0 Then
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
          ._DPNBR = myGLFUND._DPNBR1
          ._FDNBR = FundCtl(I)
          ._FIL10 = "9999999999"
          ._FNPGM = myGLFUND._FNPGM1
          ._FSCYR = 0
          ._GLPST = ""
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBR1
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUND1
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = 0
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUND1
          ._TDESC = "AR Batch " & BatchNo
          ._TRAMT = Math.Abs(FundCtlRev(I))
          ._TRFTO = String.Empty
          ._TRNBR = 0
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("RevCtl: " & .ErrMsg)
            Application.Exit()
          End If
        End With
      End If

      'Encumbrance
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
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
          ._DPNBR = myGLFUND._DPNBRE
          ._FDNBR = FundCtl(I)
          ._FIL10 = "9999999999"
          ._FNPGM = myGLFUND._FNPGME
          ._FSCYR = 0
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = myBCHHDR._PSDT
          ._OBNBR = myGLFUND._OBNBRE
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDE
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = myAPEBCHQ._BCHNO
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDE
          ._TDESC = "AP Batch " & myAPEBCHQ._BCHNO
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = BatchNo
          ._TRTYP = "E"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("EncCtl: " & .ErrMsg)
            Application.Exit()
          End If
        End With
      End If
    Next
  End Sub
  Private Sub UpdateVendor(ByVal Amount As Decimal)
    With myVENDOR
      .GetOneRecordP(myAPEBCHQ._VNDNR)
      ._MTDPR = ._MTDPR + Amount
      ._FSCPR = ._FSCPR + Amount
      ._YTDPR = ._YTDPR + Amount
      .UpdateOneRecordP()
    End With
  End Sub
  Private Sub UpdatePO()
    Dim dsSum As DataSet = New DataSet
    Dim WrkPoOpn As Decimal
    dsSum = myPOSUMFL1.GetAllPONo(myAPEBCHQ._FSCYR, myAPEBCHQ._PONBR, 0)
    For J = 0 To dsSum.Tables(0).Rows.Count - 1
      WrkPoOpn = WrkPoOpn + dsSum.Tables(0).Rows(J).Item("poopn")
    Next

    If Trim(myAPEBCHQ._LEOPN) = "" And myAPEBCHQ._PONBR > 0 And WrkPoOpn = 0 Then
      With myPOMAST
        .GetOneRecordP(myAPEBCHQ._FSCYR, myAPEBCHQ._PONBR, 0, 0, 0)
        ._CMPCD = "C"
        .UpdateOneRecordP()
      End With
    End If
  End Sub
  Private Sub UpdatePOSUMF()
    Dim dsFile As DataSet = New DataSet
    Dim WrkStr As String
    Dim WrkAcct As Decimal
    Dim WrkAmount As Decimal
    Dim I As Integer

    If myAPEBCHQ._PONBR = 0 Then Exit Sub

    dsFile = myAPEBCDL1.GetSumbyAcct(myAPEBCHQ._BCHNO, myAPEBCHQ._SEQNO)
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      WrkAmount = dsFile.Tables(0).Rows(I).Item("wrksum")
      With myPOSUMF
        WrkStr = BuildAcct(dsFile.Tables(0).Rows(I).Item("fdnbr"),
         dsFile.Tables(0).Rows(I).Item("sfund"), dsFile.Tables(0).Rows(I).Item("dpnbr"),
         dsFile.Tables(0).Rows(I).Item("obnbr"), dsFile.Tables(0).Rows(I).Item("fnpgm"),
         dsFile.Tables(0).Rows(I).Item("subfn"))
        WrkAcct = Replace(WrkStr, "-", "")
        .GetOneRecordP(myAPEBCHQ._FSCYR, myAPEBCHQ._PONBR, WrkAcct)
        If myAPEBCHQ._LEOPN = "P" Then
          ._POOPN = ._POOPN - WrkAmount
          If ._POOPN < 0 Then ._POOPN = 0
          ._POPAD = ._POPAD + WrkAmount
          If ._POPAD > ._POAMT Then ._POPAD = ._POAMT
        Else
          ._POOPN = 0
          ._POPAD = ._POAMT
        End If
        If .RecordNotFound Then
          ._FSCYR = myAPEBCHQ._FSCYR
          ._PONBR = myAPEBCHQ._PONBR
          ._ACCT = WrkAcct
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End With
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
