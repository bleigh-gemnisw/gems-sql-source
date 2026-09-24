Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow

  Dim WrkType As String
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkBatchType As String
  Dim WrkPayType As String
  Dim WrkRefunds As Boolean
  Dim WrkFromYear As Integer
  Dim WrkToYear As Integer
  Dim WrkAnd As String
  Dim WrkOr As String

  Dim WrkTCount As Integer
  Dim WrkTPrinPaid As Decimal
  Dim WrkTPenPaid As Decimal
  Dim WrkTIntPaid As Decimal
  Dim WrkTLienPaid As Decimal
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)

    With MyFrmTXE20B
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      Select Case .CboBatch.SelectedItem.ToString
        Case "All"
          WrkBatchType = ""
        Case "Bank Service"
          WrkBatchType = "K"
        Case "Escrow"
          WrkBatchType = "E"
        Case "Leasing"
          WrkBatchType = "G"
        Case "Liened"
          WrkBatchType = "L"
        Case "Lock Box"
          WrkBatchType = "B"
        Case "Misc/Penny Batch"
          WrkBatchType = "M"
        Case "PC"
          WrkBatchType = "P"
        Case "Suspense"
          WrkBatchType = ""
        Case "Web Payment"
          WrkBatchType = "W"
      End Select
      If .RbPayAll.Checked Then WrkPayType = ""
      If .RbPayCash.Checked Then WrkPayType = "1"
      If .RbPayCheck.Checked Then WrkPayType = "2"
      If .RbPayCredit.Checked Then WrkPayType = "3"
      WrkRefunds = .ChkRefunds.Checked
      WrkFromYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToYear = MyUtils.CnvSng(.TxtToGLYear.Text)
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
      ClearTotals()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.WrkRefunds = WrkRefunds
    MyCrViewer.WrkBatchType = WrkBatchType
    MyCrViewer.WrkPayType = WrkPayType
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("BatchDt", Type.GetType("System.DateTime"))
      .Columns.Add("Batch", Type.GetType("System.Int32"))
      .Columns.Add("BatchType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TPrinPaid", Type.GetType("System.Double"))
      .Columns.Add("TPenPaid", Type.GetType("System.Double"))
      .Columns.Add("TIntPaid", Type.GetType("System.Double"))
      .Columns.Add("TLienPaid", Type.GetType("System.Double"))
      .Columns.Add("TTotPaid", Type.GetType("System.Double"))
    End With
    ds.Tables.Add(myTable)

  End Sub
  Private Sub ClearTotals()
    WrkTCount = 0
    WrkTPrinPaid = 0
    WrkTPenPaid = 0
    WrkTIntPaid = 0
    WrkTLienPaid = 0
  End Sub
  Private Sub GetDetail()
    Dim WrkSort As String
    Dim WrkQry As String
    Dim Counter As Integer
    Dim SaveBatchDt As Date
    Dim SaveBatch As Integer
    Dim SaveBatchType As String
    Dim SaveYear As Integer
    Dim SaveType As String
    Dim ChkDate As Date

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Counter = 0
    WrkQry = "RCODE <>'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd &
  "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo

    If WrkBatchType <> "" Then
      WrkQry = WrkQry & WrkAnd & "BATCHA=" & MyUtils.Quo(WrkBatchType)
    End If

    If WrkBatchType <> "L" Then
      WrkQry = WrkQry & WrkAnd & "BATCHA<>'L'"
    End If

    If Not WrkRefunds Then
      WrkQry = WrkQry & WrkAnd & "ADJCD<>'R'"
    End If

    If WrkPayType <> String.Empty Then
      WrkQry = WrkQry & WrkAnd & "CORC=" & MyUtils.Quo(WrkPayType)
    End If

    If WrkFromYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromYear
    End If

    If WrkToYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR <= " & WrkToYear
    End If

    MyTypes = MyFrmTXE20B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    SaveType = ""
    SaveBatchType = ""
    WrkSort = "PDATE, BATCHA, BATCHN, YEAR, TYPE"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        If SaveBatchDt <> ChkDate And SaveBatchDt <> MyUtils.GetDBDate(._PDATE) Or
      SaveBatch <> ._BATCHN Or
      SaveType <> "" And SaveType <> ._TYPE Or
      SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteTotals(SaveBatchDt, SaveBatch, SaveBatchType, SaveYear, SaveType)
          ClearTotals()
        End If
        If SaveBatch <> ._BATCHN Then
          SaveBatchType = GetBatchType(._BATCHA)
        End If
        SaveBatchDt = MyUtils.GetDBDate(._PDATE)
        SaveBatch = ._BATCHN
        SaveYear = ._YEAR
        SaveType = ._TYPE

        WrkTCount = WrkTCount + 1
        WrkTPrinPaid = WrkTPrinPaid + ._PAMT
        WrkTPenPaid = WrkTPenPaid + ._PCAMT
        WrkTIntPaid = WrkTIntPaid + ._IAMT
        WrkTLienPaid = WrkTLienPaid + ._LAMT
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

    WriteTotals(SaveBatchDt, SaveBatch, SaveBatchType, SaveYear, SaveType)
    myFrmProgress.Close()

