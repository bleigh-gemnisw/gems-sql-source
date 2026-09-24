Public Class FrmTX401SU
  Inherits System.Windows.Forms.Form
	Dim myTXSUPP As TXSupp.myData
	Const WrkType As String = "S"
  Dim LoadScrn As Boolean
  Dim AddMode As Boolean

	Friend WithEvents GrpCC As System.Windows.Forms.GroupBox
	Friend WithEvents lblccrs As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label
	Friend WithEvents lblcrdesc As System.Windows.Forms.Label
	Friend WithEvents Label7 As System.Windows.Forms.Label
	Friend WithEvents lblccex As System.Windows.Forms.Label
	Friend WithEvents Label8 As System.Windows.Forms.Label
	Friend WithEvents lblccgrs As System.Windows.Forms.Label
	Friend WithEvents Label19 As System.Windows.Forms.Label
	Friend WithEvents LblCCDate As System.Windows.Forms.Label
	Friend WithEvents LblCCNo As System.Windows.Forms.Label
	Friend WithEvents Label20 As System.Windows.Forms.Label
	Friend WithEvents TxtLease As System.Windows.Forms.TextBox
	Friend WithEvents Label21 As System.Windows.Forms.Label
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents LblNet As System.Windows.Forms.Label
	Friend WithEvents Label34 As System.Windows.Forms.Label
	Friend WithEvents LblExempt As System.Windows.Forms.Label
	Friend WithEvents LblGross As System.Windows.Forms.Label
	Friend WithEvents Label30 As System.Windows.Forms.Label
	Friend WithEvents Label29 As System.Windows.Forms.Label
 Friend WithEvents ChkBackTax As System.Windows.Forms.CheckBox
 Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
 Friend WithEvents Label47 As System.Windows.Forms.Label
 Friend WithEvents Label48 As System.Windows.Forms.Label
 Friend WithEvents Label49 As System.Windows.Forms.Label
 Friend WithEvents Label50 As System.Windows.Forms.Label
 Friend WithEvents Label51 As System.Windows.Forms.Label
 Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
 Friend WithEvents Label58 As System.Windows.Forms.Label
 Friend WithEvents Label59 As System.Windows.Forms.Label
 Friend WithEvents Label60 As System.Windows.Forms.Label
 Friend WithEvents Label61 As System.Windows.Forms.Label
 Friend WithEvents Label62 As System.Windows.Forms.Label
 Friend WithEvents Label63 As System.Windows.Forms.Label
 Friend WithEvents Label64 As System.Windows.Forms.Label
 Friend WithEvents Label65 As System.Windows.Forms.Label
 Friend WithEvents Label66 As System.Windows.Forms.Label
 Friend WithEvents Label67 As System.Windows.Forms.Label
 Friend WithEvents Label68 As System.Windows.Forms.Label
 Friend WithEvents Label52 As System.Windows.Forms.Label
 Friend WithEvents Label53 As System.Windows.Forms.Label
 Friend WithEvents Label54 As System.Windows.Forms.Label
 Friend WithEvents Label55 As System.Windows.Forms.Label
 Friend WithEvents Label56 As System.Windows.Forms.Label
 Friend WithEvents Label57 As System.Windows.Forms.Label
 Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
 Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
 Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
 Friend WithEvents Label35 As System.Windows.Forms.Label
 Friend WithEvents Label36 As System.Windows.Forms.Label
 Friend WithEvents Label37 As System.Windows.Forms.Label
 Friend WithEvents Label38 As System.Windows.Forms.Label
 Friend WithEvents Label39 As System.Windows.Forms.Label
 Friend WithEvents Label40 As System.Windows.Forms.Label
 Friend WithEvents Label41 As System.Windows.Forms.Label
 Friend WithEvents Label43 As System.Windows.Forms.Label
 Friend WithEvents Label44 As System.Windows.Forms.Label
 Friend WithEvents Label45 As System.Windows.Forms.Label
 Friend WithEvents Label46 As System.Windows.Forms.Label
 Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
 Friend WithEvents Label12 As System.Windows.Forms.Label
 Friend WithEvents Label22 As System.Windows.Forms.Label
 Friend WithEvents Label23 As System.Windows.Forms.Label
 Friend WithEvents Label24 As System.Windows.Forms.Label
 Friend WithEvents Label25 As System.Windows.Forms.Label
 Friend WithEvents Label26 As System.Windows.Forms.Label
 Friend WithEvents Label27 As System.Windows.Forms.Label
 Friend WithEvents Label28 As System.Windows.Forms.Label
 Friend WithEvents Label31 As System.Windows.Forms.Label
 Friend WithEvents Label32 As System.Windows.Forms.Label
 Friend WithEvents Label33 As System.Windows.Forms.Label
 Friend WithEvents TxtBody As System.Windows.Forms.TextBox
 Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
 Friend WithEvents LblOid As System.Windows.Forms.Label
 Friend WithEvents Label69 As System.Windows.Forms.Label
 Friend WithEvents LblSS2 As System.Windows.Forms.Label
 Friend WithEvents Label70 As System.Windows.Forms.Label
 Friend WithEvents LblSSNo As System.Windows.Forms.Label
 Friend WithEvents Label71 As System.Windows.Forms.Label
	Dim log_count As Integer

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
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
	Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
	Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
	Friend WithEvents TxtSname As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
	Friend WithEvents TxtName As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents TxtState As System.Windows.Forms.TextBox
	Friend WithEvents TxtCity As System.Windows.Forms.TextBox
	Friend WithEvents TxtDist As System.Windows.Forms.TextBox
	Friend WithEvents Label42 As System.Windows.Forms.Label
	Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
	Friend WithEvents Label9 As System.Windows.Forms.Label
	Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
	Friend WithEvents Label18 As System.Windows.Forms.Label
	Friend WithEvents TxtRegno As System.Windows.Forms.TextBox
	Friend WithEvents Label17 As System.Windows.Forms.Label
	Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
	Friend WithEvents Label16 As System.Windows.Forms.Label
	Friend WithEvents TxtClass As System.Windows.Forms.TextBox
	Friend WithEvents Label15 As System.Windows.Forms.Label
	Friend WithEvents TxtYear As System.Windows.Forms.TextBox
	Friend WithEvents Label14 As System.Windows.Forms.Label
	Friend WithEvents Label13 As System.Windows.Forms.Label
	Friend WithEvents TxtModel As System.Windows.Forms.TextBox
	Friend WithEvents Label10 As System.Windows.Forms.Label
	Friend WithEvents TxtMake As System.Windows.Forms.TextBox
	Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtRegno = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TxtVIN = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.GrpCC = New System.Windows.Forms.GroupBox()
    Me.lblccrs = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.lblcrdesc = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.lblccex = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.lblccgrs = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.TxtLease = New System.Windows.Forms.TextBox()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.ChkBackTax = New System.Windows.Forms.CheckBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.Label35 = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.Label38 = New System.Windows.Forms.Label()
    Me.Label39 = New System.Windows.Forms.Label()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.Label43 = New System.Windows.Forms.Label()
    Me.Label44 = New System.Windows.Forms.Label()
    Me.Label45 = New System.Windows.Forms.Label()
    Me.Label46 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.Label47 = New System.Windows.Forms.Label()
    Me.Label48 = New System.Windows.Forms.Label()
    Me.Label49 = New System.Windows.Forms.Label()
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label51 = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.Label59 = New System.Windows.Forms.Label()
    Me.Label60 = New System.Windows.Forms.Label()
    Me.Label61 = New System.Windows.Forms.Label()
    Me.Label62 = New System.Windows.Forms.Label()
    Me.Label63 = New System.Windows.Forms.Label()
    Me.Label64 = New System.Windows.Forms.Label()
    Me.Label65 = New System.Windows.Forms.Label()
    Me.Label66 = New System.Windows.Forms.Label()
    Me.Label67 = New System.Windows.Forms.Label()
    Me.Label68 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.Label53 = New System.Windows.Forms.Label()
    Me.Label54 = New System.Windows.Forms.Label()
    Me.Label55 = New System.Windows.Forms.Label()
    Me.Label56 = New System.Windows.Forms.Label()
    Me.Label57 = New System.Windows.Forms.Label()
    Me.TextBox18 = New System.Windows.Forms.TextBox()
    Me.TextBox19 = New System.Windows.Forms.TextBox()
    Me.TextBox20 = New System.Windows.Forms.TextBox()
    Me.TextBox21 = New System.Windows.Forms.TextBox()
    Me.TextBox22 = New System.Windows.Forms.TextBox()
    Me.TextBox23 = New System.Windows.Forms.TextBox()
    Me.TextBox24 = New System.Windows.Forms.TextBox()
    Me.TextBox25 = New System.Windows.Forms.TextBox()
    Me.TextBox26 = New System.Windows.Forms.TextBox()
    Me.TextBox27 = New System.Windows.Forms.TextBox()
    Me.TextBox28 = New System.Windows.Forms.TextBox()
    Me.TextBox29 = New System.Windows.Forms.TextBox()
    Me.TxtBody = New System.Windows.Forms.TextBox()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.LblOid = New System.Windows.Forms.Label()
    Me.Label69 = New System.Windows.Forms.Label()
    Me.LblSS2 = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.LblSSNo = New System.Windows.Forms.Label()
    Me.Label71 = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpCC.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(397, 132)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(43, 22)
    Me.TxtZip4.TabIndex = 17
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(342, 132)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(49, 22)
    Me.TxtZip5.TabIndex = 15
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 132)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 132
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 84)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 131
    Me.Label3.Text = "Street Address"
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 108)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 84)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(96, 60)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 130
    Me.Label2.Text = "Second Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(96, 12)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.ReadOnly = True
    Me.TxtListNo.Size = New System.Drawing.Size(73, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(96, 36)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.ReadOnly = True
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 129
    Me.Label1.Text = "List No"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(8, 36)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 128
    Me.Label5.Text = "Name"
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(312, 132)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 14
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 132)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(94, 161)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(30, 22)
    Me.TxtDist.TabIndex = 18
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(8, 165)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(48, 16)
    Me.Label42.TabIndex = 137
    Me.Label42.Text = "District"
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Checked = False
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(260, 191)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.ShowCheckBox = True
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 21
    Me.DtPckDOB.Value = New Date(2004, 11, 10, 8, 56, 25, 849)
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(172, 195)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(88, 16)
    Me.Label9.TabIndex = 135
    Me.Label9.Text = "Date of Birth"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(425, 222)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(44, 16)
    Me.Label18.TabIndex = 194
    Me.Label18.Text = "Reg #"
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegno.Location = New System.Drawing.Point(428, 241)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.ReadOnly = True
    Me.TxtRegno.Size = New System.Drawing.Size(72, 22)
    Me.TxtRegno.TabIndex = 29
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(278, 222)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(44, 16)
    Me.Label17.TabIndex = 193
    Me.Label17.Text = "VIN #"
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVIN.Location = New System.Drawing.Point(277, 241)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(145, 22)
    Me.TxtVIN.TabIndex = 28
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(237, 222)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(44, 16)
    Me.Label16.TabIndex = 192
    Me.Label16.Text = "Class"
    '
    'TxtClass
    '
    Me.TxtClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtClass.Location = New System.Drawing.Point(240, 241)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 22)
    Me.TxtClass.TabIndex = 27
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(202, 222)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 16)
    Me.Label15.TabIndex = 191
    Me.Label15.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(198, 241)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtYear.TabIndex = 26
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(144, 222)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 16)
    Me.Label14.TabIndex = 190
    Me.Label14.Text = "Body"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(63, 222)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(44, 16)
    Me.Label13.TabIndex = 189
    Me.Label13.Text = "Model"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtModel.Location = New System.Drawing.Point(66, 241)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(72, 22)
    Me.TxtModel.TabIndex = 24
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(12, 222)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(44, 16)
    Me.Label10.TabIndex = 187
    Me.Label10.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMake.Location = New System.Drawing.Point(10, 241)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(52, 22)
    Me.TxtMake.TabIndex = 23
    '
    'GrpCC
    '
    Me.GrpCC.BackColor = System.Drawing.SystemColors.Control
    Me.GrpCC.Controls.Add(Me.lblccrs)
    Me.GrpCC.Controls.Add(Me.Label6)
    Me.GrpCC.Controls.Add(Me.lblcrdesc)
    Me.GrpCC.Controls.Add(Me.Label7)
    Me.GrpCC.Controls.Add(Me.lblccex)
    Me.GrpCC.Controls.Add(Me.Label8)
    Me.GrpCC.Controls.Add(Me.lblccgrs)
    Me.GrpCC.Controls.Add(Me.Label19)
    Me.GrpCC.Controls.Add(Me.LblCCDate)
    Me.GrpCC.Controls.Add(Me.LblCCNo)
    Me.GrpCC.Controls.Add(Me.Label20)
    Me.GrpCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GrpCC.Location = New System.Drawing.Point(304, 272)
    Me.GrpCC.Name = "GrpCC"
    Me.GrpCC.Size = New System.Drawing.Size(317, 108)
    Me.GrpCC.TabIndex = 223
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
    'Label6
    '
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(6, 87)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(60, 16)
    Me.Label6.TabIndex = 141
    Me.Label6.Text = "Reason"
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
    'Label7
    '
    Me.Label7.BackColor = System.Drawing.SystemColors.Control
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(6, 71)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(60, 16)
    Me.Label7.TabIndex = 139
    Me.Label7.Text = "Exemption"
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
    'Label8
    '
    Me.Label8.BackColor = System.Drawing.SystemColors.Control
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(6, 55)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(71, 16)
    Me.Label8.TabIndex = 137
    Me.Label8.Text = "Assessment"
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
    'Label19
    '
    Me.Label19.BackColor = System.Drawing.SystemColors.Control
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(6, 39)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(60, 16)
    Me.Label19.TabIndex = 135
    Me.Label19.Text = "Date"
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
    'Label20
    '
    Me.Label20.BackColor = System.Drawing.SystemColors.Control
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(6, 23)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(60, 16)
    Me.Label20.TabIndex = 11
    Me.Label20.Text = "Number"
    '
    'TxtLease
    '
    Me.TxtLease.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLease.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLease.Location = New System.Drawing.Point(458, 191)
    Me.TxtLease.MaxLength = 2
    Me.TxtLease.Name = "TxtLease"
    Me.TxtLease.Size = New System.Drawing.Size(24, 22)
    Me.TxtLease.TabIndex = 22
    '
    'Label21
    '
    Me.Label21.BackColor = System.Drawing.SystemColors.Control
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.Location = New System.Drawing.Point(381, 195)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(71, 16)
    Me.Label21.TabIndex = 237
    Me.Label21.Text = "Lease Code"
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
    Me.GroupBox2.Location = New System.Drawing.Point(485, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(136, 72)
    Me.GroupBox2.TabIndex = 239
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
    'ChkBackTax
    '
    Me.ChkBackTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkBackTax.Location = New System.Drawing.Point(10, 187)
    Me.ChkBackTax.Name = "ChkBackTax"
    Me.ChkBackTax.Size = New System.Drawing.Size(91, 19)
    Me.ChkBackTax.TabIndex = 20
    Me.ChkBackTax.Text = "Back Tax?"
    Me.ChkBackTax.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox1.Controls.Add(Me.Label12)
    Me.GroupBox1.Controls.Add(Me.Label22)
    Me.GroupBox1.Controls.Add(Me.Label23)
    Me.GroupBox1.Controls.Add(Me.Label24)
    Me.GroupBox1.Controls.Add(Me.Label25)
    Me.GroupBox1.Controls.Add(Me.Label26)
    Me.GroupBox1.Controls.Add(Me.Label27)
    Me.GroupBox1.Controls.Add(Me.Label28)
    Me.GroupBox1.Controls.Add(Me.Label31)
    Me.GroupBox1.Controls.Add(Me.Label32)
    Me.GroupBox1.Controls.Add(Me.Label33)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(304, 272)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(317, 108)
    Me.GroupBox1.TabIndex = 223
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "C/C Information"
    '
    'Label12
    '
    Me.Label12.BackColor = System.Drawing.SystemColors.Control
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(82, 87)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(19, 16)
    Me.Label12.TabIndex = 142
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label22
    '
    Me.Label22.BackColor = System.Drawing.SystemColors.Control
    Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label22.Location = New System.Drawing.Point(6, 87)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(60, 16)
    Me.Label22.TabIndex = 141
    Me.Label22.Text = "Reason"
    '
    'Label23
    '
    Me.Label23.BackColor = System.Drawing.SystemColors.Control
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(141, 87)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(159, 16)
    Me.Label23.TabIndex = 140
    Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label24
    '
    Me.Label24.BackColor = System.Drawing.SystemColors.Control
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(6, 71)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(60, 16)
    Me.Label24.TabIndex = 139
    Me.Label24.Text = "Exemption"
    '
    'Label25
    '
    Me.Label25.BackColor = System.Drawing.SystemColors.Control
    Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label25.Location = New System.Drawing.Point(83, 71)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(64, 16)
    Me.Label25.TabIndex = 138
    Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label26
    '
    Me.Label26.BackColor = System.Drawing.SystemColors.Control
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(6, 55)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(71, 16)
    Me.Label26.TabIndex = 137
    Me.Label26.Text = "Assessment"
    '
    'Label27
    '
    Me.Label27.BackColor = System.Drawing.SystemColors.Control
    Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label27.Location = New System.Drawing.Point(83, 55)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(64, 16)
    Me.Label27.TabIndex = 136
    Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label28
    '
    Me.Label28.BackColor = System.Drawing.SystemColors.Control
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(6, 39)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(60, 16)
    Me.Label28.TabIndex = 135
    Me.Label28.Text = "Date"
    '
    'Label31
    '
    Me.Label31.BackColor = System.Drawing.SystemColors.Control
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(83, 39)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(64, 16)
    Me.Label31.TabIndex = 134
    Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label32
    '
    Me.Label32.BackColor = System.Drawing.SystemColors.Control
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(83, 23)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(64, 16)
    Me.Label32.TabIndex = 127
    Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label33
    '
    Me.Label33.BackColor = System.Drawing.SystemColors.Control
    Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label33.Location = New System.Drawing.Point(6, 23)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(60, 16)
    Me.Label33.TabIndex = 11
    Me.Label33.Text = "Number"
    '
    'GroupBox3
    '
    Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox3.Controls.Add(Me.Label35)
    Me.GroupBox3.Controls.Add(Me.Label36)
    Me.GroupBox3.Controls.Add(Me.Label37)
    Me.GroupBox3.Controls.Add(Me.Label38)
    Me.GroupBox3.Controls.Add(Me.Label39)
    Me.GroupBox3.Controls.Add(Me.Label40)
    Me.GroupBox3.Controls.Add(Me.Label41)
    Me.GroupBox3.Controls.Add(Me.Label43)
    Me.GroupBox3.Controls.Add(Me.Label44)
    Me.GroupBox3.Controls.Add(Me.Label45)
    Me.GroupBox3.Controls.Add(Me.Label46)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(304, 272)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(317, 108)
    Me.GroupBox3.TabIndex = 223
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "C/C Information"
    '
    'Label35
    '
    Me.Label35.BackColor = System.Drawing.SystemColors.Control
    Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label35.Location = New System.Drawing.Point(82, 87)
    Me.Label35.Name = "Label35"
    Me.Label35.Size = New System.Drawing.Size(19, 16)
    Me.Label35.TabIndex = 142
    Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label36
    '
    Me.Label36.BackColor = System.Drawing.SystemColors.Control
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(6, 87)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(60, 16)
    Me.Label36.TabIndex = 141
    Me.Label36.Text = "Reason"
    '
    'Label37
    '
    Me.Label37.BackColor = System.Drawing.SystemColors.Control
    Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label37.Location = New System.Drawing.Point(141, 87)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(159, 16)
    Me.Label37.TabIndex = 140
    Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label38
    '
    Me.Label38.BackColor = System.Drawing.SystemColors.Control
    Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label38.Location = New System.Drawing.Point(6, 71)
    Me.Label38.Name = "Label38"
    Me.Label38.Size = New System.Drawing.Size(60, 16)
    Me.Label38.TabIndex = 139
    Me.Label38.Text = "Exemption"
    '
    'Label39
    '
    Me.Label39.BackColor = System.Drawing.SystemColors.Control
    Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label39.Location = New System.Drawing.Point(83, 71)
    Me.Label39.Name = "Label39"
    Me.Label39.Size = New System.Drawing.Size(64, 16)
    Me.Label39.TabIndex = 138
    Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label40
    '
    Me.Label40.BackColor = System.Drawing.SystemColors.Control
    Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label40.Location = New System.Drawing.Point(6, 55)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(71, 16)
    Me.Label40.TabIndex = 137
    Me.Label40.Text = "Assessment"
    '
    'Label41
    '
    Me.Label41.BackColor = System.Drawing.SystemColors.Control
    Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label41.Location = New System.Drawing.Point(83, 55)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(64, 16)
    Me.Label41.TabIndex = 136
    Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label43
    '
    Me.Label43.BackColor = System.Drawing.SystemColors.Control
    Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label43.Location = New System.Drawing.Point(6, 39)
    Me.Label43.Name = "Label43"
    Me.Label43.Size = New System.Drawing.Size(60, 16)
    Me.Label43.TabIndex = 135
    Me.Label43.Text = "Date"
    '
    'Label44
    '
    Me.Label44.BackColor = System.Drawing.SystemColors.Control
    Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label44.Location = New System.Drawing.Point(83, 39)
    Me.Label44.Name = "Label44"
    Me.Label44.Size = New System.Drawing.Size(64, 16)
    Me.Label44.TabIndex = 134
    Me.Label44.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label45
    '
    Me.Label45.BackColor = System.Drawing.SystemColors.Control
    Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label45.Location = New System.Drawing.Point(83, 23)
    Me.Label45.Name = "Label45"
    Me.Label45.Size = New System.Drawing.Size(64, 16)
    Me.Label45.TabIndex = 127
    Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label46
    '
    Me.Label46.BackColor = System.Drawing.SystemColors.Control
    Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label46.Location = New System.Drawing.Point(6, 23)
    Me.Label46.Name = "Label46"
    Me.Label46.Size = New System.Drawing.Size(60, 16)
    Me.Label46.TabIndex = 11
    Me.Label46.Text = "Number"
    '
    'GroupBox4
    '
    Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox4.Controls.Add(Me.Label47)
    Me.GroupBox4.Controls.Add(Me.Label48)
    Me.GroupBox4.Controls.Add(Me.Label49)
    Me.GroupBox4.Controls.Add(Me.Label50)
    Me.GroupBox4.Controls.Add(Me.Label51)
    Me.GroupBox4.Controls.Add(Me.GroupBox5)
    Me.GroupBox4.Controls.Add(Me.Label52)
    Me.GroupBox4.Controls.Add(Me.Label53)
    Me.GroupBox4.Controls.Add(Me.Label54)
    Me.GroupBox4.Controls.Add(Me.Label55)
    Me.GroupBox4.Controls.Add(Me.Label56)
    Me.GroupBox4.Controls.Add(Me.Label57)
    Me.GroupBox4.Controls.Add(Me.TextBox18)
    Me.GroupBox4.Controls.Add(Me.TextBox19)
    Me.GroupBox4.Controls.Add(Me.TextBox20)
    Me.GroupBox4.Controls.Add(Me.TextBox21)
    Me.GroupBox4.Controls.Add(Me.TextBox22)
    Me.GroupBox4.Controls.Add(Me.TextBox23)
    Me.GroupBox4.Controls.Add(Me.TextBox24)
    Me.GroupBox4.Controls.Add(Me.TextBox25)
    Me.GroupBox4.Controls.Add(Me.TextBox26)
    Me.GroupBox4.Controls.Add(Me.TextBox27)
    Me.GroupBox4.Controls.Add(Me.TextBox28)
    Me.GroupBox4.Controls.Add(Me.TextBox29)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(304, 272)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(317, 108)
    Me.GroupBox4.TabIndex = 223
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "C/C Information"
    '
    'Label47
    '
    Me.Label47.BackColor = System.Drawing.SystemColors.Control
    Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label47.Location = New System.Drawing.Point(82, 87)
    Me.Label47.Name = "Label47"
    Me.Label47.Size = New System.Drawing.Size(19, 16)
    Me.Label47.TabIndex = 142
    Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label48
    '
    Me.Label48.BackColor = System.Drawing.SystemColors.Control
    Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label48.Location = New System.Drawing.Point(6, 87)
    Me.Label48.Name = "Label48"
    Me.Label48.Size = New System.Drawing.Size(60, 16)
    Me.Label48.TabIndex = 141
    Me.Label48.Text = "Reason"
    '
    'Label49
    '
    Me.Label49.BackColor = System.Drawing.SystemColors.Control
    Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label49.Location = New System.Drawing.Point(141, 87)
    Me.Label49.Name = "Label49"
    Me.Label49.Size = New System.Drawing.Size(159, 16)
    Me.Label49.TabIndex = 140
    Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label50
    '
    Me.Label50.BackColor = System.Drawing.SystemColors.Control
    Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label50.Location = New System.Drawing.Point(6, 71)
    Me.Label50.Name = "Label50"
    Me.Label50.Size = New System.Drawing.Size(60, 16)
    Me.Label50.TabIndex = 139
    Me.Label50.Text = "Exemption"
    '
    'Label51
    '
    Me.Label51.BackColor = System.Drawing.SystemColors.Control
    Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label51.Location = New System.Drawing.Point(83, 71)
    Me.Label51.Name = "Label51"
    Me.Label51.Size = New System.Drawing.Size(64, 16)
    Me.Label51.TabIndex = 138
    Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'GroupBox5
    '
    Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
    Me.GroupBox5.Controls.Add(Me.Label58)
    Me.GroupBox5.Controls.Add(Me.Label59)
    Me.GroupBox5.Controls.Add(Me.Label60)
    Me.GroupBox5.Controls.Add(Me.Label61)
    Me.GroupBox5.Controls.Add(Me.Label62)
    Me.GroupBox5.Controls.Add(Me.Label63)
    Me.GroupBox5.Controls.Add(Me.Label64)
    Me.GroupBox5.Controls.Add(Me.Label65)
    Me.GroupBox5.Controls.Add(Me.Label66)
    Me.GroupBox5.Controls.Add(Me.Label67)
    Me.GroupBox5.Controls.Add(Me.Label68)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(317, 108)
    Me.GroupBox5.TabIndex = 223
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "C/C Information"
    '
    'Label58
    '
    Me.Label58.BackColor = System.Drawing.SystemColors.Control
    Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label58.Location = New System.Drawing.Point(82, 87)
    Me.Label58.Name = "Label58"
    Me.Label58.Size = New System.Drawing.Size(19, 16)
    Me.Label58.TabIndex = 142
    Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label59
    '
    Me.Label59.BackColor = System.Drawing.SystemColors.Control
    Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label59.Location = New System.Drawing.Point(6, 87)
    Me.Label59.Name = "Label59"
    Me.Label59.Size = New System.Drawing.Size(60, 16)
    Me.Label59.TabIndex = 141
    Me.Label59.Text = "Reason"
    '
    'Label60
    '
    Me.Label60.BackColor = System.Drawing.SystemColors.Control
    Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label60.Location = New System.Drawing.Point(141, 87)
    Me.Label60.Name = "Label60"
    Me.Label60.Size = New System.Drawing.Size(159, 16)
    Me.Label60.TabIndex = 140
    Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label61
    '
    Me.Label61.BackColor = System.Drawing.SystemColors.Control
    Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label61.Location = New System.Drawing.Point(6, 71)
    Me.Label61.Name = "Label61"
    Me.Label61.Size = New System.Drawing.Size(60, 16)
    Me.Label61.TabIndex = 139
    Me.Label61.Text = "Exemption"
    '
    'Label62
    '
    Me.Label62.BackColor = System.Drawing.SystemColors.Control
    Me.Label62.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label62.Location = New System.Drawing.Point(83, 71)
    Me.Label62.Name = "Label62"
    Me.Label62.Size = New System.Drawing.Size(64, 16)
    Me.Label62.TabIndex = 138
    Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label63
    '
    Me.Label63.BackColor = System.Drawing.SystemColors.Control
    Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label63.Location = New System.Drawing.Point(6, 55)
    Me.Label63.Name = "Label63"
    Me.Label63.Size = New System.Drawing.Size(71, 16)
    Me.Label63.TabIndex = 137
    Me.Label63.Text = "Assessment"
    '
    'Label64
    '
    Me.Label64.BackColor = System.Drawing.SystemColors.Control
    Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label64.Location = New System.Drawing.Point(83, 55)
    Me.Label64.Name = "Label64"
    Me.Label64.Size = New System.Drawing.Size(64, 16)
    Me.Label64.TabIndex = 136
    Me.Label64.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label65
    '
    Me.Label65.BackColor = System.Drawing.SystemColors.Control
    Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label65.Location = New System.Drawing.Point(6, 39)
    Me.Label65.Name = "Label65"
    Me.Label65.Size = New System.Drawing.Size(60, 16)
    Me.Label65.TabIndex = 135
    Me.Label65.Text = "Date"
    '
    'Label66
    '
    Me.Label66.BackColor = System.Drawing.SystemColors.Control
    Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label66.Location = New System.Drawing.Point(83, 39)
    Me.Label66.Name = "Label66"
    Me.Label66.Size = New System.Drawing.Size(64, 16)
    Me.Label66.TabIndex = 134
    Me.Label66.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label67
    '
    Me.Label67.BackColor = System.Drawing.SystemColors.Control
    Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label67.Location = New System.Drawing.Point(83, 23)
    Me.Label67.Name = "Label67"
    Me.Label67.Size = New System.Drawing.Size(64, 16)
    Me.Label67.TabIndex = 127
    Me.Label67.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label68
    '
    Me.Label68.BackColor = System.Drawing.SystemColors.Control
    Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label68.Location = New System.Drawing.Point(6, 23)
    Me.Label68.Name = "Label68"
    Me.Label68.Size = New System.Drawing.Size(60, 16)
    Me.Label68.TabIndex = 11
    Me.Label68.Text = "Number"
    '
    'Label52
    '
    Me.Label52.BackColor = System.Drawing.SystemColors.Control
    Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label52.Location = New System.Drawing.Point(6, 55)
    Me.Label52.Name = "Label52"
    Me.Label52.Size = New System.Drawing.Size(71, 16)
    Me.Label52.TabIndex = 137
    Me.Label52.Text = "Assessment"
    '
    'Label53
    '
    Me.Label53.BackColor = System.Drawing.SystemColors.Control
    Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label53.Location = New System.Drawing.Point(83, 55)
    Me.Label53.Name = "Label53"
    Me.Label53.Size = New System.Drawing.Size(64, 16)
    Me.Label53.TabIndex = 136
    Me.Label53.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label54
    '
    Me.Label54.BackColor = System.Drawing.SystemColors.Control
    Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label54.Location = New System.Drawing.Point(6, 39)
    Me.Label54.Name = "Label54"
    Me.Label54.Size = New System.Drawing.Size(60, 16)
    Me.Label54.TabIndex = 135
    Me.Label54.Text = "Date"
    '
    'Label55
    '
    Me.Label55.BackColor = System.Drawing.SystemColors.Control
    Me.Label55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label55.Location = New System.Drawing.Point(83, 39)
    Me.Label55.Name = "Label55"
    Me.Label55.Size = New System.Drawing.Size(64, 16)
    Me.Label55.TabIndex = 134
    Me.Label55.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label56
    '
    Me.Label56.BackColor = System.Drawing.SystemColors.Control
    Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label56.Location = New System.Drawing.Point(83, 23)
    Me.Label56.Name = "Label56"
    Me.Label56.Size = New System.Drawing.Size(64, 16)
    Me.Label56.TabIndex = 127
    Me.Label56.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label57
    '
    Me.Label57.BackColor = System.Drawing.SystemColors.Control
    Me.Label57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label57.Location = New System.Drawing.Point(6, 23)
    Me.Label57.Name = "Label57"
    Me.Label57.Size = New System.Drawing.Size(60, 16)
    Me.Label57.TabIndex = 11
    Me.Label57.Text = "Number"
    '
    'TextBox18
    '
    Me.TextBox18.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox18.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox18.Location = New System.Drawing.Point(-294, -26)
    Me.TextBox18.MaxLength = 5
    Me.TextBox18.Name = "TextBox18"
    Me.TextBox18.Size = New System.Drawing.Size(52, 22)
    Me.TextBox18.TabIndex = 23
    '
    'TextBox19
    '
    Me.TextBox19.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox19.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox19.Location = New System.Drawing.Point(-294, -26)
    Me.TextBox19.MaxLength = 5
    Me.TextBox19.Name = "TextBox19"
    Me.TextBox19.Size = New System.Drawing.Size(52, 22)
    Me.TextBox19.TabIndex = 23
    '
    'TextBox20
    '
    Me.TextBox20.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox20.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox20.Location = New System.Drawing.Point(-238, -26)
    Me.TextBox20.MaxLength = 8
    Me.TextBox20.Name = "TextBox20"
    Me.TextBox20.Size = New System.Drawing.Size(72, 22)
    Me.TextBox20.TabIndex = 24
    '
    'TextBox21
    '
    Me.TextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox21.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox21.Location = New System.Drawing.Point(-238, -26)
    Me.TextBox21.MaxLength = 8
    Me.TextBox21.Name = "TextBox21"
    Me.TextBox21.Size = New System.Drawing.Size(72, 22)
    Me.TextBox21.TabIndex = 24
    '
    'TextBox22
    '
    Me.TextBox22.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox22.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox22.Location = New System.Drawing.Point(-162, -28)
    Me.TextBox22.MaxLength = 6
    Me.TextBox22.Name = "TextBox22"
    Me.TextBox22.Size = New System.Drawing.Size(56, 22)
    Me.TextBox22.TabIndex = 25
    '
    'TextBox23
    '
    Me.TextBox23.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox23.Location = New System.Drawing.Point(-106, -26)
    Me.TextBox23.MaxLength = 4
    Me.TextBox23.Name = "TextBox23"
    Me.TextBox23.Size = New System.Drawing.Size(40, 22)
    Me.TextBox23.TabIndex = 26
    '
    'TextBox24
    '
    Me.TextBox24.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox24.Location = New System.Drawing.Point(-106, -26)
    Me.TextBox24.MaxLength = 4
    Me.TextBox24.Name = "TextBox24"
    Me.TextBox24.Size = New System.Drawing.Size(40, 22)
    Me.TextBox24.TabIndex = 26
    '
    'TextBox25
    '
    Me.TextBox25.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox25.Location = New System.Drawing.Point(-64, -26)
    Me.TextBox25.MaxLength = 2
    Me.TextBox25.Name = "TextBox25"
    Me.TextBox25.Size = New System.Drawing.Size(28, 22)
    Me.TextBox25.TabIndex = 27
    '
    'TextBox26
    '
    Me.TextBox26.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox26.Location = New System.Drawing.Point(-64, -26)
    Me.TextBox26.MaxLength = 2
    Me.TextBox26.Name = "TextBox26"
    Me.TextBox26.Size = New System.Drawing.Size(28, 22)
    Me.TextBox26.TabIndex = 27
    '
    'TextBox27
    '
    Me.TextBox27.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox27.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox27.Location = New System.Drawing.Point(-27, -26)
    Me.TextBox27.MaxLength = 17
    Me.TextBox27.Name = "TextBox27"
    Me.TextBox27.Size = New System.Drawing.Size(145, 22)
    Me.TextBox27.TabIndex = 28
    '
    'TextBox28
    '
    Me.TextBox28.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox28.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox28.Location = New System.Drawing.Point(124, -26)
    Me.TextBox28.MaxLength = 8
    Me.TextBox28.Name = "TextBox28"
    Me.TextBox28.ReadOnly = True
    Me.TextBox28.Size = New System.Drawing.Size(72, 22)
    Me.TextBox28.TabIndex = 29
    '
    'TextBox29
    '
    Me.TextBox29.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TextBox29.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox29.Location = New System.Drawing.Point(124, -26)
    Me.TextBox29.MaxLength = 8
    Me.TextBox29.Name = "TextBox29"
    Me.TextBox29.ReadOnly = True
    Me.TextBox29.Size = New System.Drawing.Size(72, 22)
    Me.TextBox29.TabIndex = 29
    '
    'TxtBody
    '
    Me.TxtBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBody.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBody.Location = New System.Drawing.Point(142, 241)
    Me.TxtBody.MaxLength = 6
    Me.TxtBody.Name = "TxtBody"
    Me.TxtBody.Size = New System.Drawing.Size(56, 22)
    Me.TxtBody.TabIndex = 25
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(381, 14)
    Me.LblTaxExempt.Name = "LblTaxExempt"
    Me.LblTaxExempt.Size = New System.Drawing.Size(94, 20)
    Me.LblTaxExempt.TabIndex = 240
    Me.LblTaxExempt.Text = "Tax Exempt"
    Me.LblTaxExempt.Visible = False
    '
    'LblOid
    '
    Me.LblOid.AutoSize = True
    Me.LblOid.Location = New System.Drawing.Point(102, 356)
    Me.LblOid.Name = "LblOid"
    Me.LblOid.Size = New System.Drawing.Size(35, 13)
    Me.LblOid.TabIndex = 246
    Me.LblOid.Text = "<Oid>"
    '
    'Label69
    '
    Me.Label69.AutoSize = True
    Me.Label69.Location = New System.Drawing.Point(8, 356)
    Me.Label69.Name = "Label69"
    Me.Label69.Size = New System.Drawing.Size(56, 13)
    Me.Label69.TabIndex = 245
    Me.Label69.Text = "Vehicle ID"
    '
    'LblSS2
    '
    Me.LblSS2.AutoSize = True
    Me.LblSS2.Location = New System.Drawing.Point(102, 343)
    Me.LblSS2.Name = "LblSS2"
    Me.LblSS2.Size = New System.Drawing.Size(39, 13)
    Me.LblSS2.TabIndex = 244
    Me.LblSS2.Text = "<SS2>"
    '
    'Label70
    '
    Me.Label70.AutoSize = True
    Me.Label70.Location = New System.Drawing.Point(8, 343)
    Me.Label70.Name = "Label70"
    Me.Label70.Size = New System.Drawing.Size(93, 13)
    Me.Label70.TabIndex = 243
    Me.Label70.Text = "Secondary CustID"
    '
    'LblSSNo
    '
    Me.LblSSNo.AutoSize = True
    Me.LblSSNo.Location = New System.Drawing.Point(101, 330)
    Me.LblSSNo.Name = "LblSSNo"
    Me.LblSSNo.Size = New System.Drawing.Size(47, 13)
    Me.LblSSNo.TabIndex = 242
    Me.LblSSNo.Text = "<SSNo>"
    '
    'Label71
    '
    Me.Label71.AutoSize = True
    Me.Label71.Location = New System.Drawing.Point(8, 330)
    Me.Label71.Name = "Label71"
    Me.Label71.Size = New System.Drawing.Size(76, 13)
    Me.Label71.TabIndex = 241
    Me.Label71.Text = "Primary CustID"
    '
    'FrmTX401SU
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(632, 386)
    Me.Controls.Add(Me.LblOid)
    Me.Controls.Add(Me.Label69)
    Me.Controls.Add(Me.LblSS2)
    Me.Controls.Add(Me.Label70)
    Me.Controls.Add(Me.LblSSNo)
    Me.Controls.Add(Me.Label71)
    Me.Controls.Add(Me.LblTaxExempt)
    Me.Controls.Add(Me.ChkBackTax)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.TxtLease)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GrpCC)
    Me.Controls.Add(Me.DtPckDOB)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label42)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.TxtRegno)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.TxtVIN)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.TxtClass)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.TxtBody)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtModel)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtMake)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX401SU"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpCC.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

