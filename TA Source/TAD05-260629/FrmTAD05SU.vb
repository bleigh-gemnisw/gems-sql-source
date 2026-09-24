Public Class FrmTAD05SU
  Inherits System.Windows.Forms.Form
  Dim myTXSUPA As TXSUPA.MyData
  Dim myTXSUPAL1 As TXSUPAL1.MyData
  Const WrkType As String = "S"
  Dim LoadScrn As Boolean
  Dim WrkCredit As Boolean
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkFastPath As Boolean
  Dim ds As DataSet = New DataSet
  Friend WithEvents LnkOClass As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents BtnPrevious As System.Windows.Forms.Button
  Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
  Friend WithEvents BtnDMV As System.Windows.Forms.Button
  Friend WithEvents LblOid As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblSS2 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents LblSSNo As System.Windows.Forms.Label
  Friend WithEvents LblYear As Label
  Friend WithEvents TabControl1 As TabControl
  Friend WithEvents TabPage1 As TabPage
  Friend WithEvents LblPlateExp As Label
  Friend WithEvents Label22 As Label
  Friend WithEvents Label21 As Label
  Friend WithEvents TxtLightWgt As TextBox
  Friend WithEvents TxtGrossWgt As TextBox
  Friend WithEvents Label20 As Label
  Friend WithEvents GroupBox3 As GroupBox
  Friend WithEvents LnkExempt5 As LinkLabel
  Friend WithEvents TxtExempt5 As TextBox
  Friend WithEvents LnkExempt3 As LinkLabel
  Friend WithEvents TxtExempt3 As TextBox
  Friend WithEvents LnkExempt4 As LinkLabel
  Friend WithEvents TxtExempt4 As TextBox
  Friend WithEvents LnkExempt2 As LinkLabel
  Friend WithEvents TxtExempt2 As TextBox
  Friend WithEvents LnkExempt1 As LinkLabel
  Friend WithEvents TxtExempt1 As TextBox
  Friend WithEvents TxtExam4 As TextBox
  Friend WithEvents TxtExam2 As TextBox
  Friend WithEvents TxtExam5 As TextBox
  Friend WithEvents TxtExam3 As TextBox
  Friend WithEvents TxtExam1 As TextBox
  Friend WithEvents Label8 As Label
  Friend WithEvents Label32 As Label
  Friend WithEvents TabPage2 As TabPage
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Friend WithEvents TxtResAdd2 As TextBox
  Friend WithEvents TxtLoc As TextBox
  Friend WithEvents TxtLocNo As TextBox
  Friend WithEvents Label28 As Label
  Friend WithEvents TxtResZip4 As TextBox
  Friend WithEvents TxtResZip5 As TextBox
  Friend WithEvents TxtResAdd1 As TextBox
  Friend WithEvents TxtResState As TextBox
  Friend WithEvents TxtResCity As TextBox
  Friend WithEvents Label29 As Label
  Friend WithEvents Label30 As Label
  Friend WithEvents RbCatNonTax As RadioButton
  Friend WithEvents Label19 As System.Windows.Forms.Label

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
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbCatTransfer As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
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
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtBody As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtValue As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents TxtORegNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtOVIN As System.Windows.Forms.TextBox
  Friend WithEvents TxtOClass As System.Windows.Forms.TextBox
  Friend WithEvents TxtOYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtOModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtOValue As System.Windows.Forms.TextBox
  Friend WithEvents TxtOMake As System.Windows.Forms.TextBox
  Friend WithEvents LblOListNo As System.Windows.Forms.Label
  Friend WithEvents TxtAss As System.Windows.Forms.TextBox
  Friend WithEvents LblPct As System.Windows.Forms.Label
  Friend WithEvents TxtOAss As System.Windows.Forms.TextBox
  Friend WithEvents LblOPct As System.Windows.Forms.Label
  Friend WithEvents LnkAsmt As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkOAsmt As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents Label33 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents LblPRNet As System.Windows.Forms.Label
  Friend WithEvents LblPRExempt As System.Windows.Forms.Label
  Friend WithEvents LblPRGross As System.Windows.Forms.Label
  Friend WithEvents LblPRCredit As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAD05SU))
    Me.TxtOid = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbCatTransfer = New System.Windows.Forms.RadioButton()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
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
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtBody = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtValue = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtORegNo = New System.Windows.Forms.TextBox()
    Me.TxtOVIN = New System.Windows.Forms.TextBox()
    Me.TxtOClass = New System.Windows.Forms.TextBox()
    Me.TxtOYear = New System.Windows.Forms.TextBox()
    Me.TxtOModel = New System.Windows.Forms.TextBox()
    Me.TxtOValue = New System.Windows.Forms.TextBox()
    Me.TxtOMake = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtAss = New System.Windows.Forms.TextBox()
    Me.LblPct = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.TxtOAss = New System.Windows.Forms.TextBox()
    Me.LblOListNo = New System.Windows.Forms.Label()
    Me.LblOPct = New System.Windows.Forms.Label()
    Me.LnkAsmt = New System.Windows.Forms.LinkLabel()
    Me.LnkOAsmt = New System.Windows.Forms.LinkLabel()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblPRCredit = New System.Windows.Forms.Label()
    Me.Label36 = New System.Windows.Forms.Label()
    Me.LblPRNet = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblPRExempt = New System.Windows.Forms.Label()
    Me.LblPRGross = New System.Windows.Forms.Label()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.LnkOClass = New System.Windows.Forms.LinkLabel()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnPrevious = New System.Windows.Forms.Button()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.BtnDMV = New System.Windows.Forms.Button()
    Me.LblOid = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblSS2 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblSSNo = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.LblPlateExp = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtLightWgt = New System.Windows.Forms.TextBox()
    Me.TxtGrossWgt = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
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
    Me.TxtExam4 = New System.Windows.Forms.TextBox()
    Me.TxtExam2 = New System.Windows.Forms.TextBox()
    Me.TxtExam5 = New System.Windows.Forms.TextBox()
    Me.TxtExam3 = New System.Windows.Forms.TextBox()
    Me.TxtExam1 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.TxtResAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.TxtResZip4 = New System.Windows.Forms.TextBox()
    Me.TxtResZip5 = New System.Windows.Forms.TextBox()
    Me.TxtResAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtResState = New System.Windows.Forms.TextBox()
    Me.TxtResCity = New System.Windows.Forms.TextBox()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.RbCatNonTax = New System.Windows.Forms.RadioButton()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtOid
    '
    Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOid.Location = New System.Drawing.Point(348, 242)
    Me.TxtOid.MaxLength = 15
    Me.TxtOid.Name = "TxtOid"
    Me.TxtOid.Size = New System.Drawing.Size(119, 22)
    Me.TxtOid.TabIndex = 11
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(324, 245)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(24, 16)
    Me.Label11.TabIndex = 148
    Me.Label11.Text = "I.D."
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbCatNonTax)
    Me.GroupBox1.Controls.Add(Me.RbCatTransfer)
    Me.GroupBox1.Controls.Add(Me.RbCatExempt)
    Me.GroupBox1.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
    Me.GroupBox1.Location = New System.Drawing.Point(491, 36)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(84, 110)
    Me.GroupBox1.TabIndex = 147
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Category"
    '
    'RbCatTransfer
    '
    Me.RbCatTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTransfer.ForeColor = System.Drawing.Color.Black
    Me.RbCatTransfer.Location = New System.Drawing.Point(8, 82)
    Me.RbCatTransfer.Name = "RbCatTransfer"
    Me.RbCatTransfer.Size = New System.Drawing.Size(64, 24)
    Me.RbCatTransfer.TabIndex = 2
    Me.RbCatTransfer.Text = "Transfer"
    '
    'RbCatExempt
    '
    Me.RbCatExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatExempt.ForeColor = System.Drawing.Color.Black
    Me.RbCatExempt.Location = New System.Drawing.Point(8, 62)
    Me.RbCatExempt.Name = "RbCatExempt"
    Me.RbCatExempt.Size = New System.Drawing.Size(64, 24)
    Me.RbCatExempt.TabIndex = 1
    Me.RbCatExempt.Text = "Exempt"
    '
    'RbCatTaxable
    '
    Me.RbCatTaxable.Checked = True
    Me.RbCatTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTaxable.ForeColor = System.Drawing.Color.Black
    Me.RbCatTaxable.Location = New System.Drawing.Point(8, 16)
    Me.RbCatTaxable.Name = "RbCatTaxable"
    Me.RbCatTaxable.Size = New System.Drawing.Size(64, 24)
    Me.RbCatTaxable.TabIndex = 0
    Me.RbCatTaxable.TabStop = True
    Me.RbCatTaxable.Text = "Taxable"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(398, 122)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(344, 122)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 122)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 132
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 74)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 131
    Me.Label3.Text = "Street Address"
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(96, 98)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(96, 74)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(96, 50)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 50)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 130
    Me.Label2.Text = "Second Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(96, 2)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(68, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(96, 26)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 2)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 129
    Me.Label1.Text = "List No"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(8, 26)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 128
    Me.Label5.Text = "Name"
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(312, 122)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(96, 122)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(256, 242)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 10
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(208, 245)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(48, 16)
    Me.Label42.TabIndex = 137
    Me.Label42.Text = "District"
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Checked = False
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(92, 243)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.ShowCheckBox = True
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 9
    Me.DtPckDOB.Value = New Date(2004, 11, 10, 8, 56, 25, 849)
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(4, 245)
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
    Me.Label18.Location = New System.Drawing.Point(498, 262)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(44, 16)
    Me.Label18.TabIndex = 194
    Me.Label18.Text = "Reg #"
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegno.Location = New System.Drawing.Point(487, 278)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.Size = New System.Drawing.Size(72, 22)
    Me.TxtRegno.TabIndex = 18
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(349, 262)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(44, 16)
    Me.Label17.TabIndex = 193
    Me.Label17.Text = "VIN #"
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVIN.Location = New System.Drawing.Point(336, 278)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(145, 22)
    Me.TxtVIN.TabIndex = 17
    '
    'TxtClass
    '
    Me.TxtClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtClass.Location = New System.Drawing.Point(307, 278)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 22)
    Me.TxtClass.TabIndex = 16
    Me.TxtClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(273, 262)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 16)
    Me.Label15.TabIndex = 191
    Me.Label15.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(267, 278)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtYear.TabIndex = 15
    Me.TxtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(222, 263)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 16)
    Me.Label14.TabIndex = 190
    Me.Label14.Text = "Body"
    '
    'TxtBody
    '
    Me.TxtBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBody.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBody.Location = New System.Drawing.Point(214, 278)
    Me.TxtBody.MaxLength = 6
    Me.TxtBody.Name = "TxtBody"
    Me.TxtBody.Size = New System.Drawing.Size(56, 22)
    Me.TxtBody.TabIndex = 14
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(143, 262)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(44, 16)
    Me.Label13.TabIndex = 189
    Me.Label13.Text = "Model"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtModel.Location = New System.Drawing.Point(136, 278)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(72, 22)
    Me.TxtModel.TabIndex = 13
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(562, 262)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(44, 16)
    Me.Label12.TabIndex = 188
    Me.Label12.Text = "Value"
    '
    'TxtValue
    '
    Me.TxtValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtValue.Location = New System.Drawing.Point(559, 278)
    Me.TxtValue.MaxLength = 9
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(81, 22)
    Me.TxtValue.TabIndex = 19
    Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(94, 262)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(44, 16)
    Me.Label10.TabIndex = 187
    Me.Label10.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMake.Location = New System.Drawing.Point(88, 278)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(52, 22)
    Me.TxtMake.TabIndex = 12
    '
    'TxtORegNo
    '
    Me.TxtORegNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtORegNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtORegNo.Location = New System.Drawing.Point(487, 314)
    Me.TxtORegNo.MaxLength = 8
    Me.TxtORegNo.Name = "TxtORegNo"
    Me.TxtORegNo.Size = New System.Drawing.Size(72, 22)
    Me.TxtORegNo.TabIndex = 27
    '
    'TxtOVIN
    '
    Me.TxtOVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOVIN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOVIN.Location = New System.Drawing.Point(336, 314)
    Me.TxtOVIN.MaxLength = 17
    Me.TxtOVIN.Name = "TxtOVIN"
    Me.TxtOVIN.Size = New System.Drawing.Size(145, 22)
    Me.TxtOVIN.TabIndex = 26
    '
    'TxtOClass
    '
    Me.TxtOClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOClass.Location = New System.Drawing.Point(308, 314)
    Me.TxtOClass.MaxLength = 2
    Me.TxtOClass.Name = "TxtOClass"
    Me.TxtOClass.Size = New System.Drawing.Size(28, 22)
    Me.TxtOClass.TabIndex = 25
    Me.TxtOClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtOYear
    '
    Me.TxtOYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOYear.Location = New System.Drawing.Point(267, 314)
    Me.TxtOYear.MaxLength = 4
    Me.TxtOYear.Name = "TxtOYear"
    Me.TxtOYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtOYear.TabIndex = 24
    Me.TxtOYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtOModel
    '
    Me.TxtOModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOModel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOModel.Location = New System.Drawing.Point(136, 314)
    Me.TxtOModel.MaxLength = 8
    Me.TxtOModel.Name = "TxtOModel"
    Me.TxtOModel.Size = New System.Drawing.Size(72, 22)
    Me.TxtOModel.TabIndex = 23
    '
    'TxtOValue
    '
    Me.TxtOValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOValue.Location = New System.Drawing.Point(559, 314)
    Me.TxtOValue.MaxLength = 9
    Me.TxtOValue.Name = "TxtOValue"
    Me.TxtOValue.Size = New System.Drawing.Size(81, 22)
    Me.TxtOValue.TabIndex = 28
    Me.TxtOValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtOMake
    '
    Me.TxtOMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOMake.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOMake.Location = New System.Drawing.Point(88, 314)
    Me.TxtOMake.MaxLength = 5
    Me.TxtOMake.Name = "TxtOMake"
    Me.TxtOMake.Size = New System.Drawing.Size(52, 22)
    Me.TxtOMake.TabIndex = 22
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(0, 278)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(44, 16)
    Me.Label6.TabIndex = 210
    Me.Label6.Text = "Vehicle"
    '
    'TxtAss
    '
    Me.TxtAss.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAss.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAss.Location = New System.Drawing.Point(646, 278)
    Me.TxtAss.MaxLength = 1
    Me.TxtAss.Name = "TxtAss"
    Me.TxtAss.Size = New System.Drawing.Size(18, 22)
    Me.TxtAss.TabIndex = 20
    '
    'LblPct
    '
    Me.LblPct.Location = New System.Drawing.Point(677, 282)
    Me.LblPct.Name = "LblPct"
    Me.LblPct.Size = New System.Drawing.Size(40, 16)
    Me.LblPct.TabIndex = 21
    '
    'Label25
    '
    Me.Label25.Location = New System.Drawing.Point(680, 262)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(32, 16)
    Me.Label25.TabIndex = 216
    Me.Label25.Text = "Pct"
    '
    'Label27
    '
    Me.Label27.Location = New System.Drawing.Point(50, 262)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(32, 16)
    Me.Label27.TabIndex = 218
    Me.Label27.Text = "List #"
    '
    'TxtOAss
    '
    Me.TxtOAss.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOAss.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOAss.Location = New System.Drawing.Point(646, 314)
    Me.TxtOAss.MaxLength = 1
    Me.TxtOAss.Name = "TxtOAss"
    Me.TxtOAss.Size = New System.Drawing.Size(18, 22)
    Me.TxtOAss.TabIndex = 29
    '
    'LblOListNo
    '
    Me.LblOListNo.Location = New System.Drawing.Point(38, 318)
    Me.LblOListNo.Name = "LblOListNo"
    Me.LblOListNo.Size = New System.Drawing.Size(44, 16)
    Me.LblOListNo.TabIndex = 222
    Me.LblOListNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblOPct
    '
    Me.LblOPct.Location = New System.Drawing.Point(677, 316)
    Me.LblOPct.Name = "LblOPct"
    Me.LblOPct.Size = New System.Drawing.Size(40, 16)
    Me.LblOPct.TabIndex = 30
    '
    'LnkAsmt
    '
    Me.LnkAsmt.Location = New System.Drawing.Point(645, 262)
    Me.LnkAsmt.Name = "LnkAsmt"
    Me.LnkAsmt.Size = New System.Drawing.Size(32, 16)
    Me.LnkAsmt.TabIndex = 223
    Me.LnkAsmt.TabStop = True
    Me.LnkAsmt.Text = "Asmt"
    '
    'LnkOAsmt
    '
    Me.LnkOAsmt.Location = New System.Drawing.Point(643, 300)
    Me.LnkOAsmt.Name = "LnkOAsmt"
    Me.LnkOAsmt.Size = New System.Drawing.Size(32, 16)
    Me.LnkOAsmt.TabIndex = 224
    Me.LnkOAsmt.TabStop = True
    Me.LnkOAsmt.Text = "Asmt"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblPRCredit)
    Me.GroupBox4.Controls.Add(Me.Label36)
    Me.GroupBox4.Controls.Add(Me.LblPRNet)
    Me.GroupBox4.Controls.Add(Me.Label23)
    Me.GroupBox4.Controls.Add(Me.LblPRExempt)
    Me.GroupBox4.Controls.Add(Me.LblPRGross)
    Me.GroupBox4.Controls.Add(Me.Label31)
    Me.GroupBox4.Controls.Add(Me.Label33)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(587, 36)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(144, 88)
    Me.GroupBox4.TabIndex = 137
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Pro Rated Totals"
    '
    'LblPRCredit
    '
    Me.LblPRCredit.BackColor = System.Drawing.Color.Aqua
    Me.LblPRCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPRCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPRCredit.Location = New System.Drawing.Point(74, 32)
    Me.LblPRCredit.Name = "LblPRCredit"
    Me.LblPRCredit.Size = New System.Drawing.Size(64, 16)
    Me.LblPRCredit.TabIndex = 23
    Me.LblPRCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label36
    '
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.Location = New System.Drawing.Point(4, 32)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(40, 16)
    Me.Label36.TabIndex = 22
    Me.Label36.Text = "Credit"
    '
    'LblPRNet
    '
    Me.LblPRNet.BackColor = System.Drawing.Color.Aqua
    Me.LblPRNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPRNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPRNet.Location = New System.Drawing.Point(74, 64)
    Me.LblPRNet.Name = "LblPRNet"
    Me.LblPRNet.Size = New System.Drawing.Size(64, 16)
    Me.LblPRNet.TabIndex = 21
    Me.LblPRNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label23
    '
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.Location = New System.Drawing.Point(4, 64)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(48, 16)
    Me.Label23.TabIndex = 20
    Me.Label23.Text = "Net"
    '
    'LblPRExempt
    '
    Me.LblPRExempt.BackColor = System.Drawing.Color.Aqua
    Me.LblPRExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPRExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPRExempt.Location = New System.Drawing.Point(74, 48)
    Me.LblPRExempt.Name = "LblPRExempt"
    Me.LblPRExempt.Size = New System.Drawing.Size(64, 16)
    Me.LblPRExempt.TabIndex = 19
    Me.LblPRExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPRGross
    '
    Me.LblPRGross.BackColor = System.Drawing.Color.Aqua
    Me.LblPRGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPRGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPRGross.Location = New System.Drawing.Point(74, 16)
    Me.LblPRGross.Name = "LblPRGross"
    Me.LblPRGross.Size = New System.Drawing.Size(64, 16)
    Me.LblPRGross.TabIndex = 18
    Me.LblPRGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label31
    '
    Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label31.Location = New System.Drawing.Point(4, 48)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(64, 16)
    Me.Label31.TabIndex = 16
    Me.Label31.Text = "Exemption"
    '
    'Label33
    '
    Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label33.Location = New System.Drawing.Point(4, 16)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(40, 16)
    Me.Label33.TabIndex = 15
    Me.Label33.Text = "Gross"
    '
    'LnkClass
    '
    Me.LnkClass.Location = New System.Drawing.Point(308, 262)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(35, 16)
    Me.LnkClass.TabIndex = 226
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'LnkOClass
    '
    Me.LnkOClass.Location = New System.Drawing.Point(306, 300)
    Me.LnkOClass.Name = "LnkOClass"
    Me.LnkOClass.Size = New System.Drawing.Size(35, 16)
    Me.LnkOClass.TabIndex = 227
    Me.LnkOClass.TabStop = True
    Me.LnkOClass.Text = "Class"
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(676, 6)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(60, 24)
    Me.BtnNext.TabIndex = 229
    Me.BtnNext.Text = "&Next"
    '
    'BtnPrevious
    '
    Me.BtnPrevious.Location = New System.Drawing.Point(610, 6)
    Me.BtnPrevious.Name = "BtnPrevious"
    Me.BtnPrevious.Size = New System.Drawing.Size(60, 24)
    Me.BtnPrevious.TabIndex = 228
    Me.BtnPrevious.Text = "&Previous"
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(586, 127)
    Me.LblTaxExempt.Name = "LblTaxExempt"
    Me.LblTaxExempt.Size = New System.Drawing.Size(94, 20)
    Me.LblTaxExempt.TabIndex = 231
    Me.LblTaxExempt.Text = "Tax Exempt"
    Me.LblTaxExempt.Visible = False
    '
    'BtnDMV
    '
    Me.BtnDMV.Location = New System.Drawing.Point(660, 408)
    Me.BtnDMV.Name = "BtnDMV"
    Me.BtnDMV.Size = New System.Drawing.Size(75, 24)
    Me.BtnDMV.TabIndex = 232
    Me.BtnDMV.Text = "DMV Data"
    '
    'LblOid
    '
    Me.LblOid.AutoSize = True
    Me.LblOid.Location = New System.Drawing.Point(672, 384)
    Me.LblOid.Name = "LblOid"
    Me.LblOid.Size = New System.Drawing.Size(35, 13)
    Me.LblOid.TabIndex = 239
    Me.LblOid.Text = "<Oid>"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(578, 384)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(56, 13)
    Me.Label7.TabIndex = 238
    Me.Label7.Text = "Vehicle ID"
    '
    'LblSS2
    '
    Me.LblSS2.AutoSize = True
    Me.LblSS2.Location = New System.Drawing.Point(672, 371)
    Me.LblSS2.Name = "LblSS2"
    Me.LblSS2.Size = New System.Drawing.Size(39, 13)
    Me.LblSS2.TabIndex = 237
    Me.LblSS2.Text = "<SS2>"
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(578, 371)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(93, 13)
    Me.Label16.TabIndex = 236
    Me.Label16.Text = "Secondary CustID"
    '
    'LblSSNo
    '
    Me.LblSSNo.AutoSize = True
    Me.LblSSNo.Location = New System.Drawing.Point(671, 358)
    Me.LblSSNo.Name = "LblSSNo"
    Me.LblSSNo.Size = New System.Drawing.Size(47, 13)
    Me.LblSSNo.TabIndex = 235
    Me.LblSSNo.Text = "<SSNo>"
    '
    'Label19
    '
    Me.Label19.AutoSize = True
    Me.Label19.Location = New System.Drawing.Point(578, 358)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(76, 13)
    Me.Label19.TabIndex = 234
    Me.Label19.Text = "Primary CustID"
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.Aqua
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(170, 4)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(31, 16)
    Me.LblYear.TabIndex = 240
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Location = New System.Drawing.Point(8, 336)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(552, 143)
    Me.TabControl1.TabIndex = 242
    '
    'TabPage1
    '
    Me.TabPage1.Controls.Add(Me.LblPlateExp)
    Me.TabPage1.Controls.Add(Me.Label22)
    Me.TabPage1.Controls.Add(Me.Label21)
    Me.TabPage1.Controls.Add(Me.TxtLightWgt)
    Me.TabPage1.Controls.Add(Me.TxtGrossWgt)
    Me.TabPage1.Controls.Add(Me.Label20)
    Me.TabPage1.Controls.Add(Me.GroupBox3)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(544, 117)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Details"
    Me.TabPage1.UseVisualStyleBackColor = True
    '
    'LblPlateExp
    '
    Me.LblPlateExp.Location = New System.Drawing.Point(417, 6)
    Me.LblPlateExp.Name = "LblPlateExp"
    Me.LblPlateExp.Size = New System.Drawing.Size(64, 16)
    Me.LblPlateExp.TabIndex = 202
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(337, 6)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(88, 16)
    Me.Label22.TabIndex = 200
    Me.Label22.Text = "Plate Expiration"
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(169, 6)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(64, 16)
    Me.Label21.TabIndex = 199
    Me.Label21.Text = "Light Wgt"
    '
    'TxtLightWgt
    '
    Me.TxtLightWgt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLightWgt.Location = New System.Drawing.Point(249, 6)
    Me.TxtLightWgt.MaxLength = 7
    Me.TxtLightWgt.Name = "TxtLightWgt"
    Me.TxtLightWgt.Size = New System.Drawing.Size(56, 22)
    Me.TxtLightWgt.TabIndex = 201
    Me.TxtLightWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtGrossWgt
    '
    Me.TxtGrossWgt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGrossWgt.Location = New System.Drawing.Point(81, 6)
    Me.TxtGrossWgt.MaxLength = 7
    Me.TxtGrossWgt.Name = "TxtGrossWgt"
    Me.TxtGrossWgt.Size = New System.Drawing.Size(56, 22)
    Me.TxtGrossWgt.TabIndex = 198
    Me.TxtGrossWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(1, 6)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(64, 16)
    Me.Label20.TabIndex = 204
    Me.Label20.Text = "Gross Wgt"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.LnkExempt5)
    Me.GroupBox3.Controls.Add(Me.TxtExempt5)
    Me.GroupBox3.Controls.Add(Me.LnkExempt3)
    Me.GroupBox3.Controls.Add(Me.TxtExempt3)
    Me.GroupBox3.Controls.Add(Me.LnkExempt4)
    Me.GroupBox3.Controls.Add(Me.TxtExempt4)
    Me.GroupBox3.Controls.Add(Me.LnkExempt2)
    Me.GroupBox3.Controls.Add(Me.TxtExempt2)
    Me.GroupBox3.Controls.Add(Me.LnkExempt1)
    Me.GroupBox3.Controls.Add(Me.TxtExempt1)
    Me.GroupBox3.Controls.Add(Me.TxtExam4)
    Me.GroupBox3.Controls.Add(Me.TxtExam2)
    Me.GroupBox3.Controls.Add(Me.TxtExam5)
    Me.GroupBox3.Controls.Add(Me.TxtExam3)
    Me.GroupBox3.Controls.Add(Me.TxtExam1)
    Me.GroupBox3.Controls.Add(Me.Label8)
    Me.GroupBox3.Controls.Add(Me.Label32)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox3.Location = New System.Drawing.Point(-7, 30)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(464, 80)
    Me.GroupBox3.TabIndex = 203
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Exemptions"
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(416, 16)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 4
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt5.Location = New System.Drawing.Point(408, 32)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt5.TabIndex = 9
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(248, 16)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 2
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt3.Location = New System.Drawing.Point(240, 32)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt3.TabIndex = 7
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(336, 16)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 3
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt4.Location = New System.Drawing.Point(320, 32)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt4.TabIndex = 8
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(168, 16)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 1
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt2.Location = New System.Drawing.Point(160, 32)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt2.TabIndex = 6
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(96, 16)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 0
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt1.Location = New System.Drawing.Point(88, 32)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt1.TabIndex = 5
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(304, 56)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam4.TabIndex = 13
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(144, 56)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam2.TabIndex = 11
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(384, 56)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam5.TabIndex = 14
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(224, 56)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam3.TabIndex = 12
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(73, 56)
    Me.TxtExam1.MaxLength = 7
    Me.TxtExam1.Name = "TxtExam1"
    Me.TxtExam1.Size = New System.Drawing.Size(64, 22)
    Me.TxtExam1.TabIndex = 10
    Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.Color.Black
    Me.Label8.Location = New System.Drawing.Point(8, 56)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 38
    Me.Label8.Text = "Amount"
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.ForeColor = System.Drawing.Color.Black
    Me.Label32.Location = New System.Drawing.Point(8, 32)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(32, 16)
    Me.Label32.TabIndex = 0
    Me.Label32.Text = "Code"
    '
    'TabPage2
    '
    Me.TabPage2.Controls.Add(Me.C1DataGrdList)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(544, 117)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Other Vehicles"
    Me.TabPage2.UseVisualStyleBackColor = True
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.GroupByCaption = "Drag a column header here to group by that column"
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(3, 3)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.PageSettings = CType(resources.GetObject("C1DataGrdList.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    Me.C1DataGrdList.Size = New System.Drawing.Size(535, 105)
    Me.C1DataGrdList.TabIndex = 242
    '
    'TxtResAdd2
    '
    Me.TxtResAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResAdd2.Location = New System.Drawing.Point(96, 168)
    Me.TxtResAdd2.MaxLength = 35
    Me.TxtResAdd2.Name = "TxtResAdd2"
    Me.TxtResAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtResAdd2.TabIndex = 10
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(161, 218)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(209, 22)
    Me.TxtLoc.TabIndex = 16
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(96, 218)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(62, 22)
    Me.TxtLocNo.TabIndex = 15
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label28
    '
    Me.Label28.Location = New System.Drawing.Point(0, 222)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(88, 16)
    Me.Label28.TabIndex = 311
    Me.Label28.Text = "Location#/Name"
    '
    'TxtResZip4
    '
    Me.TxtResZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResZip4.Location = New System.Drawing.Point(390, 192)
    Me.TxtResZip4.MaxLength = 4
    Me.TxtResZip4.Name = "TxtResZip4"
    Me.TxtResZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtResZip4.TabIndex = 14
    '
    'TxtResZip5
    '
    Me.TxtResZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResZip5.Location = New System.Drawing.Point(339, 192)
    Me.TxtResZip5.MaxLength = 5
    Me.TxtResZip5.Name = "TxtResZip5"
    Me.TxtResZip5.Size = New System.Drawing.Size(45, 22)
    Me.TxtResZip5.TabIndex = 13
    '
    'TxtResAdd1
    '
    Me.TxtResAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResAdd1.Location = New System.Drawing.Point(96, 144)
    Me.TxtResAdd1.MaxLength = 35
    Me.TxtResAdd1.Name = "TxtResAdd1"
    Me.TxtResAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtResAdd1.TabIndex = 9
    '
    'TxtResState
    '
    Me.TxtResState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResState.Location = New System.Drawing.Point(310, 192)
    Me.TxtResState.MaxLength = 2
    Me.TxtResState.Name = "TxtResState"
    Me.TxtResState.Size = New System.Drawing.Size(24, 22)
    Me.TxtResState.TabIndex = 12
    '
    'TxtResCity
    '
    Me.TxtResCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResCity.Location = New System.Drawing.Point(96, 192)
    Me.TxtResCity.MaxLength = 25
    Me.TxtResCity.Name = "TxtResCity"
    Me.TxtResCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtResCity.TabIndex = 11
    '
    'Label29
    '
    Me.Label29.Location = New System.Drawing.Point(0, 198)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(88, 16)
    Me.Label29.TabIndex = 310
    Me.Label29.Text = "Dom City/St/Zip"
    '
    'Label30
    '
    Me.Label30.Location = New System.Drawing.Point(2, 148)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(88, 16)
    Me.Label30.TabIndex = 309
    Me.Label30.Text = "Domicile Addr"
    '
    'RbCatNonTax
    '
    Me.RbCatNonTax.AutoSize = True
    Me.RbCatNonTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatNonTax.ForeColor = System.Drawing.Color.Black
    Me.RbCatNonTax.Location = New System.Drawing.Point(6, 42)
    Me.RbCatNonTax.Name = "RbCatNonTax"
    Me.RbCatNonTax.Size = New System.Drawing.Size(66, 17)
    Me.RbCatNonTax.TabIndex = 3
    Me.RbCatNonTax.Text = "Non Tax"
    '
    'FrmTAD05SU
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(745, 485)
    Me.Controls.Add(Me.TxtResAdd2)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label28)
    Me.Controls.Add(Me.TxtResZip4)
    Me.Controls.Add(Me.TxtResZip5)
    Me.Controls.Add(Me.TxtResAdd1)
    Me.Controls.Add(Me.TxtResState)
    Me.Controls.Add(Me.TxtResCity)
    Me.Controls.Add(Me.Label29)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.TxtBody)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblOid)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.LblSS2)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.LblSSNo)
    Me.Controls.Add(Me.Label19)
    Me.Controls.Add(Me.BtnDMV)
    Me.Controls.Add(Me.LblTaxExempt)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnPrevious)
    Me.Controls.Add(Me.LnkOClass)
    Me.Controls.Add(Me.LnkClass)
    Me.Controls.Add(Me.LnkOAsmt)
    Me.Controls.Add(Me.LnkAsmt)
    Me.Controls.Add(Me.LblOListNo)
    Me.Controls.Add(Me.LblOPct)
    Me.Controls.Add(Me.TxtOAss)
    Me.Controls.Add(Me.Label27)
    Me.Controls.Add(Me.Label25)
    Me.Controls.Add(Me.LblPct)
    Me.Controls.Add(Me.TxtAss)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtORegNo)
    Me.Controls.Add(Me.TxtOVIN)
    Me.Controls.Add(Me.TxtOClass)
    Me.Controls.Add(Me.TxtOYear)
    Me.Controls.Add(Me.TxtOModel)
    Me.Controls.Add(Me.TxtOValue)
    Me.Controls.Add(Me.TxtOMake)
    Me.Controls.Add(Me.TxtOid)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.GroupBox1)
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
    Me.Controls.Add(Me.TxtClass)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtModel)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtValue)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtMake)
    Me.Controls.Add(Me.GroupBox4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAD05SU"
    Me.Text = "Supplemental Motor Vehicle  Archive"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage1.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.TabPage2.ResumeLayout(False)
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAD05SU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXSUPA = New TXSUPA.MyData(myDBConnect)
    myTXSUPAL1 = New TXSUPAL1.MyData(myDBConnect)
    BuildDS()
    LoadForm()
  End Sub
  Private Sub FrmTAD05MV_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAD05B.FormatGrid(True, False, False)
    MyFrmTAD05B.Show()
    'Memory Cleanup
    myTXSUPA = Nothing
    MyFrmTAD05SU = Nothing

  End Sub
  Private Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("Listno", Type.GetType("System.Int32"))
      .Columns.Add("Vinno", Type.GetType("System.String"))
      .Columns.Add("Regno", Type.GetType("System.String"))
      .Columns.Add("Make", Type.GetType("System.String"))
      .Columns.Add("Year", Type.GetType("System.Int32"))
      .Columns.Add("Model", Type.GetType("System.String"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Public Sub LoadForm()
    Dim WrkCat As String
    Dim WrkProRate As Decimal
    Dim WrkProRateCR As Decimal

    LoadScrn = True
    ds.Clear()
    If WrkFastPath Then
      BtnPrevious.Visible = False
      BtnNext.Visible = False
    End If

    'Fill the dataset with the data
    TxtListNo.ReadOnly = True
    TxtListNo.TabStop = False
    TxtListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    myTXSUPA.GetOneRecordP(WrkListNo, WrkYear)

    If myTXSUPA.RecordNotFound Then
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If

    With myTXSUPA
      TxtName.Text = Trim(._NAME)
      TxtSname.Text = Trim(._SNAME)
      TxtAdd1.Text = Trim(._ADD1)
      TxtAdd2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      TxtZip5.Text = Format(._ZIP5, "00000")
      TxtZip4.Text = Format(._ZIP4, "0000")
      'inserted for domicile and loc
      TxtResAdd1.Text = Trim(._RAD1)
      TxtResAdd2.Text = Trim(._RAD2)
      TxtResCity.Text = Trim(._RCTY)
      TxtResState.Text = Trim(._RST)
      TxtResZip5.Text = Format(._RZ5, "00000")
      TxtResZip4.Text = Format(._RZ4, "0000")
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)


      LblOid.Text = ._OID
      LblSSNo.Text = ._SSNo
      LblSS2.Text = ._SS2
      TxtDist.Text = ._DIST
      WrkCat = Trim(._CAT)
      Select Case WrkCat
        Case "1"
          RbCatTaxable.Checked = True
          LblTaxExempt.Visible = False
        Case "2"
          RbCatNonTax.Checked = True
          LblTaxExempt.Visible = False
        Case "3"
          RbCatExempt.Checked = True
          LblTaxExempt.Visible = True
        Case "T"
          RbCatTransfer.Checked = True
          LblTaxExempt.Visible = False


      End Select
      TxtGrossWgt.Text = ._GWT
      TxtLightWgt.Text = ._LWT
      If ._XDATE > 0 Then
        LblPlateExp.Text = MyUtils.GetDBDate(._XDATE)
      Else
        LblPlateExp.Text = ""
      End If
      TxtAss.Text = Trim(._ASS)
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtBody.Text = Trim(._BODY)
      TxtYear.Text = ._YEAR
      TxtClass.Text = ._CLASS
      TxtVIN.Text = Trim(._VINNO)
      TxtRegno.Text = Trim(._REGNO)
      TxtOAss.Text = Trim(._OASS)
      TxtOMake.Text = Trim(._OMAKE)
      TxtOModel.Text = Trim(._OMOD)
      TxtOYear.Text = ._OYEAR
      TxtOClass.Text = ._OCLS
      TxtOVIN.Text = Trim(._OVIN)
      TxtORegNo.Text = Trim(._OREGNo)
      LblOListNo.Text = String.Empty
      If ._OLIST > 0 Then
        LblOListNo.Text = ._OLIST
      End If
      TxtGrossWgt.Text = ._GWT
      TxtLightWgt.Text = ._LWT
      TxtValue.Text = ._VALUE
      TxtOValue.Text = ._OVAL
      If ._DOB > 0 Then
        DtPckDOB.Value = MyUtils.GetDBDate(._DOB)
        DtPckDOB.Checked = True
      Else
        DtPckDOB.Value = Date.Today
        DtPckDOB.Checked = False
      End If
      TxtExam1.Text = ._EXAM1
      TxtExam2.Text = ._EXAM2
      TxtExam3.Text = ._EXAM3
      TxtExam4.Text = ._EXAM4
      TxtExam5.Text = ._EXAM5
    End With

    With myTXSUPA
      'Exemption Codes
      TxtExempt1.Text = Trim(._EXCD1)
      TxtExempt2.Text = Trim(._EXCD2)
      TxtExempt3.Text = Trim(._EXCD3)
      TxtExempt4.Text = Trim(._EXCD4)
      TxtExempt5.Text = Trim(._EXCD5)
      SetExem1Tip()
      SetExem2Tip()
      SetExem3Tip()
      SetExem4Tip()
      SetExem5Tip()
      SetSupCdTip()
      SetOSupCdTip()
      WrkProRate = CalcProRate(MyUtils.CnvSng(TxtValue.Text), MyUtils.CnvSng(LblPct.Text))
      LblPRGross.Text = Format(WrkProRate, "#######0")
      WrkProRateCR = CalcProRate(MyUtils.CnvSng(TxtOValue.Text), MyUtils.CnvSng(LblOPct.Text))
      If WrkProRateCR > WrkProRate Then
        WrkProRateCR = WrkProRate
      End If
      LblPRCredit.Text = Format(WrkProRateCR, "#######0")
      LblPRExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      LblPRNet.Text = MyUtils.CnvSng(LblPRGross.Text) - MyUtils.CnvSng(LblPRCredit.Text) - MyUtils.CnvSng(LblPRExempt.Text)
      PopulateGrid(._SSNo, True)
      PopulateGrid(._SSNo, False)
      If ._SS2 > 0 Then
        PopulateGrid(._SS2, True)
        PopulateGrid(._SS2, False)
      End If
    End With
    FormatGrid()
    LoadScrn = False
  End Sub
  Private Sub PopulateGrid(ByVal WrkCustid As Integer, ByVal WrkPrimary As Boolean)
    Dim dstemp As DataSet = New DataSet
    Dim Dr As DataRow
    Dim drSel() As DataRow
    Dim WrkSelect As String
    Dim I As Integer
    If WrkPrimary Then
      dstemp = myTXSUPAL1.GetViewSSNo(WrkYear, WrkCustid, 999, False)
    Else
      dstemp = myTXSUPAL1.GetViewSS2(WrkYear, WrkCustid, 999, False)
    End If
    For I = 0 To dstemp.Tables(0).Rows.Count - 1
      If dstemp.Tables(0).Rows(I).Item("list#") = MyUtils.CnvSng(TxtListNo.Text) Then
        Continue For
      End If
      WrkSelect = "listno=" & dstemp.Tables(0).Rows(I).Item("list#")
      drSel = ds.Tables(0).Select(WrkSelect)
      If drSel.GetUpperBound(0) = -1 Then
        Dr = ds.Tables(0).NewRow
        Dr.Item(0) = dstemp.Tables(0).Rows(I).Item(0)
        Dr.Item(1) = dstemp.Tables(0).Rows(I).Item(1)
        Dr.Item(2) = dstemp.Tables(0).Rows(I).Item(2)
        Dr.Item(3) = dstemp.Tables(0).Rows(I).Item(3)
        Dr.Item(4) = dstemp.Tables(0).Rows(I).Item(4)
        Dr.Item(5) = dstemp.Tables(0).Rows(I).Item(5)
        ds.Tables(0).Rows.Add(Dr)
      End If
    Next
  End Sub
  Private Sub FormatGrid()
    C1DataGrdList.DataSource = ds.Tables(0)
    C1DataGrdList.Refresh()

    With C1DataGrdList
      .Rebind(True)
      .Columns(0).Caption = "List #"
      .Splits(0).DisplayColumns(0).Width = 50
      .Columns(1).Caption = "Vin No"
      .Splits(0).DisplayColumns(1).Width = 150
      .Columns(2).Caption = "Reg No"
      .Splits(0).DisplayColumns(2).Width = 50
      .Columns(3).Caption = "Make"
      .Splits(0).DisplayColumns(3).Width = 50
      .Columns(4).Caption = "Year"
      .Splits(0).DisplayColumns(4).Width = 50
      .Columns(5).Caption = "Model"
      .Splits(0).DisplayColumns(5).Width = 80
    End With
  End Sub
  Private Sub FrmTAD05SU_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD05.SbpScreen.Text = "TAD05SU"
    If DtPckDOB.Value <> Date.Today Then
      DtPckDOB.Checked = True
    Else
      DtPckDOB.Checked = False
    End If
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Public Sub CalcAssmt()
    Dim WrkGross As Integer
    Dim WrkCredit As Integer
    Dim WrkExam As Integer
    Dim WrkNet As Integer
    Dim WrkOValue As Integer

    If LoadScrn Then Exit Sub

    WrkOValue = MyUtils.CnvSng(TxtOValue.Text)
    WrkGross = CalcProRate(MyUtils.CnvSng(TxtValue.Text), MyUtils.CnvSng(LblPct.Text))
    WrkCredit = CalcProRate(WrkOValue, MyUtils.CnvSng(LblOPct.Text))
    WrkExam = MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) + MyUtils.CnvSng(TxtExam4.Text) + MyUtils.CnvSng(TxtExam5.Text)
    WrkNet = WrkGross - WrkCredit - WrkExam
    If WrkNet < 0 Then
      If WrkOValue > 0 And WrkExam = 0 Then
        TxtOValue.Text = MyUtils.Round(WrkOValue - (Math.Abs(WrkNet) / MyUtils.CnvSng(LblOPct.Text)), 0)
        WrkCredit = CalcProRate(MyUtils.CnvSng(TxtOValue.Text), MyUtils.CnvSng(LblOPct.Text))
        MsgBox("Credit changed from " & WrkOValue & " to " & TxtOValue.Text, MsgBoxStyle.Information, "Net would be negative")
        WrkNet = WrkGross - WrkCredit - WrkExam
      End If
    End If
    LblPRGross.Text = Format(WrkGross, "#######0")
    LblPRCredit.Text = Format(WrkCredit, "#######0")
    LblPRExempt.Text = WrkExam
    LblPRNet.Text = WrkNet
  End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt1.Text
    MyFrmListExemption.WrkCode = TxtExempt1.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt2.Text
    MyFrmListExemption.WrkCode = TxtExempt2.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt3.Text
    MyFrmListExemption.WrkCode = TxtExempt3.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt4.Text
    MyFrmListExemption.WrkCode = TxtExempt4.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt5.Text
    MyFrmListExemption.WrkCode = TxtExempt5.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub TxtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtValue.TextChanged
    CalcAssmt()
  End Sub
  Private Sub LnkAsmt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkAsmt.LinkClicked
    MyFrmListSupCd = New FrmListSupCd
    MyFrmListSupCd.MdiParent = Me.ParentForm
    MyFrmListSupCd.WrkFieldNo = ""
    MyFrmListSupCd.WrkCode = TxtAss.Text
    MyFrmListSupCd.Show()
  End Sub

  Private Sub LnkOAsmt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOAsmt.LinkClicked
    MyFrmListSupCd = New FrmListSupCd
    MyFrmListSupCd.MdiParent = Me.ParentForm
    MyFrmListSupCd.WrkFieldNo = "Credit"
    MyFrmListSupCd.WrkCode = TxtOAss.Text
    MyFrmListSupCd.Show()

  End Sub
  Private Sub TxtAss_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAss.TextChanged
    SetSupCdTip()
    CalcAssmt()
  End Sub
  Private Sub TxtOAss_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOAss.TextChanged
    SetOSupCdTip()
    CalcAssmt()
  End Sub
  Private Sub TxtOValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOValue.TextChanged
    CalcAssmt()
  End Sub
  Private Sub BtnCredit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    MyFrmTAD05SU_CR = New FrmTAD05SU_CR
    '    MyFrmTAD05SU_CR.ShowDialog()
  End Sub
  Private Sub TxtExempt1_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    SetExem1Tip()
  End Sub
  Private Sub TxtExempt2_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    SetExem2Tip()
  End Sub
  Private Sub TxtExempt3_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    SetExem3Tip()
  End Sub
  Private Sub TxtExempt4_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    SetExem4Tip()
  End Sub
  Private Sub TxtExempt5_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    SetExem5Tip()
  End Sub
  Private Sub SetExem1Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt1.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt1.Text)
    Ttp1.SetToolTip(TxtExempt1, WrkTxExem(1))
  End Sub
  Private Sub SetExem2Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt2.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt2.Text)
    Ttp1.SetToolTip(TxtExempt2, WrkTxExem(1))
  End Sub
  Private Sub SetExem3Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt3.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt3.Text)
    Ttp1.SetToolTip(TxtExempt3, WrkTxExem(1))
  End Sub
  Private Sub SetExem4Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt4.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt4.Text)
    Ttp1.SetToolTip(TxtExempt4, WrkTxExem(1))
  End Sub
  Private Sub SetExem5Tip()
    Dim WrkTxExem As String()

    If Not TxtExempt5.Modified And Not LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt5.Text)
    Ttp1.SetToolTip(TxtExempt5, WrkTxExem(1))
  End Sub
  Private Sub SetSupCdTip()
    Dim WrkTxSupCd As String()

    WrkTxSupCd = GetTXSupCd(TxtAss.Text)
    LblPct.Text = WrkTxSupCd(0)
    Ttp1.SetToolTip(TxtAss, WrkTxSupCd(1))
    If WrkTxSupCd(2) = "Y" Then
      WrkCredit = True
    Else
      WrkCredit = False
    End If
  End Sub
  Private Sub SetOSupCdTip()
    Dim WrkTxSupCd As String()

    WrkTxSupCd = GetTXSupCd(TxtOAss.Text)
    LblOPct.Text = WrkTxSupCd(0)
    Ttp1.SetToolTip(TxtOAss, WrkTxSupCd(1))
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
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
  Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOValue.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGrossWgt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLightWgt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = 1
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
  End Sub

  Private Sub LnkOClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkOClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = 2
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtOClass.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click

    With MyFrmTAD05B
      If .C1DataGrdList.Row = .C1DataGrdList.Splits(0).Rows.Count - 1 Then
        MsgBox("No more records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get next record")
        Exit Sub
      End If
      .C1DataGrdList.Row = .C1DataGrdList.Row + 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 0)
    End With

    LoadForm()

  End Sub
  Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
    With MyFrmTAD05B
      If .C1DataGrdList.Row = 0 Then
        MsgBox("No previous records in view. You can change the view from the search screen", MsgBoxStyle.Exclamation, "Cannot get previous record")
        Exit Sub
      End If

      .C1DataGrdList.Row = .C1DataGrdList.Row - 1
      WrkListNo = .C1DataGrdList.Item(.C1DataGrdList.Row, 0)
    End With

    LoadForm()

  End Sub
  Private Sub RbCatExempt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCatExempt.Click
    LblTaxExempt.Visible = True
  End Sub
  Private Sub RbCatTaxable_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCatTaxable.Click
    LblTaxExempt.Visible = False
  End Sub
  Private Sub RbCatTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbCatTransfer.Click
    LblTaxExempt.Visible = False
  End Sub

  Private Sub BtnDMV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDMV.Click
    MyFrmTAD05DMV = New FrmTAD05DMV
    MyFrmTAD05DMV.MdiParent = Me.ParentForm
    MyFrmTAD05DMV.WrkVehID = MyUtils.CnvSng(LblOid.Text)
    MyFrmTAD05DMV.WrkPCustID = MyUtils.CnvSng(LblSSNo.Text)
    MyFrmTAD05DMV.WrkSCustID = MyUtils.CnvSng(LblSS2.Text)
    MyFrmTAD05DMV.WrkRegNo = TxtRegno.Text
    MyFrmTAD05DMV.WrkVIN = TxtVIN.Text
    MyFrmTAD05DMV.WrkListNo = WrkListNo
    MyFrmTAD05DMV.WrkName = TxtName.Text
    MyFrmTAD05DMV.WrkType = "S"
    MyFrmTAD05DMV.Show()
    Me.Hide()
  End Sub
End Class






