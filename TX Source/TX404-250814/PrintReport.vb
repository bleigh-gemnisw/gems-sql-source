Module PrintReport

  Public Sub PrtReport()
	Dim Wrkds As DataSet = New DataSet
	Dim dr As DataRow
	Dim AddrLine() As String
	Dim I As Integer

    MyFrmTX404.TBarPrint.Enabled = False
	MyFrmTX404.TBarSettings.Enabled = False

	BuildDS(Wrkds)
	For I = 0 To myds.Tables(0).Rows.Count - 1
		With myds.Tables(0).Rows(I)
			dr = Wrkds.Tables(0).NewRow
			dr.Item("sortdata") = String.Empty
			dr.Item("listno") = .Item("listno")
			dr.Item("year") = .Item("year")
			dr.Item("type") = .Item("type")
			dr.Item("typedesc") = .Item("typedesc")
			With MyFrmTX4042
        AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text, .TxtAdd2.Text, _
          .TxtCity.Text, .TxtState.Text, MyUtils.CnvSng(.TxtZip5.Text), MyUtils.CnvSng(.TxtZip4.Text))
			End With
			dr.Item("addr1") = AddrLine(0)
			dr.Item("addr2") = AddrLine(1)
			dr.Item("addr3") = AddrLine(2)
			dr.Item("addr4") = AddrLine(3)
			dr.Item("addr5") = AddrLine(4)
			dr.Item("propdesc") = .Item("propdesc")
			dr.Item("propdesc2") = .Item("propdesc2")
			dr.Item("balance") = .Item("balance")
			dr.Item("amtdue") = .Item("amtdue")
			dr.Item("interest") = .Item("interest")
			dr.Item("fees") = .Item("fees")
			dr.Item("liens") = .Item("liens")
			dr.Item("bond") = .Item("bond")
			dr.Item("total") = .Item("balance")
			dr.Item("volpage") = .Item("volpage")
			dr.Item("AcctId") = Mid(.Item("year"), 3, 2) & .Item("type") & .Item("listno")
			Wrkds.Tables(0).Rows.Add(dr)
		End With
	Next

	MyCrViewer = New FrmCrViewer
	MyCrViewer.Wrkds = Wrkds
	If MyPreview Then
		MyCrViewer.Show()
	Else
		MyCrViewer.RunReport()
	End If
	MyCrViewer = Nothing

	MyFrmTX404.TBarPrint.Enabled = True
	MyFrmTX404.TBarSettings.Enabled = True

End Sub
	Private Sub BuildDS(ByRef ds As DataSet)
		Dim myTable As New DataTable
		With myTable
			.TableName = "mytable"
			.Columns.Add("SortData", Type.GetType("System.String"))
			.Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("Year", Type.GetType("System.Int32"))
			.Columns.Add("Type", Type.GetType("System.String"))
			.Columns.Add("TypeDesc", Type.GetType("System.String"))
			.Columns.Add("Addr1", Type.GetType("System.String"))
			.Columns.Add("Addr2", Type.GetType("System.String"))
			.Columns.Add("Addr3", Type.GetType("System.String"))
			.Columns.Add("Addr4", Type.GetType("System.String"))
			.Columns.Add("Addr5", Type.GetType("System.String"))
			.Columns.Add("PropDesc", Type.GetType("System.String"))
			.Columns.Add("PropDesc2", Type.GetType("System.String"))
			.Columns.Add("Balance", Type.GetType("System.Decimal"))
			.Columns.Add("Total", Type.GetType("System.Decimal"))
			.Columns.Add("AmtDue", Type.GetType("System.Decimal"))
			.Columns.Add("Interest", Type.GetType("System.Decimal"))
			.Columns.Add("Fees", Type.GetType("System.Decimal"))
			.Columns.Add("Liens", Type.GetType("System.Decimal"))
			.Columns.Add("Bond", Type.GetType("System.Decimal"))
			.Columns.Add("VolPage", Type.GetType("System.String"))
			.Columns.Add("AcctID", Type.GetType("System.String"))
		End With
		ds.Tables.Add(myTable)
	End Sub

End Module






