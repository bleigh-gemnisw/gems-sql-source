Public Class FrmGL401B_New
Dim myBCHHDR As BCHHDR.myData
Dim myGLEBCH As GLEBCH.myData

Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  Dim WrkNextBatch As Integer

  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myGLEBCH = New GLEBCH.myData()
  myGLEBCH.MyDBConn = myDBConnect
  myBCHHDR.GetOneRecordP(MyBatch, 0)
  If myBCHHDR.RecordNotFound Then
    With myBCHHDR
      ._APPID = MyBatch
      ._BCHNO = 0
      .AddOneRecordP()
    End With
  End If

  WrkNextBatch = myBCHHDR.AutoGenKey(MyBatch)
  myBCHHDR.GetOneRecordP(MyBatch, WrkNextBatch)
  If myBCHHDR.RecordNotFound Then
    With myBCHHDR
      ._APPID = MyBatch
      ._BCHNO = WrkNextBatch
      ._ORGUS = "GEMSNET"
      ._LSTUS = MyUserID
      ._STATS = "S"
      ._SUBST = ""
      ._PSDT = MyUtils.SetDBDate(DtPckPost.Value)
      .AddOneRecordP()
    End With

    myBCHHDR.GetOneRecordP(MyBatch, 0)
    If Not myBCHHDR.RecordNotFound Then
      With myBCHHDR
        ._LSBCH = WrkNextBatch
        .UpdateOneRecordP()
      End With
    End If
  End If

  MyFrmGL401B.FormatGrid()
  MyFrmGL401B.Show()
  Me.Close()
  MsgBox("Batch " & WrkNextBatch & " has been created", MsgBoxStyle.Information, "New Batch")

End Sub
  Private Sub FrmGL401B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmGL401.SbpScreen.Text = "GL401B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

 Private Sub FrmGL401B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmGL401
   .TBarCreate.Enabled = True
   .TBarImport.Enabled = True
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = True
   .TBarPrtEdits.Enabled = True
   .TBarPost.Enabled = True
  End With
End Sub

Private Sub FrmGL401_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmGL401
   .TBarCreate.Enabled = False
   .TBarImport.Enabled = True
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
   DtPckPost.Value = Date.Today
End Sub

End Class