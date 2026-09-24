Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim ds1 As DataSet = New DataSet
  Dim ds2 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim dr2 As Data.DataRow

  Dim WrkType As String
  Dim WrkStatus As String
  Dim WrkFromGLYear As Integer
  Dim WrkToGLYear As Integer
  Dim WrkFrom As Integer
  Dim WrkTo As Integer
  Dim WrkSelection As String
  Dim WrkBatchType As String
  Dim WrkBatchNo As Integer
  Dim WrkDist As Integer
  Dim WrkDistAll As Boolean
  Dim WrkUser As Boolean
  Dim WrkAnd As String
  Dim WrkOr As String

  Dim WrkTCount As Integer
  Dim WrkTPrinPaid As Decimal
  Dim WrkTPenPaid As Decimal
  Dim WrkTIntPaid As Decimal
  Dim WrkTLienPaid As Decimal
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)

    With MyFrmTXE02B
      WrkFromGLYear = MyUtils.CnvSng(.TxtFromGLYear.Text)
      WrkToGLYear = MyUtils.CnvSng(.TxtToGLYear.Text)
      WrkFrom = MyUtils.SetDBDate(.DtPckFrom.Value)
      WrkTo = MyUtils.SetDBDate(.DtPckTo.Value)
      If .RbSelAll.Checked Then
        WrkSelection = ""
      End If
      If .RbAdjustments.Checked Then
        WrkSelection = "Adjustments"
      End If
      If .RbPayments.Checked Then
        WrkSelection = "Payments"
      End If
      If .RbRefunds.Checked Then
        WrkSelection = "Refunds"
      End If
      If .RbLiens.Checked Then
        WrkSelection = "Liens"
      End If
      If .RbSuspense.Checked Then
        WrkSelection = "Suspense"
      End If
      If .RbVoids.Checked Then
        WrkSelection = "Voids"
      End If
      If .RbTransfers.Checked Then
        WrkSelection = "Transfers"
      End If
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
      WrkBatchNo = MyUtils.CnvSng(.TxtBatch.Text)
      WrkDist = MyUtils.CnvSng(.TxtDist.Text)
      WrkDistAll = False
      If .TxtDist.Text = "" Then
        WrkDistAll = True
      End If
      WrkUser = .ChkUser.Checked
      WrkStatus = .TxtStatus.Text
    End With

    If ds1.Tables.Count = 0 Then
      BuildDS()
    Else
      ds1.Clear()
      ds2.Clear()
      ClearTotals()
    End If

    GetDetail()

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds1
    MyCrViewer.wrkds2 = ds2
    MyCrViewer.WrkSelection = WrkSelection
    MyCrViewer.WrkBatchDesc = GetBatchType(WrkBatchType)
    MyCrViewer.Show()

  End Sub

  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Comment", Type.GetType("System.String"))
      .Columns.Add("Reference", Type.GetType("System.String"))
      .Columns.Add("Prf", Type.GetType("System.String"))
      .Columns.Add("PrinPaid", Type.GetType("System.Double"))
      .Columns.Add("PenPaid", Type.GetType("System.Double"))
      .Columns.Add("IntPaid", Type.GetType("System.Double"))
      .Columns.Add("LienPaid", Type.GetType("System.Double"))
      .Columns.Add("TotPaid", Type.GetType("System.Double"))
      .Columns.Add("DatePaid", Type.GetType("System.DateTime"))
      .Columns.Add("BatchNo", Type.GetType("System.Int32"))
    End With
    ds1.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TPrinPaid", Type.GetType("System.Double"))
      .Columns.Add("TPenPaid", Type.GetType("System.Double"))
      .Columns.Add("TIntPaid", Type.GetType("System.Double"))
      .Columns.Add("TLienPaid", Type.GetType("System.Double"))
      .Columns.Add("TTotPaid", Type.GetType("System.Double"))
    End With
    ds2.Tables.Add(myTable2)

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
    Dim SaveYear As Integer
    Dim SaveType As String
    Dim Counter As Integer
    Dim Good As Boolean

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If

    Select Case WrkSelection
      Case "Suspense"
        WrkQry = "RCODE ='S'" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
      Case "Voids"
        WrkQry = "RCODE ='V'" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
      Case "Transfers"
        WrkQry = "PRF ='TXA12'" & WrkAnd & "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
      Case Else
        WrkQry = "RCODE <> 'I'" & WrkAnd & "RCODE <>'V'" & WrkAnd &
    "PDATE >= " & WrkFrom & WrkAnd & "PDATE <=" & WrkTo
    End Select

    If WrkBatchType <> "" Then
      WrkQry = WrkQry & WrkAnd & "BATCHA=" & MyUtils.Quo(WrkBatchType)
    End If

    If WrkBatchType <> "L" Then
      WrkQry = WrkQry & WrkAnd & "BATCHA<>'L'"
    End If

    If WrkFromGLYear > 0 Then
      WrkQry = WrkQry & WrkAnd & "YEAR >= " & WrkFromGLYear _
  & WrkAnd & "YEAR <= " & WrkToGLYear
    End If
    If Not WrkDistAll Then
      WrkQry = WrkQry & WrkAnd & "dist=" & WrkDist
    End If

    If WrkBatchNo > 0 Then
      WrkQry = WrkQry & WrkAnd & "BATCHN= " & WrkBatchNo
    End If

    MyTypes = MyFrmTXE02B.TxtTypes.Text
    If MyTypes <> "" Then
      WrkQry = BuildSelectQryPC(WrkQry, MyTypes)
    End If

    WrkSort = "YEAR, TYPE, DIST, LIST#"
    myTXHSTQ.OpenQry(WrkSort, WrkQry)

    myFrmProgress = New FrmProgress
    myFrmProgress.Show()
    myFrmProgress.Refresh()
    Application.DoEvents()

    SaveType = ""
