Public Class FrmGLA02B_New
Dim myBCHHDR As BCHHDR.myData
Dim myTAXBCH As TAXBCH.myData

Private Sub BtnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCreate.Click
  Dim PassSecurity As Boolean
  Dim WrkNextBatch As Integer

  PassSecurity = GetFNDSEC(MyUtils.CnvSng(TxtFund.Text))
  If Not PassSecurity Then Exit Sub
  myBCHHDR = New BCHHDR.MyData()
  myBCHHDR.MyDBConn = myDBConnect
  myTAXBCH = New TAXBCH.MyData()
  myTAXBCH.MyDBConn = myDBConnect
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
      ._SUBST = ""
      ._PSDT = MyUtils.SetDBDate(Date.Today)
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

  With myTAXBCH
    .GetOneRecordP(WrkNextBatch, WrkNextBatch, 0)
    ._BCHNO = WrkNextBatch
    ._TRNBR = WrkNextBatch
    ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
    ._SFUND = 0
    ._DPNBR = 0
    ._OBNBR = 0
    ._FNPGM = 0
    ._SUBFN = 0
    ._DESCR = TxtDescr.Text
    ._AMT = 0
    ._AMTTYP = String.Empty
    ._GLTYP = String.Empty
    ._JACT8 = MyUtils.SetDBDate(DtPckPost.Value)
    ._JENT8 = MyUtils.SetDBDate(DtPckPost.Value)
    ._JRNSEQ = 0
    ._REFNO = 0
    ._SRCDE = 6
    ._TOTCR = 0
    ._TOTDR = 0
    ._TRNTYP = "X"
    .AddOneRecordP()
  End With

  MyFrmGLA02B.FormatGrid()
  MyFrmGLA02B.Show()
  Me.Close()
  MsgBox("Batch " & WrkNextBatch & " has been created", MsgBoxStyle.Information, "New Batch")

End Sub
  Private Sub FrmGLA02B_New_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
     MyFrmGLA02.SbpScreen.Text = "GLA02B_New"
     MyUtils.CenterForm(Me.ParentForm, Me)
 End Sub

 Private Sub FrmGLA02B_New_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
  With MyFrmGLA02
   .TBarCreate.Enabled = True
   .TBarImport.Enabled = True
   .TBarNew.Enabled = True
   .TBarDelete.Enabled = True
   .TBarPrtEdits.Enabled = True
   .TBarPost.Enabled = True
  End With
End Sub

Private Sub FrmGLA02_New_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  With MyFrmGLA02
   .TBarCreate.Enabled = False
   .TBarImport.Enabled = False
   .TBarNew.Enabled = False
   .TBarDelete.Enabled = False
   .TBarPrtEdits.Enabled = False
   .TBarPost.Enabled = False
  End With
   DtPckPost.Value = Date.Today
End Sub

Private Sub LnkGLFund_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkGLFund.LinkClicked
  MyFrmListFund = New FrmListFund
  MyFrmListFund.MdiParent = Me.ParentForm
  MyFrmListFund.WrkFund = MyUtils.CnvSng(TxtFund.Text)
  MyFrmListFund.Show()
End Sub
End Class