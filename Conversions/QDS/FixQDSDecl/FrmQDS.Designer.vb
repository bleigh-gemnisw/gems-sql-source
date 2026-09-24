<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmQDS
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
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
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Me.TxtErrorMsg = New System.Windows.Forms.TextBox()
    Me.BtnConvert = New System.Windows.Forms.Button()
        Me.ProgBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TxtErrorMsg
        '
        Me.TxtErrorMsg.Location = New System.Drawing.Point(224, 12)
        Me.TxtErrorMsg.Multiline = True
        Me.TxtErrorMsg.Name = "TxtErrorMsg"
        Me.TxtErrorMsg.Size = New System.Drawing.Size(235, 344)
        Me.TxtErrorMsg.TabIndex = 1
        '
        'BtnConvert
        '
        Me.BtnConvert.Location = New System.Drawing.Point(92, 34)
        Me.BtnConvert.Name = "BtnConvert"
        Me.BtnConvert.Size = New System.Drawing.Size(67, 22)
        Me.BtnConvert.TabIndex = 4
        Me.BtnConvert.Text = "Convert"
        Me.BtnConvert.UseVisualStyleBackColor = True
        '
        'ProgBar1
        '
        Me.ProgBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProgBar1.Location = New System.Drawing.Point(12, 82)
        Me.ProgBar1.Name = "ProgBar1"
        Me.ProgBar1.Size = New System.Drawing.Size(196, 19)
        Me.ProgBar1.TabIndex = 23
        '
        'LblMsg
        '
        Me.LblMsg.Location = New System.Drawing.Point(39, 63)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(152, 16)
        Me.LblMsg.TabIndex = 24
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FrmQDS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 368)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.ProgBar1)
        Me.Controls.Add(Me.BtnConvert)
        Me.Controls.Add(Me.TxtErrorMsg)
        Me.Name = "FrmQDS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fix QDS PP Decl Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtErrorMsg As System.Windows.Forms.TextBox
  Friend WithEvents BtnConvert As System.Windows.Forms.Button
    Friend WithEvents ProgBar1 As ProgressBar
    Friend WithEvents LblMsg As Label
End Class
