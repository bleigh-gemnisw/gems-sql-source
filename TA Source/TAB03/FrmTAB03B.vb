Public Class FrmTAB03B
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
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Rb1Across As System.Windows.Forms.RadioButton
  Friend WithEvents Rb3Across As System.Windows.Forms.RadioButton
  Friend WithEvents Rb2Across As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
  Friend WithEvents TxtHAdjust3 As System.Windows.Forms.TextBox
  Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
  Friend WithEvents TxtHAdjust2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtHAdjust1 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtMaxLen As System.Windows.Forms.TextBox
  Friend WithEvents ChkShowList As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
  Friend WithEvents TxtVAdjust2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtVAdjust1 As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortZip As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtToList As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtFromList As System.Windows.Forms.TextBox
  Friend WithEvents LnkExcd As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExcd As System.Windows.Forms.TextBox
  Friend WithEvents TabCtl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpRE As System.Windows.Forms.TabPage
  Friend WithEvents TpPP As System.Windows.Forms.TabPage
  Friend WithEvents TpMV As System.Windows.Forms.TabPage
  Friend WithEvents TpSU As System.Windows.Forms.TabPage
  Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
  Friend WithEvents LnkLocal As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtLocal As System.Windows.Forms.TextBox
  Friend WithEvents LblGLYear As System.Windows.Forms.Label
  Friend WithEvents TxtAppYear As System.Windows.Forms.TextBox
  Friend WithEvents RbLocal As System.Windows.Forms.RadioButton
  Friend WithEvents RbElderly As System.Windows.Forms.RadioButton
  Friend WithEvents RbRE As System.Windows.Forms.RadioButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LblVetYear As System.Windows.Forms.Label
  Friend WithEvents TxtVetYear As System.Windows.Forms.TextBox
  Friend WithEvents LblCodes As System.Windows.Forms.Label
  Friend WithEvents BtnSelCodes As System.Windows.Forms.Button
  Friend WithEvents BtnSelBusty As System.Windows.Forms.Button
  Friend WithEvents LblBusty As System.Windows.Forms.Label
  Friend WithEvents ChkMap As System.Windows.Forms.CheckBox
  Friend WithEvents LnkExemptCd As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExemptCd As System.Windows.Forms.TextBox
  Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
  Friend WithEvents TpM35H As TabPage
  Friend WithEvents Label13 As Label
  Friend WithEvents TxtM35HAppYear As TextBox
  Friend WithEvents Label14 As Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAB03B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Rb1Across = New System.Windows.Forms.RadioButton()
    Me.Rb3Across = New System.Windows.Forms.RadioButton()
    Me.Rb2Across = New System.Windows.Forms.RadioButton()
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
    Me.TxtMaxLen = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.ChkShowList = New System.Windows.Forms.CheckBox()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.PictureBox8 = New System.Windows.Forms.PictureBox()
    Me.PictureBox9 = New System.Windows.Forms.PictureBox()
    Me.TxtVAdjust2 = New System.Windows.Forms.TextBox()
    Me.TxtVAdjust1 = New System.Windows.Forms.TextBox()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbSortName = New System.Windows.Forms.RadioButton()
    Me.RbSortZip = New System.Windows.Forms.RadioButton()
    Me.GroupBox10 = New System.Windows.Forms.GroupBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtToList = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtFromList = New System.Windows.Forms.TextBox()
    Me.LnkExcd = New System.Windows.Forms.LinkLabel()
    Me.TxtExcd = New System.Windows.Forms.TextBox()
    Me.TabCtl1 = New System.Windows.Forms.TabControl()
    Me.TpRE = New System.Windows.Forms.TabPage()
    Me.ChkMap = New System.Windows.Forms.CheckBox()
    Me.LblVetYear = New System.Windows.Forms.Label()
    Me.TxtVetYear = New System.Windows.Forms.TextBox()
    Me.LnkLocal = New System.Windows.Forms.LinkLabel()
    Me.TxtLocal = New System.Windows.Forms.TextBox()
    Me.LblGLYear = New System.Windows.Forms.Label()
    Me.TxtAppYear = New System.Windows.Forms.TextBox()
    Me.RbLocal = New System.Windows.Forms.RadioButton()
    Me.RbElderly = New System.Windows.Forms.RadioButton()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.TpPP = New System.Windows.Forms.TabPage()
    Me.LblBusty = New System.Windows.Forms.Label()
    Me.BtnSelBusty = New System.Windows.Forms.Button()
    Me.TpMV = New System.Windows.Forms.TabPage()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TpSU = New System.Windows.Forms.TabPage()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TpM35H = New System.Windows.Forms.TabPage()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtM35HAppYear = New System.Windows.Forms.TextBox()
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    Me.LblCodes = New System.Windows.Forms.Label()
    Me.BtnSelCodes = New System.Windows.Forms.Button()
    Me.LnkExemptCd = New System.Windows.Forms.LinkLabel()
    Me.TxtExemptCd = New System.Windows.Forms.TextBox()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox5.SuspendLayout()
    CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox10.SuspendLayout()
    Me.TabCtl1.SuspendLayout()
    Me.TpRE.SuspendLayout()
    Me.TpPP.SuspendLayout()
    Me.TpMV.SuspendLayout()
    Me.TpSU.SuspendLayout()
    Me.TpM35H.SuspendLayout()
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
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(76, 6)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 0
    '
    'LnkDist
    '
    Me.LnkDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkDist.Location = New System.Drawing.Point(16, 9)
    Me.LnkDist.Name = "LnkDist"
    Me.LnkDist.Size = New System.Drawing.Size(54, 20)
    Me.LnkDist.TabIndex = 68
    Me.LnkDist.TabStop = True
    Me.LnkDist.Text = "District"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Rb1Across)
    Me.GroupBox1.Controls.Add(Me.Rb3Across)
    Me.GroupBox1.Controls.Add(Me.Rb2Across)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(386, 84)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(127, 81)
    Me.GroupBox1.TabIndex = 12
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
    Me.GroupBox4.Location = New System.Drawing.Point(38, 403)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(292, 68)
    Me.GroupBox4.TabIndex = 9
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
    'TxtMaxLen
    '
    Me.TxtMaxLen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMaxLen.Location = New System.Drawing.Point(477, 178)
    Me.TxtMaxLen.MaxLength = 2
    Me.TxtMaxLen.Name = "TxtMaxLen"
    Me.TxtMaxLen.Size = New System.Drawing.Size(28, 20)
    Me.TxtMaxLen.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(383, 182)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 13)
    Me.Label4.TabIndex = 13
    Me.Label4.Text = "Max Field Length"
    '
    'ChkShowList
    '
    Me.ChkShowList.AutoSize = True
    Me.ChkShowList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkShowList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkShowList.Location = New System.Drawing.Point(383, 206)
    Me.ChkShowList.Name = "ChkShowList"
    Me.ChkShowList.Size = New System.Drawing.Size(88, 17)
    Me.ChkShowList.TabIndex = 12
    Me.ChkShowList.Text = "Show List #?"
    Me.ChkShowList.UseVisualStyleBackColor = True
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
    Me.GroupBox5.Location = New System.Drawing.Point(347, 365)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(120, 154)
    Me.GroupBox5.TabIndex = 14
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
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbSortName)
    Me.GroupBox3.Controls.Add(Me.RbSortZip)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(386, 12)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(120, 66)
    Me.GroupBox3.TabIndex = 11
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Sort Order"
    '
    'RbSortName
    '
    Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortName.Checked = True
    Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortName.Location = New System.Drawing.Point(12, 16)
    Me.RbSortName.Name = "RbSortName"
    Me.RbSortName.Size = New System.Drawing.Size(102, 20)
    Me.RbSortName.TabIndex = 0
    Me.RbSortName.TabStop = True
    Me.RbSortName.Text = "Name"
    '
    'RbSortZip
    '
    Me.RbSortZip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbSortZip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbSortZip.Location = New System.Drawing.Point(12, 36)
    Me.RbSortZip.Name = "RbSortZip"
    Me.RbSortZip.Size = New System.Drawing.Size(102, 20)
    Me.RbSortZip.TabIndex = 1
    Me.RbSortZip.Text = "Zip Code"
    '
    'GroupBox10
    '
    Me.GroupBox10.Controls.Add(Me.Label5)
    Me.GroupBox10.Controls.Add(Me.TxtToList)
    Me.GroupBox10.Controls.Add(Me.Label11)
    Me.GroupBox10.Controls.Add(Me.TxtFromList)
    Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox10.Location = New System.Drawing.Point(12, 168)
    Me.GroupBox10.Name = "GroupBox10"
    Me.GroupBox10.Size = New System.Drawing.Size(163, 46)
    Me.GroupBox10.TabIndex = 8
    Me.GroupBox10.TabStop = False
    Me.GroupBox10.Text = "List # Range"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(90, 23)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(20, 13)
    Me.Label5.TabIndex = 94
    Me.Label5.Text = "To"
    '
    'TxtToList
    '
    Me.TxtToList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtToList.Location = New System.Drawing.Point(116, 20)
    Me.TxtToList.MaxLength = 6
    Me.TxtToList.Name = "TxtToList"
    Me.TxtToList.Size = New System.Drawing.Size(43, 20)
    Me.TxtToList.TabIndex = 93
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(6, 22)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(30, 13)
    Me.Label11.TabIndex = 92
    Me.Label11.Text = "From"
    '
    'TxtFromList
    '
    Me.TxtFromList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFromList.Location = New System.Drawing.Point(41, 19)
    Me.TxtFromList.MaxLength = 6
    Me.TxtFromList.Name = "TxtFromList"
    Me.TxtFromList.Size = New System.Drawing.Size(43, 20)
    Me.TxtFromList.TabIndex = 83
    '
    'LnkExcd
    '
    Me.LnkExcd.AutoSize = True
    Me.LnkExcd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkExcd.Location = New System.Drawing.Point(9, 140)
    Me.LnkExcd.Name = "LnkExcd"
    Me.LnkExcd.Size = New System.Drawing.Size(84, 13)
    Me.LnkExcd.TabIndex = 4
    Me.LnkExcd.TabStop = True
    Me.LnkExcd.Text = "Exemption Code"
    '
    'TxtExcd
    '
    Me.TxtExcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExcd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExcd.Location = New System.Drawing.Point(110, 140)
    Me.TxtExcd.MaxLength = 3
    Me.TxtExcd.Name = "TxtExcd"
    Me.TxtExcd.Size = New System.Drawing.Size(32, 20)
    Me.TxtExcd.TabIndex = 5
    '
    'TabCtl1
    '
    Me.TabCtl1.Controls.Add(Me.TpRE)
    Me.TabCtl1.Controls.Add(Me.TpPP)
    Me.TabCtl1.Controls.Add(Me.TpMV)
    Me.TabCtl1.Controls.Add(Me.TpSU)
    Me.TabCtl1.Controls.Add(Me.TpM35H)
    Me.TabCtl1.Location = New System.Drawing.Point(12, 252)
    Me.TabCtl1.Name = "TabCtl1"
    Me.TabCtl1.SelectedIndex = 0
    Me.TabCtl1.Size = New System.Drawing.Size(497, 107)
    Me.TabCtl1.TabIndex = 10
    '
    'TpRE
    '
    Me.TpRE.Controls.Add(Me.ChkMap)
    Me.TpRE.Controls.Add(Me.LblVetYear)
    Me.TpRE.Controls.Add(Me.TxtVetYear)
    Me.TpRE.Controls.Add(Me.LnkLocal)
    Me.TpRE.Controls.Add(Me.TxtLocal)
    Me.TpRE.Controls.Add(Me.LblGLYear)
    Me.TpRE.Controls.Add(Me.TxtAppYear)
    Me.TpRE.Controls.Add(Me.RbLocal)
    Me.TpRE.Controls.Add(Me.RbElderly)
    Me.TpRE.Controls.Add(Me.RbRE)
    Me.TpRE.Location = New System.Drawing.Point(4, 22)
    Me.TpRE.Name = "TpRE"
    Me.TpRE.Padding = New System.Windows.Forms.Padding(3)
    Me.TpRE.Size = New System.Drawing.Size(489, 81)
    Me.TpRE.TabIndex = 0
    Me.TpRE.Text = "Real Estate"
    Me.TpRE.UseVisualStyleBackColor = True
    '
    'ChkMap
    '
    Me.ChkMap.AutoSize = True
    Me.ChkMap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkMap.Location = New System.Drawing.Point(9, 58)
    Me.ChkMap.Name = "ChkMap"
    Me.ChkMap.Size = New System.Drawing.Size(135, 17)
    Me.ChkMap.TabIndex = 212
    Me.ChkMap.Text = "Show Map/Block/Lot?"
    Me.ChkMap.UseVisualStyleBackColor = True
    '
    'LblVetYear
    '
    Me.LblVetYear.AutoSize = True
    Me.LblVetYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblVetYear.Location = New System.Drawing.Point(14, 36)
    Me.LblVetYear.Name = "LblVetYear"
    Me.LblVetYear.Size = New System.Drawing.Size(48, 13)
    Me.LblVetYear.TabIndex = 15
    Me.LblVetYear.Text = "Vet Year"
    '
    'TxtVetYear
    '
    Me.TxtVetYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVetYear.Location = New System.Drawing.Point(80, 33)
    Me.TxtVetYear.MaxLength = 4
    Me.TxtVetYear.Name = "TxtVetYear"
    Me.TxtVetYear.Size = New System.Drawing.Size(30, 20)
    Me.TxtVetYear.TabIndex = 3
    '
    'LnkLocal
    '
    Me.LnkLocal.AutoSize = True
    Me.LnkLocal.Enabled = False
    Me.LnkLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkLocal.Location = New System.Drawing.Point(270, 37)
    Me.LnkLocal.Name = "LnkLocal"
    Me.LnkLocal.Size = New System.Drawing.Size(61, 13)
    Me.LnkLocal.TabIndex = 12
    Me.LnkLocal.TabStop = True
    Me.LnkLocal.Text = "Local Code"
    '
    'TxtLocal
    '
    Me.TxtLocal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLocal.Enabled = False
    Me.TxtLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocal.Location = New System.Drawing.Point(336, 33)
    Me.TxtLocal.MaxLength = 2
    Me.TxtLocal.Name = "TxtLocal"
    Me.TxtLocal.Size = New System.Drawing.Size(24, 20)
    Me.TxtLocal.TabIndex = 5
    '
    'LblGLYear
    '
    Me.LblGLYear.AutoSize = True
    Me.LblGLYear.Enabled = False
    Me.LblGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGLYear.Location = New System.Drawing.Point(145, 36)
    Me.LblGLYear.Name = "LblGLYear"
    Me.LblGLYear.Size = New System.Drawing.Size(56, 13)
    Me.LblGLYear.TabIndex = 11
    Me.LblGLYear.Text = "Appl. Year"
    '
    'TxtAppYear
    '
    Me.TxtAppYear.Enabled = False
    Me.TxtAppYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppYear.Location = New System.Drawing.Point(211, 33)
    Me.TxtAppYear.MaxLength = 4
    Me.TxtAppYear.Name = "TxtAppYear"
    Me.TxtAppYear.Size = New System.Drawing.Size(30, 20)
    Me.TxtAppYear.TabIndex = 4
    '
    'RbLocal
    '
    Me.RbLocal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbLocal.Location = New System.Drawing.Point(266, 6)
    Me.RbLocal.Name = "RbLocal"
    Me.RbLocal.Size = New System.Drawing.Size(98, 20)
    Me.RbLocal.TabIndex = 2
    Me.RbLocal.Text = "Local Benefit"
    '
    'RbElderly
    '
    Me.RbElderly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbElderly.Location = New System.Drawing.Point(148, 6)
    Me.RbElderly.Name = "RbElderly"
    Me.RbElderly.Size = New System.Drawing.Size(65, 20)
    Me.RbElderly.TabIndex = 1
    Me.RbElderly.Text = "Elderly"
    '
    'RbRE
    '
    Me.RbRE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbRE.Checked = True
    Me.RbRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbRE.Location = New System.Drawing.Point(9, 6)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(84, 20)
    Me.RbRE.TabIndex = 0
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    '
    'TpPP
    '
    Me.TpPP.Controls.Add(Me.LblBusty)
    Me.TpPP.Controls.Add(Me.BtnSelBusty)
    Me.TpPP.Location = New System.Drawing.Point(4, 22)
    Me.TpPP.Name = "TpPP"
    Me.TpPP.Padding = New System.Windows.Forms.Padding(3)
    Me.TpPP.Size = New System.Drawing.Size(489, 81)
    Me.TpPP.TabIndex = 1
    Me.TpPP.Text = "Personal Property"
    Me.TpPP.UseVisualStyleBackColor = True
    '
    'LblBusty
    '
    Me.LblBusty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBusty.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblBusty.Location = New System.Drawing.Point(71, 8)
    Me.LblBusty.Name = "LblBusty"
    Me.LblBusty.Size = New System.Drawing.Size(329, 40)
    Me.LblBusty.TabIndex = 212
    Me.LblBusty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnSelBusty
    '
    Me.BtnSelBusty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnSelBusty.Location = New System.Drawing.Point(6, 18)
    Me.BtnSelBusty.Name = "BtnSelBusty"
    Me.BtnSelBusty.Size = New System.Drawing.Size(59, 46)
    Me.BtnSelBusty.TabIndex = 210
    Me.BtnSelBusty.Text = "Select Types"
    Me.BtnSelBusty.UseVisualStyleBackColor = True
    '
    'TpMV
    '
    Me.TpMV.Controls.Add(Me.Label2)
    Me.TpMV.Location = New System.Drawing.Point(4, 22)
    Me.TpMV.Name = "TpMV"
    Me.TpMV.Size = New System.Drawing.Size(489, 81)
    Me.TpMV.TabIndex = 2
    Me.TpMV.Text = "Motor Vehicle"
    Me.TpMV.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(85, 31)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(199, 13)
    Me.Label2.TabIndex = 92
    Me.Label2.Text = "No Additional selections available"
    '
    'TpSU
    '
    Me.TpSU.Controls.Add(Me.Label3)
    Me.TpSU.Location = New System.Drawing.Point(4, 22)
    Me.TpSU.Name = "TpSU"
    Me.TpSU.Size = New System.Drawing.Size(489, 81)
    Me.TpSU.TabIndex = 3
    Me.TpSU.Text = "Supplemental MV"
    Me.TpSU.UseVisualStyleBackColor = True
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(85, 31)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(199, 13)
    Me.Label3.TabIndex = 93
    Me.Label3.Text = "No Additional selections available"
    '
    'TpM35H
    '
    Me.TpM35H.Controls.Add(Me.Label14)
    Me.TpM35H.Controls.Add(Me.Label13)
    Me.TpM35H.Controls.Add(Me.TxtM35HAppYear)
    Me.TpM35H.Location = New System.Drawing.Point(4, 22)
    Me.TpM35H.Name = "TpM35H"
    Me.TpM35H.Size = New System.Drawing.Size(489, 81)
    Me.TpM35H.TabIndex = 4
    Me.TpM35H.Text = "M35H"
    Me.TpM35H.UseVisualStyleBackColor = True
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label14.Location = New System.Drawing.Point(3, 59)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(434, 13)
    Me.Label14.TabIndex = 14
    Me.Label14.Text = "District, Select Codes, Exemption Codes, Taxable, Frozen List are not applicable " &
    " for M35H"
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Enabled = False
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(161, 30)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(56, 13)
    Me.Label13.TabIndex = 13
    Me.Label13.Text = "Appl. Year"
    '
    'TxtM35HAppYear
    '
    Me.TxtM35HAppYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtM35HAppYear.Location = New System.Drawing.Point(227, 27)
    Me.TxtM35HAppYear.MaxLength = 4
    Me.TxtM35HAppYear.Name = "TxtM35HAppYear"
    Me.TxtM35HAppYear.Size = New System.Drawing.Size(30, 20)
    Me.TxtM35HAppYear.TabIndex = 12
    '
    'ChkFrozenFile
    '
    Me.ChkFrozenFile.AutoSize = True
    Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozenFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ChkFrozenFile.Location = New System.Drawing.Point(12, 223)
    Me.ChkFrozenFile.Name = "ChkFrozenFile"
    Me.ChkFrozenFile.Size = New System.Drawing.Size(105, 17)
    Me.ChkFrozenFile.TabIndex = 9
    Me.ChkFrozenFile.Text = "Use Frozen List?"
    '
    'LblCodes
    '
    Me.LblCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodes.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblCodes.Location = New System.Drawing.Point(73, 38)
    Me.LblCodes.Name = "LblCodes"
    Me.LblCodes.Size = New System.Drawing.Size(299, 63)
    Me.LblCodes.TabIndex = 210
    Me.LblCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnSelCodes
    '
    Me.BtnSelCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnSelCodes.Location = New System.Drawing.Point(8, 48)
    Me.BtnSelCodes.Name = "BtnSelCodes"
    Me.BtnSelCodes.Size = New System.Drawing.Size(59, 46)
    Me.BtnSelCodes.TabIndex = 1
    Me.BtnSelCodes.Text = "Select Codes"
    Me.BtnSelCodes.UseVisualStyleBackColor = True
    '
    'LnkExemptCd
    '
    Me.LnkExemptCd.AutoSize = True
    Me.LnkExemptCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkExemptCd.Location = New System.Drawing.Point(163, 143)
    Me.LnkExemptCd.Name = "LnkExemptCd"
    Me.LnkExemptCd.Size = New System.Drawing.Size(70, 13)
    Me.LnkExemptCd.TabIndex = 6
    Me.LnkExemptCd.TabStop = True
    Me.LnkExemptCd.Text = "Exempt Code"
    '
    'TxtExemptCd
    '
    Me.TxtExemptCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExemptCd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExemptCd.Location = New System.Drawing.Point(239, 140)
    Me.TxtExemptCd.MaxLength = 4
    Me.TxtExemptCd.Name = "TxtExemptCd"
    Me.TxtExemptCd.Size = New System.Drawing.Size(40, 20)
    Me.TxtExemptCd.TabIndex = 7
    Me.TxtExemptCd.TabStop = False
    '
    'RbCatTaxable
    '
    Me.RbCatTaxable.Checked = True
    Me.RbCatTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTaxable.ForeColor = System.Drawing.Color.Black
    Me.RbCatTaxable.Location = New System.Drawing.Point(8, 113)
    Me.RbCatTaxable.Name = "RbCatTaxable"
    Me.RbCatTaxable.Size = New System.Drawing.Size(64, 24)
    Me.RbCatTaxable.TabIndex = 2
    Me.RbCatTaxable.TabStop = True
    Me.RbCatTaxable.Text = "Taxable"
    '
    'RbCatExempt
    '
    Me.RbCatExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatExempt.ForeColor = System.Drawing.Color.Black
    Me.RbCatExempt.Location = New System.Drawing.Point(78, 113)
    Me.RbCatExempt.Name = "RbCatExempt"
    Me.RbCatExempt.Size = New System.Drawing.Size(64, 24)
    Me.RbCatExempt.TabIndex = 3
    Me.RbCatExempt.Text = "Exempt"
    '
    'FrmTAB03B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
    Me.ClientSize = New System.Drawing.Size(521, 525)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbCatExempt)
    Me.Controls.Add(Me.RbCatTaxable)
    Me.Controls.Add(Me.LnkExemptCd)
    Me.Controls.Add(Me.TxtExemptCd)
    Me.Controls.Add(Me.LblCodes)
    Me.Controls.Add(Me.BtnSelCodes)
    Me.Controls.Add(Me.ChkFrozenFile)
    Me.Controls.Add(Me.TabCtl1)
    Me.Controls.Add(Me.LnkExcd)
    Me.Controls.Add(Me.TxtExcd)
    Me.Controls.Add(Me.GroupBox10)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.ChkShowList)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtMaxLen)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LnkDist)
    Me.Controls.Add(Me.TxtDist)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAB03B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox10.ResumeLayout(False)
    Me.GroupBox10.PerformLayout()
    Me.TabCtl1.ResumeLayout(False)
    Me.TpRE.ResumeLayout(False)
    Me.TpRE.PerformLayout()
    Me.TpPP.ResumeLayout(False)
    Me.TpMV.ResumeLayout(False)
    Me.TpMV.PerformLayout()
    Me.TpSU.ResumeLayout(False)
    Me.TpSU.PerformLayout()
    Me.TpM35H.ResumeLayout(False)
    Me.TpM35H.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region
  Dim Mytxdist As TXDIST.MyData

  Public Sub RunReport()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    Mytxdist = New TXDIST.MyData(myDBConnect)

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
  Private Sub FrmTAB03B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAB03.SbpScreen.Text = "TAB03B"
  End Sub
  Private Sub FrmTAB03B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
    Me.Refresh()
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      'Select Case ErrorField(I)
      'End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds As DataSet = New DataSet
    Dim I As Integer
    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next
  End Sub
  Private Sub LnkDist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
    MyFrmListDist = New FrmListDist
    MyFrmListDist.MdiParent = Me.ParentForm
    MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
    MyFrmListDist.Show()
    Me.Hide()
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub FrmTAB03B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    LblCodes.Text = "* ALL Codes *"
    MySelCodes = String.Empty
    LblBusty.Text = "* ALL Business Types *"
    MySelBusty = String.Empty
    TxtMaxLen.Text = "35"
    LnkExemptCd.Enabled = False
    TxtExemptCd.Enabled = False
  End Sub
  Private Sub TxtMaxLen_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMaxLen.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtHAdjust1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHAdjust1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtHAdjust2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHAdjust2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtHAdjust3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHAdjust3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVAdjust1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVAdjust1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVAdjust2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVAdjust2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFromList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFromList.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtToList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtToList.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub BtnSelCodes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelCodes.Click
    MyFrmSelCodes = New FrmSelCodes
    Select Case TabCtl1.SelectedTab.Name
      Case "TpRE"
        MyFrmSelCodes.WrkType = "R"
      Case "TpPP"
        MyFrmSelCodes.WrkType = "P"
      Case "TpMV"
        MyFrmSelCodes.WrkType = "M"
      Case "TpSU"
        MyFrmSelCodes.WrkType = "M"
    End Select
    MyFrmSelCodes.ShowDialog()
    If MySelCodes = "" Then
      LblCodes.Text = "* ALL Codes *"
    Else
      LblCodes.Text = MySelCodes
    End If
  End Sub
  Private Sub BtnSelBusty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSelBusty.Click
    MyFrmSelBusty = New FrmSelBusty
    MyFrmSelBusty.ShowDialog()
    If MySelBusty = "" Then
      LblBusty.Text = "* ALL Business Types *"
    Else
      LblBusty.Text = MySelBusty
    End If
  End Sub
  Private Sub LnkExcd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExcd.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkCode = TxtExcd.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkLocal_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkLocal.LinkClicked
    MyFrmListLocalCodes = New FrmListLocalCodes
    MyFrmListLocalCodes.MdiParent = Me.ParentForm
    MyFrmListLocalCodes.WrkCode = TxtLocal.Text
    MyFrmListLocalCodes.Show()
  End Sub
  Private Sub TabCtl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCtl1.Click

    LblCodes.Text = "* ALL Codes *"
    MySelCodes = String.Empty
    Select Case TabCtl1.SelectedTab.Name
      Case "TpRE"
        If RbRE.Checked Then
          MyFrmTAB03.Text = "Labels - Real Estate"
        End If
        If RbElderly.Checked Then
          MyFrmTAB03.Text = "Labels - Elderly"
        End If
        If RbLocal.Checked Then
          MyFrmTAB03.Text = "Labels - Local"
        End If
      Case "TpPP"
        MyFrmTAB03.Text = "Labels - Personal Property"
      Case "TpMV"
        MyFrmTAB03.Text = "Labels - Motor Vehicle"
      Case "TpSU"
        MyFrmTAB03.Text = "Labels - Supplemental MV"
    End Select

  End Sub
  Private Sub RbRE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbRE.Click
    MyFrmTAB03.Text = "Labels - Real Estate"
    LblVetYear.Enabled = False
    TxtVetYear.Enabled = False
    LblGLYear.Enabled = False
    TxtAppYear.Enabled = False
    LnkLocal.Enabled = False
    TxtLocal.Enabled = False
  End Sub
  Private Sub RbElderly_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbElderly.Click
    MyFrmTAB03.Text = "Labels - Elderly"
    LblVetYear.Enabled = True
    TxtVetYear.Enabled = True
    LblGLYear.Enabled = True
    TxtAppYear.Enabled = True
    LnkLocal.Enabled = False
    TxtLocal.Enabled = False
  End Sub
  Private Sub RbLocal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLocal.Click
    MyFrmTAB03.Text = "Labels - Local"
    LblVetYear.Enabled = False
    TxtVetYear.Enabled = False
    LblGLYear.Enabled = True
    TxtAppYear.Enabled = True
    LnkLocal.Enabled = True
    TxtLocal.Enabled = True
  End Sub

  Private Sub TxtAppYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAppYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtVetYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVetYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub ChkMap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMap.CheckedChanged

  End Sub
  Private Sub RbCatTaxable_Click(sender As Object, e As EventArgs) Handles RbCatTaxable.Click
    LnkExcd.Enabled = True
    TxtExcd.Enabled = True
    LnkExemptCd.Enabled = False
    TxtExemptCd.Enabled = False
    TxtExemptCd.Text = ""
  End Sub
  Private Sub RbCatExempt_Click(sender As Object, e As EventArgs) Handles RbCatExempt.Click
    LnkExcd.Enabled = False
    TxtExcd.Enabled = False
    TxtExcd.Text = ""
    LnkExemptCd.Enabled = True
    TxtExemptCd.Enabled = True
  End Sub

  Private Sub LnkExemptCd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkExemptCd.LinkClicked
    MyFrmListExempt = New FrmListExempt
    MyFrmListExempt.MdiParent = Me.ParentForm
    MyFrmListExempt.WrkCode = TxtExemptCd.Text
    MyFrmListExempt.Show()
  End Sub

End Class






