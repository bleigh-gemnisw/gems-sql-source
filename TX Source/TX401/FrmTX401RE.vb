Imports System.Data
Public Class FrmTX401RE
  Inherits System.Windows.Forms.Form
	Dim myTXREALC As TXREALC.myData
	Dim LoadScrn As Boolean
  Dim AddMode As Boolean

 Dim log_count As Integer
  Friend WithEvents GrpCC As System.Windows.Forms.GroupBox
  Friend WithEvents LblCCDate As System.Windows.Forms.Label
  Friend WithEvents LblCCNo As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents lblccex As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents lblccgrs As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents lblcrdesc As System.Windows.Forms.Label
  Friend WithEvents lblccrs As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents txtacctn As System.Windows.Forms.TextBox
  Friend WithEvents txtbksv As System.Windows.Forms.TextBox
  Friend WithEvents Chkwmail As System.Windows.Forms.CheckBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtMap As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents LnkBkCd As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkBksv As System.Windows.Forms.LinkLabel
  Friend WithEvents txtbkcd As System.Windows.Forms.TextBox
	Friend WithEvents lbltwnbn As System.Windows.Forms.Label
 Friend WithEvents ChkBackTax As System.Windows.Forms.CheckBox
 Friend WithEvents LblLocalBen As System.Windows.Forms.Label
 Friend WithEvents LblElderly As System.Windows.Forms.Label
 Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
	Const WrkType As String = "R"
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
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents LblNet As System.Windows.Forms.Label
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents LblExempt As System.Windows.Forms.Label
	Friend WithEvents LblGross As System.Windows.Forms.Label
	Friend WithEvents Label30 As System.Windows.Forms.Label
	Friend WithEvents Label29 As System.Windows.Forms.Label
	Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
	Friend WithEvents TxtCity As System.Windows.Forms.TextBox
	Friend WithEvents TxtState As System.Windows.Forms.TextBox
	Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
	Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
	Friend WithEvents TxtSname As System.Windows.Forms.TextBox
	Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
	Friend WithEvents TxtName As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GrpCC = New System.Windows.Forms.GroupBox()
    Me.lblccrs = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.lblcrdesc = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.lblccex = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.lblccgrs = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TxtOid = New System.Windows.Forms.TextBox()
    Me.txtbksv = New System.Windows.Forms.TextBox()
    Me.txtacctn = New System.Windows.Forms.TextBox()
    Me.Chkwmail = New System.Windows.Forms.CheckBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.LnkBkCd = New System.Windows.Forms.LinkLabel()
    Me.txtbkcd = New System.Windows.Forms.TextBox()
    Me.LnkBksv = New System.Windows.Forms.LinkLabel()
    Me.lbltwnbn = New System.Windows.Forms.Label()
    Me.ChkBackTax = New System.Windows.Forms.CheckBox()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.LblLocalBen = New System.Windows.Forms.Label()
    Me.LblElderly = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GrpCC.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblNet)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblExempt)
    Me.GroupBox2.Controls.Add(Me.LblGross)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.Label29)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(484, 4)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(136, 72)
    Me.GroupBox2.TabIndex = 143
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(64, 48)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(64, 16)
    Me.LblNet.TabIndex = 21
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(8, 48)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Net"
    '
    'LblExempt
    '
    Me.LblExempt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(64, 32)
    Me.LblExempt.Name = "LblExempt"
    Me.LblExempt.Size = New System.Drawing.Size(64, 16)
    Me.LblExempt.TabIndex = 19
    Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(64, 16)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(64, 16)
    Me.LblGross.TabIndex = 18
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(48, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Exempt"
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(8, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(40, 16)
    Me.Label29.TabIndex = 15
    Me.Label29.Text = "Gross"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(399, 128)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(43, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 128)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(312, 128)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 104)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 80)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(96, 56)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(344, 128)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(50, 22)
    Me.TxtZip5.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 128)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 142
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 141
    Me.Label3.Text = "Street Address"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 56)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 140
    Me.Label2.Text = "Second Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(96, 8)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(64, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(96, 32)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 139
    Me.Label1.Text = "List No"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(8, 32)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 138
    Me.Label5.Text = "Name"
    '
    'GrpCC
    '
    Me.GrpCC.BackColor = System.Drawing.SystemColors.Control
    Me.GrpCC.Controls.Add(Me.lblccrs)
    Me.GrpCC.Controls.Add(Me.Label11)
    Me.GrpCC.Controls.Add(Me.lblcrdesc)
    Me.GrpCC.Controls.Add(Me.Label9)
    Me.GrpCC.Controls.Add(Me.lblccex)
    Me.GrpCC.Controls.Add(Me.Label7)
    Me.GrpCC.Controls.Add(Me.lblccgrs)
    Me.GrpCC.Controls.Add(Me.Label6)
    Me.GrpCC.Controls.Add(Me.LblCCDate)
    Me.GrpCC.Controls.Add(Me.LblCCNo)
    Me.GrpCC.Controls.Add(Me.Label31)
    Me.GrpCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpCC.Location = New System.Drawing.Point(303, 266)
    Me.GrpCC.Name = "GrpCC"
    Me.GrpCC.Size = New System.Drawing.Size(317, 108)
    Me.GrpCC.TabIndex = 158
    Me.GrpCC.TabStop = False
    Me.GrpCC.Text = "C/C Information"
    '
    'lblccrs
    '
    Me.lblccrs.BackColor = System.Drawing.SystemColors.Control
    Me.lblccrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblccrs.Location = New System.Drawing.Point(82, 87)
    Me.lblccrs.Name = "lblccrs"
    Me.lblccrs.Size = New System.Drawing.Size(19, 16)
    Me.lblccrs.TabIndex = 142
    Me.lblccrs.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label11
    '
    Me.Label11.BackColor = System.Drawing.SystemColors.Control
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(6, 87)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(60, 16)
    Me.Label11.TabIndex = 141
    Me.Label11.Text = "Reason"
    '
    'lblcrdesc
    '
    Me.lblcrdesc.BackColor = System.Drawing.SystemColors.Control
    Me.lblcrdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblcrdesc.Location = New System.Drawing.Point(141, 87)
    Me.lblcrdesc.Name = "lblcrdesc"
    Me.lblcrdesc.Size = New System.Drawing.Size(159, 16)
    Me.lblcrdesc.TabIndex = 140
    Me.lblcrdesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label9
    '
    Me.Label9.BackColor = System.Drawing.SystemColors.Control
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(6, 71)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(60, 16)
    Me.Label9.TabIndex = 139
    Me.Label9.Text = "Exemption"
    '
    'lblccex
    '
    Me.lblccex.BackColor = System.Drawing.SystemColors.Control
    Me.lblccex.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblccex.Location = New System.Drawing.Point(83, 71)
    Me.lblccex.Name = "lblccex"
    Me.lblccex.Size = New System.Drawing.Size(64, 16)
    Me.lblccex.TabIndex = 138
    Me.lblccex.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 55)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(71, 16)
    Me.Label7.TabIndex = 137
    Me.Label7.Text = "Assessment"
    '
    'lblccgrs
    '
    Me.lblccgrs.BackColor = System.Drawing.SystemColors.Control
    Me.lblccgrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblccgrs.Location = New System.Drawing.Point(83, 55)
    Me.lblccgrs.Name = "lblccgrs"
    Me.lblccgrs.Size = New System.Drawing.Size(64, 16)
    Me.lblccgrs.TabIndex = 136
    Me.lblccgrs.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(6, 39)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(60, 16)
    Me.Label6.TabIndex = 135
    Me.Label6.Text = "Date"
    '
    'LblCCDate
    '
    Me.LblCCDate.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCDate.Location = New System.Drawing.Point(83, 39)
    Me.LblCCDate.Name = "LblCCDate"
    Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
    Me.LblCCDate.TabIndex = 134
    Me.LblCCDate.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblCCNo
    '
    Me.LblCCNo.BackColor = System.Drawing.SystemColors.Control
    Me.LblCCNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCCNo.Location = New System.Drawing.Point(83, 23)
    Me.LblCCNo.Name = "LblCCNo"
    Me.LblCCNo.Size = New System.Drawing.Size(64, 16)
    Me.LblCCNo.TabIndex = 127
    Me.LblCCNo.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label31
    '
    Me.Label31.BackColor = System.Drawing.SystemColors.Control
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(6, 23)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(60, 16)
    Me.Label31.TabIndex = 11
    Me.Label31.Text = "Number"
    '
    'Label13
    '
    Me.Label13.BackColor = System.Drawing.SystemColors.Control
    Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label13.Location = New System.Drawing.Point(377, 214)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(96, 16)
    Me.Label13.TabIndex = 161
    Me.Label13.Text = "Escrow Account"
    '
    'Label10
    '
    Me.Label10.BackColor = System.Drawing.SystemColors.Control
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(8, 184)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 16)
    Me.Label10.TabIndex = 160
    Me.Label10.Text = "District Code"
    '
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(11, 360)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(77, 16)
    Me.Label8.TabIndex = 159
    Me.Label8.Text = "Local Benefit"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(96, 181)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(30, 22)
    Me.TxtDist.TabIndex = 12
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.Location = New System.Drawing.Point(158, 185)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(24, 16)
    Me.Label17.TabIndex = 169
    Me.Label17.Text = "I.D."
    '
    'TxtOid
    '
    Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOid.Location = New System.Drawing.Point(199, 181)
    Me.TxtOid.MaxLength = 15
    Me.TxtOid.Name = "TxtOid"
    Me.TxtOid.Size = New System.Drawing.Size(129, 22)
    Me.TxtOid.TabIndex = 13
    '
    'txtbksv
    '
    Me.txtbksv.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtbksv.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbksv.Location = New System.Drawing.Point(334, 212)
    Me.txtbksv.MaxLength = 1
    Me.txtbksv.Name = "txtbksv"
    Me.txtbksv.Size = New System.Drawing.Size(18, 22)
    Me.txtbksv.TabIndex = 18
    '
    'txtacctn
    '
    Me.txtacctn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtacctn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtacctn.Location = New System.Drawing.Point(472, 212)
    Me.txtacctn.MaxLength = 15
    Me.txtacctn.Name = "txtacctn"
    Me.txtacctn.Size = New System.Drawing.Size(128, 22)
    Me.txtacctn.TabIndex = 19
    '
    'Chkwmail
    '
    Me.Chkwmail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.Chkwmail.Location = New System.Drawing.Point(11, 213)
    Me.Chkwmail.Name = "Chkwmail"
    Me.Chkwmail.Size = New System.Drawing.Size(94, 17)
    Me.Chkwmail.TabIndex = 14
    Me.Chkwmail.Text = "Mail To Bank"
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(168, 153)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(208, 22)
    Me.TxtLoc.TabIndex = 10
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(96, 153)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(64, 22)
    Me.TxtLocNo.TabIndex = 9
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(8, 153)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(88, 16)
    Me.Label14.TabIndex = 177
    Me.Label14.Text = "Location#/Name"
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMap.Location = New System.Drawing.Point(472, 157)
    Me.TxtMap.MaxLength = 17
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(144, 22)
    Me.TxtMap.TabIndex = 11
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(378, 157)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(88, 16)
    Me.Label18.TabIndex = 179
    Me.Label18.Text = "Map Block Lot"
    '
    'LnkBkCd
    '
    Me.LnkBkCd.Location = New System.Drawing.Point(135, 212)
    Me.LnkBkCd.Name = "LnkBkCd"
    Me.LnkBkCd.Size = New System.Drawing.Size(71, 17)
    Me.LnkBkCd.TabIndex = 15
    Me.LnkBkCd.TabStop = True
    Me.LnkBkCd.Text = "Bank Code"
    '
    'txtbkcd
    '
    Me.txtbkcd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtbkcd.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.txtbkcd.Location = New System.Drawing.Point(199, 211)
    Me.txtbkcd.MaxLength = 2
    Me.txtbkcd.Name = "txtbkcd"
    Me.txtbkcd.Size = New System.Drawing.Size(24, 22)
    Me.txtbkcd.TabIndex = 16
    '
    'LnkBksv
    '
    Me.LnkBksv.Location = New System.Drawing.Point(256, 214)
    Me.LnkBksv.Name = "LnkBksv"
    Me.LnkBksv.Size = New System.Drawing.Size(72, 15)
    Me.LnkBksv.TabIndex = 17
    Me.LnkBksv.TabStop = True
    Me.LnkBksv.Text = "Bank Service"
    '
    'lbltwnbn
    '
    Me.lbltwnbn.BackColor = System.Drawing.SystemColors.Control
    Me.lbltwnbn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lbltwnbn.Location = New System.Drawing.Point(93, 358)
    Me.lbltwnbn.Name = "lbltwnbn"
    Me.lbltwnbn.Size = New System.Drawing.Size(92, 16)
    Me.lbltwnbn.TabIndex = 185
    Me.lbltwnbn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ChkBackTax
    '
    Me.ChkBackTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBackTax.Location = New System.Drawing.Point(14, 235)
    Me.ChkBackTax.Name = "ChkBackTax"
    Me.ChkBackTax.Size = New System.Drawing.Size(91, 19)
    Me.ChkBackTax.TabIndex = 20
    Me.ChkBackTax.Text = "Back Tax?"
    Me.ChkBackTax.UseVisualStyleBackColor = True
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(390, 16)
    Me.LblTaxExempt.Name = "LblTaxExempt"
    Me.LblTaxExempt.Size = New System.Drawing.Size(94, 20)
    Me.LblTaxExempt.TabIndex = 197
    Me.LblTaxExempt.Text = "Tax Exempt"
    Me.LblTaxExempt.Visible = False
    '
    'LblLocalBen
    '
    Me.LblLocalBen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLocalBen.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblLocalBen.Location = New System.Drawing.Point(384, 56)
    Me.LblLocalBen.Name = "LblLocalBen"
    Me.LblLocalBen.Size = New System.Drawing.Size(94, 20)
    Me.LblLocalBen.TabIndex = 199
    Me.LblLocalBen.Text = "Local Benefit"
    Me.LblLocalBen.Visible = False
    '
    'LblElderly
    '
    Me.LblElderly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblElderly.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblElderly.Location = New System.Drawing.Point(419, 36)
    Me.LblElderly.Name = "LblElderly"
    Me.LblElderly.Size = New System.Drawing.Size(59, 20)
    Me.LblElderly.TabIndex = 198
    Me.LblElderly.Text = "Elderly "
    Me.LblElderly.Visible = False
    '
    'FrmTX401RE
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(632, 386)
    Me.Controls.Add(Me.LblLocalBen)
    Me.Controls.Add(Me.LblElderly)
    Me.Controls.Add(Me.LblTaxExempt)
    Me.Controls.Add(Me.ChkBackTax)
    Me.Controls.Add(Me.lbltwnbn)
    Me.Controls.Add(Me.LnkBksv)
    Me.Controls.Add(Me.txtbkcd)
    Me.Controls.Add(Me.LnkBkCd)
    Me.Controls.Add(Me.TxtMap)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Chkwmail)
    Me.Controls.Add(Me.txtacctn)
    Me.Controls.Add(Me.txtbksv)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.TxtOid)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.GrpCC)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label5)
    Me.ForeColor = System.Drawing.Color.Black
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX401RE"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Real Estate "
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GrpCC.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region


