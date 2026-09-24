Imports System.Text
Module PrintShared
Public Sub BuildDs(ByRef Ds As DataSet, ByRef Ds2 As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
			.Columns.Add("SortData", Type.GetType("System.String"))
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Route", Type.GetType("System.String"))
      .Columns.Add("Section", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("Prev", Type.GetType("System.Int32"))
      .Columns.Add("Curr", Type.GetType("System.Int32"))
      .Columns.Add("Use", Type.GetType("System.Int32"))
      .Columns.Add("Mult", Type.GetType("System.Int32"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
  End With
  Ds.Tables.Add(myTable)
  Ds2 = Ds.Clone
End Sub
End Module






