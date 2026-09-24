Public Class FrmMainB
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
Friend WithEvents LblName As System.Windows.Forms.Label
Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathPP As System.Windows.Forms.Label
Friend WithEvents LnkFilePathPP As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathRE As System.Windows.Forms.Label
Friend WithEvents LnkFilePathRE As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathMV As System.Windows.Forms.Label
Friend WithEvents LnkFilePathMV As System.Windows.Forms.LinkLabel
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label1 As System.Windows.Forms.Label
Friend WithEvents DtPckDue2 As System.Windows.Forms.DateTimePicker
Friend WithEvents DtPckDue1 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtPayTo As System.Windows.Forms.TextBox
Friend WithEvents TxtLine5 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine4 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine3 As System.Windows.Forms.TextBox
Friend WithEvents TxtLine2 As System.Windows.Forms.TextBox
Friend WithEvents Label9 As System.Windows.Forms.Label
Friend WithEvents TxtLine1 As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtAssrPhone As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtTownNo As System.Windows.Forms.TextBox
Friend WithEvents Label12 As System.Windows.Forms.Label
Friend WithEvents TxtOnline As System.Windows.Forms.TextBox
Friend WithEvents Label13 As System.Windows.Forms.Label
Friend WithEvents TxtTownName As System.Windows.Forms.TextBox
Friend WithEvents Label16 As System.Windows.Forms.Label
Friend WithEvents TxtMaxRecs As System.Windows.Forms.TextBox
Friend WithEvents DtPckGrace2 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label18 As System.Windows.Forms.Label
Friend WithEvents DtPckGrace1 As System.Windows.Forms.DateTimePicker
Friend WithEvents Label17 As System.Windows.Forms.Label
Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathNCOA As System.Windows.Forms.Label
Friend WithEvents LnkFilePathNCOA As System.Windows.Forms.LinkLabel
Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
Friend WithEvents Label19 As System.Windows.Forms.Label
Friend WithEvents TxtGroupID As System.Windows.Forms.TextBox
Friend WithEvents LblTypes As System.Windows.Forms.Label
Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathMS As System.Windows.Forms.Label
Friend WithEvents LnkFilePathMS As System.Windows.Forms.LinkLabel
Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
Friend WithEvents LblFilePathExport As System.Windows.Forms.Label
Friend WithEvents LnkFilePathExport As System.Windows.Forms.LinkLabel
Friend WithEvents RbExport As System.Windows.Forms.RadioButton
Friend WithEvents RbPrint As System.Windows.Forms.RadioButton
Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TTp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.LblName = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.LblFilePathPP = New System.Windows.Forms.Label()
    Me.LnkFilePathPP = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblFilePathRE = New System.Windows.Forms.Label()
    Me.LnkFilePathRE = New System.Windows.Forms.LinkLabel()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LblFilePathMV = New System.Windows.Forms.Label()
    Me.LnkFilePathMV = New System.Windows.Forms.LinkLabel()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.DtPckDue1 = New System.Windows.Forms.DateTimePicker()
    Me.DtPckDue2 = New System.Windows.Forms.DateTimePicker()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtPayTo = New System.Windows.Forms.TextBox()
    Me.TxtLine5 = New System.Windows.Forms.TextBox()
    Me.TxtLine4 = New System.Windows.Forms.TextBox()
    Me.TxtLine3 = New System.Windows.Forms.TextBox()
    Me.TxtLine2 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtLine1 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtAssrPhone = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtTownNo = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtOnline = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtTownName = New System.Windows.Forms.TextBox()
    Me.TxtMaxRecs = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.DtPckGrace1 = New System.Windows.Forms.DateTimePicker()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.DtPckGrace2 = New System.Windows.Forms.DateTimePicker()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblFilePathNCOA = New System.Windows.Forms.Label()
    Me.LnkFilePathNCOA = New System.Windows.Forms.LinkLabel()
    Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.TxtGroupID = New System.Windows.Forms.TextBox()
    Me.LblTypes = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.LblFilePathMS = New System.Windows.Forms.Label()
    Me.LnkFilePathMS = New System.Windows.Forms.LinkLabel()
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.LblFilePathExport = New System.Windows.Forms.Label()
    Me.LnkFilePathExport = New System.Windows.Forms.LinkLabel()
    Me.RbPrint = New System.Windows.Forms.RadioButton()
    Me.RbExport = New System.Windows.Forms.RadioButton()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblName
    '
    Me.LblName.AutoSize = True
    Me.LblName.Location = New System.Drawing.Point(114, 9)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(64, 13)
    Me.LblName.TabIndex = 4
    Me.LblName.Text = "<File name>"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LblFilePathPP)
    Me.GroupBox3.Controls.Add(Me.LnkFilePathPP)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(452, 137)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox3.TabIndex = 5
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "PP Bill File Details"
    '
    'LblFilePathPP
    '
    Me.LblFilePathPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathPP.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathPP.Name = "LblFilePathPP"
    Me.LblFilePathPP.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathPP.TabIndex = 67
    '
    'LnkFilePathPP
    '
    Me.LnkFilePathPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathPP.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathPP.Name = "LnkFilePathPP"
    Me.LnkFilePathPP.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathPP.TabIndex = 65
    Me.LnkFilePathPP.TabStop = True
    Me.LnkFilePathPP.Text = "File Path"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblFilePathRE)
    Me.GroupBox2.Controls.Add(Me.LnkFilePathRE)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(451, 75)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox2.TabIndex = 4
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "RE Bill File Details"
    '
    'LblFilePathRE
    '
    Me.LblFilePathRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathRE.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathRE.Name = "LblFilePathRE"
    Me.LblFilePathRE.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathRE.TabIndex = 67
    '
    'LnkFilePathRE
    '
    Me.LnkFilePathRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathRE.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathRE.Name = "LnkFilePathRE"
    Me.LnkFilePathRE.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathRE.TabIndex = 65
    Me.LnkFilePathRE.TabStop = True
    Me.LnkFilePathRE.Text = "File Path"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LblFilePathMV)
    Me.GroupBox1.Controls.Add(Me.LnkFilePathMV)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(452, 199)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox1.TabIndex = 3
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "MV Bill File Details"
    '
    'LblFilePathMV
    '
    Me.LblFilePathMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathMV.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathMV.Name = "LblFilePathMV"
    Me.LblFilePathMV.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathMV.TabIndex = 67
    '
    'LnkFilePathMV
    '
    Me.LnkFilePathMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathMV.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathMV.Name = "LnkFilePathMV"
    Me.LnkFilePathMV.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathMV.TabIndex = 65
    Me.LnkFilePathMV.TabStop = True
    Me.LnkFilePathMV.Text = "File Path"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(19, 53)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(62, 13)
    Me.Label1.TabIndex = 78
    Me.Label1.Text = "Due Date 1"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(202, 53)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(62, 13)
    Me.Label3.TabIndex = 79
    Me.Label3.Text = "Due Date 2"
    '
    'DtPckDue1
    '
    Me.DtPckDue1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDue1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue1.Location = New System.Drawing.Point(87, 49)
    Me.DtPckDue1.Name = "DtPckDue1"
    Me.DtPckDue1.Size = New System.Drawing.Size(88, 20)
    Me.DtPckDue1.TabIndex = 6
    '
    'DtPckDue2
    '
    Me.DtPckDue2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckDue2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue2.Location = New System.Drawing.Point(270, 49)
    Me.DtPckDue2.Name = "DtPckDue2"
    Me.DtPckDue2.Size = New System.Drawing.Size(88, 20)
    Me.DtPckDue2.TabIndex = 7
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(19, 261)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(80, 20)
    Me.Label7.TabIndex = 94
    Me.Label7.Text = "Line 5"
    Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(19, 211)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 20)
    Me.Label6.TabIndex = 93
    Me.Label6.Text = "Line 4"
    Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(19, 183)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(88, 20)
    Me.Label5.TabIndex = 92
    Me.Label5.Text = "Line 3"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label4.Location = New System.Drawing.Point(19, 155)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 20)
    Me.Label4.TabIndex = 91
    Me.Label4.Text = "Line 2"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(19, 103)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(88, 20)
    Me.Label8.TabIndex = 90
    Me.Label8.Text = "Pay to"
    Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtPayTo
    '
    Me.TxtPayTo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPayTo.Location = New System.Drawing.Point(113, 103)
    Me.TxtPayTo.MaxLength = 30
    Me.TxtPayTo.Name = "TxtPayTo"
    Me.TxtPayTo.Size = New System.Drawing.Size(250, 22)
    Me.TxtPayTo.TabIndex = 8
    '
    'TxtLine5
    '
    Me.TxtLine5.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine5.Location = New System.Drawing.Point(113, 261)
    Me.TxtLine5.MaxLength = 60
    Me.TxtLine5.Name = "TxtLine5"
    Me.TxtLine5.Size = New System.Drawing.Size(326, 20)
    Me.TxtLine5.TabIndex = 13
    '
    'TxtLine4
    '
    Me.TxtLine4.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine4.Location = New System.Drawing.Point(113, 211)
    Me.TxtLine4.MaxLength = 90
    Me.TxtLine4.Multiline = True
    Me.TxtLine4.Name = "TxtLine4"
    Me.TxtLine4.Size = New System.Drawing.Size(326, 40)
    Me.TxtLine4.TabIndex = 12
    '
    'TxtLine3
    '
    Me.TxtLine3.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine3.Location = New System.Drawing.Point(113, 183)
    Me.TxtLine3.MaxLength = 60
    Me.TxtLine3.Name = "TxtLine3"
    Me.TxtLine3.Size = New System.Drawing.Size(326, 20)
    Me.TxtLine3.TabIndex = 11
    '
    'TxtLine2
    '
    Me.TxtLine2.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine2.Location = New System.Drawing.Point(113, 155)
    Me.TxtLine2.MaxLength = 60
    Me.TxtLine2.Name = "TxtLine2"
    Me.TxtLine2.Size = New System.Drawing.Size(326, 20)
    Me.TxtLine2.TabIndex = 10
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(19, 129)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(88, 20)
    Me.Label9.TabIndex = 86
    Me.Label9.Text = "Line 1"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtLine1
    '
    Me.TxtLine1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLine1.Location = New System.Drawing.Point(113, 129)
    Me.TxtLine1.MaxLength = 60
    Me.TxtLine1.Name = "TxtLine1"
    Me.TxtLine1.Size = New System.Drawing.Size(326, 20)
    Me.TxtLine1.TabIndex = 9
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(21, 314)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(88, 20)
    Me.Label10.TabIndex = 96
    Me.Label10.Text = "Assessor Phone"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtAssrPhone
    '
    Me.TxtAssrPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssrPhone.Location = New System.Drawing.Point(115, 314)
    Me.TxtAssrPhone.MaxLength = 20
    Me.TxtAssrPhone.Name = "TxtAssrPhone"
    Me.TxtAssrPhone.Size = New System.Drawing.Size(145, 22)
    Me.TxtAssrPhone.TabIndex = 15
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(20, 15)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(51, 13)
    Me.Label11.TabIndex = 98
    Me.Label11.Text = "Town No"
    '
    'TxtTownNo
    '
    Me.TxtTownNo.Location = New System.Drawing.Point(78, 12)
    Me.TxtTownNo.Name = "TxtTownNo"
    Me.TxtTownNo.Size = New System.Drawing.Size(30, 20)
    Me.TxtTownNo.TabIndex = 0
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(19, 286)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(90, 20)
    Me.Label12.TabIndex = 100
    Me.Label12.Text = "Online Payments"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtOnline
    '
    Me.TxtOnline.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOnline.Location = New System.Drawing.Point(113, 286)
    Me.TxtOnline.MaxLength = 60
    Me.TxtOnline.Name = "TxtOnline"
    Me.TxtOnline.Size = New System.Drawing.Size(326, 20)
    Me.TxtOnline.TabIndex = 14
    '
    'Label13
    '
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(19, 75)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(88, 20)
    Me.Label13.TabIndex = 102
    Me.Label13.Text = "Town Name"
    Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtTownName
    '
    Me.TxtTownName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTownName.Location = New System.Drawing.Point(113, 75)
    Me.TxtTownName.MaxLength = 30
    Me.TxtTownName.Name = "TxtTownName"
    Me.TxtTownName.Size = New System.Drawing.Size(250, 22)
    Me.TxtTownName.TabIndex = 101
    '
    'TxtMaxRecs
    '
    Me.TxtMaxRecs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMaxRecs.Location = New System.Drawing.Point(177, 420)
    Me.TxtMaxRecs.MaxLength = 10
    Me.TxtMaxRecs.Name = "TxtMaxRecs"
    Me.TxtMaxRecs.Size = New System.Drawing.Size(36, 20)
    Me.TxtMaxRecs.TabIndex = 107
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(12, 423)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(159, 17)
    Me.Label16.TabIndex = 108
    Me.Label16.Text = "SAMPLE: Limit No of record to "
    '
    'DtPckGrace1
    '
    Me.DtPckGrace1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckGrace1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace1.Location = New System.Drawing.Point(467, 49)
    Me.DtPckGrace1.Name = "DtPckGrace1"
    Me.DtPckGrace1.Size = New System.Drawing.Size(88, 20)
    Me.DtPckGrace1.TabIndex = 109
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(388, 53)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(71, 13)
    Me.Label17.TabIndex = 110
    Me.Label17.Text = "Grace Date 1"
    '
    'DtPckGrace2
    '
    Me.DtPckGrace2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckGrace2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace2.Location = New System.Drawing.Point(658, 49)
    Me.DtPckGrace2.Name = "DtPckGrace2"
    Me.DtPckGrace2.Size = New System.Drawing.Size(88, 20)
    Me.DtPckGrace2.TabIndex = 111
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(579, 53)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(71, 13)
    Me.Label18.TabIndex = 112
    Me.Label18.Text = "Grace Date 2"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblFilePathNCOA)
    Me.GroupBox4.Controls.Add(Me.LnkFilePathNCOA)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(452, 326)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox4.TabIndex = 113
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "NCOA File Details"
    '
    'LblFilePathNCOA
    '
    Me.LblFilePathNCOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathNCOA.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathNCOA.Name = "LblFilePathNCOA"
    Me.LblFilePathNCOA.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathNCOA.TabIndex = 67
    '
    'LnkFilePathNCOA
    '
    Me.LnkFilePathNCOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathNCOA.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathNCOA.Name = "LnkFilePathNCOA"
    Me.LnkFilePathNCOA.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathNCOA.TabIndex = 65
    Me.LnkFilePathNCOA.TabStop = True
    Me.LnkFilePathNCOA.Text = "File Path"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(249, 423)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(50, 13)
    Me.Label19.TabIndex = 115
    Me.Label19.Text = "Group ID"
    '
    'TxtGroupID
    '
    Me.TxtGroupID.Location = New System.Drawing.Point(305, 418)
    Me.TxtGroupID.Name = "TxtGroupID"
    Me.TxtGroupID.Size = New System.Drawing.Size(28, 20)
    Me.TxtGroupID.TabIndex = 114
    '
    'LblTypes
    '
    Me.LblTypes.AutoSize = True
    Me.LblTypes.Location = New System.Drawing.Point(114, 22)
    Me.LblTypes.Name = "LblTypes"
    Me.LblTypes.Size = New System.Drawing.Size(48, 13)
    Me.LblTypes.TabIndex = 116
    Me.LblTypes.Text = "<Types>"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.LblFilePathMS)
    Me.GroupBox5.Controls.Add(Me.LnkFilePathMS)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(453, 261)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox5.TabIndex = 117
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "MS Bill File Details"
    '
    'LblFilePathMS
    '
    Me.LblFilePathMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathMS.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathMS.Name = "LblFilePathMS"
    Me.LblFilePathMS.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathMS.TabIndex = 67
    '
    'LnkFilePathMS
    '
    Me.LnkFilePathMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathMS.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathMS.Name = "LnkFilePathMS"
    Me.LnkFilePathMS.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathMS.TabIndex = 65
    Me.LnkFilePathMS.TabStop = True
    Me.LnkFilePathMS.Text = "File Path"
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.LblFilePathExport)
    Me.GroupBox6.Controls.Add(Me.LnkFilePathExport)
    Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox6.Location = New System.Drawing.Point(451, 388)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(408, 56)
    Me.GroupBox6.TabIndex = 118
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Export File Details"
    '
    'LblFilePathExport
    '
    Me.LblFilePathExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFilePathExport.Location = New System.Drawing.Point(72, 16)
    Me.LblFilePathExport.Name = "LblFilePathExport"
    Me.LblFilePathExport.Size = New System.Drawing.Size(324, 36)
    Me.LblFilePathExport.TabIndex = 67
    '
    'LnkFilePathExport
    '
    Me.LnkFilePathExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkFilePathExport.Location = New System.Drawing.Point(12, 24)
    Me.LnkFilePathExport.Name = "LnkFilePathExport"
    Me.LnkFilePathExport.Size = New System.Drawing.Size(52, 16)
    Me.LnkFilePathExport.TabIndex = 65
    Me.LnkFilePathExport.TabStop = True
    Me.LnkFilePathExport.Text = "File Path"
    '
    'RbPrint
    '
    Me.RbPrint.AutoSize = True
    Me.RbPrint.Location = New System.Drawing.Point(205, 15)
    Me.RbPrint.Name = "RbPrint"
    Me.RbPrint.Size = New System.Drawing.Size(67, 17)
    Me.RbPrint.TabIndex = 119
    Me.RbPrint.Text = "Print Bills"
    Me.RbPrint.UseVisualStyleBackColor = True
    '
    'RbExport
    '
    Me.RbExport.AutoSize = True
    Me.RbExport.Checked = True
    Me.RbExport.Location = New System.Drawing.Point(278, 15)
    Me.RbExport.Name = "RbExport"
    Me.RbExport.Size = New System.Drawing.Size(55, 17)
    Me.RbExport.TabIndex = 120
    Me.RbExport.TabStop = True
    Me.RbExport.Text = "Export"
    Me.RbExport.UseVisualStyleBackColor = True
    '
    'FrmMainB
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(871, 450)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbExport)
    Me.Controls.Add(Me.RbPrint)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.LblTypes)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.TxtGroupID)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.DtPckGrace2)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.DtPckGrace1)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.TxtMaxRecs)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtTownName)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtOnline)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtTownNo)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtAssrPhone)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtPayTo)
    Me.Controls.Add(Me.TxtLine5)
    Me.Controls.Add(Me.TxtLine4)
    Me.Controls.Add(Me.TxtLine3)
    Me.Controls.Add(Me.TxtLine2)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtLine1)
    Me.Controls.Add(Me.DtPckDue2)
    Me.Controls.Add(Me.DtPckDue1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblName)
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMainB"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox6.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Public Sub RunBills()
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
    ProcBills()
    Windows.Forms.Cursor.Current = Cursors.Default

  End Sub
