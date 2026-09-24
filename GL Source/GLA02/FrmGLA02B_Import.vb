Public Class FrmGLA02B_Import

Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub

Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
  If MyFrmGLA02B_Import.LblFilePath.Text <> "" Then
    ProcBatches(True)
    MyFrmGLA02B.FormatGrid()
  End If
End Sub
  Private Sub FrmGLA02B_Import_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmGLA02.SbpScreen.Text = "GLA02B_Import"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub
 Private Sub FrmGLA02B_Import_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmGLA02
   .TBarCreate.Enabled = True
   .TBarImport.Enabled = True
   .TBarNew.Enabled = True
   .TBarDelete.Enabled = True
   .TBarPrtEdits.Enabled = True
   .TBarPost.Enabled = True
  End With
End Sub

Private Sub FrmGLA02_Import_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmGLA02
   .TBarCreate.Enabled = False
   .TBarImport.Enabled = False
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub
End Class