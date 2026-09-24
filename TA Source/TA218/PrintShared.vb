Module PrintShared
Friend Sub BuildDS(ByRef ds As DataSet)
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("exempt", Type.GetType("System.Boolean"))
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("addr1", Type.GetType("System.String"))
    .Columns.Add("addr2", Type.GetType("System.String"))
    .Columns.Add("addr3", Type.GetType("System.String"))
    .Columns.Add("addr4", Type.GetType("System.String"))
    .Columns.Add("addr5", Type.GetType("System.String"))
    .Columns.Add("proploc", Type.GetType("System.String"))
    .Columns.Add("units", Type.GetType("System.Int64"))
    .Columns.Add("map", Type.GetType("System.String"))
    .Columns.Add("acres", Type.GetType("System.Decimal"))
    .Columns.Add("volpage", Type.GetType("System.String"))
		.Columns.Add("gross", Type.GetType("System.Int64"))
  End With
  ds.Tables.Add(myTable)
End Sub
End Module






