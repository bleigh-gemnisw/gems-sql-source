Public Class FrmTX401SU
  Inherits System.Windows.Forms.Form
  Dim myTXSUPPC As TXSUPPC.MyData
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
    Me.lblcrdesc.Location = New System.Drawing.Point(107, 87)
    Me.lblcrdesc.Name = "lblcrdesc"
    Me.lblcrdesc.Size = New System.Drawing.Size(204, 18)
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
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub FrmTX401SU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim WrkListNo As Integer
    myTXSUPPC = New TXSUPPC.MyData(myDBConnect)

    MyFrmTX401.TBarSave.Enabled = True

    LoadScrn = True
    AddMode = False

    If s_chg = False And s_full = False Then  '#sec
      MyFrmTX401.TBarSave.Visible = False  '#sec
    End If  '#sec


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
    myTXSUPPC.GetOneRecordP(WrkListNo)
    If myTXSUPPC.RecordNotFound Then
      MyFrmTX401.TBarSave.Enabled = False
      Me.ErrProv.SetError(TxtListNo, "Record not found")
      Exit Sub
    End If
    With myTXSUPPC
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
    myTXSUPPC = Nothing

  End Sub
  Public Sub SaveData()
    Dim ErrorField(50) As String
    Dim ErrorMsg(50) As String
    Dim WrkListNo As Integer

    WrkListNo = MyUtils.CnvSng(TxtListNo.Text)

    myTXSUPPC.GetOneRecordP(WrkListNo)
    MoveToFile()
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      myTXSUPPC.UpdateOneRecordP()
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If
    Me.Close()

  End Sub
  Private Sub MoveToFile()
    With myTXSUPPC
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






