Public Class FrmTA001MV
  Inherits System.Windows.Forms.Form
  Friend WrkListNo As Integer
  Friend WrkFastPath As Boolean
  Dim myTXMVD As TXMVD.MyData
  Dim myTXMVDCL1 As TXMVDCL1.MyData
  Dim myTXMVA As TXMVA.MyData
  Dim myTXMCTL As TXMCTL.MyData
  Dim myTXMSRP As TXMSRP.MyData
  Dim myTXMSRPDEP As TXMSRPDEP.MyData
  Dim myTXBTR As TXBTR.MyData
  Dim myTAXCOM As TAXCOM.MyData
  Dim myLOGMV As LOGMV.MyData
  Dim WrkChkYear As Integer
  Dim LoadScrn As Boolean
  Dim AddMode As Boolean

  Dim logmv_ds As DataSet = New DataSet
  Friend WithEvents LblSoftFreeze As System.Windows.Forms.Label
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
  Friend WithEvents LblComments As System.Windows.Forms.Label
  Friend WithEvents BtnDMV As System.Windows.Forms.Button
  Friend WithEvents LblTaxExempt As System.Windows.Forms.Label
  Friend WithEvents DtPckDOB As System.Windows.Forms.DateTimePicker
  Friend WithEvents LblSSNo As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents LblOid As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents LblSS2 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtSource As TextBox
  Friend WithEvents LnkSource As LinkLabel
  Friend WithEvents Label24 As Label
  Friend WithEvents TxtOVMSRP As TextBox
  Friend WithEvents LblValue As Label
  Friend WithEvents LblMSRP As Label
  Friend WithEvents Label27 As Label
  Friend WithEvents RbCatNonTax As RadioButton
  Friend WithEvents ChkComplete As CheckBox
    Friend WithEvents LblMSRPCalc As Label
  Friend WithEvents TxtResAdd2 As TextBox
  Const WrkType As String = "M"
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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTransfer As System.Windows.Forms.RadioButton
  Friend WithEvents TxtPdst As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
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
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbCatNonTax = New System.Windows.Forms.RadioButton()
    Me.RbCatTransfer = New System.Windows.Forms.RadioButton()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.TxtPdst = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
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
    Me.LblSoftFreeze = New System.Windows.Forms.Label()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnPrevious = New System.Windows.Forms.Button()
    Me.ChkDnbtr = New System.Windows.Forms.CheckBox()
    Me.DtPckBtr = New System.Windows.Forms.DateTimePicker()
    Me.LblDtPckBtr = New System.Windows.Forms.Label()
    Me.LblComments = New System.Windows.Forms.Label()
    Me.BtnDMV = New System.Windows.Forms.Button()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.DtPckDOB = New System.Windows.Forms.DateTimePicker()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.LblSSNo = New System.Windows.Forms.Label()
    Me.LblSS2 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblOid = New System.Windows.Forms.Label()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.LblBeforeCC = New System.Windows.Forms.Label()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtOVMSRP = New System.Windows.Forms.TextBox()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.TxtSource = New System.Windows.Forms.TextBox()
    Me.LnkSource = New System.Windows.Forms.LinkLabel()
    Me.LblValue = New System.Windows.Forms.Label()
    Me.LblMSRP = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.ChkComplete = New System.Windows.Forms.CheckBox()
    Me.LblMSRPCalc = New System.Windows.Forms.Label()
    Me.TxtResAdd2 = New System.Windows.Forms.TextBox()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(4, 251)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(73, 16)
    Me.Label9.TabIndex = 69
    Me.Label9.Text = "Date of Birth"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(4, 206)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 68
    Me.Label7.Text = "Dom City/St/Zip"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(394, 132)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(340, 132)
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
    Me.GroupBox2.Location = New System.Drawing.Point(574, 41)
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
    Me.Label6.Location = New System.Drawing.Point(4, 160)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 67
    Me.Label6.Text = "Domicile Addr"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(4, 136)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 66
    Me.Label4.Text = "City/State/Zip"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(4, 88)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 65
    Me.Label3.Text = "Street Address"
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(92, 108)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(92, 84)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(92, 60)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(4, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 64
    Me.Label2.Text = "Second Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(92, 12)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(61, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(92, 36)
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
    Me.Label5.Location = New System.Drawing.Point(4, 40)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 61
    Me.Label5.Text = "Name"
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(308, 132)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(92, 132)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(251, 247)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 17
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(197, 251)
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
    Me.GroupBox3.Location = New System.Drawing.Point(4, 372)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(460, 80)
    Me.GroupBox3.TabIndex = 29
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Exemptions"
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(416, 16)
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
    Me.TxtExempt5.Location = New System.Drawing.Point(408, 32)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt5.TabIndex = 35
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(248, 16)
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
    Me.TxtExempt3.Location = New System.Drawing.Point(240, 32)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt3.TabIndex = 31
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(336, 16)
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
    Me.TxtExempt4.Location = New System.Drawing.Point(320, 32)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt4.TabIndex = 33
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(168, 16)
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
    Me.TxtExempt2.Location = New System.Drawing.Point(160, 32)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt2.TabIndex = 29
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(96, 16)
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
    Me.TxtExempt1.Location = New System.Drawing.Point(88, 32)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt1.TabIndex = 27
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(304, 56)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam4.TabIndex = 34
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(144, 56)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam2.TabIndex = 30
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(384, 56)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam5.TabIndex = 36
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(224, 56)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(63, 22)
    Me.TxtExam3.TabIndex = 32
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(63, 56)
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
    'TxtResZip4
    '
    Me.TxtResZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResZip4.Location = New System.Drawing.Point(394, 201)
    Me.TxtResZip4.MaxLength = 4
    Me.TxtResZip4.Name = "TxtResZip4"
    Me.TxtResZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtResZip4.TabIndex = 13
    '
    'TxtResZip5
    '
    Me.TxtResZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResZip5.Location = New System.Drawing.Point(343, 202)
    Me.TxtResZip5.MaxLength = 5
    Me.TxtResZip5.Name = "TxtResZip5"
    Me.TxtResZip5.Size = New System.Drawing.Size(45, 22)
    Me.TxtResZip5.TabIndex = 12
    '
    'TxtResAdd1
    '
    Me.TxtResAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResAdd1.Location = New System.Drawing.Point(92, 156)
    Me.TxtResAdd1.MaxLength = 35
    Me.TxtResAdd1.Name = "TxtResAdd1"
    Me.TxtResAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtResAdd1.TabIndex = 9
    '
    'TxtResState
    '
    Me.TxtResState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResState.Location = New System.Drawing.Point(308, 201)
    Me.TxtResState.MaxLength = 2
    Me.TxtResState.Name = "TxtResState"
    Me.TxtResState.Size = New System.Drawing.Size(24, 22)
    Me.TxtResState.TabIndex = 11
    '
    'TxtResCity
    '
    Me.TxtResCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResCity.Location = New System.Drawing.Point(92, 202)
    Me.TxtResCity.MaxLength = 25
    Me.TxtResCity.Name = "TxtResCity"
    Me.TxtResCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtResCity.TabIndex = 10
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(7, 299)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(44, 16)
    Me.Label10.TabIndex = 88
    Me.Label10.Text = "Make"
    '
    'TxtMake
    '
    Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMake.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMake.Location = New System.Drawing.Point(7, 315)
    Me.TxtMake.MaxLength = 5
    Me.TxtMake.Name = "TxtMake"
    Me.TxtMake.Size = New System.Drawing.Size(48, 22)
    Me.TxtMake.TabIndex = 21
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbCatNonTax)
    Me.GroupBox1.Controls.Add(Me.RbCatTransfer)
    Me.GroupBox1.Controls.Add(Me.RbCatExempt)
    Me.GroupBox1.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(488, 41)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(84, 94)
    Me.GroupBox1.TabIndex = 100
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
    'TxtPdst
    '
    Me.TxtPdst.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPdst.Location = New System.Drawing.Point(383, 247)
    Me.TxtPdst.MaxLength = 3
    Me.TxtPdst.Name = "TxtPdst"
    Me.TxtPdst.Size = New System.Drawing.Size(32, 22)
    Me.TxtPdst.TabIndex = 18
    Me.TxtPdst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label40
    '
    Me.Label40.Location = New System.Drawing.Point(311, 251)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(72, 16)
    Me.Label40.TabIndex = 103
    Me.Label40.Text = "Other District"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(578, 256)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(34, 13)
    Me.Label12.TabIndex = 106
    Me.Label12.Text = "Value"
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(59, 299)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(44, 16)
    Me.Label13.TabIndex = 108
    Me.Label13.Text = "Model"
    '
    'TxtModel
    '
    Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtModel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtModel.Location = New System.Drawing.Point(59, 315)
    Me.TxtModel.MaxLength = 8
    Me.TxtModel.Name = "TxtModel"
    Me.TxtModel.Size = New System.Drawing.Size(72, 22)
    Me.TxtModel.TabIndex = 22
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(131, 299)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(36, 16)
    Me.Label14.TabIndex = 110
    Me.Label14.Text = "Body"
    '
    'TxtBody
    '
    Me.TxtBody.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBody.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBody.Location = New System.Drawing.Point(134, 315)
    Me.TxtBody.MaxLength = 6
    Me.TxtBody.Name = "TxtBody"
    Me.TxtBody.Size = New System.Drawing.Size(56, 22)
    Me.TxtBody.TabIndex = 23
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(187, 299)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(36, 16)
    Me.Label15.TabIndex = 112
    Me.Label15.Text = "Year"
    '
    'TxtYear
    '
    Me.TxtYear.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtYear.Location = New System.Drawing.Point(187, 315)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(40, 22)
    Me.TxtYear.TabIndex = 24
    '
    'TxtClass
    '
    Me.TxtClass.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtClass.Location = New System.Drawing.Point(227, 315)
    Me.TxtClass.MaxLength = 2
    Me.TxtClass.Name = "TxtClass"
    Me.TxtClass.Size = New System.Drawing.Size(28, 22)
    Me.TxtClass.TabIndex = 25
    Me.TxtClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.Location = New System.Drawing.Point(259, 299)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(44, 16)
    Me.Label17.TabIndex = 116
    Me.Label17.Text = "VIN #"
    '
    'TxtVIN
    '
    Me.TxtVIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtVIN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtVIN.Location = New System.Drawing.Point(259, 315)
    Me.TxtVIN.MaxLength = 17
    Me.TxtVIN.Name = "TxtVIN"
    Me.TxtVIN.Size = New System.Drawing.Size(145, 22)
    Me.TxtVIN.TabIndex = 26
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(407, 299)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(44, 16)
    Me.Label18.TabIndex = 118
    Me.Label18.Text = "Reg #"
    '
    'TxtRegno
    '
    Me.TxtRegno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRegno.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtRegno.Location = New System.Drawing.Point(407, 315)
    Me.TxtRegno.MaxLength = 8
    Me.TxtRegno.Name = "TxtRegno"
    Me.TxtRegno.Size = New System.Drawing.Size(72, 22)
    Me.TxtRegno.TabIndex = 27
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtBaa
    '
    Me.TxtBaa.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa.Location = New System.Drawing.Point(266, 272)
    Me.TxtBaa.MaxLength = 9
    Me.TxtBaa.Name = "TxtBaa"
    Me.TxtBaa.Size = New System.Drawing.Size(72, 22)
    Me.TxtBaa.TabIndex = 20
    Me.TxtBaa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBaa1
    '
    Me.LblBaa1.AutoSize = True
    Me.LblBaa1.Location = New System.Drawing.Point(189, 275)
    Me.LblBaa1.Name = "LblBaa1"
    Me.LblBaa1.Size = New System.Drawing.Size(73, 13)
    Me.LblBaa1.TabIndex = 180
    Me.LblBaa1.Text = "B.A.A Amount"
    '
    'TxtGrossWgt
    '
    Me.TxtGrossWgt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtGrossWgt.Location = New System.Drawing.Point(86, 344)
    Me.TxtGrossWgt.MaxLength = 6
    Me.TxtGrossWgt.Name = "TxtGrossWgt"
    Me.TxtGrossWgt.Size = New System.Drawing.Size(56, 22)
    Me.TxtGrossWgt.TabIndex = 30
    Me.TxtGrossWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.Location = New System.Drawing.Point(16, 348)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(64, 16)
    Me.Label20.TabIndex = 182
    Me.Label20.Text = "Gross Wgt"
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(184, 348)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(57, 16)
    Me.Label21.TabIndex = 184
    Me.Label21.Text = "Light Wgt"
    '
    'TxtLightWgt
    '
    Me.TxtLightWgt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLightWgt.Location = New System.Drawing.Point(244, 344)
    Me.TxtLightWgt.MaxLength = 6
    Me.TxtLightWgt.Name = "TxtLightWgt"
    Me.TxtLightWgt.Size = New System.Drawing.Size(56, 22)
    Me.TxtLightWgt.TabIndex = 31
    Me.TxtLightWgt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label22
    '
    Me.Label22.Location = New System.Drawing.Point(352, 348)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(88, 16)
    Me.Label22.TabIndex = 32
    Me.Label22.Text = "Plate Expiration"
    '
    'LblPlateExp
    '
    Me.LblPlateExp.Location = New System.Drawing.Point(432, 348)
    Me.LblPlateExp.Name = "LblPlateExp"
    Me.LblPlateExp.Size = New System.Drawing.Size(64, 16)
    Me.LblPlateExp.TabIndex = 29
    '
    'LblSoftFreeze
    '
    Me.LblSoftFreeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSoftFreeze.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblSoftFreeze.Location = New System.Drawing.Point(161, 16)
    Me.LblSoftFreeze.Name = "LblSoftFreeze"
    Me.LblSoftFreeze.Size = New System.Drawing.Size(296, 16)
    Me.LblSoftFreeze.TabIndex = 187
    Me.LblSoftFreeze.Text = "* Soft Freeze - Only BAA data will be saved *"
    Me.LblSoftFreeze.Visible = False
    '
    'LnkClass
    '
    Me.LnkClass.Location = New System.Drawing.Point(224, 299)
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
    Me.ChkDnbtr.AutoSize = True
    Me.ChkDnbtr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDnbtr.Location = New System.Drawing.Point(349, 277)
    Me.ChkDnbtr.Name = "ChkDnbtr"
    Me.ChkDnbtr.Size = New System.Drawing.Size(66, 17)
    Me.ChkDnbtr.TabIndex = 21
    Me.ChkDnbtr.Text = "Denied?"
    '
    'DtPckBtr
    '
    Me.DtPckBtr.Checked = False
    Me.DtPckBtr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckBtr.Location = New System.Drawing.Point(87, 272)
    Me.DtPckBtr.Name = "DtPckBtr"
    Me.DtPckBtr.ShowCheckBox = True
    Me.DtPckBtr.Size = New System.Drawing.Size(96, 20)
    Me.DtPckBtr.TabIndex = 19
    '
    'LblDtPckBtr
    '
    Me.LblDtPckBtr.Location = New System.Drawing.Point(7, 272)
    Me.LblDtPckBtr.Name = "LblDtPckBtr"
    Me.LblDtPckBtr.Size = New System.Drawing.Size(73, 16)
    Me.LblDtPckBtr.TabIndex = 193
    Me.LblDtPckBtr.Text = "BTR Applied"
    '
    'LblComments
    '
    Me.LblComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblComments.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblComments.Location = New System.Drawing.Point(485, 9)
    Me.LblComments.Name = "LblComments"
    Me.LblComments.Size = New System.Drawing.Size(105, 18)
    Me.LblComments.TabIndex = 194
    Me.LblComments.Text = "* Comments *"
    Me.LblComments.Visible = False
    '
    'BtnDMV
    '
    Me.BtnDMV.Location = New System.Drawing.Point(641, 418)
    Me.BtnDMV.Name = "BtnDMV"
    Me.BtnDMV.Size = New System.Drawing.Size(75, 24)
    Me.BtnDMV.TabIndex = 226
    Me.BtnDMV.Text = "DMV Data"
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(578, 176)
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
    Me.DtPckDOB.Location = New System.Drawing.Point(87, 249)
    Me.DtPckDOB.Name = "DtPckDOB"
    Me.DtPckDOB.ShowCheckBox = True
    Me.DtPckDOB.Size = New System.Drawing.Size(96, 20)
    Me.DtPckDOB.TabIndex = 16
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(562, 365)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(76, 13)
    Me.Label11.TabIndex = 228
    Me.Label11.Text = "Primary CustID"
    '
    'LblSSNo
    '
    Me.LblSSNo.AutoSize = True
    Me.LblSSNo.Location = New System.Drawing.Point(655, 365)
    Me.LblSSNo.Name = "LblSSNo"
    Me.LblSSNo.Size = New System.Drawing.Size(47, 13)
    Me.LblSSNo.TabIndex = 229
    Me.LblSSNo.Text = "<SSNo>"
    '
    'LblSS2
    '
    Me.LblSS2.AutoSize = True
    Me.LblSS2.Location = New System.Drawing.Point(656, 378)
    Me.LblSS2.Name = "LblSS2"
    Me.LblSS2.Size = New System.Drawing.Size(39, 13)
    Me.LblSS2.TabIndex = 231
    Me.LblSS2.Text = "<SS2>"
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(562, 378)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(93, 13)
    Me.Label23.TabIndex = 230
    Me.Label23.Text = "Secondary CustID"
    '
    'LblOid
    '
    Me.LblOid.AutoSize = True
    Me.LblOid.Location = New System.Drawing.Point(656, 391)
    Me.LblOid.Name = "LblOid"
    Me.LblOid.Size = New System.Drawing.Size(35, 13)
    Me.LblOid.TabIndex = 233
    Me.LblOid.Text = "<Oid>"
    '
    'Label25
    '
    Me.Label25.AutoSize = True
    Me.Label25.Location = New System.Drawing.Point(562, 391)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(56, 13)
    Me.Label25.TabIndex = 232
    Me.Label25.Text = "Vehicle ID"
    '
    'LblBeforeCC
    '
    Me.LblBeforeCC.AutoSize = True
    Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblBeforeCC.Location = New System.Drawing.Point(571, 158)
    Me.LblBeforeCC.Name = "LblBeforeCC"
    Me.LblBeforeCC.Size = New System.Drawing.Size(144, 15)
    Me.LblBeforeCC.TabIndex = 234
    Me.LblBeforeCC.Text = "Before Bill C/C #####"
    Me.LblBeforeCC.TextAlign = System.Drawing.ContentAlignment.TopRight
    Me.LblBeforeCC.Visible = False
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(157, 227)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(209, 22)
    Me.TxtLoc.TabIndex = 15
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(92, 227)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(62, 22)
    Me.TxtLocNo.TabIndex = 14
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(4, 231)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(88, 16)
    Me.Label16.TabIndex = 237
    Me.Label16.Text = "Location#/Name"
    '
    'TxtOVMSRP
    '
    Me.TxtOVMSRP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOVMSRP.Location = New System.Drawing.Point(483, 315)
    Me.TxtOVMSRP.MaxLength = 9
    Me.TxtOVMSRP.Name = "TxtOVMSRP"
    Me.TxtOVMSRP.Size = New System.Drawing.Size(82, 22)
    Me.TxtOVMSRP.TabIndex = 238
    Me.TxtOVMSRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label24
    '
    Me.Label24.AutoSize = True
    Me.Label24.Location = New System.Drawing.Point(488, 299)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(67, 13)
    Me.Label24.TabIndex = 239
    Me.Label24.Text = "100% MSRP"
    '
    'TxtSource
    '
    Me.TxtSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSource.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSource.Location = New System.Drawing.Point(585, 315)
    Me.TxtSource.MaxLength = 2
    Me.TxtSource.Name = "TxtSource"
    Me.TxtSource.Size = New System.Drawing.Size(19, 22)
    Me.TxtSource.TabIndex = 279
    '
    'LnkSource
    '
    Me.LnkSource.AutoSize = True
    Me.LnkSource.Location = New System.Drawing.Point(572, 299)
    Me.LnkSource.Name = "LnkSource"
    Me.LnkSource.Size = New System.Drawing.Size(41, 13)
    Me.LnkSource.TabIndex = 280
    Me.LnkSource.TabStop = True
    Me.LnkSource.Text = "Source"
    '
    'LblValue
    '
    Me.LblValue.BackColor = System.Drawing.Color.Aqua
    Me.LblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblValue.Location = New System.Drawing.Point(566, 269)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(64, 16)
    Me.LblValue.TabIndex = 281
    Me.LblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblMSRP
    '
    Me.LblMSRP.BackColor = System.Drawing.Color.Aqua
    Me.LblMSRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMSRP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRP.Location = New System.Drawing.Point(493, 270)
    Me.LblMSRP.Name = "LblMSRP"
    Me.LblMSRP.Size = New System.Drawing.Size(64, 16)
    Me.LblMSRP.TabIndex = 283
    Me.LblMSRP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(492, 256)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(65, 13)
    Me.Label27.TabIndex = 282
    Me.Label27.Text = "DMV MSRP"
    '
    'ChkComplete
    '
    Me.ChkComplete.AutoSize = True
    Me.ChkComplete.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkComplete.Location = New System.Drawing.Point(621, 320)
    Me.ChkComplete.Name = "ChkComplete"
    Me.ChkComplete.Size = New System.Drawing.Size(76, 17)
    Me.ChkComplete.TabIndex = 284
    Me.ChkComplete.Text = "Complete?"
    '
    'LblMSRPCalc
    '
    Me.LblMSRPCalc.AutoSize = True
    Me.LblMSRPCalc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMSRPCalc.Location = New System.Drawing.Point(492, 234)
    Me.LblMSRPCalc.Name = "LblMSRPCalc"
    Me.LblMSRPCalc.Size = New System.Drawing.Size(74, 13)
    Me.LblMSRPCalc.TabIndex = 285
    Me.LblMSRPCalc.Text = "<MSRP Calc>"
    '
    'TxtResAdd2
    '
    Me.TxtResAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtResAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtResAdd2.Location = New System.Drawing.Point(92, 176)
    Me.TxtResAdd2.MaxLength = 35
    Me.TxtResAdd2.Name = "TxtResAdd2"
    Me.TxtResAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtResAdd2.TabIndex = 10
    '
    'FrmTA001MV
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(728, 458)
    Me.Controls.Add(Me.TxtResAdd2)
    Me.Controls.Add(Me.LblMSRPCalc)
    Me.Controls.Add(Me.ChkComplete)
    Me.Controls.Add(Me.LblMSRP)
    Me.Controls.Add(Me.Label27)
    Me.Controls.Add(Me.LblValue)
    Me.Controls.Add(Me.TxtSource)
    Me.Controls.Add(Me.LnkSource)
    Me.Controls.Add(Me.Label24)
    Me.Controls.Add(Me.TxtOVMSRP)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label16)
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
    Me.Controls.Add(Me.LblComments)
    Me.Controls.Add(Me.ChkDnbtr)
    Me.Controls.Add(Me.DtPckBtr)
    Me.Controls.Add(Me.LblDtPckBtr)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnPrevious)
    Me.Controls.Add(Me.LnkClass)
    Me.Controls.Add(Me.LblSoftFreeze)
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
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.Label40)
    Me.Controls.Add(Me.GroupBox1)
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
    Me.Name = "FrmTA001MV"
    Me.Text = "Motor Vehicle "
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTA001MV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkFound As Boolean
    myTXMVD = New TXMVD.MyData(myDBConnect)
    myTXMVDCL1 = New TXMVDCL1.MyData(myDBConnect)
    myTXMVA = New TXMVA.MyData(myDBConnect)
    myTXMCTL = New TXMCTL.MyData(myDBConnect)
    myTXMSRP = New TXMSRP.MyData(myDBConnect)
    myTXMSRPDEP = New TXMSRPDEP.MyData(myDBConnect)
    myTXBTR = New TXBTR.MyData(myDBConnect)
    myTAXCOM = New TAXCOM.MyData(myDBConnect)
    myLOGMV = New LOGMV.MyData(myDBConnect)

    If WrkListNo = 0 Then
      Me.Text = "Add " & Me.Text
    Else
      Me.Text = "Maintain " & Me.Text
    End If

    If MyBookPct = 0 Then
      myTXMCTL.GetOneRecordP(1)
      If Not myTXMCTL.RecordNotFound Then
        With myTXMCTL
          MyBookPct = ._VALPER
          MyMinValue = ._VALMIN
        End With
      End If
    End If

    'Calculate Depreciation Year: Last Archive Year + 1, if no archive Today.Year - 1
    WrkChkYear = Today.Year
    Do
      WrkFound = myTXMVA.GetIsPosted(WrkChkYear)
      If Not WrkFound Then
        WrkChkYear -= 1 ' Go back one year
        If WrkChkYear < 1980 Then
          WrkChkYear = Today.Year - 1
          Exit Do
        End If
      End If
    Loop Until WrkFound
    LoadForm()
  End Sub

  Private Sub FrmTA001MV_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTA001.TBarNew.Enabled = True
    MyFrmTA001.TBarSave.Enabled = False
    MyFrmTA001.TBarDelete.Enabled = False
    MyFrmTA001.TBarLog.Enabled = False
    MyFrmTA001.TBarSave.Visible = True   '#sec
    MyFrmTA001.TBarComments.Enabled = False
    MyFrmTA001.TBarAttach.Enabled = False
    MyFrmTA001.TBarAttach.Text = "Attachments"
    MyFrmTA001B.FormatGrid(True, False, False)
    MyFrmTA001B.Show()
    'Memory Cleanup
    myTXMVD = Nothing
    myLOGMV = Nothing
    MyFrmTA001MV = Nothing

  End Sub
  Public Sub LoadForm()
    Dim dsTAXCOM As DataSet = New DataSet
    Dim WrkAttachCount As Integer
    Dim WrkCat As String
    MyFrmTA001.TBarNew.Enabled = False
    MyFrmTA001.TBarSave.Enabled = True
    MyFrmTA001.TBarComments.Enabled = True

    LoadScrn = True
    AddMode = False
    LblMSRPCalc.Text = ""
    'New record
    If WrkListNo = 0 Then
      AddMode = True
      MyFrmTA001.TBarDelete.Enabled = False
      MyFrmTA001.TBarComments.Enabled = False
      BtnPrevious.Visible = False
      BtnNext.Visible = False
      LblBaaNet.Visible = False
      LblBaa.Visible = False
      LoadScrn = False
      If MySoftFreezeMV Then
        MsgBox("Cannot create new record", MsgBoxStyle.Exclamation, "Soft Freeze")
        MyFrmTA001.TBarSave.Enabled = False
      End If
      Exit Sub
    End If

    If WrkFastPath Then
      BtnPrevious.Visible = False
      BtnNext.Visible = False
    End If

    If s_chg = False And s_full = False Then  '#sec
      MyFrmTA001.TBarSave.Visible = False  '#sec
    End If  '#sec

    'change log
    MyFrmTA001.TBarLog.Enabled = False
    logmv_ds = myLOGMV.GetAllList(WrkListNo)
    If logmv_ds.Tables(0).Rows.Count > 0 Then
      MyFrmTA001.TBarLog.Enabled = True
    End If

    'Fill the dataset with the data
    MyFrmTA001.TBarDelete.Enabled = True
    TxtListNo.ReadOnly = True
    TxtListNo.TabStop = False
    TxtListNo.Text = WrkListNo
    myTXMVD.GetOneRecordP(WrkListNo)

    If myTXMVD.RecordNotFound Then
      MyFrmTA001.TBarNew.Enabled = False
      MyFrmTA001.TBarSave.Enabled = False
      MyFrmTA001.TBarDelete.Enabled = False
      MyFrmTA001.TBarComments.Enabled = False
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If

    With myTXMVD
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
      TxtResAdd1.Text = Trim(._RAD1)
      TxtResAdd2.Text = Trim(._RAD2)  ' added 9/12/25 ken
      TxtResCity.Text = Trim(._RCTY)
      TxtResState.Text = Trim(._RST)
      TxtResZip5.Text = Format(._RZ5, "00000")
      TxtResZip4.Text = Format(._RZ4, "0000")
      TxtLocNo.Text = Trim(._LOCNO)
      TxtLoc.Text = Trim(._LOC)
      TxtMake.Text = Trim(._MAKE)
      TxtModel.Text = Trim(._MODEL)
      TxtBody.Text = Trim(._BODY)
      TxtYear.Text = ._YEAR
      TxtClass.Text = ._CLASS
      TxtVIN.Text = Trim(._VINNO)
      TxtRegno.Text = Trim(._REGNO)
      LblValue.Text = ._VALUE
      LblMSRP.Text = ._MSRP
      ChkComplete.Checked = False
      TxtOVMSRP.Text = ""
      myTXMSRP.GetOneRecordP(Trim(._VINNO))
      With myTXMSRP
        If Not .RecordNotFound Then
          If Trim(._OVSOURCE) <> "" Then
            TxtOVMSRP.Text = ._OVMSRP
            TxtSource.Text = Trim(._OVSOURCE)
          End If
          If ._COMPLETE = "Y" Then
            ChkComplete.Checked = True
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
      LblSSNo.Text = ._SSNO
      LblSS2.Text = ._SS2
      LblOid.Text = ._OID
      CalcBTR()
    End With

    With myTXMVD
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
    End With

    myTXMVDCL1.GetOneRecordP(Trim(myTXMVD._VINNO))
    With myTXMVDCL1
      If Not .RecordNotFound Then
        LblBeforeCC.Visible = False
        If ._CCNO > 0 Then
          LblBeforeCC.Visible = True
          LblBeforeCC.Text = "Before Bill C/C " & ._CCNO
        End If
      End If
    End With

    'Comments
    dsTAXCOM = myTAXCOM.Getcomments(WrkListNo, WrkType, 0)
    MyFrmTA001.TBarComments.ImageKey = ""
    LblComments.Visible = False
    If dsTAXCOM.Tables(0).Rows.Count > 0 Then
      LblComments.Visible = True
      MyFrmTA001.TBarComments.ImageKey = "comment_24.png"
    End If

    If s_chg = True Or s_full = True Then  '#sec
      MyFrmTA001.TBarAttach.Enabled = True
      WrkAttachCount = GetAttachcount("TADAILY", "M" & MyUtils.CnvSng(LblSSNo.Text) & "-" & Trim(TxtRegno.Text))
      MyFrmTA001.TBarAttach.Text = WrkAttachCount & " Attachment(s)"
    End If

    If MySoftFreezeMV Then
      LblSoftFreeze.Visible = True
      LblBaa1.ForeColor = Color.Fuchsia
    End If
    LoadScrn = False
  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    If MySoftFreezeMV Then Exit Sub

    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    myLOGMV.GetOneRecordP(WrkListNo, 0, 0)
    MoveToLog("Delete")
    myLOGMV.AddOneRecordP()
    myTXBTR.GetOneRecordP(WrkListNo, WrkType)
    If Not myTXBTR.RecordNotFound Then
      myTXBTR.DeleteOneRecordP()
    End If
    myTXMVD.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim dslog As DataSet = New DataSet
    Dim WrkAutoGen As Boolean
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    myTXMVD.GetOneRecordP(WrkListNo)
    If AddMode Then
      If Not myTXMVD.RecordNotFound Then
        Me.ErrProv.SetError(TxtListNo, "Record already exists")
        Exit Sub
      End If
    End If

    SetExem1Tip()
    SetExem2Tip()
    SetExem3Tip()
    SetExem4Tip()
    SetExem5Tip()

    WrkAutoGen = False
    If Not AddMode Then
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        dslog = myLOGMV.PosData(WrkListNo, 0, 0, 1)
        If dslog.Tables(0).Rows.Count = 0 Then
          MoveToLog("Original")
          myLOGMV.AddOneRecordP()
        End If
        MoveToFile()
        MoveToLog("Change")
        myTXMVD.UpdateOneRecordP()
        myLOGMV.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If WrkListNo = 0 Then
          WrkListNo = myTXMVD.AutoGenKey()
          myTXMVD.GetOneRecordP(WrkListNo)
          WrkAutoGen = True
        End If
        MoveToFile()
        MoveToLog("Add")
        myTXMVD.AddOneRecordP()
        myLOGMV.AddOneRecordP()
        If WrkAutoGen Then
          MsgBox("Account has been assigned list number " & WrkListNo, MsgBoxStyle.Information, "System Generated List Number")
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    'Save to MSRP File
    With myTXMSRP
      .GetOneRecordP(Trim(myTXMVD._VINNO))
      ._OVMSRP = MyUtils.CnvSng(TxtOVMSRP.Text)
      ._OVSOURCE = TxtSource.Text
      If ChkComplete.Checked Then
        ._COMPLETE = "Y"
      Else
        ._COMPLETE = ""
      End If
      If RbCatNonTax.Checked Then
        ._NONTAX = "Y"
      Else
        ._NONTAX = ""
      End If
      If .RecordNotFound Then
        ._VINNO = Trim(myTXMVD._VINNO)
        .AddOneRecordP()
      Else
        .UpdateOneRecordP()
      End If
    End With

    'Save to BTR File
    myTXBTR.GetOneRecordP(WrkListNo, WrkType)

    If LblBaa.Visible Then
      With myTXBTR
        ._LISTNO = WrkListNo
        ._TYPE = WrkType
        ._BASS1 = MyUtils.CnvSng(TxtBaa.Text) - MyUtils.CnvSng(LblValue.Text)
      End With
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.UpdateOneRecordP()
      Else
        myTXBTR.AddOneRecordP()
      End If
    Else
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.DeleteOneRecordP()
      End If
    End If

    Me.Close()

  End Sub
  Public Sub SaveSoftFreeze()
    Dim dslog As DataSet = New DataSet
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

    EditChecksSoft(ErrorField, ErrorMsg)
    If Not IsNothing(ErrorMsg(0)) Then
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    myTXMVD.GetOneRecordP(WrkListNo)
    If Not myTXMVD.RecordNotFound Then
      With myTXMVD
        If LblBaa.Visible Then
          ._BTR = MyUtils.CnvSng(LblBaa.Text)
        Else
          ._BTR = 0
        End If
        If DtPckBtr.Checked Then
          ._DTBTR = MyUtils.SetDBDate(DtPckBtr.Value)
        Else
          ._DTBTR = 0
        End If
        ._DNBTR = "N"
        If ChkDnbtr.Checked Then
          ._DNBTR = "Y"
        End If
        .UpdateOneRecordP()
      End With
    End If

    dslog = myLOGMV.PosData(WrkListNo, 0, 0, 1)
    If dslog.Tables(0).Rows.Count = 0 Then
      MoveToLog("Original")
      myLOGMV.AddOneRecordP()
    End If
    MoveToLog("Change")
    myLOGMV.AddOneRecordP()

    'Save to BTR File
    myTXBTR.GetOneRecordP(WrkListNo, WrkType)

    If LblBaa.Visible Then
      With myTXBTR
        ._LISTNO = WrkListNo
        ._TYPE = WrkType
        ._BASS1 = MyUtils.CnvSng(TxtBaa.Text) - MyUtils.CnvSng(LblValue.Text)
      End With
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.UpdateOneRecordP()
      Else
        myTXBTR.AddOneRecordP()
      End If
    Else
      If Not myTXBTR.RecordNotFound Then
        myTXBTR.DeleteOneRecordP()
      End If
    End If

    Me.Close()

  End Sub
  Private Sub MoveToLog(ByVal WrkMode As String)
