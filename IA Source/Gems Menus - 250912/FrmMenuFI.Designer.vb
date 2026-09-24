<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuFI
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
    Me.BtnAP101inq = New System.Windows.Forms.Button()
    Me.BtnGL107inq = New System.Windows.Forms.Button()
    Me.BtnAP602 = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnPO306inq = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'BtnAP101inq
    '
    Me.BtnAP101inq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnAP101inq.Location = New System.Drawing.Point(161, 117)
    Me.BtnAP101inq.Name = "BtnAP101inq"
    Me.BtnAP101inq.Size = New System.Drawing.Size(224, 24)
    Me.BtnAP101inq.TabIndex = 18
    Me.BtnAP101inq.Text = "Vendor Master Inquiry"
    '
    'BtnGL107inq
    '
    Me.BtnGL107inq.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnGL107inq.Location = New System.Drawing.Point(161, 57)
    Me.BtnGL107inq.Name = "BtnGL107inq"
    Me.BtnGL107inq.Size = New System.Drawing.Size(224, 24)
    Me.BtnGL107inq.TabIndex = 19
    Me.BtnGL107inq.Text = "Account Inquiry"
    '
    'BtnAP602
    '
    Me.BtnAP602.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnAP602.Location = New System.Drawing.Point(161, 87)
    Me.BtnAP602.Name = "BtnAP602"
    Me.BtnAP602.Size = New System.Drawing.Size(224, 24)
    Me.BtnAP602.TabIndex = 20
    Me.BtnAP602.Text = "Check Number Inquiry"
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Label2.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label2.ImageIndex = 4
    Me.Label2.Location = New System.Drawing.Point(12, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(485, 40)
    Me.Label2.TabIndex = 21
    Me.Label2.Text = "Financial Inquiry"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnPO306inq
    '
    Me.BtnPO306inq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BtnPO306inq.Location = New System.Drawing.Point(161, 147)
    Me.BtnPO306inq.Name = "BtnPO306inq"
    Me.BtnPO306inq.Size = New System.Drawing.Size(224, 24)
    Me.BtnPO306inq.TabIndex = 22
    Me.BtnPO306inq.Text = "Purchase Order Inquiry"
    '
    'FrmMenuFI
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(509, 337)
    Me.Controls.Add(Me.BtnPO306inq)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.BtnAP602)
    Me.Controls.Add(Me.BtnGL107inq)
    Me.Controls.Add(Me.BtnAP101inq)
    Me.Name = "FrmMenuFI"
    Me.Text = "Financials Inquiry"
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents BtnAP101inq As System.Windows.Forms.Button
    Friend WithEvents BtnGL107inq As System.Windows.Forms.Button
    Friend WithEvents BtnAP602 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnPO306inq As System.Windows.Forms.Button
End Class
