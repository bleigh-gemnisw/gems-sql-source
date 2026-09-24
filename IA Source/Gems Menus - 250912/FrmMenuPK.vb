Public Class FrmMenuPK

Private Sub FrmMenuPK_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuPK"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuPK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  AddHandler BtnPK100.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK110.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK111.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK112.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK120.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK200.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK220.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPK230.MouseDown, AddressOf DoMouseDown
End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Private Sub FrmMenuPK_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Private Sub FrmMenuPK_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "PK"
  Else
    Me.Text = ""
  End If
End Sub
Private Sub FrmMenuPK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
End Class