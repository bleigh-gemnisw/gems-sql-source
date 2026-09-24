<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP01LOR2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LblYear = New System.Windows.Forms.Label()
        Me.LblListNo = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPrice = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GrpLease = New System.Windows.Forms.GroupBox()
        Me.RbTypeUnknown = New System.Windows.Forms.RadioButton()
        Me.RbTypeConditional = New System.Windows.Forms.RadioButton()
        Me.RbTypeCapital = New System.Windows.Forms.RadioButton()
        Me.RbTypeOperating = New System.Windows.Forms.RadioButton()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.TxtAddr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPhyLoc = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChkMfg = New System.Windows.Forms.CheckBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.DtPckAcq = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtTran = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtPckPur = New System.Windows.Forms.DateTimePicker()
        Me.TxtPurFrm = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkPurch = New System.Windows.Forms.CheckBox()
        Me.TxtTerm = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtRent = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtCosts = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ChkNewMfg = New System.Windows.Forms.CheckBox()
        Me.RbLessor = New System.Windows.Forms.RadioButton()
        Me.RbLessee = New System.Windows.Forms.RadioButton()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpLease.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblYear
        '
        Me.LblYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblYear.Location = New System.Drawing.Point(191, 8)
        Me.LblYear.Name = "LblYear"
        Me.LblYear.Size = New System.Drawing.Size(33, 18)
        Me.LblYear.TabIndex = 211
        Me.LblYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblListNo
        '
        Me.LblListNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblListNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblListNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblListNo.Location = New System.Drawing.Point(69, 8)
        Me.LblListNo.Name = "LblListNo"
        Me.LblListNo.Size = New System.Drawing.Size(69, 18)
        Me.LblListNo.TabIndex = 210
        Me.LblListNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(12, 9)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 17)
        Me.Label30.TabIndex = 213
        Me.Label30.Text = "List No"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(154, 9)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(35, 17)
        Me.Label29.TabIndex = 212
        Me.Label29.Text = "Year"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 215
        Me.Label1.Text = "Name of Lessor"
        '
        'TxtPrice
        '
        Me.TxtPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrice.Location = New System.Drawing.Point(116, 200)
        Me.TxtPrice.MaxLength = 9
        Me.TxtPrice.Name = "TxtPrice"
        Me.TxtPrice.Size = New System.Drawing.Size(73, 20)
        Me.TxtPrice.TabIndex = 6
        Me.TxtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 13)
        Me.Label9.TabIndex = 231
        Me.Label9.Text = "Current List Price"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GrpLease
        '
        Me.GrpLease.Controls.Add(Me.RbTypeUnknown)
        Me.GrpLease.Controls.Add(Me.RbTypeConditional)
        Me.GrpLease.Controls.Add(Me.RbTypeCapital)
        Me.GrpLease.Controls.Add(Me.RbTypeOperating)
        Me.GrpLease.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpLease.Location = New System.Drawing.Point(15, 343)
        Me.GrpLease.Name = "GrpLease"
        Me.GrpLease.Size = New System.Drawing.Size(440, 42)
        Me.GrpLease.TabIndex = 7
        Me.GrpLease.TabStop = False
        Me.GrpLease.Text = "Type of Lease"
        '
        'RbTypeUnknown
        '
        Me.RbTypeUnknown.AutoSize = True
        Me.RbTypeUnknown.Checked = True
        Me.RbTypeUnknown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTypeUnknown.Location = New System.Drawing.Point(341, 19)
        Me.RbTypeUnknown.Name = "RbTypeUnknown"
        Me.RbTypeUnknown.Size = New System.Drawing.Size(71, 17)
        Me.RbTypeUnknown.TabIndex = 5
        Me.RbTypeUnknown.TabStop = True
        Me.RbTypeUnknown.Text = "Unknown"
        Me.RbTypeUnknown.UseVisualStyleBackColor = True
        '
        'RbTypeConditional
        '
        Me.RbTypeConditional.AutoSize = True
        Me.RbTypeConditional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTypeConditional.Location = New System.Drawing.Point(210, 19)
        Me.RbTypeConditional.Name = "RbTypeConditional"
        Me.RbTypeConditional.Size = New System.Drawing.Size(101, 17)
        Me.RbTypeConditional.TabIndex = 2
        Me.RbTypeConditional.Text = "Conditional Sale"
        Me.RbTypeConditional.UseVisualStyleBackColor = True
        '
        'RbTypeCapital
        '
        Me.RbTypeCapital.AutoSize = True
        Me.RbTypeCapital.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTypeCapital.Location = New System.Drawing.Point(117, 19)
        Me.RbTypeCapital.Name = "RbTypeCapital"
        Me.RbTypeCapital.Size = New System.Drawing.Size(57, 17)
        Me.RbTypeCapital.TabIndex = 1
        Me.RbTypeCapital.Text = "Capital"
        Me.RbTypeCapital.UseVisualStyleBackColor = True
        '
        'RbTypeOperating
        '
        Me.RbTypeOperating.AutoSize = True
        Me.RbTypeOperating.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTypeOperating.Location = New System.Drawing.Point(11, 17)
        Me.RbTypeOperating.Name = "RbTypeOperating"
        Me.RbTypeOperating.Size = New System.Drawing.Size(71, 17)
        Me.RbTypeOperating.TabIndex = 0
        Me.RbTypeOperating.Text = "Operating"
        Me.RbTypeOperating.UseVisualStyleBackColor = True
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(115, 43)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(228, 20)
        Me.TxtName.TabIndex = 0
        '
        'TxtAddr
        '
        Me.TxtAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddr.Location = New System.Drawing.Point(115, 69)
        Me.TxtAddr.MaxLength = 35
        Me.TxtAddr.Name = "TxtAddr"
        Me.TxtAddr.Size = New System.Drawing.Size(228, 20)
        Me.TxtAddr.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Lessor Address"
        '
        'TxtPhyLoc
        '
        Me.TxtPhyLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPhyLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPhyLoc.Location = New System.Drawing.Point(115, 95)
        Me.TxtPhyLoc.MaxLength = 35
        Me.TxtPhyLoc.Name = "TxtPhyLoc"
        Me.TxtPhyLoc.Size = New System.Drawing.Size(228, 20)
        Me.TxtPhyLoc.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 237
        Me.Label4.Text = "Physical Location"
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesc.Location = New System.Drawing.Point(115, 121)
        Me.TxtDesc.MaxLength = 35
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(228, 20)
        Me.TxtDesc.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 13)
        Me.Label6.TabIndex = 239
        Me.Label6.Text = "Equip. Description"
        '
        'ChkMfg
        '
        Me.ChkMfg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkMfg.Location = New System.Drawing.Point(15, 147)
        Me.ChkMfg.Name = "ChkMfg"
        Me.ChkMfg.Size = New System.Drawing.Size(196, 24)
        Me.ChkMfg.TabIndex = 4
        Me.ChkMfg.Text = "Equipment self manufactured?"
        Me.ChkMfg.UseVisualStyleBackColor = True
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(12, 174)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(93, 20)
        Me.Label51.TabIndex = 243
        Me.Label51.Text = "Acquisition Date"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtPckAcq
        '
        Me.DtPckAcq.Checked = False
        Me.DtPckAcq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckAcq.Location = New System.Drawing.Point(115, 174)
        Me.DtPckAcq.Name = "DtPckAcq"
        Me.DtPckAcq.ShowCheckBox = True
        Me.DtPckAcq.Size = New System.Drawing.Size(109, 20)
        Me.DtPckAcq.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtTran)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DtPckPur)
        Me.GroupBox1.Controls.Add(Me.TxtPurFrm)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ChkPurch)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(294, 111)
        Me.GroupBox1.TabIndex = 247
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lease Purchase "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 252
        Me.Label7.Text = "Details"
        '
        'TxtTran
        '
        Me.TxtTran.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTran.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTran.Location = New System.Drawing.Point(52, 85)
        Me.TxtTran.MaxLength = 35
        Me.TxtTran.Name = "TxtTran"
        Me.TxtTran.Size = New System.Drawing.Size(228, 20)
        Me.TxtTran.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 20)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtPckPur
        '
        Me.DtPckPur.Checked = False
        Me.DtPckPur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPckPur.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckPur.Location = New System.Drawing.Point(52, 59)
        Me.DtPckPur.Name = "DtPckPur"
        Me.DtPckPur.ShowCheckBox = True
        Me.DtPckPur.Size = New System.Drawing.Size(103, 20)
        Me.DtPckPur.TabIndex = 2
        '
        'TxtPurFrm
        '
        Me.TxtPurFrm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPurFrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurFrm.Location = New System.Drawing.Point(52, 36)
        Me.TxtPurFrm.MaxLength = 35
        Me.TxtPurFrm.Name = "TxtPurFrm"
        Me.TxtPurFrm.Size = New System.Drawing.Size(228, 20)
        Me.TxtPurFrm.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 247
        Me.Label2.Text = "Who"
        '
        'ChkPurch
        '
        Me.ChkPurch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkPurch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPurch.Location = New System.Drawing.Point(6, 12)
        Me.ChkPurch.Name = "ChkPurch"
        Me.ChkPurch.Size = New System.Drawing.Size(254, 24)
        Me.ChkPurch.TabIndex = 0
        Me.ChkPurch.Text = "Ever been purchased, assumed or assigned?"
        Me.ChkPurch.UseVisualStyleBackColor = True
        '
        'TxtTerm
        '
        Me.TxtTerm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTerm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTerm.Location = New System.Drawing.Point(115, 398)
        Me.TxtTerm.MaxLength = 35
        Me.TxtTerm.Name = "TxtTerm"
        Me.TxtTerm.Size = New System.Drawing.Size(228, 20)
        Me.TxtTerm.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Lease Term"
        '
        'TxtRent
        '
        Me.TxtRent.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtRent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRent.Location = New System.Drawing.Point(114, 421)
        Me.TxtRent.MaxLength = 9
        Me.TxtRent.Name = "TxtRent"
        Me.TxtRent.Size = New System.Drawing.Size(73, 20)
        Me.TxtRent.TabIndex = 9
        Me.TxtRent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 426)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 251
        Me.Label10.Text = "Monthly Rent"
        '
        'TxtCosts
        '
        Me.TxtCosts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCosts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCosts.Location = New System.Drawing.Point(113, 445)
        Me.TxtCosts.MaxLength = 9
        Me.TxtCosts.Name = "TxtCosts"
        Me.TxtCosts.Size = New System.Drawing.Size(73, 20)
        Me.TxtCosts.TabIndex = 10
        Me.TxtCosts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 450)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 253
        Me.Label11.Text = "Monthly Costs"
        '
        'ChkNewMfg
        '
        Me.ChkNewMfg.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkNewMfg.Location = New System.Drawing.Point(7, 471)
        Me.ChkNewMfg.Name = "ChkNewMfg"
        Me.ChkNewMfg.Size = New System.Drawing.Size(131, 24)
        Me.ChkNewMfg.TabIndex = 11
        Me.ChkNewMfg.Text = "New Mfg Exempt?"
        Me.ChkNewMfg.UseVisualStyleBackColor = True
        '
        'RbLessor
        '
        Me.RbLessor.AutoSize = True
        Me.RbLessor.Checked = True
        Me.RbLessor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLessor.Location = New System.Drawing.Point(191, 474)
        Me.RbLessor.Name = "RbLessor"
        Me.RbLessor.Size = New System.Drawing.Size(56, 17)
        Me.RbLessor.TabIndex = 12
        Me.RbLessor.TabStop = True
        Me.RbLessor.Text = "Lessor"
        Me.RbLessor.UseVisualStyleBackColor = True
        '
        'RbLessee
        '
        Me.RbLessee.AutoSize = True
        Me.RbLessee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbLessee.Location = New System.Drawing.Point(270, 474)
        Me.RbLessee.Name = "RbLessee"
        Me.RbLessee.Size = New System.Drawing.Size(59, 17)
        Me.RbLessee.TabIndex = 13
        Me.RbLessee.Text = "Lessee"
        Me.RbLessee.UseVisualStyleBackColor = True
        '
        'FrmTAP01LOR2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 506)
        Me.ControlBox = False
        Me.Controls.Add(Me.RbLessee)
        Me.Controls.Add(Me.RbLessor)
        Me.Controls.Add(Me.ChkNewMfg)
        Me.Controls.Add(Me.TxtCosts)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtRent)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtTerm)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.DtPckAcq)
        Me.Controls.Add(Me.ChkMfg)
        Me.Controls.Add(Me.TxtDesc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtPhyLoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtAddr)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.GrpLease)
        Me.Controls.Add(Me.TxtPrice)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblYear)
        Me.Controls.Add(Me.LblListNo)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label29)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTAP01LOR2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Maintain Lessor"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpLease.ResumeLayout(False)
        Me.GrpLease.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblYear As System.Windows.Forms.Label
    Friend WithEvents LblListNo As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpLease As System.Windows.Forms.GroupBox
    Friend WithEvents RbTypeConditional As System.Windows.Forms.RadioButton
    Friend WithEvents RbTypeCapital As System.Windows.Forms.RadioButton
    Friend WithEvents RbTypeOperating As System.Windows.Forms.RadioButton
    Friend WithEvents TxtPhyLoc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAddr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents RbTypeUnknown As System.Windows.Forms.RadioButton
    Friend WithEvents ChkMfg As System.Windows.Forms.CheckBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents DtPckAcq As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtPckPur As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtPurFrm As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkPurch As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtTran As System.Windows.Forms.TextBox
    Friend WithEvents ChkNewMfg As System.Windows.Forms.CheckBox
    Friend WithEvents TxtCosts As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtRent As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTerm As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RbLessee As System.Windows.Forms.RadioButton
    Friend WithEvents RbLessor As System.Windows.Forms.RadioButton
End Class






