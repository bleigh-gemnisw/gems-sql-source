Imports System.Text
Module PostBCHHDR
  Dim myPOMASTQ As POMASTQ.MyData
  Dim myPOMAST As POMAST.MyData
  Dim myPOSUMFQ As POSUMFQ.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myAPCTRL As APCTRL.MyData
  Dim myAPEBNK As APEBNK.MyData
  Dim myAPEOPN As APEOPN.MyData
  Dim myAPEOPNL1 As APEOPNL1.MyData
  Dim myAPERCN As APERCN.MyData
  Dim myAPEHST As APEHST.MyData
  Dim myAPEOPNQ As APEOPNQ.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim myFrmProgress As FrmProgress
  Dim FundCtl(100) As Integer
  Dim FundCtlAmt(100) As Decimal
  Dim WrkSrcde As String
  Dim WrkRefNo As Integer
  Dim WrkPostDate As Integer
  Dim WrkPost As Boolean
  Dim WrkBank As String
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim WrkError As Boolean
  Dim dr As Data.DataRow
  Dim ds As DataSet = New DataSet
  Dim apds As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim rpds As DataSet = New DataSet
  Dim mysortds2 As String
  Dim mysortds As String
  Dim mypostingdate As Date
  Dim wrkpostdateMDY As String

  Public Sub Pstchecks(ByVal workpostdate As Date)

    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Dim Counter As Integer
    Dim Answer As Integer

    WrkPost = True 'Testing
    WrkSrcde = "1"
    mypostingdate = workpostdate
    WrkPostDate = mypostingdate.ToString("yyyyMMdd")
    wrkpostdateMDY = mypostingdate.ToString("MMddyyyy")

    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect
    myAPEOPN = New APEOPN.MyData()
    myAPEOPN.MyDBConn = myDBConnect
    myAPEOPNL1 = New APEOPNL1.MyData()
    myAPEOPNL1.MyDBConn = myDBConnect
    myAPEOPNQ = New APEOPNQ.MyData()
    myAPEOPNQ.MyDBConn = myDBConnect

    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)
    Counter = 0
    If ds.Tables.Count = 0 Then
      BuildDS()
      BuildRPDS()
    Else
      ds.Clear()
      rpds.Clear()
    End If
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect
    getrecordstopost()   ' AP4034R

    If WrkError Then
      MsgBox("Correct any invalid accounts or negative checks", MsgBoxStyle.Exclamation, "Rerun Select payables or Print Checks")
      Exit Sub
    Else
      Answer = MsgBox("Posting Checks to date " + MyFrmAP404B.DtPckPost.Value.ToString("MM/dd/yyyy") & ". Continue with Check Posting?", MsgBoxStyle.YesNo, "Post Checks confirmation")
      If Answer = vbNo Then
        MsgBox("Rerun post checks", MsgBoxStyle.Exclamation, "Posting has been aborted")
        Exit Sub
      End If
    End If
    'Post to ledger PLEDBCHR
    WriteControl(rpds.Tables(0).Rows(0).Item("bchno"))
    myAPEHST = New APEHST.MyData()
    myAPEHST.MyDBConn = myDBConnect
    myAPERCN = New APERCN.MyData()
    myAPERCN.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myAPCTRL = New APCTRL.MyData(myDBConnect)

    myPOMASTQ = New POMASTQ.MyData()
    myPOMASTQ.MyDBConn = myDBConnect
    myPOSUMFQ = New POSUMFQ.MyData()
    myPOSUMFQ.MyDBConn = myDBConnect
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    updateAPfiles()

    MessageBox.Show("Posting Complete", "AP Check Posting")

    'Cleanup
    myAPEHST = Nothing
    myAPERCN = Nothing
    myVENDOR = Nothing
    myAPEOPN = Nothing
    myAPEOPNQ = Nothing
    myAPEBNK = Nothing
    myAPCTRL = Nothing
    myPOMAST = Nothing
    myPOMASTQ = Nothing
    myPOSUMFQ = Nothing
    myLEDGER = Nothing
    myGLACCT = Nothing
    myGLFUND = Nothing

  End Sub
  Private Sub updatepomaster(ByVal myfscyr As Integer, ByVal mypo As Integer)
    Dim myopen As Double
    Dim Counter As Integer
    Counter = 0
    ds.Clear()