CheckFile:
    With myLOGMV
      .GetOneRecordP(WrkListNo, MyUtils.SetDBDate(DateTime.Today), Format(DateTime.Now, "HHmmss"))
      If .RecordNotFound Then
        ._ADD1 = myTXMVD._ADD1
        ._ADD2 = myTXMVD._ADD2
        ._ASS = myTXMVD._ASS
        ._BODY = myTXMVD._BODY
        ._BTC = myTXMVD._BTC
        ._BTR = myTXMVD._BTR
        ._CAT = myTXMVD._CAT
        ._CCCD1 = myTXMVD._CCCD1
        ._CCCD2 = myTXMVD._CCCD2
        ._CCCD3 = myTXMVD._CCCD3
        ._CCCD4 = myTXMVD._CCCD4
        ._CCCD5 = myTXMVD._CCCD5
        ._CCEX = myTXMVD._CCEX
        ._CCGRS = myTXMVD._CCGRS
        ._CCNO = myTXMVD._CCNO
        ._CCRS = myTXMVD._CCRS
        ._CDATE = myTXMVD._CDATE
        ._CEXA1 = myTXMVD._CEXA1
        ._CEXA2 = myTXMVD._CEXA2
        ._CEXA3 = myTXMVD._CEXA3
        ._CEXA4 = myTXMVD._CEXA4
        ._CEXA5 = myTXMVD._CEXA5
        ._CHDATE = myTXMVD._CHDATE
        ._CHTIME = myTXMVD._CHTIME
        ._CITY = myTXMVD._CITY
        ._CLASS = myTXMVD._CLASS
        ._CYCLE = myTXMVD._CYCLE
        ._CYLAX = myTXMVD._CYLAX
        ._DIST = myTXMVD._DIST
        ._DNBTR = myTXMVD._DNBTR
        ._DOB = myTXMVD._DOB
        ._DTBTR = myTXMVD._DTBTR
        ._EXAM1 = myTXMVD._EXAM1
        ._EXAM2 = myTXMVD._EXAM2
        ._EXAM3 = myTXMVD._EXAM3
        ._EXAM4 = myTXMVD._EXAM4
        ._EXAM5 = myTXMVD._EXAM5
        ._EXCD1 = myTXMVD._EXCD1
        ._EXCD2 = myTXMVD._EXCD2
        ._EXCD3 = myTXMVD._EXCD3
        ._EXCD4 = myTXMVD._EXCD4
        ._EXCD5 = myTXMVD._EXCD5
        ._GWT = myTXMVD._GWT
        ._LEASE = myTXMVD._LEASE
        ._LETT = myTXMVD._LETT
        ._LISTNo = myTXMVD._LISTNO
        ._LNVAL = myTXMVD._LNVAL
        ._LOGDTE = MyUtils.SetDBDate(DateTime.Today)
        ._LOGTIM = Format(DateTime.Now, "HHmmss")
        Select Case WrkMode
          Case "Add"
            ._LOGCMT = "Record Added"
          Case "Change"
            ._LOGCMT = "Record Changed"
          Case "Delete"
            ._LOGCMT = "Record Deleted"
          Case "Original"
            ._LOGCMT = "Original Record"
        End Select
        ._LWT = myTXMVD._LWT
        ._MAKE = myTXMVD._MAKE
        ._MODEL = myTXMVD._MODEL
        ._MSRP = myTXMVD._MSRP
        ._NADA = myTXMVD._NADA
        ._NAME = myTXMVD._NAME
        ._OASS = myTXMVD._OASS
        ._OCLS = myTXMVD._OCLS
        ._OCODE = myTXMVD._OCODE
        ._OID = myTXMVD._OID
        ._OLIST = myTXMVD._OLIST
        ._OMAKE = myTXMVD._OMAKE
        ._OMOD = myTXMVD._OMOD
        ._OPVAL = myTXMVD._OPVAL
        ._OREGNo = myTXMVD._OREGNO
        ._ORIG = myTXMVD._ORIG
        ._OVAL = myTXMVD._OVAL
        ._OVIN = myTXMVD._OVIN
        ._OYEAR = myTXMVD._OYEAR
        ._PCCOD = myTXMVD._PCCOD
        ._PCLR = myTXMVD._PCLR
        ._PDST = myTXMVD._PDST
        ._PNET = myTXMVD._PNET
        ._PREG = myTXMVD._PREG
        ._PRF = myTXMVD._PRF
        ._RAD1 = myTXMVD._RAD1
        ._RAD2 = myTXMVD._RAD2
        ._RATE = myTXMVD._RATE
        ._RCTY = myTXMVD._RCTY
        ._REGNO = myTXMVD._REGNO
        ._RST = myTXMVD._RST
        ._RZ5 = myTXMVD._RZ5
        ._RZ4 = myTXMVD._RZ4
        ._SCAP = myTXMVD._SCAP
        ._SCLR = myTXMVD._SCLR
        ._SEAT = myTXMVD._SEAT
        ._SNAME = myTXMVD._SNAME
        ._SS2 = myTXMVD._SS2
        ._SSNo = myTXMVD._SSNO
        ._STATE = myTXMVD._STATE
        ._TDATE = myTXMVD._TDATE
        ._TIN = myTXMVD._TIN
        ._TRVAL = myTXMVD._TRVAL
        ._TYPE = myTXMVD._TYPE
        ._VALUE = myTXMVD._VALUE
        ._VINNO = myTXMVD._VINNO
        ._XDATE = myTXMVD._XDATE
        ._YEAR = myTXMVD._YEAR
        ._ZIP5 = myTXMVD._ZIP5
        ._ZIP4 = myTXMVD._ZIP4
      Else
        Threading.Thread.Sleep(1000)
        GoTo CheckFile
      End If
    End With

  End Sub

  Private Sub MoveToFile()

    With myTXMVD
      ._LISTNO = WrkListNo
      ._NAME = TxtName.Text
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._RAD1 = TxtResAdd1.Text
      ._RAD2 = TxtResAdd2.Text  'added 9/12/25 ken
      ._RCTY = TxtResCity.Text
      ._RST = TxtResState.Text
      ._RZ5 = MyUtils.CnvSng(TxtResZip5.Text)
      ._RZ4 = MyUtils.CnvSng(TxtResZip4.Text)
      ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._LOC = TxtLoc.Text
      ._MAKE = TxtMake.Text
      ._MODEL = TxtModel.Text
      ._BODY = TxtBody.Text
      ._YEAR = MyUtils.CnvSng(TxtYear.Text)
      ._CLASS = MyUtils.CnvSng(TxtClass.Text)
      ._VINNO = TxtVIN.Text
      ._REGNO = TxtRegno.Text
      ._PDST = MyUtils.CnvSng(TxtPdst.Text)
      ._OID = MyUtils.CnvSng(LblOid.Text)
      ._SSNO = MyUtils.CnvSng(LblSSNo.Text)
      ._SS2 = MyUtils.CnvSng(LblSS2.Text)
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      If DtPckDOB.Checked Then
        ._DOB = MyUtils.SetDBDate(DtPckDOB.Value)
      Else
        ._DOB = 0
      End If
      ._CAT = "3"
      If RbCatTaxable.Checked Then
        ._CAT = "1"
      End If
      If RbCatNonTax.Checked Then
        ._CAT = "2"
      End If
      If RbCatTransfer.Checked Then
        ._CAT = "T"
      End If
      ._GWT = MyUtils.CnvSng(TxtGrossWgt.Text)
      ._LWT = MyUtils.CnvSng(TxtLightWgt.Text)
      ._VALUE = MyUtils.CnvSng(LblValue.Text)
      ._EXCD1 = TxtExempt1.Text
      ._EXAM1 = MyUtils.CnvSng(TxtExam1.Text)
      ._EXCD2 = TxtExempt2.Text
      ._EXAM2 = MyUtils.CnvSng(TxtExam2.Text)
      ._EXCD3 = TxtExempt3.Text
      ._EXAM3 = MyUtils.CnvSng(TxtExam3.Text)
      ._EXCD4 = TxtExempt4.Text
      ._EXAM4 = MyUtils.CnvSng(TxtExam4.Text)
      ._EXCD5 = TxtExempt5.Text
      ._EXAM5 = MyUtils.CnvSng(TxtExam5.Text)
      If LblBaa.Visible Then
        ._BTR = MyUtils.CnvSng(LblBaa.Text)
      Else
        ._BTR = 0
      End If
      If DtPckBtr.Checked Then
        ._DTBTR = MyUtils.SetDBDate(DtPckBtr.Value)
      Else
        ._DTBTR = 0
      End If
      ._DNBTR = "N"
      If ChkDnbtr.Checked Then
        ._DNBTR = "Y"
      End If
      ._TYPE = WrkType
      ._LETT = Mid$(TxtName.Text, 1, 1)
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(DateTime.Today)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
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
    ErrProv.SetError(TxtExempt1, "")
    ErrProv.SetError(TxtExempt2, "")
    ErrProv.SetError(TxtExempt3, "")
    ErrProv.SetError(TxtExempt4, "")
    ErrProv.SetError(TxtExempt5, "")
    ErrProv.SetError(LblNet, "")
    ErrProv.SetError(TxtRegno, "")
    ErrProv.SetError(TxtSource, "")
    ErrProv.SetError(LblBaa, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "list#"
          ErrProv.SetError(TxtListNo, ErrorMsg(I))
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case "add1"
          ErrProv.SetError(TxtAdd1, ErrorMsg(I))
        Case "city"
          ErrProv.SetError(TxtCity, ErrorMsg(I))
        Case "state"
          ErrProv.SetError(TxtState, ErrorMsg(I))
        Case "zip5"
          ErrProv.SetError(TxtZip5, ErrorMsg(I))
        Case "excd1"
          ErrProv.SetError(TxtExempt1, ErrorMsg(I))
        Case "excd2"
          ErrProv.SetError(TxtExempt2, ErrorMsg(I))
        Case "excd3"
          ErrProv.SetError(TxtExempt3, ErrorMsg(I))
        Case "excd4"
          ErrProv.SetError(TxtExempt4, ErrorMsg(I))
        Case "excd5"
          ErrProv.SetError(TxtExempt5, ErrorMsg(I))
        Case "net"
          ErrProv.SetError(LblNet, ErrorMsg(I))
        Case "regno"
          ErrProv.SetError(TxtRegno, ErrorMsg(I))
        Case "baa"
          ErrProv.SetError(LblBaa, ErrorMsg(I))
        'MK 9/22/25 Begin
        Case "source"
          ErrProv.SetError(TxtSource, ErrorMsg(I))
        'MK 9/22/25 Begin
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

    'If MyUtils.CnvSng(TxtListNo.Text) = 0 Then
    '  ErrorField(I) = "list#"
    '  ErrorMsg(I) = "List# cannot be zero"
    '  I = I + 1
    'End If

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name cannot be blank"
      I = I + 1
    End If

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

    If TxtExempt1.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt1)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd1"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt2.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt2)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd2"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt3.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt3)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd3"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt4.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt4)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd4"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt5.Text <> "" Then
      WrkTip = Ttp1.GetToolTip(TxtExempt5)
      If Mid(WrkTip, 1, 1) = "*" Then
        ErrorField(I) = "excd5"
        ErrorMsg(I) = "Invalid Exemption Code"
        I = I + 1
      End If
    End If

    If TxtExempt1.Text = "" And MyUtils.CnvSng(TxtExam1.Text) > 0 Then
      ErrorField(I) = "excd1"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt2.Text = "" And MyUtils.CnvSng(TxtExam2.Text) > 0 Then
      ErrorField(I) = "excd2"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt3.Text = "" And MyUtils.CnvSng(TxtExam3.Text) > 0 Then
      ErrorField(I) = "excd3"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt4.Text = "" And MyUtils.CnvSng(TxtExam4.Text) > 0 Then
      ErrorField(I) = "excd4"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If TxtExempt5.Text = "" And MyUtils.CnvSng(TxtExam5.Text) > 0 Then
      ErrorField(I) = "excd5"
      ErrorMsg(I) = "Exemption Code is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblNet.Text) < 0 Then
      ErrorField(I) = "net"
      ErrorMsg(I) = "Net Assessment cannot be negative"
      I = I + 1
    End If
    If TxtRegno.Text = String.Empty Then
      ErrorField(I) = "regno"
      ErrorMsg(I) = "Regno cannot be blank"
      I = I + 1
    End If
    'MK 9/22/25 Begin
    If Trim(TxtOVMSRP.Text) <> "" And Trim(TxtSource.Text = "") Then
      ErrorField(I) = "source"
      ErrorMsg(I) = "MSRP Source is required"
      I = I + 1
    End If
    'MK 9/22/25 End

    If LblBaa.Visible Then
      If DtPckBtr.Checked = False Or ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA Amount: Date is required and denied must be unchecked"
        I = I + 1
      End If
    End If

    If DtPckBtr.Checked Then
      If Not LblBaa.Visible And Not ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA must not be 0 or denied must be checked"
        I = I + 1
      End If
    End If

    If ChkDnbtr.Checked Then
      If LblBaa.Visible Or Not DtPckBtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "If BAA is denied then amount must be 0 and date is required"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub EditChecksSoft(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If LblBaa.Visible Then
      If DtPckBtr.Checked = False Or ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA Amount: Date is required and denied must be unchecked"
        I = I + 1
      End If
    End If

    If DtPckBtr.Checked Then
      If Not LblBaa.Visible And Not ChkDnbtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "BAA must not be 0 or denied must be checked"
        I = I + 1
      End If
    End If

    If ChkDnbtr.Checked Then
      If LblBaa.Visible Or Not DtPckBtr.Checked Then
        ErrorField(I) = "baa"
        ErrorMsg(I) = "If BAA is denied then amount must be 0 and date is required"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub FrmTA001MV_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmLOG = New FrmLOG
    MyFrmTA001.SbpScreen.Text = "TA001MV"
    MyFrmLOG.WrkListNo = MyFrmTA001MV.WrkListNo
    MyFrmLOG.WrkType = WrkType
    MyFrmLOG.ds = MyFrmTA001MV.logmv_ds

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
  Private Sub TxtExam1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam1.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam2.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam3.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam4.TextChanged
    CalcAssmt()
  End Sub
  Private Sub TxtExam5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam5.TextChanged
    CalcAssmt()
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
  Private Sub TxtExempt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt1.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt1.Text = "APA" Then
      TxtExam1.Text = MyUtils.CnvSng(LblGross.Text)
    Else
      WrkTxExem = GetTXExem(TxtExempt1.Text)
      TxtExam1.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam1.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt2.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt2.Text = "APA" Then
      TxtExam2.Text = MyUtils.CnvSng(LblGross.Text)
    Else
      WrkTxExem = GetTXExem(TxtExempt2.Text)
      TxtExam2.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam2.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt3.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt3.Text = "APA" Then
      TxtExam3.Text = MyUtils.CnvSng(LblGross.Text)
    Else
      WrkTxExem = GetTXExem(TxtExempt3.Text)
      TxtExam3.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam3.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt4.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt4.Text = "APA" Then
      TxtExam4.Text = MyUtils.CnvSng(LblGross.Text)
    Else
      WrkTxExem = GetTXExem(TxtExempt4.Text)
      TxtExam4.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam4.Text = WrkAmt
      End If
    End If
  End Sub
  Private Sub TxtExempt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt5.TextChanged
    Dim WrkTxExem As String()
    Dim WrkAmt As Integer

    If LoadScrn Then Exit Sub

    If TxtExempt5.Text = "APA" Then
      TxtExam5.Text = MyUtils.CnvSng(LblGross.Text)
    Else
      WrkTxExem = GetTXExem(TxtExempt5.Text)
      TxtExam5.Text = WrkTxExem(0)
      If MyLocEldDarien Then
        WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
        If MyUtils.CnvSng(WrkTxExem(2)) > 0 Then
          WrkAmt = CalcDarNet() * (MyUtils.CnvSng(WrkTxExem(2)) / 100)
          If MyUtils.CnvSng(WrkTxExem(0)) > WrkAmt Then
            WrkAmt = MyUtils.CnvSng(WrkTxExem(0))
          End If
        End If
        TxtExam5.Text = WrkAmt
      End If
    End If
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
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = 1
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click

    With MyFrmTA001B
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
    With MyFrmTA001B
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
    MyFrmTA001DMV = New FrmTA001DMV
    MyFrmTA001DMV.MdiParent = Me.ParentForm
    MyFrmTA001DMV.WrkVehID = MyUtils.CnvSng(LblOid.Text)
    MyFrmTA001DMV.WrkPCustID = MyUtils.CnvSng(LblSSNo.Text)
    MyFrmTA001DMV.WrkSCustID = MyUtils.CnvSng(LblSS2.Text)
    MyFrmTA001DMV.WrkRegNo = TxtRegno.Text
    MyFrmTA001DMV.WrkVIN = TxtVIN.Text
    MyFrmTA001DMV.WrkListNo = WrkListNo
    MyFrmTA001DMV.WrkName = TxtName.Text
    MyFrmTA001DMV.WrkType = "M"
    MyFrmTA001DMV.Show()
    Me.Hide()
  End Sub
  Private Sub DtPckBtr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtPckBtr.ValueChanged
    CalcBTR()
  End Sub
  Private Sub ChkDnbtr_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkDnbtr.Click
    CalcBTR()
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
  Private Function CalcDarNet() As Integer
    Dim WrkCode(4) As String
    Dim WrkExam(4) As Integer
    Dim WrkGross As Integer
    Dim WrkTExam As Integer
    Dim J As Integer
    If MyLocEldDarien Then
      WrkCode(0) = TxtExempt1.Text
      WrkCode(1) = TxtExempt2.Text
      WrkCode(2) = TxtExempt3.Text
      WrkCode(3) = TxtExempt4.Text
      WrkCode(4) = TxtExempt5.Text
      WrkGross = MyUtils.CnvSng(LblGross.Text)
      WrkExam(0) = MyUtils.CnvSng(TxtExam1.Text)
      WrkExam(1) = MyUtils.CnvSng(TxtExam2.Text)
      WrkExam(2) = MyUtils.CnvSng(TxtExam3.Text)
      WrkExam(3) = MyUtils.CnvSng(TxtExam4.Text)
      WrkExam(4) = MyUtils.CnvSng(TxtExam5.Text)
      WrkTExam = 0
      For J = 0 To 4
        If WrkCode(J) <> cDarExcd1 And WrkCode(J) <> cDarExcd2 _
        And WrkCode(J) <> cDarExcd3 And WrkCode(J) <> cDarExcd4 Then
          WrkTExam = WrkTExam + WrkExam(J)
        End If
      Next J
      Return (WrkGross - WrkTExam)
    End If

  End Function
  Private Sub TxtOVMSRP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOVMSRP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOVMSRP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOVMSRP.TextChanged
    Dim WrkMSRP As Integer
    Dim WrkOvMSRP As Integer
    Dim WrkYear As Integer
    Dim WrkValue As Integer
    WrkMSRP = MyUtils.CnvSng(LblMSRP.Text)
    WrkOvMSRP = MyUtils.CnvSng(TxtOVMSRP.Text)
    WrkYear = MyUtils.CnvSng(TxtYear.Text)
    WrkValue = CalcValue(WrkMSRP, WrkOvMSRP, WrkYear)
    LblValue.Text = MyUtils.Round10(WrkValue, "Normal")
  End Sub

  Private Sub LnkSource_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkSource.LinkClicked
    MyFrmListSource = New FrmListSource
    MyFrmListSource.MdiParent = Me.ParentForm
    MyFrmListSource.WrkScreen = "MV"
    MyFrmListSource.WrkCode = TxtSource.Text
    MyFrmListSource.Show()
  End Sub
  Private Function CalcValue(ByVal WrkMSRP As Integer, ByVal WrkOvMSRP As Integer, ByVal WrkYear As Integer) As Integer
    Dim WrkDeYear As Integer
    Dim WrkValue As Integer
    Dim WrkDepr As Decimal
    'Calculate Assessment Value
    WrkValue = 0
    WrkDeYear = (WrkChkYear + 1) - WrkYear + 1
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

  Private Sub RbCatNonTax_CheckedChanged(sender As Object, e As EventArgs) Handles RbCatNonTax.CheckedChanged

  End Sub
End Class






