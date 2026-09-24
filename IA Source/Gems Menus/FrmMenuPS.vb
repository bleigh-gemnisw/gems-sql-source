Public Class FrmMenuPS

Private Sub FrmMenuPS_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuPS"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  AddHandler BtnPS001.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPS002.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPS003.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPS004.MouseDown, AddressOf DoMouseDown
End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Private Sub FrmMenuPS_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Private Sub FrmMenuPS_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "PS"
  Else
    Me.Text = ""
  End If
End Sub
Private Sub FrmMenuPS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub

Private Sub btnap103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub
End Class