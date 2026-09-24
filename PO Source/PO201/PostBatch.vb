Module PostBatch
  Dim myBCHHDR As BCHHDR.MyData
  Dim myRQEBCHQ As RQEBCHQ.MyData
  Dim myRQEBCH As RQEBCH.MyData
  Dim myRQEBCD As RQEBCD.MyData
  Dim myRQEBCDL1 As RQEBCDL1.MyData
  Dim myPOMBCH As POMBCH.MyData
  Dim myPOMBCD As POMBCD.MyData
  Dim myPURCTL As PURCTL.MyData
  Dim myPURCTLL1 As PURCTLL1.MyData
  Dim myFrmProgress As FrmProgress
  Dim ds As DataSet = New DataSet
Public Sub PstPO(ByVal LLocn As String, ByVal BatchNo As Integer)

  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim WrkQry As String
  Dim WrkSort As String
  Dim Counter As Integer
  Dim WrkPOBatch As Integer
  Dim WrkRecovery As Boolean
  Dim WrkRecoveryNormal As Boolean
  Dim WrkRecoverySeq As Integer
  Dim WrkPosted As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim Answer As Integer

  myRQEBCHQ = New RQEBCHQ.MyData()
  myRQEBCHQ.MyDBConn = myDBConnect
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myRQEBCH = New RQEBCH.MyData()
  myRQEBCH.MyDBConn = myDBConnect
  myRQEBCD = New RQEBCD.MyData()
  myRQEBCD.MyDBConn = myDBConnect
  myRQEBCDL1 = New RQEBCDL1.MyData()
  myRQEBCDL1.MyDBConn = myDBConnect
  myPOMBCH = New POMBCH.MyData()
  myPOMBCH.MyDBConn = myDBConnect
  myPOMBCD = New POMBCD.MyData()
  myPOMBCD.MyDBConn = myDBConnect
  myPURCTL = New PURCTL.MyData()
  myPURCTL.MyDBConn = myDBConnect
  myPURCTLL1 = New PURCTLL1.MyData()
  myPURCTLL1.MyDBConn = myDBConnect

  myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
  Counter = 0
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
  myRQEBCHQ.OpenQry(WrkSort, WrkQry)

  myFrmProgress = New FrmProgress
  myFrmProgress.Text = "Posting Batch"
  myFrmProgress.Show()
  myFrmProgress.Refresh()
  Application.DoEvents()

  Counter = 0
  WrkPOBatch = GetPoBatch()

ReadNext:
 myRQEBCHQ.ReadQry()
 If Not myRQEBCHQ.IsEOF Then
  With myRQEBCHQ
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
    WritePOBatch(WrkPOBatch, LLocn, BatchNo, ._RQNBR)
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

myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
myBCHHDR.DeleteOneRecordP()
myRQEBCH.DeleteBatch(BatchNo)
myRQEBCD.DeleteBatch(LLocn, BatchNo)

Cleanup:
  'Memory Cleanup
  myBCHHDR = Nothing
  myRQEBCH = Nothing
  If WrkRecovery Then
    MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
  End If

