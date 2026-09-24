Public Class FrmCalcIncr
Friend WrkListNo As Integer
Private Sub TxtNGross_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNGross.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub

Private Sub TxtNGross_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNGross.TextChanged
  CalcIncrease()
End Sub
Private Sub CalcIncrease()
  Dim WrkAmount As Integer

  WrkAmount = MyUtils.CnvSng(TxtNGross.Text) - MyUtils.CnvSng(LblGross.Text)
  LblAmount.Text = WrkAmount
End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(LblAmount.Text) <= 0 Then
      ErrorField(I) = "amount"
      ErrorMsg(I) = "Amount must be greater than 0"
      I = I + 1
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblAmount, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "amount"
        ErrProv.SetError(LblAmount, ErrorMsg(I))
      Case ""
        Exit Sub
      End Select
    Next I
  End Sub

Private Sub BtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOK.Click
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  EditChecks(ErrorField, ErrorMsg)
  If IsNothing(ErrorMsg(0)) Then
    MyFrmTAE01C.TxtAmount.Text = LblAmount.Text
    Me.Close()
  Else
    ShowError(ErrorField, ErrorMsg)
  End If
End Sub
Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
  Me.Close()
End Sub
  Private Sub FrmCalcIncr_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  Dim myTXREALC As TXREALC.myData
  Dim WrkGross As Decimal

  myTXREALC = New TXREALC.mydata(MyDBConnect)
  myTXREALC.GetOneRecordP(WrkListNo)
  If myTXREALC._CCNO > 0 Then
    WrkGross = myTXREALC._CCGRS
  Else
    WrkGross = myTXREALC._GROSS + myTXREALC._BTR
  End If
  LblGross.Text = WrkGross
  If MyUtils.CnvSng(MyFrmTAE01C.TxtAmount.Text) > 0 Then
    TxtNGross.Text = MyUtils.CnvSng(MyFrmTAE01C.TxtAmount.Text) + WrkGross
    CalcIncrease()
  End If
End Sub
End Class





