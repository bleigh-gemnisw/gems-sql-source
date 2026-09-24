Imports System.Text
Module ImportData

  Dim myFrmProgress As FrmProgress
  Dim WrkPct As Integer
  Dim SavePct As Integer
  Dim myTXHSTQ As TXHSTQ.MyData
  Dim myNETGLBCH As NETGLBCH.MyData

  Dim dr As DataRow
  Dim ds As DataSet = New DataSet
  Dim DsTXHST As DataSet = New DataSet
  Public Sub Impdata()
    Dim Good As Boolean

    MyDBName = MyFrmFixB.TxtDBName.Text
    Good = Connect()

    If Not Good Then Exit Sub

    myTXHSTQ = New TXHSTQ.MyData(myDBConnect)
    myNETGLBCH = New NETGLBCH.MyData()
    myNETGLBCH.MyDBConn = myDBConnect

    If ds.Tables.Count = 0 Then
      BuildDS()
    Else
      ds.Clear()
    End If
    GetDetail()

    MyCrViewer = New FrmCrViewer
    MyCrViewer.Wrkds = ds
    MyCrViewer.Show()

  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Batch", Type.GetType("System.Int32"))
      .Columns.Add("SeqNo", Type.GetType("System.Int32"))
      .Columns.Add("List", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Paid", Type.GetType("System.Decimal"))
      .Columns.Add("Bald", Type.GetType("System.Decimal"))
      .Columns.Add("Msg", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetDetail()
    Dim WrkBatch As Integer
    Dim WrkDBDate As Integer
    Dim WrkUpdate As Boolean
    Dim WrkListNo As Integer
    Dim WrkType As String
    Dim WrkYear As Integer
    Dim WrkAmount As Decimal
    Dim WrkInterest As Decimal
    Dim WrkAnd As String
    Dim WrkQry As String
    Dim WrkSort As String
    Dim Counter As Integer

    WrkAnd = " and "

    With MyFrmFixB
      WrkBatch = CnvSng(.TxtBatch.Text)
      WrkDBDate = SetDBDate(.DtPckPost.Value)
      WrkUpdate = .ChkUpdate.Checked
    End With

    WrkQry = "BATCHN=" & WrkBatch & WrkAnd & "PDATE=" & WrkDBDate
    WrkSort = "BATCHS"
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
        If ._RCODE = "V" Then GoTo NextRec
        If ._RCODE = "I" Then GoTo NextRec
        WrkListNo = ._LISTNo
        WrkType = ._TYPE
        WrkYear = ._YEAR
        WrkAmount = ._PAMT
        WrkInterest = ._IAMT
        'Report
        myNETGLBCH.GetOneRecordP(._BATCHN, ._BATCHS)
        dr = ds.Tables(0).NewRow
        dr.Item("batch") = ._BATCHN
        dr.Item("seqno") = ._BATCHS
        dr.Item("list") = ._LISTNo
        dr.Item("type") = ._TYPE
        dr.Item("year") = ._YEAR
        dr.Item("paid") = ._PAMT
        If myNETGLBCH.RecordNotFound Then
          dr.Item("msg") = ""
        Else
          dr.Item("msg") = "*SKIP*"
        End If
        ds.Tables(0).Rows.Add(dr)
        If WrkUpdate And myNETGLBCH.RecordNotFound Then
          WriteNETGLBCH()
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

  End Sub
  Private Sub WriteNETGLBCH()

    With myNETGLBCH
      ._ADJCD = myTXHSTQ._ADJCD
      ._BATCH = myTXHSTQ._BATCHN
      ._DIST = myTXHSTQ._DIST
      ._IAMT = myTXHSTQ._IAMT
      ._LAMT = myTXHSTQ._LAMT
      ._LIST = myTXHSTQ._LISTNo
      ._PAMT = myTXHSTQ._PAMT
      ._PAYDT = myTXHSTQ._CDATE
      ._PCAMT = myTXHSTQ._PCAMT
      ._PENCD = myTXHSTQ._PENCD
      ._PSTDT = myTXHSTQ._PDATE
      ._SEQNO = myTXHSTQ._BATCHS
      ._STAT = ""
      ._TYPE = myTXHSTQ._TYPE
      ._YEAR = myTXHSTQ._YEAR
      .AddOneRecordP()
    End With

  End Sub
End Module
