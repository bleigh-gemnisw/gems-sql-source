Module PrintShared
Friend Sub BuildDS(ByRef ds As DataSet)
  Dim myTable As New DataTable
  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("gross", Type.GetType("System.Int64"))
  End With
  ds.Tables.Add(myTable)
End Sub
End Module






