Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEOPNQ As APEOPNQ.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkFromFund As Integer
  Dim WrkToFund As Integer
  Dim WrkDetail As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPEOPNQ = New APEOPNQ.MyData()
    myAPEOPNQ.MyDBConn = myDBConnect
    myGLACCT = New GLACCT.MyData()
    myGLACCT.MyDBConn = myDBConnect

    With MyFrmAP202B
      WrkFromFund = MyUtils.CnvSng(.TxtFromFund.Text)
      WrkToFund = MyUtils.CnvSng(.TxtToFund.Text)
      WrkDetail = .ChkDetail.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If
    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .wrkds = ds
      .Show()
    End With
  End Sub
  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Vsort", Type.GetType("System.String"))
      .Columns.Add("Vendor", Type.GetType("System.String"))
      .Columns.Add("VendName", Type.GetType("System.String"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("InvDate", Type.GetType("System.DateTime"))
      .Columns.Add("DueDate", Type.GetType("System.DateTime"))
      .Columns.Add("Amtgr", Type.GetType("System.Decimal"))
      .Columns.Add("Amtop", Type.GetType("System.Decimal"))
      .Columns.Add("Lstpd", Type.GetType("System.String"))
      .Columns.Add("Chkpd", Type.GetType("System.Int32"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("Partial", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Recno", Type.GetType("System.Int32"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      .Columns.Add("AcctDescr", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer
    Dim SavePONbr As Integer
    Dim SaveInvDte As Date
    Dim SaveDueDte As Date
    WrkAnd = " and "
    WrkOr = " or "

    If WrkDetail Then
      WrkQry = ""
    Else
      WrkQry = "RECNO=0"
    End If
    If WrkFromFund > 0 Then
      If WrkQry = "" Then
        WrkQry = "FDNBR >= " & WrkFromFund
      Else
        WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFromFund
      End If
    End If
    If WrkToFund > 0 Then
      If WrkQry = "" Then
        WrkQry = "FDNBR <= " & WrkToFund
      Else
        WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkToFund
      End If
    End If

      WrkSort = "VSORT,VNDNR, INVNO, RECNO"
    Counter = 0
    myAPEOPNQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myAPEOPNQ.ReadQry()
    If Not myAPEOPNQ.IsEOF Then
      Counter = Counter + 1

      'Create Report
      With myAPEOPNQ
        If WrkDetail And ._RECNO = 0 Then
          SavePONbr = ._PONBR
          SaveInvDte = MyUtils.GetDBDateMDY(._INVD8)
          SaveDueDte = MyUtils.GetDBDate(._DUED8)
          GoTo NextRec
        End If
        dr = ds.Tables(0).NewRow
        dr.Item("vsort") = ._VSORT
        dr.Item("vendor") = ._VNDNR
        dr.Item("vendname") = ._VENNM
        dr.Item("invno") = ._INVNO
        dr.Item("amtgr") = ._AMTGR
        dr.Item("amtop") = ._AMTGR
        If ._LSTPD > 0 Then
          dr.Item("lstpd") = ._LSTPD
        Else
          dr.Item("lstpd") = ""
        End If
        dr.Item("chkpd") = ._CHKPD
        If WrkDetail Then
          dr.Item("invdate") = SaveInvDte
          dr.Item("duedate") = SaveDueDte
          dr.Item("ponbr") = SavePONbr
        Else
          dr.Item("invdate") = MyUtils.GetDBDateMDY(._INVD8)
          dr.Item("duedate") = MyUtils.GetDBDate(._DUED8)
          dr.Item("ponbr") = ._PONBR
          If ._LEOPN = "P" Then
            dr.Item("partial") = "P"
          Else
            dr.Item("partial") = ""
          End If
        End If
        dr.Item("descr") = ._DSCTX
        If WrkDetail Then
          dr.Item("recno") = ._RECNO
          dr.Item("acct") = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
          dr.Item("acctdescr") = GetAcctDesc(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
        Else
          dr.Item("recno") = 0
          dr.Item("acct") = ""
          dr.Item("acctdescr") = ""
        End If
        ds.Tables(0).Rows.Add(dr)
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
    myAPEOPNQ.CloseFile()

  End Sub
  Public Function GetAcctDesc(ByVal Fund As Integer, ByVal Sfund As Integer, Dept As Integer,
    ByVal Obnbr As Integer, ByVal Fnpgm As Integer, ByVal Subfn As Integer) As String
    myGLACCT.GetOneRecordP(Fund, Sfund, Dept, Obnbr, Fnpgm, Subfn)
    If Not myGLACCT.RecordNotFound Then
      GetAcctDesc = Trim(myGLACCT._GLDSC) ' & " " & Format(Dept, "0000") & "-" & Format(Obnbr, "000") & _
      '"-" & Format(Fnpgm, "0000") & "-" & Format(Subfn, "0000")
    Else
      GetAcctDesc = "*** Unknown ***"
    End If
    Return GetAcctDesc
  End Function
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
End Module
