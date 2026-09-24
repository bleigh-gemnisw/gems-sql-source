Public Class FrmTAP01DSP
  Dim MyTXDCDSP As TXDCDSP.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
Private Sub FrmTAP01DSP_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarDsp.Enabled = True
    End With
End Sub
Private Sub FrmTAP01DSP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCDSP = New TXDCDSP.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarDsp.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01DSP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01DSP"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Visible = False
      .Splits(0).DisplayColumns(3).Visible = False
      .Columns(4).Caption = "Code"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Ltr"
      .Splits(0).DisplayColumns(5).Width = 40
      .Columns(6).Caption = "Description"
      .Splits(0).DisplayColumns(6).Width = 150
      .Splits(0).DisplayColumns(7).Visible = False
      .Columns(8).Caption = "Value"
      .Splits(0).DisplayColumns(8).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCDSP.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01DSP2 = New FrmTAP01DSP2
      MyFrmTAP01DSP2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01DSP2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01DSP2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01DSP2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01DSP2.Show()
      MyFrmTAP01DSP.Hide()
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class





