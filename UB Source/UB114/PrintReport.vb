Module PrintReport
  Dim ds As DataSet = New DataSet
  Dim dr As DataRow
  Dim myUTDEDDIFF As UTDEDDIFF.MyData
  Dim myUTCUST As UTCUST.MyData
  Public MyCrViewer As FrmCrViewer

  Public Sub PrtReport()
    myUTDEDDIFF = New UTDEDDIFF.MyData(myDBConnect)
    myUTCUST = New UTCUST.MyData(myDBConnect)

    If ds.Tables.Count = 0 Then
      BuildReportDS(ds)
    Else
      ds.Clear()
    End If

    GetReportDetail()

    If ds.Tables(0).Rows.Count = 0 Then
      MessageBox.Show("No meter/deduct records found.", "UB114", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Exit Sub
    End If

    MyCrViewer = New FrmCrViewer
    MyCrViewer.wrkds = ds
    MyCrViewer.Show()
  End Sub

  Private Sub GetReportDetail()
    Dim WrkDS As DataSet

    WrkDS = myUTDEDDIFF.GetLatestAll()
    If WrkDS Is Nothing Then Exit Sub
    If WrkDS.Tables.Count = 0 Then Exit Sub

    For Each WrkRow As DataRow In WrkDS.Tables(0).Rows
      dr = ds.Tables(0).NewRow
      dr.Item("account") = CLng(WrkRow("DDACCT"))
      dr.Item("meter") = Trim(WrkRow("DDMETER").ToString())

      myUTCUST.GetOneRecordP(CInt(WrkRow("DDACCT")))
      If myUTCUST.RecordNotFound Then
        dr.Item("name") = ""
      Else
        dr.Item("name") = Trim(myUTCUST._CUNAM1)
      End If

      dr.Item("readdate") = MyUtils.GetDBDate(CInt(WrkRow("DDDATE")))
      dr.Item("reading") = CLng(WrkRow("DDREAD"))
      dr.Item("difference") = CLng(WrkRow("DDDIFF"))
      dr.Item("reason") = Trim(WrkRow("DDRESN").ToString())
      ds.Tables(0).Rows.Add(dr)
    Next
  End Sub

  Friend Sub BuildReportDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("account", Type.GetType("System.Int64"))
      .Columns.Add("meter", Type.GetType("System.String"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("readdate", Type.GetType("System.DateTime"))
      .Columns.Add("reading", Type.GetType("System.Int64"))
      .Columns.Add("difference", Type.GetType("System.Int64"))
      .Columns.Add("reason", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
End Module
