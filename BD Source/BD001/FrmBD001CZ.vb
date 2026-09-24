Public Class FrmBD001CZ
  Inherits System.Windows.Forms.Form
  Dim myBDMAST As BDMAST.myData
  Dim myBDRATE As BDRATE.MyData
  Friend WrkRecID As Integer
  Friend WrkType As String
  Friend WrkApp As Boolean
  Friend WithEvents LblFee As System.Windows.Forms.Label
  Friend WithEvents LblFeeHdr As System.Windows.Forms.Label
  Friend WithEvents TxtPermitNo As System.Windows.Forms.TextBox
  Friend WithEvents LblPermitNo As System.Windows.Forms.Label
  Friend WithEvents TxtName As System.Windows.Forms.TextBox
  Friend WithEvents LblTran As System.Windows.Forms.Label
  Friend WithEvents DtPckTran As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtLoc As System.Windows.Forms.TextBox
  Friend WithEvents TxtLocNo As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TxtMap As System.Windows.Forms.TextBox
  Friend WithEvents LblMap As System.Windows.Forms.Label
  Friend WithEvents LblInsp As System.Windows.Forms.Label
  Friend WithEvents DtPckInsp As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtValue As System.Windows.Forms.TextBox
  Friend WithEvents LblValue As System.Windows.Forms.Label
  Friend WithEvents LblPayRef As System.Windows.Forms.Label
  Friend WithEvents TxtPayRef As System.Windows.Forms.TextBox
  Friend WithEvents TxtMischg As System.Windows.Forms.TextBox
  Friend WithEvents LblMischg As System.Windows.Forms.Label
  Friend WithEvents BtnReceipt As System.Windows.Forms.Button
  Friend WithEvents LblTotal As System.Windows.Forms.Label
  Friend WithEvents LblTotalHdr As System.Windows.Forms.Label
  Friend WithEvents LblMisc As System.Windows.Forms.Label
  Friend WithEvents LblMiscHdr As System.Windows.Forms.Label
  Friend WithEvents TxtCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAdd1 As System.Windows.Forms.TextBox
  Friend WithEvents TxtZip5 As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents LblListNo As System.Windows.Forms.Label
  Friend WithEvents LblType As System.Windows.Forms.Label
  Friend WithEvents LnkName As System.Windows.Forms.LinkLabel
  Friend WithEvents LblDesc As System.Windows.Forms.Label
  Friend WithEvents LblAppl As System.Windows.Forms.Label
  Friend WithEvents DtPckApp As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnPermit As System.Windows.Forms.Button
  Friend WithEvents LblPermit As System.Windows.Forms.Label
  Friend WithEvents TxtAuth As System.Windows.Forms.TextBox
  Friend WithEvents LblAuth As System.Windows.Forms.Label
  Friend WithEvents LblBTUB As System.Windows.Forms.Label
  Friend WithEvents LblBTRE As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GrpPaytyp As System.Windows.Forms.GroupBox
  Friend WithEvents RbCash As System.Windows.Forms.RadioButton
  Friend WithEvents RbCheck As System.Windows.Forms.RadioButton
  Friend WithEvents RbCredit As System.Windows.Forms.RadioButton
  Friend WithEvents LblAppName As System.Windows.Forms.Label
  Friend WithEvents TxtAppCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtAppState As System.Windows.Forms.TextBox
  Friend WithEvents TxtAppAddr As System.Windows.Forms.TextBox
  Friend WithEvents TxtAppZip As System.Windows.Forms.TextBox
  Friend WithEvents LblAppCity As System.Windows.Forms.Label
  Friend WithEvents LblAppAddr As System.Windows.Forms.Label
  Friend WithEvents TxtAppName As System.Windows.Forms.TextBox
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents GrpProp As System.Windows.Forms.GroupBox
  Friend WithEvents RbPropOther As System.Windows.Forms.RadioButton
  Friend WithEvents RbPropOpt As System.Windows.Forms.RadioButton
  Friend WithEvents RbPropOwn As System.Windows.Forms.RadioButton
  Friend WithEvents RbPropRent As System.Windows.Forms.RadioButton
  Friend WithEvents TxtAppPhone As System.Windows.Forms.TextBox
  Friend WithEvents LblAppPhone As System.Windows.Forms.Label
  Friend WithEvents TxtZone As System.Windows.Forms.TextBox
  Friend WithEvents LblZone As System.Windows.Forms.Label
  Friend WithEvents ChkCityWater As System.Windows.Forms.CheckBox
  Friend WithEvents TxtFloorSqfoot As System.Windows.Forms.TextBox
  Friend WithEvents LblFloorSqfoot As System.Windows.Forms.Label
  Friend WithEvents TxtPropSqFoot As System.Windows.Forms.TextBox
  Friend WithEvents LblPropSqFoot As System.Windows.Forms.Label
  Friend WithEvents ChkCityFront As System.Windows.Forms.CheckBox
  Dim LoadScrn As Boolean
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents TxtSusign As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents TxtSudesc As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TxtSuemp As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents TxtSuhrs As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TxtSubus As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents RbAppTax As System.Windows.Forms.RadioButton
  Friend WithEvents RbAppSpecial As System.Windows.Forms.RadioButton
  Friend WithEvents RbAppSite As System.Windows.Forms.RadioButton
  Friend WithEvents LblPermDesc As System.Windows.Forms.Label
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
Friend WithEvents LblRecID As System.Windows.Forms.Label
 <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.LblRecID = New System.Windows.Forms.Label()
    Me.LblFee = New System.Windows.Forms.Label()
    Me.LblFeeHdr = New System.Windows.Forms.Label()
    Me.TxtPermitNo = New System.Windows.Forms.TextBox()
    Me.LblPermitNo = New System.Windows.Forms.Label()
    Me.LblTran = New System.Windows.Forms.Label()
    Me.DtPckTran = New System.Windows.Forms.DateTimePicker()
    Me.TxtName = New System.Windows.Forms.TextBox()
    Me.TxtLoc = New System.Windows.Forms.TextBox()
    Me.TxtLocNo = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtMap = New System.Windows.Forms.TextBox()
    Me.LblMap = New System.Windows.Forms.Label()
    Me.TxtValue = New System.Windows.Forms.TextBox()
    Me.LblValue = New System.Windows.Forms.Label()
    Me.LblInsp = New System.Windows.Forms.Label()
    Me.DtPckInsp = New System.Windows.Forms.DateTimePicker()
    Me.LblPayRef = New System.Windows.Forms.Label()
    Me.TxtPayRef = New System.Windows.Forms.TextBox()
    Me.TxtMischg = New System.Windows.Forms.TextBox()
    Me.LblMischg = New System.Windows.Forms.Label()
    Me.BtnReceipt = New System.Windows.Forms.Button()
    Me.LblMisc = New System.Windows.Forms.Label()
    Me.LblMiscHdr = New System.Windows.Forms.Label()
    Me.LblTotal = New System.Windows.Forms.Label()
    Me.LblTotalHdr = New System.Windows.Forms.Label()
    Me.TxtCity = New System.Windows.Forms.TextBox()
    Me.TxtState = New System.Windows.Forms.TextBox()
    Me.TxtAdd1 = New System.Windows.Forms.TextBox()
    Me.TxtZip5 = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.LblListNo = New System.Windows.Forms.Label()
    Me.LblType = New System.Windows.Forms.Label()
    Me.LnkName = New System.Windows.Forms.LinkLabel()
    Me.LblDesc = New System.Windows.Forms.Label()
    Me.LblAppl = New System.Windows.Forms.Label()
    Me.DtPckApp = New System.Windows.Forms.DateTimePicker()
    Me.BtnPermit = New System.Windows.Forms.Button()
    Me.LblPermit = New System.Windows.Forms.Label()
    Me.TxtAuth = New System.Windows.Forms.TextBox()
    Me.LblAuth = New System.Windows.Forms.Label()
    Me.LblBTRE = New System.Windows.Forms.Label()
    Me.LblBTUB = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GrpPaytyp = New System.Windows.Forms.GroupBox()
    Me.RbCredit = New System.Windows.Forms.RadioButton()
    Me.RbCheck = New System.Windows.Forms.RadioButton()
    Me.RbCash = New System.Windows.Forms.RadioButton()
    Me.TxtAppCity = New System.Windows.Forms.TextBox()
    Me.TxtAppState = New System.Windows.Forms.TextBox()
    Me.TxtAppAddr = New System.Windows.Forms.TextBox()
    Me.TxtAppZip = New System.Windows.Forms.TextBox()
    Me.LblAppCity = New System.Windows.Forms.Label()
    Me.LblAppAddr = New System.Windows.Forms.Label()
    Me.TxtAppName = New System.Windows.Forms.TextBox()
    Me.LblAppName = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.GrpProp = New System.Windows.Forms.GroupBox()
    Me.RbPropOther = New System.Windows.Forms.RadioButton()
    Me.RbPropOpt = New System.Windows.Forms.RadioButton()
    Me.RbPropOwn = New System.Windows.Forms.RadioButton()
    Me.RbPropRent = New System.Windows.Forms.RadioButton()
    Me.TxtAppPhone = New System.Windows.Forms.TextBox()
    Me.LblAppPhone = New System.Windows.Forms.Label()
    Me.TxtZone = New System.Windows.Forms.TextBox()
    Me.LblZone = New System.Windows.Forms.Label()
    Me.ChkCityFront = New System.Windows.Forms.CheckBox()
    Me.TxtPropSqFoot = New System.Windows.Forms.TextBox()
    Me.LblPropSqFoot = New System.Windows.Forms.Label()
    Me.TxtFloorSqfoot = New System.Windows.Forms.TextBox()
    Me.LblFloorSqfoot = New System.Windows.Forms.Label()
    Me.ChkCityWater = New System.Windows.Forms.CheckBox()
    Me.LblPermDesc = New System.Windows.Forms.Label()
    Me.RbAppSite = New System.Windows.Forms.RadioButton()
    Me.RbAppSpecial = New System.Windows.Forms.RadioButton()
    Me.RbAppTax = New System.Windows.Forms.RadioButton()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtSubus = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtSuhrs = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtSuemp = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.TxtSudesc = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtSusign = New System.Windows.Forms.TextBox()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpPaytyp.SuspendLayout()
    Me.GrpProp.SuspendLayout()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'LblRecID
    '
    Me.LblRecID.Location = New System.Drawing.Point(504, 9)
    Me.LblRecID.Name = "LblRecID"
    Me.LblRecID.Size = New System.Drawing.Size(98, 13)
    Me.LblRecID.TabIndex = 155
    Me.LblRecID.Text = "<Recid>"
    Me.LblRecID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblFee
    '
    Me.LblFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFee.Location = New System.Drawing.Point(538, 34)
    Me.LblFee.Name = "LblFee"
    Me.LblFee.Size = New System.Drawing.Size(64, 16)
    Me.LblFee.TabIndex = 222
    Me.LblFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblFeeHdr
    '
    Me.LblFeeHdr.AutoSize = True
    Me.LblFeeHdr.BackColor = System.Drawing.SystemColors.Control
    Me.LblFeeHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblFeeHdr.Location = New System.Drawing.Point(507, 35)
    Me.LblFeeHdr.Name = "LblFeeHdr"
    Me.LblFeeHdr.Size = New System.Drawing.Size(25, 13)
    Me.LblFeeHdr.TabIndex = 221
    Me.LblFeeHdr.Text = "Fee"
    '
    'TxtPermitNo
    '
    Me.TxtPermitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPermitNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPermitNo.Location = New System.Drawing.Point(514, 474)
    Me.TxtPermitNo.MaxLength = 10
    Me.TxtPermitNo.Name = "TxtPermitNo"
    Me.TxtPermitNo.Size = New System.Drawing.Size(88, 22)
    Me.TxtPermitNo.TabIndex = 28
    '
    'LblPermitNo
    '
    Me.LblPermitNo.AutoSize = True
    Me.LblPermitNo.Location = New System.Drawing.Point(419, 478)
    Me.LblPermitNo.Name = "LblPermitNo"
    Me.LblPermitNo.Size = New System.Drawing.Size(76, 13)
    Me.LblPermitNo.TabIndex = 224
    Me.LblPermitNo.Text = "Permit Number"
    '
    'LblTran
    '
    Me.LblTran.AutoSize = True
    Me.LblTran.Location = New System.Drawing.Point(419, 454)
    Me.LblTran.Name = "LblTran"
    Me.LblTran.Size = New System.Drawing.Size(75, 13)
    Me.LblTran.TabIndex = 352
    Me.LblTran.Text = "Approval Date"
    '
    'DtPckTran
    '
    Me.DtPckTran.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTran.Location = New System.Drawing.Point(514, 448)
    Me.DtPckTran.Name = "DtPckTran"
    Me.DtPckTran.Size = New System.Drawing.Size(84, 20)
    Me.DtPckTran.TabIndex = 27
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(121, 66)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 0
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(265, 137)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(208, 22)
    Me.TxtLoc.TabIndex = 6
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(121, 138)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(64, 22)
    Me.TxtLocNo.TabIndex = 5
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(18, 141)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(89, 13)
    Me.Label6.TabIndex = 356
    Me.Label6.Text = "Job Site: Street #"
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMap.Location = New System.Drawing.Point(309, 164)
    Me.TxtMap.MaxLength = 17
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(144, 22)
    Me.TxtMap.TabIndex = 8
    '
    'LblMap
    '
    Me.LblMap.AutoSize = True
    Me.LblMap.Location = New System.Drawing.Point(275, 168)
    Me.LblMap.Name = "LblMap"
    Me.LblMap.Size = New System.Drawing.Size(28, 13)
    Me.LblMap.TabIndex = 360
    Me.LblMap.Text = "Map"
    '
    'TxtValue
    '
    Me.TxtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtValue.Location = New System.Drawing.Point(121, 411)
    Me.TxtValue.MaxLength = 10
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(85, 22)
    Me.TxtValue.TabIndex = 21
    Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblValue
    '
    Me.LblValue.AutoSize = True
    Me.LblValue.Location = New System.Drawing.Point(20, 416)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(54, 13)
    Me.LblValue.TabIndex = 368
    Me.LblValue.Text = "Job Value"
    '
    'LblInsp
    '
    Me.LblInsp.AutoSize = True
    Me.LblInsp.Location = New System.Drawing.Point(20, 440)
    Me.LblInsp.Name = "LblInsp"
    Me.LblInsp.Size = New System.Drawing.Size(82, 13)
    Me.LblInsp.TabIndex = 370
    Me.LblInsp.Text = "Inspection Date"
    '
    'DtPckInsp
    '
    Me.DtPckInsp.Checked = False
    Me.DtPckInsp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInsp.Location = New System.Drawing.Point(121, 440)
    Me.DtPckInsp.Name = "DtPckInsp"
    Me.DtPckInsp.ShowCheckBox = True
    Me.DtPckInsp.Size = New System.Drawing.Size(99, 20)
    Me.DtPckInsp.TabIndex = 23
    Me.DtPckInsp.Value = New Date(2015, 9, 20, 0, 0, 0, 0)
    '
    'LblPayRef
    '
    Me.LblPayRef.AutoSize = True
    Me.LblPayRef.Location = New System.Drawing.Point(214, 478)
    Me.LblPayRef.Name = "LblPayRef"
    Me.LblPayRef.Size = New System.Drawing.Size(101, 13)
    Me.LblPayRef.TabIndex = 374
    Me.LblPayRef.Text = "Payment Reference"
    '
    'TxtPayRef
    '
    Me.TxtPayRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPayRef.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPayRef.Location = New System.Drawing.Point(323, 474)
    Me.TxtPayRef.MaxLength = 10
    Me.TxtPayRef.Name = "TxtPayRef"
    Me.TxtPayRef.Size = New System.Drawing.Size(85, 22)
    Me.TxtPayRef.TabIndex = 25
    '
    'TxtMischg
    '
    Me.TxtMischg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMischg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMischg.Location = New System.Drawing.Point(300, 411)
    Me.TxtMischg.MaxLength = 10
    Me.TxtMischg.Name = "TxtMischg"
    Me.TxtMischg.Size = New System.Drawing.Size(85, 22)
    Me.TxtMischg.TabIndex = 22
    Me.TxtMischg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblMischg
    '
    Me.LblMischg.AutoSize = True
    Me.LblMischg.Location = New System.Drawing.Point(227, 416)
    Me.LblMischg.Name = "LblMischg"
    Me.LblMischg.Size = New System.Drawing.Size(66, 13)
    Me.LblMischg.TabIndex = 376
    Me.LblMischg.Text = "Misc Charge"
    '
    'BtnReceipt
    '
    Me.BtnReceipt.Location = New System.Drawing.Point(494, 124)
    Me.BtnReceipt.Name = "BtnReceipt"
    Me.BtnReceipt.Size = New System.Drawing.Size(56, 49)
    Me.BtnReceipt.TabIndex = 379
    Me.BtnReceipt.Text = "Print Receipt"
    Me.BtnReceipt.UseVisualStyleBackColor = True
    '
    'LblMisc
    '
    Me.LblMisc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMisc.Location = New System.Drawing.Point(538, 50)
    Me.LblMisc.Name = "LblMisc"
    Me.LblMisc.Size = New System.Drawing.Size(64, 16)
    Me.LblMisc.TabIndex = 381
    Me.LblMisc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblMiscHdr
    '
    Me.LblMiscHdr.AutoSize = True
    Me.LblMiscHdr.BackColor = System.Drawing.SystemColors.Control
    Me.LblMiscHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMiscHdr.Location = New System.Drawing.Point(481, 52)
    Me.LblMiscHdr.Name = "LblMiscHdr"
    Me.LblMiscHdr.Size = New System.Drawing.Size(51, 13)
    Me.LblMiscHdr.TabIndex = 380
    Me.LblMiscHdr.Text = "Misc Chg"
    '
    'LblTotal
    '
    Me.LblTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotal.Location = New System.Drawing.Point(538, 75)
    Me.LblTotal.Name = "LblTotal"
    Me.LblTotal.Size = New System.Drawing.Size(64, 16)
    Me.LblTotal.TabIndex = 383
    Me.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblTotalHdr
    '
    Me.LblTotalHdr.AutoSize = True
    Me.LblTotalHdr.BackColor = System.Drawing.SystemColors.Control
    Me.LblTotalHdr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblTotalHdr.Location = New System.Drawing.Point(501, 77)
    Me.LblTotalHdr.Name = "LblTotalHdr"
    Me.LblTotalHdr.Size = New System.Drawing.Size(31, 13)
    Me.LblTotalHdr.TabIndex = 382
    Me.LblTotalHdr.Text = "Total"
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(121, 110)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 2
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(337, 110)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 3
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(121, 88)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 1
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(369, 110)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 4
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(21, 114)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(80, 16)
    Me.Label13.TabIndex = 404
    Me.Label13.Text = "City/State/Zip"
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(20, 92)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(80, 16)
    Me.Label15.TabIndex = 403
    Me.Label15.Text = "Street Address"
    '
    'LblListNo
    '
    Me.LblListNo.AutoSize = True
    Me.LblListNo.Location = New System.Drawing.Point(419, 68)
    Me.LblListNo.Name = "LblListNo"
    Me.LblListNo.Size = New System.Drawing.Size(42, 13)
    Me.LblListNo.TabIndex = 398
    Me.LblListNo.Text = "<List#>"
    '
    'LblType
    '
    Me.LblType.AutoSize = True
    Me.LblType.Location = New System.Drawing.Point(415, 9)
    Me.LblType.Name = "LblType"
    Me.LblType.Size = New System.Drawing.Size(43, 13)
    Me.LblType.TabIndex = 397
    Me.LblType.Text = "<Type>"
    Me.LblType.UseMnemonic = False
    '
    'LnkName
    '
    Me.LnkName.AutoSize = True
    Me.LnkName.Location = New System.Drawing.Point(19, 68)
    Me.LnkName.Name = "LnkName"
    Me.LnkName.Size = New System.Drawing.Size(69, 13)
    Me.LnkName.TabIndex = 1
    Me.LnkName.TabStop = True
    Me.LnkName.Text = "Owner Name"
    '
    'LblDesc
    '
    Me.LblDesc.AutoSize = True
    Me.LblDesc.Location = New System.Drawing.Point(18, 349)
    Me.LblDesc.Name = "LblDesc"
    Me.LblDesc.Size = New System.Drawing.Size(96, 13)
    Me.LblDesc.TabIndex = 414
    Me.LblDesc.Text = "Project Description"
    '
    'LblAppl
    '
    Me.LblAppl.AutoSize = True
    Me.LblAppl.Location = New System.Drawing.Point(419, 431)
    Me.LblAppl.Name = "LblAppl"
    Me.LblAppl.Size = New System.Drawing.Size(85, 13)
    Me.LblAppl.TabIndex = 419
    Me.LblAppl.Text = "Application Date"
    '
    'DtPckApp
    '
    Me.DtPckApp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckApp.Location = New System.Drawing.Point(514, 425)
    Me.DtPckApp.Name = "DtPckApp"
    Me.DtPckApp.Size = New System.Drawing.Size(84, 20)
    Me.DtPckApp.TabIndex = 26
    '
    'BtnPermit
    '
    Me.BtnPermit.Location = New System.Drawing.Point(553, 124)
    Me.BtnPermit.Name = "BtnPermit"
    Me.BtnPermit.Size = New System.Drawing.Size(52, 49)
    Me.BtnPermit.TabIndex = 421
    Me.BtnPermit.Text = "Print Permit"
    Me.BtnPermit.UseVisualStyleBackColor = True
    '
    'LblPermit
    '
    Me.LblPermit.AutoSize = True
    Me.LblPermit.Location = New System.Drawing.Point(459, 9)
    Me.LblPermit.Name = "LblPermit"
    Me.LblPermit.Size = New System.Drawing.Size(48, 13)
    Me.LblPermit.TabIndex = 424
    Me.LblPermit.Text = "<Permit>"
    '
    'TxtAuth
    '
    Me.TxtAuth.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAuth.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAuth.Location = New System.Drawing.Point(360, 5)
    Me.TxtAuth.MaxLength = 5
    Me.TxtAuth.Name = "TxtAuth"
    Me.TxtAuth.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.TxtAuth.Size = New System.Drawing.Size(48, 22)
    Me.TxtAuth.TabIndex = 34
    '
    'LblAuth
    '
    Me.LblAuth.AutoSize = True
    Me.LblAuth.Location = New System.Drawing.Point(286, 9)
    Me.LblAuth.Name = "LblAuth"
    Me.LblAuth.Size = New System.Drawing.Size(68, 13)
    Me.LblAuth.TabIndex = 436
    Me.LblAuth.Text = "Authorization"
    '
    'LblBTRE
    '
    Me.LblBTRE.AutoSize = True
    Me.LblBTRE.ForeColor = System.Drawing.Color.Red
    Me.LblBTRE.Location = New System.Drawing.Point(536, 91)
    Me.LblBTRE.Name = "LblBTRE"
    Me.LblBTRE.Size = New System.Drawing.Size(71, 13)
    Me.LblBTRE.TabIndex = 467
    Me.LblBTRE.Text = "Back Tax RE"
    Me.LblBTRE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LblBTUB
    '
    Me.LblBTUB.AutoSize = True
    Me.LblBTUB.ForeColor = System.Drawing.Color.Red
    Me.LblBTUB.Location = New System.Drawing.Point(536, 106)
    Me.LblBTUB.Name = "LblBTUB"
    Me.LblBTUB.Size = New System.Drawing.Size(71, 13)
    Me.LblBTUB.TabIndex = 468
    Me.LblBTUB.Text = "Back Tax UB"
    Me.LblBTUB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(193, 141)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(66, 13)
    Me.Label1.TabIndex = 469
    Me.Label1.Text = "Street Name"
    '
    'GrpPaytyp
    '
    Me.GrpPaytyp.Controls.Add(Me.RbCredit)
    Me.GrpPaytyp.Controls.Add(Me.RbCheck)
    Me.GrpPaytyp.Controls.Add(Me.RbCash)
    Me.GrpPaytyp.Location = New System.Drawing.Point(12, 465)
    Me.GrpPaytyp.Name = "GrpPaytyp"
    Me.GrpPaytyp.Size = New System.Drawing.Size(196, 36)
    Me.GrpPaytyp.TabIndex = 24
    Me.GrpPaytyp.TabStop = False
    '
    'RbCredit
    '
    Me.RbCredit.AutoSize = True
    Me.RbCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCredit.Location = New System.Drawing.Point(135, 11)
    Me.RbCredit.Name = "RbCredit"
    Me.RbCredit.Size = New System.Drawing.Size(52, 17)
    Me.RbCredit.TabIndex = 33
    Me.RbCredit.Text = "Credit"
    Me.RbCredit.UseVisualStyleBackColor = True
    '
    'RbCheck
    '
    Me.RbCheck.AutoSize = True
    Me.RbCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCheck.Location = New System.Drawing.Point(6, 11)
    Me.RbCheck.Name = "RbCheck"
    Me.RbCheck.Size = New System.Drawing.Size(56, 17)
    Me.RbCheck.TabIndex = 31
    Me.RbCheck.Text = "Check"
    Me.RbCheck.UseVisualStyleBackColor = True
    '
    'RbCash
    '
    Me.RbCash.AutoSize = True
    Me.RbCash.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCash.Location = New System.Drawing.Point(75, 11)
    Me.RbCash.Name = "RbCash"
    Me.RbCash.Size = New System.Drawing.Size(49, 17)
    Me.RbCash.TabIndex = 32
    Me.RbCash.Text = "Cash"
    Me.RbCash.UseVisualStyleBackColor = True
    '
    'TxtAppCity
    '
    Me.TxtAppCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAppCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppCity.Location = New System.Drawing.Point(120, 232)
    Me.TxtAppCity.MaxLength = 25
    Me.TxtAppCity.Name = "TxtAppCity"
    Me.TxtAppCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtAppCity.TabIndex = 11
    '
    'TxtAppState
    '
    Me.TxtAppState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAppState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppState.Location = New System.Drawing.Point(336, 232)
    Me.TxtAppState.MaxLength = 2
    Me.TxtAppState.Name = "TxtAppState"
    Me.TxtAppState.Size = New System.Drawing.Size(24, 22)
    Me.TxtAppState.TabIndex = 12
    '
    'TxtAppAddr
    '
    Me.TxtAppAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAppAddr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppAddr.Location = New System.Drawing.Point(120, 210)
    Me.TxtAppAddr.MaxLength = 35
    Me.TxtAppAddr.Name = "TxtAppAddr"
    Me.TxtAppAddr.Size = New System.Drawing.Size(288, 22)
    Me.TxtAppAddr.TabIndex = 10
    '
    'TxtAppZip
    '
    Me.TxtAppZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppZip.Location = New System.Drawing.Point(368, 232)
    Me.TxtAppZip.MaxLength = 5
    Me.TxtAppZip.Name = "TxtAppZip"
    Me.TxtAppZip.Size = New System.Drawing.Size(48, 22)
    Me.TxtAppZip.TabIndex = 13
    '
    'LblAppCity
    '
    Me.LblAppCity.Location = New System.Drawing.Point(20, 236)
    Me.LblAppCity.Name = "LblAppCity"
    Me.LblAppCity.Size = New System.Drawing.Size(80, 16)
    Me.LblAppCity.TabIndex = 495
    Me.LblAppCity.Text = "City/State/Zip"
    '
    'LblAppAddr
    '
    Me.LblAppAddr.Location = New System.Drawing.Point(19, 214)
    Me.LblAppAddr.Name = "LblAppAddr"
    Me.LblAppAddr.Size = New System.Drawing.Size(80, 16)
    Me.LblAppAddr.TabIndex = 494
    Me.LblAppAddr.Text = "Street Address"
    '
    'TxtAppName
    '
    Me.TxtAppName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAppName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppName.Location = New System.Drawing.Point(120, 188)
    Me.TxtAppName.MaxLength = 35
    Me.TxtAppName.Name = "TxtAppName"
    Me.TxtAppName.Size = New System.Drawing.Size(288, 22)
    Me.TxtAppName.TabIndex = 9
    '
    'LblAppName
    '
    Me.LblAppName.Location = New System.Drawing.Point(21, 188)
    Me.LblAppName.Name = "LblAppName"
    Me.LblAppName.Size = New System.Drawing.Size(95, 22)
    Me.LblAppName.TabIndex = 496
    Me.LblAppName.Text = "Applicant Name"
    '
    'TxtDesc
    '
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(120, 343)
    Me.TxtDesc.Multiline = True
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtDesc.Size = New System.Drawing.Size(482, 62)
    Me.TxtDesc.TabIndex = 20
    '
    'GrpProp
    '
    Me.GrpProp.Controls.Add(Me.RbPropOther)
    Me.GrpProp.Controls.Add(Me.RbPropOpt)
    Me.GrpProp.Controls.Add(Me.RbPropOwn)
    Me.GrpProp.Controls.Add(Me.RbPropRent)
    Me.GrpProp.Location = New System.Drawing.Point(329, 265)
    Me.GrpProp.Name = "GrpProp"
    Me.GrpProp.Size = New System.Drawing.Size(178, 55)
    Me.GrpProp.TabIndex = 15
    Me.GrpProp.TabStop = False
    Me.GrpProp.Text = "Interest in Property"
    '
    'RbPropOther
    '
    Me.RbPropOther.AutoSize = True
    Me.RbPropOther.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPropOther.Location = New System.Drawing.Point(113, 32)
    Me.RbPropOther.Name = "RbPropOther"
    Me.RbPropOther.Size = New System.Drawing.Size(51, 17)
    Me.RbPropOther.TabIndex = 19
    Me.RbPropOther.Text = "Other"
    Me.RbPropOther.UseVisualStyleBackColor = True
    '
    'RbPropOpt
    '
    Me.RbPropOpt.AutoSize = True
    Me.RbPropOpt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPropOpt.Location = New System.Drawing.Point(7, 32)
    Me.RbPropOpt.Name = "RbPropOpt"
    Me.RbPropOpt.Size = New System.Drawing.Size(88, 17)
    Me.RbPropOpt.TabIndex = 18
    Me.RbPropOpt.Text = "Option to buy"
    Me.RbPropOpt.UseVisualStyleBackColor = True
    '
    'RbPropOwn
    '
    Me.RbPropOwn.AutoSize = True
    Me.RbPropOwn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPropOwn.Location = New System.Drawing.Point(48, 15)
    Me.RbPropOwn.Name = "RbPropOwn"
    Me.RbPropOwn.Size = New System.Drawing.Size(47, 17)
    Me.RbPropOwn.TabIndex = 16
    Me.RbPropOwn.Text = "Own"
    Me.RbPropOwn.UseVisualStyleBackColor = True
    '
    'RbPropRent
    '
    Me.RbPropRent.AutoSize = True
    Me.RbPropRent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbPropRent.Location = New System.Drawing.Point(116, 15)
    Me.RbPropRent.Name = "RbPropRent"
    Me.RbPropRent.Size = New System.Drawing.Size(48, 17)
    Me.RbPropRent.TabIndex = 17
    Me.RbPropRent.Text = "Rent"
    Me.RbPropRent.UseVisualStyleBackColor = True
    '
    'TxtAppPhone
    '
    Me.TxtAppPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAppPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAppPhone.Location = New System.Drawing.Point(120, 260)
    Me.TxtAppPhone.MaxLength = 20
    Me.TxtAppPhone.Name = "TxtAppPhone"
    Me.TxtAppPhone.Size = New System.Drawing.Size(148, 22)
    Me.TxtAppPhone.TabIndex = 14
    '
    'LblAppPhone
    '
    Me.LblAppPhone.AutoSize = True
    Me.LblAppPhone.Location = New System.Drawing.Point(17, 265)
    Me.LblAppPhone.Name = "LblAppPhone"
    Me.LblAppPhone.Size = New System.Drawing.Size(85, 13)
    Me.LblAppPhone.TabIndex = 500
    Me.LblAppPhone.Text = "Applicant Phone"
    '
    'TxtZone
    '
    Me.TxtZone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtZone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZone.Location = New System.Drawing.Point(120, 164)
    Me.TxtZone.MaxLength = 5
    Me.TxtZone.Name = "TxtZone"
    Me.TxtZone.Size = New System.Drawing.Size(39, 22)
    Me.TxtZone.TabIndex = 7
    '
    'LblZone
    '
    Me.LblZone.AutoSize = True
    Me.LblZone.Location = New System.Drawing.Point(82, 168)
    Me.LblZone.Name = "LblZone"
    Me.LblZone.Size = New System.Drawing.Size(32, 13)
    Me.LblZone.TabIndex = 502
    Me.LblZone.Text = "Zone"
    '
    'ChkCityFront
    '
    Me.ChkCityFront.AutoSize = True
    Me.ChkCityFront.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCityFront.Location = New System.Drawing.Point(191, 294)
    Me.ChkCityFront.Name = "ChkCityFront"
    Me.ChkCityFront.Size = New System.Drawing.Size(125, 17)
    Me.ChkCityFront.TabIndex = 18
    Me.ChkCityFront.Text = "City Street Frontage?"
    Me.ChkCityFront.UseVisualStyleBackColor = True
    '
    'TxtPropSqFoot
    '
    Me.TxtPropSqFoot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPropSqFoot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPropSqFoot.Location = New System.Drawing.Point(120, 289)
    Me.TxtPropSqFoot.MaxLength = 7
    Me.TxtPropSqFoot.Name = "TxtPropSqFoot"
    Me.TxtPropSqFoot.Size = New System.Drawing.Size(61, 22)
    Me.TxtPropSqFoot.TabIndex = 16
    Me.TxtPropSqFoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblPropSqFoot
    '
    Me.LblPropSqFoot.AutoSize = True
    Me.LblPropSqFoot.Location = New System.Drawing.Point(7, 294)
    Me.LblPropSqFoot.Name = "LblPropSqFoot"
    Me.LblPropSqFoot.Size = New System.Drawing.Size(107, 13)
    Me.LblPropSqFoot.TabIndex = 505
    Me.LblPropSqFoot.Text = "Property Sq. Footage"
    '
    'TxtFloorSqfoot
    '
    Me.TxtFloorSqfoot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFloorSqfoot.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFloorSqfoot.Location = New System.Drawing.Point(120, 313)
    Me.TxtFloorSqfoot.MaxLength = 7
    Me.TxtFloorSqfoot.Name = "TxtFloorSqfoot"
    Me.TxtFloorSqfoot.Size = New System.Drawing.Size(61, 22)
    Me.TxtFloorSqfoot.TabIndex = 17
    Me.TxtFloorSqfoot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblFloorSqfoot
    '
    Me.LblFloorSqfoot.AutoSize = True
    Me.LblFloorSqfoot.Location = New System.Drawing.Point(23, 317)
    Me.LblFloorSqfoot.Name = "LblFloorSqfoot"
    Me.LblFloorSqfoot.Size = New System.Drawing.Size(91, 13)
    Me.LblFloorSqfoot.TabIndex = 507
    Me.LblFloorSqfoot.Text = "Floor Sq. Footage"
    '
    'ChkCityWater
    '
    Me.ChkCityWater.AutoSize = True
    Me.ChkCityWater.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkCityWater.Location = New System.Drawing.Point(191, 316)
    Me.ChkCityWater.Name = "ChkCityWater"
    Me.ChkCityWater.Size = New System.Drawing.Size(116, 17)
    Me.ChkCityWater.TabIndex = 19
    Me.ChkCityWater.Text = "City Water/Sewer?"
    Me.ChkCityWater.UseVisualStyleBackColor = True
    '
    'LblPermDesc
    '
    Me.LblPermDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPermDesc.ForeColor = System.Drawing.Color.Black
    Me.LblPermDesc.Location = New System.Drawing.Point(18, 10)
    Me.LblPermDesc.Name = "LblPermDesc"
    Me.LblPermDesc.Size = New System.Drawing.Size(258, 17)
    Me.LblPermDesc.TabIndex = 508
    Me.LblPermDesc.Text = "<Perm Desc>"
    Me.LblPermDesc.UseMnemonic = False
    '
    'RbAppSite
    '
    Me.RbAppSite.AutoSize = True
    Me.RbAppSite.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAppSite.Location = New System.Drawing.Point(22, 33)
    Me.RbAppSite.Name = "RbAppSite"
    Me.RbAppSite.Size = New System.Drawing.Size(112, 17)
    Me.RbAppSite.TabIndex = 509
    Me.RbAppSite.Text = "Site Plan Approval"
    Me.RbAppSite.UseVisualStyleBackColor = True
    '
    'RbAppSpecial
    '
    Me.RbAppSpecial.AutoSize = True
    Me.RbAppSpecial.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAppSpecial.Location = New System.Drawing.Point(156, 33)
    Me.RbAppSpecial.Name = "RbAppSpecial"
    Me.RbAppSpecial.Size = New System.Drawing.Size(132, 17)
    Me.RbAppSpecial.TabIndex = 510
    Me.RbAppSpecial.Text = "Special Exception Use"
    Me.RbAppSpecial.UseVisualStyleBackColor = True
    '
    'RbAppTax
    '
    Me.RbAppTax.AutoSize = True
    Me.RbAppTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbAppTax.Location = New System.Drawing.Point(305, 35)
    Me.RbAppTax.Name = "RbAppTax"
    Me.RbAppTax.Size = New System.Drawing.Size(145, 17)
    Me.RbAppTax.TabIndex = 511
    Me.RbAppTax.Text = "Text Change Amendment"
    Me.RbAppTax.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(185, 504)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(239, 20)
    Me.Label2.TabIndex = 512
    Me.Label2.Text = "- - - - Statement of Use - - - -"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(10, 531)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 13)
    Me.Label3.TabIndex = 514
    Me.Label3.Text = "Business Name"
    '
    'TxtSubus
    '
    Me.TxtSubus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSubus.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSubus.Location = New System.Drawing.Point(109, 527)
    Me.TxtSubus.MaxLength = 35
    Me.TxtSubus.Name = "TxtSubus"
    Me.TxtSubus.Size = New System.Drawing.Size(288, 22)
    Me.TxtSubus.TabIndex = 513
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(10, 559)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(96, 13)
    Me.Label4.TabIndex = 516
    Me.Label4.Text = "Hours of Operation"
    '
    'TxtSuhrs
    '
    Me.TxtSuhrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSuhrs.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSuhrs.Location = New System.Drawing.Point(109, 555)
    Me.TxtSuhrs.MaxLength = 25
    Me.TxtSuhrs.Name = "TxtSuhrs"
    Me.TxtSuhrs.Size = New System.Drawing.Size(207, 22)
    Me.TxtSuhrs.TabIndex = 515
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(327, 559)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(90, 13)
    Me.Label5.TabIndex = 518
    Me.Label5.Text = "No. of Employees"
    '
    'TxtSuemp
    '
    Me.TxtSuemp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSuemp.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSuemp.Location = New System.Drawing.Point(422, 555)
    Me.TxtSuemp.MaxLength = 5
    Me.TxtSuemp.Name = "TxtSuemp"
    Me.TxtSuemp.Size = New System.Drawing.Size(43, 22)
    Me.TxtSuemp.TabIndex = 517
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(10, 588)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(117, 13)
    Me.Label7.TabIndex = 520
    Me.Label7.Text = "Description of Business"
    '
    'TxtSudesc
    '
    Me.TxtSudesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSudesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSudesc.Location = New System.Drawing.Point(132, 584)
    Me.TxtSudesc.MaxLength = 50
    Me.TxtSudesc.Name = "TxtSudesc"
    Me.TxtSudesc.Size = New System.Drawing.Size(470, 22)
    Me.TxtSudesc.TabIndex = 519
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(10, 616)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(46, 13)
    Me.Label8.TabIndex = 522
    Me.Label8.Text = "Signage"
    '
    'TxtSusign
    '
    Me.TxtSusign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSusign.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSusign.Location = New System.Drawing.Point(132, 612)
    Me.TxtSusign.MaxLength = 50
    Me.TxtSusign.Name = "TxtSusign"
    Me.TxtSusign.Size = New System.Drawing.Size(470, 22)
    Me.TxtSusign.TabIndex = 521
    '
    'FrmBD001CZ
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.AutoScroll = True
    Me.ClientSize = New System.Drawing.Size(636, 644)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.TxtSusign)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtSudesc)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.TxtSuemp)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtSuhrs)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtSubus)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.RbAppTax)
    Me.Controls.Add(Me.RbAppSpecial)
    Me.Controls.Add(Me.RbAppSite)
    Me.Controls.Add(Me.LblPermDesc)
    Me.Controls.Add(Me.ChkCityWater)
    Me.Controls.Add(Me.TxtFloorSqfoot)
    Me.Controls.Add(Me.LblFloorSqfoot)
    Me.Controls.Add(Me.TxtPropSqFoot)
    Me.Controls.Add(Me.LblPropSqFoot)
    Me.Controls.Add(Me.ChkCityFront)
    Me.Controls.Add(Me.TxtZone)
    Me.Controls.Add(Me.LblZone)
    Me.Controls.Add(Me.TxtAppPhone)
    Me.Controls.Add(Me.LblAppPhone)
    Me.Controls.Add(Me.GrpProp)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.LblAppName)
    Me.Controls.Add(Me.TxtAppCity)
    Me.Controls.Add(Me.TxtAppState)
    Me.Controls.Add(Me.TxtAppAddr)
    Me.Controls.Add(Me.TxtAppZip)
    Me.Controls.Add(Me.LblAppCity)
    Me.Controls.Add(Me.LblAppAddr)
    Me.Controls.Add(Me.TxtAppName)
    Me.Controls.Add(Me.GrpPaytyp)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblBTUB)
    Me.Controls.Add(Me.LblBTRE)
    Me.Controls.Add(Me.TxtAuth)
    Me.Controls.Add(Me.LblAuth)
    Me.Controls.Add(Me.LblPermit)
    Me.Controls.Add(Me.BtnPermit)
    Me.Controls.Add(Me.LblAppl)
    Me.Controls.Add(Me.DtPckApp)
    Me.Controls.Add(Me.LblDesc)
    Me.Controls.Add(Me.TxtCity)
    Me.Controls.Add(Me.TxtState)
    Me.Controls.Add(Me.TxtAdd1)
    Me.Controls.Add(Me.TxtZip5)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.LblType)
    Me.Controls.Add(Me.LnkName)
    Me.Controls.Add(Me.LblTotal)
    Me.Controls.Add(Me.LblTotalHdr)
    Me.Controls.Add(Me.LblMisc)
    Me.Controls.Add(Me.LblMiscHdr)
    Me.Controls.Add(Me.BtnReceipt)
    Me.Controls.Add(Me.TxtMischg)
    Me.Controls.Add(Me.LblMischg)
    Me.Controls.Add(Me.TxtPayRef)
    Me.Controls.Add(Me.LblPayRef)
    Me.Controls.Add(Me.LblInsp)
    Me.Controls.Add(Me.DtPckInsp)
    Me.Controls.Add(Me.TxtValue)
    Me.Controls.Add(Me.LblValue)
    Me.Controls.Add(Me.TxtMap)
    Me.Controls.Add(Me.LblMap)
    Me.Controls.Add(Me.TxtLoc)
    Me.Controls.Add(Me.TxtLocNo)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtName)
    Me.Controls.Add(Me.LblTran)
    Me.Controls.Add(Me.DtPckTran)
    Me.Controls.Add(Me.TxtPermitNo)
    Me.Controls.Add(Me.LblPermitNo)
    Me.Controls.Add(Me.LblFee)
    Me.Controls.Add(Me.LblFeeHdr)
    Me.Controls.Add(Me.LblRecID)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD001CZ"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Maintenance"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpPaytyp.ResumeLayout(False)
    Me.GrpPaytyp.PerformLayout()
    Me.GrpProp.ResumeLayout(False)
    Me.GrpProp.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmBD001CZ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBDMAST = New BDMAST.mydata(MyDBConnect)
  myBDRATE = New BDRATE.mydata(MyDBConnect)

    InitFile()

  MyFrmBD001.TBarSettings.Enabled = False
  MyFrmBD001.TBarPending.Enabled = False
  MyFrmBD001.TBarChange.Enabled = False
  If MyPublic Then
    Me.Text = "Application"
    Me.ControlBox = False
    MyFrmBD001.TBarAuth.Enabled = True
    If WrkApp Then
      MyFrmBD001.TBarSave.Visible = True
      MyFrmBD001.TBarSave.Enabled = True
    Else
      SetPublic(False)
    End If
  Else
    MyFrmBD001.TBarNew.Enabled = False
    MyFrmBD001.TBarSave.Enabled = True
    If WrkRecID > 0 Then
      MyFrmBD001.TBarDelete.Enabled = True
    End If
    MyFrmBD001.TBarSettings.Enabled = False
  End If
  myBDMAST.GetOneRecordP(WrkRecID)
  LblAuth.Visible = False
  TxtAuth.Visible = False
  If Not MyPayCredit Then
    RbCredit.Visible = False
    MyFrmBD001.TBarCredit.Visible = False
  End If
  If myBDMAST.RecordNotFound Then
    If TxtValue.Visible = False Then
      LblFee.Text = Format(CalcFee(LblType.Text, 1), "fixed")
      LblTotal.Text = LblFee.Text
    End If
  End If

  If s_chg = False And s_full = False Then    '#sec
    MyFrmBD001.TBarSave.Visible = False
  End If
  LoadForm()
 End Sub
 Public Sub LoadForm()
   Dim ds2 As DataSet = New DataSet
   With myBDMAST
    If WrkRecID > 0 Then
      LblRecID.Text = "Record ID " & WrkRecID
    Else
      LblRecID.Text = "Pending"
    End If
    Select Case ._PZAPP
    Case "S"
      RbAppSite.Checked = True
    Case "E"
      RbAppSpecial.Checked = True
    Case "T"
      RbAppTax.Checked = True
    End Select
    If ._APDATE > 0 Then
      DtPckApp.Value = MyUtils.GetDBDate(._APDATE)
    Else
      DtPckApp.Value = Date.Today
    End If
    If ._TRDATE > 0 Then
      DtPckTran.Value = MyUtils.GetDBDate(._TRDATE)
    Else
      DtPckTran.Value = Date.Today
    End If
    TxtPermitNo.Text = Trim(._PERMNO)
    myBDRATE.GetFirstTier(WrkType)
    LblPermDesc.Text = Trim(myBDRATE._DESC)
    LblPermit.Text = Trim(myBDRATE._PERMIT)
    LblType.Text = WrkType
      BtnPermit.Enabled = False
      ds2 = myBDRATE.GetAllType(WrkType)
      If ds2.Tables(0).Rows.Count > 0 Then
        If Trim(ds2.Tables(0).Rows(0).Item("permit")) <> "" Then
          BtnPermit.Enabled = True
        End If
      End If
      If ._LISTNO > 0 Then
        LblListNo.Text = ._LISTNO
      Else
        LblListNo.Text = ""
    End If
    TxtName.Text = Trim(._NAME)
    TxtAdd1.Text = Trim(._ADD1)
    TxtCity.Text = Trim(._CITY)
    TxtState.Text = Trim(._STATE)
    If ._ZIP > 0 Then
      TxtZip5.Text = Format(._ZIP, "00000")
    End If
    TxtLocNo.Text = Trim(._LOCNO)
    TxtLoc.Text = Trim(._LOC)
    TxtMap.Text = Trim(._MAP)
    If ._VALUE > 0 Then
      TxtValue.Text = ._VALUE
    Else
      TxtValue.Text = ""
    End If
    If ._FEE > 0 And ._VALUE = 0 Then
      TxtValue.Text = ""
    End If
    If ._MISCHG > 0 Then
      TxtMischg.Text = ._MISCHG
    Else
      TxtMischg.Text = ""
    End If
    If ._INDATE > 0 Then
      DtPckInsp.Value = MyUtils.GetDBDate(._INDATE)
    Else
      DtPckInsp.Value = Date.Today
      DtPckInsp.Checked = False
    End If
    Select Case ._PAYTYP
    Case "CA"
      RbCash.Checked = True
    Case "CK"
      RbCheck.Checked = True
    Case "CR"
      RbCredit.Checked = True
    End Select
    TxtPayRef.Text = Trim(._PAYREF)
    LblFee.Text = Format(._FEE, "fixed")
    LblMisc.Text = Format(._MISCHG, "fixed")
    LblTotal.Text = Format(._FEE + ._MISCHG, "fixed")
    LblBTRE.Visible = False
    LblBTUB.Visible = False
    If Not RbCash.Checked And Not RbCheck.Checked Then
        CheckBackTax()
      End If
      TxtAppName.Text = Trim(._ANAME)
    TxtAppAddr.Text = Trim(._AADD1)
    TxtAppCity.Text = Trim(._APCITY)
    TxtAppState.Text = Trim(._ASTATE)
    If ._AZIP > 0 Then
      TxtAppZip.Text = Format(._AZIP, "00000")
    End If
    TxtAppPhone.Text = Trim(._APHONE)
    Select Case ._APROP
    Case "W"
      RbPropOwn.Checked = True
    Case "R"
      RbPropRent.Checked = True
    Case "B"
      RbPropOpt.Checked = True
    Case "O"
      RbPropOther.Checked = True
    End Select
    TxtZone.Text = Trim(._ZONE)
    If ._PZSQ > 0 Then
      TxtPropSqFoot.Text = ._PZSQ
    End If
    If ._PZUSE > 0 Then
      TxtFloorSqfoot.Text = ._PZUSE
    End If
    If ._PZFRNT = "Y" Then
      ChkCityFront.Checked = True
    Else
      ChkCityFront.Checked = False
    End If
    If ._PZWATR = "Y" Then
      ChkCityWater.Checked = True
    Else
      ChkCityWater.Checked = False
    End If
    TxtSubus.Text = Trim(._SUBUS)
    TxtSuhrs.Text = Trim(._SUHRS)
    If ._SUEMP > 0 Then
      TxtSuemp.Text = ._SUEMP
    End If
    TxtSudesc.Text = Trim(._SUDESC)
    TxtSusign.Text = Trim(._SUSIGN)
  End With
  TxtDesc.Text = FormatDesc(WrkRecID)
  If TxtValue.Visible = False Then
    LblFee.Text = Format(CalcFee(LblType.Text, 1), "fixed")
    LblTotal.Text = LblFee.Text
  End If
  If MyPayCredit And RbCredit.Checked Then
    MyFrmBD001.TBarCredit.Enabled = True
  End If

 End Sub
  Public Sub CheckBackTax()
    LblBTRE.Visible = False
    LblBTUB.Visible = False
    If CalcDelqListNo(MyUtils.CnvSng(LblListNo.Text), "R", DtPckTran.Value) Then
      LblBTRE.Visible = True
    End If
    If CalcDelqListNo(MyUtils.CnvSng(LblListNo.Text), "C", DtPckTran.Value) Then
      LblBTUB.Visible = True
    End If
  End Sub
  Public Sub SetPublic(IsVisible As Boolean)
    MyFrmBD001.TBarBack.Visible = IsVisible
    MyFrmBD001.TBarSave.Visible = IsVisible
    BtnReceipt.Visible = IsVisible
    BtnPermit.Visible = IsVisible
    LblFeeHdr.Visible = IsVisible
    LblFee.Visible = IsVisible
    LblMiscHdr.Visible = IsVisible
    LblMisc.Visible = IsVisible
    LblTotalHdr.Visible = IsVisible
    LblTotal.Visible = IsVisible
    LblAppl.Visible = IsVisible
    LblMap.Visible = IsVisible
    TxtMap.Visible = IsVisible
    DtPckApp.Visible = IsVisible
    LblTran.Visible = IsVisible
    DtPckTran.Visible = IsVisible
    GrpPaytyp.Visible = IsVisible
    RbCash.Visible = IsVisible
    RbCheck.Visible = IsVisible
    RbCredit.Visible = IsVisible
    LblInsp.Visible = IsVisible
    DtPckInsp.Visible = IsVisible
    LblMischg.Visible = IsVisible
    TxtMischg.Visible = IsVisible
    LblPayRef.Visible = IsVisible
    TxtPayRef.Visible = IsVisible
    LblPermitNo.Visible = IsVisible
    TxtPermitNo.Visible = IsVisible
    LblMap.Visible = False
    TxtMap.Visible = False
  End Sub
  Private Sub FrmBD001CZ_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
  If Not MyPublic Then
    MyFrmBD001.TBarNew.Enabled = True
    MyFrmBD001.TBarDelete.Enabled = False
    MyFrmBD001.TBarSave.Enabled = False
    MyFrmBD001.TBarSave.Visible = True   '#sec
    MyFrmBD001.TBarSettings.Enabled = True
    MyFrmBD001.TBarPending.Enabled = False
    MyFrmBD001.TBarCredit.Enabled = False
    MyFrmBD001B.FormatGrid()
    MyFrmBD001B.Show()
  Else
    MyFrmBD001.TBarNew.Enabled = False
    MyFrmBD001.TBarDelete.Enabled = False
    MyFrmBD001.TBarSave.Enabled = False
    MyFrmBD001.TBarSave.Visible = False    '#sec
    MyFrmBD001.TBarSettings.Enabled = False
    MyFrmBD001.TBarAuth.Enabled = False
    MyFrmBD001.TBarPending.Enabled = False
    MyFrmBD001.TBarCredit.Enabled = False
    MyFrmListTypes.Show()
  End If
  MyFrmBD001CZ = Nothing
  End Sub
  Public Sub DeleteData()
    myBDMAST.DeleteOneRecordP()
    DeleteBDCOM(WrkRecID)
  End Sub
  Public Sub SaveData()
  Dim ErrorField(50) As String
  Dim ErrorMsg(50) As String

  If Trim(TxtName.Text) = "BD001" Then
    Exit Sub
  End If

    If WrkRecID > 0 Then
      myBDMAST.GetOneRecordP(WrkRecID)
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myBDMAST.UpdateOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg, False)
        Exit Sub
      End If
    Else
      WrkRecID = myBDMAST.AutoGenKey
      myBDMAST.GetOneRecordP(WrkRecID)
      MoveToFile()
      EditChecks(ErrorField, ErrorMsg)
      If IsNothing(ErrorMsg(0)) Then
        myBDMAST._RECID = WrkRecID
        myBDMAST._PRF = Mid(MyUserID, 1, 10)
        myBDMAST.AddOneRecordP()
      Else
        ShowError(ErrorField, ErrorMsg, False)
      Exit Sub
    End If
  End If

  SaveBDCOM(WrkRecID, TxtDesc.Text)
  Me.Close()
  End Sub
