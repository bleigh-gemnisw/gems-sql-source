Public Class FrmTXE48B
Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents RbFile As System.Windows.Forms.RadioButton
  Friend WithEvents RbFTP As System.Windows.Forms.RadioButton
  Friend WithEvents TxtHost As System.Windows.Forms.TextBox
  Friend WithEvents TxtUser As System.Windows.Forms.TextBox
  Friend WithEvents TxtPassword As System.Windows.Forms.TextBox

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.RbFile = New System.Windows.Forms.RadioButton()
    Me.RbFTP = New System.Windows.Forms.RadioButton()
    Me.TxtHost = New System.Windows.Forms.TextBox()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(60, 13)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Host Name"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 76)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "User Name"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 102)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "Password"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(147, 24)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(0, 13)
    Me.Label4.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(147, 24)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(0, 13)
    Me.Label5.TabIndex = 5
    '
    'RbFile
    '
    Me.RbFile.AutoSize = True
    Me.RbFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFile.Checked = True
    Me.RbFile.Location = New System.Drawing.Point(115, 22)
    Me.RbFile.Name = "RbFile"
    Me.RbFile.Size = New System.Drawing.Size(99, 17)
    Me.RbFile.TabIndex = 6
    Me.RbFile.TabStop = True
    Me.RbFile.Text = "Update TXDLQ"
    Me.RbFile.UseVisualStyleBackColor = True
    '
    'RbFTP
    '
    Me.RbFTP.AutoSize = True
    Me.RbFTP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbFTP.Location = New System.Drawing.Point(238, 22)
    Me.RbFTP.Name = "RbFTP"
    Me.RbFTP.Size = New System.Drawing.Size(45, 17)
    Me.RbFTP.TabIndex = 7
    Me.RbFTP.Text = "FTP"
    Me.RbFTP.UseVisualStyleBackColor = True
    '
    'TxtHost
    '
    Me.TxtHost.Location = New System.Drawing.Point(79, 47)
    Me.TxtHost.Name = "TxtHost"
    Me.TxtHost.Size = New System.Drawing.Size(371, 20)
    Me.TxtHost.TabIndex = 8
    '
    'TxtUser
    '
    Me.TxtUser.Location = New System.Drawing.Point(79, 73)
    Me.TxtUser.Name = "TxtUser"
    Me.TxtUser.Size = New System.Drawing.Size(135, 20)
    Me.TxtUser.TabIndex = 9
    '
    'TxtPassword
    '
    Me.TxtPassword.Location = New System.Drawing.Point(79, 99)
    Me.TxtPassword.Name = "TxtPassword"
    Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassword.Size = New System.Drawing.Size(371, 20)
    Me.TxtPassword.TabIndex = 10
    '
    'FrmTXE48B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(462, 145)
    Me.ControlBox = False
    Me.Controls.Add(Me.TxtPassword)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.TxtHost)
    Me.Controls.Add(Me.RbFTP)
    Me.Controls.Add(Me.RbFile)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label2)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE48B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

 Public Sub RunReport()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  Array.Clear(ErrorField, 0, 25)
  Array.Clear(ErrorMsg, 0, 25)

  If Not IsNothing(ErrorMsg(0)) Then
   Exit Sub
  End If

  Me.Refresh()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  PrtReport()
  Windows.Forms.Cursor.Current = Cursors.Default

 End Sub
Private Sub FrmTXE48B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmTXE48.SbpPgmID.Text = "TXE48B"
  MyFrmTXE48.SbpEnvironment.Text = myDBConnect.PgmDB
  RbFile.Checked = MyAppSettings.FileMode
  RbFTP.Checked = Not MyAppSettings.FileMode
  TxtHost.Text = MyAppSettings.Host
  TxtUser.Text = MyAppSettings.User
  TxtPassword.Text = GetPassword(MyAppSettings.Password)
  If RbFile.Checked Then
    TxtHost.Enabled = False
    TxtUser.Enabled = False
    TxtPassword.Enabled = False
  End If
End Sub
Private Sub FrmTXE48B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTXE48.SbpScreen.Text = "TXE48B"
End Sub
Private Sub FrmTXE48B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
Private Sub FrmTXE48B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub
Private Sub RbNormal_Click(sender As Object, e As EventArgs) Handles RbFile.Click
  TxtHost.Enabled = False
  TxtUser.Enabled = False
  TxtPassword.Enabled = False
End Sub
Private Sub RbFTP_Click(sender As Object, e As EventArgs) Handles RbFTP.Click
  TxtHost.Enabled = True
  TxtUser.Enabled = True
  TxtPassword.Enabled = True
End Sub

Private Sub RbFile_CheckedChanged(sender As Object, e As EventArgs) Handles RbFile.CheckedChanged

End Sub
End Class






