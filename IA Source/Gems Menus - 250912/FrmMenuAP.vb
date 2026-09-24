Public Class FrmMenuAP

  Private Sub FrmMenuAP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmMain.SbpScreen.Text = "MenuAP"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub FrmMenuAP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    AddHandler BtnAP101.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP103.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP201.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP202.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP230.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP231.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP304.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP305.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP307.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP311.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP312.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP313.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP401.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP403.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP404.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP502.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP504.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP510.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP530.MouseDown, AddressOf DoMouseDown
    'AddHandler BtnAP531.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP600.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP701.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP702.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP703.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP706.MouseDown, AddressOf DoMouseDown
    AddHandler BtnAP730.MouseDown, AddressOf DoMouseDown
  End Sub
  Public Sub DoMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    'Handles all button Mouse Clicks on form
    If e.Clicks = 1 Then
      LaunchEXE(Me.ActiveControl.Name)
    End If
  End Sub
  Private Sub FrmMenuAP_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmMenu.Show()
  End Sub
  Private Sub FrmMenuAP_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
    If Me.WindowState = FormWindowState.Minimized Then
      Me.Text = "AP"
    Else
      Me.Text = ""
    End If
  End Sub
  Private Sub FrmMenuAP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub
    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub

  Private Sub btnaplechk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub

  Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

  End Sub

  Private Sub tabAP_Click(sender As Object, e As EventArgs) Handles TpTables.Click

  End Sub

  Private Sub ListOpenPayablesToolStripMenuItem1_Click(sender As Object, e As EventArgs)

  End Sub

  Private Sub TpReports_Click(sender As Object, e As EventArgs) Handles TpReports.Click

  End Sub

  Private Sub Tp1099_Click(sender As Object, e As EventArgs) Handles Tp1099.Click

  End Sub

  Private Sub TpCheck_Click(sender As Object, e As EventArgs) Handles TpCheck.Click

  End Sub

  Private Sub TpRecon_Click(sender As Object, e As EventArgs) Handles TpRecon.Click

  End Sub
End Class