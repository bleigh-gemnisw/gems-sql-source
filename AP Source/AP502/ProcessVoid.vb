Imports System.Text
Module ProcessVoid
  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEHSTQ As APEHSTQ.MyData
  Dim myAPEHST As APEHST.MyData
  Dim myAPEBNK As APEBNK.MyData
  Dim myAPERCN As APERCN.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim ds As DataSet = New DataSet
  Dim vds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim rpds As DataSet = New DataSet
  Dim Wrkpdate As Integer
  Dim WrkCheckFrom As Integer
  Dim WrkCheckTo As Integer
  Dim WrkBank As String
  Dim WrkPrData As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Dim wrkpostdateMDY As String
  Dim wrkpostdate As Integer
  Friend passpostdate As Date
  Public Sub DoVoid()
    Dim Answer As Integer
    WrkAnd = " and "
    WrkOr = " or "
    myAPEHSTQ = New APEHSTQ.MyData
    myAPEHSTQ.MyDBConn = myDBConnect
    myAPEHST = New APEHST.MyData
    myAPEHST.MyDBConn = myDBConnect
    myAPERCN = New APERCN.MyData()
    myAPERCN.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect
    myAPEBNK = New APEBNK.MyData()
    myAPEBNK.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect

    'Dates PAssed
    Wrkpdate = MyUtils.SetDBDate(passpostdate)
    wrkpostdateMDY = passpostdate.ToString("MMddyyyy")
    wrkpostdate = Wrkpdate
    With MyFrmAP502B
      WrkBank = .TxtBank.Text
      WrkCheckFrom = MyUtils.CnvSng(.TxtChkFrom.Text)
      WrkCheckTo = MyUtils.CnvSng(.TxtChkTo.Text)
      If WrkCheckTo = 0 Then
        WrkCheckTo = WrkCheckFrom
      End If
    End With

    CreateLedbch()   'AP5032R
    editbatchprint() 'ELEDBCHR 
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .ds = vds
      .ds2 = rpds
      .plistonly = " "
      .mypostingdate = MyFrmAP502B.DtPckpdate.Value
      .ShowDialog()
    End With

    If vds.Tables(0).Rows.Count > 0 Then
      Answer = MsgBox("Reports cannot be rerun once void has completed. Continue processing void?", MsgBoxStyle.YesNo, "Report print confirmation")
      If Answer = vbYes Then
        DoPost() 'Post to files
      End If
    End If

    myAPEBNK = Nothing
    myAPEHST = Nothing
    myAPEHSTQ = Nothing
    myGLFUND = Nothing
    myGLACCT = Nothing
    myVENDOR = Nothing
    myAPERCN = Nothing
    myLEDGER = Nothing
  End Sub
  Private Sub DoPost()
    Dim I As Integer
    Dim pyear As Integer
    Dim pmo As Integer
    Dim mydate As String
    Dim Counter As Integer
    Counter = 0
    myFrmProgress = New FrmProgress
    myFrmProgress.Text = "Void - Posting to Ledger"

    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect
    For I = 0 To vds.Tables(0).Rows.Count - 1
      'CHECK RECON FILE MARK AS VOIDED 
      myAPERCN.GetOneRecordP(WrkBank, vds.Tables(0).Rows(I).Item("checkno"))
      If Not myAPEBNK.RecordNotFound Then
        myAPERCN._RCCDE = "V"
        myAPERCN._PAYC8 = wrkpostdate
        myAPERCN._BANKRP = "1"
        myAPERCN.UpdateOneRecordP()
      End If
      voidhistrec(WrkBank, vds.Tables(0).Rows(I).Item("checkno"))
    Next

    For I = 0 To ds.Tables(0).Rows.Count - 1
      Counter = Counter + 1
      mydate = ds.Tables(0).Rows(I).Item("pstdt").ToString()
      pyear = mydate.Substring(0, 4)
      pmo = mydate.Substring(4, 2)
      WriteLEDGER(I, pmo, pyear)       ' NOTE  UNCOMMENT OUT add of record
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
    Next
    myFrmProgress.Close()
  End Sub
  Private Sub WriteLEDGER(ByVal i As Integer, ByVal wrkmonth As Integer, ByVal wrkyear As Integer)
    With myLEDGER
      ._AMTYP = ds.Tables(0).Rows(i).Item("AMTYP")
      ._AUTOG = String.Empty
      ._BALFC = String.Empty
      ._BCHNO = ds.Tables(0).Rows(i).Item("BCHNO")
      ._CBLCD = String.Empty
      ._CHKN = ds.Tables(0).Rows(i).Item("CHKN")
      ._CNTRL = 0
      ._DATED = MyUtils.SetDBDateMDY(Date.Today)
      ._DPNBR = ds.Tables(0).Rows(i).Item("DPNBR")
      ._FDNBR = ds.Tables(0).Rows(i).Item("FDNBR")
      If ds.Tables(0).Rows(i).Item("GLTYP") = "Q" Then
        ._FIL10 = 9999999999
      Else
        ._FIL10 = 0
      End If
      ._FIL045 = ""
      ._FNPGM = ds.Tables(0).Rows(i).Item("FNPGM")
      ._FSCYR = 0
      ._GLPST = ds.Tables(0).Rows(i).Item("GLPST")
      ._GLTYP = ds.Tables(0).Rows(i).Item("GLTYP")
      ._INVNR = ds.Tables(0).Rows(i).Item("INVNR")
      ._JRNSQ = 0
      ._OBNBR = ds.Tables(0).Rows(i).Item("OBNBR")
      ._ORIG = 0
      ._PONBR = 0
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = ds.Tables(0).Rows(i).Item("PSTDT")
      ._RECLS = String.Empty
      ._REFNO = ds.Tables(0).Rows(i).Item("REFNO")
      ._ROCR = String.Empty
      ._SFUND = ds.Tables(0).Rows(i).Item("SFUND")
      ._SRCDE = ds.Tables(0).Rows(i).Item("SRCDE")
      ._SUBFN = ds.Tables(0).Rows(i).Item("SUBFN")
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      ._TDESC = ds.Tables(0).Rows(i).Item("TDESC")
      ._TRAMT = ds.Tables(0).Rows(i).Item("TRAMT")
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = ds.Tables(0).Rows(i).Item("TRTYP")
      .InsertOneRecordP()
      If .ErrMsg <> "" Then
        WriteErrorLog(.ErrMsg)
        Application.Exit()
      End If
    End With
  End Sub
  Private Sub editbatchprint()
    Dim RPdr As Data.DataRow
    Dim i As Integer
    Dim workamt As Double
    Dim NOGL As Boolean

    If rpds.Tables.Count = 0 Then
      BuildRPDS()
    Else
      rpds.Clear()
    End If
    i = 0
    workamt = 0
    For Each row As DataRow In ds.Tables("mytable").Rows
      NOGL = False
      RPdr = rpds.Tables(0).NewRow
      myGLACCT.GetOneRecordP(ds.Tables(0).Rows(i).Item("fdnbr"), ds.Tables(0).Rows(i).Item("SFUND"), ds.Tables(0).Rows(i).Item("DPNBR"), ds.Tables(0).Rows(i).Item("OBNBR"), ds.Tables(0).Rows(i).Item("FNPGM"), ds.Tables(0).Rows(i).Item("SUBFN"))
      If myGLACCT.RecordNotFound = True Then NOGL = True

      RPdr.Item("acct") = Buildacct(ds.Tables(0).Rows(i).Item("fdnbr"), ds.Tables(0).Rows(i).Item("SFUND"), ds.Tables(0).Rows(i).Item("DPNBR"), ds.Tables(0).Rows(i).Item("OBNBR"), ds.Tables(0).Rows(i).Item("FNPGM"), ds.Tables(0).Rows(i).Item("SUBFN"))
      Select Case NOGL
        Case True
          RPdr.Item("desc") = "  * * INVALID ACCOUNT * * "
          RPdr.Item("actyp") = " "
          RPdr.Item("errorfound") = "ERROR"
        Case False
          RPdr.Item("desc") = myGLACCT._GLDSC
          RPdr.Item("actyp") = myGLACCT._GLTYP
          RPdr.Item("errorfound") = " "
      End Select
      workamt = ds.Tables(0).Rows(i).Item("tramt")

      If workamt < 0 Then workamt = workamt * -1
      Select Case ds.Tables(0).Rows(i).Item("amtyp")
        Case "D"
          RPdr.Item("damount") = workamt
          RPdr.Item("camount") = 0
        Case "C"
          RPdr.Item("camount") = workamt
          RPdr.Item("damount") = 0
      End Select
      RPdr.Item("trtyp") = ds.Tables(0).Rows(i).Item("trtyp")
      rpds.Tables(0).Rows.Add(RPdr)
      i = i + 1
    Next
  End Sub
  Private Sub CreateLedbch()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim i As Integer
    Dim save_vname As String
    Dim eamt As Double
    Dim ramt As Double
    eamt = 0
    ramt = 0
    save_vname = ""
    Counter = 0
    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    If vds.Tables.Count = 0 Then
      BuildvoidDS()
    Else
      vds.Clear()
    End If
    '------------------------------------------------------
    i = 0

    'read apehst bank and check
    WrkSort = "BNKCD, CHKPD"
    WrkQry = "BNKCD = " & MyUtils.Quo(WrkBank) & WrkAnd & "CHKPD >= " & WrkCheckFrom &
    WrkAnd & "CHKPD <= " & WrkCheckTo & " and AVOID <> 'V'"
    myAPEHSTQ.OpenQry(WrkSort, WrkQry)
