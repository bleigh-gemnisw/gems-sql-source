Imports System.Text
Imports System.IO
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myLEDGERQ As LEDGERQ.MyData
  Dim myLEDGERL1 As LEDGERL1.MyData
  Dim myGLFUND As GLFUND.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkFundFrom As Integer
  Dim WrkFundTo As Integer
  Dim WrkSfundFrom As Integer
  Dim WrkSfundTo As Integer
  Dim WrkDeptFrom As Integer
  Dim WrkDeptTo As Integer
  Dim WrkObjFrom As Integer
  Dim WrkObjTo As Integer
  Dim WrkFuncFrom As Integer
  Dim WrkFuncTo As Integer
  Dim WrkGltyp As String
  Dim WrkSrcde As Integer
  Dim WrkPrtAcct As Boolean
  Dim WrkNoActivity As Boolean
  Dim WrkInactiveRpt As Boolean
  Dim WrkShowFundBal As Boolean
  Dim WrkDateFrom As Integer
  Dim WrkDateTo As Integer
  Dim WrkFile As String
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myLEDGERQ = New LEDGERQ.MyData()
    myLEDGERQ.MyDBConn = myDBConnect
    myLEDGERL1 = New LEDGERL1.MyData()
    myLEDGERL1.MyDBConn = myDBConnect
    myGLFUND = New GLFUND.MyData()
    myGLFUND.MyDBConn = myDBConnect

    With MyFrmGL701B
      WrkDateFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkDateTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkFundFrom = MyUtils.CnvSng(.TxtFundFrom.Text)
      WrkFundTo = MyUtils.CnvSng(.TxtFundTo.Text)
      WrkSfundFrom = MyUtils.CnvSng(.TxtSfundFrom.Text)
      WrkSfundTo = MyUtils.CnvSng(.TxtSfundTo.Text)
      WrkDeptFrom = MyUtils.CnvSng(.TxtDeptFrom.Text)
      WrkDeptTo = MyUtils.CnvSng(.TxtDeptTo.Text)
      WrkObjFrom = MyUtils.CnvSng(.TxtObjFrom.Text)
      WrkObjTo = MyUtils.CnvSng(.TxtObjTo.Text)
      WrkFuncFrom = MyUtils.CnvSng(.TxtFuncFrom.Text)
      WrkFuncTo = MyUtils.CnvSng(.TxtFuncTo.Text)
      WrkPrtAcct = .ChkAcct.Checked
      WrkNoActivity = .ChkNoActivity.Checked
      WrkInactiveRpt = .ChkInactiveRpt.Checked
      WrkShowFundBal = .ChkFundBal.Checked
      WrkFile = .LblFilePath.Text
    End With

    If WrkFile <> String.Empty Then
      sw = New StreamWriter(MyFrmGL701B.LblFilePath.Text)
    End If

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    UpdateControl()
    GetDetail()

Done:
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
  Private Sub UpdateControl()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim SaveFund As Integer
    Dim Counter As Integer
    Dim Good As Boolean

    WrkAnd = " and "
    WrkOr = " or "

    Counter = 0
    WrkQry = "GLTYP = 'Q'" & WrkAnd & "FIL10 <> 9999999999"
    WrkSort = "FDNBR"

    SaveFund = 0
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        Good = False
        If ._FDNBR <> SaveFund Then
          myGLFUND.GetOneRecordP(._FDNBR, 0)
        End If
        SaveFund = ._FDNBR
        If ._DPNBR = myGLFUND._DPNBRE And ._OBNBR = myGLFUND._OBNBRE And ._FNPGM = myGLFUND._FNPGME And ._SUBFN = myGLFUND._SFUNDE Then
          Good = True
        End If
        If ._DPNBR = myGLFUND._DPNBRE And ._OBNBR = myGLFUND._OBNBRR And ._FNPGM = myGLFUND._FNPGMR And ._SUBFN = myGLFUND._SFUNDR Then
          Good = True
        End If
        If ._DPNBR = myGLFUND._DPNBR1 And ._OBNBR = myGLFUND._OBNBR1 And ._FNPGM = myGLFUND._FNPGM1 And ._SUBFN = myGLFUND._SFUND1 Then
          Good = True
        End If
        If ._DPNBR = myGLFUND._DPNBR2 And ._OBNBR = myGLFUND._OBNBR2 And ._FNPGM = myGLFUND._FNPGM2 And ._SUBFN = myGLFUND._SFUND2 Then
          Good = True
        End If
        If Good Then
          '      .UpdateOneRecordP()
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

    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
  End Sub
  Private Sub GetDetail()
    Dim sb As StringBuilder
    Dim WrkQry As String
    Dim WrkSort As String
    Dim SaveQry As String
    Dim SaveFund As Integer
    Dim SaveDept As Integer
    Dim SaveObj As Integer
    Dim SaveFunc As Integer
    Dim SaveSfunc As Integer
    Dim SaveGltyp As String
    Dim WrkFundDesc As String
    Dim WrkFundBal As Decimal
    Dim WrkDebit As Decimal
    Dim WrkCredit As Decimal
    Dim WrkDescr As String
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0

    WrkQry = "PSTDT <= " & WrkDateTo
    If WrkFundFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFundFrom
    End If
    If WrkFundTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkFundTo
    End If
    If WrkSfundFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "SFUND >= " & WrkSfundFrom
    End If
    If WrkSfundTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "SFUND <= " & WrkSfundTo
    End If
    If WrkDeptFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "DPNBR >= " & WrkDeptFrom
    End If
    If WrkDeptTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "DPNBR <= " & WrkDeptTo
    End If
    If WrkObjFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "OBNBR >= " & WrkObjFrom
    End If
    If WrkObjTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "OBNBR <= " & WrkObjTo
    End If
    If WrkFuncFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "FNPGM >= " & WrkFuncFrom
    End If
    If WrkFuncTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "FNPGM <= " & WrkFuncTo
    End If
    SaveQry = WrkQry
    WrkQry = SaveQry & WrkAnd & "GLTYP = 'A'" & WrkAnd & "TRTYP = 'X'" &
 WrkOr & SaveQry & WrkAnd & "GLTYP = 'L'" & WrkAnd & "TRTYP = 'X'" &
 WrkOr & SaveQry & WrkAnd & "GLTYP = 'Q'"
    WrkSort = "FDNBR, SFUND, GLTYP, DPNBR, OBNBR, FNPGM, SUBFN, PSTDT"

    SaveFund = 0
    SaveDept = 0
    SaveObj = 0
    SaveFunc = 0
    SaveSfunc = 0
    SaveGltyp = ""
    WrkFundBal = 0
    WrkDebit = 0
    WrkCredit = 0
    WrkFundDesc = ""
    myLEDGERQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    'Header Record
    If WrkFile <> String.Empty Then
      sb = New StringBuilder
      sb.Append("Account")
      sb.Append(",")
      sb.Append("Descr")
      sb.Append(",")
      sb.Append("Debit")
      sb.Append(",")
      sb.Append("Credit")
      sw.WriteLine(sb.ToString)
      sb = Nothing
    End If

