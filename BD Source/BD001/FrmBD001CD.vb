Public Class FrmBD001CD
  Inherits System.Windows.Forms.Form
  Dim myBDMAST As BDMAST.myData
  Dim myBDRATE As BDRATE.myData
  Dim myBDCON As BDCON.myData
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
  Friend WithEvents LblAppl As System.Windows.Forms.Label
  Friend WithEvents DtPckApp As System.Windows.Forms.DateTimePicker
  Friend WithEvents BtnPermit As System.Windows.Forms.Button
  Friend WithEvents TxtPhone As System.Windows.Forms.TextBox
  Friend WithEvents LblPhone As System.Windows.Forms.Label
  Friend WithEvents LblPermit As System.Windows.Forms.Label
  Friend WithEvents TxtAuth As System.Windows.Forms.TextBox
  Friend WithEvents LblAuth As System.Windows.Forms.Label
  Friend WithEvents LblCoZip As System.Windows.Forms.Label
  Friend WithEvents LblCoState As System.Windows.Forms.Label
  Friend WithEvents LblCoID As System.Windows.Forms.Label
  Friend WithEvents TxtCoCity As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoState As System.Windows.Forms.TextBox
  Friend WithEvents TxtCoZip As System.Windows.Forms.TextBox
  Friend WithEvents LblCoCity As System.Windows.Forms.Label
  Friend WithEvents LblCoAddr As System.Windows.Forms.Label
  Friend WithEvents TxtCoAddr As System.Windows.Forms.TextBox
  Friend WithEvents LnkCoName As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtCoPhon As System.Windows.Forms.TextBox
  Friend WithEvents LblCoPhon As System.Windows.Forms.Label
  Friend WithEvents TxtCoLic As System.Windows.Forms.TextBox
  Friend WithEvents LblCoLic As System.Windows.Forms.Label
  Friend WithEvents TxtCoName As System.Windows.Forms.TextBox
  Friend WithEvents LblBTUB As System.Windows.Forms.Label
  Friend WithEvents LblBTRE As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents GrpPaytyp As System.Windows.Forms.GroupBox
  Friend WithEvents RbCash As System.Windows.Forms.RadioButton
  Friend WithEvents TxtSize As System.Windows.Forms.TextBox
  Friend WithEvents LblSize As System.Windows.Forms.Label
  Friend WithEvents TxtStory As System.Windows.Forms.TextBox
  Friend WithEvents LblStory As System.Windows.Forms.Label
  Friend WithEvents TxtConsty As System.Windows.Forms.TextBox
  Friend WithEvents LblConsty As System.Windows.Forms.Label
  Friend WithEvents TxtBldgas As System.Windows.Forms.TextBox
  Friend WithEvents LblBldgas As System.Windows.Forms.Label
  Friend WithEvents LblStart As System.Windows.Forms.Label
  Friend WithEvents DtPckStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents ChkSeptic As System.Windows.Forms.CheckBox
  Friend WithEvents ChkSewer As System.Windows.Forms.CheckBox
  Friend WithEvents ChkElec As System.Windows.Forms.CheckBox
  Friend WithEvents ChkPhone As System.Windows.Forms.CheckBox
  Friend WithEvents ChkWPCA As System.Windows.Forms.CheckBox
  Friend WithEvents ChkGas As System.Windows.Forms.CheckBox
  Friend WithEvents RbCheck As System.Windows.Forms.RadioButton
  Friend WithEvents RbCredit As System.Windows.Forms.RadioButton
  Dim LoadScrn As Boolean
  Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
  Friend WithEvents LblDesc As System.Windows.Forms.Label
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
    Me.LblAppl = New System.Windows.Forms.Label()
    Me.DtPckApp = New System.Windows.Forms.DateTimePicker()
    Me.BtnPermit = New System.Windows.Forms.Button()
    Me.TxtPhone = New System.Windows.Forms.TextBox()
    Me.LblPhone = New System.Windows.Forms.Label()
    Me.LblPermit = New System.Windows.Forms.Label()
    Me.TxtAuth = New System.Windows.Forms.TextBox()
    Me.LblAuth = New System.Windows.Forms.Label()
    Me.LblCoZip = New System.Windows.Forms.Label()
    Me.LblCoState = New System.Windows.Forms.Label()
    Me.LblCoID = New System.Windows.Forms.Label()
    Me.TxtCoCity = New System.Windows.Forms.TextBox()
    Me.TxtCoState = New System.Windows.Forms.TextBox()
    Me.TxtCoZip = New System.Windows.Forms.TextBox()
    Me.LblCoCity = New System.Windows.Forms.Label()
    Me.LblCoAddr = New System.Windows.Forms.Label()
    Me.TxtCoAddr = New System.Windows.Forms.TextBox()
    Me.LnkCoName = New System.Windows.Forms.LinkLabel()
    Me.TxtCoPhon = New System.Windows.Forms.TextBox()
    Me.LblCoPhon = New System.Windows.Forms.Label()
    Me.TxtCoLic = New System.Windows.Forms.TextBox()
    Me.LblCoLic = New System.Windows.Forms.Label()
    Me.TxtCoName = New System.Windows.Forms.TextBox()
    Me.LblBTRE = New System.Windows.Forms.Label()
    Me.LblBTUB = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GrpPaytyp = New System.Windows.Forms.GroupBox()
    Me.RbCredit = New System.Windows.Forms.RadioButton()
    Me.RbCheck = New System.Windows.Forms.RadioButton()
    Me.RbCash = New System.Windows.Forms.RadioButton()
    Me.TxtSize = New System.Windows.Forms.TextBox()
    Me.LblSize = New System.Windows.Forms.Label()
    Me.TxtStory = New System.Windows.Forms.TextBox()
    Me.LblStory = New System.Windows.Forms.Label()
    Me.TxtConsty = New System.Windows.Forms.TextBox()
    Me.LblConsty = New System.Windows.Forms.Label()
    Me.TxtBldgas = New System.Windows.Forms.TextBox()
    Me.LblBldgas = New System.Windows.Forms.Label()
    Me.LblStart = New System.Windows.Forms.Label()
    Me.DtPckStart = New System.Windows.Forms.DateTimePicker()
    Me.ChkSeptic = New System.Windows.Forms.CheckBox()
    Me.ChkSewer = New System.Windows.Forms.CheckBox()
    Me.ChkElec = New System.Windows.Forms.CheckBox()
    Me.ChkPhone = New System.Windows.Forms.CheckBox()
    Me.ChkWPCA = New System.Windows.Forms.CheckBox()
    Me.ChkGas = New System.Windows.Forms.CheckBox()
    Me.LblPermDesc = New System.Windows.Forms.Label()
    Me.TxtDesc = New System.Windows.Forms.TextBox()
    Me.LblDesc = New System.Windows.Forms.Label()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpPaytyp.SuspendLayout()
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
    Me.LblFee.Location = New System.Drawing.Point(538, 35)
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
    Me.LblFeeHdr.Location = New System.Drawing.Point(507, 36)
    Me.LblFeeHdr.Name = "LblFeeHdr"
    Me.LblFeeHdr.Size = New System.Drawing.Size(25, 13)
    Me.LblFeeHdr.TabIndex = 221
    Me.LblFeeHdr.Text = "Fee"
    '
    'TxtPermitNo
    '
    Me.TxtPermitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPermitNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPermitNo.Location = New System.Drawing.Point(514, 472)
    Me.TxtPermitNo.MaxLength = 10
    Me.TxtPermitNo.Name = "TxtPermitNo"
    Me.TxtPermitNo.Size = New System.Drawing.Size(88, 22)
    Me.TxtPermitNo.TabIndex = 34
    '
    'LblPermitNo
    '
    Me.LblPermitNo.AutoSize = True
    Me.LblPermitNo.Location = New System.Drawing.Point(419, 476)
    Me.LblPermitNo.Name = "LblPermitNo"
    Me.LblPermitNo.Size = New System.Drawing.Size(76, 13)
    Me.LblPermitNo.TabIndex = 224
    Me.LblPermitNo.Text = "Permit Number"
    '
    'LblTran
    '
    Me.LblTran.AutoSize = True
    Me.LblTran.Location = New System.Drawing.Point(419, 452)
    Me.LblTran.Name = "LblTran"
    Me.LblTran.Size = New System.Drawing.Size(75, 13)
    Me.LblTran.TabIndex = 352
    Me.LblTran.Text = "Approval Date"
    '
    'DtPckTran
    '
    Me.DtPckTran.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckTran.Location = New System.Drawing.Point(514, 446)
    Me.DtPckTran.Name = "DtPckTran"
    Me.DtPckTran.Size = New System.Drawing.Size(84, 20)
    Me.DtPckTran.TabIndex = 33
    '
    'TxtName
    '
    Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtName.Location = New System.Drawing.Point(120, 32)
    Me.TxtName.MaxLength = 35
    Me.TxtName.Name = "TxtName"
    Me.TxtName.Size = New System.Drawing.Size(288, 22)
    Me.TxtName.TabIndex = 0
    '
    'TxtLoc
    '
    Me.TxtLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLoc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLoc.Location = New System.Drawing.Point(264, 103)
    Me.TxtLoc.MaxLength = 25
    Me.TxtLoc.Name = "TxtLoc"
    Me.TxtLoc.Size = New System.Drawing.Size(208, 22)
    Me.TxtLoc.TabIndex = 6
    '
    'TxtLocNo
    '
    Me.TxtLocNo.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtLocNo.Location = New System.Drawing.Point(120, 104)
    Me.TxtLocNo.MaxLength = 7
    Me.TxtLocNo.Name = "TxtLocNo"
    Me.TxtLocNo.Size = New System.Drawing.Size(64, 22)
    Me.TxtLocNo.TabIndex = 5
    Me.TxtLocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(17, 107)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(89, 13)
    Me.Label6.TabIndex = 356
    Me.Label6.Text = "Job Site: Street #"
    '
    'TxtMap
    '
    Me.TxtMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMap.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMap.Location = New System.Drawing.Point(309, 134)
    Me.TxtMap.MaxLength = 17
    Me.TxtMap.Name = "TxtMap"
    Me.TxtMap.Size = New System.Drawing.Size(144, 22)
    Me.TxtMap.TabIndex = 8
    '
    'LblMap
    '
    Me.LblMap.AutoSize = True
    Me.LblMap.Location = New System.Drawing.Point(275, 138)
    Me.LblMap.Name = "LblMap"
    Me.LblMap.Size = New System.Drawing.Size(28, 13)
    Me.LblMap.TabIndex = 360
    Me.LblMap.Text = "Map"
    '
    'TxtValue
    '
    Me.TxtValue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtValue.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtValue.Location = New System.Drawing.Point(120, 292)
    Me.TxtValue.MaxLength = 10
    Me.TxtValue.Name = "TxtValue"
    Me.TxtValue.Size = New System.Drawing.Size(85, 22)
    Me.TxtValue.TabIndex = 14
    Me.TxtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblValue
    '
    Me.LblValue.AutoSize = True
    Me.LblValue.Location = New System.Drawing.Point(19, 297)
    Me.LblValue.Name = "LblValue"
    Me.LblValue.Size = New System.Drawing.Size(54, 13)
    Me.LblValue.TabIndex = 368
    Me.LblValue.Text = "Job Value"
    '
    'LblInsp
    '
    Me.LblInsp.AutoSize = True
    Me.LblInsp.Location = New System.Drawing.Point(20, 438)
    Me.LblInsp.Name = "LblInsp"
    Me.LblInsp.Size = New System.Drawing.Size(82, 13)
    Me.LblInsp.TabIndex = 370
    Me.LblInsp.Text = "Inspection Date"
    '
    'DtPckInsp
    '
    Me.DtPckInsp.Checked = False
    Me.DtPckInsp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInsp.Location = New System.Drawing.Point(121, 438)
    Me.DtPckInsp.Name = "DtPckInsp"
    Me.DtPckInsp.ShowCheckBox = True
    Me.DtPckInsp.Size = New System.Drawing.Size(99, 20)
    Me.DtPckInsp.TabIndex = 23
    Me.DtPckInsp.Value = New Date(2015, 9, 20, 0, 0, 0, 0)
    '
    'LblPayRef
    '
    Me.LblPayRef.AutoSize = True
    Me.LblPayRef.Location = New System.Drawing.Point(214, 476)
    Me.LblPayRef.Name = "LblPayRef"
    Me.LblPayRef.Size = New System.Drawing.Size(101, 13)
    Me.LblPayRef.TabIndex = 374
    Me.LblPayRef.Text = "Payment Reference"
    '
    'TxtPayRef
    '
    Me.TxtPayRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPayRef.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPayRef.Location = New System.Drawing.Point(323, 472)
    Me.TxtPayRef.MaxLength = 10
    Me.TxtPayRef.Name = "TxtPayRef"
    Me.TxtPayRef.Size = New System.Drawing.Size(85, 22)
    Me.TxtPayRef.TabIndex = 31
    '
    'TxtMischg
    '
    Me.TxtMischg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtMischg.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtMischg.Location = New System.Drawing.Point(313, 292)
    Me.TxtMischg.MaxLength = 10
    Me.TxtMischg.Name = "TxtMischg"
    Me.TxtMischg.Size = New System.Drawing.Size(85, 22)
    Me.TxtMischg.TabIndex = 15
    Me.TxtMischg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'LblMischg
    '
    Me.LblMischg.AutoSize = True
    Me.LblMischg.Location = New System.Drawing.Point(213, 297)
    Me.LblMischg.Name = "LblMischg"
    Me.LblMischg.Size = New System.Drawing.Size(66, 13)
    Me.LblMischg.TabIndex = 376
    Me.LblMischg.Text = "Misc Charge"
    '
    'BtnReceipt
    '
    Me.BtnReceipt.Location = New System.Drawing.Point(462, 127)
    Me.BtnReceipt.Name = "BtnReceipt"
    Me.BtnReceipt.Size = New System.Drawing.Size(67, 34)
    Me.BtnReceipt.TabIndex = 379
    Me.BtnReceipt.Text = "Print Receipt"
    Me.BtnReceipt.UseVisualStyleBackColor = True
    '
    'LblMisc
    '
    Me.LblMisc.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblMisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblMisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMisc.Location = New System.Drawing.Point(538, 51)
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
    Me.LblMiscHdr.Location = New System.Drawing.Point(481, 53)
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
    Me.LblTotal.Location = New System.Drawing.Point(538, 76)
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
    Me.LblTotalHdr.Location = New System.Drawing.Point(501, 78)
    Me.LblTotalHdr.Name = "LblTotalHdr"
    Me.LblTotalHdr.Size = New System.Drawing.Size(31, 13)
    Me.LblTotalHdr.TabIndex = 382
    Me.LblTotalHdr.Text = "Total"
    '
    'TxtCity
    '
    Me.TxtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCity.Location = New System.Drawing.Point(120, 76)
    Me.TxtCity.MaxLength = 25
    Me.TxtCity.Name = "TxtCity"
    Me.TxtCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCity.TabIndex = 2
    '
    'TxtState
    '
    Me.TxtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtState.Location = New System.Drawing.Point(336, 76)
    Me.TxtState.MaxLength = 2
    Me.TxtState.Name = "TxtState"
    Me.TxtState.Size = New System.Drawing.Size(24, 22)
    Me.TxtState.TabIndex = 3
    '
    'TxtAdd1
    '
    Me.TxtAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAdd1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtAdd1.Location = New System.Drawing.Point(120, 54)
    Me.TxtAdd1.MaxLength = 35
    Me.TxtAdd1.Name = "TxtAdd1"
    Me.TxtAdd1.Size = New System.Drawing.Size(288, 22)
    Me.TxtAdd1.TabIndex = 1
    '
    'TxtZip5
    '
    Me.TxtZip5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtZip5.Location = New System.Drawing.Point(368, 76)
    Me.TxtZip5.MaxLength = 5
    Me.TxtZip5.Name = "TxtZip5"
    Me.TxtZip5.Size = New System.Drawing.Size(48, 22)
    Me.TxtZip5.TabIndex = 4
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(20, 80)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(80, 16)
    Me.Label13.TabIndex = 404
    Me.Label13.Text = "City/State/Zip"
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(19, 58)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(80, 16)
    Me.Label15.TabIndex = 403
    Me.Label15.Text = "Street Address"
    '
    'LblListNo
    '
    Me.LblListNo.AutoSize = True
    Me.LblListNo.Location = New System.Drawing.Point(418, 34)
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
    Me.LnkName.Location = New System.Drawing.Point(18, 34)
    Me.LnkName.Name = "LnkName"
    Me.LnkName.Size = New System.Drawing.Size(69, 13)
    Me.LnkName.TabIndex = 1
    Me.LnkName.TabStop = True
    Me.LnkName.Text = "Owner Name"
    '
    'LblAppl
    '
    Me.LblAppl.AutoSize = True
    Me.LblAppl.Location = New System.Drawing.Point(419, 429)
    Me.LblAppl.Name = "LblAppl"
    Me.LblAppl.Size = New System.Drawing.Size(85, 13)
    Me.LblAppl.TabIndex = 419
    Me.LblAppl.Text = "Application Date"
    '
    'DtPckApp
    '
    Me.DtPckApp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckApp.Location = New System.Drawing.Point(514, 423)
    Me.DtPckApp.Name = "DtPckApp"
    Me.DtPckApp.Size = New System.Drawing.Size(84, 20)
    Me.DtPckApp.TabIndex = 32
    '
    'BtnPermit
    '
    Me.BtnPermit.Location = New System.Drawing.Point(535, 127)
    Me.BtnPermit.Name = "BtnPermit"
    Me.BtnPermit.Size = New System.Drawing.Size(67, 34)
    Me.BtnPermit.TabIndex = 421
    Me.BtnPermit.Text = "Print Permit"
    Me.BtnPermit.UseVisualStyleBackColor = True
    '
    'TxtPhone
    '
    Me.TxtPhone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPhone.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPhone.Location = New System.Drawing.Point(121, 134)
    Me.TxtPhone.MaxLength = 20
    Me.TxtPhone.Name = "TxtPhone"
    Me.TxtPhone.Size = New System.Drawing.Size(148, 22)
    Me.TxtPhone.TabIndex = 7
    '
    'LblPhone
    '
    Me.LblPhone.AutoSize = True
    Me.LblPhone.Location = New System.Drawing.Point(18, 139)
    Me.LblPhone.Name = "LblPhone"
    Me.LblPhone.Size = New System.Drawing.Size(72, 13)
    Me.LblPhone.TabIndex = 423
    Me.LblPhone.Text = "Owner Phone"
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
    'LblCoZip
    '
    Me.LblCoZip.AutoSize = True
    Me.LblCoZip.Location = New System.Drawing.Point(408, 364)
    Me.LblCoZip.Name = "LblCoZip"
    Me.LblCoZip.Size = New System.Drawing.Size(22, 13)
    Me.LblCoZip.TabIndex = 466
    Me.LblCoZip.Text = "Zip"
    '
    'LblCoState
    '
    Me.LblCoState.AutoSize = True
    Me.LblCoState.Location = New System.Drawing.Point(338, 364)
    Me.LblCoState.Name = "LblCoState"
    Me.LblCoState.Size = New System.Drawing.Size(32, 13)
    Me.LblCoState.TabIndex = 465
    Me.LblCoState.Text = "State"
    '
    'LblCoID
    '
    Me.LblCoID.AutoSize = True
    Me.LblCoID.Location = New System.Drawing.Point(415, 320)
    Me.LblCoID.Name = "LblCoID"
    Me.LblCoID.Size = New System.Drawing.Size(30, 13)
    Me.LblCoID.TabIndex = 464
    Me.LblCoID.Text = "<ID>"
    '
    'TxtCoCity
    '
    Me.TxtCoCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoCity.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoCity.Location = New System.Drawing.Point(121, 360)
    Me.TxtCoCity.MaxLength = 25
    Me.TxtCoCity.Name = "TxtCoCity"
    Me.TxtCoCity.Size = New System.Drawing.Size(210, 22)
    Me.TxtCoCity.TabIndex = 18
    '
    'TxtCoState
    '
    Me.TxtCoState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoState.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoState.Location = New System.Drawing.Point(376, 360)
    Me.TxtCoState.MaxLength = 2
    Me.TxtCoState.Name = "TxtCoState"
    Me.TxtCoState.Size = New System.Drawing.Size(24, 22)
    Me.TxtCoState.TabIndex = 19
    '
    'TxtCoZip
    '
    Me.TxtCoZip.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoZip.Location = New System.Drawing.Point(436, 359)
    Me.TxtCoZip.MaxLength = 5
    Me.TxtCoZip.Name = "TxtCoZip"
    Me.TxtCoZip.Size = New System.Drawing.Size(48, 22)
    Me.TxtCoZip.TabIndex = 20
    '
    'LblCoCity
    '
    Me.LblCoCity.AutoSize = True
    Me.LblCoCity.Location = New System.Drawing.Point(20, 364)
    Me.LblCoCity.Name = "LblCoCity"
    Me.LblCoCity.Size = New System.Drawing.Size(24, 13)
    Me.LblCoCity.TabIndex = 463
    Me.LblCoCity.Text = "City"
    '
    'LblCoAddr
    '
    Me.LblCoAddr.AutoSize = True
    Me.LblCoAddr.Location = New System.Drawing.Point(19, 342)
    Me.LblCoAddr.Name = "LblCoAddr"
    Me.LblCoAddr.Size = New System.Drawing.Size(76, 13)
    Me.LblCoAddr.TabIndex = 462
    Me.LblCoAddr.Text = "Street Address"
    '
    'TxtCoAddr
    '
    Me.TxtCoAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoAddr.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoAddr.Location = New System.Drawing.Point(121, 338)
    Me.TxtCoAddr.MaxLength = 35
    Me.TxtCoAddr.Name = "TxtCoAddr"
    Me.TxtCoAddr.Size = New System.Drawing.Size(219, 22)
    Me.TxtCoAddr.TabIndex = 17
    '
    'LnkCoName
    '
    Me.LnkCoName.AutoSize = True
    Me.LnkCoName.Location = New System.Drawing.Point(18, 320)
    Me.LnkCoName.Name = "LnkCoName"
    Me.LnkCoName.Size = New System.Drawing.Size(87, 13)
    Me.LnkCoName.TabIndex = 452
    Me.LnkCoName.TabStop = True
    Me.LnkCoName.Text = "Contractor Name"
    '
    'TxtCoPhon
    '
    Me.TxtCoPhon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoPhon.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoPhon.Location = New System.Drawing.Point(121, 404)
    Me.TxtCoPhon.MaxLength = 20
    Me.TxtCoPhon.Name = "TxtCoPhon"
    Me.TxtCoPhon.Size = New System.Drawing.Size(175, 22)
    Me.TxtCoPhon.TabIndex = 22
    '
    'LblCoPhon
    '
    Me.LblCoPhon.AutoSize = True
    Me.LblCoPhon.Location = New System.Drawing.Point(20, 408)
    Me.LblCoPhon.Name = "LblCoPhon"
    Me.LblCoPhon.Size = New System.Drawing.Size(90, 13)
    Me.LblCoPhon.TabIndex = 461
    Me.LblCoPhon.Text = "Contractor Phone"
    '
    'TxtCoLic
    '
    Me.TxtCoLic.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoLic.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoLic.Location = New System.Drawing.Point(121, 382)
    Me.TxtCoLic.MaxLength = 25
    Me.TxtCoLic.Name = "TxtCoLic"
    Me.TxtCoLic.Size = New System.Drawing.Size(209, 22)
    Me.TxtCoLic.TabIndex = 21
    '
    'LblCoLic
    '
    Me.LblCoLic.AutoSize = True
    Me.LblCoLic.Location = New System.Drawing.Point(20, 386)
    Me.LblCoLic.Name = "LblCoLic"
    Me.LblCoLic.Size = New System.Drawing.Size(96, 13)
    Me.LblCoLic.TabIndex = 460
    Me.LblCoLic.Text = "Contractor License"
    '
    'TxtCoName
    '
    Me.TxtCoName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtCoName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtCoName.Location = New System.Drawing.Point(121, 316)
    Me.TxtCoName.MaxLength = 35
    Me.TxtCoName.Name = "TxtCoName"
    Me.TxtCoName.Size = New System.Drawing.Size(288, 22)
    Me.TxtCoName.TabIndex = 16
    '
    'LblBTRE
    '
    Me.LblBTRE.AutoSize = True
    Me.LblBTRE.ForeColor = System.Drawing.Color.Red
    Me.LblBTRE.Location = New System.Drawing.Point(536, 92)
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
    Me.LblBTUB.Location = New System.Drawing.Point(536, 107)
    Me.LblBTUB.Name = "LblBTUB"
    Me.LblBTUB.Size = New System.Drawing.Size(71, 13)
    Me.LblBTUB.TabIndex = 468
    Me.LblBTUB.Text = "Back Tax UB"
    Me.LblBTUB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(192, 107)
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
    Me.GrpPaytyp.Location = New System.Drawing.Point(12, 463)
    Me.GrpPaytyp.Name = "GrpPaytyp"
    Me.GrpPaytyp.Size = New System.Drawing.Size(196, 36)
    Me.GrpPaytyp.TabIndex = 30
    Me.GrpPaytyp.TabStop = False
    '
    'RbCredit
    '
    Me.RbCredit.AutoSize = True
    Me.RbCredit.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.RbCredit.Location = New System.Drawing.Point(135, 11)
    Me.RbCredit.Name = "RbCredit"
    Me.RbCredit.Size = New System.Drawing.Size(52, 17)
    Me.RbCredit.TabIndex = 2
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
    Me.RbCheck.TabIndex = 0
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
    Me.RbCash.TabIndex = 1
    Me.RbCash.Text = "Cash"
    Me.RbCash.UseVisualStyleBackColor = True
    '
    'TxtSize
    '
    Me.TxtSize.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSize.Location = New System.Drawing.Point(207, 269)
    Me.TxtSize.MaxLength = 25
    Me.TxtSize.Name = "TxtSize"
    Me.TxtSize.Size = New System.Drawing.Size(208, 22)
    Me.TxtSize.TabIndex = 13
    '
    'LblSize
    '
    Me.LblSize.AutoSize = True
    Me.LblSize.Location = New System.Drawing.Point(175, 273)
    Me.LblSize.Name = "LblSize"
    Me.LblSize.Size = New System.Drawing.Size(27, 13)
    Me.LblSize.TabIndex = 478
    Me.LblSize.Text = "Size"
    '
    'TxtStory
    '
    Me.TxtStory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtStory.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtStory.Location = New System.Drawing.Point(121, 269)
    Me.TxtStory.MaxLength = 25
    Me.TxtStory.Name = "TxtStory"
    Me.TxtStory.Size = New System.Drawing.Size(36, 22)
    Me.TxtStory.TabIndex = 12
    '
    'LblStory
    '
    Me.LblStory.AutoSize = True
    Me.LblStory.Location = New System.Drawing.Point(9, 273)
    Me.LblStory.Name = "LblStory"
    Me.LblStory.Size = New System.Drawing.Size(89, 13)
    Me.LblStory.TabIndex = 477
    Me.LblStory.Text = "Number of stories"
    '
    'TxtConsty
    '
    Me.TxtConsty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtConsty.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtConsty.Location = New System.Drawing.Point(121, 242)
    Me.TxtConsty.MaxLength = 25
    Me.TxtConsty.Name = "TxtConsty"
    Me.TxtConsty.Size = New System.Drawing.Size(208, 22)
    Me.TxtConsty.TabIndex = 11
    '
    'LblConsty
    '
    Me.LblConsty.AutoSize = True
    Me.LblConsty.Location = New System.Drawing.Point(9, 246)
    Me.LblConsty.Name = "LblConsty"
    Me.LblConsty.Size = New System.Drawing.Size(105, 13)
    Me.LblConsty.TabIndex = 476
    Me.LblConsty.Text = "Type of Construction"
    '
    'TxtBldgas
    '
    Me.TxtBldgas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtBldgas.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtBldgas.Location = New System.Drawing.Point(15, 214)
    Me.TxtBldgas.MaxLength = 35
    Me.TxtBldgas.Name = "TxtBldgas"
    Me.TxtBldgas.Size = New System.Drawing.Size(288, 22)
    Me.TxtBldgas.TabIndex = 9
    '
    'LblBldgas
    '
    Me.LblBldgas.AutoSize = True
    Me.LblBldgas.Location = New System.Drawing.Point(11, 200)
    Me.LblBldgas.Name = "LblBldgas"
    Me.LblBldgas.Size = New System.Drawing.Size(373, 13)
    Me.LblBldgas.TabIndex = 475
    Me.LblBldgas.Text = "What use for at present (if vacant, give used for which building was designed)"
    '
    'LblStart
    '
    Me.LblStart.AutoSize = True
    Me.LblStart.Location = New System.Drawing.Point(328, 218)
    Me.LblStart.Name = "LblStart"
    Me.LblStart.Size = New System.Drawing.Size(80, 13)
    Me.LblStart.TabIndex = 480
    Me.LblStart.Text = "Work start date"
    '
    'DtPckStart
    '
    Me.DtPckStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStart.Location = New System.Drawing.Point(411, 216)
    Me.DtPckStart.Name = "DtPckStart"
    Me.DtPckStart.Size = New System.Drawing.Size(84, 20)
    Me.DtPckStart.TabIndex = 10
    '
    'ChkSeptic
    '
    Me.ChkSeptic.AutoSize = True
    Me.ChkSeptic.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSeptic.Location = New System.Drawing.Point(518, 291)
    Me.ChkSeptic.Name = "ChkSeptic"
    Me.ChkSeptic.Size = New System.Drawing.Size(68, 17)
    Me.ChkSeptic.TabIndex = 29
    Me.ChkSeptic.Text = "Septic?  "
    Me.ChkSeptic.UseVisualStyleBackColor = True
    '
    'ChkSewer
    '
    Me.ChkSewer.AutoSize = True
    Me.ChkSewer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkSewer.Location = New System.Drawing.Point(436, 291)
    Me.ChkSewer.Name = "ChkSewer"
    Me.ChkSewer.Size = New System.Drawing.Size(65, 17)
    Me.ChkSewer.TabIndex = 26
    Me.ChkSewer.Text = "Sewer? "
    Me.ChkSewer.UseVisualStyleBackColor = True
    '
    'ChkElec
    '
    Me.ChkElec.AutoSize = True
    Me.ChkElec.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkElec.Location = New System.Drawing.Point(517, 268)
    Me.ChkElec.Name = "ChkElec"
    Me.ChkElec.Size = New System.Drawing.Size(67, 17)
    Me.ChkElec.TabIndex = 28
    Me.ChkElec.Text = "Electric?"
    Me.ChkElec.UseVisualStyleBackColor = True
    '
    'ChkPhone
    '
    Me.ChkPhone.AutoSize = True
    Me.ChkPhone.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkPhone.Location = New System.Drawing.Point(436, 268)
    Me.ChkPhone.Name = "ChkPhone"
    Me.ChkPhone.Size = New System.Drawing.Size(63, 17)
    Me.ChkPhone.TabIndex = 25
    Me.ChkPhone.Text = "Phone?"
    Me.ChkPhone.UseVisualStyleBackColor = True
    '
    'ChkWPCA
    '
    Me.ChkWPCA.AutoSize = True
    Me.ChkWPCA.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkWPCA.Location = New System.Drawing.Point(517, 245)
    Me.ChkWPCA.Name = "ChkWPCA"
    Me.ChkWPCA.Size = New System.Drawing.Size(67, 17)
    Me.ChkWPCA.TabIndex = 27
    Me.ChkWPCA.Text = "WPCA? "
    Me.ChkWPCA.UseVisualStyleBackColor = True
    '
    'ChkGas
    '
    Me.ChkGas.AutoSize = True
    Me.ChkGas.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.ChkGas.Location = New System.Drawing.Point(436, 245)
    Me.ChkGas.Name = "ChkGas"
    Me.ChkGas.Size = New System.Drawing.Size(63, 17)
    Me.ChkGas.TabIndex = 24
    Me.ChkGas.Text = "Gas?    "
    Me.ChkGas.UseVisualStyleBackColor = True
    '
    'LblPermDesc
    '
    Me.LblPermDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPermDesc.ForeColor = System.Drawing.Color.Black
    Me.LblPermDesc.Location = New System.Drawing.Point(18, 10)
    Me.LblPermDesc.Name = "LblPermDesc"
    Me.LblPermDesc.Size = New System.Drawing.Size(258, 17)
    Me.LblPermDesc.TabIndex = 488
    Me.LblPermDesc.Text = "<Perm Desc>"
    Me.LblPermDesc.UseMnemonic = False
    '
    'TxtDesc
    '
    Me.TxtDesc.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDesc.Location = New System.Drawing.Point(121, 162)
    Me.TxtDesc.Multiline = True
    Me.TxtDesc.Name = "TxtDesc"
    Me.TxtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtDesc.Size = New System.Drawing.Size(482, 35)
    Me.TxtDesc.TabIndex = 9
    '
    'LblDesc
    '
    Me.LblDesc.AutoSize = True
    Me.LblDesc.Location = New System.Drawing.Point(14, 168)
    Me.LblDesc.Name = "LblDesc"
    Me.LblDesc.Size = New System.Drawing.Size(96, 13)
    Me.LblDesc.TabIndex = 490
    Me.LblDesc.Text = "Project Description"
    '
    'FrmBD001CD
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(614, 503)
    Me.Controls.Add(Me.TxtDesc)
    Me.Controls.Add(Me.LblDesc)
    Me.Controls.Add(Me.LblPermDesc)
    Me.Controls.Add(Me.GrpPaytyp)
    Me.Controls.Add(Me.ChkSeptic)
    Me.Controls.Add(Me.ChkSewer)
    Me.Controls.Add(Me.ChkElec)
    Me.Controls.Add(Me.ChkPhone)
    Me.Controls.Add(Me.ChkWPCA)
    Me.Controls.Add(Me.ChkGas)
    Me.Controls.Add(Me.LblStart)
    Me.Controls.Add(Me.DtPckStart)
    Me.Controls.Add(Me.TxtSize)
    Me.Controls.Add(Me.LblSize)
    Me.Controls.Add(Me.TxtStory)
    Me.Controls.Add(Me.LblStory)
    Me.Controls.Add(Me.TxtConsty)
    Me.Controls.Add(Me.LblConsty)
    Me.Controls.Add(Me.TxtBldgas)
    Me.Controls.Add(Me.LblBldgas)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblBTUB)
    Me.Controls.Add(Me.LblBTRE)
    Me.Controls.Add(Me.LblCoZip)
    Me.Controls.Add(Me.LblCoState)
    Me.Controls.Add(Me.LblCoID)
    Me.Controls.Add(Me.TxtCoCity)
    Me.Controls.Add(Me.TxtCoState)
    Me.Controls.Add(Me.TxtCoZip)
    Me.Controls.Add(Me.LblCoCity)
    Me.Controls.Add(Me.LblCoAddr)
    Me.Controls.Add(Me.TxtCoAddr)
    Me.Controls.Add(Me.LnkCoName)
    Me.Controls.Add(Me.TxtCoPhon)
    Me.Controls.Add(Me.LblCoPhon)
    Me.Controls.Add(Me.TxtCoLic)
    Me.Controls.Add(Me.LblCoLic)
    Me.Controls.Add(Me.TxtCoName)
    Me.Controls.Add(Me.TxtAuth)
    Me.Controls.Add(Me.LblAuth)
    Me.Controls.Add(Me.LblPermit)
    Me.Controls.Add(Me.TxtPhone)
    Me.Controls.Add(Me.LblPhone)
    Me.Controls.Add(Me.BtnPermit)
    Me.Controls.Add(Me.LblAppl)
    Me.Controls.Add(Me.DtPckApp)
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
    Me.Name = "FrmBD001CD"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Maintenance"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpPaytyp.ResumeLayout(False)
    Me.GrpPaytyp.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub

