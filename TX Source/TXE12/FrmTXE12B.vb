Public Class FrmTXE12B
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
Friend WithEvents TTp1 As System.Windows.Forms.ToolTip
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
Friend WithEvents LblGLYear As System.Windows.Forms.Label
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents ChkOmitMail As System.Windows.Forms.CheckBox
Friend WithEvents LnkTypes As System.Windows.Forms.LinkLabel
Friend WithEvents TxtTypes As System.Windows.Forms.TextBox
Friend WithEvents ChkOmitDelq As System.Windows.Forms.CheckBox
Friend WithEvents GrpRE As System.Windows.Forms.GroupBox
Friend WithEvents RbSelAll As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNon As System.Windows.Forms.RadioButton
Friend WithEvents RbSelNonBanks As System.Windows.Forms.RadioButton
Friend WithEvents ChkBalances As System.Windows.Forms.CheckBox
Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
Friend WithEvents TpLabels As System.Windows.Forms.TabPage
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
Friend WithEvents TxtVAdjust2 As System.Windows.Forms.TextBox
Friend WithEvents TxtVAdjust1 As System.Windows.Forms.TextBox
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
Friend WithEvents TxtHAdjust3 As System.Windows.Forms.TextBox
Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
Friend WithEvents TxtHAdjust2 As System.Windows.Forms.TextBox
Friend WithEvents TxtHAdjust1 As System.Windows.Forms.TextBox
Friend WithEvents ChkShowList As System.Windows.Forms.CheckBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents TxtMaxLen As System.Windows.Forms.TextBox
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents Rb1Across As System.Windows.Forms.RadioButton
Friend WithEvents Rb3Across As System.Windows.Forms.RadioButton
Friend WithEvents Rb2Across As System.Windows.Forms.RadioButton
Friend WithEvents TpReport As System.Windows.Forms.TabPage
Friend WithEvents TxtMsg As System.Windows.Forms.TextBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents RbReport As System.Windows.Forms.RadioButton
Friend WithEvents RbLabels As System.Windows.Forms.RadioButton
Friend WithEvents RbPaySecond As System.Windows.Forms.RadioButton
Friend WithEvents RbPayFirst As System.Windows.Forms.RadioButton
Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents ChkNewOwner As CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTXE12B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.RbSortZip = New System.Windows.Forms.RadioButton()
    Me.LblGLYear = New System.Windows.Forms.Label()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.LnkTypes = New System.Windows.Forms.LinkLabel()
    Me.TxtTypes = New System.Windows.Forms.TextBox()
    Me.ChkOmitMail = New System.Windows.Forms.CheckBox()
    Me.ChkOmitDelq = New System.Windows.Forms.CheckBox()
    Me.GrpRE = New System.Windows.Forms.GroupBox()
    Me.RbSelAll = New System.Windows.Forms.RadioButton()
    Me.RbSelNon = New System.Windows.Forms.RadioButton()
    Me.RbSelNonBanks = New System.Windows.Forms.RadioButton()
    Me.ChkBalances = New System.Windows.Forms.CheckBox()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpReport = New System.Windows.Forms.TabPage()
    Me.TxtMsg = New System.Windows.Forms.TextBox()
    Me.TpLabels = New System.Windows.Forms.TabPage()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.PictureBox8 = New System.Windows.Forms.PictureBox()
    Me.PictureBox9 = New System.Windows.Forms.PictureBox()
    Me.TxtVAdjust2 = New System.Windows.Forms.TextBox()
    Me.TxtVAdjust1 = New System.Windows.Forms.TextBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.PictureBox4 = New System.Windows.Forms.PictureBox()
    Me.PictureBox5 = New System.Windows.Forms.PictureBox()
    Me.TxtHAdjust3 = New System.Windows.Forms.TextBox()
    Me.PictureBox6 = New System.Windows.Forms.PictureBox()
    Me.TxtHAdjust2 = New System.Windows.Forms.TextBox()
    Me.TxtHAdjust1 = New System.Windows.Forms.TextBox()
    Me.ChkShowList = New System.Windows.Forms.CheckBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtMaxLen = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Rb1Across = New System.Windows.Forms.RadioButton()
    Me.Rb3Across = New System.Windows.Forms.RadioButton()
    Me.Rb2Across = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RbReport = New System.Windows.Forms.RadioButton()
    Me.RbLabels = New System.Windows.Forms.RadioButton()
    Me.RbPayFirst = New System.Windows.Forms.RadioButton()
    Me.RbPaySecond = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.ChkNewOwner = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.GrpRE.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TpReport.SuspendLayout()
    Me.TpLabels.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'ImageList1
    '
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    Me.ImageList1.Images.SetKeyName(0, "")
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbSortName)
    Me.GroupBox3.Controls.Add(Me.RbSortZip)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(518, 74)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(93, 63)
    Me.GroupBox3.TabIndex = 10
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort Order"
    '
    'RbSortName
    '
    Me.RbSortName.AutoSize = True
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 16)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(53, 17)
    Me.RbSortName.TabIndex = 0
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'RbSortZip
    '
    Me.RbSortZip.AutoSize = True
    Me.RbSortZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortZip.Location = New System.Drawing.Point(12, 36)
    Me.RbSortZip.Name = "RbSortZip"
    Me.RbSortZip.Size = New System.Drawing.Size(68, 17)
    Me.RbSortZip.TabIndex = 1
    Me.RbSortZip.Text = "Zip Code"
    '
    'LblGLYear
    '
    Me.LblGLYear.AutoSize = True
    Me.LblGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGLYear.Location = New System.Drawing.Point(17, 9)
    Me.LblGLYear.Name = "LblGLYear"
    Me.LblGLYear.Size = New System.Drawing.Size(51, 13)
    Me.LblGLYear.TabIndex = 179
    Me.LblGLYear.Text = "G/L Year"
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGLYear.Location = New System.Drawing.Point(92, 6)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(30, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'LnkTypes
    '
    Me.LnkTypes.Location = New System.Drawing.Point(14, 36)
    Me.LnkTypes.Name = "LnkTypes"
    Me.LnkTypes.Size = New System.Drawing.Size(72, 16)
    Me.LnkTypes.TabIndex = 181
    Me.LnkTypes.TabStop = True
    Me.LnkTypes.Text = "Select Types"
    '
    'TxtTypes
    '
    Me.TxtTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTypes.Location = New System.Drawing.Point(90, 32)
    Me.TxtTypes.MaxLength = 20
    Me.TxtTypes.Name = "TxtTypes"
    Me.TxtTypes.Size = New System.Drawing.Size(116, 20)
    Me.TxtTypes.TabIndex = 1
    '
    'ChkOmitMail
    '
    Me.ChkOmitMail.AutoSize = True
    Me.ChkOmitMail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitMail.Checked = True
    Me.ChkOmitMail.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkOmitMail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOmitMail.Location = New System.Drawing.Point(15, 58)
    Me.ChkOmitMail.Name = "ChkOmitMail"
    Me.ChkOmitMail.Size = New System.Drawing.Size(110, 17)
    Me.ChkOmitMail.TabIndex = 2
    Me.ChkOmitMail.Text = "Omit Mail Return?"
    '
    'ChkOmitDelq
    '
    Me.ChkOmitDelq.AutoSize = True
    Me.ChkOmitDelq.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkOmitDelq.Checked = True
    Me.ChkOmitDelq.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkOmitDelq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkOmitDelq.Location = New System.Drawing.Point(15, 74)
    Me.ChkOmitDelq.Name = "ChkOmitDelq"
    Me.ChkOmitDelq.Size = New System.Drawing.Size(112, 17)
    Me.ChkOmitDelq.TabIndex = 3
    Me.ChkOmitDelq.Text = "Omit Delinquents?"
    '
    'GrpRE
    '
    Me.GrpRE.Controls.Add(Me.RbSelAll)
    Me.GrpRE.Controls.Add(Me.RbSelNon)
    Me.GrpRE.Controls.Add(Me.RbSelNonBanks)
    Me.GrpRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpRE.Location = New System.Drawing.Point(291, 12)
    Me.GrpRE.Name = "GrpRE"
    Me.GrpRE.Size = New System.Drawing.Size(208, 84)
    Me.GrpRE.TabIndex = 6
    Me.GrpRE.TabStop = False
    Me.GrpRE.Text = "Bank Code/Bank Service"
    '
    'RbSelAll
    '
    Me.RbSelAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelAll.Location = New System.Drawing.Point(4, 56)
    Me.RbSelAll.Name = "RbSelAll"
    Me.RbSelAll.Size = New System.Drawing.Size(196, 20)
    Me.RbSelAll.TabIndex = 77
    Me.RbSelAll.Text = "All Accounts"
    '
    'RbSelNon
    '
    Me.RbSelNon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelNon.Checked = True
    Me.RbSelNon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelNon.Location = New System.Drawing.Point(4, 16)
    Me.RbSelNon.Name = "RbSelNon"
    Me.RbSelNon.Size = New System.Drawing.Size(196, 20)
    Me.RbSelNon.TabIndex = 75
    Me.RbSelNon.TabStop = True
    Me.RbSelNon.Text = "Non Escrow Accounts Only "
    '
    'RbSelNonBanks
    '
    Me.RbSelNonBanks.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSelNonBanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSelNonBanks.Location = New System.Drawing.Point(4, 36)
    Me.RbSelNonBanks.Name = "RbSelNonBanks"
    Me.RbSelNonBanks.Size = New System.Drawing.Size(196, 20)
    Me.RbSelNonBanks.TabIndex = 76
    Me.RbSelNonBanks.Text = "Non Escrow Accounts Plus Banks"
    '
    'ChkBalances
    '
    Me.ChkBalances.AutoSize = True
    Me.ChkBalances.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBalances.Checked = True
    Me.ChkBalances.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkBalances.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkBalances.Location = New System.Drawing.Point(15, 110)
    Me.ChkBalances.Name = "ChkBalances"
    Me.ChkBalances.Size = New System.Drawing.Size(187, 17)
    Me.ChkBalances.TabIndex = 5
    Me.ChkBalances.Text = "Only Balance Due greater than 0?"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TpReport)
    Me.TabControl1.Controls.Add(Me.TpLabels)
    Me.TabControl1.Location = New System.Drawing.Point(16, 143)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(605, 200)
    Me.TabControl1.TabIndex = 187
    '
    'TpReport
    '
    Me.TpReport.Controls.Add(Me.TxtMsg)
    Me.TpReport.Location = New System.Drawing.Point(4, 22)
    Me.TpReport.Name = "TpReport"
    Me.TpReport.Padding = New System.Windows.Forms.Padding(3)
    Me.TpReport.Size = New System.Drawing.Size(597, 174)
    Me.TpReport.TabIndex = 1
    Me.TpReport.Text = "Message"
    Me.TpReport.UseVisualStyleBackColor = True
    '
    'TxtMsg
    '
    Me.TxtMsg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMsg.Location = New System.Drawing.Point(3, 6)
    Me.TxtMsg.MaxLength = 2500
    Me.TxtMsg.Multiline = True
    Me.TxtMsg.Name = "TxtMsg"
    Me.TxtMsg.Size = New System.Drawing.Size(588, 172)
    Me.TxtMsg.TabIndex = 0
    '
    'TpLabels
    '
    Me.TpLabels.Controls.Add(Me.GroupBox5)
    Me.TpLabels.Controls.Add(Me.GroupBox4)
    Me.TpLabels.Controls.Add(Me.ChkShowList)
    Me.TpLabels.Controls.Add(Me.Label4)
    Me.TpLabels.Controls.Add(Me.TxtMaxLen)
    Me.TpLabels.Controls.Add(Me.GroupBox1)
    Me.TpLabels.Location = New System.Drawing.Point(4, 22)
    Me.TpLabels.Name = "TpLabels"
    Me.TpLabels.Padding = New System.Windows.Forms.Padding(3)
    Me.TpLabels.Size = New System.Drawing.Size(597, 174)
    Me.TpLabels.TabIndex = 0
    Me.TpLabels.Text = "Labels"
    Me.TpLabels.UseVisualStyleBackColor = True
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.Label1)
    Me.GroupBox5.Controls.Add(Me.Label6)
    Me.GroupBox5.Controls.Add(Me.Label10)
    Me.GroupBox5.Controls.Add(Me.PictureBox8)
    Me.GroupBox5.Controls.Add(Me.PictureBox9)
    Me.GroupBox5.Controls.Add(Me.TxtVAdjust2)
    Me.GroupBox5.Controls.Add(Me.TxtVAdjust1)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(467, 25)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(120, 154)
    Me.GroupBox5.TabIndex = 109
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Vertical  Spacing "
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.Label1.Location = New System.Drawing.Point(27, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(82, 13)
    Me.Label1.TabIndex = 92
    Me.Label1.Text = "(250 = 1 line)"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(30, 128)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(25, 13)
    Me.Label6.TabIndex = 91
    Me.Label6.Text = "2nd"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(29, 75)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(21, 13)
    Me.Label10.TabIndex = 90
    Me.Label10.Text = "1st"
    '
    'PictureBox8
    '
    Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
    Me.PictureBox8.Location = New System.Drawing.Point(61, 120)
    Me.PictureBox8.Name = "PictureBox8"
    Me.PictureBox8.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox8.TabIndex = 87
    Me.PictureBox8.TabStop = False
    '
    'PictureBox9
    '
    Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
    Me.PictureBox9.Location = New System.Drawing.Point(56, 66)
    Me.PictureBox9.Name = "PictureBox9"
    Me.PictureBox9.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox9.TabIndex = 84
    Me.PictureBox9.TabStop = False
    '
    'TxtVAdjust2
    '
    Me.TxtVAdjust2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVAdjust2.Location = New System.Drawing.Point(51, 94)
    Me.TxtVAdjust2.MaxLength = 4
    Me.TxtVAdjust2.Name = "TxtVAdjust2"
    Me.TxtVAdjust2.Size = New System.Drawing.Size(35, 20)
    Me.TxtVAdjust2.TabIndex = 83
    '
    'TxtVAdjust1
    '
    Me.TxtVAdjust1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVAdjust1.Location = New System.Drawing.Point(51, 38)
    Me.TxtVAdjust1.MaxLength = 4
    Me.TxtVAdjust1.Name = "TxtVAdjust1"
    Me.TxtVAdjust1.Size = New System.Drawing.Size(33, 20)
    Me.TxtVAdjust1.TabIndex = 81
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.Label9)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.Label7)
    Me.GroupBox4.Controls.Add(Me.PictureBox4)
    Me.GroupBox4.Controls.Add(Me.PictureBox5)
    Me.GroupBox4.Controls.Add(Me.TxtHAdjust3)
    Me.GroupBox4.Controls.Add(Me.PictureBox6)
    Me.GroupBox4.Controls.Add(Me.TxtHAdjust2)
    Me.GroupBox4.Controls.Add(Me.TxtHAdjust1)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(159, 58)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(292, 68)
    Me.GroupBox4.TabIndex = 108
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Horizontal  Spacing (Enter # of spaces needed)"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(240, 20)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(22, 13)
    Me.Label9.TabIndex = 92
    Me.Label9.Text = "3rd"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(153, 20)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(25, 13)
    Me.Label8.TabIndex = 91
    Me.Label8.Text = "2nd"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(63, 17)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(21, 13)
    Me.Label7.TabIndex = 90
    Me.Label7.Text = "1st"
    '
    'PictureBox4
    '
    Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
    Me.PictureBox4.Location = New System.Drawing.Point(242, 36)
    Me.PictureBox4.Name = "PictureBox4"
    Me.PictureBox4.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox4.TabIndex = 89
    Me.PictureBox4.TabStop = False
    '
    'PictureBox5
    '
    Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
    Me.PictureBox5.Location = New System.Drawing.Point(152, 36)
    Me.PictureBox5.Name = "PictureBox5"
    Me.PictureBox5.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox5.TabIndex = 87
    Me.PictureBox5.TabStop = False
    '
    'TxtHAdjust3
    '
    Me.TxtHAdjust3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHAdjust3.Location = New System.Drawing.Point(191, 36)
    Me.TxtHAdjust3.MaxLength = 2
    Me.TxtHAdjust3.Name = "TxtHAdjust3"
    Me.TxtHAdjust3.Size = New System.Drawing.Size(28, 20)
    Me.TxtHAdjust3.TabIndex = 86
    '
    'PictureBox6
    '
    Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
    Me.PictureBox6.Location = New System.Drawing.Point(66, 36)
    Me.PictureBox6.Name = "PictureBox6"
    Me.PictureBox6.Size = New System.Drawing.Size(23, 22)
    Me.PictureBox6.TabIndex = 84
    Me.PictureBox6.TabStop = False
    '
    'TxtHAdjust2
    '
    Me.TxtHAdjust2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHAdjust2.Location = New System.Drawing.Point(107, 36)
    Me.TxtHAdjust2.MaxLength = 2
    Me.TxtHAdjust2.Name = "TxtHAdjust2"
    Me.TxtHAdjust2.Size = New System.Drawing.Size(28, 20)
    Me.TxtHAdjust2.TabIndex = 83
    '
    'TxtHAdjust1
    '
    Me.TxtHAdjust1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtHAdjust1.Location = New System.Drawing.Point(20, 36)
    Me.TxtHAdjust1.MaxLength = 2
    Me.TxtHAdjust1.Name = "TxtHAdjust1"
    Me.TxtHAdjust1.Size = New System.Drawing.Size(28, 20)
    Me.TxtHAdjust1.TabIndex = 81
    '
    'ChkShowList
    '
    Me.ChkShowList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkShowList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkShowList.Location = New System.Drawing.Point(16, 143)
    Me.ChkShowList.Name = "ChkShowList"
    Me.ChkShowList.Size = New System.Drawing.Size(114, 17)
    Me.ChkShowList.TabIndex = 106
    Me.ChkShowList.Text = "Show List #?"
    Me.ChkShowList.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(13, 117)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 13)
    Me.Label4.TabIndex = 107
    Me.Label4.Text = "Max Field Length"
    '
    'TxtMaxLen
    '
    Me.TxtMaxLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMaxLen.Location = New System.Drawing.Point(107, 113)
    Me.TxtMaxLen.MaxLength = 2
    Me.TxtMaxLen.Name = "TxtMaxLen"
    Me.TxtMaxLen.Size = New System.Drawing.Size(28, 20)
    Me.TxtMaxLen.TabIndex = 105
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Rb1Across)
    Me.GroupBox1.Controls.Add(Me.Rb3Across)
    Me.GroupBox1.Controls.Add(Me.Rb2Across)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(10, 18)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(127, 81)
    Me.GroupBox1.TabIndex = 104
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Format"
    '
    'Rb1Across
    '
    Me.Rb1Across.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb1Across.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb1Across.Location = New System.Drawing.Point(12, 16)
    Me.Rb1Across.Name = "Rb1Across"
    Me.Rb1Across.Size = New System.Drawing.Size(102, 20)
    Me.Rb1Across.TabIndex = 0
    Me.Rb1Across.Text = "1 Across"
    '
    'Rb3Across
    '
    Me.Rb3Across.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb3Across.Checked = True
    Me.Rb3Across.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb3Across.Location = New System.Drawing.Point(12, 56)
    Me.Rb3Across.Name = "Rb3Across"
    Me.Rb3Across.Size = New System.Drawing.Size(102, 20)
    Me.Rb3Across.TabIndex = 2
    Me.Rb3Across.TabStop = True
    Me.Rb3Across.Text = "3 Across"
    '
    'Rb2Across
    '
    Me.Rb2Across.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Rb2Across.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Rb2Across.Location = New System.Drawing.Point(12, 36)
    Me.Rb2Across.Name = "Rb2Across"
    Me.Rb2Across.Size = New System.Drawing.Size(102, 20)
    Me.Rb2Across.TabIndex = 1
    Me.Rb2Across.Text = "2 Across"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.RbReport)
    Me.GroupBox2.Controls.Add(Me.RbLabels)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(518, 12)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(93, 56)
    Me.GroupBox2.TabIndex = 9
    Me.GroupBox2.TabStop = False
    '
    'RbReport
    '
    Me.RbReport.AutoSize = True
    Me.RbReport.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbReport.Checked = True
    Me.RbReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbReport.Location = New System.Drawing.Point(12, 16)
    Me.RbReport.Name = "RbReport"
    Me.RbReport.Size = New System.Drawing.Size(57, 17)
    Me.RbReport.TabIndex = 0
    Me.RbReport.TabStop = True
    Me.RbReport.Text = "Report"
    '
    'RbLabels
    '
    Me.RbLabels.AutoSize = True
    Me.RbLabels.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLabels.Location = New System.Drawing.Point(12, 36)
    Me.RbLabels.Name = "RbLabels"
    Me.RbLabels.Size = New System.Drawing.Size(56, 17)
    Me.RbLabels.TabIndex = 1
    Me.RbLabels.Text = "Labels"
    '
    'RbPayFirst
    '
    Me.RbPayFirst.AutoSize = True
    Me.RbPayFirst.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPayFirst.Checked = True
    Me.RbPayFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPayFirst.Location = New System.Drawing.Point(291, 102)
    Me.RbPayFirst.Name = "RbPayFirst"
    Me.RbPayFirst.Size = New System.Drawing.Size(88, 17)
    Me.RbPayFirst.TabIndex = 7
    Me.RbPayFirst.TabStop = True
    Me.RbPayFirst.Text = "First Payment"
    '
    'RbPaySecond
    '
    Me.RbPaySecond.AutoSize = True
    Me.RbPaySecond.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPaySecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbPaySecond.Location = New System.Drawing.Point(291, 120)
    Me.RbPaySecond.Name = "RbPaySecond"
    Me.RbPaySecond.Size = New System.Drawing.Size(106, 17)
    Me.RbPaySecond.TabIndex = 8
    Me.RbPaySecond.Text = "Second Payment"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(216, 352)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(203, 13)
    Me.Label2.TabIndex = 191
    Me.Label2.Text = "This program does NOT calculate interest"
    '
    'ChkNewOwner
    '
    Me.ChkNewOwner.AutoSize = True
    Me.ChkNewOwner.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkNewOwner.Checked = True
    Me.ChkNewOwner.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkNewOwner.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkNewOwner.Location = New System.Drawing.Point(15, 91)
    Me.ChkNewOwner.Name = "ChkNewOwner"
    Me.ChkNewOwner.Size = New System.Drawing.Size(147, 17)
    Me.ChkNewOwner.TabIndex = 4
    Me.ChkNewOwner.Text = "Only New Owners (N/O)?"
    '
    'FrmTXE12B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(626, 374)
    Me.ControlBox = False
    Me.Controls.Add(Me.ChkNewOwner)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.RbPaySecond)
    Me.Controls.Add(Me.RbPayFirst)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.ChkBalances)
    Me.Controls.Add(Me.GrpRE)
    Me.Controls.Add(Me.ChkOmitDelq)
    Me.Controls.Add(Me.ChkOmitMail)
    Me.Controls.Add(Me.LnkTypes)
    Me.Controls.Add(Me.TxtTypes)
    Me.Controls.Add(Me.LblGLYear)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.GroupBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTXE12B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GrpRE.ResumeLayout(False)
    Me.TabControl1.ResumeLayout(False)
    Me.TpReport.ResumeLayout(False)
    Me.TpReport.PerformLayout()
    Me.TpLabels.ResumeLayout(False)
    Me.TpLabels.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
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

    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    PrtReport()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmTXE12B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTXE12.SbpScreen.Text = "TXE12B"
End Sub
Private Sub FrmTXE12B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    ErrProv.SetError(TxtGLYear, "")

    Select Case ErrorField(I)
    Case "glyear"
      ErrProv.SetError(TxtGLYear, ErrorMsg(I))
    Case Nothing
      Exit Sub
    End Select
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtGLYear.Text) = 0 Then
      ErrorField(I) = "glyear"
      ErrorMsg(I) = "Invalid G/L Year"
      I = I + 1
    End If

  End Sub
Private Sub FrmTXE12B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  TxtMaxLen.Text = "35"
End Sub
Private Sub TxtMaxLen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtHAdjust1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtHAdjust2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtHAdjust3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtVAdjust1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtVAdjust2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






