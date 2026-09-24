Module PrintEdits
Dim myRQEBCHQ As RQEBCHQ.myData
Dim myRQEBCH As RQEBCH.MyData
Dim myBCHHDR As BCHHDR.MyData
Dim myRQEBCDL1 As RQEBCDL1.MyData
Dim myGLACCT As GLACCT.MyData
Dim myGLFUND As GLFUND.myData
Dim myVENDOR As VENDOR.MyData
Dim myPURCTL As PURCTL.MyData
Dim myPURCTLL1 As PURCTLL1.MyData
Dim ds As DataSet = New DataSet
Dim ds2 As DataSet = New DataSet
Dim ds3 As DataSet = New DataSet
Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim WrkError As Boolean
'General
Dim FundCtl(100) As Integer
Dim FundCtlAmt(100) As Decimal
Dim SaveYear As Integer
Dim SaveDist As Integer

Public Function PrtEdits(ByVal Llocn As String, ByVal BatchNo As Integer, ByVal Post As Boolean) As Boolean

  myRQEBCHQ = New RQEBCHQ.MyData()
  myRQEBCHQ.MyDBConn = myDBConnect
  myRQEBCH = New RQEBCH.MyData()
  myRQEBCH.MyDBConn = myDBConnect
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myRQEBCDL1 = New RQEBCDL1.MyData()
  myRQEBCDL1.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect
  myGLFUND = New GLFUND.MyData()
  myGLFUND.MyDBConn = myDBConnect
  myVENDOR = New VENDOR.MyData()
  myVENDOR.MyDBConn = myDBConnect
  myPURCTL = New PURCTL.MyData()
  myPURCTL.MyDBConn = myDBConnect
  myPURCTLL1 = New PURCTLL1.MyData()
  myPURCTLL1.MyDBConn = myDBConnect

  WrkError = False
  If ds.Tables.Count = 0 Then
    BuildDS()
    BuildDs2()
    BuildDs3()
  Else
    ds.Clear()
    ds2.Clear()
    ds3.Clear()
  End If
  WriteDS(Llocn, BatchNo, Post)
  myRQEBCH.GetOneRecordP(Llocn, BatchNo, 0)

  MyFrmCr_PrtEdits = New FrmCr_PrtEdits
  MyFrmCr_PrtEdits.Wrkds = ds
  MyFrmCr_PrtEdits.Wrkds2 = ds2
  MyFrmCr_PrtEdits.Wrkds3 = ds3
  MyFrmCr_PrtEdits.WrkBatch = BatchNo
  MyFrmCr_PrtEdits.WrkPost = Post
  MyFrmCr_PrtEdits.WrkError = WrkError
  MyFrmCr_PrtEdits.ShowDialog()
  'Memory Cleanup
  myRQEBCH = Nothing
  Return WrkError

