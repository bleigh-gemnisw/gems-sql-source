<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIA003D
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
Me.BtnImport = New System.Windows.Forms.Button
Me.BtnExport = New System.Windows.Forms.Button
Me.SuspendLayout()
'
'BtnImport
'
Me.BtnImport.Location = New System.Drawing.Point(66, 25)
Me.BtnImport.Name = "BtnImport"
Me.BtnImport.Size = New System.Drawing.Size(118, 39)
Me.BtnImport.TabIndex = 0
Me.BtnImport.Text = "Import data"
Me.BtnImport.UseVisualStyleBackColor = True
'
'BtnExport
'
Me.BtnExport.Location = New System.Drawing.Point(66, 81)
Me.BtnExport.Name = "BtnExport"
Me.BtnExport.Size = New System.Drawing.Size(118, 39)
Me.BtnExport.TabIndex = 1
Me.BtnExport.Text = "Export data"
Me.BtnExport.UseVisualStyleBackColor = True
'
'FrmIA003D
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(252, 165)
Me.Controls.Add(Me.BtnExport)
Me.Controls.Add(Me.BtnImport)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "FrmIA003D"
Me.Text = "FTP Interface"
Me.ResumeLayout(False)

End Sub
		Friend WithEvents BtnImport As System.Windows.Forms.Button
	Friend WithEvents BtnExport As System.Windows.Forms.Button
End Class
