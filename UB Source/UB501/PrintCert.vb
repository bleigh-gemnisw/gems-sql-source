Module PrintCert
  Dim ds As DataSet = New DataSet

  Public Sub PrtCert(ByVal WrkType As String)

    BuildPrtDS()
    AddRecord()
    MyFrmCrViewer = New FrmCrViewer
    MyFrmCrViewer.Wrkds = ds
    MyFrmCrViewer.WrkType = WrkType
    MyFrmCrViewer.ShowDialog()
    ds.Tables.Remove("mytable")

  End Sub
  Private Sub BuildPrtDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Type", Type.GetType("System.String"))
      .Columns.Add("TypeDesc", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Cdate", Type.GetType("System.DateTime"))
      .Columns.Add("Cdesc", Type.GetType("System.String"))
      .Columns.Add("Locno", Type.GetType("System.String"))
      .Columns.Add("Loc", Type.GetType("System.String"))
      .Columns.Add("Rsncd", Type.GetType("System.String"))
      .Columns.Add("RsnDesc", Type.GetType("System.String"))
      .Columns.Add("Otax1", Type.GetType("System.Decimal"))
      .Columns.Add("Ntax1", Type.GetType("System.Decimal"))
      .Columns.Add("Ctax1", Type.GetType("System.Decimal"))
      .Columns.Add("Otax2", Type.GetType("System.Decimal"))
      .Columns.Add("Ntax2", Type.GetType("System.Decimal"))
      .Columns.Add("Ctax2", Type.GetType("System.Decimal"))
      .Columns.Add("Otax3", Type.GetType("System.Decimal"))
      .Columns.Add("Ntax3", Type.GetType("System.Decimal"))
      .Columns.Add("Ctax3", Type.GetType("System.Decimal"))
      .Columns.Add("Otax4", Type.GetType("System.Decimal"))
      .Columns.Add("Ntax4", Type.GetType("System.Decimal"))
      .Columns.Add("Ctax4", Type.GetType("System.Decimal"))
      .Columns.Add("Obond", Type.GetType("System.Decimal"))
      .Columns.Add("Nbond", Type.GetType("System.Decimal"))
      .Columns.Add("Cbond", Type.GetType("System.Decimal"))
    End With
    ds.Tables.Add(myTable)
  End Sub

  Private Sub AddRecord()
    Dim myDr As Data.DataRow

    myDr = ds.Tables(0).NewRow
    With MyFrmUB501C
      myDr("ccno") = .WrkCCNo
      myDr("listno") = .WrkListNo
      myDr("type") = .WrkType
      myDr("typedesc") = GetUTTypeDesc(.WrkType)
      myDr("year") = .WrkYear
      myDr("cdate") = .LblCCDate.Text
      myDr("locno") = .TxtLocNo.Text
      myDr("loc") = .TxtLoc.Text
      myDr("rsncd") = .TxtReason.Text
      myDr("rsndesc") = GetUTCRESNDesc(.TxtReason.Text)
      myDr("cdesc") = .TxtDesc.Text
      myDr("otax1") = MyUtils.CnvSng(.LblOrigTax1.Text)
      myDr("ntax1") = MyUtils.CnvSng(.TxtTax1.Text)
      myDr("ctax1") = MyUtils.CnvSng(.LblChgTax1.Text)
      myDr("otax2") = MyUtils.CnvSng(.LblOrigTax2.Text)
      myDr("ntax2") = MyUtils.CnvSng(.TxtTax2.Text)
      myDr("ctax2") = MyUtils.CnvSng(.LblChgTax2.Text)
      myDr("otax3") = MyUtils.CnvSng(.LblOrigTax3.Text)
      myDr("ntax3") = MyUtils.CnvSng(.TxtTax3.Text)
      myDr("ctax3") = MyUtils.CnvSng(.LblChgTax3.Text)
      myDr("otax4") = MyUtils.CnvSng(.LblOrigTax4.Text)
      myDr("ntax4") = MyUtils.CnvSng(.TxtTax4.Text)
      myDr("ctax4") = MyUtils.CnvSng(.LblChgTax4.Text)
      myDr("obond") = MyUtils.CnvSng(.LblOrigBond.Text)
      myDr("nbond") = MyUtils.CnvSng(.TxtBond.Text)
      myDr("cbond") = MyUtils.CnvSng(.LblChgBond.Text)
      ds.Tables(0).Rows.Add(myDr)
    End With

  End Sub
End Module






