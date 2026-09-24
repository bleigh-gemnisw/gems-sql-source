<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWeb
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
    Me.Web = New System.Windows.Forms.WebBrowser()
        Me.SuspendLayout()
        '
        'Web
        '
        Me.Web.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Web.Location = New System.Drawing.Point(0, 0)
        Me.Web.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Web.Name = "Web"
        Me.Web.ScriptErrorsSuppressed = True
        Me.Web.Size = New System.Drawing.Size(844, 379)
        Me.Web.TabIndex = 0
        '
        'FrmWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 379)
        Me.Controls.Add(Me.Web)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "FrmWeb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Web As System.Windows.Forms.WebBrowser
End Class






