Module PostBCHHDR

	Dim myBCHHDR As BCHHDR.myData
  Dim myMSCBCH As MSCBCH.myData
  Dim myMSCBCHL1 As MSCBCHL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.myData
  Dim myGNET As GNET.myData
  Dim myFNDSEC As FNDSEC.myData
  Dim myLEDGER As LEDGER.myData
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
  myMSCBCH = New MSCBCH.myData()
  myMSCBCH.MyDBConn = myDBConnect
  myMSCBCHL1 = New MSCBCHL1.MyData()
  myMSCBCHL1.MyDBConn = myDBConnect
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

  myFrmProgress = New FrmProgress
  myFrmProgress.Text = "Posting Batch"
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

  Counter = 0

  myMSCBCHL1.SetRange(BatchNo)

  Do While Not myMSCBCH.IsEOF
    Counter = Counter + 1
    myMSCBCHL1.ReadFileE()
    With myMSCBCHL1
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
    If myMSCBCHL1._JRNSEQ > 0 Then
      WriteLEDGER()
    End If

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

WriteControl(BatchNo)
myMSCBCH.GetOneRecordP(BatchNo, BatchNo, 0)
myMSCBCH.DeleteBatch(BatchNo)
myBCHHDR.DeleteOneRecordP()

Cleanup:
  'Memory Cleanup
  myBCHHDR = Nothing
  myMSCBCH = Nothing
  If WrkRecovery Then
    MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
  End If

End Sub
Private Sub WriteLEDGER()
  Dim K As Integer

  With myLEDGER
    ._AMTYP = myMSCBCHL1._AMTTYP
    ._AUTOG = String.Empty
    ._BALFC = String.Empty
    ._BCHNO = myMSCBCHL1._BCHNO
    ._CBLCD = String.Empty
    ._CHKN = 0
    ._CNTRL = 0
    ._DATED = MyUtils.SetDBDateMDY(Date.Today)
    ._DPNBR = myMSCBCHL1._DPNBR
    ._FDNBR = myMSCBCHL1._FDNBR
    ._FIL10 = 0
    ._FIL045 = String.Empty
    ._FNPGM = myMSCBCHL1._FNPGM
    ._FSCYR = 0
    ._GLPST = String.Empty
    ._GLTYP = myMSCBCHL1._GLTYP
    ._INVNR = String.Empty
    ._JRNSQ = myMSCBCHL1._JRNSEQ
    ._ORIG = 0
    ._OBNBR = myMSCBCHL1._OBNBR
    ._PONBR = 0
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = myMSCBCHL1._JACT8
    ._RECLS = String.Empty
    ._REFNO = myMSCBCHL1._REFNO
    ._ROCR = String.Empty
    ._SFUND = myMSCBCHL1._SFUND
    ._SRCDE = myMSCBCHL1._SRCDE
    ._SUBFN = myMSCBCHL1._SUBFN
    ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
    ._TDESC = myMSCBCHL1._DESCR
    ._TRAMT = myMSCBCHL1._AMT
    ._TRFTO = String.Empty
    ._TRNBR = myMSCBCHL1._TRNBR
    ._TRTYP = myMSCBCHL1._TRNTYP
    .InsertOneRecordP()
    If .ErrMsg <>"" Then
      WriteErrorLog(.ErrMsg) 
      Application.exit
    End If
  End With

  With myMSCBCHL1
    WrkRefNo = ._REFNO
    WrkSrcde = ._SRCDE
    WrkPostDate = ._JACT8
    K = LookupFundCtl(._FDNBR)
    FundCtl(K) = ._FDNBR
    If ._GLTYP = "R" Then
      If ._AMTTYP = "C" Then
        FundCtlAmt(K) = FundCtlAmt(K) + ._AMT
      Else
        FundCtlAmt(K) = FundCtlAmt(K) - ._AMT
      End If
    End If
  End With
End Sub
Private Sub WriteControl(ByVal BatchNo As Integer)
 Dim I As Integer

 For I = 0 To FundCtl.GetUpperBound(0)
   If FundCtlAmt(I) <> 0 Then
     myGLFUND.GetOneRecordP(FundCtl(I), 0)
     With myGLFUND
      myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
     End With

        With myLEDGER
          ._BALFC = String.Empty
          ._TRTYP = "X"
          ._CBLCD = String.Empty
          ._GLTYP = myGLACCT._GLTYP
          ._TRFTO = String.Empty
          ._FDNBR = FundCtl(I)
          ._DPNBR = myGLFUND._DPNBR1
          ._OBNBR = myGLFUND._OBNBR1
          ._FNPGM = myGLFUND._FNPGM1
          ._DATED = MyUtils.SetDBDateMDY(Date.Today)
          ._SRCDE = WrkSrcde
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TDESC = Replace(myGLACCT._GLDSC, "'", "")
          ._REFNO = WrkRefNo
          ._ORIG = 0
          ._SUBFN = myGLFUND._SFUND1
          ._AUTOG = String.Empty
          ._BCHNO = BatchNo
          ._TRNBR = BatchNo
          ._JRNSQ = 9999
          ._GLPST = String.Empty
          If FundCtlAmt(I) > 0 Then
            ._AMTYP = "C"
          Else
            ._AMTYP = "D"
          End If
          ._INVNR = String.Empty
          ._SFUND = myGLFUND._SFUND1
          ._PRF = Mid(MyUserID, 1, 10)
          ._ROCR = String.Empty
          ._PSTDT = WrkPostDate
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          ._PONBR = 0
          ._CHKN = 0
          ._FSCYR = 0
          ._CNTRL = 0
          ._RECLS = String.Empty
          ._FIL10 = "9999999999"
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Application.Exit()
          End If
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

End Function
End Module
