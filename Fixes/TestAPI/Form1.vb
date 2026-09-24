Public Class Form1

  Public Sub New()
    InitializeComponent()
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    TxtTownNo.Text = "004"
    TxtAcctID.Text = "21M1904350"
    LblAmount.Text = ""
    LblName.Text = ""
    LblAddr.Text = ""
  End Sub

  Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
    Dim WrkTran As Transaction
    WrkTran = GetApiTran(TxtTownNo.Text, TxtAcctID.Text)
    LblAmount.Text = WrkTran.Amount
    LblName.Text = WrkTran.Owner_Name
    LblAddr.Text = WrkTran.Property_Full_Address
  End Sub
End Class

