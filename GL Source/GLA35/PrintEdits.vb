Module PrintEdits
Dim myMSCBCH As MSCBCH.myData
Dim myMSCBCHL1 As MSCBCHL1.MyData
Dim myGLACCT As GLACCT.MyData
Dim myGLFUND As GLFUND.myData
Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim dsDtl As DataSet = New DataSet
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkError As Boolean
'General
Dim FundCtl(25) As Integer
Dim FundCtlAmt(25) As Decimal
Dim SaveYear As Integer
Dim SaveDist As Integer

Public Function PrtEdits(ByVal BatchNo As Integer, ByVal Post As Boolean) As Boolean

  myMSCBCH = New MSCBCH.myData()
  myMSCBCH.MyDBConn = myDBConnect
  myMSCBCHL1 = New MSCBCHL1.MyData()
  myMSCBCHL1.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect
  myGLFUND = New GLFUND.MyData()
  myGLFUND.MyDBConn = myDBConnect

  WrkError = False
  myMSCBCHL1.SetRange(BatchNo)
  If ds.Tables.Count = 0 Then
    BuildPrtDS()
    ds2 = ds.Clone
    BuildDsDtl(dsDtl)
  Else
    ds.Clear()
    ds2.Clear()
    dsDtl.Clear()
  End If
  WriteDS(BatchNo, Post)
  myMSCBCH.GetOneRecordP(BatchNo, BatchNo, 0)

  MyFrmCr_PrtEdits = New FrmCr_PrtEdits
  MyFrmCr_PrtEdits.Wrkds = ds
  MyFrmCr_PrtEdits.Wrkds2 = ds2
  MyFrmCr_PrtEdits.WrkPost = Post
  MyFrmCr_PrtEdits.WrkError = WrkError
  MyFrmCr_PrtEdits.ShowDialog()
  'Memory Cleanup
  myMSCBCH = Nothing
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
   .Columns.Add("MSCBCHno", Type.GetType("System.Int16"))
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
Sub WriteDS(ByVal BatchNo As Integer, ByVal Post As Boolean)
 Dim WrkAcct As String
 Dim SaveBatch As Integer
 Dim SaveDate As Date
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
 Array.Clear(FundCtl, 0, 25)
 Array.Clear(FundCtlAmt, 0, 25)

 Do While Not myMSCBCHL1.IsEOF
  myMSCBCHL1.ReadFileE()
  With myMSCBCHL1
   If .IsEOF Then Exit Do
   Counter = Counter + 1
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
   dr("trntyp") = ._TRNTYP
   dr("acdate") = MyUtils.GetDBDate(._JACT8)
    If ._AMTTYP = "D" Then
      dr("debit") = ._AMT
      If ._GLTYP = "R" Then
       K = LookupFundCtl(._FDNBR)
       FundCtl(K) = ._FDNBR
       FundCtlAmt(K) = FundCtlAmt(K) - ._AMT
      End If
    Else
      dr("credit") = ._AMT
      If ._GLTYP = "R" Then
       K = LookupFundCtl(._FDNBR)
       FundCtl(K) = ._FDNBR
       FundCtlAmt(K) = FundCtlAmt(K) + ._AMT
      End If
    End If
   dr("descr") = ._DESCR
   If ._JRNSEQ > 0 Then
     WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
     dr("acct") = WrkAcct
     If Not myGLACCT.RecordNotFound Then
       dr("acctdescr") = myGLACCT._GLDSC
     Else
       dr("acctdescr") = "*** Invalid Account ***"
       WrkError = True
     End If
   End If
   dr("refno") = ._REFNO
   If Not myGLACCT.RecordNotFound Then
     dr("errmsg") = String.Empty
   Else
     dr("errmsg") = "*** Invalid Account ***"
   End If
   If ._JRNSEQ > 0 Then
    ds.Tables(0).Rows.Add(dr)
   Else
    SaveBatch = ._BCHNO
    SaveDate = MyUtils.GetDBDate(._JACT8)
    If ._TOTCR <> ._TOTDR Then WrkError = True
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

 myFrmProgress.Close()
 Application.DoEvents()

 ds2 = ds.Copy
 For I = 0 To FundCtl.GetUpperBound(0)
   myGLFUND.GetOneRecordP(FundCtl(I), 0)
   With myGLFUND
    myGLACCT.GetOneRecordP(FundCtl(I), ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
   End With

   If FundCtlAmt(I) <> 0 Then
    With myMSCBCHL1
     dr = ds2.Tables(0).NewRow
     dr("bchno") = SaveBatch
     dr("group") = "1"
     dr("trnbr") = 0
     dr("jrnseq") = 0
     dr("gltyp") = myGLACCT._GLTYP
     dr("trntyp") = "X"
     dr("acdate") = SaveDate
     If FundCtlAmt(I) > 0 Then
       dr("credit") = FundCtlAmt(I)
     Else
       dr("debit") = Math.Abs(FundCtlAmt(I))
     End If
     dr("descr") = String.Empty
     WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUND1, myGLFUND._DPNBR1, myGLFUND._OBNBR1, _
      myGLFUND._FNPGM1, myGLFUND._SUBFN1)
     dr("acct") = WrkAcct
     dr("acctdescr") = myGLACCT._GLDSC
     dr("refno") = 0
     dr("errmsg") = String.Empty
     ds2.Tables(0).Rows.Add(dr)
    End With
   End If
 Next

 myMSCBCHL1.CloseFile()
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

End Function
End Module