ReadNext:
    myTXHSTQ.ReadQry()
    If Not myTXHSTQ.IsEOF Then
      With myTXHSTQ
        Counter = Counter + 1
        dr = ds1.Tables(0).NewRow
        If SaveType <> "" And SaveType <> ._TYPE Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        If SaveYear > 0 And SaveYear <> ._YEAR Then
          WriteTotals(SaveYear, SaveType)
          ClearTotals()
        End If
        SaveYear = ._YEAR
        SaveType = ._TYPE

        'Filter records based on selection
        Select Case WrkSelection
          Case "Adjustments"
            If ._ADJCD <> "A" Then GoTo NextRec
          Case "Liens"
            If ._LAMT = 0 Then GoTo NextRec
          Case "Payments"
            If ._PAMT <= 0 Then GoTo NextRec
          Case "Refunds"
            If ._ADJCD <> "R" Then GoTo NextRec
          Case Else
        End Select

        myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            'Filter - Include Status Codes
            If Trim(WrkStatus) > "" Then
              Good = False
              If WrkStatus = String.Empty Then
                Good = True
              End If
              If Not Good And Trim(._STCD1) <> String.Empty Then
                If InStr(WrkStatus, Trim(._STCD1)) > 0 Then
                  Good = True
                End If
              End If
              If Not Good And Trim(._STCD2) <> String.Empty Then
                If InStr(WrkStatus, Trim(._STCD2)) > 0 Then
                  Good = True
                End If
              End If
              If Not Good And Trim(._STCD3) <> String.Empty Then
                If InStr(WrkStatus, Trim(._STCD3)) > 0 Then
                  Good = True
                End If
              End If
              If Not Good And Trim(._STCD4) <> String.Empty Then
                If InStr(WrkStatus, Trim(._STCD4)) > 0 Then
                  Good = True
                End If
              End If
              If Not Good And Trim(._STCD5) <> String.Empty Then
                If InStr(WrkStatus, Trim(._STCD5)) > 0 Then
                  Good = True
                End If
              End If
              If Not Good Then GoTo NextRec
            End If
          End With
        End If

        WrkTCount = WrkTCount + 1
        dr.Item("listno") = ._LISTNo
        dr.Item("year") = ._YEAR
        dr.Item("type") = ._TYPE
        dr.Item("comment") = Trim(._COMM)
        dr.Item("reference") = Trim(._REF)
        If WrkUser Then
          dr.Item("prf") = Trim(._PRF)
        Else
          dr.Item("prf") = String.Empty
        End If
        dr.Item("prinpaid") = ._PAMT
        dr.Item("penpaid") = ._PCAMT
        dr.Item("intpaid") = ._IAMT
        dr.Item("lienpaid") = ._LAMT
        dr.Item("totpaid") = ._PAMT + ._PCAMT + ._IAMT + ._LAMT
        dr.Item("reference") = Trim(._REF)
        dr.Item("datepaid") = MyUtils.GetDBDate(._PDATE)
        dr.Item("batchno") = ._BATCHN
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            dr.Item("name") = Trim(._NAME)
          End With
        End If
        WrkTPrinPaid = WrkTPrinPaid + ._PAMT
        WrkTPenPaid = WrkTPenPaid + ._PCAMT
        WrkTIntPaid = WrkTIntPaid + ._IAMT
        WrkTLienPaid = WrkTLienPaid + ._LAMT
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

    WriteTotals(SaveYear, SaveType)
    myFrmProgress.Close()

CloseFiles:
    myTXHSTQ.CloseFile()
    myTXINV.CloseFile()

  End Sub
  Private Sub WriteTotals(ByVal SaveYear As Integer, ByVal SaveType As String)
    If WrkTCount = 0 Then Exit Sub

    dr2 = ds2.Tables(0).NewRow
    dr2.Item("tcount") = WrkTCount
    dr2.Item("year") = SaveYear
    dr2.Item("type") = SaveType
    dr2.Item("tprinpaid") = WrkTPrinPaid
    dr2.Item("tpenpaid") = WrkTPenPaid
    dr2.Item("tintpaid") = WrkTIntPaid
    dr2.Item("tlienpaid") = WrkTLienPaid
    dr2.Item("ttotpaid") = WrkTPrinPaid + WrkTPenPaid + WrkTIntPaid + WrkTLienPaid
    ds2.Tables(0).Rows.Add(dr2)
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
    If MyFrmTXE02B.CboBatch.SelectedItem.ToString = "Suspense" Then
      WrkBatchType = "Suspense"
    End If
    Return WrkBatchType
  End Function
End Module
