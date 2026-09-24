Imports System.text
Module PrintReport
Dim myTXDCSUM As TXDCSUM.myData
Dim myTXDVCD As TXDVCD.myData
Dim DsSum As DataSet = New DataSet
Public Sub PrtReport()
  Dim MyCRViewer As FrmCrViewer
  myTXDCSUM = New TXDCSUM.mydata(MyDBConnect)
  myTXDVCD = New TXDVCD.mydata(MyDBConnect)

  If DsSum.Tables.Count = 0 Then
    BuildDSSum()
  Else
    DsSum.Clear()
  End If

  GetSummary()

Done:
  MyCRViewer = New FrmCrViewer
  MyCRViewer.wrkdsSum = DsSum
  MyCRViewer.WrkYear = MyFrmTAP03C.LblYear.Text
  MyCRViewer.ShowDialog()

End Sub
  Private Sub BuildDSSum()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("ListNo", Type.GetType("System.Int32"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Name", Type.GetType("System.String"))
      .Columns.Add("Code", Type.GetType("System.Int32"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Depr", Type.GetType("System.Int32"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
    End With
    DsSum.Tables.Add(myTable)
 End Sub
Private Sub GetSummary()
  Dim ds2 As DataSet = New DataSet
  Dim dr As Data.DataRow
  Dim WrkListNo As Integer
  Dim WrkYear As Integer

  Dim I As Integer

  WrkListNo = MyUtils.CnvSng(MyFrmTAP03C.TxtListNo.Text)
  WrkYear = MyUtils.CnvSng(MyFrmTAP03C.LblYear.Text)
  ds2 = MyTXDVCD.GetAllYear(WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      myTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, ds2.Tables(0).Rows(I).Item("code"))
      With myTXDCSUM
        dr = DsSum.Tables(0).NewRow
        dr("ListNo") = wrklistno
        dr("Name") = MyFrmTAP03C.TxtName.Text
        dr("Code") = ds2.Tables(0).Rows(I).Item("code")
        dr("Desc") = ds2.Tables(0).Rows(I).Item("desc")
        If .RecordNotFound Then
          dr("Depr") = 0
          dr("Net") = 0
        Else
          dr("Depr") = ._VALUE
          dr("Net") = ._NET
        End If
        DsSum.Tables(0).Rows.Add(dr)
      End With
    Next

  End Sub
End Module