End Function
  Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Llocn", Type.GetType("System.String"))
      .Columns.Add("BchNo", Type.GetType("System.Int32"))
      .Columns.Add("RqNbr", Type.GetType("System.Int32"))
      .Columns.Add("RqDate", Type.GetType("System.DateTime"))
      .Columns.Add("Vendor", Type.GetType("System.String"))
      .Columns.Add("Vennm", Type.GetType("System.String"))
      .Columns.Add("Sname", Type.GetType("System.String"))
      .Columns.Add("Sadr1", Type.GetType("System.String"))
      .Columns.Add("Sadr2", Type.GetType("System.String"))
      .Columns.Add("Sadr3", Type.GetType("System.String"))
      .Columns.Add("Sadr4", Type.GetType("System.String"))
      .Columns.Add("Szip", Type.GetType("System.String"))
      .Columns.Add("Szipe", Type.GetType("System.String"))
      .Columns.Add("Rname", Type.GetType("System.String"))
      .Columns.Add("Radr1", Type.GetType("System.String"))
      .Columns.Add("Radr2", Type.GetType("System.String"))
      .Columns.Add("Radr3", Type.GetType("System.String"))
      .Columns.Add("Radr4", Type.GetType("System.String"))
      .Columns.Add("Rzip", Type.GetType("System.String"))
      .Columns.Add("Rzipe", Type.GetType("System.String"))
      .Columns.Add("Ordsp", Type.GetType("System.Decimal"))
      .Columns.Add("AcctDisc", Type.GetType("System.String"))
      .Columns.Add("Orshp", Type.GetType("System.Decimal"))
      .Columns.Add("AcctShip", Type.GetType("System.String"))
      .Columns.Add("TotAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Discount", Type.GetType("System.Decimal"))
      .Columns.Add("Shipping", Type.GetType("System.Decimal"))
      .Columns.Add("TotNet", Type.GetType("System.Decimal"))
      .Columns.Add("RqSeq", Type.GetType("System.Int32"))
      .Columns.Add("Itnbr", Type.GetType("System.String"))
      .Columns.Add("Itdsc", Type.GetType("System.String"))
      .Columns.Add("RqQty", Type.GetType("System.Int32"))
      .Columns.Add("Unitp", Type.GetType("System.Decimal"))
      .Columns.Add("Exval", Type.GetType("System.Decimal"))
      .Columns.Add("Unmsr", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Public Sub BuildDs2()
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
    .Columns.Add("AcctDescr", Type.GetType("System.String"))
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
Sub WriteDS(ByVal WrkLlocn As String, WrkBatch As Integer, ByVal Post As Boolean)
 Dim dsFile As DataSet = New DataSet
 Dim WrkAcct As String
 Dim SaveBatch As Integer
 Dim SaveDate As Date
 Dim Counter As Integer
 Dim dr As Data.DataRow
 Dim WrkAnd As String
 Dim WrkOr As String
 Dim WrkQry As String
 Dim WrkSort As String
 Dim WrkBal As Decimal
 Dim WrkDateFrom As Integer
 Dim WrkDateTo As Integer
 Dim I As Integer
 Dim K As Integer

 WrkAnd = " and "
 WrkOr = " or "
 WrkQry = "BCHNO = " & WrkBatch
 WrkSort = ""
 myRQEBCHQ.OpenQry(WrkSort, WrkQry)

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
 Array.Clear(FundCtl, 0, 100)
 Array.Clear(FundCtlAmt, 0, 100)

ReadNext:
 myRQEBCHQ.ReadQry()
 If Not myRQEBCHQ.IsEOF Then
  With myRQEBCHQ
  If WrkDateFrom = 0 Then
    MyFiscyr = ._FSCYR
    With myPURCTL
      .GetOneRecordP(MyFiscyr)
      If Not .RecordNotFound Then
        WrkDateFrom = ._FSCS8
        WrkDateTo = ._FSCE8
      End If
    End With
   End If

   Counter = Counter + 1
   dsFile = myRQEBCDL1.GetViewbyRqnbr(WrkLlocn, WrkBatch, ._RQNBR, 0)
   For I = 0 To dsFile.Tables(0).Rows.Count - 1
     dr = ds.Tables(0).NewRow
     dr("llocn") = WrkLlocn
     dr("bchno") = WrkBatch
     myBCHHDR.GetOneRecordP(MyBatch, WrkBatch)
     dr("rqnbr") = ._RQNBR
     dr("rqdate") = MyUtils.GetDBDate(._RENTD)
     dr("vendor") = ._VNDNR
     dr("vennm") = ._VENNM
     dr("sname") = ._SNAME
     dr("sadr1") = ._SADR1
     dr("sadr2") = ._SADR2
     dr("sadr3") = ._SADR3
     dr("sadr4") = ._SADR4
     dr("szip") = ._SZIP
     dr("szipe") = ._SZIPE
     dr("rname") = ._RNAME
     dr("radr1") = ._RADR1
     dr("radr2") = ._RADR2
     dr("radr3") = ._RADR3
     dr("radr4") = ._RADR4
     dr("rzip") = ._RZIP
     dr("rzipe") = ._RZIPE
     dr("ordsp") = ._ORDSP
     WrkAcct = BuildAcct(._FDNBD, ._SFUDD, ._DPNBD, ._OBNBD, ._FNPGD, ._SUBFD)
     dr("acctdisc") = WrkAcct
     dr("orshp") = ._ORSHP
     WrkAcct = BuildAcct(._FDNBS, ._SFUNS, ._DPNBS, ._OBNBS, ._FNPGS, ._SUBFS)
     dr("acctship") = WrkAcct
     dr("totamt") = ._AMTGR
     dr("discount") = ._DSCDL
     dr("shipping") = ._SHPDL
     dr("totnet") = ._AMTNT
     With dsFile.Tables(0).Rows(I)
       dr("rqseq") = .Item("rqseq")
       dr("itnbr") = .Item("itnbr")
       dr("itdsc") = .Item("itdsc")
       dr("rqqty") = .Item("rqqty")
       dr("unitp") = .Item("unitp")
       dr("exval") = .Item("exval")
       dr("unmsr") = .Item("unmsr")
       If .Item("FDNBR") > 0 Then
         myGLACCT.GetOneRecordP(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), .Item("FNPGM"), .Item("SUBFN"))
         WrkAcct = BuildAcct(.Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), .Item("FNPGM"), .Item("SUBFN"))
         dr("acct") = WrkAcct
         If Not myGLACCT.RecordNotFound Then
           dr("acctdesc") = myGLACCT._GLDSC
         Else
           dr("acctdesc") = "*** Invalid Account ***"
           WrkError = True
         End If
       Else
         dr("acctdesc") = ""
       End If
     End With
     ds.Tables(0).Rows.Add(dr)

     If dsFile.Tables(0).Rows(I).Item("FDNBR") > 0 Then
       dr = ds2.Tables(0).NewRow
       dr("bchno") = WrkBatch
       dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
       dr("fund") = dsFile.Tables(0).Rows(I).Item("FDNBR")
       dr("group") = "2"
       dr("gltyp") = myGLACCT._GLTYP
       dr("trntyp") = "E"
       With dsFile.Tables(0).Rows(I)
         If .Item("exval") > 0 Then
           dr("debit") = .Item("exval")
         Else
           dr("credit") = .Item("exval")
         End If
         K = LookupFundCtl(.Item("FDNBR"))
         FundCtl(K) = .Item("FDNBR")
         FundCtlAmt(K) = FundCtlAmt(K) + .Item("exval")
       End With
       dr("acct") = WrkAcct
       If Not myGLACCT.RecordNotFound Then
         dr("acctdescr") = myGLACCT._GLDSC
       Else
         dr("acctdescr") = "*** Invalid Account ***"
         WrkError = True
       End If
       ds2.Tables(0).Rows.Add(dr)

       With dsFile.Tables(0).Rows(I)
         WrkBal = GetAcctBal(myGLACCT._GLTYP, .Item("FDNBR"), .Item("SFUND"), .Item("DPNBR"), .Item("OBNBR"), _
          .Item("FNPGM"), .Item("SUBFN"), WrkDateFrom, WrkDateTo)
       End With
       If WrkBal < 0 Then
         dr = ds3.Tables(0).NewRow
         dr("bchno") = WrkBatch
         dr("bchdate") = MyUtils.GetDBDate(myBCHHDR._PSDT)
         dr("acct") = WrkAcct
         dr("acctdescr") = myGLACCT._GLDSC
         dr("errmsg") = WrkBal & " " & WrkDateFrom
         ds3.Tables(0).Rows.Add(dr)
       End If
     End If
     SaveBatch = ._BCHNO
     SaveDate = MyUtils.GetDBDate(myBCHHDR._PSDT)
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

   If FundCtlAmt(I) <> 0 Then
    With myRQEBCH
     'Reserve for Encumbrance
     With myGLFUND
       myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
     End With
     dr = ds2.Tables(0).NewRow
     dr("bchno") = SaveBatch
     dr("bchdate") = SaveDate
     dr("fund") = FundCtl(I)
     dr("group") = "1"
     dr("gltyp") = myGLACCT._GLTYP
     dr("trntyp") = "X"
     If FundCtlAmt(I) > 0 Then
       dr("credit") = FundCtlAmt(I)
     Else
       dr("debit") = Math.Abs(FundCtlAmt(I))
     End If
     WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDR, myGLFUND._DPNBRR, myGLFUND._OBNBRR, _
      myGLFUND._FNPGMR, myGLFUND._SUBFNR)
     dr("acct") = WrkAcct
     dr("acctdescr") = myGLACCT._GLDSC
     dr("errmsg") = String.Empty
     ds2.Tables(0).Rows.Add(dr)

     'Encumbrance 
     With myGLFUND
       myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
     End With
     dr = ds2.Tables(0).NewRow
     dr("bchno") = SaveBatch
     dr("bchdate") = SaveDate
     dr("fund") = FundCtl(I)
     dr("group") = "1"
     dr("gltyp") = myGLACCT._GLTYP
     dr("trntyp") = "X"
     If FundCtlAmt(I) > 0 Then
       dr("debit") = FundCtlAmt(I)
     Else
       dr("credit") = Math.Abs(FundCtlAmt(I))
     End If
     WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDE, myGLFUND._DPNBRE, myGLFUND._OBNBRE, _
      myGLFUND._FNPGME, myGLFUND._SUBFNE)
     dr("acct") = WrkAcct
     dr("acctdescr") = myGLACCT._GLDSC
     dr("errmsg") = String.Empty
     ds2.Tables(0).Rows.Add(dr)
    End With
   End If
 Next

 myRQEBCH.CloseFile()
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