ReadNext:
    myopen = 0
    Counter = Counter + 1
    myopen = getsumfopen(myfscyr, mypo)
    myPOMAST.GetOneRecordP(myfscyr, mypo, 0, 0, 0)
    If myopen > 0 Then
      myPOMAST._CMPCD = "O"
      myPOMAST._POPEN = myopen
    Else
      myPOMAST._CMPCD = "C"
      myPOMAST._POPEN = 0
    End If
    If WrkPost Then
      myPOMAST.UpdateOneRecordP()
    End If
NextRec:
    myFrmProgress.Close()

  End Sub
  Function getsumfopen(ByVal myfscyr As Integer, myponbr As Integer) As Double
    Dim WrkQry As String
    Dim WrkSort As String
    Dim myopen As Double

    WrkQry = "FSCYR = " + myfscyr.ToString
    WrkQry = WrkQry + " AND PONBR = " + myponbr.ToString
    WrkSort = ""
    WrkSort = "FSCYR, PONBR"

    myopen = 0
    myPOSUMFQ.OpenQry(WrkSort, WrkQry)

ReadNext:

    myPOSUMFQ.ReadQry()
    If Not myPOSUMFQ.IsEOF Then

      With myPOSUMFQ
        myopen = myopen + ._POOPN
      End With
NextRec:

      GoTo ReadNext
    End If
    getsumfopen = myopen
  End Function
  Private Sub updateAPfiles()
    'LEFT OFF HERE AP4042R
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim Counter As Integer
    Dim save_vndnr As String
    Dim save_invno As String
    Dim save_recno As Integer
    Dim save_REFNO As Integer
    Dim save_CHKN As Integer
    Dim save_payck As Integer
    Dim save_TDESC As String
    Dim save_INVNR As String
    Dim save_bchno As Integer
    Dim save_payam As Double
    Dim save_fscyr As Integer
    Dim vamt As Double
    Dim lastpaid As String
    Dim mypostingmdy As String
    Dim save_invd8 As String
    Dim save_ponbr As Integer
    Dim save_bnkcd As String

    save_bnkcd = ""
    save_bchno = 0
    save_vndnr = ""
    save_invno = ""
    save_recno = 0
    save_REFNO = 0
    save_CHKN = 0
    save_payam = 0
    save_payck = 0
    save_fscyr = 0
    save_ponbr = 0
    save_invd8 = ""
    save_TDESC = ""
    save_INVNR = ""
    vamt = 0
    lastpaid = ""
    mypostingmdy = 0
    mypostingmdy = flipmetomdy(WrkPostDate.ToString)
    Counter = 0
    WrkAnd = " and "
    WrkQry = "SLTPY='1'"
    WrkSort = ""
    WrkSort = "VNDNR, INVNO, RECNO"
    ds.Clear()
    myAPEOPNQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Check Posting - Updating AP History"

    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
