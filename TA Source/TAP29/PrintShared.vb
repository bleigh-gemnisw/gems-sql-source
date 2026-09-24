'Buffered files
Module PrintShared
	Public Sub BuildDS(ByRef ds As DataSet)
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("Listno", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Benefit", Type.GetType("System.Decimal"))
		End With
		ds.Tables.Add(myTable)
	End Sub
End Module