Private Sub FrmTX401RE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	Dim WrkListNo As Integer
	myTXREALC = New TXREALC.mydata(MyDBConnect)

	LoadScrn = True
	MyFrmTX401.TBarSave.Enabled = True

	AddMode = False
	If s_chg = False And s_full = False Then	'#sec
		MyFrmTX401.TBarSave.Visible = False	 '#sec
	End If	'#sec

	'Fill the dataset with the existing data
 ' Me.Text = "Maintain " & Me.Text
	TxtListNo.ReadOnly = True
	TxtListNo.TabStop = False

	TxtName.ReadOnly = True
	TxtName.TabStop = False
	TxtMap.ReadOnly = True
	TxtMap.TabStop = False
	WrkListNo = ProcessSelItems()
	LoadForm(WrkListNo)
	End Sub
Private Sub LoadForm(ByVal WrkListNo As Integer)
		TxtListNo.Text = WrkListNo
		myTXREALC.GetOneRecordP(WrkListNo)
		If myTXREALC.RecordNotFound Then
			MyFrmTX401.TBarSave.Enabled = False
			Me.ErrProv.SetError(TxtListNo, "Record not found")
			Exit Sub
		End If

		With myTXREALC
      If ._CAT = "1" Then
        LblTaxExempt.Visible = False
      Else
        LblTaxExempt.Visible = True
      End If
      LblLocalBen.Visible = False
      If ._TWNBN > 0 Then
        LblLocalBen.Visible = True
      End If
      Select Case Trim(._FCCOD)
        Case Is = "C", "F"
          LblElderly.Visible = True
        Case Else
          LblElderly.Visible = False
      End Select
      TxtName.Text = Trim(._NAME)
      TxtSname.Text = Trim(._SNAME)
      TxtAdd1.Text = Trim(._ADD1)
      TxtAdd2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      TxtZip5.Text = Format(._ZIP5, "00000")
      TxtZip4.Text = Format(._ZIP4, "0000")
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
      TxtOid.Text = Trim(._OID)
      TxtDist.Text = ._DIST
      TxtMap.Text = Trim(._MAP)
      If Trim(._WMAIL) = "Y" Then
        Chkwmail.Checked = True
      End If

      txtbkcd.Text = Trim(._BKCD)
      txtbksv.Text = Trim(._BKSV)
      txtacctn.Text = Trim(._ACCTN)
      ChkBackTax.Checked = False
      If Trim(._BTC) <> String.Empty Then
        ChkBackTax.Checked = True
      End If
      lbltwnbn.Text = Format(._TWNBN, "standard")
      LblGross.Text = ._GROSS + ._BTR
      LblExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 _
        + ._EXAM5 + ._EXAM6 + ._EXAM7
      LblNet.Text = ._NET + ._BTR

      LblCCNo.Text = ""
      LblCCDate.Text = ""
      lblccgrs.Text = ""
      lblccex.Text = ""
      lblccrs.Text = ""
      lblcrdesc.Text = ""
      If ._CCNO > 0 Then
        LblCCNo.Text = ._CCNO
        LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
        lblcrdesc.Text = GetTXCRESNDesc(._CCRS)
        lblccrs.Text = Trim(._CCRS)
        lblccgrs.Text = Format(._CCGRS, "###,###,###")
        lblccex.Text = Format(._CCEX, "###,###,###")
      End If
    End With

		LoadScrn = False
