Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myCSHBCH As CSHBCH.myData
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmAR101.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmAR101, MyFrmDltBch)
End Sub

Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  With MyFrmAR101
     .TBarCreate.Enabled = True
      .TBarDelete.Text = "Delete Batch"
      .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = True
  End With
 MyFrmAR101B.Show()
End Sub

Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.MyData()
   myBCHHDR.MyDBConn = myDBConnect
   myCSHBCH = New CSHBCH.myData()
   myCSHBCH.MyDBConn = myDBConnect
   Me.Text = Me.Text & " " & WrkBatchNo
  With MyFrmAR101
   .TBarCreate.Enabled = False
      .TBarDelete.Enabled = False
      .TBarDelete.Text = "Delete"
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub

Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

 myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
 If Not myBCHHDR.RecordNotFound Then
  myBCHHDR.DeleteOneRecordP()
  myCSHBCH.DeleteBatch(WrkBatchNo)
 End If

 MyFrmAR101B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class