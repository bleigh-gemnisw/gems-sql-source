Public Class FrmTX340B
Private Sub FrmTX340B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
  MyFrmTX340.SbpScreen.Text = "TX340B"
End Sub
Private Sub FrmTX340C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  DtPckDue.Value = Date.Today
  DtPckGrace.Value = Date.Today

  GetTXFMBILL("R")
  If Trim(myTXFMBILL._LINE1) = String.Empty Then
    GetTXFMBILL(" ")
  End If
  GetTXFMSTMT("R")
  If Trim(myTXFMSTMT._LINE1) = String.Empty Then
    GetTXFMSTMT(" ")
  End If

  GetReturnTo()
End Sub
Private Sub ClearForm()
  TxtAddr1.Text = ""
  TxtListNo.Text = ""
End Sub
Private Sub RbClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbClear.Click
  ClearForm()
End Sub
Private Sub GetReturnTo()
  If RbBill.Checked Then
    TxtPayTo.Text = Trim(myTXFMBILL._PAYTO)
    TxtLine1.Text = Trim(myTXFMBILL._LINE1)
    TxtLine2.Text = Trim(myTXFMBILL._LINE2)
    TxtLine3.Text = Trim(myTXFMBILL._LINE3)
    TxtLine4.Text = Trim(myTXFMBILL._LINE4)
    TxtLine5.Text = Trim(myTXFMBILL._LINE5)
  Else
    TxtPayTo.Text = Trim(myTXFMSTMT._PAYTO)
    TxtLine1.Text = Trim(myTXFMSTMT._LINE1)
    TxtLine2.Text = Trim(myTXFMSTMT._LINE2)
    TxtLine3.Text = Trim(myTXFMSTMT._LINE3)
    TxtLine4.Text = Trim(myTXFMSTMT._LINE4)
    TxtLine5.Text = Trim(myTXFMSTMT._LINE5)
  End If
End Sub

Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtGross_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGross.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtExam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtNet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNet.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtMillRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMillRate.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtTax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub TxtYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtYear.LostFocus
  GetMillRate(MyUtils.CnvSng(TxtYear.Text), "R", 0)
  With myTXMRATE
    If .RecordNotFound Then Exit Sub
    TxtMillRate.Text = Format(._MRRATE * 1000, "###.000")
  End With
End Sub
Private Sub RbBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbBill.Click
  GetReturnTo()
End Sub
Private Sub RbStmt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbStmt.Click
  GetReturnTo()
End Sub
End Class





