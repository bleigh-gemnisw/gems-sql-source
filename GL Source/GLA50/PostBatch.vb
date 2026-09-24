Module PostBatch

  Dim myLEDGER As LEDGER.MyData

  'General
  Dim WrkDelete As Boolean
  Dim WrkBatch As Integer
  Dim WrkBatchDate As Integer
  Dim WrkNewDate As Integer
  Dim WrkAnd As String
  Dim WrkOr As String
  Public Sub PstBatch()

    myLEDGER = New LEDGER.MyData()
    myLEDGER.MyDBConn = myDBConnect

    With MyFrmGLA50B
      WrkDelete = .RbDelete.Checked
      WrkBatch = MyUtils.CnvSng(.TxtBatch.Text)
      WrkBatchDate = MyUtils.SetDBDate(.DtPckBatch.Value)
      WrkNewDate = MyUtils.SetDBDate(.DTPckNew.Value)
    End With

    GetDetail()
  End Sub
  Private Sub GetDetail()
    Dim WrkWhere As String
    Dim WrkSet As String
    WrkAnd = " and "
    WrkOr = " or "

    If WrkDelete Then
      WrkWhere = "BCHNO=" & WrkBatch & WrkAnd & "PSTDT=" & WrkBatchDate
      myLEDGER.DeleteRecords(WrkWhere)
    Else
      WrkWhere = "Where BCHNO=" & WrkBatch & WrkAnd & "PSTDT=" & WrkBatchDate
      WrkSet = "Set PSTDT=" & WrkNewDate
      myLEDGER.RunUpdateQuery(WrkSet, WrkWhere)
    End If
  End Sub
End Module
