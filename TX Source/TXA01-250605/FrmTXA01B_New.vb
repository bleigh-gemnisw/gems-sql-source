Public Class FrmTXA01B_New
Dim myBCHHDR As BCHHDR.myData

  Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
    Dim WrkNextBatch As Integer

    myBCHHDR = New BCHHDR.MyData()
    myBCHHDR.MyDBConn = myDBConnect
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
        ._STATS = "S"
        ._STRDT = MyUtils.SetDBDate(DtPckInterest.Value)
        Select Case CboBatch.SelectedItem.ToString
          Case "Bank Service"
            ._SUBST = "K"
          Case "Escrow"
            ._SUBST = "E"
          Case "Leasing"
            ._SUBST = "G"
          Case "Lock Box"
            ._SUBST = "B"
          Case "Misc/Penny Batch"
            ._SUBST = "M"
          Case "Web Payment"
            ._SUBST = "W"
        End Select
        ._PSDT = MyUtils.SetDBDate(DtPckReceipt.Value)
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

    MyFrmTXA01B.FormatGrid()
    MyFrmTXA01B.Show()
    MsgBox("Batch " & WrkNextBatch & " has been created", MsgBoxStyle.Information, "New Batch")
    Me.Close()

  End Sub
  Private Sub FrmTXA01B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    MyFrmTXA01.SbpScreen.Text = "TXA01B_New"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmTXA01_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    With MyFrmTXA01
      .TBarNew.Enabled = False
      .TBarDelete.Enabled = False
      .TBarPrtEdits.Enabled = False
      .TBarPost.Enabled = False
    End With
    DtPckReceipt.Value = Today.Date
    DtPckInterest.Value = Today.Date
    CboBatch.Items.Add("Bank Service")
    CboBatch.Items.Add("Escrow")
    CboBatch.Items.Add("Leasing")
    CboBatch.Items.Add("Lock Box")
    CboBatch.Items.Add("Misc/Penny Batch")
    CboBatch.Items.Add("Web Payment")
    CboBatch.SelectedItem = "Lock Box"
  End Sub
  Private Sub FrmTXA01_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
    With MyFrmTXA01
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = True
      .TBarPrtEdits.Enabled = True
      .TBarPost.Enabled = True
    End With
  End Sub
End Class
