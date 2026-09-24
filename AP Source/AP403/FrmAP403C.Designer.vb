<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAP403C
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
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtCheckNo = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckChk = New System.Windows.Forms.DateTimePicker()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGrdView = New System.Windows.Forms.DataGridView()
        Me.TxtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtPckInvoice = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnRemove = New System.Windows.Forms.Button()
        Me.TxtAmt = New System.Windows.Forms.TextBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.TxtPoNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RbClear = New System.Windows.Forms.Button()
        Me.TxtVendor = New System.Windows.Forms.TextBox()
        Me.LnkVendor = New System.Windows.Forms.LinkLabel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtBank = New System.Windows.Forms.TextBox()
        Me.LblTot = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtAddr1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtAddr2 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtAddr3 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtAddr4 = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(524, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Check Number"
        '
        'TxtCheckNo
        '
        Me.TxtCheckNo.Location = New System.Drawing.Point(527, 25)
        Me.TxtCheckNo.MaxLength = 7
        Me.TxtCheckNo.Name = "TxtCheckNo"
        Me.TxtCheckNo.Size = New System.Drawing.Size(75, 20)
        Me.TxtCheckNo.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(426, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Check Date"
        '
        'DtPckChk
        '
        Me.DtPckChk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckChk.Location = New System.Drawing.Point(424, 25)
        Me.DtPckChk.Name = "DtPckChk"
        Me.DtPckChk.Size = New System.Drawing.Size(91, 20)
        Me.DtPckChk.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGrdView)
        Me.GroupBox1.Controls.Add(Me.TxtInvoiceNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtPckInvoice)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BtnRemove)
        Me.GroupBox1.Controls.Add(Me.TxtAmt)
        Me.GroupBox1.Controls.Add(Me.TxtDesc)
        Me.GroupBox1.Controls.Add(Me.TxtPoNo)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox1.Location = New System.Drawing.Point(12, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(597, 243)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'DataGrdView
        '
        Me.DataGrdView.AllowUserToAddRows = False
        Me.DataGrdView.AllowUserToDeleteRows = False
        Me.DataGrdView.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrdView.Location = New System.Drawing.Point(6, 60)
        Me.DataGrdView.MultiSelect = False
        Me.DataGrdView.Name = "DataGrdView"
        Me.DataGrdView.ReadOnly = True
        Me.DataGrdView.RowTemplate.Height = 16
        Me.DataGrdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGrdView.Size = New System.Drawing.Size(584, 152)
        Me.DataGrdView.TabIndex = 323
        '
        'TxtInvoiceNo
        '
        Me.TxtInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtInvoiceNo.Location = New System.Drawing.Point(280, 33)
        Me.TxtInvoiceNo.MaxLength = 30
        Me.TxtInvoiceNo.Name = "TxtInvoiceNo"
        Me.TxtInvoiceNo.Size = New System.Drawing.Size(146, 21)
        Me.TxtInvoiceNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(281, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 322
        Me.Label2.Text = "Invoice No"
        '
        'DtPckInvoice
        '
        Me.DtPckInvoice.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckInvoice.Location = New System.Drawing.Point(85, 33)
        Me.DtPckInvoice.Name = "DtPckInvoice"
        Me.DtPckInvoice.Size = New System.Drawing.Size(91, 21)
        Me.DtPckInvoice.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(87, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 320
        Me.Label1.Text = "Invoice Date"
        '
        'BtnRemove
        '
        Me.BtnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.Color.Black
        Me.BtnRemove.Location = New System.Drawing.Point(6, 218)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(79, 19)
        Me.BtnRemove.TabIndex = 5
        Me.BtnRemove.Text = "Remove Item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'TxtAmt
        '
        Me.TxtAmt.Location = New System.Drawing.Point(182, 33)
        Me.TxtAmt.MaxLength = 14
        Me.TxtAmt.Name = "TxtAmt"
        Me.TxtAmt.Size = New System.Drawing.Size(92, 21)
        Me.TxtAmt.TabIndex = 2
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(432, 33)
        Me.TxtDesc.MaxLength = 20
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(159, 21)
        Me.TxtDesc.TabIndex = 4
        '
        'TxtPoNo
        '
        Me.TxtPoNo.Location = New System.Drawing.Point(6, 33)
        Me.TxtPoNo.MaxLength = 7
        Me.TxtPoNo.Name = "TxtPoNo"
        Me.TxtPoNo.Size = New System.Drawing.Size(73, 21)
        Me.TxtPoNo.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(213, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 315
        Me.Label8.Text = "Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(431, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 313
        Me.Label7.Text = "Description "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 311
        Me.Label6.Text = "PO Number"
        '
        'RbClear
        '
        Me.RbClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbClear.ForeColor = System.Drawing.Color.Black
        Me.RbClear.Location = New System.Drawing.Point(12, 429)
        Me.RbClear.Name = "RbClear"
        Me.RbClear.Size = New System.Drawing.Size(79, 34)
        Me.RbClear.TabIndex = 4
        Me.RbClear.Text = "Clear Form"
        Me.RbClear.UseVisualStyleBackColor = True
        '
        'TxtVendor
        '
        Me.TxtVendor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtVendor.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendor.Location = New System.Drawing.Point(114, 64)
        Me.TxtVendor.MaxLength = 5
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(48, 22)
        Me.TxtVendor.TabIndex = 4
        '
        'LnkVendor
        '
        Me.LnkVendor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkVendor.ForeColor = System.Drawing.Color.Maroon
        Me.LnkVendor.Location = New System.Drawing.Point(21, 64)
        Me.LnkVendor.Name = "LnkVendor"
        Me.LnkVendor.Size = New System.Drawing.Size(52, 17)
        Me.LnkVendor.TabIndex = 3
        Me.LnkVendor.TabStop = True
        Me.LnkVendor.Text = "Vendor #"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(21, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 18)
        Me.Label17.TabIndex = 323
        Me.Label17.Text = "Bank Account"
        '
        'TxtBank
        '
        Me.TxtBank.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBank.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBank.Location = New System.Drawing.Point(114, 23)
        Me.TxtBank.MaxLength = 5
        Me.TxtBank.Name = "TxtBank"
        Me.TxtBank.Size = New System.Drawing.Size(47, 22)
        Me.TxtBank.TabIndex = 0
        '
        'LblTot
        '
        Me.LblTot.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblTot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTot.ForeColor = System.Drawing.Color.Black
        Me.LblTot.Location = New System.Drawing.Point(196, 437)
        Me.LblTot.Name = "LblTot"
        Me.LblTot.Size = New System.Drawing.Size(90, 20)
        Me.LblTot.TabIndex = 325
        Me.LblTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(157, 440)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 324
        Me.Label13.Text = "Total"
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(275, 64)
        Me.TxtName.MaxLength = 40
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(327, 22)
        Me.TxtName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(182, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 18)
        Me.Label3.TabIndex = 327
        Me.Label3.Text = "Name"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(182, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 18)
        Me.Label9.TabIndex = 329
        Me.Label9.Text = "Address Line 1"
        '
        'TxtAddr1
        '
        Me.TxtAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddr1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddr1.Location = New System.Drawing.Point(275, 86)
        Me.TxtAddr1.MaxLength = 40
        Me.TxtAddr1.Name = "TxtAddr1"
        Me.TxtAddr1.Size = New System.Drawing.Size(327, 22)
        Me.TxtAddr1.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(182, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 18)
        Me.Label10.TabIndex = 331
        Me.Label10.Text = "Address Line 2"
        '
        'TxtAddr2
        '
        Me.TxtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddr2.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddr2.Location = New System.Drawing.Point(275, 108)
        Me.TxtAddr2.MaxLength = 40
        Me.TxtAddr2.Name = "TxtAddr2"
        Me.TxtAddr2.Size = New System.Drawing.Size(327, 22)
        Me.TxtAddr2.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(182, 134)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 18)
        Me.Label11.TabIndex = 333
        Me.Label11.Text = "Address Line 3"
        '
        'TxtAddr3
        '
        Me.TxtAddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddr3.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddr3.Location = New System.Drawing.Point(275, 130)
        Me.TxtAddr3.MaxLength = 40
        Me.TxtAddr3.Name = "TxtAddr3"
        Me.TxtAddr3.Size = New System.Drawing.Size(327, 22)
        Me.TxtAddr3.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(182, 152)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 18)
        Me.Label12.TabIndex = 331
        Me.Label12.Text = "Address Line 4"
        '
        'TxtAddr4
        '
        Me.TxtAddr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAddr4.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddr4.Location = New System.Drawing.Point(275, 152)
        Me.TxtAddr4.MaxLength = 40
        Me.TxtAddr4.Name = "TxtAddr4"
        Me.TxtAddr4.Size = New System.Drawing.Size(327, 22)
        Me.TxtAddr4.TabIndex = 9
        '
        'FrmAP403C
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 466)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtAddr4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtAddr3)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtAddr2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtAddr1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LblTot)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtBank)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtVendor)
        Me.Controls.Add(Me.LnkVendor)
        Me.Controls.Add(Me.RbClear)
        Me.Controls.Add(Me.DtPckChk)
        Me.Controls.Add(Me.TxtCheckNo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAP403C"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manual Check Entry (Data will NOT be saved)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGrdView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents TxtCheckNo As System.Windows.Forms.TextBox
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents DtPckChk As System.Windows.Forms.DateTimePicker
		Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
		Friend WithEvents TxtAmt As System.Windows.Forms.TextBox
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents TxtPoNo As System.Windows.Forms.TextBox
		Friend WithEvents BtnRemove As System.Windows.Forms.Button
		Friend WithEvents RbClear As System.Windows.Forms.Button
	Friend WithEvents TxtVendor As System.Windows.Forms.TextBox
	Friend WithEvents LnkVendor As System.Windows.Forms.LinkLabel
 Friend WithEvents Label17 As System.Windows.Forms.Label
 Friend WithEvents TxtBank As System.Windows.Forms.TextBox
 Friend WithEvents DtPckInvoice As System.Windows.Forms.DateTimePicker
 Friend WithEvents Label1 As System.Windows.Forms.Label
 Friend WithEvents TxtInvoiceNo As System.Windows.Forms.TextBox
 Friend WithEvents Label2 As System.Windows.Forms.Label
 Friend WithEvents LblTot As System.Windows.Forms.Label
 Friend WithEvents Label13 As System.Windows.Forms.Label
 Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents TxtName As System.Windows.Forms.TextBox
 Friend WithEvents Label10 As System.Windows.Forms.Label
 Friend WithEvents TxtAddr2 As System.Windows.Forms.TextBox
 Friend WithEvents Label9 As System.Windows.Forms.Label
 Friend WithEvents TxtAddr1 As System.Windows.Forms.TextBox
 Friend WithEvents Label12 As System.Windows.Forms.Label
 Friend WithEvents TxtAddr4 As System.Windows.Forms.TextBox
 Friend WithEvents Label11 As System.Windows.Forms.Label
 Friend WithEvents TxtAddr3 As System.Windows.Forms.TextBox
 Friend WithEvents DataGrdView As System.Windows.Forms.DataGridView
End Class
