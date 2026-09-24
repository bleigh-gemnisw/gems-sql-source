Module PostBCHHDR

  Dim myBCHHDR As BCHHDR.myData
  Dim myGLEBCH As GLEBCH.myData
  Dim myGLACCT As GLACCT.myData
  Dim myGLFUND As GLFUND.myData
  Dim myGNET As GNET.myData
  Dim myFNDSEC As FNDSEC.myData
  Dim myLEDGER As LEDGER.myData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myGLEDOBJ As GLEDOBJ.MyData
  '  Dim myGLEDSUM As GLEDSUM.myData
  Dim myFrmProgress As FrmProgress
  Dim FundCtl(100) As Integer
  Dim FundCtlType(100) As String
  Dim FundCtlTrnbr(100) As Integer
  Dim FundCtlDate(100) As Integer
  Dim FundCtlAmt(100) As Decimal
  Dim WrkRefNo As Integer
  Dim WrkTrnbr As Integer
  Dim WrkSrcde As String
  Dim WrkPostDate As Integer
  Dim ds As DataSet = New DataSet
  Public Sub PstBCHHDR(ByVal BatchNo As Integer)

    Dim dsRec As DataSet = New DataSet
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim Counter As Integer
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim WrkRecoveryTran As Integer
    Dim WrkRecoverySeq As Integer
    Dim WrkPosted As Boolean
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim Answer As Integer

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLEBCH = New GLEBCH.myData()
    myGLEBCH.MyDBConn = myDBConnect
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
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect
    myGLEDOBJ = New GLEDOBJ.MyData()
    myGLEDOBJ.MyDBConn = myDBConnect

    myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
    Counter = 0
    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlType, 0, 100)
    Array.Clear(FundCtlDate, 0, 100)
    Array.Clear(FundCtlTrnbr, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)
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
    If Trim(myBCHHDR._FREEA) = "PR" Then
      WrkSrcde = "5"
    Else
      WrkSrcde = "2"
    End If
    myGLEBCH.OpenFile()
    myGLEBCH.SetRange(BatchNo)

    Do While Not myGLEBCH.IsEOF
      Counter = Counter + 1
      myGLEBCH.ReadFileE()
      With myGLEBCH
        If .IsEOF Then Exit Do
      End With

      WrkPosted = False
      WrkRecoveryTran = 0
      WrkRecoverySeq = 0
      If WrkRecovery And Not WrkRecoveryNormal Then
        If Not WrkPosted Then
          dsRec = myLEDGERL1.GetRecoveryTran(myGLEBCH._BCHNO, myGLEBCH._JACT8)
          If dsRec.Tables(0).Rows.Count > 0 Then
            WrkRecoveryTran = dsRec.Tables(0).Rows(0).Item("trnbr")
            WrkRecoverySeq = dsRec.Tables(0).Rows(0).Item("jrnsq")
          End If
          WrkRecoveryNormal = True
          myFrmProgress.Text = "Creating Report..."
          myFrmProgress.Refresh()
          Answer = MsgBox("Posting will continue after Tran " & WrkRecoveryTran &
         ", Seq " & WrkRecoverySeq & ". If this is not correct click CANCEL",
         MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, "Batch posting recovery mode")
          If Answer = MsgBoxResult.Cancel Then
            myFrmProgress.Close()
            Application.DoEvents()
            GoTo Cleanup
          End If
          Application.DoEvents()
        End If
      End If
      With myGLEBCH
        If ._JRNSEQ > 0 Then
          If WrkRecovery Then
            If WrkRecoveryTran >= ._TRNBR Or WrkRecoveryTran = ._TRNBR And WrkRecoverySeq >= ._JRNSEQ Then
              GoTo SkipHst
            End If
          End If
          WriteLEDGER()
          If WrkSrcde = "2" Then
            If ._TRNTYP = "B" Or ._TRNTYP = "E" Or ._TRNTYP = "X" Then
              UpdateGLEDOBJ()
            End If
          End If
        End If
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
    Loop
    myFrmProgress.Close()
    Application.DoEvents()

    WriteControl(BatchNo)
    myGLEBCH.DeleteBatch(BatchNo)
    myBCHHDR.DeleteOneRecordP()

