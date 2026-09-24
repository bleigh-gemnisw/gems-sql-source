Public Class FrmMenuFA

Private Sub FrmMenuFA_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuFA"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuFA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  AddHandler BtnFA001.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA002.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA003.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA004.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA005.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA006.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA007.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA008.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA009.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA010.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA011.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA012.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA020.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA100.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA101.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA102.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA103.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA104.MouseDown, AddressOf DoMouseDown
  AddHandler BtnFA200.MouseDown, AddressOf DoMouseDown

End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Private Sub FrmMenuFA_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Private Sub FrmMenuFA_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "FA"
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

Private Sub label10_Click(sender As Object, e As EventArgs)

End Sub
End Class