Public Class FrmTAP01LOR2
  Dim MyTXDCLOR As TXDCLOR.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer

Private Sub FrmTAP01LOR2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP01
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
    End With
    MyFrmTAP01LOR.FormatGrid()
    MyFrmTAP01LOR.Show()
End Sub
Private Sub FrmTAP01LOR2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDCLOR = New TXDCLOR.mydata(MyDBConnect)

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
    MyTXDCLOR.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDCLOR.RecordNotFound Then Exit Sub

    With MyTXDCLOR
      TxtName.Text = Trim(._NAME)
      TxtAddr.Text = Trim(._ADDR)
      TxtPhyLoc.Text = Trim(._PHYLOC)
      TxtDesc.Text = Trim(._DESC)
      If ._MFG = "Y" Then
        ChkMfg.Checked = True
      End If
      If ._ACQDT > 0 Then
        DtPckAcq.Value = MyUtils.GetDBDate(._ACQDT)
        DtPckAcq.Checked = True
      Else
        DtPckAcq.Value = Date.Today
        DtPckAcq.Checked = False
      End If
      TxtPrice.Text = ._PRICE
      If ._PURCH = "Y" Then
        ChkPurch.Checked = True
      End If
      TxtPurFrm.Text = Trim(._PURFRM)
      If ._PURDT > 0 Then
        DtPckPur.Value = MyUtils.GetDBDate(._PURDT)
        DtPckPur.Checked = True
      Else
        DtPckPur.Value = Date.Today
        DtPckPur.Checked = False
      End If
      TxtTran.Text = Trim(._TRAN)
      Select Case Trim(._LESTYP)
      Case "O"
        RbTypeOperating.Checked = True
      Case "C"
        RbTypeCapital.Checked = True
      Case "S"
        RbTypeConditional.Checked = True
      End Select
      TxtTerm.Text = Trim(._TERM)
      TxtRent.Text = ._RENT
      TxtCosts.Text = ._COSTS
      If ._NEWMFG = "Y" Then
        ChkNewMfg.Checked = True
      End If
      Select Case Trim(._NEWTYP)
      Case "R"
        RbLessor.Checked = True
      Case "E"
        RbLessee.Checked = True
      End Select
    End With

End Sub
  Private Sub FrmTAP01LOR2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP01.SbpScreen.Text = "TAP01LOR2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXDCLOR.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDCLOR.AutoGenKey(WrkListNo, WrkYear)
    End If
    MyTXDCLOR.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDCLOR.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCLOR.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXDCLOR.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDCLOR
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._NAME = TxtName.Text
        ._ADDR = TxtAddr.Text
        ._PHYLOC = TxtPhyLoc.Text
        ._DESC = TxtDesc.Text
        If ChkMfg.Checked Then
          ._MFG = "Y"
        Else
          ._MFG = "N"
        End If
        If DtPckAcq.Checked Then
          ._ACQDT = MyUtils.SetDBDate(DtPckAcq.Value)
        Else
          ._ACQDT = 0
        End If
        ._PRICE = MyUtils.CnvSng(TxtPrice.Text)
        If ChkPurch.Checked Then
          ._PURCH = "Y"
        Else
          ._PURCH = "N"
        End If
        ._PURFRM = TxtPurFrm.Text
        If DtPckPur.Checked Then
          ._PURDT = MyUtils.SetDBDate(DtPckPur.Value)
        Else
          ._PURDT = 0
        End If
        ._TRAN = TxtTran.Text
        If RbTypeCapital.Checked Then ._LESTYP = "C"
        If RbTypeOperating.Checked Then ._LESTYP = "O"
        If RbTypeConditional.Checked Then ._LESTYP = "C"
        If RbTypeUnknown.Checked Then ._LESTYP = ""
        ._TERM = TxtTerm.Text
        ._RENT = MyUtils.CnvSng(TxtRent.Text)
        ._COSTS = MyUtils.CnvSng(TxtCosts.Text)
        ._TERM = TxtTerm.Text
        ._RENT = MyUtils.CnvSng(TxtRent.Text)
        ._COSTS = MyUtils.CnvSng(TxtCosts.Text)
        If ChkNewMfg.Checked Then
          ._NEWMFG = "Y"
        Else
          ._NEWMFG = "N"
        End If
        If RbLessor.Checked Then ._NEWTYP = "R"
        If RbLessee.Checked Then ._NEWTYP = "E"
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

Private Sub TxtPrice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPrice.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtRent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtRent.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtCosts_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCosts.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub TxtPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrice.TextChanged

End Sub
End Class





