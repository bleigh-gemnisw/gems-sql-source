Public Class FrmGLA35B_New
Dim myBCHHDR As BCHHDR.myData
Dim myMSCBCH As MSCBCH.myData

Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  If LblFilePath.Text = "" Then Exit Sub
  ProcBatch()
  MyFrmGLA35B.FormatGrid()
  MyFrmGLA35B.Show()
  Me.Close()
End Sub
  Private Sub FrmGLA35B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmGLA35.SbpScreen.Text = "GLA35B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

 Private Sub FrmGLA35B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmGLA35
   .TBarCreate.Enabled = True
   .TBarNew.Enabled = True
   .TBarDelete.Enabled = True
   .TBarPrtEdits.Enabled = True
   .TBarPost.Enabled = True
  End With
End Sub

Private Sub FrmGLA35_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmGLA35
   .TBarCreate.Enabled = False
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub

Private Sub LnkFilePath_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With OpenFileDialog1
    .ReadOnlyChecked = True
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
End Class