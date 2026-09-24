Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myMRHSTQ As MRHSTQ.MyData
  Dim myMRCODE As MRCODE.MyData
  Dim ds1 As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkDetail As Boolean
  Dim WrkBatchNo As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PrtReport()

    myMRHSTQ = New MRHSTQ.MyData()
    myMRHSTQ.MyDBConn = myDBConnect
    myMRCODE = New MRCODE.MyData()
    myMRCODE.MyDBConn = myDBConnect

    With MyFrmMR200B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds1
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
      .Columns.Add("Date", Type.GetType("System.DateTime"))
      .Columns.Add("Code", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Cash", Type.GetType("System.Decimal"))
      .Columns.Add("Check", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    ds1.Tables.Add(myTable)

  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Pos As Integer
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

    WrkSort = "CODE"
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
        If MySelCodes <> String.Empty Then
          Pos = InStr(MySelCodes, Trim(._CODE))
          If Pos <= 0 Then
            GoTo NextRec
          End If
        End If
        dr = ds1.Tables(0).NewRow
        dr.Item("batchno") = ._BCHNO
        dr.Item("date") = MyUtils.GetDBDate(._RECDT)
        dr.Item("code") = ._CODE
        myMRCODE.GetOneRecordP(._CODE)
        If Not myMRCODE.RecordNotFound Then
          With myMRCODE
            dr.Item("descr") = Trim(._DESCR)
          End With
        End If
        dr.Item("cash") = ._CASH
        dr.Item("check") = ._CHECK
        dr.Item("credit") = ._CREDIT
        dr.Item("total") = ._TOTAL
      End With
      ds1.Tables(0).Rows.Add(dr)
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
    myMRCODE.CloseFile()

  End Sub
End Module
