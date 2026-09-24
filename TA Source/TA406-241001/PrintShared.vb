Module PrintShared
'Buffered Fields
Public WrkOClass(25000) As Integer
Public WrkOYear(25000) As Integer
Public WrkOMake(25000) As String
Public WrkOModel(25000) As String
Public WrkOValue(25000) As Integer
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Oname", Type.GetType("System.String"))
      .Columns.Add("class", Type.GetType("System.Int32"))
      .Columns.Add("make", Type.GetType("System.String"))
      .Columns.Add("year", Type.GetType("System.Int32"))
      .Columns.Add("idno", Type.GetType("System.String"))
      .Columns.Add("model", Type.GetType("System.String"))
      .Columns.Add("body", Type.GetType("System.String"))
      .Columns.Add("nada", Type.GetType("System.String"))
      .Columns.Add("msrp", Type.GetType("System.Int32"))
      .Columns.Add("lstyrval", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
End Module