End Sub
Private Function GetPoBatch() As Integer
  Dim WrkPOBatch As Integer
  myBCHHDR.GetOneRecordP(MyBatchPO, 0)
  If myBCHHDR.RecordNotFound Then
    With myBCHHDR
      ._APPID = MyBatchPO
      ._BCHNO = 0
      ._LSBCH = 0
      ._LSTUS = ""
      ._NBRRC = 0
      ._ORGUS = ""
      ._PSDT = 0
      ._STATS = ""
      .AddOneRecordP()
    End With
  End If

  WrkPOBatch = myBCHHDR.AutoGenKey(MyBatchPO)
  myBCHHDR.GetOneRecordP(MyBatchPO, WrkPOBatch)
  If myBCHHDR.RecordNotFound Then
    With myBCHHDR
      ._APPID = MyBatchPO
      ._BCHNO = WrkPOBatch
      ._ORGUS = "GEMSNET"
      ._STATS = "S"
      ._SUBST = ""
      ._PSDT = MyUtils.SetDBDate(MyPostDate)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(MyBatchPO, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkPOBatch
        .UpdateOneRecordP()
      End With
    End If
  End If
  Return WrkPOBatch
End Function
Private Sub WritePOBatch(ByVal WrkPoBatch As Integer, ByVal LLocn As String, _
 ByVal BatchNo As Integer, ByVal WrkRqnbr As Integer)
  Dim dsFile As DataSet = New DataSet
  Dim WrkPONbr As Integer
  Dim I As Integer
  MyFiscyr = myPURCTLL1.GetFscyr(MyUtils.SetDBDate(MyPostDate))
  With myPURCTL
    .GetOneRecordP(MyFiscyr)
    If Not .RecordNotFound Then
      WrkPONbr = ._NXTPO
      ._NXTPO = ._NXTPO + 1
      .UpdateOneRecordP()
    End If
  End With

  dsFile = myRQEBCDL1.GetViewbyRqnbr(LLocn, BatchNo, WrkRqnbr, 0)
  With myPOMBCH
    .GetOneRecordP(BatchNo, WrkPONbr)
    ._AMTGR = myRQEBCHQ._AMTGR
    ._AMTNT = myRQEBCHQ._AMTNT
    ._DPNBD = myRQEBCHQ._DPNBD
    ._DPNBS = myRQEBCHQ._DPNBS
    ._DSCDL = myRQEBCHQ._DSCDL
    ._FDNBD = myRQEBCHQ._FDNBD
    ._FDNBS = myRQEBCHQ._FDNBS
    ._FNPGD = myRQEBCHQ._FNPGD
    ._FNPGS = myRQEBCHQ._FNPGS
    ._FSCYR = MyFiscyr
    ._LLOCN = myRQEBCHQ._LLOCN
    ._LNE = myRQEBCHQ._LNE
    ._OBNBD = myRQEBCHQ._OBNBD
    ._OBNBS = myRQEBCHQ._OBNBS
    ._ORDSP = myRQEBCHQ._ORDSP
    ._ORSHP = myRQEBCHQ._ORSHP
    ._POFXR = myRQEBCHQ._POFXR
    ._POPST = myRQEBCHQ._RQPST
    ._PRJ = myRQEBCHQ._PRJ
    ._RACTD = myRQEBCHQ._RACTD
    ._RADR1 = myRQEBCHQ._RADR1
    ._RADR2 = myRQEBCHQ._RADR2
    ._RADR3 = myRQEBCHQ._RADR3
    ._RADR4 = myRQEBCHQ._RADR4
    ._RENTC = myRQEBCHQ._RENTC
    ._RENTD = myRQEBCHQ._RENTD
    ._RNAME = myRQEBCHQ._RNAME
    ._RQNBR = myRQEBCHQ._RQNBR
    ._RZIP = myRQEBCHQ._RZIP
    ._RZIPE = myRQEBCHQ._RZIPE
    ._SADR1 = myRQEBCHQ._SADR1
    ._SADR2 = myRQEBCHQ._SADR2
    ._SADR3 = myRQEBCHQ._SADR3
    ._SADR4 = myRQEBCHQ._SADR4
    ._SFUDD = myRQEBCHQ._SFUDD
    ._SFUNS = myRQEBCHQ._SFUNS
    ._SHPDL = myRQEBCHQ._SHPDL
    ._SNAME = myRQEBCHQ._SNAME
    ._SUBFD = myRQEBCHQ._SUBFD
    ._SUBFS = myRQEBCHQ._SUBFS
    ._SZIP = myRQEBCHQ._SZIP
    ._SZIPE = myRQEBCHQ._SZIPE
    ._VENNM = myRQEBCHQ._VENNM
    ._VNDNR = myRQEBCHQ._VNDNR
    ._VNNAM = myRQEBCHQ._VNNAM
    If .RecordNotFound Then
      ._BCHNO = WrkPOBatch
      ._PONBR = WrkPONbr
      .AddOneRecordP()
    Else
      .UpdateOneRecordP()
    End If
  End With

  'Detail Records
  For I = 0 To dsFile.Tables(0).Rows.Count - 1
    With myPOMBCD
      .GetOneRecordP(BatchNo, WrkPONbr, dsFile.Tables(0).Rows(I).Item("rqseq"))
      ._DPNBR = dsFile.Tables(0).Rows(I).Item("dpnbr")
      ._EXVAL = dsFile.Tables(0).Rows(I).Item("exval")
      ._FDNBR = dsFile.Tables(0).Rows(I).Item("fdnbr")
      ._FNPGM = dsFile.Tables(0).Rows(I).Item("fnpgm")
      ._ITDSC = dsFile.Tables(0).Rows(I).Item("itdsc")
      ._ITNBR = dsFile.Tables(0).Rows(I).Item("itnbr")
      ._OBNBR = dsFile.Tables(0).Rows(I).Item("obnbr")
      ._RQQTY = dsFile.Tables(0).Rows(I).Item("rqqty")
      ._SFUND = dsFile.Tables(0).Rows(I).Item("sfund")
      ._SUBFN = dsFile.Tables(0).Rows(I).Item("subfn")
      ._TOTVL = 0
      ._UNITP = dsFile.Tables(0).Rows(I).Item("unitp")
      ._UNMSR = dsFile.Tables(0).Rows(I).Item("unmsr")
      If .RecordNotFound Then
        ._BCHNO = WrkPOBatch
        ._PONBR = WrkPONbr
        ._POSEQ = dsFile.Tables(0).Rows(I).Item("rqseq")
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With
  Next
End Sub
End Module
