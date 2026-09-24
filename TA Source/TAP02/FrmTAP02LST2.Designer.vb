<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTAP02LST2
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
    Me.TxtPrDesc = New System.Windows.Forms.TextBox()
    Me.TxtPurch = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.TxtIrsCls = New System.Windows.Forms.TextBox()
    Me.DtPckAcq = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.TxtPrMod = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TxtQty = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.DtPckIns = New System.Windows.Forms.DateTimePicker()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.TxtTrans = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.LblAcqCst = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtLease = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.LblGLYear = New System.Windows.Forms.Label()
    Me.LnkLease = New System.Windows.Forms.LinkLabel()
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.LblListNo.Size = New System.Drawing.Size(61, 18)
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
    'TxtPrDesc
    '
    Me.TxtPrDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPrDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPrDesc.Location = New System.Drawing.Point(108, 38)
    Me.TxtPrDesc.MaxLength = 40
    Me.TxtPrDesc.Name = "TxtPrDesc"
    Me.TxtPrDesc.Size = New System.Drawing.Size(351, 20)
    Me.TxtPrDesc.TabIndex = 0
    '
    'TxtPurch
    '
    Me.TxtPurch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPurch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPurch.Location = New System.Drawing.Point(109, 223)
    Me.TxtPurch.MaxLength = 9
    Me.TxtPurch.Name = "TxtPurch"
    Me.TxtPurch.Size = New System.Drawing.Size(81, 20)
    Me.TxtPurch.TabIndex = 7
    Me.TxtPurch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(13, 226)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(79, 13)
    Me.Label9.TabIndex = 231
    Me.Label9.Text = "Purchase Price"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'TxtIrsCls
    '
    Me.TxtIrsCls.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtIrsCls.Location = New System.Drawing.Point(109, 197)
    Me.TxtIrsCls.MaxLength = 4
    Me.TxtIrsCls.Name = "TxtIrsCls"
    Me.TxtIrsCls.Size = New System.Drawing.Size(35, 20)
    Me.TxtIrsCls.TabIndex = 6
    '
    'DtPckAcq
    '
    Me.DtPckAcq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckAcq.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckAcq.Location = New System.Drawing.Point(108, 115)
    Me.DtPckAcq.Name = "DtPckAcq"
    Me.DtPckAcq.Size = New System.Drawing.Size(97, 22)
    Me.DtPckAcq.TabIndex = 3
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(11, 122)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(75, 13)
    Me.Label2.TabIndex = 239
    Me.Label2.Text = "Date Acquired"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 41)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(60, 13)
    Me.Label3.TabIndex = 241
    Me.Label3.Text = "Description"
    '
    'TxtPrMod
    '
    Me.TxtPrMod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPrMod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtPrMod.Location = New System.Drawing.Point(108, 64)
    Me.TxtPrMod.MaxLength = 20
    Me.TxtPrMod.Name = "TxtPrMod"
    Me.TxtPrMod.Size = New System.Drawing.Size(140, 20)
    Me.TxtPrMod.TabIndex = 1
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 67)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(46, 13)
    Me.Label1.TabIndex = 243
    Me.Label1.Text = "Model #"
    '
    'TxtQty
    '
    Me.TxtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtQty.Location = New System.Drawing.Point(108, 89)
    Me.TxtQty.MaxLength = 7
    Me.TxtQty.Name = "TxtQty"
    Me.TxtQty.Size = New System.Drawing.Size(50, 20)
    Me.TxtQty.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(12, 92)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(53, 13)
    Me.Label4.TabIndex = 245
    Me.Label4.Text = "# of items"
    '
    'DtPckIns
    '
    Me.DtPckIns.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DtPckIns.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckIns.Location = New System.Drawing.Point(109, 143)
    Me.DtPckIns.Name = "DtPckIns"
    Me.DtPckIns.Size = New System.Drawing.Size(97, 22)
    Me.DtPckIns.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 150)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 13)
    Me.Label5.TabIndex = 247
    Me.Label5.Text = "Date Installed"
    '
    'TxtTrans
    '
    Me.TxtTrans.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TxtTrans.Location = New System.Drawing.Point(108, 249)
    Me.TxtTrans.MaxLength = 9
    Me.TxtTrans.Name = "TxtTrans"
    Me.TxtTrans.Size = New System.Drawing.Size(82, 20)
    Me.TxtTrans.TabIndex = 8
    Me.TxtTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 252)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(90, 13)
    Me.Label6.TabIndex = 249
    Me.Label6.Text = "Trans/Install Cost"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(14, 200)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(89, 13)
    Me.Label7.TabIndex = 250
    Me.Label7.Text = "IRS Classification"
    '
    'LblAcqCst
    '
    Me.LblAcqCst.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblAcqCst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblAcqCst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblAcqCst.Location = New System.Drawing.Point(108, 273)
    Me.LblAcqCst.Name = "LblAcqCst"
    Me.LblAcqCst.Size = New System.Drawing.Size(82, 18)
    Me.LblAcqCst.TabIndex = 251
    Me.LblAcqCst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(13, 273)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(60, 18)
    Me.Label10.TabIndex = 252
    Me.Label10.Text = "Total Cost"
    '
    'TxtLease
    '
    Me.TxtLease.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLease.Location = New System.Drawing.Point(110, 171)
    Me.TxtLease.MaxLength = 20
    Me.TxtLease.Name = "TxtLease"
    Me.TxtLease.Size = New System.Drawing.Size(138, 20)
    Me.TxtLease.TabIndex = 5
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(351, 273)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(60, 18)
    Me.Label12.TabIndex = 255
    Me.Label12.Text = "G/L Year"
    '
    'LblGLYear
    '
    Me.LblGLYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
    Me.LblGLYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblGLYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblGLYear.Location = New System.Drawing.Point(426, 273)
    Me.LblGLYear.Name = "LblGLYear"
    Me.LblGLYear.Size = New System.Drawing.Size(33, 18)
    Me.LblGLYear.TabIndex = 256
    Me.LblGLYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LnkLease
    '
    Me.LnkLease.Location = New System.Drawing.Point(13, 174)
    Me.LnkLease.Name = "LnkLease"
    Me.LnkLease.Size = New System.Drawing.Size(80, 16)
    Me.LnkLease.TabIndex = 257
    Me.LnkLease.TabStop = True
    Me.LnkLease.Text = "Lease ID"
    '
    'FrmTAP02LST2
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(475, 297)
    Me.ControlBox = False
    Me.Controls.Add(Me.LnkLease)
    Me.Controls.Add(Me.LblGLYear)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtLease)
    Me.Controls.Add(Me.LblAcqCst)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.TxtTrans)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.DtPckIns)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.TxtQty)
    Me.Controls.Add(Me.TxtPrMod)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtPrDesc)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.DtPckAcq)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.TxtIrsCls)
    Me.Controls.Add(Me.TxtPurch)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.LblYear)
    Me.Controls.Add(Me.LblListNo)
    Me.Controls.Add(Me.Label30)
    Me.Controls.Add(Me.Label29)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTAP02LST2"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Maintain Assets"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
		Friend WithEvents LblYear As System.Windows.Forms.Label
		Friend WithEvents LblListNo As System.Windows.Forms.Label
		Friend WithEvents Label30 As System.Windows.Forms.Label
		Friend WithEvents Label29 As System.Windows.Forms.Label
		Friend WithEvents TxtPrDesc As System.Windows.Forms.TextBox
		Friend WithEvents TxtPurch As System.Windows.Forms.TextBox
		Friend WithEvents Label9 As System.Windows.Forms.Label
		Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
		Friend WithEvents TxtIrsCls As System.Windows.Forms.TextBox
		Friend WithEvents DtPckAcq As System.Windows.Forms.DateTimePicker
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
		Friend WithEvents TxtPrMod As System.Windows.Forms.TextBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents TxtQty As System.Windows.Forms.TextBox
		Friend WithEvents TxtTrans As System.Windows.Forms.TextBox
		Friend WithEvents Label6 As System.Windows.Forms.Label
		Friend WithEvents DtPckIns As System.Windows.Forms.DateTimePicker
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents Label7 As System.Windows.Forms.Label
		Friend WithEvents LblAcqCst As System.Windows.Forms.Label
		Friend WithEvents Label10 As System.Windows.Forms.Label
		Friend WithEvents TxtLease As System.Windows.Forms.TextBox
		Friend WithEvents LblGLYear As System.Windows.Forms.Label
		Friend WithEvents Label12 As System.Windows.Forms.Label
		Friend WithEvents LnkLease As System.Windows.Forms.LinkLabel
End Class






