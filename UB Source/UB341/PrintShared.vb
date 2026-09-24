Imports System.Text
Module PrintShared
Public Sub BuildDs(ByRef Ds As DataSet)
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("Name", Type.GetType("System.String"))
			.Columns.Add("Location", Type.GetType("System.String"))
			.Columns.Add("Dist", Type.GetType("System.Int32"))
			.Columns.Add("RateCd", Type.GetType("System.String"))
			.Columns.Add("Units", Type.GetType("System.Decimal"))
			.Columns.Add("CurrYr", Type.GetType("System.Int32"))
			.Columns.Add("PrevYr", Type.GetType("System.Int32"))
			.Columns.Add("PrevYr2", Type.GetType("System.Int32"))
			.Columns.Add("MeterID", Type.GetType("System.String"))
	End With
	Ds.Tables.Add(myTable)
End Sub
End Module






