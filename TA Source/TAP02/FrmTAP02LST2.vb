Public Class FrmTAP02LST2
  Dim MyTXDMLST As TXDMLST.myData
  Dim ds As DataSet = New DataSet
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkSeqNo As Integer

Private Sub FrmTAP02LST2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    With MyFrmTAP02
      .TbForms.Visible = True
      .TBarNew.Enabled = True
      .TBarDelete.Enabled = False
      .TBarSave.Enabled = False
			.TBarPrint.Enabled = True
		End With
		MyFrmTAP02LST.FormatGrid(False)
    MyFrmTAP02LST.Show()
End Sub
Private Sub FrmTAP02LST2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXDMLST = New TXDMLST.mydata(MyDBConnect)

    With MyFrmTAP02
      .TbForms.Visible = False
      .TBarNew.Enabled = False
      If WrkSeqNo > 0 Then
        .TBarDelete.Enabled = True
      End If
      .TBarSave.Enabled = True
			.TBarPrint.Enabled = False
		End With

    LblListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    MyTXDMLST.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If MyTXDMLST.RecordNotFound Then
      DtPckAcq.Value = Date.Today
      DtPckIns.Value = Date.Today
      CalcGLYear()
      Exit Sub
    End If

    SetLeaseTip()
    With MyTXDMLST
      TxtPrDesc.Text = Trim(._PRDESC)
      TxtPrMod.Text = Trim(._PRMOD)
      TxtQty.Text = ._QTY
      If ._ACQDT > 0 Then
        DtPckAcq.Value = MyUtils.GetDBDate(._ACQDT)
      End If
      If ._INSDT > 0 Then
        DtPckIns.Value = MyUtils.GetDBDate(._INSDT)
      End If
      TxtLease.Text = Trim(._LEASE)
      TxtIrsCls.Text = ._IRSCLS
      TxtPurch.Text = ._PURCH
      TxtTrans.Text = ._TRANS
      LblAcqCst.Text = ._ACQCST
      LblGLYear.Text = ._GLYEAR
    End With

