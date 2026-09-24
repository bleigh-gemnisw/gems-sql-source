Public Class FrmPO330B
  Inherits System.Windows.Forms.Form
  Friend WithEvents LblMsg As System.Windows.Forms.Label
  Dim myPOMAST As POMAST.MyData
  Dim myPOMASTL1 As POMASTL1.MyData
  Dim myPOSUMF As POSUMF.MyData
  Dim myPOSUMFL1 As POSUMFL1.MyData
  Dim myPURCTL As PURCTL.MyData
  Friend WithEvents GrpPO As System.Windows.Forms.GroupBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents LblVennm As System.Windows.Forms.Label
  Friend WithEvents LblOverExpend As System.Windows.Forms.Label
  Friend WithEvents BtnRemDtl As System.Windows.Forms.Button
  Friend WithEvents BtnAddDtl As System.Windows.Forms.Button
  Friend WithEvents TxtUnmsr As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents TxtUnitp As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents TxtRqqty As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents TxtItdsc As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents TxtItnbr As System.Windows.Forms.TextBox
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents LblRecno As System.Windows.Forms.Label
  Friend WithEvents LnkGLAcct As System.Windows.Forms.LinkLabel
  Friend WithEvents TxtSfcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtFcn As System.Windows.Forms.TextBox
  Friend WithEvents TxtObj As System.Windows.Forms.TextBox
  Friend WithEvents TxtDept As System.Windows.Forms.TextBox
  Friend WithEvents TxtSFund As System.Windows.Forms.TextBox
  Friend WithEvents TxtFund As System.Windows.Forms.TextBox
  Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
  Friend WithEvents BtnReset As System.Windows.Forms.Button
  Friend WithEvents LblExval As System.Windows.Forms.Label
  Friend WithEvents Label4 As Label
  Friend WithEvents DtPckRent8 As DateTimePicker
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
  Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TxtFscyr As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TxtPONbr As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblOpenAmt As System.Windows.Forms.Label
  Friend WithEvents LblPOAmt As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents BtnVerify As System.Windows.Forms.Button
  Friend WithEvents label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.label3 = New System.Windows.Forms.Label()
    Me.TxtPONbr = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtFscyr = New System.Windows.Forms.TextBox()
    Me.LblPOAmt = New System.Windows.Forms.Label()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.LblOpenAmt = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.BtnVerify = New System.Windows.Forms.Button()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.GrpPO = New System.Windows.Forms.GroupBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckRent8 = New System.Windows.Forms.DateTimePicker()
    Me.LblExval = New System.Windows.Forms.Label()
    Me.LblOverExpend = New System.Windows.Forms.Label()
    Me.BtnRemDtl = New System.Windows.Forms.Button()
    Me.BtnAddDtl = New System.Windows.Forms.Button()
    Me.TxtUnmsr = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtUnitp = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtRqqty = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtItdsc = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtItnbr = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.LblRecno = New System.Windows.Forms.Label()
    Me.LnkGLAcct = New System.Windows.Forms.LinkLabel()
    Me.TxtSfcn = New System.Windows.Forms.TextBox()
    Me.TxtFcn = New System.Windows.Forms.TextBox()
    Me.TxtObj = New System.Windows.Forms.TextBox()
    Me.TxtDept = New System.Windows.Forms.TextBox()
    Me.TxtSFund = New System.Windows.Forms.TextBox()
    Me.TxtFund = New System.Windows.Forms.TextBox()
    Me.DataGrdView = New System.Windows.Forms.DataGridView()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.LblVennm = New System.Windows.Forms.Label()
    Me.BtnReset = New System.Windows.Forms.Button()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GrpPO.SuspendLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'label3
    '
    Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.label3.Location = New System.Drawing.Point(-100, 74)
    Me.label3.Name = "label3"
    Me.label3.Size = New System.Drawing.Size(100, 23)
    Me.label3.TabIndex = 6
    Me.label3.Text = "New file name"
    Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'TxtPONbr
    '
    Me.TxtPONbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPONbr.Location = New System.Drawing.Point(79, 32)
    Me.TxtPONbr.MaxLength = 7
    Me.TxtPONbr.Name = "TxtPONbr"
    Me.TxtPONbr.Size = New System.Drawing.Size(60, 20)
    Me.TxtPONbr.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(9, 35)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(62, 13)
    Me.Label1.TabIndex = 403
    Me.Label1.Text = "PO Number"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(59, 13)
    Me.Label2.TabIndex = 406
    Me.Label2.Text = "Fiscal Year"
    '
    'TxtFscyr
    '
    Me.TxtFscyr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFscyr.Location = New System.Drawing.Point(79, 9)
    Me.TxtFscyr.MaxLength = 5
    Me.TxtFscyr.Name = "TxtFscyr"
    Me.TxtFscyr.Size = New System.Drawing.Size(35, 20)
    Me.TxtFscyr.TabIndex = 0
    '
    'LblPOAmt
    '
    Me.LblPOAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblPOAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblPOAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPOAmt.Location = New System.Drawing.Point(537, 9)
    Me.LblPOAmt.Name = "LblPOAmt"
    Me.LblPOAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblPOAmt.TabIndex = 408
    Me.LblPOAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.BackColor = System.Drawing.SystemColors.Control
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.Location = New System.Drawing.Point(470, 9)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(61, 13)
    Me.Label16.TabIndex = 407
    Me.Label16.Text = "PO Amount"
    '
    'LblOpenAmt
    '
    Me.LblOpenAmt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblOpenAmt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblOpenAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOpenAmt.Location = New System.Drawing.Point(537, 25)
    Me.LblOpenAmt.Name = "LblOpenAmt"
    Me.LblOpenAmt.Size = New System.Drawing.Size(64, 16)
    Me.LblOpenAmt.TabIndex = 409
    Me.LblOpenAmt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.BackColor = System.Drawing.SystemColors.Control
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(461, 28)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 13)
    Me.Label5.TabIndex = 410
    Me.Label5.Text = "Open Amount"
    '
    'BtnVerify
    '
    Me.BtnVerify.Location = New System.Drawing.Point(150, 18)
    Me.BtnVerify.Name = "BtnVerify"
    Me.BtnVerify.Size = New System.Drawing.Size(55, 34)
    Me.BtnVerify.TabIndex = 4
    Me.BtnVerify.Text = "Verify"
    Me.BtnVerify.UseVisualStyleBackColor = True
    '
    'LblMsg
    '
    Me.LblMsg.AutoSize = True
    Me.LblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblMsg.Location = New System.Drawing.Point(277, 29)
    Me.LblMsg.Name = "LblMsg"
    Me.LblMsg.Size = New System.Drawing.Size(71, 13)
    Me.LblMsg.TabIndex = 496
    Me.LblMsg.Text = "<Message>"
    '
    'GrpPO
    '
    Me.GrpPO.Controls.Add(Me.Label4)
    Me.GrpPO.Controls.Add(Me.DtPckRent8)
    Me.GrpPO.Controls.Add(Me.LblExval)
    Me.GrpPO.Controls.Add(Me.LblOverExpend)
    Me.GrpPO.Controls.Add(Me.BtnRemDtl)
    Me.GrpPO.Controls.Add(Me.BtnAddDtl)
    Me.GrpPO.Controls.Add(Me.TxtUnmsr)
    Me.GrpPO.Controls.Add(Me.Label13)
    Me.GrpPO.Controls.Add(Me.TxtUnitp)
    Me.GrpPO.Controls.Add(Me.Label12)
    Me.GrpPO.Controls.Add(Me.TxtRqqty)
    Me.GrpPO.Controls.Add(Me.Label11)
    Me.GrpPO.Controls.Add(Me.TxtItdsc)
    Me.GrpPO.Controls.Add(Me.Label10)
    Me.GrpPO.Controls.Add(Me.TxtItnbr)
    Me.GrpPO.Controls.Add(Me.Label9)
    Me.GrpPO.Controls.Add(Me.LblRecno)
    Me.GrpPO.Controls.Add(Me.LnkGLAcct)
    Me.GrpPO.Controls.Add(Me.TxtSfcn)
    Me.GrpPO.Controls.Add(Me.TxtFcn)
    Me.GrpPO.Controls.Add(Me.TxtObj)
    Me.GrpPO.Controls.Add(Me.TxtDept)
    Me.GrpPO.Controls.Add(Me.TxtSFund)
    Me.GrpPO.Controls.Add(Me.TxtFund)
    Me.GrpPO.Controls.Add(Me.DataGrdView)
    Me.GrpPO.Controls.Add(Me.Label6)
    Me.GrpPO.Controls.Add(Me.LblVennm)
    Me.GrpPO.Location = New System.Drawing.Point(9, 58)
    Me.GrpPO.Name = "GrpPO"
    Me.GrpPO.Size = New System.Drawing.Size(613, 336)
    Me.GrpPO.TabIndex = 498
    Me.GrpPO.TabStop = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(9, 10)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(86, 13)
    Me.Label4.TabIndex = 527
    Me.Label4.Text = "PO Posting Date"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'DtPckRent8
    '
    Me.DtPckRent8.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckRent8.Location = New System.Drawing.Point(102, 10)
    Me.DtPckRent8.Name = "DtPckRent8"
    Me.DtPckRent8.Size = New System.Drawing.Size(84, 20)
    Me.DtPckRent8.TabIndex = 526
    '
    'LblExval
    '
    Me.LblExval.AutoSize = True
    Me.LblExval.Location = New System.Drawing.Point(433, 264)
    Me.LblExval.Name = "LblExval"
    Me.LblExval.Size = New System.Drawing.Size(44, 13)
    Me.LblExval.TabIndex = 525
    Me.LblExval.Text = "<exval>"
    Me.LblExval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblOverExpend
    '
    Me.LblOverExpend.AutoSize = True
    Me.LblOverExpend.BackColor = System.Drawing.SystemColors.Control
    Me.LblOverExpend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblOverExpend.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblOverExpend.Location = New System.Drawing.Point(495, 264)
    Me.LblOverExpend.Name = "LblOverExpend"
    Me.LblOverExpend.Size = New System.Drawing.Size(112, 13)
    Me.LblOverExpend.TabIndex = 524
    Me.LblOverExpend.Text = "OVER EXPENDED"
    '
    'BtnRemDtl
    '
    Me.BtnRemDtl.Location = New System.Drawing.Point(461, 291)
    Me.BtnRemDtl.Name = "BtnRemDtl"
    Me.BtnRemDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnRemDtl.TabIndex = 523
    Me.BtnRemDtl.TabStop = False
    Me.BtnRemDtl.Text = "Remove Item"
    Me.BtnRemDtl.UseVisualStyleBackColor = True
    '
    'BtnAddDtl
    '
    Me.BtnAddDtl.Location = New System.Drawing.Point(374, 291)
    Me.BtnAddDtl.Name = "BtnAddDtl"
    Me.BtnAddDtl.Size = New System.Drawing.Size(81, 22)
    Me.BtnAddDtl.TabIndex = 522
    Me.BtnAddDtl.TabStop = False
    Me.BtnAddDtl.Text = "Add Item"
    Me.BtnAddDtl.UseVisualStyleBackColor = True
    '
    'TxtUnmsr
    '
    Me.TxtUnmsr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUnmsr.Location = New System.Drawing.Point(387, 261)
    Me.TxtUnmsr.MaxLength = 4
    Me.TxtUnmsr.Name = "TxtUnmsr"
    Me.TxtUnmsr.Size = New System.Drawing.Size(40, 20)
    Me.TxtUnmsr.TabIndex = 509
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(298, 264)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(82, 13)
    Me.Label13.TabIndex = 521
    Me.Label13.Text = "Unit of Measure"
    Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtUnitp
    '
    Me.TxtUnitp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtUnitp.Location = New System.Drawing.Point(202, 261)
    Me.TxtUnitp.MaxLength = 11
    Me.TxtUnitp.Name = "TxtUnitp"
    Me.TxtUnitp.Size = New System.Drawing.Size(81, 20)
    Me.TxtUnitp.TabIndex = 508
    Me.TxtUnitp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(143, 264)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(53, 13)
    Me.Label12.TabIndex = 520
    Me.Label12.Text = "Unit Price"
    Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtRqqty
    '
    Me.TxtRqqty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtRqqty.Location = New System.Drawing.Point(57, 261)
    Me.TxtRqqty.MaxLength = 10
    Me.TxtRqqty.Name = "TxtRqqty"
    Me.TxtRqqty.Size = New System.Drawing.Size(74, 20)
    Me.TxtRqqty.TabIndex = 507
    Me.TxtRqqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(9, 264)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(46, 13)
    Me.Label11.TabIndex = 519
    Me.Label11.Text = "Quantity"
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtItdsc
    '
    Me.TxtItdsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtItdsc.Location = New System.Drawing.Point(342, 235)
    Me.TxtItdsc.MaxLength = 30
    Me.TxtItdsc.Name = "TxtItdsc"
    Me.TxtItdsc.Size = New System.Drawing.Size(263, 20)
    Me.TxtItdsc.TabIndex = 506
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(277, 238)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(60, 13)
    Me.Label10.TabIndex = 518
    Me.Label10.Text = "Description"
    Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'TxtItnbr
    '
    Me.TxtItnbr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtItnbr.Location = New System.Drawing.Point(98, 235)
    Me.TxtItnbr.MaxLength = 20
    Me.TxtItnbr.Name = "TxtItnbr"
    Me.TxtItnbr.Size = New System.Drawing.Size(166, 20)
    Me.TxtItnbr.TabIndex = 505
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(9, 238)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(83, 13)
    Me.Label9.TabIndex = 517
    Me.Label9.Text = "Catalog Number"
    Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblRecno
    '
    Me.LblRecno.AutoSize = True
    Me.LblRecno.Location = New System.Drawing.Point(322, 295)
    Me.LblRecno.Name = "LblRecno"
    Me.LblRecno.Size = New System.Drawing.Size(46, 13)
    Me.LblRecno.TabIndex = 516
    Me.LblRecno.Text = "<recno>"
    Me.LblRecno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LnkGLAcct
    '
    Me.LnkGLAcct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LnkGLAcct.ForeColor = System.Drawing.Color.Maroon
    Me.LnkGLAcct.Location = New System.Drawing.Point(10, 295)
    Me.LnkGLAcct.Name = "LnkGLAcct"
    Me.LnkGLAcct.Size = New System.Drawing.Size(36, 18)
    Me.LnkGLAcct.TabIndex = 504
    Me.LnkGLAcct.TabStop = True
    Me.LnkGLAcct.Text = "Acct"
    '
    'TxtSfcn
    '
    Me.TxtSfcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSfcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSfcn.Location = New System.Drawing.Point(271, 291)
    Me.TxtSfcn.MaxLength = 4
    Me.TxtSfcn.Name = "TxtSfcn"
    Me.TxtSfcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtSfcn.TabIndex = 515
    '
    'TxtFcn
    '
    Me.TxtFcn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFcn.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFcn.Location = New System.Drawing.Point(220, 291)
    Me.TxtFcn.MaxLength = 4
    Me.TxtFcn.Name = "TxtFcn"
    Me.TxtFcn.Size = New System.Drawing.Size(45, 22)
    Me.TxtFcn.TabIndex = 514
    '
    'TxtObj
    '
    Me.TxtObj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtObj.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtObj.Location = New System.Drawing.Point(184, 291)
    Me.TxtObj.MaxLength = 3
    Me.TxtObj.Name = "TxtObj"
    Me.TxtObj.Size = New System.Drawing.Size(32, 22)
    Me.TxtObj.TabIndex = 513
    '
    'TxtDept
    '
    Me.TxtDept.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDept.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtDept.Location = New System.Drawing.Point(133, 291)
    Me.TxtDept.MaxLength = 4
    Me.TxtDept.Name = "TxtDept"
    Me.TxtDept.Size = New System.Drawing.Size(45, 22)
    Me.TxtDept.TabIndex = 512
    '
    'TxtSFund
    '
    Me.TxtSFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtSFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtSFund.Location = New System.Drawing.Point(95, 291)
    Me.TxtSFund.MaxLength = 3
    Me.TxtSFund.Name = "TxtSFund"
    Me.TxtSFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtSFund.TabIndex = 511
    '
    'TxtFund
    '
    Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtFund.Location = New System.Drawing.Point(57, 291)
    Me.TxtFund.MaxLength = 3
    Me.TxtFund.Name = "TxtFund"
    Me.TxtFund.Size = New System.Drawing.Size(32, 22)
    Me.TxtFund.TabIndex = 510
    '
    'DataGrdView
    '
    Me.DataGrdView.AllowUserToAddRows = False
    Me.DataGrdView.AllowUserToDeleteRows = False
    Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
    Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.DataGrdView.DefaultCellStyle = DataGridViewCellStyle1
    Me.DataGrdView.Location = New System.Drawing.Point(9, 65)
    Me.DataGrdView.MultiSelect = False
    Me.DataGrdView.Name = "DataGrdView"
    Me.DataGrdView.ReadOnly = True
    Me.DataGrdView.RowTemplate.Height = 16
    Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.DataGrdView.Size = New System.Drawing.Size(573, 157)
    Me.DataGrdView.TabIndex = 503
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.BackColor = System.Drawing.SystemColors.Control
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label6.Location = New System.Drawing.Point(10, 40)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(41, 13)
    Me.Label6.TabIndex = 500
    Me.Label6.Text = "Vendor"
    '
    'LblVennm
    '
    Me.LblVennm.AutoSize = True
    Me.LblVennm.Location = New System.Drawing.Point(78, 40)
    Me.LblVennm.Name = "LblVennm"
    Me.LblVennm.Size = New System.Drawing.Size(84, 13)
    Me.LblVennm.TabIndex = 499
    Me.LblVennm.Text = "<Vendor Name>"
    Me.LblVennm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.LblVennm.UseMnemonic = False
    '
    'BtnReset
    '
    Me.BtnReset.Location = New System.Drawing.Point(211, 18)
    Me.BtnReset.Name = "BtnReset"
    Me.BtnReset.Size = New System.Drawing.Size(55, 34)
    Me.BtnReset.TabIndex = 499
    Me.BtnReset.Text = "Reset"
    Me.BtnReset.UseVisualStyleBackColor = True
    '
    'FrmPO330B
    '
    Me.AllowDrop = True
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(635, 406)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnReset)
    Me.Controls.Add(Me.GrpPO)
    Me.Controls.Add(Me.LblMsg)
    Me.Controls.Add(Me.BtnVerify)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.LblOpenAmt)
    Me.Controls.Add(Me.LblPOAmt)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtFscyr)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPONbr)
    Me.Controls.Add(Me.label3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmPO330B"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GrpPO.ResumeLayout(False)
    Me.GrpPO.PerformLayout()
    CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

#End Region

  Private Sub PO330B_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    myPOMAST = New POMAST.MyData()
    myPOMAST.MyDBConn = myDBConnect
    myPOMASTL1 = New POMASTL1.MyData()
    myPOMASTL1.MyDBConn = myDBConnect
    myPOSUMF = New POSUMF.MyData()
    myPOSUMF.MyDBConn = myDBConnect
    myPOSUMFL1 = New POSUMFL1.MyData()
    myPOSUMFL1.MyDBConn = myDBConnect
    myPURCTL = New PURCTL.MyData()
    myPURCTL.MyDBConn = myDBConnect
    With MyFrmPO330
      .TBarPrint.Visible = False
    End With
    LblMsg.Text = ""
    LblVennm.Text = ""
    LblRecno.Text = ""
    LblExval.Text = ""
    GrpPO.Visible = False
    BtnRemDtl.Enabled = False
    BuildDS()
  End Sub
  Private Sub PO330B_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    MyFrmPO330.SbpScreen.Text = "PO330B"
    MyUtils.CenterForm(Me.ParentForm, Me)
  End Sub

  Public Sub SaveData(ByVal WrkSeqno As Integer)
    Dim WrkStr As String
    Dim WrkAcct As Decimal
    Dim SaveExval As Decimal
    Dim DiffExval As Decimal
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String

    If WrkSeqno = 0 Then
      WrkSeqno = myPOMAST.AutoGenKey(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text))
    End If

    myPOMAST.GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   0, WrkSeqno, 0)
    EditChecks(ErrorField, ErrorMsg)
    If IsNothing(ErrorMsg(0)) Then
      If myPOMAST.RecordNotFound Then
        MovetoFile(WrkSeqno, True)
        SaveExval = myPOMAST._EXVAL
        DiffExval = myPOMAST._EXVAL
        myPOMAST.AddOneRecordP()
      Else
        SaveExval = myPOMAST._EXVAL
        MovetoFile(WrkSeqno, False)
        DiffExval = myPOMAST._EXVAL - SaveExval
        myPOMAST.UpdateOneRecordP()
      End If
    Else
      ShowError(ErrorField, ErrorMsg)
      Exit Sub
    End If

    With myPOMAST
      WrkStr = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
      WrkAcct = Replace(WrkStr, "-", "")
      'Header Record 
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   0, 0, 0)
      ._POPEN = ._POPEN + DiffExval
      .UpdateOneRecordP()
    End With

    If DiffExval <> 0 Then
      UpdatePOAmt(WrkSeqno, DiffExval)
      With myPOSUMF
        .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
     WrkAcct)
        If .RecordNotFound Then
          ._FSCYR = MyUtils.CnvSng(TxtFscyr.Text)
          ._PONBR = MyUtils.CnvSng(TxtPONbr.Text)
          ._ACCT = WrkAcct
          ._POAMT = DiffExval
          ._POOPN = DiffExval
          ._POPAD = 0
          .AddOneRecordP()
        Else
          ._POAMT = ._POAMT + DiffExval
          ._POOPN = ._POOPN + DiffExval
          .UpdateOneRecordP()
        End If
        ProcFile(DiffExval)
      End With
    End If

    TxtItnbr.Text = ""
    TxtItdsc.Text = ""
    TxtRqqty.Text = ""
    TxtUnitp.Text = ""
    TxtUnmsr.Text = ""
    LblRecno.Text = ""
    LblExval.Text = ""
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    LnkGLAcct.Enabled = True
    TxtFund.Enabled = True
    TxtSFund.Enabled = True
    TxtDept.Enabled = True
    TxtObj.Enabled = True
    TxtFcn.Enabled = True
    TxtSfcn.Enabled = True
    ErrProv.Clear()
  End Sub
  Private Sub EditChecks(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim WrkDiffExval As Decimal
    Dim I As Integer

    For I = 0 To ErrorField.GetUpperBound(0)
      If IsNothing(ErrorField(I)) Then
        Exit For
      End If
    Next

    If MyUtils.CnvSng(TxtFscyr.Text) = 0 Then
      ErrorField(I) = "Fscyr"
      ErrorMsg(I) = "Fiscal Year cannot be zero"
      I = I + 1
    End If

    If MyUtils.CnvSng(TxtPONbr.Text) = 0 Then
      ErrorField(I) = "PONbr"
      ErrorMsg(I) = "PO Number cannot be zero"
      I = I + 1
    End If

    WrkDiffExval = MyUtils.CnvSng(LblExval.Text) - (MyUtils.CnvSng(TxtRqqty.Text) * MyUtils.CnvSng(TxtUnitp.Text))
    If WrkDiffExval >= 0 Then
      ErrorField(I) = "Exval"
      ErrorMsg(I) = "Cannot decrease to less than this amount"
      I = I + 1
    End If
    If MyUtils.CnvSng(TxtFund.Text) = 0 Then
      ErrorField(I) = "Fund"
      ErrorMsg(I) = "Account is required"
      I = I + 1
    End If

  End Sub
  Private Sub ShowError(ByVal ErrorField() As String, ByVal ErrorMsg() As String)
    Dim I As Integer
    ErrProv.Clear()
    For I = 0 To ErrorField.GetUpperBound(0)
      Select Case ErrorField(I)
        Case "Exval"
          ErrProv.SetError(LblExval, ErrorMsg(I))
        Case "Fscyr"
          ErrProv.SetError(TxtFscyr, ErrorMsg(I))
        Case "Fund"
          ErrProv.SetError(TxtFund, ErrorMsg(I))
        Case "PONbr"
          ErrProv.SetError(TxtPONbr, ErrorMsg(I))
        Case Nothing
          Exit Sub
      End Select
    Next I
  End Sub
  Private Sub MovetoFile(ByVal WrkSeqno As Integer, ByVal IsAdd As Boolean)
    Dim myPOMASTHdr As POMAST.MyData
    myPOMASTHdr = New POMAST.MyData()
    myPOMASTHdr.MyDBConn = myDBConnect
    myPOMASTHdr.GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   0, 0, 0)
    With myPOMAST
      If IsAdd Then
        ._BCHNO = myPOMASTHdr._BCHNO
        ._PONBR = MyUtils.CnvSng(TxtPONbr.Text)
        ._POSEQ = WrkSeqno
        ._RACTD = 0
        ._RENTC = 0
        ._RENTD = 0
        ._AMTNT = 0
        ._AMTGR = 0
        ._LNE = 0
        ._VNDNR = ""
        ._VENNM = ""
        ._LLOCN = ""
        ._PRJ = myPOMASTHdr._PRJ
        ._FSCYR = MyUtils.CnvSng(TxtFscyr.Text)
        ._SNAME = ""
        ._SADR1 = ""
        ._SADR2 = ""
        ._SADR3 = ""
        ._SADR4 = ""
        ._SZIP = ""
        ._SZIPE = ""
        ._RNAME = ""
        ._RADR1 = ""
        ._RADR2 = ""
        ._RADR3 = ""
        ._RADR4 = ""
        ._RZIP = ""
        ._RZIPE = ""
        ._ORDSP = 0
        ._DSCDL = 0
        ._ORSHP = 0
        ._SHPDL = 0
        ._FDNBD = 0
        ._SFUDD = 0
        ._DPNBD = 0
        ._OBNBD = 0
        ._FNPGD = 0
        ._SUBFD = 0
        ._FDNBS = 0
        ._SFUNS = 0
        ._DPNBS = 0
        ._OBNBS = 0
        ._FNPGS = 0
        ._SUBFS = 0
        '._AMTGR = 0
        '._AMTNT = 0
        ._POPST = myPOMASTHdr._POPST
      End If
      'Detail
      ._FDNBR = MyUtils.CnvSng(TxtFund.Text)
      ._SFUND = MyUtils.CnvSng(TxtSFund.Text)
      ._DPNBR = MyUtils.CnvSng(TxtDept.Text)
      ._OBNBR = MyUtils.CnvSng(TxtObj.Text)
      ._FNPGM = MyUtils.CnvSng(TxtFcn.Text)
      ._SUBFN = MyUtils.CnvSng(TxtSfcn.Text)
      ._ITDSC = TxtItdsc.Text
      ._ITNBR = TxtItnbr.Text
      ._RQQTY = MyUtils.CnvSng(TxtRqqty.Text)
      ._UNITP = MyUtils.CnvSng(TxtUnitp.Text)
      ._UNMSR = TxtUnmsr.Text
      ._EXVAL = ._RQQTY * ._UNITP
      ._POPEN = 0
      ._CMPCD = ""
    End With
  End Sub
  Public Sub DeleteDtl()
    Dim WrkSeqno As Integer
    Dim WrkStr As String
    Dim WrkAcct As Decimal
    Dim SaveExval As Decimal
    Dim Answer As Integer
    WrkSeqno = MyUtils.CnvSng(LblRecno.Text)

    Answer = MsgBox("Remove item " & WrkSeqno & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirm Remove")
    If Answer = vbNo Then
      Exit Sub
    End If

    With myPOMAST
      'Detail Record 
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   0, WrkSeqno, 0)
      SaveExval = ._EXVAL
      WrkStr = BuildAcct(._FDNBR, ._SFUND, ._DPNBR, ._OBNBR, ._FNPGM, ._SUBFN)
      .DeleteOneRecordP()
      WrkAcct = Replace(WrkStr, "-", "")
      If SaveExval <> 0 Then
        'Header Record 
        .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
     0, 0, 0)
        ._POPEN = ._POPEN - SaveExval
        .UpdateOneRecordP()
      End If
    End With

    If SaveExval <> 0 Then
      UpdatePOAmt(WrkSeqno, SaveExval * -1)
      With myPOSUMF
        .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
     WrkAcct)
        If Not .RecordNotFound Then
          ._POAMT = ._POAMT - SaveExval
          ._POOPN = ._POOPN - SaveExval
          .UpdateOneRecordP()
        End If
      End With
      ProcFile(SaveExval * -1)
    End If

    TxtItnbr.Text = ""
    TxtItdsc.Text = ""
    TxtRqqty.Text = ""
    TxtUnitp.Text = ""
    TxtUnmsr.Text = ""
    LblRecno.Text = ""
    FormatGrid()
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    LnkGLAcct.Enabled = True
    TxtFund.Enabled = True
    TxtSFund.Enabled = True
    TxtDept.Enabled = True
    TxtObj.Enabled = True
    TxtFcn.Enabled = True
    TxtSfcn.Enabled = True
  End Sub
  Private Sub UpdatePOAmt(ByVal WrkSeqNo As Integer, ByVal DiffExval As Decimal)
    Dim WrkSet As String
    Dim WrkWhere As String

    WrkSet = "Set AMTGR=AMTGR+" & DiffExval & ",AMTNT=AMTNT+" & DiffExval
    WrkWhere = " where FSCYR=" & MyUtils.CnvSng(TxtFscyr.Text) & " and PONBR=" & MyUtils.CnvSng(TxtPONbr.Text) &
      " and POSEQ in(" & WrkSeqNo & ",0)"
    myPOMAST.RunUpdateQuery(WrkSet, WrkWhere)
  End Sub

  Private Sub TxtFscyr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFscyr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtPONbr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPONbr.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
    BtnVerify.Enabled = False
    TxtFscyr.Enabled = False
    TxtPONbr.Enabled = False
    VerifyPO()
  End Sub
  Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
    ErrProv.Clear()
    LblOpenAmt.Text = ""
    LblPOAmt.Text = ""
    LblMsg.Text = ""
    LblExval.Text = ""
    TxtItnbr.Text = ""
    TxtItdsc.Text = ""
    TxtRqqty.Text = ""
    TxtUnitp.Text = ""
    TxtUnmsr.Text = ""
    TxtFund.Text = ""
    TxtSFund.Text = ""
    TxtDept.Text = ""
    TxtObj.Text = ""
    TxtFcn.Text = ""
    TxtSfcn.Text = ""
    LblRecno.Text = ""
    BtnVerify.Enabled = True
    TxtFscyr.Enabled = True
    TxtPONbr.Enabled = True
    GrpPO.Visible = False
    BtnAddDtl.Text = "Add Item"
    BtnRemDtl.Enabled = False
    LnkGLAcct.Enabled = True
    TxtFund.Enabled = True
    TxtSFund.Enabled = True
    TxtDept.Enabled = True
    TxtObj.Enabled = True
    TxtFcn.Enabled = True
    TxtSfcn.Enabled = True
  End Sub
  Private Sub VerifyPO()
    Dim ErrorField(25) As String
    Dim ErrorMsg(25) As String
    LblMsg.Text = ""
    GrpPO.Visible = False
    BtnRemDtl.Enabled = False
    LblVennm.Text = ""
    myPOMAST.GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text),
   0, 0, 0)
    If Not myPOMAST.RecordNotFound Then
      If myPOMAST._CMPCD = "C" Then
        LblMsg.Text = "*** PO is closed ***"
        Exit Sub
      End If
      LblVennm.Text = myPOMAST._VENNM
      LblOpenAmt.Text = myPOMAST._POPEN
      LblPOAmt.Text = myPOMAST._AMTNT
    Else
      LblMsg.Text = "*** PO not found ***"
      Exit Sub
    End If
    GrpPO.Visible = True
    DtPckRent8.Value = Date.Today
    With myPURCTL
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text))
      If MyUtils.SetDBDate(DtPckRent8.Value) > ._FSCE8 Then
        DtPckRent8.Value = MyUtils.GetDBDate(._FSCE8)
      End If
    End With
    GetPOMAST()
    FormatGrid()
  End Sub
  Public Sub FormatGrid()
    Call ShowGrid()

    With DataGrdView
      .AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
      .RowHeadersWidth = 25
      .Columns(0).HeaderText = "Seq No"
      .Columns(0).Width = 45
      .Columns(1).HeaderText = "Catalog"
      .Columns(1).Width = 100
      .Columns(2).HeaderText = "Description"
      .Columns(2).Width = 150
      .Columns(3).HeaderText = "Amount"
      .Columns(3).Width = 75
      .Columns(4).HeaderText = "Quantity"
      .Columns(4).Width = 60
      .Columns(5).HeaderText = "Price"
      .Columns(5).Width = 60
      .Columns(6).HeaderText = "UOM"
      .Columns(6).Width = 50
      .Columns(7).HeaderText = "Fund"
      .Columns(7).Width = 40
      .Columns(8).HeaderText = "Sfund"
      .Columns(8).Width = 40
      .Columns(9).HeaderText = "Dept"
      .Columns(9).Width = 40
      .Columns(10).HeaderText = "Obj"
      .Columns(10).Width = 40
      .Columns(11).HeaderText = "Func"
      .Columns(11).Width = 40
      .Columns(12).HeaderText = "Sfcn"
      .Columns(12).Width = 40
    End With
  End Sub
  Public Sub ShowGrid()
    DataGrdView.DataSource = ds.Tables(0)
    DataGrdView.Refresh()
  End Sub
  Sub BuildDS()
    Dim myTable As New DataTable
    With myTable
      .TableName = "mytable"
      .Columns.Add("poseq", Type.GetType("System.Int32"))
      .Columns.Add("itnbr", Type.GetType("System.String"))
      .Columns.Add("itdsc", Type.GetType("System.String"))
      .Columns.Add("amtnt", Type.GetType("System.Decimal"))
      .Columns.Add("rqqty", Type.GetType("System.Decimal"))
      .Columns.Add("unitp", Type.GetType("System.Decimal"))
      .Columns.Add("unmsr", Type.GetType("System.String"))
      .Columns.Add("fdnbr", Type.GetType("System.Int32"))
      .Columns.Add("sfund", Type.GetType("System.Int32"))
      .Columns.Add("dpnbr", Type.GetType("System.Int32"))
      .Columns.Add("obnbr", Type.GetType("System.Int32"))
      .Columns.Add("fnpgm", Type.GetType("System.Int32"))
      .Columns.Add("subfn", Type.GetType("System.Int32"))
    End With
    ds.Tables.Add(myTable)
  End Sub
  Private Sub GetPOMAST()
    Dim dr As DataRow
    Dim ds2 As DataSet = New DataSet
    Dim ds3 As DataSet = New DataSet
    Dim SumAcct(25) As Decimal
    Dim SumAmt(25) As Decimal
    Dim WrkStr As String
    Dim WrkAcct As Decimal
    Dim WrkRecno As Integer
    Dim I As Integer
    Dim J As Integer

    ds.Clear()
    With myPOMASTL1
      ds2 = .GetAllPONo(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text), 0)
    End With
    If ds2.Tables(0).Rows.Count = 0 Then
      Exit Sub
    End If

    ds3 = myPOSUMFL1.GetAllPONo(MyUtils.CnvSng(TxtFscyr.Text), MyUtils.CnvSng(TxtPONbr.Text), 0)
    If ds3.Tables(0).Rows.Count > 0 Then
      For J = 0 To ds3.Tables(0).Rows.Count - 1
        SumAcct(J) = ds3.Tables(0).Rows(J).Item("acct")
        SumAmt(J) = ds3.Tables(0).Rows(J).Item("poopn")
      Next
    End If

    For I = 0 To ds2.Tables(0).Rows.Count - 1
      If I = 0 Then
        LblVennm.Text = ds2.Tables(0).Rows(I).Item("vennm")
        If ds2.Tables(0).Rows(I).Item("cmpcd") = "C" Then
          Exit Sub
        End If
      Else
        WrkStr = BuildAcct(ds2.Tables(0).Rows(I).Item("fdnbr"),
        ds2.Tables(0).Rows(I).Item("sfund"), ds2.Tables(0).Rows(I).Item("dpnbr"),
        ds2.Tables(0).Rows(I).Item("obnbr"), ds2.Tables(0).Rows(I).Item("fnpgm"),
        ds2.Tables(0).Rows(I).Item("subfn"))
        WrkAcct = Replace(WrkStr, "-", "")
        For J = 0 To SumAcct.GetUpperBound(0)
          If WrkAcct = SumAcct((J)) Then
            Exit For
          End If
        Next
        If ds2.Tables(0).Rows(I).Item("exval") = 0 Then
          dr = ds.Tables(0).NewRow
          dr("poseq") = ds2.Tables(0).Rows(I).Item("poseq")
          dr("itnbr") = ds2.Tables(0).Rows(I).Item("itnbr")
          dr("itdsc") = ds2.Tables(0).Rows(I).Item("itdsc")
          dr("amtnt") = ds2.Tables(0).Rows(I).Item("exval")
          dr("rqqty") = ds2.Tables(0).Rows(I).Item("rqqty")
          dr("unitp") = ds2.Tables(0).Rows(I).Item("unitp")
          dr("unmsr") = ds2.Tables(0).Rows(I).Item("unmsr")
          dr("fdnbr") = ds2.Tables(0).Rows(I).Item("fdnbr")
          dr("sfund") = ds2.Tables(0).Rows(I).Item("sfund")
          dr("dpnbr") = ds2.Tables(0).Rows(I).Item("dpnbr")
          dr("obnbr") = ds2.Tables(0).Rows(I).Item("obnbr")
          dr("fnpgm") = ds2.Tables(0).Rows(I).Item("fnpgm")
          dr("subfn") = ds2.Tables(0).Rows(I).Item("subfn")
          dr("amtnt") = ds2.Tables(0).Rows(I).Item("exval")
          ds.Tables(0).Rows.Add(dr)
          Continue For
        End If
        If SumAcct.GetUpperBound(0) >= J Then
          If SumAmt(J) > 0 Then
            WrkRecno = WrkRecno + 1
            dr = ds.Tables(0).NewRow
            dr("poseq") = ds2.Tables(0).Rows(I).Item("poseq")
            dr("itnbr") = ds2.Tables(0).Rows(I).Item("itnbr")
            dr("itdsc") = ds2.Tables(0).Rows(I).Item("itdsc")
            dr("amtnt") = ds2.Tables(0).Rows(I).Item("exval")
            dr("rqqty") = ds2.Tables(0).Rows(I).Item("rqqty")
            dr("unitp") = ds2.Tables(0).Rows(I).Item("unitp")
            dr("unmsr") = ds2.Tables(0).Rows(I).Item("unmsr")
            dr("fdnbr") = ds2.Tables(0).Rows(I).Item("fdnbr")
            dr("sfund") = ds2.Tables(0).Rows(I).Item("sfund")
            dr("dpnbr") = ds2.Tables(0).Rows(I).Item("dpnbr")
            dr("obnbr") = ds2.Tables(0).Rows(I).Item("obnbr")
            dr("fnpgm") = ds2.Tables(0).Rows(I).Item("fnpgm")
            dr("subfn") = ds2.Tables(0).Rows(I).Item("subfn")
            If ds2.Tables(0).Rows(I).Item("exval") <= SumAmt(J) Then
              dr("amtnt") = ds2.Tables(0).Rows(I).Item("exval")
              SumAmt(J) = SumAmt(J) - ds2.Tables(0).Rows(I).Item("exval")
            Else
              dr("amtnt") = SumAmt(J)
              SumAmt(J) = 0
            End If
            ds.Tables(0).Rows.Add(dr)
          End If
        End If
      End If
    Next
  End Sub
  Private Sub DataGrdView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrdView.DoubleClick
    Dim WrkExVal As Decimal
    If DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value <> "" Then
      LblRecno.Text = DataGrdView.Item(0, DataGrdView.CurrentRow.Index).Value
      TxtItnbr.Text = Trim(DataGrdView.Item(1, DataGrdView.CurrentRow.Index).Value)
      TxtItdsc.Text = Trim(DataGrdView.Item(2, DataGrdView.CurrentRow.Index).Value)
      TxtRqqty.Text = DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value
      TxtUnitp.Text = DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value
      TxtUnmsr.Text = Trim(DataGrdView.Item(6, DataGrdView.CurrentRow.Index).Value)
      TxtFund.Text = DataGrdView.Item(7, DataGrdView.CurrentRow.Index).Value
      TxtSFund.Text = DataGrdView.Item(8, DataGrdView.CurrentRow.Index).Value
      TxtDept.Text = DataGrdView.Item(9, DataGrdView.CurrentRow.Index).Value
      TxtObj.Text = DataGrdView.Item(10, DataGrdView.CurrentRow.Index).Value
      TxtFcn.Text = DataGrdView.Item(11, DataGrdView.CurrentRow.Index).Value
      TxtSfcn.Text = DataGrdView.Item(12, DataGrdView.CurrentRow.Index).Value
      WrkExVal = (DataGrdView.Item(4, DataGrdView.CurrentRow.Index).Value * DataGrdView.Item(5, DataGrdView.CurrentRow.Index).Value) - DataGrdView.Item(3, DataGrdView.CurrentRow.Index).Value
      LblExval.Text = Format(WrkExVal, "fixed")
      LnkGLAcct.Enabled = False
      TxtFund.Enabled = False
      TxtSFund.Enabled = False
      TxtDept.Enabled = False
      TxtObj.Enabled = False
      TxtFcn.Enabled = False
      TxtSfcn.Enabled = False
      BtnAddDtl.Text = "Update Item"
      If WrkExVal = 0 Then
        BtnRemDtl.Enabled = True
      End If
      LblOverExpend.Visible = False
    End If
  End Sub
  Private Sub BtnAddDtl_Click(sender As Object, e As EventArgs) Handles BtnAddDtl.Click
    With myPURCTL
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text))
      If MyUtils.SetDBDate(DtPckRent8.Value) > ._FSCE8 Then
        DtPckRent8.Value = MyUtils.GetDBDate(._FSCE8)
        MsgBox("Posting Date was not within valid range and set to ending date", MsgBoxStyle.Information, "Posting Date was changed")
        Exit Sub
      End If
    End With
    SaveData(MyUtils.CnvSng(LblRecno.Text))
    VerifyPO()
  End Sub
  Private Sub BtnRemDtl_Click(sender As Object, e As EventArgs) Handles BtnRemDtl.Click
    With myPURCTL
      .GetOneRecordP(MyUtils.CnvSng(TxtFscyr.Text))
      If MyUtils.SetDBDate(DtPckRent8.Value) > ._FSCE8 Then
        DtPckRent8.Value = MyUtils.GetDBDate(._FSCE8)
        MsgBox("Posting Date was not within valid range and set to ending date", MsgBoxStyle.Information, "Posting Date was changed")
        Exit Sub
      End If
    End With
    DeleteDtl()
    VerifyPO()
  End Sub
  Private Sub LnkGLAcct_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkGLAcct.LinkClicked
    Dim WrkAcct As String

    WrkAcct = BuildAcct(MyUtils.CnvSng(TxtFund.Text), MyUtils.CnvSng(TxtSFund.Text), MyUtils.CnvSng(TxtDept.Text),
    MyUtils.CnvSng(TxtObj.Text), MyUtils.CnvSng(TxtFcn.Text), MyUtils.CnvSng(TxtSfcn.Text))
    MyFrmListGLAcct = New FrmListGLAcct
    MyFrmListGLAcct.MdiParent = Me.ParentForm
    MyFrmListGLAcct.WrkField = ""
    MyFrmListGLAcct.WrkCode = WrkAcct
    MyFrmListGLAcct.Show()
    Me.Hide()
  End Sub
  Private Sub TxtRqqty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRqqty.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtUnitp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtUnitp.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, True, False)
  End Sub
  Private Sub TxtFund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfund_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSFund.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtDept_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDept.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtObj_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObj.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtFcn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFcn.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub
  Private Sub TxtSfcn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtSfcn.KeyPress
    e.Handled = MyUtils.FilterNumbers(e.KeyChar, False, False)
  End Sub

  Private Sub DataGrdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrdView.CellContentClick

  End Sub

  Private Sub GrpPO_Enter(sender As Object, e As EventArgs) Handles GrpPO.Enter

  End Sub
End Class
