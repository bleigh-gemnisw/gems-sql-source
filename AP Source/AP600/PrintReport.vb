Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myAPEHSTQ As APEHSTQ.MyData
  Dim myAPEHST As APEHST.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkAsofDate As Date
  Dim WrkUpdate As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myAPEHSTQ = New APEHSTQ.MyData()
    myAPEHSTQ.MyDBConn = myDBConnect
    myAPEHST = New APEHST.MyData()
    myAPEHST.MyDBConn = myDBConnect

    With MyFrmAP600B
      WrkAsofDate = .DtPckAsof.Value
      WrkUpdate = .ChkUpdate.Checked
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If

    GetDetail()

Done:
    MyCRViewer = New FrmCrViewer
    With MyCRViewer
      .wrkds = ds
      .WrkAsofDate = Format(WrkAsofDate, "short date")
      .Show()
    End With
  End Sub
  Private Sub GetDetail()
    Dim sw As StreamWriter
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkPaidDate As Date
    Dim Counter As Integer
    Dim WrkStr As String

    WrkAnd = " and "
    WrkOr = " or "

    Counter = 0
    WrkQry = "ppdt8<=" & MyUtils.SetDBDate(WrkAsofDate)
    WrkSort = "VNDNR, INVNO desc, BCHNO, RECNO"

    If MyFrmAP600B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmAP600B.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

    myAPEHSTQ.OpenQry(WrkSort, WrkQry)
    If myAPEHSTQ.IsEOF Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myAPEHSTQ.ReadQry()
    If Not myAPEHSTQ.IsEOF Then
      Counter = Counter + 1
      With myAPEHSTQ
        If ._RECNO = 0 Then
          If ._PPDT8 > 0 Then
            WrkPaidDate = MyUtils.GetDBDate(._PPDT8)
          Else
            WrkPaidDate = MyUtils.GetDBDateMDY(._INVD8)
          End If
        End If
        If WrkPaidDate > WrkAsofDate Then
          GoTo NextRec
        End If
        If ._RECNO = 0 Then
          dr = ds.Tables(0).NewRow
          dr.Item("bchno") = ._BCHNO
          dr.Item("invno") = ._INVNO
          dr.Item("vndnr") = ._VNDNR
          dr.Item("amtpd") = ._AMTPD
          dr.Item("ppdt") = WrkPaidDate
          ds.Tables(0).Rows.Add(dr)
        End If
        If MyFrmAP600B.LblFilePath.Text <> String.Empty Then
          sw.WriteLine(DownloadCSV)
        End If
        If WrkUpdate And ._RECNO = 0 And ._PPDT8 = 0 Then
          WrkStr = "VNDNR='" & ._VNDNR & "' and INVNO='" & ._INVNO & "' and bchno=" & ._BCHNO & " and INVD8=" & ._INVD8
          myAPEHST.DeleteRecords(WrkStr)
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

    If MyFrmAP600B.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    myAPEHST.DeleteRecords(WrkQry)

    myAPEHSTQ.CloseFile()
    myFrmProgress.Close()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Bchno", Type.GetType("System.Int32"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("Amtpd", Type.GetType("System.Decimal"))
      .Columns.Add("Ppdt", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const CQuote As String = Chr(34)

    With myAPEHSTQ
      sb = New StringBuilder
      sb.Append(CQuote)
      sb.Append(Trim(._VNDNR))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._INVNO))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._RECNO)
      sb.Append(CComma)
      sb.Append(._AMTGR)
      sb.Append(CComma)
      sb.Append(._AMTDS)
      sb.Append(CComma)
      sb.Append(._AMTSH)
      sb.Append(CComma)
      sb.Append(._AMTNT)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._DSCTX))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._PONBR)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._F1099))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._LEOPN))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._FDNBR)
      sb.Append(CComma)
      sb.Append(._SFUND)
      sb.Append(CComma)
      sb.Append(._DPNBR)
      sb.Append(CComma)
      sb.Append(._OBNBR)
      sb.Append(CComma)
      sb.Append(._FNPGM)
      sb.Append(CComma)
      sb.Append(._SUBFN)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._VENNM))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._BCHNO)
      sb.Append(CComma)
      sb.Append(._LSTPD)
      sb.Append(CComma)
      sb.Append(._AMTPD)
      sb.Append(CComma)
      sb.Append(._CHKPD)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._BNKCD))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CSHYN))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._MANUL))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._FSCYR)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._AVOID))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._VNCAT))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._OTIME))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._FA))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._INVD8)
      sb.Append(CComma)
      sb.Append(._DUED8)
      sb.Append(CComma)
      sb.Append(._PPDT8)
      sb.Append(CComma)
      sb.Append(._LSTP8)
      sb.Append(CComma)
      sb.Append(._PRJ)
      sb.Append(CComma)
      sb.Append(._APPST)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._VSORT))
      sb.Append(CQuote)
    End With
    Return sb.ToString
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("Vendor Number")
    sb.Append(CComma)
    sb.Append("Invoice Number")
    sb.Append(CComma)
    sb.Append("Recno Seqno")
    sb.Append(CComma)
    sb.Append("Gross Amount")
    sb.Append(CComma)
    sb.Append("Amount Discount")
    sb.Append(CComma)
    sb.Append("Amount S/H")
    sb.Append(CComma)
    sb.Append("Net Amount")
    sb.Append(CComma)
    sb.Append("Description")
    sb.Append(CComma)
    sb.Append("PO Number")
    sb.Append(CComma)
    sb.Append("1099 Flag")
    sb.Append(CComma)
    sb.Append("Leave Encum Open")
    sb.Append(CComma)
    sb.Append("Fund")
    sb.Append(CComma)
    sb.Append("Sun Fund")
    sb.Append(CComma)
    sb.Append("Dept")
    sb.Append(CComma)
    sb.Append("Object")
    sb.Append(CComma)
    sb.Append("Func/Prog")
    sb.Append(CComma)
    sb.Append("Sunfunction")
    sb.Append(CComma)
    sb.Append("Vendor Name")
    sb.Append(CComma)
    sb.Append("Batch Number")
    sb.Append(CComma)
    sb.Append("Last Paid")
    sb.Append(CComma)
    sb.Append("Amt Paid")
    sb.Append(CComma)
    sb.Append("Chk# Paid")
    sb.Append(CComma)
    sb.Append("Bank")
    sb.Append(CComma)
    sb.Append("Cash Acct")
    sb.Append(CComma)
    sb.Append("Manual Check")
    sb.Append(CComma)
    sb.Append("Fiscal Year")
    sb.Append(CComma)
    sb.Append("Void")
    sb.Append(CComma)
    sb.Append("Category")
    sb.Append(CComma)
    sb.Append("One Time Vendor")
    sb.Append(CComma)
    sb.Append("Fixed Asset")
    sb.Append(CComma)
    sb.Append("Invoice Date")
    sb.Append(CComma)
    sb.Append("Due Date")
    sb.Append(CComma)
    sb.Append("Check Date")
    sb.Append(CComma)
    sb.Append("Last Paid")
    sb.Append(CComma)
    sb.Append("Project")
    sb.Append(CComma)
    sb.Append("Posting Date")
    sb.Append(CComma)
    sb.Append("Sort Field")
    Return sb.ToString
  End Function
End Module
