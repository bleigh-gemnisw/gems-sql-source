Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myGLRBCH As GLRBCH.MyData
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmGL403.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmGL403, MyFrmDltBch)
End Sub

  Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    With MyFrmGL403
      .TBarCreate.Enabled = True
      .TBarChange.Enabled = True
      .TBarNew.Enabled = False
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
    MyFrmGL403B.Show()
  End Sub

  Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLRBCH = New GLRBCH.MyData()
    myGLRBCH.MyDBConn = myDBConnect
    Me.Text = Me.Text & " " & WrkBatchNo
    With MyFrmGL403
      .TBarCreate.Enabled = False
      .TBarChange.Enabled = False
      .TBarNew.Enabled = False
      .TBarNew.Text = "New"
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
  End Sub

  Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

 myGLRBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
 myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
 If Not myBCHHDR.RecordNotFound Then
  myBCHHDR.DeleteOneRecordP()
  myGLRBCH.DeleteBatch(WrkBatchNo)
 End If

 MyFrmGL403B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class