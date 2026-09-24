Public Class FrmTAP01LEE
  Dim MyTXDCLEE As TXDCLEE.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
Private Sub FrmTAP01LEE_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarLee.Enabled = True
    End With
End Sub
Private Sub FrmTAP01LEE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCLEE = New TXDCLEE.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarLee.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01LEE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01LEE"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()
    Dim I As Integer

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Visible = False
      .Columns(3).Caption = "Name"
      .Splits(0).DisplayColumns(3).Width = 250
      .Columns(4).Caption = "Address"
      .Splits(0).DisplayColumns(4).Width = 250
      .Splits(0).DisplayColumns(5).Visible = False
      .Columns(6).Caption = "Description"
      .Splits(0).DisplayColumns(6).Width = 200
      For I = 7 To 15
        .Splits(0).DisplayColumns(I).Visible = False
      Next
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCLEE.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01LEE2 = New FrmTAP01LEE2
      MyFrmTAP01LEE2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01LEE2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01LEE2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01LEE2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01LEE2.Show()
      MyFrmTAP01LEE.Hide()
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class





