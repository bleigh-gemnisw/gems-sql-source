<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAvon
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
        Me.BtnConvert = New System.Windows.Forms.Button()
        Me.ProgBar1 = New System.Windows.Forms.ProgressBar()
        Me.LblMsg = New System.Windows.Forms.Label()
        Me.ErrProv = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Ttp1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblFilePathRE = New System.Windows.Forms.Label()
        Me.LnkFilePathRE = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LblFilePathPP = New System.Windows.Forms.Label()
        Me.LnkFilePathPP = New System.Windows.Forms.LinkLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblFilePathMV = New System.Windows.Forms.Label()
        Me.LnkFilePathMV = New System.Windows.Forms.LinkLabel()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnConvert
        '
        Me.BtnConvert.Location = New System.Drawing.Point(124, 37)
        Me.BtnConvert.Name = "BtnConvert"
        Me.BtnConvert.Size = New System.Drawing.Size(67, 22)
        Me.BtnConvert.TabIndex = 4
        Me.BtnConvert.Text = "Convert"
        Me.BtnConvert.UseVisualStyleBackColor = True
        '
        'ProgBar1
        '
        Me.ProgBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProgBar1.Location = New System.Drawing.Point(197, 40)
        Me.ProgBar1.Name = "ProgBar1"
        Me.ProgBar1.Size = New System.Drawing.Size(196, 19)
        Me.ProgBar1.TabIndex = 23
        '
        'LblMsg
        '
        Me.LblMsg.Location = New System.Drawing.Point(121, 74)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(152, 16)
        Me.LblMsg.TabIndex = 24
        Me.LblMsg.Text = "<Message>"
        Me.LblMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ErrProv
        '
        Me.ErrProv.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblFilePathRE)
        Me.GroupBox1.Controls.Add(Me.LnkFilePathRE)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RE File Details (Admin.csv)"
        '
        'LblFilePathRE
        '
        Me.LblFilePathRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilePathRE.Location = New System.Drawing.Point(72, 16)
        Me.LblFilePathRE.Name = "LblFilePathRE"
        Me.LblFilePathRE.Size = New System.Drawing.Size(324, 36)
        Me.LblFilePathRE.TabIndex = 67
        '
        'LnkFilePathRE
        '
        Me.LnkFilePathRE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkFilePathRE.Location = New System.Drawing.Point(12, 24)
        Me.LnkFilePathRE.Name = "LnkFilePathRE"
        Me.LnkFilePathRE.Size = New System.Drawing.Size(52, 16)
        Me.LnkFilePathRE.TabIndex = 65
        Me.LnkFilePathRE.TabStop = True
        Me.LnkFilePathRE.Text = "File Path"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "After this Run MV Install with Only Refresh DMV data checked"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LblFilePathPP)
        Me.GroupBox2.Controls.Add(Me.LnkFilePathPP)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox2.TabIndex = 27
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PP File Details (pp.csv)"
        '
        'LblFilePathPP
        '
        Me.LblFilePathPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilePathPP.Location = New System.Drawing.Point(72, 16)
        Me.LblFilePathPP.Name = "LblFilePathPP"
        Me.LblFilePathPP.Size = New System.Drawing.Size(324, 36)
        Me.LblFilePathPP.TabIndex = 67
        '
        'LnkFilePathPP
        '
        Me.LnkFilePathPP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkFilePathPP.Location = New System.Drawing.Point(12, 24)
        Me.LnkFilePathPP.Name = "LnkFilePathPP"
        Me.LnkFilePathPP.Size = New System.Drawing.Size(52, 16)
        Me.LnkFilePathPP.TabIndex = 65
        Me.LnkFilePathPP.TabStop = True
        Me.LnkFilePathPP.Text = "File Path"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LblFilePathMV)
        Me.GroupBox3.Controls.Add(Me.LnkFilePathMV)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 227)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MV File Details (mv.csv)"
        '
        'LblFilePathMV
        '
        Me.LblFilePathMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilePathMV.Location = New System.Drawing.Point(72, 16)
        Me.LblFilePathMV.Name = "LblFilePathMV"
        Me.LblFilePathMV.Size = New System.Drawing.Size(324, 36)
        Me.LblFilePathMV.TabIndex = 67
        '
        'LnkFilePathMV
        '
        Me.LnkFilePathMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkFilePathMV.Location = New System.Drawing.Point(12, 24)
        Me.LnkFilePathMV.Name = "LnkFilePathMV"
        Me.LnkFilePathMV.Size = New System.Drawing.Size(52, 16)
        Me.LnkFilePathMV.TabIndex = 65
        Me.LnkFilePathMV.TabStop = True
        Me.LnkFilePathMV.Text = "File Path"
        '
        'FrmAvon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 295)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.ProgBar1)
        Me.Controls.Add(Me.BtnConvert)
        Me.Name = "FrmAvon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert RE, PP and MV files"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnConvert As System.Windows.Forms.Button
    Friend WithEvents ProgBar1 As ProgressBar
    Friend WithEvents LblMsg As Label
    Friend WithEvents ErrProv As ErrorProvider
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Ttp1 As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblFilePathRE As Label
    Friend WithEvents LnkFilePathRE As LinkLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents LblFilePathMV As Label
    Friend WithEvents LnkFilePathMV As LinkLabel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LblFilePathPP As Label
    Friend WithEvents LnkFilePathPP As LinkLabel
End Class
