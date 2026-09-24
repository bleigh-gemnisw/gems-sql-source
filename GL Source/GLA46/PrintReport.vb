Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBatchFrom As Integer
  Dim WrkBatchTo As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)

    With MyFrmGLA46B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkBatchFrom = MyUtils.CnvSng(.TxtBatchFrom.Text)
      WrkBatchTo = MyUtils.CnvSng(.TxtBatchTo.Text)
    End With
    If ds.Tables.Count = 0 Then
      BuildDS(ds)
    Else
      ds.Clear()
    End If
    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()

  End Sub
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batchn", Type.GetType("System.Decimal"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkFilePath As String
    Dim WrkAmount As Decimal
    Dim SaveBatch As Decimal
    Dim Counter As Integer

    If MyServerName = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    SaveBatch = -1
    WrkAmount = 0
    WrkQry = "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    WrkQry = WrkQry & WrkAnd & "RCODE <> 'I'" & WrkAnd & "RCODE <> 'V'"
    If WrkBatchFrom > 0 Then
      If WrkBatchTo = 0 Then
        WrkBatchTo = WrkBatchFrom
      End If
      WrkQry = WrkQry & WrkAnd & "BATCHN>=" & WrkBatchFrom & WrkAnd & "BATCHN<=" & WrkBatchTo
    End If

    WrkSort = "BATCHN, DIST"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()
    WrkFilePath = MyAppSettings.FilePath & "/gems-" & WrkFrom & "-" & WrkTo & ".csv"
    sw = New StreamWriter(WrkFilePath)

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        WriteFile()
        If SaveBatch >= 0 And SaveBatch <> ._BATCHN Then
          AddReport(SaveBatch, WrkAmount)
          WrkAmount = 0
        End If
        SaveBatch = ._BATCHN
        WrkAmount = WrkAmount + ._PAMT + ._IAMT + ._LAMT + ._PCAMT
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

CloseFiles:
    AddReport(SaveBatch, WrkAmount)
    myFrmProgress.Close()
    myTXHSTQ.CloseFile()
    sw.Close()
  End Sub
  Private Sub WriteFile()
    Dim sb As StringBuilder
    'Export File
    sb = New StringBuilder
    With myTXHSTQ
      sb.Append(Trim(._RCODE))
      sb.Append(",")
      sb.Append(._BATCHN)
      sb.Append(",")
      sb.Append(._BATCHS)
      sb.Append(",")
      sb.Append(._LISTNo)
      sb.Append(",")
      sb.Append(._YEAR)
      sb.Append(",")
      sb.Append(Trim(._TYPE))
      sb.Append(",")
      sb.Append(._PAMT)
      sb.Append(",")
      sb.Append(._IAMT)
      sb.Append(",")
      sb.Append(._LAMT)
      sb.Append(",")
      sb.Append(._PCAMT)
      sb.Append(",")
      sb.Append(._DIST)
      sb.Append(",")
      sb.Append(Trim(._ADJCD))
      sb.Append(",")
      sb.Append(Trim(._PENCD))
      sb.Append(",")
      sb.Append(._PDATE)
      sb.Append(",")
      sb.Append(._PDATE)
      sb.Append(",")
    End With
    sw.WriteLine(sb.ToString)
    sb = Nothing

  End Sub
  Private Sub AddReport(ByVal SaveBatch As Integer, ByVal SaveAmount As Decimal)
    dr = ds.Tables(0).NewRow
    dr.Item("batchn") = SaveBatch
    dr.Item("amount") = SaveAmount
    ds.Tables(0).Rows.Add(dr)
  End Sub
End Module
