Module PrintShared
  Public ds As DataSet
  Public dr As Data.DataRow
  Friend Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Friend Sub BuildDSLbl()
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






