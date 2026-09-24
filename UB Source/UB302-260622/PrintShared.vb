Imports System.Text
Module PrintShared
Public Sub BuildDs(ByRef Ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("UBName", Type.GetType("System.String"))
      .Columns.Add("Location", Type.GetType("System.String"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("TaxTotal", Type.GetType("System.Decimal"))
      .Columns.Add("ErrMsg", Type.GetType("System.String"))
  End With
  Ds.Tables.Add(myTable)
End Sub
End Module






