<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGLA02B_New
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
Me.BtnCreate = New System.Windows.Forms.Button
Me.LnkGLFund = New System.Windows.Forms.LinkLabel
Me.TxtFund = New System.Windows.Forms.TextBox
Me.TxtDescr = New System.Windows.Forms.TextBox
Me.Label7 = New System.Windows.Forms.Label
Me.Label3 = New System.Windows.Forms.Label
Me.DtPckPost = New System.Windows.Forms.DateTimePicker
Me.SuspendLayout()
'
'BtnCreate
'
Me.BtnCreate.Location = New System.Drawing.Point(86, 109)
Me.BtnCreate.Name = "BtnCreate"
Me.BtnCreate.Size = New System.Drawing.Size(84, 37)
Me.BtnCreate.TabIndex = 3
Me.BtnCreate.Text = "Create Batch"
Me.BtnCreate.UseVisualStyleBackColor = True
'
'LnkGLFund
'
Me.LnkGLFund.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LnkGLFund.ForeColor = System.Drawing.Color.Maroon
Me.LnkGLFund.Location = New System.Drawing.Point(39, 18)
Me.LnkGLFund.Name = "LnkGLFund"
Me.LnkGLFund.Size = New System.Drawing.Size(36, 18)
Me.LnkGLFund.TabIndex = 9
Me.LnkGLFund.TabStop = True
Me.LnkGLFund.Text = "Fund"
'
'TxtFund
'
Me.TxtFund.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtFund.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.TxtFund.Location = New System.Drawing.Point(86, 14)
Me.TxtFund.MaxLength = 3
Me.TxtFund.Name = "TxtFund"
Me.TxtFund.Size = New System.Drawing.Size(32, 22)
Me.TxtFund.TabIndex = 0
'
'TxtDescr
'
Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
Me.TxtDescr.Location = New System.Drawing.Point(86, 71)
Me.TxtDescr.MaxLength = 20
Me.TxtDescr.Name = "TxtDescr"
Me.TxtDescr.Size = New System.Drawing.Size(164, 20)
Me.TxtDescr.TabIndex = 2
'
'Label7
'
Me.Label7.Location = New System.Drawing.Point(12, 72)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(68, 16)
Me.Label7.TabIndex = 25
Me.Label7.Text = "Description"
Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'Label3
'
Me.Label3.Location = New System.Drawing.Point(10, 49)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(70, 16)
Me.Label3.TabIndex = 27
Me.Label3.Text = "Posting Date"
'
'DtPckPost
'
Me.DtPckPost.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.DtPckPost.Location = New System.Drawing.Point(86, 45)
Me.DtPckPost.Name = "DtPckPost"
Me.DtPckPost.Size = New System.Drawing.Size(88, 20)
Me.DtPckPost.TabIndex = 1
Me.DtPckPost.Value = New Date(2005, 10, 6, 9, 11, 0, 953)
'
'FrmGLA02B_New
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(259, 170)
Me.ControlBox = False
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.DtPckPost)
Me.Controls.Add(Me.TxtDescr)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.LnkGLFund)
Me.Controls.Add(Me.TxtFund)
Me.Controls.Add(Me.BtnCreate)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.Name = "FrmGLA02B_New"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
Me.Text = "Create New Batch"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
		Friend WithEvents BtnCreate As System.Windows.Forms.Button
	Friend WithEvents LnkGLFund As System.Windows.Forms.LinkLabel
	Friend WithEvents TxtFund As System.Windows.Forms.TextBox
 Friend WithEvents TxtDescr As System.Windows.Forms.TextBox
 Friend WithEvents Label7 As System.Windows.Forms.Label
 Friend WithEvents Label3 As System.Windows.Forms.Label
 Friend WithEvents DtPckPost As System.Windows.Forms.DateTimePicker
End Class
