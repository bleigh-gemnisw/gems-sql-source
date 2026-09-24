Public Class FrmTAD05PP
  Inherits System.Windows.Forms.Form
  Dim myTXPPRA As TXPPRA.MyData
  Dim myTXBAA As TXBAA.MyData
  Dim myTXBUSTY As TXBUSTY.MyData
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkFastPath As Boolean
  Const WrkType As String = "P"
  Dim LoadScrn As Boolean
  Dim WrkAdjYear As Integer

  Friend WithEvents BtnNext As System.Windows.Forms.Button
  Friend WithEvents BtnPrevious As System.Windows.Forms.Button
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LblYear As Label
  Friend WithEvents BtnUp As Button
  Friend WithEvents BtnDown As Button
  Friend WithEvents LblTaxExempt As System.Windows.Forms.Label


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
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtUnit1 As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents TxtAssmt1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa1 As System.Windows.Forms.TextBox
  Friend WithEvents LblBTR1 As System.Windows.Forms.Label
  Friend WithEvents LblBTR2 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents TxtUnit2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit8 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit9 As System.Windows.Forms.TextBox
  Friend WithEvents TxtUnit10 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt8 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt9 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAssmt10 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa8 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa9 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBaa10 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents Label36 As System.Windows.Forms.Label
  Friend WithEvents Label37 As System.Windows.Forms.Label
  Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtBusty As System.Windows.Forms.TextBox
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Friend WithEvents TxtPdst As System.Windows.Forms.TextBox
  Friend WithEvents Label40 As System.Windows.Forms.Label
  Friend WithEvents TxtAdyr As System.Windows.Forms.TextBox
  Friend WithEvents Label41 As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents LblDtPckBtr As System.Windows.Forms.Label
  Friend WithEvents DtPckBtr As System.Windows.Forms.DateTimePicker
  Friend WithEvents ChkDnbtr As System.Windows.Forms.CheckBox
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
  Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
  Friend WithEvents TxtCode1 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode1 As System.Windows.Forms.LinkLabel
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtCode2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode6 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode7 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode8 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode9 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCode10 As System.Windows.Forms.TextBox
  Friend WithEvents LnkCode2 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode3 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode4 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode5 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode6 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode7 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode8 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode9 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkCode10 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExempt2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExempt5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExempt3 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt5 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkExempt3 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkExempt4 As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtExempt4 As System.Windows.Forms.TextBox
  Friend WithEvents LnkExempt2 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkExempt1 As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkBusty As System.Windows.Forms.LinkLabel
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents LblBaaNet As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents LblNet As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LblExempt As System.Windows.Forms.Label
  Friend WithEvents LblGross As System.Windows.Forms.Label
  Friend WithEvents LblBaa As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LnkCode10 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode10 = New System.Windows.Forms.TextBox()
    Me.LnkCode9 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode9 = New System.Windows.Forms.TextBox()
    Me.LnkCode8 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode8 = New System.Windows.Forms.TextBox()
    Me.LnkCode7 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode7 = New System.Windows.Forms.TextBox()
    Me.LnkCode6 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode6 = New System.Windows.Forms.TextBox()
    Me.LnkCode5 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode5 = New System.Windows.Forms.TextBox()
    Me.LnkCode4 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode4 = New System.Windows.Forms.TextBox()
    Me.LnkCode3 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode3 = New System.Windows.Forms.TextBox()
    Me.LnkCode2 = New System.Windows.Forms.LinkLabel()
    Me.TxtCode2 = New System.Windows.Forms.TextBox()
    Me.LnkCode1 = New System.Windows.Forms.LinkLabel()
    Me.TxtBaa10 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt10 = New System.Windows.Forms.TextBox()
    Me.TxtUnit10 = New System.Windows.Forms.TextBox()
    Me.TxtBaa9 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt9 = New System.Windows.Forms.TextBox()
    Me.TxtUnit9 = New System.Windows.Forms.TextBox()
    Me.TxtBaa8 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt8 = New System.Windows.Forms.TextBox()
    Me.TxtUnit8 = New System.Windows.Forms.TextBox()
    Me.TxtBaa7 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt7 = New System.Windows.Forms.TextBox()
    Me.TxtUnit7 = New System.Windows.Forms.TextBox()
    Me.TxtBaa6 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt6 = New System.Windows.Forms.TextBox()
    Me.TxtUnit6 = New System.Windows.Forms.TextBox()
    Me.TxtBaa4 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt4 = New System.Windows.Forms.TextBox()
    Me.TxtUnit4 = New System.Windows.Forms.TextBox()
    Me.TxtBaa5 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt5 = New System.Windows.Forms.TextBox()
    Me.TxtUnit5 = New System.Windows.Forms.TextBox()
    Me.TxtBaa3 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt3 = New System.Windows.Forms.TextBox()
    Me.TxtUnit3 = New System.Windows.Forms.TextBox()
    Me.LblBTR2 = New System.Windows.Forms.Label()
    Me.TxtBaa2 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt2 = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtUnit2 = New System.Windows.Forms.TextBox()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.LblBTR1 = New System.Windows.Forms.Label()
    Me.TxtBaa1 = New System.Windows.Forms.TextBox()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtUnit1 = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtCode1 = New System.Windows.Forms.TextBox()
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
    Me.Label36 = New System.Windows.Forms.Label()
    Me.Label37 = New System.Windows.Forms.Label()
    Me.TxtExam5 = New System.Windows.Forms.TextBox()
    Me.TxtExam3 = New System.Windows.Forms.TextBox()
    Me.TxtExam1 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.TxtBusty = New System.Windows.Forms.TextBox()
    Me.TxtOid = New System.Windows.Forms.TextBox()
    Me.TxtPdst = New System.Windows.Forms.TextBox()
    Me.Label40 = New System.Windows.Forms.Label()
    Me.TxtAdyr = New System.Windows.Forms.TextBox()
    Me.Label41 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.LblDtPckBtr = New System.Windows.Forms.Label()
    Me.DtPckBtr = New System.Windows.Forms.DateTimePicker()
    Me.ChkDnbtr = New System.Windows.Forms.CheckBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LnkBusty = New System.Windows.Forms.LinkLabel()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblBaaNet = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblNet = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblExempt = New System.Windows.Forms.Label()
    Me.LblGross = New System.Windows.Forms.Label()
    Me.LblBaa = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.BtnNext = New System.Windows.Forms.Button()
    Me.BtnPrevious = New System.Windows.Forms.Button()
    Me.LblTaxExempt = New System.Windows.Forms.Label()
    Me.LblBeforeCC = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.BtnUp = New System.Windows.Forms.Button()
    Me.BtnDown = New System.Windows.Forms.Button()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(104, 40)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 1
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(16, 40)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(48, 16)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Name"
    '
    'TxtListNo
    '
    Me.TxtListNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtListNo.Location = New System.Drawing.Point(104, 16)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(62, 22)
    Me.TxtListNo.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 13
    Me.Label1.Text = "List No"
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(104, 64)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(288, 22)
    Me.TxtSname.TabIndex = 2
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(16, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 22
    Me.Label2.Text = "Second Name"
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(104, 88)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 3
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(104, 112)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd2.TabIndex = 4
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(320, 136)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 6
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(104, 136)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 5
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(16, 88)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 27
    Me.Label3.Text = "Street Address"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(16, 136)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(80, 16)
    Me.Label4.TabIndex = 28
    Me.Label4.Text = "City/State/Zip"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(16, 160)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 29
    Me.Label6.Text = "Location#/Name"
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(104, 160)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(62, 22)
    Me.TxtLocNo.TabIndex = 9
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(169, 160)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(209, 22)
    Me.TxtLoc.TabIndex = 10
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(352, 136)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 7
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(406, 136)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(42, 22)
    Me.TxtZip4.TabIndex = 8
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(16, 208)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(88, 16)
    Me.Label9.TabIndex = 35
    Me.Label9.Text = "I.D."
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LnkCode10)
    Me.GroupBox1.Controls.Add(Me.TxtCode10)
    Me.GroupBox1.Controls.Add(Me.LnkCode9)
    Me.GroupBox1.Controls.Add(Me.TxtCode9)
    Me.GroupBox1.Controls.Add(Me.LnkCode8)
    Me.GroupBox1.Controls.Add(Me.TxtCode8)
    Me.GroupBox1.Controls.Add(Me.LnkCode7)
    Me.GroupBox1.Controls.Add(Me.TxtCode7)
    Me.GroupBox1.Controls.Add(Me.LnkCode6)
    Me.GroupBox1.Controls.Add(Me.TxtCode6)
    Me.GroupBox1.Controls.Add(Me.LnkCode5)
    Me.GroupBox1.Controls.Add(Me.TxtCode5)
    Me.GroupBox1.Controls.Add(Me.LnkCode4)
    Me.GroupBox1.Controls.Add(Me.TxtCode4)
    Me.GroupBox1.Controls.Add(Me.LnkCode3)
    Me.GroupBox1.Controls.Add(Me.TxtCode3)
    Me.GroupBox1.Controls.Add(Me.LnkCode2)
    Me.GroupBox1.Controls.Add(Me.TxtCode2)
    Me.GroupBox1.Controls.Add(Me.LnkCode1)
    Me.GroupBox1.Controls.Add(Me.TxtBaa10)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt10)
    Me.GroupBox1.Controls.Add(Me.TxtUnit10)
    Me.GroupBox1.Controls.Add(Me.TxtBaa9)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt9)
    Me.GroupBox1.Controls.Add(Me.TxtUnit9)
    Me.GroupBox1.Controls.Add(Me.TxtBaa8)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt8)
    Me.GroupBox1.Controls.Add(Me.TxtUnit8)
    Me.GroupBox1.Controls.Add(Me.TxtBaa7)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt7)
    Me.GroupBox1.Controls.Add(Me.TxtUnit7)
    Me.GroupBox1.Controls.Add(Me.TxtBaa6)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt6)
    Me.GroupBox1.Controls.Add(Me.TxtUnit6)
    Me.GroupBox1.Controls.Add(Me.TxtBaa4)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt4)
    Me.GroupBox1.Controls.Add(Me.TxtUnit4)
    Me.GroupBox1.Controls.Add(Me.TxtBaa5)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt5)
    Me.GroupBox1.Controls.Add(Me.TxtUnit5)
    Me.GroupBox1.Controls.Add(Me.TxtBaa3)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt3)
    Me.GroupBox1.Controls.Add(Me.TxtUnit3)
    Me.GroupBox1.Controls.Add(Me.LblBTR2)
    Me.GroupBox1.Controls.Add(Me.TxtBaa2)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt2)
    Me.GroupBox1.Controls.Add(Me.Label20)
    Me.GroupBox1.Controls.Add(Me.Label21)
    Me.GroupBox1.Controls.Add(Me.TxtUnit2)
    Me.GroupBox1.Controls.Add(Me.Label23)
    Me.GroupBox1.Controls.Add(Me.LblBTR1)
    Me.GroupBox1.Controls.Add(Me.TxtBaa1)
    Me.GroupBox1.Controls.Add(Me.TxtAssmt1)
    Me.GroupBox1.Controls.Add(Me.Label17)
    Me.GroupBox1.Controls.Add(Me.Label16)
    Me.GroupBox1.Controls.Add(Me.TxtUnit1)
    Me.GroupBox1.Controls.Add(Me.Label10)
    Me.GroupBox1.Controls.Add(Me.TxtCode1)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(8, 232)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(720, 152)
    Me.GroupBox1.TabIndex = 19
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Assessment Property Codes"
    '
    'LnkCode10
    '
    Me.LnkCode10.Location = New System.Drawing.Point(368, 128)
    Me.LnkCode10.Name = "LnkCode10"
    Me.LnkCode10.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode10.TabIndex = 172
    Me.LnkCode10.TabStop = True
    Me.LnkCode10.Text = "10"
    '
    'TxtCode10
    '
    Me.TxtCode10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode10.Location = New System.Drawing.Point(392, 128)
    Me.TxtCode10.MaxLength = 3
    Me.TxtCode10.Name = "TxtCode10"
    Me.TxtCode10.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode10.TabIndex = 36
    '
    'LnkCode9
    '
    Me.LnkCode9.Location = New System.Drawing.Point(8, 128)
    Me.LnkCode9.Name = "LnkCode9"
    Me.LnkCode9.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode9.TabIndex = 170
    Me.LnkCode9.TabStop = True
    Me.LnkCode9.Text = "9"
    '
    'TxtCode9
    '
    Me.TxtCode9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode9.Location = New System.Drawing.Point(32, 128)
    Me.TxtCode9.MaxLength = 3
    Me.TxtCode9.Name = "TxtCode9"
    Me.TxtCode9.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode9.TabIndex = 32
    '
    'LnkCode8
    '
    Me.LnkCode8.Location = New System.Drawing.Point(368, 104)
    Me.LnkCode8.Name = "LnkCode8"
    Me.LnkCode8.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode8.TabIndex = 168
    Me.LnkCode8.TabStop = True
    Me.LnkCode8.Text = "8"
    '
    'TxtCode8
    '
    Me.TxtCode8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode8.Location = New System.Drawing.Point(392, 104)
    Me.TxtCode8.MaxLength = 3
    Me.TxtCode8.Name = "TxtCode8"
    Me.TxtCode8.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode8.TabIndex = 28
    '
    'LnkCode7
    '
    Me.LnkCode7.Location = New System.Drawing.Point(8, 104)
    Me.LnkCode7.Name = "LnkCode7"
    Me.LnkCode7.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode7.TabIndex = 166
    Me.LnkCode7.TabStop = True
    Me.LnkCode7.Text = "7"
    '
    'TxtCode7
    '
    Me.TxtCode7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode7.Location = New System.Drawing.Point(32, 104)
    Me.TxtCode7.MaxLength = 3
    Me.TxtCode7.Name = "TxtCode7"
    Me.TxtCode7.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode7.TabIndex = 24
    '
    'LnkCode6
    '
    Me.LnkCode6.Location = New System.Drawing.Point(368, 80)
    Me.LnkCode6.Name = "LnkCode6"
    Me.LnkCode6.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode6.TabIndex = 164
    Me.LnkCode6.TabStop = True
    Me.LnkCode6.Text = "6"
    '
    'TxtCode6
    '
    Me.TxtCode6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode6.Location = New System.Drawing.Point(392, 80)
    Me.TxtCode6.MaxLength = 3
    Me.TxtCode6.Name = "TxtCode6"
    Me.TxtCode6.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode6.TabIndex = 20
    '
    'LnkCode5
    '
    Me.LnkCode5.Location = New System.Drawing.Point(8, 80)
    Me.LnkCode5.Name = "LnkCode5"
    Me.LnkCode5.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode5.TabIndex = 162
    Me.LnkCode5.TabStop = True
    Me.LnkCode5.Text = "5"
    '
    'TxtCode5
    '
    Me.TxtCode5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode5.Location = New System.Drawing.Point(32, 80)
    Me.TxtCode5.MaxLength = 3
    Me.TxtCode5.Name = "TxtCode5"
    Me.TxtCode5.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode5.TabIndex = 16
    '
    'LnkCode4
    '
    Me.LnkCode4.Location = New System.Drawing.Point(368, 56)
    Me.LnkCode4.Name = "LnkCode4"
    Me.LnkCode4.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode4.TabIndex = 160
    Me.LnkCode4.TabStop = True
    Me.LnkCode4.Text = "4"
    '
    'TxtCode4
    '
    Me.TxtCode4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode4.Location = New System.Drawing.Point(392, 56)
    Me.TxtCode4.MaxLength = 3
    Me.TxtCode4.Name = "TxtCode4"
    Me.TxtCode4.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode4.TabIndex = 12
    '
    'LnkCode3
    '
    Me.LnkCode3.Location = New System.Drawing.Point(8, 56)
    Me.LnkCode3.Name = "LnkCode3"
    Me.LnkCode3.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode3.TabIndex = 158
    Me.LnkCode3.TabStop = True
    Me.LnkCode3.Text = "3"
    '
    'TxtCode3
    '
    Me.TxtCode3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode3.Location = New System.Drawing.Point(32, 56)
    Me.TxtCode3.MaxLength = 3
    Me.TxtCode3.Name = "TxtCode3"
    Me.TxtCode3.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode3.TabIndex = 8
    '
    'LnkCode2
    '
    Me.LnkCode2.Location = New System.Drawing.Point(368, 32)
    Me.LnkCode2.Name = "LnkCode2"
    Me.LnkCode2.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode2.TabIndex = 156
    Me.LnkCode2.TabStop = True
    Me.LnkCode2.Text = "2"
    '
    'TxtCode2
    '
    Me.TxtCode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode2.Location = New System.Drawing.Point(392, 32)
    Me.TxtCode2.MaxLength = 3
    Me.TxtCode2.Name = "TxtCode2"
    Me.TxtCode2.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode2.TabIndex = 4
    '
    'LnkCode1
    '
    Me.LnkCode1.Location = New System.Drawing.Point(8, 32)
    Me.LnkCode1.Name = "LnkCode1"
    Me.LnkCode1.Size = New System.Drawing.Size(24, 16)
    Me.LnkCode1.TabIndex = 154
    Me.LnkCode1.TabStop = True
    Me.LnkCode1.Text = "1"
    '
    'TxtBaa10
    '
    Me.TxtBaa10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa10.Location = New System.Drawing.Point(558, 128)
    Me.TxtBaa10.MaxLength = 9
    Me.TxtBaa10.Name = "TxtBaa10"
    Me.TxtBaa10.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa10.TabIndex = 39
    Me.TxtBaa10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt10
    '
    Me.TxtAssmt10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt10.Location = New System.Drawing.Point(472, 128)
    Me.TxtAssmt10.MaxLength = 9
    Me.TxtAssmt10.Name = "TxtAssmt10"
    Me.TxtAssmt10.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt10.TabIndex = 38
    Me.TxtAssmt10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit10
    '
    Me.TxtUnit10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit10.Location = New System.Drawing.Point(432, 128)
    Me.TxtUnit10.MaxLength = 3
    Me.TxtUnit10.Name = "TxtUnit10"
    Me.TxtUnit10.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit10.TabIndex = 37
    Me.TxtUnit10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa9
    '
    Me.TxtBaa9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa9.Location = New System.Drawing.Point(198, 128)
    Me.TxtBaa9.MaxLength = 9
    Me.TxtBaa9.Name = "TxtBaa9"
    Me.TxtBaa9.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa9.TabIndex = 35
    Me.TxtBaa9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt9
    '
    Me.TxtAssmt9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt9.Location = New System.Drawing.Point(112, 128)
    Me.TxtAssmt9.MaxLength = 9
    Me.TxtAssmt9.Name = "TxtAssmt9"
    Me.TxtAssmt9.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt9.TabIndex = 34
    Me.TxtAssmt9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit9
    '
    Me.TxtUnit9.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit9.Location = New System.Drawing.Point(72, 128)
    Me.TxtUnit9.MaxLength = 3
    Me.TxtUnit9.Name = "TxtUnit9"
    Me.TxtUnit9.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit9.TabIndex = 33
    Me.TxtUnit9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa8
    '
    Me.TxtBaa8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa8.Location = New System.Drawing.Point(558, 104)
    Me.TxtBaa8.MaxLength = 9
    Me.TxtBaa8.Name = "TxtBaa8"
    Me.TxtBaa8.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa8.TabIndex = 31
    Me.TxtBaa8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt8
    '
    Me.TxtAssmt8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt8.Location = New System.Drawing.Point(472, 104)
    Me.TxtAssmt8.MaxLength = 9
    Me.TxtAssmt8.Name = "TxtAssmt8"
    Me.TxtAssmt8.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt8.TabIndex = 30
    Me.TxtAssmt8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit8
    '
    Me.TxtUnit8.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit8.Location = New System.Drawing.Point(432, 104)
    Me.TxtUnit8.MaxLength = 3
    Me.TxtUnit8.Name = "TxtUnit8"
    Me.TxtUnit8.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit8.TabIndex = 29
    Me.TxtUnit8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa7
    '
    Me.TxtBaa7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa7.Location = New System.Drawing.Point(198, 104)
    Me.TxtBaa7.MaxLength = 9
    Me.TxtBaa7.Name = "TxtBaa7"
    Me.TxtBaa7.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa7.TabIndex = 27
    Me.TxtBaa7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt7
    '
    Me.TxtAssmt7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt7.Location = New System.Drawing.Point(112, 104)
    Me.TxtAssmt7.MaxLength = 9
    Me.TxtAssmt7.Name = "TxtAssmt7"
    Me.TxtAssmt7.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt7.TabIndex = 26
    Me.TxtAssmt7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit7
    '
    Me.TxtUnit7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit7.Location = New System.Drawing.Point(72, 104)
    Me.TxtUnit7.MaxLength = 3
    Me.TxtUnit7.Name = "TxtUnit7"
    Me.TxtUnit7.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit7.TabIndex = 25
    Me.TxtUnit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa6
    '
    Me.TxtBaa6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa6.Location = New System.Drawing.Point(558, 80)
    Me.TxtBaa6.MaxLength = 9
    Me.TxtBaa6.Name = "TxtBaa6"
    Me.TxtBaa6.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa6.TabIndex = 23
    Me.TxtBaa6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt6
    '
    Me.TxtAssmt6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt6.Location = New System.Drawing.Point(472, 80)
    Me.TxtAssmt6.MaxLength = 9
    Me.TxtAssmt6.Name = "TxtAssmt6"
    Me.TxtAssmt6.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt6.TabIndex = 22
    Me.TxtAssmt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit6
    '
    Me.TxtUnit6.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit6.Location = New System.Drawing.Point(432, 80)
    Me.TxtUnit6.MaxLength = 3
    Me.TxtUnit6.Name = "TxtUnit6"
    Me.TxtUnit6.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit6.TabIndex = 21
    Me.TxtUnit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa4
    '
    Me.TxtBaa4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa4.Location = New System.Drawing.Point(558, 56)
    Me.TxtBaa4.MaxLength = 9
    Me.TxtBaa4.Name = "TxtBaa4"
    Me.TxtBaa4.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa4.TabIndex = 15
    Me.TxtBaa4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt4
    '
    Me.TxtAssmt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt4.Location = New System.Drawing.Point(472, 56)
    Me.TxtAssmt4.MaxLength = 9
    Me.TxtAssmt4.Name = "TxtAssmt4"
    Me.TxtAssmt4.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt4.TabIndex = 14
    Me.TxtAssmt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit4
    '
    Me.TxtUnit4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit4.Location = New System.Drawing.Point(432, 56)
    Me.TxtUnit4.MaxLength = 3
    Me.TxtUnit4.Name = "TxtUnit4"
    Me.TxtUnit4.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit4.TabIndex = 13
    Me.TxtUnit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa5
    '
    Me.TxtBaa5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa5.Location = New System.Drawing.Point(198, 80)
    Me.TxtBaa5.MaxLength = 9
    Me.TxtBaa5.Name = "TxtBaa5"
    Me.TxtBaa5.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa5.TabIndex = 19
    Me.TxtBaa5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt5
    '
    Me.TxtAssmt5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt5.Location = New System.Drawing.Point(112, 80)
    Me.TxtAssmt5.MaxLength = 9
    Me.TxtAssmt5.Name = "TxtAssmt5"
    Me.TxtAssmt5.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt5.TabIndex = 18
    Me.TxtAssmt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit5
    '
    Me.TxtUnit5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit5.Location = New System.Drawing.Point(72, 80)
    Me.TxtUnit5.MaxLength = 3
    Me.TxtUnit5.Name = "TxtUnit5"
    Me.TxtUnit5.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit5.TabIndex = 17
    Me.TxtUnit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtBaa3
    '
    Me.TxtBaa3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa3.Location = New System.Drawing.Point(198, 56)
    Me.TxtBaa3.MaxLength = 9
    Me.TxtBaa3.Name = "TxtBaa3"
    Me.TxtBaa3.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa3.TabIndex = 11
    Me.TxtBaa3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt3
    '
    Me.TxtAssmt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt3.Location = New System.Drawing.Point(112, 56)
    Me.TxtAssmt3.MaxLength = 9
    Me.TxtAssmt3.Name = "TxtAssmt3"
    Me.TxtAssmt3.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt3.TabIndex = 10
    Me.TxtAssmt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtUnit3
    '
    Me.TxtUnit3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit3.Location = New System.Drawing.Point(72, 56)
    Me.TxtUnit3.MaxLength = 3
    Me.TxtUnit3.Name = "TxtUnit3"
    Me.TxtUnit3.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit3.TabIndex = 9
    Me.TxtUnit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblBTR2
    '
    Me.LblBTR2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBTR2.ForeColor = System.Drawing.Color.Black
    Me.LblBTR2.Location = New System.Drawing.Point(561, 16)
    Me.LblBTR2.Name = "LblBTR2"
    Me.LblBTR2.Size = New System.Drawing.Size(72, 16)
    Me.LblBTR2.TabIndex = 45
    Me.LblBTR2.Text = "B.A.A Amt"
    '
    'TxtBaa2
    '
    Me.TxtBaa2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa2.Location = New System.Drawing.Point(558, 32)
    Me.TxtBaa2.MaxLength = 9
    Me.TxtBaa2.Name = "TxtBaa2"
    Me.TxtBaa2.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa2.TabIndex = 7
    Me.TxtBaa2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt2
    '
    Me.TxtAssmt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt2.Location = New System.Drawing.Point(472, 32)
    Me.TxtAssmt2.MaxLength = 9
    Me.TxtAssmt2.Name = "TxtAssmt2"
    Me.TxtAssmt2.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt2.TabIndex = 6
    Me.TxtAssmt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.ForeColor = System.Drawing.Color.Black
    Me.Label20.Location = New System.Drawing.Point(472, 16)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(73, 13)
    Me.Label20.TabIndex = 42
    Me.Label20.Text = "Assessment"
    '
    'Label21
    '
    Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label21.ForeColor = System.Drawing.Color.Black
    Me.Label21.Location = New System.Drawing.Point(432, 16)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(40, 16)
    Me.Label21.TabIndex = 41
    Me.Label21.Text = "Unit"
    '
    'TxtUnit2
    '
    Me.TxtUnit2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit2.Location = New System.Drawing.Point(432, 32)
    Me.TxtUnit2.MaxLength = 3
    Me.TxtUnit2.Name = "TxtUnit2"
    Me.TxtUnit2.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit2.TabIndex = 5
    Me.TxtUnit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label23
    '
    Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label23.ForeColor = System.Drawing.Color.Black
    Me.Label23.Location = New System.Drawing.Point(392, 16)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(40, 16)
    Me.Label23.TabIndex = 37
    Me.Label23.Text = "Code"
    '
    'LblBTR1
    '
    Me.LblBTR1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBTR1.ForeColor = System.Drawing.Color.Black
    Me.LblBTR1.Location = New System.Drawing.Point(206, 16)
    Me.LblBTR1.Name = "LblBTR1"
    Me.LblBTR1.Size = New System.Drawing.Size(72, 16)
    Me.LblBTR1.TabIndex = 36
    Me.LblBTR1.Text = "B.A.A Amt"
    '
    'TxtBaa1
    '
    Me.TxtBaa1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBaa1.Location = New System.Drawing.Point(198, 32)
    Me.TxtBaa1.MaxLength = 9
    Me.TxtBaa1.Name = "TxtBaa1"
    Me.TxtBaa1.Size = New System.Drawing.Size(80, 22)
    Me.TxtBaa1.TabIndex = 3
    Me.TxtBaa1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtAssmt1
    '
    Me.TxtAssmt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAssmt1.Location = New System.Drawing.Point(112, 32)
    Me.TxtAssmt1.MaxLength = 9
    Me.TxtAssmt1.Name = "TxtAssmt1"
    Me.TxtAssmt1.Size = New System.Drawing.Size(80, 22)
    Me.TxtAssmt1.TabIndex = 2
    Me.TxtAssmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label17.ForeColor = System.Drawing.Color.Black
    Me.Label17.Location = New System.Drawing.Point(112, 16)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(73, 13)
    Me.Label17.TabIndex = 33
    Me.Label17.Text = "Assessment"
    '
    'Label16
    '
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Black
    Me.Label16.Location = New System.Drawing.Point(72, 16)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(40, 16)
    Me.Label16.TabIndex = 32
    Me.Label16.Text = "Unit"
    '
    'TxtUnit1
    '
    Me.TxtUnit1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtUnit1.Location = New System.Drawing.Point(72, 32)
    Me.TxtUnit1.MaxLength = 3
    Me.TxtUnit1.Name = "TxtUnit1"
    Me.TxtUnit1.Size = New System.Drawing.Size(32, 22)
    Me.TxtUnit1.TabIndex = 1
    Me.TxtUnit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.ForeColor = System.Drawing.Color.Black
    Me.Label10.Location = New System.Drawing.Point(32, 16)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(40, 16)
    Me.Label10.TabIndex = 14
    Me.Label10.Text = "Code"
    '
    'TxtCode1
    '
    Me.TxtCode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCode1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCode1.Location = New System.Drawing.Point(32, 32)
    Me.TxtCode1.MaxLength = 3
    Me.TxtCode1.Name = "TxtCode1"
    Me.TxtCode1.Size = New System.Drawing.Size(32, 22)
    Me.TxtCode1.TabIndex = 0
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
    Me.GroupBox3.Controls.Add(Me.Label36)
    Me.GroupBox3.Controls.Add(Me.Label37)
    Me.GroupBox3.Controls.Add(Me.TxtExam5)
    Me.GroupBox3.Controls.Add(Me.TxtExam3)
    Me.GroupBox3.Controls.Add(Me.TxtExam1)
    Me.GroupBox3.Controls.Add(Me.Label8)
    Me.GroupBox3.Controls.Add(Me.Label32)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox3.Location = New System.Drawing.Point(8, 392)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(720, 104)
    Me.GroupBox3.TabIndex = 20
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Exemptions"
    '
    'LnkExempt5
    '
    Me.LnkExempt5.Location = New System.Drawing.Point(8, 80)
    Me.LnkExempt5.Name = "LnkExempt5"
    Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt5.TabIndex = 168
    Me.LnkExempt5.TabStop = True
    Me.LnkExempt5.Text = "5"
    '
    'TxtExempt5
    '
    Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt5.Location = New System.Drawing.Point(32, 80)
    Me.TxtExempt5.MaxLength = 3
    Me.TxtExempt5.Name = "TxtExempt5"
    Me.TxtExempt5.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt5.TabIndex = 8
    '
    'LnkExempt3
    '
    Me.LnkExempt3.Location = New System.Drawing.Point(8, 56)
    Me.LnkExempt3.Name = "LnkExempt3"
    Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt3.TabIndex = 167
    Me.LnkExempt3.TabStop = True
    Me.LnkExempt3.Text = "3"
    '
    'TxtExempt3
    '
    Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt3.Location = New System.Drawing.Point(32, 56)
    Me.TxtExempt3.MaxLength = 3
    Me.TxtExempt3.Name = "TxtExempt3"
    Me.TxtExempt3.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt3.TabIndex = 4
    '
    'LnkExempt4
    '
    Me.LnkExempt4.Location = New System.Drawing.Point(368, 56)
    Me.LnkExempt4.Name = "LnkExempt4"
    Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt4.TabIndex = 164
    Me.LnkExempt4.TabStop = True
    Me.LnkExempt4.Text = "4"
    '
    'TxtExempt4
    '
    Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt4.Location = New System.Drawing.Point(392, 56)
    Me.TxtExempt4.MaxLength = 3
    Me.TxtExempt4.Name = "TxtExempt4"
    Me.TxtExempt4.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt4.TabIndex = 6
    '
    'LnkExempt2
    '
    Me.LnkExempt2.Location = New System.Drawing.Point(368, 32)
    Me.LnkExempt2.Name = "LnkExempt2"
    Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt2.TabIndex = 163
    Me.LnkExempt2.TabStop = True
    Me.LnkExempt2.Text = "2"
    '
    'TxtExempt2
    '
    Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt2.Location = New System.Drawing.Point(392, 32)
    Me.TxtExempt2.MaxLength = 3
    Me.TxtExempt2.Name = "TxtExempt2"
    Me.TxtExempt2.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt2.TabIndex = 2
    '
    'LnkExempt1
    '
    Me.LnkExempt1.Location = New System.Drawing.Point(8, 32)
    Me.LnkExempt1.Name = "LnkExempt1"
    Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
    Me.LnkExempt1.TabIndex = 155
    Me.LnkExempt1.TabStop = True
    Me.LnkExempt1.Text = "1"
    '
    'TxtExempt1
    '
    Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtExempt1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExempt1.Location = New System.Drawing.Point(32, 32)
    Me.TxtExempt1.MaxLength = 3
    Me.TxtExempt1.Name = "TxtExempt1"
    Me.TxtExempt1.Size = New System.Drawing.Size(32, 22)
    Me.TxtExempt1.TabIndex = 0
    '
    'TxtExam4
    '
    Me.TxtExam4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam4.Location = New System.Drawing.Point(432, 56)
    Me.TxtExam4.MaxLength = 7
    Me.TxtExam4.Name = "TxtExam4"
    Me.TxtExam4.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam4.TabIndex = 7
    Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam2
    '
    Me.TxtExam2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam2.Location = New System.Drawing.Point(432, 32)
    Me.TxtExam2.MaxLength = 7
    Me.TxtExam2.Name = "TxtExam2"
    Me.TxtExam2.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam2.TabIndex = 3
    Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label36
    '
    Me.Label36.AutoSize = True
    Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label36.ForeColor = System.Drawing.Color.Black
    Me.Label36.Location = New System.Drawing.Point(445, 16)
    Me.Label36.Name = "Label36"
    Me.Label36.Size = New System.Drawing.Size(49, 13)
    Me.Label36.TabIndex = 48
    Me.Label36.Text = "Amount"
    '
    'Label37
    '
    Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label37.ForeColor = System.Drawing.Color.Black
    Me.Label37.Location = New System.Drawing.Point(392, 16)
    Me.Label37.Name = "Label37"
    Me.Label37.Size = New System.Drawing.Size(40, 16)
    Me.Label37.TabIndex = 46
    Me.Label37.Text = "Code"
    '
    'TxtExam5
    '
    Me.TxtExam5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam5.Location = New System.Drawing.Point(74, 80)
    Me.TxtExam5.MaxLength = 7
    Me.TxtExam5.Name = "TxtExam5"
    Me.TxtExam5.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam5.TabIndex = 9
    Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam3
    '
    Me.TxtExam3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam3.Location = New System.Drawing.Point(74, 56)
    Me.TxtExam3.MaxLength = 7
    Me.TxtExam3.Name = "TxtExam3"
    Me.TxtExam3.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam3.TabIndex = 5
    Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtExam1
    '
    Me.TxtExam1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtExam1.Location = New System.Drawing.Point(74, 32)
    Me.TxtExam1.MaxLength = 7
    Me.TxtExam1.Name = "TxtExam1"
    Me.TxtExam1.Size = New System.Drawing.Size(62, 22)
    Me.TxtExam1.TabIndex = 1
    Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.ForeColor = System.Drawing.Color.Black
    Me.Label8.Location = New System.Drawing.Point(88, 16)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(49, 13)
    Me.Label8.TabIndex = 38
    Me.Label8.Text = "Amount"
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.ForeColor = System.Drawing.Color.Black
    Me.Label32.Location = New System.Drawing.Point(32, 16)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(36, 13)
    Me.Label32.TabIndex = 35
    Me.Label32.Text = "Code"
    '
    'TxtBusty
    '
    Me.TxtBusty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBusty.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBusty.Location = New System.Drawing.Point(104, 184)
    Me.TxtBusty.MaxLength = 4
    Me.TxtBusty.Name = "TxtBusty"
    Me.TxtBusty.Size = New System.Drawing.Size(40, 22)
    Me.TxtBusty.TabIndex = 11
    '
    'TxtOid
    '
    Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtOid.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtOid.Location = New System.Drawing.Point(104, 208)
    Me.TxtOid.MaxLength = 15
    Me.TxtOid.Name = "TxtOid"
    Me.TxtOid.Size = New System.Drawing.Size(125, 22)
    Me.TxtOid.TabIndex = 16
    '
    'TxtPdst
    '
    Me.TxtPdst.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPdst.Location = New System.Drawing.Point(192, 184)
    Me.TxtPdst.MaxLength = 3
    Me.TxtPdst.Name = "TxtPdst"
    Me.TxtPdst.Size = New System.Drawing.Size(32, 22)
    Me.TxtPdst.TabIndex = 13
    Me.TxtPdst.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label40
    '
    Me.Label40.Location = New System.Drawing.Point(152, 184)
    Me.Label40.Name = "Label40"
    Me.Label40.Size = New System.Drawing.Size(40, 16)
    Me.Label40.TabIndex = 12
    Me.Label40.Text = "O-Dist"
    '
    'TxtAdyr
    '
    Me.TxtAdyr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdyr.Location = New System.Drawing.Point(320, 210)
    Me.TxtAdyr.MaxLength = 4
    Me.TxtAdyr.Name = "TxtAdyr"
    Me.TxtAdyr.Size = New System.Drawing.Size(40, 22)
    Me.TxtAdyr.TabIndex = 17
    '
    'Label41
    '
    Me.Label41.Location = New System.Drawing.Point(256, 214)
    Me.Label41.Name = "Label41"
    Me.Label41.Size = New System.Drawing.Size(64, 15)
    Me.Label41.TabIndex = 44
    Me.Label41.Text = "Audit Year"
    '
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(438, 212)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(32, 22)
    Me.TxtDist.TabIndex = 18
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.Location = New System.Drawing.Point(387, 216)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(45, 14)
    Me.Label42.TabIndex = 46
    Me.Label42.Text = "District"
    '
    'LblDtPckBtr
    '
    Me.LblDtPckBtr.Location = New System.Drawing.Point(248, 184)
    Me.LblDtPckBtr.Name = "LblDtPckBtr"
    Me.LblDtPckBtr.Size = New System.Drawing.Size(72, 16)
    Me.LblDtPckBtr.TabIndex = 48
    Me.LblDtPckBtr.Text = "BTR Applied"
    '
    'DtPckBtr
    '
    Me.DtPckBtr.Checked = False
    Me.DtPckBtr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckBtr.Location = New System.Drawing.Point(320, 184)
    Me.DtPckBtr.Name = "DtPckBtr"
    Me.DtPckBtr.ShowCheckBox = True
    Me.DtPckBtr.Size = New System.Drawing.Size(96, 20)
    Me.DtPckBtr.TabIndex = 14
    '
    'ChkDnbtr
    '
    Me.ChkDnbtr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkDnbtr.Location = New System.Drawing.Point(432, 184)
    Me.ChkDnbtr.Name = "ChkDnbtr"
    Me.ChkDnbtr.Size = New System.Drawing.Size(72, 16)
    Me.ChkDnbtr.TabIndex = 15
    Me.ChkDnbtr.Text = "Denied?"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.RbCatExempt)
    Me.GroupBox4.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox4.Location = New System.Drawing.Point(577, 160)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(160, 48)
    Me.GroupBox4.TabIndex = 152
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Category"
    '
    'RbCatExempt
    '
    Me.RbCatExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbCatExempt.ForeColor = System.Drawing.Color.Black
    Me.RbCatExempt.Location = New System.Drawing.Point(88, 16)
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
    'LnkBusty
    '
    Me.LnkBusty.Location = New System.Drawing.Point(16, 184)
    Me.LnkBusty.Name = "LnkBusty"
    Me.LnkBusty.Size = New System.Drawing.Size(80, 16)
    Me.LnkBusty.TabIndex = 153
    Me.LnkBusty.TabStop = True
    Me.LnkBusty.Text = "Business Type"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblBaaNet)
    Me.GroupBox2.Controls.Add(Me.Label12)
    Me.GroupBox2.Controls.Add(Me.LblNet)
    Me.GroupBox2.Controls.Add(Me.Label34)
    Me.GroupBox2.Controls.Add(Me.LblExempt)
    Me.GroupBox2.Controls.Add(Me.LblGross)
    Me.GroupBox2.Controls.Add(Me.LblBaa)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.Label29)
    Me.GroupBox2.Controls.Add(Me.Label28)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(585, 40)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(152, 112)
    Me.GroupBox2.TabIndex = 154
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
    '
    'LblBaaNet
    '
    Me.LblBaaNet.BackColor = System.Drawing.Color.Aqua
    Me.LblBaaNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaaNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaaNet.Location = New System.Drawing.Point(79, 86)
    Me.LblBaaNet.Name = "LblBaaNet"
    Me.LblBaaNet.Size = New System.Drawing.Size(64, 16)
    Me.LblBaaNet.TabIndex = 23
    Me.LblBaaNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label12
    '
    Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label12.Location = New System.Drawing.Point(8, 88)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(48, 16)
    Me.Label12.TabIndex = 22
    Me.Label12.Text = "BAA Net"
    '
    'LblNet
    '
    Me.LblNet.BackColor = System.Drawing.Color.Aqua
    Me.LblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblNet.Location = New System.Drawing.Point(79, 46)
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
    Me.LblExempt.BackColor = System.Drawing.Color.Aqua
    Me.LblExempt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblExempt.Location = New System.Drawing.Point(79, 30)
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
    Me.LblGross.Location = New System.Drawing.Point(79, 14)
    Me.LblGross.Name = "LblGross"
    Me.LblGross.Size = New System.Drawing.Size(64, 16)
    Me.LblGross.TabIndex = 18
    Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblBaa
    '
    Me.LblBaa.BackColor = System.Drawing.Color.Aqua
    Me.LblBaa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblBaa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBaa.Location = New System.Drawing.Point(79, 70)
    Me.LblBaa.Name = "LblBaa"
    Me.LblBaa.Size = New System.Drawing.Size(64, 16)
    Me.LblBaa.TabIndex = 17
    Me.LblBaa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(65, 14)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Exemption"
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
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(8, 72)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(40, 16)
    Me.Label28.TabIndex = 14
    Me.Label28.Text = "B.A.A"
    '
    'BtnNext
    '
    Me.BtnNext.ForeColor = System.Drawing.Color.Black
    Me.BtnNext.Location = New System.Drawing.Point(677, 5)
    Me.BtnNext.Name = "BtnNext"
    Me.BtnNext.Size = New System.Drawing.Size(60, 24)
    Me.BtnNext.TabIndex = 174
    Me.BtnNext.Text = "&Next"
    '
    'BtnPrevious
    '
    Me.BtnPrevious.ForeColor = System.Drawing.Color.Black
    Me.BtnPrevious.Location = New System.Drawing.Point(611, 5)
    Me.BtnPrevious.Name = "BtnPrevious"
    Me.BtnPrevious.Size = New System.Drawing.Size(60, 24)
    Me.BtnPrevious.TabIndex = 173
    Me.BtnPrevious.Text = "&Previous"
    '
    'LblTaxExempt
    '
    Me.LblTaxExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTaxExempt.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblTaxExempt.Location = New System.Drawing.Point(485, 66)
    Me.LblTaxExempt.Name = "LblTaxExempt"
    Me.LblTaxExempt.Size = New System.Drawing.Size(94, 20)
    Me.LblTaxExempt.TabIndex = 197
    Me.LblTaxExempt.Text = "Tax Exempt"
    Me.LblTaxExempt.Visible = False
    '
    'LblBeforeCC
    '
    Me.LblBeforeCC.AutoSize = True
    Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblBeforeCC.Location = New System.Drawing.Point(453, 47)
    Me.LblBeforeCC.Name = "LblBeforeCC"
    Me.LblBeforeCC.Size = New System.Drawing.Size(119, 15)
    Me.LblBeforeCC.TabIndex = 200
    Me.LblBeforeCC.Text = "Before C/C #####"
    Me.LblBeforeCC.TextAlign = System.Drawing.ContentAlignment.TopRight
    Me.LblBeforeCC.Visible = False
    '
    'LblYear
    '
    Me.LblYear.BackColor = System.Drawing.Color.Aqua
    Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblYear.Location = New System.Drawing.Point(169, 18)
    Me.LblYear.Name = "LblYear"
    Me.LblYear.Size = New System.Drawing.Size(31, 16)
    Me.LblYear.TabIndex = 201
    Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'BtnUp
    '
    Me.BtnUp.ForeColor = System.Drawing.Color.Black
    Me.BtnUp.Location = New System.Drawing.Point(265, 14)
    Me.BtnUp.Name = "BtnUp"
    Me.BtnUp.Size = New System.Drawing.Size(51, 24)
    Me.BtnUp.TabIndex = 206
    Me.BtnUp.Text = "+Year"
    '
    'BtnDown
    '
    Me.BtnDown.ForeColor = System.Drawing.Color.Black
    Me.BtnDown.Location = New System.Drawing.Point(206, 14)
    Me.BtnDown.Name = "BtnDown"
    Me.BtnDown.Size = New System.Drawing.Size(53, 24)
    Me.BtnDown.TabIndex = 205
    Me.BtnDown.Text = "-Year"
    '
    'FrmTAD05PP
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(744, 502)
    Me.Controls.Add(Me.BtnUp)
    Me.Controls.Add(Me.BtnDown)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblBeforeCC)
    Me.Controls.Add(Me.LblTaxExempt)
    Me.Controls.Add(Me.BtnNext)
    Me.Controls.Add(Me.BtnPrevious)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.LnkBusty)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.ChkDnbtr)
    Me.Controls.Add(Me.DtPckBtr)
    Me.Controls.Add(Me.LblDtPckBtr)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label42)
    Me.Controls.Add(Me.TxtAdyr)
    Me.Controls.Add(Me.Label41)
    Me.Controls.Add(Me.TxtPdst)
    Me.Controls.Add(Me.Label40)
    Me.Controls.Add(Me.TxtOid)
    Me.Controls.Add(Me.TxtBusty)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label5)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAD05PP"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Personal Property  Archive"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAD05PP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myTXPPRA = New TXPPRA.MyData(myDBConnect)
    myTXBAA = New TXBAA.MyData(myDBConnect)
    myTXBUSTY = New TXBUSTY.MyData(myDBConnect)
    WrkAdjYear = 0
    LoadForm()
  End Sub

  Private Sub FrmTAD05PP_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAD05B.FormatGrid(True, False, False)
    MyFrmTAD05B.Show()
    'Memory Cleanup
    myTXPPRA = Nothing
    myTXBAA = Nothing
    myTXBUSTY = Nothing
    MyFrmTAD05PP = Nothing
  End Sub
  Public Sub LoadForm()
    LoadScrn = True
    If WrkFastPath Then
      BtnPrevious.Visible = False
      BtnNext.Visible = False
    End If

    'Fill the dataset with the data
    TxtListNo.Text = WrkListNo
    TxtListNo.ReadOnly = True
    LblYear.Text = WrkYear
    Select Case WrkAdjYear
      Case <> 0
        myTXPPRA.GetOneRecordP(WrkListNo, WrkYear + WrkAdjYear)
        If myTXPPRA.RecordNotFound Then
          WrkAdjYear = 0
        End If
      Case Else
    End Select
    LblYear.Text = WrkYear + WrkAdjYear
    myTXPPRA.GetOneRecordP(WrkListNo, MyUtils.CnvSng(LblYear.Text))
    If myTXPPRA.RecordNotFound Then
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If

    With myTXPPRA
      If ._CAT = "5" Then
        RbCatTaxable.Checked = True
        LblTaxExempt.Visible = False
      Else
        RbCatExempt.Checked = True
        LblTaxExempt.Visible = True
      End If
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
      TxtLocNo.Text = Trim(._LOCNo)
      TxtLoc.Text = Trim(._LOC)
      TxtPdst.Text = ._PDST
      TxtOid.Text = Trim(._OID)
      TxtDist.Text = ._DIST
      TxtBusty.Text = Trim(._BUSTY)
      TxtAdyr.Text = ._ADYR
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
      TxtUnit1.Text = ._UNIT1
      TxtAssmt1.Text = ._ASS1
      TxtUnit2.Text = ._UNIT2
      TxtAssmt2.Text = ._ASS2
      TxtUnit3.Text = ._UNIT3
      TxtAssmt3.Text = ._ASS3
      TxtUnit4.Text = ._UNIT4
      TxtAssmt4.Text = ._ASS4
      TxtUnit5.Text = ._UNIT5
      TxtAssmt5.Text = ._ASS5
      TxtUnit6.Text = ._UNIT6
      TxtAssmt6.Text = ._ASS6
      TxtUnit7.Text = ._UNIT7
      TxtAssmt7.Text = ._ASS7
      TxtUnit8.Text = ._UNIT8
      TxtAssmt8.Text = ._ASS8
      TxtUnit9.Text = ._UNIT9
      TxtAssmt9.Text = ._ASS9
      TxtUnit10.Text = ._UNITA
      TxtAssmt10.Text = ._ASS10
      TxtExam1.Text = ._EXAM1
      TxtExam2.Text = ._EXAM2
      TxtExam3.Text = ._EXAM3
      TxtExam4.Text = ._EXAM4
      TxtExam5.Text = ._EXAM5
      LblGross.Text = ._GROSS
      LblExempt.Text = ._EXAM1 + ._EXAM2 + ._EXAM3 + ._EXAM4 + ._EXAM5
      LblNet.Text = ._NET
    End With
    'BTR
    myTXBAA.GetOneRecordP(WrkListNo, WrkType, WrkYear)
    If Not myTXBAA.RecordNotFound Then
      With myTXBAA
        TxtBaa1.Text = MyUtils.CnvSng(TxtAssmt1.Text) + ._BASS1
        TxtBaa2.Text = MyUtils.CnvSng(TxtAssmt2.Text) + ._BASS2
        TxtBaa3.Text = MyUtils.CnvSng(TxtAssmt3.Text) + ._BASS3
        TxtBaa4.Text = MyUtils.CnvSng(TxtAssmt4.Text) + ._BASS4
        TxtBaa5.Text = MyUtils.CnvSng(TxtAssmt5.Text) + ._BASS5
        TxtBaa6.Text = MyUtils.CnvSng(TxtAssmt6.Text) + ._BASS6
        TxtBaa7.Text = MyUtils.CnvSng(TxtAssmt7.Text) + ._BASS7
        TxtBaa8.Text = MyUtils.CnvSng(TxtAssmt8.Text) + ._BASS8
        TxtBaa9.Text = MyUtils.CnvSng(TxtAssmt9.Text) + ._BASS9
        TxtBaa10.Text = MyUtils.CnvSng(TxtAssmt10.Text) + ._BASSA
      End With
    Else
      TxtBaa1.Text = 0
      TxtBaa2.Text = 0
      TxtBaa3.Text = 0
      TxtBaa4.Text = 0
      TxtBaa5.Text = 0
      TxtBaa6.Text = 0
      TxtBaa7.Text = 0
      TxtBaa8.Text = 0
      TxtBaa9.Text = 0
      TxtBaa10.Text = 0
    End If
    CalcBTR()

    With myTXPPRA
      'Assessment Property Codes
      TxtCode1.Text = ._CODE1
      TxtCode2.Text = ._CODE2
      TxtCode3.Text = ._CODE3
      TxtCode4.Text = ._CODE4
      TxtCode5.Text = ._CODE5
      TxtCode6.Text = ._CODE6
      TxtCode7.Text = ._CODE7
      TxtCode8.Text = ._CODE8
      TxtCode9.Text = ._CODE9
      TxtCode10.Text = ._CODEA
      SetCode1Tip()
      SetCode2Tip()
      SetCode3Tip()
      SetCode4Tip()
      SetCode5Tip()
      SetCode6Tip()
      SetCode7Tip()
      SetCode8Tip()
      SetCode9Tip()
      SetCode10Tip()
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
      'BUSTY
      SetBustyTip()
    End With
    LoadScrn = False
  End Sub
  Private Sub FrmTAD05PP_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD05.SbpScreen.Text = "TAD05PP"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub CalcAssmt()
    Dim TotGross As Long
    Dim TotExempt As Long

    TotGross = MyUtils.CnvSng(TxtAssmt1.Text) + MyUtils.CnvSng(TxtAssmt2.Text) + MyUtils.CnvSng(TxtAssmt3.Text) +
      MyUtils.CnvSng(TxtAssmt4.Text) + MyUtils.CnvSng(TxtAssmt5.Text) + MyUtils.CnvSng(TxtAssmt6.Text) + MyUtils.CnvSng(TxtAssmt7.Text) +
      MyUtils.CnvSng(TxtAssmt8.Text) + MyUtils.CnvSng(TxtAssmt9.Text) + MyUtils.CnvSng(TxtAssmt10.Text)
    TotExempt = MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) + MyUtils.CnvSng(TxtExam4.Text) + MyUtils.CnvSng(TxtExam5.Text)
    LblGross.Text = TotGross
    LblExempt.Text = TotExempt
    LblNet.Text = TotGross - TotExempt
    LblBaaNet.Text = TotGross - TotExempt + MyUtils.CnvSng(LblBaa.Text)
  End Sub
  Private Sub CalcBTR()
    Dim TotBTR As Long

    TotBTR = MyUtils.CnvSng(TxtBaa1.Text) + MyUtils.CnvSng(TxtBaa2.Text) + MyUtils.CnvSng(TxtBaa3.Text) +
      MyUtils.CnvSng(TxtBaa4.Text) + MyUtils.CnvSng(TxtBaa5.Text) + MyUtils.CnvSng(TxtBaa6.Text) + MyUtils.CnvSng(TxtBaa7.Text) +
      MyUtils.CnvSng(TxtBaa8.Text) + MyUtils.CnvSng(TxtBaa9.Text) + MyUtils.CnvSng(TxtBaa10.Text)
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
  Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles BtnDown.Click
    WrkAdjYear = WrkAdjYear - 1
    LoadForm()
  End Sub
  Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles BtnUp.Click
    WrkAdjYear = WrkAdjYear + 1
    LoadForm()
  End Sub
  Private Sub LnkCode1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode1.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode1.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode1.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode2.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode2.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode2.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode3.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode3.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode3.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode4.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode4.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode4.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode5.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode5.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode5.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode6.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode6.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode6.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode7.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode7.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode7.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode8.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode8.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode8.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode9.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode9.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode9.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkCode10_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkCode10.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkType = WrkType
    MyFrmListCodes.WrkFieldNo = LnkCode10.Text
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtCode10.Text)
    MyFrmListCodes.Show()
  End Sub
  Private Sub LnkExempt1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkExempt1.LinkClicked
    MyFrmListExemption = New FrmListExemption
    MyFrmListExemption.MdiParent = Me.ParentForm
    MyFrmListExemption.WrkType = WrkType
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
  Private Sub TxtCode1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode1.Leave
    SetCode1Tip()
  End Sub
  Private Sub TxtCode2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode2.Leave
    SetCode2Tip()
  End Sub
  Private Sub TxtCode3_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode3.Leave
    SetCode3Tip()
  End Sub
  Private Sub TxtCode4_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode4.Leave
    SetCode4Tip()
  End Sub
  Private Sub TxtCode5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode5.Leave
    SetCode5Tip()
  End Sub
  Private Sub TxtCode6_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode6.Leave
    SetCode6Tip()
  End Sub
  Private Sub TxtCode7_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode7.Leave
    SetCode7Tip()
  End Sub
  Private Sub TxtCode8_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode8.Leave
    SetCode8Tip()
  End Sub
  Private Sub TxtCode9_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode9.Leave
    SetCode9Tip()
  End Sub
  Private Sub TxtCode10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCode10.Leave
    SetCode10Tip()
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
  Private Sub LnkBusty_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkBusty.LinkClicked
    MyfrmListBusty = New FrmListBusty
    MyfrmListBusty.MdiParent = Me.ParentForm
    MyfrmListBusty.WrkCode = TxtBusty.Text
    MyfrmListBusty.Show()
  End Sub
  Private Sub SetCode1Tip()
    Dim WrkDesc As String

    If Not TxtCode1.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode1.Text), WrkType)
    Ttp1.SetToolTip(TxtCode1, WrkDesc)
  End Sub
  Private Sub SetCode2Tip()
    Dim WrkDesc As String

    If Not TxtCode2.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode2.Text), WrkType)
    Ttp1.SetToolTip(TxtCode2, WrkDesc)
  End Sub
  Private Sub SetCode3Tip()
    Dim WrkDesc As String

    If Not TxtCode3.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode3.Text), WrkType)
    Ttp1.SetToolTip(TxtCode3, WrkDesc)
  End Sub
  Private Sub SetCode4Tip()
    Dim WrkDesc As String

    If Not TxtCode4.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode4.Text), WrkType)
    Ttp1.SetToolTip(TxtCode4, WrkDesc)
  End Sub
  Private Sub SetCode5Tip()
    Dim WrkDesc As String

    If Not TxtCode5.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode5.Text), WrkType)
    Ttp1.SetToolTip(TxtCode5, WrkDesc)
  End Sub
  Private Sub SetCode6Tip()
    Dim WrkDesc As String

    If Not TxtCode6.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode6.Text), WrkType)
    Ttp1.SetToolTip(TxtCode6, WrkDesc)
  End Sub
  Private Sub SetCode7Tip()
    Dim WrkDesc As String

    If Not TxtCode7.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode7.Text), WrkType)
    Ttp1.SetToolTip(TxtCode7, WrkDesc)
  End Sub
  Private Sub SetCode8Tip()
    Dim WrkDesc As String

    If Not TxtCode8.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode8.Text), WrkType)
    Ttp1.SetToolTip(TxtCode8, WrkDesc)
  End Sub
  Private Sub SetCode9Tip()
    Dim WrkDesc As String

    If Not TxtCode9.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode9.Text), WrkType)
    Ttp1.SetToolTip(TxtCode9, WrkDesc)
  End Sub
  Private Sub SetCode10Tip()
    Dim WrkDesc As String

    If Not TxtCode10.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCodeDesc(MyUtils.CnvSng(TxtCode10.Text), WrkType)
    Ttp1.SetToolTip(TxtCode10, WrkDesc)
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
  Private Sub SetBustyTip()
    Dim WrkDesc As String

    If Not TxtBusty.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXBustyDesc(TxtBusty.Text)
    Ttp1.SetToolTip(TxtBusty, WrkDesc)
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
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPdst_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPdst.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt8.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt9.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt10.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode8.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode9.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtCode10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtCode10.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit8.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit9.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtUnit10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUnit10.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa1.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa2.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa3.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa6.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa7.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa8.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa9.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBaa10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBaa10.KeyPress
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
  Private Sub TxtAdyr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAdyr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtBusty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBusty.Leave
    SetBustyTip()
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
End Class






