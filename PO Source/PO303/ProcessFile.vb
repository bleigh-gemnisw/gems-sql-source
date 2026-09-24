Imports System.Text
Module ProcessFile
Dim myPOSUMFL1 As POSUMFL1.MyData
Dim myPOMAST As POMAST.MyData
Dim myGLACCT As GLACCT.MyData
Dim myGLFUND As GLFUND.MyData
Dim myLEDGER As LEDGER.MyData
Dim ds As DataSet = New DataSet
Dim WrkError As Boolean
'General
Dim FundCtl(25) As Integer
Dim FundCtlAmt(25) As Decimal
Dim SaveYear As Integer
Dim SaveDist As Integer
Dim WrkFiscyr As Integer
Dim WrkPONbr As Integer
Dim WrkPOSuf As Integer
Dim WrkPostDate As Integer
Dim cSrcde As Integer = 4
Public Sub ProcFile(ByVal WrkPopst As Integer)
  myPOSUMFL1 = New POSUMFL1.MyData()
  myPOSUMFL1.MyDBConn = myDBConnect
  myPOMAST = New POMAST.MyData()
  myPOMAST.MyDBConn = myDBConnect
  myGLACCT = New GLACCT.MyData()
  myGLACCT.MyDBConn = myDBConnect
  myGLFUND = New GLFUND.MyData()
  myGLFUND.MyDBConn = myDBConnect
  myLEDGER = New LEDGER.MyData()
  myLEDGER.MyDBConn = myDBConnect

  With MyFrmPO303B
    WrkFiscyr = MyUtils.CnvSng(.TxtFscyr.Text)
    WrkPONbr = MyUtils.CnvSng(.TxtPONbr.Text)
    WrkPOSuf = MyUtils.CnvSng(.TxtPOSufx.Text)
    WrkPostDate = MyUtils.SetDBDate(.DtPckRent8.Value)
  End With

  WrkError = False
  If ds.Tables.Count = 0 Then
    BuildPrtDS()
  Else
    ds.Clear()
  End If
  WriteDS(WrkPopst)
  WriteLEDGER(WrkPopst)
  WriteControl()
  MyFrmCr_PrtEdits = New FrmCr_PrtEdits
  MyFrmCr_PrtEdits.Wrkds = ds
  MyFrmCr_PrtEdits.ShowDialog()
