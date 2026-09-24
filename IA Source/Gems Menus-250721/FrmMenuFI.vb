Public Class FrmMenuFI

Private Sub FrmMenuFI_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuFI"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuFI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  AddHandler BtnAP101inq.MouseDown, AddressOf DoAP101inq
  AddHandler BtnAP602.MouseDown, AddressOf DoMouseDown
  AddHandler BtnGL107inq.MouseDown, AddressOf DoGL107inq
  AddHandler BtnPO306inq.MouseDown, AddressOf DoPO306inq

End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Public Sub DoAP101inq(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  If e.Clicks = 1 Then
    LaunchEXE("AP101", "inquiry")
  End If
End Sub
Public Sub DoGL107inq(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  If e.Clicks = 1 Then
    LaunchEXE("GL107", "inquiry")
  End If
End Sub
Public Sub DoPO306inq(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  If e.Clicks = 1 Then
    LaunchEXE("PO306", "inquiry")
  End If
End Sub
Private Sub FrmMenuFI_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Private Sub FrmMenuFI_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "FI"
  Else
    Me.Text = ""
  End If
End Sub
Private Sub FrmMenuFA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub

Private Sub BtnGL107_Click(sender As Object, e As EventArgs) Handles BtnGL107inq.Click

End Sub
End Class