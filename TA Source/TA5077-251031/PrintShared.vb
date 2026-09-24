Module PrintShared
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("name", Type.GetType("System.String"))
      .Columns.Add("sname", Type.GetType("System.String"))
      .Columns.Add("addr", Type.GetType("System.String"))
      .Columns.Add("city", Type.GetType("System.String"))
      .Columns.Add("State", Type.GetType("System.String"))
      .Columns.Add("value70", Type.GetType("System.Int32"))

    End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("TCount", Type.GetType("System.Int32"))
      .Columns.Add("TVal70", Type.GetType("System.Int32"))
      .Columns.Add("TLYVal", Type.GetType("System.Int32"))
      .Columns.Add("TLNVal", Type.GetType("System.Int32"))
      .Columns.Add("TTIVal", Type.GetType("System.Int32"))
      .Columns.Add("TMSRPVal", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable2)

  End Sub
End Module






