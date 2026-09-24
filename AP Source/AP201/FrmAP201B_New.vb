Public Class FrmAP201B_New
Dim myBCHHDR As BCHHDR.myData
Dim myAPEBCH As APEBCH.myData

Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  MyPostDate = DtPckPost.Value
  MyFrmAP201D = New FrmAP201D
  MyFrmAP201D.MdiParent = Me.ParentForm
  MyFrmAP201D.WrkBatchNo = 0
  MyFrmAP201D.Show()
  Me.Close()
End Sub
  Private Sub FrmAP201B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmAP201.SbpScreen.Text = "AP201B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

 Private Sub FrmAP201B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmAP201
   .TBarNew.Enabled = True
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub

Private Sub FrmAP201_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmAP201
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub
End Class