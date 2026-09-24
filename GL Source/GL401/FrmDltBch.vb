Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myGLEBCH As GLEBCH.myData
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmGL401.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmGL401, MyFrmDltBch)
End Sub

Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  With MyFrmGL401
     .TBarCreate.Enabled = True
     .TBarImport.Enabled = True
     .TBarNew.Enabled = False
     .TBarDelete.Text = "Delete Batch"
     .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = True
  End With
 MyFrmGL401B.Show()
End Sub

Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.MyData()
   myBCHHDR.MyDBConn = myDBConnect
   myGLEBCH = New GLEBCH.myData()
   myGLEBCH.MyDBConn = myDBConnect
   Me.Text = Me.Text & " " & WrkBatchNo
  With MyFrmGL401
   .TBarCreate.Enabled = False
   .TBarImport.Enabled = False
   .TBarNew.Enabled = False
   .TBarNew.Text = "New"
   .TBarDelete.Enabled = False
   .TBarDelete.Text = "Delete"
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub

Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

 myGLEBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
 myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
 If Not myBCHHDR.RecordNotFound Then
  myBCHHDR.DeleteOneRecordP()
  myGLEBCH.DeleteBatch(WrkBatchNo)
 End If

 MyFrmGL401B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class