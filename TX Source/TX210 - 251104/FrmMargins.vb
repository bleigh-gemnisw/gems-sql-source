Public Class FrmMargins

Private Sub TbMain_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles TbMain.ButtonClick
  If e.Button Is TBarBack Then
    DoBtnBack()
  End If
  If e.Button Is TBarSave1 Then
    DoBtnSave()
  End If
End Sub
Private Sub DoBtnBack()
  Me.Close()
End Sub
Private Sub DoBtnSave()
  MyReportTopMargin = MyUtils.CnvSng(TxtTop.Text)
  MyReportLeftMargin = MyUtils.CnvSng(TxtLeft.Text)
  SetReportMargins()
  Me.Close()
End Sub

Private Sub FrmMargins_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  GetReportMargins()
  TxtTop.Text = MyReportTopMargin
  TxtLeft.Text = MyReportLeftMargin
End Sub
Private Sub TxtTop_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTop.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtLeft_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLeft.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





