Public Class FrmUB207B
  Inherits System.Windows.Forms.Form

  Friend ds As DataSet = New DataSet
  Dim Wrkdistr As Decimal
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbSortList As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortName As System.Windows.Forms.RadioButton
  Friend WithEvents RbSortLoc As System.Windows.Forms.RadioButton
  Friend WithEvents GrpVert As System.Windows.Forms.GroupBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
  Friend WithEvents TxtVAdjust2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtVAdjust1 As System.Windows.Forms.TextBox
  Friend WithEvents GrpHoriz As System.Windows.Forms.GroupBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
  Friend WithEvents TxtHAdjust3 As System.Windows.Forms.TextBox
  Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
  Friend WithEvents TxtHAdjust2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtHAdjust1 As System.Windows.Forms.TextBox
  Friend WithEvents GrpFormat As System.Windows.Forms.GroupBox
  Friend WithEvents Rb1Across As System.Windows.Forms.RadioButton
  Friend WithEvents Rb3Across As System.Windows.Forms.RadioButton
  Friend WithEvents Rb2Across As System.Windows.Forms.RadioButton
  Friend WithEvents ChkShowList As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents RbList As System.Windows.Forms.RadioButton
  Friend WithEvents RbLabels As System.Windows.Forms.RadioButton
  Friend WithEvents LinkUBType As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtUBType As System.Windows.Forms.TextBox
    Friend WithEvents ChkMailAddr As CheckBox
    Dim Wrkdiphas As Decimal
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
Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents TxtPhase As System.Windows.Forms.TextBox
Friend WithEvents Label44 As System.Windows.Forms.Label
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents LnkDistrict As System.Windows.Forms.LinkLabel
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents txtphaseto As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents txtdistto As System.Windows.Forms.TextBox
Friend WithEvents LinkDistrictto As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUB207B))
        Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtphaseto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdistto = New System.Windows.Forms.TextBox()
        Me.LinkDistrictto = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPhase = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.TxtDist = New System.Windows.Forms.TextBox()
        Me.LnkDistrict = New System.Windows.Forms.LinkLabel()
        Me.GrpVert = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.TxtVAdjust2 = New System.Windows.Forms.TextBox()
        Me.TxtVAdjust1 = New System.Windows.Forms.TextBox()
        Me.GrpHoriz = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.TxtHAdjust3 = New System.Windows.Forms.TextBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TxtHAdjust2 = New System.Windows.Forms.TextBox()
        Me.TxtHAdjust1 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RbSortList = New System.Windows.Forms.RadioButton()
        Me.RbSortName = New System.Windows.Forms.RadioButton()
        Me.RbSortLoc = New System.Windows.Forms.RadioButton()
        Me.GrpFormat = New System.Windows.Forms.GroupBox()
        Me.Rb1Across = New System.Windows.Forms.RadioButton()
        Me.Rb3Across = New System.Windows.Forms.RadioButton()
        Me.Rb2Across = New System.Windows.Forms.RadioButton()
        Me.ChkShowList = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.RbList = New System.Windows.Forms.RadioButton()
        Me.RbLabels = New System.Windows.Forms.RadioButton()
        Me.LinkUBType = New System.Windows.Forms.LinkLabel()
        Me.TxtUBType = New System.Windows.Forms.TextBox()
        Me.ChkMailAddr = New System.Windows.Forms.CheckBox()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpVert.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpHoriz.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GrpFormat.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtphaseto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtdistto)
        Me.GroupBox1.Controls.Add(Me.LinkDistrictto)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtPhase)
        Me.GroupBox1.Controls.Add(Me.Label44)
        Me.GroupBox1.Controls.Add(Me.TxtDist)
        Me.GroupBox1.Controls.Add(Me.LnkDistrict)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 55)
        Me.GroupBox1.TabIndex = 304
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "District Selection"
        '
        'txtphaseto
        '
        Me.txtphaseto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtphaseto.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphaseto.Location = New System.Drawing.Point(464, 25)
        Me.txtphaseto.MaxLength = 1
        Me.txtphaseto.Name = "txtphaseto"
        Me.txtphaseto.Size = New System.Drawing.Size(16, 22)
        Me.txtphaseto.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label2.Location = New System.Drawing.Point(391, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 311
        Me.Label2.Text = "Phase"
        '
        'txtdistto
        '
        Me.txtdistto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdistto.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdistto.Location = New System.Drawing.Point(344, 23)
        Me.txtdistto.MaxLength = 3
        Me.txtdistto.Name = "txtdistto"
        Me.txtdistto.Size = New System.Drawing.Size(32, 22)
        Me.txtdistto.TabIndex = 7
        '
        'LinkDistrictto
        '
        Me.LinkDistrictto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkDistrictto.Location = New System.Drawing.Point(277, 25)
        Me.LinkDistrictto.Name = "LinkDistrictto"
        Me.LinkDistrictto.Size = New System.Drawing.Size(48, 16)
        Me.LinkDistrictto.TabIndex = 6
        Me.LinkDistrictto.TabStop = True
        Me.LinkDistrictto.Text = "District"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(236, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 16)
        Me.Label1.TabIndex = 308
        Me.Label1.Text = "To"
        '
        'TxtPhase
        '
        Me.TxtPhase.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhase.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPhase.Location = New System.Drawing.Point(203, 23)
        Me.TxtPhase.MaxLength = 1
        Me.TxtPhase.Name = "TxtPhase"
        Me.TxtPhase.Size = New System.Drawing.Size(16, 22)
        Me.TxtPhase.TabIndex = 5
        '
        'Label44
        '
        Me.Label44.BackColor = System.Drawing.SystemColors.Control
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label44.Location = New System.Drawing.Point(122, 25)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(56, 16)
        Me.Label44.TabIndex = 303
        Me.Label44.Text = "Phase"
        '
        'TxtDist
        '
        Me.TxtDist.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDist.Location = New System.Drawing.Point(81, 23)
        Me.TxtDist.MaxLength = 3
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.Size = New System.Drawing.Size(32, 22)
        Me.TxtDist.TabIndex = 3
        '
        'LnkDistrict
        '
        Me.LnkDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkDistrict.Location = New System.Drawing.Point(17, 25)
        Me.LnkDistrict.Name = "LnkDistrict"
        Me.LnkDistrict.Size = New System.Drawing.Size(48, 16)
        Me.LnkDistrict.TabIndex = 2
        Me.LnkDistrict.TabStop = True
        Me.LnkDistrict.Text = "District"
        '
        'GrpVert
        '
        Me.GrpVert.Controls.Add(Me.Label3)
        Me.GrpVert.Controls.Add(Me.Label6)
        Me.GrpVert.Controls.Add(Me.Label10)
        Me.GrpVert.Controls.Add(Me.PictureBox8)
        Me.GrpVert.Controls.Add(Me.PictureBox9)
        Me.GrpVert.Controls.Add(Me.TxtVAdjust2)
        Me.GrpVert.Controls.Add(Me.TxtVAdjust1)
        Me.GrpVert.Enabled = False
        Me.GrpVert.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpVert.Location = New System.Drawing.Point(339, 169)
        Me.GrpVert.Name = "GrpVert"
        Me.GrpVert.Size = New System.Drawing.Size(120, 154)
        Me.GrpVert.TabIndex = 309
        Me.GrpVert.TabStop = False
        Me.GrpVert.Text = "Vertical  Spacing "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(27, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "(250 = 1 line)"
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
        'GrpHoriz
        '
        Me.GrpHoriz.Controls.Add(Me.Label9)
        Me.GrpHoriz.Controls.Add(Me.Label8)
        Me.GrpHoriz.Controls.Add(Me.Label7)
        Me.GrpHoriz.Controls.Add(Me.PictureBox4)
        Me.GrpHoriz.Controls.Add(Me.PictureBox5)
        Me.GrpHoriz.Controls.Add(Me.TxtHAdjust3)
        Me.GrpHoriz.Controls.Add(Me.PictureBox6)
        Me.GrpHoriz.Controls.Add(Me.TxtHAdjust2)
        Me.GrpHoriz.Controls.Add(Me.TxtHAdjust1)
        Me.GrpHoriz.Enabled = False
        Me.GrpHoriz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpHoriz.Location = New System.Drawing.Point(12, 207)
        Me.GrpHoriz.Name = "GrpHoriz"
        Me.GrpHoriz.Size = New System.Drawing.Size(292, 68)
        Me.GrpHoriz.TabIndex = 308
        Me.GrpHoriz.TabStop = False
        Me.GrpHoriz.Text = "Horizontal  Spacing (Enter # of spaces needed)"
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RbSortList)
        Me.GroupBox3.Controls.Add(Me.RbSortName)
        Me.GroupBox3.Controls.Add(Me.RbSortLoc)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(530, 58)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(127, 81)
        Me.GroupBox3.TabIndex = 310
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sort Order"
        '
        'RbSortList
        '
        Me.RbSortList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortList.Location = New System.Drawing.Point(12, 19)
        Me.RbSortList.Name = "RbSortList"
        Me.RbSortList.Size = New System.Drawing.Size(102, 21)
        Me.RbSortList.TabIndex = 2
        Me.RbSortList.Text = "List No"
        '
        'RbSortName
        '
        Me.RbSortName.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortName.Checked = True
        Me.RbSortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortName.Location = New System.Drawing.Point(12, 38)
        Me.RbSortName.Name = "RbSortName"
        Me.RbSortName.Size = New System.Drawing.Size(102, 20)
        Me.RbSortName.TabIndex = 0
        Me.RbSortName.TabStop = True
        Me.RbSortName.Text = "Name"
        '
        'RbSortLoc
        '
        Me.RbSortLoc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbSortLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbSortLoc.Location = New System.Drawing.Point(12, 55)
        Me.RbSortLoc.Name = "RbSortLoc"
        Me.RbSortLoc.Size = New System.Drawing.Size(102, 20)
        Me.RbSortLoc.TabIndex = 1
        Me.RbSortLoc.Text = "Location"
        '
        'GrpFormat
        '
        Me.GrpFormat.Controls.Add(Me.Rb1Across)
        Me.GrpFormat.Controls.Add(Me.Rb3Across)
        Me.GrpFormat.Controls.Add(Me.Rb2Across)
        Me.GrpFormat.Enabled = False
        Me.GrpFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpFormat.Location = New System.Drawing.Point(530, 191)
        Me.GrpFormat.Name = "GrpFormat"
        Me.GrpFormat.Size = New System.Drawing.Size(127, 81)
        Me.GrpFormat.TabIndex = 311
        Me.GrpFormat.TabStop = False
        Me.GrpFormat.Text = "Format"
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
        'ChkShowList
        '
        Me.ChkShowList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkShowList.Enabled = False
        Me.ChkShowList.Location = New System.Drawing.Point(12, 153)
        Me.ChkShowList.Name = "ChkShowList"
        Me.ChkShowList.Size = New System.Drawing.Size(135, 19)
        Me.ChkShowList.TabIndex = 312
        Me.ChkShowList.Text = "Show List #?"
        Me.ChkShowList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkShowList.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.RbList)
        Me.GroupBox6.Controls.Add(Me.RbLabels)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(219, 34)
        Me.GroupBox6.TabIndex = 313
        Me.GroupBox6.TabStop = False
        '
        'RbList
        '
        Me.RbList.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbList.Checked = True
        Me.RbList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbList.Location = New System.Drawing.Point(13, 8)
        Me.RbList.Name = "RbList"
        Me.RbList.Size = New System.Drawing.Size(71, 20)
        Me.RbList.TabIndex = 0
        Me.RbList.TabStop = True
        Me.RbList.Text = "Listing"
        '
        'RbLabels
        '
        Me.RbLabels.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RbLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLabels.Location = New System.Drawing.Point(133, 8)
        Me.RbLabels.Name = "RbLabels"
        Me.RbLabels.Size = New System.Drawing.Size(74, 20)
        Me.RbLabels.TabIndex = 2
        Me.RbLabels.Text = "Labels"
        '
        'LinkUBType
        '
        Me.LinkUBType.Location = New System.Drawing.Point(12, 21)
        Me.LinkUBType.Name = "LinkUBType"
        Me.LinkUBType.Size = New System.Drawing.Size(68, 16)
        Me.LinkUBType.TabIndex = 315
        Me.LinkUBType.TabStop = True
        Me.LinkUBType.Text = "Bill Type"
        '
        'TxtUBType
        '
        Me.TxtUBType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtUBType.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUBType.Location = New System.Drawing.Point(93, 17)
        Me.TxtUBType.MaxLength = 2
        Me.TxtUBType.Name = "TxtUBType"
        Me.TxtUBType.Size = New System.Drawing.Size(24, 22)
        Me.TxtUBType.TabIndex = 314
        '
        'ChkMailAddr
        '
        Me.ChkMailAddr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMailAddr.Location = New System.Drawing.Point(13, 176)
        Me.ChkMailAddr.Name = "ChkMailAddr"
        Me.ChkMailAddr.Size = New System.Drawing.Size(134, 22)
        Me.ChkMailAddr.TabIndex = 316
        Me.ChkMailAddr.Text = "Use Mailing Address?"
        Me.ChkMailAddr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMailAddr.UseVisualStyleBackColor = True
        '
        'FrmUB207B
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(662, 329)
        Me.ControlBox = False
        Me.Controls.Add(Me.ChkMailAddr)
        Me.Controls.Add(Me.LinkUBType)
        Me.Controls.Add(Me.TxtUBType)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.ChkShowList)
        Me.Controls.Add(Me.GrpFormat)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GrpVert)
        Me.Controls.Add(Me.GrpHoriz)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "FrmUB207B"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpVert.ResumeLayout(False)
        Me.GrpVert.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpHoriz.ResumeLayout(False)
        Me.GrpHoriz.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GrpFormat.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub FrmUB207B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

  Wrkdistr = 0
  Wrkdiphas = 0