End Sub
  Private Sub FrmTAP02LST2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAP02.SbpScreen.Text = "TAP02LST2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
		Dim WrkDiffCst As Integer
		Dim WrkDiffQty As Integer
		Dim WrkDeYear As Integer
		Dim Answer As Integer

    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
		WrkDiffCst = MyTXDMLST._ACQCST * -1
		WrkDiffQty = MyTXDMLST._QTY * -1
		MyTXDMLST.DeleteOneRecordP()
    WrkDeYear = WrkYear - MyUtils.CnvSng(LblGLYear.Text) + 1
    WriteTXDMSUM(WrkListNo, WrkYear, WrkDeYear, WrkDiffCst, WrkDiffQty)
    WriteTXDCSUM(WrkListNo, WrkYear, WrkDeYear, WrkDiffCst)
  End Sub
  Public Sub SaveData()
    Dim WrkDiffCst As Integer
    Dim WrkDiffQty As Integer
    Dim WrkDeYear As Integer
    Dim WrkPrevGLYear As Integer
    Dim WrkPrevDeYear As Integer
    Dim WrkPrevAcqCst As Integer
    Dim WrkPrevQty As Integer
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqNo = 0 Then
      WrkSeqNo = MyTXDMLST.AutoGenKey(WrkListNo, WrkYear)
    End If
    WrkDeYear = WrkYear - MyUtils.CnvSng(LblGLYear.Text) + 1
    SetLeaseTip()

    MyTXDMLST.GetOneRecordP(WrkListNo, WrkYear, WrkSeqNo)
    If Not MyTXDMLST.RecordNotFound Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiffCst = MyUtils.CnvSng(LblAcqCst.Text) - MyTXDMLST._ACQCST
        WrkDiffQty = MyUtils.CnvSng(TxtQty.Text) - MyTXDMLST._QTY
        WrkPrevGLYear = MyTXDMLST._GLYEAR
        WrkPrevAcqCst = MyTXDMLST._ACQCST * -1
        WrkPrevDeYear = WrkYear - WrkPrevGLYear + 1
        WrkPrevQty = MyTXDMLST._QTY * -1
        MoveToFile()
        MyTXDMLST.UpdateOneRecordP()
        If WrkPrevGLYear = MyTXDMLST._GLYEAR Then
          WriteTXDMSUM(WrkListNo, WrkYear, WrkDeYear, WrkDiffCst, WrkDiffQty)
        Else
          WriteTXDMSUM(WrkListNo, WrkYear, WrkPrevDeYear, WrkPrevAcqCst, WrkPrevQty)
          WriteTXDMSUM(WrkListNo, WrkYear, WrkDeYear, MyUtils.CnvSng(LblAcqCst.Text), MyUtils.CnvSng(TxtQty.Text))
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        WrkDiffCst = MyUtils.CnvSng(LblAcqCst.Text)
        WrkDiffQty = MyUtils.CnvSng(TxtQty.Text)
        MoveToFile()
        MyTXDMLST.AddOneRecordP()
        WriteTXDMSUM(WrkListNo, WrkYear, WrkDeYear, WrkDiffCst, WrkDiffQty)
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    WriteTXDCSUM(WrkListNo, WrkYear, WrkDeYear, WrkDiffCst)
    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With MyTXDMLST
        ._LISTNO = WrkListNo
        ._YEAR = WrkYear
        ._SEQNO = WrkSeqNo
        ._PRDESC = TxtPrDesc.Text
        ._PRMOD = TxtPrMod.Text
        ._QTY = MyUtils.CnvSng(TxtQty.Text)
        ._ACQDT = MyUtils.SetDBDate(DtPckAcq.Value)
        ._INSDT = MyUtils.SetDBDate(DtPckIns.Value)
        ._GLYEAR = MyUtils.CnvSng(LblGLYear.Text)
        ._LEASE = TxtLease.Text
        ._IRSCLS = MyUtils.CnvSng(TxtIrsCls.Text)
        ._PURCH = MyUtils.CnvSng(TxtPurch.Text)
        ._TRANS = MyUtils.CnvSng(TxtTrans.Text)
        ._ACQCST = MyUtils.CnvSng(LblAcqCst.Text)
      End With
   End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkTip As String
    Dim WrkDate As Date
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtQty.Text) = 0 Then
      ErrorField(I) = "qty"
      ErrorMsg(I) = "Qty cannot be 0"
      I = I + 1
    End If

    If TxtPrDesc.Text = String.Empty Then
      ErrorField(I) = "prdesc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

    If TxtLease.Text <> String.Empty Then
      WrkTip = Ttp1.GetToolTip(TxtLease)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "lease"
        ErrorMsg(I) = "Invalid Lease ID"
        I = I + 1
      End If
    End If

    If DtPckAcq.Value > DtPckIns.Value Then
      ErrorField(I) = "acqdt"
      ErrorMsg(I) = "Date Acquired cannot be before Date Installed"
      I = I + 1
    End If

    WrkDate = "#10/1/" & WrkYear & "#"
    If DtPckIns.Value > WrkDate Then
      ErrorField(I) = "insdt"
      ErrorMsg(I) = "Date Installed cannot be after 10/1/" & WrkYear
      I = I + 1
    End If

    If MyUtils.CnvSng(LblAcqCst.Text) = 0 Then
      ErrorField(I) = "acqcst"
      ErrorMsg(I) = "Total Cost cannot be 0"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtQty, "")
    ErrProv.SetError(TxtPrDesc, "")
    ErrProv.SetError(TxtLease, "")
    ErrProv.SetError(DtPckAcq, "")
    ErrProv.SetError(DtPckIns, "")
    ErrProv.SetError(LblAcqCst, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "qty"
        ErrProv.SetError(TxtQty, ErrorMsg(I))
      Case "prdesc"
        ErrProv.SetError(TxtPrDesc, ErrorMsg(I))
      Case "acqdt"
        ErrProv.SetError(DtPckAcq, ErrorMsg(I))
      Case "insdt"
        ErrProv.SetError(DtPckIns, ErrorMsg(I))
      Case "lease"
        ErrProv.SetError(TxtLease, ErrorMsg(I))
      Case "acqcst"
        ErrProv.SetError(LblAcqCst, ErrorMsg(I))
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub
Private Sub TxtPurch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPurch.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtTrans_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTrans.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPurch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPurch.KeyUp
  CalcCost()
End Sub
Private Sub TxtTrans_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTrans.KeyUp
  CalcCost()
End Sub
Private Sub CalcCost()
  LblAcqCst.Text = MyUtils.CnvSng(TxtPurch.Text) + MyUtils.CnvSng(TxtTrans.Text)
End Sub
Private Sub TxtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQty.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtIrsCls_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtIrsCls.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub DtPckIns_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckIns.ValueChanged
  CalcGLYear()
End Sub
Private Sub CalcGLYear()
  Dim WrkGLYear As Integer

  Select Case DtPckIns.Value.Month
  Case Is < 10
		WrkGLYear = WrkYear - (WrkYear - DtPckIns.Value.Year)
  Case Is > 10
		WrkGLYear = WrkYear - (WrkYear - DtPckIns.Value.Year) + 1
  Case 10
    If DtPckIns.Value.Day = 1 Then
			WrkGLYear = WrkYear - (WrkYear - DtPckIns.Value.Year)
    Else
			WrkGLYear = WrkYear - (WrkYear - DtPckIns.Value.Year) + 1
    End If
  End Select

	LblGLYear.Text = WrkGLYear
End Sub

Private Sub LnkLease_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkLease.LinkClicked
    MyFrmListLease = New FrmListLease
    MyFrmListLease.MdiParent = Me.ParentForm
    MyFrmListLease.WrkCode = TxtLease.Text
    MyFrmListLease.Show()
End Sub
Private Sub SetLeaseTip()
    Dim WrkDesc As String

    If Not TxtLease.Modified Or TxtLease.Text = String.Empty Then Exit Sub

    WrkDesc = GetTXDMLESName(TxtLease.Text)
    Ttp1.SetToolTip(TxtLease, WrkDesc)
End Sub

End Class





