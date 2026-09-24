Module PostBatch

  Dim myTBATCH As TBATCH.MyData
  Dim myTXBATCH As TXBATCH.MyData
  Dim myTXBATCHl1 As TXBATCHL1.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXINV_NY As TXINV.myData
  Dim myTXINVLM As TXINVLM.myData
  Dim myTXINVLN As TXINVLN.MyData
  Dim myTXHST As TXHST.MyData
  Dim myTXHSTL3 As TXHSTL3.myData
  Dim myTXPROF As TXPROF.myData

  Dim ds As DataSet = New DataSet
  Dim dsTXBATCH As DataSet = New DataSet

  Dim BchStatus As String
  Dim BchListNo As Integer
  Dim BchYear As Integer
  Dim BchType As String
  Dim BchPamt As Decimal
  Dim BchIamt As Decimal
  Dim BchLamt As Decimal
  Dim BchPcamt As Decimal
  Dim BchPencd As String
  Dim BchCash As Decimal
  Dim BchCheck As Decimal
  Dim BchCredit As Decimal
  Dim BchCorc As String
  Dim BchRef As String
  Dim BchSeqNo As Integer
  Dim BchComm As String
  Dim BchAdjCd As String
  Dim BchSimt As Decimal
  Dim BchIntYr As Integer
  Dim BchIntMo As Integer
  Dim BchIntDy As Integer
  Dim InvIcode As String
  Public Sub PstBatch()

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    Dim I As Integer
    Dim WrkRecID As Integer
    Dim WrkInterestDate As Date
    Dim WrkAdjTax As Decimal
    Dim WrkBald As Decimal
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim WrkRecoverySeq As Integer
    Dim WrkPosted As Boolean
    Dim WrkDist As Integer

    myTBATCH = New TBATCH.mydata(MyDBConnect)
    myTXBATCH = New TXBATCH.mydata(MyDBConnect)
    myTXBATCHl1 = New TXBATCHL1.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXINV_NY = New TXINV.mydata(MyDBConnect)
    myTXINVLM = New TXINVLM.mydata(MyDBConnect)
    myTXINVLN = New TXINVLN.mydata(MyDBConnect)
    myTXHST = New TXHST.MyData(myDBConnect)
    myTXHSTL3 = New TXHSTL3.mydata(MyDBConnect)
    myTXPROF = New TXPROF.mydata(MyDBConnect)

    myTBATCH.GetOneRecordP(MyBatch, MyBatchNo)
    WrkRecovery = False
    WrkRecoveryNormal = False
    WrkDist = 0
    If myTBATCH.RecordNotFound Then Exit Sub

    With myTBATCH
      If ._KBSTAT = "P" Then
        MsgBox("This process will automatically determine what needs to be done to finish the batch posting",
        MsgBoxStyle.Exclamation, "Batch has partially posted. Batch recovery will start.")
        WrkRecovery = True
      Else
        ._KBSTAT = "P"
        .UpdateOneRecordP()
      End If
    End With

    myTXBATCH.OpenFile()
    dsTXBATCH = myTXBATCHl1.GetViewByBatch(MyBatch, MyBatchNo, 9999)
    For I = 0 To (dsTXBATCH.Tables(0).Rows.Count - 1)
      With dsTXBATCH.Tables(0).Rows(I)
        BchStatus = .Item("jstat")
        BchListNo = .Item("list#")
        BchYear = .Item("year")
        BchType = .Item("type")
        BchPamt = .Item("pamt")
        BchIamt = .Item("iamt")
        BchLamt = .Item("lamt")
        BchPcamt = .Item("tcamt")
        BchCash = .Item("cash")
        BchCheck = .Item("check")
        BchCredit = .Item("credit")
        BchPencd = .Item("cpencd")
        BchCorc = .Item("corc")
        BchRef = .Item("refe")
        BchSeqNo = .Item("jseqno")
        BchComm = .Item("comm")
        BchAdjCd = .Item("adjcd")
        BchSimt = .Item("simt")
        BchIntYr = .Item("jiy")
        BchIntMo = .Item("jim")
        BchIntDy = .Item("jid")
      End With

      If BchStatus = "V" Then GoTo SkipInv

      WrkPosted = False
      If WrkRecovery And Not WrkRecoveryNormal Then
        myTXHSTL3.SetRange(BchListNo, BchYear, BchType, MyUtils.SetDBDate(MyReceiptDate))
        Do While Not myTXHSTL3.IsEOF
          myTXHSTL3.ReadFileE()
          If myTXHSTL3.IsEOF Or myTXHSTL3._PDATE < MyUtils.SetDBDate(MyReceiptDate) Then Exit Do
          If myTXHSTL3._BATCHN = MyBatchNo Then
            WrkPosted = True
            WrkRecoverySeq = dsTXBATCH.Tables(0).Rows(I).Item("jseqno")
            Exit Do
          End If
        Loop
        'If not posted then rest of batch can be posted normally 
        If Not WrkPosted Then WrkRecoveryNormal = True
      End If

      If WrkPosted Then GoTo SkipHst
      myTXINV.GetOneRecordP(BchListNo, BchYear, BchType)
      With myTXINV
        WrkDist = ._DIST
        InvIcode = ._ICODE
        If ._PRLIN <> 0 Then
          ._PRLIN = ._PRLIN - BchLamt
        End If
        ._PRINT = 0
        If BchAdjCd = "R" Then
          ._RPD = ._RPD + BchPamt
        End If
        If MyReceiptDate <> MyUtils.GetDBDate(._TXIDT) Then
          ._TXIDT = MyUtils.SetDBDate(MyReceiptDate)
        End If
        If ._CCNO > 0 Then
          WrkAdjTax = ._CCETAX
        Else
          WrkAdjTax = ._TAXT
        End If
        ._PAYREC = ._PAYREC + BchPamt
        ._NEWPAY = ._NEWPAY - BchPamt
        ._BALD = WrkAdjTax - ._PAYREC
        WrkBald = ._BALD
        ._LNPD = ._LNPD + BchLamt
        If ._BALD <= 0 And ._ICODE = "B" Then
          ._ICODE = String.Empty
        End If
        If ._LNPD > 0 Then
          myTXPROF.GetOneRecordP(BchType, BchYear, String.Empty, 0)
          If ._LNPD >= myTXPROF._PRLIEN And ._BALD <= 0 Then
            ._LIEN = String.Empty
          End If
        End If
        If BchLamt < 0 Then
          ._LIEN = "L"
        End If
        If BchPencd = "BI" Then 'Bond Interest
          ._BONDP = ._BONDP + BchPcamt
          If ._BONT > 0 Then
            ._BONT = ._BONT - BchPcamt
          End If
          If ._BONT < 0 Then
            ._BONT = 0
          End If
        End If
        'Interest Paid is used for AS/400 program compatibility only
        If BchAdjCd = String.Empty Then
          ._INTPD = ._INTPD + BchIamt
        Else
          ._INTPD = ._INTPD + BchIamt
          If ._INTPD < 0 Then
            ._INTPD = 0
          End If
        End If
        'If a regular Fee is paid then clear or reduce it (not MV or Bond)
        If BchPcamt > 0 And BchPencd <> "BI" And BchPencd <> "MV" Then
          If BchPencd = Trim(._FEC1) Then
            If BchPamt >= ._FED1 Then
              ._FEC1 = String.Empty
              ._FED1 = 0
            Else
              ._FED1 = ._FED1 - BchPcamt
            End If
          End If
          If BchPencd = Trim(._FEC2) Then
            If BchPamt >= ._FED2 Then
              ._FEC2 = String.Empty
              ._FED2 = 0
            Else
              ._FED2 = ._FED2 - BchPcamt
            End If
          End If
          If BchPencd = Trim(._FEC3) Then
            If BchPamt >= ._FED3 Then
              ._FEC3 = String.Empty
              ._FED3 = 0
            Else
              ._FED3 = ._FED3 - BchPcamt
            End If
          End If
          If BchPencd = Trim(._FEC4) Then
            If BchPamt >= ._FED4 Then
              ._FEC4 = String.Empty
              ._FED4 = 0
            Else
              ._FED4 = ._FED4 - BchPcamt
            End If
          End If
          If BchPencd = Trim(._FEC5) Then
            If BchPamt >= ._FED5 Then
              ._FEC5 = String.Empty
              ._FED5 = 0
            Else
              ._FED5 = ._FED5 - BchPcamt
            End If
          End If
        End If
        'If a MV Fee is paid then change MVFlag to P (Paid)
        If BchPcamt > 0 And BchPencd = "MV" Then
          ._MVFLAG = "P"
        End If
      End With
      myTXINV.UpdateOneRecordP()
      If myTXINV.ErrMsg <> "" Then
        WriteErrorLog(myTXINV.ErrMsg)
        Exit Sub
      End If

      If Trim(myTXINV._IMVREG) = "" Then
        'Check next year for back tax code
        myTXINV_NY.GetOneRecordP(BchListNo, BchYear + 1, BchType)
        If Not myTXINV_NY.RecordNotFound And WrkBald <= 0 Then
          With myTXINV_NY
            If Trim(._ICODE) = "B" Then
              ._ICODE = String.Empty
              .UpdateOneRecordP()
            End If
          End With
        End If
      Else
        'Check for back tax code
        UpdateTXINV_MV(myTXINV._SSNo)
      End If

