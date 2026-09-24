Module PrintShared
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Oname", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("body", Type.GetType("System.String"))
      .Columns.Add("nada", Type.GetType("System.String"))
      'MK 7/21/25 Begin
      '.Columns.Add("LoanVal", Type.GetType("System.Int32"))
      '.Columns.Add("TradeVal", Type.GetType("System.Int32"))
      'MK 7/21/25 End
      .Columns.Add("msrp", Type.GetType("System.Int32"))
      .Columns.Add("lastyrval", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
End Module






