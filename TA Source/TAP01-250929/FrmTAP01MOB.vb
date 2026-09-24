Public Class FrmTAP01MOB
  Dim MyTXDCMOB As TXDCMOB.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer

Private Sub FrmTAP01MOB_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarMob.Enabled = True
    End With
End Sub
Private Sub FrmTAP01MOB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCMOB = New TXDCMOB.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarMob.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01MOB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01MOB"
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
    ds = MyTXDCMOB.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01MOB2 = New FrmTAP01MOB2
      MyFrmTAP01MOB2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01MOB2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01MOB2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01MOB2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01MOB2.Show()
      MyFrmTAP01MOB.Hide()
End Sub

End Class