SkipInv:
      With myTXHST
        WrkRecID = .AutoGenKey
        .GetOneRecordP(WrkRecID)
        ._RECID = WrkRecID
        ._RCODE = String.Empty
        If InvIcode = "S" Then
          ._RCODE = "S"
        End If
        If BchStatus = "V" Then
          ._RCODE = "V"
        End If
        ._LISTNO = BchListNo
        ._YEAR = BchYear
        ._TYPE = BchType
        ._PAMT = BchPamt
        ._IAMT = BchIamt
        ._LAMT = BchLamt
        ._PCAMT = BchPcamt
        ._PENCD = BchPencd
        ._CASH = BchCash
        ._CHECK = BchCheck
        ._CREDIT = BchCredit
        ._CORC = BchCorc
        ._DIST = WrkDist
        ._REF = BchRef
        ._COMM = BchComm
        ._ADJCD = BchAdjCd
        ._BATCHN = MyBatchNo
        ._BATCHS = BchSeqNo
        ._BATCHA = MyBatch
        ._PDATE = MyUtils.SetDBDate(MyReceiptDate)
        WrkInterestDate = "#" & BchIntMo & "/" & BchIntDy & "/" & BchIntYr & "#"
        ._CDATE = MyUtils.SetDBDate(WrkInterestDate)
        ._THINPD = String.Empty
        If BchPamt = 0 And BchIamt > 0 Then
          ._THINPD = "Y"
        End If
        ._INTOR = BchSimt
        ._PRF = Mid(MyUserID, 1, 10)
        ._CHDATE = MyUtils.SetDBDate(Date.Now.Date)
        ._CHTIME = MyUtils.SetDBTime(Date.Now)
        .AddOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Exit Sub
        End If
      End With
