<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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
    Me.components = New System.ComponentModel.Container()
    Me.TxtErrorMsg = New System.Windows.Forms.TextBox()
    Me.BtnConvert = New System.Windows.Forms.Button()
    Me.ProgBar1 = New System.Windows.Forms.ProgressBar()
    Me.LblMsg = New System.Windows.Forms.Label()
    Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
    Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
    Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
    Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtErrorMsg
        '
        Me.TxtErrorMsg.Location = New System.Drawing.Point(358, 12)
        Me.TxtErrorMsg.Multiline = True
        Me.TxtErrorMsg.Name = "TxtErrorMsg"
        Me.TxtErrorMsg.Size = New System.Drawing.Size(101, 344)
        Me.TxtErrorMsg.TabIndex = 1
        '
        'BtnConvert
        '
        Me.BtnConvert.Location = New System.Drawing.Point(22, 37)
        Me.BtnConvert.Name = "BtnConvert"
        Me.BtnConvert.Size = New System.Drawing.Size(67, 22)
        Me.BtnConvert.TabIndex = 4
        Me.BtnConvert.Text = "Convert"
        Me.BtnConvert.UseVisualStyleBackColor = True
        '
        'ProgBar1
        '
        Me.ProgBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProgBar1.Location = New System.Drawing.Point(106, 40)
        Me.ProgBar1.Name = "ProgBar1"
        Me.ProgBar1.Size = New System.Drawing.Size(196, 19)
        Me.ProgBar1.TabIndex = 23
        '
        'LblMsg
        '
        Me.LblMsg.Location = New System.Drawing.Point(139, 18)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(152, 16)
        Me.LblMsg.TabIndex = 24
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(242, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Set files in /Settings/CnvWorth.xml"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 368)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.ProgBar1)
        Me.Controls.Add(Me.BtnConvert)
        Me.Controls.Add(Me.TxtErrorMsg)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert Worthington Files"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtErrorMsg As System.Windows.Forms.TextBox
  Friend WithEvents BtnConvert As System.Windows.Forms.Button
  Friend WithEvents ProgBar1 As ProgressBar
  Friend WithEvents LblMsg As Label
  Friend WithEvents ErrProv As ErrorProvider
  Friend WithEvents OpenFileDialog1 As OpenFileDialog
  Friend WithEvents Ttp1 As ToolTip
  Friend WithEvents Label1 As Label
End Class
