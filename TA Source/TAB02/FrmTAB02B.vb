Public Class FrmTAB02B
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
Friend WithEvents ChkFrozenFile As System.Windows.Forms.CheckBox
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents TxtGLYear As System.Windows.Forms.TextBox
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents ChkSU As System.Windows.Forms.CheckBox
Friend WithEvents ChkMV As System.Windows.Forms.CheckBox
Friend WithEvents ChkPP As System.Windows.Forms.CheckBox
Friend WithEvents ChkRE As System.Windows.Forms.CheckBox
Friend WithEvents LnkDist As System.Windows.Forms.LinkLabel
Friend WithEvents ChkLocal As System.Windows.Forms.CheckBox
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents LnkExempt5 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt5 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt3 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt3 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt4 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt4 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt2 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt2 As System.Windows.Forms.TextBox
Friend WithEvents LnkExempt1 As System.Windows.Forms.LinkLabel
Friend WithEvents TxtExempt1 As System.Windows.Forms.TextBox
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents TxtOPM As System.Windows.Forms.TextBox
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents TxtIncomeLevel As System.Windows.Forms.TextBox
Friend WithEvents Label2 As System.Windows.Forms.Label
Friend WithEvents TxtSubdivision As System.Windows.Forms.TextBox
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents TxtCategory As System.Windows.Forms.TextBox
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents TxtCategory4 As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtCategory3 As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtCategory2 As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtCategory1 As System.Windows.Forms.TextBox
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAB02B))
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.ChkFrozenFile = New System.Windows.Forms.CheckBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtGLYear = New System.Windows.Forms.TextBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.ChkSU = New System.Windows.Forms.CheckBox()
    Me.ChkMV = New System.Windows.Forms.CheckBox()
    Me.ChkPP = New System.Windows.Forms.CheckBox()
    Me.ChkRE = New System.Windows.Forms.CheckBox()
    Me.LnkDist = New System.Windows.Forms.LinkLabel()
    Me.ChkLocal = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.TxtCategory4 = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtCategory3 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtCategory2 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtCategory1 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtOPM = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtIncomeLevel = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtSubdivision = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtCategory = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LnkExempt5 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt5 = New System.Windows.Forms.TextBox()
    Me.LnkExempt3 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt3 = New System.Windows.Forms.TextBox()
    Me.LnkExempt4 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt4 = New System.Windows.Forms.TextBox()
    Me.LnkExempt2 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt2 = New System.Windows.Forms.TextBox()
    Me.LnkExempt1 = New System.Windows.Forms.LinkLabel()
    Me.TxtExempt1 = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'ChkFrozenFile
    '
    Me.ChkFrozenFile.AutoSize = True
    Me.ChkFrozenFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozenFile.Location = New System.Drawing.Point(28, 277)
    Me.ChkFrozenFile.Name = "ChkFrozenFile"
    Me.ChkFrozenFile.Size = New System.Drawing.Size(105, 17)
    Me.ChkFrozenFile.TabIndex = 6
    Me.ChkFrozenFile.Text = "Use Frozen List?"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(25, 46)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(84, 16)
    Me.Label4.TabIndex = 56
    Me.Label4.Text = "Grand List Year"
    '
    'TxtGLYear
    '
    Me.TxtGLYear.Location = New System.Drawing.Point(115, 46)
    Me.TxtGLYear.MaxLength = 4
    Me.TxtGLYear.Name = "TxtGLYear"
    Me.TxtGLYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtGLYear.TabIndex = 0
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(115, 73)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(28, 20)
    Me.TxtDist.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.ChkSU)
    Me.GroupBox1.Controls.Add(Me.ChkMV)
    Me.GroupBox1.Controls.Add(Me.ChkPP)
    Me.GroupBox1.Controls.Add(Me.ChkRE)
    Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.GroupBox1.Location = New System.Drawing.Point(160, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(127, 109)
    Me.GroupBox1.TabIndex = 8
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Files"
    '
    'ChkSU
    '
    Me.ChkSU.AutoSize = True
    Me.ChkSU.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkSU.Location = New System.Drawing.Point(6, 86)
    Me.ChkSU.Name = "ChkSU"
    Me.ChkSU.Size = New System.Drawing.Size(75, 17)
    Me.ChkSU.TabIndex = 3
    Me.ChkSU.Text = "Suppl. MV"
    Me.ChkSU.UseVisualStyleBackColor = True
    '
    'ChkMV
    '
    Me.ChkMV.AutoSize = True
    Me.ChkMV.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkMV.Location = New System.Drawing.Point(6, 65)
    Me.ChkMV.Name = "ChkMV"
    Me.ChkMV.Size = New System.Drawing.Size(91, 17)
    Me.ChkMV.TabIndex = 2
    Me.ChkMV.Text = "Motor Vehicle"
    Me.ChkMV.UseVisualStyleBackColor = True
    '
    'ChkPP
    '
    Me.ChkPP.AutoSize = True
    Me.ChkPP.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkPP.Location = New System.Drawing.Point(6, 44)
    Me.ChkPP.Name = "ChkPP"
    Me.ChkPP.Size = New System.Drawing.Size(109, 17)
    Me.ChkPP.TabIndex = 1
    Me.ChkPP.Text = "Personal Property"
    Me.ChkPP.UseVisualStyleBackColor = True
    '
    'ChkRE
    '
    Me.ChkRE.AutoSize = True
    Me.ChkRE.Checked = True
    Me.ChkRE.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkRE.ForeColor = System.Drawing.SystemColors.ControlText
    Me.ChkRE.Location = New System.Drawing.Point(6, 23)
    Me.ChkRE.Name = "ChkRE"
    Me.ChkRE.Size = New System.Drawing.Size(81, 17)
    Me.ChkRE.TabIndex = 0
    Me.ChkRE.Text = "Real Estate"
    Me.ChkRE.UseVisualStyleBackColor = True
    '
    'LnkDist
    '
    Me.LnkDist.AutoSize = True
    Me.LnkDist.Location = New System.Drawing.Point(29, 73)
    Me.LnkDist.Name = "LnkDist"
    Me.LnkDist.Size = New System.Drawing.Size(39, 13)
    Me.LnkDist.TabIndex = 68
    Me.LnkDist.TabStop = True
    Me.LnkDist.Text = "District"
    '
    'ChkLocal
    '
    Me.ChkLocal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkLocal.Checked = True
    Me.ChkLocal.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkLocal.Location = New System.Drawing.Point(28, 298)
    Me.ChkLocal.Name = "ChkLocal"
    Me.ChkLocal.Size = New System.Drawing.Size(105, 17)
    Me.ChkLocal.TabIndex = 7
    Me.ChkLocal.Text = "Include Local?"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.TxtCategory4)
    Me.GroupBox2.Controls.Add(Me.Label11)
    Me.GroupBox2.Controls.Add(Me.TxtCategory3)
    Me.GroupBox2.Controls.Add(Me.Label10)
    Me.GroupBox2.Controls.Add(Me.TxtCategory2)
    Me.GroupBox2.Controls.Add(Me.Label9)
    Me.GroupBox2.Controls.Add(Me.TxtCategory1)
    Me.GroupBox2.Controls.Add(Me.Label8)
    Me.GroupBox2.Controls.Add(Me.Label7)
    Me.GroupBox2.Controls.Add(Me.Label6)
    Me.GroupBox2.Controls.Add(Me.TxtOPM)
    Me.GroupBox2.Controls.Add(Me.Label1)
    Me.GroupBox2.Controls.Add(Me.TxtIncomeLevel)
    Me.GroupBox2.Controls.Add(Me.Label2)
    Me.GroupBox2.Controls.Add(Me.TxtSubdivision)
    Me.GroupBox2.Controls.Add(Me.Label3)
    Me.GroupBox2.Controls.Add(Me.TxtCategory)
    Me.GroupBox2.Controls.Add(Me.Label5)
    Me.GroupBox2.Controls.Add(Me.LnkExempt5)
    Me.GroupBox2.Controls.Add(Me.TxtExempt5)
    Me.GroupBox2.Controls.Add(Me.LnkExempt3)
    Me.GroupBox2.Controls.Add(Me.TxtExempt3)
    Me.GroupBox2.Controls.Add(Me.LnkExempt4)
    Me.GroupBox2.Controls.Add(Me.TxtExempt4)
    Me.GroupBox2.Controls.Add(Me.LnkExempt2)
    Me.GroupBox2.Controls.Add(Me.TxtExempt2)
    Me.GroupBox2.Controls.Add(Me.LnkExempt1)
    Me.GroupBox2.Controls.Add(Me.TxtExempt1)
    Me.GroupBox2.ForeColor = System.Drawing.Color.Black
    Me.GroupBox2.Location = New System.Drawing.Point(28, 127)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(362, 144)
    Me.GroupBox2.TabIndex = 72
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Select Exemptions (State)"
    '
    'TxtCategory4
    '
    Me.TxtCategory4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCategory4.Location = New System.Drawing.Point(328, 94)
    Me.TxtCategory4.MaxLength = 1
    Me.TxtCategory4.Name = "TxtCategory4"
    Me.TxtCategory4.Size = New System.Drawing.Size(19, 20)
    Me.TxtCategory4.TabIndex = 216
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(261, 98)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(61, 16)
    Me.Label11.TabIndex = 217
    Me.Label11.Text = "Category 4"
    '
    'TxtCategory3
    '
    Me.TxtCategory3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCategory3.Location = New System.Drawing.Point(328, 68)
    Me.TxtCategory3.MaxLength = 1
    Me.TxtCategory3.Name = "TxtCategory3"
    Me.TxtCategory3.Size = New System.Drawing.Size(19, 20)
    Me.TxtCategory3.TabIndex = 214
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(261, 72)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(61, 16)
    Me.Label10.TabIndex = 215
    Me.Label10.Text = "Category 3"
    '
    'TxtCategory2
    '
    Me.TxtCategory2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCategory2.Location = New System.Drawing.Point(328, 42)
    Me.TxtCategory2.MaxLength = 1
    Me.TxtCategory2.Name = "TxtCategory2"
    Me.TxtCategory2.Size = New System.Drawing.Size(19, 20)
    Me.TxtCategory2.TabIndex = 212
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(261, 46)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(61, 16)
    Me.Label9.TabIndex = 213
    Me.Label9.Text = "Category 2"
    '
    'TxtCategory1
    '
    Me.TxtCategory1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCategory1.Location = New System.Drawing.Point(328, 16)
    Me.TxtCategory1.MaxLength = 1
    Me.TxtCategory1.Name = "TxtCategory1"
    Me.TxtCategory1.Size = New System.Drawing.Size(19, 20)
    Me.TxtCategory1.TabIndex = 210
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(261, 20)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(61, 16)
    Me.Label8.TabIndex = 211
    Me.Label8.Text = "Category 1"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(225, 67)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(35, 13)
    Me.Label7.TabIndex = 209
    Me.Label7.Text = "- OR -"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(117, 64)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(35, 13)
    Me.Label6.TabIndex = 208
    Me.Label6.Text = "- OR -"
    '
    'TxtOPM
    '
    Me.TxtOPM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOPM.Location = New System.Drawing.Point(92, 98)
    Me.TxtOPM.MaxLength = 1
    Me.TxtOPM.Name = "TxtOPM"
    Me.TxtOPM.Size = New System.Drawing.Size(19, 20)
    Me.TxtOPM.TabIndex = 203
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(6, 101)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(82, 20)
    Me.Label1.TabIndex = 207
    Me.Label1.Text = "OPM Group"
    '
    'TxtIncomeLevel
    '
    Me.TxtIncomeLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtIncomeLevel.Location = New System.Drawing.Point(92, 72)
    Me.TxtIncomeLevel.MaxLength = 1
    Me.TxtIncomeLevel.Name = "TxtIncomeLevel"
    Me.TxtIncomeLevel.Size = New System.Drawing.Size(19, 20)
    Me.TxtIncomeLevel.TabIndex = 202
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(4, 75)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(82, 20)
    Me.Label2.TabIndex = 206
    Me.Label2.Text = "Income Level"
    '
    'TxtSubdivision
    '
    Me.TxtSubdivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubdivision.Location = New System.Drawing.Point(92, 46)
    Me.TxtSubdivision.MaxLength = 1
    Me.TxtSubdivision.Name = "TxtSubdivision"
    Me.TxtSubdivision.Size = New System.Drawing.Size(19, 20)
    Me.TxtSubdivision.TabIndex = 201
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(4, 49)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 20)
    Me.Label3.TabIndex = 205
    Me.Label3.Text = "Subdivision"
    '
    'TxtCategory
    '
    Me.TxtCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCategory.Location = New System.Drawing.Point(92, 16)
    Me.TxtCategory.MaxLength = 1
    Me.TxtCategory.Name = "TxtCategory"
    Me.TxtCategory.Size = New System.Drawing.Size(19, 20)
    Me.TxtCategory.TabIndex = 200
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(6, 19)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(61, 20)
    Me.Label5.TabIndex = 204
    Me.Label5.Text = "Category"
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(163, 116)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 199
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Location = New System.Drawing.Point(187, 116)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt5.TabIndex = 5
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(163, 64)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 198
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Location = New System.Drawing.Point(187, 64)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt3.TabIndex = 3
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(163, 90)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 197
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Location = New System.Drawing.Point(187, 90)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt4.TabIndex = 4
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(163, 38)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 196
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Location = New System.Drawing.Point(187, 38)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt2.TabIndex = 2
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(163, 15)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 0
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Location = New System.Drawing.Point(187, 15)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 20)
    Me.TxtExempt1.TabIndex = 1
    '
    'FrmTAB02B
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(417, 323)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.ChkLocal)
    Me.Controls.Add(Me.LnkDist)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.ChkFrozenFile)
    Me.Controls.Add(Me.TxtGLYear)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAB02B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region
