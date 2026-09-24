Public Class FrmTAP01TWN
  Dim MyTXDCTWN As TXDCTWN.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

Private Sub FrmTAP01TWN_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarTowns.Enabled = True
    End With
End Sub
Private Sub FrmTAP01TWN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCTWN = New TXDCTWN.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarTowns.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01TWN_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01TWN"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()
    Dim I As Integer

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      For I = 0 To 4
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      .Columns(5).Caption = "Loc No"
      .Splits(0).DisplayColumns(5).Width = 70
      .Columns(6).Caption = "Location"
      .Splits(0).DisplayColumns(6).Width = 200
      .Columns(7).Caption = "Cost"
      .Splits(0).DisplayColumns(7).Width = 80
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCTWN.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01TWN2 = New FrmTAP01TWN2
      MyFrmTAP01TWN2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01TWN2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01TWN2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01TWN2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01TWN2.Show()
      MyFrmTAP01TWN.Hide()
End Sub

End Class





