Module PrintShared
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Value70", Type.GetType("System.Int32"))
      .Columns.Add("Lstyrval", Type.GetType("System.Int32"))
      .Columns.Add("lnvalue", Type.GetType("System.Int32"))
      .Columns.Add("tradein", Type.GetType("System.Int32"))
      .Columns.Add("msrp", Type.GetType("System.Int32"))
      .Columns.Add("ecode", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("body", Type.GetType("System.String"))
      .Columns.Add("cyl", Type.GetType("System.Int32"))
      .Columns.Add("lwt", Type.GetType("System.Int32"))
      .Columns.Add("gwt", Type.GetType("System.Int32"))
      .Columns.Add("regno", Type.GetType("System.String"))
      .Columns.Add("Oname", Type.GetType("System.String"))
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






