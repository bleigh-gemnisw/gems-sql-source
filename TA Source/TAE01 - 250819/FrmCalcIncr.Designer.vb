<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalcIncr
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
Me.TxtNGross = New System.Windows.Forms.TextBox
Me.Label22 = New System.Windows.Forms.Label
Me.Label1 = New System.Windows.Forms.Label
Me.Label2 = New System.Windows.Forms.Label
Me.BtnOK = New System.Windows.Forms.Button
Me.BtnCancel = New System.Windows.Forms.Button
Me.LblAmount = New System.Windows.Forms.Label
Me.LblGross = New System.Windows.Forms.Label
Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'TxtNGross
'
Me.TxtNGross.Location = New System.Drawing.Point(103, 28)
Me.TxtNGross.MaxLength = 12
Me.TxtNGross.Name = "TxtNGross"
Me.TxtNGross.Size = New System.Drawing.Size(82, 20)
Me.TxtNGross.TabIndex = 61
Me.TxtNGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label22
'
Me.Label22.Location = New System.Drawing.Point(34, 31)
Me.Label22.Name = "Label22"
Me.Label22.Size = New System.Drawing.Size(69, 17)
Me.Label22.TabIndex = 62
Me.Label22.Text = "New Gross"
'
'Label1
'
Me.Label1.Location = New System.Drawing.Point(34, 61)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(69, 17)
Me.Label1.TabIndex = 63
Me.Label1.Text = "Gross"
'
'Label2
'
Me.Label2.Location = New System.Drawing.Point(34, 90)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(69, 17)
Me.Label2.TabIndex = 64
Me.Label2.Text = "Amount"
'
'BtnOK
'
Me.BtnOK.Location = New System.Drawing.Point(42, 123)
Me.BtnOK.Name = "BtnOK"
Me.BtnOK.Size = New System.Drawing.Size(61, 32)
Me.BtnOK.TabIndex = 65
Me.BtnOK.Text = "OK"
Me.BtnOK.UseVisualStyleBackColor = True
'
'BtnCancel
'
Me.BtnCancel.Location = New System.Drawing.Point(120, 123)
Me.BtnCancel.Name = "BtnCancel"
Me.BtnCancel.Size = New System.Drawing.Size(61, 32)
Me.BtnCancel.TabIndex = 66
Me.BtnCancel.Text = "Cancel"
Me.BtnCancel.UseVisualStyleBackColor = True
'
'LblAmount
'
Me.LblAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblAmount.Location = New System.Drawing.Point(113, 91)
Me.LblAmount.Name = "LblAmount"
Me.LblAmount.Size = New System.Drawing.Size(72, 16)
Me.LblAmount.TabIndex = 67
Me.LblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'LblGross
'
Me.LblGross.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
Me.LblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
Me.LblGross.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.LblGross.Location = New System.Drawing.Point(113, 59)
Me.LblGross.Name = "LblGross"
Me.LblGross.Size = New System.Drawing.Size(72, 16)
Me.LblGross.TabIndex = 68
Me.LblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'ErrProv
'
Me.ErrProv.ContainerControl = Me
'
'FrmCalcIncr
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(223, 176)
Me.Controls.Add(Me.LblGross)
Me.Controls.Add(Me.LblAmount)
Me.Controls.Add(Me.BtnCancel)
Me.Controls.Add(Me.BtnOK)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.TxtNGross)
Me.Controls.Add(Me.Label22)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmCalcIncr"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Calculate Increase Amount"
CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents TxtNGross As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnOK As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents LblAmount As System.Windows.Forms.Label
    Friend WithEvents LblGross As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
End Class