End Sub


Private Sub FrmUB207B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmUB207.SbpScreen.Text = "UB207B"
  MyFrmUB207.TBarPrint.Enabled = True
  MyUtils.CenterForm(Me.ParentForm, Me)
End Sub

Private Sub LnkDistrict_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDistrict.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(TxtPhase.Text)
  MyFrmListDist.Wrkwhichdist = "F"
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtPhase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPhase.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub LinkDistrictto_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkDistrictto.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(txtdistto.Text)
  MyFrmListDist.WrkPhase = MyUtils.CnvSng(txtphaseto.Text)
  MyFrmListDist.Wrkwhichdist = "T"
  MyFrmListDist.Show()
  Me.Hide()
End Sub

Private Sub txtDistto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdistto.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub txtPhaseto_Keypressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtphaseto.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtDist.Text) > MyUtils.CnvSng(txtdistto.Text) Then
      ErrorField(I) = "TxtDist"
      ErrorMsg(I) = "Invalid District Range"
      I = I + 1
      End If
    If MyUtils.CnvSng(TxtDist.Text) = MyUtils.CnvSng(txtdistto.Text) And _
      MyUtils.CnvSng(TxtPhase.Text) > MyUtils.CnvSng(txtphaseto.Text) Then
      ErrorField(I) = "TxtPhase"
      ErrorMsg(I) = "Invalid Phase Range"
      I = I + 1
      End If

End Sub
Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtDist, "")
    ErrProv.SetError(TxtPhase, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "TxtDist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
      Case "TxtPhase"
        ErrProv.SetError(TxtPhase, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
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
Private Sub RbList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbList.Click
  ChkShowList.Enabled = False
  MyFrmUB207.MenuStrip1.Enabled = False
  GrpHoriz.Enabled = False
  GrpVert.Enabled = False
  GrpFormat.Enabled = False
End Sub
Private Sub RbLabels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbLabels.Click
  ChkShowList.Enabled = True
  MyFrmUB207.MenuStrip1.Enabled = True
  GrpHoriz.Enabled = True
  GrpVert.Enabled = True
  GrpFormat.Enabled = True
End Sub

Private Sub RbLabels_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbLabels.CheckedChanged

End Sub

Private Sub LinkUBType_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkUBType.LinkClicked
  MyFrmListUBType = New FrmListUBType
  MyFrmListUBType.MdiParent = Me.ParentForm
  MyFrmListUBType.WrkType = TxtUBType.Text
  MyFrmListUBType.Show()
  Me.Hide()
End Sub
End Class






