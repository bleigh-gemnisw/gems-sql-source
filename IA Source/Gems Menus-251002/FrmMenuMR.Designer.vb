<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuMR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.BtnMR200 = New System.Windows.Forms.Button()
    Me.BtnMR001 = New System.Windows.Forms.Button()
    Me.BtnMR101 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.BackColor = System.Drawing.SystemColors.Control
    Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Label2.Font = New System.Drawing.Font("Cooper Black", 21.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Black
    Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Label2.ImageIndex = 4
    Me.Label2.Location = New System.Drawing.Point(32, 9)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(484, 40)
    Me.Label2.TabIndex = 16
    Me.Label2.Text = "Misc. Receipts"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'BtnMR200
    '
    Me.BtnMR200.Location = New System.Drawing.Point(109, 124)
    Me.BtnMR200.Name = "BtnMR200"
    Me.BtnMR200.Size = New System.Drawing.Size(312, 24)
    Me.BtnMR200.TabIndex = 19
    Me.BtnMR200.Text = "Print History"
    '
    'BtnMR001
    '
    Me.BtnMR001.Location = New System.Drawing.Point(109, 94)
    Me.BtnMR001.Name = "BtnMR001"
    Me.BtnMR001.Size = New System.Drawing.Size(312, 24)
    Me.BtnMR001.TabIndex = 18
    Me.BtnMR001.Text = "Maintain Batches"
    '
    'BtnMR101
    '
    Me.BtnMR101.Location = New System.Drawing.Point(109, 64)
    Me.BtnMR101.Name = "BtnMR101"
    Me.BtnMR101.Size = New System.Drawing.Size(312, 24)
    Me.BtnMR101.TabIndex = 17
    Me.BtnMR101.Text = "Maintain Receipts Codes"
    '
    'FrmMenuMR
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(539, 371)
    Me.Controls.Add(Me.BtnMR200)
    Me.Controls.Add(Me.BtnMR001)
    Me.Controls.Add(Me.BtnMR101)
    Me.Controls.Add(Me.Label2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.KeyPreview = True
    Me.MaximizeBox = False
    Me.Name = "FrmMenuMR"
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnMR200 As System.Windows.Forms.Button
    Friend WithEvents BtnMR001 As System.Windows.Forms.Button
    Friend WithEvents BtnMR101 As System.Windows.Forms.Button
End Class