End Sub
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("PONbr", Type.GetType("System.Int32"))
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
  Sub WriteDS(ByVal WrkPopst As Integer)
    Dim dsFile As DataSet = New DataSet
    Dim WrkAcct As String
    Dim WrkFdnbr As Integer
    Dim WrkSfund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim Counter As Integer
    Dim dr As Data.DataRow
    Dim I As Integer
    Dim K As Integer
    Dim WrkSeq As Integer

    Counter = 0
    SaveYear = 0
    SaveDist = 0
    WrkSeq = 0
    Array.Clear(FundCtl, 0, 25)
    Array.Clear(FundCtlAmt, 0, 25)

    dsFile = myPOSUMFL1.GetAllPONo(WrkFiscyr, WrkPONbr, 0)
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With dsFile.Tables(0).Rows(I)
        If .Item("poopn") = 0 Then Continue For
        BreakAcct(.Item("acct"), WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      End With
      WrkSeq = WrkSeq + 10
      myGLACCT.GetOneRecordP(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      dr = ds.Tables(0).NewRow
      dr("ponbr") = WrkPONbr
      dr("group") = "1"
      dr("trnbr") = WrkPONbr
      dr("jrnseq") = WrkSeq
      dr("gltyp") = myGLACCT._GLTYP
      dr("trntyp") = "E"
      dr("acdate") = MyUtils.GetDBDate(WrkPostDate)
      dr("credit") = dsFile.Tables(0).Rows(I).Item("poopn")
      K = LookupFundCtl(WrkFdnbr)
      FundCtl(K) = WrkFdnbr
      FundCtlAmt(K) = FundCtlAmt(K) + dsFile.Tables(0).Rows(I).Item("poopn")
      dr("descr") = "CLOSE PO " & WrkPONbr
      With dsFile.Tables(0).Rows(I)
        WrkAcct = BuildAcct(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      End With
      dr("acct") = WrkAcct
      If Not myGLACCT.RecordNotFound Then
        dr("acctdescr") = myGLACCT._GLDSC
      Else
        dr("acctdescr") = "*** Invalid Account ***"
        WrkError = True
      End If
      dr("refno") = WrkPONbr
      If Not myGLACCT.RecordNotFound Then
        dr("errmsg") = String.Empty
      Else
        dr("errmsg") = "*** Invalid Account ***"
      End If
      ds.Tables(0).Rows.Add(dr)
    Next

    For I = 0 To FundCtl.GetUpperBound(0)
      If FundCtlAmt(I) <> 0 Then
        'Encumbrance 
        myGLFUND.GetOneRecordP(FundCtl(I), 0)
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
        End With
        WrkSeq = WrkSeq + 10
        dr = ds.Tables(0).NewRow
        dr("ponbr") = WrkPONbr
        dr("group") = "1"
        dr("trnbr") = WrkPONbr
        dr("jrnseq") = WrkSeq
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "E"
        dr("acdate") = MyUtils.GetDBDate(WrkPostDate)
        If FundCtlAmt(I) > 0 Then
          dr("credit") = FundCtlAmt(I)
        Else
          dr("debit") = Math.Abs(FundCtlAmt(I))
        End If
        dr("descr") = String.Empty
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDE, myGLFUND._DPNBRE, myGLFUND._OBNBRE,
      myGLFUND._FNPGME, myGLFUND._SUBFNE)
        dr("acct") = WrkAcct
        dr("acctdescr") = myGLACCT._GLDSC
        dr("refno") = WrkPONbr
        ds.Tables(0).Rows.Add(dr)

        'Expenditure Control 
        myGLFUND.GetOneRecordP(FundCtl(I), 0)
        With myGLFUND
          myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
        End With
        WrkSeq = WrkSeq + 10
        dr = ds.Tables(0).NewRow
        dr("ponbr") = WrkPONbr
        dr("group") = "1"
        dr("trnbr") = WrkPONbr
        dr("jrnseq") = WrkSeq
        dr("gltyp") = myGLACCT._GLTYP
        dr("trntyp") = "E"
        dr("acdate") = MyUtils.GetDBDate(WrkPostDate)
        If FundCtlAmt(I) > 0 Then
          dr("debit") = Math.Abs(FundCtlAmt(I))
        Else
          dr("credit") = FundCtlAmt(I)
        End If
        dr("descr") = String.Empty
        WrkAcct = BuildAcct(FundCtl(I), myGLFUND._SFUNDR, myGLFUND._DPNBRR, myGLFUND._OBNBRR,
      myGLFUND._FNPGMR, myGLFUND._SUBFNR)
        dr("acct") = WrkAcct
        dr("acctdescr") = myGLACCT._GLDSC
        dr("refno") = WrkPONbr
        ds.Tables(0).Rows.Add(dr)
      End If
    Next
  End Sub
  Private Sub WriteLEDGER(ByVal WrkPopst As Integer)
    Dim dsFile As DataSet = New DataSet
    Dim WrkFdnbr As Integer
    Dim WrkSfund As Integer
    Dim WrkDpnbr As Integer
    Dim WrkObnbr As Integer
    Dim WrkFnpgm As Integer
    Dim WrkSubfn As Integer
    Dim WrkVennm As String
    Dim I As Integer

    dsFile = myPOSUMFL1.GetAllPONo(WrkFiscyr, WrkPONbr, 0)
    For I = 0 To dsFile.Tables(0).Rows.Count - 1
      With dsFile.Tables(0).Rows(I)
        If .Item("poopn") = 0 Then Continue For
        BreakAcct(.Item("acct"), WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      End With
      With myLEDGER
        With dsFile.Tables(0).Rows(I)
          myGLACCT.GetOneRecordP(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
        End With
        If dsFile.Tables(0).Rows(I).Item("poopn") >= 0 Then
          ._AMTYP = "C"
        Else
          ._AMTYP = "D"
        End If
        ._AUTOG = String.Empty
        ._BALFC = String.Empty
        ._BCHNO = 0
        ._CBLCD = String.Empty
        ._CHKN = 0
        ._CNTRL = 0
        ._DATED = MyUtils.SetDBDateMDY(Date.Today)
        ._DPNBR = WrkDpnbr
        ._GLPST = String.Empty
        ._GLTYP = myGLACCT._GLTYP
        ._FDNBR = WrkFdnbr
        ._FNPGM = WrkFnpgm
        ._FSCYR = WrkFiscyr
        ._INVNR = ""
        ._JRNSQ = I + 1
        ._OBNBR = WrkObnbr
        ._ORIG = 0
        ._PONBR = WrkPONbr
        ._PRF = MyUserID
        ._PSTDT = WrkPostDate
        ._RECLS = String.Empty
        ._REFNO = WrkPONbr
        ._ROCR = String.Empty
        ._SFUND = WrkSfund
        ._SRCDE = cSrcde
        ._SUBFN = WrkSubfn
        ._TRAMT = dsFile.Tables(0).Rows(I).Item("poopn")
        myPOMAST.GetOneRecordP(WrkFiscyr, WrkPONbr, WrkPOSuf, 0, 0)
        WrkVennm = Left(Trim(myPOMAST._VENNM), 20)
        WrkVennm = Replace(WrkVennm, "'", "")
        ._TDESC = WrkVennm
        ._TRFTO = String.Empty
        ._TRNBR = 0
        ._TRTYP = "E"
        ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
        .InsertOneRecordP()
      End With
    Next
  End Sub
  Private Sub WriteControl()
 Dim I As Integer

 For I = 0 To FundCtl.GetUpperBound(0)
   If FundCtlAmt(I) <> 0 Then
     With myGLFUND
       .GetOneRecordP(FundCtl(I), 0)
       myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
     End With
     With myLEDGER
      If FundCtlAmt(I) > 0 Then
        ._AMTYP = "C"
      Else
        ._AMTYP = "D"
      End If
      ._AUTOG = String.Empty
      ._BALFC = String.Empty
      ._BCHNO = 0
      ._CBLCD = String.Empty
      ._CHKN = 0
      ._CNTRL = 0
      ._DATED = MyUtils.SetDBDateMDY(Date.Today)
      ._DPNBR = myGLFUND._DPNBRE
      ._FDNBR = FundCtl(I)
      ._FNPGM = myGLFUND._FNPGME
      ._FIL10 = "9999999999"
      ._FSCYR = WrkFiscyr
      ._GLPST = ""
      ._GLTYP = myGLACCT._GLTYP
      ._INVNR = String.Empty
      ._JRNSQ = 0
      ._PONBR = WrkPONbr
      ._PRF = MyUserID
      ._PSTDT = WrkPostDate
      ._OBNBR = myGLFUND._OBNBRE
      ._ORIG = 0
      ._SFUND = myGLFUND._SFUNDE
      ._SRCDE = cSrcde
      ._RECLS = String.Empty
      ._REFNO = WrkPONbr
      ._ROCR = String.Empty
      ._SUBFN = myGLFUND._SFUNDE
      ._TDESC = "Close PO " & WrkPONbr
      ._TRAMT = Math.Abs(FundCtlAmt(I))
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = "E"
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      .InsertOneRecordP()
     End With

     With myGLFUND
      myGLACCT.GetOneRecordP(FundCtl(I), ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
     End With
     With myLEDGER
      If FundCtlAmt(I) > 0 Then
        ._AMTYP = "D"
      Else
        ._AMTYP = "C"
      End If
      ._AUTOG = String.Empty
      ._BALFC = String.Empty
      ._BCHNO = 0
      ._CBLCD = String.Empty
      ._CHKN = 0
      ._CNTRL = 0
      ._DATED = MyUtils.SetDBDateMDY(Date.Today)
      ._DPNBR = myGLFUND._DPNBRR
      ._FDNBR = FundCtl(I)
      ._FIL10 = "9999999999"
      ._FNPGM = myGLFUND._FNPGMR
      ._FSCYR = WrkFiscyr
      ._GLPST = ""
      ._GLTYP = myGLACCT._GLTYP
      ._INVNR = String.Empty
      ._JRNSQ = 0
      ._PONBR = WrkPONbr
      ._PRF = MyUserID
      ._PSTDT = WrkPostDate
      ._OBNBR = myGLFUND._OBNBRR
      ._ORIG = 0
      ._SFUND = myGLFUND._SFUNDR
      ._SRCDE = cSrcde
      ._RECLS = String.Empty
      ._REFNO = WrkPONbr
      ._ROCR = String.Empty
      ._SUBFN = myGLFUND._SFUNDR
      ._TDESC = "Close PO " & WrkPONbr
      ._TRAMT = Math.Abs(FundCtlAmt(I))
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = "E"
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      .InsertOneRecordP()
     End With
   End If
 Next
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
Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, _
 ByVal Dept As Integer, ByVal Obj As Integer, ByVal Func As Integer, ByVal SFunc As Integer) As String
 Dim sb As StringBuilder = New StringBuilder

 If Fund > 0 Then
  sb.Append(Format(Fund, "000"))
  sb.Append("-")
  sb.Append(Format(SFund, "000"))
  sb.Append("-")
  sb.Append(Format(Dept, "0000"))
  sb.Append("-")
  sb.Append(Format(Obj, "000"))
  sb.Append("-")
  sb.Append(Format(Func, "0000"))
  sb.Append("-")
  sb.Append(Format(SFunc, "0000"))
 Else
  sb.Append(String.Empty)
 End If
 Return sb.ToString
End Function
Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer, _
 ByRef Out_Obj As Integer, ByRef Out_Func As Integer, ByRef Out_Subfn As Integer)
 Dim sb As StringBuilder = New StringBuilder
 Dim WrkLen As Integer
 Dim WrkStr As Integer

 Select Case Len(In_Acct)
 Case 19
  WrkLen = 1
 Case 20
  WrkLen = 2
 Case 21
  WrkLen = 3
 End Select
 Out_Fund = Mid(In_Acct, 1, WrkLen)
 WrkStr = 1 + WrkLen
 Out_SFund = Mid(In_Acct, WrkStr, 3)
 WrkStr = WrkStr + 3
 Out_Dept = Mid(In_Acct, WrkStr, 4)
 WrkStr = WrkStr + 4
 Out_Obj = Mid(In_Acct, WrkStr, 3)
 WrkStr = WrkStr + 3
 Out_Func = Mid(In_Acct, WrkStr, 4)
 WrkStr = WrkStr + 4
 Out_Subfn = Mid(In_Acct, WrkStr, 4)
End Sub
End Module
