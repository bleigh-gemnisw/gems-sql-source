Imports System.Text
Module ProcessFile
  Dim myGLACCT As GLACCT.MyData
  Dim myGLFUND As GLFUND.MyData
  Dim myLEDGER As LEDGER.MyData
  Dim ds As DataSet = New DataSet
  'General
  Dim SaveYear As Integer
  Dim SaveDist As Integer
  Dim WrkFiscyr As Integer
  Dim WrkPONbr As Integer
  Dim WrkPOSuf As Integer
  Dim WrkFdnbr As Integer
  Dim WrkSfund As Integer
  Dim WrkDpnbr As Integer
  Dim WrkObnbr As Integer
  Dim WrkFnpgm As Integer
  Dim WrkSubfn As Integer
  Dim WrkPostDate As Integer
  Dim cSrcde As Integer = 4
  Public Sub ProcFile(ByVal WrkSumExval As Decimal)
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect

    With MyFrmPO330B
      WrkFiscyr = MyUtils.CnvSng(.TxtFscyr.Text)
      WrkPONbr = MyUtils.CnvSng(.TxtPONbr.Text)
      WrkFdnbr = MyUtils.CnvSng(.TxtFund.Text)
      WrkSfund = MyUtils.CnvSng(.TxtSFund.Text)
      WrkDpnbr = MyUtils.CnvSng(.TxtDept.Text)
      WrkObnbr = MyUtils.CnvSng(.TxtObj.Text)
      WrkFnpgm = MyUtils.CnvSng(.TxtFcn.Text)
      WrkSubfn = MyUtils.CnvSng(.TxtSfcn.Text)
      WrkPostDate = MyUtils.SetDBDate(.DtPckRent8.Value)
    End With

    If ds.Tables.Count = 0 Then
      BuildPrtDS()
    Else
      ds.Clear()
    End If
    If WrkSumExval = 0 Then Exit Sub

    WriteDS(WrkSumExval)
    WriteLEDGER(WrkSumExval)
    WriteControl(WrkSumExval)
    MyFrmCr_PrtEdits = New FrmCr_PrtEdits
    MyFrmCr_PrtEdits.Wrkds = ds
    MyFrmCr_PrtEdits.ShowDialog()
  End Sub
  Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BchDate", Type.GetType("System.DateTime"))
      .Columns.Add("Group", Type.GetType("System.String"))
      .Columns.Add("TrnTyp", Type.GetType("System.String"))
      .Columns.Add("GLTyp", Type.GetType("System.String"))
      .Columns.Add("Debit", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDescr", Type.GetType("System.String"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Sub WriteDS(ByVal WrkSumExval As Decimal)
    Dim WrkAcct As String
    Dim Counter As Integer
    Dim dr As Data.DataRow
    Dim WrkSeq As Integer

    Counter = 0
    SaveYear = 0
    SaveDist = 0
    WrkSeq = 0

    WrkSeq = WrkSeq + 10
    myGLACCT.GetOneRecordP(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    dr = ds.Tables(0).NewRow
    dr("bchdate") = MyUtils.GetDBDate(WrkPostDate)
    dr("group") = "2"
    dr("gltyp") = "X"
    dr("trntyp") = "E"
    If WrkSumExval > 0 Then
      dr("debit") = WrkSumExval
    Else
      dr("credit") = Math.Abs(WrkSumExval)
    End If
    dr("descr") = "Change PO " & WrkPONbr
    WrkAcct = BuildAcct(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
    dr("acct") = WrkAcct
    If Not myGLACCT.RecordNotFound Then
      dr("acctdescr") = myGLACCT._GLDSC
    End If
    ds.Tables(0).Rows.Add(dr)

    'Encumbrance 
    myGLFUND.GetOneRecordP(WrkFdnbr, 0)
    With myGLFUND
      myGLACCT.GetOneRecordP(WrkFdnbr, ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
    End With
    WrkSeq = WrkSeq + 10
    dr = ds.Tables(0).NewRow
    dr("bchdate") = MyUtils.GetDBDate(WrkPostDate)
    dr("group") = "1"
    dr("gltyp") = myGLACCT._GLTYP
    dr("trntyp") = "X"
    If WrkSumExval > 0 Then
      dr("credit") = WrkSumExval
    Else
      dr("debit") = Math.Abs(WrkSumExval)
    End If
    dr("descr") = String.Empty
    WrkAcct = BuildAcct(WrkFdnbr, myGLFUND._SFUNDE, myGLFUND._DPNBRE, myGLFUND._OBNBRE,
      myGLFUND._FNPGME, myGLFUND._SUBFNE)
    dr("acct") = WrkAcct
    dr("acctdescr") = myGLACCT._GLDSC
    ds.Tables(0).Rows.Add(dr)

    'Expenditure Control 
    myGLFUND.GetOneRecordP(WrkFdnbr, 0)
    With myGLFUND
      myGLACCT.GetOneRecordP(WrkFdnbr, ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
    End With
    WrkSeq = WrkSeq + 10
    dr = ds.Tables(0).NewRow
    dr("bchdate") = MyUtils.GetDBDate(WrkPostDate)
    dr("group") = "1"
    dr("gltyp") = myGLACCT._GLTYP
    dr("trntyp") = "X"
    If WrkSumExval > 0 Then
      dr("debit") = WrkSumExval
    Else
      dr("credit") = Math.Abs(WrkSumExval)
    End If
    dr("descr") = String.Empty
    WrkAcct = BuildAcct(WrkFdnbr, myGLFUND._SFUNDR, myGLFUND._DPNBRR, myGLFUND._OBNBRR,
      myGLFUND._FNPGMR, myGLFUND._SUBFNR)
    dr("acct") = WrkAcct
    dr("acctdescr") = myGLACCT._GLDSC
    ds.Tables(0).Rows.Add(dr)
  End Sub
  Private Sub WriteLEDGER(ByVal WrkSumExval As Decimal)
    Dim WrkVennm As String
    Dim I As Integer

    With myLEDGER
      myGLACCT.GetOneRecordP(WrkFdnbr, WrkSfund, WrkDpnbr, WrkObnbr, WrkFnpgm, WrkSubfn)
      If WrkSumExval >= 0 Then
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
      ._DPNBR = WrkDpnbr
      ._GLPST = String.Empty
      ._GLTYP = "X"
      ._FDNBR = WrkFdnbr
      ._FNPGM = WrkFnpgm
      ._FSCYR = WrkFiscyr
      ._INVNR = ""
      ._JRNSQ = I + 1
      ._OBNBR = WrkObnbr
      ._ORIG = 0
      ._PONBR = WrkPONbr
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = WrkPostDate
      ._RECLS = String.Empty
      ._REFNO = WrkPONbr
      ._ROCR = String.Empty
      ._SFUND = WrkSfund
      ._SRCDE = cSrcde
      ._SUBFN = WrkSubfn
      ._TRAMT = Math.Abs(WrkSumExval)
      WrkVennm = Left(Trim(MyFrmPO330B.LblVennm.Text), 20)
      WrkVennm = Replace(WrkVennm, "'", "")
      ._TDESC = WrkVennm
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = "E"
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      .InsertOneRecordP()
    End With
  End Sub
  Private Sub WriteControl(ByVal WrkSumExval As Decimal)
    With myGLFUND
      .GetOneRecordP(WrkFdnbr, 0)
      myGLACCT.GetOneRecordP(WrkFdnbr, ._SFUNDE, ._DPNBRE, ._OBNBRE, ._FNPGME, ._SUBFNE)
    End With
    With myLEDGER
      If WrkSumExval > 0 Then
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
      ._DPNBR = myGLFUND._DPNBRE
      ._FDNBR = WrkFdnbr
      ._FNPGM = myGLFUND._FNPGME
      ._FIL10 = "9999999999"
      ._FSCYR = WrkFiscyr
      ._GLPST = ""
      ._GLTYP = myGLACCT._GLTYP
      ._INVNR = String.Empty
      ._JRNSQ = 0
      ._PONBR = WrkPONbr
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = WrkPostDate
      ._OBNBR = myGLFUND._OBNBRE
      ._ORIG = 0
      ._SFUND = myGLFUND._SFUNDE
      ._SRCDE = cSrcde
      ._RECLS = String.Empty
      ._REFNO = WrkPONbr
      ._ROCR = String.Empty
      ._SUBFN = myGLFUND._SFUNDE
      ._TDESC = "Change PO " & WrkPONbr
      ._TRAMT = Math.Abs(WrkSumExval)
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = "X"
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      .InsertOneRecordP()
    End With

    With myGLFUND
      myGLACCT.GetOneRecordP(WrkFdnbr, ._SFUNDR, ._DPNBRR, ._OBNBRR, ._FNPGMR, ._SUBFNR)
    End With
    With myLEDGER
      If WrkSumExval > 0 Then
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
      ._DPNBR = myGLFUND._DPNBRR
      ._FDNBR = WrkFdnbr
      ._FIL10 = "9999999999"
      ._FNPGM = myGLFUND._FNPGMR
      ._FSCYR = WrkFiscyr
      ._GLPST = ""
      ._GLTYP = myGLACCT._GLTYP
      ._INVNR = String.Empty
      ._JRNSQ = 0
      ._PONBR = WrkPONbr
      ._PRF = Mid(MyUserID, 1, 10)
      ._PSTDT = WrkPostDate
      ._OBNBR = myGLFUND._OBNBRR
      ._ORIG = 0
      ._SFUND = myGLFUND._SFUNDR
      ._SRCDE = cSrcde
      ._RECLS = String.Empty
      ._REFNO = WrkPONbr
      ._ROCR = String.Empty
      ._SUBFN = myGLFUND._SFUNDR
      ._TDESC = "Change PO " & WrkPONbr
      ._TRAMT = Math.Abs(WrkSumExval)
      ._TRFTO = String.Empty
      ._TRNBR = 0
      ._TRTYP = "X"
      ._TDATE = MyUtils.SetDBDateMDY(Date.Today)
      .InsertOneRecordP()
    End With
  End Sub
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer,
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
  Private Sub BreakAcct(ByVal In_Acct As String, ByRef Out_Fund As Integer, ByRef Out_SFund As Integer, ByRef Out_Dept As Integer,
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
