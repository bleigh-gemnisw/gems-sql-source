Public Class FrmTXA09Defer
	Dim myTXINV As TXINV.MyData
	Friend WrkListNo As Integer
	Friend WrkYear As Integer
	Friend WrkType As String
	Private Sub FrmTXA09Defer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		myTXINV = New TXINV.MyData(myDBConnect)

		LblTax2.Visible = MyFrmTXA09B.LblTax2.Visible
		LblTax3.Visible = MyFrmTXA09B.LblTax3.Visible
		LblTax4.Visible = MyFrmTXA09B.LblTax4.Visible
		LblDue2.Visible = MyFrmTXA09B.LblTax2.Visible
		LblDue3.Visible = MyFrmTXA09B.LblTax3.Visible
		LblDue4.Visible = MyFrmTXA09B.LblTax4.Visible
		LblDefer2.Visible = MyFrmTXA09B.LblTax2.Visible
		LblDefer3.Visible = MyFrmTXA09B.LblTax3.Visible
		LblDefer4.Visible = MyFrmTXA09B.LblTax4.Visible
		LblTax1Txt.Text = MyFrmTXA09B.LblTax1Txt.Text
		LblTax2Txt.Text = MyFrmTXA09B.LblTax2Txt.Text
		LblTax2Txt.Visible = MyFrmTXA09B.LblTax2Txt.Visible
		LblTax3Txt.Text = MyFrmTXA09B.LblTax3Txt.Text
		LblTax3Txt.Visible = MyFrmTXA09B.LblTax3Txt.Visible
		LblTax4Txt.Text = MyFrmTXA09B.LblTax4Txt.Text
		LblTax4Txt.Visible = MyFrmTXA09B.LblTax4Txt.Visible
		LblDue1Txt.Text = MyFrmTXA09B.LblTax1Txt.Text
		LblDue2Txt.Text = MyFrmTXA09B.LblTax2Txt.Text
		LblDue2Txt.Visible = MyFrmTXA09B.LblTax2Txt.Visible
		LblDue3Txt.Text = MyFrmTXA09B.LblTax3Txt.Text
		LblDue3Txt.Visible = MyFrmTXA09B.LblTax3Txt.Visible
		LblDue4Txt.Text = MyFrmTXA09B.LblTax4Txt.Text
		LblDue4Txt.Visible = MyFrmTXA09B.LblTax4Txt.Visible
		LblDefer2Txt.Visible = MyFrmTXA09B.LblTax2Txt.Visible
		LblDefer3Txt.Visible = MyFrmTXA09B.LblTax3Txt.Visible
		LblDefer4Txt.Visible = MyFrmTXA09B.LblTax4Txt.Visible
		LblList.Text = WrkListNo
		LblYear.Text = WrkYear
		LblType.Text = WrkType
		LblName.Text = MyFrmTXA09B.LblName.Text

		myTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
		With myTXINV
			'MK 9/29/25 Begin
			If ._CCNO = 0 Then
				'MK 9/29/25 End
				LblDueT.Text = Format(._TAXT - ._DEFERT, "standard")
				LblDue1.Text = Format(._TAX1 - ._DEFER1, "standard")
				LblDue2.Text = Format(._TAX2 - ._DEFER2, "standard")
				LblDue3.Text = Format(._TX3RD - ._DEFER3, "standard")
				LblDue4.Text = Format(._TX4TH - ._DEFER4, "standard")
				LblDeferT.Text = Format(._DEFERT, "standard")
				LblDefer1.Text = Format(._DEFER1, "standard")
				LblDefer2.Text = Format(._DEFER2, "standard")
				LblDefer3.Text = Format(._DEFER3, "standard")
				LblDefer4.Text = Format(._DEFER4, "standard")
				LblTaxt.Text = Format(._TAXT, "standard")
				LblTax1.Text = Format(._TAX1, "standard")
				LblTax2.Text = Format(._TAX2, "standard")
				LblTax3.Text = Format(._TX3RD, "standard")
				LblTax4.Text = Format(._TX4TH, "standard")
				LblTotpay.Text = MyFrmTXA09B.LblTotpay.Text
				LblRemain.Text = Format(._TAXT - MyUtils.CnvSng(LblTotpay.Text), "standard")
				LblDeferRemain.Text = Format(._TAXT - ._DEFERT - MyUtils.CnvSng(LblTotpay.Text), "standard")
				'MK 9/29/25 Begin
			Else
				GrpTax.Text = "C/C Amounts"
				LblDueT.Text = Format(._CCETAX + ._DEFERT, "standard")
				LblDue1.Text = Format(._CCTX1 + ._DEFER1, "standard")
				LblDue2.Text = Format(._CCTX2 + ._DEFER2, "standard")
				LblDue3.Text = Format(._CCTX3 + ._DEFER3, "standard")
				LblDue4.Text = Format(._CCTX4 + ._DEFER4, "standard")
				LblDeferT.Text = Format(._DEFERT, "standard")
				LblDefer1.Text = Format(._DEFER1, "standard")
				LblDefer2.Text = Format(._DEFER2, "standard")
				LblDefer3.Text = Format(._DEFER3, "standard")
				LblDefer4.Text = Format(._DEFER4, "standard")
				LblTaxt.Text = Format(._CCETAX, "standard")
				LblTax1.Text = Format(._CCTX1, "standard")
				LblTax2.Text = Format(._CCTX2, "standard")
				LblTax3.Text = Format(._CCTX3, "standard")
				LblTax4.Text = Format(._CCTX4, "standard")
				LblTotpay.Text = MyFrmTXA09B.LblTotpay.Text
				LblRemain.Text = Format(._CCETAX + ._DEFERT - MyUtils.CnvSng(LblTotpay.Text), "standard")
				LblDeferRemain.Text = Format(._CCETAX + ._DEFERT - MyUtils.CnvSng(LblTotpay.Text), "standard")
			End If
			'MK 9/29/25 End
		End With
	End Sub

	Private Sub FrmTXA09Defer_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		'    MyFrmTXA09B.TBarSave.Enabled = False
		myTXINV.CloseFile()
		myTXINV = Nothing
		MyFrmTXA09B.Show()

	End Sub
	Private Sub FrmTXA09Defer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
		MyFrmTXA09.SbpScreen.Text = "TXA09Defer"
		MyUtils.CenterForm(Me.ParentForm, Me)
	End Sub
End Class