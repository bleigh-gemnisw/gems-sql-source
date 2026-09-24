Imports System.Text
Module PrintReport

Dim ds As DataSet = New DataSet
Dim dsDet As DataSet = New DataSet
Dim dr As Data.DataRow
Dim drDet As Data.DataRow
Dim WrkBillDesc As String


Public Sub PrtReport(ByVal ds2 As DataSet, ByVal TaxType As String, ByVal WrkCaveat As Decimal)

  If ds.Tables.Count = 0 Then
    BuildDS()
  Else
    ds.Clear()
    dsDet.Clear()
  End If

  GetDetail(ds2, TaxType)

  MyFrmCrViewer = New FrmCrViewer
  With MyFrmCrViewer
    .wrkds = ds
    .WrkBillDesc = WrkBillDesc
    .WrkCaveat = WrkCaveat
    .Show()
  End With

End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    Dim myTable2 As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
			.Columns.Add("Location", Type.GetType("System.String"))
			.Columns.Add("Units", Type.GetType("System.Decimal"))
			.Columns.Add("OrigAssmnt", Type.GetType("System.Decimal"))
			.Columns.Add("AssmntLeft", Type.GetType("System.Decimal"))
			.Columns.Add("Deferred", Type.GetType("System.Decimal"))
			.Columns.Add("BondPct", Type.GetType("System.Decimal"))
End With
    ds.Tables.Add(myTable)

    With myTable2
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
			.Columns.Add("PaymentNo", Type.GetType("System.Int16"))
			.Columns.Add("BillAmt", Type.GetType("System.Decimal"))
      .Columns.Add("Principal", Type.GetType("System.Decimal"))
      .Columns.Add("Bond", Type.GetType("System.Decimal"))
      .Columns.Add("Balance", Type.GetType("System.Decimal"))
    End With
    dsDet.Tables.Add(myTable2)
  End Sub

Private Sub GetDetail(ByVal ds2 As DataSet, ByVal TaxType As String)
  Dim AddrLine() As String
  Dim I As Integer

  With MyFrmUB102C
    AddrLine = MyUtils.SetAddrLine(.TxtName.Text, .TxtSname.Text, .TxtAdd1.Text, _
      .TxtAdd2.Text, .TxtCity.Text, .TxtState.Text, 0, 0, .TxtZip.Text)
  End With
  WrkBillDesc = GetUTTypeDesc(TaxType)

 'Report
  With MyFrmUB102Amort
    dr = ds.Tables(0).NewRow
    dr.Item("listno") = MyUtils.CnvSng(.LblListNo.Text)
    dr.Item("BillType") = WrkBillDesc
    dr.Item("addr1") = AddrLine(0)
    dr.Item("addr2") = AddrLine(1)
    dr.Item("addr3") = AddrLine(2)
    dr.Item("addr4") = AddrLine(3)
    dr.Item("addr5") = AddrLine(4)
    dr.Item("Origassmnt") = MyUtils.CnvSng(.LblOrigAssmnt.Text) + MyUtils.CnvSng(MyFrmUB102AS.TxtDeferAmt.Text)
    dr.Item("assmntleft") = MyUtils.CnvSng(.LblAssmntLeft.Text)
    dr.Item("deferred") = MyUtils.CnvSng(MyFrmUB102AS.TxtDeferAmt.Text)
    dr.Item("location") = Trim(MyFrmUB102C.TxtLocNo.Text) & " " & MyFrmUB102C.TxtLoc.Text
    dr.Item("units") = MyUtils.CnvSng(MyFrmUB102AS.TxtDwellUnits.Text)
'		myUTRATEAS.GetOneRecordP(WrkUBType, WrkCode)
'		dr.Item("bondpct") = myUTRATEAS._RAPCT * 100
    ds.Tables(0).Rows.Add(dr)
  End With

  For I = 0 To ds2.Tables(0).Rows.Count - 1
    With ds2.Tables(0).Rows(I)
      drDet = dsDet.Tables(0).NewRow
      drDet.Item("listno") = MyUtils.CnvSng(MyFrmUB102Amort.LblListNo.Text)
      drDet.Item("paymentno") = .Item("billno")
      drDet.Item("billamt") = .Item("billamt")
      drDet.Item("principal") = .Item("principal")
      drDet.Item("bond") = .Item("bond")
      drDet.Item("balance") = .Item("balance")
      dsDet.Tables(0).Rows.Add(drDet)
    End With
  Next

  ds.Merge(dsDet)

End Sub
End Module
