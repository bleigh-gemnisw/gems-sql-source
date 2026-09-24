Public Class FrmTO222C
  Inherits System.Windows.Forms.Form
  Dim MyTXOPMD1 As TXOPMD1.MyData
  Dim MyTXREAL As TXREAL.MyData
  Dim MyTXMVD As TXMVD.MyData
  Dim MyTXSUPP As TXSupp.MyData

  Friend WrkListNo As Integer
  Friend WrkType As String
  Friend WrkYear As Integer
  Dim AddMode As Boolean
  Dim LoadScrn As Boolean
  Dim WrkExcludeGross As Integer
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  Friend WithEvents Label38 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label39 As System.Windows.Forms.Label
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label43 As System.Windows.Forms.Label
  Friend WithEvents Label44 As System.Windows.Forms.Label
  Friend WithEvents Label45 As System.Windows.Forms.Label
  Friend WithEvents Label46 As System.Windows.Forms.Label
  Friend WithEvents Label47 As System.Windows.Forms.Label
  Friend WithEvents Label49 As System.Windows.Forms.Label
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents Label53 As System.Windows.Forms.Label
  Friend WithEvents Label56 As System.Windows.Forms.Label
  Friend WithEvents Label57 As System.Windows.Forms.Label
  Friend WithEvents RbLocAllowed As RadioButton
  Friend WithEvents RbLocDisallowed As RadioButton
  Friend WithEvents TxtLocDisallowReason As TextBox
  Friend WithEvents RbEBCAllowed As RadioButton
  Friend WithEvents RbEBCDisallowed As RadioButton
  Friend WithEvents TxtEBCDisallowReason As TextBox
  Friend WithEvents RbFBCAllowed As RadioButton
  Friend WithEvents RbFBCDisallowed As RadioButton
  Friend WithEvents TxtFBCDisallowReason As TextBox
  Friend WithEvents Label62 As Label
  Friend WithEvents Label63 As Label
  Friend WithEvents Label64 As Label
  Friend WithEvents Label65 As Label
  Friend WithEvents Label66 As Label
  Friend WithEvents TxtPhone As TextBox
  Friend WithEvents TxtMZip As TextBox
  Friend WithEvents TxtMState As TextBox
  Friend WithEvents TxtMAddr As TextBox
  Friend WithEvents TxtMCity As TextBox
  Friend WithEvents MskTxtASSN As MaskedTextBox
  Friend WithEvents TxtALName As TextBox
  Friend WithEvents Label10 As Label
  Friend WithEvents Label4 As Label
  Friend WithEvents Label2 As Label
  Friend WithEvents TxtAFName As TextBox
  Friend WithEvents TxtAInit As TextBox
  Friend WithEvents Label1 As Label
  Friend WithEvents GroupBox6 As GroupBox
  Friend WithEvents TxtSName As TextBox
  Friend WithEvents TxtName As TextBox
  Friend WithEvents LnkListNo As LinkLabel
  Friend WithEvents TxtYear As TextBox
  Friend WithEvents Label13 As Label
  Friend WithEvents TxtListNo As TextBox
  Friend WithEvents GrpType As GroupBox
  Friend WithEvents RbSU As RadioButton
  Friend WithEvents RbRE As RadioButton
  Friend WithEvents RbMV As RadioButton
  Friend WithEvents DtPckAssr As DateTimePicker
  Friend WithEvents Label54 As Label
  Friend WithEvents ChkProofE As CheckBox
  Friend WithEvents Label5 As Label
  Friend WithEvents RichTextBox1 As RichTextBox
  Friend WithEvents RichTextBox2 As RichTextBox
  Friend WithEvents ChkProofT As CheckBox
  Friend WithEvents RichTextBox3 As RichTextBox
  Friend WithEvents ChkProofA As CheckBox
  Friend WithEvents RichTextBox4 As RichTextBox
  Friend WithEvents DtPckSigned As DateTimePicker
  Friend WithEvents DtPckDob As DateTimePicker
  Friend WithEvents Label3 As Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList


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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTO222C))
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Label34 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.Label56 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.RbLocAllowed = New System.Windows.Forms.RadioButton()
    Me.RbLocDisallowed = New System.Windows.Forms.RadioButton()
    Me.TxtLocDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbEBCAllowed = New System.Windows.Forms.RadioButton()
    Me.RbEBCDisallowed = New System.Windows.Forms.RadioButton()
    Me.TxtEBCDisallowReason = New System.Windows.Forms.TextBox()
    Me.RbFBCAllowed = New System.Windows.Forms.RadioButton()
    Me.RbFBCDisallowed = New System.Windows.Forms.RadioButton()
    Me.TxtFBCDisallowReason = New System.Windows.Forms.TextBox()
    Me.GrpType = New System.Windows.Forms.GroupBox()
    Me.RbSU = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbMV = New System.Windows.Forms.RadioButton()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.TxtSName = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.MskTxtASSN = New System.Windows.Forms.MaskedTextBox()
    Me.TxtALName = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAFName = New System.Windows.Forms.TextBox()
    Me.TxtAInit = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label62 = New System.Windows.Forms.Label()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.Label66 = New System.Windows.Forms.Label()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.TxtMZip = New System.Windows.Forms.TextBox()
    Me.TxtMState = New System.Windows.Forms.TextBox()
    Me.TxtMAddr = New System.Windows.Forms.TextBox()
    Me.TxtMCity = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.ChkProofE = New System.Windows.Forms.CheckBox()
    Me.DtPckAssr = New System.Windows.Forms.DateTimePicker()
    Me.Label54 = New System.Windows.Forms.Label()
    Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
    Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
    Me.ChkProofT = New System.Windows.Forms.CheckBox()
    Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
    Me.RichTextBox4 = New System.Windows.Forms.RichTextBox()
    Me.ChkProofA = New System.Windows.Forms.CheckBox()
    Me.DtPckSigned = New System.Windows.Forms.DateTimePicker()
    Me.DtPckDob = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GrpType.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "scroll.ico")
    '
    'Label34
    '
    Me.Label34.AutoSize = True
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(19, 123)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(163, 13)
    Me.Label34.TabIndex = 206
    Me.Label34.Text = "11. Additional Exemption Allowed"
    '
    'Label36
    '
    Me.Label36.AutoSize = True
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(19, 101)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(107, 13)
    Me.Label36.TabIndex = 205
    Me.Label36.Text = "10. Qualfying Income"
    '
    'CheckBox2
    '
    Me.CheckBox2.AutoSize = True
    Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.CheckBox2.Location = New System.Drawing.Point(19, 81)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(263, 17)
    Me.CheckBox2.TabIndex = 204
    Me.CheckBox2.Text = "9. Indicate Income Level: Disabled Income Level?"
    Me.CheckBox2.UseVisualStyleBackColor = True
    '
    'Label38
    '
    Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.Location = New System.Drawing.Point(325, 101)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(66, 18)
    Me.Label38.TabIndex = 202
    Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TextBox1
    '
    Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(325, 123)
    Me.TextBox1.MaxLength = 8
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(66, 20)
    Me.TextBox1.TabIndex = 200
    Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label39
    '
    Me.Label39.AutoSize = True
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.Location = New System.Drawing.Point(19, 65)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(300, 13)
    Me.Label39.TabIndex = 199
    Me.Label39.Text = "8. The Applicant is receiving the following veteran's exemption"
    '
    'Label40
    '
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(15, 175)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(141, 20)
    Me.Label40.TabIndex = 198
    Me.Label40.Text = "11. Net Assessment"
    Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'TextBox2
    '
    Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox2.Location = New System.Drawing.Point(325, 62)
    Me.TextBox2.MaxLength = 8
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(66, 20)
    Me.TextBox2.TabIndex = 197
    Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label41
    '
    Me.Label41.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label41.Location = New System.Drawing.Point(50, 22)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(134, 18)
    Me.Label41.TabIndex = 195
    Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label42
    '
    Me.Label42.AutoSize = True
    Me.Label42.Location = New System.Drawing.Point(13, 23)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(31, 13)
    Me.Label42.TabIndex = 196
    Me.Label42.Text = "Type"
    '
    'DateTimePicker1
    '
    Me.DateTimePicker1.Checked = False
    Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DateTimePicker1.Location = New System.Drawing.Point(154, 460)
    Me.DateTimePicker1.Name = "DateTimePicker1"
    Me.DateTimePicker1.ShowCheckBox = True
    Me.DateTimePicker1.Size = New System.Drawing.Size(100, 20)
    Me.DateTimePicker1.TabIndex = 181
    '
    'Label43
    '
    Me.Label43.Location = New System.Drawing.Point(24, 464)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(124, 16)
    Me.Label43.TabIndex = 180
    Me.Label43.Text = "Date Assessor Signed"
    '
    'Label44
    '
    Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.Location = New System.Drawing.Point(772, 23)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(15, 18)
    Me.Label44.TabIndex = 174
    Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label45
    '
    Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(652, 23)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(114, 18)
    Me.Label45.TabIndex = 173
    Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label46
    '
    Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(418, 23)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(228, 18)
    Me.Label46.TabIndex = 2
    Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label47
    '
    Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(352, 23)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(33, 18)
    Me.Label47.TabIndex = 1
    Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label49
    '
    Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(247, 22)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(56, 18)
    Me.Label49.TabIndex = 0
    Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TextBox3)
    Me.GroupBox2.Controls.Add(Me.RadioButton1)
    Me.GroupBox2.Controls.Add(Me.RadioButton2)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(19, 386)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(479, 66)
    Me.GroupBox2.TabIndex = 8
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Assessor Affidavit"
    '
    'TextBox3
    '
    Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox3.Location = New System.Drawing.Point(270, 40)
    Me.TextBox3.MaxLength = 30
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(180, 20)
    Me.TextBox3.TabIndex = 167
    '
    'RadioButton1
    '
    Me.RadioButton1.AutoSize = True
    Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton1.Location = New System.Drawing.Point(8, 40)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(246, 17)
    Me.RadioButton1.TabIndex = 2
    Me.RadioButton1.Text = "This claim is disallowed for the following reason"
    '
    'RadioButton2
    '
    Me.RadioButton2.AutoSize = True
    Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RadioButton2.Location = New System.Drawing.Point(8, 16)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(442, 17)
    Me.RadioButton2.TabIndex = 0
    Me.RadioButton2.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'Label50
    '
    Me.Label50.AutoSize = True
    Me.Label50.Location = New System.Drawing.Point(201, 25)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(40, 13)
    Me.Label50.TabIndex = 155
    Me.Label50.Text = "List No"
    '
    'Label52
    '
    Me.Label52.AutoSize = True
    Me.Label52.Location = New System.Drawing.Point(756, -1)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(44, 13)
    Me.Label52.TabIndex = 154
    Me.Label52.Text = "(Middle)"
    '
    'Label53
    '
    Me.Label53.AutoSize = True
    Me.Label53.Location = New System.Drawing.Point(651, -1)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(32, 13)
    Me.Label53.TabIndex = 153
    Me.Label53.Text = "(First)"
    '
    'Label56
    '
    Me.Label56.AutoSize = True
    Me.Label56.Location = New System.Drawing.Point(415, 2)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(64, 13)
    Me.Label56.TabIndex = 152
    Me.Label56.Text = "Name (Last)"
    '
    'Label57
    '
    Me.Label57.AutoSize = True
    Me.Label57.Location = New System.Drawing.Point(315, 24)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(29, 13)
    Me.Label57.TabIndex = 150
    Me.Label57.Text = "Year"
    '
    'RbLocAllowed
    '
    Me.RbLocAllowed.AutoSize = True
    Me.RbLocAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLocAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbLocAllowed.Name = "RbLocAllowed"
    Me.RbLocAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbLocAllowed.TabIndex = 0
    Me.RbLocAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'RbLocDisallowed
    '
    Me.RbLocDisallowed.AutoSize = True
    Me.RbLocDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLocDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbLocDisallowed.Name = "RbLocDisallowed"
    Me.RbLocDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbLocDisallowed.TabIndex = 2
    Me.RbLocDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'TxtLocDisallowReason
    '
    Me.TxtLocDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLocDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtLocDisallowReason.MaxLength = 30
    Me.TxtLocDisallowReason.Name = "TxtLocDisallowReason"
    Me.TxtLocDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtLocDisallowReason.TabIndex = 167
    '
    'RbEBCAllowed
    '
    Me.RbEBCAllowed.AutoSize = True
    Me.RbEBCAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEBCAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbEBCAllowed.Name = "RbEBCAllowed"
    Me.RbEBCAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbEBCAllowed.TabIndex = 0
    Me.RbEBCAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'RbEBCDisallowed
    '
    Me.RbEBCDisallowed.AutoSize = True
    Me.RbEBCDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEBCDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbEBCDisallowed.Name = "RbEBCDisallowed"
    Me.RbEBCDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbEBCDisallowed.TabIndex = 2
    Me.RbEBCDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'TxtEBCDisallowReason
    '
    Me.TxtEBCDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtEBCDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtEBCDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtEBCDisallowReason.MaxLength = 30
    Me.TxtEBCDisallowReason.Name = "TxtEBCDisallowReason"
    Me.TxtEBCDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtEBCDisallowReason.TabIndex = 167
    '
    'RbFBCAllowed
    '
    Me.RbFBCAllowed.AutoSize = True
    Me.RbFBCAllowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFBCAllowed.Location = New System.Drawing.Point(8, 16)
    Me.RbFBCAllowed.Name = "RbFBCAllowed"
    Me.RbFBCAllowed.Size = New System.Drawing.Size(442, 17)
    Me.RbFBCAllowed.TabIndex = 0
    Me.RbFBCAllowed.Text = "I am satified that the above name applicant meet all the necessary statutory requ" &
    "irements"
    '
    'RbFBCDisallowed
    '
    Me.RbFBCDisallowed.AutoSize = True
    Me.RbFBCDisallowed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbFBCDisallowed.Location = New System.Drawing.Point(8, 40)
    Me.RbFBCDisallowed.Name = "RbFBCDisallowed"
    Me.RbFBCDisallowed.Size = New System.Drawing.Size(246, 17)
    Me.RbFBCDisallowed.TabIndex = 2
    Me.RbFBCDisallowed.Text = "This claim is disallowed for the following reason"
    '
    'TxtFBCDisallowReason
    '
    Me.TxtFBCDisallowReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFBCDisallowReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFBCDisallowReason.Location = New System.Drawing.Point(270, 40)
    Me.TxtFBCDisallowReason.MaxLength = 30
    Me.TxtFBCDisallowReason.Name = "TxtFBCDisallowReason"
    Me.TxtFBCDisallowReason.Size = New System.Drawing.Size(180, 20)
    Me.TxtFBCDisallowReason.TabIndex = 167
    '
    'GrpType
    '
    Me.GrpType.Controls.Add(Me.RbSU)
    Me.GrpType.Controls.Add(Me.RbRE)
    Me.GrpType.Controls.Add(Me.RbMV)
    Me.GrpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpType.Location = New System.Drawing.Point(21, 24)
    Me.GrpType.Name = "GrpType"
    Me.GrpType.Size = New System.Drawing.Size(325, 49)
    Me.GrpType.TabIndex = 1
    Me.GrpType.TabStop = False
    Me.GrpType.Text = "Bill Type"
    '
    'RbSU
    '
    Me.RbSU.AutoSize = True
    Me.RbSU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSU.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSU.Location = New System.Drawing.Point(196, 20)
    Me.RbSU.Name = "RbSU"
    Me.RbSU.Size = New System.Drawing.Size(108, 17)
    Me.RbSU.TabIndex = 3
    Me.RbSU.Text = "Supplemental MV"
    '
    'RbRE
    '
    Me.RbRE.AutoSize = True
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(12, 16)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(80, 17)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'RbMV
    '
    Me.RbMV.AutoSize = True
    Me.RbMV.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbMV.Location = New System.Drawing.Point(100, 18)
    Me.RbMV.Name = "RbMV"
    Me.RbMV.Size = New System.Drawing.Size(90, 17)
    Me.RbMV.TabIndex = 2
    Me.RbMV.Text = "Motor Vehicle"
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(357, 40)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(44, 13)
    Me.LnkListNo.TabIndex = 145
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(514, 36)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 143
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(473, 36)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(35, 17)
    Me.Label13.TabIndex = 144
    Me.Label13.Text = "Year"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(411, 36)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 20)
    Me.TxtListNo.TabIndex = 142
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.TxtSName)
    Me.GroupBox6.Controls.Add(Me.TxtName)
    Me.GroupBox6.Location = New System.Drawing.Point(564, 26)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(241, 47)
    Me.GroupBox6.TabIndex = 172
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Copy && Paste as needed"
    '
    'TxtSName
    '
    Me.TxtSName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtSName.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtSName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSName.ForeColor = System.Drawing.Color.Navy
    Me.TxtSName.Location = New System.Drawing.Point(6, 30)
    Me.TxtSName.MaxLength = 20
    Me.TxtSName.Name = "TxtSName"
    Me.TxtSName.ReadOnly = True
    Me.TxtSName.Size = New System.Drawing.Size(228, 13)
    Me.TxtSName.TabIndex = 172
    Me.TxtSName.TabStop = False
    '
    'TxtName
    '
    Me.TxtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.ForeColor = System.Drawing.Color.Navy
    Me.TxtName.Location = New System.Drawing.Point(6, 16)
    Me.TxtName.MaxLength = 20
    Me.TxtName.Name = "TxtName"
    Me.TxtName.ReadOnly = True
    Me.TxtName.Size = New System.Drawing.Size(228, 13)
    Me.TxtName.TabIndex = 171
    Me.TxtName.TabStop = False
    '
    'MskTxtASSN
    '
    Me.MskTxtASSN.Location = New System.Drawing.Point(425, 116)
    Me.MskTxtASSN.Mask = "000-00-0000"
    Me.MskTxtASSN.Name = "MskTxtASSN"
    Me.MskTxtASSN.Size = New System.Drawing.Size(71, 20)
    Me.MskTxtASSN.TabIndex = 176
    Me.MskTxtASSN.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
    '
    'TxtALName
    '
    Me.TxtALName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtALName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtALName.Location = New System.Drawing.Point(21, 116)
    Me.TxtALName.MaxLength = 20
    Me.TxtALName.Name = "TxtALName"
    Me.TxtALName.Size = New System.Drawing.Size(228, 20)
    Me.TxtALName.TabIndex = 173
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(413, 100)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(101, 13)
    Me.Label10.TabIndex = 180
    Me.Label10.Text = "Social Security No"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(359, 99)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(44, 13)
    Me.Label4.TabIndex = 179
    Me.Label4.Text = "(Middle)"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(252, 99)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(32, 13)
    Me.Label2.TabIndex = 178
    Me.Label2.Text = "(First)"
    '
    'TxtAFName
    '
    Me.TxtAFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAFName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAFName.Location = New System.Drawing.Point(255, 116)
    Me.TxtAFName.MaxLength = 10
    Me.TxtAFName.Name = "TxtAFName"
    Me.TxtAFName.Size = New System.Drawing.Size(114, 20)
    Me.TxtAFName.TabIndex = 174
    '
    'TxtAInit
    '
    Me.TxtAInit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAInit.Location = New System.Drawing.Point(375, 116)
    Me.TxtAInit.MaxLength = 35
    Me.TxtAInit.Name = "TxtAInit"
    Me.TxtAInit.Size = New System.Drawing.Size(17, 20)
    Me.TxtAInit.TabIndex = 175
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(18, 100)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(76, 13)
    Me.Label1.TabIndex = 177
    Me.Label1.Text = "1. Name (Last)"
    '
    'Label62
    '
    Me.Label62.Location = New System.Drawing.Point(628, 145)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(74, 13)
    Me.Label62.TabIndex = 191
    Me.Label62.Text = "Phone No"
    Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label63
    '
    Me.Label63.AutoSize = True
    Me.Label63.Location = New System.Drawing.Point(587, 145)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(25, 13)
    Me.Label63.TabIndex = 190
    Me.Label63.Text = "Zip "
    '
    'Label64
    '
    Me.Label64.AutoSize = True
    Me.Label64.Location = New System.Drawing.Point(549, 145)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(32, 13)
    Me.Label64.TabIndex = 189
    Me.Label64.Text = "State"
    '
    'Label65
    '
    Me.Label65.AutoSize = True
    Me.Label65.Location = New System.Drawing.Point(349, 145)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(66, 13)
    Me.Label65.TabIndex = 188
    Me.Label65.Text = "City or Town"
    '
    'Label66
    '
    Me.Label66.AutoSize = True
    Me.Label66.Location = New System.Drawing.Point(18, 145)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(193, 13)
    Me.Label66.TabIndex = 187
    Me.Label66.Text = "Mailing Address (If different from above)"
    '
    'TxtPhone
    '
    Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhone.Location = New System.Drawing.Point(628, 161)
    Me.TxtPhone.MaxLength = 10
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(73, 20)
    Me.TxtPhone.TabIndex = 186
    '
    'TxtMZip
    '
    Me.TxtMZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMZip.Location = New System.Drawing.Point(582, 161)
    Me.TxtMZip.MaxLength = 5
    Me.TxtMZip.Name = "TxtMZip"
    Me.TxtMZip.Size = New System.Drawing.Size(40, 20)
    Me.TxtMZip.TabIndex = 185
    '
    'TxtMState
    '
    Me.TxtMState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMState.Location = New System.Drawing.Point(552, 161)
    Me.TxtMState.MaxLength = 2
    Me.TxtMState.Name = "TxtMState"
    Me.TxtMState.Size = New System.Drawing.Size(24, 20)
    Me.TxtMState.TabIndex = 184
    '
    'TxtMAddr
    '
    Me.TxtMAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMAddr.Location = New System.Drawing.Point(21, 161)
    Me.TxtMAddr.MaxLength = 40
    Me.TxtMAddr.Name = "TxtMAddr"
    Me.TxtMAddr.Size = New System.Drawing.Size(325, 20)
    Me.TxtMAddr.TabIndex = 182
    '
    'TxtMCity
    '
    Me.TxtMCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMCity.Location = New System.Drawing.Point(352, 161)
    Me.TxtMCity.MaxLength = 25
    Me.TxtMCity.Name = "TxtMCity"
    Me.TxtMCity.Size = New System.Drawing.Size(191, 20)
    Me.TxtMCity.TabIndex = 183
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(37, 453)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(80, 16)
    Me.Label5.TabIndex = 193
    Me.Label5.Text = "Date Signed"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'ChkProofE
    '
    Me.ChkProofE.AutoSize = True
    Me.ChkProofE.Location = New System.Drawing.Point(21, 203)
    Me.ChkProofE.Name = "ChkProofE"
    Me.ChkProofE.Size = New System.Drawing.Size(15, 14)
    Me.ChkProofE.TabIndex = 194
    Me.ChkProofE.UseVisualStyleBackColor = True
    '
    'DtPckAssr
    '
    Me.DtPckAssr.Checked = False
    Me.DtPckAssr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAssr.Location = New System.Drawing.Point(174, 489)
    Me.DtPckAssr.Name = "DtPckAssr"
    Me.DtPckAssr.ShowCheckBox = True
    Me.DtPckAssr.Size = New System.Drawing.Size(100, 20)
    Me.DtPckAssr.TabIndex = 195
    '
    'Label54
    '
    Me.Label54.Location = New System.Drawing.Point(44, 493)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(124, 16)
    Me.Label54.TabIndex = 196
    Me.Label54.Text = "Date Assessor Signed"
    '
    'RichTextBox1
    '
    Me.RichTextBox1.BackColor = System.Drawing.SystemColors.Control
    Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.RichTextBox1.Location = New System.Drawing.Point(54, 203)
    Me.RichTextBox1.Name = "RichTextBox1"
    Me.RichTextBox1.ReadOnly = True
    Me.RichTextBox1.Size = New System.Drawing.Size(361, 32)
    Me.RichTextBox1.TabIndex = 197
    Me.RichTextBox1.TabStop = False
    Me.RichTextBox1.Text = "Proof of eligibility, in accordance with applicable federal regulations, to recei" &
    "ve Permanent Total Disability benefits under Social Security,"
    '
    'RichTextBox2
    '
    Me.RichTextBox2.BackColor = System.Drawing.SystemColors.Control
    Me.RichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.RichTextBox2.Location = New System.Drawing.Point(54, 278)
    Me.RichTextBox2.Name = "RichTextBox2"
    Me.RichTextBox2.ReadOnly = True
    Me.RichTextBox2.Size = New System.Drawing.Size(454, 76)
    Me.RichTextBox2.TabIndex = 199
    Me.RichTextBox2.TabStop = False
    Me.RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
    '
    'ChkProofT
    '
    Me.ChkProofT.AutoSize = True
    Me.ChkProofT.Location = New System.Drawing.Point(21, 278)
    Me.ChkProofT.Name = "ChkProofT"
    Me.ChkProofT.Size = New System.Drawing.Size(15, 14)
    Me.ChkProofT.TabIndex = 198
    Me.ChkProofT.UseVisualStyleBackColor = True
    '
    'RichTextBox3
    '
    Me.RichTextBox3.BackColor = System.Drawing.SystemColors.Control
    Me.RichTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.RichTextBox3.Location = New System.Drawing.Point(54, 241)
    Me.RichTextBox3.Name = "RichTextBox3"
    Me.RichTextBox3.ReadOnly = True
    Me.RichTextBox3.Size = New System.Drawing.Size(400, 32)
    Me.RichTextBox3.TabIndex = 200
    Me.RichTextBox3.TabStop = False
    Me.RichTextBox3.Text = "If the applicant has not been engaged in employment covered by Social Security an" &
    "d accordingly has not qualified for benefits thereunder must provide:"
    '
    'RichTextBox4
    '
    Me.RichTextBox4.BackColor = System.Drawing.SystemColors.Control
    Me.RichTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.RichTextBox4.Location = New System.Drawing.Point(54, 356)
    Me.RichTextBox4.Name = "RichTextBox4"
    Me.RichTextBox4.ReadOnly = True
    Me.RichTextBox4.Size = New System.Drawing.Size(442, 59)
    Me.RichTextBox4.TabIndex = 201
    Me.RichTextBox4.TabStop = False
    Me.RichTextBox4.Text = resources.GetString("RichTextBox4.Text")
    '
    'ChkProofA
    '
    Me.ChkProofA.AutoSize = True
    Me.ChkProofA.Location = New System.Drawing.Point(21, 356)
    Me.ChkProofA.Name = "ChkProofA"
    Me.ChkProofA.Size = New System.Drawing.Size(15, 14)
    Me.ChkProofA.TabIndex = 202
    Me.ChkProofA.UseVisualStyleBackColor = True
    '
    'DtPckSigned
    '
    Me.DtPckSigned.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckSigned.Location = New System.Drawing.Point(174, 447)
    Me.DtPckSigned.Name = "DtPckSigned"
    Me.DtPckSigned.Size = New System.Drawing.Size(88, 20)
    Me.DtPckSigned.TabIndex = 203
    '
    'DtPckDob
    '
    Me.DtPckDob.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDob.Location = New System.Drawing.Point(524, 116)
    Me.DtPckDob.Name = "DtPckDob"
    Me.DtPckDob.Size = New System.Drawing.Size(88, 20)
    Me.DtPckDob.TabIndex = 205
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(532, 100)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 204
    Me.Label3.Text = "Date Of Birth"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'FrmTO222C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(810, 586)
    Me.Controls.Add(Me.DtPckDob)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckSigned)
    Me.Controls.Add(Me.ChkProofA)
    Me.Controls.Add(Me.RichTextBox4)
    Me.Controls.Add(Me.RichTextBox3)
    Me.Controls.Add(Me.RichTextBox2)
    Me.Controls.Add(Me.ChkProofT)
    Me.Controls.Add(Me.RichTextBox1)
    Me.Controls.Add(Me.DtPckAssr)
    Me.Controls.Add(Me.Label54)
    Me.Controls.Add(Me.ChkProofE)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label62)
    Me.Controls.Add(Me.Label63)
    Me.Controls.Add(Me.Label64)
    Me.Controls.Add(Me.Label65)
    Me.Controls.Add(Me.Label66)
    Me.Controls.Add(Me.TxtPhone)
    Me.Controls.Add(Me.TxtMZip)
    Me.Controls.Add(Me.TxtMState)
    Me.Controls.Add(Me.TxtMAddr)
    Me.Controls.Add(Me.TxtMCity)
    Me.Controls.Add(Me.MskTxtASSN)
    Me.Controls.Add(Me.TxtALName)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtAFName)
    Me.Controls.Add(Me.TxtAInit)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.GrpType)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTO222C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GrpType.ResumeLayout(False)
    Me.GrpType.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTO222C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyTXOPMD1 = New TXOPMD1.MyData(myDBConnect)
    MyTXMVD = New TXMVD.MyData(myDBConnect)
    MyTXREAL = New TXREAL.MyData(myDBConnect)
    MyTXSUPP = New TXSupp.MyData(myDBConnect)


    LoadScrn = True
    TxtListNo.Focus()
    MyFrmTO222.TBarNew.Enabled = False
    MyFrmTO222.TBarSave.Enabled = True


    AddMode = False
    MyFrmTO222.TBarPrint.Enabled = True
    MyFrmTO222.TBarBlank.Enabled = True

    If WrkListNo > 0 Then
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      Select Case WrkType
        Case "R"
          RbRE.Checked = True
          RbMV.Enabled = False
          RbSU.Enabled = False

        Case "M"
          RbMV.Checked = True
          RbRE.Enabled = False
          RbSU.Enabled = False
        Case "S"
          RbSU.Checked = True
          RbRE.Enabled = False
          RbMV.Enabled = False
      End Select
      TxtYear.ReadOnly = True
      DtPckSigned.Value = Date.Today
      DtPckAssr.Value = Date.Today
      MyTXOPMD1.GetOneRecordP(WrkListNo, WrkType, WrkYear)
      If MyTXOPMD1.RecordNotFound Then
        MyFrmTO222.TBarNew.Enabled = False
        MyFrmTO222.TBarSave.Enabled = False
        MyFrmTO222.TBarDelete.Enabled = False
        MyFrmTO222.TBarPrint.Enabled = False

        Me.ErrProv.SetError(TxtListNo, "Record not found")
        Exit Sub
      End If

      With MyTXOPMD1
        'Applicant
        TxtListNo.Text = ._LISTNO
        Select Case Trim(._TYPE)
          Case "R"
            GetTXREAL()
            RbRE.Checked = True

          Case "M"
            GetTXMVD()
            RbMV.Checked = True
          Case "S"
            GetTXSUPP()
            RbSU.Checked = True
        End Select
        TxtYear.Text = ._YEAR
        TxtALName.Text = Trim(._ALNAME)
        TxtAFName.Text = Trim(._AFNAME)
        TxtAInit.Text = Trim(._AINIT)
        If ._ASSN > 0 Then
          MskTxtASSN.Text = Format(._ASSN, "000000000")
        End If

        TxtMAddr.Text = Trim(._MADDR)
        TxtMCity.Text = Trim(._MCITY)
        TxtMState.Text = Trim(._MSTATE)
        If ._MZIP > 0 Then
          TxtMZip.Text = Format(._MZIP, "00000")
        End If

        ChkProofE.Checked = False
        If Trim(._PROOFE) = "Y" Then
          ChkProofE.Checked = True
        End If
        ChkProofT.Checked = False
        If Trim(._PROOFT) = "Y" Then
          ChkProofT.Checked = True
        End If
        ChkProofA.Checked = False
        If Trim(._PROOFA) = "Y" Then
          ChkProofA.Checked = True
        End If
        DtPckDob.Value = MyUtils.GetDBDate(._ADOB)
        DtPckSigned.Value = MyUtils.GetDBDate(._DTSIGN)
        If ._PHONE > 0 Then
          TxtPhone.Text = ._PHONE
        End If


        If ._DTASSR > 0 Then
          DtPckAssr.Value = MyUtils.GetDBDate(._DTASSR)
          DtPckAssr.Checked = True
        End If
      End With


    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      MyFrmTO222.TBarDelete.Enabled = False
    End If

    LoadScrn = False

  End Sub

  Private Sub FrmTO222C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTO222.TBarNew.Enabled = True
    MyFrmTO222.TBarSave.Enabled = False
    MyFrmTO222.TBarDelete.Enabled = False
    MyFrmTO222.TBarPrint.Enabled = False
    MyFrmTO222.TBarBlank.Enabled = False

    MyFrmTO222B.FormatGrid()
    MyFrmTO222B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXOPMD1.DeleteOneRecordP()


  End Sub
  Public Sub SaveData()
    Dim WrkDevlt As String
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkDevlt = ""
    MyTXOPMD1.GetOneRecordP(WrkListNo, WrkType, MyUtils.CnvSng(TxtYear.Text))
    If AddMode Then
      If Not MyTXOPMD1.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXOPMD1.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MoveToFile()
        MyTXOPMD1.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If




    Me.Close()
  End Sub
  Private Sub MoveToFile()
    With MyTXOPMD1
      'Applicant
      ._LISTNO = MyUtils.CnvSng(TxtListNo.Text)
      If RbRE.Checked Then
        ._TYPE = "R"
      End If

      If RbMV.Checked Then
        ._TYPE = "M"
      End If
      If RbSU.Checked Then
        ._TYPE = "S"
      End If
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
      ._ALNAME = TxtALName.Text
      ._AFNAME = TxtAFName.Text
      ._AINIT = TxtAInit.Text
      ._ASSN = Format(MyUtils.CnvSng(MskTxtASSN.Text), "000000000")

      ._MADDR = TxtMAddr.Text
      ._MCITY = TxtMCity.Text
      ._MSTATE = TxtMState.Text
      ._MZIP = MyUtils.CnvSng(TxtMZip.Text)

      If ChkProofE.Checked Then
        ._PROOFE = "Y"
      Else
        ._PROOFE = "N"
      End If
      If ChkProofT.Checked Then
        ._PROOFT = "Y"
      Else
        ._PROOFT = "N"
      End If
      If ChkProofA.Checked Then
        ._PROOFA = "Y"
      Else
        ._PROOFA = "N"
      End If
      ._ADOB = MyUtils.SetDBDate(DtPckDob.Value)
      ._DTSIGN = MyUtils.SetDBDate(DtPckSigned.Value)
      ._PHONE = MyUtils.CnvSng(TxtPhone.Text)

      'Assessor

      If DtPckAssr.Checked Then
        ._DTASSR = MyUtils.SetDBDate(DtPckAssr.Value)
      Else
        ._DTASSR = 0
      End If
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
      ErrorField(I) = "listno"
      ErrorMsg(I) = "List Number is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtYear.Text) = 0 Then
      ErrorField(I) = "year"
      ErrorMsg(I) = "Year is required"
      I = I + 1
    End If

    If TxtALName.Text = String.Empty Then
      ErrorField(I) = "alname"
      ErrorMsg(I) = "Last Name is required"
      I = I + 1
    End If

    If TxtAFName.Text = String.Empty Then
      ErrorField(I) = "afname"
      ErrorMsg(I) = "First Name is required"
      I = I + 1
    End If

    If MskTxtASSN.Text = String.Empty Then
      ErrorField(I) = "assn"
      ErrorMsg(I) = "SSN is required"
      I = I + 1
    End If



    If ChkProofE.Checked = False And ChkProofT.Checked = False And ChkProofA.Checked = False Then
      ErrorField(I) = "Proof"
      ErrorMsg(I) = "Please check one of the boxes for eligibility"
      I = I + 1

    End If




    If Not DtPckAssr.Checked Then
      ErrorField(I) = "assr"
      ErrorMsg(I) = "Assessor signed date is required"
      I = I + 1

    End If


  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtYear, "")
    ErrProv.SetError(TxtALName, "")
    ErrProv.SetError(TxtAFName, "")
    ErrProv.SetError(ChkProofE, "")
    ErrProv.SetError(MskTxtASSN, "")

    ErrProv.SetError(DtPckAssr, "")
    ErrProv.SetError(DtPckAssr, "")


    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "listno"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case "year"
          ErrProv.SetError(TxtYear, ErrorMsg(I))
        Case "alname"
          ErrProv.SetError(TxtALName, ErrorMsg(I))
        Case "afname"
          ErrProv.SetError(TxtAFName, ErrorMsg(I))
        Case "assn"
          ErrProv.SetError(MskTxtASSN, ErrorMsg(I))


        Case "proof"
          ErrProv.SetError(ChkProofE, ErrorMsg(I))

        Case "assr"
          ErrProv.SetError(DtPckAssr, ErrorMsg(I))

        Case ""
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTO222C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTO222.SbpScreen.Text = "TO222C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub TxtListNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    If TxtListNo.ReadOnly Then Exit Sub

    GetListNo()
  End Sub
  Private Sub TxtYear_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    If TxtListNo.ReadOnly Then Exit Sub

    GetTXOPMD1()

  End Sub
  Public Sub GetListNo()
    If RbRE.Checked Then
      GetTXREAL()
      WrkType = "R"
    End If

    If RbMV.Checked Then
      GetTXMVD()
      WrkType = "M"
    End If
    If RbSU.Checked Then
      GetTXSUPP()
      WrkType = "S"
    End If
  End Sub


  Public Sub GetTXREAL()

    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXREAL.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXREAL.RecordNotFound Then Exit Sub

    With MyTXREAL
      'Populate First & Last Name
      TxtName.Text = Trim(._NAME)
      TxtSName.Text = Trim(._SNAME)
      Pos = InStr(TxtName.Text, " ")
      Pos2 = InStr(Pos + 1, TxtName.Text, " ")
      If Pos > 0 Then
        TxtALName.Text = Mid(TxtName.Text, 1, Pos - 1)
        If Pos2 > 0 Then
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, Pos2 - Pos)
          If Mid(TxtName.Text, Pos2 + 1, 1) <> "&" Then
            TxtAInit.Text = Mid(TxtName.Text, Pos2 + 1, 1)
          End If
        Else
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, 30)
        End If
      End If

      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address


      TxtMAddr.Text = Trim(._ADD1)
      TxtMCity.Text = Trim(._CITY)
      TxtMState.Text = Trim(._STATE)
      TxtMZip.Text = Format(._ZIP5, "00000")

    End With

  End Sub

  Public Sub GetTXMVD()
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXMVD.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXMVD.RecordNotFound Then Exit Sub

    With MyTXMVD
      'Populate First & Last Name
      TxtName.Text = Trim(._NAME)
      TxtSName.Text = Trim(._SNAME)
      Pos = InStr(TxtName.Text, " ")
      Pos2 = InStr(Pos + 1, TxtName.Text, " ")
      If Pos > 0 Then
        TxtALName.Text = Mid(TxtName.Text, 1, Pos - 1)
        If Pos2 > 0 Then
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, Pos2 - Pos)
          If Mid(TxtName.Text, Pos2 + 1, 1) <> "&" Then
            TxtAInit.Text = Mid(TxtName.Text, Pos2 + 1, 1)
          End If
        Else
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, 30)
        End If
      End If

      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address
      TxtMAddr.Text = Trim(._ADD1)
      TxtMCity.Text = Trim(._CITY)
      TxtMState.Text = Trim(._STATE)
      TxtMZip.Text = Format(._ZIP5, "00000")
    End With

  End Sub
  Public Sub GetTXSUPP()
    Dim Pos As Integer
    Dim Pos2 As Integer

    MyTXSUPP.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text))
    If MyTXSUPP.RecordNotFound Then Exit Sub

    With MyTXSUPP
      'Populate First & Last Name
      TxtName.Text = Trim(._NAME)
      TxtSName.Text = Trim(._SNAME)
      Pos = InStr(TxtName.Text, " ")
      Pos2 = InStr(Pos + 1, TxtName.Text, " ")
      If Pos > 0 Then
        TxtALName.Text = Mid(TxtName.Text, 1, Pos - 1)
        If Pos2 > 0 Then
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, Pos2 - Pos)
          If Mid(TxtName.Text, Pos2 + 1, 1) <> "&" Then
            TxtAInit.Text = Mid(TxtName.Text, Pos2 + 1, 1)
          End If
        Else
          TxtAFName.Text = Mid(TxtName.Text, Pos + 1, 30)
        End If
      End If

      TxtALName.Text = Mid(TxtALName.Text, 1, 20)
      TxtAFName.Text = Mid(TxtAFName.Text, 1, 10)
      'Populate Property & Mailing Address
      TxtMAddr.Text = Trim(._ADD1)
      TxtMCity.Text = Trim(._CITY)
      TxtMState.Text = Trim(._STATE)
      TxtMZip.Text = Format(._ZIP5, "00000")
    End With

  End Sub

  Private Sub GetTXOPMD1()
    Dim pListNo As Integer
    pListNo = MyUtils.CnvSng(TxtListNo.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    MyTXOPMD1.GetOneRecordP(pListNo, WrkType, WrkYear - 1)
    If MyTXOPMD1.RecordNotFound Then
      MyTXOPMD1.GetOneRecordP(pListNo, WrkType, WrkYear - 2)
      If MyTXOPMD1.RecordNotFound Then
        MyFrmTO222.TBarDelete.Enabled = False
        LoadScrn = False
        Exit Sub
      End If
    End If
    'Get data from previous year
    With MyTXOPMD1
      TxtALName.Text = Trim(._ALNAME)
      TxtAFName.Text = Trim(._AFNAME)
      TxtAInit.Text = Trim(._AINIT)
      If ._ASSN > 0 Then
        MskTxtASSN.Text = Format(._ASSN, "000000000")
      End If



      If ._PHONE > 0 Then
        TxtPhone.Text = ._PHONE
      End If
    End With
  End Sub

  Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

  End Sub

  Private Sub LnkListNo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    If RbRE.Checked Then
      MyFrmListRealC = New FrmListRealC
      MyFrmListRealC.MdiParent = Me.ParentForm
      MyFrmListRealC.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListRealC.Show()
    End If

    If RbMV.Checked Then
      MyFrmListMVD = New FrmListMVD
      MyFrmListMVD.MdiParent = Me.ParentForm
      MyFrmListMVD.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListMVD.Show()
    End If
    If RbSU.Checked Then
      MyFrmListSupp = New FrmListSupp
      MyFrmListSupp.MdiParent = Me.ParentForm
      MyFrmListSupp.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      MyFrmListSupp.Show()
    End If
  End Sub

End Class






