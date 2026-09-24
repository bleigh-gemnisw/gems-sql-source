Module PrintShared
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Locno", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Int32"))
      .Columns.Add("BTR", Type.GetType("System.Int32"))
      .Columns.Add("Adjusted", Type.GetType("System.Int32"))
      .Columns.Add("Fccod", Type.GetType("System.String"))
      .Columns.Add("Dnbtr", Type.GetType("System.String"))
      .Columns.Add("Cat", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)

  End Sub
End Module






