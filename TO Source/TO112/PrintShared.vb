Module PrintShared
Dim myTXMRATE As TXMRATE.myData
'Mill Rate
Public MrateMillrt As Double
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)

myTXMRATE = New TXMRATE.mydata(MyDBConnect)
myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
If myTXMRATE.RecordNotFound Then
  myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
End If
If Not myTXMRATE.RecordNotFound Then
  With myTXMRATE
    MrateMillrt = ._MRRATE
  End With
End If
myTXMRATE.CloseFile()
End Sub
Friend Sub BuildDS(ByRef ds As DataSet)
	Dim myTable As New DataTable
	With myTable
		.TableName = "mytable"
		.Columns.Add("listno", Type.GetType("System.Int64"))
		.Columns.Add("name", Type.GetType("System.String"))
		.Columns.Add("proploc", Type.GetType("System.String"))
		.Columns.Add("units", Type.GetType("System.Int64"))
		.Columns.Add("gross", Type.GetType("System.Int64"))
		.Columns.Add("tax", Type.GetType("System.Decimal"))
	End With
	ds.Tables.Add(myTable)
End Sub
End Module






