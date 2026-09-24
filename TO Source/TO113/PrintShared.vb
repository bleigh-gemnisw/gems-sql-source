Module PrintShared
Friend Sub BuildDS(ByRef dsRE As DataSet, ByRef dsPP As DataSet, ByRef dsMV As DataSet)
  Dim myTable As New DataTable
  With myTable
    .TableName = "mytable"
    .Columns.Add("listno", Type.GetType("System.Int64"))
    .Columns.Add("name", Type.GetType("System.String"))
    .Columns.Add("gross", Type.GetType("System.Int64"))
    .Columns.Add("totbtr", Type.GetType("System.Int64"))
    .Columns.Add("newgross", Type.GetType("System.Int64"))
    .Columns.Add("errmsg", Type.GetType("System.String"))
  End With
  dsRE.Tables.Add(myTable)
  dsPP = dsRE.Clone
  dsMV = dsRE.Clone
End Sub
End Module