Private Sub FrmMainB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    MyFrmMain.SbpPgmID.Text = "Main"
    LblName.Text = ""
    LblTypes.Text = ""
End Sub
Private Sub LoadSettings()
    Dim WrkDate As Date
    MyTownNo = CnvSng(TxtTownNo.Text)
    GetAppSettings()
    If MyAppSettings.DBName = String.Empty Then Exit Sub

    With MyFrmMainB
      .LblName.Text = MyAppSettings.DBName
      If MyAppSettings.IsRPM Then
        .LblTypes.Text = "R/P/M"
      Else
        .LblTypes.Text = "S"
      End If
      .LblFilePathRE.Text = MyAppSettings.REFile
      .LblFilePathPP.Text = MyAppSettings.PPFile
      .LblFilePathMV.Text = MyAppSettings.MVFile
      .LblFilePathMS.Text = MyAppSettings.MSFile
      .LblFilePathNCOA.Text = MyAppSettings.NCOAFile
      .LblFilePathExport.Text = MyAppSettings.ExportFile
      If MyAppSettings.DueDate1 <> WrkDate Then
        .DtPckDue1.Value = MyAppSettings.DueDate1
        .DtPckDue2.Value = MyAppSettings.DueDate2
      End If
      If MyAppSettings.GraceDate1 <> WrkDate Then
        .DtPckGrace1.Value = MyAppSettings.GraceDate1
        .DtPckGrace2.Value = MyAppSettings.GraceDate2
      End If
      .TxtTownName.Text = MyAppSettings.TownName
      .TxtPayTo.Text = MyAppSettings.PayTo
      .TxtLine1.Text = MyAppSettings.Line1
      .TxtLine2.Text = MyAppSettings.Line2
      .TxtLine3.Text = MyAppSettings.Line3
      .TxtLine4.Text = MyAppSettings.Line4
      .TxtLine5.Text = MyAppSettings.Line5
      .TxtOnline.Text = MyAppSettings.Online
      .TxtAssrPhone.Text = MyAppSettings.AssrPhone
    End With