Private Sub MoveToFile()
    With myBDMAST
      ._AADD1 = TxtAppAddr.Text
      ._ADD1 = TxtAdd1.Text
      ._ANAME = TxtAppName.Text
      ._APCITY = TxtAppCity.Text
      ._APDATE = MyUtils.SetDBDate(DtPckApp.Value)
      ._APHONE = TxtAppPhone.Text
      ._APROP = ""
      If RbPropOwn.Checked Then ._APROP = "W"
      If RbPropRent.Checked Then ._APROP = "R"
      If RbPropOpt.Checked Then ._APROP = "B"
      If RbPropOther.Checked Then ._APROP = "O"
      ._ASTATE = TxtAppState.Text
      ._AZIP = MyUtils.CnvSng(TxtAppZip.Text)
      ._ARCEXP = 0
      ._ARCLIC = ""
      ._BLDGAS = ""
      ._CBYDNO = ""
      ._CITY = TxtCity.Text
      ._COID = 0
      ._COLIC = ""
      ._CONAME = ""
      ._COPHON = ""
      ._CONSTY = ""
      ._CURUSE = ""
      ._DMDATE = 0
      ._DMELEC = ""
      ._DMGAS = ""
      ._DMPHON = ""
      ._DMSEPT = ""
      ._DMSIZE = ""
      ._DMSTOR = 0
      ._DMSWR = ""
      ._DMWPCA = ""
      ._ELACCT = ""
      ._ELECCD = ""
      ._ELECYR = 0
      ._HEATTY = ""
      ._HNDDIG = ""
      ._HSTDST = ""
      If DtPckInsp.Checked Then
        ._INDATE = MyUtils.SetDBDate(DtPckInsp.Value)
      Else
        ._INDATE = 0
      End If
      ._INNAME = ""
      ._LEVEL = ""
      ._LISTNO = MyUtils.CnvSng(LblListNo.Text)
      ._LOC = TxtLoc.Text
      ._LOCNO = MyUtils.JustifyRight(TxtLocNo.Text, 7)
      ._MAP = TxtMap.Text
      ._MISCHG = MyUtils.CnvSng(TxtMischg.Text)
      ._NAME = TxtName.Text
      ._PAYREF = TxtPayRef.Text
      ._PAYTYP = ""
      If RbCash.Checked Then
        ._PAYTYP = "CA"
      End If
      If RbCheck.Checked Then
        ._PAYTYP = "CK"
      End If
      If RbCredit.Checked Then
        ._PAYTYP = "CR"
      End If
      If MyUtils.CnvSng(TxtPermitNo.Text) > 0 Then
        ._PERMNO = MyUtils.CnvSng(TxtPermitNo.Text)
      Else
        ._PERMNO = ""
      End If
      ._PHONE = ""
      ._PROUSE = ""
      ._PZAPP = ""
      If RbAppSite.Checked Then ._PZAPP = "S"
      If RbAppSpecial.Checked Then ._PZAPP = "E"
      If RbAppTax.Checked Then ._PZAPP = "T"
      If ChkCityFront.Checked Then
        ._PZFRNT = "Y"
      Else
        ._PZFRNT = "N"
      End If
      ._PZSQ = MyUtils.CnvSng(TxtPropSqFoot.Text)
      ._PZUSE = MyUtils.CnvSng(TxtFloorSqfoot.Text)
      If ChkCityWater.Checked Then
        ._PZWATR = "Y"
      Else
        ._PZWATR = "N"
      End If
      ._ROADOP = ""
      ._SGDIM = ""
      ._SGELEC = ""
      ._SGERE = ""
      ._SGFAST = ""
      ._SGSIDE = ""
      ._SGSQ = 0
      ._STATE = TxtState.Text
      If Trim(._PAYTYP) = "" Then
        ._STATUS = "A"
      Else
        ._STATUS = "P"
      End If
      ._SUBUS = TxtSubus.Text
      ._SUHRS = TxtSuhrs.Text
      ._SUEMP = MyUtils.CnvSng(TxtSuemp.Text)
      ._SUDESC = TxtSudesc.Text
      ._SUSIGN = TxtSusign.Text
      ._TANK = 0
      ._TANKLO = ""
      ._TNNAME = ""
      If Trim(._PAYTYP) <> "" Then
        ._TRDATE = MyUtils.SetDBDate(DtPckTran.Value)
      Else
        ._TRDATE = 0
      End If
      ._TYPE = LblType.Text
      ._UNIT = ""
      ._VALUE = MyUtils.CnvSng(TxtValue.Text)
      ._WETLND = ""
      ._ZIP = MyUtils.CnvSng(TxtZip5.Text)
      ._ZONE = TxtZone.Text
      If WrkRecID = 0 And TxtValue.Text = "" Then
        ._FEE = CalcFee(._TYPE, ._VALUE)
      Else
        ._FEE = MyUtils.CnvSng(LblFee.Text)
      End If
    End With
  End Sub

