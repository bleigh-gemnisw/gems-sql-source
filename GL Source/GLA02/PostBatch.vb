Module PostBCHHDR

	Dim myBCHHDR As BCHHDR.myData
  Dim myTAXBCH As TAXBCH.MyData
  Dim myTAXBCHL1 As TAXBCHL1.MyData
  Dim myNETGLBCH As NETGLBCH.myData
  Dim myGLACCT As GLACCT.myData
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
  myTAXBCH = New TAXBCH.MyData()
  myTAXBCH.MyDBConn = myDBConnect
  myTAXBCHL1 = New TAXBCHL1.MyData()
  myTAXBCHL1.MyDBConn = myDBConnect
  myNETGLBCH = New NETGLBCH.MyData()
  myNETGLBCH.MyDBConn = myDBConnect
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

  myTAXBCHL1.Setrange(BatchNo)

  Do While Not myTAXBCHL1.IsEOF
    Counter = Counter + 1
    myTAXBCHL1.ReadFileE()
    With myTAXBCHL1
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
    If myTAXBCHL1._JRNSEQ > 0 Then
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
myTAXBCH.GetOneRecordP(BatchNo, BatchNo, 0)
myNETGLBCH.DeleteBatch(myTAXBCHL1._REFNO, myTAXBCHL1._DIST)
myTAXBCH.DeleteBatch(BatchNo)
myBCHHDR.DeleteOneRecordP()

Cleanup:
	'Memory Cleanup
	myBCHHDR = Nothing
	myTAXBCH = Nothing
	If WrkRecovery Then
		MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
	End If

End Sub
Private Sub WriteLEDGER()
  Dim K As Integer

  With myLEDGER
    ._AMTYP = myTAXBCHL1._AMTTYP
    ._AUTOG = String.Empty
    ._BALFC = String.Empty
    ._BCHNO = myTAXBCHL1._BCHNO
    ._CBLCD = String.Empty
    ._CHKN = 0
    ._CNTRL = 0
    ._DATED = MyUtils.SetDBDateMDY(Date.Today)
    ._DPNBR = myTAXBCHL1._DPNBR
    ._FDNBR = myTAXBCHL1._FDNBR
    ._FIL045 = String.Empty
    ._FIL10 = 0
    ._FNPGM = myTAXBCHL1._FNPGM
    ._FSCYR = 0
    ._GLTYP = myTAXBCHL1._GLTYP
    ._GLPST = String.Empty
    ._INVNR = String.Empty
    ._JRNSQ = myTAXBCHL1._JRNSEQ
    ._OBNBR = myTAXBCHL1._OBNBR
    ._ORIG = 0
    ._PONBR = 0
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = myTAXBCHL1._JACT8
    ._RECLS = String.Empty
    ._REFNO = myTAXBCHL1._REFNO
    ._ROCR = String.Empty
    ._SRCDE = myTAXBCHL1._SRCDE
    ._SUBFN = myTAXBCHL1._SUBFN
    ._TDESC = myTAXBCHL1._DESCR
    ._TRAMT = myTAXBCHL1._AMT
    ._TRFTO = String.Empty
    ._TRNBR = myTAXBCHL1._TRNBR
    ._TRTYP = myTAXBCHL1._TRNTYP
    ._SFUND = myTAXBCHL1._SFUND
    ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
    .InsertOneRecordP()
    If .ErrMsg <>"" Then
      WriteErrorLog(.ErrMsg) 
      Application.exit
    End If
  End With

  With myTAXBCHL1
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
      ._DPNBR = myGLFUND._DPNBR1
      ._FDNBR = FundCtl(I)
      ._FIL045 = String.Empty
      ._FIL10 = "9999999999"
      ._FNPGM = myGLFUND._FNPGM1
      ._FSCYR = 0
      ._GLTYP = myGLACCT._GLTYP
      ._GLPST = String.Empty
      ._INVNR = String.Empty
      ._JRNSQ = 9999
      ._OBNBR = myGLFUND._OBNBR1
      ._ORIG = 0
      ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = WrkPostDate
      ._RECLS = String.Empty
      ._REFNO = WrkRefNo
      ._ROCR = String.Empty
      ._SFUND = myGLFUND._SFUND1
      ._SRCDE = WrkSrcde
      ._SUBFN = myGLFUND._SFUND1
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      ._TDESC = myGLACCT._GLDSC
      ._TRAMT = Math.Abs(FundCtlAmt(I))
      ._TRFTO = String.Empty
      ._TRNBR = BatchNo
      ._TRTYP = "X"
      .InsertOneRecordP()
      If .ErrMsg <>"" Then
        WriteErrorLog(.ErrMsg) 
        Application.exit
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
