Public Class FrmMenuGL

  Private Sub FrmMenuGL_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "MenuGL"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmMenuGL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler BtnGL101.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL102.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL103.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL104.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL105.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL107.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL114.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL205.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL208.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL212.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL213.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL214.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL216.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL220.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL244.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL401.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL402.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL403.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL501.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL502.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL503.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL505.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL506.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL509.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL510.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL530.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL531.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL600.MouseDown, AddressOf DoMouseDown
    AddHandler btngl650.MouseDown, AddressOf DoMouseDown
    AddHandler btngl651.MouseDown, AddressOf DoMouseDown
    AddHandler btngl652.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL660.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL661.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL701.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL703.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL704.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL730.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL801.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGL802.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA01.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA02.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA31.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA32.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA33.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA34.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA35.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA36.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA37.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA40.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA41.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA42.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA43.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA44.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA45.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA46.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA47.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA48.MouseDown, AddressOf DoMouseDown
    AddHandler BtnGLA51.MouseDown, AddressOf DoMouseDown

    If Not MyTXGL Then
      tab.TabPages.Remove(TpInterface)
    End If
  End Sub
  Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'Handles all button Mouse Clicks on form
    If e.Clicks = 1 Then
      LaunchEXE(Me.ActiveControl.Name)
    End If
  End Sub
  Private Sub FrmMenuGL_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmMenu.Show()
  End Sub
  Private Sub FrmMenuGL_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
    If Me.WindowState = FormWindowState.Minimized Then
      Me.Text = "GL"
    Else
      Me.Text = ""
    End If
  End Sub
  Private Sub FrmMenuGL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub

  Private Sub TpReports_Click(sender As Object, e As EventArgs) Handles TpReports.Click

  End Sub

  Private Sub BtnGL506t_Click(sender As Object, e As EventArgs) Handles BtnGL506t.Click
    LaunchEXE("GL506")
  End Sub
End Class