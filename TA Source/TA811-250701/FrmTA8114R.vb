Public Class FrmTA8114R
  Inherits System.Windows.Forms.Form
  Dim MyTXCOEA As TXCOEA.MyData
  Dim MyTXCOEAL1 As TXCOEAL1.MyData
  Dim MyTXCOEBL4 As TXCOEBL4.MyData
  Dim MyTXINV As TXINV.MyData
  Dim MyTXMRATE As TXMRATE.MyData
  Dim MyTXVCUS As TXVCUS.MyData
  Dim MyTXVEH As TXVEH.MyData
  Dim MyTPAYMNT As TPAYMNT.MyData
  Dim dsTXCOEAL1 As DataSet = New DataSet
  Friend WrkAddMode As Boolean
  Friend WrkCCNo As Integer
  Friend WrkListNo As Integer
  Friend WrkYear As Integer
  Friend WrkType As String
  Friend WrkFamily As String
  Friend WrkDist As Integer
  Friend WrkCCDate As Date
  Dim LoadScrn As Boolean
  Friend WithEvents LblBeforeCC As System.Windows.Forms.Label
  Friend WithEvents LnkClass As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkSaleMonth As System.Windows.Forms.LinkLabel
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtSS2 As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents TxtSSNo As System.Windows.Forms.TextBox
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents TxtOid As System.Windows.Forms.TextBox
  Dim EntryDate As Date

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
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents LblChgAmt As System.Windows.Forms.Label
  Friend WithEvents LblNewAmt As System.Windows.Forms.Label
  Friend WithEvents LblOrigAmt As System.Windows.Forms.Label
  Friend WithEvents LblChgNet As System.Windows.Forms.Label
  Friend WithEvents LblNewNet As System.Windows.Forms.Label
  Friend WithEvents LblOrigNet As System.Windows.Forms.Label
  Friend WithEvents LblChgExam As System.Windows.Forms.Label
  Friend WithEvents LblNewExam As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents LblChgGross As System.Windows.Forms.Label
  Friend WithEvents Label34 As System.Windows.Forms.Label
  Friend WithEvents LblNewGross As System.Windows.Forms.Label
  Friend WithEvents LblOrigGross As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents LblOrig As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label42 As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents LblYear As System.Windows.Forms.Label
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TpAssmnt As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents LblChgAssmt1 As System.Windows.Forms.Label
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents TxtAssmt1 As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents LblOrigAssmt1 As System.Windows.Forms.Label
  Friend WithEvents TpExemptions As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents LblChgExam5 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam4 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam3 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam2 As System.Windows.Forms.Label
  Friend WithEvents LblChgExam1 As System.Windows.Forms.Label
  Friend WithEvents Label70 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam5 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam4 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam3 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam2 As System.Windows.Forms.Label
  Friend WithEvents Label58 As System.Windows.Forms.Label
  Friend WithEvents LblOrigExam1 As System.Windows.Forms.Label
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
  Friend WithEvents TxtExam4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam3 As System.Windows.Forms.TextBox
  Friend WithEvents TxtExam1 As System.Windows.Forms.TextBox
  Friend WithEvents Label50 As System.Windows.Forms.Label
  Friend WithEvents Label52 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents LblCCNo As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblCCDate As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtDist As System.Windows.Forms.TextBox
  Friend WithEvents LnkReason As System.Windows.Forms.LinkLabel
  Friend WithEvents LblMRate As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblBankCd As System.Windows.Forms.Label
  Friend WithEvents TxtOverAmt As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents ChkOver As System.Windows.Forms.CheckBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents TxtReason As System.Windows.Forms.TextBox
  Friend WithEvents TpMain As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtID As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label25 As System.Windows.Forms.Label
  Friend WithEvents TxtReg As System.Windows.Forms.TextBox
  Friend WithEvents TxtClass As System.Windows.Forms.TextBox
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents TxtMake As System.Windows.Forms.TextBox
  Friend WithEvents TxtModel As System.Windows.Forms.TextBox
  Friend WithEvents TxtSaleMonth As System.Windows.Forms.TextBox
  Friend WithEvents TxtMVYear As System.Windows.Forms.TextBox
  Friend WithEvents LblChgProrate As System.Windows.Forms.Label
  Friend WithEvents LblNewProrate As System.Windows.Forms.Label
  Friend WithEvents LblOrigProrate As System.Windows.Forms.Label
  Friend WithEvents LblSaleNet As System.Windows.Forms.Label
  Friend WithEvents LblSalePct As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblChgAmt = New System.Windows.Forms.Label()
    Me.LblNewAmt = New System.Windows.Forms.Label()
    Me.LblOrigAmt = New System.Windows.Forms.Label()
    Me.LblChgNet = New System.Windows.Forms.Label()
    Me.LblNewNet = New System.Windows.Forms.Label()
    Me.LblOrigNet = New System.Windows.Forms.Label()
    Me.LblChgProrate = New System.Windows.Forms.Label()
    Me.LblNewProrate = New System.Windows.Forms.Label()
    Me.LblOrigProrate = New System.Windows.Forms.Label()
    Me.LblChgExam = New System.Windows.Forms.Label()
    Me.LblNewExam = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.LblChgGross = New System.Windows.Forms.Label()
    Me.Label34 = New System.Windows.Forms.Label()
    Me.LblNewGross = New System.Windows.Forms.Label()
    Me.LblOrigGross = New System.Windows.Forms.Label()
    Me.LblOrigExam = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.LblOrig = New System.Windows.Forms.Label()
    Me.Label22 = New System.Windows.Forms.Label()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.LblYear = New System.Windows.Forms.Label()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TpMain = New System.Windows.Forms.TabPage()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtSS2 = New System.Windows.Forms.TextBox()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.TxtSSNo = New System.Windows.Forms.TextBox()
    Me.Label31 = New System.Windows.Forms.Label()
    Me.TxtOid = New System.Windows.Forms.TextBox()
    Me.LnkClass = New System.Windows.Forms.LinkLabel()
    Me.TxtModel = New System.Windows.Forms.TextBox()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.TxtMake = New System.Windows.Forms.TextBox()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.TxtMVYear = New System.Windows.Forms.TextBox()
    Me.TxtClass = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtReg = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtID = New System.Windows.Forms.TextBox()
    Me.LnkReason = New System.Windows.Forms.LinkLabel()
    Me.LblMRate = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblBankCd = New System.Windows.Forms.Label()
    Me.TxtOverAmt = New System.Windows.Forms.TextBox()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.ChkOver = New System.Windows.Forms.CheckBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.TxtReason = New System.Windows.Forms.TextBox()
    Me.TpAssmnt = New System.Windows.Forms.TabPage()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.LnkSaleMonth = New System.Windows.Forms.LinkLabel()
    Me.LblSaleNet = New System.Windows.Forms.Label()
    Me.LblSalePct = New System.Windows.Forms.Label()
    Me.TxtSaleMonth = New System.Windows.Forms.TextBox()
    Me.LblChgAssmt1 = New System.Windows.Forms.Label()
    Me.Label23 = New System.Windows.Forms.Label()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.TxtAssmt1 = New System.Windows.Forms.TextBox()
    Me.Label17 = New System.Windows.Forms.Label()
    Me.LblOrigAssmt1 = New System.Windows.Forms.Label()
    Me.TpExemptions = New System.Windows.Forms.TabPage()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblChgExam5 = New System.Windows.Forms.Label()
    Me.LblChgExam4 = New System.Windows.Forms.Label()
    Me.LblChgExam3 = New System.Windows.Forms.Label()
    Me.LblChgExam2 = New System.Windows.Forms.Label()
    Me.LblChgExam1 = New System.Windows.Forms.Label()
    Me.Label70 = New System.Windows.Forms.Label()
    Me.LblOrigExam5 = New System.Windows.Forms.Label()
    Me.LblOrigExam4 = New System.Windows.Forms.Label()
    Me.LblOrigExam3 = New System.Windows.Forms.Label()
    Me.LblOrigExam2 = New System.Windows.Forms.Label()
    Me.Label58 = New System.Windows.Forms.Label()
    Me.LblOrigExam1 = New System.Windows.Forms.Label()
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
    Me.Label50 = New System.Windows.Forms.Label()
    Me.Label52 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.LblCCNo = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblCCDate = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.LblBeforeCC = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TpMain.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TpAssmnt.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TpExemptions.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtZip4
        '
        Me.TxtZip4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZip4.Location = New System.Drawing.Point(416, 128)
        Me.TxtZip4.MaxLength = 4
        Me.TxtZip4.Name = "TxtZip4"
        Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
        Me.TxtZip4.TabIndex = 8
        '
        'TxtCity
        '
        Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCity.Location = New System.Drawing.Point(96, 128)
        Me.TxtCity.MaxLength = 25
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(232, 20)
        Me.TxtCity.TabIndex = 5
        '
        'TxtState
        '
        Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtState.Location = New System.Drawing.Point(336, 128)
        Me.TxtState.MaxLength = 2
        Me.TxtState.Name = "TxtState"
        Me.TxtState.Size = New System.Drawing.Size(24, 20)
        Me.TxtState.TabIndex = 6
        '
        'TxtAdd1
        '
        Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd1.Location = New System.Drawing.Point(96, 80)
        Me.TxtAdd1.MaxLength = 35
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(280, 20)
        Me.TxtAdd1.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblChgAmt)
        Me.GroupBox2.Controls.Add(Me.LblNewAmt)
        Me.GroupBox2.Controls.Add(Me.LblOrigAmt)
        Me.GroupBox2.Controls.Add(Me.LblChgNet)
        Me.GroupBox2.Controls.Add(Me.LblNewNet)
        Me.GroupBox2.Controls.Add(Me.LblOrigNet)
        Me.GroupBox2.Controls.Add(Me.LblChgProrate)
        Me.GroupBox2.Controls.Add(Me.LblNewProrate)
        Me.GroupBox2.Controls.Add(Me.LblOrigProrate)
        Me.GroupBox2.Controls.Add(Me.LblChgExam)
        Me.GroupBox2.Controls.Add(Me.LblNewExam)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.LblChgGross)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.LblNewGross)
        Me.GroupBox2.Controls.Add(Me.LblOrigGross)
        Me.GroupBox2.Controls.Add(Me.LblOrigExam)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.LblOrig)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 392)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(464, 88)
        Me.GroupBox2.TabIndex = 170
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Totals"
        '
        'LblChgAmt
        '
        Me.LblChgAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAmt.Location = New System.Drawing.Point(368, 64)
        Me.LblChgAmt.Name = "LblChgAmt"
        Me.LblChgAmt.Size = New System.Drawing.Size(80, 16)
        Me.LblChgAmt.TabIndex = 172
        Me.LblChgAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNewAmt
        '
        Me.LblNewAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewAmt.Location = New System.Drawing.Point(368, 48)
        Me.LblNewAmt.Name = "LblNewAmt"
        Me.LblNewAmt.Size = New System.Drawing.Size(80, 16)
        Me.LblNewAmt.TabIndex = 171
        Me.LblNewAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigAmt
        '
        Me.LblOrigAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAmt.Location = New System.Drawing.Point(368, 32)
        Me.LblOrigAmt.Name = "LblOrigAmt"
        Me.LblOrigAmt.Size = New System.Drawing.Size(80, 16)
        Me.LblOrigAmt.TabIndex = 170
        Me.LblOrigAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgNet
        '
        Me.LblChgNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgNet.Location = New System.Drawing.Point(296, 64)
        Me.LblChgNet.Name = "LblChgNet"
        Me.LblChgNet.Size = New System.Drawing.Size(64, 16)
        Me.LblChgNet.TabIndex = 169
        Me.LblChgNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNewNet
        '
        Me.LblNewNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewNet.Location = New System.Drawing.Point(296, 48)
        Me.LblNewNet.Name = "LblNewNet"
        Me.LblNewNet.Size = New System.Drawing.Size(64, 16)
        Me.LblNewNet.TabIndex = 168
        Me.LblNewNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigNet
        '
        Me.LblOrigNet.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigNet.Location = New System.Drawing.Point(296, 32)
        Me.LblOrigNet.Name = "LblOrigNet"
        Me.LblOrigNet.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigNet.TabIndex = 167
        Me.LblOrigNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgProrate
        '
        Me.LblChgProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgProrate.Location = New System.Drawing.Point(152, 64)
        Me.LblChgProrate.Name = "LblChgProrate"
        Me.LblChgProrate.Size = New System.Drawing.Size(64, 16)
        Me.LblChgProrate.TabIndex = 166
        Me.LblChgProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNewProrate
        '
        Me.LblNewProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewProrate.Location = New System.Drawing.Point(152, 48)
        Me.LblNewProrate.Name = "LblNewProrate"
        Me.LblNewProrate.Size = New System.Drawing.Size(64, 16)
        Me.LblNewProrate.TabIndex = 165
        Me.LblNewProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigProrate
        '
        Me.LblOrigProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigProrate.Location = New System.Drawing.Point(152, 32)
        Me.LblOrigProrate.Name = "LblOrigProrate"
        Me.LblOrigProrate.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigProrate.TabIndex = 164
        Me.LblOrigProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam
        '
        Me.LblChgExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam.Location = New System.Drawing.Point(224, 64)
        Me.LblChgExam.Name = "LblChgExam"
        Me.LblChgExam.Size = New System.Drawing.Size(64, 16)
        Me.LblChgExam.TabIndex = 163
        Me.LblChgExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblNewExam
        '
        Me.LblNewExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewExam.Location = New System.Drawing.Point(224, 48)
        Me.LblNewExam.Name = "LblNewExam"
        Me.LblNewExam.Size = New System.Drawing.Size(64, 16)
        Me.LblNewExam.TabIndex = 162
        Me.LblNewExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(371, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 16)
        Me.Label24.TabIndex = 161
        Me.Label24.Text = "Tax  Amount"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(152, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Prorate"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(219, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 16)
        Me.Label20.TabIndex = 34
        Me.Label20.Text = "Exemptions"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(80, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 16)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "Gross"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblChgGross
        '
        Me.LblChgGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgGross.Location = New System.Drawing.Point(80, 64)
        Me.LblChgGross.Name = "LblChgGross"
        Me.LblChgGross.Size = New System.Drawing.Size(64, 16)
        Me.LblChgGross.TabIndex = 21
        Me.LblChgGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(8, 64)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 16)
        Me.Label34.TabIndex = 20
        Me.Label34.Text = "Change"
        '
        'LblNewGross
        '
        Me.LblNewGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblNewGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblNewGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewGross.Location = New System.Drawing.Point(80, 48)
        Me.LblNewGross.Name = "LblNewGross"
        Me.LblNewGross.Size = New System.Drawing.Size(64, 16)
        Me.LblNewGross.TabIndex = 19
        Me.LblNewGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigGross
        '
        Me.LblOrigGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigGross.Location = New System.Drawing.Point(80, 32)
        Me.LblOrigGross.Name = "LblOrigGross"
        Me.LblOrigGross.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigGross.TabIndex = 18
        Me.LblOrigGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigExam
        '
        Me.LblOrigExam.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam.Location = New System.Drawing.Point(224, 32)
        Me.LblOrigExam.Name = "LblOrigExam"
        Me.LblOrigExam.Size = New System.Drawing.Size(64, 16)
        Me.LblOrigExam.TabIndex = 17
        Me.LblOrigExam.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 48)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 16)
        Me.Label30.TabIndex = 16
        Me.Label30.Text = "New"
        '
        'LblOrig
        '
        Me.LblOrig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrig.Location = New System.Drawing.Point(8, 32)
        Me.LblOrig.Name = "LblOrig"
        Me.LblOrig.Size = New System.Drawing.Size(64, 16)
        Me.LblOrig.TabIndex = 15
        Me.LblOrig.Text = "Original"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(296, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 16)
        Me.Label22.TabIndex = 160
        Me.Label22.Text = "Net"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(392, 32)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(48, 16)
        Me.Label42.TabIndex = 164
        Me.Label42.Text = "District"
        '
        'LblType
        '
        Me.LblType.Location = New System.Drawing.Point(416, 8)
        Me.LblType.Name = "LblType"
        Me.LblType.Size = New System.Drawing.Size(24, 16)
        Me.LblType.TabIndex = 175
        '
        'LblYear
        '
        Me.LblYear.Location = New System.Drawing.Point(216, 8)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(32, 16)
        Me.LblYear.TabIndex = 173
        '
        'TxtAdd2
        '
        Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAdd2.Location = New System.Drawing.Point(96, 104)
        Me.TxtAdd2.MaxLength = 35
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(280, 20)
        Me.TxtAdd2.TabIndex = 4
        '
        'TxtSname
        '
        Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSname.Location = New System.Drawing.Point(96, 56)
        Me.TxtSname.MaxLength = 35
        Me.TxtSname.Name = "TxtSname"
        Me.TxtSname.Size = New System.Drawing.Size(280, 20)
        Me.TxtSname.TabIndex = 2
        '
        'TxtZip5
        '
        Me.TxtZip5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtZip5.Location = New System.Drawing.Point(368, 128)
        Me.TxtZip5.MaxLength = 5
        Me.TxtZip5.Name = "TxtZip5"
        Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
        Me.TxtZip5.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "Second Name"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TpMain)
        Me.TabControl1.Controls.Add(Me.TpAssmnt)
        Me.TabControl1.Controls.Add(Me.TpExemptions)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(8, 152)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(588, 240)
        Me.TabControl1.TabIndex = 9
        Me.TabControl1.TabStop = False
        '
        'TpMain
        '
        Me.TpMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TpMain.Controls.Add(Me.GroupBox3)
        Me.TpMain.Controls.Add(Me.LnkReason)
        Me.TpMain.Controls.Add(Me.LblMRate)
        Me.TpMain.Controls.Add(Me.Label26)
        Me.TpMain.Controls.Add(Me.LblBankCd)
        Me.TpMain.Controls.Add(Me.TxtOverAmt)
        Me.TpMain.Controls.Add(Me.Label15)
        Me.TpMain.Controls.Add(Me.ChkOver)
        Me.TpMain.Controls.Add(Me.Label14)
        Me.TpMain.Controls.Add(Me.TxtDesc)
        Me.TpMain.Controls.Add(Me.TxtReason)
        Me.TpMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TpMain.Location = New System.Drawing.Point(4, 25)
        Me.TpMain.Name = "TpMain"
        Me.TpMain.Size = New System.Drawing.Size(580, 211)
        Me.TpMain.TabIndex = 0
        Me.TpMain.Text = "Main"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.TxtSS2)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.TxtSSNo)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.TxtOid)
        Me.GroupBox3.Controls.Add(Me.LnkClass)
        Me.GroupBox3.Controls.Add(Me.TxtModel)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.TxtMake)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.TxtMVYear)
        Me.GroupBox3.Controls.Add(Me.TxtClass)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TxtReg)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.TxtID)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(498, 88)
        Me.GroupBox3.TabIndex = 173
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Current Vehicle"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(179, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 257
        Me.Label10.Text = "SecondCust ID"
        '
        'TxtSS2
        '
        Me.TxtSS2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSS2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSS2.Location = New System.Drawing.Point(264, 62)
        Me.TxtSS2.MaxLength = 9
        Me.TxtSS2.Name = "TxtSS2"
        Me.TxtSS2.Size = New System.Drawing.Size(80, 20)
        Me.TxtSS2.TabIndex = 17
        Me.TxtSS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(6, 68)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 256
        Me.Label16.Text = "PrimaryCust ID"
        '
        'TxtSSNo
        '
        Me.TxtSSNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSSNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtSSNo.Location = New System.Drawing.Point(88, 62)
        Me.TxtSSNo.MaxLength = 9
        Me.TxtSSNo.Name = "TxtSSNo"
        Me.TxtSSNo.Size = New System.Drawing.Size(80, 20)
        Me.TxtSSNo.TabIndex = 16
        Me.TxtSSNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(356, 65)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 13)
        Me.Label31.TabIndex = 255
        Me.Label31.Text = "Vehicle ID"
        '
        'TxtOid
        '
        Me.TxtOid.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TxtOid.Location = New System.Drawing.Point(417, 62)
        Me.TxtOid.MaxLength = 15
        Me.TxtOid.Name = "TxtOid"
        Me.TxtOid.Size = New System.Drawing.Size(75, 20)
        Me.TxtOid.TabIndex = 18
        '
        'LnkClass
        '
        Me.LnkClass.Location = New System.Drawing.Point(362, 20)
        Me.LnkClass.Name = "LnkClass"
        Me.LnkClass.Size = New System.Drawing.Size(35, 16)
        Me.LnkClass.TabIndex = 172
        Me.LnkClass.TabStop = True
        Me.LnkClass.Text = "Class"
        '
        'TxtModel
        '
        Me.TxtModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtModel.Location = New System.Drawing.Point(272, 40)
        Me.TxtModel.MaxLength = 8
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(72, 20)
        Me.TxtModel.TabIndex = 15
        '
        'Label27
        '
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(144, 40)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 16)
        Me.Label27.TabIndex = 166
        Me.Label27.Text = "Make/Model"
        '
        'TxtMake
        '
        Me.TxtMake.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMake.Location = New System.Drawing.Point(216, 40)
        Me.TxtMake.MaxLength = 5
        Me.TxtMake.Name = "TxtMake"
        Me.TxtMake.Size = New System.Drawing.Size(48, 20)
        Me.TxtMake.TabIndex = 14
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(8, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 16)
        Me.Label25.TabIndex = 164
        Me.Label25.Text = "Year"
        '
        'TxtMVYear
        '
        Me.TxtMVYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtMVYear.Location = New System.Drawing.Point(96, 40)
        Me.TxtMVYear.MaxLength = 4
        Me.TxtMVYear.Name = "TxtMVYear"
        Me.TxtMVYear.Size = New System.Drawing.Size(32, 20)
        Me.TxtMVYear.TabIndex = 13
        '
        'TxtClass
        '
        Me.TxtClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtClass.Location = New System.Drawing.Point(400, 16)
        Me.TxtClass.MaxLength = 2
        Me.TxtClass.Name = "TxtClass"
        Me.TxtClass.Size = New System.Drawing.Size(24, 20)
        Me.TxtClass.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(256, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 16)
        Me.Label7.TabIndex = 160
        Me.Label7.Text = "Reg"
        '
        'TxtReg
        '
        Me.TxtReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReg.Location = New System.Drawing.Point(288, 16)
        Me.TxtReg.MaxLength = 8
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.Size = New System.Drawing.Size(56, 20)
        Me.TxtReg.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 158
        Me.Label6.Text = "VIN "
        '
        'TxtID
        '
        Me.TxtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtID.Location = New System.Drawing.Point(96, 16)
        Me.TxtID.MaxLength = 17
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(144, 20)
        Me.TxtID.TabIndex = 10
        '
        'LnkReason
        '
        Me.LnkReason.Location = New System.Drawing.Point(10, 101)
        Me.LnkReason.Name = "LnkReason"
        Me.LnkReason.Size = New System.Drawing.Size(88, 16)
        Me.LnkReason.TabIndex = 16
        Me.LnkReason.TabStop = True
        Me.LnkReason.Text = "Change Reason"
        '
        'LblMRate
        '
        Me.LblMRate.Location = New System.Drawing.Point(98, 173)
        Me.LblMRate.Name = "LblMRate"
        Me.LblMRate.Size = New System.Drawing.Size(64, 16)
        Me.LblMRate.TabIndex = 163
        Me.LblMRate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(10, 173)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 16)
        Me.Label26.TabIndex = 162
        Me.Label26.Text = "Mill Rate"
        '
        'LblBankCd
        '
        Me.LblBankCd.Location = New System.Drawing.Point(408, 32)
        Me.LblBankCd.Name = "LblBankCd"
        Me.LblBankCd.Size = New System.Drawing.Size(24, 16)
        Me.LblBankCd.TabIndex = 161
        '
        'TxtOverAmt
        '
        Me.TxtOverAmt.Enabled = False
        Me.TxtOverAmt.Location = New System.Drawing.Point(234, 149)
        Me.TxtOverAmt.MaxLength = 11
        Me.TxtOverAmt.Name = "TxtOverAmt"
        Me.TxtOverAmt.Size = New System.Drawing.Size(64, 20)
        Me.TxtOverAmt.TabIndex = 22
        Me.TxtOverAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(130, 149)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 16)
        Me.Label15.TabIndex = 159
        Me.Label15.Text = "Override Amount"
        '
        'ChkOver
        '
        Me.ChkOver.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkOver.Location = New System.Drawing.Point(10, 149)
        Me.ChkOver.Name = "ChkOver"
        Me.ChkOver.Size = New System.Drawing.Size(104, 16)
        Me.ChkOver.TabIndex = 21
        Me.ChkOver.Text = "Override Tax?"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 125)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 16)
        Me.Label14.TabIndex = 156
        Me.Label14.Text = "Description"
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(98, 125)
        Me.TxtDesc.MaxLength = 50
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(310, 20)
        Me.TxtDesc.TabIndex = 20
        '
        'TxtReason
        '
        Me.TxtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtReason.Location = New System.Drawing.Point(98, 102)
        Me.TxtReason.MaxLength = 1
        Me.TxtReason.Name = "TxtReason"
        Me.TxtReason.Size = New System.Drawing.Size(18, 20)
        Me.TxtReason.TabIndex = 19
        '
        'TpAssmnt
        '
        Me.TpAssmnt.Controls.Add(Me.GroupBox1)
        Me.TpAssmnt.Location = New System.Drawing.Point(4, 25)
        Me.TpAssmnt.Name = "TpAssmnt"
        Me.TpAssmnt.Size = New System.Drawing.Size(580, 211)
        Me.TpAssmnt.TabIndex = 2
        Me.TpAssmnt.Text = "Assessments"
        Me.TpAssmnt.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LnkSaleMonth)
        Me.GroupBox1.Controls.Add(Me.LblSaleNet)
        Me.GroupBox1.Controls.Add(Me.LblSalePct)
        Me.GroupBox1.Controls.Add(Me.TxtSaleMonth)
        Me.GroupBox1.Controls.Add(Me.LblChgAssmt1)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.TxtAssmt1)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.LblOrigAssmt1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 88)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Vehicle"
        '
        'LnkSaleMonth
        '
        Me.LnkSaleMonth.Location = New System.Drawing.Point(6, 64)
        Me.LnkSaleMonth.Name = "LnkSaleMonth"
        Me.LnkSaleMonth.Size = New System.Drawing.Size(74, 16)
        Me.LnkSaleMonth.TabIndex = 199
        Me.LnkSaleMonth.TabStop = True
        Me.LnkSaleMonth.Text = "Sale Month"
        '
        'LblSaleNet
        '
        Me.LblSaleNet.BackColor = System.Drawing.Color.LightCyan
        Me.LblSaleNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblSaleNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleNet.ForeColor = System.Drawing.Color.Black
        Me.LblSaleNet.Location = New System.Drawing.Point(112, 64)
        Me.LblSaleNet.Name = "LblSaleNet"
        Me.LblSaleNet.Size = New System.Drawing.Size(72, 20)
        Me.LblSaleNet.TabIndex = 198
        Me.LblSaleNet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSalePct
        '
        Me.LblSalePct.ForeColor = System.Drawing.Color.Black
        Me.LblSalePct.Location = New System.Drawing.Point(192, 68)
        Me.LblSalePct.Name = "LblSalePct"
        Me.LblSalePct.Size = New System.Drawing.Size(40, 16)
        Me.LblSalePct.TabIndex = 186
        '
        'TxtSaleMonth
        '
        Me.TxtSaleMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleMonth.Location = New System.Drawing.Point(80, 64)
        Me.TxtSaleMonth.MaxLength = 9
        Me.TxtSaleMonth.Name = "TxtSaleMonth"
        Me.TxtSaleMonth.Size = New System.Drawing.Size(24, 20)
        Me.TxtSaleMonth.TabIndex = 4
        Me.TxtSaleMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblChgAssmt1
        '
        Me.LblChgAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgAssmt1.ForeColor = System.Drawing.Color.Black
        Me.LblChgAssmt1.Location = New System.Drawing.Point(168, 32)
        Me.LblChgAssmt1.Name = "LblChgAssmt1"
        Me.LblChgAssmt1.Size = New System.Drawing.Size(72, 20)
        Me.LblChgAssmt1.TabIndex = 183
        Me.LblChgAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(168, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 16)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "Change"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(9, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(71, 16)
        Me.Label18.TabIndex = 36
        Me.Label18.Text = "Original"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TxtAssmt1
        '
        Me.TxtAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssmt1.Location = New System.Drawing.Point(88, 32)
        Me.TxtAssmt1.MaxLength = 9
        Me.TxtAssmt1.Name = "TxtAssmt1"
        Me.TxtAssmt1.Size = New System.Drawing.Size(72, 20)
        Me.TxtAssmt1.TabIndex = 3
        Me.TxtAssmt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(88, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Value"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblOrigAssmt1
        '
        Me.LblOrigAssmt1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigAssmt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigAssmt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigAssmt1.ForeColor = System.Drawing.Color.Black
        Me.LblOrigAssmt1.Location = New System.Drawing.Point(8, 32)
        Me.LblOrigAssmt1.Name = "LblOrigAssmt1"
        Me.LblOrigAssmt1.Size = New System.Drawing.Size(72, 20)
        Me.LblOrigAssmt1.TabIndex = 22
        Me.LblOrigAssmt1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TpExemptions
        '
        Me.TpExemptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TpExemptions.Controls.Add(Me.GroupBox4)
        Me.TpExemptions.Location = New System.Drawing.Point(4, 25)
        Me.TpExemptions.Name = "TpExemptions"
        Me.TpExemptions.Size = New System.Drawing.Size(580, 211)
        Me.TpExemptions.TabIndex = 1
        Me.TpExemptions.Text = "Exemptions"
        Me.TpExemptions.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.LblChgExam5)
        Me.GroupBox4.Controls.Add(Me.LblChgExam4)
        Me.GroupBox4.Controls.Add(Me.LblChgExam3)
        Me.GroupBox4.Controls.Add(Me.LblChgExam2)
        Me.GroupBox4.Controls.Add(Me.LblChgExam1)
        Me.GroupBox4.Controls.Add(Me.Label70)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam5)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam4)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam3)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam2)
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.LblOrigExam1)
        Me.GroupBox4.Controls.Add(Me.LnkExempt5)
        Me.GroupBox4.Controls.Add(Me.TxtExempt5)
        Me.GroupBox4.Controls.Add(Me.LnkExempt3)
        Me.GroupBox4.Controls.Add(Me.TxtExempt3)
        Me.GroupBox4.Controls.Add(Me.LnkExempt4)
        Me.GroupBox4.Controls.Add(Me.TxtExempt4)
        Me.GroupBox4.Controls.Add(Me.LnkExempt2)
        Me.GroupBox4.Controls.Add(Me.TxtExempt2)
        Me.GroupBox4.Controls.Add(Me.LnkExempt1)
        Me.GroupBox4.Controls.Add(Me.TxtExempt1)
        Me.GroupBox4.Controls.Add(Me.TxtExam4)
        Me.GroupBox4.Controls.Add(Me.TxtExam2)
        Me.GroupBox4.Controls.Add(Me.TxtExam5)
        Me.GroupBox4.Controls.Add(Me.TxtExam3)
        Me.GroupBox4.Controls.Add(Me.TxtExam1)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox4.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(296, 152)
        Me.GroupBox4.TabIndex = 124
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Exemptions"
        '
        'LblChgExam5
        '
        Me.LblChgExam5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam5.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam5.Location = New System.Drawing.Point(224, 128)
        Me.LblChgExam5.Name = "LblChgExam5"
        Me.LblChgExam5.Size = New System.Drawing.Size(64, 20)
        Me.LblChgExam5.TabIndex = 201
        Me.LblChgExam5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam4
        '
        Me.LblChgExam4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam4.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam4.Location = New System.Drawing.Point(224, 104)
        Me.LblChgExam4.Name = "LblChgExam4"
        Me.LblChgExam4.Size = New System.Drawing.Size(64, 20)
        Me.LblChgExam4.TabIndex = 200
        Me.LblChgExam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam3
        '
        Me.LblChgExam3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam3.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam3.Location = New System.Drawing.Point(224, 80)
        Me.LblChgExam3.Name = "LblChgExam3"
        Me.LblChgExam3.Size = New System.Drawing.Size(64, 20)
        Me.LblChgExam3.TabIndex = 199
        Me.LblChgExam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam2
        '
        Me.LblChgExam2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam2.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam2.Location = New System.Drawing.Point(224, 56)
        Me.LblChgExam2.Name = "LblChgExam2"
        Me.LblChgExam2.Size = New System.Drawing.Size(64, 20)
        Me.LblChgExam2.TabIndex = 198
        Me.LblChgExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblChgExam1
        '
        Me.LblChgExam1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblChgExam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblChgExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChgExam1.ForeColor = System.Drawing.Color.Black
        Me.LblChgExam1.Location = New System.Drawing.Point(224, 32)
        Me.LblChgExam1.Name = "LblChgExam1"
        Me.LblChgExam1.Size = New System.Drawing.Size(64, 20)
        Me.LblChgExam1.TabIndex = 197
        Me.LblChgExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label70
        '
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.ForeColor = System.Drawing.Color.Black
        Me.Label70.Location = New System.Drawing.Point(224, 16)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(66, 16)
        Me.Label70.TabIndex = 196
        Me.Label70.Text = "Change"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblOrigExam5
        '
        Me.LblOrigExam5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam5.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam5.Location = New System.Drawing.Point(72, 128)
        Me.LblOrigExam5.Name = "LblOrigExam5"
        Me.LblOrigExam5.Size = New System.Drawing.Size(64, 20)
        Me.LblOrigExam5.TabIndex = 193
        Me.LblOrigExam5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigExam4
        '
        Me.LblOrigExam4.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam4.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam4.Location = New System.Drawing.Point(72, 104)
        Me.LblOrigExam4.Name = "LblOrigExam4"
        Me.LblOrigExam4.Size = New System.Drawing.Size(64, 20)
        Me.LblOrigExam4.TabIndex = 192
        Me.LblOrigExam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigExam3
        '
        Me.LblOrigExam3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam3.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam3.Location = New System.Drawing.Point(72, 80)
        Me.LblOrigExam3.Name = "LblOrigExam3"
        Me.LblOrigExam3.Size = New System.Drawing.Size(64, 20)
        Me.LblOrigExam3.TabIndex = 191
        Me.LblOrigExam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblOrigExam2
        '
        Me.LblOrigExam2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam2.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam2.Location = New System.Drawing.Point(72, 56)
        Me.LblOrigExam2.Name = "LblOrigExam2"
        Me.LblOrigExam2.Size = New System.Drawing.Size(64, 20)
        Me.LblOrigExam2.TabIndex = 190
        Me.LblOrigExam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.ForeColor = System.Drawing.Color.Black
        Me.Label58.Location = New System.Drawing.Point(70, 16)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(66, 16)
        Me.Label58.TabIndex = 184
        Me.Label58.Text = "Original"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblOrigExam1
        '
        Me.LblOrigExam1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblOrigExam1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblOrigExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrigExam1.ForeColor = System.Drawing.Color.Black
        Me.LblOrigExam1.Location = New System.Drawing.Point(72, 32)
        Me.LblOrigExam1.Name = "LblOrigExam1"
        Me.LblOrigExam1.Size = New System.Drawing.Size(64, 20)
        Me.LblOrigExam1.TabIndex = 183
        Me.LblOrigExam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LnkExempt5
        '
        Me.LnkExempt5.Location = New System.Drawing.Point(8, 132)
        Me.LnkExempt5.Name = "LnkExempt5"
        Me.LnkExempt5.Size = New System.Drawing.Size(24, 16)
        Me.LnkExempt5.TabIndex = 175
        Me.LnkExempt5.TabStop = True
        Me.LnkExempt5.Text = "5"
        '
        'TxtExempt5
        '
        Me.TxtExempt5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt5.Location = New System.Drawing.Point(32, 128)
        Me.TxtExempt5.MaxLength = 3
        Me.TxtExempt5.Name = "TxtExempt5"
        Me.TxtExempt5.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt5.TabIndex = 8
        '
        'LnkExempt3
        '
        Me.LnkExempt3.Location = New System.Drawing.Point(8, 84)
        Me.LnkExempt3.Name = "LnkExempt3"
        Me.LnkExempt3.Size = New System.Drawing.Size(24, 16)
        Me.LnkExempt3.TabIndex = 173
        Me.LnkExempt3.TabStop = True
        Me.LnkExempt3.Text = "3"
        '
        'TxtExempt3
        '
        Me.TxtExempt3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt3.Location = New System.Drawing.Point(32, 80)
        Me.TxtExempt3.MaxLength = 3
        Me.TxtExempt3.Name = "TxtExempt3"
        Me.TxtExempt3.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt3.TabIndex = 4
        '
        'LnkExempt4
        '
        Me.LnkExempt4.Location = New System.Drawing.Point(8, 108)
        Me.LnkExempt4.Name = "LnkExempt4"
        Me.LnkExempt4.Size = New System.Drawing.Size(24, 16)
        Me.LnkExempt4.TabIndex = 174
        Me.LnkExempt4.TabStop = True
        Me.LnkExempt4.Text = "4"
        '
        'TxtExempt4
        '
        Me.TxtExempt4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt4.Location = New System.Drawing.Point(32, 104)
        Me.TxtExempt4.MaxLength = 3
        Me.TxtExempt4.Name = "TxtExempt4"
        Me.TxtExempt4.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt4.TabIndex = 6
        '
        'LnkExempt2
        '
        Me.LnkExempt2.Location = New System.Drawing.Point(8, 60)
        Me.LnkExempt2.Name = "LnkExempt2"
        Me.LnkExempt2.Size = New System.Drawing.Size(24, 16)
        Me.LnkExempt2.TabIndex = 172
        Me.LnkExempt2.TabStop = True
        Me.LnkExempt2.Text = "2"
        '
        'TxtExempt2
        '
        Me.TxtExempt2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt2.Location = New System.Drawing.Point(32, 56)
        Me.TxtExempt2.MaxLength = 3
        Me.TxtExempt2.Name = "TxtExempt2"
        Me.TxtExempt2.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt2.TabIndex = 2
        '
        'LnkExempt1
        '
        Me.LnkExempt1.Location = New System.Drawing.Point(8, 36)
        Me.LnkExempt1.Name = "LnkExempt1"
        Me.LnkExempt1.Size = New System.Drawing.Size(24, 16)
        Me.LnkExempt1.TabIndex = 171
        Me.LnkExempt1.TabStop = True
        Me.LnkExempt1.Text = "1"
        '
        'TxtExempt1
        '
        Me.TxtExempt1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtExempt1.Location = New System.Drawing.Point(32, 32)
        Me.TxtExempt1.MaxLength = 3
        Me.TxtExempt1.Name = "TxtExempt1"
        Me.TxtExempt1.Size = New System.Drawing.Size(32, 20)
        Me.TxtExempt1.TabIndex = 0
        '
        'TxtExam4
        '
        Me.TxtExam4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam4.Location = New System.Drawing.Point(144, 104)
        Me.TxtExam4.MaxLength = 7
        Me.TxtExam4.Name = "TxtExam4"
        Me.TxtExam4.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam4.TabIndex = 7
        Me.TxtExam4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExam2
        '
        Me.TxtExam2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam2.Location = New System.Drawing.Point(144, 56)
        Me.TxtExam2.MaxLength = 7
        Me.TxtExam2.Name = "TxtExam2"
        Me.TxtExam2.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam2.TabIndex = 3
        Me.TxtExam2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExam5
        '
        Me.TxtExam5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam5.Location = New System.Drawing.Point(144, 128)
        Me.TxtExam5.MaxLength = 7
        Me.TxtExam5.Name = "TxtExam5"
        Me.TxtExam5.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam5.TabIndex = 9
        Me.TxtExam5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExam3
        '
        Me.TxtExam3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam3.Location = New System.Drawing.Point(144, 80)
        Me.TxtExam3.MaxLength = 7
        Me.TxtExam3.Name = "TxtExam3"
        Me.TxtExam3.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam3.TabIndex = 5
        Me.TxtExam3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtExam1
        '
        Me.TxtExam1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExam1.Location = New System.Drawing.Point(144, 32)
        Me.TxtExam1.MaxLength = 7
        Me.TxtExam1.Name = "TxtExam1"
        Me.TxtExam1.Size = New System.Drawing.Size(72, 20)
        Me.TxtExam1.TabIndex = 1
        Me.TxtExam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Black
        Me.Label50.Location = New System.Drawing.Point(146, 16)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(70, 16)
        Me.Label50.TabIndex = 38
        Me.Label50.Text = "New"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.ForeColor = System.Drawing.Color.Black
        Me.Label52.Location = New System.Drawing.Point(29, 16)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(41, 16)
        Me.Label52.TabIndex = 35
        Me.Label52.Text = "Code"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(160, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 172
        Me.Label9.Text = "Tax Year"
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(96, 32)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(280, 20)
        Me.TxtName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Name"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 169
        Me.Label4.Text = "City/State/Zip"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(256, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "List No"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'LblCCNo
        '
        Me.LblCCNo.Location = New System.Drawing.Point(96, 8)
        Me.LblCCNo.Name = "LblCCNo"
        Me.LblCCNo.Size = New System.Drawing.Size(48, 16)
        Me.LblCCNo.TabIndex = 178
        '
        'LblListNo
        '
        Me.LblListNo.Location = New System.Drawing.Point(304, 8)
        Me.LblListNo.Name = "LblListNo"
        Me.LblListNo.Size = New System.Drawing.Size(66, 16)
        Me.LblListNo.TabIndex = 179
        '
        'LblCCDate
        '
        Me.LblCCDate.Location = New System.Drawing.Point(520, 8)
        Me.LblCCDate.Name = "LblCCDate"
        Me.LblCCDate.Size = New System.Drawing.Size(64, 16)
        Me.LblCCDate.TabIndex = 177
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "Street Address"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(456, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 176
        Me.Label13.Text = "C/C Date"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(376, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 16)
        Me.Label12.TabIndex = 174
        Me.Label12.Text = "Type"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 171
        Me.Label8.Text = "C/C No"
        '
        'TxtDist
        '
        Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDist.Location = New System.Drawing.Point(440, 32)
        Me.TxtDist.MaxLength = 3
        Me.TxtDist.Name = "TxtDist"
        Me.TxtDist.Size = New System.Drawing.Size(24, 20)
        Me.TxtDist.TabIndex = 1
        Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblBeforeCC
        '
        Me.LblBeforeCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBeforeCC.ForeColor = System.Drawing.Color.Fuchsia
        Me.LblBeforeCC.Location = New System.Drawing.Point(439, 57)
        Me.LblBeforeCC.Name = "LblBeforeCC"
        Me.LblBeforeCC.Size = New System.Drawing.Size(149, 16)
        Me.LblBeforeCC.TabIndex = 207
        Me.LblBeforeCC.Text = "*** Before C/C exists ***"
        '
        'FrmTA8114R
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 486)
        Me.Controls.Add(Me.LblBeforeCC)
        Me.Controls.Add(Me.TxtState)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtSname)
        Me.Controls.Add(Me.TxtZip5)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtDist)
        Me.Controls.Add(Me.TxtZip4)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.LblType)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblCCNo)
        Me.Controls.Add(Me.LblListNo)
        Me.Controls.Add(Me.LblCCDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTA8114R"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Certificate of Change - Motor Vehicle "
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TpMain.ResumeLayout(False)
        Me.TpMain.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TpAssmnt.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TpExemptions.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub FrmTA8114R_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ds As DataSet = New DataSet
    Dim WrkAttachCount As Integer
    Dim WrkDate As Date
    Dim WrkDBDate As Integer
    Dim WrkDBTime As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkAss As String
    Dim WrkMonth As Integer
    Dim CoeCCNo As Integer

    MyTXCOEA = New TXCOEA.MyData(myDBConnect)
    MyTXCOEAL1 = New TXCOEAL1.MyData(myDBConnect)
    MyTXCOEBL4 = New TXCOEBL4.MyData(myDBConnect)
    MyTXINV = New TXINV.MyData(myDBConnect)
    MyTXMRATE = New TXMRATE.MyData(myDBConnect)
    MyTXVCUS = New TXVCUS.MyData(myDBConnect)
    MyTXVEH = New TXVEH.MyData(myDBConnect)
    MyTPAYMNT = New TPAYMNT.MyData(myDBConnect)
    LoadScrn = True

    With MyFrmTA811
      .TBarComments.Enabled = True
      .TBarNew.Enabled = False
      .TBarSave.Enabled = True
      .TBarHist.Enabled = False
      .TBarSettings.Enabled = False
      If WrkCCNo > 0 Then
        .TBarAttach.Enabled = True
      End If
    End With

    WrkAttachCount = GetAttachcount(“CCAFTER”, WrkCCNo)
    MyFrmTA811.TBarAttach.Text = WrkAttachCount & " Attachment(s)"

    'On New, Check for existing C/C done today. If found, then change to update mode. 
    If WrkCCNo = 0 Then
      WrkDBDate = MyUtils.SetDBDate(Date.Today)
      If Not MyBeforeBillDate Then
        If Date.Today <> WrkCCDate Then
          MsgBox("Changing date to billing date", MsgBoxStyle.Information, "C/C Entry date is before billing date")
          WrkDBDate = MyUtils.SetDBDate(WrkCCDate)
        End If
      End If
      dsTXCOEAL1 = MyTXCOEAL1.GetLastbyDate(WrkListNo, WrkYear, WrkType, WrkDBDate)
      If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
        With dsTXCOEAL1.Tables(0).Rows(0)
          If WrkDBDate = .Item("chdate") Then
            WrkCCNo = .Item("ccno")
            WrkAddMode = False
            MsgBox("New C/C was not created. Click OK to change existing C/C done today instead.", MsgBoxStyle.Information, "Existing C/C found with today's date")
          End If
        End With
      End If
    End If

    'Fill the dataset with the data
    If Not WrkAddMode Then
      MyFrmTA811.TBarPrint.Enabled = True
      LblCCNo.Text = WrkCCNo
      Me.Text = "Maintain " & Me.Text
      MyTXCOEA.GetOneRecordP(WrkCCNo)
      If MyTXCOEA.RecordNotFound Then
        MyFrmTA811.TBarNew.Enabled = False
        MyFrmTA811.TBarSave.Enabled = False
        MyFrmTA811.TBarDelete.Enabled = False
        Me.ErrProv.SetError(LblCCNo, "Record not found")
        Exit Sub
      End If
      GetTxCOEA()
      If WrkCCDate = WrkDate And LblCCDate.Text = Date.Today Then
        WrkCCDate = LblCCDate.Text
      End If
      If EntryDate <> WrkCCDate Then
        Me.ErrProv.SetError(LblCCNo, "Cannot edit (not same date)")
        MyFrmTA811.TBarSave.Enabled = False
      End If
    Else
      MyFrmTA811.TBarPrint.Enabled = False
      MyFrmTA811.TBarDelete.Enabled = False
      Me.Text = "Add " & Me.Text
      If MyOpenCC Then
        LblCCNo.Text = WrkCCNo
        LblCCDate.Text = WrkCCDate
      Else
        LblCCDate.Text = Date.Today
      End If
      LblListNo.Text = WrkListNo
      LblYear.Text = WrkYear
      LblType.Text = WrkType
      TxtDist.Text = WrkDist
    End If

    MyTXMRATE.GetOneRecordP(WrkYear, "M", WrkDist)
    If MyTXMRATE.RecordNotFound Then
      MyTXMRATE.GetOneRecordP(WrkYear, "", WrkDist)
    End If
    If Not MyTXMRATE.RecordNotFound Then
      With MyTXMRATE
        LblMRate.Text = ._MRRATE
      End With
    End If

    CoeCCNo = 0
    If WrkCCNo > 0 Then
      WrkDBDate = MyUtils.SetDBDate(EntryDate) - 1
      WrkDBTime = 999999
    Else
      LblCCDate.Text = Format(MyUtils.GetDBDate(WrkDBDate), "M/dd/yyyy")
      WrkDBDate = MyUtils.SetDBDate(Date.Today) - 1
      WrkDBTime = 999999
    End If
    dsTXCOEAL1 = MyTXCOEAL1.GetViewDescList(WrkListNo, WrkYear, WrkType, WrkDBDate,
      WrkDBTime, 50)
    If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
      With dsTXCOEAL1.Tables(0).Rows(0)
        CoeCCNo = .Item("ccno")
      End With
    End If

    LblBeforeCC.Visible = False
    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If Not MyTXINV.RecordNotFound Then
      With MyTXINV
        WrkAss = Trim(._ASS)
        If ._ETCA = "Y" Then
          LblBeforeCC.Visible = True
          ds = MyTXCOEBL4.GetDescList(WrkListNo, WrkYear, WrkType, 99999999, 999999, 1)
          If ds.Tables(0).Rows.Count > 0 Then
            WrkAss = ds.Tables(0).Rows(0).Item("ct2mc1")
          End If
        End If
        TxtName.Text = Trim(._NAME)
        TxtSname.Text = Trim(._SNAME)
        TxtAdd1.Text = Trim(._ADD1)
        TxtAdd2.Text = Trim(._ADD2)
        TxtCity.Text = Trim(._CITY)
        TxtState.Text = Trim(._STATE)
        TxtZip5.Text = Format(._ZIP5, "00000")
        TxtZip4.Text = Format(._ZIP4, "0000")
        TxtID.Text = Trim(._IMVIDNo)
        TxtReg.Text = Trim(._IMVREG)
        TxtClass.Text = ._CLASS
        TxtMVYear.Text = ._MVYR
        TxtMake.Text = Trim(._MAKE)
        TxtModel.Text = Trim(._MODEL)
        If ._SSNo > 0 Then
          TxtSSNo.Text = ._SSNo
        End If
        If ._SS2 > 0 Then
          TxtSS2.Text = ._SS2
        End If
        TxtOid.Text = Trim(._OID)
        If CoeCCNo = 0 Then
          If ._TAXT > 0 And Trim(LblCCNo.Text) = "" Then
            CalcProrateCode(WrkAss, MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkMonth)
            If WrkMonth > 0 Then
              TxtSaleMonth.Text = WrkMonth
              LblSaleNet.Text = WrkAdjNet
              LblNewProrate.Text = WrkAdjNet
            End If
          End If
          LblOrigGross.Text = FormatNumber(._GROSS, 0)
          LblOrigExam.Text = FormatNumber(._TOTEXP, 0)
          LblOrigNet.Text = FormatNumber(._NETASS, 0)
          LblOrigProrate.Text = FormatNumber(._GROSS - ._TOTEXP - ._NETASS, 0)
          LblOrigAmt.Text = MyUtils.FmtCurrency(._TAXT)
          LblOrigAssmt1.Text = ._GROSS
          LblOrigExam1.Text = ._EXAM1
          LblOrigExam2.Text = ._EXAM2
          LblOrigExam3.Text = ._EXAM3
          LblOrigExam4.Text = ._EXAM4
          LblOrigExam5.Text = ._EXAM5
          If WrkAddMode Then
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
          End If
        End If
      End With
    End If

    If CoeCCNo > 0 Then
      GetOrigTxCOEA(CoeCCNo)
    End If

    If WrkAddMode Then
      TxtAssmt1.Text = MyUtils.CnvSng(LblOrigAssmt1.Text)
      TxtExam1.Text = MyUtils.CnvSng(LblOrigExam1.Text)
      TxtExam2.Text = MyUtils.CnvSng(LblOrigExam2.Text)
      TxtExam3.Text = MyUtils.CnvSng(LblOrigExam3.Text)
      TxtExam4.Text = MyUtils.CnvSng(LblOrigExam4.Text)
      TxtExam5.Text = MyUtils.CnvSng(LblOrigExam5.Text)
    End If

    dsTXCOEAL1 = MyTXCOEAL1.GetViewbyList(WrkListNo, WrkYear, WrkType, 50)
    If WrkAddMode Then
      If dsTXCOEAL1.Tables(0).Rows.Count > 0 Then
        MyFrmTA811.TBarHist.Enabled = True
      End If
    Else
      If dsTXCOEAL1.Tables(0).Rows.Count > 1 Then
        MyFrmTA811.TBarHist.Enabled = True
      End If
    End If

    LoadScrn = False
    CalcChg()
  End Sub

  Private Sub FrmTA8114R_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    With MyFrmTA811
      .TBarComments.Enabled = False
      .TBarNew.Enabled = True
      .TBarSave.Enabled = False
      .TBarDelete.Enabled = False
      .TBarHist.Enabled = False
      .TBarPrint.Enabled = False
      .TBarSettings.Enabled = True
      .TBarAttach.Enabled = False
      .TBarAttach.Text = "Attachments"
    End With
    MyFrmTA8111R.FormatGrid(True)
    MyFrmTA8111R.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
    MyTXCOEA.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String

NextCC:
    If WrkAddMode And Not MyOpenCC Then
      WrkCCNo = NextControlCCNo()
    End If

    MyTXCOEA.GetOneRecordP(WrkCCNo)
    If WrkAddMode Then
      If Not MyTXCOEA.RecordNotFound Then
        GoTo NextCC
      End If
    End If

    If WrkAddMode Then
      If MyUtils.CnvSng(LblListNo.Text) = 0 Then
        WrkListNo = NextListNo(WrkYear, WrkType)
        LblListNo.Text = WrkListNo
      End If
    End If

    SetCResnTip()
    SetExem1Tip()
    SetExem2Tip()
    SetExem3Tip()
    SetExem4Tip()
    SetExem5Tip()

    WrkListNo = MyUtils.CnvSng(LblListNo.Text)
    WrkYear = MyUtils.CnvSng(LblYear.Text)
    MyTXINV.GetOneRecordP(WrkListNo, WrkYear, WrkType)
    If Not WrkAddMode Then
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MyTXCOEA.UpdateOneRecordP()
        If MyTXCOEA.ErrMsg <> "" Then
          WriteErrorLog(MyTXCOEA.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    Else
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        MyTXCOEA.AddOneRecordP()
        If MyTXCOEA.ErrMsg <> "" Then
          WriteErrorLog(MyTXCOEA.ErrMsg)
          Exit Sub
        End If
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    If Not MyTXINV.RecordNotFound Then
      MyTXINV.UpdateOneRecordP()
      If MyTXINV.ErrMsg <> "" Then
        WriteErrorLog(MyTXINV.ErrMsg)
        Exit Sub
      End If
    Else
      MyTXINV.AddOneRecordP()
      If MyTXINV.ErrMsg <> "" Then
        WriteErrorLog(MyTXINV.ErrMsg)
        Exit Sub
      End If
    End If

    If Trim(TxtSSNo.Text) <> "" Then
      With MyTXVCUS
        .GetOneRecordP(MyUtils.CnvSng(TxtSSNo.Text))
        If .RecordNotFound Then
          ._ADD1 = TxtAdd1.Text
          ._ADD2 = TxtAdd2.Text
          ._BUS = ""
          ._CITY = TxtCity.Text
          ._CHDATE = 0
          ._CONFID = "N"
          ._CUSTID = MyUtils.CnvSng(TxtSSNo.Text)
          ._DOB = 0
          ._NAME = TxtName.Text
          ._SEX = ""
          ._STATE = TxtState.Text
          If TxtZip4.Text = "" Then
            ._ZIPA = TxtZip5.Text
          Else
            ._ZIPA = TxtZip5.Text & "-" & TxtZip4.Text
          End If
          .AddOneRecordP()
        End If
      End With
    End If

    If Trim(TxtSS2.Text) <> "" Then
      With MyTXVCUS
        .GetOneRecordP(MyUtils.CnvSng(TxtSS2.Text))
        If .RecordNotFound Then
          ._ADD1 = TxtAdd1.Text
          ._ADD2 = TxtAdd2.Text
          ._BUS = ""
          ._CHDATE = MyUtils.SetDBDate(Date.Today)
          ._CITY = TxtCity.Text
          ._CONFID = "N"
          ._CUSTID = MyUtils.CnvSng(TxtSS2.Text)
          ._DOB = 0
          ._NAME = TxtSname.Text
          ._SEX = ""
          ._STATE = TxtState.Text
          If TxtZip4.Text = "" Then
            ._ZIPA = TxtZip5.Text
          Else
            ._ZIPA = TxtZip5.Text & "-" & TxtZip4.Text
          End If
          .AddOneRecordP()
        End If
      End With
    End If

    If Trim(TxtOid.Text) <> "" Then
      With MyTXVEH
        .GetOneRecordP(MyUtils.CnvSng(TxtOid.Text))
        If .RecordNotFound Then
          ._BODY = ""
          ._CHDATE = 0
          ._CLASS = MyUtils.CnvSng(TxtClass.Text)
          ._CLASSD = ""
          ._DADD1 = TxtAdd1.Text
          ._DADD2 = TxtAdd2.Text
          ._DCITY = TxtCity.Text
          ._DSTATE = TxtState.Text
          If TxtZip4.Text = "" Then
            ._DZIPA = TxtZip5.Text
          Else
            ._DZIPA = TxtZip5.Text & "-" & TxtZip4.Text
          End If
          ._ENDDT = 0
          ._PCUST = MyUtils.CnvSng(TxtSSNo.Text)
          ._REGNO = TxtReg.Text
          ._SCUST = MyUtils.CnvSng(TxtSS2.Text)
          ._STRDT = 0
          ._VEHID = MyUtils.CnvSng(TxtOid.Text)
          ._VMAKE = TxtMake.Text
          ._VMODEL = TxtModel.Text
          ._YEAR = MyUtils.CnvSng(TxtMVYear.Text)
          .AddOneRecordP()
        End If
      End With
    End If

    If WrkAddMode Then
      MsgBox("C/C number is " & WrkCCNo)
      PrtCert(WrkType)
    End If
    Me.Close()

  End Sub
  Public Sub ShowCCHist()
    MyFrmListCCHist = New FrmListCCHist
    MyFrmListCCHist.WrkListNo = WrkListNo
    MyFrmListCCHist.WrkType = WrkType
    MyFrmListCCHist.WrkYear = WrkYear
    MyFrmListCCHist.ShowDialog()

  End Sub
  Public Sub PrintData()
    PrtCert(WrkType)
  End Sub
  Private Sub MoveToFile()
    Dim WrkTXMVPCT As String()

    With MyTXCOEA
      ._CCNO = WrkCCNo
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._NAME = TxtName.Text
      ._ASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
      ._EXCD1 = TxtExempt1.Text
      ._EX1 = MyUtils.CnvSng(TxtExam1.Text)
      ._EXCD2 = TxtExempt2.Text
      ._EX2 = MyUtils.CnvSng(TxtExam2.Text)
      ._EXCD3 = TxtExempt3.Text
      ._EX3 = MyUtils.CnvSng(TxtExam3.Text)
      ._EXCD4 = TxtExempt4.Text
      ._EX4 = MyUtils.CnvSng(TxtExam4.Text)
      ._EXCD5 = TxtExempt5.Text
      ._EX5 = MyUtils.CnvSng(TxtExam5.Text)
      WrkTXMVPCT = GetTXMVPCTL1("M", MyUtils.CnvSng(TxtSaleMonth.Text))
      ._C1MSCD = ""
      If Mid(WrkTXMVPCT(1), 1, 1) <> "*" Then
        ._C1MSCD = WrkTXMVPCT(1)
      End If
      ._CTXOV = "N"
      If ChkOver.Checked Then
        ._CTXOV = "Y"
      End If
      ._GRCHG = MyUtils.CnvSng(LblChgGross.Text)
      ._CGRS = MyUtils.CnvSng(LblNewGross.Text)
      ._CNETAS = MyUtils.CnvSng(LblNewNet.Text)
      ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._RSNCD = TxtReason.Text
      'Reason Codes
      SetCResnTip()
      ._CDESC = TxtDesc.Text
      With MyTPAYMNT
        .In_ListNo = WrkListNo
        .In_Type = WrkType
        .In_Year = WrkYear
        .In_Dst = MyUtils.CnvSng(TxtDist.Text)
        .In_Phs = ""
        .In_TaxT = MyUtils.CnvSng(LblNewAmt.Text)
        ' added 9/20/23  using control file to check if Not to split using marks previous commented out code
        If MyNosb = True Then
          If MyTXINV._TAXT > 0 And MyTXINV._TAX2 = 0 Then
            .In_NoSbil = True
          End If
        End If
        .CalcPaySplit()
      End With
      ._CETAX = MyUtils.Round(MyTPAYMNT.Out_TaxT, 2)
      ._IMVIDNo = TxtID.Text
      ._PRF = Mid(MyUserID, 1, 10)
      ._CHDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._CHTIME = Format(DateTime.Now, "hhmmss")
    End With

    With MyTXINV
      ._LISTNo = WrkListNo
      ._YEAR = WrkYear
      ._TYPE = WrkType
      ._NAME = TxtName.Text
      ._LETT = Mid$(TxtName.Text, 1, 1)
      ._SNAME = TxtSname.Text
      ._ADD1 = TxtAdd1.Text
      ._ADD2 = TxtAdd2.Text
      ._CITY = TxtCity.Text
      ._STATE = TxtState.Text
      ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
      ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
      ._DIST = MyUtils.CnvSng(TxtDist.Text)
      ._IMVIDNo = TxtID.Text
      ._IMVREG = TxtReg.Text
      ._CLASS = MyUtils.CnvSng(TxtClass.Text)
      ._MVYR = MyUtils.CnvSng(TxtMVYear.Text)
      ._MAKE = TxtMake.Text
      ._MODEL = TxtModel.Text
      ._SSNo = MyUtils.CnvSng(TxtSSNo.Text)
      ._SS2 = MyUtils.CnvSng(TxtSS2.Text)
      ._OID = TxtOid.Text
      If Trim(._ASS) = "" Then
        ._ASS = Trim(MyTXCOEA._C1MPCD)
      End If
      ._CCNO = WrkCCNo
      ._CDATE = MyUtils.SetDBDate(LblCCDate.Text)
      ._CCETAX = MyUtils.Round(MyTPAYMNT.Out_TaxT, 2)
      ._CCTX1 = MyUtils.Round(MyTPAYMNT.Out_Tax1, 2)
      ._CCTX2 = MyUtils.Round(MyTPAYMNT.Out_Tax2, 2)
      ._CCTX3 = MyUtils.Round(MyTPAYMNT.Out_Tax3, 2)
      ._CCTX4 = MyUtils.Round(MyTPAYMNT.Out_Tax4, 2)
      ._CGRS = MyUtils.CnvSng(LblNewGross.Text)
      ._CCEXP = MyUtils.CnvSng(LblNewExam.Text)
      ._CCRSN = TxtReason.Text
      ._BALD = MyUtils.CnvSng(LblNewAmt.Text) - ._PAYREC
      ._CASS1 = MyUtils.CnvSng(TxtAssmt1.Text)
      ._CCCD1 = TxtExempt1.Text
      ._CCCD2 = TxtExempt2.Text
      ._CCCD3 = TxtExempt3.Text
      ._CCCD4 = TxtExempt4.Text
      ._CCCD5 = TxtExempt5.Text
      ._CEXA1 = MyUtils.CnvSng(TxtExam1.Text)
      ._CEXA2 = MyUtils.CnvSng(TxtExam2.Text)
      ._CEXA3 = MyUtils.CnvSng(TxtExam3.Text)
      ._CEXA4 = MyUtils.CnvSng(TxtExam4.Text)
      ._CEXA5 = MyUtils.CnvSng(TxtExam5.Text)
      ._ETC1 = "2"
    End With


  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtReason, "")
    ErrProv.SetError(LblNewAmt, "")
    ErrProv.SetError(TxtExempt1, "")
    ErrProv.SetError(TxtExempt2, "")
    ErrProv.SetError(TxtExempt3, "")
    ErrProv.SetError(TxtExempt4, "")
    ErrProv.SetError(TxtExempt5, "")
    ErrProv.SetError(LblNewNet, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
        Case "name"
          ErrProv.SetError(TxtName, ErrorMsg(I))
        Case "rsncd"
          ErrProv.SetError(TxtReason, ErrorMsg(I))
        Case "cetax"
          ErrProv.SetError(LblNewAmt, ErrorMsg(I))
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
          ErrProv.SetError(LblNewNet, ErrorMsg(I))
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

    WrkTip = Ttp1.GetToolTip(TxtReason)
    If Mid(WrkTip, 1, 1) = "*" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Invalid Reason Code"
      I = I + 1
    End If

    If TxtReason.Text = "" Then
      ErrorField(I) = "rsncd"
      ErrorMsg(I) = "Reason Code is required"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblNewNet.Text) < 0 Then
      ErrorField(I) = "net"
      ErrorMsg(I) = "Net Assessment cannot be negative"
      I = I + 1
    End If
  End Sub

  Private Sub FrmTA8114R_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTA811.SbpScreen.Text = "TA8114R"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub TxtAssmt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAssmt1.TextChanged
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkCode As String

    WrkCode = ""
    If Not TxtAssmt1.Modified Then Exit Sub
    CalcProrateMonth(MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblSalePct.Text = WrkPct
    LblSaleNet.Text = WrkAdjNet
    LblNewProrate.Text = WrkAdjNet
    CalcChg()
  End Sub
  Private Sub TxtExam1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam1.TextChanged
    If Not TxtExam1.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam2.TextChanged
    If Not TxtExam2.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam3.TextChanged
    If Not TxtExam3.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam4.TextChanged
    If Not TxtExam4.Modified Then Exit Sub
    CalcChg()
  End Sub
  Private Sub TxtExam5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExam5.TextChanged
    If Not TxtExam5.Modified Then Exit Sub
    CalcChg()
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
  Private Sub TxtExempt1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt1.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt1.Text)
    TxtExam1.Text = WrkTxExem(0)
    CalcChg()

  End Sub
  Private Sub TxtExempt2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt2.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt2.Text)
    TxtExam2.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt3.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt3.Text)
    TxtExam3.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt4.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt4.Text)
    TxtExam4.Text = WrkTxExem(0)
    CalcChg()
  End Sub
  Private Sub TxtExempt5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtExempt5.TextChanged
    Dim WrkTxExem As String()

    If LoadScrn Then Exit Sub

    WrkTxExem = GetTXExem(TxtExempt5.Text)
    TxtExam5.Text = WrkTxExem(0)
    CalcChg()
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
  Private Sub SetCResnTip()
    Dim WrkDesc As String

    If Not TxtReason.Modified And Not LoadScrn Then Exit Sub

    WrkDesc = GetTXCResnDesc(TxtReason.Text)
    Ttp1.SetToolTip(TxtReason, WrkDesc)
  End Sub
  Public Sub GetTxCOEA()
    Dim WrkSaleMonth As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single

    With MyTXCOEA
      If WrkListNo = 0 Then
        WrkListNo = ._LISTNo
        WrkYear = ._YEAR
        WrkType = ._TYPE
      End If
      WrkDist = ._DIST
      LblListNo.Text = ._LISTNo
      LblYear.Text = ._YEAR
      LblType.Text = ._TYPE
      LblCCDate.Text = MyUtils.GetDBDate(._CDATE)
      TxtName.Text = Trim(._NAME)
      TxtDist.Text = ._DIST
      LblNewGross.Text = FormatNumber(._CGRS, 0)
      LblNewExam.Text = FormatNumber(._EX1 + ._EX2 + ._EX3 + ._EX4 +
          ._EX5 + ._EX6 + ._EX7, 0)
      LblNewNet.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text), 0)
      TxtReason.Text = Trim(._RSNCD)
      TxtDesc.Text = Trim(._CDESC)
      TxtOverAmt.Enabled = False
      If Trim(._CTXOV) = "Y" Then
        ChkOver.Checked = True
        TxtOverAmt.Enabled = True
        TxtOverAmt.Text = MyUtils.FmtCurrency(._CETAX)
      End If
      TxtAssmt1.Text = ._CGRS
      CalcProrateCode(Trim(._C1MSCD), ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
      TxtSaleMonth.Text = WrkSaleMonth
      LblSalePct.Text = WrkPct
      LblSaleNet.Text = WrkAdjNet
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
      TxtExam1.Text = ._EX1
      TxtExam2.Text = ._EX2
      TxtExam3.Text = ._EX3
      TxtExam4.Text = ._EX4
      TxtExam5.Text = ._EX5
      EntryDate = MyUtils.GetDBDate(._CHDATE)
    End With
  End Sub

  Public Sub GetOrigTxCOEA(ByVal WrkCCNo As Integer)
    Dim MyorigTXCOEA As TXCOEA.MyData
    Dim WrkSaleMonth As Integer
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single

    MyorigTXCOEA = New TXCOEA.MyData(myDBConnect)
    MyorigTXCOEA.GetOneRecordP(WrkCCNo)
    If Not MyorigTXCOEA.RecordNotFound Then
      With MyorigTXCOEA
        LblOrig.Text = "C/C " & Str$(WrkCCNo)
        LblOrig.ForeColor = Color.Fuchsia
        LblOrigGross.Text = FormatNumber(._CGRS, 0)
        CalcProrateCode(Trim(._C1MSCD), ._CGRS, WrkProrate, WrkAdjNet, WrkPct, WrkSaleMonth)
        If WrkAddMode And MyUtils.CnvSng(TxtSaleMonth.Text) = 0 Then
          TxtSaleMonth.Text = WrkSaleMonth
          LblSalePct.Text = WrkPct
          LblSaleNet.Text = WrkAdjNet
        End If
        LblOrigProrate.Text = FormatNumber(._CGRS - WrkProrate, 0)
        LblOrigExam.Text = FormatNumber(._EX1 + ._EX2 + ._EX3 + ._EX4 +
        ._EX5 + ._EX6 + ._EX7, 0)
        LblOrigNet.Text = FormatNumber(MyUtils.CnvSng(LblOrigGross.Text) - MyUtils.CnvSng(LblOrigExam.Text) - MyUtils.CnvSng(LblOrigProrate.Text), 0)
        LblOrigAmt.Text = MyUtils.FmtCurrency(._CETAX)
        LblOrigAssmt1.Text = ._CGRS
        'Exemption Codes 'Removed 10/16/23
        'TxtExempt1.Text = Trim(._EXCD1)
        'TxtExempt2.Text = Trim(._EXCD2)
        'TxtExempt3.Text = Trim(._EXCD3)
        'TxtExempt4.Text = Trim(._EXCD4)
        'TxtExempt5.Text = Trim(._EXCD5)
        'SetExem1Tip()
        'SetExem2Tip()
        'SetExem3Tip()
        'SetExem4Tip()
        'SetExem5Tip()
        LblOrigExam1.Text = ._EX1
        LblOrigExam2.Text = ._EX2
        LblOrigExam3.Text = ._EX3
        LblOrigExam4.Text = ._EX4
        LblOrigExam5.Text = ._EX5
      End With
    End If
  End Sub
  Sub CalcChg()
    Dim WrkProRate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkNewAmt As Decimal
    Dim WrkPct As Single
    Dim WrkCode As String
    If LoadScrn Then Exit Sub

    WrkCode = ""
    LblNewGross.Text = FormatNumber(MyUtils.CnvSng(TxtAssmt1.Text), 0)
    CalcProrateMonth(MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProRate, WrkAdjNet, WrkPct, WrkCode)
    LblNewProrate.Text = FormatNumber(WrkAdjNet, 0)
    LblNewExam.Text = FormatNumber(MyUtils.CnvSng(TxtExam1.Text) + MyUtils.CnvSng(TxtExam2.Text) + MyUtils.CnvSng(TxtExam3.Text) +
    MyUtils.CnvSng(TxtExam4.Text) + MyUtils.CnvSng(TxtExam5.Text), 0)
    LblNewNet.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblNewExam.Text) - MyUtils.CnvSng(LblNewProrate.Text), 0)
    If ChkOver.Checked Then
      WrkNewAmt = MyUtils.CnvSng(TxtOverAmt.Text)
    Else
      WrkNewAmt = MyUtils.CnvSng(LblNewNet.Text) * MyUtils.CnvSng(LblMRate.Text)
    End If

    With MyTPAYMNT
      .In_ListNo = WrkListNo
      .In_Type = WrkType
      .In_Year = WrkYear
      .In_Dst = MyUtils.CnvSng(TxtDist.Text)
      .In_Phs = ""
      .In_TaxT = MyUtils.Round(WrkNewAmt, 2)
      ' added 9/20/23  using control file to check if Not to split using marks previous commented out code
      If MyNosb = True Then
        If MyTXINV._TAXT > 0 And MyTXINV._TAX2 = 0 Then
          .In_NoSbil = True
        End If
      End If
      .CalcPaySplit()
      LblNewAmt.Text = MyUtils.FmtCurrency(.Out_TaxT)
    End With

    LblChgGross.Text = FormatNumber(MyUtils.CnvSng(LblNewGross.Text) - MyUtils.CnvSng(LblOrigGross.Text), 0)
    LblChgExam.Text = FormatNumber(MyUtils.CnvSng(LblNewExam.Text) - MyUtils.CnvSng(LblOrigExam.Text), 0)
    LblChgProrate.Text = FormatNumber(MyUtils.CnvSng(LblNewProrate.Text) - MyUtils.CnvSng(LblOrigProrate.Text), 0)
    LblChgNet.Text = FormatNumber(MyUtils.CnvSng(LblNewNet.Text) - MyUtils.CnvSng(LblOrigNet.Text), 0)
    LblChgAmt.Text = MyUtils.FmtCurrency(MyUtils.CnvSng(LblNewAmt.Text) - MyUtils.CnvSng(LblOrigAmt.Text))
    LblChgAssmt1.Text = MyUtils.CnvSng(TxtAssmt1.Text) - MyUtils.CnvSng(LblOrigAssmt1.Text)
    LblChgExam1.Text = MyUtils.CnvSng(TxtExam1.Text) - MyUtils.CnvSng(LblOrigExam1.Text)
    LblChgExam2.Text = MyUtils.CnvSng(TxtExam2.Text) - MyUtils.CnvSng(LblOrigExam2.Text)
    LblChgExam3.Text = MyUtils.CnvSng(TxtExam3.Text) - MyUtils.CnvSng(LblOrigExam3.Text)
    LblChgExam4.Text = MyUtils.CnvSng(TxtExam4.Text) - MyUtils.CnvSng(LblOrigExam4.Text)
    LblChgExam5.Text = MyUtils.CnvSng(TxtExam5.Text) - MyUtils.CnvSng(LblOrigExam5.Text)
  End Sub
  Public Sub CalcProrateMonth(ByVal In_SaleMonth As Integer, ByVal In_Value As Integer,
    ByRef Out_Prorate As Integer, ByRef Out_AdjNet As Integer, ByRef Out_Pct As Single,
    ByRef Out_SaleCode As String)

    Dim WrkTxMVPCT As String()

    WrkTxMVPCT = GetTXMVPCTL1("M", In_SaleMonth)
    Out_SaleCode = WrkTxMVPCT(1)
    Out_Pct = MyUtils.CnvSng(WrkTxMVPCT(0))
    If MyProrateRound Then
      Out_AdjNet = MyUtils.Round10(In_Value * Out_Pct, "Normal")
    Else
      Out_AdjNet = MyUtils.Round(In_Value * Out_Pct, 0)
    End If
    Out_Prorate = In_Value - Out_AdjNet
  End Sub
  Public Sub CalcProrateCode(ByVal In_SaleCode As String, ByVal In_Value As Integer,
    ByRef Out_Prorate As Integer, ByRef Out_AdjNet As Integer,
    ByRef Out_Pct As Single, ByRef Out_SaleMonth As Integer)

    Dim WrkTxMVPCT As String()

    WrkTxMVPCT = GetTXMVPCT("M", In_SaleCode)
    Out_SaleMonth = MyUtils.CnvSng(WrkTxMVPCT(1))
    Out_Pct = MyUtils.CnvSng(WrkTxMVPCT(0))
    If MyProrateRound Then
      Out_AdjNet = MyUtils.Round10(In_Value * Out_Pct, "Normal")
    Else
      Out_AdjNet = MyUtils.Round(In_Value * Out_Pct, 0)
    End If
    Out_Prorate = In_Value - Out_AdjNet
  End Sub
  Private Sub LnkReason_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkReason.LinkClicked
    MyFrmListCResn = New FrmListCResn
    MyFrmListCResn.MdiParent = Me.ParentForm
    MyFrmListCResn.WrkType = WrkType
    MyFrmListCResn.WrkCode = TxtReason.Text
    MyFrmListCResn.Show()
  End Sub
  Private Sub TxtOverAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOverAmt.TextChanged
    Call CalcChg()
  End Sub
  Private Sub TxtSaleMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSaleMonth.TextChanged
    CalcSale()
  End Sub
  Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtAssmt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAssmt1.KeyPress
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
  Private Sub TxtClass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtClass.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtMVYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMVYear.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSaleMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSaleMonth.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtOverAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOverAmt.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub ChkOver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOver.Click
    If ChkOver.Checked Then
      TxtOverAmt.Text = "0"
      TxtOverAmt.Enabled = True
    Else
      TxtOverAmt.Text = ""
      TxtOverAmt.Enabled = False
    End If
  End Sub
  Private Sub TxtReason_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtReason.Leave
    SetCResnTip()
  End Sub
  Private Sub LnkClass_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkClass.LinkClicked
    MyFrmListCodes = New FrmListCodes
    MyFrmListCodes.MdiParent = Me.ParentForm
    MyFrmListCodes.WrkFamily = WrkFamily
    MyFrmListCodes.WrkFieldNo = 1
    MyFrmListCodes.WrkCode = MyUtils.CnvSng(TxtClass.Text)
    MyFrmListCodes.Show()
  End Sub

  Private Sub LnkSaleMonth_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkSaleMonth.LinkClicked
    MyFrmListMvpct = New FrmListMvpct
    MyFrmListMvpct.MdiParent = Me.ParentForm
    MyFrmListMvpct.WrkType = "M"
    MyFrmListMvpct.Show()
  End Sub
  Public Sub CalcSale()
    Dim WrkProrate As Integer
    Dim WrkAdjNet As Integer
    Dim WrkPct As Single
    Dim WrkProPct As Single
    Dim WrkCode As String

    WrkCode = ""
    CalcProrateMonth(MyUtils.CnvSng(TxtSaleMonth.Text), MyUtils.CnvSng(TxtAssmt1.Text), WrkProrate, WrkAdjNet, WrkPct, WrkCode)
    LblSalePct.Text = FormatNumber(WrkPct, 3)
    LblSaleNet.Text = WrkAdjNet
    LblNewProrate.Text = WrkAdjNet
    WrkProPct = 1 - WrkPct
    If WrkAddMode Then
      TxtExam1.Text = Math.Round(MyUtils.CnvSng(LblOrigExam1.Text) * WrkProPct, 0)
      TxtExam2.Text = Math.Round(MyUtils.CnvSng(LblOrigExam2.Text) * WrkProPct, 0)
      TxtExam3.Text = Math.Round(MyUtils.CnvSng(LblOrigExam3.Text) * WrkProPct, 0)
      TxtExam4.Text = Math.Round(MyUtils.CnvSng(LblOrigExam4.Text) * WrkProPct, 0)
      TxtExam5.Text = Math.Round(MyUtils.CnvSng(LblOrigExam5.Text) * WrkProPct, 0)
    End If
    CalcChg()
  End Sub
End Class






