Public Class FrmTAP01DSP2
  Dim MyTXDCDSP As TXDCDSP.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer

Private Sub FrmTAP01DSP2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01DSP.FormatGrid()
    MyFrmTAP01DSP.Show()
End Sub
Private Sub FrmTAP01DSP2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCDSP = New TXDCDSP.mydata(MyDBConnect)

    With MyFrmTAP01
      .TbForms.Visible = False
      .TBarNew.Enabled = False
      If WrkSeqNo > 0 Then
        .TBarDelete.Enabled = True
      End If
      .TBarSave.Enabled = True
    End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    MyTXDCDSP.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCDSP.RecordNotFound Then
      DtPckRem.Value = Date.Today
      DtPckAcq.Value = Date.Today
      Exit Sub
    End If

    With MyTXDCDSP
      DtPckRem.Value = MyUtils.GetDBDate(._DSPDT)
      TxtCode.Text = Trim(._CODE)
      TxtLtr.Text = Trim(._LTR)
      TxtDesc.Text = Trim(._DESC)
      If ._ACQDT > 0 Then
        DtPckAcq.Value = MyUtils.GetDBDate(._ACQDT)
      End If
      TxtAcqCst.Text = ._ACQCST
    End With

End Sub
  Private Sub FrmTAP01DSP2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01DSP2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCDSP.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCDSP.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCDSP.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCDSP.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCDSP.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCDSP.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCDSP
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._DSPDT = MyUtils.SetDBDate(DtPckRem.Value)
        ._CODE = MyUtils.CnvSng(TxtCode.Text)
        ._LTR = TxtLtr.Text
        ._DESC = TxtDesc.Text
        ._ACQDT = MyUtils.SetDBDate(DtPckAcq.Value)
        ._ACQCST = MyUtils.CnvSng(TxtAcqCst.Text)
      End With
   End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub

Private Sub LnkCode_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkYear = WrkYear
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode.Text)
    MyFrmListCodes.WrkLtr = TxtLtr.Text
    MyFrmListCodes.WrkScreen = "DSP"
    MyFrmListCodes.Show()
End Sub

Private Sub TxtAcqCst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAcqCst.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





