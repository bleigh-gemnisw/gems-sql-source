Public Class FrmGL401B_Import

  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With OpenFileDialog1
      .ReadOnlyChecked = True
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub

  Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
    If MyFrmGL401B_Import.LblFilePath.Text <> "" Then
      ProcBatch()
      MyFrmGL401B.FormatGrid()
      MyFrmGL401B.Show()
      Me.Close()
    End If
  End Sub
  Private Sub FrmGL401B_Import_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    MyFrmGL401.SbpScreen.Text = "GL401B_Import"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmGL401B_Import_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmGL401
      .TBarCreate.Enabled = True
      .TBarImport.Enabled = True
      .TBarLayout.Enabled = False
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
  End Sub

  Private Sub FrmGL401_Import_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With MyFrmGL401
      .TBarCreate.Enabled = False
      .TBarImport.Enabled = False
      .TBarLayout.Enabled = True
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
  End Sub

  Private Sub RbPRJE_CheckedChanged(sender As Object, e As EventArgs) Handles RbPRJE.CheckedChanged

  End Sub
End Class