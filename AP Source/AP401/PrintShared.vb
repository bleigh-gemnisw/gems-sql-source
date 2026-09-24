Module PrintShared
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("Vennm", Type.GetType("System.String"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("Invdt", Type.GetType("System.DateTime"))
      .Columns.Add("Duedt", Type.GetType("System.DateTime"))
      .Columns.Add("Amtop", Type.GetType("System.Decimal"))
  End With
    ds.Tables.Add(myTable)
  End Sub
End Module
