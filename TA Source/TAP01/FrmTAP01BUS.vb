Public Class FrmTAP01BUS
  Dim MyTXDCBUS As TXDCBUS.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
Private Sub FrmTAP01BUS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarBus.Enabled = True
    End With
End Sub
Private Sub FrmTAP01BUS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCBUS = New TXDCBUS.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarBus.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01BUS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01BUS"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()
    Dim I As Integer

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      For I = 0 To 2
        .Splits(0).DisplayColumns(I).Visible = False
      Next
      .Columns(3).Caption = "Name"
      .Splits(0).DisplayColumns(3).Width = 200
      .Columns(4).Caption = "Address"
      .Splits(0).DisplayColumns(4).Width = 200
      .Columns(5).Caption = "City"
      .Splits(0).DisplayColumns(5).Width = 200
      For I = 6 To 8
        .Splits(0).DisplayColumns(I).Visible = False
      Next
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCBUS.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01BUS2 = New FrmTAP01BUS2
      MyFrmTAP01BUS2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01BUS2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01BUS2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01BUS2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01BUS2.Show()
      MyFrmTAP01BUS.Hide()
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class





