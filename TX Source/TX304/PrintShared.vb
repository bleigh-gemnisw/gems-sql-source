Imports System.Text
Module PrintShared
Public Sub BuildDSTot(ByRef dsTot As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Description", Type.GetType("System.String"))
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("Tax", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
			.Columns.Add("Fee", Type.GetType("System.Decimal"))
			.Columns.Add("Lien", Type.GetType("System.Decimal"))
      .Columns.Add("Total", Type.GetType("System.Decimal"))
    End With
    dsTot.Tables.Add(myTable)
End Sub
Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("SortData", Type.GetType("System.String"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("SName", Type.GetType("System.String"))
			.Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("VolPage", Type.GetType("System.String"))
			.Columns.Add("Balance", Type.GetType("System.Decimal"))
			.Columns.Add("AmtDue", Type.GetType("System.Decimal"))
      .Columns.Add("Interest", Type.GetType("System.Decimal"))
			.Columns.Add("Fees", Type.GetType("System.Decimal"))
			.Columns.Add("Liens", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
			.Columns.Add("Total", Type.GetType("System.Decimal"))
			.Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("DueDate1", Type.GetType("System.String"))
      .Columns.Add("DueDate2", Type.GetType("System.String"))
			.Columns.Add("BarCode", Type.GetType("System.String"))
	End With
  ds.Tables.Add(myTable)
End Sub
Public Function BuildBarCode(ByVal WrkList As Integer, ByVal WrkType As String, _
	ByVal WrkGLYear As Integer) As String
	Dim WrkBarCode As String

	WrkBarCode = "*" & Format(WrkList, "000000") & WrkType & WrkGLYear & "*"
	Return WrkBarCode
End Function
End Module






