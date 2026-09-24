Imports System.Text
Module ImportData

Dim myFrmProgress As FrmProgress
Dim WrkPct As Integer
Dim SavePct As Integer
Dim myTXHSTQ As TXHSTQ.myData
Dim myTXHST As TXHSTL1.myData
Dim myTXINV As TXINV.myData

Dim dr As DataRow
Dim ds As DataSet = New DataSet
Dim DsTXHST As DataSet = New DataSet
Public Sub Impdata()
Dim Good As Boolean

MyDBName = MyFrmFixB.TxtDBName.Text
Good = Connect()

If Not Good Then Exit Sub

myTXHSTQ = New TXHSTQ.myData(myDBConnect.pgmDB)
myTXHST = New TXHSTL1.myData(myDBConnect.pgmDB)
myTXINV = New TXINV.myData(myDBConnect.pgmDB)

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
      .Columns.Add("NPaid", Type.GetType("System.Decimal"))
      .Columns.Add("NBald", Type.GetType("System.Decimal"))
      .Columns.Add("Recid", Type.GetType("System.Int64"))
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
Dim SaveSeq As Integer
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
WrkSort = "BATCHS *ASCEND"
SaveSeq = 0
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
    If SaveSeq = ._BATCHS Then
      WrkListNo = ._LISTNo
      WrkType = ._TYPE
      WrkYear = ._YEAR
      WrkAmount = ._PAMT
      WrkInterest = ._IAMT
      'Report
      myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
      dr = ds.Tables(0).NewRow
      dr.Item("batch") = ._BATCHN
      dr.Item("seqno") = ._BATCHS
      dr.Item("list") = ._LISTNo
      dr.Item("type") = ._TYPE
      dr.Item("year") = ._YEAR
      dr.Item("name") = myTXINV._NAME
      dr.Item("paid") = myTXINV._PAYREC
      dr.Item("bald") = myTXINV._BALD
      dr.Item("npaid") = myTXINV._PAYREC + WrkAmount
      dr.Item("nbald") = myTXINV._BALD + WrkAmount
      dr.Item("recid") = ._RECID
      ds.Tables(0).Rows.Add(dr)
      If WrkUpdate Then
        UpdateTXINV(WrkListNo, WrkType, WrkYear, WrkAmount, WrkInterest)
        DeleteTXHST(._RECID)
      End If
    End If
    SaveSeq = ._BATCHS
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
Private Sub UpdateTXINV(ByVal ListNo As Integer, ByVal Type As String, ByVal Year As Integer, ByVal Amount As Decimal, _
	ByVal Interest As Decimal)

With myTXINV
  ._PAYREC = ._PAYREC - Amount
	._BALD = ._BALD + Amount
	._INTPD = ._INTPD - Interest
	.UpdateOneRecordP()
End With

End Sub
Private Sub DeleteTXHST(ByVal RecID As Long)

    With myTXHST
      .GetOneRecordP(RecID)
      .DeleteOneRecordP()
    End With
End Sub

End Module
