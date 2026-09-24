Public Class FrmTX831B
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtUser As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtFilePath As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtFileName As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label1 As Label

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAddress = New System.Windows.Forms.TextBox()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtFilePath = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtFileName = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 120)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(71, 13)
    Me.Label2.TabIndex = 70
    Me.Label2.Text = "FTP Address:"
    '
    'TxtAddress
    '
    Me.TxtAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAddress.Location = New System.Drawing.Point(85, 117)
    Me.TxtAddress.MaxLength = 40
    Me.TxtAddress.Name = "TxtAddress"
    Me.TxtAddress.Size = New System.Drawing.Size(254, 20)
    Me.TxtAddress.TabIndex = 5
    '
    'TxtUser
    '
    Me.TxtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUser.Location = New System.Drawing.Point(85, 136)
    Me.TxtUser.MaxLength = 40
    Me.TxtUser.Name = "TxtUser"
    Me.TxtUser.Size = New System.Drawing.Size(254, 20)
    Me.TxtUser.TabIndex = 6
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(13, 139)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(63, 13)
    Me.Label3.TabIndex = 72
    Me.Label3.Text = "User Name:"
    '
    'TxtPassword
    '
    Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPassword.Location = New System.Drawing.Point(85, 155)
    Me.TxtPassword.MaxLength = 20
    Me.TxtPassword.Name = "TxtPassword"
    Me.TxtPassword.Size = New System.Drawing.Size(129, 20)
    Me.TxtPassword.TabIndex = 7
    Me.TxtPassword.UseSystemPasswordChar = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(13, 158)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(56, 13)
    Me.Label4.TabIndex = 74
    Me.Label4.Text = "Password:"
    '
    'TxtFilePath
    '
    Me.TxtFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFilePath.Location = New System.Drawing.Point(74, 40)
    Me.TxtFilePath.MaxLength = 50
    Me.TxtFilePath.Name = "TxtFilePath"
    Me.TxtFilePath.Size = New System.Drawing.Size(218, 20)
    Me.TxtFilePath.TabIndex = 3
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(12, 43)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(56, 17)
    Me.Label6.TabIndex = 80
    Me.Label6.Text = "File Path"
    '
    'TxtFileName
    '
    Me.TxtFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFileName.Location = New System.Drawing.Point(74, 69)
    Me.TxtFileName.MaxLength = 50
    Me.TxtFileName.Name = "TxtFileName"
    Me.TxtFileName.Size = New System.Drawing.Size(278, 20)
    Me.TxtFileName.TabIndex = 4
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(12, 72)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 17)
    Me.Label7.TabIndex = 82
    Me.Label7.Text = "File Name"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(33, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(389, 18)
    Me.Label1.TabIndex = 85
    Me.Label1.Text = "File Types and Omit Status Codes are the same as program TX830"
    '
    'FrmTX831B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(450, 189)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtFileName)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtFilePath)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtPassword)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAddress)
    Me.Controls.Add(Me.Label2)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX831B"
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
  Private Sub FrmTX831B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX831.SbpPgmID.Text = "TX831B"
    MyFrmTX831.SbpEnvironment.Text = myDBConnect.PgmDB

    TxtFilePath.Text = MyAppSettings2.FilePath
    TxtFileName.Text = MyAppSettings2.FileName
    TxtAddress.Text = MyAppSettings2.Address
    TxtUser.Text = MyAppSettings2.User
    TxtPassword.Text = MyAppSettings2.Password
  End Sub
  Private Sub FrmTX831B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX831.SbpScreen.Text = "TX831B"
  End Sub
  Private Sub FrmTX831B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub FrmTX831B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
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