SkipHst:
    Next

    'Post G/L interface
    PstGL()

    myTXBATCH.DeleteBatch(MyBatch, MyBatchNo)
    myTBATCH.DeleteOneRecordP()

Cleanup:
    'Memory Cleanup
    ds.Clear()
    dsTXBATCH.Clear()

    myTXBATCH.CloseFile()
    myTBATCH.CloseFile()
    myTXINV.CloseFile()
    myTXINV_NY.CloseFile()
    myTXHST.CloseFile()
    myTXHSTL3.CloseFile()
    myTXPROF.CloseFile()

    myTBATCH = Nothing
    myTXBATCH = Nothing
    myTXINV = Nothing
    myTXINV_NY = Nothing
    myTXHST = Nothing
    myTXPROF = Nothing
    Application.DoEvents()

    If WrkRecovery Then
      MsgBox("Verify both Sequence " & WrkRecoverySeq &
      " and the next one for balance error or missing history. Contact hotline to adjust as needed",
      MsgBoxStyle.Information, "Batch recovery has finished. Proceed with manual review as instructed below.")
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    'Dim I As Integer
    'ErrProv.SetError(LblBatchNo, String.Empty)

    'For I = 0 To ErrorField.GetUpperBound(0)
    '  Select Case ErrorField(I)
    '  Case "kbtch#"
    '    ErrProv.SetError(LblBatchNo, ErrorMsg(I))
    '  Case String.Empty
    '    Exit Sub
    '  End Select
    'Next I
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
        If WrkFirstYear = 0 Or ds3.Tables(0).Rows(I).Item("year") <= WrkFirstYear Then
          WrkFirstYear = ds3.Tables(0).Rows(I).Item("year")
          dr2 = ds2.Tables(0).NewRow
          dr2.Item("year") = ds3.Tables(0).Rows(I).Item("year")
          dr2.Item("type") = ds3.Tables(0).Rows(I).Item("type")
          dr2.Item("listno") = ds3.Tables(0).Rows(I).Item("list#")
          ds2.Tables(0).Rows.Add(dr2)
        End If
      End If
    Next
    ds3 = myTXINVLN.GetAllSS2(CustID, 5000, False)
    For I = 0 To ds3.Tables(0).Rows.Count - 1
      If ds3.Tables(0).Rows(I).Item("wbal") > 0 Then
        If WrkFirstYear = 0 Or ds3.Tables(0).Rows(I).Item("year") <= WrkFirstYear Then
          WrkFirstYear = ds3.Tables(0).Rows(I).Item("year")
          dr2 = ds2.Tables(0).NewRow
          dr2.Item("year") = ds3.Tables(0).Rows(I).Item("year")
          dr2.Item("type") = ds3.Tables(0).Rows(I).Item("type")
          dr2.Item("listno") = ds3.Tables(0).Rows(I).Item("list#")
          ds2.Tables(0).Rows.Add(dr2)
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






