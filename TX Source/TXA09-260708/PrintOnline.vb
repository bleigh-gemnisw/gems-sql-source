Module PrintOnline
  Dim myreport1 As New CrystalDecisions.CrystalReports.Engine.ReportDocument
	Dim MyTXINV As TXINV.myData
	Dim myds As DataSet = New DataSet
  Dim myDr As DataRow

Public Sub PrtOnline(ByVal ds As DataSet)
  Windows.Forms.Cursor.Current = Cursors.WaitCursor()
  If myds.Tables.Count = 0 Then
    BuildDs()
  Else
    myds.Clear()
  End If

  CreateDs(ds)
  Windows.Forms.Cursor.Current = Cursors.Default
  If MyFrmTXA094B.RbDupBill.Checked Then
    OnlineDupBill()
  Else
    MyFrmCr_Online = New FrmCr_Online
    MyFrmCr_Online.Wrkds = myds
    If MyFrmTXA094B.RbStatement.Checked Then
      MyFrmCr_Online.WrkRptNo = 1
    End If
    If MyFrmTXA094B.RbDemand.Checked Then
      MyFrmCr_Online.WrkRptNo = 2
    End If
    If MyFrmTXA094B.RbWarrants.Checked Then
      MyFrmCr_Online.WrkRptNo = 3
    End If
    MyFrmCr_Online.Show()
  End If
  End Sub

Private Sub BuildDs()

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
  myds.Tables.Add(myTable)
End Sub
Private Sub CreateDs(ByVal ds As DataSet)
  Dim WrkFamily As String
  Dim AddrLine() As String
	Dim I As Integer

	MyTXINV = New TXINV.mydata(MyDBConnect)

  For I = 0 To (ds.Tables(0).Rows.Count - 2)
    With ds.Tables(0).Rows(I)
			MyTXINV.GetOneRecordP(.Item("listno"), .Item("year"), .Item("type"))
      myDr = myds.Tables(0).NewRow
      myDr("sortdata") = String.Empty
      myDr("listno") = .Item("listno")
      myDr("propdesc") = .Item("desc")
      myDr("year") = .Item("year")
      myDr("type") = .Item("type")
      myDr("TypeDesc") = GetTXTypeDesc(.Item("type"))
      WrkFamily = GetTXTypeFamily(.Item("type"))
      Select Case WrkFamily
      Case "M", "S"
				myDr.Item("propdesc") = Trim(MyTXINV._MAKE) & " " & MyTXINV._MVYR & " " & Trim(MyTXINV._IMVREG)
				myDr.Item("propdesc2") = Trim(MyTXINV._IMVIDNo)
      Case Else
				myDr.Item("propdesc") = Trim(MyTXINV._LOCNo) & " " & Trim(MyTXINV._LOC)
        myDr.Item("propdesc2") = ""
      End Select
      AddrLine = MyUtils.SetAddrLine(MyFrmTXA094B.TxtName.Text, MyFrmTXA094B.TxtSname.Text, MyFrmTXA094B.TxtAdd1.Text, _
        MyFrmTXA094B.TxtAdd2.Text, MyFrmTXA094B.TxtCity.Text, MyFrmTXA094B.TxtState.Text, MyFrmTXA094B.TxtZip5.Text, _
        MyFrmTXA094B.TxtZip4.Text)
      myDr("addr1") = AddrLine(0)
      myDr("addr2") = AddrLine(1)
      myDr("addr3") = AddrLine(2)
      myDr("addr4") = AddrLine(3)
      myDr("addr5") = AddrLine(4)
      myDr("amtdue") = .Item("tax")
      myDr("balance") = .Item("balance")
      myDr("interest") = .Item("interest")
      myDr("liens") = .Item("lien")
			myDr("fees") = .Item("fee")
			myDr("bond") = .Item("bond")
      myDr("total") = .Item("total")
			myDr("volpage") = Trim(MyTXINV._VOL) & " " & Trim(MyTXINV._IPAGE)
			myDr("AcctId") = Mid(.Item("year"), 3, 2) & .Item("type") & .Item("listno")
      myds.Tables(0).Rows.Add(myDr)
    End With
  Next

	MyTXINV.CloseFile()
	MyTXINV = Nothing
End Sub
Private Sub OnlineDupBill()
  Dim I As Integer

  For I = 0 To (myds.Tables(0).Rows.Count - 1)
    PrtDupBill(myds.Tables(0).Rows(I).Item("listno"), myds.Tables(0).Rows(I).Item("type"), _
     myds.Tables(0).Rows(I).Item("year"), MyFrmTXA094B.DtPckInt.Value, MyAppSettings.DupBillPrinter)
  Next

End Sub
End Module






