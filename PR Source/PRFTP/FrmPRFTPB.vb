Public Class FrmPRFTPB
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
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtPassword As TextBox
  Friend WithEvents TxtUser As TextBox
  Friend WithEvents TxtHost As TextBox
  Friend WithEvents Label3 As Label
  Friend WithEvents Label1 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents RbChkSup As RadioButton
  Friend WithEvents RbCkhist As RadioButton
  Friend WithEvents RbState As RadioButton
  Friend WithEvents RbFederal As RadioButton
  Friend WithEvents RbQuarterly As RadioButton
  Friend WithEvents RbDirect As RadioButton
  Friend WithEvents ChkDirectTotal As CheckBox
  Friend WithEvents RbW2 As RadioButton
  Friend WithEvents GrpFile As GroupBox
  Friend WithEvents LblFilePath As Label
  Friend WithEvents LnkFilePath As LinkLabel
  Friend WithEvents ErrProv As ErrorProvider
  Friend WithEvents SaveFileDialog1 As SaveFileDialog

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtPassword = New System.Windows.Forms.TextBox()
    Me.TxtUser = New System.Windows.Forms.TextBox()
    Me.TxtHost = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.RbChkSup = New System.Windows.Forms.RadioButton()
    Me.RbCkhist = New System.Windows.Forms.RadioButton()
    Me.RbState = New System.Windows.Forms.RadioButton()
    Me.RbFederal = New System.Windows.Forms.RadioButton()
    Me.RbQuarterly = New System.Windows.Forms.RadioButton()
    Me.RbDirect = New System.Windows.Forms.RadioButton()
    Me.ChkDirectTotal = New System.Windows.Forms.CheckBox()
    Me.RbW2 = New System.Windows.Forms.RadioButton()
    Me.GrpFile = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GrpFile.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
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
    'TxtPassword
    '
    Me.TxtPassword.Location = New System.Drawing.Point(95, 318)
    Me.TxtPassword.Name = "TxtPassword"
    Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtPassword.Size = New System.Drawing.Size(371, 20)
    Me.TxtPassword.TabIndex = 22
    '
    'TxtUser
    '
    Me.TxtUser.Location = New System.Drawing.Point(95, 292)
    Me.TxtUser.Name = "TxtUser"
    Me.TxtUser.Size = New System.Drawing.Size(135, 20)
    Me.TxtUser.TabIndex = 21
    '
    'TxtHost
    '
    Me.TxtHost.Location = New System.Drawing.Point(95, 266)
    Me.TxtHost.Name = "TxtHost"
    Me.TxtHost.Size = New System.Drawing.Size(371, 20)
    Me.TxtHost.TabIndex = 20
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(28, 321)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 19
    Me.Label3.Text = "Password"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(28, 295)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 18
    Me.Label1.Text = "User Name"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(29, 269)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(60, 13)
    Me.Label2.TabIndex = 17
    Me.Label2.Text = "Host Name"
    '
    'RbChkSup
    '
    Me.RbChkSup.AutoSize = True
    Me.RbChkSup.Checked = True
    Me.RbChkSup.Location = New System.Drawing.Point(31, 12)
    Me.RbChkSup.Name = "RbChkSup"
    Me.RbChkSup.Size = New System.Drawing.Size(161, 17)
    Me.RbChkSup.TabIndex = 23
    Me.RbChkSup.TabStop = True
    Me.RbChkSup.Text = "Transfer Check/Support files"
    Me.RbChkSup.UseVisualStyleBackColor = True
    '
    'RbCkhist
    '
    Me.RbCkhist.AutoSize = True
    Me.RbCkhist.Enabled = False
    Me.RbCkhist.Location = New System.Drawing.Point(31, 58)
    Me.RbCkhist.Name = "RbCkhist"
    Me.RbCkhist.Size = New System.Drawing.Size(139, 17)
    Me.RbCkhist.TabIndex = 30
    Me.RbCkhist.Text = "Check History (CKHIST)"
    Me.RbCkhist.UseVisualStyleBackColor = True
    '
    'RbState
    '
    Me.RbState.AutoSize = True
    Me.RbState.Location = New System.Drawing.Point(31, 150)
    Me.RbState.Name = "RbState"
    Me.RbState.Size = New System.Drawing.Size(125, 17)
    Me.RbState.TabIndex = 28
    Me.RbState.Text = "State W2 (MMREFS)"
    Me.RbState.UseVisualStyleBackColor = True
    '
    'RbFederal
    '
    Me.RbFederal.AutoSize = True
    Me.RbFederal.Location = New System.Drawing.Point(31, 127)
    Me.RbFederal.Name = "RbFederal"
    Me.RbFederal.Size = New System.Drawing.Size(128, 17)
    Me.RbFederal.TabIndex = 27
    Me.RbFederal.Text = "Federal W2 (MMREF)"
    Me.RbFederal.UseVisualStyleBackColor = True
    '
    'RbQuarterly
    '
    Me.RbQuarterly.AutoSize = True
    Me.RbQuarterly.Location = New System.Drawing.Point(31, 104)
    Me.RbQuarterly.Name = "RbQuarterly"
    Me.RbQuarterly.Size = New System.Drawing.Size(86, 17)
    Me.RbQuarterly.TabIndex = 26
    Me.RbQuarterly.Text = "Quarterly File"
    Me.RbQuarterly.UseVisualStyleBackColor = True
    '
    'RbDirect
    '
    Me.RbDirect.AutoSize = True
    Me.RbDirect.Location = New System.Drawing.Point(31, 81)
    Me.RbDirect.Name = "RbDirect"
    Me.RbDirect.Size = New System.Drawing.Size(92, 17)
    Me.RbDirect.TabIndex = 25
    Me.RbDirect.Text = "Direct Deposit"
    Me.RbDirect.UseVisualStyleBackColor = True
    '
    'ChkDirectTotal
    '
    Me.ChkDirectTotal.AutoSize = True
    Me.ChkDirectTotal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDirectTotal.Location = New System.Drawing.Point(129, 82)
    Me.ChkDirectTotal.Name = "ChkDirectTotal"
    Me.ChkDirectTotal.Size = New System.Drawing.Size(113, 17)
    Me.ChkDirectTotal.TabIndex = 29
    Me.ChkDirectTotal.Text = "Skip Total record?"
    Me.ChkDirectTotal.UseVisualStyleBackColor = True
    '
    'RbW2
    '
    Me.RbW2.AutoSize = True
    Me.RbW2.Location = New System.Drawing.Point(31, 35)
    Me.RbW2.Name = "RbW2"
    Me.RbW2.Size = New System.Drawing.Size(124, 17)
    Me.RbW2.TabIndex = 31
    Me.RbW2.Text = "Transfer W2 Print file"
    Me.RbW2.UseVisualStyleBackColor = True
    '
    'GrpFile
    '
    Me.GrpFile.Controls.Add(Me.LblFilePath)
    Me.GrpFile.Controls.Add(Me.LnkFilePath)
    Me.GrpFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpFile.ForeColor = System.Drawing.Color.Black
    Me.GrpFile.Location = New System.Drawing.Point(31, 182)
    Me.GrpFile.Name = "GrpFile"
    Me.GrpFile.Size = New System.Drawing.Size(408, 65)
    Me.GrpFile.TabIndex = 32
    Me.GrpFile.TabStop = False
    Me.GrpFile.Text = "File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(70, 24)
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
    Me.LnkFilePath.TabIndex = 0
    Me.LnkFilePath.TabStop = True
    Me.LnkFilePath.Text = "File Path"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmPRFTPB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(492, 368)
    Me.ControlBox = False
    Me.Controls.Add(Me.GrpFile)
    Me.Controls.Add(Me.RbW2)
    Me.Controls.Add(Me.RbCkhist)
    Me.Controls.Add(Me.RbState)
    Me.Controls.Add(Me.RbFederal)
    Me.Controls.Add(Me.RbQuarterly)
    Me.Controls.Add(Me.RbDirect)
    Me.Controls.Add(Me.ChkDirectTotal)
    Me.Controls.Add(Me.RbChkSup)
    Me.Controls.Add(Me.TxtPassword)
    Me.Controls.Add(Me.TxtUser)
    Me.Controls.Add(Me.TxtHost)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPRFTPB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GrpFile.ResumeLayout(False)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunProcess()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Array.Clear(ErrorField, 0, 25)
    Array.Clear(ErrorMsg, 0, 25)

    If Not IsNothing(ErrorMsg(0)) Then
      Exit Sub
    End If

    Me.Refresh()
    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    If RbChkSup.Checked Or RbW2.Checked Then
      ProcTrans()
    Else
      ProcDown()
    End If
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
  Private Sub FrmPRFTPB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmPRFTP.SbpPgmID.Text = "PRFTPB"
    MyFrmPRFTP.SbpEnvironment.Text = myDBConnect.PgmDB
    TxtHost.Text = MyAppSettings.Host
    TxtUser.Text = MyAppSettings.User
    TxtPassword.Text = GetPassword(MyAppSettings.Password)
    GrpFile.Visible = False
  End Sub
  Private Sub FrmPRFTPB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPRFTP.SbpScreen.Text = "PRFTPB"
  End Sub
  Private Sub FrmPRFTPB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub FrmPRFTPB_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(LblFilePath, "")

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

    If GrpFile.Visible = True And LblFilePath.Text = "" Then
      ErrorField(I) = "path"
      ErrorMsg(I) = "File Path cannot be blank. Click on link to set."
      I = I + 1
    End If

  End Sub

  Private Sub RbChkSup_Click(sender As Object, e As EventArgs) Handles RbChkSup.Click
    GrpFile.Visible = False
  End Sub
  Private Sub RbW2_Click(sender As Object, e As EventArgs) Handles RbW2.Click
    GrpFile.Visible = False
  End Sub

  Private Sub RbCkhist_Click(sender As Object, e As EventArgs) Handles RbCkhist.Click
    GrpFile.Visible = True
  End Sub

  Private Sub RbDirect_Click(sender As Object, e As EventArgs) Handles RbDirect.Click
    GrpFile.Visible = True
  End Sub
  Private Sub RbQuarterly_Click(sender As Object, e As EventArgs) Handles RbQuarterly.Click
    GrpFile.Visible = True
  End Sub
  Private Sub RbFederal_Click(sender As Object, e As EventArgs) Handles RbFederal.Click
    GrpFile.Visible = True
  End Sub
  Private Sub RbState_Click(sender As Object, e As EventArgs) Handles RbState.Click
    GrpFile.Visible = True
  End Sub
  Private Sub LnkFilePath_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePath.LinkClicked
    With SaveFileDialog1
      .ShowDialog()
      LblFilePath.Text = .FileName
    End With
  End Sub
End Class