ReadNext:
    myLEDGERQ.ReadQry()
    If Not myLEDGERQ.IsEOF Then
      With myLEDGERQ
        Counter = Counter + 1
        If SaveFund > 0 Then
          If ._FDNBR <> SaveFund Or ._DPNBR <> SaveDept Or ._OBNBR <> SaveObj Or ._FNPGM <> SaveFunc Or ._SUBFN <> SaveSfunc Then
            WrkFundDesc = GetFundDesc(SaveFund, WrkInactiveRpt)
            If WrkDebit - WrkCredit <> 0 And WrkFundDesc <> "" Or WrkNoActivity And WrkFundDesc <> "" Then
              dr = ds.Tables(0).NewRow
              dr.Item("fund") = SaveFund
              dr.Item("funddesc") = GetFundDesc(SaveFund, WrkInactiveRpt)
              dr.Item("sfund") = 0
              If WrkPrtAcct Then
                dr.Item("acct") = Format(SaveFund, "000") & "-" & Format(SaveDept, "0000") & "-" & Format(SaveObj, "000") &
             "-" & Format(SaveFunc, "0000") & "-" & Format(SaveSfunc, "0000")
              Else
                dr.Item("acct") = ""
              End If
              dr.Item("acctdesc") = GetAcctDesc(SaveFund, SaveDept, SaveObj, SaveFunc, SaveSfunc)
              dr.Item("gltyp") = SaveGltyp
              dr.Item("gltypdesc") = GetGlTypDesc(SaveGltyp)
              If WrkDebit >= WrkCredit Then
                dr.Item("debit") = WrkDebit - WrkCredit
              Else
                dr.Item("credit") = WrkCredit - WrkDebit
              End If
              ds.Tables(0).Rows.Add(dr)

              If WrkFile <> String.Empty Then
                sb = New StringBuilder
                sb.Append(Format(SaveFund, "000"))
                sb.Append("-")
                sb.Append(Format(SaveDept, "0000"))
                sb.Append("-")
                sb.Append(Format(SaveObj, "000"))
                sb.Append("-")
                sb.Append(Format(SaveFunc, "0000"))
                sb.Append("-")
                sb.Append(Format(SaveSfunc, "0000"))
                sb.Append(",")
                WrkDescr = GetAcctDesc(SaveFund, SaveDept, SaveObj, SaveFunc, SaveSfunc)
                sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
                sb.Append(",")
                If WrkDebit >= WrkCredit Then
                  sb.Append(WrkDebit - WrkCredit)
                  sb.Append(",")
                  sb.Append(0)
                Else
                  sb.Append(0)
                  sb.Append(",")
                  sb.Append(WrkCredit - WrkDebit)
                End If
                sw.WriteLine(sb.ToString)
                  sb = Nothing
                End If
              End If
            WrkDebit = 0
            WrkCredit = 0
          End If
        End If
        'Unclosed Fund Balance
        If WrkShowFundBal And SaveFund > 0 And ._FDNBR <> SaveFund Then
          myGLFUND.GetOneRecordP(SaveFund, 0)
          With myGLFUND
            WrkFundBal = GetFundBalance(._FDNBR1, ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
            WrkFundBal = WrkFundBal + GetFundBalance(._FDNBR2, ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
          End With
          If WrkFundBal <> 0 And WrkFundDesc <> "" Then
            dr = ds.Tables(0).NewRow
            dr.Item("fund") = SaveFund
            dr.Item("funddesc") = GetFundDesc(SaveFund, WrkInactiveRpt)
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

            If WrkFile <> String.Empty Then
              sb = New StringBuilder
              sb.Append(Format(SaveFund, "000"))
              sb.Append("----")
              sb.Append(",")
              WrkDescr = "UNCLOSED FUND BALANCE"
              sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
              sb.Append(",")
              sb.Append(WrkFundBal)
              sw.WriteLine(sb.ToString)
              sb = Nothing
            End If
          End If
        End If

        SaveFund = ._FDNBR
        SaveDept = ._DPNBR
        SaveObj = ._OBNBR
        SaveFunc = ._FNPGM
        SaveSfunc = ._SUBFN
        SaveGltyp = Trim(._GLTYP)
        If SaveGltyp = "Q" Then
          If ._FIL10 = 9999999999 And ._PSTDT < WrkDateFrom Then
            GoTo NextRec
          End If
        End If
        If ._AMTYP = "D" Then
          WrkDebit = WrkDebit + ._TRAMT
        Else
          WrkCredit = WrkCredit + ._TRAMT
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

    WrkFundDesc = GetFundDesc(SaveFund, WrkInactiveRpt)
    If WrkDebit - WrkCredit <> 0 And WrkFundDesc <> "" Or WrkNoActivity And WrkFundDesc <> "" Then
      dr = ds.Tables(0).NewRow
      dr.Item("fund") = SaveFund
      dr.Item("funddesc") = GetFundDesc(SaveFund, WrkInactiveRpt)
      dr.Item("sfund") = 0
      dr.Item("acct") = Format(SaveFund, "000") & "-" & Format(SaveDept, "0000") & "-" & Format(SaveObj, "000") &
      "-" & Format(SaveFunc, "0000") & "-" & Format(SaveSfunc, "0000")
      dr.Item("acctdesc") = GetAcctDesc(SaveFund, SaveDept, SaveObj, SaveFunc, SaveSfunc)
      dr.Item("gltyp") = SaveGltyp
      dr.Item("gltypdesc") = GetGlTypDesc(SaveGltyp)
      If WrkDebit >= WrkCredit Then
        dr.Item("debit") = WrkDebit - WrkCredit
      Else
        dr.Item("credit") = WrkCredit - WrkDebit
      End If
      ds.Tables(0).Rows.Add(dr)

      If WrkFile <> String.Empty Then
        sb = New StringBuilder
        sb.Append(Format(SaveFund, "000"))
        sb.Append("-")
        sb.Append(Format(SaveDept, "0000"))
        sb.Append("-")
        sb.Append(Format(SaveObj, "000"))
        sb.Append("-")
        sb.Append(Format(SaveFunc, "0000"))
        sb.Append("-")
        sb.Append(Format(SaveSfunc, "0000"))
        sb.Append(",")
        WrkDescr = GetAcctDesc(SaveFund, SaveDept, SaveObj, SaveFunc, SaveSfunc)
        sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
        sb.Append(",")
        If WrkDebit >= WrkCredit Then
          sb.Append(WrkDebit - WrkCredit)
        Else
          sb.Append((WrkCredit - WrkDebit) * -1)
        End If
        sw.WriteLine(sb.ToString)
        sb = Nothing
      End If
    End If

    'Unclosed Fund Balance
    If WrkShowFundBal Then
      myGLFUND.GetOneRecordP(SaveFund, 0)
      With myGLFUND
        WrkFundBal = GetFundBalance(._FDNBR1, ._SFUND1, ._DPNBR1, ._OBNBR1, ._FNPGM1, ._SUBFN1)
        WrkFundBal = WrkFundBal + GetFundBalance(._FDNBR2, ._SFUND2, ._DPNBR2, ._OBNBR2, ._FNPGM2, ._SUBFN2)
      End With
      If WrkFundBal <> 0 And WrkFundDesc <> "" Then
        dr = ds.Tables(0).NewRow
        dr.Item("fund") = SaveFund
        dr.Item("funddesc") = GetFundDesc(SaveFund, WrkInactiveRpt)
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

        If WrkFile <> String.Empty Then
          sb = New StringBuilder
          sb.Append(Format(SaveFund, "000"))
          sb.Append("----")
          sb.Append(",")
          WrkDescr = "UNCLOSED FUND BALANCE"
          sb.Append(Chr(34) & WrkDescr & Chr(34)) 'Add double quotes
          sb.Append(",")
          sb.Append(WrkFundBal)
          sw.WriteLine(sb.ToString)
          sb = Nothing
        End If
      End If
    End If

    If WrkFile <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If

    myFrmProgress.Close()
    myLEDGERQ.CloseFile()
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
End Module
