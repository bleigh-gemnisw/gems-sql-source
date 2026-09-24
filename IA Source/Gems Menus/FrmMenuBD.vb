Public Class FrmMenuBD

Private Sub FrmMenuBD_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuBD"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuBD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  If MySecGroup = "Public" Then
    AddHandler BtnBD001.MouseDown, AddressOf DoBD001Pub
    BtnBD100.Visible = False
    BtnBD101.Visible = False
    BtnBD102.Visible = False
    BtnBD103.Visible = False
    BtnBD104.Visible = False
    BtnBD200.Visible = False
    BtnBD201.Visible = False
    BtnBD202.Visible = False
  Else
    AddHandler BtnBD001.MouseDown, AddressOf DoMouseDown
  End If
  AddHandler BtnBD100.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD101.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD102.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD103.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD104.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD200.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD201.MouseDown, AddressOf DoMouseDown
  AddHandler BtnBD202.MouseDown, AddressOf DoMouseDown
End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Private Sub FrmMenuBD_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Public Sub DoBD001Pub(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  If e.Clicks = 1 Then
    LaunchEXE("BD001", "public")
  End If
  End Sub
Private Sub FrmMenuBD_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "BD"
  Else
    Me.Text = ""
  End If
End Sub
Private Sub FrmMenuBD_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
End Class