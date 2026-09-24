Public Class FrmTAP01HOR
  Dim MyTXDCHOR As TXDCHOR.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
Private Sub FrmTAP01HOR_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarHor.Enabled = True
    End With
End Sub
Private Sub FrmTAP01HOR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCHOR = New TXDCHOR.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarHor.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01HOR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01HOR"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Visible = False
      .Columns(3).Caption = "Breed"
      .Splits(0).DisplayColumns(3).Width = 80
      .Columns(4).Caption = "Registered"
      .Splits(0).DisplayColumns(4).Width = 80
      .Columns(5).Caption = "Age"
      .Splits(0).DisplayColumns(5).Width = 50
      .Columns(6).Caption = "Sex"
      .Splits(0).DisplayColumns(6).Width = 50
      .Columns(7).Caption = "Quality"
      .Splits(0).DisplayColumns(7).Width = 100
      .Columns(8).Caption = "Value"
      .Splits(0).DisplayColumns(8).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCHOR.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01HOR2 = New FrmTAP01HOR2
      MyFrmTAP01HOR2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01HOR2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01HOR2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01HOR2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01HOR2.Show()
      MyFrmTAP01HOR.Hide()
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class





