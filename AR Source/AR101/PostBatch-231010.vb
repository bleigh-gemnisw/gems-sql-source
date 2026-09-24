Module PostBCHHDR

  Dim myBCHHDR As BCHHDR.MyData
  Dim myCSHBCH As CSHBCH.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myGNET As GNET.MyData
  Dim myFNDSEC As FNDSEC.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim myFrmProgress As FrmProgress
  Dim FundCtl(100) As Integer
  Dim FundCtlDate(100) As Integer
  Dim FundCtlAmt(100) As Decimal
  Dim FundCtlRev(100) As Decimal
  Dim FundCtlExp(100) As Decimal
  Dim WrkRefNo As Integer
  Dim WrkPostDate As Integer
  Dim ds As DataSet = New DataSet
  Const cSrcde As String = "3"
  Public Sub PstBCHHDR(ByVal BatchNo As Integer)

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim Counter As Integer
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim WrkRecoverySeq As Integer
    Dim WrkPosted As Boolean
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim Answer As Integer

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myCSHBCH = New CSHBCH.MyData()
    myCSHBCH.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGNET = New GNET.MyData()
    myGNET.MyDBConn = myDBConnect
    myFNDSEC = New FNDSEC.MyData()
    myFNDSEC.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect

    myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
    Counter = 0
    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlDate, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)
    Array.Clear(FundCtlRev, 0, 100)
    Array.Clear(FundCtlExp, 0, 100)
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

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Posting Batch"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

    myCSHBCH.OpenFile()
    myCSHBCH.SetRange(BatchNo)

    Do While Not myCSHBCH.IsEOF
      Counter = Counter + 1
      myCSHBCH.ReadFileE()
      With myCSHBCH
        If .IsEOF Then Exit Do
      End With

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
      WriteLEDGER()

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
    Loop
    myFrmProgress.Close()
    Application.DoEvents()

    myCSHBCH.DeleteBatch(BatchNo)
    myBCHHDR.DeleteOneRecordP()

