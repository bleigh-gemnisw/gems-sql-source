<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMsg
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
    Me.TxtMsg = New System.Windows.Forms.TextBox()
    Me.TxtMsg2 = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'TxtMsg
    '
    Me.TxtMsg.Location = New System.Drawing.Point(24, 12)
    Me.TxtMsg.Multiline = True
    Me.TxtMsg.Name = "TxtMsg"
    Me.TxtMsg.ReadOnly = True
    Me.TxtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtMsg.Size = New System.Drawing.Size(318, 128)
    Me.TxtMsg.TabIndex = 0
    '
    'TxtMsg2
    '
    Me.TxtMsg2.Location = New System.Drawing.Point(24, 146)
    Me.TxtMsg2.Multiline = True
    Me.TxtMsg2.Name = "TxtMsg2"
    Me.TxtMsg2.ReadOnly = True
    Me.TxtMsg2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TxtMsg2.Size = New System.Drawing.Size(318, 235)
    Me.TxtMsg2.TabIndex = 1
    '
    'FrmMsg
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(360, 393)
    Me.Controls.Add(Me.TxtMsg2)
    Me.Controls.Add(Me.TxtMsg)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMsg"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Message"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents TxtMsg As System.Windows.Forms.TextBox
    Friend WithEvents TxtMsg2 As System.Windows.Forms.TextBox
End Class
