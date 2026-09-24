'Buffered files
Module PrintShared
	Public MyReportCancel As Boolean
	Public Sub BuildDS(ByRef ds As DataSet)
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("Listno", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("PropDesc", Type.GetType("System.String"))
			.Columns.Add("Gross", Type.GetType("System.Int32"))
			.Columns.Add("OGross", Type.GetType("System.Int32"))
			.Columns.Add("Diff", Type.GetType("System.Int32"))
		End With
		ds.Tables.Add(myTable)

	End Sub
End Module