ReadNext:
    myAPEHSTQ.ReadQry()    ' read all bnk/chk from history
    If Not myAPEHSTQ.IsEOF Then
      With myAPEHSTQ
        Counter = Counter + 1
        myAPEBNK.GetOneRecordP(WrkBank)
        ' hold vend name from rec 0
        If ._RECNO = 0 Then
          save_vname = Trim(._VENNM)
          save_vname = Replace(save_vname, "'", "''")
          dr = vds.Tables(0).NewRow
          dr.Item("PAYBN") = Trim(WrkBank)
          dr.Item("BANKNAME") = Trim(myAPEBNK._BNKNM)
          dr.Item("CHECKNO") = ._CHKPD
          dr.Item("CHECKDATE") = MyUtils.GetDBDate(._PPDT8)
          dr.Item("VOIDDATE") = MyUtils.GetDBDate(Wrkpdate)
          dr.Item("AMOUNT") = ._AMTPD
          dr.Item("VNAME") = Trim(._VENNM)
          vds.Tables(0).Rows.Add(dr)
          GoTo ReadNext
        End If

        ' CREDIT EXPENSE AND DEBIT CASH AND CREDIT EXPENSE CONTROL
        If ._RECNO <> 0 Then
          myGLFUND.GetOneRecordP(._FDNBR, ._SFUND)
          myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr = ds.Tables(0).NewRow
          dr.Item("fdnbr") = ._FDNBR
          dr.Item("sfund") = ._SFUND
          dr.Item("dpnbr") = ._DPNBR
          dr.Item("obnbr") = ._OBNBR
          dr.Item("fnpgm") = ._FNPGM
          dr.Item("subfn") = ._SUBFN
          dr.Item("bchno") = ._BCHNO
          dr.Item("invnr") = ._INVNO
          dr.Item("gltyp") = myGLACCT._GLTYP
          If ._AMTGR > 0 Then
            dr.Item("amtyp") = "C"
          Else
            dr.Item("amtyp") = "D"
          End If
          dr.Item("glpst") = ""
          dr.Item("tdesc") = Mid(save_vname, 1, 15) + " VOID"
          dr.Item("tramt") = Math.Abs(._AMTGR)
          dr.Item("refno") = ._CHKPD
          dr.Item("chkn") = ._CHKPD
          dr.Item("pstdt") = wrkpostdate
          dr.Item("trtyp") = "X"
          dr.Item("srcde") = 1
          ds.Tables(0).Rows.Add(dr)

          'Cash Account
          dr = ds.Tables(0).NewRow
          dr.Item("fdnbr") = myGLFUND._FDNBRC
          dr.Item("sfund") = myGLFUND._SFUNDC
          dr.Item("dpnbr") = myGLFUND._DPNBRC
          dr.Item("obnbr") = myGLFUND._OBNBRC
          dr.Item("fnpgm") = myGLFUND._FNPGMC
          dr.Item("subfn") = myGLFUND._SUBFNC
          dr.Item("bchno") = ._BCHNO
          dr.Item("invnr") = ._INVNO
          dr.Item("gltyp") = "A"
          If ._AMTGR > 0 Then
            dr.Item("amtyp") = "D"
          Else
            dr.Item("amtyp") = "C"
          End If
          dr.Item("glpst") = ""
          dr.Item("tdesc") = Mid(save_vname, 1, 15) + " VOID"
          dr.Item("tramt") = Math.Abs(._AMTGR)
          dr.Item("refno") = ._CHKPD
          dr.Item("chkn") = ._CHKPD
          dr.Item("pstdt") = wrkpostdate
          dr.Item("trtyp") = "X"
          dr.Item("srcde") = 1
          ds.Tables(0).Rows.Add(dr)

          If myGLACCT._GLTYP = "X" Then eamt = ._AMTGR
          If myGLACCT._GLTYP = "R" Then ramt = ._AMTGR
          If eamt = 0 And ramt = 0 Then GoTo bypassme

          ' EXPENSE/REVENUE CONTROL
          dr = ds.Tables(0).NewRow
            If eamt <> 0 Then
              dr.Item("fdnbr") = myGLFUND._FDNBR2
              dr.Item("sfund") = myGLFUND._SFUND2
              dr.Item("dpnbr") = myGLFUND._DPNBR2
              dr.Item("obnbr") = myGLFUND._OBNBR2
              dr.Item("fnpgm") = myGLFUND._FNPGM2
              dr.Item("subfn") = myGLFUND._SUBFN2
            End If
            If ramt <> 0 Then
              dr.Item("fdnbr") = myGLFUND._FDNBR1
              dr.Item("sfund") = myGLFUND._SFUND1
              dr.Item("dpnbr") = myGLFUND._DPNBR1
              dr.Item("obnbr") = myGLFUND._OBNBR1
              dr.Item("fnpgm") = myGLFUND._FNPGM1
              dr.Item("subfn") = myGLFUND._SUBFN1
            End If
            dr.Item("bchno") = ._BCHNO
            dr.Item("invnr") = ._INVNO
            dr.Item("gltyp") = "Q"
            If eamt > 0 Or ramt > 0 Then
              dr.Item("amtyp") = "C"
            Else
              dr.Item("amtyp") = "D"
            End If
            dr.Item("glpst") = ""
            dr.Item("tdesc") = Mid(save_vname, 1, 15) + " VOID"
            dr.Item("tramt") = Math.Abs(._AMTGR)
            dr.Item("refno") = ._CHKPD
            dr.Item("chkn") = ._CHKPD
            dr.Item("pstdt") = wrkpostdate
            dr.Item("trtyp") = "X"
            dr.Item("srcde") = 1
            ds.Tables(0).Rows.Add(dr)
            eamt = 0
            ramt = 0
