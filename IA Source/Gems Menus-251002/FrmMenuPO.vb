Public Class FrmMenuPO

Private Sub FrmMenuPO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MenuPO"
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub
Private Sub FrmMenuPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  AddHandler BtnPO101.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO103.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO104.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO105.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO201.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO201app.MouseDown, AddressOf DoPO201app
  AddHandler BtnPO301.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO303.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO306.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO310.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO320.MouseDown, AddressOf DoMouseDown
  AddHandler BtnPO330.MouseDown, AddressOf DoMouseDown
End Sub
Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  'Handles all button Mouse Clicks on form
  If e.Clicks = 1 Then
    LaunchEXE(Me.ActiveControl.Name)
  End If
End Sub
Public Sub DoPO201app(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
  If e.Clicks = 1 Then
    LaunchEXE("PO201", "approve")
  End If
End Sub
Private Sub FrmMenuPO_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  MyFrmMenu.Show()
End Sub
Private Sub FrmMenuPO_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
  If Me.WindowState = FormWindowState.Minimized Then
    Me.Text = "PO"
  Else
    Me.Text = ""
  End If
End Sub
Private Sub FrmMenuPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
  If Not e.Alt Then Exit Sub
  If e.KeyCode = Keys.F12 Then
    MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub

Private Sub BtnPO201app_Click(sender As Object, e As EventArgs) Handles BtnPO201app.Click

End Sub
End Class