Private Sub FrmTX401SU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	Dim WrkListNo As Integer
	myTXSUPP = New TXSupp.mydata(MyDBConnect)

	MyFrmTX401.TBarSave.Enabled = True

	LoadScrn = True
	AddMode = False

		If s_chg = False And s_full = False Then	'#sec
			MyFrmTX401.TBarSave.Visible = False	 '#sec
		End If	'#sec


		'Fill the dataset with the data
		'Me.Text = "Maintain " & Me.Text
		TxtListNo.ReadOnly = True
		TxtListNo.TabStop = False
		TxtName.ReadOnly = True
		TxtName.TabStop = False
		TxtRegno.ReadOnly = True
		TxtRegno.TabStop = False
		TxtClass.ReadOnly = True
		TxtClass.TabStop = False
		DtPckDOB.TabStop = False
	WrkListNo = ProcessSelItems()
	LoadForm(WrkListNo)
End Sub
Private Sub LoadForm(ByVal WrkListNo As Integer)

		TxtListNo.Text = WrkListNo
		myTXSUPP.GetOneRecordP(WrkListNo)
		If myTXSUPP.RecordNotFound Then
			MyFrmTX401.TBarSave.Enabled = False
			Me.ErrProv.SetError(TxtListNo, "Record not found")
			Exit Sub
		End If
		With myTXSUPP
      LblTaxExempt.Visible = False
      If ._CAT = "3" Then
        LblTaxExempt.Visible = True
      End If
      TxtName.Text = Trim(._NAME)
			TxtSname.Text = Trim(._SNAME)
			TxtAdd1.Text = Trim(._ADD1)
			TxtAdd2.Text = Trim(._ADD2)
			TxtCity.Text = Trim(._CITY)
			TxtState.Text = Trim(._STATE)
			TxtZip5.Text = Format(._ZIP5, "00000")
			TxtZip4.Text = Format(._ZIP4, "0000")
      TxtDist.Text = ._DIST
			TxtLease.Text = Trim(._LEASE)
			ChkBackTax.Checked = False
			If Trim(._BTC) <> String.Empty Then
				ChkBackTax.Checked = True
			End If
			TxtMake.Text = Trim(._MAKE)
			TxtModel.Text = Trim(._MODEL)
			TxtBody.Text = Trim(._BODY)
			TxtYear.Text = ._YEAR
			TxtClass.Text = ._CLASS
			TxtVIN.Text = Trim(._VINNO)
			TxtRegno.Text = Trim(._REGNO)
			DtPckDOB.Checked = False
			If ._DOB > 0 Then
        DtPckDOB.Value = MyUtils.GetDBDate(._DOB)
        DtPckDOB.Checked = False
      End If
      LblGross.Text = ._VALUE + ._BTR
      LblExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      LblNet.Text = MyUtils.CnvSng(LblGross.Text) - MyUtils.CnvSng(LblExempt.Text)
      LblSSNo.Text = ._SSNO
      LblSS2.Text = ._SS2
      LblOid.Text = ._OID

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
Private Sub FrmTX401SU_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim WrkListNo As Integer

    WrkListNo = ProcessSelItems()
    If WrkListNo > 0 Then
      LoadForm(WrkListNo)
      e.Cancel = True
    End If

