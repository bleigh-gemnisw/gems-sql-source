Public Class FrmPO201B_New
Dim myBCHHDR As BCHHDR.myData
Dim myRQEBCH As RQEBCH.myData

Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  MyPostDate = DtPckPost.Value.Date
  MyFrmPO201D = New FrmPO201D
  MyFrmPO201D.MdiParent = Me.ParentForm
  MyFrmPO201D.WrkBatchNo = 0
  MyFrmPO201D.WrkLlocn = MyFrmPO201B.LblLlocn.Text
  MyFrmPO201D.Show()
  Me.Close()
End Sub
  Private Sub FrmPO201B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmPO201.SbpScreen.Text = "PO201B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

 Private Sub FrmPO201B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmPO201
   .TBarNew.Enabled = True
   .TBarDelete.Enabled = True
  End With
End Sub

Private Sub FrmPO201_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmPO201
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub
End Class