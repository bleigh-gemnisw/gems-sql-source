Public Class FrmTAP01LEE2
  Dim MyTXDCLEE As TXDCLEE.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer

Private Sub FrmTAP01LEE2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01LEE.FormatGrid()
    MyFrmTAP01LEE.Show()
End Sub
Private Sub FrmTAP01LEE2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCLEE = New TXDCLEE.mydata(MyDBConnect)

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
    MyTXDCLEE.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCLEE.RecordNotFound Then Exit Sub

    With MyTXDCLEE
      TxtName.Text = Trim(._NAME)
      TxtAddr.Text = Trim(._ADDR)
      TxtLesNo.Text = Trim(._LESNO)
      TxtDesc.Text = Trim(._DESC)
      TxtSerial.Text = Trim(._SERIAL)
      TxtYrMfg.Text = ._YRMFG
      If ._CAPLES = "Y" Then
        ChkCapLes.Checked = True
      End If
      TxtTerm.Text = Trim(._TERM)
      TxtRent.Text = ._RENT
      TxtCost.Text = ._COST
      TxtYrInc.Text = ._YRINC
      If ._DSPITM = "Y" Then
        ChkDspItm.Checked = True
      End If
      If ._ACQITM = "Y" Then
        ChkAcqItm.Checked = True
      End If
    End With

End Sub
  Private Sub FrmTAP01LEE2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01LEE2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCLEE.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCLEE.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCLEE.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCLEE.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCLEE.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCLEE.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCLEE
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._NAME = TxtName.Text
        ._ADDR = TxtAddr.Text
        ._LESNO = TxtLesNo.Text
        ._DESC = TxtDesc.Text
        ._SERIAL = TxtSerial.Text
        ._YRMFG = MyUtils.CnvSng(TxtYrMfg.Text)
        If ChkCapLes.Checked Then
          ._CAPLES = "Y"
        Else
          ._CAPLES = "N"
        End If
        ._TERM = TxtTerm.Text
        ._RENT = MyUtils.CnvSng(TxtRent.Text)
        ._COST = MyUtils.CnvSng(TxtCost.Text)
        ._YRINC = MyUtils.CnvSng(TxtYrInc.Text)
        If ChkDspItm.Checked Then
          ._DSPITM = "Y"
        Else
          ._DSPITM = "N"
        End If
        If ChkAcqItm.Checked Then
          ._ACQITM = "Y"
        Else
          ._ACQITM = "N"
        End If
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

Private Sub TxtRent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRent.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCost.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtYrInc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYrInc.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtYrMfg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYrMfg.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class





