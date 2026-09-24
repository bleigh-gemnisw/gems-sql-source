<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWebView
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
        Me.WebView2 = New Microsoft.Web.WebView2.WinForms.WebView2()
        CType(Me.WebView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WebView2
        '
        Me.WebView2.AllowExternalDrop = True
        Me.WebView2.CreationProperties = Nothing
        Me.WebView2.DefaultBackgroundColor = System.Drawing.Color.White
        Me.WebView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebView2.Location = New System.Drawing.Point(0, 0)
        Me.WebView2.Name = "WebView2"
        Me.WebView2.Size = New System.Drawing.Size(800, 450)
        Me.WebView2.TabIndex = 0
        Me.WebView2.ZoomFactor = 1.0R
        '
        'FrmWebView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.WebView2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmWebView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmWebView"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.WebView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WebView2 As Microsoft.Web.WebView2.WinForms.WebView2
End Class
