Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myMSCBCH As MSCBCH.myData
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmGLA35.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmGLA35, MyFrmDltBch)
End Sub

Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  With MyFrmGLA35
     .TBarCreate.Enabled = True
     .TBarNew.Text = "New Batch"
     .TBarNew.Enabled = True
     .TBarDelete.Text = "Delete Batch"
     .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = True
  End With
 MyFrmGLA35B.Show()
End Sub

Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.MyData()
   myBCHHDR.MyDBConn = myDBConnect
   myMSCBCH = New MSCBCH.myData()
   myMSCBCH.MyDBConn = myDBConnect
   Me.Text = Me.Text & " " & WrkBatchNo
  With MyFrmGLA35
   .TBarCreate.Enabled = False
   .TBarNew.Enabled = False
   .TBarNew.Text = "New"
   .TBarDelete.Enabled = False
   .TBarDelete.Text = "Delete"
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
End Sub

Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click

 myMSCBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
 myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
 If Not myBCHHDR.RecordNotFound Then
  myBCHHDR.DeleteOneRecordP()
  myMSCBCH.DeleteBatch(WrkBatchNo)
 End If

 MyFrmGLA35B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class