End Sub
    Private Sub FrmTX401MV_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX401.TBarSave.Enabled = False
    MyFrmTX401.TBarSave.Visible = True   '#sec
    If s_chg = False And s_full = False Then  '#sec
      MyFrmTX401.TBarSave.Visible = False  '#sec
    End If  '#sec
    MyFrmTX401.TBarComments.Enabled = False
    MyFrmTX401B.FormatGrid(False)
    MyFrmTX401B.Show()
    'Memory Cleanup
    myTXSUPP = Nothing

  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String
    Dim WrkListNo As Integer

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)

    myTXSUPP.GetOneRecordP(WrkListNo)
    MoveToFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXSUPP.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    Me.Close()

  End Sub
   Private Sub MoveToFile()
      With myTXSUPP
        ._SNAME = TxtSname.Text
        ._ADD1 = TxtAdd1.Text
        ._ADD2 = TxtAdd2.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        ._MAKE = TxtMake.Text
        ._MODEL = TxtModel.Text
        ._BODY = TxtBody.Text
        ._YEAR = MyUtils.CnvSng(TxtYear.Text)
        ._CLASS = MyUtils.CnvSng(TxtClass.Text)
        ._VINNO = TxtVIN.Text
        If ChkBackTax.Checked Then
          ._BTC = "BT"
        Else
          ._BTC = String.Empty
        End If
        ._LEASE = TxtLease.Text
        ._DIST = MyUtils.CnvSng(TxtDist.Text)
        ._LETT = Mid$(TxtName.Text, 1, 1)
      End With

   End Sub
	Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
		Dim I As Integer
		ErrProv.SetError(TxtAdd1, "")
		ErrProv.SetError(TxtCity, "")
		ErrProv.SetError(TxtState, "")

		For I = 0 To ErrorField.GetUpperBound(0)
			Me.ForeColor = Color.DarkRed
			Select Case ErrorField(I)
			Case "add1"
				ErrProv.SetError(TxtAdd1, ErrorMsg(I))
			Case "city"
				ErrProv.SetError(TxtCity, ErrorMsg(I))
			Case "state"
				ErrProv.SetError(TxtState, ErrorMsg(I))
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
	End Sub
	Private Sub FrmTX401SU_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

		MyFrmTX401.SbpScreen.Text = "TX401SU"
		MyFrmTX401.TBarComments.Enabled = True
    MyUtils.CenterForm(Me.ParentForm, Me)
	End Sub

Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtYear.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






