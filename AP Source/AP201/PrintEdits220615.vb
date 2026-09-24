Module PrintEdits
  Dim myAPEBCHQ As APEBCHQ.MyData
  Dim myAPEBCH As APEBCH.MyData
  Dim myBCHHDR As BCHHDR.MyData
  Dim myAPEBCDL1 As APEBCDL1.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myPOSUMFL1 As POSUMFL1.MyData
  Dim ds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim ds3 As DataSet = New DataSet
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim WrkError As Boolean
  Dim WrkErrorAmt As Boolean
  'General
  Dim FundCtl(100) As Integer
  Dim FundCtlAmt(100) As Decimal
  Dim FundCtlAP(100) As Decimal
  Dim FundCtlExp(100) As Decimal
  Dim FundCtlRev(100) As Decimal

  Public Function PrtEdits(ByVal BatchNo As Integer, ByVal Post As Boolean) As Boolean

    myAPEBCHQ = New APEBCHQ.MyData()
    myAPEBCHQ.MyDBConn = myDBConnect
    myAPEBCH = New APEBCH.MyData()
    myAPEBCH.MyDBConn = myDBConnect
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myAPEBCDL1 = New APEBCDL1.MyData()
    myAPEBCDL1.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myPOSUMFL1 = New POSUMFL1.MyData()
    myPOSUMFL1.MyDBConn = myDBConnect

    WrkError = False
    WrkErrorAmt = False
    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildDs2(ds2)
      BuildDs3()
    Else
      ds.Clear()
      ds2.Clear()
      ds3.Clear()
    End If
    WriteDS(BatchNo, Post)
    myAPEBCH.GetOneRecordP(BatchNo, 0)

    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.Wrkds2 = ds2
    MyFrmCr_PrtEdits.Wrkds3 = ds3
    MyFrmCr_PrtEdits.WrkBatch = BatchNo
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.WrkError = WrkError
    MyFrmCr_PrtEdits.ShowDialog()
    'Memory Cleanup
    myAPEBCH = Nothing
    Return WrkError

  End Function
  Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("Seqno", Type.GetType("System.Int32"))
      .Columns.Add("BchDate", Type.GetType("System.DateTime"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("Vsort", Type.GetType("System.String"))
      .Columns.Add("Vendor", Type.GetType("System.String"))
      .Columns.Add("Vendname", Type.GetType("System.String"))
      .Columns.Add("Vadd1", Type.GetType("System.String"))
      .Columns.Add("Vadd2", Type.GetType("System.String"))
      .Columns.Add("Vadd3", Type.GetType("System.String"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("Invamt", Type.GetType("System.Decimal"))
      .Columns.Add("Invdate", Type.GetType("System.DateTime"))
      .Columns.Add("Duedate", Type.GetType("System.DateTime"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("Partial", Type.GetType("System.String"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDs2(ByRef Ds2 As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("BchDate", Type.GetType("System.DateTime"))
      .Columns.Add("Fund", Type.GetType("System.Int32"))
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("TrNbr", Type.GetType("System.Int32"))
      .Columns.Add("TrnTyp", Type.GetType("System.String"))
      .Columns.Add("GLTyp", Type.GetType("System.String"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    Ds2.Tables.Add(myTable)
  End Sub
  Public Sub BuildDs3()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("BchDate", Type.GetType("System.DateTime"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDescr", Type.GetType("System.String"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    ds3.Tables.Add(myTable)
  End Sub
  Sub WriteDS(ByVal WrkBatch As Integer, ByVal Post As Boolean)
    Dim dsFile As DataSet = New DataSet
    Dim dsFile2 As DataSet = New DataSet
    Dim dsSum As DataSet = New DataSet
    Dim WrkAcct As String
    Dim SaveBatch As Integer
    Dim SaveDate As Date
    Dim Counter As Integer
    Dim dr As Data.DataRow
    Dim WrkDtlAmtPO As Decimal
    Dim WrkBal As Decimal
    Dim WrkPOOpn As Decimal
    Dim WrkDateFrom As Integer
    Dim WrkDateTo As Integer
    Dim WrkAnd As String
    Dim WrkOr As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim I As Integer
    Dim J As Integer
    Dim K As Integer

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "BCHNO = " & WrkBatch
    WrkSort = ""
    myAPEBCHQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    If Post Then
      myFrmProgress.Text = "Creating Posting Reports"
    Else
      myFrmProgress.Text = "Creating Edit Reports"
    End If
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveBatch = 0
    WrkDtlAmtPO = 0
    Counter = 0
    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)
    Array.Clear(FundCtlAP, 0, 100)
    Array.Clear(FundCtlExp, 0, 100)
    Array.Clear(FundCtlRev, 0, 100)

ReadNext:
    myAPEBCHQ.ReadQry()
    If Not myAPEBCHQ.IsEOF Then
      With myAPEBCHQ
        Counter = Counter + 1
        dsFile = myAPEBCDL1.GetViewbySeqno(WrkBatch, ._SEQNO, 0)
        If dsFile.Tables(0).Rows.Count = 0 Then
          dr = ds.Tables(0).NewRow
          dr("bchno") = WrkBatch
          dr("seqno") = ._SEQNO
          myBCHHDR.GetOneRecordP(MyBatch, WrkBatch)
          dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
          dr("ponbr") = ._PONBR
          dr("vsort") = myVENDOR._VSORT
          dr("vendor") = ._VNDNR
          dr("vendname") = ._VENNM
          dr("vadd1") = myVENDOR._VADD1
          dr("vadd2") = myVENDOR._VADD2
          dr("vadd3") = myVENDOR._VADD3
          dr("invno") = ._INVNO
          dr("invamt") = ._AMTNT
          dr("invdate") = MyUtils.GetDBDate(._INVD8)
          dr("duedate") = MyUtils.GetDBDate(._DUED8)
          dr("descr") = ._DSCTX
          dr("amount") = 0
          dr("partial") = ""
          dr("acct") = ""
          dr("errmsg") = "*** Invoice amount is not equal to detail ***"
          WrkError = True
          WrkErrorAmt = True
          ds.Tables(0).Rows.Add(dr)
          GoTo ReadNext
        End If

        dsFile2 = myAPEBCDL1.GetSumbyAcct(WrkBatch, ._SEQNO)
        For I = 0 To dsFile2.Tables(0).Rows.Count - 1
          myVENDOR.GetOneRecordP(._VNDNR)
          dr = ds.Tables(0).NewRow
          dr("bchno") = WrkBatch
          dr("seqno") = ._SEQNO
          myBCHHDR.GetOneRecordP(MyBatch, WrkBatch)
          dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
          dr("ponbr") = ._PONBR
          dr("vsort") = myVENDOR._VSORT
          dr("vendor") = ._VNDNR
          dr("vendname") = ._VENNM
          dr("vadd1") = myVENDOR._VADD1
          dr("vadd2") = myVENDOR._VADD2
          dr("vadd3") = myVENDOR._VADD3
          dr("invno") = ._INVNO
          dr("invamt") = ._AMTNT
          dr("invdate") = MyUtils.GetDBDate(._INVD8)
          dr("duedate") = MyUtils.GetDBDate(._DUED8)
          dr("descr") = ._DSCTX
          With dsFile2.Tables(0).Rows(I)
            myGLACCT.GetOneRecordP(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), .Item("FNPGM"), .Item("SUBFN"))
            WrkAcct = BuildAcct(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), .Item("FNPGM"), .Item("SUBFN"))
            dr("amount") = .Item("wrksum")
            WrkDtlAmtPO = WrkDtlAmtPO + .Item("wrksum")
          End With
          dr("acct") = WrkAcct
          If Not myGLACCT.RecordNotFound Then
            dr("acctdesc") = myGLACCT._GLDSC
            dr("errmsg") = String.Empty
          Else
            dr("acctdesc") = "*** Invalid Account ***"
            dr("errmsg") = "*** Invalid Account ***"
            WrkError = True
          End If
          If I = dsFile2.Tables(0).Rows.Count - 1 Then
            If ._AMTNT <> WrkDtlAmtPO Then
              dr("errmsg") = "*** Invoice amount is not equal to detail ***"
              WrkError = True
              WrkErrorAmt = True
            End If
            WrkDtlAmtPO = 0
          End If
          If Trim(._LEOPN) = "P" Then
            dr("partial") = "PARTIAL"
          Else
            dr("partial") = ""
          End If
          ds.Tables(0).Rows.Add(dr)

          K = LookupFundCtl(dsFile2.Tables(0).Rows(I).Item("FDNBR"))
          FundCtl(K) = dsFile2.Tables(0).Rows(I).Item("FDNBR")
          FundCtlAP(K) = FundCtlAP(K) + dsFile2.Tables(0).Rows(I).Item("wrksum")
          If myGLACCT._GLTYP = "X" Then
            FundCtlExp(K) = FundCtlExp(K) + dsFile2.Tables(0).Rows(I).Item("wrksum")
          End If
          If myGLACCT._GLTYP = "R" Then
            FundCtlRev(K) = FundCtlRev(K) + dsFile2.Tables(0).Rows(I).Item("wrksum")
          End If

          'Encumbrance 
          If ._PONBR > 0 And ._POLIQ = "" Then
            dr = ds2.Tables(0).NewRow
            dr("bchno") = WrkBatch
            dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
            dr("fund") = dsFile2.Tables(0).Rows(I).Item("FDNBR")
            dr("group") = "2"
            dr("gltyp") = myGLACCT._GLTYP
            dr("trntyp") = "E"
            WrkPOOpn = 0
            If ._LEOPN = "P" Then
              dr("credit") = dsFile2.Tables(0).Rows(I).Item("wrksum")
              FundCtlAmt(K) = FundCtlAmt(K) + dsFile2.Tables(0).Rows(I).Item("wrksum")
            Else
              dsSum = myPOSUMFL1.GetAllPONo(._FSCYR, ._PONBR, 0)
              For J = 0 To dsSum.Tables(0).Rows.Count - 1
                If dsSum.Tables(0).Rows(J).Item("acct") = Replace(WrkAcct, "-", "") Then
                  WrkPOOpn = WrkPOOpn + dsSum.Tables(0).Rows(J).Item("poopn")
                End If
              Next
              dr("credit") = WrkPOOpn
              FundCtlAmt(K) = FundCtlAmt(K) + WrkPOOpn
            End If
            dr("acct") = WrkAcct
            If Not myGLACCT.RecordNotFound Then
              dr("acctdesc") = myGLACCT._GLDSC
              dr("errmsg") = String.Empty
            Else
              dr("acctdesc") = "*** Invalid Account ***"
              dr("errmsg") = "*** Invalid Account ***"
              WrkError = True
            End If
            ds2.Tables(0).Rows.Add(dr)
          End If

          'Expenditure/Revenue 
          dr = ds2.Tables(0).NewRow
          dr("bchno") = WrkBatch
          dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
          dr("fund") = dsFile2.Tables(0).Rows(I).Item("FDNBR")
          dr("group") = "2"
          dr("gltyp") = myGLACCT._GLTYP
          dr("trntyp") = "X"
          With dsFile2.Tables(0).Rows(I)
            If .Item("wrksum") > 0 Then
              dr("debit") = .Item("wrksum")
            Else
              dr("credit") = Math.Abs(.Item("wrksum"))
            End If
          End With
          dr("acct") = WrkAcct
          If Not myGLACCT.RecordNotFound Then
            dr("acctdesc") = myGLACCT._GLDSC
            dr("errmsg") = String.Empty
          Else
            dr("acctdesc") = "*** Invalid Account ***"
            dr("errmsg") = "*** Invalid Account ***"
            WrkError = True
          End If
          ds2.Tables(0).Rows.Add(dr)
          SaveBatch = ._BCHNO
          SaveDate = MyUtils.GetDBDate(myBCHHDR._PSDT)
          CalcFyDates(SaveDate, WrkDateFrom, WrkDateTo)
          With dsFile2.Tables(0).Rows(I)
            WrkBal = GetAcctBal(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"),
         .Item("FNPGM"), .Item("SUBFN"), WrkDateFrom, WrkDateTo)
            WrkBal = WrkBal - .Item("wrksum")
          End With
          If WrkBal < 0 And myGLACCT._GLTYP = "X" Then
            dr = ds3.Tables(0).NewRow
            dr("bchno") = WrkBatch
            dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
            dr("acct") = WrkAcct
            dr("acctdescr") = myGLACCT._GLDSC
            dr("errmsg") = String.Empty
            ds3.Tables(0).Rows.Add(dr)
          End If
        Next
      End With

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

    For I = 0 To FundCtl.GetUpperBound(0)
      myGLFUND.GetOneRecordP(FundCtl(I), 0)
      If FundCtlAP(I) <> 0 Then
        'A/P Control 
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDA, ._DPNBRA, ._OBNBRA, ._FNPGMA, ._SUBFNA)
        End With
        dr = ds2.Tables(0).NewRow
        dr("bchno") = SaveBatch
        dr("bchdate") = SaveDate
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "X"
        If FundCtlAP(I) > 0 Then
          dr("credit") = FundCtlAP(I)
        Else
          dr("debit") = Math.Abs(FundCtlAP(I))
        End If
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDA, myGLFUND._DPNBRA, myGLFUND._OBNBRA,
      myGLFUND._FNPGMA, myGLFUND._SUBFNA)
        dr("acct") = WrkAcct
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
          WrkError = True
        End If
        ds2.Tables(0).Rows.Add(dr)
      End If

      'Reserve for Encumbrance
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
        End With
        dr = ds2.Tables(0).NewRow
        dr("bchno") = SaveBatch
        dr("bchdate") = SaveDate
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "E"
        If FundCtlAmt(I) > 0 Then
          dr("debit") = FundCtlAmt(I)
        Else
          dr("credit") = Math.Abs(FundCtlAmt(I))
        End If
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDR, myGLFUND._DPNBRR, myGLFUND._OBNBRR,
        myGLFUND._FNPGMR, myGLFUND._SUBFNR)
        dr("acct") = WrkAcct
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
          WrkError = True
        End If
        ds2.Tables(0).Rows.Add(dr)
      End If

      'Expenditure Control
      If FundCtlExp(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
        End With
        dr = ds2.Tables(0).NewRow
        dr("bchno") = SaveBatch
        dr("bchdate") = SaveDate
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "X"
        If FundCtlExp(I) > 0 Then
          dr("debit") = FundCtlExp(I)
        Else
          dr("credit") = Math.Abs(FundCtlExp(I))
        End If
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND2, myGLFUND._DPNBR2, myGLFUND._OBNBR2,
           myGLFUND._FNPGM2, myGLFUND._SUBFN2)
        dr("acct") = WrkAcct
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
          WrkError = True
        End If
        ds2.Tables(0).Rows.Add(dr)
      End If

      'Revenue Control
      If FundCtlRev(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
        End With
        dr = ds2.Tables(0).NewRow
        dr("bchno") = SaveBatch
        dr("bchdate") = SaveDate
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "X"
        If FundCtlRev(I) > 0 Then
          dr("debit") = FundCtlRev(I)
        Else
          dr("credit") = Math.Abs(FundCtlRev(I))
        End If
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND1, myGLFUND._DPNBR1, myGLFUND._OBNBR1,
           myGLFUND._FNPGM1, myGLFUND._SUBFN1)
        dr("acct") = WrkAcct
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
          WrkError = True
        End If
        ds2.Tables(0).Rows.Add(dr)
      End If

      'Encumbrance 
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
        End With
        dr = ds2.Tables(0).NewRow
        dr("bchno") = SaveBatch
        dr("bchdate") = SaveDate
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "E"
        If FundCtlAmt(I) > 0 Then
          dr("credit") = FundCtlAmt(I)
        Else
          dr("debit") = Math.Abs(FundCtlAmt(I))
        End If
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDE, myGLFUND._DPNBRE, myGLFUND._OBNBRE,
        myGLFUND._FNPGME, myGLFUND._SUBFNE)
        dr("acct") = WrkAcct
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
          WrkError = True
        End If
        ds2.Tables(0).Rows.Add(dr)
      End If
    Next

    If WrkErrorAmt Then
      dr = ds2.Tables(0).NewRow
      dr("bchno") = SaveBatch
      dr("bchdate") = SaveDate
      dr("fund") = 0
      dr("group") = "1"
      dr("gltyp") = ""
      dr("trntyp") = "X"
      dr("credit") = 0
      dr("debit") = 0
      dr("acct") = ""
      dr("acctdesc") = "*** Invoice amount <> detail ***"
      dr("errmsg") = "Invoice amount is not equal to detail"
      WrkError = True
      ds2.Tables(0).Rows.Add(dr)
    End If
    myAPEBCH.CloseFile()
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
