Imports System.Text
Module ProcessFile

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myLEDGERQ As LEDGERQ.MyData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim myLEDSAVE As LEDGER.MyData
  Dim myLEDHST As LEDHST.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'Screen  
  Dim WrkFdnbr As Integer
  Dim WrkSfund As Integer
  Dim WrkDesc As String
  Dim WrkDateFrom As Integer
  Dim WrkDateTo As Integer
  Dim WrkOvrFile As String
  'General
  Dim WrkNextBatch As Integer
  Dim WrkDatePost As Integer
  Dim WrkError As Boolean
  Public Sub ProcFile()
    Dim WrkFileExists As Boolean
    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect
    myLEDSAVE = New LEDGER.MyData()
    myLEDSAVE.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myLEDHST = New LEDHST.MyData()
    myLEDHST.MyDBConn = myDBConnect

    With MyFrmGL802B
      WrkFdnbr = MyUtils.CnvSng(.TxtSelFund.Text)
      WrkSfund = MyUtils.CnvSng(.TxtSelSfund.Text)
      WrkDesc = .TxtDesc.Text
      WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkDatePost = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkOvrFile = "LED" & .DtPckTo.Value.Year & Format(MyUtils.CnvSng(.TxtSelFund.Text), "000")
    End With

    WrkError = False
    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    WrkFileExists = myDBConnect.CheckSQLFileExists(WrkOvrFile)
    If WrkFileExists Then
      MsgBox("File " & WrkOvrFile & " already exists", MsgBoxStyle.Critical, "Processing will stop. Contact hotline support.")
      Exit Sub
    End If

    With myLEDSAVE
      .OvrFile = WrkOvrFile
      .OpenFile()
      .CreateFile()
    End With
    SaveLEDGER()
    WriteLEDGER()
    DeleteLEDGER()
    MyCrViewer = New FrmCrViewer
    MyCrViewer.ds = ds
    MyCrViewer.Show()
  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Fund", Type.GetType("System.Int32"))
      .Columns.Add("FundDesc", Type.GetType("System.String"))
      .Columns.Add("Sfund", Type.GetType("System.Int32"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("GltypDesc", Type.GetType("System.String"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub SaveLEDGER()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "FDNBR=" & WrkFdnbr & WrkAnd & "SFUND=" & WrkSfund & WrkAnd & "PSTDT <= " & WrkDateTo
    WrkSort = "FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Write to History and Archive"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        WriteLEDHST()
        WriteLEDSAVE()
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

    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
  End Sub
  Private Sub WriteLEDGER()
    Dim WrkQry As String
    Dim SaveQry As String
    Dim WrkSort As String
    Dim WrkGlTyp As String
    Dim WrkTran As Integer
    Dim WrkSeq As Integer
    Dim WrkBal As Decimal
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFunc As Integer
    Dim SaveSfunc As Integer
    Dim SaveFil10 As Long
    Dim WrkRevBal As Decimal
    Dim WrkExpBal As Decimal
    Dim WrkFundBal As Decimal
    Dim Counter As Integer
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "FDNBR=" & WrkFdnbr & WrkAnd & "SFUND=" & WrkSfund & WrkAnd & "PSTDT <= " & WrkDateTo
    SaveQry = WrkQry
    WrkQry = SaveQry & WrkAnd & "GLTYP in ('A','L')" & WrkAnd & "TRTYP = 'X'" &
     WrkOr & SaveQry & WrkAnd & "GLTYP = 'Q'" & WrkAnd & "FIL10 = 9999999999" & WrkAnd & "PSTDT>=" & WrkDateFrom &
     WrkOr & SaveQry & WrkAnd & "GLTYP = 'Q'" & WrkAnd & "FIL10 <> 9999999999"
    WrkSort = "FDNBR, SFUND, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.LblMsg.Text = "Create report and Write to LEDGER"
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    Counter = 0
    WrkBal = 0
    WrkRevBal = 0
    WrkExpBal = 0
    SaveFil10 = 0

    myGLFUND.GetOneRecordP(WrkFdnbr, 0)
    With myGLFUND
      WrkRevBal = GetActivity(._FDNBR1, ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
      WrkExpBal = GetActivity(._FDNBR2, ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
      WrkFundBal = GetFundBalance(._FDNBR1, ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
      WrkFundBal = WrkFundBal + GetFundBalance(._FDNBR2, ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
    End With

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        If ._DPNBR <> SaveDept Or ._OBNBR <> SaveObj Or ._FNPGM <> SaveFunc Or ._SUBFN <> SaveSfunc Then
          If WrkBal <> 0 Then
            myGLACCT.GetOneRecordP(WrkFdnbr, 0, SaveDept, SaveObj, SaveFunc, SaveSfunc)
            WrkGlTyp = myGLACCT._GLTYP
            dr = ds.Tables(0).NewRow
            dr.Item("fund") = WrkFdnbr
            dr.Item("funddesc") = GetFundDesc(WrkFdnbr)
            dr.Item("sfund") = 0
            dr.Item("acct") = Format(WrkFdnbr, "000") & "-" & Format(SaveDept, "0000") & "-" & Format(SaveObj, "000") &
             "-" & Format(SaveFunc, "0000") & "-" & Format(SaveSfunc, "0000")
            dr.Item("acctdesc") = GetAcctDesc(WrkFdnbr, SaveDept, SaveObj, SaveFunc, SaveSfunc)
            dr.Item("gltyp") = WrkGlTyp
            dr.Item("gltypdesc") = GetGlTypDesc(wrkgltyp)
            If WrkBal >= 0 Then
              dr.Item("credit") = WrkBal
            Else
              dr.Item("debit") = Math.Abs(WrkBal)
            End If
            ds.Tables(0).Rows.Add(dr)

            With myLEDGER
              .OvrFile = ""
              If WrkBal >= 0 Then
                ._AMTYP = "C"
              Else
                ._AMTYP = "D"
              End If
              ._AUTOG = String.Empty
              ._BALFC = String.Empty
              ._BCHNO = WrkNextBatch
              ._CBLCD = String.Empty
              ._CHKN = 0
              ._CNTRL = 0
              ._DATED = MyUtils.SetDBDateMDY(Date.Today)
              ._DPNBR = SaveDept
              ._FDNBR = WrkFdnbr
              ._FIL10 = SaveFil10
              ._FIL045 = "GL802"
              ._FNPGM = SaveFunc
              ._FSCYR = 0
              ._GLPST = String.Empty
              ._GLTYP = WrkGlTyp
              ._INVNR = String.Empty
              ._JRNSQ = WrkSeq
              ._OBNBR = SaveObj
              ._ORIG = 0
              ._PONBR = 0
              ._PRF = Mid(MyUserID, 1, 10)
              ._PSTDT = WrkDatePost
              ._RECLS = String.Empty
              ._REFNO = 0
              ._ROCR = String.Empty
              ._SFUND = WrkSfund
              ._SRCDE = 2
              ._SUBFN = SaveSfunc
              ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
              ._TDESC = WrkDesc
              ._TRAMT = Math.Abs(WrkBal)
              ._TRFTO = String.Empty
              ._TRTYP = "X"
              ._TRNBR = WrkTran
              .InsertOneRecordP()
              If .ErrMsg <> "" Then
                WriteErrorLog(.ErrMsg)
                WrkError = True
              End If
            End With
            WrkBal = 0
          End If
        End If
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
        SaveFil10 = ._FIL10
        If ._AMTYP = "D" Then
          WrkBal = WrkBal - ._TRAMT
        Else
          WrkBal = WrkBal + ._TRAMT
        End If
      End With

NextRec:
      If WrkError Then
        Application.Exit()
        Application.DoEvents()
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
      GoTo ReadNext
    End If

    If WrkBal <> 0 Then
      myGLACCT.GetOneRecordP(WrkFdnbr, 0, SaveDept, SaveObj, SaveFunc, SaveSfunc)
      WrkGlTyp = myGLACCT._GLTYP
      dr = ds.Tables(0).NewRow
      dr.Item("fund") = WrkFdnbr
      dr.Item("funddesc") = GetFundDesc(WrkFdnbr)
      dr.Item("sfund") = 0
      dr.Item("acct") = Format(WrkFdnbr, "000") & "-" & Format(SaveDept, "0000") & "-" & Format(SaveObj, "000") &
             "-" & Format(SaveFunc, "0000") & "-" & Format(SaveSfunc, "0000")
      dr.Item("acctdesc") = GetAcctDesc(WrkFdnbr, SaveDept, SaveObj, SaveFunc, SaveSfunc)
      dr.Item("gltyp") = WrkGlTyp
      dr.Item("gltypdesc") = GetGlTypDesc(WrkGlTyp)
      If WrkBal >= 0 Then
        dr.Item("credit") = WrkBal
      Else
        dr.Item("debit") = Math.Abs(WrkBal)
      End If
      ds.Tables(0).Rows.Add(dr)

      With myLEDGER
        .OvrFile = ""
        If WrkBal >= 0 Then
          ._AMTYP = "C"
        Else
          ._AMTYP = "D"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = WrkNextBatch
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = SaveDept
        ._FDNBR = WrkFdnbr
        ._FIL10 = SaveFil10
        ._FIL045 = "GL802"
        ._FNPGM = SaveFunc
        ._FSCYR = 0
        ._GLPST = String.Empty
        ._GLTYP = WrkGlTyp
        ._INVNR = String.Empty
        ._JRNSQ = WrkSeq
        ._OBNBR = SaveObj
        ._ORIG = 0
        ._PONBR = 0
        ._PRF = Mid(MyUserID, 1, 10)
        ._PSTDT = WrkDatePost
        ._RECLS = String.Empty
        ._REFNO = 0
        ._ROCR = String.Empty
        ._SFUND = WrkSfund
        ._SRCDE = 2
        ._SUBFN = SaveSfunc
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        ._TDESC = WrkDesc
        ._TRAMT = Math.Abs(WrkBal)
        ._TRFTO = String.Empty
        ._TRTYP = "X"
        ._TRNBR = WrkTran
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          WrkError = True
        End If
      End With
    End If

    'Revenues
    If WrkRevBal <> 0 Then
      With myLEDGER
        .OvrFile = ""
        If WrkRevBal >= 0 Then
          ._AMTYP = "C"
        Else
          ._AMTYP = "D"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = WrkNextBatch
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = myGLFUND._DPNBR1
        ._FDNBR = myGLFUND._FDNBR1
        ._FIL10 = 9999999999
        ._FIL045 = "GL802"
        ._FNPGM = myGLFUND._FNPGM1
        ._FSCYR = 0
        ._GLPST = String.Empty
        ._GLTYP = "Q"
        ._INVNR = String.Empty
        ._JRNSQ = WrkSeq
        ._OBNBR = myGLFUND._OBNBR1
        ._ORIG = 0
        ._PONBR = 0
        ._PRF = Mid(MyUserID, 1, 10)
        ._PSTDT = WrkDatePost
        ._RECLS = String.Empty
        ._REFNO = 0
        ._ROCR = String.Empty
        ._SFUND = myGLFUND._SFUND1
        ._SRCDE = 2
        ._SUBFN = myGLFUND._SUBFN1
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        ._TDESC = WrkDesc
        ._TRAMT = Math.Abs(WrkRevBal)
        ._TRFTO = String.Empty
        ._TRTYP = "X"
        ._TRNBR = WrkTran
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          WrkError = True
        End If
      End With
    End If

    'Expenditures
    If WrkExpBal <> 0 Then
      With myLEDGER
        .OvrFile = ""
        If WrkExpBal >= 0 Then
          ._AMTYP = "C"
        Else
          ._AMTYP = "D"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = WrkNextBatch
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = myGLFUND._DPNBR2
        ._FDNBR = myGLFUND._FDNBR2
        ._FIL10 = 9999999999
        ._FIL045 = "GL802"
        ._FNPGM = myGLFUND._FNPGM2
        ._FSCYR = 0
        ._GLPST = String.Empty
        ._GLTYP = "Q"
        ._INVNR = String.Empty
        ._JRNSQ = WrkSeq
        ._OBNBR = myGLFUND._OBNBR2
        ._ORIG = 0
        ._PONBR = 0
        ._PRF = Mid(MyUserID, 1, 10)
        ._PSTDT = WrkDatePost
        ._RECLS = String.Empty
        ._REFNO = 0
        ._ROCR = String.Empty
        ._SFUND = myGLFUND._SFUND2
        ._SRCDE = 2
        ._SUBFN = myGLFUND._SUBFN2
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        ._TDESC = WrkDesc
        ._TRAMT = Math.Abs(WrkExpBal)
        ._TRFTO = String.Empty
        ._TRTYP = "X"
        ._TRNBR = WrkTran
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          WrkError = True
        End If
      End With
    End If

    'Unclosed Fund Balance
    If WrkFundBal <> 0 Then
      dr = ds.Tables(0).NewRow
      dr.Item("fund") = WrkFdnbr
      dr.Item("funddesc") = GetFundDesc(WrkFdnbr)
      dr.Item("sfund") = 0
      dr.Item("acct") = ""
      dr.Item("acctdesc") = "UNCLOSED FUND BALANCE"
      dr.Item("gltyp") = "Q"
      dr.Item("gltypdesc") = GetGlTypDesc("Q")
      If WrkFundBal >= 0 Then
        dr.Item("credit") = WrkFundBal
      Else
        dr.Item("debit") = WrkFundBal * -1
      End If
      ds.Tables(0).Rows.Add(dr)
    End If

    WrkFundBal = WrkExpBal + WrkRevBal
    If WrkFundBal <> 0 Then
      With myLEDGER
        myGLACCT.GetOneRecordP(myGLFUND._FDNBRF, myGLFUND._SFUND, myGLFUND._DPNBRF, myGLFUND._OBNBRF,
         myGLFUND._FNPGMF, myGLFUND._SUBFNF)
        WrkGlTyp = myGLACCT._GLTYP
        .OvrFile = ""
        If WrkFundBal >= 0 Then
          ._AMTYP = "D"
        Else
          ._AMTYP = "C"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = WrkNextBatch
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = myGLFUND._DPNBRF
        ._FDNBR = myGLFUND._FDNBRF
        ._FIL10 = 0
        ._FIL045 = "GL802"
        ._FNPGM = myGLFUND._FNPGMF
        ._FSCYR = 0
        ._GLPST = String.Empty
        ._GLTYP = WrkGlTyp
        ._INVNR = String.Empty
        ._JRNSQ = WrkSeq
        ._OBNBR = myGLFUND._OBNBRF
        ._ORIG = 0
        ._PONBR = 0
        ._PRF = Mid(MyUserID, 1, 10)
        ._PSTDT = WrkDatePost
        ._RECLS = String.Empty
        ._REFNO = 0
        ._ROCR = String.Empty
        ._SFUND = myGLFUND._SFUND
        ._SRCDE = 2
        ._SUBFN = myGLFUND._SUBFNF
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        ._TDESC = WrkDesc
        ._TRAMT = Math.Abs(WrkFundBal)
        ._TRFTO = String.Empty
        ._TRTYP = "X"
        ._TRNBR = WrkTran
        .InsertOneRecordP()
        If .ErrMsg <> "" Then
          WriteErrorLog(.ErrMsg)
          WrkError = True
        End If
      End With
    End If

    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
  End Sub
  Private Sub DeleteLEDGER()
    Dim WrkQry As String
    Dim WrkAnd As String
    Dim WrkOr As String

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "FDNBR=" & WrkFdnbr & WrkAnd & "SFUND=" & WrkSfund & WrkAnd & "PSTDT <= " & WrkDateTo & WrkAnd &
     "TDATE<>" & MyUtils.SetDBDateMDY(Date.Today)
    myLEDGER.DeleteRecords(WrkQry)
  End Sub
  Private Function GetFundBalance(ByVal WrkFund As Integer, ByVal WrkSfund As Integer,
 ByVal WrkDept As Integer, ByVal WrkObj As Integer, ByVal WrkFnpgm As Integer,
 ByVal WrkSubfcn As Integer) As Decimal
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkBal As Decimal

    WrkBal = 0
    ds2 = myLEDGERL1.GetAllAcct(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFnpgm, WrkSubfcn, 0, WrkDateFrom)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("pstdt") >= WrkDateFrom Then Continue For
        If .Item("amtyp") = "D" Then
          WrkBal = WrkBal - .Item("tramt")
        Else
          WrkBal = WrkBal + .Item("tramt")
        End If
      End With
    Next

    Return WrkBal
  End Function
  Private Function GetActivity(ByVal WrkFund As Integer, ByVal WrkSfund As Integer,
 ByVal WrkDept As Integer, ByVal WrkObj As Integer, ByVal WrkFnpgm As Integer,
 ByVal WrkSubfcn As Integer) As Decimal
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer
    Dim WrkBal As Decimal

    WrkBal = 0
    ds2 = myLEDGERL1.GetAllAcct(WrkFund, WrkSfund, WrkDept, WrkObj, WrkFnpgm, WrkSubfcn, WrkDateFrom, WrkDateTo)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      With ds2.Tables(0).Rows(I)
        If .Item("amtyp") = "D" Then
          WrkBal = WrkBal + .Item("tramt")
        Else
          WrkBal = WrkBal - .Item("tramt")
        End If
      End With
    Next

    Return WrkBal
  End Function
  Private Sub WriteLEDHST()
    With myLEDHST
      ._AMTYP = myLEDGERQ._AMTYP
      ._AUTOG = Trim(myLEDGERQ._AUTOG)
      ._BALFC = Trim(myLEDGERQ._BALFC)
      ._BCHNO = myLEDGERQ._BCHNO
      ._CBLCD = Trim(myLEDGERQ._CBLCD)
      ._CHKN = myLEDGERQ._CHKN
      ._CNTRL = myLEDGERQ._CNTRL
      ._DATED = myLEDGERQ._DATED
      ._DPNBR = myLEDGERQ._DPNBR
      ._FDNBR = myLEDGERQ._FDNBR
      ._FIL10 = Trim(myLEDGERQ._FIL10)
      ._FIL045 = "GL802"
      ._FNPGM = myLEDGERQ._FNPGM
      ._FSCYR = myLEDGERQ._FSCYR
      ._GLPST = Trim(myLEDGERQ._GLPST)
      ._GLTYP = myLEDGERQ._GLTYP
      ._INVNR = Replace(Trim(myLEDGERQ._INVNR), "'", "''") & ""
      ._JRNSQ = myLEDGERQ._JRNSQ
      ._OBNBR = myLEDGERQ._OBNBR
      ._ORIG = myLEDGERQ._ORIG
      ._PONBR = myLEDGERQ._PONBR
      ._PRF = Trim(myLEDGERQ._PRF)
      ._PSTDT = myLEDGERQ._PSTDT
      ._RECLS = Trim(myLEDGERQ._RECLS)
      ._REFNO = myLEDGERQ._REFNO
      ._ROCR = Trim(myLEDGERQ._ROCR)
      ._SFUND = myLEDGERQ._SFUND
      ._SRCDE = Trim(myLEDGERQ._SRCDE)
      ._SUBFN = myLEDGERQ._SUBFN
      ._TDATE = myLEDGERQ._TDATE
      ._TDESC = Replace(Trim(myLEDGERQ._TDESC), "'", "''") & ""
      ._TRAMT = myLEDGERQ._TRAMT
      ._TRFTO = Trim(myLEDGERQ._TRFTO)
      ._TRTYP = myLEDGERQ._TRTYP
      ._TRNBR = myLEDGERQ._TRNBR
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        WrkError = True
      End If
    End With

  End Sub
  Private Sub WriteLEDSAVE()
    With myLEDSAVE
      ._AMTYP = myLEDGERQ._AMTYP
      ._AUTOG = Trim(myLEDGERQ._AUTOG)
      ._BALFC = Trim(myLEDGERQ._BALFC)
      ._BCHNO = myLEDGERQ._BCHNO
      ._CBLCD = Trim(myLEDGERQ._CBLCD)
      ._CHKN = myLEDGERQ._CHKN
      ._CNTRL = myLEDGERQ._CNTRL
      ._DATED = myLEDGERQ._DATED
      ._DPNBR = myLEDGERQ._DPNBR
      ._FDNBR = myLEDGERQ._FDNBR
      ._FIL10 = Trim(myLEDGERQ._FIL10)
      ._FIL045 = Trim(myLEDGERQ._FIL045)
      ._FNPGM = myLEDGERQ._FNPGM
      ._FSCYR = myLEDGERQ._FSCYR
      ._GLPST = Trim(myLEDGERQ._GLPST)
      ._GLTYP = myLEDGERQ._GLTYP
      ._INVNR = Replace(Trim(myLEDGERQ._INVNR), "'", "''") & ""
      ._JRNSQ = myLEDGERQ._JRNSQ
      ._OBNBR = myLEDGERQ._OBNBR
      ._ORIG = myLEDGERQ._ORIG
      ._PONBR = myLEDGERQ._PONBR
      ._PRF = Trim(myLEDGERQ._PRF)
      ._PSTDT = myLEDGERQ._PSTDT
      ._RECLS = Trim(myLEDGERQ._RECLS)
      ._REFNO = myLEDGERQ._REFNO
      ._ROCR = Trim(myLEDGERQ._ROCR)
      ._SFUND = myLEDGERQ._SFUND
      ._SRCDE = Trim(myLEDGERQ._SRCDE)
      ._SUBFN = myLEDGERQ._SUBFN
      ._TDATE = myLEDGERQ._TDATE
      ._TDESC = Replace(Trim(myLEDGERQ._TDESC), "'", "''") & ""
      ._TRAMT = myLEDGERQ._TRAMT
      ._TRFTO = Trim(myLEDGERQ._TRFTO)
      ._TRTYP = myLEDGERQ._TRTYP
      ._TRNBR = myLEDGERQ._TRNBR
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        WrkError = True
      End If
    End With

  End Sub
End Module
