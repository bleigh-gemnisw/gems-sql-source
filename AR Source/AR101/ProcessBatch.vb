Module ProcessBatch
  Dim myCSHBCH As CSHBCH.MyData
  Dim myBCHHDR As BCHHDR.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim myFrmProgress As FrmProgress
  'General
  Dim FundCtl(100) As Integer
  Dim FundCtlDate(100) As Integer
  Dim FundCtlAmt(100) As Decimal
  Dim FundCtlRev(100) As Decimal
  Dim FundCtlExp(100) As Decimal
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim WrkError As Boolean
  Const cSrcde As String = "3"
  Public Sub ProcBatch(ByVal BatchNo As Integer, ByVal Post As Boolean)
    Dim WrkRecovery As Boolean
    Dim WrkRecoveryNormal As Boolean
    Dim Answer As Integer
    With MyFrmAR101
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    myCSHBCH = New CSHBCH.MyData()
    myCSHBCH.MyDBConn = myDBConnect
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect

    WrkError = False
    If Post Then
      myBCHHDR.GetOneRecordP(MyBatch, BatchNo)
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
    End If

    myCSHBCH.SetRange(BatchNo)
    If ds.Tables.Count = 0 Then
      BuildPrtDS()
    Else
      ds.Clear()
      ds2.Clear()
    End If
    WriteDS(BatchNo, Post)
    myCSHBCH.GetOneRecordP(BatchNo, 0)

    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.Wrkds2 = ds2
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.WrkError = WrkError
    MyFrmCr_PrtEdits.ShowDialog()

    If WrkError Then
      MsgBox("Correct and repost", MsgBoxStyle.Exclamation, "Errors found in batch")
    Else
      If Post Then
        Answer = MsgBox("Reports cannot be rerun once batch has posted. Continue with Posting?", MsgBoxStyle.YesNo, "Report print confirmation")
        If Answer = vbNo Then
          MsgBox("Rerun post batch", MsgBoxStyle.Exclamation, "Posting has been aborted")
        Else
          WriteLedger(BatchNo)
          myCSHBCH.DeleteBatch(BatchNo)
          myBCHHDR.DeleteOneRecordP()
          MsgBox("Completed normally", MsgBoxStyle.Information, BatchNo & " - Batch has been posted")
        End If
      End If
    End If
    With MyFrmAR101
      .TBarDelete.Enabled = True
      .TBarPost.Enabled = True
      .TBarPrtEdits.Enabled = True
    End With
    'Memory Cleanup
    myCSHBCH = Nothing
  End Sub
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      'Report 
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("Recno", Type.GetType("System.Int32"))
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("TrnTyp", Type.GetType("System.String"))
      .Columns.Add("GLTyp", Type.GetType("System.String"))
      .Columns.Add("WrkDate", Type.GetType("System.DateTime"))
      .Columns.Add("TrnDt", Type.GetType("System.Int32"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDescr", Type.GetType("System.String"))
      .Columns.Add("RefNo", Type.GetType("System.Int32"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
      'Needed for Posting
      .Columns.Add("Fdnbr", Type.GetType("System.Int32"))
      .Columns.Add("Sfund", Type.GetType("System.Int32"))
      .Columns.Add("Dpnbr", Type.GetType("System.Int32"))
      .Columns.Add("Obnbr", Type.GetType("System.Int32"))
      .Columns.Add("Fnpgm", Type.GetType("System.Int32"))
      .Columns.Add("Subfn", Type.GetType("System.Int32"))
      .Columns.Add("TDesc", Type.GetType("System.String"))
      .Columns.Add("Fil10", Type.GetType("System.Int64"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Sub WriteDS(ByVal BatchNo As Integer, ByVal Post As Boolean)
    Dim WrkTotCr As Decimal
    Dim WrkTotDr As Decimal
    Dim WrkAcct As String
    Dim Counter As Integer
    Dim K As Integer
    Dim dr As Data.DataRow

    myFrmProgress = New FrmProgress
    If Post Then
      myFrmProgress.Text = "Creating Posting Reports"
    Else
      myFrmProgress.Text = "Creating Edit Reports"
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkTotCr = 0
    WrkTotDr = 0
    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlDate, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)
    Array.Clear(FundCtlRev, 0, 100)
    Array.Clear(FundCtlExp, 0, 100)

    Do While Not myCSHBCH.IsEOF
      myCSHBCH.ReadFileE()
      With myCSHBCH
        If .IsEOF Then Exit Do
        'Credit 
        Counter = Counter + 1
        myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr = ds.Tables(0).NewRow
        dr("bchno") = ._BCHNO
        dr("group") = "1"
        dr("recno") = ._RECNO
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "X"
        dr("wrkdate") = MyUtils.GetDBDate(._TRNDT)
        dr("trndt") = ._TRNDT
        dr("credit") = ._AMTCS
        dr("debit") = 0
        WrkTotCr = WrkTotCr + ._AMTCS
        dr("descr") = ._DSCTX
        WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr("acct") = WrkAcct
        If Not myGLACCT.RecordNotFound Then
          dr("acctdescr") = myGLACCT._GLDSC
        Else
          dr("acctdescr") = "*** Invalid Account ***"
          WrkError = True
        End If
        dr("refno") = ._REFNO
        If Not myGLACCT.RecordNotFound Then
          dr("errmsg") = String.Empty
        Else
          dr("errmsg") = "*** Invalid Account ***"
        End If
        K = LookupFundCtl(._FDNBR, ._TRNDT)
        If ._FDNBD = 0 Then
          FundCtl(K) = ._FDNBR
          FundCtlDate(K) = ._TRNDT
          FundCtlAmt(K) = FundCtlAmt(K) + ._AMTCS
        End If
        'Revenue Control
        If myGLACCT._GLTYP = "R" Then
          FundCtl(K) = ._FDNBR
          FundCtlDate(K) = ._TRNDT
          FundCtlRev(K) = FundCtlRev(K) + ._AMTCS
        End If
        'Expenditure Control
        If myGLACCT._GLTYP = "X" Then
          FundCtl(K) = ._FDNBR
          FundCtlDate(K) = ._TRNDT
          FundCtlExp(K) = FundCtlExp(K) + ._AMTCS
        End If
        'Needed for Posting
        dr("fdnbr") = ._FDNBR
        dr("sfund") = ._SFUND
        dr("dpnbr") = ._DPNBR
        dr("obnbr") = ._OBNBR
        dr("fnpgm") = ._FNPGM
        dr("subfn") = ._SUBFN
        dr("tdesc") = dr("descr")
        dr("fil10") = 0
        ds.Tables(0).Rows.Add(dr)

        'Debit 
        If ._FDNBD > 0 Then
          myGLACCT.GetOneRecordP(._FDNBD, ._SFUDD, ._DPNBD, ._OBNBD, ._FNPGD, ._SUBFD)
          dr = ds.Tables(0).NewRow
          dr("bchno") = ._BCHNO
          dr("group") = "1"
          dr("recno") = ._RECNO
          dr("gltyp") = myGLACCT._GLTYP
          dr("trntyp") = "X"
          dr("wrkdate") = MyUtils.GetDBDate(._TRNDT)
          dr("trndt") = ._TRNDT
          dr("credit") = 0
          dr("debit") = ._AMTCS
          WrkTotDr = WrkTotDr + ._AMTCS
          dr("descr") = ._DSCTX
          WrkAcct = BuildAcct(._FDNBD, ._SFUDD, ._DPNBD, ._OBNBD, ._FNPGD, ._SUBFD)
          dr("acct") = WrkAcct
          If Not myGLACCT.RecordNotFound Then
            dr("acctdescr") = myGLACCT._GLDSC
          Else
            dr("acctdescr") = "*** Invalid Account ***"
            WrkError = True
          End If
          dr("refno") = ._REFNO
          If Not myGLACCT.RecordNotFound Then
            dr("errmsg") = String.Empty
          Else
            dr("errmsg") = "*** Invalid Account ***"
          End If
          'Needed for Posting
          dr("fdnbr") = ._FDNBD
          dr("sfund") = ._SFUDD
          dr("dpnbr") = ._DPNBD
          dr("obnbr") = ._OBNBD
          dr("fnpgm") = ._FNPGD
          dr("subfn") = ._SUBFD
          dr("tdesc") = dr("descr")
          dr("fil10") = 0
          ds.Tables(0).Rows.Add(dr)
        End If

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
      End With
    Loop

    ds2 = ds.Copy
    'Cash
    For I = 0 To FundCtl.GetUpperBound(0)
      myGLFUND.GetOneRecordP(FundCtl(I), 0)
      With myGLFUND
        myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
      End With
      If FundCtlAmt(I) <> 0 Then
        With myCSHBCH
          dr = ds2.Tables(0).NewRow
          dr("bchno") = ._BCHNO
          dr("group") = "2"
          dr("recno") = 0
          dr("gltyp") = myGLACCT._GLTYP
          dr("trntyp") = "X"
          dr("wrkdate") = MyUtils.GetDBDate(FundCtlDate(I))
          dr("trndt") = FundCtlDate(I)
          If FundCtlAmt(I) > 0 Then
            dr("credit") = 0
            dr("debit") = Math.Abs(FundCtlAmt(I))
          Else
            dr("credit") = FundCtlAmt(I)
            dr("debit") = 0
          End If
          dr("descr") = String.Empty
          WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDC, myGLFUND._DPNBRC, myGLFUND._OBNBRC,
      myGLFUND._FNPGMC, myGLFUND._SUBFNC)
          dr("acct") = WrkAcct
          dr("acctdescr") = myGLACCT._GLDSC
          dr("refno") = 0
          dr("errmsg") = String.Empty
          'Needed for Posting
          dr("fdnbr") = FundCtl(I)
          dr("sfund") = myGLFUND._SFUNDC
          dr("dpnbr") = myGLFUND._DPNBRC
          dr("obnbr") = myGLFUND._OBNBRC
          dr("fnpgm") = myGLFUND._FNPGMC
          dr("subfn") = myGLFUND._SUBFNC
          dr("tdesc") = "AR Batch " & ._BCHNO
          dr("fil10") = 0
          ds2.Tables(0).Rows.Add(dr)
        End With
      End If

      'Revenue Control
      If FundCtlRev(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
        End With
        With myCSHBCH
          dr = ds2.Tables(0).NewRow
          dr("bchno") = ._BCHNO
          dr("group") = "2"
          dr("recno") = 0
          dr("gltyp") = myGLACCT._GLTYP
          dr("trntyp") = "X"
          dr("wrkdate") = MyUtils.GetDBDate(FundCtlDate(I))
          dr("trndt") = FundCtlDate(I)
          If FundCtlRev(I) > 0 Then
            dr("credit") = FundCtlRev(I)
            dr("debit") = 0
          Else
            dr("credit") = 0
            dr("debit") = Math.Abs(FundCtlRev(I))
          End If
          dr("descr") = String.Empty
          WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND1, myGLFUND._DPNBR1, myGLFUND._OBNBR1,
          myGLFUND._FNPGM1, myGLFUND._SUBFN1)
          dr("acct") = WrkAcct
          dr("acctdescr") = myGLACCT._GLDSC
          dr("refno") = 0
          dr("errmsg") = String.Empty
          'Needed for Posting
          dr("fdnbr") = FundCtl(I)
          dr("sfund") = myGLFUND._SFUND1
          dr("dpnbr") = myGLFUND._DPNBR1
          dr("obnbr") = myGLFUND._OBNBR1
          dr("fnpgm") = myGLFUND._FNPGM1
          dr("subfn") = myGLFUND._SUBFN1
          dr("tdesc") = "AR Batch " & ._BCHNO
          dr("fil10") = "9999999999"
          ds2.Tables(0).Rows.Add(dr)
        End With
      End If

      'Expenditure Control
      If FundCtlExp(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
        End With
        With myCSHBCH
          dr = ds2.Tables(0).NewRow
          dr("bchno") = ._BCHNO
          dr("group") = "2"
          dr("recno") = 0
          dr("gltyp") = myGLACCT._GLTYP
          dr("trntyp") = "X"
          dr("wrkdate") = MyUtils.GetDBDate(FundCtlDate(I))
          dr("trndt") = FundCtlDate(I)
          If FundCtlExp(I) > 0 Then
            dr("credit") = FundCtlExp(I)
            dr("debit") = 0
          Else
            dr("credit") = 0
            dr("debit") = Math.Abs(FundCtlExp(I))
          End If
          dr("descr") = String.Empty
          WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND2, myGLFUND._DPNBR2, myGLFUND._OBNBR2,
          myGLFUND._FNPGM2, myGLFUND._SUBFN2)
          dr("acct") = WrkAcct
          dr("acctdescr") = myGLACCT._GLDSC
          dr("refno") = 0
          dr("errmsg") = String.Empty
          'Needed for Posting
          dr("fdnbr") = FundCtl(I)
          dr("sfund") = myGLFUND._SFUND2
          dr("dpnbr") = myGLFUND._DPNBR2
          dr("obnbr") = myGLFUND._OBNBR2
          dr("fnpgm") = myGLFUND._FNPGM2
          dr("subfn") = myGLFUND._SUBFN2
          dr("tdesc") = "AR Batch " & ._BCHNO
          dr("fil10") = "9999999999"
          ds2.Tables(0).Rows.Add(dr)
        End With
      End If
    Next

    myFrmProgress.Close()
    Application.DoEvents()
    myCSHBCH.CloseFile()
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
  Private Sub WriteLedger(ByVal WrkBatchNo As Integer)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With myLEDGER
        If ds2.Tables(0).Rows(I).Item("credit") <> 0 Then
          ._AMTYP = "C"
          ._TRAMT = ds2.Tables(0).Rows(I).Item("credit")
        Else
          ._AMTYP = "D"
          ._TRAMT = ds2.Tables(0).Rows(I).Item("debit")
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = WrkBatchNo
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = ds2.Tables(0).Rows(I).Item("dpnbr")
        ._FDNBR = ds2.Tables(0).Rows(I).Item("fdnbr")
        ._FIL10 = ds2.Tables(0).Rows(I).Item("fil10")
        ._FNPGM = ds2.Tables(0).Rows(I).Item("fnpgm")
        ._FSCYR = 0
        ._GLPST = String.Empty
        ._GLTYP = ds2.Tables(0).Rows(I).Item("gltyp")
        ._JRNSQ = ds2.Tables(0).Rows(I).Item("recno")
        ._INVNR = String.Empty
        ._OBNBR = ds2.Tables(0).Rows(I).Item("obnbr")
        ._ORIG = 0
        ._PRF = MyUserID
        ._PONBR = 0
        ._PSTDT = ds2.Tables(0).Rows(I).Item("trndt")
        ._RECLS = String.Empty
        ._REFNO = ds2.Tables(0).Rows(I).Item("refno")
        ._ROCR = String.Empty
        ._SFUND = ds2.Tables(0).Rows(I).Item("sfund")
        ._SRCDE = cSrcde
        ._SUBFN = ds2.Tables(0).Rows(I).Item("subfn")
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        ._TDESC = ds2.Tables(0).Rows(I).Item("tdesc")
        ._TRFTO = String.Empty
        ._TRNBR = 0
        ._TRTYP = ds2.Tables(0).Rows(I).Item("trntyp")
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          Application.Exit()
        End If
      End With
    Next
  End Sub
End Module
