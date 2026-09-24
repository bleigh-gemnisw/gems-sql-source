<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBD001D
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label99 = New System.Windows.Forms.Label()
    Me.BtnConfirm = New System.Windows.Forms.Button()
    Me.LblPermDesc = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.LblName = New System.Windows.Forms.Label()
    Me.LblLocNo = New System.Windows.Forms.Label()
    Me.LblLoc = New System.Windows.Forms.Label()
    Me.LblPermitNo = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(186, 63)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(66, 13)
    Me.Label1.TabIndex = 473
    Me.Label1.Text = "Street Name"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(11, 63)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(89, 13)
    Me.Label6.TabIndex = 472
    Me.Label6.Text = "Job Site: Street #"
    '
    'Label99
    '
    Me.Label99.AutoSize = True
    Me.Label99.Location = New System.Drawing.Point(12, 92)
    Me.Label99.Name = "Label99"
    Me.Label99.Size = New System.Drawing.Size(76, 13)
    Me.Label99.TabIndex = 475
    Me.Label99.Text = "Permit Number"
    '
    'BtnConfirm
    '
    Me.BtnConfirm.Location = New System.Drawing.Point(197, 121)
    Me.BtnConfirm.Name = "BtnConfirm"
    Me.BtnConfirm.Size = New System.Drawing.Size(61, 33)
    Me.BtnConfirm.TabIndex = 476
    Me.BtnConfirm.Text = "Confirm"
    Me.BtnConfirm.UseVisualStyleBackColor = True
    '
    'LblPermDesc
    '
    Me.LblPermDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblPermDesc.ForeColor = System.Drawing.Color.Black
    Me.LblPermDesc.Location = New System.Drawing.Point(12, 7)
    Me.LblPermDesc.Name = "LblPermDesc"
    Me.LblPermDesc.Size = New System.Drawing.Size(258, 17)
    Me.LblPermDesc.TabIndex = 488
    Me.LblPermDesc.Text = "<Perm Desc>"
    Me.LblPermDesc.UseMnemonic = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 31)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(69, 13)
    Me.Label2.TabIndex = 489
    Me.Label2.Text = "Owner Name"
    '
    'LblName
    '
    Me.LblName.AutoSize = True
    Me.LblName.Location = New System.Drawing.Point(111, 31)
    Me.LblName.Name = "LblName"
    Me.LblName.Size = New System.Drawing.Size(81, 13)
    Me.LblName.TabIndex = 490
    Me.LblName.Text = "<Owner Name>"
    '
    'LblLocNo
    '
    Me.LblLocNo.AutoSize = True
    Me.LblLocNo.Location = New System.Drawing.Point(106, 63)
    Me.LblLocNo.Name = "LblLocNo"
    Me.LblLocNo.Size = New System.Drawing.Size(54, 13)
    Me.LblLocNo.TabIndex = 491
    Me.LblLocNo.Text = "<Loc No>"
    '
    'LblLoc
    '
    Me.LblLoc.AutoSize = True
    Me.LblLoc.Location = New System.Drawing.Point(258, 63)
    Me.LblLoc.Name = "LblLoc"
    Me.LblLoc.Size = New System.Drawing.Size(60, 13)
    Me.LblLoc.TabIndex = 492
    Me.LblLoc.Text = "<Location>"
    '
    'LblPermitNo
    '
    Me.LblPermitNo.AutoSize = True
    Me.LblPermitNo.Location = New System.Drawing.Point(106, 92)
    Me.LblPermitNo.Name = "LblPermitNo"
    Me.LblPermitNo.Size = New System.Drawing.Size(65, 13)
    Me.LblPermitNo.TabIndex = 493
    Me.LblPermitNo.Text = "<Permit No>"
    '
    'FrmBD001D
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(477, 165)
    Me.Controls.Add(Me.LblPermitNo)
    Me.Controls.Add(Me.LblLoc)
    Me.Controls.Add(Me.LblLocNo)
    Me.Controls.Add(Me.LblName)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.LblPermDesc)
    Me.Controls.Add(Me.BtnConfirm)
    Me.Controls.Add(Me.Label99)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label6)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmBD001D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Confirm Permit Type Change"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents BtnConfirm As System.Windows.Forms.Button
    Friend WithEvents LblPermDesc As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents LblLocNo As System.Windows.Forms.Label
    Friend WithEvents LblLoc As System.Windows.Forms.Label
    Friend WithEvents LblPermitNo As System.Windows.Forms.Label
End Class