End Sub
Private Sub FrmMainB_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
  MyFrmMain.SbpScreen.Text = "MainB"
End Sub
Private Sub FrmMainB_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
  Me.Refresh()
End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(LblFilePathMV, "")
    ErrProv.SetError(LblFilePathNCOA, "")
    ErrProv.SetError(LblFilePathPP, "")
    ErrProv.SetError(LblFilePathRE, "")
    ErrProv.SetError(LblFilePathMS, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "MV"
        ErrProv.SetError(LblFilePathMV, ErrorMsg(I))
      Case "NCOA"
        ErrProv.SetError(LblFilePathNCOA, ErrorMsg(I))
      Case "PP"
        ErrProv.SetError(LblFilePathPP, ErrorMsg(I))
      Case "RE"
        ErrProv.SetError(LblFilePathRE, ErrorMsg(I))
      Case "MS"
        ErrProv.SetError(LblFilePathMS, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    Dim Good As Boolean

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblFilePathNCOA.Text = "" Then
      ErrorField(I) = "NCOA"
      ErrorMsg(I) = "Invalid File"
      I = I + 1
    End If

    If LblTypes.Text <> "S" Then
      If LblFilePathRE.Text <> "" Then
        Good = CheckFileExists(LblFilePathRE.Text)
        If Not Good Then
          ErrorField(I) = "RE"
          ErrorMsg(I) = "Invalid File"
          I = I + 1
        End If
      End If
      If LblFilePathPP.Text <> "" Then
        Good = CheckFileExists(LblFilePathPP.Text)
        If Not Good Then
          ErrorField(I) = "PP"
          ErrorMsg(I) = "Invalid File"
          I = I + 1
        End If
      End If
      If LblFilePathMV.Text <> "" Then
        Good = CheckFileExists(LblFilePathMV.Text)
        If Not Good Then
          ErrorField(I) = "MV"
          ErrorMsg(I) = "Invalid File"
          I = I + 1
        End If
      End If
    Else
      If LblFilePathMS.Text <> "" Then
        Good = CheckFileExists(LblFilePathMS.Text)
        If Not Good Then
          ErrorField(I) = "MS"
          ErrorMsg(I) = "Invalid File"
          I = I + 1
        End If
      End If
    End If
 End Sub
Private Sub LnkFilePathMV_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathMV.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathMV.Text = .FileName
  End With
End Sub
Private Sub LnkFilePathRE_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathRE.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathRE.Text = .FileName
  End With
End Sub
Private Sub LnkFilePathPP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathPP.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathPP.Text = .FileName
  End With
End Sub
  Private Sub TxtTownNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTownNo.LostFocus
    LoadSettings()
  End Sub
Private Sub LnkFilePathNCOA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkFilePathNCOA.LinkClicked
  With SaveFileDialog1
   .ShowDialog()
   LblFilePathNCOA.Text = .FileName
  End With
End Sub
Private Sub LnkFilePathMS_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePathMS.LinkClicked
  With OpenFileDialog1
   .ShowDialog()
   LblFilePathMS.Text = .FileName
  End With
End Sub

Private Sub LnkFilePathExport_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkFilePathExport.LinkClicked
  With SaveFileDialog1
   .ShowDialog()
   LblFilePathExport.Text = .FileName
  End With
End Sub

Private Sub TxtTownNo_TextChanged(sender As Object, e As EventArgs) Handles TxtTownNo.TextChanged

End Sub
End Class
