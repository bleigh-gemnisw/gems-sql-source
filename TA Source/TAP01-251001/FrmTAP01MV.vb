Public Class FrmTAP01MV
  Dim MyTXDCMV As TXDCMV.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

Private Sub FrmTAP01MV_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarMV.Enabled = True
    End With
End Sub
Private Sub FrmTAP01MV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCMV = New TXDCMV.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarMV.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01MV_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01MV"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Visible = False
      .Columns(3).Caption = "Year"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Make"
      .Splits(0).DisplayColumns(4).Width = 70
      .Columns(5).Caption = "Model"
      .Splits(0).DisplayColumns(5).Width = 70
      .Columns(6).Caption = "Identification No"
      .Splits(0).DisplayColumns(6).Width = 150
      .Splits(0).DisplayColumns(7).Visible = False
      .Splits(0).DisplayColumns(8).Visible = False
      .Splits(0).DisplayColumns(9).Visible = False
      .Splits(0).DisplayColumns(10).Visible = False
      .Columns(11).Caption = "Value"
      .Splits(0).DisplayColumns(11).Width = 70
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCMV.GetByList(wrklistno, wrkyear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub

Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01MV2 = New FrmTAP01MV2
      MyFrmTAP01MV2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01MV2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01MV2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01MV2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01MV2.Show()
      MyFrmTAP01MV.Hide()
End Sub
End Class





