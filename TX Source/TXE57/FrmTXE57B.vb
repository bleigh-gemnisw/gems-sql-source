Public Class FrmTXE57B
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtUser As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtFilePath As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtFileName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAddress = New System.Windows.Forms.TextBox()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtGLYear = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtFilePath = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtFileName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtTypes
        '
        Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTypes.Location = New System.Drawing.Point(109, 47)
        Me.TxtTypes.MaxLength = 20
        Me.TxtTypes.Name = "TxtTypes"
        Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
        Me.TxtTypes.TabIndex = 2
        '
        'LnkTypes
        '
        Me.LnkTypes.AutoSize = True
        Me.LnkTypes.Location = New System.Drawing.Point(15, 50)
        Me.LnkTypes.Name = "LnkTypes"
        Me.LnkTypes.Size = New System.Drawing.Size(72, 13)
        Me.LnkTypes.TabIndex = 1
        Me.LnkTypes.TabStop = True
        Me.LnkTypes.Text = "Select Types "
        Me.LnkTypes.UseMnemonic = False
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(87, 148)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "FTP Address:"
        Me.Label2.Visible = False
        '
        'TxtAddress
        '
        Me.TxtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddress.Location = New System.Drawing.Point(159, 145)
        Me.TxtAddress.MaxLength = 40
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(254, 20)
        Me.TxtAddress.TabIndex = 5
        Me.TxtAddress.Visible = False
        '
        'TxtUser
        '
        Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(159, 164)
        Me.TxtUser.MaxLength = 40
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(254, 20)
        Me.TxtUser.TabIndex = 6
        Me.TxtUser.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "User Name:"
        Me.Label3.Visible = False
        '
        'TxtPassword
        '
        Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.Location = New System.Drawing.Point(159, 183)
        Me.TxtPassword.MaxLength = 20
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(129, 20)
        Me.TxtPassword.TabIndex = 7
        Me.TxtPassword.UseSystemPasswordChar = True
        Me.TxtPassword.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(87, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Password:"
        Me.Label4.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(419, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "(Optional)"
        Me.Label1.Visible = False
        '
        'TxtGLYear
        '
        Me.TxtGLYear.Location = New System.Drawing.Point(109, 21)
        Me.TxtGLYear.MaxLength = 4
        Me.TxtGLYear.Name = "TxtGLYear"
        Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
        Me.TxtGLYear.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Current G/L Year"
        '
        'TxtFilePath
        '
        Me.TxtFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFilePath.Location = New System.Drawing.Point(77, 81)
        Me.TxtFilePath.MaxLength = 50
        Me.TxtFilePath.Name = "TxtFilePath"
        Me.TxtFilePath.Size = New System.Drawing.Size(218, 20)
        Me.TxtFilePath.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 80
        Me.Label6.Text = "File Path"
        '
        'TxtFileName
        '
        Me.TxtFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFileName.Location = New System.Drawing.Point(77, 110)
        Me.TxtFileName.MaxLength = 50
        Me.TxtFileName.Name = "TxtFileName"
        Me.TxtFileName.Size = New System.Drawing.Size(218, 20)
        Me.TxtFileName.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 17)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "File Name"
        '
        'FrmTXE57B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(450, 154)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtFileName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtFilePath)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtGLYear)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTypes)
        Me.Controls.Add(Me.LnkTypes)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTXE57B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
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
  Private Sub FrmTXE57B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkYear As Integer
    MyFrmTXE57.SbpPgmID.Text = "TXE57B"
    MyFrmTXE57.SbpEnvironment.Text = myDBConnect.PgmDB

    WrkYear = Date.Now.Year - 1
    If Date.Now.Month < 7 Then
      WrkYear = WrkYear - 1
    End If
    TxtGLYear.Text = WrkYear
    TxtTypes.Text = MyAppSettings.Types
    TxtFilePath.Text = MyAppSettings.FilePath
    TxtFileName.Text = MyAppSettings.FileName
    TxtAddress.Text = MyAppSettings.Address
    TxtUser.Text = MyAppSettings.User
    TxtPassword.Text = MyAppSettings.Password
  End Sub
  Private Sub FrmTXE57B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
 MyFrmTXE57.SbpScreen.Text = "TXE57B"
End Sub
Private Sub FrmTXE57B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
 Me.Refresh()
End Sub
Private Sub FrmTXE57B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "name"
        ErrProv.SetError(TxtFileName, ErrorMsg(I))
      Case "path"
        ErrProv.SetError(TxtFilePath, ErrorMsg(I))
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

    If TxtFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank"
      I = I + 1
    End If

    If TxtFileName.Text = "" Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "File Name cannot be blank"
      I = I + 1
    End If
  End Sub
End Class







