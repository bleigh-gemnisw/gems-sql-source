Public Class FrmDltBch
  Dim myBCHHDR As BCHHDR.myData
  Dim myTAXBCH As TAXBCH.myData
  Dim myNETGLBCH As NETGLBCH.myData
  Friend WrkBatchNo As Integer

Private Sub FrmDltBch_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmGLA02.SbpScreen.Text = "DltBch"
  MyUtils.CenterForm(MyFrmGLA02, MyFrmDltBch)
End Sub

Private Sub FrmDltBch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
  With MyFrmGLA02
     .TBarCreate.Enabled = True
     .TBarImport.Enabled = True
     .TBarNew.Text = "New Batch"
     .TBarNew.Enabled = True
     .TBarDelete.Text = "Delete Batch"
     .TBarDelete.Enabled = True
     .TBarPrtEdits.Enabled = True
     .TBarPost.Enabled = True
  End With
 MyFrmGLA02B.Show()
End Sub

Private Sub FrmDltBch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   myBCHHDR = New BCHHDR.MyData()
   myBCHHDR.MyDBConn = myDBConnect
   myTAXBCH = New TAXBCH.myData()
   myTAXBCH.MyDBConn = myDBConnect
   myNETGLBCH = New NETGLBCH.MyData()
   myNETGLBCH.MyDBConn = myDBConnect
   Me.Text = Me.Text & " " & WrkBatchNo
  With MyFrmGLA02
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

  myTAXBCH.GetOneRecordP(WrkBatchNo, WrkBatchNo, 0)
  If RbDelete.Checked Then
    myNETGLBCH.DeleteBatch(myTAXBCH._REFNO, myTAXBCH._DIST)
  End If

  myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
 If Not myBCHHDR.RecordNotFound Then
  myBCHHDR.DeleteOneRecordP()
  myTAXBCH.DeleteBatch(WrkBatchNo)
 End If

 MyFrmGLA02B.FormatGrid()
 Me.Close()

End Sub

Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
   Me.Close()
End Sub
End Class