CloseFiles:
    myTXHSTQ.CloseFile()

  End Sub
  Private Sub WriteTotals(ByVal SaveBatchDt As Date, ByVal SaveBatch As Integer,
  ByVal SaveBatchType As String, ByVal SaveYear As Integer, ByVal SaveType As String)
    If WrkTCount = 0 Then Exit Sub

    dr = ds.Tables(0).NewRow
    dr.Item("batchdt") = SaveBatchDt
    dr.Item("batch") = SaveBatch
    dr.Item("batchtype") = SaveBatchType
    dr.Item("year") = SaveYear
    dr.Item("type") = GetTXTypeDesc(SaveType)
    dr.Item("tcount") = WrkTCount
    dr.Item("tprinpaid") = WrkTPrinPaid
    dr.Item("tpenpaid") = WrkTPenPaid
    dr.Item("tintpaid") = WrkTIntPaid
    dr.Item("tlienpaid") = WrkTLienPaid
    dr.Item("ttotpaid") = WrkTPrinPaid + WrkTPenPaid + WrkTIntPaid + WrkTLienPaid
    ds.Tables(0).Rows.Add(dr)
  End Sub
  Private Function BuildSelectTypes() As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim StrLen As Integer
    Dim I As Integer

    If MyTypes = "" Then
      Return ""
    End If

    sbSelect = New System.Text.StringBuilder
    sbSelect.Append("TYPE=%Values(")
    StrLen = Len(MyTypes)

    For I = 1 To StrLen
      WrkType = Mid(MyTypes, I, 1)
      sbSelect.Append(Chr(34) & WrkType & Chr(34) & " ")
    Next

    sbSelect.Append(")")
    Return sbSelect.ToString
  End Function
  Private Function BuildSelectQryPC(ByVal WrkStrIn As String, ByVal WrkSelTypes As String) As String
    Dim sbSelect As System.Text.StringBuilder
    Dim WrkType As String
    Dim WrkStrOut As String
    Dim StrLen As Integer
    Dim I As Integer

    WrkStrOut = ""
    If WrkSelTypes = "" Then
      Return ""
    End If

    StrLen = Len(WrkSelTypes)
    sbSelect = New System.Text.StringBuilder
    For I = 1 To StrLen
      If I > 1 Then
        sbSelect.Append(",")
      End If
      WrkType = Mid(WrkSelTypes, I, 1)
      sbSelect.Append(MyUtils.Quo(WrkType))
    Next
    If WrkStrIn = "" Then
      WrkStrOut = "TYPE IN(" & sbSelect.ToString & ")"
    Else
      WrkStrOut = WrkStrIn & WrkAnd & "TYPE IN(" & sbSelect.ToString & ")"
    End If
    sbSelect = Nothing
    Return WrkStrOut
  End Function

  Private Function GetBatchType(ByVal BatchA As String) As String

    WrkBatchType = "All"
    Select Case BatchA
      Case "B"
        WrkBatchType = "Lock Box"
      Case "E"
        WrkBatchType = "Escrow"
      Case "G"
        GetBatchType = "Leasing"
      Case "K"
        WrkBatchType = "Bank Service"
      Case "L"
        WrkBatchType = "Liened"
      Case "M"
        GetBatchType = "Misc/Penny Batch"
      Case "P"
        WrkBatchType = "PC"
      Case "W"
        WrkBatchType = "Web Payment"
    End Select
    If MyFrmTXE20B.CboBatch.SelectedItem.ToString = "Suspense" Then
      WrkBatchType = "Suspense"
    End If
    Return WrkBatchType
  End Function
End Module






