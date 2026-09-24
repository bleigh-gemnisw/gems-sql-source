<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
    Me.LblFramework = New System.Windows.Forms.Label()
    Me.LblCR13 = New System.Windows.Forms.Label()
    Me.LblResult = New System.Windows.Forms.Label()
    Me.LblOS = New System.Windows.Forms.Label()
    Me.BtnCR13 = New System.Windows.Forms.Button()
    Me.BtnRefresh = New System.Windows.Forms.Button()
    Me.BtnNET = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'LblFramework
    '
    Me.LblFramework.AutoSize = True
    Me.LblFramework.Location = New System.Drawing.Point(59, 39)
    Me.LblFramework.Name = "LblFramework"
    Me.LblFramework.Size = New System.Drawing.Size(93, 13)
    Me.LblFramework.TabIndex = 0
    Me.LblFramework.Text = ".NET Framework: "
    '
    'LblCR13
    '
    Me.LblCR13.AutoSize = True
    Me.LblCR13.Location = New System.Drawing.Point(59, 66)
    Me.LblCR13.Name = "LblCR13"
    Me.LblCR13.Size = New System.Drawing.Size(105, 13)
    Me.LblCR13.TabIndex = 3
    Me.LblCR13.Text = "Crystal Reports 2013"
    '
    'LblResult
    '
    Me.LblResult.AutoSize = True
    Me.LblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblResult.Location = New System.Drawing.Point(164, 133)
    Me.LblResult.Name = "LblResult"
    Me.LblResult.Size = New System.Drawing.Size(43, 13)
    Me.LblResult.TabIndex = 4
    Me.LblResult.Text = "Result"
    '
    'LblOS
    '
    Me.LblOS.AutoSize = True
    Me.LblOS.Location = New System.Drawing.Point(61, 9)
    Me.LblOS.Name = "LblOS"
    Me.LblOS.Size = New System.Drawing.Size(28, 13)
    Me.LblOS.TabIndex = 5
    Me.LblOS.Text = "OS: "
    '
    'BtnCR13
    '
    Me.BtnCR13.Location = New System.Drawing.Point(12, 62)
    Me.BtnCR13.Name = "BtnCR13"
    Me.BtnCR13.Size = New System.Drawing.Size(43, 20)
    Me.BtnCR13.TabIndex = 7
    Me.BtnCR13.Text = "Install"
    Me.BtnCR13.UseVisualStyleBackColor = True
    '
    'BtnRefresh
    '
    Me.BtnRefresh.Location = New System.Drawing.Point(298, 133)
    Me.BtnRefresh.Name = "BtnRefresh"
    Me.BtnRefresh.Size = New System.Drawing.Size(60, 20)
    Me.BtnRefresh.TabIndex = 9
    Me.BtnRefresh.Text = "Refresh"
    Me.BtnRefresh.UseVisualStyleBackColor = True
    '
    'BtnNET
    '
    Me.BtnNET.Location = New System.Drawing.Point(12, 35)
    Me.BtnNET.Name = "BtnNET"
    Me.BtnNET.Size = New System.Drawing.Size(43, 20)
    Me.BtnNET.TabIndex = 10
    Me.BtnNET.Text = "Install"
    Me.BtnNET.UseVisualStyleBackColor = True
    '
    'FrmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(370, 160)
    Me.Controls.Add(Me.BtnNET)
    Me.Controls.Add(Me.BtnRefresh)
    Me.Controls.Add(Me.BtnCR13)
    Me.Controls.Add(Me.LblOS)
    Me.Controls.Add(Me.LblResult)
    Me.Controls.Add(Me.LblCR13)
    Me.Controls.Add(Me.LblFramework)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "FrmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "GEMS SQL Software Status"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents LblFramework As System.Windows.Forms.Label
    Friend WithEvents LblCR13 As System.Windows.Forms.Label
    Friend WithEvents LblResult As System.Windows.Forms.Label
    Friend WithEvents LblOS As System.Windows.Forms.Label
  Friend WithEvents BtnCR13 As System.Windows.Forms.Button
  Friend WithEvents BtnRefresh As System.Windows.Forms.Button
  Friend WithEvents BtnNET As System.Windows.Forms.Button

End Class
