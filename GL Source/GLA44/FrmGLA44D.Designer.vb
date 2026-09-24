<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGLA44D
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
    Me.components = New System.ComponentModel.Container()
    Me.TxtDspct = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.TxtYear = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TxtDspct
    '
    Me.TxtDspct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtDspct.Location = New System.Drawing.Point(121, 46)
    Me.TxtDspct.MaxLength = 9
    Me.TxtDspct.Name = "TxtDspct"
    Me.TxtDspct.Size = New System.Drawing.Size(72, 20)
    Me.TxtDspct.TabIndex = 354
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(12, 49)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(103, 20)
    Me.Label4.TabIndex = 355
    Me.Label4.Text = "Debt Service Rate"
    '
    'TxtYear
    '
    Me.TxtYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.TxtYear.Location = New System.Drawing.Point(121, 15)
    Me.TxtYear.MaxLength = 4
    Me.TxtYear.Name = "TxtYear"
    Me.TxtYear.Size = New System.Drawing.Size(32, 20)
    Me.TxtYear.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 18)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(103, 20)
    Me.Label1.TabIndex = 357
    Me.Label1.Text = "Year"
    '
    'ErrProv
    '
    Me.ErrProv.ContainerControl = Me
    '
    'FrmGLA44D
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(203, 87)
    Me.Controls.Add(Me.TxtYear)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TxtDspct)
    Me.Controls.Add(Me.Label4)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmGLA44D"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Tag = ""
    Me.Text = "Debt Service"
    CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents TxtDspct As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtYear As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ErrProv As System.Windows.Forms.ErrorProvider
    Friend WithEvents Ttp1 As System.Windows.Forms.ToolTip
End Class