Dim Mytxdist As TXDIST.MyData

	Public Sub RunReport()
		Dim ErrorField(25) As String
		Dim ErrorMsg(25) As String

		Mytxdist = New TXDIST.mydata(MyDBConnect)

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
Private Sub FrmTAB02B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmTAB02.SbpScreen.Text = "TAB02B"
End Sub
Private Sub FrmTAB02B_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtGLYear, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "dist"
        ErrProv.SetError(TxtDist, ErrorMsg(I))
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
    If MyUtils.CnvSng(TxtDist.Text) <> 0 Then
      Mytxdist.GetOneRecordP(MyUtils.CnvSng(TxtDist.Text))
      If Mytxdist.RecordNotFound Then
        ErrorField(I) = "dist"
        ErrorMsg(I) = "Invalid District"
        I = I + 1
      End If
    End If
  End Sub
Private Sub LnkDist_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkDist.LinkClicked
  MyFrmListDist = New FrmListDist
  MyFrmListDist.MdiParent = Me.ParentForm
  MyFrmListDist.WrkDist = MyUtils.CnvSng(TxtDist.Text)
  MyFrmListDist.Show()
  Me.Hide()
End Sub
Private Sub TxtGLYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGLYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

Private Sub FrmTAB02B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt1.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt1.Text
    MyFrmListExemption.WrkCode = TxtExempt1.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt2.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt2.Text
    MyFrmListExemption.WrkCode = TxtExempt2.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt3.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt3.Text
    MyFrmListExemption.WrkCode = TxtExempt3.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt4.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt4.Text
    MyFrmListExemption.WrkCode = TxtExempt4.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt5.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt5.Text
    MyFrmListExemption.WrkCode = TxtExempt5.Text
    MyFrmListExemption.Show()
  End Sub
End Class






