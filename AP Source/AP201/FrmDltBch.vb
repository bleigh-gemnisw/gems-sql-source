Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myAPEBCH As APEBCH.myData
  Dim myAPEBCD As APEBCD.MyData
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmAP201.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmAP201, MyFrmDltBch)
End Sub

Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  With MyFrmAP201
     .TBarNew.Text = "New Batch"
     .TBarNew.Enabled = True
     .TBarDelete.Text = "Delete Batch"
     .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = True
  End With
 MyFrmAP201B.Show()
End Sub

Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.myData()
   myBCHHDR.MyDBConn = myDBConnect
   myAPEBCH = New APEBCH.MyData()
   myAPEBCH.MyDBConn = myDBConnect
   myAPEBCD = New APEBCD.MyData()
   myAPEBCD.MyDBConn = myDBConnect
   Me.Text = Me.Text & " " & WrkBatchNo
  With MyFrmAP201
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
  myAPEBCH.DeleteBatch(WrkBatchNo)
  myAPEBCD.DeleteBatch(WrkBatchNo)
 End If

 MyFrmAP201B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class