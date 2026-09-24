Module PrintShared
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("sname", Type.GetType("System.String"))
      .Columns.Add("addr", Type.GetType("System.String"))
      .Columns.Add("city", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("value", Type.GetType("System.Int32"))
      .Columns.Add("ovalue", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
End Module






