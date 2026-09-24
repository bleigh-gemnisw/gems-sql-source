Module PrintShared
Friend Sub BuildDS(ByRef ds As DataSet)
  Dim myTable As New DataTable
  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("addr1", Type.GetType("System.String"))
    .Columns.Add("addr2", Type.GetType("System.String"))
    .Columns.Add("addr3", Type.GetType("System.String"))
    .Columns.Add("addr4", Type.GetType("System.String"))
    .Columns.Add("addr5", Type.GetType("System.String"))
    .Columns.Add("dob", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
End Sub
End Module