#End Region

Private Sub FrmBD001CD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  myBDMAST = New BDMAST.mydata(MyDBConnect)
  myBDRATE = New BDRATE.mydata(MyDBConnect)
  myBDCON = New BDCON.mydata(MyDBConnect)

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
    TxtPhone.Text = Trim(._PHONE)
    TxtLocNo.Text = Trim(._LOCNO)
    TxtLoc.Text = Trim(._LOC)
    TxtMap.Text = Trim(._MAP)
    TxtBldgas.Text = Trim(._BLDGAS)
    TxtConsty.Text = Trim(._CONSTY)
    TxtSize.Text = Trim(._DMSIZE)
    If ._DMSTOR > 0 Then
      TxtStory.Text = ._DMSTOR
    End If
    If ._DMDATE > 0 Then
      DtPckStart.Value = MyUtils.GetDBDate(._DMDATE)
    End If
    If ._DMELEC = "Y" Then
      ChkElec.Checked = True
    Else
      ChkElec.Checked = False
    End If
    If ._DMGAS = "Y" Then
      ChkGas.Checked = True
    Else
      ChkGas.Checked = False
    End If
    If ._DMPHON = "Y" Then
      ChkPhone.Checked = True
    Else
      ChkPhone.Checked = False
    End If
    If ._DMSEPT = "Y" Then
      ChkSeptic.Checked = True
    Else
      ChkSeptic.Checked = False
    End If
    If ._DMSWR = "Y" Then
      ChkSewer.Checked = True
    Else
      ChkSewer.Checked = False
    End If
    If ._DMWPCA = "Y" Then
      ChkWPCA.Checked = True
    Else
      ChkWPCA.Checked = False
    End If
    TxtCoName.Text = Trim(._CONAME)
    TxtCoLic.Text = Trim(._COLIC)
    If ._COID > 0 Then
      LblCoID.Text = ._COID
      myBDCON.GetOneRecordP(._COID)
      If Not myBDCON.RecordNotFound Then
        TxtCoAddr.Text = Trim(myBDCON._COADD1)
        TxtCoCity.Text = Trim(myBDCON._COCITY)
        TxtCoState.Text = Trim(myBDCON._COST)
        If myBDCON._COZIP > 0 Then
          TxtCoZip.Text = Format(myBDCON._COZIP, "00000")
        End If
      End If
    Else
      LblCoID.Text = ""
    End If
    TxtCoPhon.Text = Trim(._COPHON)
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
    TxtDesc.Text = FormatDesc(WrkRecID)
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
    End With
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
  End Sub
  Private Sub FrmBD001CD_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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
  MyFrmBD001CD = Nothing
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
        If TxtCoName.Text <> "" Then
          UpdateBDCON(MyUtils.CnvSng(LblCoID.Text), TxtCoName.Text, TxtCoAddr.Text, TxtCoCity.Text, TxtCoState.Text, MyUtils.CnvSng(TxtCoZip.Text),
          TxtCoPhon.Text, TxtCoLic.Text)
        End If
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
        If TxtCoName.Text <> "" Then
          UpdateBDCON(MyUtils.CnvSng(LblCoID.Text), TxtCoName.Text, TxtCoAddr.Text, TxtCoCity.Text, TxtCoState.Text, MyUtils.CnvSng(TxtCoZip.Text),
          TxtCoPhon.Text, TxtCoLic.Text)
        End If
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
      ._AADD1 = ""
      ._ADD1 = TxtAdd1.Text
      ._ANAME = ""
      ._APCITY = ""
      ._APDATE = MyUtils.SetDBDate(DtPckApp.Value)
      ._APHONE = ""
      ._APROP = ""
      ._ARCEXP = 0
      ._ARCLIC = ""
      ._ASTATE = ""
      ._AZIP = 0
      ._BLDGAS = TxtBldgas.Text
      ._CBYDNO = ""
      ._CITY = TxtCity.Text
      ._COID = MyUtils.CnvSng(LblCoID.Text)
      ._COLIC = TxtCoLic.Text
      ._CONAME = TxtCoName.Text
      ._COPHON = TxtCoPhon.Text
      ._CONSTY = TxtConsty.Text
      ._CURUSE = ""
      If DtPckStart.Visible Then
        ._DMDATE = MyUtils.SetDBDate(DtPckStart.Value)
      Else
        ._DMDATE = 0
      End If
      If ChkElec.Checked Then
        ._DMELEC = "Y"
      Else
        ._DMELEC = ""
      End If
      If ChkGas.Checked Then
        ._DMGAS = "Y"
      Else
        ._DMGAS = ""
      End If
      If ChkPhone.Checked Then
        ._DMPHON = "Y"
      Else
        ._DMPHON = ""
      End If
      If ChkSeptic.Checked Then
        ._DMSEPT = "Y"
      Else
        ._DMSEPT = ""
      End If
      ._DMSIZE = TxtSize.Text
      ._DMSTOR = MyUtils.CnvSng(TxtStory.Text)
      If ChkSewer.Checked Then
        ._DMSWR = "Y"
      Else
        ._DMSWR = ""
      End If
      If ChkWPCA.Checked Then
        ._DMWPCA = "Y"
      Else
        ._DMWPCA = ""
      End If
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
      ._PHONE = TxtPhone.Text
      ._PROUSE = ""
      ._PZAPP = ""
      ._PZFRNT = ""
      ._PZSQ = 0
      ._PZUSE = 0
      ._PZWATR = ""
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
      ._SUBUS = ""
      ._SUDESC = ""
      ._SUEMP = 0
      ._SUHRS = ""
      ._SUSIGN = ""
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
      ._ZONE = ""
      If WrkRecID = 0 And TxtValue.Text = "" Then
        ._FEE = CalcFee(._TYPE, ._VALUE)
      Else
        ._FEE = MyUtils.CnvSng(LblFee.Text)
      End If
    End With
  End Sub
  Public Sub UpdateBDCON(WrkCoID As Integer, WrkCoName As String, WrkCoAddr As String, WrkCoCity As String, WrkCoST As String, WrkCoZip As Integer,
   WrkCoPhone As String, WrkCoLic As String)

    With myBDCON
      .GetOneRecordP(WrkCoID)
      If WrkCoID > 0 Then
        If Not .RecordNotFound Then
          ._CONAME = WrkCoName
          ._COADD1 = WrkCoAddr
          ._COCITY = WrkCoCity
          ._COST = WrkCoST
          ._COZIP = WrkCoZip
          ._COPHON = WrkCoPhone
          CheckLic(WrkCoLic, ._COLIC1, ._COLIC2, ._COLIC3, ._COLIC4, ._COLIC5)
          ._PRF = Mid(MyUserID, 1, 10)
          .UpdateOneRecordP()
        End If
      Else
        WrkCoID = .AutoGenKey()
        .GetOneRecordP(WrkCoID)
        ._RECID = WrkCoID
        ._CONAME = WrkCoName
        ._COADD1 = WrkCoAddr
        ._COCITY = WrkCoCity
        ._COST = WrkCoST
        ._COZIP = WrkCoZip
        ._COPHON = WrkCoPhone
        ._COLIC1 = WrkCoLic
        ._COLIC2 = ""
        ._COLIC3 = ""
        ._COLIC4 = ""
        ._COLIC5 = ""
        ._PRF = Mid(MyUserID, 1, 10)
        .AddOneRecordP()
        LblCoID.Text = WrkCoID
        myBDMAST._COID = MyUtils.CnvSng(LblCoID.Text)
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
    ErrProv.SetError(TxtCoName, "")

    If Clear Then
      Me.ForeColor = Color.Black
      Exit Sub
    End If
    For I = 0 To ErrorField.GetUpperBound(0)
      Me.ForeColor = Color.DarkRed
      Select Case ErrorField(I)
      Case "coname"
        ErrProv.SetError(TxtCoName, ErrorMsg(I))
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

    If TxtCoName.Visible And TxtCoName.Text = String.Empty Then
      ErrorField(I) = "coname"
      ErrorMsg(I) = "Contractor Name cannot be blank"
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
  Private Sub FrmBD001CD_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmBD001.SbpScreen.Text = "BD001CD"
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
Private Sub TxtPropSqFoot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Private Sub TxtFloorSqFoot_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
  e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
End Sub
Public Sub GetTXREAL(ByVal ListNo As Integer)
 If ListNo = 0 Then Exit Sub

 myTXREAL.GetOneRecordP(ListNo)
 If Not myTXREAL.RecordNotFound Then
   With MyFrmBD001CD
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

  With MyFrmBD001CD
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
    MyFrmListReal.WrkFormID = "CD"
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
Private Sub LnkCoName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkCoName.LinkClicked
    MyFrmListCon = New FrmListCon
    MyFrmListCon.MdiParent = Me.ParentForm
    MyFrmListCon.WrkFormID = "CD"
    MyFrmListCon.WrkName = TxtCoName.Text
    MyFrmListCon.Show()
    Me.Hide()
End Sub
  Public Sub Authorize()
    Dim Good As Boolean

    With MyFrmBD001CD
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
End Class






