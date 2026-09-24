<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTXA12C
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
Me.components = New System.ComponentModel.Container
Me.Label2 = New System.Windows.Forms.Label
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.Label4 = New System.Windows.Forms.Label
Me.BtnTransfer = New System.Windows.Forms.Button
Me.BtnReset = New System.Windows.Forms.Button
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
Me.Label5 = New System.Windows.Forms.Label
Me.Label10 = New System.Windows.Forms.Label
Me.GroupBox1 = New System.Windows.Forms.GroupBox
Me.Label8 = New System.Windows.Forms.Label
Me.TxtTransfer = New System.Windows.Forms.TextBox
Me.LblFromTax = New System.Windows.Forms.Label
Me.LblFromHist = New System.Windows.Forms.Label
Me.Label13 = New System.Windows.Forms.Label
Me.Label12 = New System.Windows.Forms.Label
Me.Label6 = New System.Windows.Forms.Label
Me.LblFromBeforeBal = New System.Windows.Forms.Label
Me.LblFromAfterBal = New System.Windows.Forms.Label
Me.label24 = New System.Windows.Forms.Label
Me.LblFromDesc = New System.Windows.Forms.Label
Me.LblFromName = New System.Windows.Forms.Label
Me.TxtFromType = New System.Windows.Forms.TextBox
Me.TxtFromYear = New System.Windows.Forms.TextBox
Me.Label3 = New System.Windows.Forms.Label
Me.TxtFromList = New System.Windows.Forms.TextBox
Me.GroupBox2 = New System.Windows.Forms.GroupBox
Me.LblToHist = New System.Windows.Forms.Label
Me.Label14 = New System.Windows.Forms.Label
Me.Label16 = New System.Windows.Forms.Label
Me.Label17 = New System.Windows.Forms.Label
Me.LblToBeforeBal = New System.Windows.Forms.Label
Me.LblToAfterBal = New System.Windows.Forms.Label
Me.Label9 = New System.Windows.Forms.Label
Me.LblToTax = New System.Windows.Forms.Label
Me.LblToDesc = New System.Windows.Forms.Label
Me.LblToName = New System.Windows.Forms.Label
Me.TxtToType = New System.Windows.Forms.TextBox
Me.TxtToYear = New System.Windows.Forms.TextBox
Me.Label1 = New System.Windows.Forms.Label
Me.TxtToList = New System.Windows.Forms.TextBox
Me.Label15 = New System.Windows.Forms.Label
Me.LblTransferInt = New System.Windows.Forms.Label
Me.LblTransferTax = New System.Windows.Forms.Label
Me.Label7 = New System.Windows.Forms.Label
Me.LblTransferTot = New System.Windows.Forms.Label
Me.Label11 = New System.Windows.Forms.Label
Me.LnkFee = New System.Windows.Forms.LinkLabel
Me.label26 = New System.Windows.Forms.Label
Me.LblTransferFee = New System.Windows.Forms.Label
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
Me.GroupBox2.SuspendLayout()
Me.SuspendLayout()
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(202, 41)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(78, 16)
Me.Label2.TabIndex = 312
Me.Label2.Text = "Posting Date*"
'
'DtPckPost
'
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPost.Location = New System.Drawing.Point(286, 37)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(84, 20)
Me.DtPckPost.TabIndex = 0
'
'Label4
'
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(272, 148)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(35, 20)
Me.Label4.TabIndex = 328
Me.Label4.Text = "==>"
Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'BtnTransfer
'
Me.BtnTransfer.Location = New System.Drawing.Point(236, 401)
Me.BtnTransfer.Name = "BtnTransfer"
Me.BtnTransfer.Size = New System.Drawing.Size(90, 42)
Me.BtnTransfer.TabIndex = 3
Me.BtnTransfer.Text = "Transfer"
Me.BtnTransfer.UseVisualStyleBackColor = True
'
'BtnReset
'
Me.BtnReset.Location = New System.Drawing.Point(471, 401)
Me.BtnReset.Name = "BtnReset"
Me.BtnReset.Size = New System.Drawing.Size(90, 42)
Me.BtnReset.TabIndex = 4
Me.BtnReset.Text = "Reset"
Me.BtnReset.UseVisualStyleBackColor = True
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label5.Location = New System.Drawing.Point(6, 461)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(354, 13)
Me.Label5.TabIndex = 344
Me.Label5.Text = "*Accounts with activity after the posting date are not allowed"
'
'Label10
'
Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label10.Location = New System.Drawing.Point(194, -2)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(189, 27)
Me.Label10.TabIndex = 347
Me.Label10.Text = "Single Transfer"
Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.Label8)
Me.GroupBox1.Controls.Add(Me.TxtTransfer)
Me.GroupBox1.Controls.Add(Me.LblFromTax)
Me.GroupBox1.Controls.Add(Me.LblFromHist)
Me.GroupBox1.Controls.Add(Me.Label13)
Me.GroupBox1.Controls.Add(Me.Label12)
Me.GroupBox1.Controls.Add(Me.Label6)
Me.GroupBox1.Controls.Add(Me.LblFromBeforeBal)
Me.GroupBox1.Controls.Add(Me.LblFromAfterBal)
Me.GroupBox1.Controls.Add(Me.label24)
Me.GroupBox1.Controls.Add(Me.LblFromDesc)
Me.GroupBox1.Controls.Add(Me.LblFromName)
Me.GroupBox1.Controls.Add(Me.TxtFromType)
Me.GroupBox1.Controls.Add(Me.TxtFromYear)
Me.GroupBox1.Controls.Add(Me.Label3)
Me.GroupBox1.Controls.Add(Me.TxtFromList)
Me.GroupBox1.Location = New System.Drawing.Point(12, 74)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Size = New System.Drawing.Size(260, 199)
Me.GroupBox1.TabIndex = 1
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "From:"
'
'Label8
'
Me.Label8.BackColor = System.Drawing.SystemColors.Control
Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label8.Location = New System.Drawing.Point(7, 173)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(69, 20)
Me.Label8.TabIndex = 390
Me.Label8.Text = "Transfer Amt"
'
'TxtTransfer
'
Me.TxtTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtTransfer.Location = New System.Drawing.Point(82, 173)
Me.TxtTransfer.MaxLength = 11
Me.TxtTransfer.Name = "TxtTransfer"
Me.TxtTransfer.Size = New System.Drawing.Size(72, 20)
Me.TxtTransfer.TabIndex = 3
Me.TxtTransfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'LblFromTax
'
Me.LblFromTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblFromTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblFromTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFromTax.Location = New System.Drawing.Point(166, 33)
Me.LblFromTax.Name = "LblFromTax"
Me.LblFromTax.Size = New System.Drawing.Size(72, 20)
Me.LblFromTax.TabIndex = 388
Me.LblFromTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblFromHist
'
Me.LblFromHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFromHist.Location = New System.Drawing.Point(4, 157)
Me.LblFromHist.Name = "LblFromHist"
Me.LblFromHist.Size = New System.Drawing.Size(248, 19)
Me.LblFromHist.TabIndex = 387
Me.LblFromHist.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label13
'
Me.Label13.BackColor = System.Drawing.SystemColors.Control
Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label13.Location = New System.Drawing.Point(184, 112)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(48, 16)
Me.Label13.TabIndex = 386
Me.Label13.Text = "After"
'
'Label12
'
Me.Label12.BackColor = System.Drawing.SystemColors.Control
Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label12.Location = New System.Drawing.Point(103, 114)
Me.Label12.Name = "Label12"
Me.Label12.Size = New System.Drawing.Size(48, 16)
Me.Label12.TabIndex = 385
Me.Label12.Text = "Before"
'
'Label6
'
Me.Label6.BackColor = System.Drawing.SystemColors.Control
Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label6.Location = New System.Drawing.Point(28, 134)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(48, 16)
Me.Label6.TabIndex = 383
Me.Label6.Text = "Balance"
'
'LblFromBeforeBal
'
Me.LblFromBeforeBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblFromBeforeBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblFromBeforeBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFromBeforeBal.Location = New System.Drawing.Point(82, 130)
Me.LblFromBeforeBal.Name = "LblFromBeforeBal"
Me.LblFromBeforeBal.Size = New System.Drawing.Size(72, 20)
Me.LblFromBeforeBal.TabIndex = 384
Me.LblFromBeforeBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblFromAfterBal
'
Me.LblFromAfterBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblFromAfterBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblFromAfterBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFromAfterBal.Location = New System.Drawing.Point(160, 130)
Me.LblFromAfterBal.Name = "LblFromAfterBal"
Me.LblFromAfterBal.Size = New System.Drawing.Size(72, 20)
Me.LblFromAfterBal.TabIndex = 382
Me.LblFromAfterBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'label24
'
Me.label24.BackColor = System.Drawing.SystemColors.Control
Me.label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label24.Location = New System.Drawing.Point(190, 16)
Me.label24.Name = "label24"
Me.label24.Size = New System.Drawing.Size(48, 16)
Me.label24.TabIndex = 350
Me.label24.Text = "Tax"
'
'LblFromDesc
'
Me.LblFromDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFromDesc.Location = New System.Drawing.Point(6, 75)
Me.LblFromDesc.Name = "LblFromDesc"
Me.LblFromDesc.Size = New System.Drawing.Size(248, 19)
Me.LblFromDesc.TabIndex = 344
'
'LblFromName
'
Me.LblFromName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblFromName.Location = New System.Drawing.Point(6, 56)
Me.LblFromName.Name = "LblFromName"
Me.LblFromName.Size = New System.Drawing.Size(248, 19)
Me.LblFromName.TabIndex = 339
'
'TxtFromType
'
Me.TxtFromType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFromType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromType.Location = New System.Drawing.Point(82, 33)
Me.TxtFromType.MaxLength = 1
Me.TxtFromType.Name = "TxtFromType"
Me.TxtFromType.Size = New System.Drawing.Size(16, 20)
Me.TxtFromType.TabIndex = 1
'
'TxtFromYear
'
Me.TxtFromYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromYear.Location = New System.Drawing.Point(98, 33)
Me.TxtFromYear.MaxLength = 4
Me.TxtFromYear.Name = "TxtFromYear"
Me.TxtFromYear.Size = New System.Drawing.Size(36, 20)
Me.TxtFromYear.TabIndex = 2
'
'Label3
'
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(23, 17)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(92, 16)
Me.Label3.TabIndex = 338
Me.Label3.Text = "List #/Type/Year"
'
'TxtFromList
'
Me.TxtFromList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFromList.Location = New System.Drawing.Point(26, 33)
Me.TxtFromList.MaxLength = 11
Me.TxtFromList.Name = "TxtFromList"
Me.TxtFromList.Size = New System.Drawing.Size(56, 20)
Me.TxtFromList.TabIndex = 0
'
'GroupBox2
'
Me.GroupBox2.Controls.Add(Me.LblToHist)
Me.GroupBox2.Controls.Add(Me.Label14)
Me.GroupBox2.Controls.Add(Me.Label16)
Me.GroupBox2.Controls.Add(Me.Label17)
Me.GroupBox2.Controls.Add(Me.LblToBeforeBal)
Me.GroupBox2.Controls.Add(Me.LblToAfterBal)
Me.GroupBox2.Controls.Add(Me.Label9)
Me.GroupBox2.Controls.Add(Me.LblToTax)
Me.GroupBox2.Controls.Add(Me.LblToDesc)
Me.GroupBox2.Controls.Add(Me.LblToName)
Me.GroupBox2.Controls.Add(Me.TxtToType)
Me.GroupBox2.Controls.Add(Me.TxtToYear)
Me.GroupBox2.Controls.Add(Me.Label1)
Me.GroupBox2.Controls.Add(Me.TxtToList)
Me.GroupBox2.Location = New System.Drawing.Point(307, 75)
Me.GroupBox2.Name = "GroupBox2"
Me.GroupBox2.Size = New System.Drawing.Size(264, 198)
Me.GroupBox2.TabIndex = 2
Me.GroupBox2.TabStop = False
Me.GroupBox2.Text = "To:"
'
'LblToHist
'
Me.LblToHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblToHist.Location = New System.Drawing.Point(10, 156)
Me.LblToHist.Name = "LblToHist"
Me.LblToHist.Size = New System.Drawing.Size(248, 19)
Me.LblToHist.TabIndex = 392
Me.LblToHist.TextAlign = System.Drawing.ContentAlignment.TopCenter
'
'Label14
'
Me.Label14.BackColor = System.Drawing.SystemColors.Control
Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label14.Location = New System.Drawing.Point(186, 111)
Me.Label14.Name = "Label14"
Me.Label14.Size = New System.Drawing.Size(48, 16)
Me.Label14.TabIndex = 391
Me.Label14.Text = "After"
'
'Label16
'
Me.Label16.BackColor = System.Drawing.SystemColors.Control
Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label16.Location = New System.Drawing.Point(105, 113)
Me.Label16.Name = "Label16"
Me.Label16.Size = New System.Drawing.Size(48, 16)
Me.Label16.TabIndex = 390
Me.Label16.Text = "Before"
'
'Label17
'
Me.Label17.BackColor = System.Drawing.SystemColors.Control
Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label17.Location = New System.Drawing.Point(30, 133)
Me.Label17.Name = "Label17"
Me.Label17.Size = New System.Drawing.Size(48, 16)
Me.Label17.TabIndex = 388
Me.Label17.Text = "Balance"
'
'LblToBeforeBal
'
Me.LblToBeforeBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblToBeforeBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblToBeforeBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblToBeforeBal.Location = New System.Drawing.Point(84, 129)
Me.LblToBeforeBal.Name = "LblToBeforeBal"
Me.LblToBeforeBal.Size = New System.Drawing.Size(72, 20)
Me.LblToBeforeBal.TabIndex = 389
Me.LblToBeforeBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblToAfterBal
'
Me.LblToAfterBal.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblToAfterBal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblToAfterBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblToAfterBal.Location = New System.Drawing.Point(162, 129)
Me.LblToAfterBal.Name = "LblToAfterBal"
Me.LblToAfterBal.Size = New System.Drawing.Size(72, 20)
Me.LblToAfterBal.TabIndex = 387
Me.LblToAfterBal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label9
'
Me.Label9.BackColor = System.Drawing.SystemColors.Control
Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label9.Location = New System.Drawing.Point(198, 15)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(48, 16)
Me.Label9.TabIndex = 382
Me.Label9.Text = "Tax"
'
'LblToTax
'
Me.LblToTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblToTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblToTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblToTax.Location = New System.Drawing.Point(174, 31)
Me.LblToTax.Name = "LblToTax"
Me.LblToTax.Size = New System.Drawing.Size(72, 20)
Me.LblToTax.TabIndex = 381
Me.LblToTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblToDesc
'
Me.LblToDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblToDesc.Location = New System.Drawing.Point(6, 74)
Me.LblToDesc.Name = "LblToDesc"
Me.LblToDesc.Size = New System.Drawing.Size(248, 19)
Me.LblToDesc.TabIndex = 369
'
'LblToName
'
Me.LblToName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblToName.Location = New System.Drawing.Point(6, 55)
Me.LblToName.Name = "LblToName"
Me.LblToName.Size = New System.Drawing.Size(248, 19)
Me.LblToName.TabIndex = 360
'
'TxtToType
'
Me.TxtToType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtToType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToType.Location = New System.Drawing.Point(84, 32)
Me.TxtToType.MaxLength = 1
Me.TxtToType.Name = "TxtToType"
Me.TxtToType.Size = New System.Drawing.Size(16, 20)
Me.TxtToType.TabIndex = 357
'
'TxtToYear
'
Me.TxtToYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToYear.Location = New System.Drawing.Point(100, 32)
Me.TxtToYear.MaxLength = 4
Me.TxtToYear.Name = "TxtToYear"
Me.TxtToYear.Size = New System.Drawing.Size(36, 20)
Me.TxtToYear.TabIndex = 358
'
'Label1
'
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(25, 16)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 16)
Me.Label1.TabIndex = 359
Me.Label1.Text = "List #/Type/Year"
'
'TxtToList
'
Me.TxtToList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtToList.Location = New System.Drawing.Point(28, 32)
Me.TxtToList.MaxLength = 11
Me.TxtToList.Name = "TxtToList"
Me.TxtToList.Size = New System.Drawing.Size(56, 20)
Me.TxtToList.TabIndex = 356
'
'Label15
'
Me.Label15.BackColor = System.Drawing.SystemColors.Control
Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label15.Location = New System.Drawing.Point(200, 328)
Me.Label15.Name = "Label15"
Me.Label15.Size = New System.Drawing.Size(48, 16)
Me.Label15.TabIndex = 377
Me.Label15.Text = "Interest"
'
'LblTransferInt
'
Me.LblTransferInt.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblTransferInt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblTransferInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblTransferInt.Location = New System.Drawing.Point(254, 324)
Me.LblTransferInt.Name = "LblTransferInt"
Me.LblTransferInt.Size = New System.Drawing.Size(72, 20)
Me.LblTransferInt.TabIndex = 378
Me.LblTransferInt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblTransferTax
'
Me.LblTransferTax.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblTransferTax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblTransferTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblTransferTax.Location = New System.Drawing.Point(254, 304)
Me.LblTransferTax.Name = "LblTransferTax"
Me.LblTransferTax.Size = New System.Drawing.Size(72, 20)
Me.LblTransferTax.TabIndex = 374
Me.LblTransferTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label7
'
Me.Label7.BackColor = System.Drawing.SystemColors.Control
Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label7.Location = New System.Drawing.Point(201, 308)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(48, 16)
Me.Label7.TabIndex = 383
Me.Label7.Text = "Tax"
'
'LblTransferTot
'
Me.LblTransferTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblTransferTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblTransferTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblTransferTot.Location = New System.Drawing.Point(254, 368)
Me.LblTransferTot.Name = "LblTransferTot"
Me.LblTransferTot.Size = New System.Drawing.Size(72, 20)
Me.LblTransferTot.TabIndex = 384
Me.LblTransferTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label11
'
Me.Label11.BackColor = System.Drawing.SystemColors.Control
Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label11.Location = New System.Drawing.Point(200, 372)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(48, 16)
Me.Label11.TabIndex = 385
Me.Label11.Text = "Total"
'
'LnkFee
'
Me.LnkFee.AutoSize = True
Me.LnkFee.Location = New System.Drawing.Point(328, 348)
Me.LnkFee.Name = "LnkFee"
Me.LnkFee.Size = New System.Drawing.Size(13, 13)
Me.LnkFee.TabIndex = 388
Me.LnkFee.TabStop = True
Me.LnkFee.Text = "?"
'
'label26
'
Me.label26.BackColor = System.Drawing.SystemColors.Control
Me.label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.label26.Location = New System.Drawing.Point(202, 348)
Me.label26.Name = "label26"
Me.label26.Size = New System.Drawing.Size(46, 16)
Me.label26.TabIndex = 386
Me.label26.Text = "Fee"
'
'LblTransferFee
'
Me.LblTransferFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblTransferFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.LblTransferFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblTransferFee.Location = New System.Drawing.Point(254, 344)
Me.LblTransferFee.Name = "LblTransferFee"
Me.LblTransferFee.Size = New System.Drawing.Size(72, 20)
Me.LblTransferFee.TabIndex = 387
Me.LblTransferFee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'FrmTXA12C
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(583, 486)
Me.ControlBox = False
Me.Controls.Add(Me.LnkFee)
Me.Controls.Add(Me.label26)
Me.Controls.Add(Me.LblTransferFee)
Me.Controls.Add(Me.Label11)
Me.Controls.Add(Me.LblTransferTot)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.Label15)
Me.Controls.Add(Me.LblTransferInt)
Me.Controls.Add(Me.LblTransferTax)
Me.Controls.Add(Me.GroupBox2)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label10)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.BtnReset)
Me.Controls.Add(Me.BtnTransfer)
Me.Controls.Add(Me.Label4)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.DtPckPost)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "FrmTXA12C"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.GroupBox2.ResumeLayout(False)
Me.GroupBox2.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents BtnTransfer As System.Windows.Forms.Button
		Friend WithEvents BtnReset As System.Windows.Forms.Button
		Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
		Friend WithEvents LblFromName As System.Windows.Forms.Label
		Friend WithEvents TxtFromType As System.Windows.Forms.TextBox
		Friend WithEvents TxtFromYear As System.Windows.Forms.TextBox
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents TxtFromList As System.Windows.Forms.TextBox
		Friend WithEvents LblFromDesc As System.Windows.Forms.Label
		Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
		Friend WithEvents LblToName As System.Windows.Forms.Label
		Friend WithEvents TxtToType As System.Windows.Forms.TextBox
		Friend WithEvents TxtToYear As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents TxtToList As System.Windows.Forms.TextBox
		Friend WithEvents LblToDesc As System.Windows.Forms.Label
		Friend WithEvents Label15 As System.Windows.Forms.Label
		Friend WithEvents LblTransferInt As System.Windows.Forms.Label
		Friend WithEvents LblTransferTax As System.Windows.Forms.Label
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents LblToTax As System.Windows.Forms.Label
		Friend WithEvents label24 As System.Windows.Forms.Label
		Friend WithEvents Label14 As System.Windows.Forms.Label
		Friend WithEvents Label16 As System.Windows.Forms.Label
		Friend WithEvents Label17 As System.Windows.Forms.Label
		Friend WithEvents LblToBeforeBal As System.Windows.Forms.Label
		Friend WithEvents LblToAfterBal As System.Windows.Forms.Label
		Friend WithEvents Label13 As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents LblFromBeforeBal As System.Windows.Forms.Label
		Friend WithEvents LblFromAfterBal As System.Windows.Forms.Label
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents Label11 As System.Windows.Forms.Label
		Friend WithEvents LblTransferTot As System.Windows.Forms.Label
		Friend WithEvents LblToHist As System.Windows.Forms.Label
		Friend WithEvents LblFromHist As System.Windows.Forms.Label
	Friend WithEvents LblFromTax As System.Windows.Forms.Label
 Friend WithEvents Label8 As System.Windows.Forms.Label
 Friend WithEvents TxtTransfer As System.Windows.Forms.TextBox
 Friend WithEvents LnkFee As System.Windows.Forms.LinkLabel
 Friend WithEvents label26 As System.Windows.Forms.Label
 Friend WithEvents LblTransferFee As System.Windows.Forms.Label
End Class