Cleanup:
    WriteControl(BatchNo)
    'Memory Cleanup
    myBCHHDR = Nothing
    myCSHBCH = Nothing
    If WrkRecovery Then
      MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
    End If

  End Sub
  Private Sub WriteLEDGER()
    Dim K As Integer
    With myCSHBCH
      myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
    End With
    'Revenue Control
    If myGLACCT._GLTYP = "R" Then
      FundCtl(K) = myCSHBCH._FDNBR
      FundCtlDate(K) = myCSHBCH._TRNDT
      FundCtlRev(K) = FundCtlRev(K) + myCSHBCH._AMTCS
    End If
    'Expenditure Control
    If myGLACCT._GLTYP = "X" Then
      FundCtl(K) = myCSHBCH._FDNBR
      FundCtlDate(K) = myCSHBCH._TRNDT
      FundCtlExp(K) = FundCtlExp(K) + myCSHBCH._AMTCS
    End If

    With myLEDGER
      ._AMTYP = "C"
      ._AUTOG = String.Empty
      ._BALFC = String.Empty
      ._BCHNO = myCSHBCH._BCHNO
      ._CBLCD = String.Empty
      ._CHKN = 0
      ._CNTRL = 0
      ._DATED = MyUtils.SetDBDateMDY(Date.Today)
      ._DPNBR = myCSHBCH._DPNBR
      ._FDNBR = myCSHBCH._FDNBR
      ._FNPGM = myCSHBCH._FNPGM
      ._FSCYR = 0
      ._GLPST = String.Empty
      ._GLTYP = myGLACCT._GLTYP
      ._JRNSQ = myCSHBCH._RECNO
      ._INVNR = String.Empty
      ._OBNBR = myCSHBCH._OBNBR
      ._ORIG = 0
      ._PRF = MyUserID
      ._PONBR = 0
      ._PSTDT = myCSHBCH._TRNDT
      ._RECLS = String.Empty
      ._REFNO = myCSHBCH._REFNO
      ._ROCR = String.Empty
      ._SFUND = myCSHBCH._SFUND
      ._SRCDE = cSrcde
      ._SUBFN = myCSHBCH._SUBFN
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      ._TDESC = myCSHBCH._DSCTX
      ._TRAMT = myCSHBCH._AMTCS
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = "X"
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog("Detail: " & .ErrMsg)
        Application.Exit()
      End If
    End With

    K = LookupFundCtl(myCSHBCH._FDNBR, myCSHBCH._TRNDT)
    If myCSHBCH._FDNBD > 0 Then
      With myCSHBCH
        myGLACCT.GetOneRecordP(._FDNBD, ._SFUDD, ._DPNBD, ._OBNBD, ._FNPGD, ._SUBFD)
      End With
      With myLEDGER
        ._AMTYP = "D"
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = myCSHBCH._BCHNO
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = myCSHBCH._DPNBD
        ._FDNBR = myCSHBCH._FDNBD
        ._FNPGM = myCSHBCH._FNPGD
        ._FSCYR = 0
        ._GLPST = String.Empty
        ._GLTYP = myGLACCT._GLTYP
        ._INVNR = String.Empty
        ._JRNSQ = myCSHBCH._RECNO
        ._OBNBR = myCSHBCH._OBNBD
        ._ORIG = 0
        ._PONBR = 0
        ._PRF = MyUserID
        ._PSTDT = myCSHBCH._TRNDT
        ._RECLS = String.Empty
        ._REFNO = myCSHBCH._REFNO
        ._ROCR = String.Empty
        ._SFUND = myCSHBCH._SFUND
        ._SRCDE = cSrcde
        ._SUBFN = myCSHBCH._SUBFD
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        ._TDESC = myCSHBCH._DSCTX
        ._TRAMT = myCSHBCH._AMTCS
        ._TRFTO = String.Empty
        ._TRNBR = 0
        ._TRTYP = "X"
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog("FDNBD: " & .ErrMsg)
          Application.Exit()
        End If
      End With
    Else
      'Control
      FundCtl(K) = myCSHBCH._FDNBR
      FundCtlDate(K) = myCSHBCH._TRNDT
      FundCtlAmt(K) = FundCtlAmt(K) + myCSHBCH._AMTCS
    End If
  End Sub
  Private Sub WriteControl(ByVal BatchNo As Integer)
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtl(I) <> 0 Then
        With myGLFUND
          .GetOneRecordP(FundCtl(I), 0)
        End With
      End If
      'Cash
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
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
          ._DPNBR = myGLFUND._DPNBRC
          ._FDNBR = FundCtl(I)
          ._FIL10 = 0
          ._FNPGM = myGLFUND._FNPGMC
          ._FSCYR = 0
          ._GLPST = ""
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = MyUserID
          ._PSTDT = FundCtlDate(I)
          ._OBNBR = myGLFUND._OBNBRC
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDC
          ._SRCDE = cSrcde
          ._RECLS = String.Empty
          ._REFNO = 0
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDC
          ._TDESC = "AR Batch " & BatchNo
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = 0
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("CashCtl: " & .ErrMsg)
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
          ._PRF = MyUserID
          ._PSTDT = FundCtlDate(I)
          ._OBNBR = myGLFUND._OBNBR1
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUND1
          ._SRCDE = cSrcde
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

      'Expenditure Control
      If FundCtlExp(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
        End With
        With myLEDGER
          If FundCtlExp(I) > 0 Then
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
          ._DPNBR = myGLFUND._DPNBR2
          ._FDNBR = FundCtl(I)
          ._FIL10 = "9999999999"
          ._FNPGM = myGLFUND._FNPGM2
          ._FSCYR = 0
          ._GLPST = ""
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = MyUserID
          ._PSTDT = FundCtlDate(I)
          ._OBNBR = myGLFUND._OBNBR2
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUND2
          ._SRCDE = cSrcde
          ._RECLS = String.Empty
          ._REFNO = 0
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUND2
          ._TDESC = "AR Batch " & BatchNo
          ._TRAMT = Math.Abs(FundCtlExp(I))
          ._TRFTO = String.Empty
          ._TRNBR = 0
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog("ExpCtl: " & .ErrMsg)
            Application.Exit()
          End If
        End With
      End If
    Next
  End Sub
  Private Function LookupFundCtl(ByVal Fund As Integer, ByVal Trndt As Integer) As Integer
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtl(I) = 0 Then
        Return I
      End If
      If Fund = FundCtl(I) And Trndt = FundCtlDate(I) Then
        Return I
      End If
    Next
    Return 0

  End Function
End Module
