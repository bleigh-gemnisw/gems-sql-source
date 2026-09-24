Module PostBCHHDR

  Dim myBCHHDR As BCHHDR.myData
  Dim myTCRBCH As TCRBCH.MyData
  Dim myTCRBCHL1 As TCRBCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXINV_NY As TXINV.myData
  Dim myTXINVLC As TXINVLC.myData
  Dim myTXINVLM As TXINVLM.myData
  Dim myTXINVLN As TXINVLN.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL1 As TXHSTL1.myData
  Dim myTXPROF As TXPROF.myData
  Dim myFrmProgress As FrmProgress

  Dim ds As DataSet = New DataSet
  Dim BchStatus As String
  Dim BchSubst As String
  Dim BchSrc As Integer
  Dim BchPmeth As String
  Dim BchListNo As Integer
  Dim BchYear As Integer
  Dim BchType As String
  Dim BchPamt As Decimal
  Dim BchIamt As Decimal
  Dim BchLamt As Decimal
  Dim BchPCamt As Decimal
  Dim BchPCamt1 As Decimal
  Dim BchPCamt2 As Decimal
  Dim BchPCamt3 As Decimal
  Dim BchPCamt4 As Decimal
  Dim BchPCamt5 As Decimal
  Dim BchPCamt6 As Decimal
  Dim BchPencd1 As String
  Dim BchPencd2 As String
  Dim BchPencd3 As String
  Dim BchPencd4 As String
  Dim BchPencd5 As String
  Dim BchPencd6 As String
  Dim BchAdjcd As String
  Dim BchCash As Decimal
  Dim BchCheck As Decimal
  Dim BchCredit As Decimal
  Dim BchSeqNo As Integer
  Dim BchDist As Integer
  Dim BchIntDte As Integer
  Dim BchRecDte As Integer
  Dim BchRef As String
  Dim BchComm As String
  Public Sub PstBCHHDR(ByVal BatchNo As Integer)
    Dim ds2 As DataSet = New DataSet
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim Counter As Integer
    Dim WrkRecID As Integer
    Dim WrkAdjTax As Decimal
    Dim WrkBald As Decimal
    'Dim WrkBondDue As Decimal
    Dim WrkFee(6) As Decimal
    Dim WrkFeeCd(6) As String
    Dim WrkInvFee(6) As Decimal
    Dim WrkInvFeeCd(6) As String
    Dim WrkFirstTime As Boolean
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim WrkRecoverySeq As Integer
    Dim WrkPostDBDate As Integer
    Dim WrkPosted As Boolean
    Dim WrkTXGL As Boolean
    Dim WrkBatchA As String
    Dim WrkSuspense As Boolean
    Dim WrkPaid As Decimal
    Dim WrkSet As String
    Dim WrkWhere As String
    Dim WrkPct As Integer
    Dim SavePct As Integer
    Dim Answer As Integer
    Dim I As Integer
    Dim J As Integer

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myTCRBCH = New TCRBCH.mydata(MyDBConnect)
    myTCRBCHL1 = New TCRBCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINV_NY = New TXINV.mydata(MyDBConnect)
    myTXINVLC = New TXINVLC.mydata(MyDBConnect)
    myTXINVLM = New TXINVLM.mydata(MyDBConnect)
    myTXINVLN = New TXINVLN.mydata(MyDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL1 = New TXHSTL1.mydata(myDBConnect)
    myTXPROF = New TXPROF.mydata(MyDBConnect)
    myBCHHDR.GetOneRecordP(MyBatch, BatchNo)

    Counter = 0
    WrkRecovery = False
    WrkRecoveryNormal = False
    WrkBatchA = ""
    If myBCHHDR.RecordNotFound Then Exit Sub

    With myBCHHDR
      If Trim(._STATS) = "P" Then
        MsgBox("This process will automatically determine what needs to be done to finish the batch posting", MsgBoxStyle.Exclamation, "Batch has partially posted. Batch recovery will start.")
        WrkRecovery = True
      Else
        ._STATS = "P"
        .UpdateOneRecordP()
      End If
      BchRecDte = ._PSDT
      If ._STRDT > 0 Then
        BchIntDte = ._STRDT
      Else
        BchIntDte = BchRecDte
      End If
      BchSubst = Trim(._SUBST)
    End With

    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Posting Batch"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkTXGL = GetGNET("TXGL")
    Counter = 0

    myTCRBCH.OpenFile()
    myTCRBCHL1.SetRange(BatchNo)

    Do While Not myTCRBCHL1.IsEOF
      Counter = Counter + 1
      myTCRBCHL1.ReadFileE()
      With myTCRBCHL1
        If .IsEOF Then Exit Do
        BchSrc = ._SRC
        BchPmeth = ._PMETH
        BchListNo = ._LISTNo
        BchYear = ._YEAR
        BchType = ._TYPE
        BchPamt = ._PAMT
        BchIamt = ._IAMT
        BchLamt = ._LAMT
        BchPCamt = ._PCAMT
        BchAdjcd = ._ADJ
        WrkPaid = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
        BchCash = 0
        BchCheck = 0
        BchCredit = 0
        Select Case Trim(._PMETH)
          Case "2"
            BchCheck = WrkPaid
          Case "3"
            BchCredit = WrkPaid
          Case Else
            BchCheck = WrkPaid
        End Select
        BchComm = Trim(._COMM)
        BchSeqNo = ._TRNBR
        BchDist = ._DIST
        BchRef = Trim(._REF)
        If ._RDTE > 0 Then
          WrkPostDBDate = ._RDTE
        Else
          WrkPostDBDate = BchRecDte
        End If
        WrkFee(0) = ._PCAMT1
        WrkFee(1) = ._PCAMT2
        WrkFee(2) = ._PCAMT3
        WrkFee(3) = ._PCAMT4
        WrkFee(4) = ._PCAMT5
        WrkFee(5) = ._PCAMT6
        WrkFee(6) = ._PCAMT7
        WrkFeeCd(0) = ._PENCD1
        WrkFeeCd(1) = ._PENCD2
        WrkFeeCd(2) = ._PENCD3
        WrkFeeCd(3) = ._PENCD4
        WrkFeeCd(4) = ._PENCD5
        WrkFeeCd(5) = ._PENCD6
        WrkFeeCd(6) = ._PENCD7
      End With

      WrkPosted = False
      If WrkRecovery And Not WrkRecoveryNormal Then
        myTXHSTL1.SetRange(BchListNo, BchYear, BchType, WrkPostDBDate, True)
        Do While Not myTXHSTL1.IsEOF
          myTXHSTL1.ReadFileE()
          If myTXHSTL1.IsEOF Then Exit Do
          If myTXHSTL1._BATCHN = BatchNo Then
            WrkPosted = True
            WrkRecoverySeq = myTCRBCHL1._TRNBR
            myTXHSTL1.CloseRange()
            Exit Do
          End If
        Loop
        'If not posted then rest of batch can be posted normally 
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

      If WrkPosted Then GoTo SkipHst
      myTXINV.GetOneRecordP(BchListNo, BchYear, BchType)
      With myTXINV
        WrkWhere = "where list#=" & ._LISTNo & " and type='" & ._TYPE & "' and year=" & ._YEAR
        WrkInvFee(0) = ._FED1
        WrkInvFee(1) = ._FED2
        WrkInvFee(2) = ._FED3
        WrkInvFee(3) = ._FED4
        WrkInvFee(4) = ._FED5
        WrkInvFeeCd(0) = ._FEC1
        WrkInvFeeCd(1) = ._FEC2
        WrkInvFeeCd(2) = ._FEC3
        WrkInvFeeCd(3) = ._FEC4
        WrkInvFeeCd(4) = ._FEC5
        ._PRINT = 0
        WrkSet = "[print]=" & ._PRINT
        If ._PRLIN <> 0 Then
          ._PRLIN = ._PRLIN - BchLamt
          WrkSet = WrkSet & ",prlin=" & ._PRLIN
        End If
        If ._CCNO > 0 Then
          WrkAdjTax = ._CCETAX
        Else
          WrkAdjTax = ._TAXT
        End If
        If ._MVFLAG = "Y" Or ._MVFLAG = "M" Then
          For I = 0 To 6
            If WrkFee(I) > 0 And WrkFeeCd(I) = "MV" Then
              ._MVFLAG = "P"
              WrkSet = WrkSet & ",mvflag='" & Trim(._MVFLAG) & "'"
            End If
          Next
        End If
        If BchLamt < 0 Then
          ._LIEN = "L"
        End If
        If ._TXIDT < WrkPostDBDate Then
          ._TXIDT = WrkPostDBDate
          WrkSet = WrkSet & ",txidt=" & ._TXIDT
        End If
        'Interest Paid is used for AS/400 program compatibility only
        ._INTPD = ._INTPD + BchIamt
        WrkSet = WrkSet & ",intpd=" & ._INTPD
        ._PAYREC = ._PAYREC + BchPamt
        WrkSet = WrkSet & ",payrec=" & ._PAYREC
        ._BALD = ._BALD - BchPamt
        WrkSet = WrkSet & ",bald=" & ._BALD
        WrkBald = ._BALD
        ._LNPD = ._LNPD + BchLamt
        WrkSet = WrkSet & ",lnpd=" & ._LNPD
        If ._LNPD > 0 Then
          myTXPROF.GetOneRecordP(BchType, BchYear, "", 0)
          If ._LNPD >= myTXPROF._PRLIEN And WrkBald <= 0 Then
            ._LIEN = ""
          End If
        End If
        WrkSet = WrkSet & ",lien='" & Trim(._LIEN) & "'"
        If BchPCamt > 0 Then
          With myTCRBCHL1
            For J = 0 To 4
              If ._PCAMT1 > 0 And ._PENCD1 = WrkInvFeeCd(J) Then
                If WrkInvFee(J) <= ._PCAMT1 Then
                  WrkInvFee(J) = 0
                  WrkInvFeeCd(J) = ""
                Else
                  WrkInvFee(J) = WrkInvFee(J) - ._PCAMT1
                End If
              End If
              If ._PCAMT2 > 0 And ._PENCD2 = WrkInvFeeCd(J) Then
                If WrkInvFee(J) <= ._PCAMT2 Then
                  WrkInvFee(J) = 0
                  WrkInvFeeCd(J) = ""
                Else
                  WrkInvFee(J) = WrkInvFee(J) - ._PCAMT2
                End If
              End If
              If ._PCAMT3 > 0 And ._PENCD3 = WrkInvFeeCd(J) Then
                If WrkInvFee(J) <= ._PCAMT3 Then
                  WrkInvFee(J) = 0
                  WrkInvFeeCd(J) = ""
                Else
                  WrkInvFee(J) = WrkInvFee(J) - ._PCAMT3
                End If
              End If
              If ._PCAMT4 > 0 And ._PENCD4 = WrkInvFeeCd(J) Then
                If WrkInvFee(J) <= ._PCAMT4 Then
                  WrkInvFee(J) = 0
                  WrkInvFeeCd(J) = ""
                Else
                  WrkInvFee(J) = WrkInvFee(J) - ._PCAMT4
                End If
              End If
              If ._PCAMT5 > 0 And ._PENCD5 = WrkInvFeeCd(J) Then
                If WrkInvFee(J) <= ._PCAMT5 Then
                  WrkInvFee(J) = 0
                  WrkInvFeeCd(J) = ""
                Else
                  WrkInvFee(J) = WrkInvFee(J) - ._PCAMT5
                End If
              End If
              If ._PCAMT6 > 0 And ._PENCD6 = WrkInvFeeCd(J) Then
                If WrkInvFee(J) <= ._PCAMT6 Then
                  WrkInvFee(J) = 0
                  WrkInvFeeCd(J) = ""
                Else
                  WrkInvFee(J) = WrkInvFee(J) - ._PCAMT6
                End If
              End If
            Next
          End With
        End If
        ._FED1 = WrkInvFee(0)
        ._FED2 = WrkInvFee(1)
        ._FED3 = WrkInvFee(2)
        ._FED4 = WrkInvFee(3)
        ._FED5 = WrkInvFee(4)
        WrkSet = WrkSet & ",fed1=" & ._FED1
        WrkSet = WrkSet & ",fed2=" & ._FED2
        WrkSet = WrkSet & ",fed3=" & ._FED3
        WrkSet = WrkSet & ",fed4=" & ._FED4
        WrkSet = WrkSet & ",fed5=" & ._FED5
        ._FEC1 = WrkInvFeeCd(0)
        ._FEC2 = WrkInvFeeCd(1)
        ._FEC3 = WrkInvFeeCd(2)
        ._FEC4 = WrkInvFeeCd(3)
        ._FEC5 = WrkInvFeeCd(4)
        WrkSet = WrkSet & ",fec1='" & Trim(._FEC1) & "'"
        WrkSet = WrkSet & ",fec2='" & Trim(._FEC2) & "'"
        WrkSet = WrkSet & ",fec3='" & Trim(._FEC3) & "'"
        WrkSet = WrkSet & ",fec4='" & Trim(._FEC4) & "'"
        WrkSet = WrkSet & ",fec5='" & Trim(._FEC5) & "'"
        '        WrkBondDue = ._BOND - ._BONT - ._BONDP
        If myTCRBCHL1._PENCD1 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT1
        End If
        If myTCRBCHL1._PENCD2 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT2
        End If
        If myTCRBCHL1._PENCD3 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT3
        End If
        If myTCRBCHL1._PENCD4 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT4
        End If
        If myTCRBCHL1._PENCD5 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT5
        End If
        If myTCRBCHL1._PENCD6 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT6
        End If
        If myTCRBCHL1._PENCD7 = "BI" Then
          ._BONDP = ._BONDP + myTCRBCHL1._PCAMT7
        End If
        If ._BONDP > ._BOND Then
          ._BONDP = ._BOND
        End If
        WrkSet = WrkSet & ",bondp=" & ._BONDP
        If ._ICODE = "S" Then
          WrkSuspense = True
        Else
          WrkSuspense = False
        End If
      End With

      If IsNothing(ErrorMsg(0)) Then
        WrkSet = "set " & WrkSet
        myTXINV.RunUpdateQuery(WrkSet, WrkWhere)
        'myTXINV.UpdateOneRecordP()
        'If myTXINV.ErrMsg <> "" Then
        ' WriteErrorLog(myTXINV.ErrMsg)
        'Exit Sub
        'End If
      Else
        Exit Sub
      End If

      If Trim(myTXINV._IMVREG) = "" Then
        'Check next year for back tax code
        myTXINV_NY.GetOneRecordP(BchListNo, BchYear + 1, BchType)
        If Not myTXINV_NY.RecordNotFound And WrkBald = 0 Then
          With myTXINV_NY
            If ._ICODE = "B" Then
              ._ICODE = ""
              WrkWhere = "where list#=" & BchListNo & " and type='" & BchType & "' and year=" & (BchYear + 1)
              WrkSet = "set icode='" & Trim(._ICODE) & "'"
              myTXINV.RunUpdateQuery(WrkSet, WrkWhere)
              'If IsNothing(ErrorMsg(0)) Then
              '  myTXINV.UpdateOneRecordP()
              'End If
            End If
          End With
        End If
      Else
        'Check by regno for back tax code
        'GetTXINVRegNo(Trim(myTXINV._IMVREG))
        'Check by Custid for back tax code
        UpdateTXINV_MV(myTXINV._SSNo)
      End If

SkipInv:
      WrkFirstTime = True
      J = 0
      'Move fees to lowest array positions
      For I = 0 To 6
        If WrkFee(I) <> 0 Then
          If I <> J Then
            WrkFee(J) = WrkFee(I)
            WrkFeeCd(J) = WrkFeeCd(I)
            WrkFee(I) = 0
            WrkFeeCd(I) = String.Empty
          End If
          J = J + 1
        End If
      Next

      For I = 0 To 6
        If Not WrkFirstTime And WrkFee(I) = 0 Then Exit For
        With myTXHST
          .ClearFields()
          WrkRecID = .AutoGenKey()
          '.GetOneRecordP(WrkRecID)
          ._RECID = WrkRecID
          If WrkSuspense Then
            ._RCODE = "S"
          Else
            ._RCODE = ""
          End If
          ._LISTNO = BchListNo
          ._YEAR = BchYear
          ._TYPE = BchType
          If WrkFirstTime Then
            ._PAMT = BchPamt
            ._IAMT = BchIamt
            ._LAMT = BchLamt
            ._CASH = BchCash
            ._CHECK = BchCheck
            ._CREDIT = BchCredit
          Else
            ._PAMT = 0
            ._IAMT = 0
            ._LAMT = 0
            ._CASH = 0
            ._CHECK = 0
            ._CREDIT = 0
          End If
          ._PCAMT = WrkFee(I)
          ._PENCD = WrkFeeCd(I)
          ._ADJCD = BchAdjcd
          ._DIST = BchDist
          ._REF = BchRef
          ._COMM = Replace(BchComm, "'", "''")
          ._CORC = BchPmeth
          ._BATCHN = BatchNo
          WrkBatchA = BchSubst
          'if not PC batch then use As/400 batch source code
          If WrkBatchA = String.Empty Then
            Select Case BchSrc
              Case 2
                WrkBatchA = "B"
              Case 3
                WrkBatchA = "E"
              Case 4
                WrkBatchA = "K"
              Case 5
                WrkBatchA = "W"
              Case Else
                WrkBatchA = ""
            End Select
          End If
          ._BATCHA = WrkBatchA
          ._BATCHS = BchSeqNo
          ._PDATE = WrkPostDBDate
          ._CDATE = BchIntDte
          ._THINPD = ""
          If WrkFirstTime And BchPamt = 0 And BchIamt > 0 Then
            ._THINPD = "Y"
          End If
          ._PRF = Mid(MyUserID, 1, 10)
          ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
          ._CHTIME = MyUtils.SetDBTime(Date.Now)
          '.AddOneRecordP()
          .InsertOneRecordP()
          If .ErrMsg <> "" Then
            WriteErrorLog(.ErrMsg)
            Exit Sub
          End If
        End With
        WrkFirstTime = False
      Next
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

    'Post G/L interface
    If WrkTXGL Then
      PstGL(BatchNo, WrkBatchA)
    Else
      If myTOWN._TOWNBR = 156 Then 'West Haven
        PstGL(BatchNo, WrkBatchA)
      End If
    End If

    myTCRBCH.DeleteBatch(BatchNo)
    myBCHHDR.DeleteOneRecordP()

Cleanup:
    'Memory Cleanup
    myBCHHDR = Nothing
    myTCRBCH = Nothing
    myTXINV = Nothing
    myTXHST = Nothing
    myTXPROF = Nothing
    If WrkRecovery Then
      MsgBox("Verify both Sequence " & WrkRecoverySeq & " and the next one for balance error or missing history. Contact hotline to adjust as needed", MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
    End If

  End Sub
  Private Sub GetTXINVRegNo(ByVal RegNo As String)
    Dim I As Integer
    Dim FirstOne As Boolean
    Dim SaveYear As Integer

    SaveYear = 0
    ds = myTXINVLC.GetAllRegNo(RegNo, 999, False)
    If ds.Tables(0).Rows.Count = 0 Then Exit Sub

    FirstOne = True
    For I = 0 To ds.Tables(0).Rows.Count - 1
      With ds.Tables(0).Rows(I)
        If SaveYear > 0 And .Item("year") > SaveYear Then Continue For
        myTXINV.GetOneRecordP(.Item("list#"), .Item("year"), .Item("type"))
      End With
      With myTXINV
        If ._BALD <= 0 Then
          If ._ICODE = "B" Then
            ._ICODE = ""
            .UpdateOneRecordP()
          End If
          GoTo NextInv
        End If
        If FirstOne Then
          SaveYear = ._YEAR
          FirstOne = False
        End If
        If ._ICODE = "B" Then
          ._ICODE = ""
          .UpdateOneRecordP()
        End If
      End With
NextInv:
    Next
  End Sub
  Private Sub UpdateTXINV_MV(ByVal CustID As Long)
    Dim I As Integer
    Dim dr2 As DataRow
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim WrkFirstYear As Integer
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Listno", Type.GetType("System.Int32"))
    End With

    ds2.Tables.Add(myTable)
    WrkFirstYear = 0
    ds3 = myTXINVLM.GetAllSSNo(CustID, 5000, False)
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      If ds3.Tables(0).Rows(I).Item("wbal") > 0 Then
        If ds3.Tables(0).Rows(I).Item("year") Then
          If WrkFirstYear = 0 Or ds3.Tables(0).Rows(I).Item("year") <= WrkFirstYear Then
            WrkFirstYear = ds3.Tables(0).Rows(I).Item("year")
            dr2 = ds2.Tables(0).NewRow
            dr2.Item("year") = ds3.Tables(0).Rows(I).Item("year")
            dr2.Item("type") = ds3.Tables(0).Rows(I).Item("type")
            dr2.Item("listno") = ds3.Tables(0).Rows(I).Item("list#")
            ds2.Tables(0).Rows.Add(dr2)
          End If
        End If
      End If
    Next
    ds3 = myTXINVLN.GetAllSS2(CustID, 5000, False)
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      If ds3.Tables(0).Rows(I).Item("wbal") > 0 Then
        If ds3.Tables(0).Rows(I).Item("year") Then
          If WrkFirstYear = 0 Or ds3.Tables(0).Rows(I).Item("year") <= WrkFirstYear Then
            WrkFirstYear = ds3.Tables(0).Rows(I).Item("year")
            dr2 = ds2.Tables(0).NewRow
            dr2.Item("year") = ds3.Tables(0).Rows(I).Item("year")
            dr2.Item("type") = ds3.Tables(0).Rows(I).Item("type")
            dr2.Item("listno") = ds3.Tables(0).Rows(I).Item("list#")
            ds2.Tables(0).Rows.Add(dr2)
          End If
        End If
      End If
    Next

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If WrkFirstYear = .Item("year") Then
          myTXINV.GetOneRecordP(.Item("listno"), .Item("year"), .Item("type"))
          With myTXINV
            If Trim(._ICODE) = "B" Then
              ._ICODE = ""
              .UpdateOneRecordP()
            End If
          End With
        End If
      End With
    Next
  End Sub
End Module






