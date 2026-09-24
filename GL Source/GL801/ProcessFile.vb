Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myPOSUMFQ As POSUMFQ.MyData
  Dim myPOSUMF As POSUMF.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myBCHHDR As BCHHDR.MyData
  Dim myGLEBCH As GLEBCH.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen  
  Dim WrkSelFund As Integer
  Dim WrkSelsfund As Integer
  Dim WrkFiscyr As Integer
  Dim WrkFdnbr As Integer
  Dim WrkSfund As Integer
  Dim WrkDpnbr As Integer
  Dim WrkObnbr As Integer
  Dim WrkFnpgm As Integer
  Dim WrkSubfn As Integer
  'General
  Dim SaveGltyp As String
  Dim WrkNextBatch As Integer
  Dim WrkNextBatch2 As Integer
  Dim WrkDatePost As Integer
  Dim FundCtl(25) As Integer
  Dim FundCtlAmt(25) As Decimal
  Public Sub ProcFile()
    myPOSUMFQ = New POSUMFQ.MyData()
    myPOSUMFQ.MyDBConn = myDBConnect
    myPOSUMF = New POSUMF.MyData()
    myPOSUMF.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLEBCH = New GLEBCH.MyData()
    myGLEBCH.MyDBConn = myDBConnect

    With MyFrmGL801B
      WrkSelFund = MyUtils.CnvSng(.TxtSelFund.Text)
      WrkSelsfund = MyUtils.CnvSng(.TxtSelSfund.Text)
      WrkFiscyr = MyUtils.CnvSng(.TxtFiscyr.Text)
      WrkDatePost = MyUtils.SetDBDate(.DtPckPost.Value)
      WrkFdnbr = MyUtils.CnvSng(.TxtFund.Text)
      WrkSfund = MyUtils.CnvSng(.TxtSfund.Text)
      WrkDpnbr = MyUtils.CnvSng(.TxtDept.Text)
      WrkObnbr = MyUtils.CnvSng(.TxtObj.Text)
      WrkFnpgm = MyUtils.CnvSng(.TxtFcn.Text)
      WrkSubfn = MyUtils.CnvSng(.TxtSfcn.Text)
    End With

    CreateBCHHDR()
    WriteBatch()
    MsgBox("Batch has been created", MsgBoxStyle.Information, "Process completed")
  End Sub
  Private Sub CreateBCHHDR()
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLEBCH = New GLEBCH.MyData()
    myGLEBCH.MyDBConn = myDBConnect
    myBCHHDR.GetOneRecordP(MyBatch, 0)
    If myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._APPID = MyBatch
        ._BCHNO = 0
        .AddOneRecordP()
      End With
    End If

    WrkNextBatch = myBCHHDR.AutoGenKey(MyBatch)
    myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch)
    If myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._APPID = MyBatch
        ._BCHNO = WrkNextBatch
        ._ORGUS = "GEMSNET"
        ._LSTUS = MyUserID
        ._STATS = "S"
        ._SUBST = ""
        ._PSDT = WrkDatePost
        .AddOneRecordP()
      End With
    End If

    WrkNextBatch2 = WrkNextBatch + 1
    myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch2)
    If myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._APPID = MyBatch
        ._BCHNO = WrkNextBatch2
        ._ORGUS = "GEMSNET"
        ._LSTUS = MyUserID
        ._STATS = "S"
        ._SUBST = ""
        ._PSDT = WrkDatePost
        .AddOneRecordP()
      End With
    End If

    myBCHHDR.GetOneRecordP(MyBatch, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkNextBatch2
        .UpdateOneRecordP()
      End With
    End If
  End Sub
  Private Sub WriteBatch()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkSumFdnbr As Integer
    Dim WrkSumSfund As Integer
    Dim WrkSumDpnbr As Integer
    Dim WrkSumObnbr As Integer
    Dim WrkSumFnpgm As Integer
    Dim WrkSumSubfn As Integer
    Dim WrkAcct As String
    Dim WrkTran As Integer
    Dim WrkSeq As Integer
    Dim K As Integer
    Dim Counter As Integer
    Dim NumRecs As Integer
    Dim NumRecs2 As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "ACCT like '" & WrkSelFund & Format(WrkSelsfund, "000") & "%'"
    WrkQry = WrkQry & WrkAnd & "FSCYR=" & WrkFiscyr & WrkAnd & " POOPN>0 and POLIQ<>'N'"
    WrkSort = ""
    myPOSUMFQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = ""
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkTran = myGLEBCH.AutoGenTran(WrkNextBatch)
    Counter = 0
    NumRecs = 0
    NumRecs2 = 0
    Array.Clear(FundCtl, 0, 25)
    Array.Clear(FundCtlAmt, 0, 25)

ReadNext:
    myPOSUMFQ.ReadQry()
    If Not myPOSUMFQ.IsEOF Then
      With myPOSUMFQ
        Counter = Counter + 1
        'Debit Expense
        WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch, WrkTran)
        myGLEBCH.GetOneRecordP(WrkNextBatch, WrkTran, WrkSeq)
        myGLEBCH._BCHNO = WrkNextBatch
        myGLEBCH._TRNBR = WrkTran
        myGLEBCH._JRNSEQ = WrkSeq
        myGLEBCH._TRNTYP = "X"
        BreakAcct(._ACCT, WrkSumFdnbr, WrkSumSfund, WrkSumDpnbr, WrkSumObnbr, WrkSumFnpgm, WrkSumSubfn)
        myGLEBCH._FDNBR = WrkSumFdnbr
        myGLEBCH._SFUND = WrkSumSfund
        myGLEBCH._DPNBR = WrkSumDpnbr
        myGLEBCH._OBNBR = WrkSumObnbr
        myGLEBCH._FNPGM = WrkSumFnpgm
        myGLEBCH._SUBFN = WrkSumSubfn
        myGLEBCH._DESCR = "F/Y Close PO " & ._PONBR
        myGLEBCH._AMT = ._POOPN
        myGLEBCH._GLTYP = "X"
        myGLEBCH._JACT8 = WrkDatePost
        myGLEBCH._JENT8 = WrkDatePost
        myGLEBCH._REFNO = 0
        myGLEBCH._PRJ = 0
        myGLEBCH._AMTTYP = "D"
        myGLEBCH._TOTDR = ._POOPN
        myGLEBCH._TOTCR = 0
        myGLEBCH.AddOneRecordP()
        NumRecs = NumRecs + 1

        'Credit Liability
        WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch, WrkTran)
        myGLEBCH.GetOneRecordP(WrkNextBatch, WrkTran, WrkSeq)
        myGLEBCH._BCHNO = WrkNextBatch
        myGLEBCH._TRNBR = WrkTran
        myGLEBCH._JRNSEQ = WrkSeq
        myGLEBCH._TRNTYP = "X"
        myGLEBCH._FDNBR = WrkFdnbr
        myGLEBCH._SFUND = WrkSfund
        myGLEBCH._DPNBR = WrkDpnbr
        myGLEBCH._OBNBR = WrkObnbr
        myGLEBCH._FNPGM = WrkFnpgm
        myGLEBCH._SUBFN = WrkSubfn
        myGLEBCH._DESCR = "F/Y Close PO " & ._PONBR
        myGLEBCH._AMT = ._POOPN
        myGLEBCH._GLTYP = "L"
        myGLEBCH._JACT8 = WrkDatePost
        myGLEBCH._JENT8 = WrkDatePost
        myGLEBCH._REFNO = 0
        myGLEBCH._PRJ = 0
        myGLEBCH._AMTTYP = "C"
        myGLEBCH._TOTDR = ._POOPN
        myGLEBCH._TOTCR = 0
        myGLEBCH.AddOneRecordP()
        NumRecs = NumRecs + 1

        'Credit Encumbrance
        WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch2, WrkTran)
        myGLEBCH.GetOneRecordP(WrkNextBatch2, WrkTran, WrkSeq)
        myGLACCT.GetOneRecordP(WrkSumFdnbr, WrkSumSfund, WrkSumDpnbr, WrkSumObnbr, WrkSumFnpgm, WrkSumSubfn)
        myGLEBCH._BCHNO = WrkNextBatch2
        myGLEBCH._TRNBR = WrkTran
        myGLEBCH._JRNSEQ = WrkSeq
        myGLEBCH._TRNTYP = "E"
        myGLEBCH._FDNBR = WrkSumFdnbr
        myGLEBCH._SFUND = WrkSumSfund
        myGLEBCH._DPNBR = WrkSumDpnbr
        myGLEBCH._OBNBR = WrkSumObnbr
        myGLEBCH._FNPGM = WrkSumFnpgm
        myGLEBCH._SUBFN = WrkSumSubfn
        myGLEBCH._DESCR = "F/Y Close PO " & ._PONBR
        myGLEBCH._AMT = ._POOPN
        myGLEBCH._GLTYP = myGLACCT._GLTYP
        myGLEBCH._JACT8 = WrkDatePost
        myGLEBCH._JENT8 = WrkDatePost
        myGLEBCH._REFNO = 0
        myGLEBCH._PRJ = 0
        myGLEBCH._AMTTYP = "C"
        myGLEBCH._TOTDR = 0
        myGLEBCH._TOTCR = ._POOPN
        myGLEBCH.AddOneRecordP()
        NumRecs2 = NumRecs2 + 1
        'Write To Control totals
        K = LookupFundCtl(WrkSumFdnbr)
        FundCtl(K) = WrkSumFdnbr
        FundCtlAmt(K) = FundCtlAmt(K) + ._POOPN
        'Write POSUMF Liability Account
        WrkAcct = BuildAcct(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
        myPOSUMF._ACCT = WrkAcct
        myPOSUMF._FSCYR = WrkFiscyr
        myPOSUMF._PONBR = ._PONBR
        myPOSUMF._POAMT = ._POOPN
        myPOSUMF._POOPN = ._POOPN
        myPOSUMF._POPAD = 0
        myPOSUMF._POLIQ = "N"
        myPOSUMF.InsertOneRecordP()
        'Update POSUMF Account
        myPOSUMF.GetOneRecordP(WrkFiscyr, ._PONBR, ._ACCT)
        myPOSUMF._POOPN = 0
        myPOSUMF._POPAD = ._POAMT
        myPOSUMF.UpdateOneRecordP()
      End With 'myPOSUMFQ

NextRec:
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

    'Write to Control Accounts
    For I = 0 To FundCtl.GetUpperBound(0)
      myGLFUND.GetOneRecordP(FundCtl(I), 0)
      If FundCtlAmt(I) <> 0 Then
        With myGLEBCH
          'Reserve for Encumbrance
          With myGLFUND
            myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
          End With
          WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch2, WrkTran)
          myGLEBCH.GetOneRecordP(WrkNextBatch2, WrkTran, WrkSeq)
          myGLEBCH._BCHNO = WrkNextBatch2
          myGLEBCH._TRNBR = WrkTran
          myGLEBCH._JRNSEQ = WrkSeq
          myGLEBCH._TRNTYP = "E"
          myGLEBCH._FDNBR = FundCtl(I)
          myGLEBCH._SFUND = myGLFUND._SFUNDR
          myGLEBCH._DPNBR = myGLFUND._DPNBRR
          myGLEBCH._OBNBR = myGLFUND._OBNBRR
          myGLEBCH._FNPGM = myGLFUND._FNPGMR
          myGLEBCH._SUBFN = myGLFUND._SUBFNR
          myGLEBCH._DESCR = Mid(Trim(myGLACCT._GLDSC), 1, 20)
          myGLEBCH._AMT = FundCtlAmt(I)
          myGLEBCH._GLTYP = myGLACCT._GLTYP
          myGLEBCH._JACT8 = WrkDatePost
          myGLEBCH._JENT8 = WrkDatePost
          myGLEBCH._REFNO = 0
          myGLEBCH._PRJ = 0
          If FundCtlAmt(I) > 0 Then
            myGLEBCH._AMTTYP = "D"
            myGLEBCH._TOTCR = FundCtlAmt(I)
            myGLEBCH._TOTDR = 0
          Else
            myGLEBCH._AMTTYP = "C"
            myGLEBCH._TOTDR = FundCtlAmt(I)
            myGLEBCH._TOTCR = 0
          End If
          myGLEBCH.AddOneRecordP()
          NumRecs2 = NumRecs2 + 1

          'Encumbrance 
          With myGLFUND
            myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
          End With
          WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch2, WrkTran)
          myGLEBCH.GetOneRecordP(WrkNextBatch2, WrkTran, WrkSeq)
          myGLEBCH._BCHNO = WrkNextBatch2
          myGLEBCH._TRNBR = WrkTran
          myGLEBCH._JRNSEQ = WrkSeq
          myGLEBCH._TRNTYP = "E"
          myGLEBCH._FDNBR = FundCtl(I)
          myGLEBCH._SFUND = myGLFUND._SFUNDE
          myGLEBCH._DPNBR = myGLFUND._DPNBRE
          myGLEBCH._OBNBR = myGLFUND._OBNBRE
          myGLEBCH._FNPGM = myGLFUND._FNPGME
          myGLEBCH._SUBFN = myGLFUND._SUBFNE
          myGLEBCH._DESCR = Mid(Trim(myGLACCT._GLDSC), 1, 20)
          myGLEBCH._AMT = FundCtlAmt(I)
          myGLEBCH._GLTYP = myGLACCT._GLTYP
          myGLEBCH._JACT8 = WrkDatePost
          myGLEBCH._JENT8 = WrkDatePost
          myGLEBCH._REFNO = 0
          myGLEBCH._PRJ = 0
          If FundCtlAmt(I) > 0 Then
            myGLEBCH._AMTTYP = "C"
            myGLEBCH._TOTDR = FundCtlAmt(I)
            myGLEBCH._TOTCR = 0
          Else
            myGLEBCH._AMTTYP = "D"
            myGLEBCH._TOTCR = FundCtlAmt(I)
            myGLEBCH._TOTDR = 0
          End If
          myGLEBCH.AddOneRecordP()
          NumRecs2 = NumRecs2 + 1
        End With

        'Expenditure Control 
        '  With myGLFUND
        '    myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
        '  End With
        '  WrkSeq = myGLEBCH.AutoGenSeq(WrkNextBatch2, WrkTran)
        '  myGLEBCH.GetOneRecordP(WrkNextBatch2, WrkTran, WrkSeq)
        '  myGLEBCH._BCHNO = WrkNextBatch2
        '  myGLEBCH._TRNBR = WrkTran
        '  myGLEBCH._JRNSEQ = WrkSeq
        '  myGLEBCH._TRNTYP = "X"
        '  myGLEBCH._FDNBR = FundCtl(I)
        '  myGLEBCH._SFUND = myGLFUND._SFUND2
        '  myGLEBCH._DPNBR = myGLFUND._DPNBR2
        '  myGLEBCH._OBNBR = myGLFUND._OBNBR2
        '  myGLEBCH._FNPGM = myGLFUND._FNPGM2
        '  myGLEBCH._SUBFN = myGLFUND._SUBFN2
        '  myGLEBCH._DESCR = Mid(Trim(myGLACCT._GLDSC), 1, 20)
        '  myGLEBCH._AMT = FundCtlAmt(I)
        '  myGLEBCH._GLTYP = myGLACCT._GLTYP
        '  myGLEBCH._JACT8 = WrkDatePost
        '  myGLEBCH._JENT8 = WrkDatePost
        '  myGLEBCH._REFNO = 0
        '  myGLEBCH._PRJ = 0
        '  If FundCtlAmt(I) > 0 Then
        '    myGLEBCH._AMTTYP = "D"
        '    myGLEBCH._TOTDR = FundCtlAmt(I)
        '    myGLEBCH._TOTCR = 0
        '  Else
        '    myGLEBCH._AMTTYP = "C"
        '    myGLEBCH._TOTCR = FundCtlAmt(I)
        '    myGLEBCH._TOTDR = 0
        '  End If
        '  myGLEBCH.AddOneRecordP()
        '  NumRecs2 = NumRecs2 + 1
      End If
    Next

    UpdateBCHHDR(WrkNextBatch, NumRecs)
    UpdateBCHHDR(WrkNextBatch2, NumRecs2)
    myFrmProgress.Close()
    myPOSUMFQ.CloseFile()
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
  Private Sub UpdateBCHHDR(ByVal WrkBatch As Integer, ByVal NumRecs As Integer)
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect

    myBCHHDR.GetOneRecordP(MyBatch, WrkBatch)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._NBRRC = NumRecs
        .UpdateOneRecordP()
      End With
    End If
  End Sub
End Module
