Public Class FrmTXE53B
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
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  Friend WithEvents LnkFilePath As System.Windows.Forms.LinkLabel
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtUser As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RbView As System.Windows.Forms.RadioButton
  Friend WithEvents RbGeneric As System.Windows.Forms.RadioButton

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAddress = New System.Windows.Forms.TextBox()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbGeneric = New System.Windows.Forms.RadioButton()
    Me.RbView = New System.Windows.Forms.RadioButton()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(136, 23)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
    Me.TxtTypes.TabIndex = 0
    '
    'LnkTypes
    '
    Me.LnkTypes.AutoSize = True
    Me.LnkTypes.Location = New System.Drawing.Point(58, 26)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(72, 13)
    Me.LnkTypes.TabIndex = 67
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Select Types "
    Me.LnkTypes.UseMnemonic = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Controls.Add(Me.LnkFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(8, 99)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 67
    '
    'LnkFilePath
    '
    Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePath.Name = "LnkFilePath"
    Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePath.TabIndex = 65
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(11, 183)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(71, 13)
    Me.Label2.TabIndex = 70
    Me.Label2.Text = "FTP Address:"
    '
    'TxtAddress
    '
    Me.TxtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddress.Location = New System.Drawing.Point(83, 180)
    Me.TxtAddress.MaxLength = 40
    Me.TxtAddress.Name = "TxtAddress"
    Me.TxtAddress.Size = New System.Drawing.Size(254, 20)
    Me.TxtAddress.TabIndex = 2
    '
    'TxtUser
    '
    Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser.Location = New System.Drawing.Point(83, 199)
    Me.TxtUser.MaxLength = 40
    Me.TxtUser.Name = "TxtUser"
    Me.TxtUser.Size = New System.Drawing.Size(254, 20)
    Me.TxtUser.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(11, 202)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(63, 13)
    Me.Label3.TabIndex = 72
    Me.Label3.Text = "User Name:"
    '
    'TxtPassword
    '
    Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPassword.Location = New System.Drawing.Point(83, 218)
    Me.TxtPassword.MaxLength = 20
    Me.TxtPassword.Name = "TxtPassword"
    Me.TxtPassword.Size = New System.Drawing.Size(129, 20)
    Me.TxtPassword.TabIndex = 4
    Me.TxtPassword.UseSystemPasswordChar = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(11, 221)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 13)
    Me.Label4.TabIndex = 74
    Me.Label4.Text = "Password:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(343, 183)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(52, 13)
    Me.Label1.TabIndex = 76
    Me.Label1.Text = "(Optional)"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbView)
    Me.GroupBox2.Controls.Add(Me.RbGeneric)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(316, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(100, 63)
    Me.GroupBox2.TabIndex = 5
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "File Format"
    '
    'RbGeneric
    '
    Me.RbGeneric.AutoSize = True
    Me.RbGeneric.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbGeneric.Checked = True
    Me.RbGeneric.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbGeneric.Location = New System.Drawing.Point(6, 19)
    Me.RbGeneric.Name = "RbGeneric"
    Me.RbGeneric.Size = New System.Drawing.Size(62, 17)
    Me.RbGeneric.TabIndex = 78
    Me.RbGeneric.TabStop = True
    Me.RbGeneric.Text = "Generic"
    Me.RbGeneric.UseVisualStyleBackColor = True
    '
    'RbView
    '
    Me.RbView.AutoSize = True
    Me.RbView.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbView.Location = New System.Drawing.Point(6, 42)
    Me.RbView.Name = "RbView"
    Me.RbView.Size = New System.Drawing.Size(80, 17)
    Me.RbView.TabIndex = 79
    Me.RbView.Text = "View Permit"
    Me.RbView.UseVisualStyleBackColor = True
    '
    'FrmTXE53B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(424, 247)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPassword)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAddress)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE53B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

 Public Sub RunReport()
  Dim ErrorField(25) As String
  Dim ErrorMsg(25) As String

  Array.Clear(ErrorField, 0, 25)
  Array.Clear(ErrorMsg, 0, 25)

  EditChecks(ErrorField, ErrorMsg)
  ShowError(ErrorField, ErrorMsg)
  If Not IsNothing(ErrorMsg(0)) Then
   Exit Sub
  End If

  Me.Refresh()
  Windows.Forms.Cursor.Current = Cursors.WaitCursor
  PrtReport()
  Windows.Forms.Cursor.Current = Cursors.Default

 End Sub
Private Sub FrmTXE53B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  MyFrmTXE53.SbpPgmID.Text = "TXE53B"
  MyFrmTXE53.SbpEnvironment.Text = myDBConnect.PgmDB
  TxtTypes.Text = MyAppSettings.Types
  LblFilePath.Text = MyAppSettings.FilePath
  If MyAppSettings.Format = "VP" Then
    RbView.Checked = True
  Else
    RbGeneric.Checked = True
  End If
  TxtAddress.Text = MyAppSettings.Address
  TxtUser.Text = MyAppSettings.User
  TxtPassword.Text = MyAppSettings.Password
End Sub
Private Sub FrmTXE53B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTXE53.SbpScreen.Text = "TXE53B"
End Sub
Private Sub FrmTXE53B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
Private Sub FrmTXE53B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
 If Not e.Alt Then Exit Sub

  If e.KeyCode = Keys.F12 Then
   MyUtils.PrtScreen(Form.ActiveForm)
  End If
End Sub

Private Sub LnkTypes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
  MyTypes = TxtTypes.Text
  MyFrmSelTypes = New FrmSelTypes
  MyFrmSelTypes.MdiParent = Me.ParentForm
  MyFrmSelTypes.WrkField = "Types"
  MyFrmSelTypes.WrkTypes = MyTypes
  MyFrmSelTypes.Show()
End Sub
Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
  With SaveFileDialog1
    .ShowDialog()
    LblFilePath.Text = .FileName
  End With
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "path"
        ErrProv.SetError(LblFilePath, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub
End Class






