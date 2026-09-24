Imports System.IO
Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myMRHSTQ As MRHSTQ.MyData
  Dim myTXGLAD As TXGLAD.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim sw As StreamWriter

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBatchNo As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myMRHSTQ = New MRHSTQ.MyData()
    myMRHSTQ.MyDBConn = myDBConnect
    myTXGLAD = New TXGLAD.MyData(myDBConnect)

    With MyFrmGLA34B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
    End With

    If myTOWN._TOWNBR = 4 Then 'Avon
      GetCombined()
    Else
      GetDetail()
    End If
  End Sub
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Amount", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkStr As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkFilePath As String
    Dim SaveBatch As Integer
    Dim WrkBchCnt As Integer
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    WrkQry = "RECDT >= " & WrkFrom & WrkAnd & "RECDT <=" & WrkTo

    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BCHNO= " & WrkBatchNo
    End If

    WrkBchCnt = 0
    WrkSort = "RECDT, BCHNO"
    myMRHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myMRHSTQ.ReadQry()
    If Not myMRHSTQ.IsEOF Then
      With myMRHSTQ
        Counter = Counter + 1
        If SaveBatch <> ._BCHNO Then
          If SaveBatch > 0 Then sw.Close()
          WrkBchCnt = WrkBchCnt + 1
          WrkFilePath = MyAppSettings.FilePath & "misc-" & ._BCHNO & "-" & ._RECDT & ".csv"
          sw = New StreamWriter(WrkFilePath)
          WriteHeader()
        End If
        With myMRHSTQ
          If ._CASH <> 0 Then
            WrkStr = WriteRecord(._CASH, "CA")
            sw.WriteLine(WrkStr)
          End If
          If ._CHECK <> 0 Then
            WrkStr = WriteRecord(._CHECK, "CK")
            sw.WriteLine(WrkStr)
          End If
          If ._CREDIT <> 0 Then
            WrkStr = WriteRecord(._CHECK, "CC")
            sw.WriteLine(WrkStr)
          End If
        End With
        SaveBatch = ._BCHNO
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

CloseFiles:
    myMRHSTQ.CloseFile()
    myTXGLAD.CloseFile()
    If Counter > 0 Then
      sw.Close()
    End If
    MsgBox(WrkBchCnt & " files have been created", MsgBoxStyle.Information, "Process completed")

  End Sub
  Private Sub GetCombined()
    Dim WrkStr As String
    Dim WrkSort As String
    Dim WrkQry As String
    Dim WrkCredit As Boolean
    Dim WrkFilePath As String
    Dim Counter As Integer

    WrkAnd = " and "
    WrkOr = " or "
    WrkQry = "RECDT >= " & WrkFrom & WrkAnd & "RECDT <=" & WrkTo

    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BCHNO= " & WrkBatchNo
    End If

    WrkSort = "RECDT, BCHNO, CODE"
    myMRHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    WrkFilePath = MyAppSettings.FilePath & "misc-" & WrkFrom & "-" & WrkTo & ".csv"
    sw = New StreamWriter(WrkFilePath)
    WriteHeader()
ReadNext:
    myMRHSTQ.ReadQry()
    If Not myMRHSTQ.IsEOF Then
      With myMRHSTQ
        Counter = Counter + 1
        If Trim(._CODE) = "" Then
          If ._CREDIT <> 0 Then
            WrkCredit = True
          Else
            WrkCredit = False
          End If
        End If
        If ._TOTAL <> 0 Then
          If WrkCredit Then
            WrkStr = WriteRecord(._TOTAL, "CC")
          Else
            WrkStr = WriteRecord(._TOTAL, "CK")
          End If
          sw.WriteLine(WrkStr)
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

CloseFiles:
    myMRHSTQ.CloseFile()
    myTXGLAD.CloseFile()
    If Counter > 0 Then
      sw.Close()
    End If
    MsgBox("File has been created", MsgBoxStyle.Information, "Process completed")

  End Sub
  Private Sub WriteHeader()
    Dim sb As StringBuilder
    sb = New StringBuilder
    sb.Append("Date")
    sb.Append(",")
    sb.Append("Code")
    sb.Append(",")
    sb.Append("Description")
    sb.Append(",")
    sb.Append("Qty")
    sb.Append(",")
    sb.Append("Amount")
    sb.Append(",")
    sb.Append("PayType")
    sw.WriteLine(sb.ToString)
  End Sub
  Private Function WriteRecord(ByVal WrkAmount As Decimal, ByVal WrkPayType As String) As String
    Dim sb As StringBuilder
    Dim WrkNote As String
    Dim WrkQty As Integer
    With myMRHSTQ
      sb = New StringBuilder
      sb.Append(Format(MyUtils.GetDBDate(._RECDT), "M/d/yyyy"))
      sb.Append(",")
      sb.Append(._CODE)
      sb.Append(",")
      WrkNote = "Misc " & ._BCHNO
      sb.Append(WrkNote)
      sb.Append(",")
      WrkQty = 1
      sb.Append(WrkQty)
      sb.Append(",")
      sb.Append(Format(WrkAmount, "fixed"))
      sb.Append(",")
      sb.Append(WrkPayType)

      'Create Report
      'dr = ds.Tables(0).NewRow
      'dr.Item("batchno") = ._BATCHN
      'dr.Item("year") = ._YEAR
      'dr.Item("type") = ._TYPE
      'dr.Item("code") = WrkRWACode
      'dr.Item("amount") = WrkAmount
      'ds.Tables(0).Rows.Add(dr)
    End With

    Return sb.ToString
  End Function
End Module
