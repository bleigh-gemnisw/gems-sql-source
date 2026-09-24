Public Class FrmGL102C
  Inherits System.Windows.Forms.Form
  Dim myGLFUND As GLFUND.MyData
  Dim myGLACCT As GLACCT.MyData
  Dim myGLACCTCopy As GLACCT.MyData
  Dim myGLGRUP As GLGRUP.MyData
  Friend WithEvents LnkGroup As System.Windows.Forms.LinkLabel
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtSfund As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LnkGLAcctCA As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkGLAcctAP As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnCA As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnCA As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjCA As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptCA As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndCA As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfcnAP As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnAP As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjAP As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptAP As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndAP As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndCA As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndAP As System.Windows.Forms.TextBox
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtGroup As System.Windows.Forms.TextBox
  Friend WithEvents ChkEntfn As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAccfn As System.Windows.Forms.CheckBox
  Friend WithEvents ChkAcrec As System.Windows.Forms.CheckBox
  Friend WithEvents LnkGLAcctRC As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnRC As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnRC As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjRC As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptRC As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndRC As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndRC As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcctRE As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnRE As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnRE As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjRE As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptRE As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndRE As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndRE As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcctEN As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnEN As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnEN As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjEN As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptEN As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndEN As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndEN As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcctFB As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnFB As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnFB As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjFB As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptFB As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndFB As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndFB As System.Windows.Forms.TextBox
  Friend WithEvents LnkGLAcctEC As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcnEC As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcnEC As System.Windows.Forms.TextBox
  Friend WithEvents TxtObjEC As System.Windows.Forms.TextBox
  Friend WithEvents TxtDptEC As System.Windows.Forms.TextBox
  Friend WithEvents TxtSfndEC As System.Windows.Forms.TextBox
  Friend WithEvents TxtFndEC As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents DtPckFiscEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents DtPckFiscStr As System.Windows.Forms.DateTimePicker
  Friend WrkFdnbr As Integer
  Friend WrkSfund As Integer
  Friend WrkMode As String
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.LnkGroup = New System.Windows.Forms.LinkLabel()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSfund = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LnkGLAcctEC = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnEC = New System.Windows.Forms.TextBox()
    Me.TxtFcnEC = New System.Windows.Forms.TextBox()
    Me.TxtObjEC = New System.Windows.Forms.TextBox()
    Me.TxtDptEC = New System.Windows.Forms.TextBox()
    Me.TxtSfndEC = New System.Windows.Forms.TextBox()
    Me.TxtFndEC = New System.Windows.Forms.TextBox()
    Me.LnkGLAcctRC = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnRC = New System.Windows.Forms.TextBox()
    Me.TxtFcnRC = New System.Windows.Forms.TextBox()
    Me.TxtObjRC = New System.Windows.Forms.TextBox()
    Me.TxtDptRC = New System.Windows.Forms.TextBox()
    Me.TxtSfndRC = New System.Windows.Forms.TextBox()
    Me.TxtFndRC = New System.Windows.Forms.TextBox()
    Me.LnkGLAcctRE = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnRE = New System.Windows.Forms.TextBox()
    Me.TxtFcnRE = New System.Windows.Forms.TextBox()
    Me.TxtObjRE = New System.Windows.Forms.TextBox()
    Me.TxtDptRE = New System.Windows.Forms.TextBox()
    Me.TxtSfndRE = New System.Windows.Forms.TextBox()
    Me.TxtFndRE = New System.Windows.Forms.TextBox()
    Me.LnkGLAcctEN = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnEN = New System.Windows.Forms.TextBox()
    Me.TxtFcnEN = New System.Windows.Forms.TextBox()
    Me.TxtObjEN = New System.Windows.Forms.TextBox()
    Me.TxtDptEN = New System.Windows.Forms.TextBox()
    Me.TxtSfndEN = New System.Windows.Forms.TextBox()
    Me.TxtFndEN = New System.Windows.Forms.TextBox()
    Me.LnkGLAcctFB = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnFB = New System.Windows.Forms.TextBox()
    Me.TxtFcnFB = New System.Windows.Forms.TextBox()
    Me.TxtObjFB = New System.Windows.Forms.TextBox()
    Me.TxtDptFB = New System.Windows.Forms.TextBox()
    Me.TxtSfndFB = New System.Windows.Forms.TextBox()
    Me.TxtFndFB = New System.Windows.Forms.TextBox()
    Me.LnkGLAcctCA = New System.Windows.Forms.LinkLabel()
    Me.LnkGLAcctAP = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcnCA = New System.Windows.Forms.TextBox()
    Me.TxtFcnCA = New System.Windows.Forms.TextBox()
    Me.TxtObjCA = New System.Windows.Forms.TextBox()
    Me.TxtDptCA = New System.Windows.Forms.TextBox()
    Me.TxtSfndCA = New System.Windows.Forms.TextBox()
    Me.TxtSfcnAP = New System.Windows.Forms.TextBox()
    Me.TxtFcnAP = New System.Windows.Forms.TextBox()
    Me.TxtObjAP = New System.Windows.Forms.TextBox()
    Me.TxtDptAP = New System.Windows.Forms.TextBox()
    Me.TxtSfndAP = New System.Windows.Forms.TextBox()
    Me.TxtFndCA = New System.Windows.Forms.TextBox()
    Me.TxtFndAP = New System.Windows.Forms.TextBox()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtGroup = New System.Windows.Forms.TextBox()
    Me.ChkEntfn = New System.Windows.Forms.CheckBox()
    Me.ChkAccfn = New System.Windows.Forms.CheckBox()
    Me.ChkAcrec = New System.Windows.Forms.CheckBox()
    Me.DtPckFiscStr = New System.Windows.Forms.DateTimePicker()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckFiscEnd = New System.Windows.Forms.DateTimePicker()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(123, 42)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(60, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Description"
    '
    'TxtDesc
    '
    Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDesc.Location = New System.Drawing.Point(191, 38)
    Me.TxtDesc.MaxLength = 30
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.Size = New System.Drawing.Size(282, 20)
    Me.TxtDesc.TabIndex = 2
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Location = New System.Drawing.Point(69, 12)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 20)
    Me.TxtFund.TabIndex = 0
    '
    'LnkGroup
    '
    Me.LnkGroup.AutoSize = True
    Me.LnkGroup.Location = New System.Drawing.Point(12, 77)
    Me.LnkGroup.Name = "LnkGroup"
    Me.LnkGroup.Size = New System.Drawing.Size(58, 13)
    Me.LnkGroup.TabIndex = 29
    Me.LnkGroup.TabStop = True
    Me.LnkGroup.Text = "Fund Type"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(31, 13)
    Me.Label2.TabIndex = 30
    Me.Label2.Text = "Fund"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 41)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 32
    Me.Label3.Text = "Sub Fund"
    '
    'TxtSfund
    '
    Me.TxtSfund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfund.Location = New System.Drawing.Point(69, 38)
    Me.TxtSfund.MaxLength = 3
    Me.TxtSfund.Name = "TxtSfund"
    Me.TxtSfund.Size = New System.Drawing.Size(32, 20)
    Me.TxtSfund.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctEC)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnEC)
    Me.GroupBox1.Controls.Add(Me.TxtFcnEC)
    Me.GroupBox1.Controls.Add(Me.TxtObjEC)
    Me.GroupBox1.Controls.Add(Me.TxtDptEC)
    Me.GroupBox1.Controls.Add(Me.TxtSfndEC)
    Me.GroupBox1.Controls.Add(Me.TxtFndEC)
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctRC)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnRC)
    Me.GroupBox1.Controls.Add(Me.TxtFcnRC)
    Me.GroupBox1.Controls.Add(Me.TxtObjRC)
    Me.GroupBox1.Controls.Add(Me.TxtDptRC)
    Me.GroupBox1.Controls.Add(Me.TxtSfndRC)
    Me.GroupBox1.Controls.Add(Me.TxtFndRC)
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctRE)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnRE)
    Me.GroupBox1.Controls.Add(Me.TxtFcnRE)
    Me.GroupBox1.Controls.Add(Me.TxtObjRE)
    Me.GroupBox1.Controls.Add(Me.TxtDptRE)
    Me.GroupBox1.Controls.Add(Me.TxtSfndRE)
    Me.GroupBox1.Controls.Add(Me.TxtFndRE)
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctEN)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnEN)
    Me.GroupBox1.Controls.Add(Me.TxtFcnEN)
    Me.GroupBox1.Controls.Add(Me.TxtObjEN)
    Me.GroupBox1.Controls.Add(Me.TxtDptEN)
    Me.GroupBox1.Controls.Add(Me.TxtSfndEN)
    Me.GroupBox1.Controls.Add(Me.TxtFndEN)
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctFB)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnFB)
    Me.GroupBox1.Controls.Add(Me.TxtFcnFB)
    Me.GroupBox1.Controls.Add(Me.TxtObjFB)
    Me.GroupBox1.Controls.Add(Me.TxtDptFB)
    Me.GroupBox1.Controls.Add(Me.TxtSfndFB)
    Me.GroupBox1.Controls.Add(Me.TxtFndFB)
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctCA)
    Me.GroupBox1.Controls.Add(Me.LnkGLAcctAP)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnCA)
    Me.GroupBox1.Controls.Add(Me.TxtFcnCA)
    Me.GroupBox1.Controls.Add(Me.TxtObjCA)
    Me.GroupBox1.Controls.Add(Me.TxtDptCA)
    Me.GroupBox1.Controls.Add(Me.TxtSfndCA)
    Me.GroupBox1.Controls.Add(Me.TxtSfcnAP)
    Me.GroupBox1.Controls.Add(Me.TxtFcnAP)
    Me.GroupBox1.Controls.Add(Me.TxtObjAP)
    Me.GroupBox1.Controls.Add(Me.TxtDptAP)
    Me.GroupBox1.Controls.Add(Me.TxtSfndAP)
    Me.GroupBox1.Controls.Add(Me.TxtFndCA)
    Me.GroupBox1.Controls.Add(Me.TxtFndAP)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 133)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(423, 213)
    Me.GroupBox1.TabIndex = 9
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Control Accounts"
    '
    'LnkGLAcctEC
    '
    Me.LnkGLAcctEC.AutoSize = True
    Me.LnkGLAcctEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctEC.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctEC.Location = New System.Drawing.Point(6, 186)
    Me.LnkGLAcctEC.Name = "LnkGLAcctEC"
    Me.LnkGLAcctEC.Size = New System.Drawing.Size(99, 13)
    Me.LnkGLAcctEC.TabIndex = 40
    Me.LnkGLAcctEC.TabStop = True
    Me.LnkGLAcctEC.Text = "Expenditure Control"
    '
    'TxtSfcnEC
    '
    Me.TxtSfcnEC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnEC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnEC.Location = New System.Drawing.Point(364, 184)
    Me.TxtSfcnEC.MaxLength = 4
    Me.TxtSfcnEC.Name = "TxtSfcnEC"
    Me.TxtSfcnEC.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnEC.TabIndex = 46
    '
    'TxtFcnEC
    '
    Me.TxtFcnEC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnEC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnEC.Location = New System.Drawing.Point(313, 184)
    Me.TxtFcnEC.MaxLength = 4
    Me.TxtFcnEC.Name = "TxtFcnEC"
    Me.TxtFcnEC.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnEC.TabIndex = 45
    '
    'TxtObjEC
    '
    Me.TxtObjEC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjEC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjEC.Location = New System.Drawing.Point(277, 184)
    Me.TxtObjEC.MaxLength = 3
    Me.TxtObjEC.Name = "TxtObjEC"
    Me.TxtObjEC.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjEC.TabIndex = 44
    '
    'TxtDptEC
    '
    Me.TxtDptEC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptEC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptEC.Location = New System.Drawing.Point(226, 184)
    Me.TxtDptEC.MaxLength = 4
    Me.TxtDptEC.Name = "TxtDptEC"
    Me.TxtDptEC.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptEC.TabIndex = 43
    '
    'TxtSfndEC
    '
    Me.TxtSfndEC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndEC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndEC.Location = New System.Drawing.Point(188, 184)
    Me.TxtSfndEC.MaxLength = 3
    Me.TxtSfndEC.Name = "TxtSfndEC"
    Me.TxtSfndEC.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndEC.TabIndex = 42
    '
    'TxtFndEC
    '
    Me.TxtFndEC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndEC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndEC.Location = New System.Drawing.Point(150, 184)
    Me.TxtFndEC.MaxLength = 3
    Me.TxtFndEC.Name = "TxtFndEC"
    Me.TxtFndEC.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndEC.TabIndex = 41
    '
    'LnkGLAcctRC
    '
    Me.LnkGLAcctRC.AutoSize = True
    Me.LnkGLAcctRC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctRC.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctRC.Location = New System.Drawing.Point(6, 160)
    Me.LnkGLAcctRC.Name = "LnkGLAcctRC"
    Me.LnkGLAcctRC.Size = New System.Drawing.Size(87, 13)
    Me.LnkGLAcctRC.TabIndex = 33
    Me.LnkGLAcctRC.TabStop = True
    Me.LnkGLAcctRC.Text = "Revenue Control"
    '
    'TxtSfcnRC
    '
    Me.TxtSfcnRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnRC.Location = New System.Drawing.Point(364, 158)
    Me.TxtSfcnRC.MaxLength = 4
    Me.TxtSfcnRC.Name = "TxtSfcnRC"
    Me.TxtSfcnRC.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnRC.TabIndex = 39
    '
    'TxtFcnRC
    '
    Me.TxtFcnRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnRC.Location = New System.Drawing.Point(313, 158)
    Me.TxtFcnRC.MaxLength = 4
    Me.TxtFcnRC.Name = "TxtFcnRC"
    Me.TxtFcnRC.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnRC.TabIndex = 38
    '
    'TxtObjRC
    '
    Me.TxtObjRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjRC.Location = New System.Drawing.Point(277, 158)
    Me.TxtObjRC.MaxLength = 3
    Me.TxtObjRC.Name = "TxtObjRC"
    Me.TxtObjRC.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjRC.TabIndex = 37
    '
    'TxtDptRC
    '
    Me.TxtDptRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptRC.Location = New System.Drawing.Point(226, 158)
    Me.TxtDptRC.MaxLength = 4
    Me.TxtDptRC.Name = "TxtDptRC"
    Me.TxtDptRC.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptRC.TabIndex = 36
    '
    'TxtSfndRC
    '
    Me.TxtSfndRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndRC.Location = New System.Drawing.Point(188, 158)
    Me.TxtSfndRC.MaxLength = 3
    Me.TxtSfndRC.Name = "TxtSfndRC"
    Me.TxtSfndRC.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndRC.TabIndex = 35
    '
    'TxtFndRC
    '
    Me.TxtFndRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndRC.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndRC.Location = New System.Drawing.Point(150, 158)
    Me.TxtFndRC.MaxLength = 3
    Me.TxtFndRC.Name = "TxtFndRC"
    Me.TxtFndRC.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndRC.TabIndex = 34
    '
    'LnkGLAcctRE
    '
    Me.LnkGLAcctRE.AutoSize = True
    Me.LnkGLAcctRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctRE.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctRE.Location = New System.Drawing.Point(6, 132)
    Me.LnkGLAcctRE.Name = "LnkGLAcctRE"
    Me.LnkGLAcctRE.Size = New System.Drawing.Size(131, 13)
    Me.LnkGLAcctRE.TabIndex = 26
    Me.LnkGLAcctRE.TabStop = True
    Me.LnkGLAcctRE.Text = "Reserve for Encumbrance"
    '
    'TxtSfcnRE
    '
    Me.TxtSfcnRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnRE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnRE.Location = New System.Drawing.Point(364, 130)
    Me.TxtSfcnRE.MaxLength = 4
    Me.TxtSfcnRE.Name = "TxtSfcnRE"
    Me.TxtSfcnRE.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnRE.TabIndex = 32
    '
    'TxtFcnRE
    '
    Me.TxtFcnRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnRE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnRE.Location = New System.Drawing.Point(313, 130)
    Me.TxtFcnRE.MaxLength = 4
    Me.TxtFcnRE.Name = "TxtFcnRE"
    Me.TxtFcnRE.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnRE.TabIndex = 31
    '
    'TxtObjRE
    '
    Me.TxtObjRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjRE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjRE.Location = New System.Drawing.Point(277, 130)
    Me.TxtObjRE.MaxLength = 3
    Me.TxtObjRE.Name = "TxtObjRE"
    Me.TxtObjRE.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjRE.TabIndex = 30
    '
    'TxtDptRE
    '
    Me.TxtDptRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptRE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptRE.Location = New System.Drawing.Point(226, 130)
    Me.TxtDptRE.MaxLength = 4
    Me.TxtDptRE.Name = "TxtDptRE"
    Me.TxtDptRE.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptRE.TabIndex = 29
    '
    'TxtSfndRE
    '
    Me.TxtSfndRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndRE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndRE.Location = New System.Drawing.Point(188, 130)
    Me.TxtSfndRE.MaxLength = 3
    Me.TxtSfndRE.Name = "TxtSfndRE"
    Me.TxtSfndRE.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndRE.TabIndex = 28
    '
    'TxtFndRE
    '
    Me.TxtFndRE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndRE.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndRE.Location = New System.Drawing.Point(150, 130)
    Me.TxtFndRE.MaxLength = 3
    Me.TxtFndRE.Name = "TxtFndRE"
    Me.TxtFndRE.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndRE.TabIndex = 27
    '
    'LnkGLAcctEN
    '
    Me.LnkGLAcctEN.AutoSize = True
    Me.LnkGLAcctEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctEN.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctEN.Location = New System.Drawing.Point(6, 106)
    Me.LnkGLAcctEN.Name = "LnkGLAcctEN"
    Me.LnkGLAcctEN.Size = New System.Drawing.Size(73, 13)
    Me.LnkGLAcctEN.TabIndex = 19
    Me.LnkGLAcctEN.TabStop = True
    Me.LnkGLAcctEN.Text = "Encumbrance"
    '
    'TxtSfcnEN
    '
    Me.TxtSfcnEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnEN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnEN.Location = New System.Drawing.Point(364, 104)
    Me.TxtSfcnEN.MaxLength = 4
    Me.TxtSfcnEN.Name = "TxtSfcnEN"
    Me.TxtSfcnEN.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnEN.TabIndex = 25
    '
    'TxtFcnEN
    '
    Me.TxtFcnEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnEN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnEN.Location = New System.Drawing.Point(313, 104)
    Me.TxtFcnEN.MaxLength = 4
    Me.TxtFcnEN.Name = "TxtFcnEN"
    Me.TxtFcnEN.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnEN.TabIndex = 24
    '
    'TxtObjEN
    '
    Me.TxtObjEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjEN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjEN.Location = New System.Drawing.Point(277, 104)
    Me.TxtObjEN.MaxLength = 3
    Me.TxtObjEN.Name = "TxtObjEN"
    Me.TxtObjEN.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjEN.TabIndex = 23
    '
    'TxtDptEN
    '
    Me.TxtDptEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptEN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptEN.Location = New System.Drawing.Point(226, 104)
    Me.TxtDptEN.MaxLength = 4
    Me.TxtDptEN.Name = "TxtDptEN"
    Me.TxtDptEN.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptEN.TabIndex = 22
    '
    'TxtSfndEN
    '
    Me.TxtSfndEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndEN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndEN.Location = New System.Drawing.Point(188, 104)
    Me.TxtSfndEN.MaxLength = 3
    Me.TxtSfndEN.Name = "TxtSfndEN"
    Me.TxtSfndEN.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndEN.TabIndex = 21
    '
    'TxtFndEN
    '
    Me.TxtFndEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndEN.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndEN.Location = New System.Drawing.Point(150, 104)
    Me.TxtFndEN.MaxLength = 3
    Me.TxtFndEN.Name = "TxtFndEN"
    Me.TxtFndEN.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndEN.TabIndex = 20
    '
    'LnkGLAcctFB
    '
    Me.LnkGLAcctFB.AutoSize = True
    Me.LnkGLAcctFB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctFB.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctFB.Location = New System.Drawing.Point(6, 79)
    Me.LnkGLAcctFB.Name = "LnkGLAcctFB"
    Me.LnkGLAcctFB.Size = New System.Drawing.Size(73, 13)
    Me.LnkGLAcctFB.TabIndex = 12
    Me.LnkGLAcctFB.TabStop = True
    Me.LnkGLAcctFB.Text = "Fund Balance"
    '
    'TxtSfcnFB
    '
    Me.TxtSfcnFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnFB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnFB.Location = New System.Drawing.Point(364, 77)
    Me.TxtSfcnFB.MaxLength = 4
    Me.TxtSfcnFB.Name = "TxtSfcnFB"
    Me.TxtSfcnFB.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnFB.TabIndex = 18
    '
    'TxtFcnFB
    '
    Me.TxtFcnFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnFB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnFB.Location = New System.Drawing.Point(313, 77)
    Me.TxtFcnFB.MaxLength = 4
    Me.TxtFcnFB.Name = "TxtFcnFB"
    Me.TxtFcnFB.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnFB.TabIndex = 17
    '
    'TxtObjFB
    '
    Me.TxtObjFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjFB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjFB.Location = New System.Drawing.Point(277, 77)
    Me.TxtObjFB.MaxLength = 3
    Me.TxtObjFB.Name = "TxtObjFB"
    Me.TxtObjFB.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjFB.TabIndex = 16
    '
    'TxtDptFB
    '
    Me.TxtDptFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptFB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptFB.Location = New System.Drawing.Point(226, 77)
    Me.TxtDptFB.MaxLength = 4
    Me.TxtDptFB.Name = "TxtDptFB"
    Me.TxtDptFB.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptFB.TabIndex = 15
    '
    'TxtSfndFB
    '
    Me.TxtSfndFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndFB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndFB.Location = New System.Drawing.Point(188, 77)
    Me.TxtSfndFB.MaxLength = 3
    Me.TxtSfndFB.Name = "TxtSfndFB"
    Me.TxtSfndFB.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndFB.TabIndex = 14
    '
    'TxtFndFB
    '
    Me.TxtFndFB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndFB.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndFB.Location = New System.Drawing.Point(150, 77)
    Me.TxtFndFB.MaxLength = 3
    Me.TxtFndFB.Name = "TxtFndFB"
    Me.TxtFndFB.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndFB.TabIndex = 13
    '
    'LnkGLAcctCA
    '
    Me.LnkGLAcctCA.AutoSize = True
    Me.LnkGLAcctCA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctCA.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctCA.Location = New System.Drawing.Point(6, 53)
    Me.LnkGLAcctCA.Name = "LnkGLAcctCA"
    Me.LnkGLAcctCA.Size = New System.Drawing.Size(74, 13)
    Me.LnkGLAcctCA.TabIndex = 6
    Me.LnkGLAcctCA.TabStop = True
    Me.LnkGLAcctCA.Text = "Cash Account"
    '
    'LnkGLAcctAP
    '
    Me.LnkGLAcctAP.AutoSize = True
    Me.LnkGLAcctAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcctAP.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcctAP.Location = New System.Drawing.Point(6, 29)
    Me.LnkGLAcctAP.Name = "LnkGLAcctAP"
    Me.LnkGLAcctAP.Size = New System.Drawing.Size(93, 13)
    Me.LnkGLAcctAP.TabIndex = 0
    Me.LnkGLAcctAP.TabStop = True
    Me.LnkGLAcctAP.Text = "Accounts Payable"
    '
    'TxtSfcnCA
    '
    Me.TxtSfcnCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnCA.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnCA.Location = New System.Drawing.Point(364, 51)
    Me.TxtSfcnCA.MaxLength = 4
    Me.TxtSfcnCA.Name = "TxtSfcnCA"
    Me.TxtSfcnCA.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnCA.TabIndex = 11
    '
    'TxtFcnCA
    '
    Me.TxtFcnCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnCA.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnCA.Location = New System.Drawing.Point(313, 51)
    Me.TxtFcnCA.MaxLength = 4
    Me.TxtFcnCA.Name = "TxtFcnCA"
    Me.TxtFcnCA.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnCA.TabIndex = 10
    '
    'TxtObjCA
    '
    Me.TxtObjCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjCA.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjCA.Location = New System.Drawing.Point(277, 51)
    Me.TxtObjCA.MaxLength = 3
    Me.TxtObjCA.Name = "TxtObjCA"
    Me.TxtObjCA.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjCA.TabIndex = 9
    '
    'TxtDptCA
    '
    Me.TxtDptCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptCA.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptCA.Location = New System.Drawing.Point(226, 51)
    Me.TxtDptCA.MaxLength = 4
    Me.TxtDptCA.Name = "TxtDptCA"
    Me.TxtDptCA.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptCA.TabIndex = 8
    '
    'TxtSfndCA
    '
    Me.TxtSfndCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndCA.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndCA.Location = New System.Drawing.Point(188, 51)
    Me.TxtSfndCA.MaxLength = 3
    Me.TxtSfndCA.Name = "TxtSfndCA"
    Me.TxtSfndCA.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndCA.TabIndex = 7
    '
    'TxtSfcnAP
    '
    Me.TxtSfcnAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcnAP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcnAP.Location = New System.Drawing.Point(364, 25)
    Me.TxtSfcnAP.MaxLength = 4
    Me.TxtSfcnAP.Name = "TxtSfcnAP"
    Me.TxtSfcnAP.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcnAP.TabIndex = 5
    '
    'TxtFcnAP
    '
    Me.TxtFcnAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcnAP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcnAP.Location = New System.Drawing.Point(313, 25)
    Me.TxtFcnAP.MaxLength = 4
    Me.TxtFcnAP.Name = "TxtFcnAP"
    Me.TxtFcnAP.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcnAP.TabIndex = 4
    '
    'TxtObjAP
    '
    Me.TxtObjAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObjAP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObjAP.Location = New System.Drawing.Point(277, 25)
    Me.TxtObjAP.MaxLength = 3
    Me.TxtObjAP.Name = "TxtObjAP"
    Me.TxtObjAP.Size = New System.Drawing.Size(32, 22)
    Me.TxtObjAP.TabIndex = 3
    '
    'TxtDptAP
    '
    Me.TxtDptAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDptAP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDptAP.Location = New System.Drawing.Point(226, 25)
    Me.TxtDptAP.MaxLength = 4
    Me.TxtDptAP.Name = "TxtDptAP"
    Me.TxtDptAP.Size = New System.Drawing.Size(45, 22)
    Me.TxtDptAP.TabIndex = 2
    '
    'TxtSfndAP
    '
    Me.TxtSfndAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfndAP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfndAP.Location = New System.Drawing.Point(188, 25)
    Me.TxtSfndAP.MaxLength = 3
    Me.TxtSfndAP.Name = "TxtSfndAP"
    Me.TxtSfndAP.Size = New System.Drawing.Size(32, 22)
    Me.TxtSfndAP.TabIndex = 1
    '
    'TxtFndCA
    '
    Me.TxtFndCA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndCA.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndCA.Location = New System.Drawing.Point(150, 51)
    Me.TxtFndCA.MaxLength = 3
    Me.TxtFndCA.Name = "TxtFndCA"
    Me.TxtFndCA.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndCA.TabIndex = 6
    '
    'TxtFndAP
    '
    Me.TxtFndAP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFndAP.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFndAP.Location = New System.Drawing.Point(150, 25)
    Me.TxtFndAP.MaxLength = 3
    Me.TxtFndAP.Name = "TxtFndAP"
    Me.TxtFndAP.Size = New System.Drawing.Size(32, 22)
    Me.TxtFndAP.TabIndex = 0
    '
    'TxtGroup
    '
    Me.TxtGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtGroup.Location = New System.Drawing.Point(79, 74)
    Me.TxtGroup.MaxLength = 2
    Me.TxtGroup.Name = "TxtGroup"
    Me.TxtGroup.Size = New System.Drawing.Size(22, 20)
    Me.TxtGroup.TabIndex = 4
    '
    'ChkEntfn
    '
    Me.ChkEntfn.AutoSize = True
    Me.ChkEntfn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkEntfn.Location = New System.Drawing.Point(15, 100)
    Me.ChkEntfn.Name = "ChkEntfn"
    Me.ChkEntfn.Size = New System.Drawing.Size(79, 17)
    Me.ChkEntfn.TabIndex = 5
    Me.ChkEntfn.Text = "Enterprise?"
    Me.ChkEntfn.UseVisualStyleBackColor = True
    '
    'ChkAccfn
    '
    Me.ChkAccfn.AutoSize = True
    Me.ChkAccfn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAccfn.Location = New System.Drawing.Point(126, 100)
    Me.ChkAccfn.Name = "ChkAccfn"
    Me.ChkAccfn.Size = New System.Drawing.Size(68, 17)
    Me.ChkAccfn.TabIndex = 6
    Me.ChkAccfn.Text = "Accrual?"
    Me.ChkAccfn.UseVisualStyleBackColor = True
    '
    'ChkAcrec
    '
    Me.ChkAcrec.AutoSize = True
    Me.ChkAcrec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkAcrec.Location = New System.Drawing.Point(126, 64)
    Me.ChkAcrec.Name = "ChkAcrec"
    Me.ChkAcrec.Size = New System.Drawing.Size(165, 17)
    Me.ChkAcrec.TabIndex = 3
    Me.ChkAcrec.Text = "Inactivate on Ledger Report?"
    Me.ChkAcrec.UseVisualStyleBackColor = True
    '
    'DtPckFiscStr
    '
    Me.DtPckFiscStr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFiscStr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFiscStr.Location = New System.Drawing.Point(288, 87)
    Me.DtPckFiscStr.Name = "DtPckFiscStr"
    Me.DtPckFiscStr.ShowCheckBox = True
    Me.DtPckFiscStr.Size = New System.Drawing.Size(114, 20)
    Me.DtPckFiscStr.TabIndex = 7
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(223, 93)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(59, 13)
    Me.Label4.TabIndex = 165
    Me.Label4.Text = "Fiscal Start"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(223, 111)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(56, 13)
    Me.Label5.TabIndex = 167
    Me.Label5.Text = "Fiscal End"
    '
    'DtPckFiscEnd
    '
    Me.DtPckFiscEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckFiscEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckFiscEnd.Location = New System.Drawing.Point(288, 107)
    Me.DtPckFiscEnd.Name = "DtPckFiscEnd"
    Me.DtPckFiscEnd.ShowCheckBox = True
    Me.DtPckFiscEnd.Size = New System.Drawing.Size(114, 20)
    Me.DtPckFiscEnd.TabIndex = 8
    '
    'FrmGL102C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 350)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.DtPckFiscEnd)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.DtPckFiscStr)
    Me.Controls.Add(Me.ChkAcrec)
    Me.Controls.Add(Me.ChkAccfn)
    Me.Controls.Add(Me.ChkEntfn)
    Me.Controls.Add(Me.TxtGroup)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtSfund)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LnkGroup)
    Me.Controls.Add(Me.TxtFund)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGL102C"
    Me.Text = "Maintain Funds"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmGL102C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myGLFUND = New GLFUND.MyData()
    myGLACCT = New GLACCT.MyData()
    myGLACCTCopy = New GLACCT.MyData()
    myGLGRUP = New GLGRUP.MyData()
    myGLFUND.MyDBConn = myDBConnect
    myGLACCT.MyDBConn = myDBConnect
    myGLACCTCopy.MyDBConn = myDBConnect
    myGLGRUP.MyDBConn = myDBConnect
    MyFrmGL102.TBarNew.Enabled = False
    MyFrmGL102.TBarSave.Enabled = True
    MyFrmGL102.TBarCopy.Enabled = False
    MyFrmGL102.TBarPrint.Enabled = False
    If WrkFdnbr > 0 Then
      If WrkMode = "Copy" Then
        Me.Text = "Copy Fund and Create Control accounts"
        MyUtils.SetTxtReadOnly(TxtFndAP)
        MyUtils.SetTxtReadOnly(TxtFndCA)
        MyUtils.SetTxtReadOnly(TxtFndEC)
        MyUtils.SetTxtReadOnly(TxtFndEN)
        MyUtils.SetTxtReadOnly(TxtFndFB)
        MyUtils.SetTxtReadOnly(TxtFndRC)
        MyUtils.SetTxtReadOnly(TxtFndRE)
      End If
    Else
      Me.Text = "Add " & Me.Text
      MyFrmGL102.TBarDelete.Enabled = False
      Exit Sub
    End If

    myGLFUND.GetOneRecordP(WrkFdnbr, WrkSfund)
    If WrkMode = "Maintain" Then
      TxtFund.Text = WrkFdnbr
      TxtSfund.Text = WrkSfund
    End If

    If myGLFUND.RecordNotFound Then
      MyFrmGL102.TBarNew.Enabled = False
      MyFrmGL102.TBarSave.Enabled = False
      MyFrmGL102.TBarDelete.Enabled = False
      Me.ErrProv.SetError(TxtDesc, "Record not found")
      Exit Sub
    End If

    If s_chg = False And s_full = False Then    '#sec
      MyFrmGL102.TBarSave.Visible = False
    End If

    With myGLFUND
      If Trim(._ACREC) = "Y" Then
        ChkAcrec.Checked = True
      Else
        ChkAcrec.Checked = False
      End If
      If Trim(._ACCFN) = "Y" Then
        ChkAccfn.Checked = True
      Else
        ChkAccfn.Checked = False
      End If
      If Trim(._ENTFN) = "Y" Then
        ChkEntfn.Checked = True
      Else
        ChkEntfn.Checked = False
      End If
      If WrkMode = "Maintain" Then
        TxtDesc.Text = Trim(._FNDSC)
      End If
      TxtGroup.Text = ._GROUP
      TxtDptRC.Text = ._DPNBR1
      TxtDptEC.Text = ._DPNBR2
      TxtDptAP.Text = ._DPNBRA
      TxtDptCA.Text = ._DPNBRC
      TxtDptFB.Text = ._DPNBRF
      TxtDptEN.Text = ._DPNBRE
      TxtDptRE.Text = ._DPNBRR
      TxtFcnRC.Text = ._FNPGM1
      TxtFcnEC.Text = ._FNPGM2
      TxtFcnAP.Text = ._FNPGMA
      TxtFcnCA.Text = ._FNPGMC
      TxtFcnFB.Text = ._FNPGMF
      TxtFcnEN.Text = ._FNPGME
      TxtFcnRE.Text = ._FNPGMR
      If WrkMode = "Maintain" Then
        TxtFndRC.Text = ._FDNBR1
        TxtFndEC.Text = ._FDNBR2
        TxtFndAP.Text = ._FDNBRA
        TxtFndCA.Text = ._FDNBRC
        TxtFndFB.Text = ._FDNBRF
        TxtFndEN.Text = ._FDNBRE
        TxtFndRE.Text = ._FDNBRR
      End If
      TxtObjRC.Text = ._OBNBR1
      TxtObjEC.Text = ._OBNBR2
      TxtObjAP.Text = ._OBNBRA
      TxtObjCA.Text = ._OBNBRC
      TxtObjFB.Text = ._OBNBRF
      TxtObjEN.Text = ._OBNBRE
      TxtObjRE.Text = ._OBNBRR
      TxtSfcnRC.Text = ._SUBFN1
      TxtSfcnEC.Text = ._SUBFN2
      TxtSfcnAP.Text = ._SUBFNA
      TxtSfcnCA.Text = ._SUBFNC
      TxtSfcnFB.Text = ._SUBFNF
      TxtSfcnEN.Text = ._SUBFNE
      TxtSfcnRE.Text = ._SUBFNR
      TxtSfndRC.Text = ._SFUND1
      TxtSfndEC.Text = ._SFUND2
      TxtSfndAP.Text = ._SFUNDA
      TxtSfndCA.Text = ._SFUNDC
      TxtSfndFB.Text = ._SFUNDF
      TxtSfndEN.Text = ._SFUNDE
      TxtSfndRE.Text = ._SFUNDR
      If ._FSTDT > 0 Then
        DtPckFiscStr.Value = MyUtils.GetDBDateMDY(._FSTDT)
      Else
        DtPckFiscStr.Value = Date.Today
        DtPckFiscStr.Checked = False
      End If
      If ._FENDT > 0 Then
        DtPckFiscEnd.Value = MyUtils.GetDBDateMDY(._FENDT)
      Else
        DtPckFiscEnd.Value = Date.Today
        DtPckFiscEnd.Checked = False
      End If
    End With
  End Sub
  Private Sub FrmGL102C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmGL102.SbpScreen.Text = "GL102C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Private Sub FrmGL102C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmGL102.TBarNew.Enabled = True
    MyFrmGL102.TBarDelete.Enabled = False
    MyFrmGL102.TBarSave.Enabled = False
    MyFrmGL102.TBarPrint.Enabled = False
    MyFrmGL102B.FormatGrid()
    MyFrmGL102B.Show()
  End Sub
  Public Sub DeleteData()
    Dim Answer As Integer
    Answer = MsgBox("Delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Delete")
    If Answer = vbNo Then
      Exit Sub
    End If
    myGLFUND.DeleteOneRecordP()
    Me.Close()
  End Sub

  Public Sub SaveData()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    myGLFUND.GetOneRecordP(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSfund.Text))
    If WrkFdnbr = 0 Or WrkMode = "Copy" Then
      If Not myGLFUND.RecordNotFound Then
        Me.ErrProv.SetError(TxtFund, "Record already exists")
        Exit Sub
      End If
    End If
    If WrkFdnbr > 0 Then
      If WrkMode = "Copy" Then
        myGLFUND._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      End If
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        If WrkMode = "Maintain" Then
          myGLFUND.UpdateOneRecordP()
        Else
          myGLFUND.AddOneRecordP()
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      myGLFUND._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      MovetoFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myGLFUND.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If WrkMode = "Copy" Then
      CopyAcct(MyUtils.CnvSng(TxtFndAP.Text), MyUtils.CnvSng(TxtSfndAP.Text), MyUtils.CnvSng(TxtDptAP.Text),
          MyUtils.CnvSng(TxtObjAP.Text), MyUtils.CnvSng(TxtFcnAP.Text), MyUtils.CnvSng(TxtSfcnAP.Text))
      CopyAcct(MyUtils.CnvSng(TxtFndCA.Text), MyUtils.CnvSng(TxtSfndCA.Text), MyUtils.CnvSng(TxtDptCA.Text),
          MyUtils.CnvSng(TxtObjCA.Text), MyUtils.CnvSng(TxtFcnCA.Text), MyUtils.CnvSng(TxtSfcnCA.Text))
      CopyAcct(MyUtils.CnvSng(TxtFndEC.Text), MyUtils.CnvSng(TxtSfndEC.Text), MyUtils.CnvSng(TxtDptEC.Text),
          MyUtils.CnvSng(TxtObjEC.Text), MyUtils.CnvSng(TxtFcnEC.Text), MyUtils.CnvSng(TxtSfcnEC.Text))
      CopyAcct(MyUtils.CnvSng(TxtFndEN.Text), MyUtils.CnvSng(TxtSfndEN.Text), MyUtils.CnvSng(TxtDptEN.Text),
          MyUtils.CnvSng(TxtObjEN.Text), MyUtils.CnvSng(TxtFcnEN.Text), MyUtils.CnvSng(TxtSfcnEN.Text))
      CopyAcct(MyUtils.CnvSng(TxtFndFB.Text), MyUtils.CnvSng(TxtSfndFB.Text), MyUtils.CnvSng(TxtDptFB.Text),
          MyUtils.CnvSng(TxtObjFB.Text), MyUtils.CnvSng(TxtFcnFB.Text), MyUtils.CnvSng(TxtSfcnFB.Text))
      CopyAcct(MyUtils.CnvSng(TxtFndRC.Text), MyUtils.CnvSng(TxtSfndRC.Text), MyUtils.CnvSng(TxtDptRC.Text),
          MyUtils.CnvSng(TxtObjRC.Text), MyUtils.CnvSng(TxtFcnRC.Text), MyUtils.CnvSng(TxtSfcnRC.Text))
      CopyAcct(MyUtils.CnvSng(TxtFndRE.Text), MyUtils.CnvSng(TxtSfndRE.Text), MyUtils.CnvSng(TxtDptRE.Text),
          MyUtils.CnvSng(TxtObjRE.Text), MyUtils.CnvSng(TxtFcnRE.Text), MyUtils.CnvSng(TxtSfcnRE.Text))
    End If
    Me.Close()
  End Sub
  Private Sub CopyAcct(ByVal Fund As Integer, ByVal SFund As Integer, ByVal Dept As Integer, ByVal Obnbr As Integer,
  ByVal Fnpgm As Integer, ByVal Subfn As Integer)
    myGLACCTCopy.GetOneRecordP(WrkFdnbr, SFund, Dept, Obnbr, Fnpgm, Subfn)
    With myGLACCT
      .GetOneRecordP(Fund, SFund, Dept, Obnbr, Fnpgm, Subfn)
      If .RecordNotFound Then
        ._ACREC = myGLACCTCopy._ACREC
        ._CSHYN = myGLACCTCopy._CSHYN
        ._DPNBR = Dept
        ._FDNBR = Fund
        ._FNPGM = Fnpgm
        ._GLDSC = myGLACCTCopy._GLDSC
        ._GLTYP = myGLACCTCopy._GLTYP
        ._NONPR = myGLACCTCopy._NONPR
        ._OBNBR = myGLACCTCopy._OBNBR
        ._RLNBR = myGLACCTCopy._RLNBR
        ._SFUND = SFund
        ._SUBFN = Subfn
        .AddOneRecordP()
      End If
    End With
  End Sub
  Private Sub MovetoFile()
    With myGLFUND
      ._ACCFN = ""
      If ChkAcrec.Checked Then
        ._ACREC = "Y"
      Else
        ._ACREC = ""
      End If
      If ChkAccfn.Checked Then
        ._ACCFN = "Y"
      Else
        ._ACCFN = ""
      End If
      If ChkEntfn.Checked Then
        ._ENTFN = "Y"
      Else
        ._ENTFN = ""
      End If
      ._FNDSC = TxtDesc.Text
      ._GROUP = MyUtils.CnvSng(TxtGroup.Text)
      ._DPNBR1 = MyUtils.CnvSng(TxtDptRC.Text)
      ._DPNBR2 = MyUtils.CnvSng(TxtDptEC.Text)
      ._DPNBRA = MyUtils.CnvSng(TxtDptAP.Text)
      ._DPNBRC = MyUtils.CnvSng(TxtDptCA.Text)
      ._DPNBRF = MyUtils.CnvSng(TxtDptFB.Text)
      ._DPNBRE = MyUtils.CnvSng(TxtDptEN.Text)
      ._DPNBRR = MyUtils.CnvSng(TxtDptRE.Text)
      ._FNPGM1 = MyUtils.CnvSng(TxtFcnRC.Text)
      ._FNPGM2 = MyUtils.CnvSng(TxtFcnEC.Text)
      ._FNPGMA = MyUtils.CnvSng(TxtFcnAP.Text)
      ._FNPGMC = MyUtils.CnvSng(TxtFcnCA.Text)
      ._FNPGMF = MyUtils.CnvSng(TxtFcnFB.Text)
      ._FNPGME = MyUtils.CnvSng(TxtFcnEN.Text)
      ._FNPGMR = MyUtils.CnvSng(TxtFcnRE.Text)
      ._FDNBR1 = MyUtils.CnvSng(TxtFndRC.Text)
      ._FDNBR2 = MyUtils.CnvSng(TxtFndEC.Text)
      ._FDNBRA = MyUtils.CnvSng(TxtFndAP.Text)
      ._FDNBRC = MyUtils.CnvSng(TxtFndCA.Text)
      ._FDNBRF = MyUtils.CnvSng(TxtFndFB.Text)
      ._FDNBRE = MyUtils.CnvSng(TxtFndEN.Text)
      ._FDNBRR = MyUtils.CnvSng(TxtFndRE.Text)
      ._OBNBR1 = MyUtils.CnvSng(TxtObjRC.Text)
      ._OBNBR2 = MyUtils.CnvSng(TxtObjEC.Text)
      ._OBNBRA = MyUtils.CnvSng(TxtObjAP.Text)
      ._OBNBRC = MyUtils.CnvSng(TxtObjCA.Text)
      ._OBNBRF = MyUtils.CnvSng(TxtObjFB.Text)
      ._OBNBRE = MyUtils.CnvSng(TxtObjEN.Text)
      ._OBNBRR = MyUtils.CnvSng(TxtObjRE.Text)
      ._SFUND1 = MyUtils.CnvSng(TxtSfndRC.Text)
      ._SFUND2 = MyUtils.CnvSng(TxtSfndEC.Text)
      ._SFUNDA = MyUtils.CnvSng(TxtSfndAP.Text)
      ._SFUNDC = MyUtils.CnvSng(TxtSfndCA.Text)
      ._SFUNDF = MyUtils.CnvSng(TxtSfndFB.Text)
      ._SFUNDE = MyUtils.CnvSng(TxtSfndEN.Text)
      ._SFUNDR = MyUtils.CnvSng(TxtSfndRE.Text)
      ._SUBFN1 = MyUtils.CnvSng(TxtSfcnRC.Text)
      ._SUBFN2 = MyUtils.CnvSng(TxtSfcnEC.Text)
      ._SUBFNA = MyUtils.CnvSng(TxtSfcnAP.Text)
      ._SUBFNC = MyUtils.CnvSng(TxtSfcnCA.Text)
      ._SUBFNF = MyUtils.CnvSng(TxtSfcnFB.Text)
      ._SUBFNE = MyUtils.CnvSng(TxtSfcnEN.Text)
      ._SUBFNR = MyUtils.CnvSng(TxtSfcnRE.Text)
      If DtPckFiscEnd.Checked Then
        ._FENDT = MyUtils.SetDBDateMDY(DtPckFiscEnd.Value)
      Else
        ._FENDT = 0
      End If
      If DtPckFiscStr.Checked Then
        ._FSTDT = MyUtils.SetDBDateMDY(DtPckFiscStr.Value)
      Else
        ._FSTDT = 0
      End If
    End With
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFund.Text) = 0 Then
      ErrorField(I) = "fund"
      ErrorMsg(I) = "Fund is required"
      I = I + 1
    End If

    If TxtDesc.Text = String.Empty Then
      ErrorField(I) = "desc"
      ErrorMsg(I) = "Description is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtGroup.Text) > 0 Then
      myGLGRUP.GetOneRecordP(MyUtils.CnvSng(TxtGroup.Text))
      If myGLGRUP.RecordNotFound Then
        ErrorField(I) = "group"
        ErrorMsg(I) = "Group is invalid"
        I = I + 1
      End If
    End If

    If WrkMode = "Copy" Then Exit Sub

    If MyUtils.CnvSng(TxtFndAP.Text) > 0 Or MyUtils.CnvSng(TxtSfndAP.Text) > 0 Or MyUtils.CnvSng(TxtDptAP.Text) > 0 Or
  MyUtils.CnvSng(TxtObjAP.Text) > 0 Or MyUtils.CnvSng(TxtFcnAP.Text) > 0 Or MyUtils.CnvSng(TxtSfcnAP.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndAP.Text), MyUtils.CnvSng(TxtSfndAP.Text), MyUtils.CnvSng(TxtDptAP.Text),
      MyUtils.CnvSng(TxtObjAP.Text), MyUtils.CnvSng(TxtFcnAP.Text), MyUtils.CnvSng(TxtSfcnAP.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctap"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndCA.Text) > 0 Or MyUtils.CnvSng(TxtSfndCA.Text) > 0 Or MyUtils.CnvSng(TxtDptCA.Text) > 0 Or
  MyUtils.CnvSng(TxtObjCA.Text) > 0 Or MyUtils.CnvSng(TxtFcnCA.Text) > 0 Or MyUtils.CnvSng(TxtSfcnCA.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndCA.Text), MyUtils.CnvSng(TxtSfndCA.Text), MyUtils.CnvSng(TxtDptCA.Text),
      MyUtils.CnvSng(TxtObjCA.Text), MyUtils.CnvSng(TxtFcnCA.Text), MyUtils.CnvSng(TxtSfcnCA.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctca"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndFB.Text) > 0 Or MyUtils.CnvSng(TxtSfndFB.Text) > 0 Or MyUtils.CnvSng(TxtDptFB.Text) > 0 Or
  MyUtils.CnvSng(TxtObjFB.Text) > 0 Or MyUtils.CnvSng(TxtFcnFB.Text) > 0 Or MyUtils.CnvSng(TxtSfcnFB.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndFB.Text), MyUtils.CnvSng(TxtSfndFB.Text), MyUtils.CnvSng(TxtDptFB.Text),
      MyUtils.CnvSng(TxtObjFB.Text), MyUtils.CnvSng(TxtFcnFB.Text), MyUtils.CnvSng(TxtSfcnFB.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctfb"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndEN.Text) > 0 Or MyUtils.CnvSng(TxtSfndEN.Text) > 0 Or MyUtils.CnvSng(TxtDptEN.Text) > 0 Or
  MyUtils.CnvSng(TxtObjEN.Text) > 0 Or MyUtils.CnvSng(TxtFcnEN.Text) > 0 Or MyUtils.CnvSng(TxtSfcnEN.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndEN.Text), MyUtils.CnvSng(TxtSfndEN.Text), MyUtils.CnvSng(TxtDptEN.Text),
      MyUtils.CnvSng(TxtObjEN.Text), MyUtils.CnvSng(TxtFcnEN.Text), MyUtils.CnvSng(TxtSfcnEN.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "accten"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndRE.Text) > 0 Or MyUtils.CnvSng(TxtSfndRE.Text) > 0 Or MyUtils.CnvSng(TxtDptRE.Text) > 0 Or
  MyUtils.CnvSng(TxtObjRE.Text) > 0 Or MyUtils.CnvSng(TxtFcnRE.Text) > 0 Or MyUtils.CnvSng(TxtSfcnRE.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndRE.Text), MyUtils.CnvSng(TxtSfndRE.Text), MyUtils.CnvSng(TxtDptRE.Text),
      MyUtils.CnvSng(TxtObjRE.Text), MyUtils.CnvSng(TxtFcnRE.Text), MyUtils.CnvSng(TxtSfcnRE.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctre"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndRC.Text) > 0 Or MyUtils.CnvSng(TxtSfndRC.Text) > 0 Or MyUtils.CnvSng(TxtDptRC.Text) > 0 Or
  MyUtils.CnvSng(TxtObjRC.Text) > 0 Or MyUtils.CnvSng(TxtFcnRC.Text) > 0 Or MyUtils.CnvSng(TxtSfcnRC.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndRC.Text), MyUtils.CnvSng(TxtSfndRC.Text), MyUtils.CnvSng(TxtDptRC.Text),
      MyUtils.CnvSng(TxtObjRC.Text), MyUtils.CnvSng(TxtFcnRC.Text), MyUtils.CnvSng(TxtSfcnRC.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctrc"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If

    If MyUtils.CnvSng(TxtFndEC.Text) > 0 Or MyUtils.CnvSng(TxtSfndEC.Text) > 0 Or MyUtils.CnvSng(TxtDptEC.Text) > 0 Or
  MyUtils.CnvSng(TxtObjEC.Text) > 0 Or MyUtils.CnvSng(TxtFcnEC.Text) > 0 Or MyUtils.CnvSng(TxtSfcnEC.Text) > 0 Then
      myGLACCT.GetOneRecordP(MyUtils.CnvSng(TxtFndEC.Text), MyUtils.CnvSng(TxtSfndEC.Text), MyUtils.CnvSng(TxtDptEC.Text),
      MyUtils.CnvSng(TxtObjEC.Text), MyUtils.CnvSng(TxtFcnEC.Text), MyUtils.CnvSng(TxtSfcnEC.Text))
      If myGLACCT.RecordNotFound Then
        ErrorField(I) = "acctec"
        ErrorMsg(I) = "Acct is invalid"
        I = I + 1
      End If
    End If
  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "acctap"
          ErrProv.SetError(TxtFndAP, ErrorMsg(I))
        Case "acctca"
          ErrProv.SetError(TxtFndCA, ErrorMsg(I))
        Case "acctfb"
          ErrProv.SetError(TxtFndFB, ErrorMsg(I))
        Case "accten"
          ErrProv.SetError(TxtFndEN, ErrorMsg(I))
        Case "acctre"
          ErrProv.SetError(TxtFndRE, ErrorMsg(I))
        Case "acctrc"
          ErrProv.SetError(TxtFndRC, ErrorMsg(I))
        Case "acctec"
          ErrProv.SetError(TxtFndEC, ErrorMsg(I))
        Case "desc"
          ErrProv.SetError(TxtDesc, ErrorMsg(I))
        Case "fund"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "group"
          ErrProv.SetError(TxtGroup, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub

  Private Sub TxtFund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
    If WrkMode = "Copy" Then
      ErrProv.SetError(TxtFndAP, "")
      ErrProv.SetError(TxtFndCA, "")
      ErrProv.SetError(TxtFndFB, "")
      ErrProv.SetError(TxtFndEN, "")
      ErrProv.SetError(TxtFndRE, "")
      ErrProv.SetError(TxtFndRC, "")
      ErrProv.SetError(TxtFndEC, "")
    End If
  End Sub
  Private Sub TxtFund_TextChanged(sender As Object, e As EventArgs) Handles TxtFund.TextChanged
    TxtFndAP.Text = TxtFund.Text
    TxtFndCA.Text = TxtFund.Text
    TxtFndFB.Text = TxtFund.Text
    TxtFndEN.Text = TxtFund.Text
    TxtFndRE.Text = TxtFund.Text
    TxtFndRC.Text = TxtFund.Text
    TxtFndEC.Text = TxtFund.Text
    TxtFndAP.Text = TxtFund.Text
  End Sub
  Private Sub TxtSfund_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSfund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtGroup_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGroup.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndAP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndAP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptAP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjAP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnAP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnAP.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndCA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndCA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndCA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndCA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptCA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptCA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjCA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjCA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnCA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnCA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnCA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnCA.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndFB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndFB.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndFB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndFB.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptFB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptFB.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjFB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjFB.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnFB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnFB.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnFB_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnFB.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndEN.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndEN.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptEN.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjEN.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnEN.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnEN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnEN.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndRE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndRE.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndRE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndRE.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptRE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptRE.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjRE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjRE.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnRE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnRE.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnRE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnRE.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndRC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndRC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndRC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndRC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptRC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptRC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjRC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjRC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnRC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnRC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnRC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnRC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFndEC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFndEC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfndEC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfndEC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFnDptEC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDptEC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObjEC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObjEC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcnEC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcnEC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcnEC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcnEC.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub LnkGLAcctAP_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctAP.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndAP.Text), MyUtils.CnvSng(TxtSfndAP.Text), MyUtils.CnvSng(TxtDptAP.Text),
    MyUtils.CnvSng(TxtObjAP.Text), MyUtils.CnvSng(TxtFcnAP.Text), MyUtils.CnvSng(TxtSfcnAP.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "AP"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub LnkGLAcctCA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctCA.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndCA.Text), MyUtils.CnvSng(TxtSfndCA.Text), MyUtils.CnvSng(TxtDptCA.Text),
    MyUtils.CnvSng(TxtObjCA.Text), MyUtils.CnvSng(TxtFcnCA.Text), MyUtils.CnvSng(TxtSfcnCA.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "CA"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub LnkGLAcctFB_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctFB.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndFB.Text), MyUtils.CnvSng(TxtSfndFB.Text), MyUtils.CnvSng(TxtDptFB.Text),
    MyUtils.CnvSng(TxtObjFB.Text), MyUtils.CnvSng(TxtFcnFB.Text), MyUtils.CnvSng(TxtSfcnFB.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "FB"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub LnkGLAcctEN_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctEN.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndEN.Text), MyUtils.CnvSng(TxtSfndEN.Text), MyUtils.CnvSng(TxtDptEN.Text),
    MyUtils.CnvSng(TxtObjEN.Text), MyUtils.CnvSng(TxtFcnEN.Text), MyUtils.CnvSng(TxtSfcnEN.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "EN"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub LnkGLAcctRE_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctRE.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndRE.Text), MyUtils.CnvSng(TxtSfndRE.Text), MyUtils.CnvSng(TxtDptRE.Text),
    MyUtils.CnvSng(TxtObjRE.Text), MyUtils.CnvSng(TxtFcnRE.Text), MyUtils.CnvSng(TxtSfcnRE.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "RE"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub LnkGLAcctRC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctRC.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndRC.Text), MyUtils.CnvSng(TxtSfndRC.Text), MyUtils.CnvSng(TxtDptRC.Text),
    MyUtils.CnvSng(TxtObjRC.Text), MyUtils.CnvSng(TxtFcnRC.Text), MyUtils.CnvSng(TxtSfcnRC.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "RC"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub
  Private Sub LnkGLAcctEC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcctEC.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFndEC.Text), MyUtils.CnvSng(TxtSfndEC.Text), MyUtils.CnvSng(TxtDptEC.Text),
    MyUtils.CnvSng(TxtObjEC.Text), MyUtils.CnvSng(TxtFcnEC.Text), MyUtils.CnvSng(TxtSfcnEC.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = "EC"
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()

  End Sub

  Private Sub LnkGroup_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGroup.LinkClicked
    MyFrmListGroup = New FrmListGroup
    MyFrmListGroup.MdiParent = Me.ParentForm
    MyFrmListGroup.WrkGroup = MyUtils.CnvSng(TxtGroup.Text)
    MyFrmListGroup.Show()
    Me.Hide()

  End Sub

End Class
