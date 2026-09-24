Module PrintShared
  Public MyReportCancel As Boolean
  Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Fscyr", Type.GetType("System.Int32"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("rentd", Type.GetType("System.DateTime"))
      .Columns.Add("Vndnr", Type.GetType("System.String"))
      .Columns.Add("SName", Type.GetType("System.String"))
      .Columns.Add("Sadr1", Type.GetType("System.String"))
      .Columns.Add("Sadr2", Type.GetType("System.String"))
      .Columns.Add("Sadr3", Type.GetType("System.String"))
      .Columns.Add("Sadr4", Type.GetType("System.String"))
      .Columns.Add("Sadr5", Type.GetType("System.String"))
      .Columns.Add("RName", Type.GetType("System.String"))
      .Columns.Add("Radr1", Type.GetType("System.String"))
      .Columns.Add("Radr2", Type.GetType("System.String"))
      .Columns.Add("Radr3", Type.GetType("System.String"))
      .Columns.Add("Radr4", Type.GetType("System.String"))
      .Columns.Add("Radr5", Type.GetType("System.String"))
      .Columns.Add("TotVl", Type.GetType("System.Decimal"))
      .Columns.Add("Memo", Type.GetType("System.String"))
      .Columns.Add("AcctSum", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub BuildDS2(ByRef ds2 As DataSet)
    Dim myTable2 As New DataTable
    With myTable2
      .TableName = "mytable2"
      .Columns.Add("Fscyr", Type.GetType("System.Int32"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("Poseq", Type.GetType("System.Int32"))
      .Columns.Add("RqQty", Type.GetType("System.Decimal"))
      .Columns.Add("UnitP", Type.GetType("System.Decimal"))
      .Columns.Add("Itdsc", Type.GetType("System.String"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("ExVal", Type.GetType("System.Decimal"))
    End With
    ds2.Tables.Add(myTable2)
  End Sub
  Public Sub BuildDSDtl(ByRef ds2 As DataSet)
    Dim myTable2 As New DataTable
    With myTable2
      .TableName = "mytable2"
      .Columns.Add("RptGrp", Type.GetType("System.String"))
      .Columns.Add("Fscyr", Type.GetType("System.Int32"))
      .Columns.Add("Ponbr", Type.GetType("System.Int32"))
      .Columns.Add("Poseq", Type.GetType("System.Int32"))
      .Columns.Add("RqQty", Type.GetType("System.Decimal"))
      .Columns.Add("UnitP", Type.GetType("System.Decimal"))
      .Columns.Add("Itdsc", Type.GetType("System.String"))
      .Columns.Add("AcctNo", Type.GetType("System.String"))
      .Columns.Add("ExVal", Type.GetType("System.Decimal"))
      .Columns.Add("Chkdt", Type.GetType("System.String"))
      .Columns.Add("Invdt", Type.GetType("System.String"))
      .Columns.Add("Chkpd", Type.GetType("System.Int32"))
      .Columns.Add("Invno", Type.GetType("System.String"))
      .Columns.Add("Amtnt", Type.GetType("System.Decimal"))
      .Columns.Add("Avoid", Type.GetType("System.String"))
    End With
    ds2.Tables.Add(myTable2)
  End Sub
End Module
