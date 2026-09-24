<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDltBch
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
    Me.BtnDelete = New System.Windows.Forms.Button()
    Me.BtnCancel = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'BtnDelete
    '
    Me.BtnDelete.Location = New System.Drawing.Point(121, 35)
    Me.BtnDelete.Name = "BtnDelete"
    Me.BtnDelete.Size = New System.Drawing.Size(58, 48)
    Me.BtnDelete.TabIndex = 0
    Me.BtnDelete.Text = "Delete Batch"
    Me.BtnDelete.UseVisualStyleBackColor = True
    '
    'BtnCancel
    '
    Me.BtnCancel.Location = New System.Drawing.Point(201, 35)
    Me.BtnCancel.Name = "BtnCancel"
    Me.BtnCancel.Size = New System.Drawing.Size(58, 48)
    Me.BtnCancel.TabIndex = 2
    Me.BtnCancel.Text = "Cancel"
    Me.BtnCancel.UseVisualStyleBackColor = True
    '
    'FrmDltBch
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(411, 126)
    Me.ControlBox = False
    Me.Controls.Add(Me.BtnCancel)
    Me.Controls.Add(Me.BtnDelete)
    Me.Name = "FrmDltBch"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Confirm Delete Batch"
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
End Class
