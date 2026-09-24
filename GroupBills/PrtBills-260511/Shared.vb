Module PrintShared
Public Sub BuildDSBill(ByRef dsBill As DataSet, WrkPrint As Boolean, WrkSewer As Boolean)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("BillDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Acct", Type.GetType("System.String"))
      If WrkPrint Then
        .Columns.Add("Addr1", Type.GetType("System.String"))
        .Columns.Add("Addr2", Type.GetType("System.String"))
        .Columns.Add("Addr3", Type.GetType("System.String"))
        .Columns.Add("Addr4", Type.GetType("System.String"))
        .Columns.Add("Addr5", Type.GetType("System.String"))
      Else
        .Columns.Add("Name", Type.GetType("System.String"))
        .Columns.Add("Sname", Type.GetType("System.String"))
        .Columns.Add("Addr", Type.GetType("System.String"))
        .Columns.Add("Addr2", Type.GetType("System.String"))
        .Columns.Add("City", Type.GetType("System.String"))
        .Columns.Add("State", Type.GetType("System.String"))
        .Columns.Add("Zipa", Type.GetType("System.String"))
      End If
      .Columns.Add("Bank", Type.GetType("System.String"))
      .Columns.Add("Gross", Type.GetType("System.Decimal"))
      .Columns.Add("Exemption", Type.GetType("System.Decimal"))
      .Columns.Add("Prorate", Type.GetType("System.Decimal"))
      .Columns.Add("Credit", Type.GetType("System.Decimal"))
      .Columns.Add("Net", Type.GetType("System.Decimal"))
      .Columns.Add("Taxtot", Type.GetType("System.Decimal"))
      .Columns.Add("Tax1st", Type.GetType("System.Decimal"))
      .Columns.Add("Tax2nd", Type.GetType("System.Decimal"))
      .Columns.Add("STBenefit", Type.GetType("System.Decimal"))
      .Columns.Add("TownBenefit", Type.GetType("System.Decimal"))
      .Columns.Add("PropDesc", Type.GetType("System.String"))
      .Columns.Add("PropDesc2", Type.GetType("System.String"))
      .Columns.Add("BackTax", Type.GetType("System.Boolean"))
      .Columns.Add("BarCode", Type.GetType("System.String"))
      .Columns.Add("GroupID", Type.GetType("System.String"))
      .Columns.Add("Group12", Type.GetType("System.String"))
      .Columns.Add("GroupNo", Type.GetType("System.Int32"))
      .Columns.Add("PostNet", Type.GetType("System.String"))
      .Columns.Add("PostID", Type.GetType("System.Int32"))
      .Columns.Add("ScanLine", Type.GetType("System.String"))
      .Columns.Add("AddlDesc", Type.GetType("System.String"))
      .Columns.Add("AddlDesc2", Type.GetType("System.String"))
      .Columns.Add("AddlDesc3", Type.GetType("System.String"))
      .Columns.Add("AddlDesc4", Type.GetType("System.String"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDesc", Type.GetType("System.String"))
      .Columns.Add("CCDate", Type.GetType("System.String"))
      .Columns.Add("MillRt", Type.GetType("System.Decimal"))
      .Columns.Add("TaxBase", Type.GetType("System.String"))
      .Columns.Add("MillRtBefore", Type.GetType("System.String"))
      .Columns.Add("MapLot", Type.GetType("System.String"))
      .Columns.Add("Lease", Type.GetType("System.String"))
      If WrkSewer Then
        .Columns.Add("Sewertot", Type.GetType("System.Decimal"))
        .Columns.Add("Sewer1st", Type.GetType("System.Decimal"))
        .Columns.Add("Sewer2nd", Type.GetType("System.Decimal"))
        .Columns.Add("Combtot", Type.GetType("System.Decimal"))
        .Columns.Add("Comb1st", Type.GetType("System.Decimal"))
        .Columns.Add("Comb2nd", Type.GetType("System.Decimal"))
      End If
      .Columns.Add("TaxWouldBe", Type.GetType("System.Decimal"))
  End With
  dsBill.Tables.Add(myTable)
End Sub
Public Sub BuildDSTot(ByRef dsTot As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytabletot"
      .Columns.Add("Count", Type.GetType("System.Int32"))
      .Columns.Add("Group", Type.GetType("System.Int32"))
      .Columns.Add("Total", Type.GetType("System.Int32"))
      .Columns.Add("StrPage", Type.GetType("System.Int32"))
    End With
    dsTot.Tables.Add(myTable)
End Sub
End Module
