Imports System.Text
Module PrintShared
Public Sub BuildDs(ByRef Ds As DataSet, ByRef Ds2 As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("XRef", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("PropCat", Type.GetType("System.String"))
      .Columns.Add("Reading", Type.GetType("System.Int32"))
      .Columns.Add("Reading3", Type.GetType("System.Int32"))
      .Columns.Add("Reading6", Type.GetType("System.Int32"))
      .Columns.Add("Reading9", Type.GetType("System.Int32"))
  End With
  Ds.Tables.Add(myTable)
  Ds2 = Ds.Clone
End Sub
End Module






