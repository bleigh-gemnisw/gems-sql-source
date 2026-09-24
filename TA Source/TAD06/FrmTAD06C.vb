Public Class FrmTAD06C
  Inherits System.Windows.Forms.Form
  Dim myTXCOOA As TXCOOA.MyData
  Dim myTXREAA As TXREAA.MyData
  Friend WrkListNo As Integer
  Friend WrkDevlt As String
  Friend WrkYear As Integer
  Friend WithEvents RbTaxable As RadioButton
  Friend WithEvents Label3 As Label
  Friend WithEvents Label2 As Label
  Dim LoadScrn As Boolean

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
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label29 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
  Friend WithEvents TxtDevlt As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label19 As System.Windows.Forms.Label
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents RbNew As System.Windows.Forms.RadioButton
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents LblAmount As System.Windows.Forms.Label
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtSname As System.Windows.Forms.TextBox
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents LblRECity As System.Windows.Forms.Label
  Friend WithEvents LblREAdd2 As System.Windows.Forms.Label
  Friend WithEvents LblREAdd1 As System.Windows.Forms.Label
  Friend WithEvents LblRESname As System.Windows.Forms.Label
  Friend WithEvents LblREName As System.Windows.Forms.Label
  Friend WithEvents LblAddlTax As System.Windows.Forms.Label
  Friend WithEvents LblPct As System.Windows.Forms.Label
  Friend WithEvents LblDays As System.Windows.Forms.Label
  Friend WithEvents DtPckProrate As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtAmount As System.Windows.Forms.TextBox
  Friend WithEvents LblUnit As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents LblSMap As System.Windows.Forms.Label
  Friend WithEvents Label28 As System.Windows.Forms.Label
  Friend WithEvents LblMap As System.Windows.Forms.Label
  Friend WithEvents Label26 As System.Windows.Forms.Label
  Friend WithEvents LblDist As System.Windows.Forms.Label
  Friend WithEvents Label24 As System.Windows.Forms.Label
  Friend WithEvents LblLoc As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents LblREState As System.Windows.Forms.Label
  Friend WithEvents LblReZip5 As System.Windows.Forms.Label
  Friend WithEvents LblREZip4 As System.Windows.Forms.Label
  Friend WithEvents RbVet As System.Windows.Forms.RadioButton
  Friend WithEvents RbEld As System.Windows.Forms.RadioButton
  Friend WithEvents TxtReListNo As System.Windows.Forms.TextBox
  Friend WithEvents LblGrantor As System.Windows.Forms.Label
  Friend WithEvents LblProrate As System.Windows.Forms.Label
  Friend WithEvents LblProrateText As System.Windows.Forms.Label
  Friend WithEvents LblGrantorText As System.Windows.Forms.Label
  Friend WithEvents LblIncr As System.Windows.Forms.Label
  Friend WithEvents LblIncrText As System.Windows.Forms.Label
  Friend WithEvents TxtAfterPct As System.Windows.Forms.TextBox
  Friend WithEvents TxtBeforePct As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.LblIncr = New System.Windows.Forms.Label()
    Me.LblIncrText = New System.Windows.Forms.Label()
    Me.LblGrantor = New System.Windows.Forms.Label()
    Me.LblGrantorText = New System.Windows.Forms.Label()
    Me.LblAddlTax = New System.Windows.Forms.Label()
    Me.LblProrate = New System.Windows.Forms.Label()
    Me.LblPct = New System.Windows.Forms.Label()
    Me.LblDays = New System.Windows.Forms.Label()
    Me.Label30 = New System.Windows.Forms.Label()
    Me.Label29 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.LblProrateText = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtDevlt = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtReListNo = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.TxtAfterPct = New System.Windows.Forms.TextBox()
    Me.TxtBeforePct = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.Label19 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.RbTaxable = New System.Windows.Forms.RadioButton()
    Me.RbVet = New System.Windows.Forms.RadioButton()
    Me.RbEld = New System.Windows.Forms.RadioButton()
    Me.RbNew = New System.Windows.Forms.RadioButton()
    Me.DtPckProrate = New System.Windows.Forms.DateTimePicker()
    Me.Label21 = New System.Windows.Forms.Label()
    Me.TxtAmount = New System.Windows.Forms.TextBox()
    Me.LblAmount = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.LblREZip4 = New System.Windows.Forms.Label()
    Me.LblReZip5 = New System.Windows.Forms.Label()
    Me.LblREState = New System.Windows.Forms.Label()
    Me.LblUnit = New System.Windows.Forms.Label()
    Me.Label32 = New System.Windows.Forms.Label()
    Me.LblSMap = New System.Windows.Forms.Label()
    Me.Label28 = New System.Windows.Forms.Label()
    Me.LblMap = New System.Windows.Forms.Label()
    Me.Label26 = New System.Windows.Forms.Label()
    Me.LblDist = New System.Windows.Forms.Label()
    Me.Label24 = New System.Windows.Forms.Label()
    Me.LblLoc = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblRECity = New System.Windows.Forms.Label()
    Me.LblREAdd2 = New System.Windows.Forms.Label()
    Me.LblREAdd1 = New System.Windows.Forms.Label()
    Me.LblRESname = New System.Windows.Forms.Label()
    Me.LblREName = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox2.SuspendLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(104, 12)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(68, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.LblIncr)
    Me.GroupBox2.Controls.Add(Me.LblIncrText)
    Me.GroupBox2.Controls.Add(Me.LblGrantor)
    Me.GroupBox2.Controls.Add(Me.LblGrantorText)
    Me.GroupBox2.Controls.Add(Me.LblAddlTax)
    Me.GroupBox2.Controls.Add(Me.LblProrate)
    Me.GroupBox2.Controls.Add(Me.LblPct)
    Me.GroupBox2.Controls.Add(Me.LblDays)
    Me.GroupBox2.Controls.Add(Me.Label30)
    Me.GroupBox2.Controls.Add(Me.Label29)
    Me.GroupBox2.Controls.Add(Me.Label15)
    Me.GroupBox2.Controls.Add(Me.LblProrateText)
    Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox2.Location = New System.Drawing.Point(520, 224)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(216, 120)
    Me.GroupBox2.TabIndex = 37
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Totals"
    '
    'LblIncr
    '
    Me.LblIncr.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblIncr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblIncr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblIncr.Location = New System.Drawing.Point(136, 48)
    Me.LblIncr.Name = "LblIncr"
    Me.LblIncr.Size = New System.Drawing.Size(72, 16)
    Me.LblIncr.TabIndex = 27
    Me.LblIncr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblIncrText
    '
    Me.LblIncrText.AutoSize = True
    Me.LblIncrText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblIncrText.Location = New System.Drawing.Point(8, 48)
    Me.LblIncrText.Name = "LblIncrText"
    Me.LblIncrText.Size = New System.Drawing.Size(93, 13)
    Me.LblIncrText.TabIndex = 26
    Me.LblIncrText.Text = "Increment Amount"
    '
    'LblGrantor
    '
    Me.LblGrantor.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGrantor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGrantor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGrantor.Location = New System.Drawing.Point(136, 80)
    Me.LblGrantor.Name = "LblGrantor"
    Me.LblGrantor.Size = New System.Drawing.Size(72, 16)
    Me.LblGrantor.TabIndex = 25
    Me.LblGrantor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblGrantorText
    '
    Me.LblGrantorText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGrantorText.Location = New System.Drawing.Point(8, 80)
    Me.LblGrantorText.Name = "LblGrantorText"
    Me.LblGrantorText.Size = New System.Drawing.Size(104, 16)
    Me.LblGrantorText.TabIndex = 24
    Me.LblGrantorText.Text = "Grantors Benefit"
    '
    'LblAddlTax
    '
    Me.LblAddlTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAddlTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAddlTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAddlTax.Location = New System.Drawing.Point(136, 96)
    Me.LblAddlTax.Name = "LblAddlTax"
    Me.LblAddlTax.Size = New System.Drawing.Size(72, 16)
    Me.LblAddlTax.TabIndex = 22
    Me.LblAddlTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblProrate
    '
    Me.LblProrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblProrate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblProrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblProrate.Location = New System.Drawing.Point(136, 64)
    Me.LblProrate.Name = "LblProrate"
    Me.LblProrate.Size = New System.Drawing.Size(72, 16)
    Me.LblProrate.TabIndex = 21
    Me.LblProrate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblPct
    '
    Me.LblPct.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPct.Location = New System.Drawing.Point(136, 32)
    Me.LblPct.Name = "LblPct"
    Me.LblPct.Size = New System.Drawing.Size(40, 16)
    Me.LblPct.TabIndex = 19
    Me.LblPct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblDays
    '
    Me.LblDays.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblDays.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDays.Location = New System.Drawing.Point(136, 16)
    Me.LblDays.Name = "LblDays"
    Me.LblDays.Size = New System.Drawing.Size(32, 16)
    Me.LblDays.TabIndex = 18
    Me.LblDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label30
    '
    Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label30.Location = New System.Drawing.Point(8, 32)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(64, 16)
    Me.Label30.TabIndex = 16
    Me.Label30.Text = "Percentage"
    '
    'Label29
    '
    Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label29.Location = New System.Drawing.Point(8, 16)
    Me.Label29.Name = "Label29"
    Me.Label29.Size = New System.Drawing.Size(64, 16)
    Me.Label29.TabIndex = 15
    Me.Label29.Text = "No of Days"
    '
    'Label15
    '
    Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.Location = New System.Drawing.Point(8, 96)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(104, 16)
    Me.Label15.TabIndex = 23
    Me.Label15.Text = "Additional tax (Est)"
    '
    'LblProrateText
    '
    Me.LblProrateText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblProrateText.Location = New System.Drawing.Point(8, 64)
    Me.LblProrateText.Name = "LblProrateText"
    Me.LblProrateText.Size = New System.Drawing.Size(120, 16)
    Me.LblProrateText.TabIndex = 20
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtDevlt
    '
    Me.TxtDevlt.Location = New System.Drawing.Point(264, 12)
    Me.TxtDevlt.MaxLength = 6
    Me.TxtDevlt.Name = "TxtDevlt"
    Me.TxtDevlt.Size = New System.Drawing.Size(32, 20)
    Me.TxtDevlt.TabIndex = 1
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(178, 16)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(80, 16)
    Me.Label13.TabIndex = 47
    Me.Label13.Text = "Developers Lot"
    '
    'TxtReListNo
    '
    Me.TxtReListNo.Location = New System.Drawing.Point(390, 12)
    Me.TxtReListNo.MaxLength = 7
    Me.TxtReListNo.Name = "TxtReListNo"
    Me.TxtReListNo.Size = New System.Drawing.Size(67, 20)
    Me.TxtReListNo.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(463, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 16)
    Me.Label1.TabIndex = 52
    Me.Label1.Text = "(if different)"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.TxtAfterPct)
    Me.GroupBox1.Controls.Add(Me.TxtBeforePct)
    Me.GroupBox1.Controls.Add(Me.Label20)
    Me.GroupBox1.Controls.Add(Me.Label19)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(8, 256)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(144, 72)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Percentage Owned"
    '
    'TxtAfterPct
    '
    Me.TxtAfterPct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAfterPct.Location = New System.Drawing.Point(96, 48)
    Me.TxtAfterPct.MaxLength = 6
    Me.TxtAfterPct.Name = "TxtAfterPct"
    Me.TxtAfterPct.Size = New System.Drawing.Size(40, 20)
    Me.TxtAfterPct.TabIndex = 1
    '
    'TxtBeforePct
    '
    Me.TxtBeforePct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBeforePct.Location = New System.Drawing.Point(96, 24)
    Me.TxtBeforePct.MaxLength = 6
    Me.TxtBeforePct.Name = "TxtBeforePct"
    Me.TxtBeforePct.Size = New System.Drawing.Size(40, 20)
    Me.TxtBeforePct.TabIndex = 0
    '
    'Label20
    '
    Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label20.Location = New System.Drawing.Point(8, 48)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(80, 16)
    Me.Label20.TabIndex = 44
    Me.Label20.Text = "After Transfer"
    '
    'Label19
    '
    Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label19.Location = New System.Drawing.Point(8, 24)
    Me.Label19.Name = "Label19"
    Me.Label19.Size = New System.Drawing.Size(88, 16)
    Me.Label19.TabIndex = 43
    Me.Label19.Text = "Before Transfer"
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.RbTaxable)
    Me.GroupBox3.Controls.Add(Me.RbVet)
    Me.GroupBox3.Controls.Add(Me.RbEld)
    Me.GroupBox3.Controls.Add(Me.RbNew)
    Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox3.Location = New System.Drawing.Point(160, 256)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(136, 88)
    Me.GroupBox3.TabIndex = 5
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Proration Code"
    '
    'RbTaxable
    '
    Me.RbTaxable.AutoSize = True
    Me.RbTaxable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbTaxable.Location = New System.Drawing.Point(7, 65)
    Me.RbTaxable.Name = "RbTaxable"
    Me.RbTaxable.Size = New System.Drawing.Size(113, 17)
    Me.RbTaxable.TabIndex = 3
    Me.RbTaxable.Text = "Exempt to Taxable"
    '
    'RbVet
    '
    Me.RbVet.AutoSize = True
    Me.RbVet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbVet.Location = New System.Drawing.Point(8, 48)
    Me.RbVet.Name = "RbVet"
    Me.RbVet.Size = New System.Drawing.Size(62, 17)
    Me.RbVet.TabIndex = 2
    Me.RbVet.Text = "Veteran"
    '
    'RbEld
    '
    Me.RbEld.AutoSize = True
    Me.RbEld.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbEld.Location = New System.Drawing.Point(8, 32)
    Me.RbEld.Name = "RbEld"
    Me.RbEld.Size = New System.Drawing.Size(108, 17)
    Me.RbEld.TabIndex = 1
    Me.RbEld.Text = "Elderly Exemption"
    '
    'RbNew
    '
    Me.RbNew.AutoSize = True
    Me.RbNew.Checked = True
    Me.RbNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbNew.Location = New System.Drawing.Point(8, 16)
    Me.RbNew.Name = "RbNew"
    Me.RbNew.Size = New System.Drawing.Size(109, 17)
    Me.RbNew.TabIndex = 0
    Me.RbNew.TabStop = True
    Me.RbNew.Text = "New Construction"
    '
    'DtPckProrate
    '
    Me.DtPckProrate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckProrate.Location = New System.Drawing.Point(392, 280)
    Me.DtPckProrate.Name = "DtPckProrate"
    Me.DtPckProrate.Size = New System.Drawing.Size(88, 20)
    Me.DtPckProrate.TabIndex = 6
    '
    'Label21
    '
    Me.Label21.Location = New System.Drawing.Point(312, 280)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(80, 16)
    Me.Label21.TabIndex = 59
    Me.Label21.Text = "Proration Date"
    '
    'TxtAmount
    '
    Me.TxtAmount.Location = New System.Drawing.Point(392, 304)
    Me.TxtAmount.MaxLength = 12
    Me.TxtAmount.Name = "TxtAmount"
    Me.TxtAmount.Size = New System.Drawing.Size(96, 20)
    Me.TxtAmount.TabIndex = 7
    '
    'LblAmount
    '
    Me.LblAmount.Location = New System.Drawing.Point(344, 307)
    Me.LblAmount.Name = "LblAmount"
    Me.LblAmount.Size = New System.Drawing.Size(48, 16)
    Me.LblAmount.TabIndex = 60
    Me.LblAmount.Text = "Amount"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.LblREZip4)
    Me.GroupBox4.Controls.Add(Me.LblReZip5)
    Me.GroupBox4.Controls.Add(Me.LblREState)
    Me.GroupBox4.Controls.Add(Me.LblUnit)
    Me.GroupBox4.Controls.Add(Me.Label32)
    Me.GroupBox4.Controls.Add(Me.LblSMap)
    Me.GroupBox4.Controls.Add(Me.Label28)
    Me.GroupBox4.Controls.Add(Me.LblMap)
    Me.GroupBox4.Controls.Add(Me.Label26)
    Me.GroupBox4.Controls.Add(Me.LblDist)
    Me.GroupBox4.Controls.Add(Me.Label24)
    Me.GroupBox4.Controls.Add(Me.LblLoc)
    Me.GroupBox4.Controls.Add(Me.Label7)
    Me.GroupBox4.Controls.Add(Me.LblRECity)
    Me.GroupBox4.Controls.Add(Me.LblREAdd2)
    Me.GroupBox4.Controls.Add(Me.LblREAdd1)
    Me.GroupBox4.Controls.Add(Me.LblRESname)
    Me.GroupBox4.Controls.Add(Me.LblREName)
    Me.GroupBox4.Controls.Add(Me.Label8)
    Me.GroupBox4.Controls.Add(Me.Label9)
    Me.GroupBox4.Controls.Add(Me.Label10)
    Me.GroupBox4.Controls.Add(Me.Label11)
    Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox4.Location = New System.Drawing.Point(8, 42)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(384, 200)
    Me.GroupBox4.TabIndex = 70
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Real Estate Name and Address"
    '
    'LblREZip4
    '
    Me.LblREZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREZip4.Location = New System.Drawing.Point(344, 112)
    Me.LblREZip4.Name = "LblREZip4"
    Me.LblREZip4.Size = New System.Drawing.Size(32, 16)
    Me.LblREZip4.TabIndex = 82
    '
    'LblReZip5
    '
    Me.LblReZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblReZip5.Location = New System.Drawing.Point(296, 112)
    Me.LblReZip5.Name = "LblReZip5"
    Me.LblReZip5.Size = New System.Drawing.Size(40, 16)
    Me.LblReZip5.TabIndex = 81
    '
    'LblREState
    '
    Me.LblREState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREState.Location = New System.Drawing.Point(264, 112)
    Me.LblREState.Name = "LblREState"
    Me.LblREState.Size = New System.Drawing.Size(24, 16)
    Me.LblREState.TabIndex = 80
    '
    'LblUnit
    '
    Me.LblUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblUnit.Location = New System.Drawing.Point(344, 160)
    Me.LblUnit.Name = "LblUnit"
    Me.LblUnit.Size = New System.Drawing.Size(32, 16)
    Me.LblUnit.TabIndex = 79
    '
    'Label32
    '
    Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label32.Location = New System.Drawing.Point(304, 160)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(32, 16)
    Me.Label32.TabIndex = 78
    Me.Label32.Text = "Unit"
    '
    'LblSMap
    '
    Me.LblSMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblSMap.Location = New System.Drawing.Point(280, 176)
    Me.LblSMap.Name = "LblSMap"
    Me.LblSMap.Size = New System.Drawing.Size(88, 16)
    Me.LblSMap.TabIndex = 77
    '
    'Label28
    '
    Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label28.Location = New System.Drawing.Point(224, 176)
    Me.Label28.Name = "Label28"
    Me.Label28.Size = New System.Drawing.Size(48, 16)
    Me.Label28.TabIndex = 76
    Me.Label28.Text = "S. Map"
    '
    'LblMap
    '
    Me.LblMap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMap.Location = New System.Drawing.Point(104, 176)
    Me.LblMap.Name = "LblMap"
    Me.LblMap.Size = New System.Drawing.Size(112, 16)
    Me.LblMap.TabIndex = 75
    '
    'Label26
    '
    Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label26.Location = New System.Drawing.Point(8, 176)
    Me.Label26.Name = "Label26"
    Me.Label26.Size = New System.Drawing.Size(88, 16)
    Me.Label26.TabIndex = 74
    Me.Label26.Text = "Map"
    '
    'LblDist
    '
    Me.LblDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDist.Location = New System.Drawing.Point(104, 144)
    Me.LblDist.Name = "LblDist"
    Me.LblDist.Size = New System.Drawing.Size(32, 16)
    Me.LblDist.TabIndex = 73
    '
    'Label24
    '
    Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label24.Location = New System.Drawing.Point(8, 144)
    Me.Label24.Name = "Label24"
    Me.Label24.Size = New System.Drawing.Size(56, 16)
    Me.Label24.TabIndex = 72
    Me.Label24.Text = "District"
    '
    'LblLoc
    '
    Me.LblLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblLoc.Location = New System.Drawing.Point(104, 160)
    Me.LblLoc.Name = "LblLoc"
    Me.LblLoc.Size = New System.Drawing.Size(192, 16)
    Me.LblLoc.TabIndex = 71
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(8, 160)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 70
    Me.Label7.Text = "Location#/Name"
    '
    'LblRECity
    '
    Me.LblRECity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRECity.Location = New System.Drawing.Point(96, 112)
    Me.LblRECity.Name = "LblRECity"
    Me.LblRECity.Size = New System.Drawing.Size(168, 16)
    Me.LblRECity.TabIndex = 63
    '
    'LblREAdd2
    '
    Me.LblREAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREAdd2.Location = New System.Drawing.Point(96, 88)
    Me.LblREAdd2.Name = "LblREAdd2"
    Me.LblREAdd2.Size = New System.Drawing.Size(272, 16)
    Me.LblREAdd2.TabIndex = 62
    '
    'LblREAdd1
    '
    Me.LblREAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREAdd1.Location = New System.Drawing.Point(96, 64)
    Me.LblREAdd1.Name = "LblREAdd1"
    Me.LblREAdd1.Size = New System.Drawing.Size(272, 16)
    Me.LblREAdd1.TabIndex = 61
    '
    'LblRESname
    '
    Me.LblRESname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblRESname.Location = New System.Drawing.Point(96, 40)
    Me.LblRESname.Name = "LblRESname"
    Me.LblRESname.Size = New System.Drawing.Size(272, 16)
    Me.LblRESname.TabIndex = 60
    Me.LblRESname.UseMnemonic = False
    '
    'LblREName
    '
    Me.LblREName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblREName.Location = New System.Drawing.Point(96, 16)
    Me.LblREName.Name = "LblREName"
    Me.LblREName.Size = New System.Drawing.Size(272, 16)
    Me.LblREName.TabIndex = 59
    Me.LblREName.UseMnemonic = False
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(8, 112)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(80, 16)
    Me.Label8.TabIndex = 58
    Me.Label8.Text = "City/State/Zip"
    '
    'Label9
    '
    Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label9.Location = New System.Drawing.Point(8, 64)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(80, 16)
    Me.Label9.TabIndex = 57
    Me.Label9.Text = "Street Address"
    '
    'Label10
    '
    Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label10.Location = New System.Drawing.Point(8, 40)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(80, 16)
    Me.Label10.TabIndex = 56
    Me.Label10.Text = "Second Name"
    '
    'Label11
    '
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(8, 16)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(48, 16)
    Me.Label11.TabIndex = 55
    Me.Label11.Text = "Name"
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.TxtZip4)
    Me.GroupBox5.Controls.Add(Me.TxtZip5)
    Me.GroupBox5.Controls.Add(Me.TxtCity)
    Me.GroupBox5.Controls.Add(Me.TxtState)
    Me.GroupBox5.Controls.Add(Me.TxtAdd2)
    Me.GroupBox5.Controls.Add(Me.TxtAdd1)
    Me.GroupBox5.Controls.Add(Me.TxtSname)
    Me.GroupBox5.Controls.Add(Me.TxtName)
    Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox5.Location = New System.Drawing.Point(392, 42)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(344, 136)
    Me.GroupBox5.TabIndex = 3
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "C/O Name and Address"
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(304, 112)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 7
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(264, 112)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 6
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(8, 112)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 4
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(240, 112)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 5
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(8, 88)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd2.TabIndex = 3
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(8, 64)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd1.TabIndex = 2
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(8, 40)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(280, 20)
    Me.TxtSname.TabIndex = 1
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(8, 16)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 0
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(16, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 16)
    Me.Label2.TabIndex = 73
    Me.Label2.Text = "List No"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(326, 15)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(58, 13)
    Me.Label3.TabIndex = 74
    Me.Label3.Text = "RE List No"
    '
    'FrmTAD06C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(744, 350)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.TxtAmount)
    Me.Controls.Add(Me.LblAmount)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.DtPckProrate)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtReListNo)
    Me.Controls.Add(Me.TxtDevlt)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.GroupBox2)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAD06C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Proration "
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTAD06C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkPcd As String
    Dim WrkMRate As Decimal
    Dim WrkTotTax As Decimal
    Dim TotAmount As Decimal
    myTXCOOA = New TXCOOA.MyData(myDBConnect)
    myTXREAA = New TXREAA.MyData(myDBConnect)

    LoadScrn = True

    With myTXCOOA
      .GetOneRecordP(WrkListNo, WrkDevlt, WrkYear)
      TxtListNo.Text = WrkListNo
      TxtDevlt.Text = WrkDevlt
      TxtReListNo.Text = ._RLIST
      TxtName.Text = Trim(._CONAM)
      TxtSname.Text = Trim(._CONAM2)
      TxtAdd1.Text = Trim(._COADD1)
      TxtAdd2.Text = Trim(._COADD2)
      TxtCity.Text = Trim(._COCITY)
      TxtState.Text = Trim(._COSTE)
      TxtZip5.Text = Format(._COZIP5, "00000")
      TxtZip4.Text = Format(._COZIP4, "0000")
      Call GetREAddr(TxtReListNo.Text, WrkYear)
      TxtBeforePct.Text = ._PCOBEF
      TxtAfterPct.Text = ._PCOAFT
      WrkPcd = ._PCD
      Select Case WrkPcd
        Case "E"
          LblGrantorText.Visible = True
          LblGrantor.Visible = True
          LblIncr.Visible = True
          TxtAmount.Visible = True
          LblProrateText.Text = "Revenue Loss Total"
          LblIncr.Text = ._AMT
          LblProrate.Text = ._BENAMT
          LblGrantor.Text = ._PINC
          TxtAmount.Text = ._BENAMT
          WrkTotTax = ._BENAMT - ._PINC
          LblAddlTax.Text = Format(WrkTotTax, "fixed")
          RbEld.Checked = True
        Case "N"
          LblIncr.Visible = True
          TxtAmount.Visible = True
          LblProrateText.Text = "Pro-Rate Increment"
          LblIncr.Text = Format(._AMT, "fixed")
          LblProrate.Text = Format(._PINC, "fixed")
          TxtAmount.Text = Format(._AMT, "fixed")
          WrkMRate = GetMRateLast(MyUtils.CnvSng(LblDist.Text))
          WrkTotTax = WrkMRate * ._PINC
          If WrkMRate > 0 Then
            LblAddlTax.Text = Format(WrkTotTax, "fixed")
          Else
            LblAddlTax.Text = "No Mill Rt"
          End If
          RbNew.Checked = True
        Case "T"
          LblProrateText.Text = "Pro-Rate Assessment"
          LblProrate.Text = Format(._PINC, "fixed")
          WrkMRate = GetMRateLast(MyUtils.CnvSng(LblDist.Text))
          WrkTotTax = WrkMRate * ._PINC
          If WrkMRate > 0 Then
            LblAddlTax.Text = Format(WrkTotTax, "fixed")
          Else
            LblAddlTax.Text = "No Mill Rt"
          End If
          RbTaxable.Checked = True
        Case "V"
          LblIncr.Visible = True
          TxtAmount.Visible = True
          LblProrateText.Text = "Pro-Rate Increment"
          LblIncr.Text = Format(._AMT, "fixed")
          LblProrate.Text = Format(._PINC, "fixed")
          TxtAmount.Text = Format(._AMT, "fixed")
          WrkMRate = GetMRateLast(MyUtils.CnvSng(LblDist.Text))
          WrkTotTax = WrkMRate * ._PINC
          If WrkMRate > 0 Then
            LblAddlTax.Text = Format(WrkTotTax, "fixed")
          Else
            LblAddlTax.Text = "No Mill Rt"
          End If
          RbVet.Checked = True
      End Select
      If ._DATE > 0 Then
        DtPckProrate.Value = MyUtils.GetDBDate(._DATE)
      End If
      LblDays.Text = ._DAYS
      LblPct.Text = ._PCT
    End With

    LoadScrn = False
    LblGrantorText.Visible = False
    LblGrantor.Visible = False
    LblAmount.Visible = False
    TxtAmount.Visible = False
    LblIncrText.Text = "Increment Assessment"
    If RbTaxable.Checked Then
      LblIncrText.Text = "Gross Assessment"
      LblProrateText.Text = "Pro-Rate Assessment"
      myTXREAA.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), WrkYear)
      If myTXREAa._CCNO > 0 Then
        TotAmount = myTXREAA._CCGRS
      Else
        TotAmount = myTXREAA._GROSS + myTXREAA._BTR
      End If
      LblIncr.Text = Format(MyUtils.Round(TotAmount, 0), "fixed")
    End If
    If RbEld.Checked Then
      LblGrantorText.Visible = True
      LblGrantor.Visible = True
      LblAmount.Visible = True
      TxtAmount.Visible = True
    End If
    If RbNew.Checked Or RbVet.Checked Then
      LblAmount.Visible = True
      TxtAmount.Visible = True
      LblProrateText.Text = "Pro-Rate Increment"
    End If
  End Sub

  Private Sub FrmTAD06C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTAD06B.FormatGrid()
    MyFrmTAD06B.Show()
  End Sub
  Private Sub FrmTAD06C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTAD06.SbpScreen.Text = "TAD06C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
  Private Sub CalcProrate(WrkRefresh As Boolean)
    Dim GLDate As Date
    Dim WrkYear As Integer
    Dim WrkLeapYear As Boolean
    Dim TotDays As Integer
    Dim TotAmount As Decimal
    Dim TotIncr As Decimal
    Dim TotTax As Decimal
    Dim MRate As Decimal
    Dim Pct As Decimal

    MRate = GetMRateLast(MyUtils.CnvSng(LblDist.Text))
    WrkYear = Year(DtPckProrate.Value)
    If Month(DtPckProrate.Value) >= 10 Then
      WrkYear = WrkYear + 1
    End If
    GLDate = "10/01/" & WrkYear
    WrkLeapYear = Date.IsLeapYear(WrkYear)
    TotDays = DateDiff(DateInterval.Day, DtPckProrate.Value, GLDate)
    TotAmount = MyUtils.CnvSng(TxtAmount.Text)
    If WrkRefresh Then
      LblGrantorText.Visible = False
      LblGrantor.Visible = False
      LblAmount.Visible = False
      TxtAmount.Visible = False
      LblIncrText.Text = "Increment Assessment"
    End If
    If RbTaxable.Checked Then
      myTXREAA.GetOneRecordP(MyUtils.CnvSng(TxtListNo.Text), WrkYear)
      If myTXREAA._CCNO > 0 Then
        TotAmount = myTXREAA._CCGRS
      Else
        TotAmount = myTXREAA._GROSS + myTXREAA._BTR
      End If
      If WrkRefresh Then
        LblIncrText.Text = "Gross Assessment"
        LblProrateText.Text = "Pro-Rate Assessment"
      End If
      If WrkLeapYear Then
        Pct = Math.Round((TotDays / 366), 3)
      Else
        Pct = Math.Round((TotDays / 365), 3)
      End If
      TotIncr = Pct * TotAmount
      TotTax = MRate * TotIncr
      LblIncr.Text = Format(MyUtils.Round(TotAmount, 0), "fixed")
      If MyIncrRound Then
        LblProrate.Text = Format(MyUtils.Round10(TotIncr, "Normal"), "fixed")
      Else
        LblProrate.Text = Format(MyUtils.Round(TotIncr, 0), "fixed")
      End If
      LblAddlTax.Text = Format(TotTax, "fixed")
    End If
    If RbEld.Checked Then
      If WrkRefresh Then
        LblGrantorText.Visible = True
        LblGrantor.Visible = True
        LblAmount.Visible = True
        TxtAmount.Visible = True
      End If
      Pct = GetTXPROETB(Month(DtPckProrate.Value))
      If Month(DtPckProrate.Value) = 10 Then
        Pct = 0
      End If
      TotIncr = Pct * TotAmount
      TotTax = TotAmount - TotIncr
      LblProrateText.Text = "Revenue Loss Total"
      LblIncr.Text = Format((TotAmount / MRate), "fixed")
      LblProrate.Text = Format(MyUtils.Round(TotAmount, 2), "fixed")
      LblGrantor.Text = Format(MyUtils.Round(TotIncr, 2), "fixed")
      LblAddlTax.Text = Format(TotTax, "fixed")
    End If
    If RbNew.Checked Or RbVet.Checked Then
      If WrkRefresh Then
        LblAmount.Visible = True
        TxtAmount.Visible = True
        LblProrateText.Text = "Pro-Rate Increment"
      End If
      If WrkLeapYear Then
        Pct = Math.Round((TotDays / 366), 3)
      Else
        Pct = Math.Round((TotDays / 365), 3)
      End If
      TotIncr = Pct * TotAmount
      TotTax = MRate * TotIncr
      LblIncr.Text = Format(MyUtils.Round(TotAmount, 0), "fixed")
      If MyIncrRound Then
        LblProrate.Text = Format(MyUtils.Round10(TotIncr, "Normal"), "fixed")
      Else
        LblProrate.Text = Format(MyUtils.Round(TotIncr, 0), "fixed")
      End If
      LblAddlTax.Text = Format(TotTax, "fixed")
    End If
    LblDays.Text = TotDays
    LblPct.Text = Pct
  End Sub
  Private Sub TxtListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtReListNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReListNo.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtZip5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip5.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtZip4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtZip4.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtBeforePct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBeforePct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAfterPct_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAfterPct.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Public Sub LoadAddrs()
    Dim WrkListNo As Integer
    Dim WrkREListNo As Integer
    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    Call GetAddr(WrkListNo, WrkYear)
    WrkREListNo = MyUtils.CnvSng(TxtReListNo.Text)
    If WrkREListNo > 0 Then
      TxtReListNo.Text = WrkListNo
      Call GetREAddr(WrkListNo, WrkYear)
    End If
  End Sub
End Class
