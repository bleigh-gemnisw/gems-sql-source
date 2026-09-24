<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTXA01B_New
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
    Me.BtnCreate = New System.Windows.Forms.Button()
    Me.LblDtInt = New System.Windows.Forms.Label()
    Me.DtPckReceipt = New System.Windows.Forms.DateTimePicker()
    Me.DtPckInterest = New System.Windows.Forms.DateTimePicker()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.CboBatch = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'BtnCreate
    '
    Me.BtnCreate.Location = New System.Drawing.Point(66, 122)
    Me.BtnCreate.Name = "BtnCreate"
    Me.BtnCreate.Size = New System.Drawing.Size(84, 37)
    Me.BtnCreate.TabIndex = 3
    Me.BtnCreate.Text = "Create Batch"
    Me.BtnCreate.UseVisualStyleBackColor = True
    '
    'LblDtInt
    '
    Me.LblDtInt.Location = New System.Drawing.Point(11, 91)
    Me.LblDtInt.Name = "LblDtInt"
    Me.LblDtInt.Size = New System.Drawing.Size(72, 16)
    Me.LblDtInt.TabIndex = 246
    Me.LblDtInt.Text = "Receipt Date"
    '
    'DtPckReceipt
    '
    Me.DtPckReceipt.Checked = False
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(87, 87)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(83, 20)
    Me.DtPckReceipt.TabIndex = 2
    '
    'DtPckInterest
    '
    Me.DtPckInterest.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckInterest.Location = New System.Drawing.Point(86, 61)
    Me.DtPckInterest.Name = "DtPckInterest"
    Me.DtPckInterest.Size = New System.Drawing.Size(84, 20)
    Me.DtPckInterest.TabIndex = 1
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 64)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(68, 13)
    Me.Label3.TabIndex = 248
    Me.Label3.Text = "Interest Date"
    '
    'CboBatch
    '
    Me.CboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.CboBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.CboBatch.FormattingEnabled = True
    Me.CboBatch.Location = New System.Drawing.Point(76, 28)
    Me.CboBatch.Name = "CboBatch"
    Me.CboBatch.Size = New System.Drawing.Size(117, 21)
    Me.CboBatch.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(2, 31)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(62, 13)
    Me.Label1.TabIndex = 251
    Me.Label1.Text = "Batch Type"
    '
    'FrmTXA01B_New
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(205, 177)
    Me.ControlBox = False
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.CboBatch)
    Me.Controls.Add(Me.DtPckInterest)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.LblDtInt)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.BtnCreate)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmTXA01B_New"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Create New Batch"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents BtnCreate As System.Windows.Forms.Button
  Friend WithEvents LblDtInt As System.Windows.Forms.Label
  Friend WithEvents DtPckReceipt As System.Windows.Forms.DateTimePicker
  Friend WithEvents DtPckInterest As DateTimePicker
  Friend WithEvents Label3 As Label
  Friend WithEvents CboBatch As ComboBox
  Friend WithEvents Label1 As Label
End Class






