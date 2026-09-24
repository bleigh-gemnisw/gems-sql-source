<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTX340B
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
    Me.TxtAddr1 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtListNo = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.DtPckDue = New System.Windows.Forms.DateTimePicker()
    Me.RbClear = New System.Windows.Forms.Button()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TxtAddr2 = New System.Windows.Forms.TextBox()
    Me.TxtAddr3 = New System.Windows.Forms.TextBox()
    Me.TxtAddr4 = New System.Windows.Forms.TextBox()
    Me.TxtAddr5 = New System.Windows.Forms.TextBox()
    Me.DtPckGrace = New System.Windows.Forms.DateTimePicker()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.TxtPropDesc = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.TxtTax = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TxtMsg2 = New System.Windows.Forms.TextBox()
    Me.TxtMsg1 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TxtGross = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.TxtExam = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.TxtNet = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.TxtMillRate = New System.Windows.Forms.TextBox()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RbStmt = New System.Windows.Forms.RadioButton()
    Me.RbBill = New System.Windows.Forms.RadioButton()
    Me.TxtLine1 = New System.Windows.Forms.TextBox()
    Me.TxtLine5 = New System.Windows.Forms.TextBox()
    Me.TxtLine4 = New System.Windows.Forms.TextBox()
    Me.TxtLine3 = New System.Windows.Forms.TextBox()
    Me.TxtLine2 = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.TxtPayTo = New System.Windows.Forms.TextBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.RbRE = New System.Windows.Forms.RadioButton()
    Me.RbPP = New System.Windows.Forms.RadioButton()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TxtAddr1
    '
    Me.TxtAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr1.Location = New System.Drawing.Point(339, 173)
    Me.TxtAddr1.MaxLength = 35
    Me.TxtAddr1.Name = "TxtAddr1"
    Me.TxtAddr1.Size = New System.Drawing.Size(272, 20)
    Me.TxtAddr1.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(336, 157)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(135, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Tax Payer Mailing Address:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(15, 24)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(33, 13)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "List #"
    '
    'TxtListNo
    '
    Me.TxtListNo.Location = New System.Drawing.Point(18, 40)
    Me.TxtListNo.MaxLength = 7
    Me.TxtListNo.Name = "TxtListNo"
    Me.TxtListNo.Size = New System.Drawing.Size(58, 20)
    Me.TxtListNo.TabIndex = 0
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(15, 304)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(53, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Due Date"
    '
    'DtPckDue
    '
    Me.DtPckDue.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckDue.Location = New System.Drawing.Point(13, 320)
    Me.DtPckDue.Name = "DtPckDue"
    Me.DtPckDue.Size = New System.Drawing.Size(91, 20)
    Me.DtPckDue.TabIndex = 10
    '
    'RbClear
    '
    Me.RbClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.RbClear.ForeColor = System.Drawing.Color.Black
    Me.RbClear.Location = New System.Drawing.Point(532, 434)
    Me.RbClear.Name = "RbClear"
    Me.RbClear.Size = New System.Drawing.Size(79, 34)
    Me.RbClear.TabIndex = 19
    Me.RbClear.Text = "Clear Form"
    Me.RbClear.UseVisualStyleBackColor = True
    Me.RbClear.Visible = False
    '
    'TxtYear
    '
    Me.TxtYear.Location = New System.Drawing.Point(82, 40)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(36, 20)
    Me.TxtYear.TabIndex = 1
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(81, 24)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(29, 13)
    Me.Label6.TabIndex = 321
    Me.Label6.Text = "Year"
    '
    'TxtAddr2
    '
    Me.TxtAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr2.Location = New System.Drawing.Point(339, 194)
    Me.TxtAddr2.MaxLength = 35
    Me.TxtAddr2.Name = "TxtAddr2"
    Me.TxtAddr2.Size = New System.Drawing.Size(272, 20)
    Me.TxtAddr2.TabIndex = 6
    '
    'TxtAddr3
    '
    Me.TxtAddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr3.Location = New System.Drawing.Point(339, 215)
    Me.TxtAddr3.MaxLength = 35
    Me.TxtAddr3.Name = "TxtAddr3"
    Me.TxtAddr3.Size = New System.Drawing.Size(272, 20)
    Me.TxtAddr3.TabIndex = 7
    '
    'TxtAddr4
    '
    Me.TxtAddr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr4.Location = New System.Drawing.Point(339, 236)
    Me.TxtAddr4.MaxLength = 35
    Me.TxtAddr4.Name = "TxtAddr4"
    Me.TxtAddr4.Size = New System.Drawing.Size(272, 20)
    Me.TxtAddr4.TabIndex = 8
    '
    'TxtAddr5
    '
    Me.TxtAddr5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtAddr5.Location = New System.Drawing.Point(339, 257)
    Me.TxtAddr5.MaxLength = 35
    Me.TxtAddr5.Name = "TxtAddr5"
    Me.TxtAddr5.Size = New System.Drawing.Size(272, 20)
    Me.TxtAddr5.TabIndex = 9
    '
    'DtPckGrace
    '
    Me.DtPckGrace.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckGrace.Location = New System.Drawing.Point(111, 320)
    Me.DtPckGrace.Name = "DtPckGrace"
    Me.DtPckGrace.Size = New System.Drawing.Size(91, 20)
    Me.DtPckGrace.TabIndex = 11
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(108, 304)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(62, 13)
    Me.Label9.TabIndex = 333
    Me.Label9.Text = "Grace Date"
    '
    'TxtPropDesc
    '
    Me.TxtPropDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPropDesc.Location = New System.Drawing.Point(120, 40)
    Me.TxtPropDesc.MaxLength = 35
    Me.TxtPropDesc.Name = "TxtPropDesc"
    Me.TxtPropDesc.Size = New System.Drawing.Size(272, 20)
    Me.TxtPropDesc.TabIndex = 2
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(125, 24)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(105, 13)
    Me.Label10.TabIndex = 335
    Me.Label10.Text = "Property Description:"
    '
    'TxtTax
    '
    Me.TxtTax.Location = New System.Drawing.Point(365, 371)
    Me.TxtTax.MaxLength = 9
    Me.TxtTax.Name = "TxtTax"
    Me.TxtTax.Size = New System.Drawing.Size(84, 20)
    Me.TxtTax.TabIndex = 16
    Me.TxtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(362, 355)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(87, 13)
    Me.Label2.TabIndex = 339
    Me.Label2.Text = "Tax Amount Due"
    '
    'TxtMsg2
    '
    Me.TxtMsg2.Location = New System.Drawing.Point(13, 448)
    Me.TxtMsg2.MaxLength = 50
    Me.TxtMsg2.Name = "TxtMsg2"
    Me.TxtMsg2.Size = New System.Drawing.Size(377, 20)
    Me.TxtMsg2.TabIndex = 18
    '
    'TxtMsg1
    '
    Me.TxtMsg1.Location = New System.Drawing.Point(13, 427)
    Me.TxtMsg1.MaxLength = 50
    Me.TxtMsg1.Name = "TxtMsg1"
    Me.TxtMsg1.Size = New System.Drawing.Size(377, 20)
    Me.TxtMsg1.TabIndex = 17
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(10, 411)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 341
    Me.Label3.Text = "Message:"
    '
    'TxtGross
    '
    Me.TxtGross.Location = New System.Drawing.Point(13, 371)
    Me.TxtGross.MaxLength = 9
    Me.TxtGross.Name = "TxtGross"
    Me.TxtGross.Size = New System.Drawing.Size(84, 20)
    Me.TxtGross.TabIndex = 12
    Me.TxtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(43, 355)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(34, 13)
    Me.Label11.TabIndex = 344
    Me.Label11.Text = "Gross"
    '
    'TxtExam
    '
    Me.TxtExam.Location = New System.Drawing.Point(106, 371)
    Me.TxtExam.MaxLength = 9
    Me.TxtExam.Name = "TxtExam"
    Me.TxtExam.Size = New System.Drawing.Size(84, 20)
    Me.TxtExam.TabIndex = 13
    Me.TxtExam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(117, 355)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(61, 13)
    Me.Label12.TabIndex = 346
    Me.Label12.Text = "Exemptions"
    '
    'TxtNet
    '
    Me.TxtNet.Location = New System.Drawing.Point(199, 371)
    Me.TxtNet.MaxLength = 9
    Me.TxtNet.Name = "TxtNet"
    Me.TxtNet.Size = New System.Drawing.Size(84, 20)
    Me.TxtNet.TabIndex = 14
    Me.TxtNet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(229, 355)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(24, 13)
    Me.Label13.TabIndex = 348
    Me.Label13.Text = "Net"
    '
    'TxtMillRate
    '
    Me.TxtMillRate.Location = New System.Drawing.Point(290, 371)
    Me.TxtMillRate.MaxLength = 6
    Me.TxtMillRate.Name = "TxtMillRate"
    Me.TxtMillRate.Size = New System.Drawing.Size(66, 20)
    Me.TxtMillRate.TabIndex = 15
    Me.TxtMillRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(299, 355)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(48, 13)
    Me.Label14.TabIndex = 350
    Me.Label14.Text = "Mill Rate"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RbStmt)
    Me.GroupBox1.Controls.Add(Me.RbBill)
    Me.GroupBox1.Controls.Add(Me.TxtLine1)
    Me.GroupBox1.Controls.Add(Me.TxtLine5)
    Me.GroupBox1.Controls.Add(Me.TxtLine4)
    Me.GroupBox1.Controls.Add(Me.TxtLine3)
    Me.GroupBox1.Controls.Add(Me.TxtLine2)
    Me.GroupBox1.Controls.Add(Me.Label8)
    Me.GroupBox1.Controls.Add(Me.TxtPayTo)
    Me.GroupBox1.Controls.Add(Me.Label7)
    Me.GroupBox1.Location = New System.Drawing.Point(13, 66)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(317, 215)
    Me.GroupBox1.TabIndex = 4
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Return payment to"
    '
    'RbStmt
    '
    Me.RbStmt.AutoSize = True
    Me.RbStmt.Location = New System.Drawing.Point(161, 19)
    Me.RbStmt.Name = "RbStmt"
    Me.RbStmt.Size = New System.Drawing.Size(94, 17)
    Me.RbStmt.TabIndex = 1
    Me.RbStmt.Text = "Statement Info"
    Me.RbStmt.UseVisualStyleBackColor = True
    '
    'RbBill
    '
    Me.RbBill.AutoSize = True
    Me.RbBill.Checked = True
    Me.RbBill.Location = New System.Drawing.Point(61, 19)
    Me.RbBill.Name = "RbBill"
    Me.RbBill.Size = New System.Drawing.Size(59, 17)
    Me.RbBill.TabIndex = 0
    Me.RbBill.TabStop = True
    Me.RbBill.Text = "Bill Info"
    Me.RbBill.UseVisualStyleBackColor = True
    '
    'TxtLine1
    '
    Me.TxtLine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine1.Location = New System.Drawing.Point(9, 105)
    Me.TxtLine1.MaxLength = 35
    Me.TxtLine1.Name = "TxtLine1"
    Me.TxtLine1.Size = New System.Drawing.Size(272, 20)
    Me.TxtLine1.TabIndex = 3
    '
    'TxtLine5
    '
    Me.TxtLine5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine5.Location = New System.Drawing.Point(9, 189)
    Me.TxtLine5.MaxLength = 35
    Me.TxtLine5.Name = "TxtLine5"
    Me.TxtLine5.Size = New System.Drawing.Size(272, 20)
    Me.TxtLine5.TabIndex = 7
    '
    'TxtLine4
    '
    Me.TxtLine4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine4.Location = New System.Drawing.Point(9, 168)
    Me.TxtLine4.MaxLength = 35
    Me.TxtLine4.Name = "TxtLine4"
    Me.TxtLine4.Size = New System.Drawing.Size(272, 20)
    Me.TxtLine4.TabIndex = 6
    '
    'TxtLine3
    '
    Me.TxtLine3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine3.Location = New System.Drawing.Point(9, 147)
    Me.TxtLine3.MaxLength = 35
    Me.TxtLine3.Name = "TxtLine3"
    Me.TxtLine3.Size = New System.Drawing.Size(272, 20)
    Me.TxtLine3.TabIndex = 5
    '
    'TxtLine2
    '
    Me.TxtLine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtLine2.Location = New System.Drawing.Point(9, 126)
    Me.TxtLine2.MaxLength = 35
    Me.TxtLine2.Name = "TxtLine2"
    Me.TxtLine2.Size = New System.Drawing.Size(272, 20)
    Me.TxtLine2.TabIndex = 4
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(6, 91)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(99, 13)
    Me.Label8.TabIndex = 337
    Me.Label8.Text = "Bill Return Address:"
    '
    'TxtPayTo
    '
    Me.TxtPayTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtPayTo.Location = New System.Drawing.Point(9, 63)
    Me.TxtPayTo.MaxLength = 35
    Me.TxtPayTo.Name = "TxtPayTo"
    Me.TxtPayTo.Size = New System.Drawing.Size(272, 20)
    Me.TxtPayTo.TabIndex = 2
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(6, 47)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(128, 13)
    Me.Label7.TabIndex = 336
    Me.Label7.Text = "Make Checks payable to:"
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label15.ForeColor = System.Drawing.Color.Red
    Me.Label15.Location = New System.Drawing.Point(80, 3)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(488, 19)
    Me.Label15.TabIndex = 351
    Me.Label15.Text = "Proceed with caution. Information entered will not be validated or saved."
    '
    'RbRE
    '
    Me.RbRE.AutoSize = True
    Me.RbRE.Checked = True
    Me.RbRE.Location = New System.Drawing.Point(502, 41)
    Me.RbRE.Name = "RbRE"
    Me.RbRE.Size = New System.Drawing.Size(80, 17)
    Me.RbRE.TabIndex = 352
    Me.RbRE.TabStop = True
    Me.RbRE.Text = "Real Estate"
    Me.RbRE.UseVisualStyleBackColor = True
    '
    'RbPP
    '
    Me.RbPP.AutoSize = True
    Me.RbPP.Location = New System.Drawing.Point(502, 63)
    Me.RbPP.Name = "RbPP"
    Me.RbPP.Size = New System.Drawing.Size(108, 17)
    Me.RbPP.TabIndex = 353
    Me.RbPP.Text = "Personal Property"
    Me.RbPP.UseVisualStyleBackColor = True
    '
    'FrmTX340B
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(622, 485)
    Me.ControlBox = False
    Me.Controls.Add(Me.RbPP)
    Me.Controls.Add(Me.RbRE)
    Me.Controls.Add(Me.TxtPropDesc)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.TxtMillRate)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.TxtNet)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.TxtExam)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.TxtGross)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.TxtMsg2)
    Me.Controls.Add(Me.TxtMsg1)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.TxtTax)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckGrace)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.TxtAddr5)
    Me.Controls.Add(Me.TxtAddr4)
    Me.Controls.Add(Me.TxtAddr3)
    Me.Controls.Add(Me.TxtAddr2)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.TxtAddr1)
    Me.Controls.Add(Me.RbClear)
    Me.Controls.Add(Me.DtPckDue)
    Me.Controls.Add(Me.TxtListNo)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmTX340B"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents TxtAddr1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtListNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtPckDue As System.Windows.Forms.DateTimePicker
    Friend WithEvents RbClear As System.Windows.Forms.Button
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAddr2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddr3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddr4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtAddr5 As System.Windows.Forms.TextBox
    Friend WithEvents DtPckGrace As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtPropDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtTax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMsg2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtMsg1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtGross As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtExam As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtNet As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtMillRate As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtLine1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLine5 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLine4 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLine3 As System.Windows.Forms.TextBox
    Friend WithEvents TxtLine2 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPayTo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RbStmt As System.Windows.Forms.RadioButton
    Friend WithEvents RbBill As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RbRE As System.Windows.Forms.RadioButton
    Friend WithEvents RbPP As System.Windows.Forms.RadioButton
End Class






