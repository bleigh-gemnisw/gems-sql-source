Module PrintShared
  Dim myCASHINT As CASHINT.MyData
  Dim myTXHSTL4 As TXHSTL4.myData
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable

    With myTable
      .TableName = "mytable"
      .Columns.Add("FromListNo", Type.GetType("System.Int32"))
      .Columns.Add("FromType", Type.GetType("System.String"))
      .Columns.Add("FromYear", Type.GetType("System.String"))
      .Columns.Add("FromName", Type.GetType("System.String"))
      .Columns.Add("FromBeforeBal", Type.GetType("System.Decimal"))
      .Columns.Add("FromAfterBal", Type.GetType("System.Decimal"))
      .Columns.Add("FromTransferTax", Type.GetType("System.Decimal"))
      .Columns.Add("ToListNo", Type.GetType("System.Int32"))
      .Columns.Add("ToType", Type.GetType("System.String"))
      .Columns.Add("ToYear", Type.GetType("System.String"))
      .Columns.Add("ToName", Type.GetType("System.String"))
      .Columns.Add("ToBeforeBal", Type.GetType("System.Decimal"))
      .Columns.Add("ToAfterBal", Type.GetType("System.Decimal"))
      .Columns.Add("ToTransferTax", Type.GetType("System.Decimal"))
      .Columns.Add("ToTransferInt", Type.GetType("System.Decimal"))
      .Columns.Add("ToTransferFee", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)

  End Sub
Public Sub InitCASHINT()
  myCASHINT = New CASHINT.mydata(MyDBConnect)
End Sub
Public Sub InitTXHSTL4()
  myTXHSTL4 = New TXHSTL4.mydata(MyDBConnect)
End Sub
Public Sub CalcInterest(ByVal InIntDate As Date, ByVal InListNo As Integer, ByVal InType As String, _
		ByVal InYear As Integer, ByRef OutInterest As Decimal, ByRef OutInterestPaid As Decimal, _
		ByRef OutFee As Decimal, ByRef OutLien As Decimal, ByRef OutBond As Decimal, ByRef OutTax As Decimal, _
		ByRef OutDue As Decimal)
		With myCASHINT
			.In_IntDate = InIntDate
			.In_ListNo = InListNo
			.In_Type = InType
			.In_Year = InYear
			.CalcInterest()
			OutInterest = Format(.Out_Int(), "standard")
			OutInterestPaid = Format(.Out_IntPaid(), "standard")
			OutLien = Format(.Out_Lien(), "standard")
			OutFee = Format(.Out_Fee(), "standard")
			OutBond = Format(.Out_Bond(), "standard")
			OutTax = Format(.Out_Prin(), "standard")
			OutDue = Format(.Out_Tot(), "standard")
		End With
End Sub
Public Function GetLastHist(ByVal ListNo As Integer, ByVal Year As Integer, ByVal Type As String, ByVal PDate As Integer) As Integer

	Dim ds As DataSet = New DataSet
	Dim WrkDate As Integer
	Dim I As Integer

	ds = myTXHSTL4.GetViewDscList(ListNo, Year, Type, PDate, 10)
	If ds.Tables(0).Rows.Count = 0 Then Return 0

	For I = 0 To ds.Tables(0).Rows.Count - 1
		If ds.Tables(0).Rows(I).Item("rcode") <> "V" And ds.Tables(0).Rows(I).Item("rcode") <> "I" Then
			WrkDate = ds.Tables(0).Rows(I).Item("pdate")
			Exit For
		End If
	Next
	Return WrkDate
End Function
End Module






