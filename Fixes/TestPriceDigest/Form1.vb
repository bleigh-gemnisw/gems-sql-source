Public Class Form1
  Dim myPriceDigestSpecs As PriceDigestAPI.ApiSpecs
  Dim myPriceDigestVIN As PriceDigestAPI.ApiVIN
  Dim myPriceDigestValue As PriceDigestAPI.ApiValue
  Public Sub New()
    InitializeComponent()
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    TxtVIN.Text = "5PVNJ8JV8J4S69840"
  End Sub

  Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
    myPriceDigestSpecs = New PriceDigestAPI.ApiSpecs
    myPriceDigestVIN = New PriceDigestAPI.ApiVIN
    myPriceDigestValue = New PriceDigestAPI.ApiValue
    With myPriceDigestVIN
      .GetApiVIN(TxtVIN.Text)
      If .IsError Then
        LblMfgName.Text = "** Error **"
        Exit Sub
      End If
      LblMfgName.Text = .manufacturerName
      LblCatName.Text = .categoryName
      LblClassification.Text = .classificationName
      LblSubType.Text = .subtypeName
    End With
    With myPriceDigestValue
      .GetApiValue(myPriceDigestVIN.configurationId)
      LblMSRP.Text = .MSRP
      LblClassMin.Text = .sizeClassMin
      LblClassMax.Text = .sizeClassMax
      LblRetail.Text = .unadjustedRetail
      LblWholesale.Text = .unadjustedWholesale
      LblTradeIn.Text = .unadjustedTradeIn
    End With
    With myPriceDigestSpecs
      .GetApiSpecs(myPriceDigestVIN.configurationId)
      LblComplete.Text = .Complete
    End With
  End Sub
End Class

