Public Class FrmTAP01ASS
  Dim MyTXDCASS As TXDCASS.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
Private Sub FrmTAP01ASS_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarSave.Enabled = True
      .TBarDecl.Enabled = False
      .TBarAss.Enabled = True
    End With
End Sub
Private Sub FrmTAP01ASS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCASS = New TXDCASS.mydata(MyDBConnect)

    With MyFrmTAP01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
      .TBarDecl.Enabled = True
      .TBarAss.Enabled = False
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    LblOwname.Text = Trim(MyFrmTAP01C.TxtOwname.Text) & " / " & Trim(MyFrmTAP01C.TxtDBA.Text)

    Call FormatGrid()
End Sub
  Private Sub FrmTAP01ASS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01ASS"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub FormatGrid()

    Call ShowGrid()
    With C1DataGrdList
      .Rebind(True)
      .Splits(0).DisplayColumns(0).Visible = False
      .Splits(0).DisplayColumns(1).Visible = False
      .Splits(0).DisplayColumns(2).Visible = False
      .Columns(3).Caption = "Code"
      .Splits(0).DisplayColumns(3).Width = 40
      .Columns(4).Caption = "Ltr"
      .Splits(0).DisplayColumns(4).Width = 40
      .Columns(5).Caption = "Description"
      .Splits(0).DisplayColumns(5).Width = 300
      .Splits(0).DisplayColumns(6).Visible = False
      .Columns(7).Caption = "Value"
      .Splits(0).DisplayColumns(7).Width = 50
    End With
  End Sub
  Public Sub ShowGrid()
    ds = MyTXDCASS.GetByList(WrkListNo, WrkYear)
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

  End Sub
Private Sub C1DataGrdList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1DataGrdList.DoubleClick
      MyFrmTAP01ASS2 = New FrmTAP01ASS2
      MyFrmTAP01ASS2.MdiParent = MyFrmTAP01B.ParentForm
      MyFrmTAP01ASS2.WrkListNo = C1DataGrdList.Item(C1DataGrdList.Row, 0)
      MyFrmTAP01ASS2.WrkYear = C1DataGrdList.Item(C1DataGrdList.Row, 1)
      MyFrmTAP01ASS2.WrkSeqNo = C1DataGrdList.Item(C1DataGrdList.Row, 2)
      MyFrmTAP01ASS2.Show()
      MyFrmTAP01ASS.Hide()
End Sub

Private Sub C1DataGrdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1DataGrdList.Click

End Sub
End Class





