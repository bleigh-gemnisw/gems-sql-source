Public Class FrmUB102Payoff2

  Private Sub FrmUB102Payoff2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkPrincipal As Decimal
    Dim WrkInterest As Decimal
    Dim WrkBond As Decimal
    Dim WrkFees As Decimal
    Dim WrkLiens As Decimal
    Dim WrkAmtDue As Decimal

    With MyFrmUB102Payoff
      WrkPrincipal = MyUtils.CnvSng(.LblDelqBal.Text) + MyUtils.CnvSng(.LblAssmntLeft.Text) + MyUtils.CnvSng(.LblDeferAmt.Text)
      WrkInterest = MyUtils.CnvSng(.LblDelqInt.Text)
      WrkBond = MyUtils.CnvSng(.LblDelqBond.Text) + MyUtils.CnvSng(.LblBond.Text)
      WrkFees = MyUtils.CnvSng(.LblDelqFee.Text)
      WrkLiens = MyUtils.CnvSng(.LblLiens.Text) + MyUtils.CnvSng(.LblCaveat.Text)
      WrkAmtDue = MyUtils.CnvSng(.LblAmountDue.Text)

      LblListNo.Text = .LblListNo.Text
      LblAddr1.Text = .LblAddr1.Text
      LblPrincipal.Text = MyUtils.FmtCurrency(WrkPrincipal)
      LblInterest.Text = MyUtils.FmtCurrency(WrkInterest)
      LblBond.Text = MyUtils.FmtCurrency(WrkBond)
      LblFee.Text = MyUtils.FmtCurrency(WrkFees)
      LblLiens.Text = MyUtils.FmtCurrency(WrkLiens)
      LblAmtDue.Text = MyUtils.FmtCurrency(WrkAmtDue)
    End With
  End Sub
  Private Sub FrmUB102Payoff2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmUB102.SbpScreen.Text = "UB102Payoff2"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmUB102Payoff_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmUB102Payoff.Show()
    'Memory Cleanup
    MyFrmUB102Payoff2 = Nothing
  End Sub
End Class