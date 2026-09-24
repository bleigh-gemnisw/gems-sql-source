Module PrintEdits
Dim myGLRBCH As GLRBCH.myData
Dim myGLACCT As GLACCT.myData
Dim myGLFUND As GLFUND.myData
Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dsDtl As DataSet = New DataSet
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkError As Boolean
  'General
  Dim FundCtl(100) As Integer
  Dim FundCtlType(100) As String
  Dim FundCtlAmt(100) As Decimal
  Dim SaveYear As Integer
  Dim SaveDist As Integer

  Public Function PrtEdits(ByVal BatchNo As Integer, ByVal PostDate As Integer, ByVal Post As Boolean) As Boolean

    myGLRBCH = New GLRBCH.MyData()
    myGLRBCH.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect

    WrkError = False
    myGLRBCH.SetRange(BatchNo)
    If ds.Tables.Count = 0 Then
      BuildPrtDS()
      ds2 = ds.Clone
      BuildDsDtl(dsDtl)
    Else
      ds.Clear()
      ds2.Clear()
      dsDtl.Clear()
    End If
    WriteDS(BatchNo, PostDate, Post)
    myGLRBCH.GetOneRecordP(BatchNo, 0, 0)

    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.Wrkds2 = ds2
    MyFrmCr_PrtEdits.WrkPost = Post
    MyFrmCr_PrtEdits.WrkError = WrkError
    MyFrmCr_PrtEdits.ShowDialog()
    'Memory Cleanup
    myGLRBCH = Nothing
    Return WrkError

  End Function
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("TrNbr", Type.GetType("System.Int32"))
      .Columns.Add("JrnSeq", Type.GetType("System.Int32"))
      .Columns.Add("TrnTyp", Type.GetType("System.String"))
      .Columns.Add("GLTyp", Type.GetType("System.String"))
      .Columns.Add("AcDate", Type.GetType("System.DateTime"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDescr", Type.GetType("System.String"))
      .Columns.Add("RefNo", Type.GetType("System.Int32"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDsDtl(ByRef DsDtl As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("Trnbr", Type.GetType("System.Int16"))
      .Columns.Add("Seqno", Type.GetType("System.Int16"))
      .Columns.Add("Dist", Type.GetType("System.Int16"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int16"))
      .Columns.Add("Susp", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
    End With
    DsDtl.Tables.Add(myTable)
  End Sub
  Sub WriteDS(ByVal BatchNo As Integer, ByVal PostDate As Integer, ByVal Post As Boolean)
    Dim WrkTotCr As Decimal
    Dim WrkTotDr As Decimal
    Dim WrkAcct As String
    Dim SaveBatch As Integer
    Dim SaveTrnbr As Integer
    Dim SaveJrnSeq As Integer
    Dim SaveDate As Date
    Dim SaveTrntyp As String
    Dim Counter As Integer
    Dim dr As Data.DataRow
    Dim I As Integer
    Dim K As Integer

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
    SaveYear = 0
    SaveDist = 0
    WrkTotCr = 0
    WrkTotDr = 0
    Array.Clear(FundCtl, 0, 100)
    Array.Clear(FundCtlType, 0, 100)
    Array.Clear(FundCtlAmt, 0, 100)

    Do While Not myGLRBCH.IsEOF
      myGLRBCH.ReadFileE()
      With myGLRBCH
        If .IsEOF Then Exit Do
        Counter = Counter + 1
        If SaveTrnbr > 0 And SaveTrnbr <> ._TRNBR Then
          If WrkTotDr <> WrkTotCr Then
            dr = ds.Tables(0).NewRow
            dr("bchno") = ._BCHNO
            dr("trnbr") = SaveTrnbr
            dr("jrnseq") = SaveJrnSeq
            dr("errmsg") = "*** Transaction " & SaveTrnbr & " is not balanced ***"
            ds.Tables(0).Rows.Add(dr)
            WrkError = True
          End If
          WrkTotDr = 0
          WrkTotCr = 0
        End If
        myGLACCT.GetOneRecordP(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        dr = ds.Tables(0).NewRow
        dr("bchno") = ._BCHNO
        If ._GLTYP <> "R" Then
          dr("group") = "1"
        Else
          dr("group") = "2"
        End If
        dr("trnbr") = ._TRNBR
        dr("jrnseq") = ._JRNSEQ
        dr("gltyp") = ._GLTYP
        SaveTrnbr = ._TRNBR
        SaveJrnSeq = ._JRNSEQ
        SaveTrntyp = ._TRNTYP
        Select Case ._TRNTYP
          Case "T"
            dr("trntyp") = "B"
          Case "Z"
            dr("trntyp") = "B"
          Case Else
            dr("trntyp") = ._TRNTYP
        End Select
        dr("acdate") = MyUtils.GetDBDateMDY(PostDate)
        If ._AMTTYP = "D" Then
          dr("debit") = ._AMT
          If SaveTrntyp = "T" Or ._TRNTYP = "X" Then
            WrkTotDr = WrkTotDr + ._AMT
          End If
          If ._GLTYP = "R" And ._TRNTYP <> "T" And ._TRNTYP <> "Z" Or ._GLTYP = "X" And ._TRNTYP <> "T" And ._TRNTYP <> "Z" Then
            K = LookupFundCtl(._FDNBR, ._GLTYP)
            FundCtl(K) = ._FDNBR
            FundCtlType(K) = ._GLTYP
            If FundCtlType(K) = "R" Then
              FundCtlAmt(K) = FundCtlAmt(K) - ._AMT
            Else
              FundCtlAmt(K) = FundCtlAmt(K) + ._AMT
            End If
          End If
        Else
          dr("credit") = ._AMT
          If SaveTrntyp = "T" Or ._TRNTYP = "X" Then
            WrkTotCr = WrkTotCr + ._AMT
          End If
          If ._GLTYP = "R" And ._TRNTYP <> "T" And ._TRNTYP <> "Z" Or ._GLTYP = "X" And ._TRNTYP <> "T" And ._TRNTYP <> "Z" Then
            K = LookupFundCtl(._FDNBR, ._GLTYP)
            FundCtl(K) = ._FDNBR
            FundCtlType(K) = ._GLTYP
            If FundCtlType(K) = "R" Then
              FundCtlAmt(K) = FundCtlAmt(K) + ._AMT
            Else
              FundCtlAmt(K) = FundCtlAmt(K) - ._AMT
            End If
          End If
        End If
        dr("descr") = ._DESCR
        If ._JRNSEQ > 0 Then
          WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr("acct") = WrkAcct
          If myGLACCT.RecordNotFound Then
            dr("acctdescr") = "*** Invalid Account ***"
            dr("errmsg") = "*** Invalid Account ***"
            WrkError = True
          Else
            dr("acctdescr") = myGLACCT._GLDSC
            If myGLACCT._ACREC = "I" Then
              dr("acctdescr") = "*** Inactive Account ***"
              dr("errmsg") = "*** Inactive Account ***"
              WrkError = True
            End If
            If myGLACCT._GLTYP = "H" Then
              dr("acctdescr") = "*** Header Account ***"
              dr("errmsg") = "*** Header Account ***"
              WrkError = True
            End If
          End If
        End If
        dr("refno") = ._REFNO
        SaveBatch = ._BCHNO
        If ._JRNSEQ > 0 Then
          ds.Tables(0).Rows.Add(dr)
          SaveDate = MyUtils.GetDBDateMDY(PostDate)
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

    If WrkTotDr <> WrkTotCr Then
      dr = ds.Tables(0).NewRow
      dr("bchno") = SaveBatch
      dr("trnbr") = SaveTrnbr
      dr("jrnseq") = SaveJrnSeq
      dr("errmsg") = "*** Transaction " & SaveTrnbr & " is not balanced ***"
      ds.Tables(0).Rows.Add(dr)
      WrkError = True
    End If
    myFrmProgress.Close()
    Application.DoEvents()

    If WrkTotCr <> WrkTotDr Then WrkError = True

    ds2 = ds.Copy
    For I = 0 To FundCtl.GetUpperBound(0)
      myGLFUND.GetOneRecordP(FundCtl(I), 0)
      With myGLFUND
        If FundCtlType(I) = "R" Then
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
        Else
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
        End If
      End With

      If FundCtlAmt(I) <> 0 Then
        With myGLRBCH
          dr = ds2.Tables(0).NewRow
          dr("bchno") = SaveBatch
          dr("group") = "1"
          dr("trnbr") = 0
          dr("jrnseq") = 0
          dr("gltyp") = myGLACCT._GLTYP
          dr("trntyp") = "X"
          dr("acdate") = SaveDate
          dr("descr") = String.Empty
          If FundCtlType(I) = "R" Then
            If FundCtlAmt(I) > 0 Then
              dr("credit") = FundCtlAmt(I)
            Else
              dr("debit") = Math.Abs(FundCtlAmt(I))
            End If
            WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND1, myGLFUND._DPNBR1, myGLFUND._OBNBR1,
        myGLFUND._FNPGM1, myGLFUND._SUBFN1)
          Else
            If FundCtlAmt(I) > 0 Then
              dr("debit") = FundCtlAmt(I)
            Else
              dr("credit") = Math.Abs(FundCtlAmt(I))
            End If
            WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND2, myGLFUND._DPNBR2, myGLFUND._OBNBR2,
        myGLFUND._FNPGM2, myGLFUND._SUBFN2)
          End If
          dr("acct") = WrkAcct
          dr("acctdescr") = myGLACCT._GLDSC
          dr("refno") = 0
          dr("errmsg") = String.Empty
          ds2.Tables(0).Rows.Add(dr)
        End With
      End If
    Next

    myGLRBCH.CloseFile()
  End Sub
  Private Function LookupFundCtl(ByVal Fund As Integer, ByVal Gltyp As String) As Integer
    Dim I As Integer

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtl(I) = 0 Then
        Return I
      End If
      If Fund = FundCtl(I) And Gltyp = FundCtlType(I) Then
        Return I
      End If
    Next

  End Function
End Module
