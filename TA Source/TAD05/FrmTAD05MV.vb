Public Class FrmTAD05MV
  Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkFastPath As Boolean
  Dim myTXMVA As TXMVA.MyData
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMVAL8 As TXMVAL8.MyData
  Dim myTXMVAL9 As TXMVAL9.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXBAA As TXBAA.MyData
  Dim LoadScrn As Boolean

  Friend WithEvents LblBaaNet As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LblBaa As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents BtnPrevious As System.Windows.Forms.Button
  Friend WithEvents ChkDnbtr As System.Windows.Forms.CheckBox
  Friend WithEvents DtPckBtr As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblDtPckBtr As System.Windows.Forms.Label
  Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
  Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblSSNo As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblOid As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents LblSS2 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents BtnDMV As System.Windows.Forms.Button
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LblYear As Label
  Friend WithEvents C1DataGrdList As C1.Win.C1TrueDBGrid.C1TrueDBGrid
  Const WrkType As String = "M"
  Friend WithEvents LblMSRPCalc As Label
  Friend WithEvents LblMSRP As Label
  Friend WithEvents Label27 As Label
  Friend WithEvents LblValue As Label
  Friend WithEvents TxtSource As TextBox
  Friend WithEvents Label24 As Label
  Friend WithEvents TxtOVMSRP As TextBox
  Friend WithEvents Label16 As Label
  Friend WithEvents GroupBox1 As GroupBox
  Friend WithEvents RbCatNonTax As RadioButton
  Friend WithEvents RbCatTransfer As RadioButton
  Friend WithEvents RbCatExempt As RadioButton
  Friend WithEvents RbCatTaxable As RadioButton
  Friend WithEvents LnkSource As LinkLabel
  Dim ds As DataSet = New DataSet
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
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LblExempt As System.Windows.Forms.Label
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
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
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtPdst As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtBody As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents TxtYear As System.Windows.Forms.TextBox
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtVIN As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtRegno As System.Windows.Forms.TextBox
  Friend WithEvents TxtResZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtResZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtResAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtResState As System.Windows.Forms.TextBox
  Friend WithEvents TxtResCity As System.Windows.Forms.TextBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
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
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtBaa As System.Windows.Forms.TextBox
  Friend WithEvents LblBaa1 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents TxtGrossWgt As System.Windows.Forms.TextBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents TxtLightWgt As System.Windows.Forms.TextBox
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents LblPlateExp As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTAD05MV))
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblBaaNet = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblBaa = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
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
    Me.TxtResZip4 = New System.Windows.Forms.TextBox()
    Me.TxtResZip5 = New System.Windows.Forms.TextBox()
    Me.TxtResAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtResState = New System.Windows.Forms.TextBox()
    Me.TxtResCity = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.TxtPdst = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtBody = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.TxtVIN = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtRegno = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtBaa = New System.Windows.Forms.TextBox()
    Me.LblBaa1 = New System.Windows.Forms.Label()
    Me.TxtGrossWgt = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtLightWgt = New System.Windows.Forms.TextBox()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.LblPlateExp = New System.Windows.Forms.Label()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnPrevious = New System.Windows.Forms.Button()
    Me.ChkDnbtr = New System.Windows.Forms.CheckBox()
    Me.DtPckBtr = New System.Windows.Forms.DateTimePicker()
    Me.LblDtPckBtr = New System.Windows.Forms.Label()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblSSNo = New System.Windows.Forms.Label()
    Me.LblSS2 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblOid = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.BtnDMV = New System.Windows.Forms.Button()
    Me.LblBeforeCC = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.C1DataGrdList = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    Me.LblMSRPCalc = New System.Windows.Forms.Label()
    Me.LblMSRP = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.LblValue = New System.Windows.Forms.Label()
    Me.TxtSource = New System.Windows.Forms.TextBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.TxtOVMSRP = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbCatNonTax = New System.Windows.Forms.RadioButton()
    Me.RbCatTransfer = New System.Windows.Forms.RadioButton()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.LnkSource = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(4, 204)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(88, 16)
    Me.Label9.TabIndex = 69
    Me.Label9.Text = "Date of Birth"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(4, 172)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(102, 16)
    Me.Label7.TabIndex = 68
    Me.Label7.Text = "Domicile City/St/Zip"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(410, 123)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(356, 123)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 7
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblBaaNet)
    Me.GroupBox2.Controls.Add(Me.Label19)
    Me.GroupBox2.Controls.Add(Me.LblBaa)
    Me.GroupBox2.Controls.Add(Me.Label28)
    Me.GroupBox2.Controls.Add(Me.LblNet)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblExempt)
    Me.GroupBox2.Controls.Add(Me.LblGross)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.Label29)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(580, 36)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(142, 113)
    Me.GroupBox2.TabIndex = 71
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
    '
    'LblBaaNet
    '
    Me.LblBaaNet.BackColor = System.Drawing.Color.Aqua
    Me.LblBaaNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaaNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaaNet.Location = New System.Drawing.Point(72, 92)
    Me.LblBaaNet.Name = "LblBaaNet"
    Me.LblBaaNet.Size = New System.Drawing.Size(64, 16)
    Me.LblBaaNet.TabIndex = 27
    Me.LblBaaNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(4, 94)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(48, 16)
    Me.Label19.TabIndex = 26
    Me.Label19.Text = "BAA Net"
    '
    'LblBaa
    '
    Me.LblBaa.BackColor = System.Drawing.Color.Aqua
    Me.LblBaa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaa.Location = New System.Drawing.Point(72, 76)
    Me.LblBaa.Name = "LblBaa"
    Me.LblBaa.Size = New System.Drawing.Size(64, 16)
    Me.LblBaa.TabIndex = 25
    Me.LblBaa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(4, 78)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(40, 16)
    Me.Label28.TabIndex = 24
    Me.Label28.Text = "B.A.A"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.Aqua
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(72, 46)
    Me.LblNet.Name = "LblNet"
    Me.LblNet.Size = New System.Drawing.Size(64, 16)
    Me.LblNet.TabIndex = 21
    Me.LblNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label34
    '
    Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label34.Location = New System.Drawing.Point(4, 48)
    Me.Label34.Name = "Label34"
    Me.Label34.Size = New System.Drawing.Size(48, 16)
    Me.Label34.TabIndex = 20
    Me.Label34.Text = "Net"
    '
    'LblExempt
    '
    Me.LblExempt.BackColor = System.Drawing.Color.Aqua
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(72, 30)
    Me.LblExempt.Name = "LblExempt"
    Me.LblExempt.Size = New System.Drawing.Size(64, 16)
    Me.LblExempt.TabIndex = 19
    Me.LblExempt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGross
    '
    Me.LblGross.BackColor = System.Drawing.Color.Aqua
    Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGross.Location = New System.Drawing.Point(72, 14)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(64, 16)
    Me.LblGross.TabIndex = 18
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(4, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(62, 14)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Exemption"
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(4, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(40, 16)
    Me.Label29.TabIndex = 15
    Me.Label29.Text = "Gross"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(4, 148)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 67
    Me.Label6.Text = "Domicile Addr"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(4, 126)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 66
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(4, 84)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 65
    Me.Label3.Text = "Street Address"
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(108, 100)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(108, 81)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(108, 57)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(4, 60)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 64
    Me.Label2.Text = "Second Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(108, 13)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(70, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(108, 38)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(4, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 63
    Me.Label1.Text = "List No"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(4, 41)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 61
    Me.Label5.Text = "Name"
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(324, 123)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(108, 123)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(272, 201)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 14
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(228, 204)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(48, 16)
    Me.Label42.TabIndex = 15
    Me.Label42.Text = "District"
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
    Me.GroupBox3.Location = New System.Drawing.Point(7, 300)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(460, 80)
    Me.GroupBox3.TabIndex = 29
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Exemptions"
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(416, 12)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 178
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt5.Location = New System.Drawing.Point(408, 28)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt5.TabIndex = 35
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(248, 12)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 177
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt3.Location = New System.Drawing.Point(240, 28)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt3.TabIndex = 31
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(336, 12)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 176
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt4.Location = New System.Drawing.Point(320, 28)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt4.TabIndex = 33
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(168, 12)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 175
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt2.Location = New System.Drawing.Point(160, 28)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt2.TabIndex = 29
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(96, 12)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 174
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt1.Location = New System.Drawing.Point(88, 28)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt1.TabIndex = 27
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(304, 52)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam4.TabIndex = 34
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(144, 52)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam2.TabIndex = 30
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(384, 52)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam5.TabIndex = 36
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(224, 52)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam3.TabIndex = 32
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(63, 52)
    Me.TxtExam1.MaxLength = 7
    Me.TxtExam1.Name = "TxtExam1"
    Me.TxtExam1.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam1.TabIndex = 28
    Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.Color.Black
    Me.Label8.Location = New System.Drawing.Point(8, 52)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 38
    Me.Label8.Text = "Amount"
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.ForeColor = System.Drawing.Color.Black
    Me.Label32.Location = New System.Drawing.Point(8, 28)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(32, 16)
    Me.Label32.TabIndex = 0
    Me.Label32.Text = "Code"
    '
    'TxtResZip4
    '
    Me.TxtResZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResZip4.Location = New System.Drawing.Point(414, 169)
    Me.TxtResZip4.MaxLength = 4
    Me.TxtResZip4.Name = "TxtResZip4"
    Me.TxtResZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtResZip4.TabIndex = 12
    '
    'TxtResZip5
    '
    Me.TxtResZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResZip5.Location = New System.Drawing.Point(363, 169)
    Me.TxtResZip5.MaxLength = 5
    Me.TxtResZip5.Name = "TxtResZip5"
    Me.TxtResZip5.Size = New System.Drawing.Size(45, 22)
    Me.TxtResZip5.TabIndex = 11
    '
    'TxtResAdd1
    '
    Me.TxtResAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResAdd1.Location = New System.Drawing.Point(108, 146)
    Me.TxtResAdd1.MaxLength = 35
    Me.TxtResAdd1.Name = "TxtResAdd1"
    Me.TxtResAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtResAdd1.TabIndex = 9
    '
    'TxtResState
    '
    Me.TxtResState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResState.Location = New System.Drawing.Point(328, 169)
    Me.TxtResState.MaxLength = 2
    Me.TxtResState.Name = "TxtResState"
    Me.TxtResState.Size = New System.Drawing.Size(24, 22)
    Me.TxtResState.TabIndex = 11
    '
    'TxtResCity
    '
    Me.TxtResCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResCity.Location = New System.Drawing.Point(108, 169)
    Me.TxtResCity.MaxLength = 25
    Me.TxtResCity.Name = "TxtResCity"
    Me.TxtResCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtResCity.TabIndex = 10
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(12, 256)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(44, 16)
    Me.Label10.TabIndex = 88
    Me.Label10.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMake.Location = New System.Drawing.Point(12, 272)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(48, 22)
    Me.TxtMake.TabIndex = 18
    '
    'TxtPdst
    '
    Me.TxtPdst.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPdst.Location = New System.Drawing.Point(404, 201)
    Me.TxtPdst.MaxLength = 3
    Me.TxtPdst.Name = "TxtPdst"
    Me.TxtPdst.Size = New System.Drawing.Size(32, 22)
    Me.TxtPdst.TabIndex = 15
    Me.TxtPdst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label40
    '
    Me.Label40.Location = New System.Drawing.Point(332, 204)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(72, 16)
    Me.Label40.TabIndex = 103
    Me.Label40.Text = "Other District"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(64, 256)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(44, 16)
    Me.Label13.TabIndex = 108
    Me.Label13.Text = "Model"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtModel.Location = New System.Drawing.Point(64, 272)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(72, 22)
    Me.TxtModel.TabIndex = 19
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(136, 256)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 16)
    Me.Label14.TabIndex = 110
    Me.Label14.Text = "Body"
    '
    'TxtBody
    '
    Me.TxtBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBody.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBody.Location = New System.Drawing.Point(139, 272)
    Me.TxtBody.MaxLength = 6
    Me.TxtBody.Name = "TxtBody"
    Me.TxtBody.Size = New System.Drawing.Size(56, 22)
    Me.TxtBody.TabIndex = 20
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(192, 256)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 16)
    Me.Label15.TabIndex = 112
    Me.Label15.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(192, 272)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtYear.TabIndex = 21
    '
    'TxtClass
    '
    Me.TxtClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtClass.Location = New System.Drawing.Point(232, 272)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 22)
    Me.TxtClass.TabIndex = 22
    Me.TxtClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(264, 256)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(44, 16)
    Me.Label17.TabIndex = 116
    Me.Label17.Text = "VIN #"
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVIN.Location = New System.Drawing.Point(264, 272)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(145, 22)
    Me.TxtVIN.TabIndex = 23
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(412, 256)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(44, 16)
    Me.Label18.TabIndex = 118
    Me.Label18.Text = "Reg #"
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegno.Location = New System.Drawing.Point(412, 272)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.Size = New System.Drawing.Size(72, 22)
    Me.TxtRegno.TabIndex = 24
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtBaa
    '
    Me.TxtBaa.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa.Location = New System.Drawing.Point(618, 272)
    Me.TxtBaa.MaxLength = 9
    Me.TxtBaa.Name = "TxtBaa"
    Me.TxtBaa.Size = New System.Drawing.Size(72, 22)
    Me.TxtBaa.TabIndex = 26
    Me.TxtBaa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBaa1
    '
    Me.LblBaa1.Location = New System.Drawing.Point(618, 258)
    Me.LblBaa1.Name = "LblBaa1"
    Me.LblBaa1.Size = New System.Drawing.Size(79, 14)
    Me.LblBaa1.TabIndex = 180
    Me.LblBaa1.Text = "B.A.A Amount"
    '
    'TxtGrossWgt
    '
    Me.TxtGrossWgt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGrossWgt.Location = New System.Drawing.Point(545, 308)
    Me.TxtGrossWgt.MaxLength = 6
    Me.TxtGrossWgt.Name = "TxtGrossWgt"
    Me.TxtGrossWgt.Size = New System.Drawing.Size(56, 22)
    Me.TxtGrossWgt.TabIndex = 27
    Me.TxtGrossWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(478, 312)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(64, 16)
    Me.Label20.TabIndex = 182
    Me.Label20.Text = "Gross Wgt"
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(485, 336)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(57, 16)
    Me.Label21.TabIndex = 184
    Me.Label21.Text = "Light Wgt"
    '
    'TxtLightWgt
    '
    Me.TxtLightWgt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLightWgt.Location = New System.Drawing.Point(545, 332)
    Me.TxtLightWgt.MaxLength = 6
    Me.TxtLightWgt.Name = "TxtLightWgt"
    Me.TxtLightWgt.Size = New System.Drawing.Size(56, 22)
    Me.TxtLightWgt.TabIndex = 28
    Me.TxtLightWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(473, 357)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(88, 16)
    Me.Label22.TabIndex = 185
    Me.Label22.Text = "Plate Expiration"
    '
    'LblPlateExp
    '
    Me.LblPlateExp.Location = New System.Drawing.Point(553, 357)
    Me.LblPlateExp.Name = "LblPlateExp"
    Me.LblPlateExp.Size = New System.Drawing.Size(64, 16)
    Me.LblPlateExp.TabIndex = 29
    '
    'LnkClass
    '
    Me.LnkClass.Location = New System.Drawing.Point(229, 256)
    Me.LnkClass.Name = "LnkClass"
    Me.LnkClass.Size = New System.Drawing.Size(35, 16)
    Me.LnkClass.TabIndex = 188
    Me.LnkClass.TabStop = True
    Me.LnkClass.Text = "Class"
    '
    'BtnNext
    '
    Me.BtnNext.Location = New System.Drawing.Point(662, 6)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(60, 24)
    Me.BtnNext.TabIndex = 190
    Me.BtnNext.Text = "&Next"
    '
    'BtnPrevious
    '
    Me.BtnPrevious.Location = New System.Drawing.Point(596, 6)
    Me.BtnPrevious.Name = "BtnPrevious"
    Me.BtnPrevious.Size = New System.Drawing.Size(60, 24)
    Me.BtnPrevious.TabIndex = 189
    Me.BtnPrevious.Text = "&Previous"
    '
    'ChkDnbtr
    '
    Me.ChkDnbtr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDnbtr.Location = New System.Drawing.Point(212, 234)
    Me.ChkDnbtr.Name = "ChkDnbtr"
    Me.ChkDnbtr.Size = New System.Drawing.Size(72, 16)
    Me.ChkDnbtr.TabIndex = 17
    Me.ChkDnbtr.Text = "Denied?"
    '
    'DtPckBtr
    '
    Me.DtPckBtr.Checked = False
    Me.DtPckBtr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckBtr.Location = New System.Drawing.Point(108, 231)
    Me.DtPckBtr.Name = "DtPckBtr"
    Me.DtPckBtr.ShowCheckBox = True
    Me.DtPckBtr.Size = New System.Drawing.Size(96, 20)
    Me.DtPckBtr.TabIndex = 16
    '
    'LblDtPckBtr
    '
    Me.LblDtPckBtr.Location = New System.Drawing.Point(4, 229)
    Me.LblDtPckBtr.Name = "LblDtPckBtr"
    Me.LblDtPckBtr.Size = New System.Drawing.Size(88, 16)
    Me.LblDtPckBtr.TabIndex = 193
    Me.LblDtPckBtr.Text = "BTR Applied"
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(615, 152)
    Me.LblTaxExempt.Name = "LblTaxExempt"
    Me.LblTaxExempt.Size = New System.Drawing.Size(94, 20)
    Me.LblTaxExempt.TabIndex = 227
    Me.LblTaxExempt.Text = "Tax Exempt"
    Me.LblTaxExempt.Visible = False
    '
    'DtPckDOB
    '
    Me.DtPckDOB.Checked = False
    Me.DtPckDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDOB.Location = New System.Drawing.Point(108, 202)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.ShowCheckBox = True
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 13
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(564, 413)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(76, 13)
    Me.Label11.TabIndex = 228
    Me.Label11.Text = "Primary CustID"
    '
    'LblSSNo
    '
    Me.LblSSNo.AutoSize = True
    Me.LblSSNo.Location = New System.Drawing.Point(657, 413)
    Me.LblSSNo.Name = "LblSSNo"
    Me.LblSSNo.Size = New System.Drawing.Size(47, 13)
    Me.LblSSNo.TabIndex = 229
    Me.LblSSNo.Text = "<SSNo>"
    '
    'LblSS2
    '
    Me.LblSS2.AutoSize = True
    Me.LblSS2.Location = New System.Drawing.Point(658, 426)
    Me.LblSS2.Name = "LblSS2"
    Me.LblSS2.Size = New System.Drawing.Size(39, 13)
    Me.LblSS2.TabIndex = 231
    Me.LblSS2.Text = "<SS2>"
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(564, 426)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(93, 13)
    Me.Label23.TabIndex = 230
    Me.Label23.Text = "Secondary CustID"
    '
    'LblOid
    '
    Me.LblOid.AutoSize = True
    Me.LblOid.Location = New System.Drawing.Point(658, 439)
    Me.LblOid.Name = "LblOid"
    Me.LblOid.Size = New System.Drawing.Size(35, 13)
    Me.LblOid.TabIndex = 233
    Me.LblOid.Text = "<Oid>"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Location = New System.Drawing.Point(564, 439)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(56, 13)
    Me.Label25.TabIndex = 232
    Me.Label25.Text = "Vehicle ID"
    '
    'BtnDMV
    '
    Me.BtnDMV.Location = New System.Drawing.Point(643, 466)
    Me.BtnDMV.Name = "BtnDMV"
    Me.BtnDMV.Size = New System.Drawing.Size(75, 24)
    Me.BtnDMV.TabIndex = 226
    Me.BtnDMV.Text = "DMV Data"
    '
    'LblBeforeCC
    '
    Me.LblBeforeCC.AutoSize = True
    Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblBeforeCC.Location = New System.Drawing.Point(451, 10)
    Me.LblBeforeCC.Name = "LblBeforeCC"
    Me.LblBeforeCC.Size = New System.Drawing.Size(119, 15)
    Me.LblBeforeCC.TabIndex = 234
    Me.LblBeforeCC.Text = "Before C/C #####"
    Me.LblBeforeCC.TextAlign = System.Drawing.ContentAlignment.TopRight
    Me.LblBeforeCC.Visible = False
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.Aqua
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(184, 16)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(31, 16)
    Me.LblYear.TabIndex = 235
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'C1DataGrdList
    '
    Me.C1DataGrdList.AllowColSelect = False
    Me.C1DataGrdList.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
    Me.C1DataGrdList.AlternatingRows = True
    Me.C1DataGrdList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.C1DataGrdList.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
    Me.C1DataGrdList.Images.Add(CType(resources.GetObject("C1DataGrdList.Images"), System.Drawing.Image))
    Me.C1DataGrdList.Location = New System.Drawing.Point(7, 386)
    Me.C1DataGrdList.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.NoMarquee
    Me.C1DataGrdList.Name = "C1DataGrdList"
    Me.C1DataGrdList.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    Me.C1DataGrdList.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    Me.C1DataGrdList.PreviewInfo.ZoomFactor = 75.0R
    Me.C1DataGrdList.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
    Me.C1DataGrdList.PrintInfo.MeasurementPrinterName = Nothing
    Me.C1DataGrdList.Size = New System.Drawing.Size(535, 105)
    Me.C1DataGrdList.TabIndex = 236
    Me.C1DataGrdList.PropBag = resources.GetString("C1DataGrdList.PropBag")
    '
    'LblMSRPCalc
    '
    Me.LblMSRPCalc.AutoSize = True
    Me.LblMSRPCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRPCalc.Location = New System.Drawing.Point(490, 190)
    Me.LblMSRPCalc.Name = "LblMSRPCalc"
    Me.LblMSRPCalc.Size = New System.Drawing.Size(74, 13)
    Me.LblMSRPCalc.TabIndex = 294
    Me.LblMSRPCalc.Text = "<MSRP Calc>"
    '
    'LblMSRP
    '
    Me.LblMSRP.BackColor = System.Drawing.Color.Aqua
    Me.LblMSRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRP.Location = New System.Drawing.Point(491, 226)
    Me.LblMSRP.Name = "LblMSRP"
    Me.LblMSRP.Size = New System.Drawing.Size(64, 16)
    Me.LblMSRP.TabIndex = 293
    Me.LblMSRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(490, 212)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(65, 13)
    Me.Label27.TabIndex = 292
    Me.Label27.Text = "DMV MSRP"
    '
    'LblValue
    '
    Me.LblValue.BackColor = System.Drawing.Color.Aqua
    Me.LblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValue.Location = New System.Drawing.Point(564, 225)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(64, 16)
    Me.LblValue.TabIndex = 291
    Me.LblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtSource
    '
    Me.TxtSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSource.Location = New System.Drawing.Point(584, 271)
    Me.TxtSource.MaxLength = 2
    Me.TxtSource.Name = "TxtSource"
    Me.TxtSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtSource.TabIndex = 289
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(494, 256)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(67, 13)
    Me.Label24.TabIndex = 288
    Me.Label24.Text = "100% MSRP"
    '
    'TxtOVMSRP
    '
    Me.TxtOVMSRP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOVMSRP.Location = New System.Drawing.Point(488, 272)
    Me.TxtOVMSRP.MaxLength = 9
    Me.TxtOVMSRP.Name = "TxtOVMSRP"
    Me.TxtOVMSRP.Size = New System.Drawing.Size(82, 22)
    Me.TxtOVMSRP.TabIndex = 287
    Me.TxtOVMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(576, 212)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(34, 13)
    Me.Label16.TabIndex = 286
    Me.Label16.Text = "Value"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbCatNonTax)
    Me.GroupBox1.Controls.Add(Me.RbCatTransfer)
    Me.GroupBox1.Controls.Add(Me.RbCatExempt)
    Me.GroupBox1.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(490, 38)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(84, 94)
    Me.GroupBox1.TabIndex = 295
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Category"
    '
    'RbCatNonTax
    '
    Me.RbCatNonTax.AutoSize = True
    Me.RbCatNonTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatNonTax.ForeColor = System.Drawing.Color.Black
    Me.RbCatNonTax.Location = New System.Drawing.Point(8, 34)
    Me.RbCatNonTax.Name = "RbCatNonTax"
    Me.RbCatNonTax.Size = New System.Drawing.Size(66, 17)
    Me.RbCatNonTax.TabIndex = 3
    Me.RbCatNonTax.Text = "Non Tax"
    '
    'RbCatTransfer
    '
    Me.RbCatTransfer.AutoSize = True
    Me.RbCatTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTransfer.ForeColor = System.Drawing.Color.Black
    Me.RbCatTransfer.Location = New System.Drawing.Point(8, 70)
    Me.RbCatTransfer.Name = "RbCatTransfer"
    Me.RbCatTransfer.Size = New System.Drawing.Size(64, 17)
    Me.RbCatTransfer.TabIndex = 2
    Me.RbCatTransfer.Text = "Transfer"
    '
    'RbCatExempt
    '
    Me.RbCatExempt.AutoSize = True
    Me.RbCatExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatExempt.ForeColor = System.Drawing.Color.Black
    Me.RbCatExempt.Location = New System.Drawing.Point(8, 52)
    Me.RbCatExempt.Name = "RbCatExempt"
    Me.RbCatExempt.Size = New System.Drawing.Size(60, 17)
    Me.RbCatExempt.TabIndex = 1
    Me.RbCatExempt.Text = "Exempt"
    '
    'RbCatTaxable
    '
    Me.RbCatTaxable.AutoSize = True
    Me.RbCatTaxable.Checked = True
    Me.RbCatTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatTaxable.ForeColor = System.Drawing.Color.Black
    Me.RbCatTaxable.Location = New System.Drawing.Point(8, 16)
    Me.RbCatTaxable.Name = "RbCatTaxable"
    Me.RbCatTaxable.Size = New System.Drawing.Size(63, 17)
    Me.RbCatTaxable.TabIndex = 0
    Me.RbCatTaxable.TabStop = True
    Me.RbCatTaxable.Text = "Taxable"
    '
    'LnkSource
    '
    Me.LnkSource.AutoSize = True
    Me.LnkSource.Location = New System.Drawing.Point(571, 255)
    Me.LnkSource.Name = "LnkSource"
    Me.LnkSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkSource.TabIndex = 290
    Me.LnkSource.TabStop = True
    Me.LnkSource.Text = "Source"
    '
    'FrmTAD05MV
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(728, 499)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.LblMSRPCalc)
    Me.Controls.Add(Me.LblMSRP)
    Me.Controls.Add(Me.Label27)
    Me.Controls.Add(Me.LblValue)
    Me.Controls.Add(Me.TxtSource)
    Me.Controls.Add(Me.LnkSource)
    Me.Controls.Add(Me.Label24)
    Me.Controls.Add(Me.TxtOVMSRP)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.C1DataGrdList)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblBeforeCC)
    Me.Controls.Add(Me.LblOid)
    Me.Controls.Add(Me.Label25)
    Me.Controls.Add(Me.LblSS2)
    Me.Controls.Add(Me.Label23)
    Me.Controls.Add(Me.LblSSNo)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.DtPckDOB)
    Me.Controls.Add(Me.LblTaxExempt)
    Me.Controls.Add(Me.BtnDMV)
    Me.Controls.Add(Me.ChkDnbtr)
    Me.Controls.Add(Me.DtPckBtr)
    Me.Controls.Add(Me.LblDtPckBtr)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnPrevious)
    Me.Controls.Add(Me.LnkClass)
    Me.Controls.Add(Me.LblPlateExp)
    Me.Controls.Add(Me.Label22)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.TxtLightWgt)
    Me.Controls.Add(Me.TxtGrossWgt)
    Me.Controls.Add(Me.TxtRegno)
    Me.Controls.Add(Me.TxtVIN)
    Me.Controls.Add(Me.TxtClass)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.TxtBody)
    Me.Controls.Add(Me.TxtModel)
    Me.Controls.Add(Me.TxtPdst)
    Me.Controls.Add(Me.TxtMake)
    Me.Controls.Add(Me.TxtResZip4)
    Me.Controls.Add(Me.TxtResZip5)
    Me.Controls.Add(Me.TxtResAdd1)
    Me.Controls.Add(Me.TxtResState)
    Me.Controls.Add(Me.TxtResCity)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.TxtBaa)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.LblBaa1)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label40)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label42)
    Me.Controls.Add(Me.GroupBox3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAD05MV"
    Me.Text = "Motor Vehicle Archive"
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.C1DataGrdList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAD05MV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXMVA = New TXMVA.MyData(myDBConnect)
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMVAL8 = New TXMVAL8.MyData(myDBConnect)
    myTXMVAL9 = New TXMVAL9.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)

    If MyBookPct = 0 Then
      myTXMCTL.GetOneRecordP(1)
      If Not myTXMCTL.RecordNotFound Then
        With myTXMCTL
          MyBookPct = ._VALPER
          MyMinValue = ._VALMIN
        End With
      End If
    End If

    BuildDS()
    LoadForm()
  End Sub

  Private Sub FrmTAD05MV_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAD05B.FormatGrid(True, False, False)
    MyFrmTAD05B.Show()
    'Memory Cleanup
    myTXMVA = Nothing
    MyFrmTAD05MV = Nothing

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
    Dim dsTAXCOM As DataSet = New DataSet
    Dim WrkCat As String

    LoadScrn = True
    ds.Clear()
    If WrkFastPath Then
      BtnPrevious.Visible = False
      BtnNext.Visible = False
    End If

    TxtListNo.ReadOnly = True
    TxtListNo.TabStop = False
    TxtListNo.Text = WrkListNo
    LblYear.Text = WrkYear
    myTXMVA.GetOneRecordP(WrkListNo, WrkYear)
    If myTXMVA.RecordNotFound Then
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If

    With myTXMVA
      LblBeforeCC.Visible = False
      If ._CCNO > 0 Then
        LblBeforeCC.Visible = True
        LblBeforeCC.Text = "Before C/C " & ._CCNO
      End If
      TxtName.Text = Trim(._NAME)
      TxtSname.Text = Trim(._SNAME)
      TxtAdd1.Text = Trim(._ADD1)
      TxtAdd2.Text = Trim(._ADD2)
      TxtCity.Text = Trim(._CITY)
      TxtState.Text = Trim(._STATE)
      TxtZip5.Text = Format(._ZIP5, "00000")
      TxtZip4.Text = Format(._ZIP4, "0000")
      TxtPdst.Text = ._PDST
      TxtDist.Text = ._DIST
      If ._DTBTR > 0 Then
        DtPckBtr.Value = MyUtils.GetDBDate(._DTBTR)
        DtPckBtr.Checked = True
      Else
        DtPckBtr.Value = Date.Today
        DtPckBtr.Checked = False
      End If
      ChkDnbtr.Checked = False
      If ._DNBTR = "Y" Then
        ChkDnbtr.Checked = True
      End If
      WrkCat = Trim(._CAT)
      Select Case WrkCat
        Case "1"
          RbCatTaxable.Checked = True
          LblTaxExempt.Visible = False
        Case "3"
          RbCatExempt.Checked = True
          LblTaxExempt.Visible = True
        Case "T"
          RbCatTransfer.Checked = True
          LblTaxExempt.Visible = False
      End Select
      TxtResAdd1.Text = Trim(._RAD1)
      TxtResCity.Text = Trim(._RCTY)
      TxtResState.Text = Trim(._RST)
      TxtResZip5.Text = Format(._RZ5, "00000")
      TxtResZip4.Text = Format(._RZ4, "0000")
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtBody.Text = Trim(._BODY)
      TxtYear.Text = ._YEAR
      TxtClass.Text = ._CLASS
      TxtVIN.Text = Trim(._VINNO)
      TxtRegno.Text = Trim(._REGNO)
      LblValue.Text = ._VALUE
      LblMSRP.Text = ._MSRP
      TxtOVMSRP.Text = ""
      myTXMSRP.GetOneRecordP(Trim(._VINNO))
      With myTXMSRP
        If Not .RecordNotFound Then
          If Trim(._OVSOURCE) <> "" Then
            TxtOVMSRP.Text = ._OVMSRP
            TxtSource.Text = Trim(._OVSOURCE)
          End If
          If ._NONTAX = "Y" Then
            RbCatNonTax.Checked = True
          End If
        End If
      End With
      CalcValue(._MSRP, MyUtils.CnvSng(TxtOVMSRP.Text), ._YEAR) 'populate LblMSRPCalc
      If ._DOB > 0 Then
        DtPckDOB.Value = MyUtils.GetDBDate(._DOB)
        DtPckDOB.Checked = True
      Else
        DtPckDOB.Value = Date.Today
        DtPckDOB.Checked = False
      End If
      TxtGrossWgt.Text = ._GWT
      TxtLightWgt.Text = ._LWT
      If ._XDATE > 0 Then
        LblPlateExp.Text = MyUtils.GetDBDate(._XDATE)
      Else
        LblPlateExp.Text = ""
      End If
      TxtExam1.Text = ._EXAM1
      TxtExam2.Text = ._EXAM2
      TxtExam3.Text = ._EXAM3
      TxtExam4.Text = ._EXAM4
      TxtExam5.Text = ._EXAM5
      LblGross.Text = ._VALUE
      LblExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      LblNet.Text = MyUtils.CnvSng(LblGross.Text) - MyUtils.CnvSng(LblExempt.Text)
      If ._BTR <> 0 Then
        TxtBaa.Text = MyUtils.CnvSng(LblValue.Text) + ._BTR
      Else
        TxtBaa.Text = "0"
      End If
      LblSSNo.Text = ._SSNo
      LblSS2.Text = ._SS2
      LblOid.Text = ._OID
      CalcBTR()
    End With

    With myTXMVA
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
      dstemp = myTXMVAL8.GetViewSSNo(WrkYear, WrkCustid, 999, False)
    Else
      dstemp = myTXMVAL9.GetViewSS2(WrkYear, WrkCustid, 999, False)
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
  Private Sub FrmTAD05MV_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD05.SbpScreen.Text = "TAD05MV"
    If DtPckDOB.Value <> Date.Today Then
      DtPckDOB.Checked = True
    Else
      DtPckDOB.Checked = False
    End If
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub CalcAssmt()
    Dim TotGross As Long
    Dim TotExempt As Long

    TotGross = MyUtils.CnvSng(LblValue.Text)
    TotExempt = MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) + MyUtils.CnvSng(TxtExam4.Text) + MyUtils.CnvSng(TxtExam5.Text)
    LblGross.Text = TotGross
    LblExempt.Text = TotExempt
    LblNet.Text = TotGross - TotExempt
    LblBaaNet.Text = TotGross - TotExempt + MyUtils.CnvSng(LblBaa.Text)
  End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt1.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkFieldNo = LnkExempt1.Text
    MyFrmListExemption.WrkCode = TxtExempt1.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt2.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt2.Text
    MyFrmListExemption.WrkCode = TxtExempt2.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt3.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt3.Text
    MyFrmListExemption.WrkCode = TxtExempt3.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt4.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt4.Text
    MyFrmListExemption.WrkCode = TxtExempt4.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub LnkExempt5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt5.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
    MyFrmListExemption.WrkFieldNo = LnkExempt5.Text
    MyFrmListExemption.WrkCode = TxtExempt5.Text
    MyFrmListExemption.Show()
  End Sub
  Private Sub TxtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    CalcAssmt()
  End Sub
  Private Sub TxtExempt1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt1.Leave
    SetExem1Tip()
  End Sub
  Private Sub TxtExempt2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt2.Leave
    SetExem2Tip()
  End Sub
  Private Sub TxtExempt3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt3.Leave
    SetExem3Tip()
  End Sub
  Private Sub TxtExempt4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt4.Leave
    SetExem4Tip()
  End Sub
  Private Sub TxtExempt5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtExempt5.Leave
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
  Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGrossWgt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGrossWgt.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtLightWgt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLightWgt.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtExam5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExam5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtResZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtResZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtResZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtResZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBaa.TextChanged
    CalcBTR()
  End Sub
  Private Sub TxtBaa_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub CalcBTR()
    Dim TotBTR As Long

    TotBTR = MyUtils.CnvSng(TxtBaa.Text)
    If TotBTR <> 0 Or (DtPckBtr.Checked And Not ChkDnbtr.Checked) Then
      LblBaaNet.Visible = True
      LblBaa.Visible = True
      LblBaaNet.Text = TotBTR - MyUtils.CnvSng(LblExempt.Text)
      LblBaa.Text = TotBTR - MyUtils.CnvSng(LblGross.Text)
    Else
      LblBaaNet.Visible = False
      LblBaa.Visible = False
      LblBaaNet.Text = 0
      LblBaa.Text = MyUtils.CnvSng(LblGross.Text)
    End If
  End Sub
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer) As Integer
    Dim WrkChkYear As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkChkYear = MyUtils.CnvSng(LblYear.Text)
    WrkDeYear = WrkChkYear - WrkYear + 1
    If WrkDeYear < 1 Then
      WrkDeYear = 1
    End If
    WrkDepr = GetTXMSRPDEP(WrkDeYear)
    If WrkOvMSRP > 0 Then
      WrkValue = WrkOvMSRP * WrkDepr * MyBookPct
      LblMSRPCalc.Text = WrkOvMSRP & " x " & WrkDepr & "% (" & WrkDeYear & ") x " & MyBookPct & "%"
    Else
      WrkValue = WrkMSRP * WrkDepr * MyBookPct
      LblMSRPCalc.Text = WrkMSRP & " x " & WrkDepr & "% (" & WrkDeYear & ") x " & MyBookPct & "%"
    End If
    WrkValue = MyUtils.Round10(WrkValue, "Normal")
    If WrkValue < MyMinValue Then
      WrkValue = MyMinValue
    End If
    Return WrkValue
  End Function
  Public Function GetTXMSRPDEP(ByVal DeprYear As Integer) As Decimal
    Dim WrkDepr As Decimal
    If DeprYear < 0 Then DeprYear = 1
    WrkDepr = myTXMSRPDEP.GetDepr(DeprYear)
    Return WrkDepr
  End Function
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = 1
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
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
    MyFrmTAD05DMV.WrkType = "M"
    MyFrmTAD05DMV.Show()
    Me.Hide()
  End Sub
  Private Sub DtPckBtr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckBtr.ValueChanged
    CalcBTR()
  End Sub
  Private Sub ChkDnbtr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDnbtr.Click
    CalcBTR()
  End Sub
  Private Sub RbCatExempt_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    LblTaxExempt.Visible = True
  End Sub
  Private Sub RbCatTaxable_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    LblTaxExempt.Visible = False
  End Sub
  Private Sub RbCatTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    LblTaxExempt.Visible = False
  End Sub
End Class






