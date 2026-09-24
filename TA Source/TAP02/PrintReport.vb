Imports System.text
Module PrintReport

Dim myTXDMLST As TXDMLST.myData
Dim MyTXDMDEP As TXDMDEP.myData
Dim myTXDMSUM As TXDMSUM.myData
Dim Ds As DataSet = New DataSet
Dim DsSum As DataSet = New DataSet
Public Sub PrtReport()
 Dim MyCRViewer As FrmCrViewer
 myTXDMLST = New TXDMLST.mydata(MyDBConnect)
 MyTXDMDEP = New TXDMDEP.mydata(MyDBConnect)
 myTXDMSUM = New TXDMSUM.mydata(MyDBConnect)
  If Ds.Tables.Count = 0 Then
    BuildDS()
    BuildDSSum()
  Else
    Ds.Clear()
    DsSum.Clear()
  End If

 GetDetail()
 GetSummary()

Done:
 MyCRViewer = New FrmCrViewer
 MyCRViewer.wrkds = Ds
 MyCRViewer.wrkdsSum = DsSum
 MyCRViewer.WrkYear = MyUtils.CnvSng(MyFrmTAP02C.LblYear.Text)
 MyCRViewer.ShowDialog()

End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Descr", Type.GetType("System.String"))
      .Columns.Add("Acqdt", Type.GetType("System.DateTime"))
      .Columns.Add("Insdt", Type.GetType("System.DateTime"))
      .Columns.Add("GLYear", Type.GetType("System.Int32"))
      .Columns.Add("Cost", Type.GetType("System.Int32"))
    End With
    Ds.Tables.Add(myTable)
  End Sub
  Private Sub BuildDSSum()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("LAddr", Type.GetType("System.String"))
      .Columns.Add("DeYear", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Int32"))
      .Columns.Add("DeCost", Type.GetType("System.Int32"))
      .Columns.Add("DeNet", Type.GetType("System.Int32"))
      .Columns.Add("AsCost", Type.GetType("System.Int32"))
      .Columns.Add("AsNet", Type.GetType("System.Int32"))
    End With
    DsSum.Tables.Add(myTable)
 End Sub
Private Sub GetDetail()
 Dim DsFile As DataSet = New DataSet
 Dim dr As Data.DataRow
 Dim WrkListNo As Integer
 Dim WrkYear As Integer
 Dim I As Integer

 WrkListNo = MyUtils.CnvSng(MyFrmTAP02C.TxtListNo.Text)
 WrkYear = MyUtils.CnvSng(MyFrmTAP02C.LblYear.Text)

 DsFile = myTXDMLST.GetByList(WrkListNo, WrkYear)
 For I = 0 To DsFile.Tables(0).Rows.Count - 1
  With MyFrmTAP02LST
   dr = Ds.Tables(0).NewRow
   dr.Item("listno") = WrkListNo
   dr.Item("name") = MyFrmTAP02C.TxtName.Text
   dr.Item("descr") = Trim(DsFile.Tables(0).Rows(I).Item("prdesc"))
   dr.Item("glyear") = DsFile.Tables(0).Rows(I).Item("glyear")
   dr.Item("cost") = DsFile.Tables(0).Rows(I).Item("acqcst")
   dr.Item("acqdt") = MyUtils.GetDBDate(DsFile.Tables(0).Rows(I).Item("acqdt"))
   dr.Item("insdt") = MyUtils.GetDBDate(DsFile.Tables(0).Rows(I).Item("insdt"))
   Ds.Tables(0).Rows.Add(dr)
  End With
 Next

End Sub
Private Sub GetSummary()
  Dim ds3 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkYear As Integer
  Dim I As Integer

  WrkYear = MyUtils.CnvSng(MyFrmTAP02C.LblYear.Text)
  'Summary 
  ds3 = myTXDMSUM.GetByList(MyUtils.CnvSng(MyFrmTAP02C.TxtListNo.Text), WrkYear)
  For I = 0 To ds3.Tables(0).Rows.Count - 1
      If ds3.Tables(0).Rows(I).Item("decost") = 0 Then Continue For
      dr = DsSum.Tables(0).NewRow
      dr("ListNo") = MyUtils.CnvSng(MyFrmTAP02C.TxtListNo.Text)
      dr("Name") = MyFrmTAP02C.TxtName.Text
      dr("laddr") = Trim(MyFrmTAP02C.TxtLocNo.Text) & " " & Trim(MyFrmTAP02C.TxtLoc.Text)
      dr("DeYear") = WrkYear - ds3.Tables(0).Rows(I).Item("deyear") + 1
      MyTXDMDEP.GetOneRecordP(WrkYear, ds3.Tables(0).Rows(I).Item("deyear"))
      dr("Pct") = MyTXDMDEP._PCT
      dr("DeCost") = ds3.Tables(0).Rows(I).Item("decost")
      dr("DeNet") = ds3.Tables(0).Rows(I).Item("denet")
      dr("AsCost") = ds3.Tables(0).Rows(I).Item("ascost")
      dr("AsNet") = ds3.Tables(0).Rows(I).Item("asnet")
      DsSum.Tables(0).Rows.Add(dr)
  Next
End Sub
End Module






