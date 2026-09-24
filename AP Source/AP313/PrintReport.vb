Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEHSTQ As APEHSTQ.MyData
  Dim myVENDOR As VENDOR.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkFromFund As Integer
  Dim WrkToFund As Integer
  Dim WrkChkFrom As Integer
  Dim WrkChkTo As Integer
  Dim WrkVoid As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String

  Public Sub PrtReport()

    myAPEHSTQ = New APEHSTQ.MyData()
    myAPEHSTQ.MyDBConn = myDBConnect
    myVENDOR = New VENDOR.MyData()
    myVENDOR.MyDBConn = myDBConnect

    With MyFrmAP313B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkFromFund = MyUtils.CnvSng(.TxtFromFund.Text)
      WrkToFund = MyUtils.CnvSng(.TxtToFund.Text)
      WrkChkFrom = MyUtils.CnvSng(.TxtChkFrom.Text)
      WrkChkTo = MyUtils.CnvSng(.TxtChkTo.Text)
      WrkVoid = .ChkVoid.Checked
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
      .Columns.Add("RptID", Type.GetType("System.String"))
      .Columns.Add("vndnr", Type.GetType("System.String"))
      .Columns.Add("vennm", Type.GetType("System.String"))
      .Columns.Add("chkpd", Type.GetType("System.Int32"))
      .Columns.Add("ppdt8", Type.GetType("System.DateTime"))
      .Columns.Add("bnkcd", Type.GetType("System.String"))
      .Columns.Add("invno", Type.GetType("System.String"))
      .Columns.Add("invd8", Type.GetType("System.DateTime"))
      .Columns.Add("amtgr", Type.GetType("System.Decimal"))
      .Columns.Add("amtds", Type.GetType("System.Decimal"))
      .Columns.Add("amtpd", Type.GetType("System.Decimal"))
      .Columns.Add("avoid", Type.GetType("System.String"))
      .Columns.Add("ponbr", Type.GetType("System.Int32"))
      .Columns.Add("AcctDesc", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkName As String
    Dim WrkAcct As String
    Dim WrkAcctDesc As String
    Dim SavePONbr As Integer
    Dim Counter As Integer

    WrkAnd = " and "
    WrkOr = " or "

    WrkQry = "PPDT8 >= " & WrkFrom & WrkAnd & "PPDT8 <=" & WrkTo
    If Not WrkVoid Then
      WrkQry = WrkQry & WrkAnd & "AVOID<>'V'"
    End If
    If WrkFromFund > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR >= " & WrkFromFund
    End If
    If WrkToFund > 0 Then
      WrkQry = WrkQry & WrkAnd & "FDNBR <= " & WrkToFund
    End If
    If Trim(MyFrmAP313B.TxtVndFrom.Text) <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "VNDNR >=" & MyUtils.Quo(MyFrmAP313B.TxtVndFrom.Text)
    End If
    If Trim(MyFrmAP313B.TxtVndTo.Text) <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "VNDNR <=" & MyUtils.Quo(MyFrmAP313B.TxtVndTo.Text)
    End If
    If WrkChkFrom > 0 Then
      WrkQry = WrkQry & WrkAnd & "CHKPD >= " & WrkChkFrom
    End If
    If WrkChkTo > 0 Then
      WrkQry = WrkQry & WrkAnd & "CHKPD <= " & WrkChkTo
    End If

    WrkSort = "VNDNR,PPDT8,CHKPD,INVNO"
    Counter = 0
    myAPEHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()


ReadNext:
    myAPEHSTQ.ReadQry()
    If Not myAPEHSTQ.IsEOF Then
      Counter = Counter + 1
      myVENDOR.GetOneRecordP(myAPEHSTQ._VNDNR)

      'Create Report
      With myAPEHSTQ
        If ._RECNO = 0 Then
          SavePONbr = ._PONBR
          GoTo NextRec
        End If
        WrkName = ""
        WrkAcct = ""
        WrkAcctDesc = ""
        WrkAcct = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)

        dr = ds.Tables(0).NewRow
        dr.Item("rptid") = "D"
        dr.Item("vndnr") = ._VNDNR
        dr.Item("vennm") = myVENDOR._VENNM
        dr.Item("chkpd") = ._CHKPD
        dr.Item("ppdt8") = MyUtils.GetDBDate(._PPDT8)
        dr.Item("bnkcd") = ._BNKCD
        dr.Item("invno") = ._INVNO
        dr.Item("invd8") = MyUtils.GetDBDate(._INVD8)
        dr.Item("amtgr") = ._AMTGR
        dr.Item("amtds") = ._AMTDS
        dr.Item("amtpd") = ._AMTGR
        dr.Item("avoid") = ._AVOID
        dr.Item("ponbr") = SavePONbr
        dr.Item("acctdesc") = WrkAcct
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
    myAPEHSTQ.CloseFile()

  End Sub
  Public Function BuildAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer, ByVal Obj As Integer,
 ByVal Func As Integer, ByVal Subfn As Integer) As String
    Dim sb As StringBuilder = New StringBuilder

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
    sb.Append(Format(Subfn, "0000"))
    Return sb.ToString
  End Function
End Module