ReadNext:
    myAPEOPNQ.ReadQry()
    If Not myAPEOPNQ.IsEOF Then
      Counter = Counter + 1
      With myAPEOPNQ
        If save_vndnr <> ._VNDNR Then   'L3
          'update vendor 
          If vamt <> 0 Then doupdatevendortime(save_vndnr, vamt, lastpaid, save_bnkcd, save_payck) ' UPDATE VENDOR
          vamt = 0
        End If
        If save_vndnr <> ._VNDNR Or save_invno <> ._INVNO Then              'L2()
          If save_vndnr <> "" Then
            'Remove from open file
            If WrkPost Then
              myAPEOPN.DeleteVendorInvoice(save_vndnr, save_invno)
            End If
          End If
          lastpaid = flipmedate(._PPDT8)
          vamt = vamt + ._PAYAM
          save_payam = ._PAYAM
          save_vndnr = ._VNDNR
          save_recno = ._RECNO
          save_invno = ._INVNO
          save_REFNO = ._PAYCK
          save_CHKN = ._PAYCK
          save_ponbr = ._PONBR
          save_INVNR = ._INVNO
          save_bchno = ._BCHNO
          save_fscyr = ._FSCYR
          save_invd8 = ._INVD8
          save_payck = ._PAYCK
          save_bnkcd = ._PAYBN
        End If

        'update apehst
        myAPEHST.GetOneRecordP("", "", 0, 0)
        myAPEHST._VNDNR = ._VNDNR
        myAPEHST._INVNO = ._INVNO
        myAPEHST._RECNO = ._RECNO
        myAPEHST._AMTGR = ._AMTGR
        myAPEHST._AMTDS = ._AMTDS
        myAPEHST._AMTSH = ._AMTSH
        myAPEHST._AMTNT = ._AMTNT
        myAPEHST._DSCTX = ._DSCTX
        myAPEHST._PONBR = ._PONBR
        myAPEHST._F1099 = ._F1099
        myAPEHST._LEOPN = ._LEOPN
        myAPEHST._FDNBR = ._FDNBR
        myAPEHST._SFUND = ._SFUND
        myAPEHST._DPNBR = ._DPNBR
        myAPEHST._OBNBR = ._OBNBR
        myAPEHST._FNPGM = ._FNPGM
        myAPEHST._SUBFN = ._SUBFN
        myAPEHST._VENNM = ._VENNM
        myAPEHST._BCHNO = ._BCHNO
        myAPEHST._LSTPD = ._LSTPD
        myAPEHST._AMTPD = save_payam
        myAPEHST._CHKPD = save_payck
        myAPEHST._BNKCD = save_bnkcd
        myAPEHST._CSHYN = ._CSHYN
        myAPEHST._MANUL = ""
        myAPEHST._FSCYR = save_fscyr
        myAPEHST._AVOID = ""
        myAPEHST._VNCAT = ._VNCAT
        myAPEHST._OTIME = ._OTIME
        myAPEHST._FA = ._FA
        myAPEHST._INVD8 = ._INVD8
        myAPEHST._DUED8 = ._DUED8
        myAPEHST._PPDT8 = lastpaid
        myAPEHST._LSTP8 = lastpaid
        myAPEHST._PRJ = ._PRJ
        myAPEHST._APPST = mypostingmdy
        myAPEHST._VSORT = ._VSORT
        'Add to history file
        If WrkPost Then
          myAPEHST.AddOneRecordP()
          UpdateLedgerCheck(save_payck, ._PONBR, ._INVNO, ._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        End If
        ' MOVED TO HERE  UPDATE POMASTER IF REQUIRED instead of doing 400 thing
        If ._RECNO = 0 And save_ponbr > 0 Then
          updatepomaster(save_fscyr, save_ponbr)
        End If
      End With

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

    ' finished reading so LAst vendor need to update
    If vamt <> 0 Then doupdatevendortime(save_vndnr, vamt, lastpaid, save_bnkcd, save_payck)

    'Remove from open file
    If WrkPost Then
      myAPEOPN.DeleteVendorInvoice(save_vndnr, save_invno)
    End If

    'LR Time  updated bank file
    With myAPEBNK
      .GetOneRecordP(save_bnkcd)
      If Not .RecordNotFound And save_payck < 99999 Then
        ._BCHKN = save_payck + 1
        If WrkPost Then
          .UpdateOneRecordP()
        End If
      End If
    End With

    'Replaces UPAPCTRL pgm
    myAPCTRL.GetOneRecordP(1)
    myAPCTRL._CPST = " "
    If WrkPost Then
      myAPCTRL.UpdateOneRecordP()
    End If
    myFrmProgress.Close()
  End Sub
  Private Sub doupdatevendortime(ByVal myvend As String, ByVal myamt As Double, ByVal mydate As String, ByVal mybank As String, ByVal mycheck As Integer)
    'add to check file
    With myAPERCN
      .GetOneRecordP(mybank, mycheck)
      ._VNDNR = myvend
      ._PAYAM = myamt
      ._PAYP8 = mydate
      ._BANKRP = "0"
      ._RCCDE = "A"
      If WrkPost Then
        If .RecordNotFound Then
          ._PAYBN = mybank
          ._PAYCK = mycheck
          .AddOneRecordP()
        Else
          .UpdateOneRecordP()
        End If
      End If
    End With

    'update vendor
    myVENDOR.GetOneRecordP(myvend)
    myVENDOR._MTDPA = myVENDOR._MTDPA + myamt
    myVENDOR._YTDPA = myVENDOR._YTDPA + myamt
    myVENDOR._FSCPA = myVENDOR._FSCPA + myamt
    myVENDOR._DTLPD = mydate
    If WrkPost Then
      myVENDOR.UpdateOneRecordP()
    End If

  End Sub
  Private Sub WriteControl(ByVal BatchNo As Integer)
    Dim WrkFdnbr As Integer
    Dim WrkSfund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtlAmt(I) <> 0 Then
        With myGLFUND
          'A/P Control 
          .GetOneRecordP(FundCtl(I), 0)
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDA, ._DPNBRA, ._OBNBRA, ._FNPGMA, ._SUBFNA)
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
          ._DPNBR = myGLFUND._DPNBRA
          ._FDNBR = FundCtl(I)
          ._FIL10 = 0
          ._FNPGM = myGLFUND._FNPGMA
          ._FSCYR = 0
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = WrkPostDate
          ._OBNBR = myGLFUND._OBNBRA
          ._ORIG = 0
          ._SFUND = myGLFUND._SFUNDA
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = BatchNo
          ._ROCR = String.Empty
          ._SUBFN = myGLFUND._SFUNDA
          ._TDESC = "Checks " & WrkPostDate
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = BatchNo
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          If WrkPost Then
            .InsertOneRecordP()
            If .ErrMsg <> "" Then
              WriteErrorLog("A/P: " & .ErrMsg)
              Application.Exit()
            End If
          End If
        End With

        'Accounts Payable/Cash
        With myAPEBNK
          .GetOneRecordP(WrkBank)
          If ._FDNBR > 0 Then
            myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
            WrkFdnbr = ._FDNBR
            WrkSfund = ._SFUND
            WrkDpnbr = ._DPNBR
            WrkObnbr = ._OBNBR
            WrkFnpgm = ._FNPGM
            WrkSubfn = ._SUBFN
          Else
            With myGLFUND
              myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
              WrkFdnbr = ._FDNBRC
              WrkSfund = ._SFUNDC
              WrkDpnbr = ._DPNBRC
              WrkObnbr = ._OBNBRC
              WrkFnpgm = ._FNPGMC
              WrkSubfn = ._SUBFNC
            End With
          End If
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
          ._DPNBR = WrkDpnbr
          ._FDNBR = WrkFdnbr
          ._FIL10 = 0
          ._FNPGM = WrkFnpgm
          ._FSCYR = 0
          ._GLPST = "CD"
          ._GLTYP = myGLACCT._GLTYP
          ._INVNR = String.Empty
          ._JRNSQ = 0
          ._PONBR = 0
          ._PRF = Mid(MyUserID, 1, 10)
          ._PSTDT = WrkPostDate
          ._OBNBR = WrkObnbr
          ._ORIG = 0
          ._SFUND = WrkSfund
          ._SRCDE = WrkSrcde
          ._RECLS = String.Empty
          ._REFNO = BatchNo
          ._ROCR = String.Empty
          ._SUBFN = WrkSfund
          ._TDESC = "Checks " & WrkPostDate
          ._TRAMT = Math.Abs(FundCtlAmt(I))
          ._TRFTO = String.Empty
          ._TRNBR = BatchNo
          ._TRTYP = "X"
          ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
          If WrkPost Then
            .InsertOneRecordP()
            If .ErrMsg <> "" Then
              WriteErrorLog("Checks: " & .ErrMsg)
              Application.Exit()
            End If
          End If
        End With
      End If
    Next
  End Sub
  Private Sub getrecordstopost()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkAnd As String
    Dim Counter As Integer
    Dim WrkAmtGr As Decimal
    Dim save_vndnr As String
    Dim save_invno As String
    Dim save_recno As Integer
    Dim save_REFNO As Integer
    Dim save_FSCYR As Integer
    Dim save_PONBR As Integer
    Dim save_CHKN As Integer
    Dim save_TDESC As String
    Dim save_INVNR As String
    Dim save_bchno As Integer
    Dim WrkAcct As String
    Dim vendormaxLength As Integer = 30
    Dim Wrkvendorname As String
    Dim K As Integer
    save_bchno = 0
    save_vndnr = 0
    save_invno = 0
    save_recno = 0
    save_REFNO = 0
    save_FSCYR = 0
    save_PONBR = 0
    save_CHKN = 0
    save_TDESC = ""
    save_INVNR = ""

    WrkAnd = " and "
    WrkQry = "SLTPY='1'"
    WrkSort = ""
    WrkSort = "VNDNR, INVNO, RECNO"
    ds.Clear()
    WrkError = False
    myAPEOPNQ.OpenQry(WrkSort, WrkQry)
    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Check Posting: Select records"

    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkBank = ""

