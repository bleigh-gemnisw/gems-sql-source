Imports System.io
Imports System.Text
Module PrintReport

Public myTXFMBILL As TXFMBILL.myData
Public myTXFMSTMT As TXFMSTMT.myData
Public myTXMRATE As TXMRATE.myData
Dim ds As DataSet = New DataSet
Dim dr As Data.DataRow

  Public Sub PrtReport()

  With MyFrmTX340B
  End With

  If ds.Tables.Count = 0 Then
    BuildDS(ds)
  Else
    ds.Clear()
  End If

  GetDetail()

Done:
  MyCrViewer = New FrmCrViewer
  With MyCrViewer
    .wrkds = ds
    .Show()
  End With
  End Sub
Public Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable2"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("BillType", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Addr1", Type.GetType("System.String"))
      .Columns.Add("Addr2", Type.GetType("System.String"))
      .Columns.Add("Addr3", Type.GetType("System.String"))
      .Columns.Add("Addr4", Type.GetType("System.String"))
      .Columns.Add("Addr5", Type.GetType("System.String"))
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
      .Columns.Add("PostNet", Type.GetType("System.String"))
      .Columns.Add("ScanLine", Type.GetType("System.String"))
      .Columns.Add("AddlDesc", Type.GetType("System.String"))
      .Columns.Add("AddlDesc2", Type.GetType("System.String"))
      .Columns.Add("AddlDesc3", Type.GetType("System.String"))
      .Columns.Add("CCNo", Type.GetType("System.Int32"))
      .Columns.Add("CCDesc", Type.GetType("System.String"))
      .Columns.Add("CCDate", Type.GetType("System.DateTime"))
  End With
  ds.Tables.Add(myTable)
End Sub
Private Sub GetDetail()
  With MyFrmTX340B
    dr = ds.Tables(0).NewRow
    'Create Billing File
    If .RbRE.Checked Then
      dr.Item("BillType") = "Real Estate"
    Else
      dr.Item("BillType") = "Personal Property"
    End If
    dr.Item("listno") = MyUtils.CnvSng(.TxtListNo.Text)
    dr.Item("year") = MyUtils.CnvSng(.TxtYear.Text)
    dr.Item("addr1") = .TxtAddr1.Text
    dr.Item("addr2") = .TxtAddr2.Text
    dr.Item("addr3") = .TxtAddr3.Text
    dr.Item("addr4") = .TxtAddr4.Text
    dr.Item("addr5") = .TxtAddr5.Text
    dr.Item("bank") = String.Empty
    dr.Item("gross") = MyUtils.CnvSng(.TxtGross.Text)
    dr.Item("exemption") = MyUtils.CnvSng(.TxtExam.Text)
    dr.Item("net") = MyUtils.CnvSng(.TxtNet.Text)
    dr.Item("taxtot") = MyUtils.CnvSng(.TxtTax.Text)
    dr.Item("tax1st") = 0
    dr.Item("tax2nd") = 0
    dr.Item("stbenefit") = 0
    dr.Item("townbenefit") = 0
    dr.Item("propdesc") = .TxtPropDesc.Text
    dr.Item("propdesc2") = String.Empty
    dr.Item("backtax") = False
    dr.Item("barcode") = String.Empty
    dr.Item("postnet") = String.Empty
    dr.Item("scanline") = String.Empty
    dr.Item("ccno") = 0
    dr.Item("ccdesc") = String.Empty
'    dr.Item("ccdate") = 
    ds.Tables(0).Rows.Add(dr)
End With

End Sub
Public Sub GetMillRate(ByVal WrkGLYear As Integer, ByVal WrkType As String, ByVal WrkDist As Integer)

  myTXMRATE = New TXMRATE.mydata(MyDBConnect)
  myTXMRATE.GetOneRecordP(WrkGLYear, WrkType, WrkDist)
  If myTXMRATE.RecordNotFound Then
    myTXMRATE.GetOneRecordP(WrkGLYear, "", WrkDist)
  End If
End Sub
Public Sub GetTXFMBILL(ByVal WrkType As String)
  myTXFMBILL = New TXFMBILL.mydata(MyDBConnect)
  myTXFMBILL.GetOneRecordP(WrkType)
End Sub
Public Sub GetTXFMSTMT(ByVal WrkType As String)
  myTXFMSTMT = New TXFMSTMT.mydata(MyDBConnect)
  myTXFMSTMT.GetOneRecordP(WrkType)
End Sub
End Module






