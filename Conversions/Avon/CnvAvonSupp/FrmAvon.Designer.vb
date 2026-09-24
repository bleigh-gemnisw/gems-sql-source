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
        Me.LblFilePath = New System.Windows.Forms.Label()
        Me.LnkFilePath = New System.Windows.Forms.LinkLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.GroupBox1.Controls.Add(Me.LblFilePath)
        Me.GroupBox1.Controls.Add(Me.LnkFilePath)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox1.TabIndex = 25
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File Details (mvsup.csv)"
        '
        'LblFilePath
        '
        Me.LblFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFilePath.Location = New System.Drawing.Point(72, 16)
        Me.LblFilePath.Name = "LblFilePath"
        Me.LblFilePath.Size = New System.Drawing.Size(324, 36)
        Me.LblFilePath.TabIndex = 67
        '
        'LnkFilePath
        '
        Me.LnkFilePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkFilePath.Location = New System.Drawing.Point(12, 24)
        Me.LnkFilePath.Name = "LnkFilePath"
        Me.LnkFilePath.Size = New System.Drawing.Size(52, 16)
        Me.LnkFilePath.TabIndex = 65
        Me.LnkFilePath.TabStop = True
        Me.LnkFilePath.Text = "File Path"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(398, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "After this Run MV Suppl Install with Only Refresh DMV data checked"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FrmAvon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 166)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblMsg)
        Me.Controls.Add(Me.ProgBar1)
        Me.Controls.Add(Me.BtnConvert)
        Me.Name = "FrmAvon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Convert MV Supp file"
        CType(Me.ErrProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
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
    Friend WithEvents LblFilePath As Label
    Friend WithEvents LnkFilePath As LinkLabel
    Friend WithEvents Label1 As Label
End Class
