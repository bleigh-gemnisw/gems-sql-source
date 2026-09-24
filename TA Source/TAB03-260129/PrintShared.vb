Module PrintShared
Public ds As DataSet = New DataSet
Public dr As Data.DataRow
Friend Sub BuildDS()
  Dim myTable As New DataTable

  With myTable
    .TableName = "mytable"
    .Columns.Add("line0", Type.GetType("System.String"))
    .Columns.Add("line1", Type.GetType("System.String"))
    .Columns.Add("line2", Type.GetType("System.String"))
    .Columns.Add("line3", Type.GetType("System.String"))
    .Columns.Add("line4", Type.GetType("System.String"))
    .Columns.Add("line5", Type.GetType("System.String"))
  End With
  ds.Tables.Add(myTable)
End Sub
End Module