End Sub
Private Sub FrmTX401RE_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim WrkListNo As Integer

		WrkListNo = ProcessSelItems()
		If WrkListNo > 0 Then
			LoadForm(WrkListNo)
			e.Cancel = True
		End If

End Sub
	Private Sub FrmTX401RE_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		MyFrmTX401.TBarSave.Enabled = False
		MyFrmTX401.TBarSave.Visible = True	 '#sec
		If s_chg = False And s_full = False Then	'#sec
			MyFrmTX401.TBarSave.Visible = False	 '#sec
		End If	'#sec
		MyFrmTX401.TBarComments.Enabled = False
		MyFrmTX401B.FormatGrid(False)
		MyFrmTX401B.Show()
		'Memory Cleanup
		myTXREALC = Nothing

		MyFrmTX401RE = Nothing
	End Sub
	Public Sub SaveData()
		Dim ErrorField(50) As String
		Dim ErrorMsg(50) As String
		Dim WrkListNo As Integer

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    myTXREALC.GetOneRecordP(WrkListNo)
    MoveToFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXREALC.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    Me.Close()
  End Sub

  Private Sub MoveToFile()
    With myTXREALC
      ._NAME = TxtName.Text
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._LOC = TxtLoc.Text
      ._OID = TxtOid.Text
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._MAP = TxtMap.Text
      ._WMAIL = "N"
      If Chkwmail.Checked Then
        ._WMAIL = "Y"
      End If
      ._BKCD = txtbkcd.Text
      ._BKSV = txtbksv.Text
      ._ACCTN = txtacctn.Text
      If ChkBackTax.Checked Then
        ._BTC = "BT"
      Else
        ._BTC = String.Empty
      End If
      ._LETT = Mid$(TxtName.Text, 1, 1)
      SetBankTip()
      SetBksvTip()
    End With

  End Sub

  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtListNo, "")
		ErrProv.SetError(TxtName, "")
		ErrProv.SetError(TxtAdd1, "")
		ErrProv.SetError(TxtCity, "")
		ErrProv.SetError(TxtState, "")
		ErrProv.SetError(TxtZip5, "")
		ErrProv.SetError(txtbkcd, "")
		ErrProv.SetError(txtbksv, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Me.ForeColor = Color.DarkRed
			Select Case ErrorField(I)
			Case "add1"
				ErrProv.SetError(TxtAdd1, ErrorMsg(I))
			Case "city"
				ErrProv.SetError(TxtCity, ErrorMsg(I))
			Case "state"
				ErrProv.SetError(TxtState, ErrorMsg(I))
			Case "bkcd"
				ErrProv.SetError(txtbkcd, ErrorMsg(I))
			Case "bksv"
				ErrProv.SetError(txtbksv, ErrorMsg(I))
			Case Nothing
				Exit Sub
			End Select
		Next I
	End Sub
	Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim WrkTip As String
		Dim I As Integer

		For I = 0 To ErrorField.GetUpperBound(0)
			If IsNothing(ErrorField(I)) Then
				Exit For
			End If
		Next

		If TxtAdd1.Text = String.Empty Then
			ErrorField(I) = "add1"
			ErrorMsg(I) = "Address 1 cannot be blank"
			I = I + 1
		End If

		If TxtCity.Text = String.Empty Then
			ErrorField(I) = "city"
			ErrorMsg(I) = "City cannot be blank"
			I = I + 1
		End If

		If TxtState.Text = String.Empty Then
			ErrorField(I) = "state"
			ErrorMsg(I) = "State cannot be blank"
			I = I + 1
		End If

		If txtbkcd.Text <> "" Then
				WrkTip = Ttp1.GetToolTip(txtbkcd)
				If Mid(WrkTip, 1, 1) = "*" Then
					ErrorField(I) = "bkcd"
					ErrorMsg(I) = "Invalid Bank Code"
					I = I + 1
				End If
			End If
			If txtbksv.Text <> "" Then
				WrkTip = Ttp1.GetToolTip(txtbksv)
				If Mid(WrkTip, 1, 1) = "*" Then
					ErrorField(I) = "bksv"
					ErrorMsg(I) = "Invalid Bank Service"
					I = I + 1
				End If
			End If

	End Sub
	 Private Sub FrmTX401RE_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
	 MyFrmTX401.TBarComments.Enabled = True
	 MyFrmTX401.SbpScreen.Text = "TX401RE"
   MyUtils.CenterForm(Me.ParentForm, Me)
	End Sub

	Private Sub TxtBkCd_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
		SetBankTip()
	End Sub
	Private Sub TxtBkSv_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
		SetBksvTip()
	End Sub

Private Sub SetBankTip()
		Dim WrkDesc As String

		If Not txtbkcd.Modified And Not LoadScrn Then Exit Sub

		WrkDesc = GetTXBanksDesc(txtbkcd.Text)
		Ttp1.SetToolTip(txtbkcd, WrkDesc)
End Sub
Private Sub SetBksvTip()
		Dim WrkDesc As String

		If Not txtbksv.Modified And Not LoadScrn Then Exit Sub

		WrkDesc = GetTXBserDesc(txtbksv.Text)
		Ttp1.SetToolTip(txtbksv, WrkDesc)
End Sub

Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub

 Private Sub LnkBkCd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBkCd.LinkClicked
	MyFrmListBanks = New FrmListBanks
	MyFrmListBanks.MdiParent = Me.ParentForm
	MyFrmListBanks.WrkCode = txtbkcd.Text
	MyFrmListBanks.Show()
End Sub

 Private Sub LnkBksv_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBksv.LinkClicked
		MyFrmListBser = New FrmListBser
		MyFrmListBser.MdiParent = Me.ParentForm
		MyFrmListBser.WrkCode = txtbksv.Text
		MyFrmListBser.Show()
End Sub
 End Class