bypassme:  ' no GLACCT record
            '-----------------------------------------------------------------------------
          End If ' recno <> 0
      End With

NextRec:

      GoTo ReadNext
    End If ' record not found
  End Sub
  Private Sub voidhistrec(ByVal wrkbank As String, ByVal WrkCheck As Integer)
    Dim wrkset As String
    Dim wrkwhere As String
    wrkset = "Set avoid = 'V'"
    wrkwhere = "Where BNKCD = " & MyUtils.Quo(wrkbank) & WrkAnd & "CHKPD = " & WrkCheck
    myAPEHST.RunUpdateQuery(wrkset, wrkwhere)
  End Sub
  Private Sub BuildvoidDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("PAYBN", Type.GetType("System.String"))
      .Columns.Add("BANKNAME", Type.GetType("System.String"))
      .Columns.Add("CHECKNO", Type.GetType("System.Int32"))
      .Columns.Add("CHECKDATE", Type.GetType("System.DateTime"))
      .Columns.Add("VOIDDATE", Type.GetType("System.DateTime"))
      .Columns.Add("AMOUNT", Type.GetType("System.Decimal"))
      .Columns.Add("VNAME", Type.GetType("System.String"))
    End With
    vds.Tables.Add(myTable)
  End Sub
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
      .Columns.Add("ACCT", Type.GetType("System.String"))
      .Columns.Add("DESC", Type.GetType("System.String"))
      .Columns.Add("ACTYP", Type.GetType("System.String"))
      .Columns.Add("TRTYP", Type.GetType("System.String"))
      .Columns.Add("DAMOUNT", Type.GetType("System.Decimal"))
      .Columns.Add("CAMOUNT", Type.GetType("System.Decimal"))

      .Columns.Add("ERRORFOUND", Type.GetType("System.String"))
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
End Module