Public Function VerifyData() As Boolean
  Dim ErrorField(50) As String
  Dim ErrorMsg(50) As String

  EditChecks(ErrorField, ErrorMsg)
  If IsNothing(ErrorMsg(0)) Then
    ShowError(ErrorField, ErrorMsg, True)
    Return True
  Else
    ShowError(ErrorField, ErrorMsg, False)
    Return False
  End If
End Function
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String, Clear As Boolean)
    Dim I As Integer
    ErrProv.SetError(LblType, "")
    ErrProv.SetError(LblListNo, "")
    ErrProv.SetError(TxtName, "")
    ErrProv.SetError(TxtPermitNo, "")

    If Clear Then
      Me.ForeColor = Color.Black
      Exit Sub
    End If
    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "list#"
        ErrProv.SetError(LblListNo, ErrorMsg(I))
      Case "name"
        ErrProv.SetError(TxtName, ErrorMsg(I))
      Case "permno"
        ErrProv.SetError(TxtPermitNo, ErrorMsg(I))
      Case "type"
        ErrProv.SetError(LblType, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If TxtName.Text = String.Empty Then
      ErrorField(I) = "name"
      ErrorMsg(I) = "Name cannot be blank"
      I = I + 1
    End If

    If MyUtils.CnvSng(LblListNo.Text) > 0 Then
      myTXREAL.GetOneRecordP(MyUtils.CnvSng(LblListNo.Text))
      If myTXREAL.RecordNotFound Then
        ErrorField(I) = "list#"
        ErrorMsg(I) = "List # is invalid"
        I = I + 1
      End If
    End If

    ds2 = myBDRATE.GetAllType(LblType.Text)
    If ds2.Tables(0).Rows.Count = 0 Then
      ErrorField(I) = "type"
      ErrorMsg(I) = "Type is invalid"
      I = I + 1
    End If
  End Sub
Public Function VerifyPermit() As Boolean
  Dim ErrorField(50) As String
  Dim ErrorMsg(50) As String

  PermitEdit(ErrorField, ErrorMsg)
  If IsNothing(ErrorMsg(0)) Then
    PermitError(ErrorField, ErrorMsg, True)
    Return True
  Else
    PermitError(ErrorField, ErrorMsg, False)
    Return False
  End If
End Function
  Private Sub PermitError(ByVal ErrorField() As String, ByVal ErrorMsg() As String, Clear As Boolean)
    Dim I As Integer
    ErrProv.SetError(RbCash, "")
    ErrProv.SetError(RbCheck, "")
    ErrProv.SetError(RbCredit, "")
    ErrProv.SetError(TxtPayRef, "")
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
      Case "cash"
        ErrProv.SetError(RbCash, ErrorMsg(I))
        ErrProv.SetError(RbCheck, ErrorMsg(I))
        ErrProv.SetError(RbCredit, ErrorMsg(I))
      Case "payref"
        ErrProv.SetError(TxtPayRef, ErrorMsg(I))
      Case Nothing
        Exit Sub
      End Select
    Next I
  End Sub
  Private Sub PermitEdit(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim ds2 As DataSet = New DataSet
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If Not RbCash.Checked And Not RbCheck.Checked And Not RbCredit.Checked Then
      ErrorField(I) = "cash"
      ErrorMsg(I) = "Choose a payment method"
      I = I + 1
    End If

    If RbCheck.Checked And Trim(TxtPayRef.Text) = String.Empty Then
      ErrorField(I) = "payref"
      ErrorMsg(I) = "Reference cannot be blank"
      I = I + 1
    End If

  End Sub
  Private Sub FrmBD001CZ_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmBD001.SbpScreen.Text = "BD001CZ"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub
Private Sub TxtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtValue.TextChanged
    Dim WrkFee As Decimal

    If MyUtils.CnvSng(TxtValue.Text) > 0 Then
      WrkFee = CalcFee(LblType.Text, MyUtils.CnvSng(TxtValue.Text))
      LblFee.Text = Format(WrkFee, "fixed")
      LblTotal.Text = Format(WrkFee + MyUtils.CnvSng(LblMisc.Text), "fixed")
    Else
      WrkFee = 0
      LblFee.Text = "0.00"
      LblTotal.Text = Format(WrkFee + MyUtils.CnvSng(LblMisc.Text), "fixed")
    End If
End Sub
Private Sub TxtMischg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtMischg.TextChanged
    LblMisc.Text = Format(MyUtils.CnvSng(TxtMischg.Text), "fixed")
    LblTotal.Text = Format(MyUtils.CnvSng(LblFee.Text) + MyUtils.CnvSng(LblMisc.Text), "fixed")
End Sub
Private Sub TxtValue_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtValue.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtMischg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMischg.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtPropSqFoot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPropSqFoot.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtFloorSqFoot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFloorSqfoot.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Public Sub GetTXREAL(ByVal ListNo As Integer)
 If ListNo = 0 Then Exit Sub

 myTXREAL.GetOneRecordP(ListNo)
 If Not myTXREAL.RecordNotFound Then
   With MyFrmBD001CZ
     .TxtName.Text = Trim(myTXREAL._NAME)
     .TxtAdd1.Text = Trim(myTXREAL._ADD1)
     .TxtCity.Text = Trim(myTXREAL._CITY)
     .TxtState.Text = Trim(myTXREAL._STATE)
     .TxtZip5.Text = Format(myTXREAL._ZIP5, "00000")
     .TxtLocNo.Text = Trim(myTXREAL._LOCNO)
     .TxtLoc.Text = Trim(myTXREAL._LOC)
     .TxtMap.Text = Trim(myTXREAL._MAP)
   End With
 End If
  End Sub
Private Sub BtnReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReceipt.Click
  Dim WrkPropLoc As String
  Dim WrkFee As Decimal
  Dim WrkMischg As Decimal
  Dim WrkTotal As Decimal
  Dim WrkPayType As String

    CheckBackTax()
    If LblBTRE.Visible Or LblBTUB.Visible Then Exit Sub

    If MyUtils.CnvSng(TxtPermitNo.Text) = 0 Then
    TxtPermitNo.Text = NextPermitNo(LblType.Text)
  End If

  With MyFrmBD001CZ
    WrkPropLoc = .TxtLocNo.Text & " " & .TxtLoc.Text
    WrkFee = MyUtils.CnvSng(.LblFee.Text)
    WrkMischg = MyUtils.CnvSng(.LblMisc.Text)
    WrkTotal = MyUtils.CnvSng(.LblTotal.Text)
    WrkPayType = ""
    If .RbCheck.Checked Then
      WrkPayType = "Check"
      PrtEndorseDirect(.DtPckTran.Value)
    End If
    If .RbCash.Checked Then
      WrkPayType = "Cash"
    End If
    If MyAppSettings.Receipt Then
      PrtReceiptDirect(.DtPckTran.Value, .TxtName.Text, WrkPropLoc, WrkFee, WrkMischg, WrkTotal, _
      .LblType.Text, .TxtPermitNo.Text, WrkPayType)
    End If
  End With

End Sub
Private Sub LnkName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkName.LinkClicked
    MyFrmListReal = New FrmListReal
    MyFrmListReal.MdiParent = Me.ParentForm
    MyFrmListReal.WrkFormID = "CZ"
    MyFrmListReal.WrkListNo = MyUtils.CnvSng(LblListNo.Text)
    MyFrmListReal.Show()
    Me.Hide()
End Sub
  Private Sub LblListNo_TextChanged(sender As Object, e As EventArgs) Handles LblListNo.TextChanged
    If MyUtils.CnvSng(LblListNo.Text) > 0 And Trim(TxtName.Text) <> "" Then
      GetTXREAL(LblListNo.Text)
    End If
  End Sub
  Private Sub BtnPermit_Click(sender As Object, e As EventArgs) Handles BtnPermit.Click
    Dim Good As Boolean
    Good = VerifyData()
    If Not Good Then Exit Sub

    Good = VerifyPermit()
    If Not Good Then Exit Sub

    If MyUtils.CnvSng(TxtPermitNo.Text) = 0 Then
      TxtPermitNo.Text = NextPermitNo(LblType.Text)
    End If
    If MyUtils.CnvSng(TxtPermitNo.Text) > 0 Then
      PrtPermit(LblType.Text, DtPckTran.Value)
    End If
  End Sub
Private Sub LnkCoName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
    MyFrmListCon = New FrmListCon
    MyFrmListCon.MdiParent = Me.ParentForm
    MyFrmListCon.WrkFormID = "CZ"
    MyFrmListCon.Show()
    Me.Hide()
End Sub
  Public Sub Authorize()
    Dim Good As Boolean

    With MyFrmBD001CZ
      If .TxtName.Text = "RESET" Then
        Me.Close()
        Exit Sub
      End If
      If Trim(.TxtName.Text) = "BD001" Then
        .TxtAuth.Visible = True
        Application.Exit()
      End If
      Good = .VerifyData
      If Not Good Then Exit Sub
      If Not .LblAuth.Visible Then
        .LblAuth.Visible = True
        .TxtAuth.Visible = True
        .TxtAuth.Focus()
        Exit Sub
      End If
      If Trim(.TxtAuth.Text) = "BD001" Then
        .SetPublic(True)
        CheckBackTax()
        .LblAuth.Visible = False
        .TxtAuth.Visible = False
      Else
        Exit Sub
      End If
    End With

    MyFrmBD001.TBarSave.Enabled = True
    MyFrmBD001.TBarAuth.Enabled = False
  End Sub
  Private Sub RbCheck_Click(sender As Object, e As EventArgs) Handles RbCheck.Click
    MyFrmBD001.TBarCredit.Enabled = False
  End Sub
  Private Sub RbCash_Click(sender As Object, e As EventArgs) Handles RbCash.Click
    MyFrmBD001.TBarCredit.Enabled = False
  End Sub
  Private Sub RbCredit_Click(sender As Object, e As EventArgs) Handles RbCredit.Click
    MyFrmBD001.TBarCredit.Enabled = True
  End Sub
Private Sub TxtSuemp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSuemp.KeyPress
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
End Sub
End Class






