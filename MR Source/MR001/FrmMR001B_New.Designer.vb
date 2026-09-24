<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMR001B_New
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.DtPckStart = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.DtPckEnd = New System.Windows.Forms.DateTimePicker()
    Me.TxtDescr = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.LblCodes = New System.Windows.Forms.Label()
    Me.BtnSelCodes = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'BtnCreate
    '
    Me.BtnCreate.Location = New System.Drawing.Point(179, 178)
    Me.BtnCreate.Name = "BtnCreate"
    Me.BtnCreate.Size = New System.Drawing.Size(84, 37)
    Me.BtnCreate.TabIndex = 1
    Me.BtnCreate.Text = "Create Batch"
    Me.BtnCreate.UseVisualStyleBackColor = True
    '
    'LblDtInt
    '
    Me.LblDtInt.Location = New System.Drawing.Point(12, 18)
    Me.LblDtInt.Name = "LblDtInt"
    Me.LblDtInt.Size = New System.Drawing.Size(72, 16)
    Me.LblDtInt.TabIndex = 246
    Me.LblDtInt.Text = "Receipt Date"
    '
    'DtPckReceipt
    '
    Me.DtPckReceipt.Checked = False
    Me.DtPckReceipt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckReceipt.Location = New System.Drawing.Point(88, 14)
    Me.DtPckReceipt.Name = "DtPckReceipt"
    Me.DtPckReceipt.Size = New System.Drawing.Size(83, 20)
    Me.DtPckReceipt.TabIndex = 245
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 44)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 16)
    Me.Label1.TabIndex = 248
    Me.Label1.Text = "Period Start"
    '
    'DtPckStart
    '
    Me.DtPckStart.Checked = False
    Me.DtPckStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckStart.Location = New System.Drawing.Point(88, 40)
    Me.DtPckStart.Name = "DtPckStart"
    Me.DtPckStart.Size = New System.Drawing.Size(83, 20)
    Me.DtPckStart.TabIndex = 247
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 73)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(72, 16)
    Me.Label2.TabIndex = 250
    Me.Label2.Text = "Period End"
    '
    'DtPckEnd
    '
    Me.DtPckEnd.Checked = False
    Me.DtPckEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.DtPckEnd.Location = New System.Drawing.Point(88, 69)
    Me.DtPckEnd.Name = "DtPckEnd"
    Me.DtPckEnd.Size = New System.Drawing.Size(83, 20)
    Me.DtPckEnd.TabIndex = 249
    '
    'TxtDescr
    '
    Me.TxtDescr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDescr.Location = New System.Drawing.Point(88, 100)
    Me.TxtDescr.MaxLength = 25
    Me.TxtDescr.Name = "TxtDescr"
    Me.TxtDescr.Size = New System.Drawing.Size(233, 20)
    Me.TxtDescr.TabIndex = 251
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(12, 104)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(72, 16)
    Me.Label5.TabIndex = 252
    Me.Label5.Text = "Description"
    Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'LblCodes
    '
    Me.LblCodes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblCodes.ForeColor = System.Drawing.Color.Fuchsia
    Me.LblCodes.Location = New System.Drawing.Point(7, 133)
    Me.LblCodes.Name = "LblCodes"
    Me.LblCodes.Size = New System.Drawing.Size(324, 43)
    Me.LblCodes.TabIndex = 254
    Me.LblCodes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnSelCodes
    '
    Me.BtnSelCodes.Location = New System.Drawing.Point(73, 179)
    Me.BtnSelCodes.Name = "BtnSelCodes"
    Me.BtnSelCodes.Size = New System.Drawing.Size(87, 35)
    Me.BtnSelCodes.TabIndex = 253
    Me.BtnSelCodes.Text = "Select Codes"
    Me.BtnSelCodes.UseVisualStyleBackColor = True
    '
    'FrmMR001B_New
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(343, 225)
    Me.ControlBox = False
    Me.Controls.Add(Me.LblCodes)
    Me.Controls.Add(Me.BtnSelCodes)
    Me.Controls.Add(Me.TxtDescr)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.DtPckEnd)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DtPckStart)
    Me.Controls.Add(Me.LblDtInt)
    Me.Controls.Add(Me.DtPckReceipt)
    Me.Controls.Add(Me.BtnCreate)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "FrmMR001B_New"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Create New Batch"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents BtnCreate As System.Windows.Forms.Button
  Friend WithEvents LblDtInt As System.Windows.Forms.Label
  Friend WithEvents DtPckReceipt As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents DtPckStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents DtPckEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents TxtDescr As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LblCodes As Label
  Friend WithEvents BtnSelCodes As Button
End Class
