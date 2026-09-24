Public Class FrmTAP03SUM
  Dim MyTXDVCD As TXDVCD.myData
  Dim MyTXDCSUM As TXDCSUM.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Dim WrkDeprValue As Integer
  Dim WrkAssrNet As Integer
  Private Sub FrmTAP01SUM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP03
      .TBarMV.Enabled = False
      .TBarSum.Enabled = True
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarPrint.Enabled = False
    End With
End Sub
Private Sub FrmTAP01SUM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDVCD = New TXDVCD.mydata(MyDBConnect)
    MyTXDCSUM = New TXDCSUM.mydata(MyDBConnect)

    With MyFrmTAP03
      .TBarMV.Enabled = True
      .TBarSum.Enabled = False
      .TBarDelete.Enabled = False
      .TBarPrint.Enabled = True
      .TBarSave.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblName.Text = MyFrmTAP03C.TxtName.Text

    BuildDS(ds)
    BuildGrid()
    ShowGrid()

End Sub
  Private Sub FrmTAP01SUM_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP03.SbpScreen.Text = "TAP03SUM"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
    MyFrmTAP03SUM2 = New FrmTAP03SUM2
    MyFrmTAP03SUM2.MdiParent = MyFrmTAP03B.ParentForm
    MyFrmTAP03SUM2.WrkListNo = WrkListNo
    MyFrmTAP03SUM2.WrkYear = WrkYear
    MyFrmTAP03SUM2.WrkCode = C1DataGrdList.Item(C1DataGrdList.Row, 0)
    MyFrmTAP03SUM2.WrkDesc = C1DataGrdList.Item(C1DataGrdList.Row, 1)
    MyFrmTAP03SUM2.WrkPct = C1DataGrdList.Item(C1DataGrdList.Row, 4)
    MyFrmTAP03SUM2.Show()
    MyFrmTAP03SUM.Hide()
End Sub

  Private Sub BuildDS(ByRef ds As DataSet)
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Code", Type.GetType("System.Int32"))
      .Columns.Add("Desc", Type.GetType("System.String"))
      .Columns.Add("Depr", Type.GetType("System.Int32"))
      .Columns.Add("Net", Type.GetType("System.Int32"))
      .Columns.Add("Pct", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
Sub BuildGrid()
    Dim ds2 As DataSet = New DataSet
    Dim myDr As Data.DataRow
    Dim I As Integer

    WrkDeprValue = 0
    WrkAssrNet = 0
    ds.Clear()

		ds2 = MyTXDVCD.GetAllYear(WrkYear)
    For I = 0 To ds2.Tables(0).Rows.Count - 1
      MyTXDCSUM.GetOneRecordP(WrkListNo, WrkYear, ds2.Tables(0).Rows(I).Item("code"))
      With MyTXDCSUM
        myDr = ds.Tables(0).NewRow
        myDr("Code") = ds2.Tables(0).Rows(I).Item("code")
        myDr("Desc") = ds2.Tables(0).Rows(I).Item("desc")
        If .RecordNotFound Then
          myDr("Depr") = 0
          myDr("Net") = 0
        Else
          myDr("Depr") = ._VALUE
          myDr("Net") = ._NET
          If ds2.Tables(0).Rows(I).Item("code") <> 25 Then
            WrkDeprValue = WrkDeprValue + ._VALUE
            WrkAssrNet = WrkAssrNet + ._NET
          End If
        End If
        myDr("Pct") = ds2.Tables(0).Rows(I).Item("aspct")
        ds.Tables(0).Rows.Add(myDr)
      End With
    Next

    LblDeprValue.Text = WrkDeprValue
    LblAssrNet.Text = WrkAssrNet
End Sub
    Public Sub ShowGrid()
     Windows.Forms.Cursor.Current = Cursors.WaitCursor

     With C1DataGrdList
      .DataSource = ds.Tables(0)
      .Refresh()
      .Columns(0).Caption = "Code"
      .Splits(0).DisplayColumns(0).Width = 40
      .Columns(1).Caption = "Description"
      .Splits(0).DisplayColumns(1).Width = 250
      .Columns(2).Caption = "Depr Value"
      .Splits(0).DisplayColumns(2).Width = 70
      .Columns(3).Caption = "Assr Net"
      .Splits(0).DisplayColumns(3).Width = 70
      .Splits(0).DisplayColumns(4).Visible = False
     End With
     Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

End Class





