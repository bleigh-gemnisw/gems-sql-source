Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myRQEBCH As RQEBCH.myData
  Dim myRQEBCD As RQEBCD.MyData
  Friend WrkLlocn As String
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmPO201.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmPO201, MyFrmDltBch)
End Sub

Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  With MyFrmPO201
     .TBarNew.Text = "New Batch"
     .TBarNew.Enabled = True
     .TBarDelete.Text = "Delete Batch"
     .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = False
  End With
 MyFrmPO201B.Show()
End Sub

Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.myData()
   myBCHHDR.MyDBConn = myDBConnect
   myRQEBCH = New RQEBCH.MyData()
   myRQEBCH.MyDBConn = myDBConnect
   myRQEBCD = New RQEBCD.MyData()
   myRQEBCD.MyDBConn = myDBConnect
   Me.Text = Me.Text & " " & WrkBatchNo
  With MyFrmPO201
   .TBarNew.Enabled = False
   .TBarNew.Text = "New"
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
  myRQEBCH.DeleteBatch(WrkBatchNo)
  myRQEBCD.DeleteBatch(WrkLlocn, WrkBatchNo)
 End If

 MyFrmPO201B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class