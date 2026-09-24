Imports System.io
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myLEDHSTQ As LEDHSTQ.MyData
  Dim myLEDHST As LEDHST.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkAsofDate As Date
  Dim WrkUpdate As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()
    myLEDHSTQ = New LEDHSTQ.MyData()
    myLEDHSTQ.MyDBConn = myDBConnect
    myLEDHST = New LEDHST.MyData()
    myLEDHST.MyDBConn = myDBConnect

    With MyFrmGL600B
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
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkQry = "pstdt<=" & MyUtils.SetDBDate(WrkAsofDate)
    WrkSort = "PSTDT, BCHNO, JRNSQ"

    If MyFrmGL600B.LblFilePath.Text <> String.Empty Then
      sw = New StreamWriter(MyFrmGL600B.LblFilePath.Text)
      sw.WriteLine(HeadingsCSV)
    End If

    myLEDHSTQ.OpenQry(WrkSort, WrkQry)
    If myLEDHSTQ.IsEOF Then Exit Sub

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myLEDHSTQ.ReadQry()
    If Not myLEDHSTQ.IsEOF Then
      Counter = Counter + 1
      With myLEDHSTQ
        dr = ds.Tables(0).NewRow
        dr.Item("bchno") = ._BCHNO
        dr.Item("jrnsq") = ._JRNSQ
        dr.Item("gltyp") = ._GLTYP
        dr.Item("trtyp") = ._TRTYP
        dr.Item("amtyp") = ._AMTYP
        dr.Item("tramt") = ._TRAMT
        dr.Item("tdesc") = ._TDESC
        dr.Item("pstdt") = MyUtils.GetDBDate(._PSTDT)
        ds.Tables(0).Rows.Add(dr)
        If MyFrmGL600B.LblFilePath.Text <> String.Empty Then
          sw.WriteLine(DownloadCSV)
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

    If MyFrmGL600B.LblFilePath.Text <> String.Empty Then
      sw.Flush()
      sw.Close()
    End If
    If WrkUpdate Then
      myLEDHST.DeleteRecords(WrkQry)
    End If
    myLEDHSTQ.CloseFile()
    myFrmProgress.Close()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Bchno", Type.GetType("System.Int32"))
      .Columns.Add("Jrnsq", Type.GetType("System.Int32"))
      .Columns.Add("Gltyp", Type.GetType("System.String"))
      .Columns.Add("Trtyp", Type.GetType("System.String"))
      .Columns.Add("Amtyp", Type.GetType("System.String"))
      .Columns.Add("Tramt", Type.GetType("System.Decimal"))
      .Columns.Add("Tdesc", Type.GetType("System.String"))
      .Columns.Add("Pstdt", Type.GetType("System.DateTime"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Function DownloadCSV() As String
    Dim sb As StringBuilder
    Const CComma As String = ","
    Const CQuote As String = Chr(34)

    With myLEDHSTQ
      sb = New StringBuilder
      sb.Append(CQuote)
      sb.Append(Trim(._BALFC))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._TRTYP))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._CBLCD))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._GLTYP))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._TRFTO))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._FDNBR)
      sb.Append(CComma)
      sb.Append(._DPNBR)
      sb.Append(CComma)
      sb.Append(._OBNBR)
      sb.Append(CComma)
      sb.Append(._FNPGM)
      sb.Append(CComma)
      sb.Append(._DATED)
      sb.Append(CComma)
      sb.Append(._FIL10)
      sb.Append(CComma)
      sb.Append(._SRCDE)
      sb.Append(CComma)
      sb.Append(._TRAMT)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._TDESC))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._REFNO)
      sb.Append(CComma)
      sb.Append(._ORIG)
      sb.Append(CComma)
      sb.Append(._SUBFN)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._AUTOG))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._FIL045))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._BCHNO)
      sb.Append(CComma)
      sb.Append(._TRNBR)
      sb.Append(CComma)
      sb.Append(._JRNSQ)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._GLPST))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._AMTYP))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._INVNR))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._SFUND)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._PRF))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._ROCR))
      sb.Append(CQuote)
      sb.Append(CComma)
      sb.Append(._PSTDT)
      sb.Append(CComma)
      sb.Append(._TDATE)
      sb.Append(CComma)
      sb.Append(._PONBR)
      sb.Append(CComma)
      sb.Append(._CHKN)
      sb.Append(CComma)
      sb.Append(._FSCYR)
      sb.Append(CComma)
      sb.Append(._CNTRL)
      sb.Append(CComma)
      sb.Append(CQuote)
      sb.Append(Trim(._RECLS))
      sb.Append(CQuote)
    End With
    Return sb.ToString
  End Function
  Private Function HeadingsCSV() As String
    Dim sb As StringBuilder
    Dim CComma As String = ","

    sb = New StringBuilder
    sb.Append("Balance Forward")
    sb.Append(CComma)
    sb.Append("Transaction Type")
    sb.Append(CComma)
    sb.Append("Closing Balance Code")
    sb.Append(CComma)
    sb.Append("G/L Type")
    sb.Append(CComma)
    sb.Append("Transfer Code")
    sb.Append(CComma)
    sb.Append("Fund")
    sb.Append(CComma)
    sb.Append("Dept")
    sb.Append(CComma)
    sb.Append("Object")
    sb.Append(CComma)
    sb.Append("Func/Prog")
    sb.Append(CComma)
    sb.Append("System Date")
    sb.Append(CComma)
    sb.Append("Fil10")
    sb.Append(CComma)
    sb.Append("Source")
    sb.Append(CComma)
    sb.Append("Trans Amount")
    sb.Append(CComma)
    sb.Append("Description")
    sb.Append(CComma)
    sb.Append("PO/Chk")
    sb.Append(CComma)
    sb.Append("Original Budget")
    sb.Append(CComma)
    sb.Append("Subfunction")
    sb.Append(CComma)
    sb.Append("Auto Generated")
    sb.Append(CComma)
    sb.Append("Filler")
    sb.Append(CComma)
    sb.Append("Batch Number")
    sb.Append(CComma)
    sb.Append("Tran Number")
    sb.Append(CComma)
    sb.Append("Journal Number")
    sb.Append(CComma)
    sb.Append("CD")
    sb.Append(CComma)
    sb.Append("Debit/Credit")
    sb.Append(CComma)
    sb.Append("Invoice Number")
    sb.Append(CComma)
    sb.Append("Sub Fund")
    sb.Append(CComma)
    sb.Append("User")
    sb.Append(CComma)
    sb.Append("Reoccurring")
    sb.Append(CComma)
    sb.Append("Posting Date")
    sb.Append(CComma)
    sb.Append("Tran Date")
    sb.Append(CComma)
    sb.Append("PO Number")
    sb.Append(CComma)
    sb.Append("Check Number")
    sb.Append(CComma)
    sb.Append("Fiscal Year")
    sb.Append(CComma)
    sb.Append("Control Acct")
    sb.Append(CComma)
    sb.Append("Reclass")
    Return sb.ToString
  End Function
End Module
