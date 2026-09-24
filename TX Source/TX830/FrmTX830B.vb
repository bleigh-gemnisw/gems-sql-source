Public Class FrmTX830B
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

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtGLFromYear As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
  Friend WithEvents TxtGLToYear As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtBlocked As System.Windows.Forms.TextBox
  Friend WithEvents LnkBlocked As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtOmit As System.Windows.Forms.TextBox
  Friend WithEvents LnkOmit As System.Windows.Forms.LinkLabel
  Friend WithEvents ChkBlockSusp As System.Windows.Forms.CheckBox
  Friend WithEvents TxtWebName As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents ChkBlockBackTax As System.Windows.Forms.CheckBox
  Friend WithEvents ChkOmitSusp As System.Windows.Forms.CheckBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtNonPublic As System.Windows.Forms.TextBox
  Friend WithEvents LnkNonPublic As System.Windows.Forms.LinkLabel
  Friend WithEvents LblNonPublic As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtLienMsg As System.Windows.Forms.TextBox
  Friend WithEvents TxtLiened As System.Windows.Forms.TextBox
  Friend WithEvents LnkLiened As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtWebTown As System.Windows.Forms.TextBox
  Friend WithEvents RbSecondary As System.Windows.Forms.RadioButton
  Friend WithEvents RbPrimary As System.Windows.Forms.RadioButton
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtWebScript As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtNonCodes As TextBox
  Friend WithEvents LnkNonCodes As LinkLabel
  Friend WithEvents ChkQRCode As CheckBox
  Friend WithEvents LblFilePath As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePath = New System.Windows.Forms.Label()
    Me.TxtGLFromYear = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtGLToYear = New System.Windows.Forms.TextBox()
    Me.LnkBlocked = New System.Windows.Forms.LinkLabel()
    Me.TxtBlocked = New System.Windows.Forms.TextBox()
    Me.TxtOmit = New System.Windows.Forms.TextBox()
    Me.LnkOmit = New System.Windows.Forms.LinkLabel()
    Me.ChkBlockSusp = New System.Windows.Forms.CheckBox()
    Me.TxtWebName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ChkBlockBackTax = New System.Windows.Forms.CheckBox()
    Me.ChkOmitSusp = New System.Windows.Forms.CheckBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtNonPublic = New System.Windows.Forms.TextBox()
    Me.LnkNonPublic = New System.Windows.Forms.LinkLabel()
    Me.LblNonPublic = New System.Windows.Forms.Label()
    Me.TxtLiened = New System.Windows.Forms.TextBox()
    Me.LnkLiened = New System.Windows.Forms.LinkLabel()
    Me.TxtLienMsg = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.RbPrimary = New System.Windows.Forms.RadioButton()
    Me.RbSecondary = New System.Windows.Forms.RadioButton()
    Me.TxtWebTown = New System.Windows.Forms.TextBox()
    Me.TxtWebScript = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LnkNonCodes = New System.Windows.Forms.LinkLabel()
    Me.TxtNonCodes = New System.Windows.Forms.TextBox()
    Me.ChkQRCode = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePath)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(24, 256)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(341, 62)
    Me.GroupBox1.TabIndex = 11
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "WEBTAX File Details"
    '
    'LblFilePath
    '
    Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePath.Location = New System.Drawing.Point(6, 16)
    Me.LblFilePath.Name = "LblFilePath"
    Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePath.TabIndex = 0
    '
    'TxtGLFromYear
    '
    Me.TxtGLFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLFromYear.Location = New System.Drawing.Point(155, 35)
    Me.TxtGLFromYear.MaxLength = 4
    Me.TxtGLFromYear.Name = "TxtGLFromYear"
    Me.TxtGLFromYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLFromYear.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(19, 39)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(109, 13)
    Me.Label3.TabIndex = 48
    Me.Label3.Text = "All data for G/L Years"
    '
    'LnkTypes
    '
    Me.LnkTypes.AutoSize = True
    Me.LnkTypes.Location = New System.Drawing.Point(19, 70)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(72, 13)
    Me.LnkTypes.TabIndex = 65
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Select Types "
    Me.LnkTypes.UseMnemonic = False
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTypes.Location = New System.Drawing.Point(155, 68)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(129, 20)
    Me.TxtTypes.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(193, 37)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(18, 16)
    Me.Label1.TabIndex = 67
    Me.Label1.Text = "to"
    '
    'TxtGLToYear
    '
    Me.TxtGLToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLToYear.Location = New System.Drawing.Point(217, 35)
    Me.TxtGLToYear.MaxLength = 4
    Me.TxtGLToYear.Name = "TxtGLToYear"
    Me.TxtGLToYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLToYear.TabIndex = 1
    '
    'LnkBlocked
    '
    Me.LnkBlocked.AutoSize = True
    Me.LnkBlocked.Location = New System.Drawing.Point(21, 122)
    Me.LnkBlocked.Name = "LnkBlocked"
    Me.LnkBlocked.Size = New System.Drawing.Size(128, 13)
    Me.LnkBlocked.TabIndex = 68
    Me.LnkBlocked.TabStop = True
    Me.LnkBlocked.Text = "Codes-Blocked Payments"
    '
    'TxtBlocked
    '
    Me.TxtBlocked.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBlocked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBlocked.Location = New System.Drawing.Point(155, 119)
    Me.TxtBlocked.MaxLength = 20
    Me.TxtBlocked.Name = "TxtBlocked"
    Me.TxtBlocked.Size = New System.Drawing.Size(129, 20)
    Me.TxtBlocked.TabIndex = 4
    '
    'TxtOmit
    '
    Me.TxtOmit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOmit.Location = New System.Drawing.Point(155, 196)
    Me.TxtOmit.MaxLength = 20
    Me.TxtOmit.Name = "TxtOmit"
    Me.TxtOmit.Size = New System.Drawing.Size(129, 20)
    Me.TxtOmit.TabIndex = 9
    '
    'LnkOmit
    '
    Me.LnkOmit.AutoSize = True
    Me.LnkOmit.Location = New System.Drawing.Point(21, 199)
    Me.LnkOmit.Name = "LnkOmit"
    Me.LnkOmit.Size = New System.Drawing.Size(104, 13)
    Me.LnkOmit.TabIndex = 71
    Me.LnkOmit.TabStop = True
    Me.LnkOmit.Text = "Codes-Omit Records"
    '
    'ChkBlockSusp
    '
    Me.ChkBlockSusp.AutoSize = True
    Me.ChkBlockSusp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBlockSusp.Location = New System.Drawing.Point(295, 121)
    Me.ChkBlockSusp.Name = "ChkBlockSusp"
    Me.ChkBlockSusp.Size = New System.Drawing.Size(109, 17)
    Me.ChkBlockSusp.TabIndex = 5
    Me.ChkBlockSusp.Text = "Block Suspense?"
    Me.ChkBlockSusp.UseVisualStyleBackColor = True
    '
    'TxtWebName
    '
    Me.TxtWebName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtWebName.Location = New System.Drawing.Point(191, 328)
    Me.TxtWebName.MaxLength = 20
    Me.TxtWebName.Name = "TxtWebName"
    Me.TxtWebName.Size = New System.Drawing.Size(125, 20)
    Me.TxtWebName.TabIndex = 13
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(22, 332)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(127, 13)
    Me.Label2.TabIndex = 74
    Me.Label2.Text = "Webpay Town No/Name"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(322, 331)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(99, 13)
    Me.Label4.TabIndex = 75
    Me.Label4.Text = "(Assigned by RWA)"
    '
    'ChkBlockBackTax
    '
    Me.ChkBlockBackTax.AutoSize = True
    Me.ChkBlockBackTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBlockBackTax.Location = New System.Drawing.Point(428, 121)
    Me.ChkBlockBackTax.Name = "ChkBlockBackTax"
    Me.ChkBlockBackTax.Size = New System.Drawing.Size(118, 17)
    Me.ChkBlockBackTax.TabIndex = 6
    Me.ChkBlockBackTax.Text = "Block ""Back Tax""?"
    Me.ChkBlockBackTax.UseVisualStyleBackColor = True
    '
    'ChkOmitSusp
    '
    Me.ChkOmitSusp.AutoSize = True
    Me.ChkOmitSusp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitSusp.Location = New System.Drawing.Point(295, 198)
    Me.ChkOmitSusp.Name = "ChkOmitSusp"
    Me.ChkOmitSusp.Size = New System.Drawing.Size(103, 17)
    Me.ChkOmitSusp.TabIndex = 10
    Me.ChkOmitSusp.Text = "Omit Suspense?"
    Me.ChkOmitSusp.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(255, 38)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(273, 13)
    Me.Label5.TabIndex = 77
    Me.Label5.Text = "(Delinquent data will be included for years outside range)"
    '
    'TxtNonPublic
    '
    Me.TxtNonPublic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtNonPublic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtNonPublic.Location = New System.Drawing.Point(155, 93)
    Me.TxtNonPublic.MaxLength = 20
    Me.TxtNonPublic.Name = "TxtNonPublic"
    Me.TxtNonPublic.Size = New System.Drawing.Size(129, 20)
    Me.TxtNonPublic.TabIndex = 3
    '
    'LnkNonPublic
    '
    Me.LnkNonPublic.AutoSize = True
    Me.LnkNonPublic.Location = New System.Drawing.Point(19, 95)
    Me.LnkNonPublic.Name = "LnkNonPublic"
    Me.LnkNonPublic.Size = New System.Drawing.Size(124, 13)
    Me.LnkNonPublic.TabIndex = 79
    Me.LnkNonPublic.TabStop = True
    Me.LnkNonPublic.Text = "Select Non Public Types"
    '
    'LblNonPublic
    '
    Me.LblNonPublic.AutoSize = True
    Me.LblNonPublic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNonPublic.Location = New System.Drawing.Point(290, 95)
    Me.LblNonPublic.Name = "LblNonPublic"
    Me.LblNonPublic.Size = New System.Drawing.Size(161, 13)
    Me.LblNonPublic.TabIndex = 80
    Me.LblNonPublic.Text = "(Only Current or Delinquent data)"
    '
    'TxtLiened
    '
    Me.TxtLiened.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLiened.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLiened.Location = New System.Drawing.Point(155, 145)
    Me.TxtLiened.MaxLength = 1
    Me.TxtLiened.Name = "TxtLiened"
    Me.TxtLiened.Size = New System.Drawing.Size(15, 20)
    Me.TxtLiened.TabIndex = 7
    '
    'LnkLiened
    '
    Me.LnkLiened.AutoSize = True
    Me.LnkLiened.Location = New System.Drawing.Point(21, 148)
    Me.LnkLiened.Name = "LnkLiened"
    Me.LnkLiened.Size = New System.Drawing.Size(120, 13)
    Me.LnkLiened.TabIndex = 82
    Me.LnkLiened.TabStop = True
    Me.LnkLiened.Text = "Code-Collection Agency"
    '
    'TxtLienMsg
    '
    Me.TxtLienMsg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLienMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLienMsg.Location = New System.Drawing.Point(155, 172)
    Me.TxtLienMsg.MaxLength = 50
    Me.TxtLienMsg.Name = "TxtLienMsg"
    Me.TxtLienMsg.Size = New System.Drawing.Size(373, 20)
    Me.TxtLienMsg.TabIndex = 8
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(34, 175)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(115, 13)
    Me.Label7.TabIndex = 84
    Me.Label7.Text = "Coll. Agency Message "
    '
    'RbPrimary
    '
    Me.RbPrimary.AutoSize = True
    Me.RbPrimary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPrimary.Checked = True
    Me.RbPrimary.Location = New System.Drawing.Point(12, 6)
    Me.RbPrimary.Name = "RbPrimary"
    Me.RbPrimary.Size = New System.Drawing.Size(101, 17)
    Me.RbPrimary.TabIndex = 15
    Me.RbPrimary.TabStop = True
    Me.RbPrimary.Text = "Primary Website"
    Me.RbPrimary.UseVisualStyleBackColor = True
    '
    'RbSecondary
    '
    Me.RbSecondary.AutoSize = True
    Me.RbSecondary.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSecondary.Location = New System.Drawing.Point(136, 6)
    Me.RbSecondary.Name = "RbSecondary"
    Me.RbSecondary.Size = New System.Drawing.Size(118, 17)
    Me.RbSecondary.TabIndex = 16
    Me.RbSecondary.Text = "Secondary Website"
    Me.RbSecondary.UseVisualStyleBackColor = True
    '
    'TxtWebTown
    '
    Me.TxtWebTown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtWebTown.Location = New System.Drawing.Point(154, 328)
    Me.TxtWebTown.MaxLength = 4
    Me.TxtWebTown.Name = "TxtWebTown"
    Me.TxtWebTown.Size = New System.Drawing.Size(32, 20)
    Me.TxtWebTown.TabIndex = 12
    '
    'TxtWebScript
    '
    Me.TxtWebScript.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtWebScript.Location = New System.Drawing.Point(155, 354)
    Me.TxtWebScript.MaxLength = 20
    Me.TxtWebScript.Name = "TxtWebScript"
    Me.TxtWebScript.Size = New System.Drawing.Size(125, 20)
    Me.TxtWebScript.TabIndex = 14
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(22, 357)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(77, 13)
    Me.Label8.TabIndex = 86
    Me.Label8.Text = "Webpay Script"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(149, 413)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(216, 13)
    Me.Label6.TabIndex = 87
    Me.Label6.Text = "Non Public search is by list# or account only"
    '
    'LnkNonCodes
    '
    Me.LnkNonCodes.AutoSize = True
    Me.LnkNonCodes.Location = New System.Drawing.Point(24, 224)
    Me.LnkNonCodes.Name = "LnkNonCodes"
    Me.LnkNonCodes.Size = New System.Drawing.Size(92, 13)
    Me.LnkNonCodes.TabIndex = 88
    Me.LnkNonCodes.TabStop = True
    Me.LnkNonCodes.Text = "Codes-Non Public"
    '
    'TxtNonCodes
    '
    Me.TxtNonCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtNonCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtNonCodes.Location = New System.Drawing.Point(154, 222)
    Me.TxtNonCodes.MaxLength = 20
    Me.TxtNonCodes.Name = "TxtNonCodes"
    Me.TxtNonCodes.Size = New System.Drawing.Size(129, 20)
    Me.TxtNonCodes.TabIndex = 10
    '
    'ChkQRCode
    '
    Me.ChkQRCode.AutoSize = True
    Me.ChkQRCode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkQRCode.Location = New System.Drawing.Point(94, 380)
    Me.ChkQRCode.Name = "ChkQRCode"
    Me.ChkQRCode.Size = New System.Drawing.Size(76, 17)
    Me.ChkQRCode.TabIndex = 91
    Me.ChkQRCode.Text = "QR Code?"
    Me.ChkQRCode.UseVisualStyleBackColor = True
    '
    'FrmTX830B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(585, 435)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkQRCode)
    Me.Controls.Add(Me.TxtNonCodes)
    Me.Controls.Add(Me.LnkNonCodes)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtWebScript)
    Me.Controls.Add(Me.TxtWebTown)
    Me.Controls.Add(Me.RbSecondary)
    Me.Controls.Add(Me.RbPrimary)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtLienMsg)
    Me.Controls.Add(Me.TxtLiened)
    Me.Controls.Add(Me.LnkLiened)
    Me.Controls.Add(Me.LblNonPublic)
    Me.Controls.Add(Me.TxtNonPublic)
    Me.Controls.Add(Me.LnkNonPublic)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ChkOmitSusp)
    Me.Controls.Add(Me.ChkBlockBackTax)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtWebName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.ChkBlockSusp)
    Me.Controls.Add(Me.TxtOmit)
    Me.Controls.Add(Me.LnkOmit)
    Me.Controls.Add(Me.TxtBlocked)
    Me.Controls.Add(Me.LnkBlocked)
    Me.Controls.Add(Me.TxtGLToYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtGLFromYear)
    Me.Controls.Add(Me.Label3)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX830B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
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
  Private Sub FrmTX830B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmTX830.SbpPgmID.Text = "TX830B"
    MyFrmTX830.SbpEnvironment.Text = myDBConnect.PgmDB
    GetSettings(True)
    If Not MyWebNP Then
      LblNonPublic.Text = ""
    End If
  End Sub
  Private Sub FrmTX830B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX830.SbpScreen.Text = "TX830B"
  End Sub
  Private Sub FrmTX830B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLFromYear, "")
    ErrProv.SetError(TxtTypes, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "glyear"
          ErrProv.SetError(TxtGLFromYear, ErrorMsg(I))
        Case "types"
          ErrProv.SetError(TxtTypes, ErrorMsg(I))
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

    If MyUtils.CnvSng(TxtGLFromYear.Text) > MyUtils.CnvSng(TxtGLToYear.Text) Then
      ErrorField(I) = "to"
      ErrorMsg(I) = "Invalid GL Year Range"
      I = I + 1
    End If
  End Sub
  Private Sub FrmTX830B_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If Not e.Alt Then Exit Sub

    If e.KeyCode = Keys.F12 Then
      MyUtils.PrtScreen(Form.ActiveForm)
    End If
  End Sub
  Private Sub TxtGLFromYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLFromYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGLToYear_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLToYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkTypes_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkTypes.LinkClicked
    MyTypes = TxtTypes.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.WrkField = "Types"
    MyFrmSelTypes.WrkTypes = MyTypes
    MyFrmSelTypes.Show()

  End Sub
  Private Sub LnkBlocked_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBlocked.LinkClicked
    MyStsBlocked = TxtBlocked.Text
    MyFrmSelSts = New FrmSelSts
    MyFrmSelSts.WrkField = "Blocked"
    MyFrmSelSts.MdiParent = Me.ParentForm
    MyFrmSelSts.Show()
    Me.Hide()
  End Sub
  Private Sub LnkLiened_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkLiened.LinkClicked
    MyStsLiened = TxtLiened.Text
    MyFrmSelSts = New FrmSelSts
    MyFrmSelSts.WrkField = "Liened"
    MyFrmSelSts.MdiParent = Me.ParentForm
    MyFrmSelSts.Show()
    Me.Hide()
  End Sub
  Private Sub LnkOmit_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOmit.LinkClicked
    MyStsOmit = TxtOmit.Text
    MyFrmSelSts = New FrmSelSts
    MyFrmSelSts.WrkField = "Omit"
    MyFrmSelSts.MdiParent = Me.ParentForm
    MyFrmSelSts.Show()
    Me.Hide()
  End Sub
  Private Sub ChkBlockSusp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkBlockSusp.Click
    ChkOmitSusp.Checked = False
  End Sub
  Private Sub ChkOmitSusp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOmitSusp.Click
    ChkBlockSusp.Checked = False
  End Sub

  Private Sub LnkNonPublic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkNonPublic.LinkClicked
    MyNonPublic = TxtNonPublic.Text
    MyFrmSelTypes = New FrmSelTypes
    MyFrmSelTypes.MdiParent = Me.ParentForm
    MyFrmSelTypes.WrkField = "NonPublic"
    MyFrmSelTypes.WrkTypes = MyNonPublic
    MyFrmSelTypes.Show()
  End Sub
  Private Sub LnkNonCodes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkNonCodes.LinkClicked
    MyStsNonCodes = TxtNonCodes.Text
    MyFrmSelSts = New FrmSelSts
    MyFrmSelSts.WrkField = "NonCodes"
    MyFrmSelSts.MdiParent = Me.ParentForm
    MyFrmSelSts.Show()
    Me.Hide()
  End Sub
  Private Sub RbPrimary_Click(sender As Object, e As EventArgs) Handles RbPrimary.Click
    GetSettings(True)
  End Sub
  Private Sub RbSecondary_Click(sender As Object, e As EventArgs) Handles RbSecondary.Click
    GetSettings(False)
  End Sub
  Private Sub GetSettings(ByVal WrkPrimary As Boolean)
    MyTypes = ""
    MyStsBlocked = ""
    MyStsLiened = ""
    MyStsOmit = ""
    If RbPrimary.Checked Then
      GetAppSettings()
      TxtGLFromYear.Text = MyAppSettings.FromYear
      TxtGLToYear.Text = MyAppSettings.ToYear
      TxtTypes.Text = MyAppSettings.Types
      TxtNonPublic.Text = MyAppSettings.NonPublic
      TxtBlocked.Text = MyAppSettings.Status
      TxtNonCodes.Text = MyAppSettings.NonCodes
      TxtLiened.Text = MyAppSettings.Liened
      TxtLienMsg.Text = MyAppSettings.LienMsg
      TxtOmit.Text = MyAppSettings.Omit
      TxtNonCodes.Text = MyAppSettings.NonCodes
      ChkBlockSusp.Checked = MyAppSettings.BlockSusp
      ChkBlockBackTax.Checked = MyAppSettings.BlockBackTax
      ChkOmitSusp.Checked = MyAppSettings.OmitSusp
      TxtWebTown.Text = MyAppSettings.WebTown
      TxtWebName.Text = MyAppSettings.WebName
      TxtWebScript.Text = MyAppSettings.WebScript
      ChkQRCode.Checked = MyAppSettings.QRCode
      LblFilePath.Text = MyUtils.GetDataPath() & "WEBTAX.csv"
    Else
      GetAppSettings2()
      TxtGLFromYear.Text = MyAppSettings2.FromYear
      TxtGLToYear.Text = MyAppSettings2.ToYear
      TxtTypes.Text = MyAppSettings2.Types
      TxtNonPublic.Text = MyAppSettings2.NonPublic
      TxtBlocked.Text = MyAppSettings2.Status
      TxtNonCodes.Text = MyAppSettings2.NonCodes
      TxtLiened.Text = MyAppSettings2.Liened
      TxtLienMsg.Text = MyAppSettings2.LienMsg
      TxtOmit.Text = MyAppSettings2.Omit
      TxtNonCodes.Text = MyAppSettings2.NonCodes
      ChkBlockSusp.Checked = MyAppSettings2.BlockSusp
      ChkBlockBackTax.Checked = MyAppSettings2.BlockBackTax
      ChkOmitSusp.Checked = MyAppSettings2.OmitSusp
      TxtWebTown.Text = MyAppSettings2.WebTown
      TxtWebName.Text = MyAppSettings2.WebName
      TxtWebScript.Text = MyAppSettings2.WebScript
      ChkQRCode.Checked = MyAppSettings2.QRCode
      LblFilePath.Text = MyUtils.GetDataPath() & "WEBTAX2.csv"
    End If
  End Sub

End Class