ReadNext:
    myAPEOPNQ.ReadQry()
    If Not myAPEOPNQ.IsEOF Then
      With myAPEOPNQ
        If Trim(._PAYBN) <> "" And WrkBank = "" Then
          WrkBank = ._PAYBN
        End If
        If save_vndnr <> ._VNDNR And save_invno <> ._INVNO Then
          WrkAmtGr = myAPEOPNL1.GetVndnrAmtgr(._VNDNR)
          If WrkAmtGr < 0 Then
            WrkError = True
          End If
          save_vndnr = ._VNDNR
          save_recno = ._RECNO
          save_invno = ._INVNO
          save_REFNO = ._PAYCK
          save_FSCYR = ._FSCYR
          save_PONBR = ._PONBR
          save_CHKN = ._PAYCK
          Wrkvendorname = ._VENNM.Substring(0, vendormaxLength)
          save_TDESC = Replace(Wrkvendorname, "'", "")
          save_INVNR = ._INVNO
          save_bchno = ._BCHNO
        End If

        'get accounts from fund
        myGLFUND.GetOneRecordP(._FDNBR, ._SFUND)
        If ._RECNO > 0 Then

          '          If ._CSHYN <> "Y" Then
          K = LookupFundCtl(._FDNBR)
          FundCtl(K) = ._FDNBR
          FundCtlAmt(K) = FundCtlAmt(K) + ._AMTGR
          myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          '          End If 'end cshyn <> Y
        End If
      End With

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

    For I = 0 To FundCtl.GetUpperBound(0)
      myGLFUND.GetOneRecordP(FundCtl(I), 0)
      If FundCtlAmt(I) <> 0 Then
        'A/P Control 
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDA, ._DPNBRA, ._OBNBRA, ._FNPGMA, ._SUBFNA)
        End With
        dr = rpds.Tables(0).NewRow
        dr("bchno") = save_bchno
        dr("bchdate") = MyUtils.GetDBDate(WrkPostDate)
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "X"
        If FundCtlAmt(I) > 0 Then
          dr("debit") = FundCtlAmt(I)
        Else
          dr("credit") = Math.Abs(FundCtlAmt(I))
        End If
        WrkAcct = Buildacct(FundCtl(I), myGLFUND._SFUNDA, myGLFUND._DPNBRA, myGLFUND._OBNBRA,
      myGLFUND._FNPGMA, myGLFUND._SUBFNA)
        dr("acct") = WrkAcct
        If WrkError Then
          dr("errmsg") = "*** Negative Check ***"
        End If
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          WrkError = True
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
        End If
        rpds.Tables(0).Rows.Add(dr)

        'Accounts Payable/Cash
        With myAPEBNK
          .GetOneRecordP(WrkBank)
          If ._FDNBR > 0 Then
            myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
            WrkAcct = Buildacct(FundCtl(I), ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          Else
            With myGLFUND
              myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
              WrkAcct = Buildacct(FundCtl(I), ._SFUNDC, ._DPNBRC, ._OBNBRC, ._FNPGMC, ._SUBFNC)
            End With
          End If
        End With
        dr = rpds.Tables(0).NewRow
        dr("bchno") = save_bchno
        dr("bchdate") = MyUtils.GetDBDate(WrkPostDate)
        dr("fund") = FundCtl(I)
        dr("group") = "1"
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "X"
        If FundCtlAmt(I) > 0 Then
          dr("credit") = FundCtlAmt(I)
        Else
          dr("debit") = Math.Abs(FundCtlAmt(I))
        End If
        dr("acct") = WrkAcct
        If WrkError Then
          dr("errmsg") = "*** Negative Check ***"
        End If
        If Not myGLACCT.RecordNotFound Then
          dr("acctdesc") = myGLACCT._GLDSC
          dr("errmsg") = String.Empty
        Else
          WrkError = True
          dr("acctdesc") = "*** Invalid Account ***"
          dr("errmsg") = "*** Invalid Account ***"
        End If
        rpds.Tables(0).Rows.Add(dr)
      End If
    Next
    myFrmProgress.Close()
    MyCrViewer = New FrmCrViewer
    MyCrViewer.mypostingdate = mypostingdate
    MyCrViewer.ds = rpds
    MyCrViewer.ShowDialog()
  End Sub
  Private Sub UpdateLedgerCheck(ByVal ChkNo As Integer, ByVal PONbr As Integer, ByVal Invnr As String,
    ByVal Fdnbr As Integer, ByVal Sfund As Integer, ByVal Dpnbr As Integer, ByVal Obnbr As Integer,
    ByVal Fnpgm As Integer, ByVal Subfn As Integer)
    Dim wrkset As String
    Dim wrkwhere As String
    wrkset = "Set REFNO=" & ChkNo & ",GLPST='CD',CHKN=" & ChkNo
    wrkwhere = "Where REFNO = " & PONbr & " and INVNR = " & MyUtils.Quo(Invnr) & " and TRTYP='X' and GLPST=''" _
     & " and FDNBR = " & Fdnbr & " and SFUND = " & Sfund & " and DPNBR = " & Dpnbr _
     & " and OBNBR = " & Obnbr & " and FNPGM = " & Fnpgm & " and SUBFN = " & Subfn
    myLEDGER.RunUpdateQuery(wrkset, wrkwhere)
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
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("fdnbr", Type.GetType("System.Int32"))
      .Columns.Add("sfund", Type.GetType("System.Int32"))
      .Columns.Add("dpnbr", Type.GetType("System.Double"))
      .Columns.Add("obnbr", Type.GetType("System.Int32"))
      .Columns.Add("fnpgm", Type.GetType("System.Int32"))
      .Columns.Add("subfn", Type.GetType("System.Int32"))
      .Columns.Add("refno", Type.GetType("System.Int32"))
      .Columns.Add("fscyr", Type.GetType("System.Int32"))
      .Columns.Add("ponbr", Type.GetType("System.Int32"))
      .Columns.Add("tdesc", Type.GetType("System.String"))
      .Columns.Add("tramt", Type.GetType("System.Decimal"))
      .Columns.Add("invnr", Type.GetType("System.String"))
      .Columns.Add("chkn", Type.GetType("System.String"))
      .Columns.Add("gltyp", Type.GetType("System.String"))
      .Columns.Add("amtyp", Type.GetType("System.String"))
      .Columns.Add("glpst", Type.GetType("System.String"))
      .Columns.Add("pstdt", Type.GetType("System.String"))
      .Columns.Add("trtyp", Type.GetType("System.String"))
      .Columns.Add("srcde", Type.GetType("System.Int32"))
      .Columns.Add("bchno", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildRPDS()
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
    rpds.Tables.Add(myTable)
  End Sub
  Private Function Buildacct(ByVal mfund As Integer, ByVal msfund As Integer, ByVal mdept As Integer, ByVal mobj As Integer, ByVal mfnpgm As Integer, ByVal msubfn As Integer) As String
    Dim sb As StringBuilder
    Dim WrkStr As String
    sb = New StringBuilder
    sb.Append(Format(mfund, "000"))
    sb.Append("-")
    sb.Append(Format(msfund, "000"))
    sb.Append("-")
    sb.Append(Format(mdept, "0000"))
    sb.Append("-")
    sb.Append(Format(mobj, "000"))
    sb.Append("-")
    sb.Append(Format(mfnpgm, "0000"))
    sb.Append("-")
    sb.Append(Format(msubfn, "0000"))
    WrkStr = sb.ToString
    sb = Nothing
    Return WrkStr
  End Function
  Private Function flipmedate(ByVal myd8 As String) As String
    Dim myw8 As Integer
    Dim wrkdate As Date
    myw8 = myd8
    ' flipmedate = myd8.Substring(4, 4) + myd8.Substring(0, 4)
    wrkdate = MyUtils.GetDBDateMDY(myw8)
    flipmedate = MyUtils.SetDBDate(wrkdate).ToString
  End Function
  Private Function flipmetomdy(ByVal myd8 As String) As String
    Dim mystring As String
    mystring = Mid$(myd8, 5, 2) & Right$(myd8, 2) & Left$(myd8, 4)
    flipmetomdy = mystring
  End Function
End Module
