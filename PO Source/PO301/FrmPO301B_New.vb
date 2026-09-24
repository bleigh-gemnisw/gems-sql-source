Public Class FrmPO301B_New
Dim myBCHHDR As BCHHDR.myData
Dim myPOMBCH As POMBCH.myData

Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  MyPostDate = DtPckPost.Value.Date
  MyFrmPO301D = New FrmPO301D
  MyFrmPO301D.MdiParent = Me.ParentForm
  MyFrmPO301D.WrkBatchNo = 0
  MyFrmPO301D.Show()
  Me.Close()
End Sub
  Private Sub FrmPO301B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmPO301.SbpScreen.Text = "PO301B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

 Private Sub FrmPO301B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmPO301
   .TBarNew.Enabled = True
   .TBarDelete.Enabled = True
  End With
End Sub

Private Sub FrmPO301_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmPO301
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub
End Class