Cleanup:
    'Memory Cleanup
    myBCHHDR = Nothing
    myGLEBCH = Nothing
    If WrkRecovery Then
      MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
    End If

  End Sub
  Private Sub WriteLEDGER()
    Dim K As Integer

    With myLEDGER
      ._AMTYP = myGLEBCH._AMTTYP
      ._AUTOG = String.Empty
      ._BALFC = String.Empty
      ._BCHNO = myGLEBCH._BCHNO
      ._CBLCD = String.Empty
      ._CHKN = 0
      ._CNTRL = 0
      ._DATED = MyUtils.SetDBDateMDY(Date.Today)
      ._DPNBR = myGLEBCH._DPNBR
      ._FDNBR = myGLEBCH._FDNBR
      ._FNPGM = myGLEBCH._FNPGM
      ._FSCYR = 0
      ._GLPST = String.Empty
      ._GLTYP = myGLEBCH._GLTYP
      ._INVNR = String.Empty
      ._JRNSQ = myGLEBCH._JRNSEQ
      ._OBNBR = myGLEBCH._OBNBR
      ._ORIG = 0
      ._PONBR = 0
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = myGLEBCH._JACT8
      ._RECLS = String.Empty
      ._REFNO = myGLEBCH._REFNO
      ._ROCR = String.Empty
      ._SFUND = myGLEBCH._SFUND
      ._SRCDE = WrkSrcde
      ._SUBFN = myGLEBCH._SUBFN
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      ._TDESC = myGLEBCH._DESCR
      ._TRAMT = myGLEBCH._AMT
      ._TRFTO = String.Empty
      Select Case myGLEBCH._TRNTYP
        Case "T"
          ._TRTYP = "B"
          If myGLEBCH._AMTTYP = "D" Then
            ._TRFTO = "T"
          Else
            ._TRFTO = "F"
          End If
        Case "Z"
          ._TRTYP = "B"
          ._ORIG = myGLEBCH._AMT
        Case Else
          ._TRTYP = myGLEBCH._TRNTYP
      End Select
      ._TRNBR = myGLEBCH._TRNBR
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Application.Exit()
      End If
    End With

    With myGLEBCH
      WrkRefNo = ._REFNO
      WrkPostDate = ._JACT8
      If ._GLTYP = "R" And ._TRNTYP = "X" Or ._GLTYP = "X" And ._TRNTYP = "X" Then
        K = LookupFundCtl(._FDNBR, ._GLTYP, ._TRNBR)
        FundCtl(K) = ._FDNBR
          FundCtlType(K) = ._GLTYP
        FundCtlTrnbr(K) = ._TRNBR
        FundCtlDate(K) = ._JACT8
          If FundCtlType(K) = "R" Then
            If ._AMTTYP = "C" Then
              FundCtlAmt(K) = FundCtlAmt(K) + ._AMT
            Else
              FundCtlAmt(K) = FundCtlAmt(K) - ._AMT
            End If
          Else
            If ._AMTTYP = "D" Then
              FundCtlAmt(K) = FundCtlAmt(K) + ._AMT
            Else
              FundCtlAmt(K) = FundCtlAmt(K) - ._AMT
            End If
          End If
        End If
    End With
  End Sub
  Private Sub UpdateGLEDOBJ()
    'Source Code 2 ONLY
    Dim WrkGLType As String
    Dim WrkAmt As Decimal
    Dim WrkMonth As Integer
    Dim WrkYear As Integer

    With myGLEBCH
      WrkGLType = ._AMTTYP
      If WrkGLType = "C" Then
        WrkAmt = ._AMT * -1
      Else
        WrkAmt = ._AMT
      End If
      WrkMonth = Month(MyUtils.GetDBDate(._JENT8))
      WrkYear = Year(MyUtils.GetDBDate(._JENT8))
      If WrkMonth >= 7 Then
        WrkYear = WrkYear + 1
      End If
    End With

    With myGLEDOBJ
      .GetOneRecordP(WrkYear, myGLEBCH._FDNBR, myGLEBCH._SFUND, myGLEBCH._DPNBR, myGLEBCH._OBNBR)
      Select Case Trim(myGLEBCH._TRNTYP)
        Case "B"
          Select Case WrkMonth
            Case 1
              ._B01 = ._B01 + WrkAmt
            Case 2
              ._B02 = ._B02 + WrkAmt
            Case 3
              ._B03 = ._B03 + WrkAmt
            Case 4
              ._B04 = ._B04 + WrkAmt
            Case 5
              ._B05 = ._B05 + WrkAmt
            Case 6
              ._B06 = ._B06 + WrkAmt
            Case 7
              ._B07 = ._B07 + WrkAmt
            Case 8
              ._B08 = ._B08 + WrkAmt
            Case 9
              ._B09 = ._B09 + WrkAmt
            Case 10
              ._B10 = ._B10 + WrkAmt
            Case 11
              ._B11 = ._B11 + WrkAmt
            Case 12
              ._B12 = ._B12 + WrkAmt
          End Select
        Case "E"
          Select Case WrkMonth
            Case 1
              ._E01 = ._E01 + WrkAmt
            Case 2
              ._E02 = ._E02 + WrkAmt
            Case 3
              ._E03 = ._E03 + WrkAmt
            Case 4
              ._E04 = ._E04 + WrkAmt
            Case 5
              ._E05 = ._E05 + WrkAmt
            Case 6
              ._E06 = ._E06 + WrkAmt
            Case 7
              ._E07 = ._E07 + WrkAmt
            Case 8
              ._E08 = ._E08 + WrkAmt
            Case 9
              ._E09 = ._E09 + WrkAmt
            Case 10
              ._E10 = ._E10 + WrkAmt
            Case 11
              ._E11 = ._E11 + WrkAmt
            Case 12
              ._E12 = ._E12 + WrkAmt
          End Select
        Case "X"
          Select Case WrkMonth
            Case 1
              ._J01 = ._J01 + WrkAmt
            Case 2
              ._J02 = ._J02 + WrkAmt
            Case 3
              ._J03 = ._J03 + WrkAmt
            Case 4
              ._J04 = ._J04 + WrkAmt
            Case 5
              ._J05 = ._J05 + WrkAmt
            Case 6
              ._J06 = ._J06 + WrkAmt
            Case 7
              ._J07 = ._J07 + WrkAmt
            Case 8
              ._J08 = ._J08 + WrkAmt
            Case 9
              ._J09 = ._J09 + WrkAmt
            Case 10
              ._J10 = ._J10 + WrkAmt
            Case 11
              ._J11 = ._J11 + WrkAmt
            Case 12
              ._J12 = ._J12 + WrkAmt
          End Select
      End Select
      If .RecordNotFound Then
        ._FDNBR = myGLEBCH._FDNBR
        ._DPNBR = myGLEBCH._DPNBR
        ._OBNBR = myGLEBCH._OBNBR
        ._FNPGM = myGLEBCH._FNPGM
        ._SUBFN = myGLEBCH._SUBFN
        ._FSCYR = WrkYear
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With

  End Sub
  'Private Sub UpdateGLEDSUM()
  '  'Source Code 2 ONLY
  '  Dim WrkGLType As String
  '  Dim WrkAmt As Decimal
  '  Dim WrkMonth As Integer
  '  Dim WrkYear As Integer

  '  With myGLEBCH
  '    WrkGLType = ._AMTTYP
  '    If WrkGLType = "C" Then
  '      WrkAmt = ._AMT * -1
  '    Else
  '      WrkAmt = ._AMT
  '    End If
  '    WrkMonth = Month(MyUtils.GetDBDate(._JENT8))
  '    WrkYear = Year(MyUtils.GetDBDate(._JENT8))
  '    If WrkMonth >= 7 Then
  '      WrkYear = WrkYear + 1
  '    End If
  '  End With

  '  With myGLEDSUM
  '    .GetOneRecordP(WrkYear, myGLEBCH._FDNBR, myGLEBCH._SFUND, myGLEBCH._DPNBR, myGLEBCH._OBNBR)
  '    Select Case Trim(myGLEBCH._TRNTYP)
  '    Case "B"
  '      Select Case WrkMonth
  '      Case 1
  '        ._B01 = ._B01 + WrkAmt
  '      Case 2
  '        ._B02 = ._B02 + WrkAmt
  '      Case 3
  '        ._B03 = ._B03 + WrkAmt
  '      Case 4
  '        ._B04 = ._B04 + WrkAmt
  '      Case 5
  '        ._B05 = ._B05 + WrkAmt
  '      Case 6
  '        ._B06 = ._B06 + WrkAmt
  '      Case 7
  '        ._B07 = ._B07 + WrkAmt
  '      Case 8
  '        ._B08 = ._B08 + WrkAmt
  '      Case 9
  '        ._B09 = ._B09 + WrkAmt
  '      Case 10
  '        ._B10 = ._B10 + WrkAmt
  '      Case 11
  '        ._B11 = ._B11 + WrkAmt
  '      Case 12
  '        ._B12 = ._B12 + WrkAmt
  '      End Select
  '    Case "E"
  '      Select Case WrkMonth
  '      Case 1
  '        ._E01 = ._E01 + WrkAmt
  '      Case 2
  '        ._E02 = ._E02 + WrkAmt
  '      Case 3
  '        ._E03 = ._E03 + WrkAmt
  '      Case 4
  '        ._E04 = ._E04 + WrkAmt
  '      Case 5
  '        ._E05 = ._E05 + WrkAmt
  '      Case 6
  '        ._E06 = ._E06 + WrkAmt
  '      Case 7
  '        ._E07 = ._E07 + WrkAmt
  '      Case 8
  '        ._E08 = ._E08 + WrkAmt
  '      Case 9
  '        ._E09 = ._E09 + WrkAmt
  '      Case 10
  '        ._E10 = ._E10 + WrkAmt
  '      Case 11
  '        ._E11 = ._E11 + WrkAmt
  '      Case 12
  '        ._E12 = ._E12 + WrkAmt
  '      End Select
  '    Case "X"
  '      Select Case WrkMonth
  '      Case 1
  '        ._J01 = ._J01 + WrkAmt
  '      Case 2
  '        ._J02 = ._J02 + WrkAmt
  '      Case 3
  '        ._J03 = ._J03 + WrkAmt
  '      Case 4
  '        ._J04 = ._J04 + WrkAmt
  '      Case 5
  '        ._J05 = ._J05 + WrkAmt
  '      Case 6
  '        ._J06 = ._J06 + WrkAmt
  '      Case 7
  '        ._J07 = ._J07 + WrkAmt
  '      Case 8
  '        ._J08 = ._J08 + WrkAmt
  '      Case 9
  '        ._J09 = ._J09 + WrkAmt
  '      Case 10
  '        ._J10 = ._J10 + WrkAmt
  '      Case 11
  '        ._J11 = ._J11 + WrkAmt
  '      Case 12
  '        ._J12 = ._J12 + WrkAmt
  '      End Select
  '    End Select
  '    If .RecordNotFound Then
  '      ._FDNBR = myGLEBCH._FDNBR
  '      ._DPNBR = myGLEBCH._DPNBR
  '      ._OBNBR = myGLEBCH._OBNBR
  '      ._FNPGM = myGLEBCH._FNPGM
  '      ._SUBFN = myGLEBCH._SUBFN
  '      ._FSCYR = WrkYear
  '      .AddOneRecordP()
  '    Else
  '      .UpdateOneRecordP()
  '    End If
  '  End With

  'End Sub
  Private Sub WriteControl(ByVal BatchNo As Integer)
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtlAmt(I) <> 0 Then
        myGLFUND.GetOneRecordP(FundCtl(I), 0)
        With myGLFUND
          If FundCtlType(I) = "R" Then
            myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
          Else
            myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
          End If
        End With

        With myLEDGER
          If FundCtlType(I) = "R" Then
            ._DPNBR = myGLFUND._DPNBR1
            ._FNPGM = myGLFUND._FNPGM1
            ._OBNBR = myGLFUND._OBNBR1
            ._SFUND = myGLFUND._SFUND1
            ._SUBFN = myGLFUND._SFUND1
            If FundCtlAmt(I) > 0 Then
              ._AMTYP = "C"
            Else
              ._AMTYP = "D"
            End If
          Else
            ._DPNBR = myGLFUND._DPNBR2
            ._FNPGM = myGLFUND._FNPGM2
            ._OBNBR = myGLFUND._OBNBR2
            ._SFUND = myGLFUND._SFUND2
            ._SUBFN = myGLFUND._SFUND2
            If FundCtlAmt(I) > 0 Then
              ._AMTYP = "D"
            Else
              ._AMTYP = "C"
            End If
          End If
          ._AUTOG = String.Empty
          ._BALFC = String.Empty
          ._BCHNO = BatchNo
          ._CBLCD = String.Empty
          ._CHKN = 0
          ._CNTRL = 0
          ._DATED = MyUtils.SetDBDateMDY(Date.Today)
          ._FDNBR = FundCtl(I)
          ._FIL10 = "9999999999"
          ._FSCYR = 0
          ._GLPST = String.Empty
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 9999
          ._ORIG = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = FundCtlDate(I)
          ._RECLS = String.Empty
          ._REFNO = WrkRefNo
          ._ROCR = String.Empty
          ._SRCDE = WrkSrcde
          ._TDESC = "GL Batch " & BatchNo
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = FundCtlTrnbr(I)
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Application.Exit()
          End If
        End With
      End If
    Next
  End Sub
  Private Function LookupFundCtl(ByVal Fund As Integer, ByVal Gltyp As String, ByVal Trnbr As Integer) As Integer
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtl(I) = 0 Then
        Return I
      End If
      If Fund = FundCtl(I) And Gltyp = FundCtlType(I) And Trnbr = FundCtlTrnbr(I) Then
        Return I
      End If
    Next
    Return 0

  End Function
End Module
