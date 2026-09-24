Public Class FrmMenuAR

Private Sub FrmMenuAR_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuAR"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuAR_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  AddHandler BtnAR101.MouseDown, AddressOf DoMouseDown
End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Private Sub FrmMenuAR_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Private Sub FrmMenuAR_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "AR"
  Else
    Me.Text = ""
  End If
End Sub
Private Sub FrmMenuAR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
End Class