Public Class FrmTX311C
  Inherits System.Windows.Forms.Form
	Dim myTXPROMS As TXPROMS.myData
	Friend WrkListNo As Integer
  Friend WrkDevlt As String
  Dim AddMode As Boolean
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents LnkREListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents LnkListNo As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtReListNo As System.Windows.Forms.TextBox
  Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
  Friend WithEvents ChkFrozen As System.Windows.Forms.CheckBox
  Friend WithEvents ChkMltpr As System.Windows.Forms.CheckBox
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
Friend WithEvents TxtZip4 As System.Windows.Forms.TextBox
Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
Friend WithEvents TxtCity As System.Windows.Forms.TextBox
Friend WithEvents TxtState As System.Windows.Forms.TextBox
Friend WithEvents TxtAdd2 As System.Windows.Forms.TextBox
Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
Friend WithEvents TxtSname As System.Windows.Forms.TextBox
Friend WithEvents TxtName As System.Windows.Forms.TextBox
Friend WithEvents Label7 As System.Windows.Forms.Label
Friend WithEvents Label8 As System.Windows.Forms.Label
Friend WithEvents TxtMap As System.Windows.Forms.TextBox
Friend WithEvents Label10 As System.Windows.Forms.Label
Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
Friend WithEvents Label11 As System.Windows.Forms.Label
Friend WithEvents TxtVol As System.Windows.Forms.TextBox
Friend WithEvents TxtPage As System.Windows.Forms.TextBox
Friend WithEvents Label33 As System.Windows.Forms.Label
Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
Friend WithEvents RbCatExempt As System.Windows.Forms.RadioButton
Friend WithEvents RbCatTaxable As System.Windows.Forms.RadioButton
Friend WithEvents TxtDist As System.Windows.Forms.TextBox
Friend WithEvents Label42 As System.Windows.Forms.Label
Friend WithEvents TxtBankCd As System.Windows.Forms.TextBox
Friend WithEvents LnkBankCd As System.Windows.Forms.LinkLabel
Friend WithEvents Label3 As System.Windows.Forms.Label
Friend WithEvents Label4 As System.Windows.Forms.Label
Friend WithEvents Label5 As System.Windows.Forms.Label
Friend WithEvents Label6 As System.Windows.Forms.Label
Friend WithEvents ChkPosted As System.Windows.Forms.CheckBox
Friend WithEvents TxtCoNo As System.Windows.Forms.TextBox
Friend WithEvents TxtGross As System.Windows.Forms.TextBox
Friend WithEvents TxtExempt As System.Windows.Forms.TextBox
Friend WithEvents TxtNet As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtZip4 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd2 = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtSname = New System.Windows.Forms.TextBox()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtVol = New System.Windows.Forms.TextBox()
    Me.TxtPage = New System.Windows.Forms.TextBox()
    Me.Label33 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbCatExempt = New System.Windows.Forms.RadioButton()
    Me.RbCatTaxable = New System.Windows.Forms.RadioButton()
    Me.TxtDist = New System.Windows.Forms.TextBox()
    Me.Label42 = New System.Windows.Forms.Label()
    Me.TxtBankCd = New System.Windows.Forms.TextBox()
    Me.LnkBankCd = New System.Windows.Forms.LinkLabel()
    Me.TxtCoNo = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtGross = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtExempt = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtNet = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.ChkPosted = New System.Windows.Forms.CheckBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LnkREListNo = New System.Windows.Forms.LinkLabel()
    Me.LnkListNo = New System.Windows.Forms.LinkLabel()
    Me.TxtReListNo = New System.Windows.Forms.TextBox()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.ChkFrozen = New System.Windows.Forms.CheckBox()
    Me.ChkMltpr = New System.Windows.Forms.CheckBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtZip4
    '
    Me.TxtZip4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip4.Location = New System.Drawing.Point(360, 128)
    Me.TxtZip4.MaxLength = 4
    Me.TxtZip4.Name = "TxtZip4"
    Me.TxtZip4.Size = New System.Drawing.Size(32, 20)
    Me.TxtZip4.TabIndex = 9
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(320, 128)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(40, 20)
    Me.TxtZip5.TabIndex = 8
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(64, 128)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(232, 20)
    Me.TxtCity.TabIndex = 6
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(296, 128)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 20)
    Me.TxtState.TabIndex = 7
    '
    'TxtAdd2
    '
    Me.TxtAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd2.Location = New System.Drawing.Point(64, 104)
    Me.TxtAdd2.MaxLength = 35
    Me.TxtAdd2.Name = "TxtAdd2"
    Me.TxtAdd2.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd2.TabIndex = 5
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(64, 80)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(280, 20)
    Me.TxtAdd1.TabIndex = 4
    '
    'TxtSname
    '
    Me.TxtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSname.Location = New System.Drawing.Point(64, 56)
    Me.TxtSname.MaxLength = 35
    Me.TxtSname.Name = "TxtSname"
    Me.TxtSname.Size = New System.Drawing.Size(280, 20)
    Me.TxtSname.TabIndex = 3
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(64, 32)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(280, 20)
    Me.TxtName.TabIndex = 2
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label7.Location = New System.Drawing.Point(16, 32)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(40, 16)
    Me.Label7.TabIndex = 99
    Me.Label7.Text = "Name"
    '
    'Label8
    '
    Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label8.Location = New System.Drawing.Point(16, 80)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(48, 16)
    Me.Label8.TabIndex = 100
    Me.Label8.Text = "Address"
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Location = New System.Drawing.Point(96, 184)
    Me.TxtMap.MaxLength = 17
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(144, 20)
    Me.TxtMap.TabIndex = 13
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(8, 184)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(88, 16)
    Me.Label10.TabIndex = 146
    Me.Label10.Text = "Map Block Lot"
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Location = New System.Drawing.Point(152, 160)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(184, 20)
    Me.TxtLoc.TabIndex = 11
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Location = New System.Drawing.Point(96, 160)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(48, 20)
    Me.TxtLocNo.TabIndex = 10
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(8, 160)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(88, 16)
    Me.Label11.TabIndex = 145
    Me.Label11.Text = "Location#/Name"
    '
    'TxtVol
    '
    Me.TxtVol.Location = New System.Drawing.Point(344, 184)
    Me.TxtVol.MaxLength = 5
    Me.TxtVol.Name = "TxtVol"
    Me.TxtVol.Size = New System.Drawing.Size(40, 20)
    Me.TxtVol.TabIndex = 14
    Me.TxtVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'TxtPage
    '
    Me.TxtPage.Location = New System.Drawing.Point(392, 184)
    Me.TxtPage.MaxLength = 5
    Me.TxtPage.Name = "TxtPage"
    Me.TxtPage.Size = New System.Drawing.Size(40, 20)
    Me.TxtPage.TabIndex = 15
    Me.TxtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label33
    '
    Me.Label33.Location = New System.Drawing.Point(280, 184)
    Me.Label33.Name = "Label33"
    Me.Label33.Size = New System.Drawing.Size(56, 16)
    Me.Label33.TabIndex = 156
    Me.Label33.Text = "Vol/Page"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbCatExempt)
    Me.GroupBox1.Controls.Add(Me.RbCatTaxable)
    Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
    Me.GroupBox1.Location = New System.Drawing.Point(404, 32)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(160, 48)
    Me.GroupBox1.TabIndex = 23
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Category"
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
    'TxtDist
    '
    Me.TxtDist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDist.Location = New System.Drawing.Point(398, 160)
    Me.TxtDist.MaxLength = 3
    Me.TxtDist.Name = "TxtDist"
    Me.TxtDist.Size = New System.Drawing.Size(40, 20)
    Me.TxtDist.TabIndex = 12
    Me.TxtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label42
    '
    Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label42.Location = New System.Drawing.Point(352, 160)
    Me.Label42.Name = "Label42"
    Me.Label42.Size = New System.Drawing.Size(40, 16)
    Me.Label42.TabIndex = 160
    Me.Label42.Text = "District"
    '
    'TxtBankCd
    '
    Me.TxtBankCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBankCd.Location = New System.Drawing.Point(96, 208)
    Me.TxtBankCd.MaxLength = 2
    Me.TxtBankCd.Name = "TxtBankCd"
    Me.TxtBankCd.Size = New System.Drawing.Size(24, 20)
    Me.TxtBankCd.TabIndex = 16
    '
    'LnkBankCd
    '
    Me.LnkBankCd.Location = New System.Drawing.Point(5, 212)
    Me.LnkBankCd.Name = "LnkBankCd"
    Me.LnkBankCd.Size = New System.Drawing.Size(80, 16)
    Me.LnkBankCd.TabIndex = 162
    Me.LnkBankCd.TabStop = True
    Me.LnkBankCd.Text = "Escrow Bank"
    '
    'TxtCoNo
    '
    Me.TxtCoNo.Location = New System.Drawing.Point(344, 212)
    Me.TxtCoNo.MaxLength = 5
    Me.TxtCoNo.Name = "TxtCoNo"
    Me.TxtCoNo.Size = New System.Drawing.Size(56, 20)
    Me.TxtCoNo.TabIndex = 18
    Me.TxtCoNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(272, 212)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(64, 16)
    Me.Label3.TabIndex = 166
    Me.Label3.Text = "CO Number"
    '
    'TxtGross
    '
    Me.TxtGross.Location = New System.Drawing.Point(120, 248)
    Me.TxtGross.MaxLength = 9
    Me.TxtGross.Name = "TxtGross"
    Me.TxtGross.Size = New System.Drawing.Size(80, 20)
    Me.TxtGross.TabIndex = 19
    Me.TxtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 248)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(104, 16)
    Me.Label4.TabIndex = 168
    Me.Label4.Text = "Gross Assessment"
    '
    'TxtExempt
    '
    Me.TxtExempt.Location = New System.Drawing.Point(120, 272)
    Me.TxtExempt.MaxLength = 9
    Me.TxtExempt.Name = "TxtExempt"
    Me.TxtExempt.Size = New System.Drawing.Size(80, 20)
    Me.TxtExempt.TabIndex = 20
    Me.TxtExempt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(8, 272)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(104, 16)
    Me.Label5.TabIndex = 170
    Me.Label5.Text = "Exemptions"
    '
    'TxtNet
    '
    Me.TxtNet.Location = New System.Drawing.Point(120, 296)
    Me.TxtNet.MaxLength = 9
    Me.TxtNet.Name = "TxtNet"
    Me.TxtNet.Size = New System.Drawing.Size(80, 20)
    Me.TxtNet.TabIndex = 21
    Me.TxtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 296)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(104, 16)
    Me.Label6.TabIndex = 172
    Me.Label6.Text = "Net Assessment"
    '
    'ChkPosted
    '
    Me.ChkPosted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPosted.Location = New System.Drawing.Point(8, 320)
    Me.ChkPosted.Name = "ChkPosted"
    Me.ChkPosted.Size = New System.Drawing.Size(80, 16)
    Me.ChkPosted.TabIndex = 22
    Me.ChkPosted.Text = "Posted?"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(303, 8)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(64, 16)
    Me.Label2.TabIndex = 180
    Me.Label2.Text = "(if different)"
    '
    'LnkREListNo
    '
    Me.LnkREListNo.Location = New System.Drawing.Point(162, 8)
    Me.LnkREListNo.Name = "LnkREListNo"
    Me.LnkREListNo.Size = New System.Drawing.Size(64, 16)
    Me.LnkREListNo.TabIndex = 179
    Me.LnkREListNo.TabStop = True
    Me.LnkREListNo.Text = "RE List No"
    '
    'LnkListNo
    '
    Me.LnkListNo.Location = New System.Drawing.Point(10, 8)
    Me.LnkListNo.Name = "LnkListNo"
    Me.LnkListNo.Size = New System.Drawing.Size(48, 17)
    Me.LnkListNo.TabIndex = 178
    Me.LnkListNo.TabStop = True
    Me.LnkListNo.Text = "List No"
    '
    'TxtReListNo
    '
    Me.TxtReListNo.Location = New System.Drawing.Point(232, 4)
    Me.TxtReListNo.MaxLength = 7
    Me.TxtReListNo.Name = "TxtReListNo"
    Me.TxtReListNo.Size = New System.Drawing.Size(66, 20)
    Me.TxtReListNo.TabIndex = 1
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(64, 6)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(66, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'ChkFrozen
    '
    Me.ChkFrozen.AutoSize = True
    Me.ChkFrozen.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkFrozen.Checked = True
    Me.ChkFrozen.CheckState = System.Windows.Forms.CheckState.Checked
    Me.ChkFrozen.Location = New System.Drawing.Point(412, 6)
    Me.ChkFrozen.Name = "ChkFrozen"
    Me.ChkFrozen.Size = New System.Drawing.Size(147, 17)
    Me.ChkFrozen.TabIndex = 181
    Me.ChkFrozen.TabStop = False
    Me.ChkFrozen.Text = "Lookup uses Frozen File?"
    Me.ChkFrozen.UseVisualStyleBackColor = True
    '
    'ChkMltpr
    '
    Me.ChkMltpr.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkMltpr.Location = New System.Drawing.Point(160, 212)
    Me.ChkMltpr.Name = "ChkMltpr"
    Me.ChkMltpr.Size = New System.Drawing.Size(80, 18)
    Me.ChkMltpr.TabIndex = 17
    Me.ChkMltpr.Text = "Mult Prop?"
    '
    'FrmTX311C
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(576, 350)
    Me.Controls.Add(Me.ChkMltpr)
    Me.Controls.Add(Me.ChkFrozen)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LnkREListNo)
    Me.Controls.Add(Me.LnkListNo)
    Me.Controls.Add(Me.TxtReListNo)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.ChkPosted)
    Me.Controls.Add(Me.TxtNet)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtExempt)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtGross)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtCoNo)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtBankCd)
    Me.Controls.Add(Me.LnkBankCd)
    Me.Controls.Add(Me.TxtDist)
    Me.Controls.Add(Me.Label42)
    Me.Controls.Add(Me.TxtVol)
    Me.Controls.Add(Me.TxtPage)
    Me.Controls.Add(Me.Label33)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtMap)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtZip4)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd2)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtSname)
    Me.Controls.Add(Me.TxtName)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX311C"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Proration Maintainence"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX311C_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		myTXPROMS = New TXPROMS.mydata(MyDBConnect)

    LoadScrn = True
    MyFrmTX311.TBarNew.Enabled = False
    MyFrmTX311.TBarSave.Enabled = True

    AddMode = False
    'Fill the dataset with the data
    If WrkListNo > 0 Then
      Me.Text = "Maintain " & Me.Text
      MyFrmTX311.TBarDelete.Enabled = True
      MyFrmTX311.TBarPrint.Enabled = True
      TxtListNo.Text = WrkListNo
      LnkListNo.Enabled = False
      TxtListNo.ReadOnly = True
      LnkREListNo.Enabled = False
      TxtReListNo.ReadOnly = True
			myTXPROMS.GetOneRecordP(WrkListNo)
			If myTXPROMS.RecordNotFound Then
				 MyFrmTX311.TBarNew.Enabled = False
				 MyFrmTX311.TBarSave.Enabled = False
				 MyFrmTX311.TBarDelete.Enabled = False
				 Me.ErrProv.SetError(TxtListNo, "Record not found")
				 Exit Sub
			End If

			With myTXPROMS
				If ._CAT = "1" Then
					RbCatTaxable.Checked = True
				Else
					RbCatExempt.Checked = True
				End If
				TxtReListNo.Text = ._RLIST
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
				TxtDist.Text = ._DIST
				TxtBankCd.Text = Trim(._BKCD)
				TxtVol.Text = Trim(._VOL)
				TxtMap.Text = Trim(._MAP)
				TxtPage.Text = Trim(._XPAGE)
				If Trim(._MLTPR) = "Y" Then
					ChkMltpr.Checked = True
				End If
				TxtCoNo.Text = ._CONUM
				TxtGross.Text = ._GROSS
				TxtExempt.Text = ._TEX
				TxtNet.Text = ._NET
				If Trim(._POST) = "X" Then
					ChkPosted.Checked = True
				End If
			End With
    Else
      Me.Text = "Add " & Me.Text
      AddMode = True
      MyFrmTX311.TBarDelete.Enabled = False
    End If

    LoadScrn = False
 End Sub

  Private Sub FrmTX311C_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    MyFrmTX311.TBarNew.Enabled = True
    MyFrmTX311.TBarSave.Enabled = False
    MyFrmTX311.TBarDelete.Enabled = False
    MyFrmTX311.TBarPrint.Enabled = False
    MyFrmTX311B.FormatGrid()
    MyFrmTX311B.Show()

  End Sub
  Public Sub DeleteData(ByRef Cancel As Boolean)
    Dim Answer As Integer
    Cancel = True
    Answer = MsgBox("Delete record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm delete")
    If Answer = vbNo Then Exit Sub

    Cancel = False
		myTXPROMS.DeleteOneRecordP()
  End Sub
  Public Sub SaveData()
		Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    WrkListNo = Val(TxtListNo.Text)
		myTXPROMS.GetOneRecordP(WrkListNo)
    If AddMode Then
			If Not myTXPROMS.RecordNotFound Then
				Me.ErrProv.SetError(TxtListNo, "Record already exists")
				Exit Sub
			End If
    End If

    If Not AddMode Then
      MoveToFile()
			If IsNothing(ErrorMsg(0)) Then
				myTXPROMS.UpdateOneRecordP()
			Else
				ShowError(ErrorField, ErrorMsg)
				Exit Sub
			End If
    Else
      WrkListNo = Val(TxtListNo.Text)
      myTXPROMS._LISTNo = MyUtils.CnvSng(TxtListNo.Text)
      MoveToFile()
      If IsNothing(ErrorMsg(0)) Then
        myTXPROMS.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg)
        Exit Sub
      End If
    End If

    Me.Close()
  End Sub
   Private Sub MoveToFile()
      With myTXPROMS
        ._CAT = "3"
        If RbCatTaxable.Checked Then
          ._CAT = "1"
        End If
        ._RLIST = MyUtils.CnvSng(TxtReListNo.Text)
        ._NAME = TxtName.Text
        ._SNAME = TxtSname.Text
        ._ADD1 = TxtAdd1.Text
        ._ADD2 = TxtAdd2.Text
        ._CITY = TxtCity.Text
        ._STATE = TxtState.Text
        ._ZIP5 = MyUtils.CnvSng(TxtZip5.Text)
        ._ZIP4 = MyUtils.CnvSng(TxtZip4.Text)
        ._LOCNo = TxtLocNo.Text
        ._LOC = TxtLoc.Text
        ._DIST = MyUtils.CnvSng(TxtDist.Text)
        ._BKCD = TxtBankCd.Text
        ._VOL = TxtVol.Text
        ._MAP = TxtMap.Text
        ._XPAGE = TxtPage.Text
        If ChkMltpr.Checked Then
          ._MLTPR = "Y"
        Else
          ._MLTPR = ""
        End If
        ._CONUM = MyUtils.CnvSng(TxtCoNo.Text)
        ._GROSS = MyUtils.CnvSng(TxtGross.Text)
        ._TEX = MyUtils.CnvSng(TxtExempt.Text)
        ._NET = MyUtils.CnvSng(TxtNet.Text)
        If ChkPosted.Checked Then
          ._POST = "X"
        Else
          ._POST = ""
        End If
      End With

   End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.SetError(TxtListNo, "")
    ErrProv.SetError(TxtName, "")

    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "list#"
        ErrProv.SetError(TxtListNo, ErrorMsg(I))
      Case "name"
        ErrProv.SetError(TxtName, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub FrmTX311C_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmTX311.SbpScreen.Text = "TX311C"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Sub TxtZip5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtZip4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtGross_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtGross.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtExempt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtExempt.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtNet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNet.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
Private Sub TxtDist_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDist.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
  Private Sub LnkListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListNo.LinkClicked
    MyFrmListReal = New FrmListReal
    MyFrmListReal.MdiParent = Me.ParentForm
    MyFrmListReal.WrkField = "ListNo"
    MyFrmListReal.WrkListNo = MyUtils.CnvSng(TxtListNo.Text)
    MyFrmListReal.Show()
  End Sub
  Private Sub LnkREListNo_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkREListNo.LinkClicked
    MyFrmListReal = New FrmListReal
    MyFrmListReal.MdiParent = Me.ParentForm
    MyFrmListReal.WrkField = "REListNo"
    MyFrmListReal.WrkListNo = MyUtils.CnvSng(TxtReListNo.Text)
    MyFrmListReal.Show()
  End Sub
  Private Sub TxtListNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtListNo.Leave
    Dim WrkFrozen As Boolean
    If Not TxtListNo.Modified Then Exit Sub

    WrkFrozen = ChkFrozen.Checked
    Call GetAddr(TxtListNo.Text, WrkFrozen)
  End Sub
Private Sub ChkFrozen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkFrozen.Click
    Dim WrkFrozen As Boolean

    If TxtListNo.Text = "" Then Exit Sub

    WrkFrozen = ChkFrozen.Checked
    If TxtName.Text = "" Then
      Call GetAddr(TxtListNo.Text, WrkFrozen)
    End If
End Sub
 Private Sub LnkBankCd_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkBankCd.LinkClicked
  MyFrmListBanks = New FrmListBanks
  MyFrmListBanks.MdiParent = Me.ParentForm
  MyFrmListBanks.WrkCode = TxtBankCd.Text
  MyFrmListBanks.Show()
End Sub
 End Class






