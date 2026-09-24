Public Class Form1
  Public myDBConnect As SQLConnect.DBConnection
  Public MyDBName As String
  Dim MyCASHINT As CASHINT
  Public Sub New()
    InitializeComponent()
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    TxtDBName.Text = "gemskens"
    TxtList.Text = "801297"
    TxtType.Text = "S"
    TxtYear.Text = "2025"
  End Sub

  Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles BtnCheck.Click
    Dim Good As Boolean
    MyDBName = TxtDBName.Text
    Good = Connect()

    MyCASHINT = New CASHINT(myDBConnect)
    With MyCASHINT
      .In_IntDate = DtPckInt.Value
      .In_ListNo = TxtList.Text
      .In_Type = TxtType.Text
      .In_Year = TxtYear.Text
      '.CalcInterest()
      .CalcInterest_219SW()
      LblInterest.Text = Format(.Out_Int(), "standard")
      LblLien.Text = Format(.Out_Lien(), "standard")
      LblFee.Text = Format(.Out_Fee(), "standard")
      LblBond.Text = Format(.Out_Bond(), "standard")
      LblTax.Text = Format(.Out_Prin(), "standard")
      LblDue.Text = Format(.Out_Tot(), "standard")
    End With
  End Sub
  Public Function Connect() As Boolean
    Dim Good As Boolean

    myDBConnect = New SQLConnect.DBConnection(MyDBName)
    myDBConnect.Open()
    Good = myDBConnect.IsConnected
    If Not Good Then
      MsgBox("Invalid database name", MsgBoxStyle.Critical, "Check database name")
    End If
    Return Good
  End Function
End Class

