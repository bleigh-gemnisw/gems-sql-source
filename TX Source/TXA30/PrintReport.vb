Imports System.Text
Module PrintReport

  Dim myFrmProgress As FrmProgress
  Public MyReportCancel As Boolean
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myTXINV As TXINV.MyData
  Dim myTXHSTL4 As TXHSTL4.MyData

  Dim ds As DataSet = New DataSet
  Dim dr As Data.DataRow
  'General
  Dim WrkPost As Boolean
  Dim WrkBatch As Integer
  Dim WrkBatchType As String
  Dim WrkBatchTypeDesc As String
  Dim WrkBatchDate As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  'Buffer Type
  Dim WrkCode(50) As String
  Dim WrkDesc(50) As String
  Dim WrkFamily(50) As String
  Public Sub PrtReport()

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myTXINV = New TXINV.MyData(myDBConnect)
    myTXHSTL4 = New TXHSTL4.MyData(myDBConnect)

    With MyFrmTXA30B
      WrkBatch = MyUtils.CnvSng(.TxtBatch.Text)
      WrkPost = .ChkPost.Checked
      WrkBatchDate = MyUtils.SetDBDate(.DtPckBatch.Value)
      Select Case .CboBatch.SelectedItem.ToString
        Case "Bank Service"
          WrkBatchType = "K"
        Case "Escrow"
          WrkBatchType = "E"
        Case "Leasing"
          WrkBatchType = "G"
        Case "Lock Box"
          WrkBatchType = "B"
        Case "Misc/Penny Batch"
          WrkBatchType = "M"
        Case "PC"
          WrkBatchType = "P"
        Case "Web Payment"
          WrkBatchType = "W"
      End Select
    End With

    If ds.Tables.Count = 0 Then
      BuildDS()
      BufferType()
    Else
      ds.Clear()
    End If

    GetDetail()
    WrkBatchTypeDesc = GetBatchTypeDesc(WrkBatchType)

Done:
    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.WrkBatchTypeDesc = WrkBatchTypeDesc
    MyCrViewer.WrkPost = WrkPost
    MyCrViewer.ShowDialog()

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
      .Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Fees", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
      .Columns.Add("Activity", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim ds2 As DataSet = New DataSet
    Dim WrkQry As String
    Dim WrkSort As String
    Dim WrkTXType As String()
    Dim Counter As Integer

    If MyServer = "DB2" Then
      WrkAnd = " *and "
      WrkOr = " *or "
    Else
      WrkAnd = " and "
      WrkOr = " or "
    End If
    If MyServer = "SQL" Then
      MyBlocking = False
    Else
      MyBlocking = True
    End If

    MyBatchTotal = 0
    WrkQry = "BATCHN=" & WrkBatch & WrkAnd & "BATCHA=" & MyUtils.Quo(WrkBatchType) & WrkAnd & "PDATE=" & WrkBatchDate &
  WrkAnd & "RCODE<>'V'" & WrkAnd & "RCODE<>'I'"
    WrkSort = ""
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
        dr = ds.Tables(0).NewRow
        dr("listno") = ._LISTNo
        dr("type") = ._TYPE
        WrkTXType = LookupType(._TYPE)
        dr("typedesc") = WrkTXType(0)
        dr("year") = ._YEAR
        dr("principal") = ._PAMT
        dr("interest") = ._IAMT
        dr("liens") = ._LAMT
        dr("fees") = ._PCAMT
        dr("total") = ._PAMT + ._IAMT + ._LAMT + ._PCAMT
        myTXINV.GetOneRecordP(._LISTNo, ._YEAR, ._TYPE)
        If Not myTXINV.RecordNotFound Then
          With myTXINV
            dr("name") = ._NAME
          End With
        End If
        ds2 = myTXHSTL4.GetViewDscList(._LISTNo, ._YEAR, ._TYPE, 99999999, 1)
        If ds2.Tables(0).Rows.Count > 1 Then
          dr("activity") = "YES"
        End If
        MyBatchTotal = MyBatchTotal + dr("total")
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

    MyFrmTXA30B.TxtBatchTotal.Text = MyBatchTotal
    myFrmProgress.Close()
    myTXHSTQ.CloseFile()

  End Sub
  Private Sub BufferType()
    Dim I As Integer

    Dim myTXTYPE As TXTYPE.MyData
    Dim dsTXType As DataSet = New DataSet

    myTXTYPE = New TXTYPE.MyData(myDBConnect)

    dsTXType = myTXTYPE.GetAllData
    For I = 0 To dsTXType.Tables(0).Rows.Count - 1
      With dsTXType.Tables(0).Rows(I)
        WrkCode(I) = .Item("tycode")
        WrkDesc(I) = .Item("tydesc")
        WrkFamily(I) = .Item("txfam")
      End With
    Next

  End Sub
  Private Function LookupType(ByVal Type As String) As String()
    Dim I As Integer
    Dim WrkResult(1) As String

    WrkResult(0) = ""
    WrkResult(1) = ""

    For I = 0 To WrkCode.GetUpperBound(0)
      If WrkCode(I) = "" Then
        Return WrkResult
      End If
      If Type = WrkCode(I) Then
        WrkResult(0) = WrkDesc(I)
        WrkResult(1) = WrkFamily(I)
        Return WrkResult
      End If
    Next

    Return WrkResult
  End Function

End Module






