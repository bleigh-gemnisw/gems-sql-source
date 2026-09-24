Public Class FrmGL403B_New
  Friend WrkMode As String
  Friend WrkBatchNo As Integer
  Dim myBCHHDR As BCHHDR.MyData
  Dim myGLRBCH As GLRBCH.MyData

  Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
    Dim WrkNextBatch As Integer

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
    myGLRBCH = New GLRBCH.MyData()
    myGLRBCH.MyDBConn = myDBConnect
    myBCHHDR.GetOneRecordP(MyBatch, 0)

    If WrkMode = "New" Then
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

      MyFrmGL403B.FormatGrid()
      MyFrmGL403B.Show()
      MsgBox("Batch " & WrkNextBatch & " has been created", MsgBoxStyle.Information, "New Batch")
    Else
      myBCHHDR.GetOneRecordP(MyBatch, WrkBatchNo)
      If Not myBCHHDR.RecordNotFound Then
        With myBCHHDR
          ._PSDT = MyUtils.SetDBDate(DtPckPost.Value)
          .UpdateOneRecordP()
        End With
      End If
      MyFrmGL403B.FormatGrid()
      MyFrmGL403B.Show()
    End If
    Me.Close()
  End Sub
  Private Sub FrmGL403B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmGL403.SbpScreen.Text = "GL403B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

  Private Sub FrmGL403B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmGL403
      .TBarCreate.Enabled = True
      .TBarChange.Enabled = True
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
  End Sub

  Private Sub FrmGL403_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    With MyFrmGL403
      .TBarCreate.Enabled = False
      .TBarChange.Enabled = False
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
      DtPckPost.Value = Date.Today
    End With
    If WrkMode = "Change" Then
      Me.Text = "Change Batch Date"
      BtnCreate.Text = "Save"
    Else
    End If
  End Sub

End Class